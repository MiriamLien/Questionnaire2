<%@ Page Title="" Language="C#" MasterPageFile="~/BackAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="mainPageA_Add.aspx.cs" Inherits="questionnaire.BackAdmin.mainPageA_Add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>--%>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.13.1/themes/base/jquery-ui.css">
    <link rel="stylesheet" href="/resources/demos/style.css">
    <script src="https://code.jquery.com/jquery-3.6.0.js"></script>
    <script src="https://code.jquery.com/ui/1.13.1/jquery-ui.js"></script>
    <style>
        li {
            width: auto;
            font-weight: 600;
            font-size: 18px;
        }

        #tabs {
            width: 90%;
            height: 580px;
        }

        #textSpace {
            padding-top: 20px;
            padding-left: 20px;
        }

        #btnSpace {
            padding-top: 20px;
            padding-left: 220px;
        }

        #question {
            padding-top: 35px;
            padding-left: 45px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField ID="hfCurrentTab" runat="server" />
    <div id="tabs">
        <ul>
            <li><a href="#paper">問卷</a></li>
            <li><a href="#question">問題</a></li>
        </ul>

        <div id="paper">
            <div id="textSpace">
                <asp:Literal ID="ltlTitle" runat="server">問卷名稱</asp:Literal>
                <asp:TextBox ID="txtTitle" runat="server" Width="420"></asp:TextBox><br />
                <br />
                <asp:Literal ID="ltlContent" runat="server">描述內容</asp:Literal>
                <asp:TextBox ID="txtContent" runat="server" TextMode="MultiLine" Width="420"></asp:TextBox><br />
                <br />
                <asp:Literal ID="ltlStartDate" runat="server">開始時間</asp:Literal>
                <asp:TextBox ID="txtStartDate" runat="server" TextMode="Date" Width="420" OnTextChanged="txtStartDate_TextChanged" AutoPostBack="true"></asp:TextBox><br />
                <br />
                <asp:Literal ID="ltlEndDate" runat="server">結束時間</asp:Literal>
                <asp:TextBox ID="txtEndDate" runat="server" TextMode="Date" Width="420" OnTextChanged="txtEndDate_TextChanged" AutoPostBack="true"></asp:TextBox><br />
                <br />
                <asp:Label runat="server" ID="lblMsg"></asp:Label>
                <br />
                <br />
                <asp:CheckBox ID="ckbPaperEnable" runat="server" Text="已啟用" Checked="true" />
                <br />
            </div>
            <div id="btnSpace">
                <asp:Button ID="btnPaperCancel" runat="server" Text="取消" OnClick="btnPaperCancel_Click" />
                &emsp;&emsp;&emsp;&emsp;&emsp;
                <asp:Button ID="btnPaperSend" runat="server" Text="送出" OnClick="btnPaperSend_Click" />
                <br />
            </div>
        </div>

        <div id="question">
            <asp:HiddenField ID="hfID" runat="server" />
            <asp:Literal ID="ltlQuesType" runat="server">種類</asp:Literal>
            <asp:DropDownList ID="ddlQuesType" runat="server" OnSelectedIndexChanged="ddlQuesType_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>&emsp;&emsp;
            <br /><br />
            <asp:Literal ID="ltlQuesTitle" runat="server">問題</asp:Literal>
            <asp:TextBox ID="txtQuesTitle" runat="server" Width="320" TextMode="MultiLine"></asp:TextBox>
            &emsp;
                <asp:DropDownList ID="ddlAnsType" runat="server" OnSelectedIndexChanged="ddlAnsType_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>&emsp;
                <asp:CheckBox ID="ckbMustAns" runat="server" Text="必填" />
            <br /><p></p>
            <asp:Literal ID="ltlQuesAns" runat="server">回答</asp:Literal>
            <asp:TextBox ID="txtQuesAns" runat="server" Width="320" TextMode="MultiLine"></asp:TextBox>&nbsp;
                <span>﹝多個答案以；分隔﹞</span>&emsp;&emsp;
                <asp:Button ID="btnAdd" runat="server" Text="加入" OnClick="btnAdd_Click" /><br />
            <br />
            <br />
            <table border="1">
                <tr>
                    <th></th>
                    <th>編號</th>
                    <th>問題</th>
                    <th>種類</th>
                    <th>必填</th>
                    <th></th>
                </tr>
                <asp:Repeater ID="rptQuestion" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td width="50">&emsp;<asp:CheckBox ID="ckbForDel" runat="server" />
                            </td>
                            <td width="60">&nbsp;<asp:Literal runat="server" ID="ltlNum"></asp:Literal>
                            </td>
                            <td width="280">
                                <%# Eval("QuesTitle") %>
                            </td>
                            <td width="100">
                                <%# Eval("QuesType1") %>
                            </td>
                            <td width="50">
                                <asp:CheckBox ID="ckbMustAns2" runat="server" Checked='<%# Eval("IsEnable") %>' Enabled="false" />
                            </td>
                            <td width="50"><a>編輯</a></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
            <p></p><br />
            <asp:Button ID="btnQuesCancel" runat="server" Text="取消" OnClick="btnQuesCancel_Click" />
            &emsp;&emsp;&emsp;&emsp;&emsp;
            <asp:Button ID="btnQuesSend" runat="server" Text="送出" OnClick="btnQuesSend_Click" />
        </div>
    </div>
    <script>
        $(function () {
            $("#tabs").tabs();
        });
    </script>
</asp:Content>
