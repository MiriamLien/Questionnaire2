<%@ Page Title="" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="checkPage.aspx.cs" Inherits="questionnaire.checkPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        #userInfoQuesChk {
            margin-left: 520px;
        }

        #btnSpaceChk {
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Repeater runat="server" ID="rptTitle">
        <ItemTemplate>
            <h2 align="center"><%# Eval("Title") %></h2>
        </ItemTemplate>
    </asp:Repeater>
    <br />
    <br />

    <div id="userInfoQuesChk">
        <asp:Literal ID="ltlName" runat="server">姓名</asp:Literal>&emsp;&emsp;
        <asp:Literal ID="ltlNameAns" runat="server"></asp:Literal><br />
        <br />
        <asp:Literal ID="ltlPhone" runat="server">手機</asp:Literal>&emsp;&emsp;
        <asp:Literal ID="ltlPhoneAns" runat="server"></asp:Literal><br />
        <br />
        <asp:Literal ID="ltlEmail" runat="server">Email</asp:Literal>&emsp;&emsp;
        <asp:Literal ID="ltlEmailAns" runat="server"></asp:Literal><br />
        <br />
        <asp:Literal ID="ltlAge" runat="server">年齡</asp:Literal>&emsp;&emsp;
        <asp:Literal ID="ltlAgeAns" runat="server"></asp:Literal><br />
        <br />
        <br />
        <br />
        <p></p>
    </div>
    <br />
    <br />
    <div id="btnSpaceChk">
        <asp:Button ID="btnChange" runat="server" Text="修改" OnClick="btnChange_Click" />
        &emsp;&emsp;&emsp;&emsp;&emsp;
        <asp:Button ID="btnSend" runat="server" Text="送出" OnClick="btnSend_Click" />
    </div>
</asp:Content>
