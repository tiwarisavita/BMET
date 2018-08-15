<%@ page language="C#" autoeventwireup="true" inherits="clock" CodeFile="~/clock.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
<style type="text/css">
.clock {width:230px; margin:0 ; padding:0px; color:Purple;background:#ffffff; height:25px; text-align:center; vertical-align:top; }
.Date { font-family:'Verdana Arial Sans-Serif'; font-size:12px; font-weight:bold; text-align:center; vertical-align:top;  }
</style>
<script type="text/javascript">
    var monthNames = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];
    var dayNames = ["Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"]
    function startTime() {
        var today = new Date();
        var day = today.getDay();
        var h = today.getHours();
        var m = today.getMinutes();
        var s = today.getSeconds();
        var dd = today.getDate();
        var dm = today.getMonth();
        var dy = today.getFullYear();
        // add a zero in front of numbers<10
        m = checkTime(m);
        s = checksecond(s);
        day = checkday(day);
        dm = checkmonth(dm);
        document.getElementById('date').innerHTML = day + " " + dd + " " + dm + " " + dy + " " + h + ":" + m + ":" + s;
        t = setTimeout('startTime()');
    }
    function checksecond(l) {
        if (l < 10) {
            l = "0" + l;
        }
        return l;
    }
    function checkmonth(k) {
        k = monthNames[k];
        return k;
    }
    function checkday(j) {
        j = dayNames[j];
        return j;
    }
    function checkTime(i) {
        if (i < 10) {
            i = "0" + i;
        }
        return i;
    }
</script>
</head>
<body onload="startTime()">
    <form id="form2" runat="server">
    <div class="clock">
<div class="Date">
<div id="date"></div>
</div>
</div>
    </form>
</body>
</html>
