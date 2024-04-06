using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NSBM_Hostel_Management
{
    public partial class landlogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string loginemail = txtLoginEmail.Text;
            string loginpassword = txtLoginPassword.Text;

            string connectionString = ConfigurationManager.ConnectionStrings["MsSqlConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM Landloards_UserDetails WHERE Email = @Email AND Password = @Password";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", loginemail);
                    command.Parameters.AddWithValue("@Password", loginpassword);

                    try
                    {
                        connection.Open();
                        int count = (int)command.ExecuteScalar();
                        if (count > 0)
                        {
                            // Login successful
                            Session["Email"] = loginemail; // Store user email in session
                            Response.Redirect("landload.aspx"); // Redirect to landlord dashboard
                        }
                        else
                        {
                            // Login failed
                            Response.Write("Invalid email or password. Please try again.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Response.Write("Error: " + ex.Message);
                    }
                }
            }

            // Clear textboxes after login attempt
            txtLoginEmail.Text = "";
            txtLoginPassword.Text = "";
        }


    }
}
