using questionnaire.Managers;
using questionnaire.Models;
using questionnaire.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace questionnaire
{
    public partial class checkPage : System.Web.UI.Page
    {
        private QuesContentsManager _mgrQuesContents = new QuesContentsManager();
        private UserInfoManager _mgrUserInfo = new UserInfoManager();
        private QuesDetailManager _mgrQuesDetail = new QuesDetailManager();
        Guid userID = new Guid();
        int i = 1;

        protected void Page_Load(object sender, EventArgs e)
        {
                string idText = Request.QueryString["ID"];
                Guid questionnaireID = Guid.Parse(idText);

                var quesList = this._mgrQuesContents.GetQuesContent(questionnaireID);

                // 取得問卷狀態、日期和標題
                this.ltlState.Text = quesList.IsEnable.ToString();
                if (this.ltlState.Text == "True")
                {
                    this.ltlState.Text = "投票中";
                }
                this.ltlDate.Text = $"{quesList.StartDate.ToShortDateString()} ~ {quesList.EndDate.ToShortDateString()}";
                this.ltlTitle.Text = quesList.Title;

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
                }

            var ans = (this.Session["Answer"]).ToString().Split(';');

            string name = this.Session["Name"] as string;
            string phone = this.Session["Phone"] as string;
            string email = this.Session["Email"] as string;
            string age = this.Session["Age"] as string;

            if (!string.IsNullOrWhiteSpace(name))
                this.ltlNameAns.Text = name;

            if (!string.IsNullOrWhiteSpace(phone))
                this.ltlPhoneAns.Text = phone;

            if (!string.IsNullOrWhiteSpace(email))
                this.ltlEmailAns.Text = email;

            if (!string.IsNullOrWhiteSpace(age))
                this.ltlAgeAns.Text = age;
        }

        private void createTextBox(QuesDetail ques)
        {
            TextBox textBox = new TextBox();
            textBox.ID = "Q" + ques.QuesID.ToString();
            this.plcForQuestion.Controls.Add(textBox);
        }

        private void createRdb(QuesDetail ques)
        {
            RadioButtonList rdbList = new RadioButtonList();
            rdbList.ID = "Q" + ques.QuesID.ToString();
            this.plcForQuestion.Controls.Add(rdbList);

            string[] ansArray = (ques.QuesChoices).Trim().Split(';');

            for (int i = 0; i < ansArray.Length; i++)
            {
                RadioButton rdb = new RadioButton();
                rdb.Text = ansArray[i].ToString();
                rdb.ID = ques.QuesID + i.ToString();
                rdb.GroupName = "group" + ques.QuesID;
                this.plcForQuestion.Controls.Add(rdb);
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

                CheckBox item = new CheckBox();
                item.Text = ansArray[i].ToString();
                item.ID = ques.QuesID + i.ToString();
                this.plcForQuestion.Controls.Add(item);
                this.plcForQuestion.Controls.Add(new LiteralControl("&emsp;"));
            }
        }

        // 返回填寫問卷內容的內頁
        protected void btnChange_Click(object sender, EventArgs e)
        {

            string idText = Request.QueryString["ID"];
            Guid questionnaireID = Guid.Parse(idText);

            Response.Redirect($"mainPage.aspx?ID={questionnaireID}");
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            string idText = Request.QueryString["ID"];
            Guid questionnaireID = Guid.Parse(idText);

            // 取得問卷內容
            var quesList = this._mgrQuesContents.GetQuesContent(questionnaireID);
            // 取得問題內容
            var questionList = this._mgrQuesDetail.GetQuesDetailList(questionnaireID);

            var name = this.Session["Name"];
            var phone = this.Session["Phone"];
            var email = this.Session["Email"];
            var age = this.Session["Age"];

            UserInfoModel userInfo = new UserInfoModel()
            {
                UserID = userID,
                ID = questionnaireID,
                Name = name.ToString().Trim(),
                Phone = phone.ToString().Trim(),
                Email = email.ToString().Trim(),
                Age = age.ToString().Trim(),
            };

            this._mgrUserInfo.CreateUserInfo(userInfo);

            //// 從Session拿出問題列表
            //List<UserQuesDetailModel> ansList = ;

            //UserQuesDetailModel ans = new UserQuesDetailModel()
            //{
            //    ID = questionnaireID,
            //    QuesID = ,
            //    QuesTypeID = ,
            //};

            //for (int i = 0; i < questionList.Count; i++)
            //{

            //}








            Response.Redirect("listPage.aspx");
        }
    }
}