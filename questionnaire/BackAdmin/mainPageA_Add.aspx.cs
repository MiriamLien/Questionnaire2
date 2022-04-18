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
        private QuesTypeManager _mgrQuesType = new QuesTypeManager();
        private CQManager _mgrCQ = new CQManager();

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
                var TypeList = this._mgrCQ.GetCQsList();
                this.ddlQuesType.DataSource = TypeList;
                this.ddlQuesType.DataValueField = "CQID";
                this.ddlQuesType.DataTextField = "CQTitle";
                this.ddlQuesType.DataBind();

                this.ddlQuesType.Items.Insert(0, new ListItem("自訂問題", "0"));
            }
        }

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

        protected void btnPaperSend_Click(object sender, EventArgs e)
        {
            List<string> errorMsgList = new List<string>();
            if (!this.CheckInput(out errorMsgList))
            {
                this.lblMsg.Text = string.Join("<br/>", errorMsgList);
                return;
            }

            QuesContentsModel model = new QuesContentsModel()
            {
                Title = this.txtTitle.Text.Trim(),
                Content = this.txtContent.Text.Trim(),
                StartDate = Convert.ToDateTime(this.txtStartDate.Text.Trim()),
                EndDate = Convert.ToDateTime(this.txtEndDate.Text.Trim()),
                IsEnable = this.ckbPaperEnable.Checked,
            };

            Account account = new AccountManager().GetCurrentUser();

            this._mgrQuesContents.CreateQues(model, account.AccountID);
        }

        protected void btnPaperCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("listPageA.aspx");
        }
    }
}