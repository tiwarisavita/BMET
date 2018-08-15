using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessEntity;
using System.Data;

namespace DataAccessLib
{
    public class DALSchedule
    {
        public int CreateSchedule(Scheduling obj)
        {
            DBParams[] dbParams = new DBParams[10];
            dbParams[0] = new DBParams("@cunt_id", obj.cunt_id, ParamType.Int , ParamDirection.Input);
            dbParams[1] = new DBParams("@vehi_number", obj.vehi_number, ParamType.String, ParamDirection.Input);
            dbParams[2] = new DBParams("@frm_city", obj.frm_city , ParamType.String, ParamDirection.Input);
            dbParams[3] = new DBParams("@to_city", obj.to_city , ParamType.String, ParamDirection.Input);
            dbParams[4] = new DBParams("@mode", obj.mode , ParamType.String, ParamDirection.Input);
            dbParams[5] = new DBParams("@dtm_date", obj.dtm_date , ParamType.DateTime, ParamDirection.Input);
            dbParams[6] = new DBParams("@schd_time", obj.schd_time , ParamType.String, ParamDirection.Input);
            dbParams[7] = new DBParams("@tran_value", obj.tran_value , ParamType.Int, ParamDirection.Input);
            dbParams[8] = new DBParams("@custdis", obj.cust_dis, ParamType.Int, ParamDirection.Input);
            dbParams[9] = new DBParams("@frandis", obj.fran_dis , ParamType.Int, ParamDirection.Input);
            

            DALHandler.ExecuteStatement(Constants.CreateSchedule, dbParams);

            return 1;

        }
        public int AddVehicle(Vehicle obj)
        {
            DBParams[] dbParams = new DBParams[8];
            dbParams[0] = new DBParams("@cunt_id", obj.cunt_id, ParamType.Int, ParamDirection.Input);
            dbParams[1] = new DBParams("@vehi_state", obj.vehi_state , ParamType.String, ParamDirection.Input);
            dbParams[2] = new DBParams("@vehi_number", obj.vehi_number , ParamType.String, ParamDirection.Input);
            dbParams[3] = new DBParams("@own_name", obj.own_name , ParamType.String, ParamDirection.Input);
            dbParams[4] = new DBParams("@own_address", obj.own_address , ParamType.String, ParamDirection.Input);
            dbParams[5] = new DBParams("@own_phone", obj.own_phone , ParamType.String, ParamDirection.Input);
            dbParams[6] = new DBParams("@vehi_type", obj.vehi_type , ParamType.String, ParamDirection.Input);
            dbParams[7] = new DBParams("@vehi_layout", obj.vehi_layout , ParamType.String, ParamDirection.Input);

            DALHandler.ExecuteStatement(Constants.AddVehicle, dbParams);
            return 1;

        
        }
        public string AddCashDeatails(CashDetails  obj)
        {
            DBParams[] dbParams = new DBParams[15];

            dbParams[0] = new DBParams("@CustName", obj.CustName, ParamType.String, ParamDirection.Input);
            dbParams[1] = new DBParams("@EmailID", obj.EmailID, ParamType.String, ParamDirection.Input);
            dbParams[2] = new DBParams("@Mobile_no", obj.Mobile_no, ParamType.String, ParamDirection.Input);
            dbParams[3] = new DBParams("@Address", obj.Address, ParamType.String, ParamDirection.Input);
            //dbParams[4] = new DBParams("@User_session_id", obj.User_session_id, ParamType.Int, ParamDirection.Input);
            dbParams[4] = new DBParams("@session_id", obj.session_id, ParamType.Int , ParamDirection.Input);
            dbParams[5] = new DBParams("@total_seat", obj.total_seats, ParamType.String, ParamDirection.Input);
            dbParams[6] = new DBParams("@total_amount", obj.total_amount, ParamType.Int, ParamDirection.Input);
            dbParams[7] = new DBParams("@ActiveID", obj.ActiveID, ParamType.Int, ParamDirection.Input);
            dbParams[8] = new DBParams("@mode", obj.Mode, ParamType.String, ParamDirection.Input);
            dbParams[9] = new DBParams("@tranid",obj.tranid,ParamType.String,ParamDirection.Output,20);
            dbParams[10] = new DBParams("@FranCode", obj.FranCode, ParamType.String, ParamDirection.Input);
            dbParams[11] = new DBParams("@cust_Amt", obj.cust_amount, ParamType.Int, ParamDirection.Input);
            dbParams[12] = new DBParams("@boardingPoint", obj.BoardingPoint, ParamType.String, ParamDirection.Input);
            dbParams[13] = new DBParams("@gender", obj.Gender, ParamType.String, ParamDirection.Input);
            dbParams[14] = new DBParams("@age", obj.Age, ParamType.String, ParamDirection.Input);
            string tranid = DALHandler.ExecuteStatementCashEntry(Constants.AddCashDetails, dbParams).ToString();
            return tranid;
          
        }
        public DataTable GetLoginInfo(string username,string pwd)
        {

            DBParams[] dbParams = new DBParams[2];

            dbParams[0] = new DBParams("@user_name", username , ParamType.String , ParamDirection.Input);
            dbParams[1] = new DBParams("@pwd", pwd, ParamType.String , ParamDirection.Input);
            return DALHandler.GetDataTable("USP_GET_Logininfo", dbParams);
        }
        public DataSet GetSchedule(string from, string to,string mode, string dt)
        {

            DBParams[] dbParams = new DBParams[4];

            dbParams[0] = new DBParams("@from_city", from , ParamType.String, ParamDirection.Input);
            dbParams[1] = new DBParams("@to_city", to, ParamType.String, ParamDirection.Input);
            dbParams[2] = new DBParams("@mode", mode, ParamType.String, ParamDirection.Input);
            dbParams[3] = new DBParams("@dt", dt, ParamType.DateTime , ParamDirection.Input);
            return DALHandler.GetDataSet("USP_Get_Schedule", dbParams); 

        }
        public DataSet GetBoardingPoints(int session_id)
        {

            DBParams[] dbParams = new DBParams[1];

            dbParams[0] = new DBParams("@session_id", session_id, ParamType.Int , ParamDirection.Input);
            return DALHandler.GetDataSet("USP_Get_BoardingPoints", dbParams);

        }
        public DataSet GetBestDealSchedule(string from, string to, string mode, string dt)
        {

            DBParams[] dbParams = new DBParams[4];

            dbParams[0] = new DBParams("@from_city", from, ParamType.String, ParamDirection.Input);
            dbParams[1] = new DBParams("@to_city", to, ParamType.String, ParamDirection.Input);
            dbParams[2] = new DBParams("@mode", mode, ParamType.String, ParamDirection.Input);
            dbParams[3] = new DBParams("@dt", dt, ParamType.DateTime, ParamDirection.Input);
            return DALHandler.GetDataSet("USP_GetBestDeal_Schedule", dbParams);

        }
        public DataSet GetScheduleInfo(int sessionid,string mode)
        {

            DBParams[] dbParams = new DBParams[2];

            dbParams[0] = new DBParams("@session_id", sessionid, ParamType.Int, ParamDirection.Input);
            dbParams[1] = new DBParams("@mode", mode, ParamType.String, ParamDirection.Input);
            return DALHandler.GetDataSet("USP_GET_SESSION_INFO", dbParams);

        }
        public DataSet GetTravellingInfo(string src, string des,int sid)
        {

            DBParams[] dbParams = new DBParams[3];

            dbParams[0] = new DBParams("@src", src, ParamType.String , ParamDirection.Input);
            dbParams[1] = new DBParams("@des", des, ParamType.String, ParamDirection.Input);
            dbParams[2] = new DBParams("@sid", sid, ParamType.Int, ParamDirection.Input);

            return DALHandler.GetDataSet("USP_Get_travellingInfo", dbParams);
        }
        public DataSet GetScheduleDetails(int sid)
        {
            DBParams[] dbParams = new DBParams[1];

            dbParams[0] = new DBParams("@session_id", sid, ParamType.Int , ParamDirection.Input);

            return DALHandler.GetDataSet("USP_GET_Schedule_details", dbParams);
        }
        public DataTable GetTicketInfo(string tranid,string mobno)
        {
            DBParams[] dbParams = new DBParams[2];

            dbParams[0] = new DBParams("@tranid", tranid, ParamType.String, ParamDirection.Input);
            dbParams[1] = new DBParams("@mobileno", mobno, ParamType.String, ParamDirection.Input);

            return DALHandler.GetDataSet(Constants.GetTicketDetails.ToString(), dbParams).Tables[0];
        }
        
