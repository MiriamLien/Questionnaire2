using questionnaire.Managers;
using questionnaire.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace questionnaire.BackAdmin
{
    public partial class listPageA : System.Web.UI.Page
    {
        private AccountManager _mgrAccount = new AccountManager();
        private QuesContentsManager _mgrQuesContents = new QuesContentsManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            //string idtext = this.Request.QueryString["ID"];

            if (!IsPostBack) //二次重整頁面就不會跑這裡
            {
                string keyword = string.Empty;
                var quesList = this._mgrQuesContents.GetQuesContentsList(keyword);
                this.rptList.DataSource = quesList;
                this.rptList.DataBind();

                foreach (RepeaterItem item in rptList.Items)
                {
                    HiddenField hfID = item.FindControl("hfID") as HiddenField;
                    Guid id = new Guid(hfID.Value);
                    var q = this._mgrQuesContents.GetQuesContent(id);
                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string titleText = this.txtTitle.Text;
            string startDT = this.txtStartDate.Text;
            string endDT = this.txtEndDate.Text;

            bool hasTitle = !string.IsNullOrWhiteSpace(titleText);
            bool hasStartDT = !string.IsNullOrWhiteSpace(startDT);
            bool hasEndDT = !string.IsNullOrWhiteSpace(endDT);

            if (hasTitle)
            {
                var titleQList = this._mgrQuesContents.GetQuesContentsList(titleText);

                this.rptList.DataSource = titleQList;
                this.rptList.DataBind();

                this.txtTitle.Text = string.Empty;

                if (titleQList.Count == 0 || titleQList == null)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('查無資料。');location.href='listPageA.aspx';", true);
                }
            }
            else if (hasStartDT && !hasEndDT)
            {
                DateTime sDT = Convert.ToDateTime(startDT);
                var startDTQList = this._mgrQuesContents.GetStartDateQuesContentsList(sDT);

                this.rptList.DataSource = startDTQList;
                this.rptList.DataBind();

                this.txtStartDate.Text = string.Empty;

                if (startDTQList.Count == 0 || startDTQList == null)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('查無資料。');location.href='listPageA.aspx';", true);
                }
            }
            else if (!hasStartDT && hasEndDT)
            {
                DateTime eDT = Convert.ToDateTime(endDT);
                var endDTQList = this._mgrQuesContents.GetEndDateQuesContentsList(eDT);

                this.rptList.DataSource = endDTQList;
                this.rptList.DataBind();

                this.txtEndDate.Text = string.Empty;

                if (endDTQList.Count == 0 || endDTQList == null)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('查無資料。');location.href='listPageA.aspx';", true);
                }
            }
            else if (hasStartDT && hasEndDT)
            {
                DateTime sDT = Convert.ToDateTime(startDT);
                DateTime eDT = Convert.ToDateTime(endDT);

                var bothDTList = this._mgrQuesContents.GetDateQuesContentsList(sDT, eDT);

                this.rptList.DataSource = bothDTList;
                this.rptList.DataBind();

                if (sDT > eDT)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('結束時間不可小於開始時間。');", true);
                    this.txtStartDate.Text = string.Empty;
                    this.txtEndDate.Text = string.Empty;

                    string keyword = string.Empty;
                    var QList = this._mgrQuesContents.GetQuesContentsList(keyword);
                    this.rptList.DataSource = QList;
                    this.rptList.DataBind();
                }
                
                if (bothDTList.Count == 0 || bothDTList == null)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('查無資料。');location.href='listPageA.aspx';", true);
                }
            }
            else
            {
                string keyword = string.Empty;
                var QList = this._mgrQuesContents.GetQuesContentsList(keyword);

                this.rptList.DataSource = QList;
                this.rptList.DataBind();
            }
        }

        // 軟刪除問卷
        protected void btnDelete_Command(object sender, CommandEventArgs e)
        {
            Guid id = Guid.Parse(e.CommandName);
            this._mgrQuesContents.DeleteQues(id);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('問卷已關閉。');location.href='listPageA.aspx';", true);
        }

        // 導至新增模式頁面
        protected void ImgBtnAdd_Click(object sender, ImageClickEventArgs e)
        {
            if (this._mgrAccount.IsLogined())
                Response.Redirect("mainPageA_Add.aspx");
            else
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('請先進行登入。');location.href='../Login.aspx';", true);
        }
    }
}