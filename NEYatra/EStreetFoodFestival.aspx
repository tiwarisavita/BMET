<%@ Page Language="C#" MasterPageFile="~/Master/MasterPage2.master" AutoEventWireup="true" CodeFile="EStreetFoodFestival.aspx.cs" Inherits="EStreetFoodFestival" Title="Buymyeticket.com :: E-Street Food Festival 2017" %>

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
    <div class="large">TEZPUR YOUTH FEAST-2017, TEZPUR -  9th January 2017 - 3 PM onwards <br />
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
                                        <asp:Label ID="lblCoupleTicketValue" runat="server" Text="200"></asp:Label></td>
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
            <li>Venue -- Bam Parbatiya Field, Opp.Rupam Petrol Pump, Tezpur, Sonitpur, Assam.</li>
            <li>Date and Time - 9th January 2017 - 3P.M onwards</li>
             <li>Contact No - +918134834888</li>
            <li><b>Artists - DJ Rugerio (Shillong), DJ Brahmin (Guwahati)</b></li>
            
           </ul>
                                </p>      
<br /><br /><br /><br /><br /><br />
           <p  class="pagetext"><b>Terms & Conditions</b>
          <ul>
            <li>Children up to 3 ft height has free entry.</li>
            <li>Intoxicated persons are not allowed to enter the event.</li>
            <li>Management will not be responsible for any injury / accident due to negligence of guests.</li>
            <li>Parents are advised to pay attention to their children.</li>
            <li>Food Beverage and alcoholic drinks are not allowed from outside.</li>
            <li>The management has the right to remove any person found misbehaving or with a misconduct.</li>
            <li>You will be constantly under surveillance.</li>
              <li>Once sold pass cannot be returned or cancelled.</li>
              <li>Any technical issues or defaults kindly cooperate.</li>
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
                        <td  align="right" >
                            <div>Customer Care :: +91-9435351122</div> <br />   
                            <img src="images/tezpur_event.png" height="550" style="width: 500px; margin-left: 0px; margin-top: 0px;"/>
                        
                    </td>
                </table>
              </td>
                   
               

        </tr>

    </table>

</asp:Content>




