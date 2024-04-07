using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Optimization;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace NSBM_Hostel_Management
{
    public partial class WebMaster : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Call a method to fetch and display the posts
                DisplayPosts();
            }
        }
        private void DisplayPosts()
        {
            // Assume you have a method to fetch posts from the database
            List<Post> posts = FetchPostsFromDatabase();

            // Bind the posts to a control
            postsContainer.InnerHtml = ""; // Clear existing content
            foreach (var post in posts)
            {
                postsContainer.InnerHtml += $@"
        <div class='post-container'>
            <div class='post'>
                <h2>Title:{post.Title}</h2>
                <p><strong>Author:</strong> {post.Author}</p>
                    <br>
                <p>Content:{post.Content}</p>
            </div>
        </div>";

            }
        }

        private List<Post> FetchPostsFromDatabase()
        {
            List<Post> posts = new List<Post>();

            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MsSqlConnection"].ConnectionString;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT Title, Author, Content FROM PostDB";
                    SqlCommand command = new SqlCommand(query, connection);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Post post = new Post
                        {
                            Title = reader["Title"].ToString(),
                            Author = reader["Author"].ToString(),
                            Content = reader["Content"].ToString()
                        };

                        posts.Add(post);
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                // Handle the exception appropriately
                Response.Write("Error fetching posts: " + ex.Message);
            }

            return posts;
        }


        public class Post
        {
            public string Title { get; set; }
            public string Author { get; set; }
            public string Content { get; set; }
        }
        //extra
        protected void submitButton_Click(object sender, EventArgs e)
        {
            // Retrieve the values entered by the user
            string title = this.ptitle.Text;
            string author = this.pauthor.Text;
            string content = this.pcontent.Text;
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
            this.ptitle.Text = "";
            this.pauthor.Text = "";
            this.pcontent.Text = "";
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

                string landquery = "INSERT INTO Landlords_UserDetails (FirstName, LastName, Email, Password, Address, NIC) VALUES (@FirstName1, @LastName1, @Email1, @Password1, @Address, @NID1)";
                string wardenquery = "INSERT INTO Wardens_UserDetails (FirstName, LastName, Email, Password, NIC) VALUES (@FirstName2, @LastName2, @Email2, @Password2, @NID2)";
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
                            Response.Write("<script>alert('Landlord Registered Successfully');</script>");
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
                            Response.Write("<script>alert('Warden registered successfully!');</script>");
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
                            Response.Write("<script>alert('Student registered successfully!');</script>");
                        }
                        catch (Exception ex)
                        {
                            Response.Write("Error: " + ex.Message);
                        }
                    }
                }





            }
        }

        protected void submitpostButton_Click(object sender, EventArgs e)
        {
            // Extract data from form fields
            string postTitle = ptitle.Text;
            string postAuthor = pauthor.Text;
            string postContent = pcontent.Text;

            // Validate data (optional)

            // Save data to the database (Assuming you have a method to do this)
            bool success = SavePostToDatabase(postTitle, postAuthor, postContent);

            if (success)
            {
                // Optionally, you can display a success message or redirect the user
                Response.Write("<script>alert('Post submitted successfully!');</script>");
                // You might want to redirect the user to another page after successful submission
                // Response.Redirect("SomeOtherPage.aspx");
            }
            else
            {
                // Display an error message if the post couldn't be saved
                Response.Write("<script>alert('Failed to submit post. Please try again.');</script>");
            }

            // Clear the form fields after submission
            ptitle.Text = "";
            pauthor.Text = "";
            pcontent.Text = "";
        }

        private bool SavePostToDatabase(string title, string author, string content)
        {
            // Implement logic to save the post to your database
            // This is just a dummy implementation for demonstration purposes
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MsSqlConnection"].ConnectionString;
                // Example:
                using (SqlConnection connection = new SqlConnection(connectionString))
                 {
                     connection.Open();
                    string query = "INSERT INTO PostDB (Title, Author, Content) VALUES (@Title, @Author, @Content)";
                     using (SqlCommand command = new SqlCommand(query, connection))
                     {
                         command.Parameters.AddWithValue("@Title", title);
                         command.Parameters.AddWithValue("@Author", author);
                         command.Parameters.AddWithValue("@Content", content);
                         int rowsAffected = command.ExecuteNonQuery();
                         return rowsAffected > 0;
                     }
                 }
                return true; // Return true if the post is successfully saved
            }
            catch (Exception ex)
            {
                // Log or handle the exception appropriately
                return false; // Return false if an error occurs while saving the post
            }
        }
        protected void btnwebLogout_Click(object sender, EventArgs e)
        {
         


        }


    }
}
