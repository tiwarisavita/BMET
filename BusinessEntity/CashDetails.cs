using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessEntity
{
    public class CashDetails
    {
    public String CustName {get; set;}
    public String EmailID  {get; set;}
    public String Mobile_no{get; set;}
    public String Address{get; set;}
    //public int User_session_id{get; set;}
    public int session_id{get; set;}
    public String total_seats{get; set;}
    public Int64  total_amount{get; set;}
    public DateTime ActionDate{get; set;}
    public int ActiveID{ get; set; }
    public string Mode { get; set; }
    public string tranid { get; set; }
    public string FranCode { get; set; }
    public Int64 cust_amount { get; set; }
    public string BoardingPoint { get; set; }
    public string Age { get; set; }
    public string Gender { get; set; }
  
    }
}
