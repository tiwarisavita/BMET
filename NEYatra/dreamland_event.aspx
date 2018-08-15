<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage2.master" AutoEventWireup="true" CodeFile="dreamland_event.aspx.cs" Inherits="dreamland_event" %>

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
 color: #444;
        }
    li{
  font: 200 20px/1.5 Helvetica, Verdana, sans-serif;
  border-bottom: 1px solid #ccc;
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="large">On Saturday, 31 Dec 2016 &nbsp;&nbsp;&nbsp;
        Dreamland Amusement Park, Guwahati
    </div>
    <br />
         
    <br /><br />
    <div class="pagetext">
        TICKETS ON SALE
    </div>
     <table width="100%" cellpadding="0" cellspacing="0" class="pagetext">
        <tr>
             <td width="50%">
                <table style="width: 100%">
                    <tr>
                        <td  align="left"  valign="top" >                        
                            <table cellpadding="10" cellspacing="5" >
                                   <tr>
                                    <td>Couple</td>
                                    <td>
                                        <asp:DropDownList ID="ddlCoupleTicketno" runat="server" OnSelectedIndexChanged="ddlCoupleTicketno_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList></td>
                                    <td>* </td>
                                    <td>
                                        <asp:Label ID="lblCoupleTicketValue" runat="server" Text="2000"></asp:Label></td>
                                    <td>= </td>
                                    <td>
                                        Rs.<asp:Label ID="lblTotalValueCoupleTicket" runat="server" Text="0"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Stag Boy</td>
                                    <td>
                                        <asp:DropDownList ID="ddlSingleTicketno" runat="server" OnSelectedIndexChanged="ddlSingleTicketno_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList></td>
                                    <td>* </td>
                                    <td>
                                        <asp:Label ID="lblSingleTicketValue" runat="server" Text="1500"></asp:Label></td>
                                    <td>= </td>
                                    <td>
                                        Rs.<asp:Label ID="lblTotalValueSingleTicket" runat="server" Text="0"  style="text-align:right" ></asp:Label>
                                    </td>
                                </tr>
                              <tr>
                                    <td>Stag Girl</td>
                                    <td>
                                        <asp:DropDownList ID="ddlSingleGirlTicketno" runat="server"  AutoPostBack="true" OnSelectedIndexChanged="ddlSingleGirlTicketno_SelectedIndexChanged"></asp:DropDownList></td>
                                    <td>* </td>
                                    <td>
                                        <asp:Label ID="lblSingleGirlTicketValue" runat="server" Text="1200"></asp:Label></td>
                                    <td>= </td>
                                    <td>
                                        Rs.<asp:Label ID="lblTotalValueSingleGirlTicket" runat="server" Text="0"  style="text-align:right" ></asp:Label>
                                    </td>
                                </tr>
                             
                                   <tr>
                                    <td>Child</td>
                                    <td>
                                        <asp:DropDownList ID="ddlChildTicketno" runat="server" OnSelectedIndexChanged="ddlChildTicketno_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList></td>
                                    <td>* </td>
                                    <td>
                                        <asp:Label ID="lblChildTicketValue" runat="server" Text="500" ></asp:Label></td>
                                    <td>= </td>
                                    <td>
                                        Rs.<asp:Label ID="lblTotalValueChildTicket" runat="server" Text="0"></asp:Label>
                                    </td>
                                </tr>

                            </table>
                            <br /><br />
                            <div style=" background-color:lightblue; border-top:solid;border-bottom:solid">
                                <br />Total Ticket Value = Rs. <asp:Label ID="lblTotalTicketValue" runat="server" Text=""></asp:Label>
                                <br />    <br />                       
                            </div>
                            
                            <div>
                                 <div class="pagetext">
        Event Details </div>
         <ul>
            <li>Venue -Dreamland Amusement Park, Swadesh Nagar Path, Koinadhara, Khanapara, Guwahati Assam. Pin-781022</li>
            <li>Date and Time - 31st December 2016 - 4:30P.M onwards.</li>
            <li>Bollywood star Upen Patel</li>
            <li>Artist - DJ Aztec (Mumbai) AND DJ Poison (Guwahati)</li>
            <li>Complimentary dinner on the House with passes.</li>
            <li>Contact no. +91 91270-09340 / +91 70022-16352 </li>
        </ul>
    <br /><br />    <br /><br />    <br /><br /><br /><br />
           <div>Terms & Conditions </div>       
          <ul type="1">
            <li>Children  up to 3 ft height has free entry.</li>
            <li>Up to 4.5 ft height half the entry that is Rs 500 per kid .</li>
            <li>Intoxicated persons are not allowed to enter the park.</li>
            <li>Management will not be responsible for any injury / accident due to negligence of guests.</li>
            <li>Parents are advised to pay attention to their children.</li>
            <li>Food Beverage and alcoholic drinks are not allowed from outside. </li>
              <li>The management has the right to remove any person found misbehaving or with a misconduct</li>
               <li>You will be constantly under surveillance.</li>
            <li>Once sold pass can't be returned or cancelled. </li>
              <li>Any technical issues or defaults kindly cooperate.
</li>
        </ul>
                            </div>
                          
                    </td>
                </table>
                 <br />
                            <asp:Button ID="btnnext" runat="server" Text="Add To Cart" Height="43px" Width="203px" OnClick="btnnext_Click" Enabled="false"  visible="false" />
                            <br /><br />
              </td>
            <td width="50%">
                <table style="width: 100%">
                    <tr>
                        <td  align="right" >
                            <div>Customer Care :: +91-9435351122</div> <br />   
                            <img src="images/dreamland.png" height="750" style="width: 450px; margin-left: 0px; margin-top: 0px;"/>
                        
                    </td>
                </table>
              </td>
                   
               

        </tr>

    </table>

</asp:Content>




