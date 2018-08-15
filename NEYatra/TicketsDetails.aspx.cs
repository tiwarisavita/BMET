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


public partial class TicketsDetails : System.Web.UI.Page
{
    string tranid="";
    string mobno="";
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!IsPostBack)
        {

            if (Request.QueryString["tranid"].ToString() != null || Request.QueryString["tranid"].ToString() != "")
           
                tranid = Request.QueryString["tranid"].ToString().Trim();
            if (Request.QueryString["mobno"].ToString() != null || Request.QueryString["mobno"].ToString() != "")
                mobno = Request.QueryString["mobno"].ToString().Trim();
     
            bindDetails(tranid, mobno);
        }
        
    }
    protected void bindDetails(string tranid,string mobno)
    {
        try
        {
            BLSchedule objBLL = new BLSchedule();
            DataTable dt = objBLL.GetTicketInfo(tranid, mobno);
            if (dt != null && dt.Rows.Count > 0)
            {
                lblmsg.Visible = false;
                lbltranid.Text = dt.Rows[0]["tranId"].ToString();
                lblCuntName.Text = dt.Rows[0]["CounterName"].ToString();
                lblFrom.Text = dt.Rows[0]["From"].ToString();
                lblTo.Text = dt.Rows[0]["To"].ToString();
                lblMode.Text = dt.Rows[0]["Mode"].ToString();
                lblDateTime.Text = Convert.ToDateTime(dt.Rows[0]["TravelDate"].ToString()).ToString("dd/MM/yyyy") + " " + dt.Rows[0]["TravelTime"].ToString();
                string[] custname = dt.Rows[0]["CustName"].ToString().Split('/');
                string[] Gender = dt.Rows[0]["Gender"].ToString().Split('/');
                string[] Age = dt.Rows[0]["Age"].ToString().Split('/');
                for (int i = 0; i < custname.Length; i++)
                {
                    if (i == custname.Length - 1)
                    {
                        lblCustName.Text = lblCustName.Text + custname[i] + "-" + Gender[i] + "-" + Age[i];
                      
                    }
                    else
                    {
                        lblCustName.Text = lblCustName.Text + custname[i] + "-" + Gender[i] + "-" + Age[i] + "/";
                        
                    }                    
                }

                //lblCustName.Text = dt.Rows[0]["CustName"].ToString();
                lblMobNo.Text = dt.Rows[0]["MobNo"].ToString();
                lblemail.Text = dt.Rows[0]["EmailID"].ToString();
                lblAddress.Text = dt.Rows[0]["Address"].ToString();
                lblSeats.Text = dt.Rows[0]["SeatBooked"].ToString();
                lblAmt.Text = "Rs." + dt.Rows[0]["Amt"].ToString();

                //if (dt.Rows[0]["Gender"].ToString() != "")
                //    lblGender.Text = dt.Rows[0]["Gender"].ToString();
                //else
                //    lblGender.Text = "";

                //if (dt.Rows[0]["Age"].ToString() != "0" || dt.Rows[0]["Age"].ToString() != "")
                //    lblAge.Text = dt.Rows[0]["Age"].ToString();
                //else
                //    lblAge.Text = "";


                if (dt.Rows[0]["BoardingPoints"].ToString() != "")
                    lblBoardingPoints.Text = "<b>" + "Boarding Points :: " + dt.Rows[0]["BoardingPoints"].ToString() + "</b>";
                if (dt.Rows[0]["Ticketprice"].ToString() != "" && dt.Rows[0]["Cusdis"].ToString() != "")
                    //lblTicketAmt.Text = "Market Ticket price (per person) Rs." + dt.Rows[0]["Ticketprice"].ToString() + "<br><b> BuyMyETicket discount :" + dt.Rows[0]["Cusdis"].ToString() + "%</b> <br> Ticket Fare : Rs." + dt.Rows[0]["Amt"].ToString();
                    lblTicketAmt.Text = "Ticket Fare : Rs." + dt.Rows[0]["Amt"].ToString();
                    if (dt.Rows[0]["FranName"].ToString() != "")
                {
                    string[] strs = dt.Rows[0]["SeatBooked"].ToString().Trim().Split(',');
                    int fran_processingfees = strs.Length * 20;
                    lblBookingdt.Text = Convert.ToDateTime(dt.Rows[0]["BookedOn"].ToString()).ToString("dd/MM/yyyy hh:mm tt") + "   <br> <b>  Franchisee :" + dt.Rows[0]["FranName"].ToString()+"</b>";
                    int totAmt = Convert.ToInt32(dt.Rows[0]["Amt"].ToString()) + fran_processingfees;
                    lblTicketAmt.Text = lblTicketAmt.Text + " +  Rs." + fran_processingfees + "(Franchisee processing charges Rs.20 per seat)<br> Total Amount Paid : Rs." + totAmt;
                                                    
                
                }
                else
                    lblBookingdt.Text = Convert.ToDateTime(dt.Rows[0]["BookedOn"].ToString()).ToString("dd/MM/yyyy hh:mm tt");
            }
            else
            {

                lblmsg.Visible = true;
                lblmsg.Text="Ticket no./Mobileno is not found,please enter valid Ticket no. and mobile/phone no.";
            
            }
        }
        catch (Exception e)
        {

            throw e;
        }
    }
}
