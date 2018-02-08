
<%@ Page Title="" Language="C#" MasterPageFile="~/SignedInStaff.Master" AutoEventWireup="true" CodeBehind="StaffHome.aspx.cs" Inherits="GUI.Staff.StaffHome" %>
<%@ Register TagPrefix="gui" TagName="welcomeMessage" Src="~/Welcome.ascx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3><gui:welcomeMessage runat="server" /></h3>
    <br />
    <h4>This page contains the information about Staff Members. Only authenticated users can access this page. The Staff Member Can Add another New Staff Member</h4> <br />
    <h3>Add New Staff</h3> <br />
    <br/>
    <asp:Label ID="staffemailLabel" runat="server" Text="Username" Font-Bold="True"></asp:Label> <br/>
    <asp:TextBox ID="staffemailTextBox" runat="server" Width="300px"></asp:TextBox> &nbsp;<asp:Label ID="emailuinuqe" runat="server" ForeColor="#CC3300"></asp:Label>
    <br/>
    <br/>
    <asp:Label ID="staffpasswordLabel" runat="server" Text="Password: " Font-Bold="True"></asp:Label> <br/>
    <asp:TextBox ID="staffpasswordTextBox" runat="server" Width="300px" TextMode="Password"></asp:TextBox> <br/>
    <br/>
    <asp:Label ID="staffconfirmpasswordlabel" runat="server" Text="Confirm Password: " Font-Bold="True"></asp:Label> <br/>
    <asp:TextBox ID="staffconfirmpasswordtextbox" runat="server" Width="300px" TextMode="Password"></asp:TextBox> &nbsp;<asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="staffpasswordTextBox" ControlToValidate="staffconfirmpasswordtextbox" ErrorMessage="Passwords Do Not Match" ForeColor="#CC3300"></asp:CompareValidator>
    <br/>
    <br/>
    <asp:Label ID="ResultLabel" runat="server" Text=""></asp:Label>
    <br/>
    <asp:Button ID="staffSubmitButton" class="btn btn-primary" runat="server" Text="Submit" OnClick="SubmitButton_Click" />
    &nbsp;&nbsp;&nbsp;
    <asp:Button ID="staffResetButton" class="btn btn-primary" runat="server" Text="Reset" OnClick="ResetButton_Click" />
    <br/>
</asp:Content>
