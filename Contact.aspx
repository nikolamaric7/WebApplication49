<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="WebApplication49.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">

        <asp:Button ID="Button1" runat="server" Text="Prikazi" />
        <br />
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>

    </div>
</asp:Content>
