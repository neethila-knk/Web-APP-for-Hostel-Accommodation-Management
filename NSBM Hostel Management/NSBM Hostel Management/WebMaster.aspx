<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebMaster.aspx.cs" Inherits="NSBM_Hostel_Management.WebMaster" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
<title><%: Page.Title %> WebMaster(Admin)</title>
 <link href="https://cdn.lineicons.com/4.0/lineicons.css" rel="stylesheet" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha3/dist/css/bootstrap.min.css" rel="stylesheet"
        integrity="sha384-KK94CHFLLe+nY2dmCWGMq91rCGa5gtU4mk92HdvYe+M/SXH301p5ILy+dN9+nJOZ" crossorigin="anonymous"/>
    <link href="webmasterstyle.css" rel="stylesheet" />
</head>
<body> <div class="wrapper">
        <aside id="sidebar">
            <div class="d-flex">
                <button class="toggle-btn" type="button">
                    <i class="lni lni-grid-alt"></i>
                </button>
                <div class="sidebar-logo">
                    <a href="#">Options</a>
                </div>
            </div>
            <ul class="sidebar-nav">
                <li class="sidebar-item">
                    <a href="#" class="sidebar-link">
                        <i class="lni lni-user"></i>
                        <span>Profile</span>
                    </a>
                </li>
                <li class="sidebar-item">
                    <a href="#" class="sidebar-link">
                        <i class="lni lni-agenda"></i>
                        <span>Task</span>
                    </a>
                </li>
                <li class="sidebar-item">
                    <a href="#" class="sidebar-link collapsed has-dropdown" data-bs-toggle="collapse"
                        data-bs-target="#auth" aria-expanded="false" aria-controls="auth">
                        <i class="lni lni-protection"></i>
                        <span>Auth</span>
                    </a>
                    <ul id="auth" class="sidebar-dropdown list-unstyled collapse" data-bs-parent="#sidebar">
                        <li class="sidebar-item">
                            <a href="#" class="sidebar-link">Login</a>
                        </li>
                        <li class="sidebar-item">
                            <a href="#" class="sidebar-link">Register</a>
                        </li>
                    </ul>
                </li>
                <li class="sidebar-item">
                    <a href="#" class="sidebar-link collapsed has-dropdown" data-bs-toggle="collapse"
                        data-bs-target="#multi" aria-expanded="false" aria-controls="multi">
                        <i class="lni lni-layout"></i>
                        <span>Multi Level</span>
                    </a>
                    <ul id="multi" class="sidebar-dropdown list-unstyled collapse" data-bs-parent="#sidebar">
                        <li class="sidebar-item">
                            <a href="#" class="sidebar-link collapsed" data-bs-toggle="collapse"
                                data-bs-target="#multi-two" aria-expanded="false" aria-controls="multi-two">
                                Two Links
                            </a>
                            <ul id="multi-two" class="sidebar-dropdown list-unstyled collapse">
                                <li class="sidebar-item">
                                    <a href="#" class="sidebar-link">Link 1</a>
                                </li>
                                <li class="sidebar-item">
                                    <a href="#" class="sidebar-link">Link 2</a>
                                </li>
                            </ul>
                        </li>
                    </ul>
                </li>
                <li class="sidebar-item">
                    <a href="#" class="sidebar-link">
                        <i class="lni lni-popup"></i>
                        <span>Notification</span>
                    </a>
                </li>
                <li class="sidebar-item">
                    <a href="#" class="sidebar-link">
                        <i class="lni lni-cog"></i>
                        <span>Setting</span>
                    </a>
                </li>
            </ul>
            <div class="sidebar-footer">
                <a href="#" class="sidebar-link">
                    <i class="lni lni-exit"></i>
                    <span>Logout</span>
                </a>
            </div>
        </aside>
        <div class="main p-3">
            <div class="text-center">
                <h1>
                    Web Master (Admin)
                </h1>
            </div>

           <form id="registrationForm" runat="server">
            <div class="form-group">
                <label for="registrationType">Choose Registration Type:</label>
                <asp:DropDownList ID="registrationType" runat="server" AutoPostBack="true" OnSelectedIndexChanged="registrationType_SelectedIndexChanged">
                        <asp:ListItem Value="landlord">Landlord</asp:ListItem>
                        <asp:ListItem Value="warden">Warden</asp:ListItem>
                        <asp:ListItem Value="student">Student</asp:ListItem>
                </asp:DropDownList>

            </div>

            <div id="landlordForm" runat="server">
                <h2>Landlord Registration Form</h2>
                <div>
                    <label for="txtFirstNameWM">First Name:</label>
                    <asp:TextBox ID="txtFirstNameWM" runat="server"></asp:TextBox>
                </div>

                <div>
                    <label for="txtLastNameWM">Last Name:</label>
                    <asp:TextBox ID="txtLastNameWM" runat="server"></asp:TextBox>
                </div>

                <div>
                    <label for="txtNIDWM">NID(National Identity Card):</label>
                    <asp:TextBox ID="txtNIDWM" runat="server"></asp:TextBox>
                </div>

                <div>
                    <label for="txtAddress">Address:</label>
                    <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
                </div>
                <div>
                    <label for="txtEmailWM">Email:</label>
                    <asp:TextBox ID="txtEmailWM" runat="server"></asp:TextBox>
                </div>
                <div>
                    <label for="txtPasswordWM">Password:</label>
                    <asp:TextBox ID="txtPasswordWM" TextMode="Password" runat="server"></asp:TextBox>
                </div>
            </div>

            <div id="wardenForm" style="display: none;" runat="server">
                <h2>Warden Registration Form</h2>
                <div>
                    <label for="txtFirstNameWM2">First Name:</label>
                    <asp:TextBox ID="txtFirstNameWM2" runat="server"></asp:TextBox>
                </div>

                <div>
                    <label for="txtLastNameWM2">Last Name:</label>
                    <asp:TextBox ID="txtLastNameWM2" runat="server"></asp:TextBox>
                </div>

                <div>
                    <label for="txtNIDWM2">NID(National Identity Card):</label>
                    <asp:TextBox ID="txtNIDWM2" runat="server"></asp:TextBox>
                </div>

                <div>
                    <label for="txtEmailWM2">Email:</label>
                    <asp:TextBox ID="txtEmailWM2" runat="server"></asp:TextBox>
                </div>
                <div>
                    <label for="txtPasswordWM2">Password:</label>
                    <asp:TextBox ID="txtPasswordWM2" TextMode="Password" runat="server"></asp:TextBox>
                </div>
            </div>

             <div id="studentForm" style="display: none;" runat="server">
     <h2>Student Registration Form</h2>
     <div>
         <label for="txtFirstNameWM3">First Name:</label>
         <asp:TextBox ID="txtFirstNameWM3" runat="server"></asp:TextBox>
     </div>

     <div>
         <label for="txtLastNameWM3">Last Name:</label>
         <asp:TextBox ID="txtLastNameWM3" runat="server"></asp:TextBox>
     </div>

     <div>
         <label for="txtSID">SID (NSBM):</label>
         <asp:TextBox ID="txtSID" runat="server"></asp:TextBox>
     </div>

     <div>
         <label for="txtEmailWM3">Email:</label>
         <asp:TextBox ID="txtEmailWM3" runat="server"></asp:TextBox>
     </div>
     <div>
         <label for="txtPasswordWM2">Password:</label>
         <asp:TextBox ID="txtPasswordWM3" TextMode="Password" runat="server"></asp:TextBox>
     </div>
 </div>

            <div>
                <asp:Button ID="registerbtn" Text="Register" runat="server" OnClick="btnRegister_Clickk" />
            </div>
        </form>
    </div>
</div>
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha3/dist/js/bootstrap.bundle.min.js"
    integrity="sha384-ENjdO4Dr2bkBIFxQpeoTz1HIcje39Wm4jDKdf19U8gI4ddQ3GYNS7NTKfAdVQSZe"
    crossorigin="anonymous"></script>
<script src="Webmaster.js"></script>

<script>
    function toggleRegistrationForm() {
        var registrationType = document.getElementById("registrationType").value;
        if (registrationType === "landlord") {
            document.getElementById("landlordForm").style.display = "block";
            document.getElementById("wardenForm").style.display = "none";
            document.getElementById("studentForm").style.display = "none";
        } else if (registrationType === "warden") {
            document.getElementById("landlordForm").style.display = "none";
            document.getElementById("wardenForm").style.display = "block";
            document.getElementById("studentForm").style.display = "none";
        } else if (registrationType === "student") {
            document.getElementById("landlordForm").style.display = "none";
            document.getElementById("wardenForm").style.display = "none";
            document.getElementById("studentForm").style.display = "block";
        }
    }
</script>
</body>
</html>
