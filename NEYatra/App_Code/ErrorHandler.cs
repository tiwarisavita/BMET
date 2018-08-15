using System;
//using System.Web.UI;
using System.Web;
using System.Configuration;
using System.IO;
using System.Text;
using System.Data;
using System.Data.SqlClient;
//using System.Web.UI.HtmlControls;
using System.Xml;
using System.ComponentModel;

/// <summary>
/// Summary description for ErrorHandler
/// </summary>
public class ErrorHandler
{

  
        #region variables
        DataSet Ds;
        DataView Dv = null;
        DataTable Dt = null;
        DataColumn Dc = null;
        DataRow Dr = null;

        public string filePath = null;
        public string Serial_No = null;
        public string Error_Type = null;
        public string Error_DateTime = null;
        public string Error_Description = null;
        public string Error_Source = null;
        public string Error_Stack_Trace = null;
        public string Error_Caused_By_Method = null;
        public string Help_Link = null;
        public string Logon_User = null;
        public string Status = null;
        public string HandledBy = null;
        public string HandledOn = null;
        public string Solu_Desc = null;
        public string BrowserInfo = null;
        public string App_Phy_Path = null;
        public string File_Path = null;
        public string Assign_To = null;
        public string Assignee_Name = string.Empty;
        public string Logon_User_Display = string.Empty;
        bool isSave = false;
        /// <summary>
        /// //////////For checking whether Log is saved or not.
        /// </summary>
        bool isLog = false;

        string[] ArrXmlNodes = { "Serial_No", "Error_Type", "Error_DateTime", "Error_Description", "Error_Source", "Error_Stack_Trace", "Error_Caused_By_Method", "Help_Link", "Logon_User", "Status", "HandledBy", "HandledOn", "Solu_Desc", "BrowserInfo", "App_Phy_Path", "File_Path", "Assign_To", "Assignee_Name", "Logon_User_Display" };
        #endregion


        #region Constructor
        //Constructor
        public ErrorHandler()
        {
            Initialize();
            if (!chkExist(filePath)) CreateLogFile(filePath);
        }

        #endregion


        #region Properties
        [Browsable(true), Category("Deployment Mode"), DefaultValue("false"), Description("Is deployment mode.")]
        public bool IsDeploymentMode
        {
            get { return isSave; }
            set { isSave = value; }
        }

        public bool IsLogSaved
        {
            get { return isLog; }
            set { isLog = value; }
        }

        #endregion


        #region Methods
        private void Initialize()
        {
            if (filePath == null)
            {
                filePath = System.Configuration.ConfigurationManager.AppSettings["Logs"].ToString();
                // filePath = HttpContext.Current.Server.MapPath("");
                string serverPath = HttpContext.Current.Request.ServerVariables["APPL_PHYSICAL_PATH"];
                filePath = serverPath + filePath;
                if (!Directory.Exists(filePath)) Directory.CreateDirectory(filePath);
                filePath = filePath + "\\Error_" + DateTime.Now.Month.ToString() + "_" + DateTime.Now.Year.ToString() + "_Log.XML";

            }
        }

        //To Check the Exitance of XML File for Logging

        private bool chkExist(string filePath)
        {

            if (System.IO.File.Exists(filePath))
            {
                return true;
            }
            else
            {
                return false;
            }


        }

        //Creating The log file With XML Schema...

        private void CreateLogFile(string errorlogfilepath)
        {
            Ds = new DataSet();
            Dt = new DataTable();

            for (int i = 0; i < ArrXmlNodes.Length; i++)
            {
                Dc = new DataColumn(ArrXmlNodes[i], System.Type.GetType("System.String"));
                Dt.Columns.Add(Dc);
                Dc = null;
            }
            Ds.Tables.Add(Dt);
            Ds.WriteXml(errorlogfilepath, System.Data.XmlWriteMode.WriteSchema);

            Ds = null;
            Dt = null;
            Dc = null;
        }

        private DataSet PopulateDataSet()
        {
            Ds = new DataSet();
            Ds.ReadXml(filePath, XmlReadMode.ReadSchema);
            //System.Web.HttpContext.Current.Cache.Insert(ProductCacheName, dsProducts, new CacheDependency(sPath));
            return Ds;
        }

