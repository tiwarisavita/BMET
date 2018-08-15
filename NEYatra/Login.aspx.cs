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

public partial class Counter_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        TextBox1.Text = "";
        TextBox2.Text = "";
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        string user_name = TextBox1.Text;
        string pwd = TextBox2.Text;
        LoginInfo LoginObj = new LoginInfo();
        DataTable dt = LoginObj.GetLoginInfo(user_name, pwd);
               
        if (dt.Rows.Count>0)
        {
            char enable = Convert.ToChar(dt.Rows[0]["user_enable"]);
            if (enable == 'Y')
            {
                Session["cuntname"] = dt.Rows[0]["cunt_name"];
                Session["cuntid"] = dt.Rows[0]["cunt_id"];
                Response.Redirect("counter_page.aspx");
               
            }
            else
                Response.Write("Access Denied");
        }
        else
            Response.Write("Invalid Login");

        
    }
}
