<%@ Page Language="C#" MasterPageFile="~/Master/MasterPage2.master" AutoEventWireup="true" CodeFile="CancelTicket.aspx.cs" Inherits="CancelTicket" Title="BuyMyETicket :: Cancel Ticket" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 <link href="style.css" rel="stylesheet" type="text/css" />
  <script type="text/javascript">
 function paynow() {
            var txtticketno = document.getElementById('<%=txtticketno.ClientID %>').value;  
         
            var mobno = document.getElementById('<%=txtMobile.ClientID%>').value;

            var letters = /^[A-Za-z ]+$/;
            var mailformat = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
            var letters1 = /^[-0-9a-zA-Z ,:]+$/;
            var no = /^[0-9]{10}$/;
            
            if (txtticketno.length == 0) {
                alert('Please enter  ticketno. ');
               return false;
            }
       
            else if (!txtticketno.match(letters1)) {
                alert("Ticket no. must have alphanumeric characters and '-',',',':' only");
                return false;
                }
            else if (mobno.length == 0) {
                alert('Please Enter  Mobile number');
                return false;
                }
            else if (!mobno.match(no)) {
                alert('Mobile Number must have ten digits only');
                return false;        
                }
            return true;
           
        }  
        function paybankdetails() {
            var name = document.getElementById('<%=txtAccholderName.ClientID %>').value;
            var bankname=document.getElementById('<%=txtBankName.ClientID %>').value;
            var accno = document.getElementById('<%=txtAccountno.ClientID %>').value;
            var emailid = document.getElementById('<%=txtEmailID.ClientID %>').value;            
            var mobno = document.getElementById('<%=txtMobno.ClientID%>').value;

            var letters = /^[A-Za-z ]+$/;
            var mailformat = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
            var letters1 = /^[-0-9a-zA-Z ,:]+$/;
            var no = /^[0-9]{10}$/;
            
            
            if (name.length == 0) {
                alert('Please enter Account Holder Name');
                return false;
            }
            else if (!name.match(letters)) {
                alert('Name must have alphabet characters only');
                return false;
                }
              if (bankname.length == 0) {
                alert('Please enter Bank name');
                return false;
            }
            else if (!bankname.match(letters)) {
                alert('Bank Name must have alphabet characters only');
                return false;
                }   
            else if (accno.length == 0) {
                alert('Please Enter Bank Account No.');
                return false;
                }
            else if (mobno.length == 0) {
                alert('Please Enter Mobile number');
                return false;
                }
            else if (!mobno.match(no)) {
                alert('Mobile Number must have ten digits only');
                return false;        
                }
            else if (emailid.length == 0) {
                alert('Please enter your Email-ID');
                return false;
                }
            else if (!emailid.match(mailformat)) {
                alert("You have entered an invalid email address!");
                return false;
                }
            


            return true;
           
        }   
        
        
        
//    function showDiv(obj)
//    {
//    if(obj=='Y')
//    {   
//    document.getElementById('tbl_details').style.display='block';
//    document.getElementById('tbl_BankInfo').style.display='block'; 
//    tbl_details   
//    }
//    else if(obj=='V') 
//    {  
//    document.getElementById('tbl_details').style.display='none';
//    document.getElementById('tbl_BankInfo').style.display='none';
//    }
//    else
//    {
//    document.getElementById('tbl_details').style.display='block';
//    document.getElementById('tbl_BankInfo').style.display='none';
//    }
//    }
        </script> 
        
    <style type="text/css">
        .style2
        {
            font-size: 12px;
            font-family: Verdana Arial Sans-Serif;
            color: Purple;
            font-weight: bold;
            width: 35%;
            height: 41px;
        }
        </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server"><br />
