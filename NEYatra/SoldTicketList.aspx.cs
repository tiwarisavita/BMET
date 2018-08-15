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


public partial class SoldTicketList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            fillgrid();        
        }
    }
    void fillgrid()
    {
        DALSchedule obj = new DALSchedule();
        DataTable dt=obj.GetSoldTicketsList("Shared");
        grdSoldTickets.DataSource = dt;
        grdSoldTickets.DataBind();
        

    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        DALSchedule obj = new DALSchedule();
        DataTable dt = obj.GetSoldTicketsList("Shared");
        ExportTableData(dt);
        dt = null;
       
    }
     public void ExportTableData(DataTable dtdata)
        {
            string attach = "attachment;filename=TicketList.xls";
            Response.ClearContent();
            Response.AddHeader("content-disposition", attach);
            Response.ContentType = "application/ms-excel";
            if (dtdata != null)
            {
                foreach (DataColumn dc in dtdata.Columns)
                {
                    Response.Write(dc.ColumnName + "\t");
                    //sep = ";";
                }
                Response.Write(System.Environment.NewLine);
                foreach (DataRow dr in dtdata.Rows)
                {
                    for (int i = 0; i < dtdata.Columns.Count; i++)
                    {
                        Response.Write(dr[i].ToString() + "\t");
                    }
                    Response.Write("\n");
                }
                Response.End();
            }
        }
     protected void grdSoldTickets_PageIndexChanging(object sender, GridViewPageEventArgs e)
     {
         grdSoldTickets.PageIndex = e.NewPageIndex;
         fillgrid();
     }
     protected void grdSoldTickets_RowDataBound(object sender, GridViewRowEventArgs e)
     {
         if ((e.Row.RowType == DataControlRowType.DataRow))
         {
           
             DataRowView drv = (DataRowView)e.Row.DataItem;
             string temp=drv["cancel"].ToString();
             if (temp == "Cancel")
             {
                 e.Row.ForeColor = System.Drawing.Color.Red;
             }
           

           
         }



         /*Added on 16/12/2011*/


        
     }
    public override void VerifyRenderingInServerForm(Control control)
    {
    }

}