        private int MaxValue()
        {
            DataSet DscurData = PopulateDataSet();
            Dt = new DataTable();
            Dv = new DataView();
            int MaxVal = 0;

            if (DscurData != null)
            {
                if (DscurData.Tables[0].Rows.Count >= 1)
                {
                    Dt = DscurData.Tables[0];
                    Dv = Dt.DefaultView;
                    int index = Convert.ToInt32(Dv.Count) - 1;
                    MaxVal = Convert.ToInt32(Dt.Rows[index][0]);
                    Ds = null;
                    Dt = null;
                    Dv = null;
                    DscurData = null;
                }
            }
            return MaxVal + 1;


        }

        /// <summary>
        /// //////////////////////////////This code is added by Savita for reading the contents from Xml file.
        /// </summary>
        /// <returns></returns>
        public String ReadMailContents()
        {
            string ErrorMailBody = "";
            Ds = new DataSet();
            Ds.ReadXml(filePath, XmlReadMode.ReadSchema);
            if (Ds != null)
            {
                if (Ds.Tables[0].Rows.Count >= 1)
                {
                    Dt = Ds.Tables[0];
                    Dv = Dt.DefaultView;
                    int index = Convert.ToInt32(Dv.Count) - 1;
                    int  MaxVal = Convert.ToInt32(Dt.Rows[index][0]);
                   
                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                                      
                    ErrorMailBody = ErrorMailBody + " <html> ";
                    ErrorMailBody = ErrorMailBody + " <body>";
                    ErrorMailBody = ErrorMailBody + " <span style='font-family: Verdana'><span style='font-size: 10pt'> ";
                    ErrorMailBody = ErrorMailBody + " <strong><span style='color: #ff0033'>An Error occured in one of your respective Module at Value Portal<br /> ";
                    ErrorMailBody = ErrorMailBody + " <br /> ";
                    ErrorMailBody = ErrorMailBody + " Error details are:  </span></strong><br /> ";
                    ErrorMailBody = ErrorMailBody + " </span></span> ";
                    ErrorMailBody = ErrorMailBody + " <br /> ";
                    ErrorMailBody = ErrorMailBody + " <table cellspacing='0' cellpadding='0' width='100%' align='center'  border='1'> ";
                    ErrorMailBody = ErrorMailBody + " <tbody> ";
                    ErrorMailBody = ErrorMailBody + " <tr> ";
                    ErrorMailBody = ErrorMailBody + " <td align='middle'><table id='Table5' bordercolor='#336699' cellspacing='1' cellpadding='3' width='100%' border='0'> ";
                    ErrorMailBody = ErrorMailBody + " <tbody> ";
                    ErrorMailBody = ErrorMailBody + " <tr valign='center' bgcolor='darkblue'> ";
                    ErrorMailBody = ErrorMailBody + " <td colspan='4' height='15'><div align='left'><strong><span style='color: #ffffff; font-size: 10pt; font-family: Verdana;'>Error Details</span></strong></div></td> ";
                    ErrorMailBody = ErrorMailBody + " </tr> ";
                    ErrorMailBody = ErrorMailBody + " <tr valign='center'> ";
                    ErrorMailBody = ErrorMailBody + " <td width='17%' bgcolor='#ffffff' height='25' style='font-size: 10pt; font-family: Verdana; color: #00008b; text-decoration: none;'><div align='right'> ";
                    ErrorMailBody = ErrorMailBody + " <strong>Error No</strong> : </div></td> ";
                    ErrorMailBody = ErrorMailBody + " <td width='25%' bgcolor='#ffffff' height='25' style='font-size: 10pt; font-family: Verdana; color: #00008b; text-decoration: none;'> ";
                    ErrorMailBody = ErrorMailBody + MaxVal.ToString();
                    ErrorMailBody = ErrorMailBody + " </td> ";
                    ErrorMailBody = ErrorMailBody + " <td width='17%' bgcolor='#ffffff' height='25' style='font-size: 10pt; font-family: Verdana; color: #00008b; text-decoration: none;'><div align='right'> ";
                    ErrorMailBody = ErrorMailBody + " <strong>Open Date &amp; Time </strong>: </div></td> ";
                    ErrorMailBody = ErrorMailBody + " <td width='41%' bgcolor='#ffffff' height='25' style='font-size: 10pt; font-family: Verdana; color: #00008b; text-decoration: none;'> ";
                    ErrorMailBody = ErrorMailBody + Dt.Rows[index][2].ToString();
                    ErrorMailBody = ErrorMailBody + " </td> ";
                    ErrorMailBody = ErrorMailBody + " </tr> ";
                    ErrorMailBody = ErrorMailBody + " <tr valign='center'> ";
                    ErrorMailBody = ErrorMailBody + " <td bgcolor='#ffffff' height='25' style='font-size: 10pt; font-family: Verdana; color: #00008b; text-decoration: none;'><div align='right'> ";
                    ErrorMailBody = ErrorMailBody + " <strong>Error Type</strong> : </div></td> ";
                    ErrorMailBody = ErrorMailBody + " <td bgcolor='#ffffff' height='25' style='font-size: 10pt; font-family: Verdana; color: #00008b; text-decoration: none;'> " + Dt.Rows[index][1].ToString() + "</td> ";
                    ErrorMailBody = ErrorMailBody + " <td bgcolor='#ffffff' height='25' style='font-size: 10pt; font-family: Verdana; color: #00008b; text-decoration: none;'><div align='right'> ";
                    ErrorMailBody = ErrorMailBody + " <strong>Error Description</strong> : </div></td> ";
                    ErrorMailBody = ErrorMailBody + " <td bgcolor='#ffffff' height='25' style='font-size: 10pt; font-family: Verdana; color: #ff0033; text-decoration: none;'> " + Dt.Rows[index][3].ToString() + "</td> ";
                    ErrorMailBody = ErrorMailBody + " </tr> ";
                    ErrorMailBody = ErrorMailBody + " <tr valign='center'> ";
                    ErrorMailBody = ErrorMailBody + " <td bgcolor='#ffffff' height='25' style='font-size: 10pt; font-family: Verdana; color: #00008b; text-decoration: none;'><div align='right'> ";
                    ErrorMailBody = ErrorMailBody + " <strong>Error Source </strong>: ";
                    ErrorMailBody = ErrorMailBody + " </div></td> ";
                    ErrorMailBody = ErrorMailBody + " <td bgcolor='#ffffff' height='25' style='font-size: 10pt; font-family: Verdana; color: #00008b; text-decoration: none;'> " + Dt.Rows[index][4].ToString() +"</td> ";
                    ErrorMailBody = ErrorMailBody + " <td bgcolor='#ffffff' height='25' style='font-size: 10pt; font-family: Verdana; color: #00008b; text-decoration: none;'><div align='right'> ";
                    ErrorMailBody = ErrorMailBody + " <strong>Status </strong>: </div></td> ";
                    ErrorMailBody = ErrorMailBody + " <td bgcolor='#ffffff' height='25' style='font-size: 10pt; font-family: Verdana; color: #00008b; text-decoration: none;'> " + Dt.Rows[index][9].ToString() +"</td> ";
                    ErrorMailBody = ErrorMailBody + " </tr> ";
                    ErrorMailBody = ErrorMailBody + " <tr valign='center'> ";
                    ErrorMailBody = ErrorMailBody + " <td bgcolor='#ffffff' height='25' style='font-size: 10pt; font-family: Verdana; color: #00008b; text-decoration: none;'><div align='right'> ";
                    ErrorMailBody = ErrorMailBody + " <strong>File Path </strong>: </div></td> ";
                    ErrorMailBody = ErrorMailBody + " <td bgcolor='#ffffff' height='25' style='font-size: 10pt; font-family: Verdana; color: #ff0033; text-decoration: none;'><div align='left' name='select'> ";
                    ErrorMailBody = ErrorMailBody + " " + Dt.Rows[index][15].ToString() +"</div></td> ";
                    ErrorMailBody = ErrorMailBody + " <td bgcolor='#ffffff' height='25' style='font-size: 10pt; font-family: Verdana; color: #00008b; text-decoration: none;'><div align='right'> ";
                    ErrorMailBody = ErrorMailBody + " <strong>Application Path</strong> : </div></td> ";
                    ErrorMailBody = ErrorMailBody + " <td bgcolor='#ffffff'  height='25' style='font-size: 10pt; font-family: Verdana; color: #00008b; text-decoration: none;'><div align='left' name='select'> ";
                    ErrorMailBody = ErrorMailBody + " " + App_Phy_Path + "</div></td> ";
                    
                    ErrorMailBody = ErrorMailBody + " </tr> ";
                    //ErrorMailBody = ErrorMailBody + " <tr valign='center'> ";
                    //ErrorMailBody = ErrorMailBody + " <td bgcolor='#ffffff' height='25' style='font-size: 10pt; font-family: Verdana; color: #00008b; text-decoration: none;'><div align='right'> ";
                    //ErrorMailBody = ErrorMailBody + " <strong>Re-Assign</strong>: </div></td> ";
                    //ErrorMailBody = ErrorMailBody + " <td bgcolor='#ffffff' colspan='2' style='font-size: 10pt; font-family: Verdana; color: #00008b; text-decoration: none;'> ";
                    //ErrorMailBody = ErrorMailBody + " <div align='center' name='select'><b><a href='http://10.113.14.45/Mps/ErrorReassign.aspx?errorid=" + Serial_No + "&assignee=" + this.OwnerEcode.Trim() + "&close=N'>Reassign</a></b></div></td> ";
                    //ErrorMailBody = ErrorMailBody + " <td bgcolor='#ffffff' colspan='1' style='font-size: 10pt; font-family: Verdana; color: #00008b; text-decoration: none;'> ";
                    //ErrorMailBody = ErrorMailBody + " <div align='center' name='select'><b><a href='http://10.113.14.45/Mps/ErrorReassign.aspx?errorid=" + Serial_No + "&assignee=" + this.OwnerEcode.Trim() + "&close=Y'>Resolve & Close</a></b></div></td> ";
                    //ErrorMailBody = ErrorMailBody + " </tr> ";
                    ErrorMailBody = ErrorMailBody + " <tr valign='center'> ";

                    ErrorMailBody = ErrorMailBody + " <td bgcolor='#ffffff' height='25' style='font-size: 10pt; font-family: Verdana; color: #00008b; text-decoration: none;'><div align='right'> ";
                    ErrorMailBody = ErrorMailBody + " <strong>Error_Caused_By_Method</strong> : </div></td> ";
                    ErrorMailBody = ErrorMailBody + " <td bgcolor='#ffffff' height='25' style='font-size: 10pt; font-family: Verdana; color: #ff0033; text-decoration: none;'><div align='left' name='select'> ";
                    ErrorMailBody = ErrorMailBody + " " + Dt.Rows[index][6].ToString() + "</div></td> ";
                    ErrorMailBody = ErrorMailBody + " <td bgcolor='#ffffff' height='25' style='font-size: 10pt; font-family: Verdana; color: #00008b; text-decoration: none;'><div align='right'> ";
                    ErrorMailBody = ErrorMailBody + " <strong>User Ecode </strong>: </div></td> ";
                    ErrorMailBody = ErrorMailBody + " <td bgcolor='#ffffff' height='25' style='font-size: 10pt; font-family: Verdana; color: #00008b; text-decoration: none;'> ";
                    ErrorMailBody = ErrorMailBody + " " + Dt.Rows[index][8].ToString() + "</td> ";
                    //ErrorMailBody = ErrorMailBody + " " + Logon_User + "</div></td> "; userdet
                    
                    ErrorMailBody = ErrorMailBody + " </tr> ";
                    //ErrorMailBody = ErrorMailBody + " <tr valign='center'> ";
                    //ErrorMailBody = ErrorMailBody + " <td bgcolor='#ffffff' height='25' style='font-size: 10pt; font-family: Verdana; color: #00008b; text-decoration: none;'><div align='right'> ";
                    //ErrorMailBody = ErrorMailBody + " <strong>Error Details </strong>: </div></td> ";
                    //ErrorMailBody = ErrorMailBody + " <td bgcolor='#ffffff' colspan='3' height='25' style='font-size: 10pt; font-family: Verdana; color: #00008b; text-decoration: none;'><div align='left' name='select'> ";
                    //ErrorMailBody = ErrorMailBody + " " /*+ objErr */+ "</div></td> ";
                    //ErrorMailBody = ErrorMailBody + " </tr> ";
                    //ErrorMailBody = ErrorMailBody + " <tr valign='center' bgcolor='darkblue'> ";
                    //ErrorMailBody = ErrorMailBody + " <td colspan='4'>&nbsp;</td> ";
                    //ErrorMailBody = ErrorMailBody + " </tr> ";

                    ErrorMailBody = ErrorMailBody + " <tr valign='center'></tr> <tr valign='center'></tr> ";
                    ErrorMailBody = ErrorMailBody + " <tr valign='center'> ";
                    ErrorMailBody = ErrorMailBody + " <td bgcolor='#ffffff' height='25' style='font-size: 10pt; font-family: Verdana; color: #00008b; text-decoration: none;'><div align='right'> ";
                    ErrorMailBody = ErrorMailBody + " <strong>Error_Stack_Trace</strong> : </div></td> ";
                    ErrorMailBody = ErrorMailBody + " <td colspan='3' bgcolor='#ffffff' height='25' style='font-size: 10pt; font-family: Verdana; color: #ff0033; text-decoration: none;'><div align='left' name='select'> ";
                    ErrorMailBody = ErrorMailBody + " " + Dt.Rows[index][5].ToString() + "</div></td> ";
                    ErrorMailBody = ErrorMailBody + " </tr> ";

                    ErrorMailBody = ErrorMailBody + " </tbody> ";
                    ErrorMailBody = ErrorMailBody + " </table></td> ";
                    ErrorMailBody = ErrorMailBody + " </tr> ";
                    ErrorMailBody = ErrorMailBody + " </tbody> ";
                    ErrorMailBody = ErrorMailBody + " </table>";
                    ErrorMailBody = ErrorMailBody + " <p class=MsoNormal align=center style='mso-margin-top-alt:auto;mso-margin-bottom-alt: ";
                    ErrorMailBody = ErrorMailBody + " auto;text-align:center'><span style='font-size:10.0pt;font-family:'Verdana','sans-serif';color:red'>*** This is system generated message please do not reply to this ";
                    ErrorMailBody = ErrorMailBody + " message ***</span><span style='font-size:12.0pt;font-family:'Times New Roman','serif''><o:p></o:p></span></p> ";
                    ErrorMailBody = ErrorMailBody + "</body> ";
                    ErrorMailBody = ErrorMailBody + "</html> ";
                                              




                }
            }
            Ds = null;
            Dv = null;
            return ErrorMailBody;

        }

