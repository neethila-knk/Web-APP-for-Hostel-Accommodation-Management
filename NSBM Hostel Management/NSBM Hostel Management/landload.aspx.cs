using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NSBM_Hostel_Management
{
    public partial class landload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Email"] != null)
                {
                    string userEmail = Session["Email"].ToString();
                    lblUserEmail.Text = "Welcome, " + userEmail;

                    // Call the method to load hostel data
                    LoadHostelData();
                }
                else
                {
                    Response.Redirect("landlogin.aspx");
                }
            }
        }

        // Method to load hostel data from the database
        protected void LoadHostelData()
        {
            // Connection string to your database
            string connectionString = ConfigurationManager.ConnectionStrings["MsSqlConnection"].ConnectionString;

            // SQL query to retrieve hostel data
            string query = "SELECT * FROM temp_hostel_details";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
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
                    cardHeader.CssClass = "card-header";

                    // Add update and delete buttons
                    Button btnUpdate = new Button();
                    btnUpdate.ID = "btnUpdate" + reader["hostelID"].ToString();
                    btnUpdate.Text = "Update";
                    btnUpdate.CssClass = "btn btn-primary mr-4";
                    btnUpdate.Click += btnlandUpdate_Click; // Attach event handler
                    cardHeader.Controls.Add(btnUpdate);

                    Button btnDelete = new Button();
                    btnDelete.ID = "btnDelete" + reader["hostelID"].ToString();
                    btnDelete.Text = "Delete";
                    btnDelete.CssClass = "btn btn-danger";
                    btnDelete.Click += btnDelete_Click;
                    cardHeader.Controls.Add(btnDelete);

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
                    priceLabel.Text = "Price: $" + reader["price"].ToString();
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

        protected void btnlandUpdate_Click(object sender, EventArgs e)
        {
            // Redirect to the updateLandload.aspx page
            Response.Redirect("updateLandload.aspx");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            // Handle delete button click event
        }

        protected void btnAddHostel_Click(object sender, EventArgs e)
        {
            // Redirect to add_hostel.aspx when the Add Hostel button is clicked
            Response.Redirect("add_hostel.aspx");
        }
    }
}
