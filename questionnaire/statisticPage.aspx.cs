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
            var userQuesDetail = this._mgrUserQuesDetail.GetUserInfoAndQues(questionnaireID);
            var userInfo = this._mgrUserInfo.GetUserInfoList(questionnaireID);



            // 選擇選項 除以 投票總人數 > 數字(趴數)

            for (int j = 0; j < questionList.Count; j++)
            {
                var question = _mgrQuesDetail.GetQuesDetail(questionList[j].QuesID);

                if (userQuesDetail == null)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('尚無統計數據(無人作答)。');location.href='listPage.aspx';", true);
                }
                else
                {
                    //switch (questionList[j].QuesID)
                    //{
                    //    case 2:

                    //        break;

                    //    case 3:
                    //        break;
                    //}

                    // 顯示題目
                    string title = $"<br /><br /><br />{i}. {(question.QuesTitle).Trim()}";
                    if (question.IsEnable == true)
                        title += " (*)";

                    i += 1;
                    Literal ltlQuestion = new Literal();
                    ltlQuestion.Text = title + "<br />";
                    this.plcForQuestion.Controls.Add(ltlQuestion);

                    string[] answerList = question.QuesChoices.Trim().Split(';');

                    // 動態生成答案 和 barchart
                    for (int k = 0; k < answerList.Length; k++)
                    {
                        Literal ltlAnswer = new Literal();
                        HtmlGenericControl div1 = new HtmlGenericControl("div");
                        div1.Style.Value = "width: 80%; border: 1px solid black;";
                        HtmlGenericControl div2 = new HtmlGenericControl("div");
                        div2.Style.Value = "border: 1px solid #0094ff; background-color: #0094ff; color: white; height: 30px;";
                        //div2.Style["width"] = percentage;
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
        }

        protected void btnToListPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("listPage.aspx");
        }
    }
}