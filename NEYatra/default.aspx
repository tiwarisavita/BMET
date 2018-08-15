 <%@ page language="C#" autoeventwireup="true" inherits="_Default"  CodeFile="~/default.aspx.cs" Title="BuyMyETicket.com :: Bus/Sumo Ticket Booking | Car Rental | Car Hire | Taxi/Cab Booking" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register TagPrefix="uc" TagName="DateTime" Src="~/CarRental_datetime.ascx"%>
    

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>BuyMyETicket.com :: Bus/Sumo Ticket Booking | Car Rental | Car Hire | Taxi/Cab
        Booking</title>
    <link id="Link1" runat="server" rel="shortcut icon" href="~/images/favicon.ico" type="image/x-icon" />
    <link id="Link2" runat="server" rel="icon" href="~/images/favicon.ico" type="image/ico" />
    <link href="style.css" rel="stylesheet" type="text/css" />
    <link href="style2.css" rel="stylesheet" type="text/css" />
    <script src="js/compressed.js" type="text/javascript"></script>
    <link href="css/StyleSheet.css" rel="stylesheet" type="text/css" />
    
    <%--<link href="tab-content/template1/tabcontent.css" rel="stylesheet" type="text/css" />--%>
    <link href="css/Ajaxtabcontent.css" rel="stylesheet" type="text/css" />
    <%--<script src="tab-content/tabcontent.js" type="text/javascript"></script>--%>

    

    <style type="text/css">
        .style1
        {
            font-size: 12px;
            font-family: Verdana Arial Sans-Serif;
            color: Purple;
            font-weight: bold;
            width: 13%;
            height: 41px;
        }
        .style2
        {
            width: 1.5%;
            height: 41px;
        }
        .style3
        {
            background-image: url(  'images/center-line-url.png' );
            background-repeat: no-repeat;
            padding-top: 4px;
            height: 185px;
            width: 23%;
        }
      </style>

    <script type="text/javascript">
        function CheckDateEalier(sender, args) {
            if (sender._selectedDate < new Date()) {
                alert("You cannot select a day before today!");
                sender._selectedDate = new Date();
                // set the date back to the today
                sender._textbox.set_Value(sender._selectedDate.format(sender._format))
            }
        }
        function DisplayDateToday(sender, args) {
            if (sender._selectedDate == null) {
                sender._selectedDate = new Date();
            }
        }
    </script>

</head>
<body>
<script type="text/javascript">
    function ss() {
        var returnstatus = 1;
        var date_value = document.getElementById('<%=txtScheduleDate.ClientID %>').value;
           var isValid = IsValidDate(date_value);

           if (document.getElementById('<%=DropDownList4.ClientID %>').selectedIndex == 0 && document.getElementById('<%=DropDownList5.ClientID %>').selectedIndex == 0)
           {
               alert("Please select Source And Destination");
               returnstatus = 0;
           }
           else if (document.getElementById('<%=DropDownList4.ClientID %>').selectedIndex == 0 && document.getElementById('<%=DropDownList5.ClientID %>').selectedIndex != 0) {
               alert("Please select Source");
               returnstatus = 0;
           }
           else if (document.getElementById('<%=DropDownList4.ClientID %>').value == document.getElementById('<%=DropDownList5.ClientID %>').value) {
               alert("Source and destination cannot be same.Please select either one.");
               returnstatus = 0;
           }
           else if (document.getElementById('<%=DropDownList4.ClientID %>') != 0 && document.getElementById('<%=DropDownList5.ClientID %>').selectedIndex == 0) {
               alert("Please select Destination");
               returnstatus = 0;
           }
           else if (date_value.length == 0) {
               alert("Please fill The Date");
               document.getElementById('<%=txtScheduleDate.ClientID %>').focus();
           returnstatus = 0;
       }




//    if (!isValid && date_value.length > 0) {
//        alert('Please select date in dd-MMM-yyyy format e.g. 12-MAY-2013');
//        document.getElementById('<%=txtScheduleDate.ClientID %>').value = '';
//                    document.getElementById('<%=txtScheduleDate.ClientID %>').focus();
//               returnstatus = 0;

//           }



           if (returnstatus) {
               return true;
           }
           else {
               return false;
           }

       }


