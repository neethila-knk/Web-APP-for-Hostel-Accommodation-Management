<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="newmap.aspx.cs" Inherits="test1.newmap" %>

<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>SDTP</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.4/css/all.min.css" rel="stylesheet" />
    <link href=" student.css" rel="stylesheet" />
    <style>
        .modal {
            display: none;
            position: absolute;
            z-index: 1;
            background-color: white;
            padding: 20px;
            border-radius: 5px;
            box-shadow: 0 2px 8px rgba(0, 0, 0, 0.1);
            overflow-y: auto; /* Add vertical scrollbar */
            max-height: 80%; /* Limit the maximum height of the modal */
            width: 200px;
        }

        #map{
            height: 100%;
        }
    </style>
</head>
<body>

    <section class="head">
        <div class="container">
            <div class="heading-container">
                <h1 class="main-heading">Student Page</h1>
                <p class="description">This is a description of the Student page.</p>
            </div>
        </div>
    </section>

    <section class="search-box p-5" runat="server">
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-4" >
                    <div class="card-list-scroll">
                        <% foreach (var hostel in fetchHostelData())
                            { %>
                        <div class="card mb-3" data-longitude="<%= hostel.Longitude %>" data-latitude="<%= hostel.Latitude %>">
                            <div class="row g-0">
                                <div class="col-md-4">
                                    <img src="<%: hostel.ImageUrl %>" class="img-fluid rounded-start hostel-img" alt="<%: hostel.Name %>" style="object-fit:cover">
                                </div>
                                <div class="col-md-8">
                                    <div class="card-body">
                                        <h5 class="card-title"><%: hostel.Name %></h5>
                                        <p class="card-text"><%: hostel.Description %></p>
                                         <p class="card-text card-price">Price: $<%: hostel.Price %></p>
                                        <div class=" d-flex d-inline-block">
                                            <p class="card-text mb-2"><small class="text-muted"><%: hostel.Rooms %> rooms</small></p>
                                        </div>
                                        <div class="btn-group" role="group" aria-label="Media buttons">

                                            <button type="button" class="btn btn-primary " id="btncheck" onclick="setHostelIdAndName(<%= hostel.CID %>, '<%= hostel.Name %>')">Reserve</button>

                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <% } %>
                    </div>

                </div>
                <div class="col-lg-8  " >
    <div id="map"></div>
</div>
                
            </div>
        </div>
    </section>




    <form id="studentregform" runat="server">
        <div>
            <span class="closeButton" id="closeButton">&times;</span>
            <h2>Landlord Registration Form</h2>
            <div>
                <label for="txtFirstName">First Name:</label>
                <asp:TextBox ID="txtFirstName" runat="server" CssClass="txtinput"></asp:TextBox>
            </div>
            <div>
                <label for="txtLastName">Last Name:</label>
                <asp:TextBox ID="txtLastName" runat="server" CssClass="txtinput"></asp:TextBox>
            </div>
            <div>
                <label for="txtEmail">Email:</label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="txtinput"></asp:TextBox>
            </div>
            <div>
                <label for="txtphone">Phone Number:</label>
                <asp:TextBox ID="txtphone" runat="server" CssClass="txtinput"></asp:TextBox>
            </div>
            <div>
                <label for="lbltextarea">More Details:</label>
                <asp:TextBox ID="txtArea" runat="server" TextMode="MultiLine" Rows="4" Columns="50" CssClass="txtinput"></asp:TextBox>
            </div>

           
    

            <asp:Button ID="btnsend" runat="server" Text="Send" OnClick="btnsend_Click" />


            <asp:HiddenField ID="hiddenHostelId" runat="server" />
            <asp:HiddenField ID="hiddenHostelName" runat="server" />
        </div>
    </form>
    <div class="overlay"></div>

    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyDZvudURYymqSItL1YUc6Hvsye9wgkED0c&libraries=geometry,places&callback=initMap" async defer></script>
    <script src="newmap.js"></script>
    <script>
        function setHostelIdAndName(hostelId, hostelName) {

            document.getElementById('<%= hiddenHostelId.ClientID %>').value = hostelId;

            document.getElementById('<%= hiddenHostelName.ClientID %>').value = hostelName;
        }





    </script>
</body>
</html>
