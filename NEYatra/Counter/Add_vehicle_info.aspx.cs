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
using BusinessEntity;
using BusinessLogicLib;

public partial class Counter_Add_vehicle_info : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        TextBox1.Text = Session["cuntname"].ToString();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        BLSchedule obj = new BLSchedule();
        Vehicle vehicle = new Vehicle();
        vehicle.cunt_id = Session["cuntid"] == null ? 0 : Convert.ToInt32(Session["cuntid"].ToString().Trim());
        vehicle.vehi_state = TextBox2.Text;
        vehicle.vehi_number = TextBox3.Text;
        vehicle.own_name = TextBox4.Text;
        vehicle.own_address = TextBox5.Text;
        vehicle.own_phone = TextBox7.Text;
        vehicle.vehi_type = DropDownList1.SelectedItem.Text.ToString();
        vehicle.vehi_layout = DropDownList2.SelectedItem.Text.ToString();
        int i = obj.AddVehicle(vehicle);
              
        if (i > 0)
            Response.Write("Vehicle information has been inserted successfully.");
        else
            Response.Write("Error occured");


        TextBox2.Text = "";
        TextBox3.Text = "";
        TextBox4.Text = "";
        TextBox5.Text = "";
        TextBox7.Text = "";
        DropDownList1.SelectedIndex = 0;
        DropDownList2.SelectedIndex = 0;
        
      
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
