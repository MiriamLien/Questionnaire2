using questionnaire.Managers;
using questionnaire.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace questionnaire.BackAdmin
{
    public partial class mainPageA : System.Web.UI.Page
    {
        //private bool _isEditMode = false;

        private QuesContentsManager _mgrQuesContents = new QuesContentsManager();
        private QuesDetailManager _mgrQuesDetail = new QuesDetailManager();
        private QuesTypeManager _mgrQuesType = new QuesTypeManager();
        private CQManager _mgrCQ = new CQManager();
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
                var questionList = this._mgrQuesDetail.GetQuesDetailList(questionnaireID);
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
            }

        }

            //string url = this.Request.Url.LocalPath + "?ID=" + idText;
            //this.Response.Redirect(url);


        protected void btnPaperCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("listPageA.aspx");
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

        // 新增問題至下方列表
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Session["questionList"] += this.txtQuesTitle.Text.Trim() + "&";
            Session["questionList"] += this.txtQuesAns.Text.Trim() + "&";
            Session["questionList"] += Convert.ToInt32(this.ddlAnsType.SelectedValue) + "&";
            Session["questionList"] += (this.ddlAnsType.SelectedItem.ToString()).Trim() + "&";
            Session["questionList"] += this.ckbMustAns.Checked + "$";

            var quesList = this._mgrQuesDetail.GetQuestionList(Session["questionList"].ToString());
            this.rptQuestion.DataSource = quesList;
            this.rptQuestion.DataBind();

            if (quesList != null || quesList.Count > 0)
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
        }

        protected void btnQuesCancel_Click(object sender, EventArgs e)
        {
            Session.Remove("questionList");
            Response.Redirect("listPageA.aspx#paper");
        }

        // 刪除問題
        protected void imgbtnDelete_Click(object sender, ImageClickEventArgs e)
        {
            foreach (RepeaterItem item in this.rptQuestion.Items)
            {
                string idText = Request.QueryString["ID"];
                HiddenField hfID = item.FindControl("hfID") as HiddenField;
                hfID.Value = idText;

                CheckBox ckbForDel = item.FindControl("ckbForDel") as CheckBox;
                Button btnEdit = item.FindControl("btnEdit") as Button;

                if (ckbForDel.Checked && Int32.TryParse(hfID.Value, out int id))
                {
                    this._mgrQuesDetail.DeleteQuesDetail(Convert.ToInt32(btnEdit.CommandName));
                    Response.Redirect(Request.RawUrl + "?ID=" + id);
                }
            }
        }

        // 編輯問題
        protected void btnEdit_Command(object sender, CommandEventArgs e)
        {
            //取得該問題的資料
            int quesID = Convert.ToInt32(e.CommandName);
            var ques = this._mgrQuesDetail.GetQuesDetail(quesID);

            //判斷該問題有無答案
            bool hasChoise;
            if (ques.QuesTypeID == 2 || ques.QuesTypeID == 3)
                hasChoise = true;
            else
                hasChoise = false;

            if (!hasChoise)
            {
                this.txtQuesTitle.Text = ques.QuesTitle.ToString();
                this.ddlAnsType.SelectedValue = ques.QuesTypeID.ToString();
                this.ckbMustAns.Checked = ques.IsEnable;
            }
            else
            {
                this.txtQuesTitle.Text = ques.QuesTitle.ToString();
                this.txtQuesAns.Text = ques.QuesChoices.ToString();
                this.ddlAnsType.SelectedValue = ques.QuesTypeID.ToString();
                this.ckbMustAns.Checked = ques.IsEnable;
            }
        }

        private void BackToListPage()
        {
            this.Response.Redirect("listPageA.aspx", true);
        }
    }
}