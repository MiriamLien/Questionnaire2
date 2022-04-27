using questionnaire.Managers;
using questionnaire.Models;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace questionnaire.BackAdmin
{
    public partial class mainPageA : System.Web.UI.Page
    {
        //private bool _isEditMode = false;

        private QuesContentsManager _mgrQuesContents = new QuesContentsManager();
        private QuesDetailManager _mgrQuesDetail = new QuesDetailManager();
        private QuesTypeManager _mgrQuesType = new QuesTypeManager();
        private CQManager _mgrCQ = new CQManager();
        private UserInfoManager _mgruserInfo = new UserInfoManager();
        private UserQuesDetailManager _mgruserQuesDetail = new UserQuesDetailManager();
        Guid id = Guid.NewGuid();

        protected void Page_Load(object sender, EventArgs e)    //編輯模式
        {
            if (!IsPostBack)
            {
                string idText = Request.QueryString["ID"];
                Guid questionnaireID = Guid.Parse(idText);

                // 如果沒有帶 id ，跳回列表頁
                if (string.IsNullOrWhiteSpace(idText))
                    this.BackToListPage();

                Guid iD;
                if (!Guid.TryParse(idText, out iD))
                    this.BackToListPage();

                // 帶入問卷內容
                var QList = this._mgrQuesContents.GetQuesContent(questionnaireID);
                this.txtTitle.Text = QList.Title;
                this.txtContent.Text = QList.Body;
                this.txtStartDate.Text = QList.StartDate.ToString("yyyy-MM-dd");
                this.txtEndDate.Text = QList.EndDate.ToString("yyyy-MM-dd");
                this.ckbPaperEnable.Checked = QList.IsEnable;

                // 帶入問題內容
                var questionList = this._mgrQuesDetail.GetQuesDetailAndTypeList(questionnaireID);
                this.rptQuestion.DataSource = questionList;
                this.rptQuestion.DataBind();               

                //問題類型下拉繫結
                var QTypeList = this._mgrQuesType.GetQuesTypesList();
                this.ddlAnsType.DataSource = QTypeList;
                this.ddlAnsType.DataValueField = "QuesTypeID";
                this.ddlAnsType.DataTextField = "QuesType1";
                this.ddlAnsType.DataBind();

                //自訂、常用問題下拉繫結
                var TypeList = this._mgrCQ.GetCQsList();
                this.ddlQuesType.DataSource = TypeList;
                this.ddlQuesType.DataValueField = "CQID";
                this.ddlQuesType.DataTextField = "CQTitle";
                this.ddlQuesType.DataBind();

                this.ddlQuesType.Items.Insert(0, new ListItem("自訂問題", "0"));

                if (questionList != null || questionList.Count > 0)
                {
                    // 生成問題編號
                    int i = 1;
                    foreach (RepeaterItem item in this.rptQuestion.Items)
                    {
                        Literal ltlNum = item.FindControl("ltlNum") as Literal;
                        ltlNum.Text = i.ToString();
                        i++;
                    }
                }
                
                // 填寫資料頁籤(使用者資料)
                var userInfo = this._mgruserInfo.GetUserInfoList(questionnaireID);
                this.rptUserInfo.DataSource = userInfo;
                this.rptUserInfo.DataBind();

                if (questionList != null || questionList.Count > 0)
                {
                    // 生成問題編號
                    int i = 1;
                    foreach (RepeaterItem item in this.rptUserInfo.Items)
                    {
                        Literal ltlNum = item.FindControl("ltlNum") as Literal;
                        ltlNum.Text = i.ToString();
                        i++;
                    }
                }
            }
        }
        
            //string url = this.Request.Url.LocalPath + "?ID=" + idText;
            //this.Response.Redirect(url);

            #region "問卷"
            protected void btnEditPaperCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("listPageA.aspx");
        }

        // 編輯問卷後送出
        protected void btnEditPaperSend_Click(object sender, EventArgs e)
        {
            string idText = Request.QueryString["ID"];
            Guid questionnaireID = Guid.Parse(idText);
            var q = this._mgrQuesContents.GetQuesContent(questionnaireID);

            string title = this.txtTitle.Text.Trim();
            string content = this.txtContent.Text.Trim();
            if (title != null && content != null)
            {
                QuesContentsModel model = new QuesContentsModel
                {
                    ID = questionnaireID,
                    TitleID = q.TitleID,
                    Title = title,
                    Body = content,
                    StartDate = q.StartDate,
                    EndDate = q.EndDate,
                    IsEnable = q.IsEnable
                };

                this._mgrQuesContents.UpdateQues(model);
            }
            
            Response.Redirect("mainPageA.aspx?ID=" + questionnaireID);
        }
        #endregion


        #region "編輯問題"
        // (問題)點擊編輯鈕
        protected void btnEdit_Command(object sender, CommandEventArgs e)
        {
            this.plcQues.Visible = false;
            this.plcEditQues.Visible = true;

            //取得該問題的資料
            int quesID = Convert.ToInt32(e.CommandName);
            var ques = this._mgrQuesDetail.GetQuesDetail(quesID);

            //問題類型下拉繫結
            var QTypeList = this._mgrQuesType.GetQuesTypesList();
            this.ddlEditAnsType.DataSource = QTypeList;
            this.ddlEditAnsType.DataValueField = "QuesTypeID";
            this.ddlEditAnsType.DataTextField = "QuesType1";
            this.ddlEditAnsType.DataBind();

            //判斷該問題有無答案
            bool hasChoise;
            if (ques.QuesTypeID == 2 || ques.QuesTypeID == 3)
                hasChoise = true;
            else
                hasChoise = false;

            if (!hasChoise)
            {
                this.btnEditCheck.CommandName = ques.QuesID.ToString();
                this.txtEditQuesTitle.Text = ques.QuesTitle.ToString();
                this.ddlEditAnsType.SelectedValue = ques.QuesTypeID.ToString();
                this.ckbEditMustAns.Checked = ques.IsEnable;
            }
            else
            {
                this.btnEditCheck.CommandName = ques.QuesID.ToString();
                this.txtEditQuesTitle.Text = ques.QuesTitle.ToString();
                this.txtEditQuesAns.Text = ques.QuesChoices.ToString();
                this.ddlEditAnsType.SelectedValue = ques.QuesTypeID.ToString();
                this.ckbEditMustAns.Checked = ques.IsEnable;
            }
        }

        // 把問題填入TextBox裡
        protected void btnUse_Click(object sender, EventArgs e)
        {
            int cqid = Convert.ToInt32(this.ddlQuesType.SelectedValue.Trim());
            CQAndTypeModel CQs = this._mgrQuesType.GetCQType(cqid);

            if (CQs != null)
            {
                this.txtQuesTitle.Text = this.ddlQuesType.SelectedItem.ToString();
                this.txtQuesAns.Text = CQs.CQChoices;
                this.ddlAnsType.SelectedIndex = CQs.QuesTypeID - 1;

                var isEnable = CQs.CQIsEnable;
                if (isEnable)
                {
                    this.ckbMustAns.Checked = true;
                }
            }
        }

        // 新增問題至DB(編輯模式)
        protected void btnAdd_Command(object sender, CommandEventArgs e)
        {
            string idText = Request.QueryString["ID"];
            Guid questionnaireID = Guid.Parse(idText);
            var ques = this._mgrQuesContents.GetQuesContent(questionnaireID);

            string q = this.txtQuesTitle.Text.Trim();
            string a = this.txtQuesAns.Text.Trim();

            QuesDetailModel model = new QuesDetailModel()
            {
                ID = ques.ID,
                QuesTitle = q,
                QuesChoices = a,
                QuesTypeID = Convert.ToInt32(this.ddlAnsType.SelectedValue),
                IsEnable = this.ckbMustAns.Checked
            };
            this._mgrQuesDetail.CreateQuesDetail(model);
            Response.Redirect(Request.RawUrl);
        }

        // 問題編輯好後的確認鈕
        protected void btnEditCheck_Command(object sender, CommandEventArgs e)
        {
            string idText = Request.QueryString["ID"];
            Guid questionnaireID = Guid.Parse(idText);

            int quesid = Convert.ToInt32(this.btnEditCheck.CommandName);
            var item = this._mgrQuesDetail.GetQuesDetail(quesid);

            QuesDetailModel model = new QuesDetailModel()
            {
                ID = item.ID,
                QuesID = item.QuesID,
                QuesTitle = this.txtEditQuesTitle.Text,
                QuesChoices = this.txtEditQuesAns.Text,
                QuesTypeID = Convert.ToInt32(this.ddlEditAnsType.SelectedValue),
                IsEnable = this.ckbEditMustAns.Checked
            };

            this._mgrQuesDetail.UpdateQuesDetail(model);
            Response.Redirect("mainPageA.aspx?ID=" + questionnaireID);
        }

        // 取消編輯
        protected void btnEditCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
            this.plcQues.Visible = true;
            this.plcEditQues.Visible = false;
        }
        #endregion

        // 刪除問題
        protected void imgbtnDelete_Click(object sender, ImageClickEventArgs e)
        {
            string idText = Request.QueryString["ID"];
            Guid questionnaireID = Guid.Parse(idText);

            foreach (RepeaterItem item in this.rptQuestion.Items)
            {
                HiddenField hfID = item.FindControl("hfID") as HiddenField;
                //hfID.Value = idText;

                CheckBox ckbForDel = item.FindControl("ckbForDel") as CheckBox;
                Button btnEdit = item.FindControl("btnEdit") as Button;

                if (ckbForDel.Checked && Int32.TryParse(hfID.Value, out int id))
                {
                    this._mgrQuesDetail.DeleteQuesDetail(Convert.ToInt32(btnEdit.CommandName));
                }
            }
            
            Response.Redirect("mainPageA.aspx?ID=" + questionnaireID);
        }

        private void BackToListPage()
        {
            this.Response.Redirect("listPageA.aspx", true);
        }

        protected void btnDownload_Click(object sender, EventArgs e)
        {
            string idText = Request.QueryString["ID"];
            Guid id = new Guid(idText);
            var quesList = this._mgrQuesDetail.GetQuesDetailList(id);

            string filePath = $"F:\\ccc\\{idText}.csv";

            //ExportToCSV(, filePath);
        }

        public void ExportToCSV(List<QuesDetailModel> dt, string filePath)
        {
            using (var file = new StreamWriter(filePath))
            {
                foreach (var item in dt)
                {
                    file.WriteLineAsync($"{item.QuesTitle},{item.QuesChoices},{item.ID}");
                }
            }
        }
    }
}