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
    public partial class LandSignup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string firstname = txtFirstName.Text;
            string lastname = txtLastName.Text;
            string email = txtEmail.Text;
            string password = txtPassword.Text;

            string connectionString = ConfigurationManager.ConnectionStrings["MsSqlConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Landloards_UserDetails (FirstName, LastName, Email, Password) VALUES (@FirstName, @LastName, @Email, @Password)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FirstName", firstname);
                    command.Parameters.AddWithValue("@LastName", lastname);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Password", password);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        Response.Write("User registered successfully!");
                    }
                    catch (Exception ex)
                    {
                        Response.Write("Error: " + ex.Message);
                    }
                }
            }
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtEmail.Text = "";
            txtPassword.Text = "";

        }
    }
}