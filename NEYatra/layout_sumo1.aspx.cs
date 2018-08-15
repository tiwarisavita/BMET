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


public partial class Counter_layout_sumo : System.Web.UI.Page
{
  public int s_id;
  int click = 0;
  //List<int> totseat = null;
  int totalAmt = 0;
  int tranValue=0;
  ArrayList totalseat = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!Page.IsPostBack)
        {
            
        if (Request.QueryString["s"].ToString() != null || Request.QueryString["s"].ToString() != "" || Request.QueryString["s"].ToString() != string.Empty)
        {
            s_id = Convert.ToInt32(Request.QueryString["s"]);
           //List<int> totseat =new List<int>();
           
            tranValue=getTransactionValue(s_id);
            ViewState["tranValue"] = tranValue;
        }
        filldata(s_id);
        totalseat = new ArrayList();
        Session["SeatNos"] = totalseat;    


       
            ViewState["flag1"] = 0;
            ViewState["flag2"] = 0;
            ViewState["flag3"] = 0;
            ViewState["flag4"] = 0;
            ViewState["flag5"] = 0;
            ViewState["flag6"] = 0;
            ViewState["flag7"] = 0;
            ViewState["flag8"] = 0;
            ViewState["flag9"] = 0;
            ViewState["flag10"] = 0;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        int s_id = Convert.ToInt32(Request.QueryString["s"]);
        if (Convert.ToInt32(ViewState["flag1"]) == 0)
        {
            click = 1;
            
            Button1.BackColor = Color.Green;
            ViewState["flag1"] = 1;

            SetStatus(Button1, 1, (int)ViewState["tranValue"]);

            ViewState["s1"] = "update tbl_layout_sumo set booked='Y' ,user_session_id=@usd,booking_dt='" + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss tt") + "' where seat_no=1 and session_id=" + s_id;
        }
        else
        {
            click = 0;
            Button1.BackColor = Color.Aqua;
            ViewState["flag1"] = 0;

            SetStatus(Button1, 0,(int)ViewState["tranValue"]);

            ViewState["s1"] = null;

        }
}
     protected void Button2_Click(object sender, EventArgs e)
    {
        int s_id = Convert.ToInt32(Request.QueryString["s"]);
        if (Convert.ToInt32(ViewState["flag2"]) == 0)
        {
            //totseat.Add(1);
            click = 1;
            
            Button2.BackColor = Color.Green;
            ViewState["flag2"] = 1;

            SetStatus(Button2, 1, (int)ViewState["tranValue"]);
            ViewState["s2"] = "update tbl_layout_sumo set booked='Y' ,user_session_id=@usd ,booking_dt='" + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss tt") + "' where seat_no=2 and session_id=" + s_id;
        }
        else
        {
            click = 0;
            Button2.BackColor = Color.Aqua;
            ViewState["flag2"] = 0;

            SetStatus(Button2, 0, (int)ViewState["tranValue"]);
            ViewState["s2"] = null;

        }
    }
     protected void Button3_Click(object sender, EventArgs e)
     {
         int s_id = Convert.ToInt32(Request.QueryString["s"]);
         if (Convert.ToInt32(ViewState["flag3"]) == 0)
         {
             //totseat.Add(2);
             click = 1;

             Button3.BackColor = Color.Green;
             ViewState["flag3"] = 1;

             SetStatus(Button3, 1, (int)ViewState["tranValue"]);

             ViewState["s3"] = "update tbl_layout_sumo set booked='Y' ,user_session_id=@usd ,booking_dt='" + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss tt") + "' where seat_no=3 and session_id=" + s_id;
         }
         else
         {
             click = 0;
             Button3.BackColor = Color.Aqua;
             ViewState["flag3"] = 0;

             SetStatus(Button3, 0, (int)ViewState["tranValue"]);

             ViewState["s3"] = null;
         }
     }
     
     protected void Button4_Click(object sender, EventArgs e)
     {
         int s_id = Convert.ToInt32(Request.QueryString["s"]);
         if (Convert.ToInt32(ViewState["flag4"]) == 0)
         {
             click = 1;
             
             Button4.BackColor = Color.Green;
             ViewState["flag4"] = 1;
             
             SetStatus(Button4, 1, (int)ViewState["tranValue"]);
             
             ViewState["s4"] = "update tbl_layout_sumo set booked='Y' ,user_session_id=@usd ,booking_dt='" + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss tt") + "' where seat_no=4 and session_id=" + s_id;
         }
         else
         {
             click = 0;
             Button4.BackColor = Color.Aqua;
             ViewState["flag4"] = 0;
             
             SetStatus(Button4, 0, (int)ViewState["tranValue"]);
             
             ViewState["s4"] = null;
         }
     }
     protected void Button5_Click(object sender, EventArgs e)
     {
         int s_id = Convert.ToInt32(Request.QueryString["s"]);
         if (Convert.ToInt32(ViewState["flag5"]) == 0)
         {
             click = 1;
             
             Button5.BackColor = Color.Green;
             ViewState["flag5"] = 1;

             SetStatus(Button5, 1, (int)ViewState["tranValue"]);
             ViewState["s5"] = "update tbl_layout_sumo set booked='Y',user_session_id=@usd ,booking_dt='" + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss tt") + "' where seat_no=5 and session_id=" + s_id;
         }
         else
         {
             click = 0;
             Button5.BackColor = Color.Aqua;
             ViewState["flag5"] = 0;
             SetStatus(Button5, 0, (int)ViewState["tranValue"]);
             ViewState["s5"] = null;
         }
     }
     protected void Button6_Click(object sender, EventArgs e)
     {
         int s_id = Convert.ToInt32(Request.QueryString["s"]);
         if (Convert.ToInt32(ViewState["flag6"]) == 0)
         {
             click = 1;
             
             Button6.BackColor = Color.Green;
             ViewState["flag6"] = 1;
             SetStatus(Button6, 1, (int)ViewState["tranValue"]);
             ViewState["s6"] = "update tbl_layout_sumo set booked='Y' ,user_session_id=@usd ,booking_dt='" + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss tt") + "' where seat_no=6 and session_id=" + s_id;
         }
         else
         {
             click = 0;
             Button6.BackColor = Color.Aqua;
             ViewState["flag6"] = 0;
             SetStatus(Button6, 0, (int)ViewState["tranValue"]);
             ViewState["s6"] = null;
         }
     }
     protected void Button7_Click(object sender, EventArgs e)
     {
         int s_id = Convert.ToInt32(Request.QueryString["s"]);
         if (Convert.ToInt32(ViewState["flag7"]) == 0)
         {
             click = 1;
             
             Button7.BackColor = Color.Green;
             ViewState["flag7"] = 1;
             SetStatus(Button7, 1, (int)ViewState["tranValue"]);
             ViewState["s7"] = "update tbl_layout_sumo set booked='Y' ,user_session_id=@usd ,booking_dt='" + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss tt") + "' where seat_no=7 and session_id=" + s_id;
         }
         else
         {
             click = 0;
             Button7.BackColor = Color.Aqua;
             ViewState["flag7"] = 0;
             SetStatus(Button7, 0, (int)ViewState["tranValue"]);
         ViewState["s7"]     = null;
         }
     }
     protected void Button8_Click(object sender, EventArgs e)
     {
         int s_id = Convert.ToInt32(Request.QueryString["s"]);
         if (Convert.ToInt32(ViewState["flag8"]) == 0)
         {
             click = 1;
            
             Button8.BackColor = Color.Green;

             ViewState["flag8"] = 1;
             SetStatus(Button8, 1, (int)ViewState["tranValue"]);
             ViewState["s8"] = "update tbl_layout_sumo set booked='Y',user_session_id=@usd ,booking_dt='" + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss tt") + "' where seat_no=8 and session_id=" + s_id;
         }
         else
         {
             click = 0;
             Button8.BackColor = Color.Aqua;

             ViewState["flag8"] = 0;


             SetStatus(Button8, 0, (int)ViewState["tranValue"]);
             ViewState["s8"] = null;
         }
     }
     protected void Button9_Click(object sender, EventArgs e)
     {
         int s_id = Convert.ToInt32(Request.QueryString["s"]);
         if (Convert.ToInt32(ViewState["flag9"]) == 0)
         {
             click = 1;
            
             Button9.BackColor = Color.Green;
             ViewState["flag9"] = 1;

             SetStatus(Button9, 1, (int)ViewState["tranValue"]);
             ViewState["s9"] = "update tbl_layout_sumo set booked='Y',user_session_id=@usd ,booking_dt='" + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss tt") + "' where seat_no=9 and session_id=" + s_id;
         }
         else
         {
             click = 0;
             Button9.BackColor = Color.Aqua;
             ViewState["flag9"] = 0;
             SetStatus(Button9, 0, (int)ViewState["tranValue"]);
             ViewState["s9"] = null;
         }
     }
     protected void Button10_Click(object sender, EventArgs e)
     {
         
         int s_id = Convert.ToInt32(Request.QueryString["s"]);
         if (Convert.ToInt32(ViewState["flag10"]) == 0)
         {
             click = 1;
             
             Button10.BackColor = Color.Green;
             ViewState["flag10"] = 1;
             SetStatus(Button10, 1, (int)ViewState["tranValue"]);
             ViewState["s10"] = "update tbl_layout_sumo set booked='Y' ,user_session_id=@usd ,booking_dt='" + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss tt") + "' where seat_no=10 and session_id=" + s_id;
         }
         else
         {
             click = 0;
             Button10.BackColor = Color.Aqua;
             ViewState["flag10"] = 0;
             SetStatus(Button10, 0, (int)ViewState["tranValue"]);
             ViewState["s10"] = null;
         }
     }
     protected void Button11_Click(object sender, EventArgs e)
     {

         if (Session["SeatNos"] == null || Session["totalAmount"]==null)
         {
             this.ClientScript.RegisterStartupScript(GetType(), "MessageAlert", "<script language='javascript'>alert('OOPS!!! Seems like you have selected any seat,please select atleast one seat');</script>");
         }
          //   if (click == 0)
         //{
             //this.ClientScript.RegisterStartupScript(GetType(), "MessageAlert", "<script language='javascript'>alert('OOPS!!! Seems like you have entered wrong user name or password,please retry');</script>");
             //ScriptManager.RegisterStartupScript(Page, this.GetType(), "msg", "alert('Please select any seat')", true);
             //this.ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('Please select any seat')", true); 
         //}
         //totseat = new List<int>();
         string cn = ConfigurationManager.ConnectionStrings["DBCon"].ToString();
         SqlConnection con = new SqlConnection(cn);
         con.Open();
         int user_sid=0;
         int s_id = Convert.ToInt32(Request.QueryString["s"]);
         SqlCommand cmd1 = new SqlCommand("insert into tbl_transaction_sumo(session_id) values(" + s_id + ")", con);
         int res=cmd1.ExecuteNonQuery();
         //cmd1 = new SqlCommand("select tran_value from tbl_schd where session_id=" + s_id, con);
         //tranValue = Convert.ToInt32(cmd1.ExecuteScalar());

         if (res > 0)
         {
             int r = 0;
             SqlCommand cmd2 = new SqlCommand("select max(user_session_id) from tbl_transaction_sumo", con);
             user_sid = Convert.ToInt32(cmd2.ExecuteScalar());
             if (ViewState["s1"] != null)
             {

                 SqlCommand cmd = new SqlCommand(ViewState["s1"].ToString(), con);
                 cmd.Parameters.Add(new SqlParameter("@usd", user_sid));
                 r = cmd.ExecuteNonQuery();
                 if (r > 0)
                 {
                     //totseat.Add(1);
                     cmd2 = new SqlCommand("update tbl_transaction_sumo set seat1='Y' where session_id=" + s_id + " and user_session_id=" + user_sid, con);
                     cmd2.ExecuteNonQuery();
                 }
             }
             if (ViewState["s2"] != null)
             {

                 SqlCommand cmd = new SqlCommand(ViewState["s2"].ToString(), con);
                 cmd.Parameters.Add(new SqlParameter("@usd", user_sid));
                 r = cmd.ExecuteNonQuery();
                 if (r > 0)
                 {
                     //totseat.Add(2);
                     cmd2 = new SqlCommand("update tbl_transaction_sumo set seat2='Y' where session_id=" + s_id + " and user_session_id=" + user_sid, con);
                     cmd2.ExecuteNonQuery();
                 }

             }
             if (ViewState["s3"] != null)
             {

                 SqlCommand cmd = new SqlCommand(ViewState["s3"].ToString(), con);
                 cmd.Parameters.Add(new SqlParameter("@usd", user_sid));
                 r = cmd.ExecuteNonQuery();
                 {
                     //totseat.Add(3);
                     cmd2 = new SqlCommand("update tbl_transaction_sumo set seat3='Y' where session_id=" + s_id + " and user_session_id=" + user_sid, con);
                     cmd2.ExecuteNonQuery();
                 }
             }
             if (ViewState["s4"] != null)
             {
                 SqlCommand cmd = new SqlCommand(ViewState["s4"].ToString(), con);
                 cmd.Parameters.Add(new SqlParameter("@usd", user_sid));
                 r = cmd.ExecuteNonQuery();
                 if (r > 0)
                 {
                     //totseat.Add(4);
                     cmd2 = new SqlCommand("update tbl_transaction_sumo set seat4='Y' where session_id=" + s_id + " and user_session_id=" + user_sid, con);
                     cmd2.ExecuteNonQuery();
                 }
             }
             if (ViewState["s5"] != null)
             {
                 SqlCommand cmd = new SqlCommand(ViewState["s5"].ToString(), con);
                 cmd.Parameters.Add(new SqlParameter("@usd", user_sid));
                 r = cmd.ExecuteNonQuery();
                 if (r > 0)
                 {
                     //totseat.Add(5);
                     cmd2 = new SqlCommand("update tbl_transaction_sumo set seat5='Y' where session_id=" + s_id + " and user_session_id=" + user_sid, con);
                     cmd2.ExecuteNonQuery();
                 }
             }
             if (ViewState["s6"] != null)
             {
                 SqlCommand cmd = new SqlCommand(ViewState["s6"].ToString(), con);
                 cmd.Parameters.Add(new SqlParameter("@usd", user_sid));
                 r = cmd.ExecuteNonQuery();
                 if (r > 0)
                 {
                     //totseat.Add(6);
                     cmd2 = new SqlCommand("update tbl_transaction_sumo set seat6='Y' where session_id=" + s_id + " and user_session_id=" + user_sid, con);
                     cmd2.ExecuteNonQuery();
                 }
             }
             if (ViewState["s7"] != null)
             {
                 SqlCommand cmd = new SqlCommand(ViewState["s7"].ToString(), con);
                 cmd.Parameters.Add(new SqlParameter("@usd", user_sid));
                 r = cmd.ExecuteNonQuery();
                 if (r > 0)
                 {
                     //totseat.Add(7);
                     cmd2 = new SqlCommand("update tbl_transaction_sumo set seat7='Y' where session_id=" + s_id + " and user_session_id=" + user_sid, con);
                     cmd2.ExecuteNonQuery();
                 }
             }
             if (ViewState["s8"] != null)
             {
                 SqlCommand cmd = new SqlCommand(ViewState["s8"].ToString(), con);
                 cmd.Parameters.Add(new SqlParameter("@usd", user_sid));
                 r = cmd.ExecuteNonQuery();
                 if (r > 0)
                 {
                     //totseat.Add(8);
                     cmd2 = new SqlCommand("update tbl_transaction_sumo set seat8='Y' where session_id=" + s_id + " and user_session_id=" + user_sid, con);
                     cmd2.ExecuteNonQuery();
                 }
             }
             if (ViewState["s9"] != null)
             {
                 SqlCommand cmd = new SqlCommand(ViewState["s9"].ToString(), con);
                 cmd.Parameters.Add(new SqlParameter("@usd", user_sid));
                 r = cmd.ExecuteNonQuery();
                 if (r > 0)
                 {
                     //totseat.Add(9);
                     cmd2 = new SqlCommand("update tbl_transaction_sumo set seat9='Y' where session_id=" + s_id + " and user_session_id=" + user_sid, con);
                     cmd2.ExecuteNonQuery();
                 }
             }
             if (ViewState["s10"] != null)
             {
                 SqlCommand cmd = new SqlCommand(ViewState["s10"].ToString(), con);
                 cmd.Parameters.Add(new SqlParameter("@usd", user_sid));
                 r = cmd.ExecuteNonQuery();
                 if (r > 0)
                 {
                     //totseat.Add(10);
                     cmd2 = new SqlCommand("update tbl_transaction_sumo set seat10='Y' where session_id=" + s_id + " and user_session_id=" + user_sid, con);
                     cmd2.ExecuteNonQuery();
                 }
             }

             if (Session["totalAmount"] != null)
             {
                 totalAmt = (int)Session["totalAmount"];
             }
             cmd2 = new SqlCommand("update tbl_transaction_sumo set amount="+totalAmt+"where session_id=" + s_id + " and user_session_id=" + user_sid, con);
             cmd2.ExecuteNonQuery();

             con.Close();


             
             Response.Redirect("Confirmation.aspx?sid=" + s_id + "&user_sid=" + user_sid);
         }
     }

     public void filldata(int sessionid)
     {
         BLSchedule obj = new BLSchedule();
         DataSet ds = obj.GetScheduleInfo(s_id, Session["VType"].ToString());
         if (ds != null && ds.Tables[0].Rows.Count > 0)
         {
             if (Convert.ToInt32(ds.Tables[0].Rows[0][2]) == 1 && ds.Tables[0].Rows[0][3].ToString() == "Y")
             {
                 Button1.BackColor = Color.Red;
                 Button1.Enabled = false;
             }
             if (Convert.ToInt32(ds.Tables[0].Rows[1][2]) == 2 && ds.Tables[0].Rows[1][3].ToString() == "Y")
             {
                 Button2.BackColor = Color.Red;
                 Button2.Enabled = false;
             }

             if (Convert.ToInt32(ds.Tables[0].Rows[2][2]) == 3 && ds.Tables[0].Rows[2][3].ToString() == "Y")
             {
                 Button3.BackColor = Color.Red;
                 Button3.Enabled = false;
             }

             if (Convert.ToInt32(ds.Tables[0].Rows[3][2]) == 4 && ds.Tables[0].Rows[3][3].ToString() == "Y")
             {
                 Button4.BackColor = Color.Red;
                 Button4.Enabled = false;
             }
             if (Convert.ToInt32(ds.Tables[0].Rows[4][2]) == 5 && ds.Tables[0].Rows[4][3].ToString() == "Y")
             {
                 Button5.BackColor = Color.Red;
                 Button5.Enabled = false;
             }
             if (Convert.ToInt32(ds.Tables[0].Rows[5][2]) == 6 && ds.Tables[0].Rows[5][3].ToString() == "Y")
             {
                 Button6.BackColor = Color.Red;
                 Button6.Enabled = false;
             }
             if (Convert.ToInt32(ds.Tables[0].Rows[6][2]) == 7 && ds.Tables[0].Rows[6][3].ToString() == "Y")
             {
                 Button7.BackColor = Color.Red;
                 Button7.Enabled = false;
             }
             if (Convert.ToInt32(ds.Tables[0].Rows[7][2]) == 8 && ds.Tables[0].Rows[7][3].ToString() == "Y")
             {
                 Button8.BackColor = Color.Red;
                 Button8.Enabled = false;
             }
             if (Convert.ToInt32(ds.Tables[0].Rows[8][2]) == 9 && ds.Tables[0].Rows[8][3].ToString() == "Y")
             {
                 Button9.BackColor = Color.Red;
                 Button9.Enabled = false;
             }
             if (Convert.ToInt32(ds.Tables[0].Rows[9][2]) == 10 && ds.Tables[0].Rows[9][3].ToString() == "Y")
             {
                 Button10.BackColor = Color.Red;
                 Button10.Enabled = false;
             }


         }
     }

     //Status -0 for deletion and 1 for addition
     void SetStatus(System.Web.UI.WebControls.Button   b, int status, int tranvalue)
     {
         if (Session["SeatNos"] != null)
         {
             ArrayList newArr = (ArrayList)Session["SeatNos"];

             if (status == 1)
             {
                 newArr.Add(b.Text.ToString());
             }   
             else
             {
                 newArr.Remove(b.Text.ToString());
             }
             SeatTxt.Text = "";
             SeatAmt.Text = "";
             for (int i = 0; i < newArr.Count; i++)
             {
                 if ((newArr.IndexOf(newArr[i])) == (newArr.Count - 1))
                 {
                     SeatTxt.Text = SeatTxt.Text + (newArr[i].ToString() + "");
                    
                 }
                 else
                 {
                     SeatTxt.Text = SeatTxt.Text + (newArr[i].ToString() + ",");
                     
                 }


             }
             SeatAmt.Text = (newArr.Count * tranvalue).ToString();
             Session["SeatNos"] = newArr;
             Session["totalAmount"] = Convert.ToInt32(SeatAmt.Text.ToString());

         }




     }

     int getTransactionValue(int sid)
     {
         string cn = ConfigurationManager.ConnectionStrings["DBCon"].ToString();
         SqlConnection con = new SqlConnection(cn);
         con.Open();
         SqlCommand cmd1 = new SqlCommand("select tran_value from tbl_schd where session_id=" + sid, con);
         int tranValue = Convert.ToInt32(cmd1.ExecuteScalar());
         return tranValue;
     }

}
