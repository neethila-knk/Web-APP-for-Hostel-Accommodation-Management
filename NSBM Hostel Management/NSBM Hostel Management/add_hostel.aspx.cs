using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NSBM_Hostel_Management
{
    public partial class add_hostel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAddHostel_Click(object sender, EventArgs e)
        {
            // Check if user is logged in
            if (Session["Email"] == null)
            {
                Response.Redirect("landlogin.aspx"); // Redirect to login page if user is not logged in
                return;
            }

            string userEmail = Session["Email"].ToString(); // Get user email from session

            string title = txtTitle.Text;
            string description = txtDescription.Text;
            decimal price = Convert.ToDecimal(txtPrice.Text);
            double longitude = Convert.ToDouble(txtLongitude.Text);
            double latitude = Convert.ToDouble(txtLatitude.Text);
            string rooms = txtRooms.Text; // Changed to string
            string beds = txtBeds.Text; // Changed to string

            List<string> imageUrls = new List<string>();
            foreach (FileUpload fileUpload in new[] { fileImage1, fileImage2, fileImage3, fileImage4 })
            {
                if (fileUpload.HasFile)
                {
                    string fileName = Path.GetFileName(fileUpload.FileName);
                    string imageUrl = "~/UploadedImages/" + fileName; // Relative path
                    string imagePath = Server.MapPath(imageUrl);
                    fileUpload.SaveAs(imagePath);
                    imageUrls.Add(imageUrl);
                }
            }

            string connectionString = ConfigurationManager.ConnectionStrings["MsSqlConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO [dbo].[hostel_details_temp] ([title], [description], [price], [latitude], [longitude], [image1], [image2], [image3], [image4], [rooms], [beds], [email])
                VALUES (@Title, @Description, @Price, @Latitude, @Longitude, @Image1, @Image2, @Image3, @Image4, @Rooms, @Beds, @Email)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Title", title);
                    command.Parameters.AddWithValue("@Description", description);
                    command.Parameters.AddWithValue("@Price", price);
                    command.Parameters.AddWithValue("@Latitude", latitude);
                    command.Parameters.AddWithValue("@Longitude", longitude);
                    for (int i = 0; i < 4; i++)
                    {
                        if (i < imageUrls.Count)
                            command.Parameters.AddWithValue($"@Image{i + 1}", imageUrls[i]);
                        else
                            command.Parameters.AddWithValue($"@Image{i + 1}", DBNull.Value);
                    }
                    command.Parameters.AddWithValue("@Rooms", rooms);
                    command.Parameters.AddWithValue("@Beds", beds);
                    command.Parameters.AddWithValue("@Email", userEmail);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            Response.Write("<script>alert('Hostel Added successfully');</script>");
            txtTitle.Text = "";
            txtDescription.Text = "";
            txtPrice.Text = "";
            txtLongitude.Text = "";
            txtLatitude.Text = "";
            txtRooms.Text = "";
            txtBeds.Text = "";
        }


    }
}
