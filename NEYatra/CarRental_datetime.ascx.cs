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

public partial class CarRental_datetime : System.Web.UI.UserControl
{
    public void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LoadTime();
            TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
            DateTime indianTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);
            txtLocalDate.Text = indianTime.AddDays(1).ToString("dd-MMM-yyyy");
        }
    }
    private void LoadTime()
    {
        try
        {
            ddlpickuptime.Items.Add(new ListItem("12:00 AM", "12:00 AM"));
            ddlpickuptime.Items.Add(new ListItem("12:30 AM", "12:30 AM"));
            for (int i = 1; i <= 11; i++)
            {
                if (i < 10)
                {
                    ddlpickuptime.Items.Add(new ListItem("0" + i.ToString() + ":00 AM", i.ToString() + ":00 AM"));
                    ddlpickuptime.Items.Add(new ListItem("0" + i.ToString() + ":30 AM", i.ToString() + ":30 AM"));
                }
                else
                {
                    ddlpickuptime.Items.Add(new ListItem(i.ToString() + ":00 AM", i.ToString() + ":00 AM"));
                    ddlpickuptime.Items.Add(new ListItem(i.ToString() + ":30 AM", i.ToString() + ":30 AM"));
                }

            }
            ddlpickuptime.Items.Add(new ListItem("12:00 PM", "12:00 PM"));
            ddlpickuptime.Items.Add(new ListItem("12:30 PM", "12:30 PM"));
            for (int i = 1; i <= 11; i++)
            {
                if (i < 10)
                {
                    ddlpickuptime.Items.Add(new ListItem("0" + i.ToString() + ":00 PM", i.ToString() + ":00 PM"));
                    ddlpickuptime.Items.Add(new ListItem("0" + i.ToString() + ":30 PM", i.ToString() + ":30 PM"));
                }
                else
                {
                    ddlpickuptime.Items.Add(new ListItem(i.ToString() + ":00 PM", i.ToString() + ":00 PM"));
                    ddlpickuptime.Items.Add(new ListItem(i.ToString() + ":30 PM", i.ToString() + ":30 PM"));
                }

            }


        }
        catch (Exception)
        {

            throw;
        }


    }

    public String GetDate
    {
        get
        {
            return Convert.ToDateTime(txtLocalDate.Text.ToString()).ToString("dd-MMM-yyyy");
        }

    }
    public String GetTime
    {
        get
        {
            return ddlpickuptime.SelectedItem.Text ;
        }

    }

   
}