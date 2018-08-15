<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Add_vehicle_info.aspx.cs" Inherits="Counter_Add_vehicle_info" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <style type="text/css">
        .style1
        {
        	color:Aqua;
            width: 491px
        }
        .style2
        {
            height: 26px;
        }
        .style3
        {
            color: Aqua;
            width: 491px;
            height: 26px;
        }
    </style>
</head>
<body>
   <a href="Default.aspx"> <img src="images/FinalLogo1.png" Style="margin-right: 0px"  Width="216px" /></a>
                                       
      
        
    <form id="form1" runat="server">
       <br />
       <br />
    <div>
      
        <table style="width: 50%; height: 51px;">
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Counter Name"></asp:Label>
                    </td>
                <td class="style1">
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
                
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Vehicle Number"></asp:Label></td>
                <td class="style1">
                    <asp:TextBox ID="TextBox2" runat="server" MaxLength="6"></asp:TextBox> &nbsp;&nbsp; 
                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox></td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="Owner Name"></asp:Label></td>
                <td class="style1">
                    <asp:TextBox ID="TextBox4" runat="server" Width="265px"></asp:TextBox></td>
                
            </tr>
             <tr>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="Owner Address"></asp:Label></td>
                <td class="style1">
                    <asp:TextBox ID="TextBox5" runat="server" Width="261px"></asp:TextBox></td>
                
            </tr>
           
            <tr>
                <td>
                    <asp:Label ID="Label6" runat="server" Text="Owner Phone no."></asp:Label></td>
                <td class="style1">
                    <asp:TextBox ID="TextBox7" runat="server" Width="261px"></asp:TextBox></td>
                
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label7" runat="server" Text="Vehicle Type"></asp:Label></td>
                <td class="style1">
                    <asp:DropDownList ID="DropDownList1" runat="server" Width="127px" 
                        onselectedindexchanged="DropDownList1_SelectedIndexChanged">
                        <asp:ListItem>Bus</asp:ListItem>
                        <asp:ListItem>Sumo</asp:ListItem>
                    </asp:DropDownList>
                </td>            
            </tr>
             <tr>
                <td class="style2">
                    <asp:Label ID="Label8" runat="server" Text="Vehicle Layout"></asp:Label></td>
                <td class="style3">
                    <asp:DropDownList ID="DropDownList2" runat="server" Width="127px">
                        <asp:ListItem>2*2</asp:ListItem>
                        <asp:ListItem>2*1</asp:ListItem>
                        <asp:ListItem>Sumo</asp:ListItem>
                    </asp:DropDownList>
                </td>            
            </tr>
             <tr>
                <td class="style2">
                    <asp:Button ID="Button1" runat="server" Text="Add info" 
                        onclick="Button1_Click" /></td>
            
            </tr>
            
        </table>
    
    </div>
    </form>
</body>
</html>
