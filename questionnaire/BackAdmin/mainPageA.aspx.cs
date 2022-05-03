using questionnaire.Managers;
using questionnaire.Models;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using questionnaire.ORM;

namespace questionnaire.BackAdmin
{
    public partial class mainPageA : System.Web.UI.Page
    {
        //private bool _isEditMode = false;

        private QuesContentsManager _mgrQuesContents = new QuesContentsManager();
        private QuesDetailManager _mgrQuesDetail = new QuesDetailManager();
        private QuesTypeManager _mgrQuesType = new QuesTypeManager();
        private CQManager _mgrCQ = new CQManager();
        private UserInfoManager _mgruserInfo = new UserInfoManager();
        private UserQuesDetailManager _mgruserQuesDetail = new UserQuesDetailManager();
        Guid id = Guid.NewGuid();
        int i = 1;

        protected void Page_Load(object sender, EventArgs e)    //編輯模式
        {
            if (!IsPostBack)
            {
                string idText = Request.QueryString["ID"];
                Guid questionnaireID = Guid.Parse(idText);

                // 如果沒有帶 id ，跳回列表頁
                if (string.IsNullOrWhiteSpace(idText))
                    this.BackToListPage();

                Guid iD;
                if (!Guid.TryParse(idText, out iD))
                    this.BackToListPage();

                #region "帶入內容"
                // 帶入問卷內容
                var QList = this._mgrQuesContents.GetQuesContent(questionnaireID);
                this.txtTitle.Text = QList.Title;
                this.txtContent.Text = QList.Body;
                this.txtStartDate.Text = QList.StartDate.ToString("yyyy-MM-dd");
                this.txtEndDate.Text = QList.EndDate.ToString("yyyy-MM-dd");
                this.ckbPaperEnable.Checked = QList.IsEnable;

                // 帶入問題內容
                var questionList = this._mgrQuesDetail.GetQuesDetailAndTypeList(questionnaireID);
                this.rptQuestion.DataSource = questionList;
                this.rptQuestion.DataBind();

                //問題類型下拉繫結
                var QTypeList = this._mgrQuesType.GetQuesTypesList();
                this.ddlAnsType.DataSource = QTypeList;
                this.ddlAnsType.DataValueField = "QuesTypeID";
                this.ddlAnsType.DataTextField = "QuesType1";
                this.ddlAnsType.DataBind();

                //自訂、常用問題下拉繫結
                string a = string.Empty;
                var TypeList = this._mgrCQ.GetCQsList(a);
                this.ddlQuesType.DataSource = TypeList;
                this.ddlQuesType.DataValueField = "CQID";
                this.ddlQuesType.DataTextField = "CQTitle";
                this.ddlQuesType.DataBind();

                this.ddlQuesType.Items.Insert(0, new ListItem("自訂問題", "0"));

                if (questionList != null || questionList.Count > 0)
                {
                    // 生成問題編號
                    int i = 1;
                    foreach (RepeaterItem item in this.rptQuestion.Items)
                    {
                        Literal ltlNum = item.FindControl("ltlNum") as Literal;
                        ltlNum.Text = i.ToString();
                        i++;
                    }
                }

                // 填寫資料頁籤(使用者資料)
                var userInfoList = this._mgruserInfo.GetUserInfoList(questionnaireID);
                this.rptUserInfo.DataSource = userInfoList;
                this.rptUserInfo.DataBind();

                if (questionList != null || questionList.Count > 0)
                {
                    // 生成問題編號
                    int i = 1;
                    foreach (RepeaterItem item in this.rptUserInfo.Items)
                    {
                        Literal ltlNum = item.FindControl("ltlNum") as Literal;
                        ltlNum.Text = i.ToString();
                        i++;
                    }
                }

                // 帶入問卷和問題內容(統計頁)
                this.rptStatistic.DataSource = questionList;
                this.rptStatistic.DataBind();

                if (questionList != null || questionList.Count > 0)
                {
                    // 生成問題編號
                    int i = 1;
                    foreach (RepeaterItem item in this.rptStatistic.Items)
                    {
                        Literal ltlNum = item.FindControl("ltlNum") as Literal;
                        ltlNum.Text = i.ToString();
                        i++;
                    }
                }
                #endregion

                // 取得問題內容
                var quesList = this._mgrQuesDetail.GetQuesDetailList(questionnaireID);

                foreach (var question in quesList)
                {
                    string title = $"<br /><br /><br />{i}. {(question.QuesTitle).Trim()}";
                    if (question.IsEnable == true)
                        title += " (*)";

                    i += 1;
                    Literal ltlQuestion = new Literal();
                    ltlQuestion.Text = title + "<br />&emsp;";
                    this.plcForQuestion.Controls.Add(ltlQuestion);

                    switch (question.QuesTypeID)
                    {
                        case 1:
                            createTextBox(question);
                            break;
                        case 2:
                            createRdb(question);
                            break;
                        case 3:
                            createCkb(question);
                            break;
                    }
                }
            }
        }

