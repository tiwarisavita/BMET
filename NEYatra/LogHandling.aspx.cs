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

public partial class LogHandling : System.Web.UI.Page
{
   
       protected string filePath = HttpContext.Current.Server.MapPath("./ErrorLog/" + "Error_" + DateTime.Now.Month.ToString() + "_" + DateTime.Now.Year.ToString() + "_Log.XML");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindGrid();

            }
        }

        protected void BindGrid()
        {
            DataSet DsXML = new DataSet();
            DataTable dt = new DataTable();


            DsXML.ReadXml(filePath, XmlReadMode.ReadSchema);
            dt = DsXML.Tables[0].Clone();
            dt.Columns[2].DataType = System.Type.GetType("System.DateTime");
            dt.Columns[2].DateTimeMode = System.Data.DataSetDateTime.UnspecifiedLocal;

            if (DsXML.Tables[0].Rows.Count > 0)
                for (int i = 0; i < DsXML.Tables[0].Rows.Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    for (int j = 0; j < DsXML.Tables[0].Columns.Count; j++)
                    {
                        dr[j] = DsXML.Tables[0].Rows[i][j];
                    }
                    dt.Rows.Add(dr);
                }


            Session["XMLDS"] = dt;
            GridLog.DataSource = dt;
            GridLog.DataBind();
        }
        protected void GridLog_PageIndexChanged(object sender, EventArgs e)
        {


        }
        protected void GridLog_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridLog.PageIndex = e.NewPageIndex;
            GridLog.DataSource = (DataTable)Session["XMLDS"];
            GridLog.DataBind();
        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
            trLabel.Visible = false;

            DataSet DsXML;
            DateTime dt = Convert.ToDateTime(txtFrom.Text);
            DataTable dtable = new DataTable();

            dtable = ((DataTable)Session["XMLDS"]).Clone();
            dtable.Columns[2].DataType = System.Type.GetType("System.DateTime");
            dtable.Columns[2].DateTimeMode = System.Data.DataSetDateTime.UnspecifiedLocal;


            if (dt.Month == DateTime.Now.Month)
                dtable = (DataTable)Session["XMLDS"];
            else if (dt.Month < DateTime.Now.Month)
            {
                for (int k = dt.Month; k <= DateTime.Now.Month; k++)
                {
                    DsXML = new DataSet();
                    filePath = HttpContext.Current.Server.MapPath("./ErrorLog/" + "Error_" + k.ToString() + "_" + dt.Year.ToString() + "_Log.XML");
                    if (System.IO.File.Exists(filePath))
                        DsXML.ReadXml(filePath, XmlReadMode.ReadSchema);
                    else
                        break;

                    if (DsXML.Tables[0].Rows.Count > 0)
                        for (int i = 0; i < DsXML.Tables[0].Rows.Count; i++)
                        {
                            DataRow dr = dtable.NewRow();
                            for (int j = 0; j < DsXML.Tables[0].Columns.Count; j++)
                            {
                                dr[j] = DsXML.Tables[0].Rows[i][j];
                            }
                            dtable.Rows.Add(dr);
                        }
                }
                Session["XMLDS"] = dtable;
            }




            if (txtFrom.Text != "")
            {

                string str = dt.ToString().Substring(0, 10);
                // string rowFilter = "Error_DateTime LIKE '" + str + "*'";
                // string rowFilter = "{2} > '#" + Convert.ToDateTime(txtFrom.Text) + "#' and {2}<'#" + Convert.ToDateTime(txtTo.Text) + "#'";
                string rowFilter = "[Error_DateTime] >=# " + Convert.ToDateTime(txtFrom.Text) + "# and [Error_DateTime] <= #" + Convert.ToDateTime(txtTo.Text) + "#";

                dtable.DefaultView.RowFilter = rowFilter;


                // Session["XMLDS"] = DsXML;
                if (dtable.DefaultView.Count > 0)
                {
                    GridLog.DataSource = dtable.DefaultView;
                    GridLog.DataBind();
                    lblNoRec.Visible = false;
                }
                else
                {
                    GridLog.DataSource = dtable.DefaultView;
                    GridLog.DataBind();
                    lblNoRec.Visible = true;
                }
            }
            else
                BindGrid();
        }

        protected void GridLog_Init(object sender, EventArgs e)
        {

        }
    }

