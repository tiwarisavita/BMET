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

public partial class CarRental : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            filldropdown();
           
        }
    }
    //protected int checkbookingtime()
    //{
    //    string trdt = Convert.ToDateTime(datetimeLocal.GetDate.ToString()).ToString("MM/dd/yyyy");
    //    DateTime schddt = Convert.ToDateTime(trdt + " " + Convert.ToString(datetimeLocal.GetTime.ToString()));
    //    TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
    //    DateTime indianTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);
    //    TimeSpan ts = schddt - indianTime;
    //    double hrs = ts.TotalHours;
    //    if (hrs >= 24)
    //    {
    //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "key", "showMe('N');", true);
    //        return 1;
    //    }
    //    else
    //    {
    //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "key", "showMe('Y');", true);
    //        lblMsg.Text = "Booking can be done prior to 24 hrs of travelling date and time only.Please select another travelling date and time.";
    //        return 0;

    //    }
    //}
    protected void filldropdown()
    {
        // Filling dropdownlist for Car Rental Section

        ddlLocalSrc.Items.Add("Silchar");
        ddlLocalSrc.Items.Add("Guwahati");
        ddlLocalDuration.Items.Add("Full Day/8 Hrs");
        ddlLocalDuration.Items.Add("Half Day/4 Hrs");
        ddlLocalDuration.Items.Add("Dropping Only");

        ddlOutstationSrc.Items.Add("Guwahati");
        ddlOutstationSrc.Items.Add("Silchar");


        ddlOutstationDes.Items.Add("Agartala");
        ddlOutstationDes.Items.Add("Aizwal");
        ddlOutstationDes.Items.Add("Bongaingaon");
        ddlOutstationDes.Items.Add("Dhubri");
        ddlOutstationDes.Items.Add("Dibrugarh");
        ddlOutstationDes.Items.Add("Diphu");
        ddlOutstationDes.Items.Add("Guwahati");
        ddlOutstationDes.Items.Add("Itanagar");
        ddlOutstationDes.Items.Add("Jorhat");
        ddlOutstationDes.Items.Add("Juwai");
        ddlOutstationDes.Items.Add("Karimganj");
        ddlOutstationDes.Items.Add("Kaziranga");   
        ddlOutstationDes.Items.Add("Kolosib");
        ddlOutstationDes.Items.Add("Ladhymbai");
        ddlOutstationDes.Items.Add("Lumding");
        ddlOutstationDes.Items.Add("Lunglei");
        ddlOutstationDes.Items.Add("Nagon");
        ddlOutstationDes.Items.Add("North Lakhimpur");
        ddlOutstationDes.Items.Add("Serechhip");
        ddlOutstationDes.Items.Add("Shillong");
        ddlOutstationDes.Items.Add("Sibsagar");
        ddlOutstationDes.Items.Add("Silchar");
        ddlOutstationDes.Items.Add("Teliamura");
        ddlOutstationDes.Items.Add("Tezpur");
        ddlOutstationDes.Items.Add("Tinsukia");
        ddlOutstationDes.Items.Add("Tura");



        ddlAirportCity.Items.Add("Silchar-Airport");
        ddlAirportCity.Items.Add("Guwahati-Airport");
        ddlPickupDrop.Items.Add("Pickup from Airport");
        ddlPickupDrop.Items.Add("Drop at Airport");


    }
  
  

    protected void TabContainer1_ActiveTabChanged(object sender, EventArgs e)
    {
        try
        {
            if (TabContainer1.ActiveTabIndex == 0)
            {

            }

            if (TabContainer1.ActiveTabIndex == 1)
            {

            }

            if (TabContainer1.ActiveTabIndex == 2)
            {

            }
        }

        catch
        {
            throw;
        }
        finally
        {

        }
    }

   
    protected void btn_LocalSearch_Click(object sender, EventArgs e)
    {

        //if (checkbookingtime() == 1)
        //{


            Session["CR_TravelType"] = "Local";
            Session["CR_SourceCity"] = ddlLocalSrc.SelectedItem.Text.ToString();
            Session["CR_DesCity"] = ddlLocalSrc.SelectedItem.Text.ToString();
            Session["CR_TravelMode"] = ddlLocalDuration.SelectedItem.Text.ToString(); ;



            Session["PickupDate"] = datetimeLocal.GetDate.ToString();
            Session["PickupTime"] = datetimeLocal.GetTime.ToString();



            Response.Redirect("CarRental_SchdDisplay.aspx");
        }
        //}
    
    protected void btn_OutstationSearch_Click(object sender, EventArgs e)
    {
        //if (checkbookingtime() == 1)
        //{
            Session["CR_TravelType"] = "Outstation";
            Session["CR_SourceCity"] = ddlOutstationSrc.SelectedItem.Text.ToString();
            Session["CR_DesCity"] = ddlOutstationDes.SelectedItem.Text.ToString();
            if (rd_Oneway.Checked == true)
                Session["CR_TravelMode"] = "OneWay";
            else
                Session["CR_TravelMode"] = "TwoWay";

            Session["PickupDate"] = datetimeOutStation.GetDate.ToString();
            Session["PickupTime"] = datetimeOutStation.GetTime.ToString();



            Response.Redirect("CarRental_SchdDisplay.aspx");
        //}

    }
    protected void btn_AirportSearch_Click(object sender, EventArgs e)
    {
        //if (checkbookingtime() == 1)
        //{
            Session["CR_TravelType"] = "Airport";
            Session["CR_SourceCity"] = ddlAirportCity.SelectedItem.Text.ToString();
            Session["CR_DesCity"] = ddlAirportCity.SelectedItem.Text.ToString();
            Session["CR_TravelMode"] = ddlPickupDrop.SelectedItem.Text.ToString();

            Session["PickupDate"] = datetimeAirport.GetDate.ToString();
            Session["PickupTime"] = datetimeAirport.GetTime.ToString();

            Response.Redirect("CarRental_SchdDisplay.aspx");
        //}
    }
}
