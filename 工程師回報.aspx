<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="report.aspx.cs" Inherits="report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            font-size: large;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <strong><span class="style1">回報處理</span></strong>
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="sn" DataSourceID="SqlDataSource1" AllowPaging="True">
    <Columns>
        <asp:CommandField ShowEditButton="True" />
        
       
        <asp:BoundField DataField="cno" HeaderText="診所編號" SortExpression="cno"  ReadOnly="True" />
        <asp:BoundField DataField="fn" HeaderText="備份檔檔名" 
            SortExpression="fn" ReadOnly="True"/>
        <asp:BoundField DataField="errornumber" HeaderText="錯誤訊息" 
            SortExpression="errornumber" ReadOnly="True"/>
        <asp:BoundField DataField="status" HeaderText="處理狀態" 
            SortExpression="status" />
    </Columns>
</asp:GridView>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:yousingConnectionString %>" 
        DeleteCommand="DELETE FROM [check1] WHERE [sn] = @sn" 
        InsertCommand="INSERT INTO [check1] ([status]) VALUES (@status)" 
        SelectCommand="SELECT * FROM [check1]" 
        UpdateCommand="UPDATE [check1] SET  [status] = @status WHERE [sn] = @sn">
    <DeleteParameters>
        <asp:Parameter Name="sn" Type="Int32" />
    </DeleteParameters>
    <InsertParameters>
        <asp:Parameter Name="cno" Type="String" />
        <asp:Parameter Name="fn" Type="String" />
        <asp:Parameter Name="errornumber" Type="String" />
        <asp:Parameter Name="status" Type="String" />
    </InsertParameters>
    <UpdateParameters>
        <asp:Parameter Name="cno" Type="String" />
        <asp:Parameter Name="fn" Type="String" />
        <asp:Parameter Name="errornumber" Type="String" />
        <asp:Parameter Name="status" Type="String" />
        <asp:Parameter Name="sn" Type="Int32" />
    </UpdateParameters>
    </asp:SqlDataSource>

</asp:Content>