        public void SaveExceptionToLog(Exception ex)
        {
            string strdt;
            if (ex.InnerException == null)
            {
                ex = ex;
            }
            else
            {
                ex = ex.InnerException;
            }

            string ErrorType = ex.GetType().FullName.ToString().Trim();

            if (IsDeploymentMode == true)

                switch (ErrorType)
                {
                    case "System.Data.SqlClient.SqlException":
                        //CurrencyManager cm = (CurrencyManager)this.BindingContext[dsCust, "Customers"];

                        SqlException sqlex = (SqlException)ex;
                        string strMessage = "";
                        foreach (SqlError sqle in sqlex.Errors)
                        {
                            strMessage = " Message: " + sqle.Message +
                                           " Number: " + sqle.Number +
                                           " Procedure: " + sqle.Procedure +
                                           " Server: " + sqle.Server +
                                           " Source: " + sqle.Source +
                                           " State: " + sqle.State +
                                           " Severity: " + sqle.Class +
                                           " LineNumber: " + sqle.LineNumber;
                        }
                        Serial_No = MaxValue().ToString();
                        Error_Type = ex.GetType().ToString();
                        Error_DateTime = DateTime.Now.ToString();
                        Error_Description = strMessage; ;
                        Error_Source = ex.Source;
                        Error_Stack_Trace = ex.StackTrace;
                        Error_Caused_By_Method = ex.TargetSite.ToString();
                        Help_Link = ex.HelpLink;
                        Logon_User = "(SAPCODE- ";
                        Logon_User += HttpContext.Current.Session == null ? "000000" : HttpContext.Current.Session["SAPCODE"] == null ? "" : HttpContext.Current.Session["SAPCODE"].ToString();
                        Logon_User += ")";
                        Status = "OPEN";
                        HandledBy = "";
                        HandledOn = "";
                        Solu_Desc = "No Action till Yet";
                        BrowserInfo = GetUserData();
                        App_Phy_Path = HttpContext.Current.Request.ServerVariables["APPL_PHYSICAL_PATH"];
                        File_Path = HttpContext.Current.Request.FilePath.ToString();
                        File_Path = File_Path.Remove(0, 1);
                        File_Path = File_Path.Substring(File_Path.IndexOf("/"));
                        Assign_To = "Yet to Assign";
                        Assignee_Name = "";
                        Logon_User_Display = "";
                         strdt = Convert.ToDateTime(Error_DateTime).ToString();
                         //if (chkErrorExist(Error_Type, Logon_User, strdt))
                         //{
                             IsLogSaved = true;
                             saveData(Error_Type);
                         //}
                         //else
                         //    IsLogSaved = false;
                        break;
                    case "System.IndexOutOfRangeException":

                        Serial_No = MaxValue().ToString();
                        Error_Type = ex.GetType().ToString();
                        Error_DateTime = DateTime.Now.ToString();
                        Error_Description = ex.Message;
                        Error_Source = ex.Source;
                        Error_Stack_Trace = ex.StackTrace;
                        Error_Caused_By_Method = ex.TargetSite.ToString();
                        Help_Link = ex.HelpLink;
                        Logon_User = "(SAPCODE- ";
                        Logon_User += HttpContext.Current.Session == null ? "000000" : HttpContext.Current.Session["SAPCODE"] == null ? "" : HttpContext.Current.Session["SAPCODE"].ToString();
                        Logon_User += ")";
                        Status = "OPEN";
                        HandledBy = "";
                        HandledOn = "";
                        Solu_Desc = "No Action till Yet";
                        BrowserInfo = GetUserData();
                        App_Phy_Path = HttpContext.Current.Request.ServerVariables["APPL_PHYSICAL_PATH"];
                        File_Path = HttpContext.Current.Request.FilePath.ToString();
                        File_Path = File_Path.Remove(0, 1);
                        File_Path = File_Path.Substring(File_Path.IndexOf("/"));
                        Assign_To = "Yet to Assign";
                        Assignee_Name = "";
                        Logon_User_Display = "";
                        strdt = Convert.ToDateTime(Error_DateTime).ToString();
                        //if (chkErrorExist(Error_Type, Logon_User, strdt))
                        //{
                            IsLogSaved = true;
                            saveData(Error_Type);
                        //}
                        //else
                        //    IsLogSaved = false;
                        break;
                    default:
                        Serial_No = MaxValue().ToString();
                        Error_Type = ex.GetType().ToString();
                        Error_DateTime = DateTime.Now.ToString();
                        Error_Description = ex.Message;
                        Error_Source = ex.Source;
                        Error_Stack_Trace = ex.StackTrace;
                        Error_Caused_By_Method = ex.TargetSite.ToString();
                        Help_Link = ex.HelpLink;
                        //Logon_User = HttpContext.Current.Session == null ? "" : HttpContext.Current.Session["UserName"] == null ? "" : HttpContext.Current.Session["SAPCODE"].ToString();
                        Logon_User = "(SAPCODE- ";
                        Logon_User += HttpContext.Current.Session == null ? "000000" : HttpContext.Current.Session["SAPCODE"] == null ? "" : HttpContext.Current.Session["SAPCODE"].ToString();
                        Logon_User += ")";
                        Status = "OPEN";
                        HandledBy = "";
                        HandledOn = "";
                        Solu_Desc = "No Action till Yet";
                        BrowserInfo = GetUserData();
                        App_Phy_Path = HttpContext.Current.Request.ServerVariables["APPL_PHYSICAL_PATH"];
                        File_Path = HttpContext.Current.Request.FilePath.ToString();
                        //File_Path = File_Path.Remove(0, 1);
                        //File_Path = File_Path.Substring(File_Path.IndexOf("/"));
                        Assign_To = "Yet to Assign";
                        Assignee_Name = "";
                        Logon_User_Display = "";
                        strdt = Convert.ToDateTime(Error_DateTime).ToString();
                        //if (chkErrorExist(Error_Type, Logon_User, strdt))
                        //{
                        IsLogSaved = true;
                        saveData(Error_Type);
                        //}
                        //else
                        //    IsLogSaved = false;
                        break;

                }

        }

