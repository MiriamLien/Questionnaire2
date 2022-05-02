<%@ Page Title="" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="checkPage.aspx.cs" Inherits="questionnaire.checkPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        #topDiv {
            margin-top: -70px;
            margin-right: 50px;
        }

        #userInfoQuesChk {
            margin-left: 330px;
        }

        #questionDiv {
            padding-left: 330px;
        }

        #btnSpaceChk {
            margin: 30px;
            text-align: right;
            padding-right: 200px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="topDiv" align="right">
        <asp:Literal ID="ltlState" runat="server"></asp:Literal><br />
        <asp:Literal ID="ltlDate" runat="server"></asp:Literal>
    </div>
    <div id="titleDiv">
        <h2 align="center">
            <asp:Literal ID="ltlTitle" runat="server" Text='<%# Eval("Title") %>'></asp:Literal></h2>
        <br />
        <br />
    </div>
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
    </div>
    <div id="questionDiv">
        <asp:PlaceHolder ID="plcForQuestion" runat="server"></asp:PlaceHolder>
    </div>
    <div id="btnSpaceChk">
        <br />
        <br />
        <br />
        <asp:Button ID="btnChange" runat="server" Text="修改" OnClick="btnChange_Click" />
        &emsp;&emsp;&emsp;&emsp;&emsp;
        <asp:Button ID="btnSend" runat="server" Text="送出" OnClick="btnSend_Click" />
    </div>
</asp:Content>
