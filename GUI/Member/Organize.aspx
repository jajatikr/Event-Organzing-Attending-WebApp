<%@ Page Title="Organize" Language="C#" MasterPageFile="~/SignedIn.Master" AutoEventWireup="true" CodeBehind="Organize.aspx.cs" Inherits="GUI.Organize" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <h3>Enter event details</h3> 
    <br/>
    <asp:Label ID="titleLabel" runat="server" Text="Title: " Font-Bold="True"></asp:Label> <br/>
    <asp:TextBox ID="titleTextBox" runat="server" Width="625px"></asp:TextBox> <br/>
    <br/>
    <asp:Label ID="locLabel" runat="server" Text="Location: " Font-Bold="True"></asp:Label> <br/>
    <asp:TextBox ID="locTextBox" runat="server" Width="625px"></asp:TextBox> <br/>
    <br/>
    <asp:Label ID="timeLabel" runat="server" Text="Date and Time: " Font-Bold="True"></asp:Label> <br/>
    <asp:TextBox ID="datetimeTextBox" runat="server" Width="625px" placeholder="mm/dd/yyyy hh:mm AM/PM"></asp:TextBox> <br/>
    <br/>
    <asp:Label ID="descriptionLabel" runat="server" Text="Description: " Font-Bold="True"></asp:Label> <br/>
    <asp:TextBox ID="descriptionTextBox" runat="server" Height="173px" Width="625px" TextMode="MultiLine"></asp:TextBox> <br/>
    <br/>
    <asp:Label ID="resultLabel" runat="server" Text=""></asp:Label>
    <br/>
    <br/>
    <asp:Button ID="eventsubmitButton" CssClass="btn btn-primary" runat="server" Text="Submit" OnClick="eventsubmitButton_Click" />
</asp:Content>
