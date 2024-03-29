﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="mainPage.aspx.cs" Inherits="questionnaire.mainPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        #topDiv {
            margin-top: -70px;
            margin-right: 50px;
        }

        #userInfoQues, #contentDiv, #questionDiv {
            padding-left: 270px;
            padding-right: 210px;
        }

        #btnSpace {
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
        </div>
        <div id="contentDiv">
            <h5>
                <asp:Literal ID="ltlBody" Text='<%# Eval("Body") %>' runat="server"></asp:Literal></h5>
            <br />
            <p>◎ 活動完成後，將會進行抽獎，因此請注意基本資料請留真實資料，以及確認Email和手機號碼是否正確喔！（僅接受Gmail信箱）</p>
            <br /><br />
        </div>
    <div id="userInfoQues">
        <p>打 * 號者為必填(或必選)</p>
        <asp:Literal ID="ltlName" runat="server">姓名 (*)</asp:Literal>&emsp;&emsp;
        <asp:TextBox ID="txtName" runat="server" Width="350"></asp:TextBox><br />
        <h6>
            <asp:Label ID="lblMsgName" runat="server" Visible="false" ForeColor="Red">此欄位為必填。</asp:Label>
        </h6>
        <br />
        <asp:Literal ID="ltlPhone" runat="server">手機 (*)</asp:Literal>&emsp;&emsp;
        <asp:TextBox ID="txtPhone" runat="server" TextMode="Phone" Width="350"></asp:TextBox><br />
        <h6>
            <asp:Label ID="lblMsgPhone" runat="server" Visible="false" ForeColor="Red">此欄位為必填。</asp:Label><br />
            <asp:Label ID="lblMsgPhone2" runat="server" Text="Label" Visible="false" ForeColor="Red">手機輸入不正確，請輸入09開頭、共十位數的號碼。</asp:Label>
        </h6>
        <br />
        <asp:Literal ID="ltlEmail" runat="server">Email (*) </asp:Literal>&emsp;&nbsp;
        <asp:TextBox ID="txtEmail" runat="server" TextMode="Email" Width="350"></asp:TextBox><br />
        <h6>
            <asp:Label ID="lblMsgEmail" runat="server" Visible="false" ForeColor="Red">此欄位為必填。</asp:Label>
            <asp:Label ID="lblMsgEmail2" runat="server" Text="Label" Visible="false" ForeColor="Red">信箱格式輸入不正確。</asp:Label>
            <asp:Label ID="Label6" runat="server" Text="Label" Visible="false" ForeColor="Red"></asp:Label>
        </h6>
        <br />
        <asp:Literal ID="ltlAge" runat="server">年齡 (*)</asp:Literal>&emsp;&emsp;
        <asp:TextBox ID="txtAge" runat="server" TextMode="Number" min="10" Width="350"></asp:TextBox><br />
        <h6>
            <asp:Label ID="lblMsgAge" runat="server" Visible="false" ForeColor="Red">此欄位為必填。</asp:Label>
        </h6>
        <br />
    </div>
    <div id="questionDiv">
        <asp:PlaceHolder ID="plcForQuestion" runat="server"></asp:PlaceHolder>
    </div>
    <div id="btnSpace">
        <br />
        <br />
        <br />
        <h6>
            <asp:Label ID="lblMsg" runat="server" Visible="false" ForeColor="Red">尚有選項未選</asp:Label>
        </h6>
        <asp:Literal ID="ltlQCount" runat="server"></asp:Literal><br />
        <br />
        <asp:Button ID="btnCancel" runat="server" Text="取消" OnClick="btnCancel_Click" />
        &emsp;&emsp;&emsp;&emsp;&emsp;
        <asp:Button ID="btnSend" runat="server" Text="送出" OnClick="btnSend_Click" />
    </div>
</asp:Content>
