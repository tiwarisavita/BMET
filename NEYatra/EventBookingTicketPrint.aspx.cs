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


public partial class EventBookingTicketPrint : System.Web.UI.Page
{
    string tranid = "";
    string mobno = "";
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

    protected void bindDetails(string tranid, string mobno)
    {
        try
        {
            BLSchedule objBLL = new BLSchedule();
            DataTable dt = objBLL.GetTicketInfo(tranid, mobno);
            if (dt != null && dt.Rows.Count > 0)
            {
                lblmsg.Visible = false;
                lbltranid.Text = dt.Rows[0]["Booking_ID"].ToString();
                lblEventName.Text = "ELECTRO NIGHT, Guwahati ";
                lblEventVenue.Text = " Kaamaakaazi Floating Disco Restaurant";
                lblDateTime.Text = "3rd March 2017 - 6 PM onwards";
                lblCustName.Text = dt.Rows[0]["Customer_name"].ToString() + "-" + dt.Rows[0]["Gender"].ToString() + "-" + dt.Rows[0]["Age"].ToString();
                lblMobNo.Text = dt.Rows[0]["Mobile_no"].ToString();
                lblemail.Text = dt.Rows[0]["Email_id"].ToString();
                lblAddress.Text = dt.Rows[0]["Address"].ToString();
                string pass = "";
                if (Convert.ToInt16(dt.Rows[0]["StagBoy"].ToString()) > 0)
                    pass = pass + "Stag Boy -" + dt.Rows[0]["StagBoy"].ToString() + "<br>";
                if (Convert.ToInt16(dt.Rows[0]["StagGirl"].ToString()) > 0)
                    pass = pass + "Stag Girl -" + dt.Rows[0]["StagGirl"].ToString() + "<br>";
                if (Convert.ToInt16(dt.Rows[0]["Couple"].ToString()) > 0)
                    pass = pass + "No. of persons -" + dt.Rows[0]["Couple"].ToString() + "<br>";
                if (Convert.ToInt16(dt.Rows[0]["Child"].ToString()) > 0)
                    pass = pass + "Child -" + dt.Rows[0]["Child"].ToString() + "<br>";
                lblPersonCount.Text = pass;
                lblAmt.Text = "Rs." + dt.Rows[0]["bookingBMET_amt"].ToString();       
                         
                lttPolicy.Text = "<h3><u>Terms & Conditions</u></h3><li>People under 18 not allowed to enter the event.</li>< li > Intoxicated persons are not allowed to enter the event.</li><li>Food, Beverage and liquor drinks are not allowed from outside.</li><li>Management will not be responsible for any injury/accident due to negligence of guests.</li><li>The management has the right to remove any person found miss behaving or with a misconduct.</li><li>Once sold pass can’t be returned or refund.</li><li>Any technical issues or defaults kindly cooperate.</li><li>Camera’s are not allowed in the event.</li> ";
                lblBookingdt.Text = Convert.ToDateTime(dt.Rows[0]["UpdationDateTime"].ToString()).ToString("dd/MM/yyyy hh:mm tt");
            }
            else
            {

                lblmsg.Visible = true;
                lblmsg.Text = "Ticket no./Mobileno is not found,please enter valid Ticket no. and mobile/phone no.";

            }
        }
        catch (Exception e)
        {

            throw e;
        }
    }
}
