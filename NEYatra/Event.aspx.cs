using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;


public partial class Event_Event : System.Web.UI.Page
{
    int singleticketcount;
    int coupleticketcount;
    int childticketcount;
    int singlegirlticketcount;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {

            ddlCoupleTicketno.Items.Add("0");
            ddlCoupleTicketno.Items.Add("1");
            ddlCoupleTicketno.Items.Add("2");
            ddlCoupleTicketno.Items.Add("3");
            ddlCoupleTicketno.Items.Add("4");
            ddlCoupleTicketno.Items.Add("5");
            ddlCoupleTicketno.Items.Add("6");
            ddlCoupleTicketno.Items.Add("7");
            ddlCoupleTicketno.Items.Add("8");
            ddlCoupleTicketno.Items.Add("9");
            ddlCoupleTicketno.Items.Add("10");



        }
    }



    protected void ddlCoupleTicketno_SelectedIndexChanged(object sender, EventArgs e)
    {

        coupleticketcount = Convert.ToInt16(ddlCoupleTicketno.SelectedItem.Value.ToString());
        lblTotalValueCoupleTicket.Text = (500 * coupleticketcount).ToString();
        lblTotalTicketValue.Text = Convert.ToInt16(lblTotalValueCoupleTicket.Text).ToString();
        Session["CoupleTicketCount"] = coupleticketcount;
        if (Convert.ToInt32(lblTotalTicketValue.Text.ToString()) > 0)
            btnnext.Enabled = true;
        else
            btnnext.Enabled = false;

    }




    protected void btnnext_Click(object sender, EventArgs e)
    {

        if (Convert.ToInt32(lblTotalTicketValue.Text.ToString()) > 0)
        {
            Session["TotalTicketValue"] = lblTotalTicketValue.Text.ToString();
            ArrayList seat = new ArrayList();
            seat.Add(1);
            Session["SeatNos"] = seat;
            Response.Redirect("Confirmation.aspx?mode=Event");
        }
    }
}