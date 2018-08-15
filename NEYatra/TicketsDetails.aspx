<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TicketsDetails.aspx.cs" Inherits="TicketsDetails"  Title="BuyMyETicket.com :: Ticket"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">  
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
        <font color="blue" size="3"><b>Ticket Confirmation</b></font>
        <hr />
        <h5>
            Dear Customer,</h5>
        <p style="text-align: justify">
            Thank you for using www.buymyeticket.com online reservation facility. Your e-ticket
            has been booked and the details are mentioned below.</p>
        <p style="text-align: justify">
            Please take a printout of this Reservation Slip .You have to carry this printout
            at the time of travel and can be ask by the staff for verification purpose.
        </p>
        <font color="blue" size="4">Booking Details</font>
        <br />
        <table width="100%" border="1">
            <tr>
                <td style="width:auto;">
                    <b>Ticket No. </b>
                </td>
                <td style="width:auto;">
                    <asp:Label ID="lbltranid" runat="server" Text=""></asp:Label>
                </td>
                <td style="width:auto;">
                    <b>Counter </b>
                </td>
                <td style="width:auto;">
                    <asp:Label ID="lblCuntName" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width:auto;">
                    <b>From</b>
                </td>
                <td style="width:auto;">
                    <asp:Label ID="lblFrom" runat="server" Text=""></asp:Label>
                </td>
                <td style="width:auto;">
                    <b>To </b>
                </td>
                <td style="width:auto;">
                    <asp:Label ID="lblTo" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width:auto;">
                    <b>Mode/Vehicle no.</b>
                </td>
                <td style="width:auto;">
                    <asp:Label ID="lblMode" runat="server" Text=""></asp:Label>
                </td>
                <td style="width:auto;">
                    <b>Travel Date & Time </b>
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
                    <b>Address </b>
                </td>
                <td style="width:auto;">
                    <asp:Label ID="lblAddress" runat="server" Text=""></asp:Label>
                </td>
            </tr>
             <tr>
                <td style="width:auto;">
                    <b>Seat no(s):</b>
                </td>
                <td style="width:auto;">
                    <asp:Label ID="lblSeats" runat="server" Text=""></asp:Label>
                </td>
                <td style="width:auto;">
                    <b>Amount </b>
                </td>
                <td style="width:auto;">
                    <asp:Label ID="lblAmt" runat="server" Text=""></asp:Label>
                </td>
            </tr>
           <%-- <tr>
                <td style="width:auto;">
                    <b>Gender/</b> <b>Age </b>
                </td>
                <td style="width:auto;">
                    <asp:Label ID="lblGender" runat="server" Text=""></asp:Label> - <asp:Label ID="lblAge" runat="server" Text=""></asp:Label>
                </td>
                <td style="width:auto;">
                  <b>Vehicle No:</b> 
                </td>
                <td style="width:auto;">
                   
                </td>
            </tr>--%>
           
           
        </table>
        <br />
        <asp:Label ID="lblTicketAmt" runat="server" Text="" Font-Bold="true" Font-Underline="true"></asp:Label><br />
        <br />
        <asp:Label ID="lblBoardingPoints" runat="server" Text=""></asp:Label><br />
        Booked On :<asp:Label ID="lblBookingdt" runat="server" Text=""></asp:Label><br />
        <asp:Label ID="lblExtraAmt" runat="server" Text=""></asp:Label>
        <p style="text-align: justify">
            For CHANGE OF BOARDING STATION &amp; CHANGE IN NAME customer can approach our
            customer care center or mail us at <a href="mailto:info@buymyeticket.com">info@buymyeticket.com</a>.
            Please do carry a valid ID proof which can be shown if inquired by staff. Passenger should report at boarding point, prior to 30 min schedule departure time.</p>
        <p style="text-align: justify">
            Thanks for choosing us, we wish you a happy journey. Keep on visiting our website
            for more discounts and attractive offers...</p>
        <b>Warm Regards,<br />
            Customer Care | www.buymyeticket.com | Helpline : +91-9435351122</b>
           
                    
    </div>
    </form>
</body>
</html>
