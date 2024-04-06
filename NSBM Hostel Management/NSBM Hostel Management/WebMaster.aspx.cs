using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace NSBM_Hostel_Management
{
    public partial class WebMaster : System.Web.UI.Page
    {

        protected void submitButton_Clickk(object sender, EventArgs e)
        {
            // Retrieve the values entered by the user
            string title = this.title.Text;
            string author = this.author.Text;
            string content = this.content.Text;
            // Create a string representing the new post container
            string newPostContainer = $@"
        <div class='post-container'>
            <div class='post'>
                <h2>Title:{title}</h2>
                <p><strong>Author:</strong> {author}</p>
                <p>Content:{content}</p>
            </div>
        </div>";

            // Append the new post container to the existing content
            this.postsContainer.InnerHtml += newPostContainer;

            // Clear the form fields for the next post
            this.title.Text = "";
            this.author.Text = "";
            this.content.Text = "";
        }

        protected void registrationType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = registrationType.Text;
            DropDownList registrationTypeDropdown = (DropDownList)sender;


            landlordForm.Style["display"] = selectedValue == "landlord" ? "block" : "none";
            wardenForm.Style["display"] = selectedValue == "warden" ? "block" : "none";
            studentForm.Style["display"] = selectedValue == "student" ? "block" : "none";
            articleForum.Style["display"] = selectedValue == "article" ? "block" : "none";
        }


        protected void btnRegister_Clickk(object sender, EventArgs e)
        {


            // landlord
            string firstname1 = txtFirstNameWM.Text;
            string lastname1 = txtLastNameWM.Text;
            string email1 = txtEmailWM.Text;
            string password1 = txtPasswordWM.Text;
            string address = txtAddress.Text;
            string nid1 = txtNIDWM.Text;

            // warden
            string firstname2 = txtFirstNameWM2.Text;
            string lastname2 = txtLastNameWM2.Text;
            string email2 = txtEmailWM2.Text;
            string password2 = txtPasswordWM2.Text;
            string nid2 = txtNIDWM2.Text;

            // student
            string firstname3 = txtFirstNameWM3.Text;
            string lastname3 = txtLastNameWM3.Text;
            string email3 = txtEmailWM3.Text;
            string password3 = txtPasswordWM3.Text;
            string sid = txtSID.Text;

            string connectionString = ConfigurationManager.ConnectionStrings["MsSqlConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string landquery = "INSERT INTO Landloards_UserDetails (FirstName, LastName, Email, Password, Address, NID) VALUES (@FirstName1, @LastName1, @Email1, @Password1, @Address, @NID1)";
                string wardenquery = "INSERT INTO Wardens_UserDetails (FirstName, LastName, Email, Password, NID) VALUES (@FirstName2, @LastName2, @Email2, @Password2, @NID2)";
                string studentquery = "INSERT INTO Students_UserDetails (FirstName, LastName, SID, Email, Password) VALUES (@FirstName3, @LastName3, @SID, @Email3, @Password3)";

                if (registrationType.SelectedValue == "landlord")
                {
                    // landlord
                    using (SqlCommand command = new SqlCommand(landquery, connection))
                    {
                        command.Parameters.AddWithValue("@FirstName1", firstname1);
                        command.Parameters.AddWithValue("@LastName1", lastname1);
                        command.Parameters.AddWithValue("@Email1", email1);
                        command.Parameters.AddWithValue("@Password1", password1);
                        command.Parameters.AddWithValue("@Address", address);
                        command.Parameters.AddWithValue("@NID1", nid1);

                        try
                        {
                            connection.Open();
                            command.ExecuteNonQuery();
                            Response.Write("Landlord registered successfully!");
                        }
                        catch (Exception ex)
                        {
                            Response.Write("Error: " + ex.Message);
                        }
                    }
                }
                else if (registrationType.SelectedValue == "warden")
                {
                    //warden
                    using (SqlCommand command = new SqlCommand(wardenquery, connection))
                    {
                        command.Parameters.AddWithValue("@FirstName2", firstname2);
                        command.Parameters.AddWithValue("@LastName2", lastname2);
                        command.Parameters.AddWithValue("@Email2", email2);
                        command.Parameters.AddWithValue("@Password2", password2);
                        command.Parameters.AddWithValue("@NID2", nid2);

                        try
                        {
                            connection.Open();
                            command.ExecuteNonQuery();
                            Response.Write("Warden registered successfully!");
                        }
                        catch (Exception ex)
                        {
                            Response.Write("Error: " + ex.Message);
                        }
                    }
                }
                else if (registrationType.SelectedValue == "student")
                {
                    //student
                    using (SqlCommand command = new SqlCommand(studentquery, connection))
                    {
                        command.Parameters.AddWithValue("@FirstName3", firstname3);
                        command.Parameters.AddWithValue("@LastName3", lastname3);
                        command.Parameters.AddWithValue("@SID", sid);
                        command.Parameters.AddWithValue("@Email3", email3);
                        command.Parameters.AddWithValue("@Password3", password3);

                        try
                        {
                            connection.Open();
                            command.ExecuteNonQuery();
                            Response.Write("Student registered successfully!");
                        }
                        catch (Exception ex)
                        {
                            Response.Write("Error: " + ex.Message);
                        }
                    }
                }





            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

    }
}