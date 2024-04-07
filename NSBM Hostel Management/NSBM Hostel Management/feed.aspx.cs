using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NSBM_Hostel_Management
{
    public partial class feed : System.Web.UI.Page
    {
        
            // Page Load event handler
            protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    // Call a method to fetch and display the posts
                    DisplayPosts();
                }
            }

            // Method to fetch posts from the database
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

        // Method to display fetched posts on the page
        private void DisplayPosts()
        {
            // Assume you have a method to fetch posts from the database
            List<Post> posts = FetchPostsFromDatabase();

            // Initialize a StringBuilder to efficiently build the HTML content
            StringBuilder htmlBuilder = new StringBuilder();

            // Iterate through each post and construct HTML for it
            foreach (var post in posts)
            {
                htmlBuilder.Append($@"
    <div class='post-container'>
        <div class='post'>
            <h2>Title: {post.Title}</h2>
            <p><strong>Author:</strong> {post.Author}</p>
            <br>
            <p>Content: {post.Content}</p>
            <hr>
        </div>
    </div>
");
            }

            // Assign the constructed HTML to the InnerHtml property of postsContainer
            string postsHtml = htmlBuilder.ToString();

            // Wrapping the posts HTML inside a frame
            string framedHtml = $@"
    <div class='frame'>
        {postsHtml}
    </div>";

            postsContainer.InnerHtml = framedHtml;
        }



        // Nested class to represent a Post
        public class Post
            {
                public string Title { get; set; }
                public string Author { get; set; }
                public string Content { get; set; }
            }

            // Other methods and event handlers...
        }
    }

