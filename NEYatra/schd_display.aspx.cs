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
using System.Data.SqlClient;
using DataAccessLib;
using BusinessLogicLib;

public partial class schd_display : System.Web.UI.Page
{

    # region public variables
    public string frm;
    public string to;
    public string mode;
    public string jdate;
    public int click;
    public int searchClick;
    public string ratingtext;
    # endregion

    protected void Page_Load(object sender, EventArgs e)
    {

        // Extracting values from previous page
        
        if (!Page.IsPostBack)
        {
            if (Session["Source"] == null || Session["Destination"] == null || Session["VType"] == null || Session["Jdate"]==null)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Message", "alert('Session is expired, please try again.');window.location='Default.aspx'; ", true);
                //Response.Redirect("Default.aspx");
            }
            else
            {            
            if (Request.QueryString["click"].ToString() != null || Request.QueryString["click"].ToString() != "" || Request.QueryString["click"].ToString() != string.Empty)
                click = Convert.ToInt32(Request.QueryString["click"].ToString());

            ddlSource.Items.Clear();
            ddldestination.Items.Clear();
            ddlSource.Items.Insert(0, new ListItem("-------", "-1"));
            ddldestination.Items.Insert(0, new ListItem("-------", "-1"));
            filldropdown();

            ddlSource.SelectedValue = Session["Source"].ToString().Trim();
            ddldestination.SelectedValue = Session["Destination"].ToString().Trim();
            ddlMode.SelectedValue = Session["VType"].ToString().Trim();

            txtScheduleDate.Text = Session["Jdate"].ToString().Trim();

            lblSource.Text = Session["Source"].ToString().Trim(); ;
            lbldes.Text = Session["Destination"].ToString().Trim();
            lblMde.Text = Session["VType"].ToString().Trim();
            lblDate.Text = Session["Jdate"].ToString().Trim();

            if (click == 0)
            {
                BestDealGrdView.Visible = false;
                fillgrid();
            }

            if (click == 1)
            {
                imgbtn_bestdeal.Visible = false;
                lblBestDeal.Visible = true;
                BestDealGrdView.Visible = true;
                fillgrid();
                fillBestDealgrd();
            }

            }
        
        }
    
    }



    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "cseat")
        {
            int index = Convert.ToInt32(e.CommandArgument);

            GridViewRow row = GridView1.Rows[index];

            ViewState["session_id"] = GridView1.DataKeys[row.RowIndex].Value.ToString();
            
           // ViewState["session_id"] = row.Cells[1].Text.ToString().Trim();

            //jdate = (Convert.ToDateTime(row.Cells[6].Text)).ToString("dd-MMM-yyyy");
            BLSchedule obj = new BLSchedule();
            DataSet ds = obj.GetScheduleDetails(Convert.ToInt32(ViewState["session_id"]));
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                Session["Source"] = ds.Tables[0].Rows[0]["Source"].ToString();
                Session["Destination"] = ds.Tables[0].Rows[0]["Destination"].ToString();
                Session["Mode"] = ds.Tables[0].Rows[0]["Mode"].ToString();
                Session["JdateTime"] = ds.Tables[0].Rows[0]["Schd_Date"].ToString();
                ViewState["VehiLayout"] = ds.Tables[0].Rows[0]["VehiLayout"].ToString().Trim();

            }


            //if (Request.QueryString["date"].ToString() != null || Request.QueryString["date"].ToString() != "" || Request.QueryString["date"].ToString() != string.Empty)
            //    jdate = Request.QueryString["date"].ToString();



            if (Session["Mode"].ToString().Trim() == "Bus")
            {
                if (ViewState["VehiLayout"].ToString() == "2*1_35")
                    Response.Redirect("layout_bus.aspx?s=" + ViewState["session_id"]);
                if (ViewState["VehiLayout"].ToString() == "2*1_37")
                    Response.Redirect("LayoutBus_2-1_37.aspx?s=" + ViewState["session_id"]);
                if (ViewState["VehiLayout"].ToString() == "2*2")
                    Response.Redirect("LayoutBus22.aspx?s=" + ViewState["session_id"]);
                if (ViewState["VehiLayout"].ToString() == "2*1_32")
                    Response.Redirect("LayoutBus_2-1_32.aspx?s=" + ViewState["session_id"]);
            }
            else if (Session["Mode"].ToString().Trim() == "Sumo")
                Response.Redirect("layout_sumo.aspx?s=" + ViewState["session_id"]);

        }
        }

   
    protected void BestDealGrdView_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "cseat")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            
            GridViewRow row = BestDealGrdView.Rows[index];
            ViewState["session_id"] = BestDealGrdView.DataKeys[row.RowIndex].Value.ToString();
            //ViewState["session_id"] = Convert.ToInt32(row.Cells[1].Text);
            //jdate = (Convert.ToDateTime(row.Cells[6].Text)).ToString("dd-MMM-yyyy");
            BLSchedule obj = new BLSchedule();
            DataSet ds = obj.GetScheduleDetails(Convert.ToInt32(ViewState["session_id"]));
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
            Session["Source"] =  ds.Tables[0].Rows[0]["Source"].ToString();
            Session["Destination"] = ds.Tables[0].Rows[0]["Destination"].ToString();
            Session["Mode"] = ds.Tables[0].Rows[0]["Mode"].ToString();
            Session["JdateTime"] = ds.Tables[0].Rows[0]["Schd_Date"].ToString();
            ViewState["VehiLayout"] = ds.Tables[0].Rows[0]["VehiLayout"].ToString().Trim();
             
            }

            if (Session["Mode"].ToString().Trim() == "Bus")
            {
                if (ViewState["VehiLayout"].ToString() == "2*1_35")
                    Response.Redirect("layout_bus.aspx?s=" + ViewState["session_id"]);
                if (ViewState["VehiLayout"].ToString() == "2*1_37")
                    Response.Redirect("LayoutBus_2-1_37.aspx?s=" + ViewState["session_id"]);
                if (ViewState["VehiLayout"].ToString() == "2*2")
                    Response.Redirect("LayoutBus22.aspx?s=" + ViewState["session_id"]);
                if (ViewState["VehiLayout"].ToString() == "2*1_32")
                    Response.Redirect("LayoutBus_2-1_32.aspx?s=" + ViewState["session_id"]);
            }

            else if (Session["Mode"].ToString().Trim() == "Sumo")
                Response.Redirect("layout_sumo.aspx?s=" + ViewState["session_id"]);
            
        }
    }

    protected void GridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        
        if ((e.Row.RowType == DataControlRowType.DataRow))
        {
            /*Added on 16/12/2011*/
            DataRowView drv = (DataRowView)e.Row.DataItem;

            /*Added on 16/12/2011*/

            HyperLink hypLink = new HyperLink();
            hypLink = (e.Row.FindControl("lnkTime") as HyperLink);

            /*Added on 16/12/2011*/
            BLSchedule obj = new BLSchedule();
            DataSet ds = obj.GetBoardingPoints(Convert.ToInt32(drv["session id"]));
            
               
                ratingtext = "<table class=datatbl><tr><td colspan=2>Boarding Points </td></tr>";
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                for (int i = 0; i < ds.Tables[0].Columns.Count; i++)
                {

                    ratingtext = ratingtext + "<tr class=Gridrow><td align=left>" + ds.Tables[0].Rows[0][i].ToString() + "</td></tr>";

                }
                }
                ratingtext = ratingtext + "</table>";
                //<tr class=AlterGridrow><td width=50%> B Place </td><td align=center>02:20 AM</td></tr><tr class=Gridrow><td width=50%> C Place  </td><td align=center>03:20 AM</td></tr><tr class=AlterGridrow><td width=50%> D Place  </td><td align=center>04:40 AM</td></tr></table>";
                //hypLink.Attributes.Add("onmouseover", "alert('hello')");
                //hypLink.Attributes.Add("onmouseover", "ddrivetip('Hello','50')");
                hypLink.Attributes.Add("onmouseover", "ddrivetip('" + ratingtext + "','50')");
            }
          


            /*Added on 16/12/2011*/
            
            
            Button schButton = new Button();
            schButton = (e.Row.FindControl("cmdbutton") as Button);
            if (schButton != null)
            {
                schButton.Text = "hello";
            }


        }
        
  

    void fillgrid()
    {
        BLSchedule obj = new BLSchedule();
        DataSet ds = obj.GetSchedule(Session["Source"].ToString().Trim(), Session["Destination"].ToString().Trim(), Session["VType"].ToString().Trim(), Session["Jdate"].ToString().Trim());
        GridView1.DataSource = ds;
        GridView1.DataBind();
        
    }
  

    protected void Button1_Click(object sender, EventArgs e)
    {
        BestDealGrdView.Visible = true;
        fillBestDealgrd();
        imgbtn_bestdeal.Enabled = false;
        lblBestDeal.Visible = true;

    }
    void fillBestDealgrd()
    {                   
        BLSchedule obj = new BLSchedule();
        DataSet ds = obj.GetBestDealSchedule(Session["Source"].ToString().Trim(), Session["Destination"].ToString().Trim(), Session["VType"].ToString().Trim(), Session["Jdate"].ToString().Trim());
        BestDealGrdView.DataSource=ds;
        BestDealGrdView.DataBind();
    }
   
    
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Session["Source"] = ddlSource.SelectedItem.ToString();
        Session["Destination"] = ddldestination.SelectedItem.ToString();
        Session["VType"] = ddlMode.SelectedItem.ToString();
        if (txtScheduleDate.Text != "")
          Session["Jdate"] = Convert.ToDateTime(txtScheduleDate.Text.ToString()).ToString("dd-MMM-yyyy");


         lblSource.Text = Session["Source"].ToString().Trim(); ;
         lbldes.Text = Session["Destination"].ToString().Trim();
         lblMde.Text = Session["VType"].ToString().Trim();
         lblDate.Text = Session["Jdate"].ToString().Trim();


        BLSchedule obj = new BLSchedule();
        DataSet ds = obj.GetSchedule(Session["Source"].ToString().Trim(), Session["Destination"].ToString().Trim(), Session["VType"].ToString().Trim(), Session["Jdate"].ToString().Trim());
        GridView1.DataSource = ds;
        GridView1.DataBind();


                
        BestDealGrdView.Visible = false;
        imgbtn_bestdeal.Visible = true;
        ViewState["searchClick"] = 1;
        imgbtn_bestdeal.Enabled = true;
        pnlSearch.Visible = true;
        lblBestDeal.Visible = false;
    }
    protected void filldropdown()
    {
        // Filling dropdownlist for source location
        ddlSource.Items.Add("Guwahati");
        ddlSource.Items.Add("Hailakandi");
        ddlSource.Items.Add("Hailakandi (Katlicherra)");
        ddlSource.Items.Add("Hailakandi (Lala)");
        ddlSource.Items.Add("Karimganj");
        ddlSource.Items.Add("Silchar");
        ddlSource.Items.Add("Silchar(Fulertal)");
        ddlSource.Items.Add("Silchar(Udharbond)");
      
        // Filling dropdownlist for destination location
        
        ddldestination.Items.Add("Aizawl");
        ddldestination.Items.Add("Bokajan");
        ddldestination.Items.Add("Bokakhat");
        ddldestination.Items.Add("Bomdila");
        ddldestination.Items.Add("Boropancholi");
        ddldestination.Items.Add("Chawngte");
        ddldestination.Items.Add("Demagiri");
        ddldestination.Items.Add("Dimapur");
        ddldestination.Items.Add("Dirang");
        ddldestination.Items.Add("Guwahati");
        ddldestination.Items.Add("Imphal");
        ddldestination.Items.Add("Karimganj");
        ddldestination.Items.Add("Kimin");
        ddldestination.Items.Add("Kolasib");
        ddldestination.Items.Add("Ladrymbai");
        ddldestination.Items.Add("Lanka");
        ddldestination.Items.Add("Lumding");
        ddldestination.Items.Add("Lunglei");
        ddldestination.Items.Add("North Lakhimpur");
        ddldestination.Items.Add("Numaligarh");
        ddldestination.Items.Add("Shillong");
        ddldestination.Items.Add("Silchar");
        ddldestination.Items.Add("Silchar(Fulertal)");
        ddldestination.Items.Add("Silchar(Udharbond)");
        ddldestination.Items.Add("Silonijan");
        ddldestination.Items.Add("Sukhanjan");
        ddldestination.Items.Add("Tawang");    

        // Filling dropdownlist for transportation location
        ddlMode.Items.Add("All");
        ddlMode.Items.Add("Bus");
        ddlMode.Items.Add("Sumo");
    }

    protected void BestDealGrdView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        BestDealGrdView.PageIndex = e.NewPageIndex;
        fillBestDealgrd();
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        fillgrid();
    }
}
