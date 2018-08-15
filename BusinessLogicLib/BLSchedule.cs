using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessEntity;
using DataAccessLib;
using System.Data;

namespace BusinessLogicLib
{
    public class BLSchedule
    {
        public int CreateSchedule(Scheduling obj)
        {
            try
            {
                DALSchedule objSch = new DALSchedule();
                objSch.CreateSchedule(obj);
                return 1;


            }
            catch (Exception)
            {
                throw;
            }

        }
        public int AddVehicle(Vehicle obj)
        {
            try
            {
                DALSchedule objSchedule = new DALSchedule();
                objSchedule.AddVehicle(obj);
                return 1;

            }
            catch (Exception)
            {
                throw;
            }

            
        }
        public string AddCashDetails(CashDetails obj)
        {
            try
            {
                DALSchedule objSchedule = new DALSchedule();
                string tranid = objSchedule.AddCashDeatails(obj).ToString();
                //return 1;
                return tranid;

            }
            catch (Exception)
            {
                throw;
            }



           
        }
      
        public DataSet GetScheduleDetails(int session_id)
        {
            try
            {
                DALSchedule obj = new DALSchedule();

                DataSet ds = obj.GetScheduleDetails(session_id);
                return ds;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public DataSet GetBoardingPoints(int session_id)
        {
            try
            {
                DALSchedule obj = new DALSchedule();

                DataSet ds = obj.GetBoardingPoints(session_id);
                return ds;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public DataSet GetSchedule(string from, string to, string mode, string dt)
        {
            try
            {
                DALSchedule obj = new DALSchedule();

                DataSet ds = obj.GetSchedule( from, to, mode, dt);
                return ds;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public DataSet GetBestDealSchedule(string from, string to, string mode, string dt)
        {
            try
            {
                DALSchedule obj = new DALSchedule();

                DataSet ds = obj.GetBestDealSchedule(from, to, mode, dt);
                return ds;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public DataSet GetScheduleInfo(int sessionid,string mode)
        {
            try
            {
                DALSchedule obj = new DALSchedule();

                DataSet ds = obj.GetScheduleInfo(sessionid,mode);
                return ds;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public DataSet GetTravellingInfo(string src,string des,int sid)
        {
            try
            {
                DALSchedule obj = new DALSchedule();

                DataSet ds = obj.GetTravellingInfo(src, des, sid);
                return ds;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public DataTable GetTicketInfo(string tranid,string mobno)
        {
            try
            {
                DALSchedule obj = new DALSchedule();

                DataTable dt = obj.GetTicketInfo(tranid, mobno);
                return dt;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public DataTable UpdateUserCashDetails(TPSLResponse  obj)
        {
            try
            {
                DALSchedule objSch = new DALSchedule();

                DataTable dt=objSch.UpdateUserCashDetails(obj);

                return dt;
                

            }
            catch (Exception)
            {
                throw;
            }


        }
        public DataTable GetFranchiseeDetails(string FranCode, int sessionid, string mode)
        {
            try
            {
                DALSchedule objSch = new DALSchedule();

                DataTable dt = objSch.GetFranchiseeDetails(FranCode, sessionid, mode);

                return dt;


            }
            catch (Exception)
            {
                throw;
            }

        }
        public DataTable CancelTicket(TicketCancel obj)
        {
            try
            {
                DALSchedule objSch = new DALSchedule();

                DataTable dt = objSch.CancelTicket(obj);

                return dt;


            }
            catch (Exception)
            {
                throw;
            }

        }
        public DataTable PaymentUpdateBMETWallet(string tranid)
        {
            try
            {
                DALSchedule objSch = new DALSchedule();

                DataTable dt = objSch.PaymentUpdateBMETWallet(tranid);

                return dt;


            }
            catch (Exception)
            {
                throw;
            }

        }

        //***********CarRentalDataAccessLib*********************************

        public DataTable GetCarRentalSchedule(string travel_type, string Source_city, string Destination_city, string travel_mode)
        {
            try
            {
                DALSchedule obj = new DALSchedule();

                DataTable  dt = obj.GetCarRentalSchedule(travel_type, Source_city, Destination_city, travel_mode);
                return dt;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public string AddCarRentalDetails(CarRentalEntity obj)
        {
            string tranid = "";
            DALSchedule objSchedule = new DALSchedule();
            tranid = objSchedule.AddCarRentalDeatails(obj);
            return tranid;

        }

        public DataTable GetCarRentalScheduleDetails(int session_id)
        {
            try
            {
                DALSchedule obj = new DALSchedule();

                DataTable  dt = obj.GetCarRentalScheduleDetails(session_id);
                return dt;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public string AddEventBookingDetails(string name, string gender, int age, string email, string mob, string address, int stagboy, int staggirl, int couple, int child, decimal bookingAmt)
        {
            try
            {
                string tranid = "";
                DALSchedule objSchedule = new DALSchedule();
                tranid = objSchedule.AddEventBookingDetails(name, gender, age,  email, mob, address,  stagboy,  staggirl,  couple,  child,  bookingAmt, out tranid);
                return tranid;
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
