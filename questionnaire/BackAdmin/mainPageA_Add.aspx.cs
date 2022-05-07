using questionnaire.Managers;
using questionnaire.Models;
using questionnaire.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace questionnaire.BackAdmin
{
    public partial class mainPageA_Add : System.Web.UI.Page
    {
        private QuesContentsManager _mgrQuesContents = new QuesContentsManager();
        private QuesDetailManager _mgrQuesDetail = new QuesDetailManager();
        private QuesTypeManager _mgrQuesType = new QuesTypeManager();
        private CQManager _mgrCQ = new CQManager();
        Guid id = Guid.NewGuid();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //問題類型下拉繫結
                var QTypeList = this._mgrQuesType.GetQuesTypesList();
                this.ddlAnsType.DataSource = QTypeList;
                this.ddlAnsType.DataValueField = "QuesTypeID";
                this.ddlAnsType.DataTextField = "QuesType1";
                this.ddlAnsType.DataBind();

                //自訂、常用問題下拉繫結
                string a = string.Empty;
                var TypeList = this._mgrCQ.GetCQsList(a);
                this.ddlQuesType.DataSource = TypeList;
                this.ddlQuesType.DataValueField = "CQID";
                this.ddlQuesType.DataTextField = "CQTitle";
                this.ddlQuesType.DataBind();

                this.ddlQuesType.Items.Insert(0, new ListItem("自訂問題", "0"));

                this.txtStartDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
        }

        // 問卷資訊填寫後送出(新增模式)
        protected void btnPaperSend_Click(object sender, EventArgs e)
        {
            List<string> errorMsgList = new List<string>();
            if (!this.CheckInput(out errorMsgList))
            {
                this.lblMsg.Text = string.Join("<br/>", errorMsgList);
                return;
            }

            string title = this.txtTitle.Text.Trim();
            string content = this.txtContent.Text.Trim();
            var startDT = Convert.ToDateTime(this.txtStartDate.Text.Trim());
            var endDT = Convert.ToDateTime(this.txtEndDate.Text.Trim());
            if (title != null && content != null && startDT != null && endDT != null)
            {
                QuesContentsModel model = new QuesContentsModel()
                {
                    ID = id,
                    Title = title,
                    Body = content,
                    StartDate = startDT,
                    EndDate = endDT,
                    IsEnable = this.ckbPaperEnable.Checked,
                };

                //Account account = new AccountManager().GetCurrentUser();

                this._mgrQuesContents.CreateQues(model);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", $"alert('問卷已新增。');location.href='mainPageA_Add.aspx?ID={model.ID.ToString()}';", true);
            }
        }

        protected void btnPaperCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("listPageA.aspx");
        }


        #region "新增問題"
        // 把問題填入TextBox裡
        protected void ddlQuesType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int cqID = Convert.ToInt32(this.ddlQuesType.SelectedValue.Trim());
            CQAndTypeModel CQs = this._mgrQuesType.GetCQType(cqID);

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

            // 自訂問題的TextBox預設為空的
            if (this.ddlQuesType.SelectedIndex == 0)
            {
                this.txtQuesTitle.Text = string.Empty;
                this.txtQuesAns.Text = string.Empty;
                this.ddlAnsType.SelectedIndex = 0;
            }
        }

        // 新增問題(寫入Session)
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

            // 重置輸入問題處
            this.ddlQuesType.SelectedIndex = 0;
            this.txtQuesTitle.Text = string.Empty;
            this.txtQuesAns.Text = string.Empty;
            this.ddlAnsType.SelectedValue = "1";
        }

        // 把問題傳送至DB(新增模式)
        protected void btnQuesSend_Click(object sender, EventArgs e)
        {
            var idText = Request.QueryString["ID"];
            Guid id = new Guid(idText);
            var quesContent = this._mgrQuesContents.GetQuesContent(id);

            var quesDetailList = this._mgrQuesDetail.GetQuestionList(Session["questionList"].ToString());

            if (quesDetailList != null || quesDetailList.Count > 0)
            {
                int i = 1;
                foreach (RepeaterItem item in this.rptQuestion.Items)
                {
                    Literal ltlNum = item.FindControl("ltlNum") as Literal;
                    ltlNum.Text = i.ToString();
                    i++;
                }

                foreach (var item in quesDetailList)
                {
                    QuesDetailModel model = new QuesDetailModel()
                    {
                        ID = quesContent.ID,
                        QuesID = i,
                        QuesTitle = item.QuesTitle,
                        QuesChoices = item.QuesChoices,
                        QuesTypeID = item.QuesTypeID,
                        IsEnable = item.IsEnable
                    };

                    this._mgrQuesDetail.CreateQuesDetail(model);
                }
            }
            Session.Remove("questionList");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('問題已新增。');location.href='listPageA.aspx';", true);
        }

        protected void btnQuesCancel_Click(object sender, EventArgs e)
        {
            Session.Remove("questionList");
            Response.Redirect("listPageA.aspx");
        }
        #endregion

        private bool CheckInput(out List<string> errorMsgList)
        {
            errorMsgList = new List<string>();

            if (string.IsNullOrWhiteSpace(this.txtTitle.Text))
                errorMsgList.Add("問卷名稱為必填。");

            if (string.IsNullOrWhiteSpace(this.txtContent.Text))
                errorMsgList.Add("描述內容為必填。");

            if (string.IsNullOrWhiteSpace(this.txtStartDate.Text))
                errorMsgList.Add("開始時間為必填。");

            if (string.IsNullOrWhiteSpace(this.txtEndDate.Text))
                errorMsgList.Add("結束時間為必填。");

            if (errorMsgList.Count > 0)
                return false;
            else
                return true;
        }
    }
}