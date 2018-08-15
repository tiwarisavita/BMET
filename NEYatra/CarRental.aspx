<%@ Page Language="C#" MasterPageFile="~/Master/MasterPage2.master" AutoEventWireup="true" CodeFile="CarRental.aspx.cs" Inherits="CarRental" Title="BuyMyETicket :: Car Rental" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <%@ register tagprefix="uc" tagname="DateTime" src="~/CarRental_datetime.ascx" %>
    <%@ register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
    <link href="style.css" rel="stylesheet" type="text/css" />
    <link href="style2.css" rel="stylesheet" type="text/css" />
    <link href="css/Ajaxtabcontent.css" rel="stylesheet" type="text/css" />
    <link href="css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="tab-content/template1/tabcontent.css" rel="stylesheet" type="text/css" />

    <script src="tab-content/tabcontent.js" type="text/javascript"></script>
    

 
    <script src="js/compressed.js" type="text/javascript"></script>
    

    <style type="text/css">
        .style1
        {
            font-size: 12px;
            font-family: Verdana Arial Sans-Serif;
            color: Purple;
            font-weight: bold;
            width: 13%;
            height: 41px;
        }
    </style>



    <script type="text/javascript">
        function moreinfo() {
            window.location = "MoreInfo.htm";
        }
   
    function CheckDateEalier(sender,args) {
        if (sender._selectedDate < new Date()) {
             alert("You cannot select a day before today!");
             sender._selectedDate = new Date(); 
             // set the date back to the today
            sender._textbox.set_Value(sender._selectedDate.format(sender._format))
         }
     }
     function DisplayDateToday(sender, args) {
         if (sender._selectedDate == null) {
             sender._selectedDate = new Date();
         }
     }
     </script>
    <script type="text/javascript">
    function showMe(test)
    {
   
    if(test=='Y')   
    {
    document.getElementById('Fran_info').style.display='block';
    //document.getElementById('pnlBooking').style.display='none';
    }
    else
    {
    document.getElementById('Fran_info').style.display='none';
   // document.getElementById('pnlBooking').style.display='block';
    }
    </script>
        <asp:ScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ScriptManager>
       <br />
    <%--<table id="Fran_info" style="display: block;" width="100%" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <table>
                            <tr>
                                <td class="text">
                                    <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="TabContainer1$Local$btn_LocalSearch" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="TabContainer1$Outstation$btn_OutstationSearch" EventName="Click" />                            
                        <asp:AsyncPostBackTrigger ControlID="TabContainer1$Airport$btn_AirportSearch" EventName="Click" />
                    </Triggers> 
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>--%>
        <br />
       
    <table width="100%" cellpadding="0" cellspacing="0">
        <tr>
            <td style="padding-left: 0px; padding-right: 15px; height: 200px; width: 40%" align="justify"
                valign="top">
                <asp:UpdatePanel ID="upd_CarRental" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:TabContainer ID="TabContainer1" runat="server" Height="154px" Visible="true"
                            CssClass="CustomTabStyle" ActiveTabIndex="0">
                            <asp:TabPanel ID="Local" runat="server" HeaderText="Local">
                                <HeaderTemplate>
                                    Local
                                </HeaderTemplate>
                                <ContentTemplate>
                                    <table width="100%">
                                        <tr>
                                            <td width="50%">
                                                <b>Local City</b>
                                            </td>
                                            <td width="50%">
                                                <b>for</b>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="50%">
                                                <asp:DropDownList ID="ddlLocalSrc" runat="server" Width="140px" CssClass="dd">
                                                </asp:DropDownList>
                                            </td>
                                            <td width="50%">
                                                <asp:DropDownList ID="ddlLocalDuration" runat="server" Width="140px" CssClass="dd">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <uc:DateTime ID="datetimeLocal" runat="server"  />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" align="center">
                                                <asp:Button ID="btn_LocalSearch" runat="server" CssClass="text" Text="Search CAR"
                                                    OnClick="btn_LocalSearch_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:TabPanel>
                            <asp:TabPanel ID="Outstation" runat="server" HeaderText="Outstation">
                                <ContentTemplate>
                                    <table width="100%">
                                        <tr>
                                            <td width="50%">
                                                <b>Source</b>
                                            </td>
                                            <td width="50%">
                                                <b>Destination</b>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="50%">
                                                <asp:DropDownList ID="ddlOutstationSrc" runat="server" Width="140px" CssClass="dd">
                                                </asp:DropDownList>
                                            </td>
                                            <td width="50%">
                                                <asp:DropDownList ID="ddlOutstationDes" runat="server" Width="140px" CssClass="dd">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <uc:DateTime ID="datetimeOutStation" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="50%">
                                                <asp:RadioButton ID="rd_Oneway" runat="server" GroupName="travelmode" Text="One Way Trip"
                                                    Font-Bold="true" Checked="true" />
                                            </td>
                                            <td width="50%">
                                                <asp:RadioButton ID="rd_RoundTrip" runat="server" GroupName="travelmode" Text="Round Trip"
                                                    Font-Bold="true" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" align="center">
                                                <asp:Button ID="btn_OutstationSearch" CausesValidation="false" runat="server" CssClass="text"
                                                    Text="Search CAR" OnClick="btn_OutstationSearch_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:TabPanel>
                            <asp:TabPanel ID="Airport" runat="server" HeaderText="Airport Transfer">
                                <ContentTemplate>
                                    <table width="100%">
                                        <tr>
                                            <td width="50%">
                                                <b>Airport City</b>
                                            </td>
                                            <td width="50%">
                                                <b>Pickup/Drop</b>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="50%">
                                                <asp:DropDownList ID="ddlAirportCity" runat="server" Width="140px" CssClass="dd">
                                                </asp:DropDownList>
                                            </td>
                                            <td width="50%">
                                                <asp:DropDownList ID="ddlPickupDrop" runat="server" Width="140px" CssClass="dd">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <uc:DateTime ID="datetimeAirport" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" align="center">
                                                <asp:Button ID="btn_AirportSearch" CausesValidation="False" runat="server" CssClass="text"
                                                    Text="Search CAR" OnClick="btn_AirportSearch_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:TabPanel>
                        </asp:TabContainer>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td align="center" style="width: 60%">
                <img src="images/car2.JPG" height="170px" />
            </td>
        </tr>
    </table>
    <br />
    
   
    
    
            
    <br /><br />
    
       <br /><br />
</asp:Content>

