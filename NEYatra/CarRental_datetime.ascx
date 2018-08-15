<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CarRental_datetime.ascx.cs" Inherits="CarRental_datetime" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<link href="style.css" rel="stylesheet" type="text/css" />
<link href="css/StyleSheet.css" rel="stylesheet" type="text/css" />
 <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
 <ContentTemplate>
<table width="100%">
<tr>
    <td width="50%">
        <b>Trip Date</b>
    </td>
    <td width="50%">
        <b>Trip Time</b>
    </td>
</tr>
<tr>
    <td width="50%">
      
            <asp:TextBox ID="txtLocalDate" runat="server" Width="110px" CssClass="dd-tb"></asp:TextBox>
            <asp:ImageButton ID="ImageButton1" ImageUrl="~/images/calendar-icon.png" Width="20px"
                Height="20px" runat="server" CausesValidation="false" />
            <asp:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd-MMM-yyyy"
                Animated="true" TargetControlID="txtLocalDate" PopupButtonID="ImageButton1"
                OnClientDateSelectionChanged="CheckDateEalier" OnClientShowing="DisplayDateToday"
                PopupPosition="BottomLeft" CssClass="AjaxCalendar">
            </asp:CalendarExtender>
       
        
    </td>
    <td width="50%">
        <asp:DropDownList ID="ddlpickuptime" runat="server" Width="140px" CssClass="dd" >
            
        </asp:DropDownList>
    </td>
</tr>


</table>
</ContentTemplate>
</asp:UpdatePanel>
