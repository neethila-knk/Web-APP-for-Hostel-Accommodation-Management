<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WardenHomePage.aspx.cs" Inherits="NSBM_Hostel_Management.WardenHomePage" %>

<!DOCTYPE html>

<html lang="en">
<head runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Warden Dashboard</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.4/css/all.min.css" rel="stylesheet" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/js/bootstrap.bundle.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jQuery-slimScroll/1.3.8/jquery.slimscroll.min.js"></script>

    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCVy90FE4evtixL-8e0avAziJz0aajSI7I&libraries=geometry,places&callback=initMap" async defer></script>



    <style>
        .card-list-scroll {
            max-height: 495px; 
            overflow-y: auto; 
            padding-right: 15px; 
        }

            .card-list-scroll .card {
                margin-bottom: 15px; 
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

        .hostel-img {
            width: 100%;
            height: 100%;
            object-fit: cover;
        }

        .hostelcard {
            transition: transform 0.3s ease, background-color 0.3s ease; 
        }

           
            .hostelcard:hover {
                transform: scale(1.05);
                background-color: seashell;
            }
    </style>


</head>
<body>
    <form id="form1" runat="server">

        <section class="head">
            <div class="container">
                <div class="heading-container">
                    <h1 class="main-heading">Warden Dashboard</h1>
                    <p class="description">Welcome to warden dashboard</p>
                </div>
            </div>
        </section>

        <section class="search-box p-5">
            <div class="container-fluid">
                <div class="row">

                    <div class="col-lg-4 listing-block">
                        <div id="cardListScroll" class="card-list-scroll" runat="server">
                        </div>
                    </div>

                    <div id="map" runat="server" class="col-lg-8 map-box mx-0 px-0">
                    </div>
                </div>
            </div>
        </section>

        <section class="sub-head">
            <div class="container">
                <div class="">
                    <h2 class="text-center mt-5"><span style="color: green">Approved</span> Hostel List</h2>
                    <p class="description text-center">Approved hostels by you!</p>
                </div>
                <hr />
            </div>
        </section>

        <section class="container">
            <asp:Table ID="approvedHostelTable" runat="server" CssClass="table">

                <asp:TableHeaderRow>
                    <asp:TableHeaderCell>Hostel ID</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Title</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Description</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Price</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Beds</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Rooms</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Status</asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>

            <nav aria-label="Page navigation">
        <ul class="pagination justify-content-center">
            <li class="page-item disabled">
                <a class="page-link" href="#" tabindex="-1" aria-disabled="true">Previous</a>
            </li>
            <li class="page-item active" aria-current="page">
                <a class="page-link" href="#">1 <span class="visually-hidden">(current)</span></a>
            </li>
            <li class="page-item"><a class="page-link" href="#">2</a></li>
            <li class="page-item"><a class="page-link" href="#">3</a></li>
            <li class="page-item">
                <a class="page-link" href="#">Next</a>
            </li>
        </ul>
    </nav>
        </section>

        <section class="sub-head">
            <div class="container">
                <div class="">
                    <h2 class="text-center" style="margin-top: 70px"><span style="color: red">Rejected</span> Hostel List</h2>
                    <p class="description text-center">Rejected hostels by you!</p>
                </div>
                <hr />
            </div>
        </section>


        <section class="container">
            <asp:Table ID="rejectedHostelTable" runat="server" CssClass="table">

                <asp:TableHeaderRow>
                    <asp:TableHeaderCell>Hostel ID</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Title</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Description</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Price</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Beds</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Rooms</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Status</asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>
        </section>


    </form>


    <script>
        var map;
        function initMap() {
            map = new google.maps.Map(document.getElementById('map'), {
                center: { lat: 6.821305058464578, lng: 80.04157728090856 },
                zoom: 17
            });
        }

        function handleCardClick(latitude, longitude) {
            var location = new google.maps.LatLng(latitude, longitude);
            map.setCenter(location);
            var marker = new google.maps.Marker({
                position: location,
                map: map
            });
        }
    </script>
</body>
</html>