//      function IsValidDate(myDate) {
//             var filter = /^([012]?\d|3[01])-([Jj][Aa][Nn]|[Ff][Ee][bB]|[Mm][Aa][Rr]|[Aa][Pp][Rr]|[Mm][Aa][Yy]|[Jj][Uu][Nn]|[Jj][u]l|[aA][Uu][gG]|[Ss][eE][pP]|[oO][Cc]|[Nn][oO][Vv]|[Dd][Ee][Cc])-(19|20)\d\d$/
//              return filter.test(myDate);
//           }
           
       function SaveNow() {
     var name = document.getElementById('<%=txtName.ClientID %>').value;
     var emailid = document.getElementById('<%=txtEmail.ClientID %>').value;
     var address = document.getElementById('<%=txtAddress.ClientID %>').value;
     var mobno = document.getElementById('<%=txtPhone.ClientID%>').value;
     var letters = /^[A-Za-z ]+$/;
     var mailformat = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
     var letters1 = /^[-0-9a-zA-Z ,:]+$/;
     var no = /^[0-9]{10}$/;

     if (name.length == 0) {
         alert('Please Enter your name');
         return false;
     }
     else if (!name.match(letters)) {
         alert('Name must have alphabet characters only');
         return false;
     }
     else if (emailid.length == 0) {
         alert('Please Enter Your Email ID');
         return false;
     }
     else if (!emailid.match(mailformat)) {
         alert("You have entered an invalid email address!");
         return false;
     }
     else if (address.length == 0) {
         alert('Please Enter Your Address');
         return false;
     }
     else if (!address.match(letters1)) {
         alert("Address must have alphanumeric characters and '-',',',':' only");
         return false;
     }
     else if (mobno.length == 0) {
         alert('Please Enter Your Mobile number');
         return false;
     }
     else if (!mobno.match(no)) {
         alert('Mobile Number must have ten digits only');
         return false;
     }
     else if (document.getElementById('<%=ddlAgentuser.ClientID %>') != 0 && document.getElementById('<%=ddlAgentuser.ClientID %>').selectedIndex == 0) {
                    alert('Please select User type');
                    return false;
                }

    return true;

}
function openFB() {
    var url = "https://www.facebook.com/Buymyeticket";
    window.open("'" + url + "'", '_blank', 'height=900,width=800,status=yes,toolbar=no,menubar=no,location=yes,scrollbars=yes,resizable=no,titlebar=no');
}
 
