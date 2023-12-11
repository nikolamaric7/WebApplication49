<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="WebApplication49.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">

        Mesta:&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="DropDownList1" runat="server">
        </asp:DropDownList>
        <br />
        Agencije:
        <asp:DropDownList ID="DropDownList2" runat="server">
        </asp:DropDownList>
        <br />
        Maksimalna cena:
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
        Datum polaska:&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <br />
        Datum dolaska:&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Ponude" />
        <asp:Label ID="Label2" runat="server"></asp:Label>
        <br />
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
        <br />
        <div class="tekstbeli">
        ID Korisnika: <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
&nbsp;ID Ponude:
        <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
        <br />
                        </div>
        <asp:Button CssClass="dugmecrno" ID="Button2" runat="server" Text="Zakazi" OnClick="Button2_Click" />

        <asp:Label ID="Label1" runat="server"></asp:Label>

    </div>
</asp:Content>
