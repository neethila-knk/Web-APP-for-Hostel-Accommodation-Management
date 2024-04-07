<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NavigationBar.ascx.cs" Inherits="NSBM_Hostel_Management.navuc" %>

<!DOCTYPE html>
<html lang="en">
<head>
<meta charset="UTF-8">
<meta name="viewport" content="width=device-width, initial-scale=1.0">
<title>Navigation Bar</title>
<style>
  body {
    font-family: Arial, sans-serif;
    margin: 0;
    padding: 0;
  }

  .navbar-container {
    position: fixed;
    top: 0;
    right: 20px; /* Adjust the right value as needed */
    width: auto;
    z-index: 999; /* Ensure it's on top */
  }

  .navbar {
    background-color: #23b158;
    overflow: hidden;
    display: flex;
    justify-content: flex-end;
    transition: width 1s ease;
    width: 55px; /* Initial width */
    
    position:center;
  }

  .navbar.expanded {
    width: 250px; /* Expanded width */
     z-index:100;
  }

  .navbar a {
    color: white;
    padding: 14px 20px;
    text-decoration: none;
    text-align: center;
  }

  .dropdown {
    background-color: #333;
    display: none;
    position: absolute;
    min-width: 160px;
    z-index: 100;
    right: 0;
    border-bottom-left-radius:20px;
    border-bottom-right-radius:20px;
  }

  .dropdown a {
    float: none;
    color: white;
    padding: 12px 16px;
    text-decoration: none;
    display: block;
    z-index: 100;
    text-align: left;
    text-align: center;

  }

  .dropdown a:hover {
    background-color: #ddd;
    color: #333;
    border-bottom-left-radius:20px;
    border-bottom-right-radius:20px;
    z-index:100;
  }

  /* Show dropdown when hovering over icon */
  .navbar:hover .dropdown {
    display: block;
    z-index:100;
  }


</style>
</head>
<body>

<div class="navbar-container">
  <div class="navbar" id="navbar">
    
    <div class="dropdown" >
        <a href="index.aspx">Home</a>
        <a href="feed.aspx">Article</a>
      
         <a href="index.aspx" >Logout</a>

    </div>
    <a href="javascript:void(0);" class="icon">
      &#9776;
    </a>
  </div>
</div>

   

</body>
</html>
