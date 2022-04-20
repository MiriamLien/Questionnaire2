<%@ Page Title="" Language="C#" MasterPageFile="~/BackAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="mainPageA.aspx.cs" Inherits="questionnaire.BackAdmin.mainPageA" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
    <!--套用jQuery-->
    <script src="../JavaScript/jquery-tablepage-1.0.js"></script>
    <style>
        li {
            width: auto;
            font-weight: 600;
            font-size: 18px;
        }

        #textSpace {
            padding-top: 30px;
            padding-left: 20px;
        }
        #btnSpace {
            padding-top: 20px;
            padding-left: 180px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ul class="nav nav-tabs">
        <li class="active"><a data-toggle="tab" href="#paper">問卷</a></li>
        <li><a data-toggle="tab" href="#question">問題</a></li>
        <li><a data-toggle="tab" href="#userInfo">填寫資料</a></li>
        <li><a data-toggle="tab" href="#statistic">統計</a></li>
    </ul>

    <div class="tab-content">
        <div id="paper" class="tab-pane fade in active">
            <div id="textSpace">
                <asp:Literal ID="ltlTitle" runat="server">問卷名稱</asp:Literal>
                <asp:TextBox ID="txtTitle" runat="server" Width="320"></asp:TextBox><br />
                <br />
                <asp:Literal ID="ltlContent" runat="server">描述內容</asp:Literal>
                <asp:TextBox ID="txtContent" runat="server" TextMode="MultiLine" Width="320"></asp:TextBox><br />
                <br />
                <asp:Literal ID="ltlStartDate" runat="server">開始時間</asp:Literal>
                <asp:TextBox ID="txtStartDate" runat="server" TextMode="Date" Width="320"></asp:TextBox><br />
                <br />
                <asp:Literal ID="ltlEndDate" runat="server">結束時間</asp:Literal>
                <asp:TextBox ID="txtEndDate" runat="server" TextMode="Date" Width="320"></asp:TextBox><br />
                <br />
                <br />
                <asp:CheckBox ID="ckbPaper" runat="server" Text="已啟用" Checked="true" />
                <br />
            </div>
            <div id="btnSpace">
                <asp:Button ID="btnPaperCancel" runat="server" Text="取消" OnClick="btnPaperCancel_Click" />
                &emsp;&emsp;&emsp;&emsp;&emsp;
                <asp:Button ID="btnPaperSend" runat="server" Text="送出" />
            </div>
        </div>

        <div id="question" class="tab-pane fade">
            <p>
                <asp:Literal ID="ltlQuesType" runat="server">種類</asp:Literal>
                <asp:DropDownList ID="ddlQuesType" runat="server"></asp:DropDownList>&emsp;&emsp;
                <asp:Button ID="btnUse" runat="server" Text="填入" OnClick="btnUse_Click" />
                <br />
                <br />
                <asp:Literal ID="ltlQuesTitle" runat="server">問題</asp:Literal>
                <asp:TextBox ID="txtQuesTitle" runat="server" Width="220"></asp:TextBox>&nbsp;
                <asp:DropDownList ID="ddlAnsType" runat="server"></asp:DropDownList>&nbsp;
                <asp:CheckBox ID="ckbMustAns" runat="server" Text="必填" />
                <br />
                <asp:Literal ID="ltlQuesAns" runat="server">回答</asp:Literal>
                <asp:TextBox ID="txtQuesAns" runat="server" Width="220" TextMode="MultiLine"></asp:TextBox>&nbsp;
                <span>﹝多個答案以；分隔﹞</span>&emsp;
                <asp:Button ID="btnAdd" runat="server" Text="加入" OnClick="btnAdd_Click" /><br />
            </p>
            <br />
            <asp:ImageButton ID="ImgBtnDel" runat="server" ImageUrl="../images/deleteICON.png" Width="50" />
            <table border="1">
                <tr>
                    <th></th>
                    <th>編號</th>
                    <th>問題</th>
                    <th>種類</th>
                    <th>必填</th>
                    <th></th>
                </tr>
                <tr>
                    <td width="50px">
                        <asp:CheckBox ID="ckbForDel" runat="server" />
                    </td>
                    <td width="60px"></td>
                    <td width="200px"></td>
                    <td width="120px"></td>
                    <td width="50px">
                        <asp:CheckBox ID="ckbMustAns2" runat="server" />
                    </td>
                    <td width="50px"><a>編輯</a></td>
                </tr>
            </table>
            <p></p>
            <asp:Button ID="btnQuesCancel" runat="server" Text="取消" />
            &emsp;&emsp;&emsp;&emsp;&emsp;
            <asp:Button ID="btnQuesSend" runat="server" Text="送出" />
        </div>

        <div id="userInfo" class="tab-pane fade">
            <asp:PlaceHolder runat="server" ID="plcInfo1">
                <asp:Button ID="Button3" runat="server" Text="匯出" />
                <p></p>
                <table id="tblUserInfo" border="1">
                    <tr>
                        <th>編號</th>
                        <th>姓名</th>
                        <th>填寫時間</th>
                        <th>觀看細節</th>
                    </tr>
                    <tr>
                        <td width="60px"></td>
                        <td width="120px"></td>
                        <td width="150px"></td>
                        <td width="80px"><a>前往</a></td>
                    </tr>
                </table>
                <br />
                <span id='table_pageA2'></span>

            </asp:PlaceHolder>

            <asp:PlaceHolder runat="server" ID="plcInfo2" Visible="false">
                <asp:Literal ID="ltlName" runat="server">姓名</asp:Literal>
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>&emsp;&emsp;&emsp;
                <asp:Literal ID="ltlPhone" runat="server">手機</asp:Literal>
                <asp:TextBox ID="txtPhone" runat="server" TextMode="Phone"></asp:TextBox><br />
                <asp:Literal ID="ltlEmail" runat="server">Email</asp:Literal>
                <asp:TextBox ID="txtEmail" runat="server" TextMode="Email"></asp:TextBox>&emsp;&emsp;&emsp;
                <asp:Literal ID="ltlAge" runat="server">年齡</asp:Literal>
                <asp:TextBox ID="txtAge" runat="server" TextMode="Number"></asp:TextBox><br />
                <br />
                填寫時間
                <p>2022/12/12 21:09:23</p>
                <br />
                <br />

            </asp:PlaceHolder>
        </div>

        <div id="statistic" class="tab-pane fade">
            <p>
                
            </p>
        </div>
    </div>

    <script>
        $("#tblUserInfo").tablepage($("#table_pageA2"), 10);
    </script>
</asp:Content>
