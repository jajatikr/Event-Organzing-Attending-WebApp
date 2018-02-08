<%@ Page Title="Member Registration Form" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MemberRegister.aspx.cs" Inherits="GUI.Member.MemberRegister" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <h3>Enter your details</h3>
    <br/>
    <asp:Label ID="fnameLabel" runat="server" Text="First Name: " Font-Bold="True"></asp:Label> <br/>
    <asp:TextBox ID="fnameTextBox" runat="server" Width="625px"></asp:TextBox> 
    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="fnameTextBox" ErrorMessage="Name Can Contain Only Characters" ForeColor="#CC3300" ValidationExpression="^([a-zA-Z'.\s]{1,40})$"></asp:RegularExpressionValidator>
    <br />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="fnameTextBox" ErrorMessage="First Name is Required" ForeColor="#CC3300"></asp:RequiredFieldValidator>
    <br/>
    <br/>
    <asp:Label ID="lnameLabel" runat="server" Text="Last Name: " Font-Bold="True"></asp:Label> <br/>
    <asp:TextBox ID="lnameTextBox" runat="server" Width="625px"></asp:TextBox> 
    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="lnameTextBox" ErrorMessage="Name Can Contain Only Characters" ForeColor="#CC3300" ValidationExpression="^([a-zA-Z'.\s]{1,40})$"></asp:RegularExpressionValidator>
    <br />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="lnameTextBox" ErrorMessage="Last Name is Required" ForeColor="#CC3300"></asp:RequiredFieldValidator>
    <br/>
    <br/>
    <asp:Label ID="cityLabel" runat="server" Text="City: " Font-Bold="True"></asp:Label> <br/>
    <asp:TextBox ID="cityTextBox" runat="server" Width="625px"></asp:TextBox>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="cityTextBox" ErrorMessage="City Can Contain only Characters" ForeColor="#CC3300" ValidationExpression="^([a-zA-Z ]+)$"></asp:RegularExpressionValidator>
    <br />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="cityTextBox" ErrorMessage="City is Required" ForeColor="#CC3300"></asp:RequiredFieldValidator>
    <br/>
    <br/>
    <asp:Label ID="stateLabel" runat="server" Text="State: " Font-Bold="True"></asp:Label> <br/>
    <asp:TextBox ID="stateTextBox" runat="server" Width="625px"></asp:TextBox>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="stateTextBox" ErrorMessage="State Can Contain only Characters" ForeColor="#CC3300" ValidationExpression="^([a-zA-Z ]+)$"></asp:RegularExpressionValidator>
    <br />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="stateTextBox" ErrorMessage="State is Required" ForeColor="#CC3300"></asp:RequiredFieldValidator>
    <br/>
    <br/>
    <asp:Label ID="zipcodeLabel" runat="server" Text="ZIP Code: " Font-Bold="True"></asp:Label> <br/>
    <asp:TextBox ID="zipcodeTextBox" runat="server" Width="625px"></asp:TextBox>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="zipcodeTextBox" ErrorMessage="Invalid ZIP Code Format" ForeColor="#CC3300" ValidationExpression="\d{5}(-\d{4})?"></asp:RegularExpressionValidator>
    <br />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="zipcodeTextBox" ErrorMessage="ZIP Code is Required" ForeColor="#CC3300"></asp:RequiredFieldValidator>
    <br/>
    <br/>
    <asp:Label ID="mobileLabel" runat="server" Text="Mobile: " Font-Bold="True"></asp:Label> <br/>
    <asp:TextBox ID="mobileTextBox" runat="server" Width="625px"></asp:TextBox>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="mobileTextBox" ErrorMessage="Invalid Mobile Format" ForeColor="#CC3300" ValidationExpression="^(\(?\d{3}\)?-? *\d{3}-? *-?\d{4})$"></asp:RegularExpressionValidator>
    <br />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="mobileTextBox" ErrorMessage="Mobile Number is Required" ForeColor="#CC3300"></asp:RequiredFieldValidator>
    <br />
    <br />
        <asp:Label ID="movilecarrier" runat="server" Text="Carrier: " Font-Bold="True"></asp:Label> <br />
        <asp:DropDownList id="carrierName" runat="server">
            <asp:ListItem Value="Alltel"> Alltel </asp:ListItem>
            <asp:ListItem Selected="True" Value="ATT"> AT&T </asp:ListItem>
            <asp:ListItem Value="BoostMobile"> Boost Mobile </asp:ListItem>
            <asp:ListItem Value="MetroPCS"> MetroPCS </asp:ListItem>
            <asp:ListItem Value="RepublicWireless"> Republic Wireless </asp:ListItem>
            <asp:ListItem Value="Sprint"> Sprint </asp:ListItem>
            <asp:ListItem Value="TMobile"> T-Mobile </asp:ListItem>
            <asp:ListItem Value="USCellular"> U.S. Cellular </asp:ListItem>
            <asp:ListItem Value="VerizonWireless"> Verizon Wireless </asp:ListItem>
            <asp:ListItem Value="VirginMobile"> Virgin Mobile </asp:ListItem>
        </asp:DropDownList>
    <br />
    <br />
    <br/>
    <asp:Label ID="emailLabel" runat="server" Text="Email: " Font-Bold="True"></asp:Label> <br/>
    <asp:TextBox ID="emailTextBox" runat="server" Width="625px"></asp:TextBox>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="emailTextBox" ErrorMessage="Invalid Email-ID Format" ForeColor="#CC3300" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
    <br />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="emailTextBox" ErrorMessage="Email ID is Required" ForeColor="#CC3300"></asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="uniqueemail" runat="server" ForeColor="#CC3300"></asp:Label>
    <br/>
    <br/>
    <asp:Label ID="passwordLabel" runat="server" Text="Password: " Font-Bold="True"></asp:Label> <br/>
    <asp:TextBox ID="passwordTextBox" runat="server" Width="625px" TextMode="Password"></asp:TextBox>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ControlToValidate="passwordTextBox" ErrorMessage="Password must contain: Minimum 8 characters atleast 1 UpperCase Alphabet, 1 LowerCase Alphabet, 1 Number and 1 Special Character" ForeColor="#CC3300" ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&amp;])[A-Za-z\d$@$!%*?&amp;]{8,}"></asp:RegularExpressionValidator>
    <br />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="passwordTextBox" ErrorMessage="Password is Required" ForeColor="#CC3300"></asp:RequiredFieldValidator>
    <br/>
    <br/>
    <asp:Label ID="confirmPasswordLabel" runat="server" Text="Confirm Password: " Font-Bold="True"></asp:Label> <br/>
    <asp:TextBox ID="confirmPasswordTextBox" runat="server" Width="625px" TextMode="Password"></asp:TextBox>
    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="passwordTextBox" ControlToValidate="confirmPasswordTextBox" ErrorMessage="Passwords Do Not Match" ForeColor="#CC3300"></asp:CompareValidator>
    <br />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="confirmPasswordTextBox" ErrorMessage="Retype Password is Required" ForeColor="#CC3300"></asp:RequiredFieldValidator>
    <br/>
    <br/>
    <asp:Label ID="creditCardNumLabel" runat="server" Text="Credit Card Number: " Font-Bold="True"></asp:Label> <br/>
    <asp:TextBox ID="creditCardNumTextBox" runat="server" Width="625px"></asp:TextBox>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="creditCardNumTextBox" ErrorMessage="Credit Card Number Should be Min 10 Numbers" ForeColor="#CC3300" ValidationExpression="^\d{10,20}$"></asp:RegularExpressionValidator>
    <br />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="creditCardNumTextBox" ErrorMessage="Credit Card Number s Required" ForeColor="#CC3300"></asp:RequiredFieldValidator>
    <br/>
    <br/>
    <asp:Label ID="verifyLabel" runat="server" Text="Verify you are human? " Font-Bold="True"></asp:Label>
    <asp:Image ID="Image1" runat="server" />
    <asp:Button ID="verifyButton" class="btn btn-primary btn-xs" runat="server" Text="Refresh" OnClick="verifyButton_Click" CausesValidation="False" />

    <asp:TextBox ID="captchaTextBox" runat="server" Width="100px"></asp:TextBox> 
    <asp:Label ID="captchaTextBoxerror" runat="server" Text=""></asp:Label><br/>
    <br/>
    <br/>
    <asp:Button ID="SubmitButton" class="btn btn-primary" runat="server" Text="Submit" OnClick="SubmitButton_Click" />
    <asp:Button ID="ResetButton" class="btn btn-primary" runat="server" Text="Reset" OnClick="ResetButton_Click" CausesValidation="False" />
</asp:Content>
