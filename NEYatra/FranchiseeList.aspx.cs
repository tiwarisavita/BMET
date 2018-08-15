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
using System.Xml.Linq;
using DataAccessLib;

public partial class FranchiseeList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            BindRepeaterData();
            ddlFranCity.Items.Clear();
            ddlFranCity.Items.Insert(0, new ListItem("-------Select--------", "-1"));
            filldropdown();
        }
    }
    protected void BindRepeaterData()
    {
        DALSchedule objDAL = new DALSchedule();
        DataTable dt=objDAL.GetFranchiseeList("");
        RepSample.DataSource = dt;
        RepSample.DataBind();
        objDAL = null;
        dt = null;
    }
    protected void filldropdown()
    {
        // Filling dropdownlist for source location
        ddlFranCity.Items.Add("Guwahati");
        ddlFranCity.Items.Add("Hailakandi");
        ddlFranCity.Items.Add("Karimganj");
        ddlFranCity.Items.Add("Silchar"); 
     
    }
    protected void ddlFranCity_SelectedIndexChanged(object sender, EventArgs e)
    {
        DALSchedule objDAL = new DALSchedule();
        DataTable dt = null;
        if(ddlFranCity.SelectedItem.Text.ToString()=="-------Select--------")
        dt = objDAL.GetFranchiseeList("");
        else
        dt = objDAL.GetFranchiseeList(ddlFranCity.SelectedItem.Text.ToString());
        RepSample.DataSource = dt;
        RepSample.DataBind();
        objDAL = null;
        dt = null;
    }
}
