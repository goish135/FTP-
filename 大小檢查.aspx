<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="sizebechecked.aspx.cs" Inherits="sizebechecked" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            font-size: x-large;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <strong><span class="style1">檢查所有診所的檔案大小</span></strong><br />
    <asp:Label ID="Label3" runat="server" Text="進入系統時間:"></asp:Label>
    <asp:Label ID="Label4" runat="server" Text="show"></asp:Label>
    <br />
    <asp:Button ID="Button2" runat="server" onclick="checkAll" Text="檢查所有診所並記錄" /><br/>
    <asp:Button ID="Button3" runat="server" Text="顯示記錄" onclick="record" /><td>&nbsp&nbsp&nbsp</td>
    <asp:Button ID="Button4" runat="server" Text="隱藏紀錄" onclick="hidden" />
<asp:SqlDataSource ID="SqlDataSource1" runat="server" 
    ConnectionString="<%$ ConnectionStrings:yousingConnectionString %>" 
    DeleteCommand="DELETE FROM [check1] WHERE [sn] = @sn" 
    InsertCommand="INSERT INTO [check1] ([cno], [fn], [errornumber]) VALUES (@cno, @fn, @errornumber)" 
    SelectCommand="SELECT * FROM [check1]" 
    UpdateCommand="UPDATE [check1] SET [cno] = @cno, [fn] = @fn, [errornumber] = @errornumber WHERE [sn] = @sn">
    <DeleteParameters>
        <asp:Parameter Name="sn" Type="Int32" />
    </DeleteParameters>
    <InsertParameters>
        <asp:Parameter Name="cno" Type="String" />
        <asp:Parameter Name="fn" Type="String" />
        <asp:Parameter Name="errornumber" Type="String" />
    </InsertParameters>
    <UpdateParameters>
        <asp:Parameter Name="cno" Type="String" />
        <asp:Parameter Name="fn" Type="String" />
        <asp:Parameter Name="errornumber" Type="String" />
        <asp:Parameter Name="sn" Type="Int32" />
    </UpdateParameters>
</asp:SqlDataSource>
<asp:SqlDataSource ID="SqlDataSource2" runat="server" 
        ConnectionString="<%$ ConnectionStrings:yousingConnectionString %>" 
        DeleteCommand="DELETE FROM [sum] WHERE [sn] = @sn" 
        InsertCommand="INSERT INTO [sum] ([cno], [OK], [Error], [total], [cday]) VALUES (@cno, @OK, @Error, @total, @cday)" 
        SelectCommand="SELECT * FROM [sum]" 
        
        UpdateCommand="UPDATE [sum] SET [cno] = @cno, [OK] = @OK, [Error] = @Error, [total] = @total, [cday] = @cday WHERE [sn] = @sn">
    <DeleteParameters>
        <asp:Parameter Name="sn" Type="Int32" />
    </DeleteParameters>
    <InsertParameters>
        <asp:Parameter Name="cno" Type="String" />
        <asp:Parameter Name="OK" Type="Int32" />
        <asp:Parameter Name="Error" Type="Int32" />
        <asp:Parameter Name="total" Type="Int32" />
        <asp:Parameter Name="cday" Type="String" />
    </InsertParameters>
    <UpdateParameters>
        <asp:Parameter Name="cno" Type="String" />
        <asp:Parameter Name="OK" Type="Int32" />
        <asp:Parameter Name="Error" Type="Int32" />
        <asp:Parameter Name="total" Type="Int32" />
        <asp:Parameter Name="cday" Type="String" />
        <asp:Parameter Name="sn" Type="Int32" />
    </UpdateParameters>
    </asp:SqlDataSource>



    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
        AutoGenerateColumns="False" DataKeyNames="sn" DataSourceID="SqlDataSource1" 
        Visible="False" PageSize="50">
        <Columns>
           
            <asp:BoundField DataField="cno" HeaderText="診所編號" SortExpression="cno" />
            <asp:BoundField DataField="fn" HeaderText="檔案名稱" SortExpression="fn" />
            <asp:BoundField DataField="errornumber" HeaderText="錯誤顯示" 
                SortExpression="errornumber" />
        </Columns>
    </asp:GridView>
<br />
    </asp:Content>