</script>
  
    <center>
        <form id="form1" runat="server"  method="post">
        <asp:ScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ScriptManager>
        <div>
            <table width="963px" cellpadding="0" cellspacing="0">
                <tr>
                    <td align="left" valign="top">
                        <table cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td>
                                    <asp:ImageButton ID="Image11" runat="server" ImageUrl="~/images/FinalLogo1.png" Style="margin-right: 0px"
                                         onclick="Image11_Click" />
                                        <%--<p align="right">Beta</p>--%>
                                </td>
                                <td align="right">
                                    <div>
                            <span>&nbsp;&nbsp;&nbsp;&nbsp;</span>
                            
                                        <a href="Default.aspx"><img id="Img2" alt="" runat="server" src="~/images/home-icon.png" />
                                        Home</a>&nbsp; <a href="PrintTicket.aspx">Print Ticket</a>&nbsp;
                                        <a href="CancelTicket.aspx">Cancel Ticket</a>
                                    </div>
                                    <div>
                                        <table cellpadding="0" cellspacing="0" style="width: 250px; height: 30px">
                                            <tr>
                                                <td align="right">
                                                    <table cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td rowspan="2">
                                                                <img id="Img3" alt="" runat="server" src="~/images/contct-us.png" />
                                                            </td>
                                                            <td class="font" align="right">
                                                                Phone No: +91-9435351122
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="font" align="right" valign="top">
                                                                  +91-9435173561
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div>
                                        <table cellpadding="0" cellspacing="0" width="340px">
                                            <tr>
                                                <td align="left" style="width: 240px; height: 25px">
                                                    <iframe src="clock.aspx" class="iframe" scrolling="no"></iframe>
                                                </td>
                                                <td align="right" style="width: 100px; height: 25px; padding-bottom: 0px">
                                                    <a href="#" target="_blank">                                                   
                                                        <asp:ImageButton ID="ImageButton5" runat="server" 
                                                        ImageUrl="~/images/facebook.png"  OnClientClick="openFB();"/></a>
                                                    <a href="#" target="_blank">
                                                        <asp:ImageButton ID="ImageButton7" runat="server" ImageUrl="~/images/t.png" /></a>
                                                    <a href="#" target="_blank">
                                                        <asp:ImageButton ID="ImageButton8" runat="server" ImageUrl="~/images/in.png" /></a>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td class="menu" style="height: 39px">
                        <table width="100%" cellpadding="0" cellspacing="0" class="menu" style="height: 39px">
                            <tr>
                                <td align="center" class="style1">
                                    <a href="Default.aspx">Home</a>
                                </td>
                                <td class="style2">
                                    <img alt="" id="Img7" runat="server" src="images/menu-line.png" />
                                </td>
                                <td align="center" class="style1">
                                    <a href="CarRental.aspx">Car Rental</a>
                                </td>
                                <td class="style2">
                                    <img alt="" id="Img8" runat="server" src="images/menu-line.png" />
                                </td>
                                <td align="center" class="style1">
                                    <a href="RouteFare.aspx">Route Fare</a>
                                </td>
                                <td class="style2">
                                    <img alt="" id="Img13" runat="server" src="images/menu-line.png" />
                                </td>
                                <td align="center" class="style1">
                                    <a href="Event.aspx">Events</a>
                                </td>
                                <td class="style2">
                                    <img alt="" id="Img14" runat="server" src="images/menu-line.png" />
                                </td>
                                <td align="center" class="style1">
                                    <a href="ContactUs.aspx">Contact Us</a>
                                </td>
                                <td class="style2">
                                    <img alt="" id="Img1" runat="server" src="images/menu-line.png" />
                                </td>
                                <td align="center" class="style1">
                                    <a href="AboutUs.aspx">About Us</a>
                                </td>
                               <td class="style2">
                                    <img alt="" id="Img9" runat="server" src="images/menu-line.png" />
                                </td>
                                <td align="center" class="style1">
                                    <a href="FranchiseeList.aspx">Our Franchisees</a>
                                </td>
                                </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="width: 100%; height: 3px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <table width="100%" cellpadding="0" cellspacing="0">
                            <tr>
                                <td class="bgimage" style="width: 225px; height: 250px;">
                                    <table border="0" cellpadding="0" cellspacing="0" class="text" style="height: 250px;
                                        width: 215px; padding: 6px 2px 20px 8px">
                                        <tr>
                                            <td colspan="2" class="text" align="center">
                                                BUS/SUMO SEARCH
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="text" style="width: 80px; text-align: left;">
                                                Source
                                            </td>
                                            <td align="left" style="width: 135px">
                                                <asp:DropDownList ID="DropDownList4" runat="server" Width="130px" CssClass="dd">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 80px; text-align: left;">
                                                Destination&nbsp;
                                            </td>
                                            <td align="left" style="width: 135px">
                                                <asp:DropDownList ID="DropDownList5" runat="server" Width="130px" CssClass="dd">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 80px; text-align: left;">
                                                Mode
                                            </td>
                                            <td style="text-align: left; width: 135px">
                                                <asp:DropDownList ID="DropDownList6" runat="server" Width="130px" CssClass="dd">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left; width: 80px">
                                                Travel Date
                                            </td>
                                            <td style="width: 135px;">
                                                <div style="position: relative; z-index: 999">
                                                    <asp:TextBox ID="txtScheduleDate" runat="server" Width="90px" CssClass="dd-tb"></asp:TextBox>
                                                    <asp:ImageButton ID="btnDate5" ImageUrl="~/images/calendar-icon.png" Width="20px"
                                                        Height="20px" runat="server" CausesValidation="false" />
                                                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MMM-yyyy"
                                                        Animated="true" TargetControlID="txtScheduleDate" PopupButtonID="btnDate5" OnClientDateSelectionChanged="CheckDateEalier"
                                                        OnClientShowing="DisplayDateToday" PopupPosition="BottomLeft" CssClass="AjaxCalendar">
                                                    </asp:CalendarExtender>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" align="center">
                                                <asp:Button ID="btn_bestdeal" runat="server" CssClass="text" Text="BestDeal" OnClick="btn_bestdeal_Click"
                                                    OnClientClick="return ss()" />&nbsp;
                                                <asp:Button ID="btn_search" runat="server" CssClass="text" Text="Search" OnClick="btn_search_Click"
                                                    OnClientClick="return ss()" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td align="left" style="border-radius:5px 5px 5px 5px;">
                                    <ul id="slideshow" style="display: none;">
                                        <li>
                                            <h3>
                                                Welcome to BuyMyETicket</h3>
                                            <span>images/amer-palace_Rajasthan.jpg</span>
                                            <p class="MsoNormal">
                                                Pioneer site to buy tickets instantly & book cabs.<span style="font-family: Wingdings;
                                                    mso-ascii-font-family: Calibri; mso-ascii-theme-font: minor-latin; mso-hansi-font-family: Calibri;
                                                    mso-hansi-theme-font: minor-latin; mso-char-type: symbol; mso-symbol-font-family: Wingdings"><span
                                                        style="mso-char-type: symbol; mso-symbol-font-family: Wingdings">J</span></span><o:p></o:p></p>
                                            <%--<a href="#">
                                                <img alt="" src="images/amer-palace_Rajasthan.png" /></a>--%>
                                        </li>
                                        <li>
                                            <h3>
                                                Welcome to BuyMyETicket</h3>
                                            <span>images/beach.jpg</span>
                                            <p class="MsoNormal">
                                                Get best deals & maximum discount guaranteed. <span style="font-family: Wingdings;
                                                    mso-ascii-font-family: Calibri; mso-ascii-theme-font: minor-latin; mso-hansi-font-family: Calibri;
                                                    mso-hansi-theme-font: minor-latin; mso-char-type: symbol; mso-symbol-font-family: Wingdings">
                                                    <span style="mso-char-type: symbol; mso-symbol-font-family: Wingdings">J</span></span><o:p></o:p></p>
                                            <%--<a href="#">
                                                <img alt="" src="images/beach.png" /></a>--%>
                                        </li>
                                        <li>
                                            <h3>
                                                Welcome to BuyMyETicket</h3>
                                            <span>images/DSCF2614pp.jpg</span>
                                            <p class="MsoNormal">
                                                Pioneer site to buy instant ticket. <span style="font-family: Wingdings; mso-ascii-font-family: Calibri;
                                                    mso-ascii-theme-font: minor-latin; mso-hansi-font-family: Calibri; mso-hansi-theme-font: minor-latin;
                                                    mso-char-type: symbol; mso-symbol-font-family: Wingdings"><span style="mso-char-type: symbol;
                                                        mso-symbol-font-family: Wingdings">J</span></span><o:p></o:p></p>
                                            <%--<a href="#">
                                                <img alt="" src="images/DSCF2614pp.png" /></a>--%>
                                        </li>
                                        <li>
                                            <h3>
                                                Welcome to BuyMyETicket</h3>
                                            <span>images/Bus.jpg</span>
                                            <p class="MsoNormal">
                                                Pioneer site to buy instant ticket <span style="font-family: Wingdings; mso-ascii-font-family: Calibri;
                                                    mso-ascii-theme-font: minor-latin; mso-hansi-font-family: Calibri; mso-hansi-theme-font: minor-latin;
                                                    mso-char-type: symbol; mso-symbol-font-family: Wingdings"><span style="mso-char-type: symbol;
                                                        mso-symbol-font-family: Wingdings">J</span></span><o:p></o:p></p>
                                            <%--  <a href="#">
                                                <img alt="" src="images/snow on mountain.png" /></a>--%>
                                        </li>
                                        <li>
                                            <h3>
                                                Welcome to BuyMyETicket</h3>
                                            <span>images/taj_mahal_01.jpg</span>
                                            <p class="MsoNormal">
                                                Pioneer site to buy instant ticket <span style="font-family: Wingdings; mso-ascii-font-family: Calibri;
                                                    mso-ascii-theme-font: minor-latin; mso-hansi-font-family: Calibri; mso-hansi-theme-font: minor-latin;
                                                    mso-char-type: symbol; mso-symbol-font-family: Wingdings"><span style="mso-char-type: symbol;
                                                        mso-symbol-font-family: Wingdings">J</span></span><o:p></o:p></p>
                                            <%-- <a href="#">
                                                <img alt="" src="images/taj_mahal_01.png" /></a> --%></li>
                                        <li>
                                            <h3>
                                                Welcome to BuyMyETicket</h3>
                                            <span>images/Kasargod.jpg</span>
                                            <p class="MsoNormal">
                                                Pioneer site to buy instant ticket <span style="font-family: Wingdings; mso-ascii-font-family: Calibri;
                                                    mso-ascii-theme-font: minor-latin; mso-hansi-font-family: Calibri; mso-hansi-theme-font: minor-latin;
                                                    mso-char-type: symbol; mso-symbol-font-family: Wingdings"><span style="mso-char-type: symbol;
                                                        mso-symbol-font-family: Wingdings">J</span></span><o:p></o:p></p>
                                            <%--<a href="#">
                                                <img alt="" src="images/Kasargod.png" /></a>--%>
                                        </li>
                                    </ul>
                                    <div id="wrapper" style="display: block;">
                                        <div id="fullsize">
                                            <div id="imgprev" class="imgnav" title="Previous Image">
                                            </div>
                                            <div id="imglink" style="cursor: pointer;" class="">
                                            </div>
                                            <div id="imgnext" class="imgnav" title="Next Image">
                                            </div>
                                            <div id="image">
                                                <img alt="" src="" />
                                                <img alt="" src="" />
                                            </div>
                                            <div id="information" style="height: 71px; left: 0px;">
                                                <h3>
                                                    Welcome to BuyMyETicket</h3>
                                                <p class="MsoNormal">
                                                    Pioneer site to buy instant ticket <span style="font-family: Wingdings; mso-ascii-font-family: Calibri;
                                                        mso-ascii-theme-font: minor-latin; mso-hansi-font-family: Calibri; mso-hansi-theme-font: minor-latin;
                                                        mso-char-type: symbol; mso-symbol-font-family: Wingdings"><span style="mso-char-type: symbol;
                                                            mso-symbol-font-family: Wingdings">J</span></span><o:p></o:p></p>
                                                <p>
                                                    &nbsp;</p>
                                            </div>
                                        </div>
                                    </div>

                                    <script type="text/javascript" src="js/compressed.js"></script>

                                    <script type="text/javascript">
                                        $('slideshow').style.display = 'none';
                                        $('wrapper').style.display = 'block';
                                        var slideshow = new TINY.slideshow("slideshow");
                                        window.onload = function () {
                                            slideshow.auto = true;
                                            slideshow.speed = 5;
                                            slideshow.link = "linkhover";
                                            slideshow.info = "information";
                                            slideshow.scrollSpeed = 4;
                                            slideshow.spacing = 5;
                                            slideshow.active = "#fff";
                                            slideshow.init("slideshow", "image", "imgprev", "imgnext", "imglink");
                                        }
                                    </script>

                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td style="width: 745px" align="left" valign="top">
                                    <table width="745px" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td colspan="2" style="width: 50%; padding-left: 0px; padding-right:7px; height: 154px;  padding-bottom:10px" align="justify"
                                                valign="top">
                                                <div>
                                                    <%--<table id="Fran_info" style="display: block;" width="100%" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <asp:UpdatePanel ID="UpdMsg" runat="server" UpdateMode="Conditional">
                                                                    <ContentTemplate>
                                                                        <table>
                                                                            <tr>
                                                                                <td class="text">
                                                                                    <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </ContentTemplate>
                                                                    <Triggers>
                                                                        <asp:AsyncPostBackTrigger ControlID="TabContainer1$Local$btn_LocalSearch" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="TabContainer1$Outstation$btn_OutstationSearch" EventName="Click" />                            
                        <asp:AsyncPostBackTrigger ControlID="TabContainer1$Airport$btn_AirportSearch" EventName="Click" />
                                                                        
                                                                    </Triggers>
                                                                </asp:UpdatePanel>
                                                            </td>
                                                        </tr>
                                                    </table>--%>
                                                 <asp:UpdatePanel ID="upd_CarRental" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                    <asp:TabContainer ID="TabContainer1" runat="server" Height="154px" Visible="true"
                                                        CssClass="CustomTabStyle" ActiveTabIndex="0">
                                                        <asp:TabPanel ID="Local" runat="server" HeaderText="Local"><HeaderTemplate>
                                                                Local
                                                            
