<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="NSBM_Hostel_Management.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.4/css/all.min.css" rel="stylesheet" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/js/bootstrap.bundle.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jQuery-slimScroll/1.3.8/jquery.slimscroll.min.js"></script>
    <style>
        /* Set the video to be fullscreen */
        video {
            position: fixed;
            top: 0;
            left: 0;
            width: 100%; /* Set video width to 100% of viewport */
            height: 100%; /* Set video height to 100% of viewport */
            z-index: -1; /* Place the video behind other content */
            opacity: 50%;
            object-fit: cover; /* Ensure the video covers the entire area */
            filter: blur(5px); /* Apply a blur effect */
        }
        /* Add additional styles for other content if necessary */
        body {
            margin: 0;
            padding: 0;
            font-family: Roboto, sans-serif;
            background-color: black;
        }
        /* You can style other content here */
        /* For example, to center content vertically and horizontally: */
        #content {
            position: absolute;
            top: 50%;
            left: 50%;
            transform: translate(-50%, -50%);
            color: white;
            text-align: center;
        }

            #content h1, #content p, #content h6, #content button {
                text-shadow: 2px 2px 4px rgba(0, 0, 0, 0.5);
            }

        @keyframes blink {
            0% {
                opacity: 1;
            }

            50% {
                opacity: 0;
            }

            100% {
                opacity: 1;
            }
        }

        h6.blinking {
            animation: blink 1s infinite;
        }
    </style>
</head>

<body>
    <form id="form1" runat="server">
        <div>

            <!-- Video element -->
            <video autoplay loop muted playsinline>
                <source src="assets/NSBM.mp4" type="video/mp4">
                <!-- Add additional source elements for different video formats if needed -->
                Your browser does not support the video tag.
            </video>

            <!-- Content -->
            <div id="content">
                <div class="px-3 py-4 my-4 text-center">
                    <h1 class="display-5 fw-bold" style="font-size: 80px">NSBM ACCOMODATIONS</h1>
                    <div class="col-lg-10 mx-auto pt-3">
                        <p class="lead mb-4">Your all-in-one solution for streamlined student accommodation (Exclusively for NSBM Green University Students). Our platform offers hassle-free room reservation, easy ad posting, robust security, and seamless communication.</p>
                        <h6 class="blinking">Select Your Role Below!</h6>
                        <div class="pt-2 d-grid gap-3 d-sm-flex justify-content-sm-center">
                            <button type="button" class="btn btn-primary btn-lg px-4 gap-3" data-bs-toggle="modal" data-bs-target="#StudentModalLog">Student</button>
                            <button type="button" class="btn btn-warning btn-lg px-4 gap-3" data-bs-toggle="modal" data-bs-target="#LandlordModalLog">Landlord</button>
                            <button type="button" class="btn btn-danger btn-lg px-4 gap-3" data-bs-toggle="modal" data-bs-target="#WardenModalLog">Warden</button>
                            <button type="button" class="btn btn-success btn-lg px-4 gap-3" data-bs-toggle="modal" data-bs-target="#WebMasterModalLog">Web Master</button>
                        </div>
                    </div>
                </div>
            </div>

        </div>



        <!-- Student login Modal -->
        <div class="modal fade" id="StudentModalLog" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="StudentModalLogLabel" aria-hidden="true">
            <div class="modal-dialog modal-dialog-centered modal-dialog-scrollable">
                <div class="modal-content">
                    <div class="modal-header">
                        <h1 class="modal-title fs-5">Login</h1>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body">
                        <form id="studentloginForm">
                            <div class="mb-3">
                                <label for="email" class="form-label">Email address</label>
                                <div class="d-flex justify-content-center">
                                    <!-- Center aligning the textbox -->
                                    <asp:TextBox ID="semail" TextMode="Email" CssClass="form-control text-center" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="mb-3">
                                <label for="password" class="form-label">Password</label>
                                <div class="d-flex justify-content-center">
                                    <!-- Center aligning the textbox -->
                                    <asp:TextBox ID="spassword" TextMode="Password" CssClass="form-control text-center" runat="server"></asp:TextBox>
                                </div>
                            </div>

                        </form>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                        <asp:Button ID="btnslogin" class="btn btn-primary" Text="Login" UseSubmitBehavior="False" OnClick="btnslogin_Click" runat="server" />

                    </div>
                </div>
            </div>
        </div>

        <!-- Landlord login Modal -->
        <div class="modal fade" id="LandlordModalLog" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="LandlordModalLogLabel" aria-hidden="true">
            <div class="modal-dialog modal-dialog-centered modal-dialog-scrollable">
                <div class="modal-content">
                    <div class="modal-header">
                        <h1 class="modal-title fs-5">Login</h1>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body">
                        <form id="landlordloginForm">
                            <div class="mb-3">
                                <label for="landemail" class="form-label">Email address</label>

                                <div class="d-flex justify-content-center">

                                    <asp:TextBox ID="llemail" TextMode="Email" CssClass="form-control text-center" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="mb-3">
                                <label for="landpassword" class="form-label">Password</label>

                                <div class="d-flex justify-content-center">

                                    <asp:TextBox ID="llpassword" TextMode="Password" CssClass="form-control text-center" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div>
                                <p>Haven't registered yet? <a href="#" data-bs-toggle="modal" data-bs-target="#LandlordModalReg">Register Now</a></p>
                            </div>
                        </form>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>

                        <asp:Button ID="llloginbtn" class="btn btn-primary" Text="Login" UseSubmitBehavior="False" OnClick="llloginbtn_Click" runat="server" />
                    </div>
                </div>
            </div>
        </div>

         
        <!-- Landlord registration Modal -->
