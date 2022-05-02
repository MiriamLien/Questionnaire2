<%@ Page Title="" Language="C#" MasterPageFile="~/BackAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="mainPageA_Add.aspx.cs" Inherits="questionnaire.BackAdmin.mainPageA_Add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
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
    <asp:HiddenField ID="hfCurrentTab" runat="server" />
    <div id="ulDiv">
        <ul class="nav nav-tabs">
            <li class="active"><a data-toggle="tab" href="#paper">問卷</a></li>
            <li><a data-toggle="tab" href="#question">問題</a></li>
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
                </div>
            </div>

            <div id="question" class="tab-pane fade">
                <br />
                <p></p>
                <p>
                    <asp:HiddenField ID="hfID" runat="server" />
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
                <p></p>
                <asp:Button ID="btnQuesCancel" runat="server" Text="取消" OnClick="btnQuesCancel_Click" />
                &emsp;&emsp;&emsp;&emsp;&emsp;
            <asp:Button ID="btnQuesSend" runat="server" Text="送出" OnClick="btnQuesSend_Click" />
            </div>
        </div>
    </div>
    <%--<script type="text/javascript">
        $(document).ready(function () {
            var tabIndex = $("#<%= hfCurrentTab.ClientID %>").val();
            $("#ulDiv").tabs({
                  select: function (event, ui) {
                      $("#<%= hfCurrentTab.ClientID %>").val(ui.index);
              }
                  , selected: tabIndex
              });
          });
    </script>--%>
</asp:Content>
