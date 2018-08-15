using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using COM;
using System.Text;
using System.Net;
using System.IO;
using BusinessLogicLib;
using BusinessEntity;
using System.Net.Mail;

public partial class final : System.Web.UI.Page
{

    string Status = "";
    String strResponseMsg = "";
    string pass = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            COM.CheckSumResponseBean objCheckSumResponseBean = new COM.CheckSumResponseBean();
            TPSLUtil1 objTPSLUtil1 = new TPSLUtil1();

            //Response.Write("Originally Generated String===========>" + Convert.ToString(Session["myString"]) + "End String===========>");
            //String strResponseMsg = "01|9892381157|16462992|NA|5.00|10|NA|NA|INR|NA|NA|NA|NA|19-04-2011 12:31:40|0399|NA|12345|100000001|NA|NA|NA|NA|NA|NA|NA|777629931425";//Request["msg"] == null ? "" : Request["msg"].Trim();

            if (System.Configuration.ConfigurationManager.AppSettings["TestMode"].ToString() == "1")
                strResponseMsg = "L2983|" + Request.QueryString["msg"].ToString().Trim() + "|90203896|1212225152|1|300|32858463|NA|INR|NA|NA|NA|NA|13-12-2013 10:51:56|0300|NA|L2983|1|NA|NA|NA|NA|NA|NA|NA|125848191442";
            else
                strResponseMsg = Request["msg"] == null ? "" : Request["msg"].Trim();

            //if(Request["msg"]!=null)
            //    Response.Write(" Request[msg]===========>" + Request["msg"].ToString());
            //else
            //    Response.Write(" Response string is null");

