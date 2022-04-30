﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Form1.aspx.cs" Inherits="questionnaire.Form1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>
        #topDiv{
            margin-top:20px;
        }
        #divTiCon {
            border: 0px solid #000000;
        }
            #divTiCon #divTitle {
                margin: 30px;
            }
            #divTiCon #divContent {
                margin: 30px;
            }
        #divUserInfo {
            margin: 20px auto;
            border: 0px solid #000000;
            text-align: left;
            line-height: 35px;
        }
        #divDynamic {
            margin: 20px auto;
            border: 0px solid #000000;
            text-align: left;
        }
        #btnSpace {
            text-align: right;
            margin-bottom:20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <%-- 投票狀態及日期 --%>
    <div class="col-lg-10" align="right" id="topDiv">
        <asp:Literal ID="ltlVote" runat="server"></asp:Literal><br />
        <asp:Literal ID="ltlTime" runat="server"></asp:Literal>
    </div>

    <%-- 標題&內文 --%>
    <div id="divTiCon" class="col-lg-12" align="center">
        <div id="divTitle">
            <asp:HiddenField ID="hfID" runat="server" />
            <h2>
                <asp:Literal ID="ltlTitle" runat="server"></asp:Literal></h2>
        </div>
        <div id="divContent" class="col-lg-5">
            <asp:Literal ID="ltlContent" runat="server"></asp:Literal>
        </div>
    </div>

    <%-- 必填個人資訊 --%>
    <div id="divUserInfo" class="col-lg-5" align="center">
        <asp:Literal ID="ltlName" runat="server">姓名</asp:Literal>&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtName" runat="server" Height="24px"></asp:TextBox>
        <asp:Label ID="Label1" runat="server" Text="此欄位不可空白"></asp:Label><br />

        <asp:Literal ID="ltlPhone" runat="server">手機</asp:Literal>&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtPhone" runat="server" TextMode="Phone" Height="24px" data-bs-toggle="tooltip" data-bs-placement="top"  title="手機號碼格式為10碼數字"></asp:TextBox>
        <asp:Label ID="Label2" runat="server" Text="此欄位不可空白"></asp:Label><br />

        <asp:Literal ID="ltlEmail" runat="server">Email</asp:Literal>&nbsp;
        <asp:TextBox ID="txtEmail" runat="server" TextMode="Email" Height="24px" data-bs-toggle="tooltip" data-bs-placement="top"  title="Tooltip on top"></asp:TextBox>
        <asp:Label ID="Label3" runat="server" Text="此欄位不可空白"></asp:Label><br />
        <asp:Label ID="Label5" runat="server" Text="無效的郵件地址"></asp:Label><br />

        <asp:Literal ID="ltlAge" runat="server">年齡</asp:Literal>&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtAge" runat="server" TextMode="Number" min="1" Height="24px" data-bs-toggle="tooltip" data-bs-placement="top"  title="Tooltip on top"></asp:TextBox>
        <asp:Label ID="Label4" runat="server" Text="此欄位不可空白"></asp:Label>
    </div>

    <%-- 問卷 --%>
    <div id="divDynamic" class="col-lg-5" align="center">
        <asp:PlaceHolder ID="plcDynamic" runat="server"></asp:PlaceHolder>
    </div>

    <%-- 問題數量及送出 --%>
    <div id="btnSpace" class="col-lg-10">
        <asp:Label ID="lblMsg" runat="server" Text="有未選/未輸入的必選選項" ForeColor="Red" Visible="false"></asp:Label>
        <asp:PlaceHolder ID="plcBtn" runat="server">
            <br />
            <asp:Literal ID="ltlQCount" runat="server"></asp:Literal><br /><br />
            <asp:Button ID="btnCancel" runat="server" Text="取消" OnClick="btnCancel_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnSend" runat="server" Text="送出" OnClick="btnSend_Click" />
        </asp:PlaceHolder>
    </div>
    </form>
</body>
</html>