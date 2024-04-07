
using System.Data.SqlClient;
using System.Net;
using System.Text.RegularExpressions;

using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.UI;


using System.Configuration;
using System.Data.SqlClient;
using System.Net;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.SessionState;



namespace NSBM_Hostel_Management
{
    public partial class index : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)

        protected void btnslogin_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Student Login Button Pressed");
            if (ValidateInputs(semail.Text, spassword.Text))
            {
                AuthenticateUser(semail.Text, spassword.Text, "Students_UserDetails");
            }
        }

        protected void llloginbtn_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Landlord Login Button Pressed");
            if (ValidateInputs(llemail.Text, llpassword.Text))
            {
                AuthenticateUser(llemail.Text, llpassword.Text, "Landlords_UserDetails");
            }
        }

        protected void wloginbtn_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Warden Login Button Pressed");
            if (ValidateInputs(wemail.Text, wpassword.Text))
            {
                AuthenticateUser(wemail.Text, wpassword.Text, "Warden_UserDetails");
            }
        }

        protected void webmlogin_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Webmaster Login Button Pressed");
            if (ValidateInputs(wmemail.Text, wmpassword.Text))
            {
                AuthenticateUser(wmemail.Text, wmpassword.Text, "Webmaster_UserDetails");
            }
        }

        protected void llregisterbtn_Click(object sender, EventArgs e)
        {

            RegisterLandlord();
            //if (ValidateRegistrationInputs())
           // {
                
           // }

        }

        private bool ValidateInputs(string email, string password)
        {
            // Add validation checks for email and password
            if (string.IsNullOrEmpty(email))
            {
                Response.Write("<script>alert('Please enter email');</script>");
                return false;
            }

            // Check email format using regular expression
            if (!IsValidEmail(email))
            {
                Response.Write("<script>alert('Please enter a valid email address');</script>");
                return false;
            }

            if (string.IsNullOrEmpty(password))
            {
                Response.Write("<script>alert('Please enter password');</script>");
                return false;
            }

            // Additional validation checks if needed

            return true;
        }

        private bool ValidateRegistrationInputs()
        {
            // Add validation checks for registration inputs
            if (string.IsNullOrEmpty(llfirstName.Text) || string.IsNullOrEmpty(lllastName.Text) ||
                string.IsNullOrEmpty(llemail2.Text) || string.IsNullOrEmpty(llpassword2.Text) ||
                string.IsNullOrEmpty(llNIC.Text) || string.IsNullOrEmpty(llAddress.Text))
            {
                Response.Write("<script>alert('Please fill in all fields');</script>");
                return false;
            }

            // Check email format using regular expression
            if (!IsValidEmail(llemail2.Text))
            {
                Response.Write("<script>alert('Please enter a valid email address');</script>");
                return false;
            }

            // Additional validation checks if needed

            return true;
        }

        private bool IsValidEmail(string email)
        {
            // Regular expression for email format validation
            string emailPattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";
            return Regex.IsMatch(email, emailPattern);
        }

        private void AuthenticateUser(string email, string password, string tableName)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MsSqlConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = $"SELECT COUNT(*) FROM {tableName} WHERE Email = @Email AND Password = @Password";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Password", password);

                    try
                    {
                        connection.Open();
                        int count = (int)command.ExecuteScalar();

                        if (count > 0)
                        {
                            Response.Write("<script>alert('Login Successful');</script>");
                            // Redirect the user to a new page or perform further actions
                        }
                        else
                        {
                            Response.Write("<script>alert('Invalid username or password');</script>");
                        }
                    }
                    catch (Exception ex)
                    {
                        Response.Write("Error: " + ex.Message);
                    }
                }
            }
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

        protected void btnslogin_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Student Login Button Pressed");
            AuthenticateUser(semail.Text, spassword.Text, "Students_UserDetails");
            Response.Redirect("newmap.aspx");
        }

        protected void llloginbtn_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Landlord Login Button Pressed");
            AuthenticateUser(llemail.Text, llpassword.Text, "Landlords_UserDetails");
            Response.Redirect("landload.aspx");
        }

        protected void wloginbtn_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Warden Login Button Pressed");
            AuthenticateUser(wemail.Text, wpassword.Text, "Warden_UserDetails");
            Response.Redirect("WardenHomePage.aspx");
        }

        protected void webmlogin_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Webmaster Login Button Pressed");
            AuthenticateUser(wmemail.Text, wmpassword.Text, "Webmaster_UserDetails");
            Response.Redirect("WebMaster.aspx");
        }

        protected void llregisterbtn_Click(object sender, EventArgs e)
        {

            

        }


        private void AuthenticateUser(string email, string password, string tableName)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MsSqlConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = $"SELECT COUNT(*) FROM {tableName} WHERE Email = @Email AND Password = @Password";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Password", password);

                    try
                    {
                        connection.Open();
                        int count = (int)command.ExecuteScalar();

                        if (count > 0)
                        {
                            // Store email in session
                            Session["Email"] = email;
                        }
                        else
                        {
                            Response.Write("<script>alert('Invalid username or password');</script>");
                        }
                    }
                    catch (Exception ex)
                    {
                        Response.Write("Error: " + ex.Message);
                    }
                }
            }
        }
    }
}