        public DataTable  UpdateUserCashDetails(TPSLResponse obj)
        {
            DBParams[] dbParams = new DBParams[27];

            dbParams[0] = new DBParams("@MERCHANTID", obj.MERCHANTID, ParamType.String, ParamDirection.Input);
            dbParams[1] = new DBParams("@CustomerID", obj.CustomerID, ParamType.String, ParamDirection.Input);
            dbParams[2] = new DBParams("@TxnreferenceNo", obj.TxnreferenceNo , ParamType.String, ParamDirection.Input);
            dbParams[3] = new DBParams("@BankReferenceNo", obj.BankReferenceNo , ParamType.String, ParamDirection.Input);
            dbParams[4] = new DBParams("@TxnAmount", obj.TxnAmount , ParamType.String , ParamDirection.Input);
            dbParams[5] = new DBParams("@BankID", obj.BankID , ParamType.String , ParamDirection.Input);
            dbParams[6] = new DBParams("@BankMERCHANTID", obj.BankMERCHANTID , ParamType.String, ParamDirection.Input);
            dbParams[7] = new DBParams("@TxnType", obj.TxnType , ParamType.String, ParamDirection.Input);
            dbParams[8] = new DBParams("@CurrencyName", obj.CurrencyName , ParamType.String, ParamDirection.Input);
            dbParams[9] = new DBParams("@ItemCode", obj.ItemCode , ParamType.String, ParamDirection.Input);
            dbParams[10] = new DBParams("@SecurityType", obj.SecurityType, ParamType.String, ParamDirection.Input);
            dbParams[11] = new DBParams("@SecurityID", obj.SecurityID , ParamType.String, ParamDirection.Input);
            dbParams[12] = new DBParams("@SecurityPassword", obj.SecurityPassword , ParamType.String, ParamDirection.Input);
            dbParams[13] = new DBParams("@TxnDate", obj.TxnDate , ParamType.String, ParamDirection.Input);
            dbParams[14] = new DBParams("@AuthStatus", obj.AuthStatus , ParamType.String, ParamDirection.Input);
            dbParams[15] = new DBParams("@SettlementType", obj.SettlementType , ParamType.String, ParamDirection.Input);
            dbParams[16] = new DBParams("@AdditionalInfo1", obj.AdditionalInfo1 , ParamType.String, ParamDirection.Input);
            dbParams[17] = new DBParams("@AdditionalInfo2", obj.AdditionalInfo2 , ParamType.String, ParamDirection.Input);
            dbParams[18] = new DBParams("@AdditionalInfo3", obj.AdditionalInfo3 , ParamType.String, ParamDirection.Input);
            dbParams[19] = new DBParams("@AdditionalInfo4", obj.AdditionalInfo4 , ParamType.String, ParamDirection.Input);
            dbParams[20] = new DBParams("@AdditionalInfo5", obj.AdditionalInfo5 , ParamType.String, ParamDirection.Input);
            dbParams[21] = new DBParams("@AdditionalInfo6", obj.AdditionalInfo6 , ParamType.String, ParamDirection.Input);
            dbParams[22] = new DBParams("@AdditionalInfo7", obj.AdditionalInfo7 , ParamType.String, ParamDirection.Input);
            dbParams[23] = new DBParams("@ErrorStatus", obj.ErrorStatus , ParamType.String, ParamDirection.Input);
            dbParams[24] = new DBParams("@ErrorDescription", obj.ErrorDescription , ParamType.String, ParamDirection.Input);
            dbParams[25] = new DBParams("@CheckSum", obj.CheckSum , ParamType.String, ParamDirection.Input);
            dbParams[26] = new DBParams("@Status", obj.Status , ParamType.String, ParamDirection.Input);

            DataTable dt=DALHandler.GetDataTable(Constants.UpdateUserCashDetails, dbParams);

            return dt;

        }
        public DataTable AddApprochingUserdetails(string name,string phone,string Email,string Address,string city,string state,string entitytype)
        {
            DBParams[] dbParams = new DBParams[7];

            dbParams[0] = new DBParams("@CustName", name, ParamType.String, ParamDirection.Input);
            dbParams[1] = new DBParams("@Mobile_no", phone, ParamType.String, ParamDirection.Input);
            dbParams[2] = new DBParams("@EmailID", Email, ParamType.String, ParamDirection.Input);
            dbParams[3] = new DBParams("@Address", Address, ParamType.String, ParamDirection.Input);
            dbParams[4] = new DBParams("@City", city, ParamType.String, ParamDirection.Input);
            dbParams[5] = new DBParams("@State", state, ParamType.String, ParamDirection.Input);
            dbParams[6] = new DBParams("@EntityType", entitytype, ParamType.String, ParamDirection.Input);

            DataTable dt = DALHandler.GetDataTable(Constants.AddApprochingUserdetails, dbParams);

            return dt;

        }
        public DataTable GetFranchiseeDetails(string FranCode,int sessionid,string mode)
        {
            DBParams[] dbParams = new DBParams[3];

            dbParams[0] = new DBParams("@FranCode", FranCode, ParamType.String, ParamDirection.Input);
            dbParams[1] = new DBParams("@sessionid", sessionid, ParamType.Int, ParamDirection.Input);
            dbParams[2] = new DBParams("@mode", mode, ParamType.String, ParamDirection.Input);
            DataTable dt = DALHandler.GetDataTable(Constants.GetFranchiseedetails , dbParams);

            return dt;

        }
        public DataTable CancelTicket(TicketCancel obj)
        { 
            DBParams[] dbParams = new DBParams[6];

            dbParams[0] = new DBParams("@TicketNo", obj.Ticketno , ParamType.String, ParamDirection.Input);
            dbParams[1] = new DBParams("@AccountHolderName", obj.AccountHolderName , ParamType.String , ParamDirection.Input);
            dbParams[2] = new DBParams("@BankAccountNo", obj.BankAccountNo , ParamType.String, ParamDirection.Input);
            dbParams[3] = new DBParams("@BankName", obj.BankName , ParamType.String , ParamDirection.Input);
            dbParams[4] = new DBParams("@Email_id", obj.Email_id , ParamType.String, ParamDirection.Input);
            dbParams[5] = new DBParams("@Mobile_no", obj.Mobile_no , ParamType.String , ParamDirection.Input);
            DataTable dt = DALHandler.GetDataTable(Constants.CancelTicket , dbParams);

            return dt;

        
        }
        public DataTable GetSoldTicketsList(string calledFrom)
        {
            DBParams[] dbParams = new DBParams[1];

            dbParams[0] = new DBParams("@calledFrom", calledFrom, ParamType.String, ParamDirection.Input);
            
            DataTable dt = DALHandler.GetDataTable(Constants.GetSoldTicketsList, dbParams);

            return dt;

        }
        public DataSet GetAvailableSeatsDetails(int sessionid, string action)
        {
            DBParams[] dbParams = new DBParams[2];

            dbParams[0] = new DBParams("@session_id", sessionid, ParamType.Int, ParamDirection.Input);
            dbParams[1] = new DBParams("@action", action, ParamType.String , ParamDirection.Input);
            DataSet  ds = DALHandler.GetDataSet(Constants.GetAvailableSeats, dbParams);

            return ds;

        }
        public DataTable BlockSeat(int sessionid,string mode, int seatno,string action)
        {
            DBParams[] dbParams = new DBParams[4];

            dbParams[0] = new DBParams("@session_id", sessionid, ParamType.Int, ParamDirection.Input);
            dbParams[1] = new DBParams("@mode", mode, ParamType.String, ParamDirection.Input);
            dbParams[2] = new DBParams("@seatno", seatno, ParamType.Int, ParamDirection.Input);
            dbParams[3] = new DBParams("@action", action, ParamType.String, ParamDirection.Input);

            DataTable dt = DALHandler.GetDataTable(Constants.BlockTicket, dbParams);

            return dt;

        }
        public DataTable PaymentUpdateBMETWallet(string tranid)
        {
            DBParams[] dbParams = new DBParams[1];

            dbParams[0] = new DBParams("@CustomerID", tranid, ParamType.String , ParamDirection.Input);
            DataTable dt = DALHandler.GetDataTable(Constants.PaymentUpdateBMETWallet, dbParams);

            return dt;
        }
        public DataTable GetFranchiseeList(string city)
        {
            DBParams[] dbParams = new DBParams[1];

            dbParams[0] = new DBParams("@forcity", city, ParamType.String, ParamDirection.Input);
            DataTable dt = DALHandler.GetDataTable(Constants.GetFranchiseeList, dbParams);

            return dt;
        }

