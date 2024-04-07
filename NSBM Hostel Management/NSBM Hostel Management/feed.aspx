<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="feed.aspx.cs" Inherits="NSBM_Hostel_Management.feed" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Hostel Articles</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
            position: relative;
        }

        .frame {
            border: 3px solid black;
            padding: 10px;
            margin: 10px;
            border-radius: 5px;
        }

        .background-overlay {
            position: fixed;
            top: 0;
            left: 0;
            width: 100%;
            height: 100%;
            background-image: url('assets/feedbg.jpeg'); /* Replace 'your-background-image.jpg' with your actual image file */
            background-size: cover;
            background-position: bottom;
            filter: blur(5px); /* Adjust the blur strength as needed */


            opacity: 70%;
            z-index: -1;
        }

        .container {
            max-width: 800px;
            margin: 20px auto;
            padding: 20px;
            background-color: rgba(255, 255, 255, 0.9); /* Adding a semi-transparent background to make text readable */
            border-radius: 8px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            position: relative;
            z-index: 1;
        }

        .post {
            padding: 20px 0;
            border-bottom: 1px solid #ddd;
        }

            .post:last-child {
                border-bottom: none;
            }

            .post img {
                max-width: 100%;
                height: auto;
                border-radius: 8px;
                margin-bottom: 10px;
            }

        .post-content {
            padding: 10px;
        }

            .post-content h2 {
                font-size: 20px;
                margin: 0 0 10px;
            }

            .post-content p {
                font-size: 16px;
                margin: 0 0 10px;
                color: #666;
            }

        hr {
            margin: 20px 0;
            border: none;
            border-top: 1px solid black;
        }

        @media screen and (max-width: 600px) {
            .container {
                padding: 10px;
            }

            .post img {
                border-radius: 0;
            }

            .post-content {
                padding: 10px;
            }
        }
    </style>
</head>
<body>
    <div class="background-overlay"></div>
    <div class="container">
       <h1 style="text-align: center;">Hostel Updates by the Webmaster.</h1>
        <hr />
        
        <div id="postsContainer" runat="server">
            <hr>
           
        </div>
    </div>
</body>
</html>