            if (strResponseMsg == "" || strResponseMsg == string.Empty || strResponseMsg == null)
            {
                Response.Write("strResponseMsg===========>TPSL Response" + strResponseMsg);
            }
            else
            {
                String[] token = strResponseMsg.Split('|');
                BLSchedule objSch = new BLSchedule();
                if (token.Length == 26)
                {
                    objCheckSumResponseBean.MSG = strResponseMsg;
                    objCheckSumResponseBean.PropertyPath = HttpContext.Current.Server.MapPath("~/Property/MerchantDetails_sharedhosting.property");

                    string strCheckSumValue = objTPSLUtil1.transactionResponseMessage(objCheckSumResponseBean);
                    ViewState["ResponseCheckSum"] = token[25].ToString();
                    ViewState["Authstatus"] = token[14].ToString();

                    ViewState["ResponseCheckSum"] = strCheckSumValue;//written for testing 

                    if (!strCheckSumValue.Equals(""))
                    {
                        if (!ViewState["ResponseCheckSum"].ToString().Equals(strCheckSumValue))
                        {
                            Status = "F";
                        }
                        else
                        {
                            if (ViewState["Authstatus"].ToString() == "0300")
                                Status = "Y";
                            else
                                Status = "N";
                        }
                    }
                    else
                    {
                        Status = "F";
                    }


                    TPSLResponse objTpsl = new TPSLResponse();

                    objTpsl.MERCHANTID = token[0].ToString();
                    objTpsl.CustomerID = token[1].ToString();
                    objTpsl.TxnreferenceNo = token[2].ToString();
                    objTpsl.BankReferenceNo = token[3].ToString();
                    objTpsl.TxnAmount = token[4].ToString();
                    objTpsl.BankID = token[5].ToString();
                    objTpsl.BankMERCHANTID = token[6].ToString();
                    objTpsl.TxnType = token[7].ToString();
                    objTpsl.CurrencyName = token[8].ToString();
                    objTpsl.ItemCode = token[9].ToString();
                    objTpsl.SecurityType = token[10].ToString();
                    objTpsl.SecurityID = token[11].ToString();
                    objTpsl.SecurityPassword = token[12].ToString();
                    objTpsl.TxnDate = token[13].ToString();
                    objTpsl.AuthStatus = token[14].ToString();
                    objTpsl.SettlementType = token[15].ToString();
                    objTpsl.AdditionalInfo1 = token[16].ToString();
                    objTpsl.AdditionalInfo2 = token[17].ToString();
                    objTpsl.AdditionalInfo3 = token[18].ToString();
                    objTpsl.AdditionalInfo4 = token[19].ToString();
                    objTpsl.AdditionalInfo5 = token[20].ToString();
                    objTpsl.AdditionalInfo6 = token[21].ToString();
                    objTpsl.AdditionalInfo7 = token[22].ToString();
                    objTpsl.ErrorStatus = token[23].ToString();
                    objTpsl.ErrorDescription = token[24].ToString();
                    objTpsl.CheckSum = token[25].ToString();
                    objTpsl.Status = Status;
                    ViewState["tranid"] = objTpsl.CustomerID.ToString();
                    DataTable dt = objSch.UpdateUserCashDetails(objTpsl);
                    if (dt != null && dt.Rows.Count > 0)
                    {

                        if (dt.Rows[0][0].ToString() == "Success")
                        {
                            lblMsg.Text = "Great!!! Your bookings have been done.Please take a printout of your booking receipt.";
                            tbl_details.Visible = true;
                            btnPrint.Visible = true;
                            bindDetails(objTpsl.CustomerID.ToString());
                        }
                        else
                        {
                            lblMsg.Text = "Oops!!!, your bookings have not been done, if your payment has been deducted please call on +919435173561 else try again.";
                            btnPrint.Visible = false;
                            tbl_details.Visible = false;
                        }
                    }
                }
                else if (token.Length == 1)
                {
                    ViewState["tranid"] = token[0].ToString();
                    Response.Write("strResponseMsg===========>Token 1 block" + strResponseMsg);
                    Response.Write(" ViewState[tranid] " + ViewState["tranid"].ToString());
                    DataTable dt = objSch.PaymentUpdateBMETWallet(token[0].ToString());
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["Status"].ToString() == "Success")
                        {
                            lblMsg.Text = "Great!!! Dear <b>" + dt.Rows[0]["FranName"].ToString() + "</b>, Your bookings have been done.<br><br> <b> Your BMETWallet Balance was  Rs." + dt.Rows[0]["PreBMETWalletBal"].ToString() + "<br>Transaction Amt. Rs." + dt.Rows[0]["txnAmt"].ToString() + "<br>Available BMETWallet Balance Rs." + dt.Rows[0]["ActualBMETWalletBal"].ToString() + " </b><br><br>Please take printout of your booking receipt. BuyMyETicket wishes a very happy journey.";
                            btnPrint.Visible = true;
                            bindDetails(ViewState["tranid"].ToString());
                        }
                        else
                        {
                            lblMsg.Text = "Oops!!! Franchisee your bookings have not been done, if your payment has been deducted please call on 9435173561 else try again.";
                            btnPrint.Visible = false;
                            tbl_details.Visible = false;
                        }
                    }
                }
                else
                {
                    Response.Write("Inside ELSE of Response***********");
                    return;
                }
            }
        }
}
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        string url="";
        if (ViewState["tranidCarRental"].ToString() == "EV")
        {
            url = "EventBookingTicketPrint.aspx?tranid=" + ViewState["tranid"].ToString() + "&mobno=" + "";
        }
         else  if (ViewState["tranidCarRental"].ToString() == "CR")
            {
                url = "CarRentalTicketDetails.aspx?tranid=" + ViewState["tranid"].ToString() + "&mobno=" + "";
            }
            else
            {
                url = "TicketsDetails.aspx?tranid=" + ViewState["tranid"].ToString() + "&mobno=" + "";
            }
       
        string cmd = "window.open('" + url + "', '_blank', 'height=900,width=800,status=yes,toolbar=no,menubar=no,location=yes,scrollbars=yes,resizable=no,titlebar=no' );";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "newWindow", cmd, true);
    }

    protected void bindDetails(string tranid)
    {
        try
        {
            
            BLSchedule objBLL = new BLSchedule();


            DataTable dt = objBLL.GetTicketInfo(tranid,"");
            if (dt != null && dt.Rows.Count > 0)
            {
                ViewState["tranidCarRental"] = tranid.ToString().Substring(0, 2);
                if (ViewState["tranidCarRental"].ToString() == "EV")
                {
                    string pass = "";
                    tbl_details.Visible = false;
                    tbl_Event.Visible = true;
                    lblBookingno.Text = dt.Rows[0]["Booking_ID"].ToString();
                    lbleventname.Text = "ELECTRO NIGHT";
                    lblVenue.Text = "Kaamaakaazi Floating Disco Restaurant";
                    lbleventdatetime.Text = "3rd March 2017 - 6 PM onwards";
                    if (Convert.ToInt16(dt.Rows[0]["StagBoy"].ToString()) > 0)
                        pass = pass + "Stag Boy -" + dt.Rows[0]["StagBoy"].ToString() + "<br>";
                    if (Convert.ToInt16(dt.Rows[0]["StagGirl"].ToString()) > 0)
                        pass = pass + "Stag Girl -" + dt.Rows[0]["StagGirl"].ToString() + "<br>";
                    if (Convert.ToInt16(dt.Rows[0]["Couple"].ToString()) > 0)
                        pass = pass + "No. of persons -" + dt.Rows[0]["Couple"].ToString() + "<br>";
                    if (Convert.ToInt16(dt.Rows[0]["Child"].ToString()) > 0)
                        pass = pass + "Child -" + dt.Rows[0]["Child"].ToString() + "<br>";

                    lblpersonCount.Text = pass;
                    lbleventAmt.Text = "Rs " + dt.Rows[0]["bookingBMET_amt"].ToString();
                    lblname.Text = dt.Rows[0]["Customer_name"].ToString();
                    lbleventuserMobno.Text = dt.Rows[0]["Mobile_no"].ToString();
                    lbl_email.Text = dt.Rows[0]["Email_id"].ToString();
                    lblAdd.Text = dt.Rows[0]["Address"].ToString();

                    //Uncomment below line while uploading on Live
                //    SendSMSTicket(dt);
                    SendMailTicketConfirmation(dt);
                }

                else
                {
                    tbl_details.Visible = true;
                    tbl_Event.Visible = false;
                    if (ViewState["tranidCarRental"].ToString() == "CR")
                    {
                        lblDes.Text = "Usage";
                        lblDesDateTime.Text = "Pick-Up Date & Time";
                        lblDesAmt.Text = "Booking Amount";
                        lblBoardingPoints.Text = "<b> Balance Amount (Approx.) Rs." + dt.Rows[0]["BalanceAmt"].ToString(); ;
                        lttPolicy.Text = dt.Rows[0]["Policydescription"].ToString();
                        lblTo.Text = dt.Rows[0]["Usage"].ToString();
                        lblSeats.Text = dt.Rows[0]["SelectedVehicle"].ToString();
                        lblAmt.Text = "Rs." + dt.Rows[0]["BookingAmt"].ToString();
                        //Uncomment below line while uploading on Live - car rental only email

                     //   SendMailTicketConfirmation(dt);
                    }
                    else
                    {
                        lblTo.Text = dt.Rows[0]["To"].ToString();
                        lblSeats.Text = dt.Rows[0]["SeatBooked"].ToString();
                        lblAmt.Text = "Rs." + dt.Rows[0]["Amt"].ToString();
                        if (dt.Rows[0]["BoardingPoints"].ToString() != null)
                            lblBoardingPoints.Text = "Boarding Points :: " + dt.Rows[0]["BoardingPoints"].ToString();

                        //Uncomment below line while uploading on Live

                     //   SendSMSTicket(dt);
                      //  SendMailTicketConfirmation(dt);
                    }
                    lbltranid.Text = dt.Rows[0]["tranId"].ToString();
                    lblCuntName.Text = dt.Rows[0]["CounterName"].ToString();
                    lblFrom.Text = dt.Rows[0]["From"].ToString();
                    lblMode.Text = dt.Rows[0]["Mode"].ToString();
                    lblDateTime.Text = Convert.ToDateTime(dt.Rows[0]["TravelDate"].ToString()).ToString("dd/MM/yyyy") + " " + dt.Rows[0]["TravelTime"].ToString();
                    lblCustName.Text = dt.Rows[0]["CustName"].ToString();
                    lblMobNo.Text = dt.Rows[0]["MobNo"].ToString();
                    lblemail.Text = dt.Rows[0]["EmailID"].ToString();
                    lblAddress.Text = dt.Rows[0]["Address"].ToString();
                    lblBookedOn.Text = "Booked on :" + Convert.ToDateTime(dt.Rows[0]["BookedOn"].ToString()).ToString("dd/MM/yyyy hh:mm tt");
                }
            }
        }
        catch (Exception e)
        {
                
            throw e;
        }
    }

    void SendMailTicketConfirmation(DataTable dt)
    {
        try
        {
            if (dt != null && dt.Rows.Count > 0)
            {
                string subject = "";
                string body = "";
                MailAddress fromAddress = new MailAddress("info@buymyeticket.com", "BuyMyETicket.com");
                MailAddress toAddress =null;

                if (ViewState["tranidCarRental"].ToString() == "EV")
                {
                    subject = "BuyMyETicket.com :: Booking/Pass No :: " + dt.Rows[0]["Booking_ID"].ToString() + "Event Booking Confirmation";
                    toAddress = new MailAddress(dt.Rows[0]["Email_id"].ToString().Trim(), dt.Rows[0]["Customer_name"].ToString().Trim());
                    body = "<table width=\"100%\"><tr><td class=\"84%\"><img src=\"http://www.buymyeticket.com/images/finallogo1.png\" alt=\"BuyMyETicket.com\" style=\"height: 59px; width: 173px\"/></td> </tr>  </table>";
                    body += "<div id=\"div_ticket\"><hr />  <font color=\"blue\" size=\"3\"><b>Ticket Booking Confirmation</b></font>";
                    body += "<hr /> <h5>  Dear " + dt.Rows[0]["Customer_name"].ToString() + ",</h5>";
                    body += "<p style=\"text-align: justify\">Thank you for using www.buymyeticket.com online reservation facility. Your e-ticket has been booked and the details are mentioned below.</p>";
                    body += "<p style=\"text-align: justify\">Please take a printout of this Reservation Slip .You have to carry this printout at the time of entry at event venue and it can be ask by the staff for verification purpose.</p>";
                    body += "<font color=\"blue\" size=\"4\">Booking Details</font> <br />";
                    body += "<table width=\"100%\" border=\"1\">";
                    body += "<tr><td style=\"width:auto;\"><b>Booking/Pass No. </b></td><td style=\"width:auto;\">" + dt.Rows[0]["Booking_ID"].ToString() + "</td>";
                    body += "<td style=\"width:auto;\"><b>Event Name </b></td><td style=\"width:auto;\">" + "ELECTRO NIGHT-2017, Guwahati " + "</td></tr>";
                    body += "<tr><td style=\"width:auto;\"><b>Event Venue</b> </td><td style=\"width:auto;\">" + "Kaamaakaazi Floating Disco Restaurant" + "</td>";
                    body += "<td style=\"width:auto;\"><b>Event Date & Time </b></td><td style=\"width:auto;\">" + "3rd March 2017 - 6 PM onwards" + "</td></tr>";
                    body += "<tr><td style=\"width:auto;\"><b>Customer Details</b> </td><td style=\"width:auto;\">" + dt.Rows[0]["Customer_name"].ToString() + "-" + dt.Rows[0]["Gender"].ToString() + "-" + dt.Rows[0]["Age"].ToString() + "</td>"; 
                    body += "<td style=\"width:auto;\"><b>Mobile no</b></td><td style=\"width:auto;\">" + dt.Rows[0]["Mobile_no"].ToString() + "</td></tr>";
                    body += "<tr><td style=\"width:auto;\"><b>Email-ID</b> </td><td style=\"width:auto;\">" + dt.Rows[0]["Email_id"].ToString() + "</td>";
                    body += "<td style=\"width:auto;\"><b>Address</b></td><td style=\"width:auto;\">" + dt.Rows[0]["Address"].ToString() + "</td></tr>";
                    string pass = "";
                    if (Convert.ToInt16(dt.Rows[0]["StagBoy"].ToString()) > 0)
                        pass = pass + "Stag Boy -" + dt.Rows[0]["StagBoy"].ToString() + "<br>";
                    if (Convert.ToInt16(dt.Rows[0]["StagGirl"].ToString()) > 0)
                        pass = pass + "Stag Girl -" + dt.Rows[0]["StagGirl"].ToString() + "<br>";
                    if (Convert.ToInt16(dt.Rows[0]["Couple"].ToString()) > 0)
                        pass = pass + "No. of persons -" + dt.Rows[0]["Couple"].ToString() + "<br>";
                    if (Convert.ToInt16(dt.Rows[0]["Child"].ToString()) > 0)
                        pass = pass + "Child -" + dt.Rows[0]["Child"].ToString() + "<br>";
                    body += "<tr><td style=\"width:auto;\"><b>No. of Persons</b> </td><td style=\"width:auto;\">" + pass + "</td>";
                    body += "<td style=\"width:auto;\"><b>Ticket Amount</b></td><td style=\"width:auto;\">" + "Rs." + dt.Rows[0]["bookingBMET_amt"].ToString() + "</td></tr>";
                    body += "</table> <br />";
                    body += "<br>";
                    body += "<h3><u>Terms & Conditions</u></h3> <li>People under 18 not allowed to enter the event.</li>< li > Intoxicated persons are not allowed to enter the event.</li><li>Food, Beverage and liquor drinks are not allowed from outside.</li><li>Management will not be responsible for any injury/accident due to negligence of guests.</li><li>The management has the right to remove any person found miss behaving or with a misconduct.</li><li>Once sold pass can’t be returned or refund.</li><li>Any technical issues or defaults kindly cooperate.</li><li>Camera’s are not allowed in the event.</li>";
                    body += "<br><br><br><b> Booked On :: " + Convert.ToDateTime(dt.Rows[0]["UpdationDateTime"].ToString()).ToString("dd/MM/yyyy hh:mm tt") + "</b><br /><br />";
                    body += "<p style=\"text - align: justify;font-weight:bold;\"> Please do carry a valid ID proof which can be shown if inquired by staff.</ p > ";
                    body += "<p style=\"text-align: justify\"> Thanks for choosing us for ticket booking, Keep on visiting our website  for more discounts and attractive offers...</p>";
                    body += "<b>Warm Regards,<br />Customer Care | www.buymyeticket.com | Helpline : +91-9435351122</b>";
                 
                }
                else
                { 
                    toAddress = new MailAddress(dt.Rows[0]["EmailID"].ToString().Trim(), dt.Rows[0]["CustName"].ToString().Trim());
                    body = "<table width=\"100%\"><tr><td class=\"84%\"><img src=\"http://www.buymyeticket.com/images/finallogo1.png\" alt=\"BuyMyETicket.com\" style=\"height: 59px; width: 173px\"/></td> </tr>  </table>";
                    body += "<div id=\"div_ticket\"><hr />  <font color=\"blue\" size=\"3\"><b>Ticket Booking Confirmation</b></font>";
                    body += "<hr /> <h5>  Dear " + dt.Rows[0]["CustName"].ToString() + ",</h5>";
                    body += "<p style=\"text-align: justify\">Thank you for using www.buymyeticket.com online reservation facility. Your e-ticket has been booked and the details are mentioned below.</p>";
                    body += "<p style=\"text-align: justify\">Please take a printout of this Reservation Slip .You have to carry this printout at the time of travel and can be ask by the staff for verification purpose.</p>";
                    body += "<font color=\"blue\" size=\"4\">Booking Details</font> <br />";
                    body += "<table width=\"100%\" border=\"1\">";
                    body += "<tr><td style=\"width:auto;\"><b>Ticket/Booking No. </b></td><td style=\"width:auto;\">" + dt.Rows[0]["tranId"].ToString() + "</td>";
                    body += "<td style=\"width:auto;\"><b>Counter/Vendor </b></td><td style=\"width:auto;\">" + dt.Rows[0]["CounterName"].ToString() + "</td></tr>";
                    body += "<tr><td style=\"width:auto;\"><b>Source City</b></td><td style=\"width:auto;\">" + dt.Rows[0]["From"].ToString() + "</td>";
                    if (ViewState["tranidCarRental"].ToString() == "CR")
                    {
                        subject = "BuyMyETicket.com :: Booking No :: " + dt.Rows[0]["tranId"].ToString() + "Car Rental Booking Confirmation";
                        body += "<td style=\"width:auto;\"> <b>Usage/Destinaton</b></td><td style=\"width:auto;\">" + dt.Rows[0]["Usage"].ToString() + "</td></tr>";
                        body += "<tr><td style=\"width:auto;\"><b>Mode</b> </td><td style=\"width:auto;\">" + dt.Rows[0]["Mode"].ToString() + "</td>";
                        body += "<td style=\"width:auto;\"><b>Pick-up Date & Time </b></td><td style=\"width:auto;\">" + Convert.ToDateTime(dt.Rows[0]["TravelDate"].ToString()).ToString("dd/MM/yyyy") + " " + dt.Rows[0]["TravelTime"].ToString() + "</td></tr>";
                    }
                    else
                    {

                        subject = "BuyMyETicket.com :: Ticket No :: " + dt.Rows[0]["tranId"].ToString() + " Booking Confirmation";
                        body += "<td style=\"width:auto;\"> <b>Destination</b></td><td style=\"width:auto;\">" + dt.Rows[0]["To"].ToString() + "</td></tr>";
                        body += "<tr><td style=\"width:auto;\"><b>Mode</b> </td><td style=\"width:auto;\">" + dt.Rows[0]["Mode"].ToString() + "</td>";
                        body += "<td style=\"width:auto;\"><b>Travel Date & Time </b></td><td style=\"width:auto;\">" + Convert.ToDateTime(dt.Rows[0]["TravelDate"].ToString()).ToString("dd/MM/yyyy") + " " + dt.Rows[0]["TravelTime"].ToString() + "</td></tr>";
                    }
                    string[] custname = dt.Rows[0]["CustName"].ToString().Split('/');
                    string[] Gender = dt.Rows[0]["Gender"].ToString().Split('/');
                    string[] Age = dt.Rows[0]["Age"].ToString().Split('/');
                    body += "<tr><td style=\"width:auto;\"><b>Customer Details</b> </td><td style=\"width:auto;\">";
                    for (int i = 0; i < custname.Length; i++)
                    {
                        if (i == custname.Length - 1)
                        {
                            body += custname[i] + "-" + Gender[i] + "-" + Age[i];
                        }
                        else
                        {
                            body += custname[i] + "-" + Gender[i] + "-" + Age[i] + "/";

                        }
                    }
                    body += "</td>";
                    body += "<td style=\"width:auto;\"><b>Mobile no</b></td><td style=\"width:auto;\">" + dt.Rows[0]["MobNo"].ToString() + "</td></tr>";
                    //body += "<tr><td style=\"width:auto;\"><b>Gender</b> </td><td style=\"width:auto;\">" + dt.Rows[0]["Gender"].ToString() + "</td>";
                    //body += "<td style=\"width:auto;\"><b>Age</b></td><td style=\"width:auto;\">" + dt.Rows[0]["Age"].ToString() + "</td></tr>";
                    body += "<tr><td style=\"width:auto;\"><b>Email-ID</b> </td><td style=\"width:auto;\">" + dt.Rows[0]["EmailID"].ToString() + "</td>";
                    body += "<td style=\"width:auto;\"><b>Address</b></td><td style=\"width:auto;\">" + dt.Rows[0]["Address"].ToString() + "</td></tr>";
                    if (ViewState["tranidCarRental"].ToString() == "CR")
                    {
                        body += "<tr><td style=\"width:auto;\"><b>Selected Vehicle</b> </td><td style=\"width:auto;\">" + dt.Rows[0]["SelectedVehicle"].ToString() + "</td>";
                        body += "<td style=\"width:auto;\"><b>Booking Amount</b></td><td style=\"width:auto;\">" + "Rs." + dt.Rows[0]["BookingAmt"].ToString() + "</td></tr>";
                        body += "</table> <br />";
                        body += "<br> Total Fare(Approx.) : Rs." + dt.Rows[0]["total_fare"].ToString();
                        body += "<br> Balance Amount(Approx.) : Rs." + dt.Rows[0]["BalanceAmt"].ToString();
                        if (dt.Rows[0]["FranName"].ToString() != "")
                        {
                            body += "<br> <b>  Franchisee :" + dt.Rows[0]["FranName"].ToString() + "</b>";
                            if (Convert.ToInt32(dt.Rows[0]["Fran_Markup"].ToString()) > 0)
                            {
                                body += "<br>Franchisee Commision/processing charges Rs. " + dt.Rows[0]["Fran_Markup"].ToString() + "(Franchisee commission is not a part of total fare amount.)";
                            }
                        }
                        body += "<br><b><u>Vendor Travel Policy</u></b><br>" + dt.Rows[0]["Policydescription"].ToString();

                    }
                    else
                    {
                        body += "<tr><td style=\"width:auto;\"><b>Seat no(s):</b> </td><td style=\"width:auto;\">" + dt.Rows[0]["SeatBooked"].ToString() + "</td>";
                        body += "<td style=\"width:auto;\"><b>Amount</b></td><td style=\"width:auto;\">" + "Rs." + dt.Rows[0]["Amt"].ToString() + "</td></tr>";
                        body += "</table> <br />";

                        if (dt.Rows[0]["Ticketprice"].ToString() != "" && dt.Rows[0]["Cusdis"].ToString() != "")
                            //body += "Market Ticket price (per person) Rs." + dt.Rows[0]["Ticketprice"].ToString() + "<br><b> BuyMyETicket discount :" + dt.Rows[0]["Cusdis"].ToString() + "%</b> <br> Ticket Fare : Rs." + dt.Rows[0]["Amt"].ToString();
                            body += "<br> Ticket Fare : Rs." + dt.Rows[0]["Amt"].ToString();
                        if (dt.Rows[0]["FranName"].ToString() != "")
                        {
                            string[] strs = dt.Rows[0]["SeatBooked"].ToString().Trim().Split(',');
                            int fran_processingfees = strs.Length * 20;
                            int totAmt = Convert.ToInt32(dt.Rows[0]["Amt"].ToString()) + fran_processingfees;
                            body += " +  Rs." + fran_processingfees + "(Franchisee processing charges Rs.20 per seat)<br> Total Amount Paid : Rs." + totAmt;
                            body += "<br> <br> <b>  Franchisee :" + dt.Rows[0]["FranName"].ToString() + "</b>";
                        }

                        if (dt.Rows[0]["BoardingPoints"].ToString() != null)
                            body += "<b>Boarding Point :: " + dt.Rows[0]["BoardingPoints"].ToString() + "</b><br />";
                        body += "<p style=\"text-align: justify\">For CHANGE OF BOARDING point or PICK-UP point(For Car Rental only) &amp; CHANGE IN NAME customer can approach our customer care center or mail us at <a href=\"mailto:info@buymyeticket.com\">info@buymyeticket.com</a>.Please do carry a valid ID proof which can be shown if inquired by staff. Passenger should report at boarding point, prior to 30 min schedule departure time.</p>";
                    }
                    body += "<br><br> Booked On :: " + Convert.ToDateTime(dt.Rows[0]["BookedOn"].ToString()).ToString("dd/MM/yyyy hh:mm tt") + "<br /><br />";
                    body += "<p style=\"text-align: justify\"> Thanks for choosing us, we wish you a happy journey. Keep on visiting our website  for more discounts and attractive offers...</p>";
                    body += "<b>Warm Regards,<br />Customer Care | www.buymyeticket.com | Helpline : +91-9435351122</b>";
                }
                var smtp = new SmtpClient
                {
                    Host = "relay-hosting.secureserver.net",
                    Port = 25,
                    UseDefaultCredentials = true,
                };

                MailMessage mailmsg = new MailMessage();
                mailmsg.From = fromAddress;
                mailmsg.To.Add(toAddress);
                mailmsg.Bcc.Add("amitkumarnandy0@gmail.com,devnandy23@gmail.com");
                if (ViewState["tranidCarRental"].ToString() == "EV")
                    mailmsg.Bcc.Add("amitkumarnandy0@gmail.com,devnandy23@gmail.com"); 
                else
                    mailmsg.Bcc.Add("amitkumarnandy0@gmail.com,devnandy23@gmail.com");
                mailmsg.IsBodyHtml = true;
                mailmsg.Subject = subject;
                mailmsg.Body = body;
                smtp.Send(mailmsg);

            }
        }
        catch (Exception ex)
        {
            throw ex;
            
        }    
        
    }


    void SendSMSTicket(DataTable dt)
    {
        string sUserID = "bmetsms";
        string sPwd = "bmetsms";
        string sSID = "BUYMET";
        string sMessage = "";
        string sNumber = "";

        if (dt != null && dt.Rows.Count > 0)
        {
            if (ViewState["tranidCarRental"].ToString() == "EV")
            {
                sNumber = "91" + dt.Rows[0]["Mobile_no"].ToString() + ",919435351122";
                //,918723986223
                sMessage = "BUYMYeTICKET.com%20::%20Helpline%20-%2009435351122%0AName%20-%20" + dt.Rows[0]["Customer_name"].ToString() + "%0APh%20-%20" + dt.Rows[0]["Mobile_no"].ToString() + "%0APass No%20-%20" + dt.Rows[0]["Booking_ID"].ToString() + "No.of Persons-" + pass + "Date/Time- 3rd March 2017 - 6 PM onwards Venue-Kaamaakaazi Floating Disco Restaurant Thanks for using BUYMYeTICKET.com";
            }
            else
            {
                sNumber = "91" + dt.Rows[0]["MobNo"].ToString() + ",91" + dt.Rows[0]["CuntMobSms"].ToString() + ",919435351122";
                string[] custname = dt.Rows[0]["CustName"].ToString().Split('/');
                sMessage = "BUYMYeTICKET.com%20::%20Helpline%20-%2009435351122%0AName%20-%20" + custname[0].ToString() + "%0APh%20-%20" + dt.Rows[0]["MobNo"].ToString() + "%0ATicket%20No%20-%20" + dt.Rows[0]["tranId"].ToString() + "%0A" + dt.Rows[0]["From"].ToString() + "%20To%20" + dt.Rows[0]["To"].ToString() + "%0ASeat(s)%20-%20" + dt.Rows[0]["SeatBooked"].ToString() + "%0AMode%20-%20" + dt.Rows[0]["Mode"].ToString() + "%0ADate/Time%20-%20" + Convert.ToDateTime(dt.Rows[0]["TravelDate"].ToString()).ToString("dd/MM/yyyy") + "%20" + dt.Rows[0]["TravelTime"].ToString() + "%0A" + dt.Rows[0]["CounterNameSms"].ToString() + "(" + dt.Rows[0]["CuntMobSms"].ToString() + ")%0ABoarding%20At%20-%20" + dt.Rows[0]["BoardingPoints"].ToString() + "%0AWish%20you%20a%20very%20Happy%20Journey.";
            }
            sMessage = sMessage.Replace(" ", "%20");
            sMessage = sMessage.Replace("&", "%26");
            string sURL = "http://api.smsgatewayhub.com/smsapi/pushsms.aspx?user=" + sUserID + "&pwd=" + sPwd + "&to=" + sNumber + "&sid=" + sSID + "&msg=" + sMessage + "&fl=0&gwid=2";
            string sResponse = GetResponse(sURL);
            if (sResponse != "") { }
            //Response.Write(sResponse);
        }
    }

    string GetResponse(string sURL)
    {
    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(sURL);
    request.MaximumAutomaticRedirections = 4;
    request.Credentials = CredentialCache.DefaultCredentials;
    try
    {
    HttpWebResponse response = (HttpWebResponse)request.GetResponse ();
    Stream receiveStream = response.GetResponseStream ();
    StreamReader readStream = new StreamReader (receiveStream, Encoding.UTF8);
    string sResponse = readStream.ReadToEnd();
    response.Close ();
    readStream.Close ();
    return sResponse;
    }
    catch(Exception ex)
    {
        throw ex;
    }
    }   


}