        //***********CarRentalDataAccessLib*********************************

        public DataTable GetCarRentalSchedule(string travel_type, string Source_city, string Destination_city, string travel_mode)
        {

            DBParams[] dbParams = new DBParams[4];

            dbParams[0] = new DBParams("@travel_type", travel_type, ParamType.String, ParamDirection.Input);
            dbParams[1] = new DBParams("@Source_city", Source_city, ParamType.String, ParamDirection.Input);
            dbParams[2] = new DBParams("@Destination_city", Destination_city, ParamType.String, ParamDirection.Input);
            dbParams[3] = new DBParams("@travel_mode", travel_mode, ParamType.String, ParamDirection.Input);
            return DALHandler.GetDataTable(Constants.GetCarRentalSchedule, dbParams);

        }
        
        public string AddCarRentalDeatails(CarRentalEntity obj)
        {
            DBParams[] dbParams = new DBParams[14];
            dbParams[0] = new DBParams("@pickup_time", obj.Pickup_Time, ParamType.String, ParamDirection.Input);            
            dbParams[1] = new DBParams("@Rental_SchdID", obj.ScheduleID , ParamType.Int , ParamDirection.Input);
            dbParams[2] = new DBParams("@Customer_name", obj.CustName , ParamType.String, ParamDirection.Input);
            dbParams[3] = new DBParams("@Gender", obj.Gender , ParamType.String, ParamDirection.Input);
            dbParams[4] = new DBParams("@Age", obj.Age, ParamType.Int, ParamDirection.Input);
            dbParams[5] = new DBParams("@Email_id", obj.EmailID , ParamType.String, ParamDirection.Input);
            dbParams[6] = new DBParams("@Mobile_no", obj.Mobile_no, ParamType.String, ParamDirection.Input);
            dbParams[7] = new DBParams("@pickup_Address", obj.Pickup_Address , ParamType.String, ParamDirection.Input);
            dbParams[8] = new DBParams("@pickup_date", obj.Pickup_Date , ParamType.DateTime , ParamDirection.Input);
            dbParams[9] = new DBParams("@Booking_ID", obj.BookingID, ParamType.String, ParamDirection.Output, 20);
            dbParams[10] = new DBParams("@bookingBMET_amt", obj.bookingBMET_amt , ParamType.Float , ParamDirection.Input);
            dbParams[11] = new DBParams("@bookingFRAN_amt", obj.bookingFRAN_amt , ParamType.Float , ParamDirection.Input);
            dbParams[12] = new DBParams("@Fran_code", obj.Fran_code , ParamType.String, ParamDirection.Input);
            dbParams[13] = new DBParams("@Fran_Markup", obj.Fran_Markup, ParamType.Int, ParamDirection.Input);


            String tranid = DALHandler.ExecuteStatementCashEntry(Constants.AddUserCarRentaldetails, dbParams);
            return tranid;

        }

