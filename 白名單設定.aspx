<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="whitelist.aspx.cs" Inherits="whitelist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .style1
    {
        text-align: left;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <h2 class="style1">白名單設定</h2>
<p class="style1">
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
        AllowSorting="True" CellPadding="4" DataSourceID="SqlDataSource1" 
        ForeColor="#333333" GridLines="None" PageSize="50" 
        AutoGenerateColumns="False" DataKeyNames="sn">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:CommandField ShowEditButton="True" />
            <asp:BoundField DataField="sn" HeaderText="編號" InsertVisible="False" 
                ReadOnly="True" SortExpression="sn" />
            <asp:BoundField DataField="cn" HeaderText="診所編號" SortExpression="cn" ReadOnly="True"/>
            <asp:BoundField DataField="cname" HeaderText="診所名稱" SortExpression="cname" ReadOnly="True"/>
            <asp:CheckBoxField DataField="check" HeaderText="是否檢查" 
                SortExpression="check"/>
        </Columns>
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
        <SortedAscendingCellStyle BackColor="#FDF5AC" />
        <SortedAscendingHeaderStyle BackColor="#4D0000" />
        <SortedDescendingCellStyle BackColor="#FCF6C0" />
        <SortedDescendingHeaderStyle BackColor="#820000" />
    </asp:GridView>
</p>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:yousingConnectionString %>" 
        SelectCommand="SELECT * FROM [list2] order by [check] desc" 
        DeleteCommand="DELETE FROM [list2] WHERE [sn] = @sn" 
        InsertCommand="INSERT INTO [list2] ([check]) VALUES (@check)" 
        UpdateCommand="UPDATE [list2] SET [check] = @check WHERE [sn] = @sn">
        <DeleteParameters>
            <asp:Parameter Name="sn" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="cn" Type="String" />
            <asp:Parameter Name="cname" Type="String" />
            <asp:Parameter Name="check" Type="Boolean" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="cn" Type="String" />
            <asp:Parameter Name="cname" Type="String" />
            <asp:Parameter Name="check" Type="Boolean" />
            <asp:Parameter Name="sn" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>

</asp:Content>

