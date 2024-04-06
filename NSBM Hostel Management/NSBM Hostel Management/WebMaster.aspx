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
                    <a href="#" class="sidebar-link collapsed has-dropdown" onclick="toggleRegistrationForm()" data-bs-toggle="collapse"
                        data-bs-target="#regi" aria-expanded="false" aria-controls="regi">
                        <i class="lni lni-agenda"></i>
                        <span>Registrations</span>
                    </a>
                     <ul id="regi" class="sidebar-dropdown list-unstyled collapse" data-bs-parent="#sidebar">
                        <li class="sidebar-item">
                        <a href="#" onclick="toggleRegistrationForm('landlord')" class="sidebar-link">Landlord</a>
                         </li>
                         <li class="sidebar-item">
                          <a href="#" onclick="toggleRegistrationForm('warden')" class="sidebar-link">Warden</a>
                          </li>
                         <li class="sidebar-item">
                        <a href="#" onclick="toggleRegistrationForm('student')" class="sidebar-link">Student</a>
                        </li>
                     </ul>
                </li>
               
             <li class="sidebar-item">
              <a href="#" class="sidebar-link" onclick="showArticleForm()">
                <i class="lni lni-layout"></i>
                  <span>Post</span>
                      </a>
                    </li>
                <li class="sidebar-item">
                    <a href="#" class="sidebar-link" onclick="showArticles()">
                        <i class="lni lni-popup"></i>
                        <span>Articles</span>
                    </a>
                </li>
                
            </ul>
            <div class="sidebar-footer">
                <a href="#" class="sidebar-link" onclick="btnwebLogout_Click()">
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
            
            <div id="testtt" runat="server">
   
</div>

            <div id="postsContainer" runat="server">
    <!-- This is where the posted content will be displayed -->
</div>
           <form id="registrationForm" runat="server" style="display:none;">
            <div class="form-group">
                <asp:DropDownList ID="registrationType" runat="server" AutoPostBack="false" OnSelectedIndexChanged="registrationType_SelectedIndexChanged" style="display: none;">
                        <asp:ListItem Value="landlord">Landlord</asp:ListItem>
                        <asp:ListItem Value="warden">Warden</asp:ListItem>
                        <asp:ListItem Value="student">Student</asp:ListItem>
                        <asp:ListItem Value="article">Article</asp:ListItem>
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
                    <label for="txtNIDWM">NIC(National Identity Card):</label>
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
                    <label for="txtPasswordWM">Password:</label><br/>
                    <asp:TextBox ID="txtPasswordWM" TextMode="Password"  runat="server" style="width:100%; height:44px; border-radius:5px" ></asp:TextBox>
                </div><br />
                <div>
    <asp:Button ID="registerbtn" Text="Register" runat="server" OnClick="btnRegister_Clickk" />
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
                    <label for="txtNIDWM2">NIC(National Identity Card):</label>
                    <asp:TextBox ID="txtNIDWM2" runat="server"></asp:TextBox>
                </div>

                <div>
                    <label for="txtEmailWM2">Email:</label>
                    <asp:TextBox ID="txtEmailWM2" runat="server"></asp:TextBox>
                </div>
                <div>
                    <label for="txtPasswordWM2">Password:</label><br />
                    <asp:TextBox ID="txtPasswordWM2" TextMode="Password" runat="server" style="width:100%;height:44px; border-radius:5px" ></asp:TextBox>
                </div><br />

                    <div>
    <asp:Button ID="Button1" Text="Register" runat="server" OnClick="btnRegister_Clickk" />
</div>
            </div>

             <div id="studentForm" style="display: none;" runat="server">
     <h2>Student Registration Form</h2>
     <div>
         <lsabel for="txtFirstNameWM3">First Name:</lsabel>
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
         <label for="txtPasswordWM2">Password:</label><br />
         <asp:TextBox ID="txtPasswordWM3" TextMode="Password" runat="server" style="width:100%;height:44px; border-radius:5px" ></asp:TextBox>
     </div><br />
                 <div>
    <asp:Button ID="Button2" Text="Register" runat="server" OnClick="btnRegister_Clickk" />
