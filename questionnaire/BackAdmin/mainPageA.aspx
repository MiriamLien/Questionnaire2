﻿<%@ Page Title="" Language="C#" MasterPageFile="~/BackAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="mainPageA.aspx.cs" Inherits="questionnaire.BackAdmin.mainPageA" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="//code.jquery.com/ui/1.13.1/themes/base/jquery-ui.css">
    <link rel="stylesheet" href="/resources/demos/style.css">
    <script src="https://code.jquery.com/jquery-3.6.0.js"></script>
    <script src="https://code.jquery.com/ui/1.13.1/jquery-ui.js"></script>
    <%-- 列表 --%>
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.11.5/css/jquery.dataTables.css">
    <script type="text/javascript" charset="utf8" src="https://cdn.datatables.net/1.11.5/js/jquery.dataTables.js"></script>
    <style>
        li {
            width: auto;
            font-weight: 600;
            font-size: 18px;
        }

        #tab_alles {
            width: 90%;
        }

        #space1 {
            padding-top: 20px;
            padding-left: 5px;
        }

        #btnSpace1 {
            padding-top: 20px;
            padding-left: 220px;
        }

        #question, #userInfo {
            padding-top: 40px;
            padding-left: 30px;
        }

        #dateDiv {
            text-align: right;
            margin-right: 60px;
            margin-bottom: -30px;
        }

        #questionDiv {
            margin-bottom: 80px;
        }

        #infoSpace {
            margin-right: 30px;
            margin-top: 30px;
            margin-bottom: 50px;
        }

        #statistic {
            margin-left: 10px;
            margin-top: -45px;
        }

        #endSpace {
            height: 50px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="tab_alles">
        <ul>
            <li><a href="#paper">問卷</a></li>
            <li><a href="#question">問題</a></li>
            <li><a href="#userInfo">填寫資料</a></li>
            <li><a href="#statistic">統計</a></li>
        </ul>

        <div id="paper">
            <div id="space1">
                <asp:Literal ID="ltlTitle" runat="server">問卷名稱</asp:Literal>
                <asp:TextBox ID="txtTitle" runat="server" Width="420"></asp:TextBox><br />
                <br />
                <asp:Literal ID="ltlContent" runat="server">描述內容</asp:Literal>
                <asp:TextBox ID="txtContent" runat="server" TextMode="MultiLine" Rows="5" Width="420"></asp:TextBox><br />
                <br />
                <asp:Literal ID="ltlStartDate" runat="server">開始時間</asp:Literal>
                <asp:TextBox ID="txtStartDate" runat="server" TextMode="Date" Width="420" OnTextChanged="txtStartDate_TextChanged" AutoPostBack="true"></asp:TextBox><br />
                <br />
                <asp:Literal ID="ltlEndDate" runat="server">結束時間</asp:Literal>
                <asp:TextBox ID="txtEndDate" runat="server" TextMode="Date" Width="420" OnTextChanged="txtEndDate_TextChanged" AutoPostBack="true"></asp:TextBox><br />
                <br />
                <br />
                <asp:Label runat="server" ID="lblMsg"></asp:Label>
                <br />
                <br />
                <asp:CheckBox ID="ckbPaperEnable" runat="server" Text="已啟用" Checked="true" />
                <br />
                <br />
            </div>
            <div id="btnSpace1">
                <asp:Button ID="btnEditPaperCancel" runat="server" Text="取消" OnClick="btnEditPaperCancel_Click" />
                &emsp;&emsp;&emsp;&emsp;&emsp;
                <asp:Button ID="btnEditPaperSend" runat="server" Text="送出" OnClick="btnEditPaperSend_Click" />
                <br />
                <br />
                <br />
                <br />
            </div>
        </div>

        <div id="question">
            <asp:PlaceHolder ID="plcQues" runat="server">
                <asp:Literal ID="ltlQuesType" runat="server">種類 </asp:Literal>
                <asp:DropDownList ID="ddlQuesType" runat="server" OnSelectedIndexChanged="ddlQuesType_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>&emsp;&emsp;
                    <br />
                <br />
                <asp:Literal ID="ltlQuesTitle" runat="server">問題 </asp:Literal>
                <asp:TextBox ID="txtQuesTitle" runat="server" Width="320" TextMode="MultiLine"></asp:TextBox>&emsp;
            <asp:DropDownList ID="ddlAnsType" runat="server" OnSelectedIndexChanged="ddlAnsType_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>&emsp;
            <asp:CheckBox ID="ckbMustAns" runat="server" Text="必填" Checked="true" />
                <br />
                <br />
                <asp:Literal ID="ltlQuesAns" runat="server">回答 </asp:Literal>
                <asp:TextBox ID="txtQuesAns" runat="server" Width="320" TextMode="MultiLine" Enabled="false"></asp:TextBox>&nbsp;
            <span>﹝多個答案以；分隔﹞</span>&emsp;
            <asp:Button ID="btnAdd" runat="server" Text="加入" CommandName='<%# Eval("QuesID") %>' OnCommand="btnAdd_Command" />
            </asp:PlaceHolder>

            <%--編輯問題--%>
            <asp:PlaceHolder ID="plcEditQues" runat="server" Visible="false">
                <asp:Literal ID="ltlEditQuesTitle" runat="server">問題 </asp:Literal>
                <asp:TextBox ID="txtEditQuesTitle" runat="server" Width="280" TextMode="MultiLine"></asp:TextBox>&nbsp;
            <asp:DropDownList ID="ddlEditAnsType" runat="server" OnSelectedIndexChanged="ddlEditAnsType_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>&nbsp;
            <asp:CheckBox ID="ckbEditMustAns" runat="server" Text="必填" />
                <br />
                <br />
                <asp:Literal ID="ltlEditQuesAns" runat="server">回答 </asp:Literal>
                <asp:TextBox ID="txtEditQuesAns" runat="server" Width="280" TextMode="MultiLine"></asp:TextBox>&nbsp;
            <span>﹝多個答案以；分隔﹞</span>&emsp;
            <asp:Button ID="btnEditCheck" runat="server" Text="確認編輯" CommandName='<%# Eval("QuesID") %>' OnCommand="btnEditCheck_Command" />&nbsp;
            <asp:Button ID="btnEditCancel" runat="server" Text="取消" OnClick="btnEditCancel_Click" />
            </asp:PlaceHolder>
            <br />
            <br />
            <br />
            <asp:ImageButton ID="imgbtnDelete" runat="server" ImageUrl="~/images/deleteICON.png" Width="50" OnClick="imgbtnDelete_Click" /><br />

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
                        <asp:HiddenField ID="hfID" runat="server" Value='<%# Eval("QuesID") %>' />
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
                            <td width="80">
                                <asp:Button ID="btnEdit" runat="server" Text="編輯" CommandName='<%# Eval("QuesID") %>' OnCommand="btnEdit_Command" />
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
            <br />
            <br />
            <br />
        </div>

        <div id="userInfo">
            <asp:PlaceHolder runat="server" ID="plcInfo1">
                <asp:Button ID="btnDownload" runat="server" Text="匯出" OnClick="btnDownload_Click" />
                <p></p>
                <div style="width: 800px;">
                    <table id="tblUserInfo" class="display" border="1">
                        <thead>
                            <tr>
                                <th>編號</th>
                                <th>姓名</th>
                                <th>填寫時間</th>
                                <th>觀看細節</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rptUserInfo" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td width="50px">&nbsp;&nbsp;<asp:Literal runat="server" ID="ltlNum"></asp:Literal></td>
                                        <td width="180px">&nbsp;&nbsp;<%# Eval("Name") %></td>
                                        <td width="220px">&nbsp;&nbsp;<%# Eval("CreateDate") %></td>
                                        <td width="80px">&nbsp;&nbsp;<asp:Button ID="btnUserInfoAndQues" runat="server" Text="前往" CommandName='<%# Eval("UserID") %>' OnCommand="btnUserInfoAndQues_Command" />
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                </div>
                <br />
                <br />
                <br />
                <br />
            </asp:PlaceHolder>

            <asp:PlaceHolder runat="server" ID="plcInfo2" Visible="false">
                <div id="info2">
                    <asp:HiddenField ID="hfUserID" runat="server" Value='<%# Eval("UserID") %>' />
                    <asp:Literal ID="ltlName" runat="server">&nbsp;&nbsp;姓名 </asp:Literal>
                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                    &emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;
                <asp:Literal ID="ltlPhone" runat="server"> 手機 </asp:Literal>
                    <asp:TextBox ID="txtPhone" runat="server" TextMode="Phone"></asp:TextBox><br />
                    <br />
                    <asp:Literal ID="ltlEmail" runat="server">Email </asp:Literal>
                    <asp:TextBox ID="txtEmail" runat="server" TextMode="Email"></asp:TextBox>
                    &emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;
                <asp:Literal ID="ltlAge" runat="server"> 年齡 </asp:Literal>
                    <asp:TextBox ID="txtAge" runat="server" TextMode="Number"></asp:TextBox><br />
                    <br />
                    <div id="dateDiv">
                        <asp:Literal ID="ltlCreateDate" runat="server"></asp:Literal>
                    </div>
                    <div id="questionDiv">
                        <asp:PlaceHolder ID="plcForQuestion" runat="server"></asp:PlaceHolder>
                    </div>
                </div>
            </asp:PlaceHolder>
            <div id="infoSpace" align="right">
                <asp:Button ID="btnBack" runat="server" Text="返回列表" OnClick="btnBack_Click" />
            </div>
        </div>

        <div id="statistic">
            <div align="center">
                <h2>
                    <asp:Literal ID="ltlStaMsg" runat="server"></asp:Literal></h2>
            </div>
            <div>
                <asp:PlaceHolder ID="plcForStatistic" runat="server"></asp:PlaceHolder>
            </div>
            <div id="endSpace"></div>
        </div>
    </div>
    <script>
        $(document).ready(function () {
            $('#tblUserInfo').DataTable({
                "searching": false,
                language: {
                    //url: "https://cdn.datatables.net/plug-ins/1.11.5/i18n/zh-HANT.json",
                    "lengthMenu": "顯示 _MENU_ 項結果",
                    "info": "顯示第 _START_ 至 _END_ 項結果，共 _TOTAL_ 項",
                    "paginate": {
                        "first": "第一頁",
                        "last": "尾頁",
                        "next": "下一頁",
                        "previous": "前一頁"
                    },
                },
                "lengthMenu": [[10, 15, 20, "全部"], [10, 15, 20, "全部"]],
                "order": [[0, "desc"]],
                "ordering": false
            });
        });

        $(function () {
            $("#tab_alles").tabs();
        });
    </script>
</asp:Content>
