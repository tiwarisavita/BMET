<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage2.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>

<%@ Register src="CarRental_datetime.ascx" tagname="DateTime" tagprefix="uc" %>

<%-- Add content controls here --%>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="Content1" runat="server">
    
     <script>
                Tabs
     
         function openLink(evt, linkName) {
             debugger;
            var i, x, tablinks;
            x = document.getElementsByClassName("myLink");
            for (i = 0; i < x.length; i++) {
                x[i].style.display = "none";
            }
            tablinks = document.getElementsByClassName("tablink");
            for (i = 0; i < x.length; i++) {
                tablinks[i].className = tablinks[i].className.replace(" w3-red", "");
            }
            document.getElementById(linkName).style.display = "block";
            evt.currentTarget.className += " w3-red";
        }
        // Click on the first tablink on load
        document.getElementsByClassName("tablink")[0].click();
    </script>
    <header class="w3-display-container w3-content w3-hide-small" style="max-width: 80%">
                                                                <table width="100%" __designer:mapid="5">
                                                                    <tr __designer:mapid="6">
                                                                        <td width="50%" __designer:mapid="7">
                                                                            <b __designer:mapid="8">Local City</b>
                                                                        </td>
                                                                        <td width="50%" __designer:mapid="9">
                                                                            <b __designer:mapid="a">for</b>
                                                                        </td>
                                                                    </tr>
                                                                    <tr __designer:mapid="b">
                                                                        <td width="50%" __designer:mapid="c">
                                                                            <asp:DropDownList runat="server" CssClass="dd" Width="140px" ID="ddlLocalSrc"></asp:DropDownList>


                                                                        </td>
                                                                        <td width="50%" __designer:mapid="e">
                                                                            <asp:DropDownList runat="server" CssClass="dd" Width="140px" ID="ddlLocalDuration"></asp:DropDownList>


                                                                        </td>
                                                                    </tr>
                                                                    <tr __designer:mapid="10">
                                                                        <td colspan="2" __designer:mapid="11">
                                                                            <uc:DateTime runat="server" ID="datetimeLocal"></uc:DateTime>


                                                                           
                                                                            
                                                                        </td>
                                                                    </tr>
                                                                    <tr __designer:mapid="13">
                                                                        <td colspan="2" align="center" __designer:mapid="14">
                                                                            <asp:Button runat="server" CausesValidation="False" Text="Search CAR" CssClass="text" ID="btn_LocalSearch" OnClick="btn_LocalSearch_Click"></asp:Button>


                                                                        </td>
                                                                    </tr>
                                                                    
                                                                    
                                                                </table>
                                                            
&nbsp;<div class="w3-display-middle" style="width: 65%">
            <div class="w3-bar w3-black">
                <button class="w3-bar-item w3-button tablink" onclick="openLink(event, 'Sumo');"><i class="fa fa-plane w3-margin-right"></i>Sumo</button>
                <button class="w3-bar-item w3-button tablink" onclick="openLink(event, 'Hotel');"><i class="fa fa-bed w3-margin-right"></i>Hotel</button>
                <button class="w3-bar-item w3-button tablink" onclick="openLink(event, 'Car');"><i class="fa fa-car w3-margin-right"></i>Rental</button>
            </div>

            <!-- Tabs -->
            <div id="Sumo" class="w3-container w3-white w3-padding-16 myLink">
                <h3>Travel the world with us</h3>
                <div class="w3-row-padding" style="margin: 0 -16px;">
                    <div class="w3-half">
                        <label>From</label>
                        <input class="w3-input w3-border" type="text" placeholder="Departing from">
                    </div>
                    <div class="w3-half">
                        <label>To</label>
                        <input class="w3-input w3-border" type="text" placeholder="Arriving at">
                    </div>
                </div>
                <p>
                    <button class="w3-button w3-dark-grey">Search and find dates</button></p>
            </div>

            <div id="Hotel" class="w3-container w3-white w3-padding-16 myLink">
                <h3>Find the best hotels</h3>
                <p>Book a hotel with us and get the best fares and promotions.</p>
                <p>We know hotels - we know comfort.</p>
                <p>
                    <button class="w3-button w3-dark-grey">Search Hotels</button></p>
            </div>

            <div id="Car" class="w3-container w3-white w3-padding-16 myLink">
                <h3>Best car rental in the world!</h3>
                <p><span class="w3-tag w3-deep-orange">DISCOUNT!</span> Special offer if you book today: 25% off anywhere in the world with CarServiceRentalRUs</p>
                <input class="w3-input w3-border" type="text" placeholder="Pick-up point">
                <p>
                    <button class="w3-button w3-dark-grey">Search Availability</button></p>
            </div>

        </div>


    </header>
</asp:Content>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder_Address" ID="Content2" runat="server">
   
        

   
</asp:Content>

   