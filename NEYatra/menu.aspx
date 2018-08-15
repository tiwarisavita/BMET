<%@ Page Language="C#" MasterPageFile="~/Master/MasterPage2.master" AutoEventWireup="true" CodeFile="menu.aspx.cs" Inherits="menu" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style type="text/css">

.gradientbuttons ul{
padding: 3px 0;
margin-left: 0;
margin-top: 1px;
margin-bottom: 0;
font: bold 13px Verdana;
list-style-type: none;
text-align: center; /*set to left, center, or right to align the menu as desired*/
}

.gradientbuttons li{
display: inline;
margin: 0;
}

.gradientbuttons li a{
text-decoration: none;
padding: 5px 7px;
margin-right: 5px;
border: 1px solid #778;
color: white;
border:1px solid gray;
/*background: #3282c2;*/
background-color:Purple;
border-radius: 8px; /*w3c border radius*/
box-shadow: 3px 3px 4px rgba(0,0,0,.5); /* w3c box shadow */
-moz-border-radius: 8px; /* mozilla border radius */
-moz-box-shadow: 3px 3px 4px rgba(0,0,0,.5); /* mozilla box shadow */
/*background: -moz-linear-gradient(center top, #a4ccec, #72a6d4 25%, #3282c2 45%, #357cbd 85%, #72a6d4); /* mozilla gradient background */
-webkit-border-radius: 8px; /* webkit border radius */
-webkit-box-shadow: 3px 3px 4px rgba(0,0,0,.5); /* webkit box shadow */
/*background: -webkit-gradient(linear, center top, center bottom, from(#a4ccec), color-stop(25%, #72a6d4), color-stop(45%, #3282c2), color-stop(85%, #357cbd), to(#72a6d4)); /* webkit gradient background */
}

.gradientbuttons li a:hover{
color: lightyellow;
}





.graytbuttons ul
{
/*padding: 3px 0;*/
margin-left: 0;
/*margin-top: 1px;*/
margin-bottom: 0;
/*font: bold 13px Verdana;*/
list-style-type: none;
/*width:950px;*/
width:100%;
text-align: center; /*set to left, center, or right to align the menu as desired*/
}

.graytbuttons li
{
text-align:center;
display: inline;
margin: 2px;
width:128px;
border:1px solid gray;
padding: 8px 0px 8px 0px;
/*height:35px;*/
background-color:#eeeeee;
border-radius: 8px; /*w3c border radius*/
box-shadow: 3px 3px 4px rgba(0,0,0,.5); /* w3c box shadow */
-moz-border-radius: 8px; /* mozilla border radius */
/*-moz-box-shadow: 3px 3px 4px rgba(0,0,0,.5); /* mozilla box shadow */
/*background: -moz-linear-gradient(center top, #a4ccec, #72a6d4 25%, #3282c2 45%, #357cbd 85%, #72a6d4); /* mozilla gradient background */
-webkit-border-radius: 8px; /* webkit border radius */
/*-webkit-box-shadow: 3px 3px 4px rgba(0,0,0,.5); /* webkit box shadow */
}

.graytbuttons li a
{
	
font-size:12px;
font-family:Verdana Arial Sans-Serif;
font-weight:bold;
text-decoration: none;
/*padding: 5px 7px;*/
/*margin-right: 5px;*/
color:Purple;
/*border:1px solid gray;
/*background-color:#eeeeee;*/
/*border-radius: 8px; /*w3c border radius*/
/*box-shadow: 3px 3px 4px rgba(0,0,0,.5); /* w3c box shadow */
/*-moz-border-radius: 8px; /* mozilla border radius */
/*-moz-box-shadow: 3px 3px 4px rgba(0,0,0,.5); /* mozilla box shadow */
/*background: -moz-linear-gradient(center top, #a4ccec, #72a6d4 25%, #3282c2 45%, #357cbd 85%, #72a6d4); /* mozilla gradient background */
/*-webkit-border-radius: 8px; /* webkit border radius */
/*-webkit-box-shadow: 3px 3px 4px rgba(0,0,0,.5); /* webkit box shadow */
/*background: -webkit-gradient(linear, center top, center bottom, from(#a4ccec), color-stop(25%, #72a6d4), color-stop(45%, #3282c2), color-stop(85%, #357cbd), to(#72a6d4)); /* webkit gradient background */
}

.graytbuttons li a:hover{
/*color: lightyellow;*/
color:Green;
}
</style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<br />
<div class="gradientbuttons">
<ul>
<li><a href="#">Home</a></li>
<li><a href="#">Car Rental</a></li>  
<li><a href="#">Route Fare</a></li>
<li><a href="#">Travel Coupon</a></li>
<li><a href="#">Contact Us</a></li>
<li><a href="#">About Us</a></li>
<li><a href="#">For Clients</a></li>
</ul>
</div>

<br />
<br />
<br />
<div class="graytbuttons">
<ul>
<li><a href="#">Home</a></li>
<li><a href="#">Car Rental</a></li>  
<li><a href="#">Route Fare</a></li>
<li><a href="#">Travel Coupon</a></li>
<li><a href="#">Contact Us</a></li>
<li><a href="#">About Us</a></li>
<li><a href="#">For Clients</a></li>
</ul>
</div>
<br /><br /><br />
<br />
</asp:Content>

