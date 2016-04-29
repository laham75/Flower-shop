<%@ Page Title="" Language="C#" MasterPageFile="~/MasterE.master" AutoEventWireup="true" CodeFile="order.aspx.cs" Inherits="order" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

   <h3>Search By Name.</h3>
                            <asp:TextBox runat="server" ID="UserName" CssClass="form-control" />
    <br />

        <asp:Button ID="Search" runat="server" OnClick="Search_Click" Text="Search" Width="142px" />
                <asp:Button ID="Delete" runat="server" OnClick="Order" Text="Delete" Width="135px" />
                <br />
    <br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2"  ForeColor="Black"  >
        <Columns>
            <asp:BoundField DataField="UserName" HeaderText="UserName" SortExpression="UserName" />
            <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
            <asp:BoundField DataField="Country" HeaderText="Country" SortExpression="Country" />
            <asp:BoundField DataField="City" HeaderText="City" SortExpression="City" />
            <asp:BoundField DataField="PhoneNumber" HeaderText="PhoneNumber" SortExpression="PhoneNumber" />
            <asp:BoundField DataField="FName" HeaderText="FName" SortExpression="FName" />
            <asp:BoundField DataField="processNumber" HeaderText="processNumber" SortExpression="processNumber" />
            <asp:BoundField DataField="DCompany" HeaderText="DCompany" SortExpression="DCompany" />
        </Columns>
        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
        <RowStyle BackColor="White" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#808080" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#383838" />
    </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:UsersConnectionString %>" SelectCommand="SELECT * FROM [data]"></asp:SqlDataSource>
                <br />

                           <br />

</asp:Content>

