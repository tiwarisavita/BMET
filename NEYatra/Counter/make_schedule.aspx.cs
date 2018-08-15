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
using System.Drawing;
using BusinessEntity;
using BusinessLogicLib;

public partial class Counter_make_schedule : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

                LoadTime();
                
            String cn = ConfigurationManager.ConnectionStrings["DBCon"].ToString();
            SqlConnection con = new SqlConnection(cn);
            con.Open();
            TextBox1.Text = Session["cuntname"].ToString();
            SqlCommand cmd = new SqlCommand("Select vehi_number from tbl_vchinfo where cunt_name='" + TextBox1.Text+"'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                DropDownList1.Items.Add(dr[0].ToString());
                            
            }
            dr.Close();
            con.Close();
            filldropdown();
            
        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Response.Write("hello");
        String cn = ConfigurationManager.ConnectionStrings["DBCon"].ToString();
        SqlConnection con = new SqlConnection(cn);
        con.Open();
        SqlCommand cmd = new SqlCommand("Select vehi_type from tbl_vchinfo where vehi_number='" +DropDownList1.Text+"'", con);
        Response.Write(DropDownList1.Text);
        SqlDataReader dr = cmd.ExecuteReader();
        dr.Read();
        TextBox2.Text = dr[0].ToString();
        dr.Close();
        con.Close();
    }

    
    private void LoadTime()
    {
        try
        {

            for (int i = 1; i <= 12; i++)
            {
                ddlTime.Items.Add(new ListItem(i.ToString() + ":00", i.ToString() + ":00"));
                ddlTime.Items.Add(new ListItem(i.ToString() + ":30", i.ToString() + ":30"));

            }
            ddlHr.Items.Add(new ListItem("AM", "AM"));
            ddlHr.Items.Add(new ListItem("PM", "PM"));

        }
        catch (Exception)
        {

            throw;
        }


    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        String cn = ConfigurationManager.ConnectionStrings["DBCon"].ToString();
        SqlConnection con = new SqlConnection(cn);
        con.Open();
        /*
        string time = Convert.ToString(ddlTime.SelectedValue) + " " + Convert.ToString(ddlHr.SelectedValue);
        DateTime dt = Convert.ToDateTime(txtScheduleDate.Text);
        int fare=Convert.ToInt32(TextBox3.Text);
        string qry = "insert into tbl_schd(cunt_name,vehi_number,frm_city,to_city,mode,dtm_date,schd_time,tran_value) values('" + TextBox1.Text + "','" + DropDownList1.SelectedItem.ToString() + "','" + DropDownList2.SelectedItem.ToString() + "','" + DropDownList3.SelectedItem.ToString() + "','" + TextBox2.Text + "'," + Convert.ToDateTime(txtScheduleDate.Text) + ",'" + time + "'," + Convert.ToInt32(TextBox3.Text) + ")";
        SqlCommand cmd = new SqlCommand("insert into tbl_schd(cunt_name,vehi_number,frm_city,to_city,mode,dtm_date,schd_time,tran_value) values(@c,@vn,@frm_city,@to_city,@mode,@dtm_date,@schd_time,@tran_value)", con);
        cmd.Parameters.Add(new SqlParameter("@c", SqlDbType.Text, 50, TextBox1.Text.ToString()));
        cmd.Parameters.Add(new SqlParameter("@vn", SqlDbType.Text, 50, DropDownList1.SelectedItem.ToString()));

        cmd.Parameters.Add(new SqlParameter("@frm_city", SqlDbType.Text, 50, DropDownList2.SelectedItem.ToString()));
        cmd.Parameters.Add(new SqlParameter("@to_city", SqlDbType.Text, 50, DropDownList3.SelectedItem.ToString()));
        cmd.Parameters.Add(new SqlParameter("@mode", SqlDbType.Text, 50, TextBox2.Text));
        cmd.Parameters.Add(new SqlParameter("@dtm_date", SqlDbType.DateTime, 0, dt.ToString()));
        cmd.Parameters.Add(new SqlParameter("@schd_time", SqlDbType.Text, 50, time.ToString()));
        cmd.Parameters.Add(new SqlParameter("@tran_value", SqlDbType.Int, 8, fare.ToString()));



        cmd.ExecuteNonQuery();
        Response.Write("Vehicle information has been inserted successfully.");
        SqlCommand cmd = new SqlCommand(qry, con);
        int i = cmd.ExecuteNonQuery();
         */
        string time = Convert.ToString(ddlTime.SelectedValue) + " " + Convert.ToString(ddlHr.SelectedValue);
        BLSchedule obj = new BLSchedule();
        Scheduling scheduling = new Scheduling();

        scheduling.cunt_id = Session["cuntid"] == null ? 0 : Convert.ToInt32(Session["cuntid"].ToString().Trim());
        scheduling.vehi_number = DropDownList1.SelectedItem.ToString();
        scheduling.frm_city = DropDownList2.SelectedItem.ToString();
        scheduling.to_city = DropDownList3.SelectedItem.ToString();
        scheduling.mode = DropDownList4.SelectedItem.ToString();
        //DateTime dt = Convert.ToDateTime(txtScheduleDate.Text.ToString());
        //scheduling.dtm_date = Convert.ToDateTime("16-10-2011 00:00:00");
        //scheduling.dtm_date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
        scheduling.dtm_date = Convert.ToDateTime(txtScheduleDate.Text);
        scheduling.schd_time = time.ToString();
        scheduling.tran_value = Convert.ToInt32(TextBox3.Text);

        int i=obj.CreateSchedule(scheduling);
        if (i > 0)
        {
            SqlCommand cmd1 = new SqlCommand("Select max(session_id) from tbl_schd", con);
            SqlDataReader dr = cmd1.ExecuteReader();
            dr.Read();
            int sid = Convert.ToInt32(dr[0].ToString());
            Response.Write(sid.ToString());
            dr.Close();
            if (scheduling.mode.ToString() == "Sumo")
            {
                int ctr = 1;
                Response.Write(ctr.ToString());
                while (ctr <= 10)
                {

                    string s = "insert into tbl_layout_sumo(vehi_number,session_id,seat_no,booked,booking_dt,pay_status) values('" + DropDownList1.SelectedItem.ToString() + "'," + sid + "," + ctr + ",'N',null,'N')";
                    SqlCommand c1 = new SqlCommand(s, con);
                    c1.ExecuteNonQuery();
                    ctr++;
                }

            }
            if (scheduling.mode.ToString() == "Bus")
            {
                int ctr = 1;
                Response.Write(ctr.ToString());
                while (ctr <= 35)
                {

                    string s = "insert into tbl_layout_bus(vehi_number,session_id,seat_no,booked,booking_dt,pay_status) values('" + DropDownList1.SelectedItem.ToString() + "'," + sid + "," + ctr + ",'N',null,'N')";
                    SqlCommand c1 = new SqlCommand(s, con);
                    c1.ExecuteNonQuery();
                    ctr++;
                }

            }
            Response.Write("Schedule Created successfully");
        }
    }
   

    protected void filldropdown()
    {
        // Filling dropdownlist for source location
        DropDownList3.Items.Add("Digboi");
        DropDownList3.Items.Add("Guwahati");
        DropDownList3.Items.Add("Haflong");
        DropDownList3.Items.Add("Hajo");
        DropDownList3.Items.Add("Majuli");
        DropDownList3.Items.Add("Sibsagar");
        DropDownList3.Items.Add("Tezpur");
        DropDownList3.Items.Add("Dibrugarh");
        DropDownList3.Items.Add("Jorhat");
        DropDownList3.Items.Add("Marigaon");

        // Filling dropdownlist for destination location
        DropDownList2.Items.Add("Digboi");
        DropDownList2.Items.Add("Guwahati");
        DropDownList2.Items.Add("Haflong");
        DropDownList2.Items.Add("Hajo");
        DropDownList2.Items.Add("Majuli");
        DropDownList2.Items.Add("Sibsagar");
        DropDownList2.Items.Add("Tezpur");
        DropDownList2.Items.Add("Dibrugarh");
        DropDownList2.Items.Add("Jorhat");
        DropDownList2.Items.Add("Marigaon");

        DropDownList4.Items.Add("Sumo");
        DropDownList4.Items.Add("Bus");




      
    }
    protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
