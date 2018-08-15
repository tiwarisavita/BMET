using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace DataAccessLib
{
    enum ParamType
    {

        Short = System.Data.DbType.Int16,
        Int = System.Data.DbType.Int32,
        Long = System.Data.DbType.Int64,
        Float = System.Data.DbType.Decimal,
        String = System.Data.DbType.String,
        Bool = System.Data.DbType.Boolean,
        Byte = System.Data.DbType.Byte,
        DateTime = System.Data.DbType.DateTime,
        Xml = System.Data.DbType.Xml
    }

    enum ParamDirection
    {
        Input = System.Data.ParameterDirection.Input,
        Output = System.Data.ParameterDirection.Output,
        InputOutput = System.Data.ParameterDirection.InputOutput
    }

    class DBParams
    {
        SqlParameter sqlParam;
        public DBParams(string paramName, object paramValue, ParamType paramType, ParamDirection paramDirection, int size)
        {
            sqlParam = new SqlParameter();
            sqlParam.ParameterName = paramName;
            sqlParam.Value = paramValue;
            sqlParam.DbType = (System.Data.DbType)((ParamType)paramType);
            sqlParam.Direction = (System.Data.ParameterDirection)((ParamDirection)paramDirection);
            sqlParam.Size = size;
        }
        public DBParams(string paramName, object paramValue, ParamType paramType, ParamDirection paramDirection)
        {
            sqlParam = new SqlParameter();
            sqlParam.ParameterName = paramName;
            sqlParam.Value = paramValue;
            sqlParam.DbType = (System.Data.DbType)((ParamType)paramType);
            sqlParam.Direction = (System.Data.ParameterDirection)((ParamDirection)paramDirection);

        }
        public SqlParameter SqlParam
        {
            get { return sqlParam; }
            //set { sqlParam = value; }
        }
    }


}
