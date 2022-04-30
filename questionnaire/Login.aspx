<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="questionnaire.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>登入</title>
    <style>
        #form1 {
            margin-left: 590px;
            margin-top: 240px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div></div>
        <asp:PlaceHolder runat="server" ID="plcLogin">
            <br />
            &nbsp;&nbsp;Account: 
            <asp:TextBox ID="txtAccount" runat="server"></asp:TextBox><br />
            <br />
            Password: 
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox><br />
            <br />
            <br />
            &emsp;&emsp;&emsp;&emsp;
            <asp:Button ID="btnBack" runat="server" ToolTip="返回前台" Text="返回" OnClick="btnBack_Click" />
            &emsp;&emsp;&emsp;
            <asp:Button ID="btnLogin" runat="server" Text=" 登入 " OnClick="btnLogin_Click" /><br />
            <asp:Literal ID="ltlMessage" runat="server"></asp:Literal>
        </asp:PlaceHolder>

        <asp:PlaceHolder runat="server" ID="plcUserPage">
            <br />
            &emsp;&emsp;&emsp;&emsp;&emsp;<asp:Literal ID="ltlAccount" runat="server"></asp:Literal><br />
            <br />
            &emsp;&emsp;&emsp;&emsp;&emsp;請前往 <a href="/BackAdmin/listPageA.aspx">後台 </a>
        </asp:PlaceHolder>
    </form>
</body>
</html>
