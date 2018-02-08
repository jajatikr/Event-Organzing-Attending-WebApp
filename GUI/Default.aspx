<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GUI._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br/>
    <br/>
    <div class="row">
        <div class="col-md-4" style="text-align:center;">
            <p>
                <asp:Button ID="MemberRegisterButton" runat="server" class="btn btn-primary" Text="Member Register" OnClick="MemberRegisterButton_Click" />
            </p>
        </div>
        <div class="col-md-4" style="text-align:center;">
            <p>
                <asp:Button ID="MemberSignInButton" runat="server" class="btn btn-primary" Text="Member Sign In" OnClick="MemberSignInButton_Click" />
            </p>
        </div>
        <div class="col-md-4" style="text-align:center;">
            <p>
                <asp:Button ID="StaffSignInButton" runat="server" class="btn btn-primary" Text="Staff Sign In" OnClick="StaffSignInButton_Click" />
            </p>
        </div>
        <br />
    </div>

</asp:Content>
