using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessEntity
{
          public class CarRentalEntity
        {
              public String BookingID { get; set; }
            public int ScheduleID { get; set; }
            public String CustName { get; set; }
            public String Gender { get; set; }
            public Int32 Age { get; set; }
            public String EmailID { get; set; }
            public String Mobile_no { get; set; }
            public String Pickup_Address { get; set; }
            public DateTime Pickup_Date { get; set; }
            public String Pickup_Time { get; set; }
            public Decimal bookingBMET_amt { get; set; }
            public Decimal bookingFRAN_amt { get; set; }
            public String Fran_code { get; set; }
            public Int32 Fran_Markup { get; set; }
                     

        }
  
}
