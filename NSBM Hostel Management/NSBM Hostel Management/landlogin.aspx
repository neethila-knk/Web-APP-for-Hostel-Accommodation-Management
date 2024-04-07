<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="landlogin.aspx.cs" Inherits="NSBM_Hostel_Management.landlogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
     <form id="landlordLoginForm" runat="server">
        <div>
            <h2>Landlord Login</h2>
            <div>
                <label for="txtEmail">Email:</label>
                 <asp:TextBox ID="txtLoginEmail" runat="server"></asp:TextBox>
            </div>
            <div>
                <label for="txtPassword">Password:</label>
                <asp:TextBox ID="txtLoginPassword" TextMode="Password" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Button ID="btnLogin" Text="Login" runat="server" OnClick="btnLogin_Click" />

            </div>
              <div>
                <!-- Hyperlink to the login page -->
                <a href="LandSignup.aspx">Let's SignUP</a>
            </div>
        </div>
    </form>

</body>
</html>
