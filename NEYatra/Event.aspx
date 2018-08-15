<%@ Page Title="Events" Language="C#" MasterPageFile="~/Master/MasterPage2.master" AutoEventWireup="true" CodeFile="Event.aspx.cs" Inherits="Event_Event" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
        .large { font-family: times, Times New Roman, times-roman, georgia, serif;
            font-size: 26px;
            line-height: 26px;
 letter-spacing: -1px;
 color: #444;
 margin: 0 0 0 0;
 padding: 0 0 0 0;
 font-weight: 100;
        }
        .pagetext{
  font-family: times, Times New Roman, times-roman, georgia, serif;
 font-size: 20px;
 line-height: 16px;
 text-transform: uppercase;
 text-decoration:underline;
 color: #446;
        }
           .pagetextcontent{
  font-family: times, Times New Roman, times-roman, georgia, serif;
 font-size: 20px;
 line-height: 16px; 
 text-decoration:underline;
 color: #444;
        }
    li{
  font: 200 20px/1.5 Helvetica, Verdana, sans-serif;
  border-bottom: 1px solid #ccc;
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
       <div class="large">ELECTRO NIGHT-2017, Guwahati -  3rd March 2017 - 6 PM onwards <br />
    </div>
    <br /><br /><br />
    <div class="pagetext">
        TICKETS ON SALE
    </div><br /><br />
     <table width="100%" cellpadding="0" cellspacing="0" class="pagetext">
        <tr>
             <td width="50%">
                <table style="width: 100%">
                    <tr>
                        <td  align="left"  valign="top" >                        
                            <table cellpadding="10" cellspacing="5" >
                                   <tr>
                                    <td>Person</td>
                                    <td>
                                        <asp:DropDownList ID="ddlCoupleTicketno" runat="server" OnSelectedIndexChanged="ddlCoupleTicketno_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList></td>
                                    <td>* </td>
                                    <td>
                                        <asp:Label ID="lblCoupleTicketValue" runat="server" Text="500"></asp:Label></td>
                                    <td>= </td>
                                    <td>
                                        Rs.<asp:Label ID="lblTotalValueCoupleTicket" runat="server" Text="0"></asp:Label>
                                    </td>
                                </tr>                           
                            </table>
                            <br /><br />
                            <div style=" background-color:lightblue; border-top:solid;border-bottom:solid">
                                <br />Total Ticket Value = Rs. <asp:Label ID="lblTotalTicketValue" runat="server" Text=""></asp:Label>
                                <br />    <br />                       
                            </div>
                            <br /><br />
                          
                                 <p class="pagetext">
        <b>Event Highlights </b>
         <ul>
            <li>Venue -- Kaamaakaazi Floating Disco Restaurant</li>
            <li>Date and Time -3rd March 2017 - 6 PM onwards </li>
             <li>Contact No - +918721912761</li>
            <li><b>DJ Yanny( Arunachalian female DJ now based in Shillong), DJ Jeet &amp; DJ Rahul (Kaamakaazi Resident DJ)</b></li>            
           </ul>
                                </p>      
<br /><br /><br /><br /><br /><br />
           <p  class="pagetext"><b>Terms & Conditions</b>
          <ul>
            <li>People under 18 not allowed to enter the event.</li>
            <li>Intoxicated persons are not allowed to enter the event.</li>
            <li>Food, Beverage and liquor drinks are not allowed from outside.</li>
            <li>Management will not be responsible for any injury/accident due to negligence of guests.</li>
            <li>The management has the right to remove any person found miss behaving or with a misconduct.</li>
            <li>Once sold pass can’t be returned or refund.</li>
            <li>Any technical issues or defaults kindly cooperate.</li>
              <li>Camera’s are not allowed in the event.</li>
              
        </ul>
                            </p>
                          
                    </td>
                </table>
                 <br />
                            <asp:Button ID="btnnext" runat="server" Text="Add To Cart" Height="43px" Width="203px" OnClick="btnnext_Click" Enabled="false"  />
                            <br /><br />
              </td>
            <td width="50%">
                <table style="width: 100%">
                    <tr>
                        <td  align="center" >
                            <div>Customer Care :: +91-9435351122</div> <br />   
                            <img src="images/ElectroNight.jpg" height="550" style="width: 550px; margin-left: 0px; margin-top: 0px;"/>
                        
                    </td>
                </table>
              </td>
                   
               

        </tr>

    </table>
    <hr />
    <h1>Past Events</h1>
    <table style="width: 100%;" cellspacing="10">
        <tr>
            <td>
                <img src="../images/dreamland.png" style="height: 400px; width: 300px" /></td>
            <td>
                <img src="../images/StreetFood.png" style="width: 300px; height: 400px" /></td>
            <td>
                <img src="../images/tezpur_event.png" style="height: 400px; width: 300px" /></td>
        </tr>
       
    </table>
</asp:Content>

