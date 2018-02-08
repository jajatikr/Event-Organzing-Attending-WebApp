<%@ Page Title="Hotels" Language="C#" MasterPageFile="~/SignedIn.Master" AutoEventWireup="true" CodeBehind="Hotels.aspx.cs" Inherits="GUI.Member.Hotels" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style type="text/css">
        .tg  {border-collapse:collapse;border-spacing:0;}
        .tg td{padding:10px 5px;border-style:solid;border-width:1px;overflow:hidden;word-break:normal;}
        .tg th{padding:10px 5px;border-style:solid;border-width:1px;overflow:hidden;word-break:normal;}
        .tg .tg-bwhq{background-color:#5bc0de;vertical-align:top}
        .tg .tg-yw4l{vertical-align:top}
    </style>
    <h2><%: Title %></h2>
    <h3>Search hotels nearby attending events</h3>
    <br/>
    <asp:Label ID="HotelLabel" runat="server" Text="Location : "></asp:Label>
    <asp:TextBox ID="LocationTextBox" runat="server" placeholder="Eg. ASU Tempe"></asp:TextBox>
    <br>
    <br>
    <asp:Label ID="HotelsResultLabel" runat="server" Text=""></asp:Label>
    <br>
    <br>
    <asp:Button ID="HotelsResultButton" class="btn btn-primary" runat="server" Text="Search" OnClick="HotelsResultButton_Click" />
</asp:Content>
