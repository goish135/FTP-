<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="checkthreeday.aspx.cs" Inherits="checkthreeday" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <strong>檢查從今天算的昨天，前天，大前天的備份資料(會自動跳過星期天)</strong> <br />
    <asp:Label ID="Label1" runat="server" Text="今天日期:"></asp:Label>
    <asp:Label ID="Label2" runat="server" Text="昨天日期:"></asp:Label>
    <asp:Label ID="Label3" runat="server" Text="前天日期:"></asp:Label>
    <asp:Label ID="Label4" runat="server" Text="大前天日期:"></asp:Label>
    <asp:Button ID="Button1" runat="server" Text="開始檢查" onclick="go" /><br />
    <asp:Label ID="Label5" runat="server" Text="" Visible="False"></asp:Label>
    <asp:Label ID="Label6" runat="server" Text=""></asp:Label>
    <asp:Label ID="Label7" runat="server" Text=""></asp:Label>
    <asp:Button ID="Button2" runat="server" Text="查看結果" onclick="show"/><td>&nbsp&nbsp&nbsp&nbsp&nbsp</td>
    <asp:Button ID="Button3" runat="server" Text="隱藏結果" onclick="close" />
    <asp:GridView ID="GridView1" runat="server" AllowPaging="False" 
        AutoGenerateColumns="False" DataKeyNames="sn" 
        Visible="False">
        <Columns>
            <asp:BoundField DataField="sn" HeaderText="流水號" InsertVisible="False" 
                ReadOnly="True" SortExpression="sn" />
            <asp:BoundField DataField="cn" HeaderText="診所編號" SortExpression="cn" />
            <asp:BoundField DataField="cna" HeaderText="診所名稱" SortExpression="cna" />
            <asp:BoundField DataField="result" HeaderText="檢測結果" 
                SortExpression="result" />
            <asp:BoundField DataField="ctime" HeaderText="檢查日期" SortExpression="ctime" />
            <asp:BoundField DataField="hms" HeaderText="檢查時間" SortExpression="hms" />
        </Columns>
        
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:yousingConnectionString %>" 
        SelectCommand="SELECT * FROM [check2] where ctime='2017/7/25 下午 04:40:17'"></asp:SqlDataSource>
    <asp:Label ID="Label8" runat="server" Text="Label" Visible="False"></asp:Label>
</asp:Content>