</HeaderTemplate>
<ContentTemplate>
                                                                <table width="100%">
                                                                    <tr>
                                                                        <td width="50%">
                                                                            <b>Local City</b>
                                                                        </td>
                                                                        <td width="50%">
                                                                            <b>for</b>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td width="50%">
                                                                            <asp:DropDownList ID="ddlLocalSrc" runat="server" Width="140px" CssClass="dd"></asp:DropDownList>

                                                                        </td>
                                                                        <td width="50%">
                                                                            <asp:DropDownList ID="ddlLocalDuration" runat="server" Width="140px" CssClass="dd"></asp:DropDownList>

                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2">
                                                                            <uc:DateTime ID="datetimeLocal" runat="server" />

                                                                           
                                                                            
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2" align="center">
                                                                            <asp:Button ID="btn_LocalSearch" CausesValidation="False" runat="server" CssClass="text"
                                                                                Text="Search CAR" onclick="btn_LocalSearch_Click"/>

                                                                        </td>
                                                                    </tr>
                                                                    
                                                                    
                                                                </table>
                                                            
</ContentTemplate>
</asp:TabPanel>
                                                        <asp:TabPanel ID="Outstation" runat="server" HeaderText="Outstation"><ContentTemplate>
                                                                <table width="100%">
                                                                    <tr>
                                                                        <td width="50%">
                                                                            <b>Source</b>
                                                                        </td>
                                                                        <td width="50%">
                                                                            <b>Destination</b>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td width="50%">
                                                                            <asp:DropDownList ID="ddlOutstationSrc" runat="server" Width="140px" CssClass="dd">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td width="50%">
                                                                            <asp:DropDownList ID="ddlOutstationDes" runat="server" Width="140px" CssClass="dd">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                 
                                                                    <tr>
                                                                        <td colspan="2">
                                                                            <uc:DateTime ID="datetimeOutStation" runat="server" />
                                                                        </td>
                                                                    </tr>
                                                                       <tr>
                                                                        <td width="50%">
                                                                            <asp:RadioButton ID="rd_Oneway" runat="server"   GroupName="travelmode" Text="One Way Trip" Font-Bold="true" Checked="true"/>
                                                                        </td>
                                                                        <td width="50%">
                                                                            <asp:RadioButton ID="rd_RoundTrip" runat="server" GroupName="travelmode" Text="Round Trip" Font-Bold="true"/>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2" align="center">
                                                                            <asp:Button ID="btn_OutstationSearch" CausesValidation="false" runat="server" CssClass="text"
                                                                                Text="Search CAR" onclick="btn_OutstationSearch_Click" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            
