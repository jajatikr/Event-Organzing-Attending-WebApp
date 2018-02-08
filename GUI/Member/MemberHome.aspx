<%@ Page Title="" Language="C#" MasterPageFile="~/SignedIn.Master" AutoEventWireup="true" CodeBehind="MemberHome.aspx.cs" Inherits="GUI.Member.MemberHome" %>
<%@ Register TagPrefix="gui" TagName="welcomeMessage" Src="~/Welcome.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3><gui:welcomeMessage runat="server" /></h3><br />
    <h2>Events</h2>
    <h3>Select interested events</h3> 
    <p><asp:Label ID="feedTableLabel" runat="server" Text="Selected event here."></asp:Label></p>
    <asp:Table id="feedTable" 
        GridLines="Both" 
        HorizontalAlign="Center" 
        Font-Names="Verdana" 
        Font-Size="8pt" 
        CellPadding="15" 
        CellSpacing="0" 
        Runat="server"/>
</asp:Content>
