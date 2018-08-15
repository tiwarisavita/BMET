<%@ Page Language="C#" MasterPageFile="~/Master/MasterPage2.master" AutoEventWireup="true" CodeFile="CarRental_SchdDisplay.aspx.cs" Inherits="CarRental_SchdDisplay" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link href="style.css" rel="stylesheet" type="text/css" />
    <link href="css/StyleSheet.css" rel="stylesheet" type="text/css" />
 <script language="javascript" type="text/javascript" src="JS/Custom.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
    <%--<h3><font color="red">Car Rental facility is running under testing mode,we will be opening shortly for our customers and users.</font></h3>--%>
    <table width="100%"><tr><td style="width:50%"><span class="text">Your selection</span></td>
    <td style="width:50%" align="right"><asp:Button ID="btn_ModifySearch" 
            runat="server" CssClass="text" Text="Modify search" 
            onclick="btn_ModifySearch_Click"/></td>
    </tr></table>
    
    <hr />
    <table>
        <tr>
            <td>
                <b>Pickup City -> </b>&nbsp;&nbsp;
            </td>
            <td>
                <asp:Label ID="lblSource" runat="server" Text=""></asp:Label>
                &nbsp;&nbsp;
            </td>
             <td>
                <b>Trip Date & Time  -></b> &nbsp;&nbsp;
            </td>
            <td>
                <asp:Label ID="lblDate" runat="server" Text=""></asp:Label>
                &nbsp;&nbsp;
            </td>
            <td>
                <b>Trip Usage-> </b>&nbsp;&nbsp;
            </td>
            <td>
                <asp:Label ID="lbltrip" runat="server" Text=""></asp:Label>
                &nbsp;&nbsp;
            </td>
           
           
        </tr>
    </table>
    <br />
       
    <br />
    
    <asp:GridView ID="Grd_CarRental" runat="server" ShowHeader="true" ShowFooter="true"
        Width="100%" AutoGenerateColumns="False" CssClass="datatbl" RowStyle-CssClass="Gridrow"
        AlternatingRowStyle-CssClass="AlterGridrow" HeaderStyle-CssClass="GridHeader"
        FooterStyle-CssClass="GridFooter" PageSize="50" PagerSettings-PageButtonCount="10"
        AllowSorting="true" PagerStyle-CssClass="GridPager" 
        OnRowDataBound="GridView_RowDataBound" onrowcommand="Grd_CarRental_RowCommand"  DataKeyNames="ScheduleID">
        <Columns>
            <asp:TemplateField HeaderText="Type of Car"  ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Right">
                <ItemTemplate>
                    <asp:Image ID="VehiImg" runat="server"  Width="150" Height="100"/>   
                            
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField  ItemStyle-HorizontalAlign="Left">
                <ItemTemplate>
                      <asp:Label ID="lblVehi" runat="server"></asp:Label>       
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="Seating Capacity" >
                <ItemTemplate>
                    <asp:Label ID="lblSeatingCapacity" runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="VendorName" HeaderText="Vendor Name"/>
            <asp:TemplateField HeaderText="Price">
                <ItemTemplate>
                    <asp:Label ID="lblPrice" runat="server"></asp:Label>
                    <span class="topnav">
                        <asp:HyperLink ID="lnkFareDetails" runat="server" NavigateUrl="#" Text="Fare Details"
                            onmouseout="hideddrivetip();" />
                    </span>
                </ItemTemplate>
                
                            </asp:TemplateField>
            <asp:ButtonField ButtonType="Button" CommandName="cseat" InsertVisible="False" Text="Select CAR"
                                                ControlStyle-CssClass="text"></asp:ButtonField>
                                                
                                              
        </Columns>
    </asp:GridView>
                                    
                                 
</asp:Content>

