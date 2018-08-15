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

public partial class PrintTicket : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        if (txtticketno.Text == null || txtticketno.Text == "")
        {
            lblMsg.Text = "Please enter your ticket no.";
        }
        else
        {
            lblMsg.Text = "";
            string tranid = txtticketno.Text.ToString().Trim();
            string mobno = txtMobile.Text.ToString().Trim();
            string url = "";
            ViewState["tranidCarRental"] = tranid.ToString().Substring(0, 2);
            if (ViewState["tranidCarRental"].ToString() == "EV")
            {
                url = "EventBookingTicketPrint.aspx?tranid=" + tranid.ToString() + "&mobno=" + mobno;
            }
            else if (ViewState["tranidCarRental"].ToString() == "CR")
               {
                url = "CarRentalTicketDetails.aspx?tranid=" + tranid.ToString() + "&mobno=" + mobno;
            }
            else
            {
                url = "TicketsDetails.aspx?tranid=" + tranid.ToString() + "&mobno=" + mobno;
            }
            string cmd = "window.open('" + url + "', '_blank', 'height=800,width=700,status=yes,toolbar=no,menubar=no,location=yes,scrollbars=yes,resizable=no,titlebar=no' );";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "newWindow", cmd, true);
        }
    }
}
