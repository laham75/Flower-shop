<%@ Page Title="" Language="C#" MasterPageFile="~/MasterE.master" AutoEventWireup="true" CodeFile="management.aspx.cs" Inherits="Management" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <div style="height: 846px; width: 282px">
        <br />
        <br />
          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label>
    &nbsp;&nbsp;
    <asp:TextBox ID="Name" runat="server"></asp:TextBox>



        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label2" runat="server" Text="Price"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="DropDownList1" runat="server" Height="22px" Width="128px">
            <asp:ListItem Value="100">100$</asp:ListItem>
            <asp:ListItem Value="200">200$</asp:ListItem>
            <asp:ListItem Value="300">300$</asp:ListItem>
        </asp:DropDownList>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:FileUpload ID="FileUpload1" runat="server" Width="292px" />
        <br />
        <asp:Button ID="Up" runat="server" OnClick="AddFlower" Text="Upload " Width="135px" />
        <asp:Button ID="Delete" runat="server" OnClick="RemoveFlower" Text="Delete" Width="135px" />
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" ForeColor="#CC0000"></asp:Label>
&nbsp; &nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;
        
        <br />
        <asp:GridView ID="GridView1" runat="server" BackColor="#FF6699" AutoGenerateColumns="False"
             BorderColor="#CCCCCC" BorderStyle="Double" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical">
            <AlternatingRowStyle BackColor="White" />
            <FooterStyle BackColor="#CCCC99" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <RowStyle BackColor="#F7F7DE" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FBFBF2" />
            <SortedAscendingHeaderStyle BackColor="#848384" />
            <SortedDescendingCellStyle BackColor="#EAEAD3" />
            <SortedDescendingHeaderStyle BackColor="#575357" />

            <Columns>

                <asp:TemplateField HeaderText="Uname">
                    <ItemTemplate>
                        <asp:Label ID="lbl" runat="server" Text='<%#Eval("Uname") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>


                <asp:TemplateField HeaderText="Umg">
                    <ItemTemplate>
                        <asp:Image ID="amg" runat="server" ImageUrl='<%#Eval("Umg") %>' Height="100" Width="100"></asp:Image>
                    </ItemTemplate>
                </asp:TemplateField>


                <asp:TemplateField HeaderText="Price">
                    <ItemTemplate>
                        <asp:Label ID="lbli" runat="server" text='<%#Eval("Price") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
        &nbsp;
        &nbsp;
        <br />



    </div>
  
</asp:Content>



