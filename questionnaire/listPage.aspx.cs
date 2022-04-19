using questionnaire.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace questionnaire
{
    public partial class listPage : System.Web.UI.Page
    {
        private QuesContentsManager _mgrQuesContents = new QuesContentsManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string str = string.Empty;
                var quesList = this._mgrQuesContents.GetQuesContentsList(str);
                this.rptQues.DataSource = quesList;
                this.rptQues.DataBind();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            // 標題搜尋
            string title = this.txtTitle.Text;
            var quesList = this._mgrQuesContents.GetQuesContentsList(title);
            this.rptQues.DataSource = quesList;
            this.rptQues.DataBind();
            
            string url = this.Request.Url.LocalPath + "?Caption=" + this.txtTitle.Text;
            this.Response.Redirect(url);

            // 日期搜尋
            var startDT = this.txtStartDate.Text;
            var endDT = this.txtEndDate.Text;
            
            if (string.IsNullOrWhiteSpace(startDT) && 
                string.IsNullOrWhiteSpace(endDT))
            {
                var dateQuesList = this._mgrQuesContents.GetDateQuesContentsList(Convert.ToDateTime(startDT), Convert.ToDateTime(endDT));
                this.rptQues.DataSource = dateQuesList;
                this.rptQues.DataBind();


                string url2 = this.Request.Url.LocalPath + "?StartDate=" + this.txtStartDate.Text + "&EndDate=" + this.txtEndDate.Text;
                this.Response.Redirect(url2);
            }
            else if(string.IsNullOrWhiteSpace(startDT))
            {
                var startDateQuesList = this._mgrQuesContents.GetStartDateQuesContentsList(Convert.ToDateTime(startDT));
                this.rptQues.DataSource = startDateQuesList;
                this.rptQues.DataBind();
            }
            else if (string.IsNullOrWhiteSpace(endDT))
            {
                var endDateQuesList = this._mgrQuesContents.GetEndDateQuesContentsList(Convert.ToDateTime(endDT));
                this.rptQues.DataSource = endDateQuesList;
                this.rptQues.DataBind();
            }
        }
    }
}