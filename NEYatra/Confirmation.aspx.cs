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
using System.Web.Services;
using System.Data.SqlClient;
using System.Collections.Generic;
using BusinessEntity;
using BusinessLogicLib;
using COM;
using System.Text;
using System.Net;
using System.IO;
using AjaxControlToolkit;



public partial class Confirmation : System.Web.UI.Page
{

    String seats = null;
    string tranid = "";
    ArrayList totalseat = null;
     
    
    protected void Page_Init(object sender, EventArgs e)
    {
        if (Session["SeatNos"] == null)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Message", "alert('Session is expired, please try again.');window.location='Default.aspx'; ", true);
        }
        else
        {
            totalseat = (ArrayList)Session["SeatNos"];
            GenerateControls(totalseat.Count);
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //  btnpay.Enabled = true;
            totalseat = (ArrayList)Session["SeatNos"];
            ViewState["seatcount"] = totalseat.Count;
            //Event Section
            if (Request.QueryString["mode"] != null && Request.QueryString["mode"].ToString() == "Event")
            {
                if (Session["TotalTicketValue"] == null)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Message", "alert('Session is expired, please try again.');window.location='Default.aspx'; ", true);
                }
                else
                {
                    ddlBoardingPoints.Visible = false;
                    lblBoardingPoint.Visible = false;
                    Bookingsummary.Visible = false;
                    lblAmtPayable.Text = "Rs. " + Session["TotalTicketValue"].ToString();
                }
            }
            //Car Rental Section
           else if (Request.QueryString["mode"] != null && Request.QueryString["mode"].ToString() == "Rental")
            {
                if (Session["CR_SourceCity"] == null || Session["PickupDate"] == null || Session["PickupTime"] == null || Session["CR_TravelType"] == null || Session["CR_TravelMode"] == null || Session["CR_DesCity"] == null || Session["ScheduleID"] == null)
                { 
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Message", "alert('Session is expired, please try again.');window.location='Default.aspx'; ", true);
                }
                else
                {
                //ScriptManager.RegisterStartupScript(this, GetType(), "Javascript", "javascript:chkEnabled('Y'); ", true);
                                
                    
                    lblSourceText.Text = "Pickup City";
                    lblSource.Text = Session["CR_SourceCity"].ToString();

                    lblDesText.Text = "Pickup Date";
                    lblDes.Text = Session["PickupDate"].ToString();

                    lblModeText.Text = "Pickup Time";
                    lblMode.Text = Session["PickupTime"].ToString();

                    lblDateText.Text = "Trip";
                    if (Session["CR_TravelType"].ToString() == "Outstation")
                        if (Session["CR_TravelMode"].ToString() == "OneWay")
                            lblDate.Text = Session["CR_TravelType"].ToString() + " (" + Session["CR_DesCity"].ToString() + " -> One Way Trip )";
                        else
                            lblDate.Text = Session["CR_TravelType"].ToString() + " (" + Session["CR_DesCity"].ToString() + " -> Round Trip )";
                    else
                        lblDate.Text = Session["CR_TravelType"].ToString() + " (" + Session["CR_TravelMode"].ToString() + ")";

                    DataTable dt = GetCarRentalScheduleDetails(Convert.ToInt32(Session["ScheduleID"].ToString()));
                    if (dt != null && dt.Rows.Count > 0)
                    {

                        lblSeatnoText.Text = "Vendor";
                        lblSeatno.Text = dt.Rows[0]["VendorName"].ToString();

                        lblFareText.Text = "Selected Car";
                        lblFare.Text = dt.Rows[0]["Vehicle"].ToString();

                        lblCounterText.Text = "Fare Details";
                        lblCounter.Text = "Rs. " + dt.Rows[0]["Fare"].ToString();

                        int CarRentalBookingAmt = (Convert.ToInt32(dt.Rows[0]["Fare"].ToString()) * Convert.ToInt32(dt.Rows[0]["BmetDiscount"].ToString())) / 100;
                        ViewState["CustomerAmt"] = CarRentalBookingAmt;
                        ViewState["FranDiscount"] = dt.Rows[0]["Fran_Discount"].ToString();
                        ViewState["BmetDiscount"] = dt.Rows[0]["BmetDiscount"].ToString();
                        ViewState["CarRentalfare"] = dt.Rows[0]["Fare"].ToString();
                        lblAmtPayabletext.Text = "Booking Amount";
                        if (ViewState["payableAmount"] != null)
                            lblAmtPayable.Text = "Rs. " + ViewState["payableAmount"].ToString();
                        else
                            lblAmtPayable.Text = "Rs. " + ViewState["CustomerAmt"].ToString();
                        lttPolicy.Text= dt.Rows[0]["Policydescription"].ToString();
                    }
                    ddlBoardingPoints.Visible = false;
                    lblBoardingPoint.Visible=false;
                    Contactdetails.Text = "Pickup Details";
                    lblAddress.Text = "Pickup Address";

                    lblFranMarkup.Visible = true;
                    txtFranMarkup.Visible = true;
                    ValMarkup.Type = ValidationDataType.Integer;
                    ValMarkup.MinimumValue = "0";
                    if (Convert.ToInt32(dt.Rows[0]["Fare"].ToString()) > 10000)
                    {
                       
                        ValMarkup.MaximumValue = "1000";
                        ValMarkup.ErrorMessage = "Mark-up cannot be more than Rs.1000";
                        txtFranMarkup.Text = "";
                    }
                    else
                    {
                        ValMarkup.MaximumValue = (Convert.ToInt32(dt.Rows[0]["Fare"].ToString()) * 10 / 100).ToString();
                        ValMarkup.ErrorMessage = "Mark-up cannot be more than 10% of total fare.";
                        txtFranMarkup.Text = "";
                    }
                }
            }
            else 
            {
               if (Session["totalAmount"] == null || Session["CounterAddress"] == null || Session["Source"] == null || Session["Destination"] == null || Session["Mode"] == null || Session["JdateTime"] == null)
               {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Message", "alert('Session is expired, please try again.');window.location='Default.aspx'; ", true);
                }
              else
              {
                    if (Request.QueryString["sid"].ToString() != null || Request.QueryString["sid"].ToString() != "")
                    ViewState["session_id"] = Request.QueryString["sid"].ToString();
                    ViewState["CustomerAmt"] = Session["totalAmount"].ToString();
                    lblSource.Text = Session["Source"].ToString();
                    lblDes.Text = Session["Destination"].ToString();
                    lblMode.Text = Session["Mode"].ToString();
                    lblDate.Text = Session["JdateTime"].ToString();
                    lblSeatno.Text =  GetSeats();
                    lblCounter.Text = Session["CounterAddress"] == null ? "" : Session["CounterAddress"].ToString().Trim();
                    lblFare.Text = "Rs." + ViewState["CustomerAmt"].ToString();
                    if (ViewState["payableAmount"] != null)
                        lblAmtPayable.Text = "Rs. " + ViewState["payableAmount"].ToString();
                    else
                        lblAmtPayable.Text = "Rs. " + ViewState["CustomerAmt"].ToString();
                    ddlBoardingPoints.Visible = true;
                    lttPolicy.Visible = false;
                    fillboardingdropdown();
                }
            }
        }


    }



    protected void btnpay_Click(object sender, EventArgs e)
    {
        // btnpay.Enabled = false;
        if (Page.IsValid)
        {
            try
            {
                if (Request.QueryString["mode"] != null && Request.QueryString["mode"].ToString() == "Event")
                {
                    tranid = BookEvent();
                }

                else
                {
                    if (Request.QueryString["mode"] != null && Request.QueryString["mode"].ToString() == "Rental")
                    {
                        tranid = BookCarRental();

                    }
                    else
                    {
                        tranid = BookSumoBusService();
                        if (tranid == "Booked")
                        {
                            errMsg.Visible = true;
                            lblErrorMsg.ForeColor = System.Drawing.Color.Red;
                            lblErrorMsg.Text = "Selected seats already booked by another user,please choose your seats again.";
                            return;
                        }
                    }
                }


                if (tranid != "" && tranid != "Booked" && tranid != null)
                {
                    //Commented for checking ticket template
                    COM.TPSLUtil1 objTPSLUtil1 = new COM.TPSLUtil1();
                    COM.CheckSumRequestBean objCheckSumRequestBean = new COM.CheckSumRequestBean();
                    objCheckSumRequestBean.MerchantTranId = tranid.ToString();
                    //objCheckSumRequestBean.MarketCode = "T2983";
                    objCheckSumRequestBean.MarketCode = "L2983";
                    objCheckSumRequestBean.AccountNo = "1";
                    //Event Section
                    if (Request.QueryString["mode"] != null && Request.QueryString["mode"].ToString() == "Event")
                    {
                        objCheckSumRequestBean.Amt = Session["TotalTicketValue"].ToString();
                    }
                    //End Event Section
                    else
                    {
                        if (ViewState["payableAmount"] != null)
                            objCheckSumRequestBean.Amt = ViewState["payableAmount"].ToString();
                        else
                            objCheckSumRequestBean.Amt = ViewState["CustomerAmt"].ToString();
                    }
                    //comment  below line on live
                  //  objCheckSumRequestBean.Amt = "1";
                    objCheckSumRequestBean.BankCode = "NA";
                    objCheckSumRequestBean.PropertyPath = HttpContext.Current.Server.MapPath("~/Property/MerchantDetails_sharedhosting.property");



                    //objCheckSumRequestBean.CustomerId = txtcustomerid.Text;


                    string strMsg = objTPSLUtil1.transactionRequestMessage(objCheckSumRequestBean);
                    Session["myString"] = strMsg;

                    if (System.Configuration.ConfigurationManager.AppSettings["TestMode"].ToString() == "1")
                        strMsg = tranid.ToString();

                    if (!strMsg.Equals("") && strMsg != null)
                    {

                        //Response.Redirect("https://www.tekprocess.co.in/PaymentGateway/TransactionRequest.jsp?msg=" + strMsg);

                        //Commented for testing --uncomment on live
                        if (System.Configuration.ConfigurationManager.AppSettings["TestMode"].ToString() == "1")
                            Response.Redirect("final.aspx?msg=" + strMsg);
                        else
                            Response.Redirect("https://www.tpsl-india.in/PaymentGateway/TransactionRequest.jsp?msg=" + strMsg);
              
                    }

                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Your ticket is not booked,please try again.')", true);

                    return;
                }




            }
            catch (Exception ex) { throw ex; }

        }
      
    }



    public string GetSeats()
    {
       
       
        for (int i = 0; i < totalseat.Count; i++)
        {

            // Setting seats information on travelling sections
            if ((totalseat.IndexOf(totalseat[i])) == (totalseat.Count - 1))
            {
                seats = seats + (totalseat[i].ToString() + "");

            }
            else
            {
                seats = seats + (totalseat[i].ToString() + ",");

            }
        } 
        return seats;
    }


    protected void btnVerify_Click(object sender, EventArgs e)
    {

        if (txtFranCode.Text == "")
        {
            lblFranName.Text = "Please Enter Franchisee Code.";
            lblFranName.ForeColor = System.Drawing.Color.Red;
        }
        else
        {
            lblFranName.ForeColor = System.Drawing.Color.Purple;
            BLSchedule objsch = new BLSchedule();
            DataTable dt=null;
            int  franticketvalue;
            double FranComm;
            if (Request.QueryString["mode"] != null && Request.QueryString["mode"].ToString() == "Rental")
             dt = objsch.GetFranchiseeDetails(txtFranCode.Text.ToString().Trim(), 0,"Rental");
            else
             dt = objsch.GetFranchiseeDetails(txtFranCode.Text.ToString().Trim(), Convert.ToInt32(ViewState["session_id"].ToString()),"");
            if (dt != null && dt.Rows.Count > 0)
            {
                tbl_BmetWallet.Visible = false;
                tbl_BmetWalletinfo.Visible = true;                
                ViewState["BMETWalletpwd"] = dt.Rows[0]["BMETWalletPwd"].ToString();
                if (Request.QueryString["mode"] != null && Request.QueryString["mode"].ToString() == "Rental")
                {
                                
                FranComm=Convert.ToDouble(ViewState["FranDiscount"].ToString());
                franticketvalue = Convert.ToInt32((Convert.ToInt32(ViewState["CarRentalfare"].ToString()) * (Convert.ToDouble(ViewState["BmetDiscount"].ToString()) - FranComm)) / 100);
                }
                else
                {
                    string[] seatno = GetSeats().Split(',');
                    FranComm = Convert.ToDouble(dt.Rows[0]["FranDis"].ToString());
                    int franprice = Convert.ToInt32(dt.Rows[0]["FranTicketPrice"].ToString());
                    franticketvalue = seatno.Length * franprice;
                }

                if (FranComm > 0)
                {
                    lblFranName.Text = "<b> Welcome " + dt.Rows[0]["FranName"].ToString() + ", Your Commision is: " + FranComm + "%</b>";
                }
                else
                {
                    lblFranName.Text = "<b> Welcome " + dt.Rows[0]["FranName"].ToString()+"</b>";
                }
                
                lblAmtPayable.Text = "Rs. " + franticketvalue.ToString();
                ViewState["payableAmount"] = franticketvalue.ToString();
                ViewState["FranCode"] = txtFranCode.Text.ToString().Trim();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "key", "chkEnabled('Y');", true);
                txtFranCode.Enabled = false;
                btnVerify.Enabled = false;
                lblFranNameWallet.Text = dt.Rows[0]["FranName"].ToString();
                lblBmetWallet.Text ="Rs. " + dt.Rows[0]["BMETWallet"].ToString();
                if (Convert.ToInt64(dt.Rows[0]["BMETWallet"].ToString()) >= franticketvalue)
                {                    
                    lblBMETWalletmsg.Visible = true;
                    txtBMETWalletCode.Visible = true;
                    btnBMETWallet.Visible = true;

                }
                else
                {
                    lblBmetWallet.Text = lblBmetWallet.Text+" <br><font color='purple'> Please recharge your BMETWallet for availing benefits.</font>";
                    lblBmetWallet.ForeColor = System.Drawing.Color.Red;
                }

            }
            else
            {
                txtFranCode.Text = "";
                lblFranName.Text = "Invalid Franchisee Code";
                lblFranName.ForeColor = System.Drawing.Color.Red;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "key", "chkEnabled('N');", true);
            }


        }


    }
    private void fillboardingdropdown()
    {
        ddlBoardingPoints.Items.Clear();
        BLSchedule obj = new BLSchedule();
        DataSet ds = obj.GetBoardingPoints(Convert.ToInt32(ViewState["session_id"].ToString()));
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            ddlBoardingPoints.Items.Insert(0, new ListItem("----Boarding points----", "-1"));
            for (int i = 0; i < ds.Tables[0].Columns.Count; i++)
            {

                ddlBoardingPoints.Items.Add(ds.Tables[0].Rows[0][i].ToString());

            }
        }
        ds = null;
        obj = null;
    }

    protected void btnBMETWallet_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            if (txtBMETWalletCode.Text != ViewState["BMETWalletpwd"].ToString())
            {
               ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Invalid BMETWallet Password.please enter your 10 characters BMETWallet password.')", true);
               return;
            }
            else
            {

                if (Request.QueryString["mode"] != null && Request.QueryString["mode"].ToString() == "Rental")
                {
                    tranid = BookCarRental();

                }
                else
                {
                   tranid = BookSumoBusService();
                    if (tranid == "Booked")
                    {
                        errMsg.Visible = true;
                        lblErrorMsg.ForeColor = System.Drawing.Color.Red;
                        lblErrorMsg.Text = "Selected seats already booked by another user,please choose your seats again.";
                        return;
                    }
                }
                if (tranid != "" && tranid != "Booked" && tranid != null)
                {
                    Response.Redirect("final.aspx?msg=" + tranid);
                }               
                 

            }
        }
       



    }
    private string BookCarRental()
    {
        BLSchedule obj = new BLSchedule();
        CarRentalEntity objCar = new CarRentalEntity();
        ArrayList psgDetails=GetPassengerDeatils();
        try
        {
            objCar.BookingID = "";
            objCar.ScheduleID = Convert.ToInt32(Session["ScheduleID"].ToString());
            objCar.CustName = psgDetails[0].ToString();
            objCar.Gender = psgDetails[1].ToString();
            objCar.Age = Convert.ToInt32(psgDetails[2].ToString());
            objCar.EmailID = txtEmail.Text.ToString();
            objCar.Mobile_no = txtMobile.Text.ToString();
            objCar.Pickup_Address = txtAddress.Text.ToString();
            objCar.Pickup_Date = Convert.ToDateTime (Session["PickupDate"].ToString());
            objCar.Pickup_Time = Session["PickupTime"].ToString();
            objCar.bookingBMET_amt = ViewState["payableAmount"] == null ? Convert.ToInt32(ViewState["CustomerAmt"].ToString()) : Convert.ToInt32(ViewState["payableAmount"].ToString());
            objCar.bookingFRAN_amt = Convert.ToInt32(ViewState["CustomerAmt"].ToString());
            objCar.Fran_code = ViewState["FranCode"] == null ? "" : ViewState["FranCode"].ToString().Trim();
            objCar.Fran_Markup = txtFranMarkup.Text=="" ? 0 : Convert.ToInt32(txtFranMarkup.Text);
            return obj.AddCarRentalDetails(objCar).ToString();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objCar = null;
            obj = null;
        }
    }
    private string BookSumoBusService()
    {
        BLSchedule obj = new BLSchedule();
        CashDetails objCash = new CashDetails();
        ArrayList psgDetails=GetPassengerDeatils();
        try
        {
            objCash.CustName = psgDetails[0].ToString();
            objCash.EmailID = txtEmail.Text.ToString();
            objCash.Mobile_no = txtMobile.Text.ToString();
            objCash.Address = txtAddress.Text.ToString();
            objCash.Gender = psgDetails[1].ToString();
            objCash.Age = psgDetails[2].ToString();
            objCash.session_id = Convert.ToInt32(ViewState["session_id"].ToString());
            objCash.total_seats = GetSeats();
            objCash.total_amount = ViewState["payableAmount"] == null ? Convert.ToInt32(ViewState["CustomerAmt"].ToString()) : Convert.ToInt32(ViewState["payableAmount"].ToString());
            objCash.ActiveID = 0;
            if (Session["Mode"] != null)
                objCash.Mode = Session["Mode"].ToString();
            objCash.FranCode = ViewState["FranCode"] == null ? "" : ViewState["FranCode"].ToString().Trim();
            objCash.cust_amount = Convert.ToInt32(ViewState["CustomerAmt"].ToString());
            objCash.BoardingPoint = ddlBoardingPoints.SelectedItem.Text.ToString();
            objCash.tranid = "";
            return obj.AddCashDetails(objCash).ToString();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objCash = null;
            obj = null;
        }

    }

    //Event Section
    private string BookEvent()
    {
        BLSchedule obj = new BLSchedule();
        ArrayList psgDetails = GetPassengerDeatils();
        try
        {
            string CustName = psgDetails[0].ToString();
            string Gender = psgDetails[1].ToString();
            int  Age = Convert.ToInt32(psgDetails[2].ToString());
            string EmailID = txtEmail.Text.ToString();
            string Mobile_no = txtMobile.Text.ToString();
            string Address = txtAddress.Text.ToString();
            int stagboy = Session["SingleBoyTicketCount"] == null ? 0 : Convert.ToInt32(Session["SingleBoyTicketCount"].ToString());
            int staggirl = Session["SingleGirlTicketCount"] == null ? 0 : Convert.ToInt32(Session["SingleGirlTicketCount"].ToString());
            int couple = Session["CoupleTicketCount"] == null ? 0 : Convert.ToInt32(Session["CoupleTicketCount"].ToString());
            int child = Session["ChildTicketCount"] == null ? 0 : Convert.ToInt32(Session["ChildTicketCount"].ToString());
            decimal bookingAmt = Convert.ToDecimal(Session["TotalTicketValue"].ToString());
            return obj.AddEventBookingDetails(CustName,Gender, Age, EmailID, Mobile_no, Address, stagboy, staggirl, couple, child, bookingAmt).ToString();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            obj = null;
        }
    }
    private void GenerateControls(int seatcount)
    {
        System.Web.UI.WebControls.TextBox tbname = null;
        System.Web.UI.WebControls.TextBox tbage = null;
        System.Web.UI.WebControls.RadioButtonList rbGenderM = null;        
        AjaxControlToolkit.TextBoxWatermarkExtender txtWatermark = null;
        AjaxControlToolkit.TextBoxWatermarkExtender txtWatermarkAge = null;
        RequiredFieldValidator rfd = null;
        RequiredFieldValidator rfdAge = null;
        RequiredFieldValidator rfdGender = null;
        RangeValidator rvdAge = null;
        RegularExpressionValidator revName = null;

       
        Table tblUserDetails = new Table();
        tblUserDetails.ID = "UserDetails";
        TableRow tr = new TableRow();
        TableCell tc1 = new TableCell();
        TableCell tc2 = new TableCell();
        TableCell tc3 = new TableCell();
        tc1.Text = "<span class='text'>Name</span>&nbsp;<span style='color: Red'>*</span>";
        tc2.Text = "<span class='text'>Gender</span>&nbsp;<span style='color: Red'>*</span>";
        tc2.Width = 180;
        tc2.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left;
        tc3.Text = "<span class='text'>Age</span>&nbsp;<span style='color: Red'>*</span>";
       
        tr.Controls.Add(tc1);
        tr.Controls.Add(tc2);
        tr.Controls.Add(tc3);
        tblUserDetails.Controls.Add(tr);
        for (int i = 0; i < seatcount; i++)
        {

            TableRow row = new TableRow();          

                //dynamically adding controls
                 tc1 = new TableCell();
                 tc2 = new TableCell();
                 tc3 = new TableCell();

                tbname = new System.Web.UI.WebControls.TextBox();
                tbname.ID = "txtuser" + i.ToString();
                tbname.Width = 200;

                txtWatermark = new AjaxControlToolkit.TextBoxWatermarkExtender();
                txtWatermark.ID = "txtWaterMark" + i.ToString();
                txtWatermark.WatermarkText = "Enter Name";
                txtWatermark.WatermarkCssClass = "watermark";
                txtWatermark.TargetControlID = "txtuser" + i.ToString();

                rfd = new RequiredFieldValidator();
                rfd.ID = "rfd" + i.ToString();
                rfd.ControlToValidate = "txtuser" + i.ToString();
                rfd.ForeColor = System.Drawing.Color.Red;
                rfd.ErrorMessage  = "Please enter name";

                revName = new RegularExpressionValidator();
                revName.ID = "revName" + i.ToString();
                revName.ControlToValidate = "txtuser" + i.ToString();
                revName.ForeColor = System.Drawing.Color.Red;
                revName.ValidationExpression = "^[-0-9a-zA-Z ,:.]+$";
                revName.ErrorMessage = "Alphabets Only";
                              



                rbGenderM = new System.Web.UI.WebControls.RadioButtonList();                               
                rbGenderM.ID = "rbGender" + i.ToString();
                rbGenderM.Items.Add("M");
                rbGenderM.Items.Add("F");
                rbGenderM.RepeatDirection = System.Web.UI.WebControls.RepeatDirection.Horizontal;

                rfdGender = new RequiredFieldValidator();
                rfdGender.ID = "rfdGender" + i.ToString();
                rfdGender.ControlToValidate = "rbGender" + i.ToString();
                rfdGender.ForeColor = System.Drawing.Color.Red;
                rfdGender.ErrorMessage = "Choose gender";
                             

                tbage = new System.Web.UI.WebControls.TextBox();
                tbage.ID = "txtage" + i.ToString();
                tbage.Width =50;
                tbage.MaxLength = 2;

                txtWatermarkAge = new AjaxControlToolkit.TextBoxWatermarkExtender();
                txtWatermarkAge.ID = "txtWaterMarkAge" + i.ToString();
                txtWatermarkAge.WatermarkText = "Age";
                txtWatermarkAge.WatermarkCssClass = "watermark";         
                txtWatermarkAge.TargetControlID = "txtage" + i.ToString();

                rfdAge = new RequiredFieldValidator();
                rfdAge.ID = "rfdAge" + i.ToString();
                rfdAge.ControlToValidate = "txtage" + i.ToString();
                rfdAge.ForeColor = System.Drawing.Color.Red;
                rfdAge.ErrorMessage = "Enter age";


               rvdAge = new RangeValidator();
               rvdAge.ID = "rvdAge" + i.ToString();
               rvdAge.ControlToValidate = "txtage" + i.ToString();
               rvdAge.ForeColor = System.Drawing.Color.Red;
               rvdAge.MinimumValue = "1";
               rvdAge.MaximumValue = "99";
               rvdAge.Type = ValidationDataType.Integer;
               rvdAge.ErrorMessage = "Age between 1-99";

                tc1.Controls.Add(tbname); 
                tc1.Controls.Add(txtWatermark);
                tc1.Controls.Add(revName);
                tc1.Controls.Add(new LiteralControl("<br />"));
                tc1.Controls.Add(rfd);

                tc2.Controls.Add(rbGenderM);
               // tc2.Controls.Add(new LiteralControl("<br />"));
                tc2.Width = 180;
                tc2.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left;
                tc2.Controls.Add(rfdGender);

                tc3.Controls.Add(tbage);
                tc3.Controls.Add(txtWatermarkAge);
                tc3.Controls.Add(rvdAge);
                tc3.Controls.Add(new LiteralControl("<br />"));
                tc3.Controls.Add(rfdAge);
                

                row.Controls.Add(tc1);
                row.Controls.Add(tc2);
                row.Controls.Add(tc3);
                

            tblUserDetails.Controls.Add(row);
            
        }
        txtPanel.Controls.Add(tblUserDetails);

    }
    private ArrayList GetPassengerDeatils()
    {
        String passengername = null;
        String passengergender = null; 
        String passengerage = null; 
        ArrayList passengerDetails=null;
      
        for(int i=0; i< Convert.ToInt16(ViewState["seatcount"]) ;i++)
        {
            if (i == Convert.ToInt16(ViewState["seatcount"]) - 1)
            {

                TextBox tb = (TextBox)txtPanel.FindControl("txtuser" + i.ToString());
                passengername = passengername + tb.Text;

                RadioButtonList rbM = (RadioButtonList)txtPanel.FindControl("rbGender" + i.ToString());
                if (rbM.SelectedIndex == 0)
                    passengergender = passengergender + "M";
                else
                    passengergender = passengergender + "F";

                TextBox tbAge = (TextBox)txtPanel.FindControl("txtage" + i.ToString());
                passengerage = passengerage + tbAge.Text;
            }
            else
            {

                TextBox tb = (TextBox)txtPanel.FindControl("txtuser" + i.ToString());
                passengername = passengername + tb.Text + "/";

                RadioButtonList rbM = (RadioButtonList)txtPanel.FindControl("rbGender" + i.ToString());
                if (rbM.SelectedIndex == 0)
                    passengergender = passengergender + "M/";
                else
                    passengergender = passengergender + "F/";
                TextBox tbAge = (TextBox)txtPanel.FindControl("txtage" + i.ToString());
                passengerage = passengerage + tbAge.Text + "/";
            }         
           
        }
        passengerDetails = new ArrayList();
        passengerDetails.Add(passengername);
        passengerDetails.Add(passengergender);
        passengerDetails.Add(passengerage);

        return passengerDetails;
    }

    private DataTable GetCarRentalScheduleDetails(int session_id)
    {
        BLSchedule objsch = new BLSchedule();
        DataTable dt = objsch.GetCarRentalScheduleDetails(session_id);
        return dt;
    }
}