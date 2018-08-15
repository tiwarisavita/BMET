using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLib
{
    public class DAlException : Exception
    {
        private string _msg = "";
        public DAlException(string message)
        {
            _msg = message;
        }
        public override string Message
        {
            get
            {
                return _msg;
            }
        }
    }
}
