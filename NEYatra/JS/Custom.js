var offsetfromcursorX=12 //Customize x offset of tooltip
var offsetfromcursorY=10 //Customize y offset of tooltip

var offsetdivfrompointerX=10 //Customize x offset of tooltip DIV relative to pointer image
var offsetdivfrompointerY=10 //Customize y offset of tooltip DIV relative to pointer image. Tip: Set it to (height_of_pointer_image-1).

document.write('<div id="global-custTip"></div>') //write out tooltip DIV
document.write('<img id="global-custTipPointer" src="../images/tipPointer.gif" width="11" height="11">') //write out pointer image

var ie=document.all
var ns6=document.getElementById && !document.all
var enabletip=false
if (ie||ns6)
var tipobj=document.all? document.all["global-custTip"] : document.getElementById? document.getElementById("global-custTip") : ""

var pointerobj=document.all? document.all["global-custTipPointer"] : document.getElementById? document.getElementById("global-custTipPointer") : ""

function ietruebody(){
return (document.compatMode && document.compatMode!="BackCompat")? document.documentElement : document.body
}

function ddrivetip(thetext, thewidth){
if (ns6||ie){
tipobj.innerHTML=thetext;
enabletip=true;
//if (typeof thewidth!="undefined") 
//{
////tipobj.style.width=thewidth+"px";
////tipobj.style.height="50px";
//}
//if (typeof thecolor!="undefined" && thecolor!="") 
////tipobj.style.backgroundColor=thecolor
//tipobj.innerHTML=thetext;
//enabletip=true
//return false
}
}

function positiontip(e){
if (enabletip){
var nondefaultpos=false
var curX=(ns6)?e.pageX : event.clientX+ietruebody().scrollLeft;
var curY=(ns6)?e.pageY : event.clientY+ietruebody().scrollTop;
//Find out how close the mouse is to the corner of the window
var winwidth=ie&&!window.opera? ietruebody().clientWidth : window.innerWidth-20
var winheight=ie&&!window.opera? ietruebody().clientHeight : window.innerHeight-20

var rightedge=ie&&!window.opera? winwidth-event.clientX-offsetfromcursorX : winwidth-e.clientX-offsetfromcursorX
var bottomedge=ie&&!window.opera? winheight-event.clientY-offsetfromcursorY : winheight-e.clientY-offsetfromcursorY

var leftedge=(offsetfromcursorX<0)? offsetfromcursorX*(-1) : -1000

//if the horizontal distance isn't enough to accomodate the width of the context menu
if (rightedge<tipobj.offsetWidth)
{
//move the horizontal position of the menu to the left by it's width
tipobj.style.left=curX-tipobj.offsetWidth+"px"
nondefaultpos=true
}
else if (curX<leftedge)
tipobj.style.left="0px"
else{
//position the horizontal position of the menu where the mouse is positioned
tipobj.style.left=curX+offsetfromcursorX-offsetdivfrompointerX+"px"
pointerobj.style.left=curX+offsetfromcursorX+"px"
}

//same concept with the vertical position
if (bottomedge<tipobj.offsetHeight){
tipobj.style.top=curY-tipobj.offsetHeight-offsetfromcursorY+"px"
nondefaultpos=true
}
else{
tipobj.style.top=curY+offsetfromcursorY+offsetdivfrompointerY+"px"
pointerobj.style.top=curY+offsetfromcursorY+"px"
}
tipobj.style.visibility="visible"
if (!nondefaultpos)
pointerobj.style.visibility="visible"
else
pointerobj.style.visibility="hidden"
}
}

function hideddrivetip(){
if (ns6||ie){
enabletip=false
tipobj.style.visibility="hidden"
pointerobj.style.visibility="hidden"
tipobj.style.left="-1000px"
tipobj.style.backgroundColor=''
tipobj.style.width=''
}
}

document.onmousemove=positiontip

 function fnSplash(id)
 {   
       //document.getElementById('ctl00_ContentPlaceHolder1_CtlSalesProjection1_Button1').disabled=true;
       obj= document.getElementById('proj');
        var tab; 
        var ddiv;        
        var tbl=obj;
        var height  = 0;       
        var divAjax =  document.getElementById('AlertDiv').parentNode.childNodes[0];
        
//       alert(divAjax.innerHTML);

//        alert(findPos(tbl,'top'));
        divAjax.style.top = findPos(tbl,'top') ;

        divAjax.style.left = findPos(tbl,'left') ;

        //divAjax.style.top = tbl.style.top;

        divAjax.style.height = tbl.offsetHeight;

        divAjax.style.width = tbl.offsetWidth;

        ActivateAlertDiv('visible', 'AlertDiv');

      }
      
      function ActivateAlertDiv(visstring, elem)
    {
         var adiv = $get(elem);
//         alert(adiv);
         adiv.style.visibility = visstring;
    }
    
    
    function findPos(obj,flag) 
    {

      var curleft = curtop = 0;
     //If the browser supports offsetParent we proceed.
      if (obj.offsetParent) {
    //Every time we find a new object, we add its offsetLeft and offsetTop to curleft and curtop.
      do {
                  curleft += obj.offsetLeft;
                  curtop += obj.offsetTop;
        //The tricky bit: return value of the = operator
        //Now we get to the tricky bit:
            } while (obj = obj.offsetParent);   
            if(flag == 'left')
               return curleft;
            else if (flag == 'top')
                return curtop;                                
            return null;
            //alert('left: ' + curleft);  
            //alert('top: ' + curtop);  

            }

       }