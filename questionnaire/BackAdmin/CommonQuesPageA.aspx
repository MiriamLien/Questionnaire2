<%@ Page Title="" Language="C#" MasterPageFile="~/BackAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="CommonQuesPageA.aspx.cs" Inherits="questionnaire.BackAdmin.CommonQuesPageA" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%-- 列表 --%>
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.11.5/css/jquery.dataTables.css">
    <script type="text/javascript" charset="utf8" src="https://cdn.datatables.net/1.11.5/js/jquery.dataTables.js"></script>

    <style>
        #topDiv {
            /*border:2px solid #000000;*/
            padding-left: 30px;
            padding-top: 10px;
            padding-bottom: 15px;
            margin-top: 20px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h3>常用問題管理</h3>
        <p></p>
    </div>
    <div id="topDiv">
        <p></p>
        <asp:Literal ID="ltlTitle" runat="server">問卷標題</asp:Literal>
        <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
        &nbsp;
        <asp:DropDownList ID="ddlAnsType" runat="server"></asp:DropDownList>&emsp;
        &emsp;&emsp;
        <asp:Button ID="btnSearch" runat="server" Text="搜尋" />
    </div>
    <hr />
    <asp:ImageButton ID="ImgBtnAdd" runat="server" ImageUrl="../images/addICON.png" Width="30" OnClick="ImgBtnAdd_Click" />
    <br />
    <asp:PlaceHolder ID="plcAddCQ" runat="server" Visible="false">
        <h4>新增</h4>
        <div>
            <p>問題：<asp:TextBox ID="txtAddQues" runat="server"></asp:TextBox></p>
            <br />
            <p>回答：<asp:TextBox ID="txtAddAns" runat="server"></asp:TextBox></p>
            <p>類型：<asp:DropDownList ID="ddlAddAnsType" runat="server"></asp:DropDownList></p>
            <p>必填：<asp:CheckBox ID="ckbAddCQMustAns" runat="server" /></p>
        </div>
        <div>
            <asp:Button ID="btnSaveAddCQ" runat="server" CssClass="nes-pointer" Text="儲存" />
            &nbsp;
                <asp:Button ID="btnCancelAddCQ" runat="server" CssClass="nes-pointer" Text="取消" />
        </div>
    </asp:PlaceHolder>

    <asp:PlaceHolder ID="plcEditCQ" runat="server" Visible="false">
        <h4>變更</h4>
        <div>
            <p>編號：<asp:TextBox ID="txtEditNum" runat="server" Enabled="false"></asp:TextBox></p>
            <p>問題：<asp:TextBox ID="txtEditQues" runat="server"></asp:TextBox></p>
            <p>回答：<asp:TextBox ID="txtEditAns" runat="server"></asp:TextBox></p>
            <p>類型：<asp:DropDownList ID="ddlEditAnsType" runat="server"></asp:DropDownList></p>
            <p>必填：<asp:CheckBox ID="ckbEditCQMustAns" runat="server" /></p>
        </div>
        <div>
            <asp:Button ID="btnSaveEditCQ" runat="server" CssClass="nes-pointer" Text="儲存" OnClick="btnSaveEditCQ_Click" />
            &nbsp;
                <asp:Button ID="btnCancelEditCQ" runat="server" CssClass="nes-pointer" Text="取消" OnClick="btnCancelEditCQ_Click" />
        </div>
    </asp:PlaceHolder>

    <br />
    <asp:PlaceHolder ID="plcCQ" runat="server">
        <table id="tblCQ" class="display">
            <thead>
                <tr>
                    <th>編號</th>
                    <th>問題</th>
                    <th>回答</th>
                    <th>必填</th>
                    <th></th>
                    <th></th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptCQ" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td width="60px">&nbsp;<asp:Literal runat="server" ID="ltlNum"></asp:Literal></td>
                            <td width="400px"><%# Eval("CQTitle") %></td>
                            <td width="380px"><%# Eval("CQChoices") %></td>
                            <td width="50px">&nbsp;<asp:CheckBox ID="ckbMustAns" runat="server" Checked='<%# Eval("CQIsEnable") %>' />
                            </td>
                            <td width="60px">
                                <asp:Button ID="btnEdit" runat="server" CommandName='<%# Eval("CQID") %>' OnCommand="btnEdit_Command" Text="編輯" />
                            </td>
                            <td width="60px">
                                <asp:Button ID="btnDelete" runat="server" CommandName='<%# Eval("CQID") %>' OnCommand="btnDelete_Command" Text="刪除" OnClientClick="return confirm('確定要刪除這項問題嗎？')" />
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
            $('#tblCQ').DataTable({
                "searching": false,
                language: {
                    "lengthMenu": "* 點擊加號進入新增 *" + "<br/>" + "<br/>" + "顯示 _MENU_ 項結果",
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
