<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="landload.aspx.cs" Inherits="NSBM_Hostel_Management.landload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Hostel</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.4/css/all.min.css" rel="stylesheet" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/js/bootstrap.bundle.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jQuery-slimScroll/1.3.8/jquery.slimscroll.min.js"></script>
    <style>
        .card {
            padding: 20px 15px 20px 20px; /* Add padding to the cards (top, right, bottom, left) */
            margin-bottom: 20px; /* Add margin bottom to create space between cards */
            border: 1px solid #ced4da; /* Add border to the cards */
            border-radius: 0.25rem; /* Add border radius to the cards */
            max-width: calc(100% - 20px); /* Set maximum width of the cards */
        }

        .section-content img {
            width: 100%; /* Ensure images take up the full width of their container */
            height: 200px; /* Set the height of the images */
            object-fit: cover; /* Ensure images maintain aspect ratio and cover the entire container */
        }

        .head {
            background-color: #f0f0f0;
            padding: 20px 0;
        }

        .heading-container {
            text-align: center;
        }

        .main-heading {
            font-size: 2.5rem;
            color: #333;
            margin-bottom: 10px;
        }

        .description {
            font-size: 1rem;
            color: #666;
        }
    </style>
</head>
<body>

    <form id="form1" runat="server">
        <section class="head">
            <div class="container">
                <div class="heading-container">
                    <h1 class="main-heading">Landlord Dashboard</h1>
                    <asp:Label ID="lblUserEmail" runat="server" Text=""></asp:Label>
                </div>
            </div>
        </section>


        <div class="container">
            <div class="text-center m-4">
                <button type="button" class="btn btn-outline-dark" data-bs-toggle="modal" data-bs-target="#addHostelModal">Click me to add hostels</button>
            </div>

            <section class="sub-head">
                <div class="container">
                    <div class="">
                        <h2 class="text-left mt-5"><span style="color: red">Pending</span> Hostel List</h2>
                        <p class="description text-left">Waiting for Approval...</p>
                    </div>
                    <hr />
                </div>
            </section>
            <asp:PlaceHolder ID="PlaceHolder" runat="server"></asp:PlaceHolder>

            <section class="sub-head">
                <div class="container">
                    <div class="">
                        <h2 class="text-left mt-5"><span style="color: green">Approved</span> Hostel List</h2>
                        <p class="description text-left">Your Approved Hostels!</p>
                    </div>
                    <hr />
                </div>
            </section>
            <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
        </div>



        <div class="modal fade" id="addHostelModal" tabindex="-1" role="dialog" aria-labelledby="addHostelModalLabel" aria-hidden="true">
            <div class="modal-dialog modal-dialog-centered modal-dialog-scrollable" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="addHostelModalLabel">Add Hostel</h5>
                        <asp:Button ID="btnCloseAddHostelModal" runat="server" CssClass="btn-close" data-dismiss="modal" aria-label="Close" />
                    </div>
                    <div class="modal-body">

                        <div>
                            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                            <br />

                            Title:
                            <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control"></asp:TextBox><br />
                            Description:
                            <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3"></asp:TextBox><br />
                            Price:
                            <asp:TextBox ID="txtPrice" runat="server" CssClass="form-control"></asp:TextBox><br />
                            Latitude:
                            <asp:TextBox ID="txtLatitude" runat="server" CssClass="form-control"></asp:TextBox><br />
                            Longitude:
                            <asp:TextBox ID="txtLongitude" runat="server" CssClass="form-control"></asp:TextBox><br />
                            Image 1:
                            <asp:FileUpload ID="fileImage1" runat="server" CssClass="form-control" /><br />
                            Image 2:
                            <asp:FileUpload ID="fileImage2" runat="server" CssClass="form-control" /><br />
                            Image 3:
                            <asp:FileUpload ID="fileImage3" runat="server" CssClass="form-control" /><br />
                            Image 4:
                            <asp:FileUpload ID="fileImage4" runat="server" CssClass="form-control" /><br />
                            <br />
                            Rooms:
                            <asp:TextBox ID="txtRooms" runat="server" CssClass="form-control"></asp:TextBox><br />
                            Beds:
                            <asp:TextBox ID="txtBeds" runat="server" CssClass="form-control"></asp:TextBox><br />
                        </div>
                    </div>

                    <div class="modal-footer">
                        <%--<button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>--%>
                        <asp:Button ID="ButtonClose" runat="server" Text="Close" CssClass="btn btn-secondary" data-dismiss="modal" />
                        <asp:Button ID="btnAddHostel" runat="server" Text="Add Hostel" OnClientClick="return validateAddModal();" OnClick="btnAddHostel_Click" CssClass="btn btn-primary" />
                    </div>
                </div>
            </div>
        </div>



        <div class="modal fade" id="myModal" runat="server">
            <div class="modal-dialog modal-dialog-centered modal-dialog-scrollable">
                <div class="modal-content">
                    <!-- Modal Header -->
                    <div class="modal-header">
                        <h4 class="modal-title">Modal Heading</h4>
                        <asp:Button ID="btnCloseModal" runat="server" CssClass="btn-close" data-dismiss="modal" aria-label="Close" />
                    </div>

                    <!-- Modal body -->
                    <div class="modal-body">
                        <div class="mb-3">
                            <label for="txtHostelIDModal" class="form-label">Hostel ID:</label>
                            <asp:TextBox ID="txtHostelIDModal" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <label for="txtTitleModal" class="form-label">Title:</label>
                            <asp:TextBox ID="txtTitleModal" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <label for="txtDescriptionModal" class="form-label">Description:</label>
                            <asp:TextBox ID="txtDescriptionModal" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3"></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <label for="txtPriceModal" class="form-label">Price:</label>
                            <asp:TextBox ID="txtPriceModal" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <label for="txtLatitudeModal" class="form-label">Latitude:</label>
                            <asp:TextBox ID="txtLatitudeModal" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <label for="txtLongitudeModal" class="form-label">Longitude:</label>
                            <asp:TextBox ID="txtLongitudeModal" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>

                        <!-- Image upload for column 1 -->
                        <div class="mb-3">
                            <label for="fileImage1" class="form-label">Image 1:</label>
                            <asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control" />
                            <img id="imgColumn1" src="#" alt="Image 1" style="display: none; max-width: 100%; max-height: 100px;" />
                        </div>
                        <!-- Image upload for column 2 -->
                        <div class="mb-3">
                            <label for="fileImage2" class="form-label">Image 2:</label>
                            <asp:FileUpload ID="FileUpload2" runat="server" CssClass="form-control" />
                            <img id="imgColumn2" src="#" alt="Image 2" style="display: none; max-width: 100%; max-height: 100px;" />
                        </div>
                        <!-- Image upload for column 3 -->
                        <div class="mb-3">
                            <label for="fileImage3" class="form-label">Image 3:</label>
                            <asp:FileUpload ID="FileUpload3" runat="server" CssClass="form-control" />
                            <img id="imgColumn3" src="#" alt="Image 3" style="display: none; max-width: 100%; max-height: 100px;" />
                        </div>
                        <!-- Image upload for column 4 -->
                        <div class="mb-3">
                            <label for="fileImage4" class="form-label">Image 4:</label>
                            <asp:FileUpload ID="FileUpload4" runat="server" CssClass="form-control" />
                            <img id="imgColumn4" src="#" alt="Image 4" style="display: none; max-width: 100%; max-height: 100px;" />
                        </div>

                        <div class="mb-3">
                            <label for="txtRoomsModal" class="form-label">Rooms:</label>
                            <asp:TextBox ID="txtRoomsModal" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>

                        <div class="mb-3">
                            <label for="txtBedsModal" class="form-label">Beds:</label>
                            <asp:TextBox ID="txtBedsModal" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>

                        <!-- Modal footer -->
                        <div class="modal-footer">
                            <asp:Button ID="Button1" runat="server" Text="Close" CssClass="btn btn-secondary" data-dismiss="modal" />
                            <asp:Button ID="btnUpdateHostel" runat="server" Text="Update now" OnClientClick="return validateUpdateModal();" OnClick="btnUpdateHostel_Click" CssClass="btn btn-primary" />
                        </div>
                    </div>
                </div>
            </div>
        </div>





        <script type="text/javascript">
            function openModal() {
                var myModal = new bootstrap.Modal(document.getElementById('myModal'));
                myModal.show();
            }
        </script>

        <script>
            function validateAddModal() {
                // Check if title is empty
                var title = document.getElementById('<%= txtTitle.ClientID %>').value;
                if (title.trim() === '') {
                    alert('Please enter a title.');
                    return false;
                }

                // Check if description is empty
                var description = document.getElementById('<%= txtDescription.ClientID %>').value;
                if (description.trim() === '') {
                    alert('Please enter a description.');
                    return false;
                }

                // Check if price is a valid number
                var price = parseFloat(document.getElementById('<%= txtPrice.ClientID %>').value);
                if (isNaN(price) || price <= 0) {
                    alert('Please enter a valid price.');
                    return false;
                }

                // Check if latitude is a valid number
                var latitude = parseFloat(document.getElementById('<%= txtLatitude.ClientID %>').value);
                if (isNaN(latitude)) {
                    alert('Please enter a valid latitude.');
                    return false;
                }

                // Check if longitude is a valid number
                var longitude = parseFloat(document.getElementById('<%= txtLongitude.ClientID %>').value);
                if (isNaN(longitude)) {
                    alert('Please enter a valid longitude.');
                    return false;
                }

                // Check if all images are uploaded
                var fileImage1 = document.getElementById('<%= fileImage1.ClientID %>').value;
                var fileImage2 = document.getElementById('<%= fileImage2.ClientID %>').value;
                var fileImage3 = document.getElementById('<%= fileImage3.ClientID %>').value;
                var fileImage4 = document.getElementById('<%= fileImage4.ClientID %>').value;
                if (fileImage1.trim() === '' || fileImage2.trim() === '' || fileImage3.trim() === '' || fileImage4.trim() === '') {
                    alert('Please upload all four images.');
                    return false;
                }

                // Check if rooms is a valid number
                var rooms = parseInt(document.getElementById('<%= txtRooms.ClientID %>').value);
                if (isNaN(rooms) || rooms <= 0) {
                    alert('Please enter a valid number of rooms.');
                    return false;
                }

                // Check if beds is a valid number
                var beds = parseInt(document.getElementById('<%= txtBeds.ClientID %>').value);
                if (isNaN(beds) || beds <= 0) {
                    alert('Please enter a valid number of beds.');
                    return false;
                }
            }

        </script>


        <script>
            function validateUpdateModal() {
                var hostelID = document.getElementById('<%= txtHostelIDModal.ClientID %>').value;
                var title = document.getElementById('<%= txtTitleModal.ClientID %>').value;
                var description = document.getElementById('<%= txtDescriptionModal.ClientID %>').value;
                var price = parseFloat(document.getElementById('<%= txtPriceModal.ClientID %>').value);
                var latitude = parseFloat(document.getElementById('<%= txtLatitudeModal.ClientID %>').value);
                var longitude = parseFloat(document.getElementById('<%= txtLongitudeModal.ClientID %>').value);
                var file1 = document.getElementById('<%= FileUpload1.ClientID %>').value;
                var file2 = document.getElementById('<%= FileUpload2.ClientID %>').value;
                var file3 = document.getElementById('<%= FileUpload3.ClientID %>').value;
                var file4 = document.getElementById('<%= FileUpload4.ClientID %>').value;
                var rooms = parseInt(document.getElementById('<%= txtRoomsModal.ClientID %>').value);
                var beds = parseInt(document.getElementById('<%= txtBedsModal.ClientID %>').value);

                if (hostelID.trim() === '') {
                    alert('Please enter a Hostel ID.');
                    return false;
                }
                if (title.trim() === '') {
                    alert('Please enter a Title.');
                    return false;
                }
                if (description.trim() === '') {
                    alert('Please enter a Description.');
                    return false;
                }
                if (isNaN(price) || price <= 0) {
                    alert('Please enter a valid Price.');
                    return false;
                }
                if (isNaN(latitude)) {
                    alert('Please enter a valid Latitude.');
                    return false;
                }
                if (isNaN(longitude)) {
                    alert('Please enter a valid Longitude.');
                    return false;
                }
                if (file1.trim() === '' || file2.trim() === '' || file3.trim() === '' || file4.trim() === '') {
                    alert('Please upload all four images.');
                    return false;
                }
                if (isNaN(rooms) || rooms <= 0) {
                    alert('Please enter a valid number of Rooms.');
                    return false;
                }
                if (isNaN(beds) || beds <= 0) {
                    alert('Please enter a valid number of Beds.');
                    return false;
                }

                return true;
            }
        </script>




    </form>
</body>
</html>

