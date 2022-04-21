<%@ Page Title="" Language="C#" MasterPageFile="~/BackAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="CommonQuesPageA.aspx.cs" Inherits="questionnaire.BackAdmin.CommonQuesPageA" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../JavaScript/jquery-tablepage-1.0.js"></script>
    <style>
        #topDiv {
            border: 2px solid #000000;
            padding-left: 30px;
            padding-top: 20px;
            margin-top: 10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h3>常用問題管理</h3>
        <p></p>
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
            <asp:Button ID="btnSearch" runat="server" Text="搜尋" />
        </p>
    </div>
    <br />
    <asp:ImageButton ID="ImgBtnAdd" runat="server" ImageUrl="../images/addICON.png" Width="30" /><br />
    <br />
    <asp:PlaceHolder ID="plcCQ" runat="server">
        <table id="tblB">
            <tr>
                
                <th>編號</th>
                <th>問題</th>
                <th>回答</th>
                <th>必填</th>
                <th></th>
                <th></th>
            </tr>
            <asp:Repeater ID="rptCQ" runat="server">
                <ItemTemplate>
                    <tr>
                        <td width="60px">&nbsp;<asp:Literal runat="server" ID="ltlNum"></asp:Literal></td>
                        <td width="410px"><%# Eval("CQTitle") %></td>
                        <td width="390px"><%# Eval("CQChoices") %></td>
                        <td width="60px">
                            &nbsp;<asp:CheckBox ID="ckbMustAns" runat="server" Checked='<%# Eval("CQIsEnable") %>' />
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
        </table>
    </asp:PlaceHolder>
    <br />
    <span id='table_pageB'></span>

    <script>
        $("#tblB").tablepage($("#table_pageB"), 10);
    </script>
</asp:Content>