<asp:ScriptManager  ID="scriptmanager1" runat="server" EnablePageMethods="true"></asp:ScriptManager>
<span style="color: Red">Tickets can be cancelled online prior to 6 hours of scheduled departure time else please call customer support +919435173561 for cancellation and refer cancellation policy</span>
    <p style="border: 2px solid grey;border-radius: 10px; background-color: Menu; padding: 5px; margin-top: 5px;
        margin-bottom: 5px; color:Purple; font-size:small ;width :48%">
        Cancellation Charges:<br />
        1. Prior to 24 hrs of departure time - 20% deduction<br />
        2. Between 24 hrs to 12 hrs before departure time – 30% deduction<br />
        3. Between 12 hrs to 6 hrs before departure time – 50% deduction<br />
        4. Prior to 6 hrs of departure time -No Cancellation<br />
                </p>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div id="Div1" style="width: 50%; height: 220px; background-color: White; display: block;
                float: left;">
                <br />
                <br />
                <table width="100%" border="0" cellspacing="10px" cellpadding="0px" style="float: left;
                    background-image: url('images/sumo-bg1.png'); background-repeat: no-repeat; height: auto;">
                    <tr>
                        <td style="width: 89px; text-align: left;" class="text">
                            Ticket No.&nbsp;<span style="color: Red">*</span>
                        </td>
                        <td style="padding: 0px 0px 0px 5px; text-align: left;">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:TextBox ID="txtticketno" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 89px; text-align: left" class="text">
                            Mobile No.&nbsp;<span style="color: Red">*</span>
                        </td>
                        <td style="padding: 0px 0px 0px 5px; text-align: left;">
                            +91
                            <asp:TextBox ID="txtMobile" runat="server" Width="200px"></asp:TextBox><br />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 89px; text-align: left" class="text">
                        </td>
                        <td style="padding: 0px 0px 0px 5px; text-align: left;">
                            Please enter same mobile/phone no which you have given<br />
                            at the time of booking.
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 89px; text-align: " class="text">
                        </td>
                        <td style="padding: 25px 5px 20px 10px; text-align: left;">
                            <asp:Button ID="btnGetDetails" runat="server" Text="Cancel Ticket" CssClass="text"
                                OnClick="btnGetDetails_Click" OnClientClick="return paynow()" />
                        </td>
                    </tr>
                </table>
            </div>
            <div id="Div4" style="width: 50%; height: 220px; background-color: White; display: block;
                float: right;">
                <br />
                <br />
                <table width="100%" border="0" cellspacing="10px" cellpadding="0px" style="float: left;
                    height: auto;">
                    <tr>
                        <td>
                            <asp:Label ID="lblMsg" runat="server" Text="ErrorMsg" Visible="false" ForeColor="Red"></asp:Label>
                            <br />
                        </td>
                    </tr>
                </table>
            </div>
            <div id="Div2" style="width: 50%; height: auto; background-color: White; display: block;
                float: left;">
                <table width="95%" style="padding: 10px 5px 5px 10px;" cellspacing="5" id="tbl_details"
                    class="bus-bg" runat="server" visible="false">
                    <tr>
                        <td align="left">
                            <b>Ticket No.</b>
                        </td>
                        <td align="left">
                            <asp:Label ID="lbltranid" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <b>Counter Name </b>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblCuntName" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <b>From</b>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblFrom" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <b>To </b>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblTo" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <b>Mode</b>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblMode" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <b>Travel Date & Time </b>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblDateTime" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <b>Customer Name</b>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblCustName" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <b>Mobile No. </b>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblMobNo" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <b>Email-ID</b>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblemail" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <b>Address </b>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblAddress" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" width="45%">
                            <b>Seats Booked/Vehicle type</b>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblSeats" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <b>Amount </b>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblAmt" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="left">
                            <asp:Label ID="lblBoardingPoints" runat="server" Text=""></asp:Label><br />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="left">
                            <asp:Label ID="lblBookedOn" runat="server" Text=""></asp:Label><br />
                        </td>
                    </tr>
                </table>
            </div>
            <div id="Div3" style="width: 50%; height: auto; background-color: White; display: block;
                float: right;">
                <table border="0" class="bus-bg" width="100%" id="tbl_BankInfo" runat="server" visible="false">
                    <%--style="float: left;background-image: url('images/sumo-bg1.png'); background-repeat: no-repeat; width: 90%;"--%>
                    <%--<table width="50%" cellspacing="4px" cellpadding="4px 0px 0px 0px">--%>
                    <tr>
                        <td colspan="2">
                            As per BuyMyETicket cancellation policy, please provide your bank A/c deatils for
                            ticket's refund transfer.
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left;" class="style2">
                            Account Holder Name&nbsp;<span style="color: Red">*</span>
                        </td>
                        <td style="padding: 0px 0px 0px 0px; text-align: left;">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtAccholderName" runat="server" Width="250px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left;" class="style2">
                            Bank Name&nbsp;<span style="color: Red">*</span>
                        </td>
                        <td style="padding: 0px 0px 0px 0px; text-align: left;">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtBankName" runat="server" Width="250px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left;" class="style2">
                            Bank A/c No.&nbsp;<span style="color: Red">*</span>
                        </td>
                        <td style="padding: 0px 0px 0px px; text-align: left;">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtAccountno" runat="server" Width="250px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left;" class="style2">
                            Mobile No.&nbsp;<span style="color: Red">*</span>
                        </td>
                        <td style="padding: 0px 0px 0px px; text-align: left;">
                            +91<asp:TextBox ID="txtMobno" runat="server" Width="250px"></asp:TextBox><br />
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left;" class="style2">
                            Email-ID&nbsp;<span style="color: Red">*</span>
                        </td>
                        <td style="padding: 0px 0px 0px px; text-align: left;">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtEmailID" runat="server" Width="250px"></asp:TextBox><br />
                        </td>
                    </tr>
                    <%--  <tr>
                        <td colspan="3">
                            <br />
                            <br />
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <table style="background-image: url('images/bkgAmt.jpg'); background-repeat: no-repeat;
                                        width: 101%; height: 64px;">
                                        <tr>
                                            <td>
                                                Amount Payable
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="lblAmtPayable" runat="server" CssClass="text"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="btnVerify" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>                   
                    
                    <tr>
                    <td colspan="3" align="left"><br />
                    <input type="checkbox" id="chkFranchisee" onclick="showMe()" />Are you Franchisee?(optional)
                       <table  id="Fran_info" style="display:none;"><tr><td>
                       <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                       <ContentTemplate>
                        <table>
                        <tr><td class="text">Enter your Code</td>
                        <td align="center"><asp:TextBox ID="txtFranCode" TextMode="Password" runat="server" ></asp:TextBox></td>
                        <td align="right" ><asp:Button ID="btnVerify" runat="server" Text="Verify Code" 
                                CssClass="text" onclick="btnVerify_Click" /></td></tr>
                        <tr>
                        <td colspan="3"><asp:Label ID="lblFranName" runat="server"  CssClass="text"></asp:Label></td>
                        
                        </tr>                        
                        </table>
                        </ContentTemplate>
                        </asp:UpdatePanel>
                        </td></tr>
                        </table>
                    </td>
                    </tr>--%>
                    <tr>
                        <td colspan="2" style="background-color: Gray" align="center">
                            <asp:Button ID="btnpay" runat="server" Text="Submit" CssClass="text" Width="73px"
                                OnClientClick="return paybankdetails()" OnClick="btnpay_Click" />
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnGetDetails" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnpay" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
        <span style="color: Red">*Cancellation charges may differ travel operator to travel operator</span>
        <br /><br /><br /><br />
</asp:Content>

