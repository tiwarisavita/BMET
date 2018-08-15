<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CarRentalTicketDetails.aspx.cs" Inherits="CarRentalTicketDetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Car Rental :: Booking Information</title>
</head>
<body style="font-size: small; font-family: 'Trebuchet MS'">
    <form id="form1" runat="server">
    <table width="100%"><tr><td class="84%"><img src="images/FinalLogo1.png" 
            alt="BuyMyETicket.com" style="height: 59px; width: 173px" /></td>
    <td width="8%" align="right"><input id="btnPrint" type="button" value="Print" onclick="window.print();"   style="width:70 px"/></td>
    <td width="8%" align="right"><input id="btnClose" type="button" value="Close" onclick="window.close();"  style="width:70 px"/></td>
    </tr>
    </table>
    <asp:Label ID="lblmsg" runat="server" Text="" Visible="false" ForeColor="Red" Font-Bold="true"></asp:Label>
       
    <div id="div_ticket">
       <hr /> 
        <font color="blue" size="3"><b>Car Rental Booking Details</b></font>
        <hr />
        <h5>
            Dear Customer,</h5>
        <p style="text-align: justify">
            Thank you for using www.buymyeticket.com online reservation facility. Your e-bookings
            has been done and the details are as follows.</p>
        <p style="text-align: justify">
            Please take a printout of this booking Slip .You have to carry this printout
            at the time of travel and can be ask by the staff for verification purpose.
        </p>
        <font color="blue" size="4">Booking Details</font>
        <br />
        <table width="100%" border="1">
            <tr>
                <td style="width:auto;">
                    <b>Booking No. </b>
                </td>
                <td style="width:auto;">
                    <asp:Label ID="lbltranid" runat="server" Text=""></asp:Label>
                </td>
                <td style="width:auto;">
                    <b>Vendor Name </b>
                </td>
                <td style="width:auto;">
                    <asp:Label ID="lblCuntName" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width:auto;">
                    <b>Source City</b>
                </td>
                <td style="width:auto;">
                    <asp:Label ID="lblFrom" runat="server" Text=""></asp:Label>
                </td>
                <td style="width:auto;">
                    <b>Usage/Destination </b>
                </td>
                <td style="width:auto;">
                    <asp:Label ID="lblTo" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width:auto;">
                    <b>Mode</b>
                </td>
                <td style="width:auto;">
                    <asp:Label ID="lblMode" runat="server" Text=""></asp:Label>
                </td>
                <td style="width:auto;">
                    <b>Pick-up Date & Time </b>
                </td>
                <td style="width:auto;">
                    <asp:Label ID="lblDateTime" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width:auto;">
                    <b>Customer Details</b>
                </td>
                <td style="width:auto;">
                    <asp:Label ID="lblCustName" runat="server" Text=""></asp:Label>
                </td>
                <td style="width:auto;">
                    <b>Mobile No. </b>
                </td>
                <td style="width:auto;">
                    <asp:Label ID="lblMobNo" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width:auto;">
                    <b>Email-ID</b>
                </td>
                <td style="width:auto;">
                    <asp:Label ID="lblemail" runat="server" Text=""></asp:Label>
                </td>
                <td style="width:auto;">
                    <b>Pick-up Address </b>
                </td>
                <td style="width:auto;">
                    <asp:Label ID="lblAddress" runat="server" Text=""></asp:Label>
                </td>
            </tr>
             <tr>
                <td style="width:auto;">
                    <b>Selected Vehicle</b>
                </td>
                <td style="width:auto;">
                    <asp:Label ID="lblSeats" runat="server" Text=""></asp:Label>
                </td>
                <td style="width:auto;">
                    <b>Booking Amount Paid (Rs.)</b>
                </td>
                <td style="width:auto;">
                    <asp:Label ID="lblAmt" runat="server" Text=""></asp:Label>
                </td>
            </tr>
          
            <tr>
                <td style="width:auto;">
                    <b>Total Fare(Approx.)</b>
                </td>
                <td style="width:auto;">
                    <asp:Label ID="lblTotalFare" runat="server" Text=""></asp:Label>
                </td>
                <td style="width:auto;">
                    <b>Balance Amount(Approx.)</b>
                </td>
                <td style="width:auto;">
                    <asp:Label ID="lblBalanceFare" runat="server" Text=""></asp:Label>
                </td>
            </tr>
        </table>
        <br />
        <asp:Label ID="lblFranname" runat="server" Text="" Font-Bold="true"></asp:Label><br />
        <br />
         <asp:Literal ID="lttPolicy" runat="server" ></asp:Literal><br /><br />
        Booked On : <asp:Label ID="lblBookingdt" runat="server" Text=""></asp:Label><br />
        
        <p style="text-align: justify">
            For change of pick-up address or time customer can approach our
            customer care center or mail us at <a href="mailto:info@buymyeticket.com">info@buymyeticket.com</a>.
            Please do carry a valid ID proof which can be shown if inquired by staff.</p>
        <p style="text-align: justify">
            Thanks for choosing us, we wish you a happy journey. Keep on visiting our website
            for more discounts and attractive offers...</p>
        <b>Warm Regards,<br />
            Customer Care | www.buymyeticket.com | Helpline : +91-9435351122</b>
           
                    
    </div>
    </form>
</body>
</html>
