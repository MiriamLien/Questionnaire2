<%@ Page Title="" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="mainPage.aspx.cs" Inherits="questionnaire.mainPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        #userInfoQues, #contentDiv {
            padding-left: 280px;
        }

        #btnSpace {
            margin: 30px;
            text-align: right;
            padding-right: 200px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="titleDiv">
        <h2 align="center">
            <asp:Literal ID="ltlTitle" runat="server" Text='<%# Eval("Title") %>'></asp:Literal></h2>
        <br />
    </div>
    <div id="contentDiv">
        <h5>
            <asp:Literal ID="ltlBody" Text='<%# Eval("Body") %>' runat="server"></asp:Literal></h5>
        <br />
        <p>* 活動完成後，將會進行抽獎，因此請注意基本資料請留真實資料，以及確認Email和手機號碼是否正確喔！*</p>
        <br />
    </div>
    <div id="userInfoQues">
        <asp:Literal ID="ltlName" runat="server">姓名</asp:Literal>&emsp;&emsp;
        <asp:TextBox ID="txtName" runat="server" Width="350"></asp:TextBox><br />
        <br />
        <asp:Literal ID="ltlPhone" runat="server">手機</asp:Literal>&emsp;&emsp;
        <asp:TextBox ID="txtPhone" runat="server" TextMode="Phone" Width="350"></asp:TextBox><br />
        <br />
        <asp:Literal ID="ltlEmail" runat="server">Email </asp:Literal>&emsp;&nbsp;
        <asp:TextBox ID="txtEmail" runat="server" TextMode="Email" Width="350"></asp:TextBox><br />
        <br />
        <asp:Literal ID="ltlAge" runat="server">年齡</asp:Literal>&emsp;&emsp;
        <asp:TextBox ID="txtAge" runat="server" TextMode="Number" min="10" Width="350"></asp:TextBox><br />
        <br />
        <br />
        <br />
    </div>
    <asp:Repeater runat="server" ID="rptQuestion">
        <ItemTemplate>
            <p><%# Eval("quesTitle") %></p>
            <p><%# Eval("QuesChoices") %></p>

        </ItemTemplate>
    </asp:Repeater>
    <div id="btnSpace">
        <asp:Button ID="btnCancel" runat="server" Text="取消" OnClick="btnCancel_Click" />
        &emsp;&emsp;&emsp;&emsp;&emsp;
        <asp:Button ID="btnSend" runat="server" Text="送出" OnClick="btnSend_Click" />
    </div>
</asp:Content>