</div>
 </div>

                  <div id="articleForum" style="display: none;" runat="server">
    <header>
        <h1>Article Forum</h1>
    </header>
    <main>
        <label for="title">Title:</label>
        <asp:TextBox ID="ptitle" runat="server"></asp:TextBox>
        <label for="author">Author:</label>
        <asp:TextBox ID="pauthor" runat="server"></asp:TextBox>
        <label for="content">Content:</label>
        <asp:TextBox ID="pcontent" runat="server" TextMode="MultiLine" Rows="5"></asp:TextBox>
        <asp:Button ID="submitpostButton" runat="server" Text="Post" OnClick="submitpostButton_Click" />
       
    </main>
</div>
            

        </form>

        
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha3/dist/js/bootstrap.bundle.min.js"
    integrity="sha384-ENjdO4Dr2bkBIFxQpeoTz1HIcje39Wm4jDKdf19U8gI4ddQ3GYNS7NTKfAdVQSZe"
    crossorigin="anonymous"></script>

<script src="Webmaster.js"></script>
    <script>
        function toggleSection(section) {
            if (section === 'article') {
                document.getElementById("landlordForm").style.display = "none";
                document.getElementById("wardenForm").style.display = "none";
                document.getElementById("studentForm").style.display = "none";
                document.getElementById("articleForum").style.display = "block";
            } else {
                toggleRegistrationForm(section);
            }
        }

        function toggleRegistrationForm(type) {
            var registrationForm = document.getElementById("registrationForm");
            var registrationTypeDropdown = document.getElementById("registrationType");

            if (type === "landlord") {
                registrationTypeDropdown.value = "landlord";
                document.getElementById("landlordForm").style.display = "block";
                document.getElementById("wardenForm").style.display = "none";
                document.getElementById("studentForm").style.display = "none";
                document.getElementById("articleForum").style.display = "none";
                document.getElementById("postsContainer").style.display = "none";
            } else if (type === "warden") {
                registrationTypeDropdown.value = "warden";
                document.getElementById("landlordForm").style.display = "none";
                document.getElementById("wardenForm").style.display = "block";
                document.getElementById("studentForm").style.display = "none";
                document.getElementById("articleForum").style.display = "none";
                document.getElementById("postsContainer").style.display = "none";
                postsContainer.style.display = "none";
            } else if (type === "student") {
                registrationTypeDropdown.value = "student";
                document.getElementById("landlordForm").style.display = "none";
                document.getElementById("wardenForm").style.display = "none";
                document.getElementById("studentForm").style.display = "block";
                document.getElementById("articleForum").style.display = "none";
                document.getElementById("postsContainer").style.display = "none";
                postsContainer.style.display = "none";
            } else if (type === "article") {
                registrationTypeDropdown.value = "article";
                document.getElementById("landlordForm").style.display = "none";
                document.getElementById("wardenForm").style.display = "none";
                document.getElementById("studentForm").style.display = "none";
                document.getElementById("articleForum").style.display = "block";
                document.getElementById("postsContainer").style.display = "none";
            } else {
                registrationForm.style.display = "block";
            }
        }


        function showArticleForm() {
            var registrationForm = document.getElementById("registrationForm");
            var articleForm = document.getElementById("articleForum");
            

            // Check if the registration form is hidden
            if (registrationForm.style.display === "none") {
                // If hidden, toggle the registration form first
                toggleRegistrationForm();
            }

            // Show the article form
            articleForm.style.display = "block";
            landlordForm.style.display = "none";
            wardenForm.style.display = "none";
            studentForm.style.display = "none";
            postsContainer.style.display = "none";
            

        }

        function showArticles() {
            document.getElementById("landlordForm").style.display = "none";
            document.getElementById("wardenForm").style.display = "none";
            document.getElementById("studentForm").style.display = "none";
            document.getElementById("articleForum").style.display = "none";
            document.getElementById("postsContainer").style.display = "block";
        }
        function btnwebLogout_Click() {
            // Your logout logic here
            console.log("Logout button clicked");
          

            window.location.href = "index.aspx"; 
        }


    </script>



</div>
</div>
</body>
</html>