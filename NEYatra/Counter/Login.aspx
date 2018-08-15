<%--<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Counter_Login" %>
--%>
<%@ Page Language="C#" MasterPageFile="~/Master/MasterPage2.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Counter_Login" Title="BuyMyETicket :: For Clients" %>

<%--<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
--%><asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <%--<form id="form1" runat="server">--%>
 <br />
 <center>
    <table border="1">
    <tr><td>User Name</td>
    <td>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </td>
    </tr>
     <tr><td>Password</td>
    <td>
        <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
        </td>
    </tr>
     <tr><td>
         <asp:Button ID="Button1" runat="server" Text="Retry" onclick="Button1_Click" 
             Width="70px" /></td>
    <td>
        <asp:Button ID="Button2" runat="server" Text="Login" onclick="Button2_Click" />
        </td>
    </tr>
    
    </table>
    </center>
    <%--</form>--%>
    <br />
</asp:Content>

<%--<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>--%>
<%--   
</body>
</html>--%>