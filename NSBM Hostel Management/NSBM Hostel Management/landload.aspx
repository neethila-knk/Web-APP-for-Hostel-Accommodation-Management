<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="landload.aspx.cs" Inherits="NSBM_Hostel_Management.landload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Hostel</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous">
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
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="lblUserEmail" runat="server" Text=""></asp:Label>
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-3">
                    <asp:Button ID="btnAddHostel" runat="server" Text="Add Hostel" CssClass="btn btn-primary mr-2" OnClick="btnAddHostel_Click" />
                </div>
                 <div class="col-md-9">
                <!-- Second Section -->
                <!-- Content for the right section goes here -->
                     
<asp:PlaceHolder ID="PlaceHolder" runat="server"></asp:PlaceHolder> 
                <section>
                   <div class="card text-center">
   <div class="card-header">
    <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-primary mr-2" OnClick="btnlandUpdate_Click" />
    <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-danger" OnClick="btnDelete_Click" />
</div>


                        <div class="card-body">
                            <div class="row">
                                <!-- Section 1: Room Info -->
                                <div class="col">
                                    <div class="section-content">
                                        <h5 class="card-title">Room Information</h5>
                                        <p class="card-text">
                                            Number of rooms: <span id="numRooms">10</span><br>
                                            Number of beds: <span id="numBeds">10</span><br>
                                            Number of rooms: <span id="description">good</span><br>
                                            Price: <span id="price">$1000</span>
                                        </p>
                                    </div>
                                </div>
                                <!-- Section 2: Image 1 -->
                                <div class="col">
                                    <div class="section-content">
                                        <img src="UploadedImages\image1.JPEG" alt="Image 1">
                                    </div>
                                </div>
                                <!-- Section 3: Image 2 -->
                                <div class="col">
                                    <div class="section-content">
                                        <img src="UploadedImages\image2.JPEG" alt="Image 2">
                                    </div>
                                </div>
                                <!-- Section 4: Image 3 -->
                                <div class="col">
                                    <div class="section-content">
                                        <img src="UploadedImages\image3.JPEG" alt="Image 3">
                                    </div>
                                </div>
                                <!-- Section 5: Image 4 -->
                                <div class="col">
                                    <div class="section-content">
                                        <img src="UploadedImages\image4.JPEG" alt="Image 4">
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </section>
            </div>
            </div>
        </div>
    </form>
</body>
</html>

