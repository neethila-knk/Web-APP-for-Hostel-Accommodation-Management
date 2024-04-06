using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI.WebControls;


namespace test1
{
    public partial class newmap : System.Web.UI.Page
    {
      

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // No need to set the Hostel ID here during initial page load
            }
            else
            {
                
            }

        }




        protected void btnsend_Click(object sender, EventArgs e)
        {
            if (checkValidation())
            {
                // Other user details
                string firstName = txtFirstName.Text;
                string lastName = txtLastName.Text;
                string email = txtEmail.Text;
                string phonenum = txtphone.Text;
                string hostelName = hiddenHostelName.Value;
                string txtarea = txtArea.Text;
               

            
                    try
                    {


                        // Get the Hostel ID
                        int hostelId;
                        if (int.TryParse(hiddenHostelId.Value, out hostelId))
                        {
                            // Insert user data into the database
                            if (InsertUserData(firstName, lastName, email, hostelId, phonenum, hostelName, txtarea))
                            {
                                // Display success message
                                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Data has been successfully sent. Hostel ID: " + hostelId + "');", true);
                                SendEmail(firstName, lastName, email, txtarea);
                                ResetForm();
                            }
                            else
                            {
                                // Display error message
                                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Failed to send data. Please try again. Hostel ID: " + hostelId + "');", true);
                            }
                        }
                        else
                        {
                            // Handle case where hiddenHostelId.Value is empty or not a valid integer
                            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Invalid or empty Hostel ID. Hostel ID: " + hostelId + "');", true);
                        }
                    }
                    catch(Exception ex)
                    {
                        // Handle image upload error
                        ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Error uploading image: " + ex.Message + "');", true);
                    }
                
               
            }
        }



        private bool checkValidation()
        {
            // Check if all fields are filled
            if (string.IsNullOrEmpty(txtFirstName.Text) ||
               string.IsNullOrEmpty(txtLastName.Text) ||
               string.IsNullOrEmpty(txtEmail.Text) ||
                string.IsNullOrEmpty(txtphone.Text) || string.IsNullOrEmpty(txtArea.Text))
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Please fill in all the fields.');", true);
                return false;
            }

            // Check if email is in a valid format
            if (!IsValidEmail(txtEmail.Text))
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Please enter a valid email address.');", true);
                return false;
            }
            string phonenum = txtphone.Text;
            if (phonenum.Length != 10 || !IsNumeric(phonenum))
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Please enter a valid 10-digit phone number.');", true);
                return false;
            }


            return true;


        }

        private bool IsNumeric(string value)
        {
            // Check if the string is numeric
            return int.TryParse(value, out _);
        }

        private bool IsValidEmail(string email)
        {
            // Regular expression pattern for email validation
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, pattern);
        }







        private bool InsertUserData(string firstName, string lastName, string email, int hostelId,string phonenum,string hostelname,string txtarea)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MsSqlConnection"].ConnectionString;
            string message = ""; // Initialize an empty message

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO user_table (firstname, lastname, email, cid,phone,cname,details) VALUES (@FirstName, @LastName, @Email, @HostelID,@phone,@cname,@txtarea)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@FirstName", firstName);
                        command.Parameters.AddWithValue("@LastName", lastName);
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@HostelID", hostelId);
                        command.Parameters.AddWithValue("@phone", phonenum);
                        command.Parameters.AddWithValue("@cname", hostelname);
                        command.Parameters.AddWithValue("@txtarea", txtarea);
                      

                        connection.Open();
                        command.ExecuteNonQuery();

                        
                        message = "User registered successfully!";
                    }
                }
                return true; 
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

                
                message = "An error occurred while processing your request. Please try again later.";
                return false; 
            }

            
        }

        private void ResetForm()
        {
        
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtEmail.Text = "";
            txtphone.Text = "";
            txtArea.Text = "";
        }



        private bool SendEmail(string firstName, string lastName, string email,string txtarea)
        {
            try
            {
                string smtpHost = "smtp.gmail.com";
                int smtpPort = 587;
                string smtpUsername = "sirionhub3@gmail.com"; 
                string smtpPassword = "zjzu xbac xgvc hrkw"; 

                string receiverEmail = "sirionhub3@gmail.com";

                MailAddress fromAddress = new MailAddress(email);
                MailAddress toAddress = new MailAddress(receiverEmail);

                MailMessage message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = "Registration Confirmation",
                    Body = "Dear " + firstName + " " + lastName + ",\n\nThank you for registering.\n"+"Email Address: "+email+"\n More Details: "+txtarea,
                    IsBodyHtml = false
                };

                SmtpClient smtpClient = new SmtpClient(smtpHost, smtpPort)
                {
                    Credentials = new NetworkCredential(smtpUsername, smtpPassword),
                    EnableSsl = true
                };

                smtpClient.Send(message);

                Console.Write("Email sent successfully!");
                return true;
            }
            catch (Exception ex)
            {
              
                Console.Write("Error sending email: " + ex.Message);
                return false;
            }
        }

        public static List<Hostel> fetchHostelData()
        {
          
            List<Hostel> hostels = new List<Hostel>();

            string connectionString = ConfigurationManager.ConnectionStrings["MsSqlConnection"].ConnectionString;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT id, name, description, rooms, price, longitude, latitude,imageUrl FROM place";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        conn.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Hostel hostel = new Hostel();
                                hostel.CID = Convert.ToInt32(reader["id"]);
                                hostel.Name = reader["name"].ToString();
                                hostel.Description = reader["description"].ToString();
                                hostel.Rooms = Convert.ToInt32(reader["rooms"]);
                                hostel.Price = Convert.ToDecimal(reader["price"]);
                                hostel.Longitude = Convert.ToDouble(reader["longitude"]);
                                hostel.Latitude = Convert.ToDouble(reader["latitude"]);
                                hostel.ImageUrl = reader["imageUrl"].ToString();

                                hostels.Add(hostel);
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            

            return hostels;
        }
    }

    

    public class Hostel
    {
        public int CID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Rooms { get; set; }
        public decimal Price { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string ImageUrl { get; set; }
    }
}
