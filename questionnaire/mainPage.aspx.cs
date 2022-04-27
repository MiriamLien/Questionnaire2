﻿using questionnaire.Managers;
using questionnaire.Models;
using questionnaire.ORM;
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
        int i = 1;

        protected void Page_Load(object sender, EventArgs e)
        {
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

                // 查問卷資料
                ORM.Content model = this._mgrQuesContents.GetQuesContent(questionnaireID);
                if (model == null)
                    this.BackToListPage();

                //// 若問卷為關閉中則不開放前台顯示
                //if (!model.IsEnable)
                //{
                //    this.BackToListPage();
                //}

                // 顯示資料
                this.ltlDate.Text = $"{model.StartDate.ToShortDateString()} ~ {model.EndDate.ToShortDateString()}";
                this.ltlTitle.Text = model.Title;
                this.ltlBody.Text = model.Body;

                // 取得問題內容
                var questionList = this._mgrQuesDetail.GetQuesDetailList(questionnaireID);

                foreach (var question in questionList)
                {
                    string title = $"<br /><br /><br />{i}. {(question.QuesTitle).Trim()}";
                    if (question.IsEnable == true)
                        title += " (*)";

                    i += 1;
                    Literal ltlQuestion = new Literal();
                    ltlQuestion.Text = title + "<br />&emsp;";
                    this.plcForQuestion.Controls.Add(ltlQuestion);

                    switch (question.QuesTypeID)
                    {
                        case 1:
                            createTextBox(question);
                            break;
                        case 2:
                            createRdb(question);
                            break;
                        case 3:
                            createCkb(question);
                            break;
                    }

                    string count = questionList.Count.ToString();
                    this.ltlQCount.Text = "共 " + count + " 個問題";
                }
            }
        }

        private void createTextBox(QuesDetail ques)
        {
            TextBox txt = new TextBox();
            txt.ID = "Q" + ques.QuesID.ToString();
            this.plcForQuestion.Controls.Add(txt);
        }

        private void createRdb(QuesDetail ques)
        {
            RadioButtonList rdbList = new RadioButtonList();
            rdbList.ID = "Q" + ques.QuesID.ToString();
            this.plcForQuestion.Controls.Add(rdbList);

            string[] ansArray = (ques.QuesChoices).Trim().Split(';');

            for (int i = 0; i < ansArray.Length; i++)
            {
                RadioButton radio = new RadioButton();
                radio.Text = ansArray[i].ToString();
                radio.ID = ques.QuesID + i.ToString();
                radio.GroupName = "group" + ques.QuesID;
                this.plcForQuestion.Controls.Add(radio);
                this.plcForQuestion.Controls.Add(new LiteralControl("<br />&emsp;"));
            }
        }

        private void createCkb(QuesDetail ques)
        {
            CheckBoxList ckbList = new CheckBoxList();
            ckbList.ID = "Q" + ques.QuesID.ToString();
            this.plcForQuestion.Controls.Add(ckbList);

            string[] ansArray = (ques.QuesChoices).Trim().Split(';');

            for (int i = 0; i < ansArray.Length; i++)
            {
                CheckBox check = new CheckBox();
                check.Text = ansArray[i].ToString();
                check.ID = ques.QuesID + i.ToString();
                this.plcForQuestion.Controls.Add(check);
                this.plcForQuestion.Controls.Add(new LiteralControl("&emsp;"));
            }
        }


        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("listPage.aspx");
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            #region "基本資料檢查"
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
            }
            #endregion

            string idText = Request.QueryString["ID"];
            Guid questionnaireID = Guid.Parse(idText);
            var questionList = this._mgrQuesDetail.GetQuesDetailList(questionnaireID);

            for (int i = 0; i < questionList.Count; i++)
            {
                switch (questionList[i].QuesTypeID)
                {
                    case 1:
                        TextBox textBox = this.plcForQuestion.FindControl($"Q{questionList[i].QuesID}") as TextBox;
                        string[] ansList1 = textBox.Text.Trim().Split(';');
                        var ans1 = ansList1[i].TrimEnd(';').ToString();
                        this.Session["ans1"] = ans1;
                        break;

                    case 2:
                        for (int j = -1; j < questionList.Count; j++)
                        {
                            // QArray -> 把一個題目的所有選項放在陣列裡
                            string[] QArray = (questionList[i].QuesChoices).Trim().Split(';');
                            for (int k = 0; k < QArray.Length; k++)
                            {
                                RadioButton rdb = Page.Master.Master.FindControl("ContentPlaceHolder1").FindControl($"{questionList[i].QuesID}{k}") as RadioButton;
                                if (rdb.Checked == true)
                                {
                                    string[] ansList2 = rdb.Text.Trim().Split(';');
                                    var ans2 = ansList2[i].TrimEnd(';').ToString();
                                    this.Session["ans2"] = ans2;
                                }
                            }
                        }
                        break;

                    case 3:
                        for (int j = -1; j < questionList.Count; j++)
                        {
                            // QArray -> 把一個題目的所有選項放在陣列裡
                            string[] QArray = (questionList[i].QuesChoices).Trim().Split(';');
                            for (int k = 0; k < QArray.Length; k++)
                            {
                                CheckBox ckb = this.plcForQuestion.FindControl($"{questionList[i].QuesID}{k}") as CheckBox;
                                if (ckb.Checked == true)
                                {
                                    string[] ansList3 = ckb.Text.Trim().Split(';');
                                    var ans3 = ansList3[i].TrimEnd(';').ToString();
                                    this.Session["ans3"] = ans3;
                                }
                            }
                        }
                        break;
                }

            }





            Response.Redirect($"checkPage.aspx?ID={questionnaireID}");
        }

        private void BackToListPage()
        {
            this.Response.Redirect("listPage.aspx", true);
        }
    }
}