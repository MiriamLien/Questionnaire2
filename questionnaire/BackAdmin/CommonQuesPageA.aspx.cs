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
    public partial class CommonQuesPageA : System.Web.UI.Page
    {
        private CQManager _mgrCQ = new CQManager();
        private QuesTypeManager _mgrQuesType = new QuesTypeManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            // 問題類型下拉繫結
            var QTypeList = this._mgrQuesType.GetQuesTypesList();
            this.ddlAnsType.DataSource = QTypeList;
            this.ddlAnsType.DataValueField = "QuesTypeID";
            this.ddlAnsType.DataTextField = "QuesType1";
            this.ddlAnsType.DataBind();

            var quesList = this._mgrCQ.GetCQsList();
            this.rptCQ.DataSource = quesList;
            this.rptCQ.DataBind();

            if (quesList != null || quesList.Count > 0)
            {
                // 生成問題編號
                int i = 1;
                foreach (RepeaterItem item in this.rptCQ.Items)
                {
                    Literal ltlNum = item.FindControl("ltlNum") as Literal;
                    ltlNum.Text = i.ToString();
                    i++;
                }
            }
        }

        #region "新增"
        protected void ImgBtnAdd_Click(object sender, ImageClickEventArgs e)
        {
            this.plcAddCQ.Visible = true;
            this.ImgBtnAdd.Visible = false;
            this.plcCQA.Visible = false;
            this.ltlAddMsg.Visible = false;

            // 問題類型下拉繫結
            var QTypeList = this._mgrQuesType.GetQuesTypesList();
            this.ddlAddAnsType.DataSource = QTypeList;
            this.ddlAddAnsType.DataValueField = "QuesTypeID";
            this.ddlAddAnsType.DataTextField = "QuesType1";
            this.ddlAddAnsType.DataBind();
        }

        //新增問題視窗內的儲存按鈕
        protected void btnSaveAddCQ_Click(object sender, EventArgs e)
        {
            string title = this.txtAddQues.Text.Trim();
            string ans = this.txtAddAns.Text.Trim();
            bool mustAns = this.ckbAddCQMustAns.Checked;

            // 生成問題編號
            int i = 1;
            foreach (RepeaterItem item in this.rptCQ.Items)
            {
                Literal ltlNum = item.FindControl("ltlNum") as Literal;
                ltlNum.Text = i.ToString();
                i++;
            }

            CQModel newCQ = new CQModel()
            {
                CQID = i,
                CQTitle = title,
                QuesTypeID = Convert.ToInt32(this.ddlAddAnsType.SelectedValue),
                CQChoices = ans,
                CQIsEnable = mustAns
            };

            this._mgrCQ.CreateCQ(newCQ);
            this.plcAddCQ.Visible = false;
            this.ImgBtnAdd.Visible = true;
            this.plcCQA.Visible = true;
            this.plcCQA.Visible = true;
            this.ltlAddMsg.Visible = true;
            Response.Redirect(Request.RawUrl);
        }

        protected void btnCancelAddCQ_Click(object sender, EventArgs e)
        {
            this.plcAddCQ.Visible = false;
            this.ImgBtnAdd.Visible = true;
            this.plcCQA.Visible = true;
            this.ltlAddMsg.Visible = true;
        }
        #endregion


        #region "編輯"
        // 點擊編輯鈕(彈出編輯視窗)
        protected void btnEdit_Command(object sender, CommandEventArgs e)
        {
            this.plcEditCQ.Visible = true;
            int id = Convert.ToInt32(e.CommandName);
            var cq = this._mgrCQ.GetCQs(id);

            this.txtEditNum.Text = cq.CQID.ToString();
            this.txtEditQues.Text = cq.CQTitle.ToString();
            this.txtEditAns.Text = cq.CQChoices.ToString();
            this.ckbEditCQMustAns.Checked = cq.CQIsEnable;
        }

        // 編輯視窗內的儲存鈕
        protected void btnSaveEditCQ_Click(object sender, EventArgs e)
        {
            try
            {
                string title = this.txtEditQues.Text.Trim();
                string ans = this.txtEditAns.Text.Trim();

                if (title != null && ans != null)
                {
                    CQModel updateCQ = new CQModel()
                    {
                        CQTitle = title,
                        CQChoices = ans,
                        CQIsEnable = this.ckbEditCQMustAns.Checked
                    };

                    this._mgrCQ.UpdateCQ(updateCQ);
                }
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('變更完畢。');location.href='CommonQuesPageA.aspx';", true);
                this.plcEditCQ.Visible = false;
            }
            catch (Exception)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('内容輸入錯誤。');location.href='CommonQuesPageA.aspx';", true);
            }
        }

        // 取消編輯按鈕
        protected void btnCancelEditCQ_Click(object sender, EventArgs e)
        {
            this.plcEditCQ.Visible = false;
        }
        #endregion

        protected void btnDelete_Command(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandName);
            this._mgrCQ.DeleteCQ(id);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('問題已刪除。');location.href='CommonQuesPageA.aspx';", true);
        }
    }
}