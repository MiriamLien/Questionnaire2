﻿using questionnaire.Managers;
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
            if (!IsPostBack)
            {
                string idText = Request.QueryString["ID"];
                Guid questionnaireID = Guid.Parse(idText);
                var quesList = this._mgrQuesContents.GetQuesContent(questionnaireID);
                this.ltlTitle.Text = quesList.Title;
                this.ltlBody.Text = quesList.Body;

                var question = this._mgrQuesDetail.GetQuesDetailList(questionnaireID);
                this.rptQuestion.DataSource = question;
                this.rptQuestion.DataBind();
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

            bool telCheck = Regex.IsMatch(this.txtPhone.Text.Trim(), @"^09[0-9]{8}$");
            bool emailCheck = Regex.IsMatch(this.txtEmail.Text.Trim(), @"@gmail.com$");

            if (!string.IsNullOrWhiteSpace(this.txtName.Text))
                isNameRight = true;
            if (!string.IsNullOrWhiteSpace(this.txtPhone.Text) && telCheck)
                isPhoneRight = true;
            if (!string.IsNullOrWhiteSpace(this.txtEmail.Text) && emailCheck)
                isEmailRight = true;
            if (!string.IsNullOrWhiteSpace(this.txtAge.Text))
                isAgeRight = true;

            if (isNameRight && isPhoneRight && isEmailRight && isAgeRight)
            {
            }

            this.Session["Name"] = this.txtName.Text;
            this.Session["Phone"] = this.txtPhone.Text;
            this.Session["Email"] = this.txtEmail.Text;
            this.Session["Age"] = this.txtAge.Text;

            Response.Redirect("checkPage.aspx");
        }
    }
}