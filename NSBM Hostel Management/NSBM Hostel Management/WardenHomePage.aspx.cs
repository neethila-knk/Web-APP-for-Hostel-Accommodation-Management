using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace NSBM_Hostel_Management
{
    public partial class WardenHomePage : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["MsSqlConnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCardDetails();

                LoadApprovedHostelList();

                LoadRejectedHostelList();
            }
            else
            {
                LoadCardDetails();

                LoadApprovedHostelList();

                LoadRejectedHostelList();
            }

        }



        protected void LoadCardDetails()
        {
            // Connect to your MS SQL database and retrieve data for the card.
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM temp_hostel_details", connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        // Retrieve data from the SQL query.
                        string hostelid = reader["hostelID"].ToString();
                        string imageUrl = reader["image1"].ToString();
                        string title = reader["title"].ToString();
                        string description = reader["description"].ToString();
                        int rooms = Convert.ToInt32(reader["rooms"]);
                        int beds = Convert.ToInt32(reader["beds"]);
                        decimal price = Convert.ToDecimal(reader["price"]);

<<<<<<< Updated upstream
                        
=======

>>>>>>> Stashed changes

                        // Generate ASP.NET buttons dynamically for the card.
                        Button approveButton = new Button();
                        approveButton.ID = "btnApprove_" + hostelid; // Unique ID for each button
                        approveButton.Text = "Approve";
                        approveButton.CssClass = "btn btn-primary";
                        approveButton.Click += new EventHandler(btnApprove_Click); // Event handler

                        Button rejectButton = new Button();
                        rejectButton.ID = "btnReject_" + hostelid; // Unique ID for each button
                        rejectButton.Text = "Reject";
                        rejectButton.CssClass = "btn btn-danger";
                        rejectButton.Click += new EventHandler(btnReject_Click); // Event handler

                        // Generate HTML dynamically for the card with ASP.NET buttons.
                        HtmlGenericControl cardDiv = new HtmlGenericControl("div");
                        cardDiv.Attributes["class"] = "card hostelcard mb-3";
                        cardDiv.ID = hostelid;

                        HtmlGenericControl rowDiv = new HtmlGenericControl("div");
                        rowDiv.Attributes["class"] = "row g-0";

                        HtmlGenericControl imgDiv = new HtmlGenericControl("div");
                        imgDiv.Attributes["class"] = "col-md-4";

                        HtmlImage img = new HtmlImage();
                        img.Src = imageUrl;
                        img.Attributes["class"] = "img-fluid rounded-start hostel-img";
                        img.Alt = "";

                        imgDiv.Controls.Add(img);

                        HtmlGenericControl contentDiv = new HtmlGenericControl("div");
                        contentDiv.Attributes["class"] = "col-md-8";

                        HtmlGenericControl bodyDiv = new HtmlGenericControl("div");
                        bodyDiv.Attributes["class"] = "card-body";

                        HtmlGenericControl titleH5 = new HtmlGenericControl("h5");
                        titleH5.Attributes["class"] = "card-title";
                        titleH5.InnerText = title;

                        HtmlGenericControl descriptionP = new HtmlGenericControl("p");
                        descriptionP.Attributes["class"] = "card-text";
                        descriptionP.InnerText = description;

                        HtmlGenericControl dFlexDiv = new HtmlGenericControl("div");
                        dFlexDiv.Attributes["class"] = "d-flex d-inline-block";

                        HtmlGenericControl roomsP = new HtmlGenericControl("p");
                        roomsP.Attributes["class"] = "card-text mb-2";
                        roomsP.InnerHtml = $"<small class='text-muted'>{rooms} rooms</small>";

                        HtmlGenericControl bedsP = new HtmlGenericControl("p");
                        bedsP.Attributes["class"] = "card-text mb-2 ps-2";
                        bedsP.InnerHtml = $"<small class='text-muted'>{beds} beds</small>";

                        HtmlGenericControl priceP = new HtmlGenericControl("p");
                        priceP.Attributes["class"] = "card-text mb-2 ps-2";
                        priceP.InnerHtml = $"<small class='text-muted'> Rs.{price}/=</small>";

                        dFlexDiv.Controls.Add(roomsP);
                        dFlexDiv.Controls.Add(bedsP);
                        dFlexDiv.Controls.Add(priceP);

                        HtmlGenericControl buttonGroupDiv = new HtmlGenericControl("div");
                        buttonGroupDiv.Attributes["class"] = "btn-group";
                        buttonGroupDiv.Attributes["role"] = "group";
                        buttonGroupDiv.Attributes["aria-label"] = "Media buttons";

                        buttonGroupDiv.Controls.Add(approveButton);
                        buttonGroupDiv.Controls.Add(rejectButton);

                        bodyDiv.Controls.Add(titleH5);
                        bodyDiv.Controls.Add(descriptionP);
                        bodyDiv.Controls.Add(dFlexDiv);
                        bodyDiv.Controls.Add(buttonGroupDiv);

                        contentDiv.Controls.Add(bodyDiv);

                        rowDiv.Controls.Add(imgDiv);
                        rowDiv.Controls.Add(contentDiv);

                        cardDiv.Controls.Add(rowDiv);

                        // Add an attribute to the cardDiv to call the JavaScript function on click
<<<<<<< Updated upstream
                       
=======

>>>>>>> Stashed changes
                        cardDiv.Attributes["onclick"] = "handleCardClick('" + reader["latitude"].ToString() + "', '" + reader["longitude"].ToString() + "');";

                        // Add the dynamically generated card HTML to your card-list-scroll div.
                        cardListScroll.Controls.Add(cardDiv);
                    }
                }
                reader.Close();
            }
        }

