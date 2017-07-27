<%@ Page Language="C#" AutoEventWireup="true" CodeFile="insert.aspx.cs" Inherits="insert" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            text-align: left;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <h2 class="style1">
            Insert DATA into DATABASE</h2>
        <p class="style1">
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:yousingConnectionString %>" 
                SelectCommand="SELECT * FROM [list]"></asp:SqlDataSource>
        </p>
        <p class="style1">
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" oncommand="btn_click" Text="新增" />
        </p>
        <p class="style1">
            <asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label>
        </p>
        <h2>
            從Ftp上取得診所ID,並放入資料表</h2>
        <p>
            <asp:Button ID="Button2" runat="server" onclick="insert_2" Text="倒資料到資料表" />
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button3" runat="server" onclick="view" Text="查看目前白名單" />
        </p>
        <p>
            <asp:Label ID="Label2" runat="server" Text="顯示陣列元素&lt;br&gt;"></asp:Label>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                CellPadding="3" DataKeyNames="sn" DataSourceID="SqlDataSource1" Visible="False">
                <Columns>
                    <asp:BoundField DataField="sn" HeaderText="sn" InsertVisible="False" 
                        ReadOnly="True" SortExpression="sn" />
                    <asp:BoundField DataField="cno" HeaderText="cno" SortExpression="cno" />
                    <asp:BoundField DataField="cname" HeaderText="cname" SortExpression="cname" />
                    <asp:CheckBoxField DataField="check" HeaderText="check" 
                        SortExpression="check" />
                </Columns>
                <FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                <RowStyle ForeColor="#000066" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#00547E" />
            </asp:GridView>
        </p>
        <p>
            &nbsp;</p>
    
    </div>
    </form>
</body>
</html>
