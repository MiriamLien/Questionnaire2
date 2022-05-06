<%@ Page Title="" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="statisticPage.aspx.cs" Inherits="questionnaire.statisticPage" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        #titleDiv {
            margin-top: -30px;
        }

        #questionDiv {
            padding-left: 330px;
            margin-bottom: 120px;
        }

        #btnDiv {
            margin-right: 150px;
            margin-bottom: 50px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="titleDiv">
        <h2 align="center">
            <asp:Literal ID="ltlTitle" runat="server"></asp:Literal></h2>
        <div id="questionDiv">
            <asp:PlaceHolder ID="plcForQuestion" runat="server"></asp:PlaceHolder>
        </div>
    </div>
    <div id="btnDiv" align="right">
        <asp:Button ID="btnToListPage" runat="server" Text=" 返回列表頁 " OnClick="btnToListPage_Click" />
    </div>
</asp:Content>
