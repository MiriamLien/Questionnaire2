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

            List<UserQuesDetailModel> ansList = (List<UserQuesDetailModel>)Session["Answer"];

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

                //switch (question.QuesTypeID)
                //{
                //    case 1:
                //        createTextBox(question);
                //        break;
                //    case 2:
                //        createRdb(question);
                //        break;
                //    case 3:
                //        createCkb(question);
                //        break;
                //}
            }
        }

        //private void createTextBox(QuesDetail ques)
        //{
        //    List<UserQuesDetailModel> ansList = (List<UserQuesDetailModel>)Session["Answer"];

        //    for (int j = 0; j < ansList.Count; j++)
        //    {
        //        if (ansList[j].QuesID == ques.QuesID)
        //        {
        //            Label lblTextBox = new Label();
        //            lblTextBox.ID = "Q" + ques.QuesID + j.ToString();
        //            lblTextBox.Text = ansList[j].Answer.TrimEnd(';');
        //            this.plcForQuestion.Controls.Add(lblTextBox);
        //        }
        //    }
        //}

        //private void createRdb(QuesDetail ques)
        //{
        //    List<UserQuesDetailModel> ansList = (List<UserQuesDetailModel>)Session["Answer"];

        //    RadioButtonList rdbList = new RadioButtonList();
        //    rdbList.ID = "Q" + ques.QuesID.ToString();
        //    this.plcForQuestion.Controls.Add(rdbList);

        //    for (int j = 0; j < ansList.Count; j++)
        //    {
        //        if (ansList[j].QuesID == ques.QuesID)
        //        {
        //            Label lblRdb = new Label();
        //            lblRdb.ID = "Q" + ques.QuesID + j.ToString();
        //            lblRdb.Text = ansList[j].Answer.TrimEnd(';');
        //            this.plcForQuestion.Controls.Add(lblRdb);
        //        }
        //    }
        //}

        //private void createCkb(QuesDetail ques)
        //{
        //    List<UserQuesDetailModel> ansList = (List<UserQuesDetailModel>)Session["Answer"];

        //    CheckBoxList ckbList = new CheckBoxList();
        //    ckbList.ID = "Q" + ques.QuesID.ToString();
        //    this.plcForQuestion.Controls.Add(ckbList);

        //    for (int j = 0; j < ansList.Count; j++)
        //    {
        //        if (ansList[j].QuesID == ques.QuesID)
        //        {
        //            Label lblCkb = new Label();
        //            lblCkb.ID = "Q" + ques.QuesID + j.ToString();
        //            lblCkb.Text = ansList[j].Answer.TrimEnd(';');
        //            this.plcForQuestion.Controls.Add(lblCkb);
        //        }
        //    }
        //}

        protected void btnToListPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("listPage.aspx");
        }
    }
}