</ContentTemplate>
</asp:TabPanel>
                                                        <asp:TabPanel ID="Airport" runat="server" HeaderText="Airport Transfer"><ContentTemplate>
                                                                <table width="100%">
                                                                    <tr>
                                                                        <td width="50%">
                                                                            <b>Airport City</b>
                                                                        </td>
                                                                        <td width="50%">
                                                                            <b>Pickup/Drop</b>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td width="50%">
                                                                            <asp:DropDownList ID="ddlAirportCity" runat="server" Width="140px" CssClass="dd">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td width="50%">
                                                                            <asp:DropDownList ID="ddlPickupDrop" runat="server" Width="140px" CssClass="dd">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2">
                                                                            <uc:DateTime ID="datetimeAirport" runat="server" />
                                                                        </td>
                                                                    </tr>
                                                                     <tr>
                                                                        <td colspan="2" align="center">
                                                                            <asp:Button ID="btn_AirportSearch" CausesValidation="False" runat="server" CssClass="text"
                                                                                Text="Search CAR" onclick="btn_AirportSearch_Click"  />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            
</ContentTemplate>
</asp:TabPanel>
                                                    </asp:TabContainer>
                                                    </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                   
                                                </div>
                                            </td>
                                            
                                            <td colspan="2" style="width: 50%; padding-right: 7px; height: 180px; padding-bottom:10px;"  align="center" valign="top">
                                               
                                               <img src="images/car2.JPG"  height="180px" width="370px"/>
                                            </td>
                                        </tr>
                                        <tr style="height:200px">
                                            <td style="width: 25%;" class="center-line" align="left"
                                                valign="top">
                                                <%--<b>Home Delivery</b><br />
                                                <br />--%>
                                                <a href="Event.aspx"><asp:Image ID="Image1" runat="server" ImageUrl="~/images/ElectroNight.jpg" Width="190px"
                                                    Height="180px" /></a>
                                                <%--<br />
                                                <span>Routes where home<br />
                                                    delivery facility<br />
                                                    is available...</span><br />
                                                <a href="MoreInfo.aspx">
                                                    <img src="images/more_info.png" /></a>--%>
                                                <%--<asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="images/more_info.png"
                                                    OnClientClick="moreinfo()" />--%>
                                            </td>
                                            <td style="width: 25%; padding-right: 2px; height: 150px" class="center-line" align="center"
                                                valign="top">
                                                <b>Partners</b>
                                                <br />
                                                <br />
                                                <asp:Image ID="Image2" runat="server" ImageUrl="~/images/partner.png" Width="150px"
                                                    Height="70px" />
                                                <br />
                                                Partners of the company<br />
                                                <br />
                                                &nbsp;<br />
                                                <a href="MoreInfo.aspx">
                                                    <img src="images/more_info.png" /></a>
                                                <%--<asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="images/more_info.png"
                                                    OnClientClick="moreinfo()" />--%>
                                            </td>
                                            <td style="width: 25%; padding-right: 5px; height: 150px" class="center-line" align="center"
                                                valign="top">
                                                <b>Hot Deals</b><br />
                                                <br />
                                                <asp:Image ID="Image4" runat="server" ImageUrl="~/images/Hot Deals 3.png" Width="150px"
                                                    Height="70px" />
                                                <br />
                                                Avail maximum discount
                                                <br />
                                                offers in the market...<br />
                                                <br />
                                                <a href="MoreInfo.aspx">
                                                    <img src="images/more_info.png" /></a>
                                                <%-- <asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="images/more_info.png"
                                                    OnClientClick="moreinfo()" />--%>
                                            </td>
                                            <td style="width: 25%; padding-right: 5px; height: 150px" class="center-line" align="center" valign="top">
                                                <b>Agent Registration</b><br />
                                                <br />
                                                <asp:Image ID="Image5" runat="server" ImageUrl="~/images/agentreg.jpg" Width="120px"
                                                    Height="80px" />
                                                <br />
                                                <br />
                                                <span style="text-align: justify">For more info please call on +91 9435173561 or mail
                                                    at info@buymyeticket.com</span><br />
                                                <%--<a href="MoreInfo.aspx"><img src="images/more_info.png" /></a>
                                                <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="images/more_info.png"
                                                    OnClientClick="moreinfo()" />--%>
                                            </td>
                                            
                                        </tr>
                                    </table>
                                   
                                </td>
                                <td style="width: 218px;" align="right" valign="top">

                                 
                                    
                             
                                               <table width="218px" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td class="freedemo" align="center" valign="bottom">
                                                            <div>
                                                                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                                                    <ContentTemplate>
                                                                        <table cellpadding="0" cellspacing="0" style="height: 200px; width: 100%; padding: 15px 10px 6px 10px">
                                                                            <caption>
                                                                                <br />
                                                                                <tr>
                                                                                    <td align="left" class="text" style="height: 15px">
                                                                                        <b>Name</b>&nbsp;
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                                                                            ControlToValidate="txtName" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                                                    </td>
                                                                                    <td align="left" style="width: 50%">
                                                                                        <asp:TextBox ID="txtName" runat="server" Width="130px"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="left" class="text" style="height: 15px">
                                                                                        <b>Phone</b>&nbsp;
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                                                                            ControlToValidate="txtPhone" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                                                    </td>
                                                                                    <td align="left" style="width: 50%">
                                                                                        <asp:TextBox ID="txtPhone" runat="server" Width="130px"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="left" class="text" style="width: 50%">
                                                                                        <b>E-mail</b>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                                                                            ControlToValidate="txtEmail" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                                                                                            ControlToValidate="txtEmail" ErrorMessage="*" 
                                                                                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                                                                    </td>
                                                                                    <td align="left" style="width: 50%">
                                                                                        <asp:TextBox ID="txtEmail" runat="server" Width="130px"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="left" class="text" style="width: 50%">
                                                                                        <b>Address</b>&nbsp;
                                                                                    </td>
                                                                                    <td align="left" style="width: 50%">
                                                                                        <asp:TextBox ID="txtAddress" runat="server" MaxLength="255" Width="130px"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="left" class="text" style="width: 50%">
                                                                                        <b>City</b>&nbsp;
                                                                                    </td>
                                                                                    <td align="left" style="width: 50%">
                                                                                        <asp:TextBox ID="txtCity" runat="server" Width="130px"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="left" class="text" style="width: 50%">
                                                                                        <b>State</b>&nbsp;
                                                                                    </td>
                                                                                    <td align="left" style="width: 50%">
                                                                                        <asp:TextBox ID="txtState" runat="server" Width="130px"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="left" class="text" style="width: 50%">
                                                                                        <b>User</b>&nbsp;
                                                                                    </td>
                                                                                    <td align="left" style="width: 50%">
                                                                                        <asp:DropDownList ID="ddlAgentuser" runat="server" Width="134px">
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 50%">
                                                                                        <asp:Label ID="errormessage" runat="server"></asp:Label>
                                                                                    </td>
                                                                                    <td align="left" style="width: 50%"><br />
                                                                                        <asp:Button ID="btnSave" runat="server" CssClass="text" Height="23px" 
                                                                                            OnClick="btnSave_Click" OnClientClick="return SaveNow()" Text="Submit" />
                                                                                    </td>
                                                                                </tr>
                                                                            </caption>
                                                                        </table>
                                                                    </ContentTemplate>                                                               
                                                                </asp:UpdatePanel>
                                                            </div>
                                                            <br />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="Reviews" style="width: 218px; height: 140px;">
                                                            <br />
                                                            <p style="text-align: justify; width: 180px; margin-left: 20px; height: 94px; margin-bottom: 0px;
                                                                margin-right: 5px;">
                                                                Earlier one has to go in person to enquire about route, availability & buy ticket,
                                                                it was tedious & time consuming.Now I can do all that in minute’s time & get the
                                                                best deal too.
                                                                <br />
                                                                <b>-Manoj Kanti Dhar</b>
                                                            </p>
                                                        </td>
                                                    </tr>
                                                </table> 
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td class="footer" style="height: 12px">
                    </td>
                </tr>
                <tr>
                    <td style="height: 30px" align="center">
                        <a href="Default.aspx">Home</a><span>&nbsp;&nbsp;::&nbsp;&nbsp;</span> <a href="PrintTicket.aspx">
                            Print Ticket</a><span>&nbsp;&nbsp;::&nbsp;&nbsp;</span><a href="CancelTicket.aspx">
                            Cancel Ticket</a><span>&nbsp;&nbsp;::&nbsp;&nbsp;</span> <a href="refundcancel.aspx">
                                Refund & Cancellation Policy</a><span>&nbsp;&nbsp;::&nbsp;&nbsp;</span>
                        <a href="termsncon.aspx">Terms & Conditions</a><span>&nbsp;&nbsp;::&nbsp;&nbsp;</span>
                        <a href="privacypolicy.aspx">Privacy Policy</a><span>&nbsp;&nbsp;::&nbsp;&nbsp;</span>
                        <a href="AboutUs.aspx">About Us</a><span>&nbsp;&nbsp;::&nbsp;&nbsp;</span> <a href="ContactUs.aspx">
                            Contact Us</a><span>&nbsp;&nbsp;::&nbsp;&nbsp;</span><a href="Login.aspx">For Clients</a>
                    </td>
                </tr>
                <br />
                <tr>
                    <td style="height: 30px" align="center">
                        &copy;2015 <span class="text">BuyMyETicket, N E Rhythm Tour & Tech P LTD. </span>
                        All rights reserved.
                    </td>
                </tr>
            </table>
        </div>
       
        </form>
    </center>
<script type="text/javascript" defer="defer" src="https://mylivechat.com/chatwidget.aspx?hccid=39752923"></script>
<script type="text/javascript" defer="defer" src="https://mylivechat.com/chatinline.aspx?hccid=39752923"></script>
</body>
</html>
