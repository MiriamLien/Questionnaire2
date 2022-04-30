<%@ Page Title="" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="listPage.aspx.cs" Inherits="questionnaire.listPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%-- 列表 --%>
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.11.5/css/jquery.dataTables.css">
    <script type="text/javascript" charset="utf8" src="https://cdn.datatables.net/1.11.5/js/jquery.dataTables.js"></script>
    <style>
        #loginDiv {
            margin-top: -120px;
            margin-right: 30px;
            margin-bottom: 90px;
        }
        #topDiv {
            border: 2px solid #000000;
            margin: 80px;
            margin-top: 10px;
            margin-bottom: -35px;
            padding: 30px;
        }

        #listDiv {
            margin: 80px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="loginDiv" align="right">
        <asp:Button ID="btnLogin" runat="server" ToolTip="前往後台請先登入" Text=" 登入 " OnClick="btnLogin_Click" />
    </div>
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
    <div id="listDiv">
        <asp:PlaceHolder ID="plcList" runat="server">
            <table id="tblQuestionnaire" class="display">
                <thead>
                    <tr>
                        <th>編號</th>
                        <th>問卷標題</th>
                        <th>狀態</th>
                        <th>開始時間</th>
                        <th>結束時間</th>
                        <th>觀看統計</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rptList" runat="server">
                        <ItemTemplate>
                            <asp:HiddenField ID="hfID" runat="server" Value='<%# Eval("ID") %>' />
                            <tr>
                                <td width="50px">&nbsp;<%# Eval("TitleID") %></td>
                                <td width="330px">&nbsp;<a href="mainPage.aspx?ID=<%# Eval("ID") %>"><%# Eval("Title") %></a></td>
                                <td width="90px">
                                    &nbsp;<asp:Literal ID="ltlState" runat="server" Text='<%# Eval("strIsEnable") %>'></asp:Literal>
                                </td>
                                <td width="130px">&nbsp;<%# Eval("StartDate", "{0:yyyy/MM/dd}") %></td>
                                <td width="130px">&nbsp;<%# Eval("EndDate", "{0:yyyy/MM/dd}") %></td>
                                <td width="80px">&nbsp;<a href="statisticPage.aspx?ID=<%# Eval("ID") %>">前往</a></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
            <br />
        </asp:PlaceHolder>
    </div>

    <script>
        $(document).ready(function () {
            $('#tblQuestionnaire').DataTable({
                "searching": false,
                language: {
                    "lengthMenu": "*點擊標題進入修改" + "<br/>" + "<br/>" + "顯示 _MENU_ 項結果",
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
            });
        });
    </script>
</asp:Content>
