using questionnaire.Managers;
using questionnaire.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace questionnaire
{
    public partial class mainPage : System.Web.UI.Page
    {
        //private AccountManager _mgrAccount = new AccountManager();
        private QuesContentsManager _mgrQuesContents = new QuesContentsManager();
        private QuesDetailManager _mgrQuesDetail = new QuesDetailManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            int i = 1;

            if (!IsPostBack)
            {
                string idText = Request.QueryString["ID"];
                Guid questionnaireID = Guid.Parse(idText);

                // 如果沒有帶 id ，跳回列表頁
                if (string.IsNullOrWhiteSpace(idText))
                    this.BackToListPage();

                Guid id;
                if (!Guid.TryParse(idText, out id))
                    this.BackToListPage();

                // 查資料
                ORM.Content model = this._mgrQuesContents.GetQuesContent(questionnaireID);
                if (model == null)
                    this.BackToListPage();

                //// 若問卷為關閉中則不開放前台顯示
                //if (!model.IsEnable)
                //{
                //    this.BackToListPage();
                //}

                // 顯示資料
                this.ltlTitle.Text = model.Title;
                this.ltlBody.Text = model.Body;

                // 重置基本資料
                this.txtName.Text = string.Empty;
                this.txtPhone.Text = string.Empty;
                this.txtEmail.Text = string.Empty;
                this.txtAge.Text = string.Empty;

                // 取得問題內容
                var question = this._mgrQuesDetail.GetQuesDetailList(questionnaireID);
                this.rptQuestion.DataSource = question;
                this.rptQuestion.DataBind();

                
                foreach (RepeaterItem item in this.rptQuestion.Items)
                {
                    Literal ltlNum = item.FindControl("ltlNum") as Literal;
                    ltlNum.Text = i.ToString();
                    i++;
                }
                

            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("listPage.aspx");
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            bool isNameRight = false;
            bool isPhoneRight = false;
            bool isEmailRight = false;
            bool isAgeRight = false;

            if (string.IsNullOrWhiteSpace(this.txtName.Text))
            {
                this.lblMsgName.Visible = true;
            }
            else
            {
                this.lblMsgName.Visible = false;
                isNameRight = true;
            }

            bool telCheck = Regex.IsMatch(this.txtPhone.Text.Trim(), @"^09[0-9]{8}$");

            if (string.IsNullOrWhiteSpace(this.txtPhone.Text))
            {
                this.lblMsgPhone.Visible = true;
            }
            else if (!telCheck)
            {
                this.lblMsgPhone.Visible = false;
                this.lblMsgPhone2.Visible = true;
            }
            else
            {
                this.lblMsgPhone2.Visible = false;
                isPhoneRight = true;
            }

            bool emailCheck = Regex.IsMatch(this.txtEmail.Text.Trim(), @"@gmail.com$");

            if (string.IsNullOrWhiteSpace(this.txtEmail.Text))
            {
                this.lblMsgEmail.Visible = true;
            }
            else if (!emailCheck)
            {
                this.lblMsgEmail.Visible = false;
                this.lblMsgEmail2.Visible = true;
            }
            else
            {
                this.lblMsgEmail2.Visible = false;
                isEmailRight = true;
            }
                
            if (string.IsNullOrWhiteSpace(this.txtAge.Text))
            {
                this.lblMsgAge.Visible = true;
            }
            else
            {
                this.lblMsgAge.Visible = false;
                isAgeRight = true;
            }

            // 達成上述條件，才寫入Session
            bool result = (isNameRight && isPhoneRight && isEmailRight && isAgeRight);
            if (result)
            {
                this.Session["Name"] = this.txtName.Text;
                this.Session["Phone"] = this.txtPhone.Text;
                this.Session["Email"] = this.txtEmail.Text;
                this.Session["Age"] = this.txtAge.Text;

                Response.Redirect("checkPage.aspx");
            }
        }

        private void BackToListPage()
        {
            this.Response.Redirect("listPage.aspx", true);
        }
    }
}