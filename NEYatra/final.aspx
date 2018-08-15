<%@ Page Language="C#" MasterPageFile="~/Master/MasterPage2.master" AutoEventWireup="true"
    Inherits="final" CodeFile="~/final.aspx.cs" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
    
    <div style="text-align: left">
        <br />
        <br />
     
        <br />

        <table width="75%" id="tbl_Event" runat="server" visible="false" class="bus-bg">
            <tr>
                <td align="left" style="width: 25%">
                    <b>Booking No.</b>
                </td>
                <td align="left" style="width: 20%">
                    <asp:Label ID="lblBookingno" runat="server" Text=""></asp:Label>
                </td>
                <td align="left" style="width: 25%">
                    <b>Event Name </b>
                </td>
                <td align="left" style="width: 30%">
                    <asp:Label ID="lbleventname" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="left" style="width: 25%">
                    <b>Venue</b>
                </td>
                <td align="left" style="width: 20%">
                    <asp:Label ID="lblVenue" runat="server" Text=""></asp:Label>
                </td>
                <td align="left" style="width: 25%">
                     <b>Date &Time </b>
                </td>
                <td align="left" style="width: 30%">
                    <asp:Label ID="lbleventdatetime" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="left" style="width: 25%">
                    <b>No.of person</b>
                </td>
                <td align="left" style="width: 20%">
                    <asp:Label ID="lblpersonCount" runat="server" Text=""></asp:Label>
                </td>
                <td align="left" style="width: 25%">
                       <b>Amount</b>
                </td>
                <td align="left" style="width: 30%">
                    <asp:Label ID="lbleventAmt" runat="server" Text="" ></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="left" style="width: 25%">
                    <b>Customer Name</b>
                </td>
                <td align="left" style="width: 20%">
                    <asp:Label ID="lblname"  Text="" runat="server" ></asp:Label>
                </td>
                <td align="left" style="width: 25%">
                    <b>Mobile No. </b>
                </td>
                <td align="left" style="width: 30%">
                    <asp:Label ID="lbleventuserMobno" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="left" style="width: 25%">
                    <b>Email-ID</b>
                </td>
                <td align="left" style="width: 20%">
                    <asp:Label ID="lbl_email" runat="server" Text=""></asp:Label>
                </td>
                <td align="left" style="width: 25%">
                    <b>Customer Address </b>
                </td>
                <td align="left" style="width: 30%">
                    <asp:Label ID="lblAdd" runat="server" Text=""></asp:Label>
                </td>
            </tr>
          
        </table>
        <br />
        <table width="75%" id="tbl_details" runat="server" visible="false" class="bus-bg">
            <tr>
                <td align="left" style="width: 25%">
                    <b>Ticket/Booking No.</b>
                </td>
                <td align="left" style="width: 20%">
                    <asp:Label ID="lbltranid" runat="server" Text=""></asp:Label>
                </td>
                <td align="left" style="width: 25%">
                    <b>Counter/Vendor </b>
                </td>
                <td align="left" style="width: 30%">
                    <asp:Label ID="lblCuntName" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="left" style="width: 25%">
                    <b>Source City</b>
                </td>
                <td align="left" style="width: 20%">
                    <asp:Label ID="lblFrom" runat="server" Text=""></asp:Label>
                </td>
                <td align="left" style="width: 25%">
                    <asp:Label ID="lblDes" runat="server" Text="Destination" Font-Bold="true"></asp:Label>
                </td>
                <td align="left" style="width: 30%">
                    <asp:Label ID="lblTo" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="left" style="width: 25%">
                    <b>Mode</b>
                </td>
                <td align="left" style="width: 20%">
                    <asp:Label ID="lblMode" runat="server" Text=""></asp:Label>
                </td>
                <td align="left" style="width: 25%">
                    <asp:Label ID="lblDesDateTime" runat="server" Text="Travel Date & Time"></asp:Label>
                </td>
                <td align="left" style="width: 30%">
                    <asp:Label ID="lblDateTime" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="left" style="width: 25%">
                    <b>Customer Name</b>
                </td>
                <td align="left" style="width: 20%">
                    <asp:Label ID="lblCustName" runat="server" Text=""></asp:Label>
                </td>
                <td align="left" style="width: 25%">
                    <b>Mobile No. </b>
                </td>
                <td align="left" style="width: 30%">
                    <asp:Label ID="lblMobNo" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="left" style="width: 25%">
                    <b>Email-ID</b>
                </td>
                <td align="left" style="width: 20%">
                    <asp:Label ID="lblemail" runat="server" Text=""></asp:Label>
                </td>
                <td align="left" style="width: 25%">
                    <b>Customer Address </b>
                </td>
                <td align="left" style="width: 30%">
                    <asp:Label ID="lblAddress" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="left" style="width: 25%">
                    <b>Seat no(s)/ Selected Vehicle</b>
                </td>
                <td align="left" style="width: 20%">
                    <asp:Label ID="lblSeats" runat="server" Text=""></asp:Label>
                </td>
                <td align="left" style="width: 25%">
                    <asp:Label ID="lblDesAmt" runat="server" Text="Amount" Font-Bold="true" ></asp:Label>
                </td>
                <td align="left" style="width: 30%">
                    <asp:Label ID="lblAmt" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="4" align="left">
                    <br />
                    <br />
                    <asp:Label ID="lblBoardingPoints" runat="server" Text=""></asp:Label><br />
                    <br />
                </td>
            </tr>
            <tr><td colspan="4" align="left">
                <asp:Literal ID="lttPolicy" runat="server" ></asp:Literal></td></tr>
            <tr>
                <td colspan="4" align="left">
                    <br />
                    <br />
                    <asp:Label ID="lblBookedOn" runat="server" Text=""></asp:Label><br />
                    <br />
                </td>
            </tr>
        </table>
      
        <asp:Button ID="btnPrint" runat="server" Text="Print Ticket" CssClass="text" OnClick="btnPrint_Click"
            Visible="false" />
        
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
    </div>
</asp:Content>
