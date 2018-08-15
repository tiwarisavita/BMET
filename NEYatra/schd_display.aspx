<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Master/MasterPage2.master"
    ValidateRequest="false" Inherits="schd_display" CodeFile="~/schd_display.aspx.cs"
    Title="BuyMyETicket :: View Schedules" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="Server">
    <link href="style.css" rel="stylesheet" type="text/css" />
    <link href="css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="JS/Custom.js"></script>

</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
        #global-custTip
        {
            border-right: #0164a7 1px solid;
            font-family: Verdana, Arial, Helvetica, sans-serif;
            font-size: 11px;
            font-weight: normal;
            text-decoration: none;
            width: auto;
            padding-right: 4px;
            border-top: #0164a7 1px solid;
            padding-left: 4px;
            z-index: 100;
            filter: progid:DXImageTransform.Microsoft.Shadow(color=gray,direction=135);
            text-align: left;
            visibility: hidden;
            padding-bottom: 4px;
            left: -300px;
            border-left: #0164a7 1px solid;
            padding-top: 4px;
            border-bottom: #0164a7 1px solid;
            position: absolute;
            background-color: #e4f4ff;
        }
        #global-custTipPointer
        {
            z-index: 100;
            left: -300px;
            visibility: hidden;
            position: absolute;
        }
        .style1
        {
            width: 137px;
        }
    </style>

    <script type="text/javascript">
    function ms()
     {
 
        var returnstatus1 = 1;
        var date_value1 = document.getElementById('<%=txtScheduleDate.ClientID%>').value;
         var isValid = IsValidDate(date_value1);
        if (document.getElementById('<%=ddlSource.ClientID%>').selectedIndex == 0 && document.getElementById('<%=ddldestination.ClientID%>').selectedIndex == 0) {
            alert("Please select Source And Destination");
            returnstatus1 = 0;
        }
        else if (document.getElementById('<%=ddlSource.ClientID%>').selectedIndex == 0 && document.getElementById('<%=ddldestination.ClientID%>').selectedIndex != 0) {
            alert("Please select Source");
            returnstatus1 = 0;
        }
        else if (document.getElementById('<%=ddlSource.ClientID%>').selectedIndex != 0 && document.getElementById('<%=ddldestination.ClientID%>').selectedIndex == 0) {
            alert("Please select Destination");
            returnstatus1 = 0;
        }
         else if(document.getElementById('<%=ddlSource.ClientID %>').value == document.getElementById('<%=ddldestination.ClientID %>').value)
           {
           alert("Source and destination cannot be same.Please select either one.");
           returnstatus1 = 0;
           }
        else if (date_value1.length == 0) {
            alert("Please fill the Date");
             document.getElementById('<%=txtScheduleDate.ClientID %>').focus();
            returnstatus1 = 0;
        }
       
         if (!isValid && date_value1.length>0) 
           {
                    alert('Please select date in dd-MMM-yyyy format e.g. 12-MAY-2013');
                     document.getElementById('<%=txtScheduleDate.ClientID %>').value='';
                    document.getElementById('<%=txtScheduleDate.ClientID %>').focus();
                    returnstatus1 = 0;
           }
               
       
        if (returnstatus1)
        {
           return true;
        }
        else
        return false;
 }
    
      //function IsValidDate(myDate) {
      //        var filter = /^([012]?\d|3[01])-([Jj][Aa][Nn]|[Ff][Ee][bB]|[Mm][Aa][Rr]|[Aa][Pp][Rr]|[Mm][Aa][Yy]|[Jj][Uu][Nn]|[Jj][u]l|[aA][Uu][gG]|[Ss][eE][pP]|[oO][Cc]|[Nn][oO][Vv]|[Dd][Ee][Cc])-(19|20)\d\d$/
      //         return filter.test(myDate);
      //      }
           
    </script>

    <script type="text/javascript">
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

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:PostBackTrigger ControlID="btnDate5" />
        </Triggers>
        <ContentTemplate>
            <center>
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="right" valign="top">
                            <a href="javascript:history.back()"><b>
                                <h2 align="right">
                                    Back</h2>
                            </b></a>
                        </td>
                    </tr>
                </table>
                <div id="Div1" style="width: 100%; height: auto; text-align: left; background-color: White;
                    display: block; margin-right: 10px;">
                    <span class="text">Your selection</span>
                    <table>
                        <tr>
                            <td>
                                <b>Source-> </b>&nbsp;&nbsp;
                            </td>
                            <td>
                                <asp:Label ID="lblSource" runat="server" Text=""></asp:Label>
                                &nbsp;&nbsp;
                            </td>
                            <td>
                                <b>Destination-> </b>&nbsp;&nbsp;
                            </td>
                            <td>
                                <asp:Label ID="lbldes" runat="server" Text=""></asp:Label>
                                &nbsp;&nbsp;
                            </td>
                            <td>
                                <b>Mode-> </b>&nbsp;&nbsp;
                            </td>
                            <td>
                                <asp:Label ID="lblMde" runat="server" Text=""></asp:Label>
                                &nbsp;&nbsp;
                            </td>
                            <td>
                                <b>Journey Date -></b> &nbsp;&nbsp;
                            </td>
                            <td>
                                <asp:Label ID="lblDate" runat="server" Text=""></asp:Label>
                                &nbsp;&nbsp;
                            </td>
                        </tr>
                    </table>
                    <br />
                    <div class="modifySearch">
                        <span class="text">MODIFY SEARCH</span>
                    </div>
                    <table cellpadding="0" cellspacing="0" width="100%" border="0" id="tblsearch" class="modifypanel">
                        <tr>
                            <td align="center">
                                <asp:Panel ID="pnlSearch" runat="server" Width="100%" Visible="true">
                                    <table cellpadding="0" cellspacing="0" width="100%" class="text">
                                        <tr>
                                            <td class="text" style="text-align: left;">
                                                Source
                                            </td>
                                            <td class="text" style="text-align: left;">
                                                Destination
                                            </td>
                                            <td class="text" style="text-align: left;">
                                                Mode
                                            </td>
                                            <td class="text" style="text-align: left;">
                                                Journey Date
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:DropDownList ID="ddlSource" runat="server" CssClass="dd" Height="25px" Width="130px">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddldestination" runat="server" CssClass="dd" Height="25px"
                                                    Width="130px">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlMode" runat="server" CssClass="dd" Height="25px" Width="130px">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtScheduleDate" runat="server" BorderColor="#15629b" BorderWidth="1px"
                                                    CssClass="dd" Width="130px" Height="22px"></asp:TextBox>
                                                <asp:ImageButton ID="btnDate5" runat="server" ImageUrl="~/images/calendar-icon.png" />
                                                <asp:CalendarExtender ID="CalendarExtenderSchedule" runat="server" Animated="true"
                                                    CssClass="AjaxCalendar" Enabled="true" Format="dd-MMM-yyyy" OnClientDateSelectionChanged="CheckDateEalier"
                                                    OnClientShowing="DisplayDateToday" PopupButtonID="btnDate5" PopupPosition="BottomLeft"
                                                    TargetControlID="txtScheduleDate">
                                                </asp:CalendarExtender>
                                                <%--  <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtScheduleDate"
                                            CssClass="validators" ErrorMessage="Select Valid Date" ValidationExpression="[0-3][0-9][-][A-Z][a-z][a-z][-][0-9][0-9][0-9][0-9]"></asp:RegularExpressionValidator>--%>
                                            </td>
                                            <td rowspan="2">
                                                <asp:Button ID="btnSearch" runat="server" CssClass="text" OnClick="btnSearch_Click"
                                                    OnClientClick="return ms();" Text="Search" />
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </td>
                        </tr>
                    </table>
                    <br>
                    <marquee><font color="red"><b>Click on Best Deal button for getting today's Best Deal</b></font></marquee>
                    <table cellpadding="0" cellspacing="0" width="100%" border="0">
                        <tr>
                            <td>
                                <asp:ImageButton ImageUrl="~/images/best_deal.png" ID="imgbtn_bestdeal" runat="server"
                                    OnClick="Button1_Click" /><br />
                                <br />
                                <center>
                                    <asp:Label ID="lblBestDeal" runat="server" Text="Today's Best Deals" Visible="false"
                                        CssClass="text"></asp:Label></center>
                                <div id="Div2" style="width: 100%; height: auto; text-align: left; background-color: White;
                                    display: block; margin-right: 10px;">
                                    <asp:GridView ID="BestDealGrdView" runat="server" AllowPaging="true" AlternatingRowStyle-CssClass="AlterGridrow"
                                        AutoGenerateColumns="False" CssClass="datatbl" FooterStyle-CssClass="GridFooter"
                                        AllowSorting="true" HeaderStyle-CssClass="GridHeader" OnRowCommand="BestDealGrdView_RowCommand"
                                        OnRowDataBound="GridView_RowDataBound" PagerSettings-PageButtonCount="10" PagerStyle-CssClass="GridPager"
                                        PageSize="30" RowStyle-CssClass="Gridrow" ShowFooter="true" ShowHeader="true"
                                        Visible="false" Width="100%" 
                                        onpageindexchanging="BestDealGrdView_PageIndexChanging" DataKeyNames="session id">
                                        
                                        <Columns>
                                            <asp:TemplateField ControlStyle-Width="5%" HeaderText="SNo." ItemStyle-HorizontalAlign="Left">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label1" runat="server" Font-Bold="false" Text='<%#(Container.DataItemIndex)+1 +"." %>' ></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField ControlStyle-Width="5%" DataField="session id" HeaderText="ID"  ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left"/>
                                            <asp:BoundField ControlStyle-Width="20%" DataField="Counter Name" HeaderText="Counter" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left"/>
                                            <asp:BoundField ControlStyle-Width="10%" DataField="From" HeaderText="Source" ItemStyle-HorizontalAlign="Center"/>
                                            <asp:BoundField ControlStyle-Width="10%" DataField="To" HeaderText="Destination" ItemStyle-HorizontalAlign="Center"/>
                                            <asp:BoundField ControlStyle-Width="10%" DataField="ModeType" HeaderText="Vehicle" ItemStyle-HorizontalAlign="Center"/>
                                            <asp:BoundField ControlStyle-Width="15%" DataField="Schedule Date" HeaderText="Journey Date" ItemStyle-HorizontalAlign="Center"/>
                                            <asp:TemplateField ControlStyle-Width="60px" HeaderText="Dep.Time"> 
                                                <ItemTemplate>
                                                    <span class="topnav">
                                                        <asp:HyperLink ID="lnkTime" runat="server" NavigateUrl="#" onmouseout="hideddrivetip();"
                                                            Text='<%#Eval("Schedule Time") %>'  Width="60px"/>
                                                    </span>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField ControlStyle-Width="10%" DataField="CustDis" HeaderText="BMET Offer(Rs.)" ItemStyle-HorizontalAlign="Center"/>
                                            <%--<asp:BoundField ControlStyle-Width="10%" DataField="fare" HeaderText="Market Price(Rs.)" ItemStyle-HorizontalAlign="Center"/>--%>
                                           <asp:BoundField ControlStyle-Width="10%" DataField="SeatsAvailable" HeaderText="Seats Available"  ItemStyle-HorizontalAlign="Center"/>
                                            <asp:ButtonField ButtonType="Button" CommandName="cseat" ControlStyle-CssClass="text"
                                                InsertVisible="False" Text="Book Seat"></asp:ButtonField>
                                        </Columns>
                                        <EmptyDataTemplate>
                                            <div id="tbldiv" style="width: 100%; height: auto; background-color: White; display: block;">
                                                <table cellpadding="0" cellspacing="0" class="datatbl" width="100%">
                                                    <tr class="GridHeader">
                                                        <th scope="col" width="5%">
                                                            S. No.
                                                        </th>
                                                        <th scope="col" width="5%">
                                                            ID
                                                        </th>
                                                        <th scope="col" width="25%">
                                                            Counter
                                                        </th>
                                                        <th scope="col" width="10%">
                                                            Source
                                                        </th>
                                                        <th scope="col" width="10%">
                                                            Destination
                                                        </th>
                                                        <th scope="col" width="10%">
                                                            Mode
                                                        </th>
                                                        <th scope="col" width="15%">
                                                            Journey Date
                                                        </th>
                                                        <th scope="col" width="10%">
                                                            Dep. Time
                                                        </th>
                                                        <th scope="col" width="10%">
                                                            Fare
                                                        </th>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" class="tbl1" colspan="9">
                                                            <strong>No Schedule Available</strong>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            &nbsp;</tr>
                        </td>
                        <tr>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div id="Div3" style="width: 100%; height: auto; text-align: left; background-color: White;
                                    display: block; margin-right: 10px;">
                                    <asp:GridView ID="GridView1" runat="server" ShowHeader="true" ShowFooter="true" AllowPaging="true"
                                        AutoGenerateColumns="False" Width="100%" CssClass="datatbl" RowStyle-CssClass="Gridrow"
                                        AlternatingRowStyle-CssClass="AlterGridrow" HeaderStyle-CssClass="GridHeader"
                                        FooterStyle-CssClass="GridFooter" PageSize="50" PagerSettings-PageButtonCount="10"
                                        AllowSorting="true" PagerStyle-CssClass="GridPager" OnRowCommand="GridView1_RowCommand"
                                        OnRowDataBound="GridView_RowDataBound" 
                                        onpageindexchanging="GridView1_PageIndexChanging" DataKeyNames="session id">
                                        <Columns>
                                            <asp:TemplateField HeaderText="SNo." ControlStyle-Width="5%" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label1" runat="server" Font-Bold="false" Text='<%#(Container.DataItemIndex)+1 +"." %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--<asp:BoundField HeaderText="ID" DataField="session id" ControlStyle-Width="5%" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left"/>--%>
                                            <asp:BoundField HeaderText="Counter" DataField="Counter Name" ControlStyle-Width="20%" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left"/>
                                            <asp:BoundField HeaderText="Source" DataField="From" ControlStyle-Width="10%" ItemStyle-HorizontalAlign="Center"/>
                                            <asp:BoundField HeaderText="Destination" DataField="To" ControlStyle-Width="10%" ItemStyle-HorizontalAlign="Center"/>
                                            <asp:BoundField HeaderText="Vehicle" DataField="ModeType" ControlStyle-Width="10%" ItemStyle-HorizontalAlign="Center" />
                                            <asp:BoundField HeaderText="Journey Date" DataField="Schedule Date" ControlStyle-Width="10%" ItemStyle-HorizontalAlign="Center"/>
                                            <%--<asp:TemplateField HeaderText="Dep. Time" ControlStyle-Width="10%" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <span class="topnav">
                                                        <asp:HyperLink ID="lnkTime" runat="server" NavigateUrl="#" Text='<%#Eval("Schedule Time") %>'
                                                            onmouseout="hideddrivetip();" width="10%"/>
                                                    </span>
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
                                            <asp:TemplateField HeaderText="Dep.Time" ControlStyle-Width="60px">
                                                <ItemTemplate>
                                                    <span class="topnav">
                                                        <asp:HyperLink ID="lnkTime" runat="server" NavigateUrl="#" Text='<%#Eval("Schedule Time") %>'
                                                            onmouseout="hideddrivetip();" />
                                                    </span>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField ControlStyle-Width="10%" DataField="CustDis" HeaderText="BMET Offer (Rs.)"  ItemStyle-HorizontalAlign="Center"/>
                                            <%--<asp:BoundField ControlStyle-Width="10%" DataField="fare" HeaderText="Market Price(Rs.)"  ItemStyle-HorizontalAlign="Center"/>--%>
                                            <asp:BoundField ControlStyle-Width="10%" DataField="SeatsAvailable" HeaderText="Seats Available"  ItemStyle-HorizontalAlign="Center"/>
                                            <asp:ButtonField ButtonType="Button" CommandName="cseat" InsertVisible="False" Text="Book Seat"
                                                ControlStyle-CssClass="text"></asp:ButtonField>
                                        </Columns>
                                        <EmptyDataTemplate>
                                            <div id="tbldiv" style="width: 100%; height: auto; background-color: White; display: block;">
                                                <table cellspacing="0" width="100%" cellpadding="0" class="datatbl">
                                                    <tr class="GridHeader">
                                                        <th scope="col" width="5%">
                                                            S. No.
                                                        </th>
                                                        <th scope="col" width="5%">
                                                            ID
                                                        </th>
                                                        <th scope="col" width="25%">
                                                            Counter
                                                        </th>
                                                        <th scope="col" width="10%">
                                                            Source
                                                        </th>
                                                        <th scope="col" width="10%">
                                                            Destination
                                                        </th>
                                                        <th scope="col" width="10%">
                                                            Mode
                                                        </th>
                                                        <th scope="col" width="15%">
                                                            Journey Date
                                                        </th>
                                                        <th scope="col" width="10%">
                                                            Time
                                                        </th>
                                                        <th scope="col" width="10%">
                                                            Fare
                                                        </th>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="9" align="center" class="tbl1">
                                                            <strong>No Schedule Available</strong>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                            </td>
                        </tr>
                        </td>
                    </table>
                </div>
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
</asp:Content>