<<<<<<< Updated upstream
 
=======

>>>>>>> Stashed changes


        protected void btnApprove_Click(object sender, EventArgs e)
        {

            Button approveButton = (Button)sender; // Get the button that triggered the event
            string hostelId = approveButton.ID.Replace("btnApprove_", ""); // Extract the hostel ID from the button ID

            // Retrieve the data of the approved hostel from the temporary table
            string query = "SELECT * FROM temp_hostel_details WHERE hostelID = @HostelID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@HostelID", hostelId);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // Insert the data into the ApprovedHostelList table
                    InsertIntoApprovedHostelList(reader);
                }
                reader.Close();
            }

            // Delete the record from the temporary table
            DeleteRecord(hostelId);

            // Remove the card from the UI
            RemoveCardFromUI(hostelId);
            LoadApprovedHostelList();
<<<<<<< Updated upstream
 
=======

>>>>>>> Stashed changes
            ClientScript.RegisterStartupScript(this.GetType(), "script", "alert('Successfully Approved');", true);

        }


        public void InsertIntoApprovedHostelList(SqlDataReader reader)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO ApprovedHostelList 
                        (hostelID, title, description, price, beds, rooms, longitude, latitude, image1, image2, image3, image4, status)
                        VALUES 
                        (@Hostelid, @Title, @Description, @Price, @Beds, @Rooms, @Longitude, @Latitude, @Image1, @Image2, @Image3, @Image4, @Status)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Hostelid", reader["hostelID"]);
                command.Parameters.AddWithValue("@Title", reader["title"]);
                command.Parameters.AddWithValue("@Description", reader["description"]);
                command.Parameters.AddWithValue("@Price", reader["price"]);
                command.Parameters.AddWithValue("@Beds", reader["beds"]);
                command.Parameters.AddWithValue("@Rooms", reader["rooms"]);
                command.Parameters.AddWithValue("@Longitude", reader["longitude"]);
                command.Parameters.AddWithValue("@Latitude", reader["latitude"]);
                command.Parameters.AddWithValue("@Image1", reader["image1"]);
                command.Parameters.AddWithValue("@Image2", reader["image2"]);
                command.Parameters.AddWithValue("@Image3", reader["image3"]);
                command.Parameters.AddWithValue("@Image4", reader["image4"]);
                command.Parameters.AddWithValue("@Status", "Approved");

                connection.Open();
                command.ExecuteNonQuery();
            }
        }


<<<<<<< Updated upstream
        protected void btnReject_Click(object sender, EventArgs e)
        {
            Button rejectButton = (Button)sender; // Get the button that triggered the event
            string hostelId = rejectButton.ID.Replace("btnReject_", ""); // Extract the hostel ID from the button ID

            // Retrieve the data of the rejected hostel from the temporary table
            string query = "SELECT * FROM hostel_details_temp WHERE hostelID = @HostelID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@HostelID", hostelId);
