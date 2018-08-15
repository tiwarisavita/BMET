<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SoldTicketList.aspx.cs" Inherits="SoldTicketList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Bus/Sumo Booking List</title>
    <link href="style.css" rel="stylesheet" type="text/css" />
    <link href="css/StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <a href="counter_page.aspx">Home</a><br /><br />
    <table width="100%"><tr><td style="background-color:Aqua; text-align:center;"><b>Booked Ticket List</b></td></tr></table>
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
                <asp:BoundField DataField="MobNo" HeaderText="Mobile No" />                
                <%--<asp:BoundField DataField="EmailID" HeaderText="Email ID" />
                <asp:BoundField DataField="Address" HeaderText="Address" />--%>
                <asp:BoundField DataField="CounterName" HeaderText="Counter" />
                <asp:BoundField DataField="From" HeaderText="Source" />
                <asp:BoundField DataField="To" HeaderText="Destination" />
                <asp:BoundField DataField="Mode" HeaderText="Mode" />
                <asp:BoundField DataField="cancel" HeaderText="Cancelled" />
                <asp:BoundField DataField="TravelDate" HeaderText="Travel Date" />
                <asp:BoundField DataField="TravelTime" HeaderText="Time" />
                <asp:BoundField DataField="SeatBooked" HeaderText="Seats" />
                <asp:BoundField DataField="MarketTicketprice" HeaderText="Ticket Price" />
                <asp:BoundField DataField="BMETAmt" HeaderText="Actual Price" />
                <asp:BoundField DataField="Cusdis" HeaderText="C Dis" />
                <asp:BoundField DataField="Frandis" HeaderText="F Dis" />
                <asp:BoundField DataField="BoardingPoints" HeaderText="Boarding" />
                <asp:BoundField DataField="FranName" HeaderText="Franchisee" />
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
