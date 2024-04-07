using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NSBM_Hostel_Management
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnWardenLogin_Click(object sender, EventArgs e)
        {
            // Check if the login form was submitted
            if (Request.HttpMethod == "POST")
            {
                string email = Request.Form["Wardemail"];
                string password = Request.Form["Wardpassword"];

                // Connect to the database and validate user credentials
                string connectionString = ConfigurationManager.ConnectionStrings["MsSqlConnection"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT WID, FirstName FROM Wardens_UserDetails WHERE Email = @Email AND Password = @Password";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@Password", password);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Authentication successful
                                int wardenId = reader.GetInt32(0);
                                string firstName = reader.GetString(1);

                                // Create a session for the authenticated user
                                string sessionId = Guid.NewGuid().ToString();
                                Session["WardenId"] = wardenId;
                                Session["FirstName"] = firstName;
                                Session["SessionId"] = sessionId;

                                // Redirect to a dashboard page or wherever you want
                                Response.Redirect("WardenHomePage.aspx");
                            }

                            else
                            {
                                // Authentication failed
                                Response.Write("<script>alert('Invalid email or password. Please try again.');</script>");
                            }
                        }
                    }
                }
            }
        }
    }
}