        //string url = this.Request.Url.LocalPath + "?ID=" + idText;
        //this.Response.Redirect(url);

        #region "問卷"
        protected void btnEditPaperCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("listPageA.aspx");
        }

        // 編輯問卷後送出
        protected void btnEditPaperSend_Click(object sender, EventArgs e)
        {
            string idText = Request.QueryString["ID"];
            Guid questionnaireID = Guid.Parse(idText);
            var q = this._mgrQuesContents.GetQuesContent(questionnaireID);

            string title = this.txtTitle.Text.Trim();
            string content = this.txtContent.Text.Trim();
            string startDT = this.txtStartDate.Text.Trim();
            string endDT = this.txtEndDate.Text.Trim();

            if (title != null && content != null && startDT != null && endDT != null)
            {
                QuesContentsModel model = new QuesContentsModel
                {
                    ID = questionnaireID,
                    TitleID = q.TitleID,
                    Title = title,
                    Body = content,
                    StartDate = Convert.ToDateTime(startDT),
                    EndDate = Convert.ToDateTime(endDT),
                    IsEnable = this.ckbPaperEnable.Checked
                };

                this._mgrQuesContents.UpdateQues(model);
                //Response.Redirect("mainPageA.aspx?ID=" + questionnaireID);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", $"alert('問卷編輯完成。');location.href='mainPageA.aspx?ID={questionnaireID}';", true);
            }
        }
        #endregion


        #region "編輯問題"
        // (問題)點擊編輯鈕
        protected void btnEdit_Command(object sender, CommandEventArgs e)
        {
            this.plcQues.Visible = false;
            this.plcEditQues.Visible = true;

            //取得該問題的資料
            int quesID = Convert.ToInt32(e.CommandName);
            var ques = this._mgrQuesDetail.GetQuesDetail(quesID);

            //問題類型下拉繫結
            var QTypeList = this._mgrQuesType.GetQuesTypesList();
            this.ddlEditAnsType.DataSource = QTypeList;
            this.ddlEditAnsType.DataValueField = "QuesTypeID";
            this.ddlEditAnsType.DataTextField = "QuesType1";
            this.ddlEditAnsType.DataBind();

            //判斷該問題有無答案
            bool hasChoise;
            if (ques.QuesTypeID == 2 || ques.QuesTypeID == 3)
                hasChoise = true;
            else
                hasChoise = false;

            if (!hasChoise)
            {
                this.btnEditCheck.CommandName = ques.QuesID.ToString();
                this.txtEditQuesTitle.Text = ques.QuesTitle.ToString();
                this.ddlEditAnsType.SelectedValue = ques.QuesTypeID.ToString();
                this.ckbEditMustAns.Checked = ques.IsEnable;
            }
            else
            {
                this.btnEditCheck.CommandName = ques.QuesID.ToString();
                this.txtEditQuesTitle.Text = ques.QuesTitle.ToString();
                this.txtEditQuesAns.Text = ques.QuesChoices.ToString();
                this.ddlEditAnsType.SelectedValue = ques.QuesTypeID.ToString();
                this.ckbEditMustAns.Checked = ques.IsEnable;
            }
        }

        // 把問題填入TextBox裡
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

        // 新增問題至DB(編輯模式)
        protected void btnAdd_Command(object sender, CommandEventArgs e)
        {
            string idText = Request.QueryString["ID"];
            Guid questionnaireID = Guid.Parse(idText);
            var ques = this._mgrQuesContents.GetQuesContent(questionnaireID);

            string q = this.txtQuesTitle.Text.Trim();
            string a = this.txtQuesAns.Text.Trim();

            QuesDetailModel model = new QuesDetailModel()
            {
                ID = ques.ID,
                QuesTitle = q,
                QuesChoices = a,
                QuesTypeID = Convert.ToInt32(this.ddlAnsType.SelectedValue),
                IsEnable = this.ckbMustAns.Checked
            };
            this._mgrQuesDetail.CreateQuesDetail(model);
            Response.Redirect(Request.RawUrl);
        }

