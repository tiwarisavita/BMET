<%@ Page Language="C#" AutoEventWireup="true" CodeFile="counter_page.aspx.cs" Inherits="Counter_counter_page" Title="BMET"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    
    <asp:ImageButton ID="ImageButton1"  ImageUrl="~/images/FinalLogo1.png" 
        Style="margin-right: 0px"  Width="216px" runat="server" 
        onclick="ImageButton1_Click" />
    
    <div>
    
    </div>
    <asp:Label ID="Label1" runat="server" Text="Welcome to Assam Travels.com"></asp:Label>
    <p>
        <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click" 
            PostBackUrl="Add_vehicle_info.aspx">Add 
        Vehicle Information</asp:LinkButton>
    </p>
    <p>
    <asp:LinkButton ID="LinkButton2" runat="server" 
        PostBackUrl="make_schedule.aspx">Make Schedule</asp:LinkButton>
        </p>
        <p> 
        
        <asp:LinkButton ID="LinkButton3" runat="server" 
        PostBackUrl="~/SoldTicketList.aspx" >View Bus/Sumo Booking List</asp:LinkButton></p>
         <p> 
        
        <asp:LinkButton ID="LinkButton6" runat="server" 
        PostBackUrl="~/CarRentalBookingList.aspx" >View CarRental Booking List</asp:LinkButton></p>
          <p> 
        
        <asp:LinkButton ID="LinkButton4" runat="server" 
        PostBackUrl="~/BlockSeat.aspx?action=B" >Block Seat</asp:LinkButton></p>
        <asp:LinkButton ID="LinkButton5" runat="server" 
        PostBackUrl="~/BlockSeat.aspx?action=R" >Release Seat</asp:LinkButton></p>
    </form>
</body>
</html>
