<%@ Page Language="C#" AutoEventWireup="true" CodeFile="insert3.aspx.cs" Inherits="insert3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    
    <div>
    <asp:Button ID="Button1" runat="server" Text="insert" onclick="i3" />
        <asp:Button ID="Button2"
        runat="server" Text="view" onclick="view" /><br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            DataSourceID="SqlDataSource1" Visible="False">
            <Columns>
                <asp:BoundField DataField="customer" HeaderText="customer" 
                    SortExpression="customer" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:yousingConnectionString %>" 
            SelectCommand="SELECT * FROM [list3]"></asp:SqlDataSource>
        <asp:DropDownList ID="DropDownList1" runat="server" 
            DataSourceID="SqlDataSource1" DataTextField="customer" 
            DataValueField="customer">
        </asp:DropDownList>
        <br />
    </div>
    </form>
</body>
</html>
