using System;
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
using System.Net.Mail;
using System.Web.Mail;
using DataAccessLib;

public partial class _Default : System.Web.UI.Page 
{

    #region public variables

    public string from = string.Empty;
    public string to = string.Empty;
    public string mode = string.Empty;
    public string date = string.Empty;

    # endregion



    protected void Page_Load(object sender, EventArgs e)
    {
        //System.Threading.Thread.Sleep(100);
        //string currenttime = DateTime.Now.ToLongTimeString();
        //lblcurrenttime.Text = currenttime;
        if (!Page.IsPostBack)
        {
            
            DropDownList4.Items.Clear();
            DropDownList5.Items.Clear();

            DropDownList4.Items.Insert(0, new ListItem("-------", "-1"));
            DropDownList5.Items.Insert(0, new ListItem("-------", "-1"));
            ddlAgentuser.Items.Insert(0, new ListItem("-------", "-1"));

            ddlLocalSrc.Items.Insert(0, new ListItem("-------", "-1"));
            ddlLocalDuration.Items.Insert(0, new ListItem("-------", "-1"));
            ddlLocalSrc.Items.Clear();
            ddlLocalDuration.Items.Clear();
            

            filldropdown();
            
            TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
            DateTime indianTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);
            txtScheduleDate.Text = indianTime.ToString("dd-MMM-yyyy");


          
            //TabContainer1_ActiveTabChanged(TabContainer1, null); 
        }





    }
    protected void filldropdown()
    {
        // Filling dropdownlist for source location
        DropDownList4.Items.Add("Guwahati");
        DropDownList4.Items.Add("Hailakandi");
        DropDownList4.Items.Add("Hailakandi (Katlicherra)");
        DropDownList4.Items.Add("Hailakandi (Lala)");
        DropDownList4.Items.Add("Karimganj");        
        DropDownList4.Items.Add("Silchar");
        DropDownList4.Items.Add("Silchar(Fulertal)");
        DropDownList4.Items.Add("Silchar(Udharbond)");


        

        // Filling dropdownlist for destination location
        DropDownList5.Items.Add("Aizawl");
        DropDownList5.Items.Add("Bokajan");
        DropDownList5.Items.Add("Bokakhat");
        DropDownList5.Items.Add("Bomdila");
        DropDownList5.Items.Add("Boropancholi");
        DropDownList5.Items.Add("Chawngte");
        DropDownList5.Items.Add("Demagiri");
        DropDownList5.Items.Add("Dimapur");
        DropDownList5.Items.Add("Dirang");
        DropDownList5.Items.Add("Guwahati");
        DropDownList5.Items.Add("Imphal");
        DropDownList5.Items.Add("Karimganj");
        DropDownList5.Items.Add("Kimin");
        DropDownList5.Items.Add("Kolasib");
        DropDownList5.Items.Add("Ladrymbai");
        DropDownList5.Items.Add("Lanka");
        DropDownList5.Items.Add("Lumding");
        DropDownList5.Items.Add("Lunglei");
        DropDownList5.Items.Add("North Lakhimpur");
        DropDownList5.Items.Add("Numaligarh");
        DropDownList5.Items.Add("Shillong");
        DropDownList5.Items.Add("Silchar");
        DropDownList5.Items.Add("Silchar(Fulertal)");
        DropDownList5.Items.Add("Silchar(Udharbond)");
        DropDownList5.Items.Add("Silonijan");
        DropDownList5.Items.Add("Sukhanjan");
        DropDownList5.Items.Add("Tawang");
      

        // Filling dropdownlist for transportation location
        DropDownList6.Items.Add("All");
        DropDownList6.Items.Add("Bus");
        DropDownList6.Items.Add("Sumo");

        ddlAgentuser.Items.Add("Customer");
        ddlAgentuser.Items.Add("Agent");

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

    

    protected void btn_search_Click(object sender, EventArgs e)
    {
        Session["Source"] = DropDownList4.SelectedItem.Text.ToString();
        Session["Destination"] = DropDownList5.SelectedItem.Text.ToString();
        Session["VType"] = DropDownList6.SelectedItem.Text.ToString();
        if (txtScheduleDate.Text != "")
        Session["Jdate"] = Convert.ToDateTime(txtScheduleDate.Text.ToString()).ToString("dd-MMM-yyyy");
        Response.Redirect("schd_display.aspx?click=0");
    }
    protected void btn_bestdeal_Click(object sender, EventArgs e)
    {
        Session["Source"] = DropDownList4.SelectedItem.Text.ToString();
        Session["Destination"] = DropDownList5.SelectedItem.Text.ToString();
        Session["VType"] = DropDownList6.SelectedItem.Text.ToString();
        if (txtScheduleDate.Text != "")
            Session["Jdate"] = Convert.ToDateTime(txtScheduleDate.Text.ToString()).ToString("dd-MMM-yyyy");

        Response.Redirect("schd_display.aspx?click=1");
    }

    
    protected void Image11_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("default.aspx");
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            DALSchedule objDL = new DALSchedule();
            DataTable dt = objDL.AddApprochingUserdetails(txtName.Text.ToString(), txtPhone.Text.ToString(), txtEmail.Text.ToString(), txtAddress.Text.ToString(), txtCity.Text.ToString(), txtState.Text.ToString(), ddlAgentuser.SelectedItem.Text.ToString());
            if (dt != null && dt.Rows.Count > 0)
            {
                if (dt.Rows[0][0].ToString() == "succcess")
                {

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Thanks for connecting with buymyeticket.com, we will revert to you shortly')", true);
                                       
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Apolozies,your information is not saved,Please try again or mail at info@buymyeticket.com')", true);
                    
                }
            }
            txtName.Text = "";
            txtPhone.Text = "";
            txtAddress.Text = "";
            txtEmail.Text = "";
            txtCity.Text = "";
            txtState.Text = "";
            ddlAgentuser.SelectedIndex = 0;
            UpdatePanel1.Update();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void ImageButton5_Click(object sender, ImageClickEventArgs e)
    {
        string url = "www.facebook.com/Buymyeticket";
        string cmd = "window.open('" + url + "', '_blank', 'height=900,width=800,status=yes,toolbar=no,menubar=no,location=yes,scrollbars=yes,resizable=no,titlebar=no' );";
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "newWindow", cmd, true);
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

    //protected void btn_CarRental_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("CarRental.aspx");
    //}

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
        //}
    }
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

