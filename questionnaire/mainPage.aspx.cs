using questionnaire.Managers;
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
        int num = 1;
        int count = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            // 如果沒有帶 id ，跳回列表頁
            if (Request.QueryString["ID"] == null)
                this.BackToListPage();

            string idText = Request.QueryString["ID"];
            Guid questionnaireID = Guid.Parse(idText);

            Guid id;
            if (!Guid.TryParse(idText, out id))
                this.BackToListPage();

            // 查問卷資料
            ORM.Content model = this._mgrQuesContents.GetQuesContent(questionnaireID);
            if (model == null)
                this.BackToListPage();

            // 若問卷為已完結或尚未開始則不開放前台內頁顯示
            if (!model.IsEnable)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('問卷已完結。');location.href='listPage.aspx';", true);
            }
            else if (model.IsEnable && model.StartDate > DateTime.Now)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('問卷尚未開始。');location.href='listPage.aspx';", true);
            }

            // 顯示資料
            this.ltlState.Text = model.IsEnable.ToString();
            if (this.ltlState.Text == "True")
            {
                this.ltlState.Text = "投票中";
            }
            this.ltlDate.Text = $"{model.StartDate.ToShortDateString()} ~ {model.EndDate.ToShortDateString()}";
            this.ltlTitle.Text = model.Title;
            this.ltlBody.Text = model.Body;

            if (Request.QueryString["Edit"] != null)
            {
                string name = this.Session["Name"] as string;
                string phone = this.Session["Phone"] as string;
                string email = this.Session["Email"] as string;
                string age = this.Session["Age"] as string;

                this.txtName.Text = name;
                this.txtPhone.Text = phone;
                this.txtEmail.Text = email;
                this.txtAge.Text = age;
            }

            // 取得問題內容
            var questionList = this._mgrQuesDetail.GetQuesDetailList(questionnaireID);

            foreach (var question in questionList)
            {
                string title = $"<br /><br /><br />{num}. {(question.QuesTitle).Trim()}";
                if (question.IsEnable == true)
                    title += " (*)";

                num += 1;
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
                this.ltlQCount.Text = " 共 " + count + " 個問題 ";
            }
        }

        private void createTextBox(QuesDetail ques)
        {
            if (Request.QueryString["Edit"] != null)
            {
                List<UserQuesDetailModel> ansList = (List<UserQuesDetailModel>)Session["Answer"];
                foreach (var item in ansList)
                {
                    TextBox txt = new TextBox();
                    txt.ID = "Q" + ques.QuesID.ToString();
                    if (item.QuesID == Convert.ToInt32(ansList[count].QuesID))
                    {
                        txt.Text = ansList[count].Answer.TrimEnd(';');
                        this.plcForQuestion.Controls.Add(txt);
                    }
                }
            }
            else
            {
                TextBox txt = new TextBox();
                txt.ID = "Q" + ques.QuesID.ToString();
                this.plcForQuestion.Controls.Add(txt);
            }
        }

        private void createRdb(QuesDetail ques)
        {
            RadioButtonList rdbList = new RadioButtonList();
            rdbList.ID = "Q" + ques.QuesID.ToString();
            this.plcForQuestion.Controls.Add(rdbList);

            string[] ansArray = (ques.QuesChoices).Trim().Split(';');

            if (Request.QueryString["Edit"] != null)
            {
                List<UserQuesDetailModel> ansList = (List<UserQuesDetailModel>)Session["Answer"];

                for (int i = 0; i < ansArray.Length; i++)
                {
                    RadioButton radio = new RadioButton();
                    radio.Text = ansArray[i].ToString();
                    radio.ID = ques.QuesID + i.ToString();
                    radio.GroupName = "group" + ques.QuesID;
                    if (radio.Text == ansList[count].Answer.TrimEnd(';'))
                    {
                        radio.Checked = true;
                    }
                    this.plcForQuestion.Controls.Add(radio);
                    this.plcForQuestion.Controls.Add(new LiteralControl("<br />&emsp;"));
                }
                count++;
            }
            else
            {
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
        }

        private void createCkb(QuesDetail ques)
        {
            CheckBoxList ckbList = new CheckBoxList();
            ckbList.ID = "Q" + ques.QuesID.ToString();
            this.plcForQuestion.Controls.Add(ckbList);

            string[] ansArray = (ques.QuesChoices).Trim().Split(';');

            if (Request.QueryString["Edit"] != null)
            {
                List<UserQuesDetailModel> ansList = (List<UserQuesDetailModel>)Session["Answer"];

                string[] checkedAns = (ansList[count].Answer.TrimEnd(';')).Trim().Split(';');
                for (int i = 0; i < ansArray.Length; i++)
                {
                    CheckBox check = new CheckBox();
                    check.Text = ansArray[i].ToString();
                    check.ID = ques.QuesID + i.ToString();

                    foreach (var item in checkedAns)
                    {
                        if (check.Text == item)
                        {
                            check.Checked = true;
                        }
                    }
                    
                    this.plcForQuestion.Controls.Add(check);
                    this.plcForQuestion.Controls.Add(new LiteralControl("&emsp;"));
                }
                count++;
            }
            else
            {
                for (int i = 0; i < ansArray.Length; i++)
                {
                    CheckBox check = new CheckBox();
                    check.Text = ansArray[i].ToString();
                    check.ID = ques.QuesID + i.ToString();
                    this.plcForQuestion.Controls.Add(check);
                    this.plcForQuestion.Controls.Add(new LiteralControl("&emsp;"));
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            this.BackToListPage();
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
                this.lblMsgPhone.Visible = false;
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
                this.lblMsgEmail.Visible = false;
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

            List<UserQuesDetailModel> answerList = new List<UserQuesDetailModel>();
            int mustAns = 0;

            // 是否為必填/必選
            for (int i = 0; i < questionList.Count; i++)
            {
                var q = _mgrQuesDetail.GetQuesDetail(questionList[i].QuesID);

                if (q.IsEnable == true)
                {
                    switch (questionList[i].QuesTypeID)
                    {
                        case 1:
                            PlaceHolder PH1 = (PlaceHolder)(Master.FindControl("ContentPlaceHolder1").FindControl("plcForQuestion"));
                            TextBox textBox = (TextBox)PH1.FindControl($"Q{questionList[i].QuesID}");

                            if (!string.IsNullOrWhiteSpace(textBox.Text))
                            {
                                mustAns++;
                                break;
                            }
                            break;

                        case 2:
                            for (int j = -1; j < questionList.Count; j++)
                            {
                                int check = 0;

                                // QArray -> 把一個題目的所有選項放在陣列裡
                                string[] QArray = (questionList[i].QuesChoices).Trim().Split(';');
                                for (int k = 0; k < QArray.Length; k++)
                                {
                                    PlaceHolder PH2 = (PlaceHolder)(Master.FindControl("ContentPlaceHolder1").FindControl("plcForQuestion"));
                                    RadioButton rdb = (RadioButton)PH2.FindControl($"{questionList[i].QuesID}{k}");

                                    if (rdb.Checked == true)
                                    {
                                        mustAns++;
                                        check = 1;
                                        break;
                                    }
                                }
                                if (check == 1)
                                    break;
                            }
                            break;

                        case 3:
                            for (int j = -1; j < questionList.Count; j++)
                            {
                                int check2 = 0;
                                bool ckbCheck = false;

                                string[] QArray2 = (questionList[i].QuesChoices).Trim().Split(';');
                                for (int k = 0; k < QArray2.Length; k++)
                                {
                                    PlaceHolder PH3 = (PlaceHolder)(Master.FindControl("ContentPlaceHolder1").FindControl("plcForQuestion"));
                                    CheckBox ckb = (CheckBox)PH3.FindControl($"{questionList[i].QuesID}{k}");

                                    if (ckb.Checked == true)
                                    {
                                        ckbCheck = true;
                                        check2++;
                                    }
                                    else if (ckb.Checked == false)
                                        check2++;

                                    if (check2 == QArray2.Length && ckbCheck)
                                    {
                                        mustAns++;
                                        break;
                                    }
                                }
                                break;
                            }
                            break;
                    }
                }
            }

            if (result && mustAns == questionList.Count)
            {
                // 取得選擇的答案
                for (int i = 0; i < questionList.Count; i++)
                {
                    var q = _mgrQuesDetail.GetQuesDetail(questionList[i].QuesID);

                    UserQuesDetailModel ans = new UserQuesDetailModel()
                    {
                        ID = q.ID,
                        QuesID = q.QuesID,
                        QuesTypeID = q.QuesTypeID,
                    };

                    switch (questionList[i].QuesTypeID)
                    {
                        case 1:
                            PlaceHolder PH1 = (PlaceHolder)(Master.FindControl("ContentPlaceHolder1").FindControl("plcForQuestion"));
                            TextBox textBox = (TextBox)PH1.FindControl($"Q{questionList[i].QuesID}");

                            if (textBox.Text != null)
                            {
                                ans.Answer = textBox.Text + ";";
                                answerList.Add(ans);
                                break;
                            }
                            break;

                        case 2:
                            for (int j = -1; j < questionList.Count; j++)
                            {
                                // QArray -> 把一個題目的所有選項放在陣列裡
                                string[] QArray = (questionList[i].QuesChoices).Trim().Split(';');

                                for (int k = 0; k < QArray.Length; k++)
                                {
                                    PlaceHolder PH2 = (PlaceHolder)(Master.FindControl("ContentPlaceHolder1").FindControl("plcForQuestion"));
                                    RadioButton rdb = (RadioButton)PH2.FindControl($"{questionList[i].QuesID}{k}");

                                    if (rdb.Checked == true)
                                    {
                                        ans.Answer = rdb.Text + ";";
                                        answerList.Add(ans);
                                        break;
                                    }
                                }
                                break;
                            }
                            break;

                        case 3:
                            for (int j = -1; j < questionList.Count; j++)
                            {
                                string[] QArray2 = (questionList[i].QuesChoices).Trim().Split(';');
                                int ansCheck = 0;

                                for (int k = 0; k < QArray2.Length; k++)
                                {
                                    PlaceHolder PH3 = (PlaceHolder)(Master.FindControl("ContentPlaceHolder1").FindControl("plcForQuestion"));
                                    CheckBox ckb = (CheckBox)PH3.FindControl($"{questionList[i].QuesID}{k}");

                                    if (ckb.Checked == true)
                                    {
                                        ans.Answer += ckb.Text + ";";
                                        ansCheck++;
                                    }
                                    else if (ckb.Checked == false)
                                    {
                                        ansCheck++;
                                    }

                                    if (ansCheck == QArray2.Length)
                                    {
                                        answerList.Add(ans);
                                        break;
                                    }
                                }
                                break;
                            }
                            break;
                    }
                }

                this.Session["Answer"] = answerList;
                Response.Redirect($"checkPage.aspx?ID={questionnaireID}");
            }
            else
            {
                this.lblMsg.Visible = true;
            }
        }

        private void BackToListPage()
        {
            this.Response.Redirect("listPage.aspx", true);
        }
    }
}