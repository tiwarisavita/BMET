<%@ Page Language="C#" MasterPageFile="~/Master/MasterPage2.master" AutoEventWireup="true" CodeFile="PrintTicket.aspx.cs" Inherits="PrintTicket" Title="Untitled Page" %>

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
                alert('Please enter your ticketno. ');
                return false;
            }
       
            else if (!txtticketno.match(letters1)) {
                alert("Ticket no. must have alphanumeric characters and '-',',',':' only");
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
            return true;
           
        }  
        </script> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="Div1" style="width: 100%; height: 400px; background-color: White; display: block;">
        <br />
        <br />
        <br />
        <br />
        <center>
        <table width="50%" border="0" cellspacing="10px" cellpadding="0px" style="float: left;
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
                    <asp:Button ID="btnPrint" runat="server" Text="Print Ticket" CssClass="text" OnClientClick="return paynow()" onclick="btnPrint_Click"/>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblMsg" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
            </tr>
        </table></center>
        <%--  <table width="75%" border="1">
            <tr>
                <td>
                    <b>Enter Ticket No. </b>
                </td>
                <td>
                    <asp:TextBox ID="txttranid" runat="server"></asp:TextBox>
                </td>
                <td>               
                    <asp:Button ID="btnPrint" runat="server" Text="Print" 
                        onclick="btnPrint_Click" CssClass="text" />
                </td>
            </tr>
          <tr>
                <td colspan="3">
                    <asp:Label ID="lblMsg" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
                
            </tr>
        </table>--%>
        <br />
        <br />
        <br />
        <br />
    </div>
</asp:Content>

