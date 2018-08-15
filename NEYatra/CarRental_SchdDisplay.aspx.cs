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

public partial class CarRental_SchdDisplay : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["CR_TravelType"] == null || Session["CR_SourceCity"] == null || Session["CR_DesCity"] == null || Session["CR_TravelMode"] == null)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Message", "alert('Session is expired, please try again.');window.location='Default.aspx'; ", true);
                //Response.Redirect("Default.aspx");
            }
            else
            {
                lblSource.Text = Session["CR_SourceCity"].ToString();
                lblDate.Text = Session["PickupDate"].ToString() + " " + Session["PickupTime"].ToString();
                if (Session["CR_TravelType"].ToString() == "Outstation")
                    if (Session["CR_TravelMode"].ToString() == "OneWay")
                        lbltrip.Text = Session["CR_TravelType"].ToString() + " (" + Session["CR_DesCity"].ToString() + " -> One Way Trip )";
                    else
                        lbltrip.Text = Session["CR_TravelType"].ToString() + " (" + Session["CR_DesCity"].ToString() + " -> Round Trip )";
                else
                    lbltrip.Text = Session["CR_TravelType"].ToString() + " (" + Session["CR_TravelMode"].ToString() + ")";
                
                
               

                fillGrid();
            }

        }
    }

    protected void GridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if ((e.Row.RowType == DataControlRowType.DataRow))
        {
            DataRowView drv = (DataRowView)e.Row.DataItem;          
            Image img = new Image();
            img = (e.Row.FindControl("VehiImg") as Image);
            img.ImageUrl = drv["VehicleImagePath"].ToString();

            Label lblVehi = new Label();
            lblVehi = (e.Row.FindControl("lblVehi") as Label);
            lblVehi.Text = "<h3>" + drv["VehicleMake"].ToString() + " " + drv["VehicleModel"].ToString() + "</h3> " + drv["VehicleType"].ToString();

            Label lblSeatingCapacity = new Label();
            lblSeatingCapacity = (e.Row.FindControl("lblSeatingCapacity") as Label);
            lblSeatingCapacity.Text = drv["vehi_seatcapacity"].ToString() +" + Driver";


            Label lblPrice = new Label();
            lblPrice = (e.Row.FindControl("lblPrice") as Label);
            lblPrice.Text = "<H2> Rs. "+drv["Fare"].ToString()+"</H2>";

            HyperLink lnkFareDetails = new HyperLink();
            lnkFareDetails = (e.Row.FindControl("lnkFareDetails") as HyperLink);
            //lnkFareDetails.Attributes.Add("onmouseover", "alert('hello')");
            string policy= drv["Policydescription"].ToString() ;
          
            lnkFareDetails.Attributes.Add("onmouseover", "ddrivetip('" + policy + "','50')");
            //lnkFareDetails.Attributes.Add("onmouseover", "ddrivetip('<h3>Vendor Travel Policy</h3><li>Rs. 500 extra paid for A.C. (According to Travel Agent)</li><li>Rs. 1800 extra paid for holding charges per day basis.</li>','50')");           
            
        }
             
    }
    protected void fillGrid()
    {

        BLSchedule obj = new BLSchedule();
        DataTable dt = null;
        if (Session["CR_TravelType"].ToString().Trim() == "Outstation")
            dt = obj.GetCarRentalSchedule(Session["CR_TravelType"].ToString().Trim(), Session["CR_SourceCity"].ToString().Trim(), Session["CR_DesCity"].ToString().Trim(), Session["CR_TravelMode"].ToString().Trim());
        else
            dt = obj.GetCarRentalSchedule(Session["CR_TravelType"].ToString().Trim(), Session["CR_SourceCity"].ToString().Trim(), null, Session["CR_TravelMode"].ToString().Trim());

        Grd_CarRental.DataSource = dt;
        Grd_CarRental.DataBind();
    }
    protected void Grd_CarRental_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "cseat")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = Grd_CarRental.Rows[index];
            Session["ScheduleID"] = Grd_CarRental.DataKeys[row.RowIndex].Value.ToString();
          
            //for creating single user details
            ArrayList seat = new ArrayList();
            seat.Add(1);
            Session["SeatNos"] = seat;
           
            Response.Redirect("Confirmation.aspx?mode=Rental");

          

            
        }
    }
    protected void btn_ModifySearch_Click(object sender, EventArgs e)
    {
        Response.Redirect("CarRental.aspx");
    }
}