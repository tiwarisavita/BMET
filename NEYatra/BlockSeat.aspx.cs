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
using DataAccessLib;

public partial class BlockSeat : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["action"] != null)
            {
                ViewState["action"] = Request.QueryString["action"].ToString();
                if (ViewState["action"].ToString() == "R")
                    btnSave.Text = "Release Seat";
                else
                    btnSave.Text = "Block Seat";
            }
            
        }
    }
    protected void btnGetDeatils_Click(object sender, EventArgs e)
    {
        DALSchedule obj = new DALSchedule();
        DataSet ds = obj.GetAvailableSeatsDetails(Convert.ToInt32(txtSessionId.Text.Trim()), ViewState["action"].ToString());
        if (ds != null && ds.Tables.Count > 0)
        {
            lblCounter.Text = ds.Tables[0].Rows[0]["CounterName"].ToString();
            lblSource.Text = ds.Tables[0].Rows[0]["Source"].ToString();
            lblDes.Text = ds.Tables[0].Rows[0]["Destination"].ToString();
            lblMode.Text = ds.Tables[0].Rows[0]["Mode"].ToString();
            lblDate.Text = ds.Tables[0].Rows[0]["Schd_Date"].ToString();
            lblFare.Text = ds.Tables[0].Rows[0]["Fare"].ToString();

            if(ds.Tables.Count > 1)
            {
            ddlSeats.Items.Clear();
              if (ds.Tables[1].Rows.Count > 0)
             {
                for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                {
                    ddlSeats.Items.Add(ds.Tables[1].Rows[i][0].ToString());
                }
             }
            }
                    
        }
       
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {
        DALSchedule obj = new DALSchedule();
        DataTable dt = obj.BlockSeat(Convert.ToInt32(txtSessionId.Text.Trim()), lblMode.Text.Trim(), Convert.ToInt32(ddlSeats.SelectedItem.Text.ToString()),ViewState["action"].ToString());
        if (dt != null && dt.Rows.Count > 0)
        {
            if (dt.Rows[0][0].ToString() == "succcess")
            {
                if(ViewState["action"].ToString()=="B")
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Selected Seat is blocked successfully.')", true);
                else
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Selected Seat is released successfully.')", true);


            }
            else
            {
                if (ViewState["action"].ToString() == "B")
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Seat is not blocked, please try again.')", true);
                else
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Seat is not released, please try again.')", true);

            }
        }
        txtSessionId.Text = "";
        lblCounter.Text ="";
        lblSource.Text ="";
        lblDes.Text = "";
        lblMode.Text = "";
        lblDate.Text = "";
        lblFare.Text = "";

        ddlSeats.Items.Clear();
        UpdatePanel1.Update();
    }
    protected void btnBlockSession_Click(object sender, EventArgs e)
    {
        DALSchedule obj = new DALSchedule();
        DataTable dt = obj.BlockSeat(Convert.ToInt32(txtSessionId.Text.Trim()), "", 0,"S");
        if (dt != null && dt.Rows.Count > 0)
        {
            if (dt.Rows[0][0].ToString() == "succcess")
            {

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Selected Session is blocked successfully. ')", true);


            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Session is not blocked, please try again.')", true);

            }
        }
        txtSessionId.Text = "";
        lblCounter.Text = "";
        lblSource.Text = "";
        lblDes.Text = "";
        lblMode.Text = "";
        lblDate.Text = "";
        lblFare.Text = "";

        ddlSeats.Items.Clear();
        UpdatePanel1.Update();
    }
    protected void btnReleaseSession_Click(object sender, EventArgs e)
    {
        DALSchedule obj = new DALSchedule();
        DataTable dt = obj.BlockSeat(Convert.ToInt32(txtSessionId.Text.Trim()), "", 0, "E");
        if (dt != null && dt.Rows.Count > 0)
        {
            if (dt.Rows[0][0].ToString() == "succcess")
            {

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Selected Session is enabled successfully. ')", true);


            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Session is not enabled, please try again.')", true);

            }
        }
        txtSessionId.Text = "";
        lblCounter.Text = "";
        lblSource.Text = "";
        lblDes.Text = "";
        lblMode.Text = "";
        lblDate.Text = "";
        lblFare.Text = "";

        ddlSeats.Items.Clear();
        UpdatePanel1.Update();
    }
    protected void btnTimeChange_Click(object sender, EventArgs e)
    {
        DALSchedule obj = new DALSchedule();
        DataSet ds = obj.GetAvailableSeatsDetails(Convert.ToInt32(txtTime.Text.Trim()), "C");
        if (ds != null && ds.Tables.Count > 0)
        {
            if (ds.Tables[0].Rows[0][0].ToString() == "Success")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Schedule display time is chnaged successfully. ')", true);
            }
        }

        txtTime.Text = "";
    }
}
