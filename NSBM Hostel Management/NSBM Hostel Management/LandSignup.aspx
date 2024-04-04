<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LandSignup.aspx.cs" Inherits="NSBM_Hostel_Management.LandSignup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
 <form id="landregform" runat="server">
     <div>
         <h2>Landloard Registration Form</h2>
         <div>
             <label for="txtFirstName">First Name:</label>
             <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
         </div>

         <div>
             <label for="txtLastName">Last Name:</label>
             <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
         </div>

         <div>
             <label for="txtEmail">Email:</label>
             <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
         </div>
         <div>
             <label for="txtPassword">Password:</label>
             <asp:TextBox ID="txtPassword" TextMode="Password" runat="server"></asp:TextBox>
         </div>
         <div>
             <asp:Button ID="btnRegister" Text="Register" runat="server" OnClick="btnRegister_Click" />
         </div>
           <div>
                <!-- Hyperlink to the login page -->
                <a href="LandLogin.aspx">Let's Log In</a>
            </div>
     </div>
 </form>
</body>
</html>
