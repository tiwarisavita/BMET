<%@ Page Language="C#" AutoEventWireup="true" CodeFile="counter_page.aspx.cs" Inherits="Counter_counter_page" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    <asp:Label ID="Label1" runat="server" Text="Welcome to Assam Travels.com"></asp:Label>
    <p>
        <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click" 
            PostBackUrl="~/Counter/Add_vehicle_info.aspx">Add 
        Vehicle Information</asp:LinkButton>
    </p>
    <asp:LinkButton ID="LinkButton2" runat="server" 
        PostBackUrl="~/Counter/make_schedule.aspx">Make Schedule</asp:LinkButton>
    </form>
</body>
</html>
