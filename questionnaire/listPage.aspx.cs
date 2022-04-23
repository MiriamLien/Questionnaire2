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
                this.rptList.DataSource = quesList;
                this.rptList.DataBind();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string titleText = this.txtTitle.Text;
            string startDT = this.txtStartDate.Text;
            string endtDT = this.txtEndDate.Text;

            if (!string.IsNullOrWhiteSpace(titleText))
            {
                var titleQList = this._mgrQuesContents.GetQuesContentsList(titleText);

                this.rptList.DataSource = titleQList;
                this.rptList.DataBind();

                titleText = string.Empty;

                if (titleQList.Count == 0 || titleQList == null)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('查無資料。');location.href='listPageA.aspx';", true);
                }
            }
            else if (!string.IsNullOrWhiteSpace(startDT))
            {
                DateTime sDT = Convert.ToDateTime(startDT);
                var startDTQList = this._mgrQuesContents.GetStartDateQuesContentsList(sDT);

                this.rptList.DataSource = startDTQList;
                this.rptList.DataBind();

                startDT = string.Empty;

                if (startDTQList.Count == 0 || startDTQList == null)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('查無資料。');location.href='listPageA.aspx';", true);
                }
            }
            else if (!string.IsNullOrWhiteSpace(endtDT))
            {
                DateTime eDT = Convert.ToDateTime(endtDT);
                var endDTQList = this._mgrQuesContents.GetEndDateQuesContentsList(eDT);

                this.rptList.DataSource = endDTQList;
                this.rptList.DataBind();

                endtDT = string.Empty;
                if (endDTQList.Count == 0 || endDTQList == null)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('查無資料。');location.href='listPageA.aspx';", true);
                }
            }
            else if (!string.IsNullOrWhiteSpace(startDT) &&
                     !string.IsNullOrWhiteSpace(endtDT))
            {
                DateTime sDT = Convert.ToDateTime(startDT);
                DateTime eDT = Convert.ToDateTime(endtDT);

                var bothDTList = this._mgrQuesContents.GetDateQuesContentsList(sDT, eDT);

                this.rptList.DataSource = bothDTList;
                this.rptList.DataBind();

                startDT = string.Empty;
                endtDT = string.Empty;

                if (bothDTList.Count == 0 || bothDTList == null)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('查無資料。');location.href='listPageA.aspx';", true);
                }
            }
        }
    }
}