=======
            protected void btnReject_Click(object sender, EventArgs e)
            {
                Button rejectButton = (Button)sender; // Get the button that triggered the event
                string hostelId = rejectButton.ID.Replace("btnReject_", ""); // Extract the hostel ID from the button ID

                // Retrieve the data of the rejected hostel from the temporary table
                string query = "SELECT * FROM temp_hostel_details WHERE hostelID = @HostelID";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@HostelID", hostelId);
>>>>>>> Stashed changes

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // Insert the data into the RejectedHostelList table
                    InsertIntoRejectedHostelList(reader);
                }
                reader.Close();
            }

            // Delete the record from the temporary table
            DeleteRecord(hostelId);

            // Remove the card from the UI
            RemoveCardFromUI(hostelId);
            LoadRejectedHostelList();
            ClientScript.RegisterStartupScript(this.GetType(), "script", "alert('Successfully rejected');", true);

        }

        public void DeleteRecord(string hostelID)
        {
            // Connect to the database and execute the delete query
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM temp_hostel_details WHERE hostelID = @HostelID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@HostelID", hostelID);

                connection.Open();
                command.ExecuteNonQuery();

            }
        }

        public void RemoveCardFromUI(string hostelId)
        {
            // Find and remove the card from the card-list-scroll div
            Control cardToRemove = cardListScroll.FindControl(hostelId);
            if (cardToRemove != null)
            {
                cardListScroll.Controls.Remove(cardToRemove);
            }
        }


        protected void LoadApprovedHostelList()
        {
            string query = "SELECT hostelID, title, description, price, beds, rooms, status FROM ApprovedHostelList";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    // Create a new row
                    System.Web.UI.WebControls.TableRow row = new System.Web.UI.WebControls.TableRow();

                    // Populate the row with data
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        TableCell cell = new TableCell();
                        cell.Text = reader[i].ToString();
                        row.Cells.Add(cell);
                    }

                    // Add the row to the table
                    approvedHostelTable.Rows.Add(row);
                }

                reader.Close();
            }
        }

        protected void LoadRejectedHostelList()
        {
            string query = "SELECT hostelID, title, description, price, beds, rooms, status FROM RejectedHostelList";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    // Create a new row
                    System.Web.UI.WebControls.TableRow row = new System.Web.UI.WebControls.TableRow();

                    // Populate the row with data
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        TableCell cell = new TableCell();
                        cell.Text = reader[i].ToString();
                        row.Cells.Add(cell);
                    }

                    // Add the row to the table
                    rejectedHostelTable.Rows.Add(row);
                }

                reader.Close();
            }
        }


        public void InsertIntoRejectedHostelList(SqlDataReader reader)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO RejectedHostelList 
                (hostelID, title, description, price, beds, rooms, longitude, latitude, image1, image2, image3, image4, status)
                VALUES 
                (@Hostelid, @Title, @Description, @Price, @Beds, @Rooms, @Longitude, @Latitude, @Image1, @Image2, @Image3, @Image4, @Status)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Hostelid", reader["hostelID"]);
                command.Parameters.AddWithValue("@Title", reader["title"]);
                command.Parameters.AddWithValue("@Description", reader["description"]);
                command.Parameters.AddWithValue("@Price", reader["price"]);
                command.Parameters.AddWithValue("@Beds", reader["beds"]);
                command.Parameters.AddWithValue("@Rooms", reader["rooms"]);
                command.Parameters.AddWithValue("@Longitude", reader["longitude"]);
                command.Parameters.AddWithValue("@Latitude", reader["latitude"]);
                command.Parameters.AddWithValue("@Image1", reader["image1"]);
                command.Parameters.AddWithValue("@Image2", reader["image2"]);
                command.Parameters.AddWithValue("@Image3", reader["image3"]);
                command.Parameters.AddWithValue("@Image4", reader["image4"]);
                command.Parameters.AddWithValue("@Status", "Rejected");

                connection.Open();
                command.ExecuteNonQuery();
            }
        }


    }
}