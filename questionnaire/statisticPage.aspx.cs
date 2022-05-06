using questionnaire.Managers;
using questionnaire.Models;
using questionnaire.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
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
            if (Request.QueryString["ID"] == null)
            {
                Response.Redirect("listPage.aspx");
            }

            string idText = Request.QueryString["ID"];
            Guid questionnaireID = Guid.Parse(idText);
            var quesList = this._mgrQuesContents.GetQuesContent(questionnaireID);
            this.ltlTitle.Text = quesList.Title;

            var questionList = this._mgrQuesDetail.GetQuesDetailList(questionnaireID);
            // 顯示問題及答案
            foreach (var question in questionList)
            {
                string title = $"<br /><br /><br />{i}. {(question.QuesTitle).Trim()}";
                if (question.IsEnable == true)
                    title += " (*)";

                i += 1;
                Literal ltlQuestion = new Literal();
                ltlQuestion.Text = title + "<br />";
                this.plcForQuestion.Controls.Add(ltlQuestion);

                string[] answerList = question.QuesChoices.Trim().Split(';');

                for (int k = 0; k < answerList.Length; k++)
                {
                    Literal ltlAnswer = new Literal();
                    HtmlGenericControl div1 = new HtmlGenericControl("div");
                    div1.Style.Value = "width: 80%; border: 1px solid black;";
                    HtmlGenericControl div2 = new HtmlGenericControl("div");
                    div2.Style.Value = "border: 1px solid blue; background-color: blue; color: white; height: 30px;";
                    div1.Controls.Add(div2);
                    Literal space = new Literal();
                    space.Text = "<br />";
                    ltlAnswer.Text = answerList[k];
                    this.plcForQuestion.Controls.Add(ltlAnswer);
                    this.plcForQuestion.Controls.Add(div1);
                    this.plcForQuestion.Controls.Add(space);
                }
            }
        }

        protected void btnToListPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("listPage.aspx");
        }
    }
}