        //private Boolean chkErrorExist(string errorType, string Logon_User,string errorDate)
        //{
        //    Ds = new DataSet();
        //    Ds.ReadXml(filePath, XmlReadMode.ReadSchema);
        //   DataView dv = Ds.Tables[0].DefaultView;
        //    dv.RowFilter = "Error_Type='" + errorType + "' AND Logon_User='" + Logon_User + "' AND substring(Error_DateTime,1,10)=#" + errorDate + "#";
        //    if (dv.Count >= 3)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        return true;
        //    }
        //    Ds = null;
        //    dv = null;
      


        //}

        private void saveData(string errorType)
        {

            Ds = null;
            Dr = null;

            //*****************
            string rowFilter = "";
            string XmlError_date = Error_DateTime.Substring(0, 10);
            string XmlBrowserInfo = BrowserInfo.Substring(0, 28);

            if (File.Exists(filePath))
            {
                DataSet DsXML = new DataSet();
                DsXML.ReadXml(filePath, XmlReadMode.ReadSchema);

                DataTable dtTable = new DataTable();

                //rowFilter = "Error_DateTime LIKE '" + XmlError_date + "*'";
                //Check the error log twice to be written  for a single user with the conditions 1.same date 2.same error Type 3.same BrowserInfo.

                //rowFilter = "Error_DateTime LIKE '" + XmlError_date + "*' and Error_Type='" + Error_Type + "' and BrowserInfo LIKE '" + XmlBrowserInfo + "*'";
                //DsXML.Tables[0].DefaultView.RowFilter = rowFilter;

                //if (DsXML.Tables[0].DefaultView.Count <= 1)
                //{
                string[] ArrXmlNodeValues = {Serial_No,Error_Type,Error_DateTime,
                                Error_Description,Error_Source,Error_Stack_Trace,
                                Error_Caused_By_Method,Help_Link,
                                Logon_User,Status,HandledBy,HandledOn,Solu_Desc,BrowserInfo,App_Phy_Path,File_Path,Assign_To, Assignee_Name, Logon_User_Display};

                try
                {
                    dtTable = DsXML.Tables[0].Copy();

                    Dr = dtTable.NewRow();

                    for (int i = 0; i < ArrXmlNodeValues.Length; i++)
                    {
                        Dr[i] = ArrXmlNodeValues[i];
                    }

                    dtTable.Rows.Add(Dr);
                    dtTable.AcceptChanges();
                    dtTable.WriteXml(filePath, System.Data.XmlWriteMode.WriteSchema, false);

                }
                catch (Exception innerex)
                {
                    throw innerex;
                    //Response.Write(innerex.Message);
                }
                finally
                {

                    Ds = null;
                    Dr = null;

                    //this is the common User Friendly error page
                    //System.Web.HttpContext.Current.Response.Redirect(System.Configuration.ConfigurationManager.AppSettings["ErrorPage"].ToString() + "?ErrorType=" + errorType);
                }
                //}
                //else
                //{
                //    Ds = null;
                //    Dr = null;
                //    System.Web.HttpContext.Current.Response.Redirect(System.Configuration.ConfigurationManager.AppSettings["ErrorPage"].ToString() + "?ErrorType=" + errorType);
                //}

            }
        }

