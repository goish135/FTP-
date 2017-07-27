<%@ Page Language="C#" AutoEventWireup="true" CodeFile="checkAll.aspx.cs" Inherits="checkAll" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

   
</script>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Button ID="Button1" runat="server" onclick="view_click" Text="Button" />
    
        <br />
        <asp:Label ID="Label1" runat="server" Text="診所名稱"></asp:Label>
    
        <br />
        <asp:Label ID="datarea" runat="server" Text="Label" Visible="False"></asp:Label>
    
    </div>
    </form>
</body>
</html>
