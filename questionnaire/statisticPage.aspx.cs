using questionnaire.Managers;
using questionnaire.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace questionnaire
{
    public partial class statisticPage : System.Web.UI.Page
    {
        private QuesContentsManager _mgrQuesContents = new QuesContentsManager();
        private QuesDetailManager _mgrQuesDetail = new QuesDetailManager();
        int i = 1;

        protected void Page_Load(object sender, EventArgs e)
        {
            string idText = Request.QueryString["ID"];
            Guid questionnaireID = Guid.Parse(idText);

            var quesList = this._mgrQuesContents.GetQuesContent(questionnaireID);
            this.ltlTitle.Text = quesList.Title;

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
    }
}