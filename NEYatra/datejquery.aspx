<%@ Page Language="C#" AutoEventWireup="true" CodeFile="datejquery.aspx.cs" Inherits="datejquery" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%--<!doctype html>--%>
<html lang="en">
<head>
  <%--<meta charset="utf-8">--%>
    <title>BuyMyETicket.com</title>
    <%--<link id="Link1" runat="server" rel="shortcut icon" href="~/images/favicon.ico" type="image/x-icon" />
    <link id="Link2" runat="server" rel="icon" href="~/images/favicon.ico" type="image/ico" />
    <link href="style.css" rel="stylesheet" type="text/css" />
    <link href="style2.css" rel="stylesheet" type="text/css" />
    <link href="css/StyleSheet.css" rel="stylesheet" type="text/css" />--%>
  <link rel="stylesheet" href="//code.jquery.com/ui/1.11.1/themes/smoothness/jquery-ui.css">
  <script src="//code.jquery.com/jquery-1.10.2.js"></script>
  <script src="//code.jquery.com/ui/1.11.1/jquery-ui.js"></script>
  <link rel="stylesheet" href="/resources/demos/style.css">
   <script src="js/compressed.js" type="text/javascript"></script>
  <script>
  $(function() {
    $( "#datepicker" ).datepicker({
      showOn: "button",
      buttonImage: "images/calendar-icon.png",
      numberOfMonths: 2,
      buttonImageOnly: true,
      buttonText: "Select date",
      dateFormat: "dd-M-yy",
      showAnim:"blind",
      minDate: 0
      });
    });
  </script>
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

    <%--<script type="text/javascript">
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
    </script>--%>
</head>
<body>
<%--<script type="text/javascript">
    function ss() {
        var returnstatus = 1;
        var date_value = document.getElementById('<%=txtScheduleDate.ClientID %>').value;


           var isValid = IsValidDate(date_value);

           if (document.getElementById('<%=DropDownList4.ClientID %>').selectedIndex == 0 && document.getElementById('<%=DropDownList5.ClientID %>').selectedIndex == 0) {
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




    if (!isValid && date_value.length > 0) {
        alert('Please select date in dd-MMM-yyyy format e.g. 12-MAY-2013');
        document.getElementById('<%=txtScheduleDate.ClientID %>').value = '';
                    document.getElementById('<%=txtScheduleDate.ClientID %>').focus();
               returnstatus = 0;

           }



           if (returnstatus) {
               return true;
           }
           else {
               return false;
           }

       }


       //function IsValidDate(myDate) {
       //       var filter = /^([012]?\d|3[01])-([Jj][Aa][Nn]|[Ff][Ee][bB]|[Mm][Aa][Rr]|[Aa][Pp][Rr]|[Mm][Aa][Yy]|[Jj][Uu][Nn]|[Jj][u]l|[aA][Uu][gG]|[Ss][eE][pP]|[oO][Cc]|[Nn][oO][Vv]|[Dd][Ee][Cc])-(19|20)\d\d$/
       //        return filter.test(myDate);
       //     }
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
</script>--%>

<center>
        <form id="form1" runat="server"  >
       <%-- <asp:ScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ScriptManager>--%>
<p>Date: <asp:TextBox ID="datepicker" runat="server" Width="90px" ></asp:TextBox></p>
  <%--<div>
  <table width="963px" cellpadding="0" cellspacing="0">
      <tr>
          <td align="left" valign="top">
              <table cellpadding="0" cellspacing="0" width="100%">
                  <tr>
                      <td>
                          <asp:ImageButton ID="Image11" runat="server" ImageUrl="~/images/FinalLogo1.png" Style="margin-right: 0px"
                              />
                         
                      </td>
                      <td align="right">
                          <div>
                              <span>&nbsp;&nbsp;&nbsp;&nbsp;</span> <a href="Default.aspx">
                                  <img id="Img2" alt="" runat="server" src="~/images/home-icon.png" />
                                  Home</a>&nbsp; <a href="PrintTicket.aspx">Print Ticket</a>&nbsp; <a href="CancelTicket.aspx">
                                      Cancel Ticket</a>
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
                                          <iframe src="clock.aspx" width="240px" class="iframe" scrolling="no"></iframe>
                                      </td>
                                      <td align="right" style="width: 100px; height: 25px; padding-bottom: 0px">
                                          <a href="#" target="_blank">
                                              <asp:ImageButton ID="ImageButton5" runat="server" ImageUrl="~/images/facebook.png"
                                                  OnClientClick="openFB();" /></a> <a href="#" target="_blank">
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
    
  </table>
  </div>--%>
 </form>
 </center>
 <%--<script type="text/javascript" defer="defer" src="https://mylivechat.com/chatwidget.aspx?hccid=39752923"></script>
<script type="text/javascript" defer="defer" src="https://mylivechat.com/chatinline.aspx?hccid=39752923"></script>--%>
</body>
</html>