        //Getting The User information to store
        private string GetUserData()
        {
            string browserInfo = null;
            HttpBrowserCapabilities browser = HttpContext.Current.Request.Browser;
            browserInfo = "IP Address = " + HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString() + "#"
            + "Type = " + browser.Type + "#"
            + "Name = " + browser.Browser + "#"
            + "Version = " + browser.Version + "#"
            + "Major Version = " + browser.MajorVersion + "#"
            + "Minor Version = " + browser.MinorVersion + "#"
            + "Platform = " + browser.Platform + "#"
            + "Is Beta = " + browser.Beta + "#"
            + "Is Crawler = " + browser.Crawler + "#"
            + "Is AOL = " + browser.AOL + "#"
            + "Is Win16 = " + browser.Win16 + "#"
            + "Is Win32 = " + browser.Win32 + "#"
            + "Supports Frames = " + browser.Frames + "#"
            + "Supports Tables = " + browser.Tables + "#"
            + "Supports Cookies = " + browser.Cookies + "#"
            + "Supports VBScript = " + browser.VBScript + "#"
            + "Supports JavaScript = " + browser.JavaScript + "#"
            + "Supports Java Applets = " + browser.JavaApplets + "#"
            + "Supports BackgroundSounds = " + browser.BackgroundSounds + "#"
            + "Supports ActiveX Controls = " + browser.ActiveXControls + "#"
            + "Browser = " + browser.Browser + "#"
            + "CDF = " + browser.CDF + "#"
            + "CLR Version = " + browser.ClrVersion + "#"
            + "ECMA Script version = " + browser.EcmaScriptVersion + "#"
            + "MSDOM version = " + browser.MSDomVersion + "#"
            + "Supports tables = " + browser.Tables + "#"
            + "W3C DOM version = " + browser.W3CDomVersion + "#";
            return browserInfo;
        }

        public void Dispose()
        {
            this.Dc = null;
            this.Dr = null;
            this.Dt = null;
            this.Dv = null;
            this.filePath = null;

            //ErrorHandler = null;
        }

        #endregion

    }
  
