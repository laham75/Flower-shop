<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Payment.aspx.cs" Inherits="Payment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
  <center>  <p style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; font-weight: bold; color: #000000; height: 125px;">
        <img alt="" src="1961373224059.jpg" style="width: 416px; height: 128px" />
     
            </p>
      SAXXXXXXXXXXXXXXXXXXXXXXXXX<br />
      <br />
      process Number<br />
      <p style="font-family: Arial, Helvetica, sans-serif; font-size: xx-large; font-weight: bold; color: #000000">
          <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
      </p>
      <p style="font-family: Arial, Helvetica, sans-serif; font-size: xx-large; font-weight: bold; color: #000000">
          &nbsp;</p>
      <p style="font-family: Arial, Helvetica, sans-serif; font-size: xx-large; font-weight: bold; color: #000000">
          <img alt="" src="fed.jpg" style="width: 350px; height: 150px" /><img alt="" src="dhl.png" style="width: 350px; height: 150px" /><img alt="" src="aramex_logo.png" style="width: 350px; height: 150px" /></p>
      <p style="font-family: Arial, Helvetica, sans-serif; font-size: xx-large; font-weight: bold; color: #000000">
         <asp:RadioButtonList id="Rdlist" runat="server">
            <asp:ListItem>FedEx</asp:ListItem>
            <asp:ListItem>DHL</asp:ListItem>
            <asp:ListItem>Aramex</asp:ListItem>
         </asp:RadioButtonList>

         
      </p>
      <p style="font-family: Arial, Helvetica, sans-serif; font-size: xx-large; font-weight: bold; color: #000000">
          &nbsp;</p>
      <p style="font-family: Arial, Helvetica, sans-serif; font-size: xx-large; font-weight: bold; color: #000000">
          <asp:Button ID="send" runat="server" OnClick="Pay" Text="send" Width="289px" />

         
      </p>
      <p style="font-family: Arial, Helvetica, sans-serif; font-size: xx-large; font-weight: bold; color: #000000">
          &nbsp;</p>
    </center>
</asp:Content>

