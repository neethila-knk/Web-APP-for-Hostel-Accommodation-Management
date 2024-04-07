<<<<<<< Updated upstream
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
=======
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Net;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.SessionState;

>>>>>>> Stashed changes

namespace NSBM_Hostel_Management
{
    public partial class index : System.Web.UI.Page
    {
<<<<<<< Updated upstream
        protected void Page_Load(object sender, EventArgs e)
        {

        }
=======
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

>>>>>>> Stashed changes
    }
}