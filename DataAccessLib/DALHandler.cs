using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DataAccessLib
{
    static class DALHandler
    {
        private static string strConnection;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private static string GetConnString()
        {
            if (string.IsNullOrEmpty(strConnection))
            {
                strConnection = ConfigurationManager.ConnectionStrings[Constants.CONNSTRINGKEY].ConnectionString;
            }
            return strConnection;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strCommandName"></param>
        public static void ExecuteStatement(string strCommandName)
        {
            SqlConnection sqlConn=null;
            try
            {
                sqlConn = new SqlConnection(GetConnString());
                SqlConnection.ClearAllPools();
                SqlHelper.ExecuteNonQuery(sqlConn, System.Data.CommandType.StoredProcedure, strCommandName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConn.Close();
                sqlConn.Dispose();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strCommandName"></param>
        /// <param name="sqlParams"></param>
        public static void ExecuteStatement(string strCommandName, DBParams[] dbParams)
        {
            SqlConnection sqlConn = null;
            try
            {
                sqlConn = new SqlConnection(GetConnString());
                SqlConnection.ClearAllPools();
                SqlHelper.ExecuteNonQuery(sqlConn, System.Data.CommandType.StoredProcedure, strCommandName, dbParams);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConn.Close();
                sqlConn.Dispose();
            }
        }
        public static string ExecuteStatementCashEntry(string strCommandName, DBParams[] dbParams)
        {
            SqlConnection sqlConn = null; 
            try
            {
                sqlConn = new SqlConnection(GetConnString());
                SqlConnection.ClearAllPools();
                SqlHelper.ExecuteNonQuery(sqlConn, System.Data.CommandType.StoredProcedure, strCommandName, dbParams);
                DBParams obj = (DBParams)dbParams.GetValue(9);
                SqlParameter p = obj.SqlParam;
                return p.SqlValue.ToString();
                //int tranid = Convert.ToInt32(p.SqlValue.ToString());
                //return tranid;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConn.Close();
                sqlConn.Dispose();
            }
        }
        /// 
        /// </summary>
        /// <param name="strCommandName"></param>
        /// <returns></returns>
        public static DataSet GetDataSet(string strCommandName)
        {
            SqlConnection sqlConn = null;
            try
            {
                sqlConn = new SqlConnection(GetConnString());
                SqlConnection.ClearAllPools();
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(sqlConn, System.Data.CommandType.StoredProcedure, strCommandName);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConn.Close();
                sqlConn.Dispose();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strCommandName"></param>
        /// <param name="sqlParams"></param>
        /// <returns></returns>
        public static DataSet GetDataSet(string strCommandName, DBParams[] sqlParams)
        {
            SqlConnection sqlConn=null;
            try
            {
                sqlConn = new SqlConnection(GetConnString());
                SqlConnection.ClearAllPools();
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(sqlConn, System.Data.CommandType.StoredProcedure, strCommandName, sqlParams);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConn.Close();
                sqlConn.Dispose();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strCommandName"></param>
        /// <returns></returns>
        public static DataTable GetDataTable(string strCommandName)
        {
            SqlConnection sqlConn=null;
            try
            {
                sqlConn = new SqlConnection(GetConnString());
                SqlConnection.ClearAllPools();
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(sqlConn, System.Data.CommandType.StoredProcedure, strCommandName);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConn.Close();
                sqlConn.Dispose();
            }
        }
        /// <summary>
        /// .
        /// </summary>
        /// <param name="strCommandName"></param>
        /// <param name="sqlParams"></param>
        /// <returns></returns>
        public static DataTable GetDataTable(string strCommandName, DBParams[] sqlParams)
        {

           SqlConnection sqlConn=null;
           try
           {
               sqlConn = new SqlConnection(GetConnString());
               SqlConnection.ClearAllPools();
               DataSet ds = new DataSet();
               ds = SqlHelper.ExecuteDataset(sqlConn, System.Data.CommandType.StoredProcedure, strCommandName, sqlParams);
               return ds.Tables[0];
           }
           catch (Exception ex)
           {
               throw ex;
           }
           finally
           {
               sqlConn.Close();
               sqlConn.Dispose();
           }
        }
    }
}
