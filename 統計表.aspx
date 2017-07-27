<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="calculate.aspx.cs" Inherits="calculate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            font-size: x-large;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <strong><span class="style1">統計表(統計每間診所檔案過小總數)</span></strong><br /><br />

    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
        AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="sn" 
        DataSourceID="SqlDataSource1">
        <Columns>
            
           
            <asp:BoundField DataField="cno" HeaderText="診所" SortExpression="cno" />
           
            <asp:BoundField DataField="Error" HeaderText="錯誤總數" SortExpression="Error" />
         
            <asp:BoundField DataField="cday" HeaderText="檢查日期" SortExpression="cday" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:yousingConnectionString %>" 
        SelectCommand="SELECT * FROM [sum] order by [Error] DESC"></asp:SqlDataSource>

</asp:Content>

