<%@ Page Title="Flights" Language="C#" MasterPageFile="~/SignedIn.Master" AutoEventWireup="true" CodeBehind="Flights.aspx.cs" Inherits="GUI.Member.Flights" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style type="text/css">
        .tg  {border-collapse:collapse;border-spacing:0;}
        .tg td{padding:10px 5px;border-style:solid;border-width:1px;overflow:hidden;word-break:normal;}
        .tg th{padding:10px 5px;border-style:solid;border-width:1px;overflow:hidden;word-break:normal;}
        .tg .tg-bwhq{background-color:#5bc0de;vertical-align:top}
        .tg .tg-yw4l{vertical-align:top}
    </style>
    <h2><%: Title %></h2>
    <h3>Search flights to attend events</h3>
    <br/>
    <asp:Label ID="OriginLabel" runat="server" Text="Origin: "></asp:Label>
    <asp:TextBox ID="OriginTextBox" runat="server" placeholder="Eg. PHX"></asp:TextBox>
    &nbsp;
    &nbsp;
    <asp:Label ID="DestinationLabel" runat="server" Text="Destination: "></asp:Label>
    <asp:TextBox ID="DestinationTextBox" runat="server" placeholder="Eg. LAX"></asp:TextBox>
    &nbsp;
    &nbsp;
    <asp:Label ID="DateLabel" runat="server" Text="Date: "></asp:Label>
    <asp:TextBox ID="DateTextBox" runat="server" placeholder="YYYY-MM-DD"></asp:TextBox>
    <br>
    <br>
    <asp:Label ID="AdultsLabel" runat="server" Text="Adults: "></asp:Label>
    <asp:DropDownList ID="AdultsDropDownList" runat="server">
        <asp:ListItem Value="0"></asp:ListItem>
        <asp:ListItem Value="1"></asp:ListItem>
        <asp:ListItem Value="2"></asp:ListItem>
        <asp:ListItem Value="3"></asp:ListItem>
        <asp:ListItem Value="4"></asp:ListItem>
        <asp:ListItem Value="5"></asp:ListItem>
        <asp:ListItem Value="6"></asp:ListItem>
        <asp:ListItem Value="7"></asp:ListItem>
        <asp:ListItem Value="8"></asp:ListItem>
        <asp:ListItem Value="9"></asp:ListItem>
    </asp:DropDownList>
    &nbsp;
    &nbsp;
    <asp:Label ID="CabinLabel" runat="server" Text="Preferred Cabin: "></asp:Label>
    <asp:DropDownList ID="CabinDropDownList" runat="server">
        <asp:ListItem Value="None"></asp:ListItem>
        <asp:ListItem Value="Coach"></asp:ListItem>
        <asp:ListItem Value="Premium_Coach" Text="Premium Coach"></asp:ListItem>
        <asp:ListItem Value="Business"></asp:ListItem>
        <asp:ListItem Value="First" Text="First Class"></asp:ListItem>
    </asp:DropDownList>
    <br>
    <br>
    <asp:Label ID="ResultLabel" runat="server" Text=""></asp:Label>
    <br>
    <br>
    <asp:Button ID="FlightServiceSubmit" class="btn btn-primary" runat="server" Text="Search" OnClick="FlightServiceSubmit_Click" />
</asp:Content>
