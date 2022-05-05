<%@ Page Title="" Language="C#" MasterPageFile="~/BackAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="listPageA.aspx.cs" Inherits="questionnaire.BackAdmin.listPageA" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%-- 列表 --%>
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.11.5/css/jquery.dataTables.css">
    <script type="text/javascript" charset="utf8" src="https://cdn.datatables.net/1.11.5/js/jquery.dataTables.js"></script>
    <style>
        #topDiv {
            border: 2px solid #000000;
            margin-top: 10px;
            padding: 30px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="topDiv">
        <p>
            <asp:Literal ID="ltlTitle" runat="server">問卷標題</asp:Literal>
            <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Literal ID="ltlDate" runat="server">開始／結束</asp:Literal>
            <asp:TextBox ID="txtStartDate" runat="server" TextMode="Date"></asp:TextBox>&nbsp;
            <asp:TextBox ID="txtEndDate" runat="server" TextMode="Date"></asp:TextBox>
            &emsp;&emsp;
            <asp:Button ID="btnSearch" runat="server" Text="搜尋" OnClick="btnSearch_Click" />
        </p>
    </div>
    <br />
    <asp:ImageButton ID="ImgBtnAdd" runat="server" ImageUrl="../images/addICON.png" Width="30" OnClick="ImgBtnAdd_Click" /><br />
    <br />
    <asp:PlaceHolder ID="plcList" runat="server">
        <table id="tblQuestionnaireA" class="display">
            <thead>
                <tr>
                    <th>編號</th>
                    <th>問卷標題</th>
                    <th>狀態</th>
                    <th>開始時間</th>
                    <th>結束時間</th>
                    <th>觀看統計</th>
                    <th></th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptList" runat="server">
                    <ItemTemplate>
                        <asp:HiddenField ID="hfID" runat="server" Value='<%# Eval("ID") %>' />
                        <tr>
                            <td width="60px" align="center"><%# Eval("TitleID") %></td>
                            <td width="350px">&nbsp;&nbsp;<a href="mainPageA.aspx?ID=<%# Eval("ID") %>"><%# Eval("Title") %></a></td>
                            <td width="100px">&nbsp;
                                <asp:Literal ID="ltlState" runat="server" Text='<%# Eval("strIsEnable") %>'></asp:Literal>
                                </td>
                            <td width="140px"><%# Eval("StartDate", "{0:yyyy/MM/dd}") %></td>
                            <td width="140px"><%# Eval("EndDate", "{0:yyyy/MM/dd}") %></td>
                            <td width="90px">&nbsp;&nbsp;<a href="mainPageA.aspx?ID=<%# Eval("ID") %>">前往</a></td>
                            <td width="70px">
                                <asp:Button ID="btnDelete" runat="server" CommandName='<%# Eval("ID") %>' OnCommand="btnDelete_Command" Text="關閉" OnClientClick="return confirm('確定要關閉這份問卷嗎？')" />
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
        <br />
    </asp:PlaceHolder>

    <script>
        $(document).ready(function () {
            $('#tblQuestionnaireA').DataTable({
                "searching": false,
                language: {
                    //url: "https://cdn.datatables.net/plug-ins/1.11.5/i18n/zh-HANT.json",
                    "lengthMenu": "* 點擊加號進入新增；點擊標題進入修改 *" + "<br/>" + "<br/>" + "顯示 _MENU_ 項結果",
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
    </script>
</asp:Content>
