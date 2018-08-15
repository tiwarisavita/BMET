using System;
using System.Collections;
using System.Collections.Generic;
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
using System.Drawing;
using System.Data.SqlClient;
using System.Windows.Forms;
using BusinessLogicLib;
using System.Web.Services;



public partial class Counter_layout_sumo : System.Web.UI.Page
{
    public int s_id;
    int click = 0;
    //List<int> totseat = null;
    int totalAmt = 0;
    int tranValue = 0;
    ArrayList totalseat = null;
    public string source;
    public string destination;
    public string mode;
    public string journeydate;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            //Ajax.Utility.RegisterTypeForAjax(typeof(Counter_layout_sumo),this);
            if (Session["Source"] == null || Session["Destination"] == null || Session["Mode"] == null || Session["JdateTime"] == null || Request.QueryString["s"] == null)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Message", "alert('Session is expired, please try again.');window.location='Default.aspx'; ", true);
                //Response.Redirect("Default.aspx");
            }
            else
            {
                lblSource.Text = Session["Source"].ToString();
                lblDestination.Text = Session["Destination"].ToString();
                lblMode.Text = Session["Mode"].ToString();
                lbldate.Text = Session["JdateTime"].ToString();
                mode = Session["Mode"].ToString();
                List<int> totseat = new List<int>();
                if (Request.QueryString["s"].ToString() != null || Request.QueryString["s"].ToString() != "" || Request.QueryString["s"].ToString() != string.Empty)
                {
                    ViewState["sessionid"] = Request.QueryString["s"].ToString();

                    tranValue = getTransactionValue(Convert.ToInt32(ViewState["sessionid"].ToString()));
                    hid_tranValue.Value = tranValue.ToString();
                    hid_session.Value = ViewState["sessionid"].ToString();
                }

                mode = Session["Mode"].ToString().Trim();
                hid_mode.Value = mode;

                Get_travellingInfodetails(Session["Source"].ToString(), Session["Destination"].ToString(), Convert.ToInt32(ViewState["sessionid"].ToString()));
                totalseat = new ArrayList();
                Session["SeatNos"] = totalseat;

            }
        }
      
    }
    protected void Button11_Click(object sender, EventArgs e)
    {

        if (Session["SeatNos"] != null)
        {
            ArrayList newArr = (ArrayList)Session["SeatNos"];
            string[] strs = hid_seatnos.Value.Split(',');

            foreach (string s in strs)
             newArr.Add(s);

            Session["SeatNos"] = newArr;
            Session["totalAmount"] = Convert.ToInt32(hid_seatAmt.Value);

        }

        Response.Redirect("Confirmation.aspx?sid=" + ViewState["sessionid"].ToString());
             
        }

    int getTransactionValue(int sid)
    {
        string cn = ConfigurationManager.ConnectionStrings["DBCon"].ToString();
        SqlConnection con = new SqlConnection(cn);
        con.Open();
        SqlCommand cmd1 = new SqlCommand("select (tran_value- (tran_value*cust_discount/100)) from tbl_schd where session_id=" + sid, con);
        int tranValue = Convert.ToInt32(cmd1.ExecuteScalar());
        return tranValue;
    }


    public void Get_travellingInfodetails(string source, string destination, int s_id)
    {
        BLSchedule obj = new BLSchedule();
        DataSet ds = obj.GetTravellingInfo(source, destination, s_id);

        if (ds.Tables[0].Rows.Count > 0 && ds != null)
        {

            lblSrc.Text = ds.Tables[0].Rows[0][1].ToString();
            lblDes.Text = ds.Tables[0].Rows[0][2].ToString();
            //lblVeh.Text = mode.ToString();
            lbldis.Text = ds.Tables[0].Rows[0][3].ToString();
            string Landmark = ds.Tables[0].Rows[0][4].ToString();
            Char[] dmter = { ',' };
            string[] LM = Landmark.Split(dmter);
            lblLM1.Text = Landmark.ToString();
            //lblLM1.Text = LM[0].ToString();
            //lblLM2.Text = LM[1].ToString();
            //lblLM3.Text = LM[2].ToString();

            lblTT.Text = ds.Tables[0].Rows[0][5].ToString();


        }
        if (ds.Tables[1].Rows.Count > 0 && ds != null)
        {
            lblMode.Text = Session["Mode"].ToString(); ;
            lblVeh.Text = Session["Mode"].ToString(); ;
            //lbldate.Text = lbldate.Text + " " + ds.Tables[1].Rows[0][3].ToString();
            lblCounter.Text = ds.Tables[1].Rows[0][0].ToString()+"<br> "+ds.Tables[1].Rows[0][2].ToString();
            Session["CounterAddress"] = lblCounter.Text.ToString();
        }


    }

    //[Ajax.AjaxMethod]
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public static string GetBookSeatInfo(int s, string mode)
    {
        DataTable dt = null;
        BLSchedule obj = new BLSchedule();

        // mode = (string)Session["Mode"].ToString();
        // int ses = Convert.ToInt32(hid_session.Value);
        DataSet ds = (DataSet)obj.GetScheduleInfo(s, mode);
        if (ds != null && ds.Tables.Count > 0)
        {
            dt = (DataTable)ds.Tables[0];
        }
        string seatno = "";


        if(dt!=null && dt.Rows.Count >=1)
        {
         for(int i=0;i< dt.Rows.Count;i++)
        {
        //    opItem = new Option(ResultDataTable.Rows[i]['vccodedesc'],ResultDataTable.Rows[i]['chcode']);   
        //    ListBoxObject.options[ListBoxObject.length] = opItem;
        seatno = seatno + (dt.Rows[i]["SeatNo"]) + ",";
        }
        }

       

        return seatno;
        //return seatno;//*/
       // return "Hello";
    }
    [WebMethod]
    public static String GetCurrentDate()
    {
        return DateTime.Now.ToString();
    }

  
}

    
    

   

