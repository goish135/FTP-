<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="history.aspx.cs" Inherits="history" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            font-size: large;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <strong><span class="style1">歷史紀錄查詢</span></strong> <br />
    客戶名稱:<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox><td>&nbsp&nbsp&nbsp</td>
    <asp:Button ID="Button1"
        runat="server" Text="Search" onclick="go" />
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView><br />
    <asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label>

    </asp:Content>


