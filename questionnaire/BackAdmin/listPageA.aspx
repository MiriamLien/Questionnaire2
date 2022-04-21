<%@ Page Title="" Language="C#" MasterPageFile="~/BackAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="listPageA.aspx.cs" Inherits="questionnaire.BackAdmin.listPageA" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!--套用jQuery-->
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
        <table id="tblA">
            <tr>
                
                <th>編號</th>
                <th>問卷標題</th>
                <th>狀態</th>
                <th>開始時間</th>
                <th>結束時間</th>
                <th>觀看統計</th>
                <th></th>
            </tr>
            <asp:Repeater ID="rptList" runat="server">
                <ItemTemplate>
                    <tr>
                        <td width="70px"><%# Eval("TitleID") %></td>
                        <td width="280px">
                            &nbsp;<a href="mainPageA.aspx?ID=<%# Eval("ID") %>"><%# Eval("Title") %></a>
                        </td>
                        <td width="120px"><%# Eval("strIsEnable") %></td>
                        <td width="130px"><%# Eval("StartDate", "{0:yyyy/MM/dd}") %></td>
                        <td width="130px"><%# Eval("EndDate", "{0:yyyy/MM/dd}") %></td>
                        <td width="100px">&nbsp;<a href="mainPageA.aspx?ID=<%# Eval("ID") %>">前往</a></td>
                        <td width="80px">
                            <asp:Button ID="btnDelete" runat="server" CommandName='<%# Eval("ID") %>' OnCommand="btnDelete_Command" Text="刪除" OnClientClick="return confirm('確定要關閉這份問卷嗎？')" />
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </asp:PlaceHolder>
    <br />
    <span id='table_pageA'></span>

    <script>
        $("#tblA").tablepage($("#table_pageA"), 10);
    </script>
</asp:Content>
