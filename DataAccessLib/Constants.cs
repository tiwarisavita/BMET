using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLib
{
    class Constants
    {
        public const string CONNSTRINGKEY = "DBCon";
        public static readonly string CreateSchedule = "USP_Create_Schedule";
        public static readonly string AddVehicle = "USP_Add_vehicle";
        public static readonly string AddCashDetails = "USP_ADD_USERINFO_CASHDETAILS";
        public static readonly string GetTicketDetails = "USP_GetTicketDetails";
        public static readonly string UpdateUserCashDetails = "USP_Update_UserInfo_CashDetails";        
        public static readonly string AddApprochingUserdetails = "USP_Add_ApprochingUsersDetails";
        public static readonly string GetFranchiseedetails = "USP_Get_FranchiseeDetails";
        public static readonly string CancelTicket = "USP_Cancel_Ticket";
        public static readonly string GetSoldTicketsList = "USP_Get_SoldTicketList";
        public static readonly string GetAvailableSeats = "USP_Get_AvaiableSeats";
        public static readonly string BlockTicket = "USP_BlockTicket";
        public static readonly string PaymentUpdateBMETWallet = "USP_BookTicketFranchiseeBMETWallet";
        public static readonly string GetFranchiseeList = "USP_Get_FranchiseeList";

        //***********CarRentalConstant*********************************

        public static readonly string GetCarRentalSchedule = "USP_CR_Get_CarRentalSchedule";
        public static readonly string AddUserCarRentaldetails = "USP_CR_Add_CarRentalBookingDetails";
        public static readonly string GetCarRentalScheduleDetails = "USP_CR_Get_CarRentalSessionDetails";

        //************EventBookingSection****************************************************
        public static readonly string AddUserEventBookingdetails = "USP_EV_Add_EventBookingDetails";

    }
}