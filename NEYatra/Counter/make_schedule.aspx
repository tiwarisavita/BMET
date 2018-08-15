<%@ Page Language="C#" AutoEventWireup="true" debug="true" CodeFile="make_schedule.aspx.cs" Inherits="Counter_make_schedule" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>

<body><%--
<asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                                </asp:ToolkitScriptManager>--%>
               
 

    <form id="form1" runat="server">
                     <asp:ScriptManager ID="ScriptManager1" runat="server">
                                </asp:ScriptManager>
    <div>
    
        <br />
        <br />
        <br />
    
        <table bgcolor="#66FF33" border="4" style="width:100%;">
            <tr>
                <td>
                    Vehicle Number</td>
                <td>
                    <asp:DropDownList ID="DropDownList1" runat="server" Height="33px" 
                        onselectedindexchanged="DropDownList1_SelectedIndexChanged" Width="195px">
                    </asp:DropDownList>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    Counter Name</td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server" Height="23px" Width="191px"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    From</td>
                <td>
                    <asp:DropDownList ID="DropDownList2" runat="server" Height="20px" Width="190px">
                    </asp:DropDownList>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    To</td>
                <td>
                    <asp:DropDownList ID="DropDownList3" runat="server" Height="18px" Width="190px">
                    </asp:DropDownList>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    Mode</td>
                <td>
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                <asp:DropDownList ID="DropDownList4" runat="server" Height="18px" Width="190px" 
                        onselectedindexchanged="DropDownList4_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    Scheduled Date
                </td>
                
<td>
<asp:TextBox ID="txtScheduleDate" runat="server" Width="100px"></asp:TextBox>
<asp:CalendarExtender ID="CalendarExtenderSchedule" runat="server"  
           Format="dd-MM-yyyy HH:mm:ss" Animated="true" Enabled="true" 
        TargetControlID="txtScheduleDate">
</asp:CalendarExtender>
</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr><td>Schedule Time</td><td><asp:DropDownList id="ddlTime" runat="server" Width="60px"></asp:DropDownList>
&nbsp;&nbsp;<asp:DropDownList id="ddlHr" runat="server" Width="60px"></asp:DropDownList>
 </td></tr>
            <tr>
                <td>
                    Fare</td>
                <td>
                    <asp:TextBox ID="TextBox3" runat="server" Height="23px" Width="197px"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:Button ID="Button1" runat="server" Text="Make Schedule" 
                        onclick="Button1_Click" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
