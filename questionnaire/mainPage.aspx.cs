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

        // !!!!!!!!!!!!!!!!
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
                //radio.ID = ques.QuesID + i.ToString();
                radio.ID = "580";
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


        // 找不到動態控制項ID!!!!!!!!!!!
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
                        for (int j = -1; j < i; j++)
                        {
                            // QArray -> 把一個題目的所有選項放在陣列裡
                            string[] QArray = (questionList[i].QuesChoices).Trim().Split(';');
                            for (int k = 0; k < QArray.Length; k++)
                            {
                                ContentPlaceHolder ctl = (ContentPlaceHolder)Page.FindControl("ContentPlaceHolder1");
                                //PlaceHolder plc = (PlaceHolder)ctl.Page.FindControl("plcForQuestion");
                                //RadioButton rdb = FindControl<RadioButton>(this.Page, "plcForQuestion") as RadioButton;
                                RadioButton rdb = (RadioButton)this.plcForQuestion.FindControl($"{questionList[i].QuesID}{k}");
                                //RadioButton rdb = (RadioButton)this.plcForQuestion.FindControl("ContentPlaceHolder1_580");
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

        public T FindControl<T>(string id) where T : Control
        {
            return FindControl<T>(Page, id);
        }

        public static T FindControl<T>(Control startingControl, string id) where T : Control
        {
            // 取得 T 的預設值，通常是 null
            T found = default(T);

            int controlCount = startingControl.Controls.Count;

            if (controlCount > 0)
            {
                for (int i = 0; i < controlCount; i++)
                {
                    Control activeControl = startingControl.Controls[i];
                    if (activeControl is T)
                    {
                        found = startingControl.Controls[i] as T;
                        if (string.Compare(id, found.ID, true) == 0) break;
                        else found = null;
                    }
                    else
                    {
                        found = FindControl<T>(activeControl, id);
                        if (found != null) break;
                    }
                }
            }
            return found;
        }


        //public override Control FindControl(string id)
        //{
        //    Control ctl = base.FindControl(id);
        //    if (ctl == null && this.Master != null) return FindControlRecursive(this.Master, id);
        //    else return ctl;
        //}
        //private Control FindControlRecursive(Control rootControl, string controlID)
        //{
        //    if (rootControl.ID == controlID)
        //        return rootControl;

        //    foreach (Control controlToSearch in rootControl.Controls)
        //    {
        //        Control controlToReturn = FindControlRecursive(controlToSearch, controlID);
        //        if (controlToReturn != null)
        //            return controlToReturn;
        //    }
        //    return null/* TODO Change to default(_) if this is not a reference type */;
        //}
        private void BackToListPage()
        {
            this.Response.Redirect("listPage.aspx", true);
        }
    }
}