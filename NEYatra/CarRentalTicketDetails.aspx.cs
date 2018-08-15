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


public partial class CarRentalTicketDetails : System.Web.UI.Page
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
                lbltranid.Text = dt.Rows[0]["tranId"].ToString();
                lblCuntName.Text = dt.Rows[0]["CounterName"].ToString();
                lblFrom.Text = dt.Rows[0]["From"].ToString();
                lblTo.Text = dt.Rows[0]["Usage"].ToString();
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

                lblMobNo.Text = dt.Rows[0]["MobNo"].ToString();
                lblemail.Text = dt.Rows[0]["EmailID"].ToString();
                lblAddress.Text = dt.Rows[0]["Address"].ToString();
                lblSeats.Text = dt.Rows[0]["SelectedVehicle"].ToString();
                lblAmt.Text = "Rs." + dt.Rows[0]["BookingAmt"].ToString();
                lblTotalFare.Text = "Rs." + dt.Rows[0]["total_fare"].ToString();
                lblBalanceFare.Text = "Rs." + dt.Rows[0]["BalanceAmt"].ToString();
               
                if (dt.Rows[0]["FranName"].ToString() != "")
                {
                    lblFranname.Text = "<br>Franchisee :" + dt.Rows[0]["FranName"].ToString();
                    if (Convert.ToInt32(dt.Rows[0]["Fran_Markup"].ToString()) > 0)
                    {
                        lblFranname.Text += "<br>Franchisee Commision/processing charges Rs. " + dt.Rows[0]["Fran_Markup"].ToString() +"(Franchisee commission is not a part of total fare amount.)";
                    }

                }
                lttPolicy.Text = dt.Rows[0]["Policydescription"].ToString();
                lblBookingdt.Text = Convert.ToDateTime(dt.Rows[0]["BookedOn"].ToString()).ToString("dd/MM/yyyy hh:mm tt");
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
