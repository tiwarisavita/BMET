<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BlockSeat.aspx.cs" Inherits="BlockSeat" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <style type="text/css">
        .style1
        {
            height: 15px;
            width: 16%;
        }
        .style2
        {
            width: 16%;
        }
        .style3
        {
            height: 20px;
            width: 198px;
        }
        .style4
        {
            width: 300px;
        }
        .style5
        {
            height: 20px;
            width: 300px;
        }
    </style>
    <link href="style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
            <asp:ScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ScriptManager>
    <a href="counter_page.aspx">Home</a>    
        
    <div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table cellpadding="0" cellspacing="0" border="0" style=" width: 100%; padding: 15px 10px 6px 10px">
                    <caption>
                        <br />
                        <tr>
                            <td align="left" class="style1">
                                <b>Session No</b>
                                
                            </td>
                            <td align="left" style="width: 50%">
                                <asp:TextBox ID="txtSessionId" runat="server" Width="130px"></asp:TextBox>&nbsp;&nbsp;
                                <asp:Button ID="btnGetDeatils" runat="server" CssClass="text"    
                                    Text="Get deatils" onclick="btnGetDeatils_Click" />
                                    
                            </td>
                        </tr>
                                  <tr style="height:auto;">
                                    <td class="style1" style="vertical-align:middle;">
                                        Counter Name:
                                    </td>
                                    <td style="vertical-align:bottom;">
                                        <asp:Label ID="lblCounter" runat="server" Text="" CssClass="text"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style1">
                                        Source:
                                    </td>
                                    <td style="height: 20px">
                                        <asp:Label ID="lblSource" runat="server" Text="" CssClass="text"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style1">
                                       Destination:
                                    </td>
                                    <td style="height: 20px">
                                        <asp:Label ID="lblDes" runat="server" Text="" CssClass="text"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style1">
                                        Mode:
                                    </td>
                                    <td style="height: 20px">
                                        <asp:Label ID="lblMode" runat="server" Text="" CssClass="text"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style1">
                                        Journey Date:
                                    </td>
                                    <td style="height: 20px">
                                        <asp:Label ID="lblDate" runat="server" Text="" CssClass="text"></asp:Label>
                                    </td>
                                </tr>
                                <%--<tr>
                                    <td class="style1">
                                       Boarding Points:
                                    </td>
                                    <td style="height: 20px">
                                        <asp:Label ID="lblBording" runat="server" Text="" CssClass="text"></asp:Label>
                                    </td>
                                </tr>--%>
                                
                                <tr>
                                    <td class="style1">
                                       Fare:
                                    </td>
                                    <td style="height: 20px">
                                        <asp:Label ID="lblFare" runat="server" Text="" CssClass="text"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style1">
                                        Available Seats</td>
                                    <td style="height: 20px">
                                        <asp:DropDownList ID="ddlSeats" runat="server" Width="130px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                        <tr>
                            <td class="style2">
                                <asp:Label ID="errormessage" runat="server"></asp:Label>
                            </td>
                            <td align="left" style="width: 50%">
                                <asp:Button ID="btnSave" runat="server" CssClass="text"  Text="Block Seat" 
                                    onclick="btnSave_Click" /> &nbsp;&nbsp;
                                <asp:Button ID="btnBlockSession" runat="server" CssClass="text"  
                                    Text="Block Session" onclick="btnBlockSession_Click" 
                                    />&nbsp;&nbsp;
                                  <asp:Button ID="btnReleaseSession" runat="server" CssClass="text"  
                                    Text="Enable Session" onclick="btnReleaseSession_Click"  
                                    />  
                            </td>
                            
                        </tr>
                    </caption>
                </table>
                <hr />
                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%; padding: 15px 10px 6px 10px">
                    <caption>
                        <br />
                        <tr>
                            <td class="style3">
                                Schedule display time(Hrs)
                            </td>
                            <td class="style5">
                                <asp:TextBox ID="txtTime" runat="server" Width="167px"></asp:TextBox>
                            </td>
                              <td align="left" class="style4">
                                <asp:Button ID="btnTimeChange" runat="server" CssClass="text" 
                                    Text="Change Schd Display Time" onclick="btnTimeChange_Click" />
                                &nbsp;&nbsp;
                            </td>
                            
                        </tr>
                       
                    </caption>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
