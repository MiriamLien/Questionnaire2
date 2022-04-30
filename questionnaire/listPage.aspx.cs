﻿using questionnaire.Managers;
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

                // !!!狀態：投票中、尚未開始、已完結，只有投票中顯示問卷填寫頁超連結，已完結則不會顯示
                foreach (RepeaterItem item in this.rptList.Items)
                {
                    Literal ltlState = item.FindControl("ltlState") as Literal;
                    HiddenField hfID = item.FindControl("hfID") as HiddenField;
                    //HiddenField hfStartDate = item.FindControl("hfStartDate") as HiddenField;
                    //HiddenField hfEndDate = item.FindControl("hfEndDate") as HiddenField;
                    //var StartDT = Convert.ToDateTime(hfStartDate.Value);
                    //var EndDT = Convert.ToDateTime(hfEndDate.Value);
                    Guid id = new Guid(hfID.Value);
                    var q = this._mgrQuesContents.GetQuesContent(id);


                    if (q.StartDate > DateTime.Now && int.TryParse(hfID.Value, out int qID))
                    {
                        ltlState.Text = "尚未開始";
                    }
                    else if (q.EndDate < DateTime.Now && int.TryParse(hfID.Value, out int qID2))
                    {
                        ltlState.Text = "已完結";
                    }
                    else if (q.StartDate <= DateTime.Now && q.EndDate >= DateTime.Now && int.TryParse(hfID.Value, out int qID3))
                    {
                        ltlState.Text = "投票中";
                    }
                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string titleText = this.txtTitle.Text;
            string startDT = this.txtStartDate.Text;
            string endDT = this.txtEndDate.Text;

            bool hasTitle = string.IsNullOrWhiteSpace(titleText);
            bool hasStartDT = string.IsNullOrWhiteSpace(startDT);
            bool hasEndDT = string.IsNullOrWhiteSpace(endDT);

            if (!hasTitle)
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
            else if (!hasStartDT && hasEndDT)
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
            else if (hasStartDT && !hasEndDT)
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
            else if (!hasStartDT && !hasEndDT)
            {
                DateTime sDT = Convert.ToDateTime(startDT);
                DateTime eDT = Convert.ToDateTime(endDT);

                var bothDTList = this._mgrQuesContents.GetDateQuesContentsList(sDT, eDT);

                this.rptList.DataSource = bothDTList;
                this.rptList.DataBind();

                this.txtStartDate.Text = string.Empty;
                this.txtEndDate.Text = string.Empty;

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
    }
}