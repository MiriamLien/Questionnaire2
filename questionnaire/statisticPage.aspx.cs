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
        private UserQuesDetailManager _mgrUserQuesDetail = new UserQuesDetailManager();
        private UserInfoManager _mgrUserInfo = new UserInfoManager();
        private StatisticManager _mgrStatistic = new StatisticManager();
        int num = 1;

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
            var userQuesDetailList = this._mgrUserQuesDetail.GetUserQuesDetailList(questionnaireID);

            foreach (var question in questionList)
            {
                if (userQuesDetailList == null)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('尚無統計數據(無人作答)。');location.href='listPage.aspx';", true);
                }
                else
                {
                    // 顯示題目
                    string title = $"<br /><br /><br />{num}. {(question.QuesTitle).Trim()}";
                    if (question.IsEnable == true)
                        title += " (*)";

                    num += 1;
                    Literal ltlQuestion = new Literal();
                    ltlQuestion.Text = title + "<br />";
                    this.plcForQuestion.Controls.Add(ltlQuestion);

                    // 一個問題的所有選項
                    string[] answerList = (question.QuesChoices.TrimEnd(';')).Trim().Split(';');

                    int total = 0;
                    int ansCount = 0;
                    List<StatisticModel> statisticList = this._mgrStatistic.GetStatisticList(questionnaireID);

                    // 單複選
                    if (question.QuesTypeID != 1)
                    {
                        List<StatisticModel> staList = statisticList.FindAll(x => x.QuesID == question.QuesID);

                        foreach (var item in staList)
                        {
                            item.AnsCount = staList.Count;
                            total = item.AnsCount;
                        }

                        // 動態生成答案的所有選項 和 barchart!!!!!!!!!!!!!!!!!!
                        for (int k = 0; k < answerList.Length; k++)
                        {
                            foreach (var oneStatistic in staList)
                            {
                                string[] itemInStaList = oneStatistic.Answer.TrimEnd(';').Trim().Split(';');

                                foreach (var sta in itemInStaList)
                                {
                                    if (sta == answerList[k])
                                    {
                                        ansCount++;
                                    }
                                }
                            }

                            Literal ltlAnswer = new Literal();
                            HtmlGenericControl div1 = new HtmlGenericControl("div");
                            div1.Style.Value = "width: 80%; border: 1px solid black;";
                            HtmlGenericControl div2 = new HtmlGenericControl("div");
                            div2.Style.Value = "border: 1px solid #0094ff; background-color: #0094ff; color: white; height: 30px;";
                            var percent = (double)ansCount / total * 100;
                            div2.Style["width"] = percent.ToString();
                            div1.Controls.Add(div2);
                            Literal space = new Literal();
                            space.Text = "<br />";
                            ltlAnswer.Text = answerList[k];
                            this.plcForQuestion.Controls.Add(ltlAnswer);
                            this.plcForQuestion.Controls.Add(div1);
                            this.plcForQuestion.Controls.Add(space);
                        }
                    }
                    else
                    {
                        Literal ltlAnswerForText = new Literal();
                        ltlAnswerForText.Text = "<br /> - <br/>";
                        this.plcForQuestion.Controls.Add(ltlAnswerForText);
                    }
                }
            }
        }

        protected void btnToListPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("listPage.aspx");
        }
    }
}