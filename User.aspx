<%@ Page Title="" Language="C#" MasterPageFile="~/MasterE.master" AutoEventWireup="true" CodeFile="User.aspx.cs" Inherits="Employees" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <p>
        &nbsp;</p>
    <p style="font-size: x-large">
        Add Or Delete User</p>
    <p>
        &nbsp;</p>
    <p>
&nbsp;User&nbsp;
        <asp:TextBox ID="U" runat="server"></asp:TextBox>
    </p>
    <p>
        pass &nbsp;
        <asp:TextBox ID="P" runat="server"></asp:TextBox>
    </p>
    <p>
        
         Type&nbsp;&nbsp;
         <asp:DropDownList ID="D" runat="server" Width="368px">
             <asp:ListItem>Customer</asp:ListItem>
             <asp:ListItem>Emloyee</asp:ListItem>
         </asp:DropDownList>
    </p>
    <p>
        
         &nbsp;</p>
    <p>
        
&nbsp;<asp:Button ID="Add" runat="server" Text="Add" Width="210px" OnClick="AddUser" Height="33px" />
&nbsp;<asp:Button ID="Delete" runat="server" Text="Delete" Width="210px" OnClick="RemoverUser" Height="33px" />
    </p>
</asp:Content>

