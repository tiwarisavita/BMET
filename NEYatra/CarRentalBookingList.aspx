<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CarRentalBookingList.aspx.cs" Inherits="CarRentalBookingList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>CarRental Booking List</title>
    <link href="style.css" rel="stylesheet" type="text/css" />
    <link href="css/StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <a href="counter_page.aspx">Home</a><br /><br />
    <table width="100%"><tr><td style="background-color:Aqua; text-align:center;"><b>Car Rental Booking List</b></td></tr></table>
    <br />
    <asp:Button ID="btnExport" runat="server" Text="Export to Excel"  CssClass="text" 
            onclick="btnExport_Click"/>
        <br />
    <br />
    <div id="Div2" style="width: 100%; height: auto; text-align: left; background-color: White;
        display: block; margin-right: 10px;">
        
        <asp:GridView ID="grdSoldTickets" runat="server" AllowPaging="true" AlternatingRowStyle-CssClass="AlterGridrow"
            AutoGenerateColumns="False" CssClass="datatbl" FooterStyle-CssClass="GridFooter"
            AllowSorting="true" HeaderStyle-CssClass="GridHeader" 
            PagerSettings-PageButtonCount="10" PagerStyle-CssClass="GridPager" PageSize="30"
            RowStyle-CssClass="Gridrow" ShowFooter="true" ShowHeader="true" 
            Width="100%" onpageindexchanging="grdSoldTickets_PageIndexChanging" 
            onrowdatabound="grdSoldTickets_RowDataBound" >
            <Columns>
                <asp:TemplateField HeaderText="SNo." ItemStyle-HorizontalAlign="Left">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Font-Bold="false" Text='<%#(Container.DataItemIndex)+1 +"." %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="tranId" HeaderText="Ticket No." />                
                <asp:BoundField DataField="CustName" HeaderText="Customer Name" />
                <%--<asp:BoundField DataField="EmailID" HeaderText="Email-ID" />--%>
                <asp:BoundField DataField="cancel" HeaderText="Cancelled" />
                <asp:BoundField DataField="MobNo" HeaderText="Mobile" />           
                <asp:BoundField DataField="Address" HeaderText="Pick-up Address" />
                <asp:BoundField DataField="CounterName" HeaderText="Vendor" />
                <asp:BoundField DataField="From" HeaderText="Source City" />
                <asp:BoundField DataField="Usage" HeaderText="Trip/Usage" />                 
                <asp:BoundField DataField="TravelDate" HeaderText="Pick-up Date" />
                <asp:BoundField DataField="TravelTime" HeaderText="Pick-up Time" />
                <asp:BoundField DataField="SelectedVehicle" HeaderText="Vehicle" />
                <asp:BoundField DataField="FranName" HeaderText="Franchisee" />
                <asp:BoundField DataField="total_fare" HeaderText="Fare" />
                <asp:BoundField DataField="BookingAmt" HeaderText="BookingAmt" />
                <asp:BoundField DataField="BookingAmtGot" HeaderText="AmountWeGot" />
                <asp:BoundField DataField="Fran_Markup" HeaderText="Markup" />                              
                <asp:BoundField DataField="BookedOn" HeaderText="Booked On" />
            </Columns>
            <EmptyDataTemplate>
                <div id="tbldiv" style="width: 100%; height: auto; background-color: White; display: block;">
                    <table cellpadding="0" cellspacing="0" class="datatbl" width="100%">
                        <tr>
                            <td align="center" class="tbl1" colspan="9">
                                <strong>No Schedule Available</strong>
                            </td>
                        </tr>
                    </table>
                </div>
            </EmptyDataTemplate>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
