<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SignIn.aspx.cs" Inherits="GUI.SignIn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2> <%= Session["loginuser"] %> <%: Title %></h2>
    <h3>Enter your details</h3> 
    <br/>
    <asp:Label ID="emailLabel" runat="server" Text="Email: " Font-Bold="True"></asp:Label> <br/>
    <asp:TextBox ID="emailTextBox" runat="server" Width="300px"></asp:TextBox> <br/>
    <br/>
    <asp:Label ID="passwordLabel" runat="server" Text="Password: " Font-Bold="True"></asp:Label> <br/>
    <asp:TextBox ID="passwordTextBox" runat="server" Width="300px" TextMode="Password"></asp:TextBox> <br/>
    <br/>
    <asp:Label ID="ResultLabel" runat="server" ForeColor="#CC3300"></asp:Label>
    <br />
    <br/>
    <asp:Button ID="SubmitButton" class="btn btn-primary" runat="server" Text="Submit" OnClick="SubmitButton_Click" />
    <asp:Button ID="ResetButton" class="btn btn-primary" runat="server" Text="Reset" OnClick="ResetButton_Click" />
    <br/>
</asp:Content>
