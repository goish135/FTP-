<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="set.aspx.cs" Inherits="set" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 166px;
        }
        .style2
        {
            width: 137px;
        }
    </style>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">

    <strong>依選取日期和輸入目錄名稱做即時性檢查</strong>
     <table width="570px" align="center" >
            <tr>
                <td align="left" valign="top" width="250">
                    
   
    <asp:Label ID="Label1" runat="server" Text="選取日期:" ForeColor="#996633" 
        style="font-weight: 700; text-align: right;"></asp:Label>
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox><br />
                    <asp:Label ID="Label2" runat="server" Text="診所名稱:" BorderColor="#FF9900" ForeColor="#996633" style="font-weight: 700; text-align: right;" ></asp:Label>
                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                     <asp:Button ID="Button1" runat="server" Height="26px" Text="開始檢查" 
                        Width="130px" onclick="click" />
                    </td>
                <td  valign="middle" class="style2">
                    &nbsp;</td>
                <td align="left" valign="top" width="250">
                    &nbsp;</td>
                <td align="left" valign="top" width="250">
               
                    資料顯示區塊
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:yousingConnectionString %>" 
                        SelectCommand="SELECT [cno], [cname] FROM [list]"></asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td align="left"  valign="top">
                <asp:Calendar ID="Calendar1" runat="server" ShowGridLines="True" 
        onselectionchanged="CHANGE" Width="405px" Height="350px"></asp:Calendar>
                 
                </td>
                <td  valign="middle" align="center" class="style2">
                    <br />
                    <br />
                    &nbsp;
                    <br />
                    <br />
                    <br />
                    <br />
                </td>
                <td  valign="middle" align="center" class="style1">
                    <br />
                    <br />
                    &nbsp;
                    <br />
                    <br />
                    <br />
                    <br />
                </td>
                <td align="left" valign="top" width="250">
                    <asp:ListBox ID="lboxsource" runat="server" Height="343px" Width="381px" 
                        SelectionMode="Multiple" Rows="20"></asp:ListBox>
                </td>
            </tr>
        </table>
</asp:Content>