        // 問題編輯好後的確認鈕
        protected void btnEditCheck_Command(object sender, CommandEventArgs e)
        {
            string idText = Request.QueryString["ID"];
            Guid questionnaireID = Guid.Parse(idText);

            int quesid = Convert.ToInt32(this.btnEditCheck.CommandName);
            var item = this._mgrQuesDetail.GetQuesDetail(quesid);

            QuesDetailModel model = new QuesDetailModel()
            {
                ID = item.ID,
                QuesID = item.QuesID,
                QuesTitle = this.txtEditQuesTitle.Text,
                QuesChoices = this.txtEditQuesAns.Text,
                QuesTypeID = Convert.ToInt32(this.ddlEditAnsType.SelectedValue),
                IsEnable = this.ckbEditMustAns.Checked
            };

            this._mgrQuesDetail.UpdateQuesDetail(model);
            //Response.Redirect("mainPageA.aspx?ID=" + questionnaireID);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", $"alert('問題編輯完成。');location.href='mainPageA.aspx?ID={questionnaireID}';", true);
        }

        // 取消編輯
        protected void btnEditCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
            this.plcQues.Visible = true;
            this.plcEditQues.Visible = false;
        }
        #endregion

        // 刪除問題
        protected void imgbtnDelete_Click(object sender, ImageClickEventArgs e)
        {
            string idText = Request.QueryString["ID"];
            Guid questionnaireID = Guid.Parse(idText);

            foreach (RepeaterItem item in this.rptQuestion.Items)
            {
                HiddenField hfID = item.FindControl("hfID") as HiddenField;
                CheckBox ckbForDel = item.FindControl("ckbForDel") as CheckBox;
                Button btnEdit = item.FindControl("btnEdit") as Button;

                if (ckbForDel.Checked && Int32.TryParse(hfID.Value, out int id))
                {
                    this._mgrQuesDetail.DeleteQuesDetail(Convert.ToInt32(btnEdit.CommandName));
                }
            }

            //Response.Redirect("mainPageA.aspx?ID=" + questionnaireID);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", $"alert('問題已刪除。');location.href='mainPageA.aspx?ID={questionnaireID}';", true);
        }

        private void BackToListPage()
        {
            this.Response.Redirect("listPageA.aspx", true);
        }

        #region "問卷管理內頁3"
        // 匯出鈕
        protected void btnDownload_Click(object sender, EventArgs e)
        {
            string idText = Request.QueryString["ID"];
            Guid id = new Guid(idText);
            var quesList = this._mgrQuesDetail.GetQuesDetailList(id);

            string folder = "F:\\ccc\\ExportToCSV";
            string fileName = $"Q_{idText}.csv";
            string fullPath = $"F:\\ccc\\ExportToCSV\\Q_{idText}.csv";

            DataTable dt = new DataTable();
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            if (!File.Exists(fileName))
            {
                File.Create(fileName);
            }
            ExportToCSV(dt, fullPath);

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", $"alert('匯出成功。');", true);
        }

        // DataTable匯出成CSV檔
        public void ExportToCSV(DataTable dt, string filePath)
        {
            string idText = Request.QueryString["ID"];
            Guid id = new Guid(idText);
            var questionList = this._mgrQuesDetail.GetQuesDetailList(id);
            var userInfoList = this._mgruserInfo.GetUserInfoList(id);

            DataTable dataTable = new DataTable();
            DataRow row;
            dataTable.Columns.Add("Name", typeof(string));
            dataTable.Columns.Add("Phone", typeof(string));
            dataTable.Columns.Add("Email", typeof(string));
            dataTable.Columns.Add("Age", typeof(string));
            dataTable.Columns.Add("CreateDate", typeof(DateTime));

            try
            {
                for (int i = 0; i < userInfoList.Count; i++)
                {
                    row = dataTable.NewRow();
                    row["Name"] = userInfoList[i].Name;
                    row["Phone"] = userInfoList[i].Phone;
                    row["Email"] = userInfoList[i].Email;
                    row["Age"] = userInfoList[i].Age;
                    row["CreateDate"] = userInfoList[i].CreateDate;

                    for (int j = 0; j < questionList.Count; j++)
                    {
                        if (dataTable.Columns.Contains($"QuesTitle{j + 1}") == false)
                        {
                            dataTable.Columns.Add($"QuesTitle{j + 1}", typeof(string));
                            dataTable.Columns.Add($"Answer{j + 1}", typeof(string));
                        }

                        row[$"QuesTitle{j + 1}"] = questionList[j].QuesTitle;
                        Guid userID = userInfoList[i].UserID;
                        var userAndAns = this._mgruserQuesDetail.GetUserInfoList(userID);
                        foreach (var item in userAndAns)
                        {
                            if (item.QuesID == questionList[j].QuesID)
                            {
                                row[$"Answer{j + 1}"] = item.Answer;
                            }
                        }
                    }

                    dataTable.Rows.Add(row);
                }

                FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.UTF8);
                string data = "";

                for (int i = 0; i < dataTable.Columns.Count; i++)//寫入列名
                {
                    data += dataTable.Columns[i].ColumnName.ToString();
                    if (i < dataTable.Columns.Count - 1)
                    {
                        data += ",";
                    }
                }
                sw.WriteLine(data);

                //寫入各行資料
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    data = "";
                    for (int j = 0; j < dataTable.Columns.Count; j++)
                    {
                        string str = dataTable.Rows[i][j].ToString();
                        //替換英文冒號 英文冒號需要換成兩個冒號
                        str = str.Replace("\"", "\"\"");
                        //含逗號 冒號 換行符的需要放到引號中
                        if (str.Contains(',') || str.Contains('"')
                          || str.Contains('\r') || str.Contains('\n'))
                        {
                            str = string.Format("\"{0}\"", str);
                        }

                        data += str;
                        if (j < dataTable.Columns.Count - 1)
                        {
                            data += ",";
                        }
                    }
                    sw.WriteLine(data);
                }
                sw.Close();
                fs.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // 前往觀看填寫的詳細內容
        protected void btnUserInfoAndQues_Command(object sender, CommandEventArgs e)
        {
            this.plcInfo1.Visible = false;
            this.plcInfo2.Visible = true;

            string idText = Request.QueryString["ID"];
            Guid questionnaireID = Guid.Parse(idText);
            var quesList = this._mgrQuesDetail.GetQuesDetailList(questionnaireID);

            Guid userID = new Guid(e.CommandName);
            var userInfoList = this._mgruserInfo.GetUserInfoList2(userID);

            for (int i = 0; i < userInfoList.Count; i++)
            {
                this.txtName.Text = userInfoList[i].Name;
                this.txtPhone.Text = userInfoList[i].Phone;
                this.txtEmail.Text = userInfoList[i].Email;
                this.txtAge.Text = userInfoList[i].Age;
                this.ltlCreateDate.Text = "填寫日期 " + (userInfoList[i].CreateDate).ToString("yyyy/MM/dd");
            }

            // 動態生成控制項和題目
            foreach (var question in quesList)
            {
                string title = $"<br /><br /><br />{i}. {(question.QuesTitle).Trim()}";
                if (question.IsEnable == true)
                    title += " (*)";

                i += 1;
                Literal ltlQuestion = new Literal();
                ltlQuestion.Text = title + "<br />&emsp;";
                this.plcForQuestion.Controls.Add(ltlQuestion);

                switch (question.QuesTypeID)
                {
                    case 1:
                        createTextBox(question);
                        break;
                    case 2:
                        createRdb(question);
                        break;
                    case 3:
                        createCkb(question);
                        break;
                }
            }
        }

        private void createTextBox(QuesDetail ques)
        {
            TextBox txt = new TextBox();
            txt.ID = "Q" + ques.QuesID.ToString();
            this.plcForQuestion.Controls.Add(txt);
        }

        private void createRdb(QuesDetail ques)
        {
            RadioButtonList rdbList = new RadioButtonList();
            rdbList.ID = "Q" + ques.QuesID.ToString();
            this.plcForQuestion.Controls.Add(rdbList);

            string[] ansArray = (ques.QuesChoices).Trim().Split(';');

            for (int i = 0; i < ansArray.Length; i++)
            {
                RadioButton radio = new RadioButton();
                radio.Text = ansArray[i].ToString();
                radio.ID = ques.QuesID + i.ToString();
                radio.GroupName = "group" + ques.QuesID;
                this.plcForQuestion.Controls.Add(radio);
                this.plcForQuestion.Controls.Add(new LiteralControl("<br />&emsp;"));
            }
        }

        private void createCkb(QuesDetail ques)
        {
            CheckBoxList ckbList = new CheckBoxList();
            ckbList.ID = "Q" + ques.QuesID.ToString();
            this.plcForQuestion.Controls.Add(ckbList);

            string[] ansArray = (ques.QuesChoices).Trim().Split(';');

            for (int i = 0; i < ansArray.Length; i++)
            {
                CheckBox check = new CheckBox();
                check.Text = ansArray[i].ToString();
                check.ID = ques.QuesID + i.ToString();
                this.plcForQuestion.Controls.Add(check);
                this.plcForQuestion.Controls.Add(new LiteralControl("&emsp;"));
            }
        }
        #endregion
    }
}