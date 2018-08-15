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

public partial class Counter_counter_page : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string un=Session["cuntname"].ToString();
        Label1.Text = "Welcome " + un;
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {

       
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
}
