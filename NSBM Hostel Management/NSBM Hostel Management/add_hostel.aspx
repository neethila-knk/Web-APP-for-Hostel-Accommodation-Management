<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="add_hostel.aspx.cs" Inherits="NSBM_Hostel_Management.add_hostel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
   <form id="form1" runat="server">
    <div>
        <h2>Add Hostel</h2>
        <asp:Label ID="lblUserEmail" runat="server" Text=""></asp:Label>
        <br /><br />
        Title: <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox><br />
        Description: <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox><br />
        Price: <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox><br />
         Latitude: <asp:TextBox ID="txtLatitude" runat="server"></asp:TextBox><br />
        Longitude: <asp:TextBox ID="txtLongitude" runat="server"></asp:TextBox><br />
        Image 1: <asp:FileUpload ID="fileImage1" runat="server" /><br />
        Image 2: <asp:FileUpload ID="fileImage2" runat="server" /><br />
        Image 3: <asp:FileUpload ID="fileImage3" runat="server" /><br />
        Image 4: <asp:FileUpload ID="fileImage4" runat="server" /><br />
        rooms: <asp:TextBox ID="txtRooms" runat="server"></asp:TextBox><br />
        beds: <asp:TextBox ID="txtBeds" runat="server"></asp:TextBox><br />
        <asp:Button ID="btnAddHostel" runat="server" Text="Add Hostel" OnClick="btnAddHostel_Click" />
    </div>
</form>
     <a href="landload.aspx">landload page</a> 
</body>
</html>
