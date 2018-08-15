
<%@ Page Language="C#" MasterPageFile="~/Master/MasterPage2.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Counter_Login" Title="BuyMyETicket :: For Clients" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <br /> <br />   <br /> 
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
        <asp:Button ID="Button2" runat="server" Text="Login"  UseSubmitBehavior ="true" onclick="Button2_Click" />
        </td>
    </tr>
    
    </table>
    </center>
  
    <br />   <br />   <br />   <br />   <br />   <br />   <br />   <br />
</asp:Content>