        public DataTable GetCarRentalScheduleDetails(int sid)
        {
            DBParams[] dbParams = new DBParams[1];

            dbParams[0] = new DBParams("@CarRentalSessionID", sid, ParamType.Int, ParamDirection.Input);

            return DALHandler.GetDataTable(Constants.GetCarRentalScheduleDetails, dbParams);
        }



        UpdateUserCashDetails
        //Event Booking Section

        public string AddEventBookingDetails(string name,string gender,int age, string email, string mob, string address, int stagboy, int staggirl, int couple,int child, decimal bookingAmt, out string booking_id )
        {
            try
            {
                booking_id = "";
                DBParams[] dbParams = new DBParams[12];
                dbParams[0] = new DBParams("@Customer_name", name, ParamType.String, ParamDirection.Input);
                dbParams[1] = new DBParams("@Gender", gender, ParamType.String, ParamDirection.Input);
                dbParams[2] = new DBParams("@Age", age, ParamType.Int, ParamDirection.Input);
                dbParams[3] = new DBParams("@Email_id", email, ParamType.String, ParamDirection.Input);
                dbParams[4] = new DBParams("@Mobile_no", mob, ParamType.String, ParamDirection.Input);
                dbParams[5] = new DBParams("@Address", address, ParamType.String, ParamDirection.Input);
                dbParams[6] = new DBParams("@StagBoy", stagboy, ParamType.Int, ParamDirection.Input);
                dbParams[7] = new DBParams("@StagGirl", staggirl, ParamType.Int, ParamDirection.Input);
                dbParams[8] = new DBParams("@Couple", couple, ParamType.Int, ParamDirection.Input);
                dbParams[9] = new DBParams("@Booking_ID", booking_id, ParamType.String, ParamDirection.Output, 20);
                dbParams[10] = new DBParams("@Child", child, ParamType.Int, ParamDirection.Input);
                dbParams[11] = new DBParams("@bookingBMET_amt", bookingAmt, ParamType.Float, ParamDirection.Input);

                booking_id = DALHandler.ExecuteStatementCashEntry(Constants.AddUserEventBookingdetails, dbParams);
                return booking_id;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
