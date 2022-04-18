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
    public partial class mainPageA : System.Web.UI.Page
    {
        private bool _isEditMode = false;

        private QuesContentsManager _mgrQuesContents = new QuesContentsManager();
        //private QuesDetailManager _mgrQuesDetail = new QuesDetailManager();
        private QuesTypeManager _mgrQuesType = new QuesTypeManager();
        private CQManager _mgrCQ = new CQManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //問題類型下拉繫結
                var QTypeList = this._mgrQuesType.GetQuesTypesList();
                this.ddlAnsType.DataSource = QTypeList;
                this.ddlAnsType.DataValueField = "QuesTypeID";
                this.ddlAnsType.DataTextField = "QuesType1";
                this.ddlAnsType.DataBind();

                //自訂、常用問題下拉繫結
                var TypeList = this._mgrCQ.GetCQsList();
                this.ddlQuesType.DataSource = TypeList;
                this.ddlQuesType.DataValueField = "CQID";
                this.ddlQuesType.DataTextField = "CQTitle";
                this.ddlQuesType.DataBind();

                this.ddlQuesType.Items.Insert(0, new ListItem("自訂問題", "0"));
            }


            // 做編輯模式或新增模式的判斷
            if (!string.IsNullOrWhiteSpace(this.Request.QueryString["ID"]))
                this._isEditMode = true;
            else
                this._isEditMode = false;


            if (this._isEditMode)
                this.InitEditMode();
            else
                this.InitCreateMode();
        }

        /// <summary> 新增模式初始化 </summary>
        private void InitCreateMode()
        {
        }
        /// <summary> 編輯模式初始化 </summary>
        private void InitEditMode()
        {
            string idText = this.Request.QueryString["ID"];
            var quesList = this._mgrQuesContents.GetQuesContentsList(idText);

            foreach (var item in quesList)
            {
                this.txtTitle.Text = item.Title;
                this.txtContent.Text = item.Body;
                this.txtStartDate.Text = item.StartDate.ToString();
                this.txtEndDate.Text = item.EndDate.ToString();
            }
            
            string url = this.Request.Url.LocalPath + "?ID=" + idText;
            this.Response.Redirect(url);
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {

        }

        protected void btnUse_Click(object sender, EventArgs e)
        {
            int cqid = Convert.ToInt32(this.ddlQuesType.SelectedValue.Trim());
            CQAndTypeModel CQs = this._mgrQuesType.GetCQType(cqid);

            if (CQs != null)
            {
                this.txtQuesTitle.Text = this.ddlQuesType.SelectedItem.ToString();
                this.txtQuesAns.Text = CQs.CQChoices;
                this.ddlAnsType.SelectedIndex = CQs.QuesTypeID - 1;

                var isEnable = CQs.CQIsEnable;
                if (isEnable)
                {
                    this.ckbMustAns.Checked = true;
                }
            }
        }

        protected void btnPaperCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("listPageA.aspx");
        }
    }
}