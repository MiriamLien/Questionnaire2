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
        private QuesDetailManager _mgrQuesDetail = new QuesDetailManager();
        private UserInfoManager _mgrUserInfo = new UserInfoManager();
        private UserQuesDetailManager _mgrUserQuesDetail = new UserQuesDetailManager();
        int ansCheck = 0;
        int i = 1;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["ID"] == null)
            {
                Response.Redirect("listPage.aspx");
            }

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

            List<UserQuesDetailModel> ansList = (List<UserQuesDetailModel>)Session["Answer"];

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

            string name = this.Session["Name"] as string;
            string phone = this.Session["Phone"] as string;
            string email = this.Session["Email"] as string;
            string age = this.Session["Age"] as string;

            this.ltlNameAns.Text = name;
            this.ltlPhoneAns.Text = phone;
            this.ltlEmailAns.Text = email;
            this.ltlAgeAns.Text = age;
        }

        private void createTextBox(QuesDetail ques)
        {
            List<UserQuesDetailModel> ansList = (List<UserQuesDetailModel>)Session["Answer"];

            for (int j = 0; j < ansList.Count; j++)
            {
                if (ansList[j].QuesID == ques.QuesID)
                {
                    Label lblTextBox = new Label();
                    lblTextBox.ID = "Q" + ques.QuesID + j.ToString();
                    lblTextBox.Text = ansList[j].Answer.TrimEnd(';');
                    this.plcForQuestion.Controls.Add(lblTextBox);
                    ansCheck++;
                }
            }
        }

        private void createRdb(QuesDetail ques)
        {
            //string idText = Request.QueryString["ID"];
            //Guid questionnaireID = Guid.Parse(idText);
            //var questionList = this._mgrQuesDetail.GetQuesDetailList(questionnaireID);

            List<UserQuesDetailModel> ansList = (List<UserQuesDetailModel>)Session["Answer"];

            RadioButtonList rdbList = new RadioButtonList();
            rdbList.ID = "Q" + ques.QuesID.ToString();
            this.plcForQuestion.Controls.Add(rdbList);

            for (int j = 0; j < ansList.Count; j++)
            {
                if (ansList[j].QuesID == ques.QuesID)
                {
                    Label lblRdb = new Label();
                    lblRdb.ID = "Q" + ques.QuesID + j.ToString();
                    lblRdb.Text = ansList[j].Answer.TrimEnd(';');
                    this.plcForQuestion.Controls.Add(lblRdb);
                    ansCheck++;
                }
            }
        }

        private void createCkb(QuesDetail ques)
        {
            List<UserQuesDetailModel> ansList = (List<UserQuesDetailModel>)Session["Answer"];

            CheckBoxList ckbList = new CheckBoxList();
            ckbList.ID = "Q" + ques.QuesID.ToString();
            this.plcForQuestion.Controls.Add(ckbList);

            for (int j = 0; j < ansList.Count; j++)
            {
                if (ansList[j].QuesID == ques.QuesID)
                {
                    Label lblCkb = new Label();
                    lblCkb.ID = "Q" + ques.QuesID + j.ToString();
                    lblCkb.Text = ansList[j].Answer.TrimEnd(';');
                    this.plcForQuestion.Controls.Add(lblCkb);
                    ansCheck++;
                }
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

            Guid userID = Guid.NewGuid();
            UserInfoModel userInfo = new UserInfoModel()
            {
                UserID = userID,
                ID = questionnaireID,
                CreateDate = DateTime.Now,
                Name = name.ToString().Trim(),
                Phone = phone.ToString().Trim(),
                Email = email.ToString().Trim(),
                Age = age.ToString().Trim(),
            };

            this._mgrUserInfo.CreateUserInfo(userInfo);

            // 從Session拿出問題列表
            List<UserQuesDetailModel> ansList = (List<UserQuesDetailModel>)Session["Answer"];

            UserQuesDetailModel userAndAns = new UserQuesDetailModel()
            {
                ID = questionnaireID,
                UserID = userID,
            };

            for (int i = 0; i < questionList.Count; i++)
            {
                foreach (var item in ansList)
                {
                    userAndAns.QuesID = questionList[i].QuesID;
                    userAndAns.Answer = item.Answer;
                    userAndAns.QuesTypeID = questionList[i].QuesTypeID;

                    this._mgrUserQuesDetail.CreateUserQuesDetail(userAndAns);
                }
            }

            Session.Remove("Name");
            Session.Remove("Phone");
            Session.Remove("Email");
            Session.Remove("Age");
            Session.Remove("Answer");

            Response.Redirect($"statisticPage.aspx?ID={questionnaireID}");
        }
    }
}