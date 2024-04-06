<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="updateLanload.aspx.cs" Inherits="NSBM_Hostel_Management.updateLanload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Update Hostel Details</h2>
            <div>
                <asp:Label ID="lblHostelID" runat="server" Text="Hostel ID:"></asp:Label>
                <asp:TextBox ID="txtHostelID" runat="server" ReadOnly="true"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="lblTitle" runat="server" Text="Title:"></asp:Label>
                <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="lblDescription" runat="server" Text="Description:"></asp:Label>
                <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="lblPrice" runat="server" Text="Price:"></asp:Label>
                <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
            </div>
             <div>
     <asp:Label ID="lblLatitude" runat="server" Text="Latitude:"></asp:Label>
     <asp:TextBox ID="txtLatitude" runat="server"></asp:TextBox>
 </div>
             <div>
     <asp:Label ID="lblLongitude" runat="server" Text="Longitude:"></asp:Label>
     <asp:TextBox ID="txtLongitude" runat="server"></asp:TextBox>
 </div>
             <div>
     <asp:Label ID="lblRooms" runat="server" Text="Rooms:"></asp:Label>
     <asp:TextBox ID="txtRooms" runat="server"></asp:TextBox>
 </div>
             <div>
     <asp:Label ID="lblBeds" runat="server" Text="Beds:"></asp:Label>
     <asp:TextBox ID="txtBeds" runat="server"></asp:TextBox>
 </div>

            <div>
                <asp:Label ID="lblImage1" runat="server" Text="Image 1:"></asp:Label>
                <asp:FileUpload ID="fuImage1" runat="server" />
            </div>
            <div>
                <asp:Label ID="lblImage2" runat="server" Text="Image 2:"></asp:Label>
                <asp:FileUpload ID="fuImage2" runat="server" />
            </div>
            <div>
                <asp:Label ID="lblImage3" runat="server" Text="Image 3:"></asp:Label>
                <asp:FileUpload ID="fuImage3" runat="server" />
            </div>
            <div>
                <asp:Label ID="lblImage4" runat="server" Text="Image 4:"></asp:Label>
                <asp:FileUpload ID="fuImage4" runat="server" />
            </div>
            <!-- Add more fields as needed -->

            <div>
                <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
            </div>
        </div>
    </form>
</body>
</html>
