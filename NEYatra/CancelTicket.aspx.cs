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
using BusinessLogicLib;
using BusinessEntity;
using System.Net.Mail;

public partial class CancelTicket : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
   
    }
    protected void btnGetDetails_Click(object sender, EventArgs e)
    {
        try
        {
            
            //lblMsg.Text = "Dear Customer, Your tickets have been booked.Please take a printout.BuyMyETicket wishes a very happy journey.";
            BLSchedule objBLL = new BLSchedule();
            DataTable dt = objBLL.GetTicketInfo(txtticketno.Text.ToString().Trim(), txtMobile.Text.ToString().Trim());
            if (dt != null && dt.Rows.Count > 0)
            {
                ViewState["dtTicketDeatils"] = dt;
                lbltranid.Text = dt.Rows[0]["tranId"].ToString();
                ViewState["Ticketno"] = dt.Rows[0]["tranId"].ToString();
                lblCuntName.Text = dt.Rows[0]["CounterName"].ToString();
                lblFrom.Text = dt.Rows[0]["From"].ToString();
                lblTo.Text = dt.Rows[0]["To"].ToString();
                lblMode.Text = dt.Rows[0]["Mode"].ToString();
                lblDateTime.Text = Convert.ToDateTime(dt.Rows[0]["TravelDate"].ToString()).ToString("dd/MM/yyyy") + " " + dt.Rows[0]["TravelTime"].ToString();
                lblCustName.Text = dt.Rows[0]["CustName"].ToString();
                lblMobNo.Text = dt.Rows[0]["MobNo"].ToString();
                lblemail.Text = dt.Rows[0]["EmailID"].ToString();
                lblAddress.Text = dt.Rows[0]["Address"].ToString();
                lblSeats.Text = dt.Rows[0]["SeatBooked"].ToString();
                lblAmt.Text = "Rs." + dt.Rows[0]["Amt"].ToString();
                if (dt.Rows[0]["BoardingPoints"].ToString() != null)
                    lblBoardingPoints.Text = "Boarding Points :: " + dt.Rows[0]["BoardingPoints"].ToString();
                lblBookedOn.Text = "Booked on :" + Convert.ToDateTime(dt.Rows[0]["BookedOn"].ToString()).ToString("dd/MM/yyyy hh:mm tt");   
                string trdt = Convert.ToDateTime(dt.Rows[0]["TravelDate"].ToString()).ToString("MM/dd/yyyy");
                DateTime schddt = Convert.ToDateTime(trdt + " " + dt.Rows[0]["TravelTime"].ToString());
                TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
                DateTime indianTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);
                //DateTime currectdt = DateTime.Now;
                TimeSpan ts = schddt - indianTime;
                double mins = ts.TotalMinutes;
                if (mins <= 360)
                {
                    ts = TimeSpan.FromMinutes(mins);
                    lblMsg.Visible = true;
                    lblMsg.Text = "Only " + ts.Hours +"hrs " + ts.Minutes+" mins left in departure, as per BuyMyETicket cancellation policy this ticket cannot be cancelled online,for further query please contact at +919435173561.";
                    //ScriptManager.RegisterStartupScript(this, GetType(), "Javascript", "javascript:showDiv('N'); ", true);
                    tbl_BankInfo.Visible = false;
                    tbl_details.Visible = true;

                }
                else
                {
                 //   ScriptManager.RegisterStartupScript(this, GetType(), "Javascript", "javascript:showDiv('Y'); ", true);
                    tbl_BankInfo.Visible = true;
                    tbl_details.Visible = true;
                    lblMsg.Visible = false;
                    lblMsg.Text = "";
                    
                }

                              
            }
            else
            {
               // ScriptManager.RegisterStartupScript(this, GetType(), "Javascript", "javascript:showDiv('V'); ", true);
                tbl_BankInfo.Visible = false;
                tbl_details.Visible = false;
                lblMsg.Visible = true;
                lblMsg.Text = "Ticket no./Mobileno is not found,please enter valid Ticket no. and mobile/phone no.";
                txtticketno.Text = "";
                txtMobile.Text = "";
            }
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

   
    protected void btnpay_Click(object sender, EventArgs e)
    {
        TicketCancel obj = new TicketCancel();
        obj.Ticketno = ViewState["Ticketno"].ToString();
        obj.AccountHolderName = txtAccholderName.Text.Trim();
        obj.BankName = txtBankName.Text.Trim();
        obj.BankAccountNo = txtAccountno.Text.Trim();
        obj.Mobile_no = txtMobno.Text.Trim();
        obj.Email_id = txtEmailID.Text.Trim();
        BLSchedule objBLL = new BLSchedule();
        DataTable dt = objBLL.CancelTicket(obj);
        lblMsg.Visible = true;
        if (dt != null && dt.Rows.Count > 0)
        {
            lblMsg.ForeColor = System.Drawing.Color.Green;
            lblMsg.Text = "Your ticket has been cancelled and cancellation transaction ID is <b> " + dt.Rows[0]["TxnID"].ToString() + " </b>.Cancellation charges will be deducted as per BuyMyETicket refund/cancellation policy and refund amount will be deposited into your BMETWallet or bank A/c within 5-6 business days.";
            txtAccholderName.Text = "";
            txtAccountno.Text = "";
            txtBankName.Text = "";
            txtEmailID.Text = "";
            txtMobno.Text = "";
            btnpay.Enabled = false;
            SendMailTicketConfirmation((DataTable)ViewState["dtTicketDeatils"], dt.Rows[0]["TxnID"].ToString());
        }
        else
        {
            lblMsg.Text = "This ticket is not cancelled due to some reasons,please try again or call at +919435173561";
        }
    }

    void SendMailTicketConfirmation(DataTable dt,String Cancellation_tranID)
    {
        var fromAddress = new MailAddress("info@buymyeticket.com", "BuyMyETicket.com");
        var toAddress = new MailAddress(dt.Rows[0]["EmailID"].ToString().Trim(), dt.Rows[0]["CustName"].ToString().Trim());

        string subject = "BuyMyETicket.com :: Ticket No :: " + dt.Rows[0]["tranId"].ToString() + " Cancelled, Cancellation Transaction ID ::" + Cancellation_tranID.ToString();
        

        string body = "<table width=\"100%\"><tr><td class=\"84%\"><img src=\"http://www.buymyeticket.com/images/finallogo1.png\" alt=\"BuyMyETicket.com\" style=\"height: 59px; width: 173px\"/></td> </tr>  </table>";
        body += "<div id=\"div_ticket\"><hr />  <font color=\"blue\" size=\"3\"><b>Ticket Cancellation</b></font>";
        body += "<hr /> <h5>  Dear " + dt.Rows[0]["CustName"].ToString() + ",</h5>";
        body += "<p style=\"text-align: justify\">Your e-ticket has been cancelled and your cancellation transaction ID is <b>" + Cancellation_tranID.ToString() + " </b> the details are mentioned below.</p>";
        body += "<font color=\"blue\" size=\"4\">Ticket Cancellation Details</font> <br />";
        body += "<table width=\"100%\" border=\"1\">";
        body += "<tr><td style=\"width:auto;\"><b>Ticket No. </b></td><td style=\"width:auto;\">" + dt.Rows[0]["tranId"].ToString() + "</td>";
        body += "<td style=\"width:auto;\"><b>Counter </b></td><td style=\"width:auto;\">" + dt.Rows[0]["CounterName"].ToString() + "</td></tr>";
        body += "<tr><td style=\"width:auto;\"><b>From</b></td><td style=\"width:auto;\">" + dt.Rows[0]["From"].ToString() + "</td>";
        body += "<td style=\"width:auto;\"> <b>To</b></td><td style=\"width:auto;\">" + dt.Rows[0]["To"].ToString() + "</td></tr>";
        body += "<tr><td style=\"width:auto;\"><b>Mode</b> </td><td style=\"width:auto;\">" + dt.Rows[0]["Mode"].ToString() + "</td>";
        body += "<td style=\"width:auto;\"><b>Travel Date & Time </b></td><td style=\"width:auto;\">" + Convert.ToDateTime(dt.Rows[0]["TravelDate"].ToString()).ToString("dd/MM/yyyy") + " " + dt.Rows[0]["TravelTime"].ToString() + "</td></tr>";
        body += "<tr><td style=\"width:auto;\"><b>Customer Name</b> </td><td style=\"width:auto;\">" + dt.Rows[0]["CustName"].ToString() + "</td>";
        body += "<td style=\"width:auto;\"><b>Mobile no</b></td><td style=\"width:auto;\">" + dt.Rows[0]["MobNo"].ToString() + "</td></tr>";
        body += "<tr><td style=\"width:auto;\"><b>Email-ID</b> </td><td style=\"width:auto;\">" + dt.Rows[0]["EmailID"].ToString() + "</td>";
        body += "<td style=\"width:auto;\"><b>Address</b></td><td style=\"width:auto;\">" + dt.Rows[0]["Address"].ToString() + "</td></tr>";
        body += "<tr><td style=\"width:auto;\"><b>Seat no(s):</b> </td><td style=\"width:auto;\">" + dt.Rows[0]["SeatBooked"].ToString() + "</td>";
        body += "<td style=\"width:auto;\"><b>Ticket Amount</b></td><td style=\"width:auto;\">" + "Rs." + dt.Rows[0]["Amt"].ToString() + "</td></tr>";
        body += "</table> <br />";

        body += "<p style=\"text-align: justify\">Your ticket was Booked On ::" + Convert.ToDateTime(dt.Rows[0]["BookedOn"].ToString()).ToString("dd/MM/yyyy hh:mm tt") +"</p>";
        body += "<p style=\"text-align: justify\"> Thanks for choosing us, we will get back to you shortly for refund process. Keep on visiting our website  for more discounts and attractive offers...</p>";
        body += "<b>Warm Regards,<br />Customer Care | www.buymyeticket.com | Helpline : +91-9435351122</b>";
        var smtp = new SmtpClient
        {
            Host = "relay-hosting.secureserver.net",
            Port = 25,
            UseDefaultCredentials = true,
        };

        MailMessage mailmsg = new MailMessage();
        mailmsg.From = fromAddress;
        mailmsg.To.Add(toAddress);
        mailmsg.Bcc.Add("tiwari.savita@gmail.com,devnandy23@gmail.com,amitkumarnandy0@gmail.com");
        mailmsg.IsBodyHtml = true;
        mailmsg.Subject = subject;
        mailmsg.Body = body;
        smtp.Send(mailmsg);
    }

}