<div class="modal fade" id="LandlordModalReg" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="LandlordModalRegLabel" aria-hidden="true">
    <div class="modal-dialog modal-dialog-centered modal-dialog-scrollable">
        <div class="modal-content">
            <div class="modal-header">
              
                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
            </div>
            <div class="modal-body">
                <form id="landlordRegistrationForm" >
                    <div class="mb-3">
                        <label for="llfirstName" class="form-label">First Name</label>
                        <asp:TextBox ID="llfirstName" CssClass="form-control text-center" runat="server" ></asp:TextBox>
                    </div>
                    <div class="mb-3">
                        <label for="lllastName" class="form-label">Last Name</label>
                        <asp:TextBox ID="lllastName" CssClass="form-control text-center" runat="server" ></asp:TextBox>
                    </div>
                    <div class="mb-3">
                        <label for="llemail" class="form-label">Email address</label>
                        <asp:TextBox ID="llemail2" CssClass="form-control text-center" runat="server" TextMode="Email" ></asp:TextBox>
                    </div>
                    <div class="mb-3">
                        <label for="llpassword" class="form-label">Password</label>
                        <asp:TextBox ID="llpassword2" CssClass="form-control text-center" runat="server" TextMode="Password" ></asp:TextBox>
                    </div>
                   
                    <div class="mb-3">
                        <label for="llNIC" class="form-label">NIC (National Identity Card)</label>
                        <asp:TextBox ID="llNIC" CssClass="form-control text-center" runat="server" ></asp:TextBox>
                    </div>
                    <div class="mb-3">
                        <label for="llAddress" class="form-label">Address</label>
                        <asp:TextBox ID="llAddress" CssClass="form-control text-center"  runat="server" ></asp:TextBox>
                    </div>
                </form>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                <asp:Button ID="llregisterbtn" CssClass="btn btn-primary" Text="Register" UseSubmitBehavior="False" OnClick="llregisterbtn_Click" runat="server" />
            </div>
        </div>
    </div>
</div>






        <!-- Warden login Modal -->
        <div class="modal fade" id="WardenModalLog" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="WardenModalLogLabel" aria-hidden="true">
            <div class="modal-dialog modal-dialog-centered modal-dialog-scrollable">
                <div class="modal-content">
                    <div class="modal-header">
                        <h1 class="modal-title fs-5">Login</h1>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body">
                        <form id="wardenloginForm">
                            <div class="mb-3">
                                <label for="email" class="form-label">Email address</label>

                                <div class="d-flex justify-content-center">

                                    <asp:TextBox ID="wemail" TextMode="Email" CssClass="form-control text-center" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="mb-3">
                                <label for="password" class="form-label">Password</label>

                                <div class="d-flex justify-content-center">

                                    <asp:TextBox ID="wpassword" TextMode="Password" CssClass="form-control text-center" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </form>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>

                        <asp:Button ID="wloginbtn" class="btn btn-primary" Text="Login" UseSubmitBehavior="False" OnClick="wloginbtn_Click" runat="server" />
                    </div>
                </div>
            </div>
        </div>

        <!-- Webmaster login Modal -->
        <div class="modal fade" id="WebMasterModalLog" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="WebMasterLogLabel" aria-hidden="true">
            <div class="modal-dialog modal-dialog-centered modal-dialog-scrollable">
                <div class="modal-content">
                    <div class="modal-header">
                        <h1 class="modal-title fs-5" id="WebMasterLogLabel">Login</h1>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body">
                        <form id="webmasterloginForm">
                            <div class="mb-3">
                                <label for="email" class="form-label">Email address</label>

                                <div class="d-flex justify-content-center">

                                    <asp:TextBox ID="wmemail" TextMode="Email" CssClass="form-control text-center" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="mb-3">
                                <label for="password" class="form-label">Password</label>

                                <div class="d-flex justify-content-center">

                                    <asp:TextBox ID="wmpassword" TextMode="Password" CssClass="form-control text-center" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </form>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>

                        <asp:Button ID="webmlogin" class="btn btn-primary" Text="Login" UseSubmitBehavior="False" OnClick="webmlogin_Click" runat="server" />
                    </div>
                </div>
            </div>
        </div>


    </form>

</body>
</html>
