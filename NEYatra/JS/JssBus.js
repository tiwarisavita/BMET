 var arraySeats = [];

function pageLoad()
 { 
    var s=document.getElementById('ctl00_ContentPlaceHolder1_hid_session').value
    var m=document.getElementById('ctl00_ContentPlaceHolder1_hid_mode').value
    
    document.getElementById('ctl00_ContentPlaceHolder1_SeatTxt').value='';
    document.getElementById('ctl00_ContentPlaceHolder1_SeatAmt').value=''; 

   
    
    PageMethods.GetBookSeatInfo(s,m,OnSuccess, OnError);

 
 } 
 
 function OnSuccess(response) {
  
   var Res = response.substring(0,response.length-1)
    if(Res == null || Res=="")
    return;
    ResultDataTable=Res.split(',');
     
    if(ResultDataTable.length>=1)
    {
    for(i=0;i< ResultDataTable.length;i++)
    {    
    var iObj="img"+ResultDataTable[i].toString();
   // alert(iObj);
    document.getElementById(iObj).src="images/red-seat.png";
    document.getElementById(iObj).title ="Booked";
    document.getElementById(iObj).onclick="alert('This seat is already booked by another person,please book other free seats');";
    }
    
    }    
        

        }

        function OnError(error) {

            alert(error);

        }



function imgclick1(imgObject)
{

var str=document.getElementById(imgObject).id;
var lblObj=str.substring(3);
var tranvalue=document.getElementById('ctl00_ContentPlaceHolder1_hid_tranValue').value;

        if (document.getElementById(imgObject).title == "Free")
        {
            document.getElementById(imgObject).src="images/green-seat.png";
            document.getElementById(imgObject).title ="Selected";
            SetStatus(lblObj, 1, tranvalue)
        }
        else
        {
            document.getElementById(imgObject).src="images/purple-seat.png";
            document.getElementById(imgObject).title ="Free";
            SetStatus(lblObj, 0, tranvalue)        

        }


}

 //Status -0 for deletion and 1 for addition
 
    function SetStatus(lblObject, status, tranvalue)
    {    
 
    var lblVal=document.getElementById('ctl00_ContentPlaceHolder1_SeatTxt').value;
    document.getElementById('ctl00_ContentPlaceHolder1_SeatTxt').value= '';   
    document.getElementById('ctl00_ContentPlaceHolder1_lblSeats').innerHTML=''; 
    document.getElementById('ctl00_ContentPlaceHolder1_SeatAmt').value= '';        
    document.getElementById('ctl00_ContentPlaceHolder1_lblTfare').innerHTML ='';          
    
            if (status == 1)
            {
                arraySeats.push(lblObject.valueOf());
            }
           
            else
            {
               for (var i = 0; i < arraySeats.length; i++)
            {
               if(arraySeats[i]==lblObject)
               {
                arraySeats.splice(i,1);
                break;
               }
            }
            }
           
           
            for (var i = 0; i < arraySeats.length; i++)
            {
              var arrindex=indexOfArr(arraySeats[i]);
                               
                if (arrindex == (arraySeats.length - 1))
                {
                    document.getElementById('ctl00_ContentPlaceHolder1_SeatTxt').value =  document.getElementById('ctl00_ContentPlaceHolder1_SeatTxt').value  + arraySeats[i] + "";
                    document.getElementById('ctl00_ContentPlaceHolder1_lblSeats').innerHTML = document.getElementById('ctl00_ContentPlaceHolder1_lblSeats').innerHTML + arraySeats[i] + "";   

                }
                else
                {
                    document.getElementById('ctl00_ContentPlaceHolder1_SeatTxt').value =  document.getElementById('ctl00_ContentPlaceHolder1_SeatTxt').value + arraySeats[i] + ", ";                   
                    document.getElementById('ctl00_ContentPlaceHolder1_lblSeats').innerHTML = document.getElementById('ctl00_ContentPlaceHolder1_lblSeats').innerHTML + arraySeats[i] + ", ";
                }


            }
       
           if(arraySeats.length!=0)
           
           { 
           document.getElementById('ctl00_ContentPlaceHolder1_SeatAmt').value=eval((arraySeats.length)*eval(tranvalue));
            
            //SeatAmt.Text = (arraySeats.length * tranvalue).ToString();
            
            document.getElementById('ctl00_ContentPlaceHolder1_lblTfare').innerHTML = "Rs." + document.getElementById('ctl00_ContentPlaceHolder1_SeatAmt').value;
            }
            
            document.getElementById('ctl00_ContentPlaceHolder1_hid_seatnos').value=arraySeats;
            document.getElementById('ctl00_ContentPlaceHolder1_hid_seatAmt').value=eval((arraySeats.length)*eval(tranvalue));
            //Session["SeatNos"] = newArr;
            //Session["totalAmount"] = Convert.ToInt32(SeatAmt.Text.ToString());
        }
       
         


           function indexOfArr(arrObject) 
            {
            for (var i = 0; i < arraySeats.length; i++)
            {
            if(arraySeats[i]==arrObject)
            {
            return i;
            }
            }
            return -1
            }

function fillSeat()
{
//debugger;
//  alert('Client Click'); 

//    var ResultDataTable = layout_bus.GetBookSeatInfo();
//    ResultDataTable = ResultDataTable.value;
// 
// 
//    if(ResultDataTable == null)
//    return;
// 
// 
//    if(ResultDataTable.Rows.length>=1)
//    {
//    for(i=0;i< ResultDataTable.Rows.length;i++)
//    {
//    //opItem = new Option(ResultDataTable.Rows[i]['vccodedesc'],ResultDataTable.Rows[i]['chcode']);   
//    //ListBoxObject.options[ListBoxObject.length] = opItem;
//    alert(ResultDataTable.Rows[i]['seat_no']+'  '+ResultDataTable.Rows[i]['booked'])
//    }
// 
//    }
// 

}
