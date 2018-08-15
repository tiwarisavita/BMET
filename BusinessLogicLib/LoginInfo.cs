using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLib;
using System.Data;

namespace BusinessLogicLib
{
    public class LoginInfo
    {
        public DataTable GetLoginInfo(string username,string pwd)
        {
            try
            {
                DALSchedule obj = new DALSchedule();

                DataTable dt = obj.GetLoginInfo(username, pwd);
                return dt;

            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
