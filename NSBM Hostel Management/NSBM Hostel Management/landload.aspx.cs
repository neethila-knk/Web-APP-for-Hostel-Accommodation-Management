using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NSBM_Hostel_Management
{
    public partial class landload : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["MsSqlConnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Email"] != null)
                {
                    string userEmail = Session["Email"].ToString();
                    lblUserEmail.Text = "Welcome, " + userEmail;

                    // Call the method to load hostel data for the logged-in user
                    LoadHostelData(userEmail);
                    LoadApprovedHostelData(userEmail);
                }
                else
                {
                    Response.Redirect("landlogin.aspx");

                }
            }
            else
            {
                if (Session["Email"] != null)
                {
                    string userEmail = Session["Email"].ToString();
                    lblUserEmail.Text = "Welcome, " + userEmail;

                    // Call the method to load hostel data for the logged-in user
                    LoadHostelData(userEmail);
                    LoadApprovedHostelData(userEmail);
                }
                else
                {
                    Response.Redirect("landlogin.aspx");

                }
            }

        }

        // Method to load hostel data from the database for the logged-in user
        protected void LoadHostelData(string userEmail)
        {
            // Connection string to your database
            string connectionString = ConfigurationManager.ConnectionStrings["MsSqlConnection"].ConnectionString;

            // SQL query to retrieve hostel data for the logged-in user
            string query = "SELECT * FROM hostel_details_temp WHERE email = @UserEmail";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserEmail", userEmail);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                // Loop through the result set and create product cards dynamically
                while (reader.Read())
                {
                    // Create a new card section
                    LiteralControl sectionStart = new LiteralControl("<section>");
                    PlaceHolder.Controls.Add(sectionStart);

                    // Create a new card div
                    Panel card = new Panel();
                    card.CssClass = "card text-center mb-4"; // Added margin bottom class


                    // Create card header
                    Panel cardHeader = new Panel();
                    cardHeader.CssClass = "card-header d-flex justify-content-between align-items-center";

                    // Add hostel ID to the left
                    Label hostelIdLabel = new Label();
                    hostelIdLabel.Text = "Hostel ID: " + reader["hostelID"].ToString();
                    cardHeader.Controls.Add(hostelIdLabel);

                    // Create a container for the buttons on the right
                    Panel buttonContainer = new Panel();
                    buttonContainer.CssClass = "d-flex";

                    // Add update button
                    Button btnUpdate = new Button();
                    btnUpdate.ID = "btnUpdate" + reader["hostelID"].ToString();
                    btnUpdate.Text = "Update";
                    btnUpdate.CssClass = "btn btn-primary me-2";
                    btnUpdate.Click += btnlandUpdate_Click; // Attach event handler
                    buttonContainer.Controls.Add(btnUpdate);

                    // Add delete button
                    Button btnDelete = new Button();
                    btnDelete.ID = "btnDelete" + reader["hostelID"].ToString();
                    btnDelete.Text = "Delete";
                    btnDelete.CssClass = "btn btn-danger";
                    btnDelete.Click += btnDelete_Click;
                    buttonContainer.Controls.Add(btnDelete);

                    // Add the button container to the card header
                    cardHeader.Controls.Add(buttonContainer);

                    card.Controls.Add(cardHeader);

                    // Create card body
                    Panel cardBody = new Panel();
                    cardBody.CssClass = "card-body";

                    // Add room information
                    LiteralControl roomInfoStart = new LiteralControl("<div class=\"row\">");
                    cardBody.Controls.Add(roomInfoStart);

                    LiteralControl roomInfoSectionStart = new LiteralControl("<div class=\"col\">");
                    cardBody.Controls.Add(roomInfoSectionStart);

                    LiteralControl roomInfoContentStart = new LiteralControl("<div class=\"section-content\">");
                    cardBody.Controls.Add(roomInfoContentStart);

                    // Set card title from database
                    LiteralControl titleLabel = new LiteralControl("<h5 class=\"card-title\">" + reader["title"].ToString() + "</h5>");
                    cardBody.Controls.Add(titleLabel);

                    LiteralControl roomInfoTextStart = new LiteralControl("<p class=\"card-text\">");
                    cardBody.Controls.Add(roomInfoTextStart);

                    Label numRoomsLabel = new Label();
                    numRoomsLabel.Text = "Number of rooms: " + reader["rooms"].ToString() + "<br />";
                    cardBody.Controls.Add(numRoomsLabel);

                    Label numBedsLabel = new Label();
                    numBedsLabel.Text = "Number of beds: " + reader["beds"].ToString() + "<br />";
                    cardBody.Controls.Add(numBedsLabel);

                    Label descriptionLabel = new Label();
                    descriptionLabel.Text = "Description: " + reader["description"].ToString() + "<br />";
                    cardBody.Controls.Add(descriptionLabel);

                    Label priceLabel = new Label();
                    priceLabel.Text = "Monthly Charge: Rs." + reader["price"].ToString();
                    cardBody.Controls.Add(priceLabel);

                    LiteralControl roomInfoTextEnd = new LiteralControl("</p>");
                    cardBody.Controls.Add(roomInfoTextEnd);

                    LiteralControl roomInfoContentEnd = new LiteralControl("</div>");
                    cardBody.Controls.Add(roomInfoContentEnd);

                    LiteralControl roomInfoSectionEnd = new LiteralControl("</div>");
                    cardBody.Controls.Add(roomInfoSectionEnd);

                    // Add images
                    for (int i = 1; i <= 4; i++)
                    {
                        if (!string.IsNullOrEmpty(reader["image" + i.ToString()].ToString()))
                        {
                            LiteralControl imageSection = new LiteralControl("<div class=\"col\">");
                            cardBody.Controls.Add(imageSection);

                            LiteralControl imageContent = new LiteralControl("<div class=\"section-content\">");
                            cardBody.Controls.Add(imageContent);

                            Image image = new Image();
                            image.ImageUrl = reader["image" + i.ToString()].ToString();
                            image.CssClass = "img-fluid";
                            cardBody.Controls.Add(image);

                            LiteralControl imageContentEnd = new LiteralControl("</div>");
                            cardBody.Controls.Add(imageContentEnd);

                            LiteralControl imageSectionEnd = new LiteralControl("</div>");
                            cardBody.Controls.Add(imageSectionEnd);
                        }
                    }

                    LiteralControl roomInfoEnd = new LiteralControl("</div>"); // Close room information row
                    cardBody.Controls.Add(roomInfoEnd);

                    card.Controls.Add(cardBody);

                    PlaceHolder.Controls.Add(card);

                    // Close card section
                    LiteralControl sectionEnd = new LiteralControl("</section>");
                    PlaceHolder.Controls.Add(sectionEnd);
                }
                reader.Close();
            }
        }


        protected void LoadApprovedHostelData(string userEmail)
        {
            // Connection string to your database
            string connectionString = ConfigurationManager.ConnectionStrings["MsSqlConnection"].ConnectionString;

            // SQL query to retrieve hostel data for the logged-in user
            string query = "SELECT * FROM ApprovedHostelList WHERE email = @UserEmail";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserEmail", userEmail);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                // Loop through the result set and create product cards dynamically
                while (reader.Read())
                {
                    // Create a new card section
                    LiteralControl sectionStart = new LiteralControl("<section>");
                    PlaceHolder1.Controls.Add(sectionStart);

                    // Create a new card div
                    Panel card = new Panel();
                    card.CssClass = "card text-center mb-4"; // Added margin bottom class


                    // Create card header
                    Panel cardHeader = new Panel();
                    cardHeader.CssClass = "card-header d-flex justify-content-between align-items-center";

                    // Add hostel ID to the left
                    Label hostelIdLabel = new Label();
                    hostelIdLabel.Text = "Hostel ID: " + reader["hostelID"].ToString();
                    cardHeader.Controls.Add(hostelIdLabel);


                    card.Controls.Add(cardHeader);

                    // Create card body
                    Panel cardBody = new Panel();
                    cardBody.CssClass = "card-body";

                    // Add room information
                    LiteralControl roomInfoStart = new LiteralControl("<div class=\"row\">");
                    cardBody.Controls.Add(roomInfoStart);

                    LiteralControl roomInfoSectionStart = new LiteralControl("<div class=\"col\">");
                    cardBody.Controls.Add(roomInfoSectionStart);

                    LiteralControl roomInfoContentStart = new LiteralControl("<div class=\"section-content\">");
                    cardBody.Controls.Add(roomInfoContentStart);

                    // Set card title from database
                    LiteralControl titleLabel = new LiteralControl("<h5 class=\"card-title\">" + reader["title"].ToString() + "</h5>");
                    cardBody.Controls.Add(titleLabel);

                    LiteralControl roomInfoTextStart = new LiteralControl("<p class=\"card-text\">");
                    cardBody.Controls.Add(roomInfoTextStart);

                    Label numRoomsLabel = new Label();
                    numRoomsLabel.Text = "Number of rooms: " + reader["rooms"].ToString() + "<br />";
                    cardBody.Controls.Add(numRoomsLabel);

                    Label numBedsLabel = new Label();
                    numBedsLabel.Text = "Number of beds: " + reader["beds"].ToString() + "<br />";
                    cardBody.Controls.Add(numBedsLabel);

                    Label descriptionLabel = new Label();
                    descriptionLabel.Text = "Description: " + reader["description"].ToString() + "<br />";
                    cardBody.Controls.Add(descriptionLabel);

                    Label priceLabel = new Label();
                    priceLabel.Text = "Monthly Charge: Rs." + reader["price"].ToString();
                    cardBody.Controls.Add(priceLabel);

                    LiteralControl roomInfoTextEnd = new LiteralControl("</p>");
                    cardBody.Controls.Add(roomInfoTextEnd);

                    LiteralControl roomInfoContentEnd = new LiteralControl("</div>");
                    cardBody.Controls.Add(roomInfoContentEnd);

                    LiteralControl roomInfoSectionEnd = new LiteralControl("</div>");
                    cardBody.Controls.Add(roomInfoSectionEnd);

                    // Add images
                    for (int i = 1; i <= 4; i++)
                    {
                        if (!string.IsNullOrEmpty(reader["image" + i.ToString()].ToString()))
                        {
                            LiteralControl imageSection = new LiteralControl("<div class=\"col\">");
                            cardBody.Controls.Add(imageSection);

                            LiteralControl imageContent = new LiteralControl("<div class=\"section-content\">");
                            cardBody.Controls.Add(imageContent);

                            Image image = new Image();
                            image.ImageUrl = reader["image" + i.ToString()].ToString();
                            image.CssClass = "img-fluid";
                            cardBody.Controls.Add(image);

                            LiteralControl imageContentEnd = new LiteralControl("</div>");
                            cardBody.Controls.Add(imageContentEnd);

                            LiteralControl imageSectionEnd = new LiteralControl("</div>");
                            cardBody.Controls.Add(imageSectionEnd);
                        }
                    }

                    LiteralControl roomInfoEnd = new LiteralControl("</div>"); // Close room information row
                    cardBody.Controls.Add(roomInfoEnd);

                    card.Controls.Add(cardBody);

                    PlaceHolder1.Controls.Add(card);

                    // Close card section
                    LiteralControl sectionEnd = new LiteralControl("</section>");
                    PlaceHolder1.Controls.Add(sectionEnd);
                }

                reader.Close();

            }
        }


        protected void btnlandUpdate_Click(object sender, EventArgs e)
        {
            // Register the script to open the modal using ClientScriptManager
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                Button deleteButton = (Button)sender; // Get the button that triggered the event
                string hostelId = deleteButton.ID.Replace("btnDelete", ""); // Extract the hostel ID from the button ID

                // Delete the record from the database
                DeleteHostel(hostelId);

                // Remove the card from the UI
                RemoveHostelCardFromUI(hostelId);

                // Display success message
                ClientScript.RegisterStartupScript(this.GetType(), "script", "alert('Hostel deleted successfully');", true);
            }

            catch (Exception ex)
            {
                // Handle any exceptions that occur during the deletion process
                ClientScript.RegisterStartupScript(this.GetType(), "script", $"alert('An error occurred: {ex.Message}');", true);
            }

            finally
            {
                Response.Redirect(Request.Url.AbsoluteUri);
            }
        }

        public void DeleteHostel(string hostelID)
        {
            // Connect to the database and execute the delete query
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM hostel_details_temp WHERE hostelID = @HostelID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@HostelID", hostelID);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void RemoveHostelCardFromUI(string hostelId)
        {
            // Find and remove the card from the PlaceHolder control
            Control cardToRemove = PlaceHolder.FindControl("section_" + hostelId);
            if (cardToRemove != null)
            {
                PlaceHolder.Controls.Remove(cardToRemove);
            }
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

            Response.Redirect(Request.Url.AbsoluteUri);
        }


        protected void btnUpdateHostel_Click(object sender, EventArgs e)
        {
            // Retrieve values from the modal form
            string hostelId = txtHostelIDModal.Text;
            string title = txtTitleModal.Text;
            string description = txtDescriptionModal.Text;
            decimal price = Convert.ToDecimal(txtPriceModal.Text);
            double latitude = Convert.ToDouble(txtLatitudeModal.Text);
            double longitude = Convert.ToDouble(txtLongitudeModal.Text);
            string rooms = txtRoomsModal.Text;
            string beds = txtBedsModal.Text;

            // Retrieve updated image URLs
            List<string> updatedImageUrls = new List<string>();
            foreach (FileUpload fileUpload in new[] { FileUpload1, FileUpload2, FileUpload3, FileUpload4 })
            {
                if (fileUpload.HasFile)
                {
                    string fileName = Path.GetFileName(fileUpload.FileName);
                    string imageUrl = "~/UploadedImages/" + fileName; // Relative path
                    string imagePath = Server.MapPath(imageUrl);
                    fileUpload.SaveAs(imagePath);
                    updatedImageUrls.Add(imageUrl);
                }
            }

            // Update the record in the database
            UpdateHostel(hostelId, title, description, price, latitude, longitude, rooms, beds, updatedImageUrls);

            // Display success message
            ClientScript.RegisterStartupScript(this.GetType(), "script", "alert('Hostel updated successfully');", true);

            txtHostelIDModal.Text = "";
            txtTitleModal.Text = "";
            txtDescriptionModal.Text = "";
            txtPriceModal.Text = "";
            txtLatitudeModal.Text = "";
            txtLongitudeModal.Text = "";
            txtRoomsModal.Text = "";
            txtBedsModal.Text = "";

            Response.Redirect(Request.Url.AbsoluteUri);
        }


        public void UpdateHostel(string hostelId, string title, string description, decimal price, double latitude, double longitude, string rooms, string beds, List<string> imageUrls)
        {
            // Connect to the database and execute the update query
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"UPDATE hostel_details_temp 
                         SET title = @Title, description = @Description, price = @Price, latitude = @Latitude, longitude = @Longitude, 
                             rooms = @Rooms, beds = @Beds, image1 = @Image1, image2 = @Image2, image3 = @Image3, image4 = @Image4
                         WHERE hostelID = @HostelID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@HostelID", hostelId);
                    command.Parameters.AddWithValue("@Title", title);
                    command.Parameters.AddWithValue("@Description", description);
                    command.Parameters.AddWithValue("@Price", price);
                    command.Parameters.AddWithValue("@Latitude", latitude);
                    command.Parameters.AddWithValue("@Longitude", longitude);
                    command.Parameters.AddWithValue("@Rooms", rooms);
                    command.Parameters.AddWithValue("@Beds", beds);

                    // Add image parameters
                    for (int i = 0; i < 4; i++)
                    {
                        if (i < imageUrls.Count)
                            command.Parameters.AddWithValue($"@Image{i + 1}", imageUrls[i]);
                        else
                            command.Parameters.AddWithValue($"@Image{i + 1}", DBNull.Value);
                    }

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

    }
}
