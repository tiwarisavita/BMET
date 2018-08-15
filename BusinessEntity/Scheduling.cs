using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessEntity
{
    public class Scheduling
    {
        public int cunt_id { get; set; }
        public String vehi_number { get; set; }
        public String frm_city { get; set; }
        public String to_city { get; set; }
        public String mode { get; set; }
        public DateTime dtm_date { get; set; }
        public String schd_time { get; set; }
        public int tran_value { get; set; }
        public int cust_dis { get; set; }
        public int fran_dis { get; set; }
    }
}
