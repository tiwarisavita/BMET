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
using BusinessLogicLib;
using System.Web.Services;
public partial class LayoutBus_2_1_37 : System.Web.UI.Page
{
    int tranValue = 0;
    int s_id;
    ArrayList totalseat = null;
    string mode = "";
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            Ajax.Utility.RegisterTypeForAjax(typeof(LayoutBus_2_1_37), this);

            if (Session["Source"] == null || Session["Destination"] == null || Session["Mode"] == null || Session["JdateTime"] == null || Request.QueryString["s"] == null)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Message", "alert('Session is expired, please try again.');window.location='Default.aspx'; ", true);
                // Response.Redirect("Default.aspx");
            }
            else
            {
                lblSource.Text = Session["Source"].ToString();
                lblDestination.Text = Session["Destination"].ToString();
                lblMode.Text = Session["Mode"].ToString();
                lbldate.Text = Session["JdateTime"].ToString();

                if (Request.QueryString["s"].ToString() != null || Request.QueryString["s"].ToString() != "" || Request.QueryString["s"].ToString() != string.Empty)
                {
                    ViewState["sessionid"] = Convert.ToInt32(Request.QueryString["s"]);
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

    int getTransactionValue(int sid)
    {
        string cn = ConfigurationManager.ConnectionStrings["DBCon"].ToString();
        SqlConnection con = new SqlConnection(cn);
        con.Open();
        SqlCommand cmd1 = new SqlCommand("select (tran_value- (tran_value*cust_discount/100)) from tbl_schd where session_id=" + sid, con);
        int tranValue = Convert.ToInt32(cmd1.ExecuteScalar());
        return tranValue;
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

    //[Ajax.AjaxMethod]
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public static string GetBookSeatInfo(int s, string mode)
    {
        DataTable dt = null;
        BLSchedule obj = new BLSchedule();


        DataSet ds = (DataSet)obj.GetScheduleInfo(s, mode);
        if (ds != null && ds.Tables.Count > 0)
        {
            dt = (DataTable)ds.Tables[0];
        }
        string seatno = "";


        if (dt != null && dt.Rows.Count >= 1)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                seatno = seatno + (dt.Rows[i]["SeatNo"]) + ",";
            }
        }



        return seatno;

    }
    public void Get_travellingInfodetails(string source, string destination, int s_id)
    {
        BLSchedule obj = new BLSchedule();
        DataSet ds = obj.GetTravellingInfo(source, destination, s_id);

        if (ds.Tables[0].Rows.Count > 0 && ds.Tables[0] != null)
        {

            lblSource.Text = ds.Tables[0].Rows[0][1].ToString();
            lblDestination.Text = ds.Tables[0].Rows[0][2].ToString();
            lblDistance.Text = ds.Tables[0].Rows[0][3].ToString();
            lblBPoints.Text = ds.Tables[0].Rows[0][4].ToString();
            lblTravelTime.Text = ds.Tables[0].Rows[0][5].ToString();


        }
        if (ds.Tables[1].Rows.Count > 0 && ds.Tables[1] != null)
        {
            lblMode.Text = ds.Tables[1].Rows[0][1].ToString();
            lblCounter.Text = ds.Tables[1].Rows[0][0].ToString() + "<br> " + ds.Tables[1].Rows[0][2].ToString();
            Session["CounterAddress"] = lblCounter.Text.ToString();
        }


    }
}
