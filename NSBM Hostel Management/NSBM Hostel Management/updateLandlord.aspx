<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="updateLandlord.aspx.cs" Inherits="NSBM_Hostel_Management.updateLanload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet" />
<link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.4/css/all.min.css" rel="stylesheet" />
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/js/bootstrap.bundle.min.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/jQuery-slimScroll/1.3.8/jquery.slimscroll.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <!-- Bootstrap 5.3 modal -->
<div class="modal fade" id="updateHostelModal" tabindex="-1" aria-labelledby="updateHostelModalLabel" aria-hidden="true">
    <div class="modal-dialog modal-lg">
        <div class="modal-content">
            <div class="modal-header">
                <h5 class="modal-title" id="updateHostelModalLabel">Update Hostel Details</h5>
                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
            </div>
            <div class="modal-body">
                <div class="mb-3">
                    <label for="txtHostelIDModal" class="form-label">Hostel ID:</label>
                    <input type="text" id="txtHostelIDModal" class="form-control" readonly />
                </div>
                <div class="mb-3">
                    <label for="txtTitleModal" class="form-label">Title:</label>
                    <input type="text" id="txtTitleModal" class="form-control" />
                </div>
                <div class="mb-3">
                    <label for="txtDescriptionModal" class="form-label">Description:</label>
                    <textarea id="txtDescriptionModal" class="form-control" rows="3"></textarea>
                </div>
                <div class="mb-3">
                    <label for="txtPriceModal" class="form-label">Price:</label>
                    <input type="number" id="txtPriceModal" class="form-control" />
                </div>
                <div class="mb-3">
                    <label for="txtLatitudeModal" class="form-label">Latitude:</label>
                    <input type="number" id="txtLatitudeModal" class="form-control" />
                </div>
                <div class="mb-3">
                    <label for="txtLongitudeModal" class="form-label">Longitude:</label>
                    <input type="number" id="txtLongitudeModal" class="form-control" />
                </div>
                <div class="mb-3">
                    <label for="txtRoomsModal" class="form-label">Rooms:</label>
                    <input type="number" id="txtRoomsModal" class="form-control" />
                </div>
                <div class="mb-3">
                    <label for="txtBedsModal" class="form-label">Beds:</label>
                    <input type="number" id="txtBedsModal" class="form-control" />
                </div>
                <!-- Add more fields as needed -->
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                <%--<asp:Button ID="btnUpdateModal" runat="server" Text="Update" OnClick="btnUpdateHostel_Click" CssClass="btn btn-primary" />--%>
            </div>
        </div>
    </div>
</div>

    </form>
</body>
</html>
