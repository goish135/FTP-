<%@ Page Language="C#" AutoEventWireup="true" CodeFile="insert2.aspx.cs" Inherits="insert2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Button ID="Button1" runat="server" Text="倒資料" onclick="insert_2" />
        <asp:Button
            ID="Button2" runat="server" Text="查看" onclick="view" /><br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            DataKeyNames="sn" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="sn" HeaderText="編號" InsertVisible="False" 
                    ReadOnly="True" SortExpression="sn" />
                <asp:BoundField DataField="cn" HeaderText="診所編號" SortExpression="cn" />
                <asp:BoundField DataField="cname" HeaderText="診所名稱" SortExpression="cname" />
                <asp:CheckBoxField DataField="check" HeaderText="是否檢查" 
                    SortExpression="check" />
            </Columns>
        </asp:GridView>
    
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:yousingConnectionString %>" 
            SelectCommand="SELECT * FROM [list2]"></asp:SqlDataSource>
    </div>
    </form>
</body>
</html>
