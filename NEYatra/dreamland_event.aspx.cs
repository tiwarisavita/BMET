using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;


public partial class dreamland_event : System.Web.UI.Page
{
    int singleticketcount;
    int coupleticketcount;
    int childticketcount;
    int singlegirlticketcount;
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!Page.IsPostBack)
        {

            ddlChildTicketno.Items.Add("0");
            ddlChildTicketno.Items.Add("1");
            ddlChildTicketno.Items.Add("2");
            ddlChildTicketno.Items.Add("3");
            ddlChildTicketno.Items.Add("4");
            ddlChildTicketno.Items.Add("5");
            ddlChildTicketno.Items.Add("6");
            ddlChildTicketno.Items.Add("7");
            ddlChildTicketno.Items.Add("8");
            ddlChildTicketno.Items.Add("9");
            ddlChildTicketno.Items.Add("10");

            ddlSingleTicketno.Items.Add("0");
            ddlSingleTicketno.Items.Add("1");
            ddlSingleTicketno.Items.Add("2");
            ddlSingleTicketno.Items.Add("3");
            ddlSingleTicketno.Items.Add("4");
            ddlSingleTicketno.Items.Add("5");
            ddlSingleTicketno.Items.Add("6");
            ddlSingleTicketno.Items.Add("7");
            ddlSingleTicketno.Items.Add("8");
            ddlSingleTicketno.Items.Add("9");
            ddlSingleTicketno.Items.Add("10");

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

            ddlSingleGirlTicketno.Items.Add("0");
            ddlSingleGirlTicketno.Items.Add("1");
            ddlSingleGirlTicketno.Items.Add("2");
            ddlSingleGirlTicketno.Items.Add("3");
            ddlSingleGirlTicketno.Items.Add("4");
            ddlSingleGirlTicketno.Items.Add("5");
            ddlSingleGirlTicketno.Items.Add("6");
            ddlSingleGirlTicketno.Items.Add("7");
            ddlSingleGirlTicketno.Items.Add("8");
            ddlSingleGirlTicketno.Items.Add("9");
            ddlSingleGirlTicketno.Items.Add("10");


        }
    }

    protected void ddlSingleTicketno_SelectedIndexChanged(object sender, EventArgs e)
    {
      
        singleticketcount = Convert.ToInt16(ddlSingleTicketno.SelectedItem.Value.ToString());
        lblTotalValueSingleTicket.Text = (1500 * singleticketcount).ToString();
       lblTotalTicketValue.Text = (Convert.ToInt16(lblTotalValueSingleGirlTicket.Text) + Convert.ToInt16(lblTotalValueSingleTicket.Text) + Convert.ToInt16(lblTotalValueCoupleTicket.Text)+ Convert.ToInt16(lblTotalValueChildTicket.Text)).ToString();
        Session["SingleBoyTicketCount"] = singleticketcount;
        if (Convert.ToInt32(lblTotalTicketValue.Text.ToString()) > 0)
            btnnext.Enabled = true;
        else
            btnnext.Enabled = false;


    }

    protected void ddlCoupleTicketno_SelectedIndexChanged(object sender, EventArgs e)
    {
     
        coupleticketcount = Convert.ToInt16(ddlCoupleTicketno.SelectedItem.Value.ToString());
        lblTotalValueCoupleTicket.Text = (2000 * coupleticketcount).ToString();
        lblTotalTicketValue.Text = (Convert.ToInt16(lblTotalValueSingleGirlTicket.Text) + Convert.ToInt16(lblTotalValueSingleTicket.Text) + Convert.ToInt16(lblTotalValueCoupleTicket.Text) + Convert.ToInt16(lblTotalValueChildTicket.Text)).ToString();
        Session["CoupleTicketCount"] = coupleticketcount;
        if (Convert.ToInt32(lblTotalTicketValue.Text.ToString()) > 0)
            btnnext.Enabled = true;
        else
            btnnext.Enabled = false;

    }

    protected void ddlChildTicketno_SelectedIndexChanged(object sender, EventArgs e)
    {
    
        childticketcount = Convert.ToInt16(ddlChildTicketno.SelectedItem.Value.ToString());
        lblTotalValueChildTicket.Text = (500 * childticketcount).ToString();
        lblTotalTicketValue.Text = (Convert.ToInt16(lblTotalValueSingleGirlTicket.Text) + Convert.ToInt16(lblTotalValueSingleTicket.Text) + Convert.ToInt16(lblTotalValueCoupleTicket.Text) + Convert.ToInt16(lblTotalValueChildTicket.Text)).ToString();
        Session["ChildTicketCount"] = childticketcount;
        if (Convert.ToInt32(lblTotalTicketValue.Text.ToString()) > 0)
            btnnext.Enabled = true;
        else
            btnnext.Enabled = false;

    }

    protected void ddlSingleGirlTicketno_SelectedIndexChanged(object sender, EventArgs e)
    {
   
        singlegirlticketcount = Convert.ToInt16(ddlSingleGirlTicketno.SelectedItem.Value.ToString());
        lblTotalValueSingleGirlTicket.Text = (1200 * singlegirlticketcount).ToString();
        lblTotalTicketValue.Text = (Convert.ToInt16(lblTotalValueSingleGirlTicket.Text) + Convert.ToInt16(lblTotalValueSingleTicket.Text) + Convert.ToInt16(lblTotalValueCoupleTicket.Text) + Convert.ToInt16(lblTotalValueChildTicket.Text)).ToString();
        Session["SingleGirlTicketCount"] = singlegirlticketcount;
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