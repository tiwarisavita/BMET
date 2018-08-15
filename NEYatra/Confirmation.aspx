<%@ Page Language="C#" MasterPageFile="~/Master/MasterPage2.master" AutoEventWireup="true" CodeFile="Confirmation.aspx.cs" Inherits="Confirmation" Title="BuyMyETicket :: Contact Info" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="style.css" rel="stylesheet" type="text/css" />
    

    <script type="text/javascript">            
        
    function showMe()
    {
    var obj=document.getElementById("chkFranchisee");
    if(obj.checked==true)   
    document.getElementById('Fran_info').style.display='block';
    else   
    document.getElementById('Fran_info').style.display='none';
    }
    
    function chkEnabled(obj)
    {
    if(obj=='Y')
          document.getElementById("chkFranchisee").disabled=true;
          else
          document.getElementById("chkFranchisee").disabled=false;
     }

    

    function ConfirmBMETWallet()
    {

        if (confirm("Do you proceed with BMETWallet payment method?")) {
            document.getElementById('<%=hd_confirm.ClientID %>').value = "Yes";
        } else {
            document.getElementById('<%=hd_confirm.ClientID %>').value = "No";
        }

    }
    </script>
    

    <style type="text/css">
        .style1
        {
            height: 20px;
            width: 118px;
        }
    </style>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
    <div id="Div1" style="width: 100%; background-color: White; display: block;">
        <table cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td align="right">
                    <a href="javascript:history.back()"><b><span style="text-align: right">Back</span> </b>
                    </a>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <table style="background-image: url('images/bkgAmt.jpg'); background-repeat: no-repeat;
                                width: 101%;" runat="server" visible="false" id="errMsg">
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="lblErrorMsg" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="btnpay" EventName="Click" />
                            <asp:AsyncPostBackTrigger ControlID="btnBMETWallet" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
       
        <table width="100%">
        <tr>
        <td style="width:70%" align="left" valign="top">
        <table>
            <tr>
                <td>
                    <span class="text" style="font-size: medium">Personal Information</span>
                    <hr width="90%" align="left" />
                    <asp:Panel ID="txtPanel" runat="server">
                    </asp:Panel>
                    <br />
                    <asp:Label ID="Contactdetails" runat="server" CssClass="text" style="font-size: medium" Text="Contact Information"></asp:Label>
                    <hr width="90%" align="left" />
                </td>
            </tr>
        </table>
        <table cellspacing="5px">
            <tr>
                <td style="width: 89px;" class="text">
                    Email-id&nbsp;<span style="color: Red">*</span>
                </td>
                <td style="padding: 0px 0px 0px 10px; text-align: left;">
                    &nbsp;&nbsp;
                    <asp:TextBox ID="txtEmail" runat="server" Width="250px"></asp:TextBox>
                    <ajx:TextBoxWatermarkExtender ID="txtEmailWaterMark" runat="server" TargetControlID="txtEmail"
                        WatermarkText="Ticket will be mailed to this ID" WatermarkCssClass="watermark">
                    </ajx:TextBoxWatermarkExtender>
                    <asp:RequiredFieldValidator ID="rfvEmailID" runat="server" ControlToValidate="txtEmail"
                        ErrorMessage="Please enter Email-id" InitialValue=""  >   
                    </asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="txtEmailREV" runat="server" SetFocusOnError="true"
                        ErrorMessage="Please enter valid mail-id" ControlToValidate="txtEmail" ValidationExpression="^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 95px; text-align: left" class="text">
                    <asp:Label ID="lblAddress" runat="server" Text="Address"></asp:Label>  &nbsp;<span style="color: Red">*</span>
                </td>
                <td style="padding: 0px 0px 0px 10px; text-align: left;">
                    &nbsp;&nbsp;
                    <asp:TextBox ID="txtAddress" runat="server" Width="250px"></asp:TextBox>
                    <ajx:TextBoxWatermarkExtender ID="txtAddWaterMark" runat="server" TargetControlID="txtAddress"
                        WatermarkText="Please enter address" WatermarkCssClass="watermark">
                    </ajx:TextBoxWatermarkExtender>
                    <asp:RequiredFieldValidator ID="txtAddressRFV" runat="server" ControlToValidate="txtAddress"
                        ErrorMessage="Please enter address" InitialValue="">                                   
                    </asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="txtAddREV" runat="server" SetFocusOnError="true"
                        ErrorMessage="Please enter valid address" ControlToValidate="txtAddress" ValidationExpression="^[-0-9a-zA-Z ,:.]+$"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 89px; text-align: left" class="text">
                    Mobile No.&nbsp;<span style="color: Red">*</span>
                </td>
                <td style="padding: 0px 0px 0px 10px; text-align: left;">
                    &nbsp;&nbsp;
                    <asp:TextBox ID="TextBox1" runat="server" Text="+91" Width="25px" Enabled="false"
                        BackColor="Silver"></asp:TextBox>
                    <asp:TextBox ID="txtMobile" runat="server" Width="218px" MaxLength="10"></asp:TextBox>
                    <ajx:TextBoxWatermarkExtender ID="txtmobWaterMark" runat="server" TargetControlID="txtMobile"
                        WatermarkText="SMS will be sent to this no." WatermarkCssClass="watermark">
                    </ajx:TextBoxWatermarkExtender>
                    <asp:RequiredFieldValidator ID="txtMobRFV" runat="server" ControlToValidate="txtMobile"
                        ErrorMessage="Please enter mobile no." InitialValue="">                                   
                    </asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="txtMobREV" runat="server" SetFocusOnError="true"
                        ErrorMessage="Ten digit no. only" ControlToValidate="txtMobile" ValidationExpression="^[0-9]{10}$"></asp:RegularExpressionValidator>
                </td>
            </tr>
            
            
            <tr>
                <td style="width: 89px; text-align: left" class="text">
                    <asp:Label ID="lblBoardingPoint" runat="server">Boarding Point&nbsp;<span style="color: Red">*</span></asp:Label>  
                </td>
                <td style="padding: 0px 0px 0px 10px; text-align: left;">
                    &nbsp;&nbsp;
                    <asp:DropDownList ID="ddlBoardingPoints" runat="server" Width="255px">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="ddlBoardingRFV" runat="server" ControlToValidate="ddlBoardingPoints"
                        ErrorMessage="Please select boarding point" InitialValue="-1">                                   
                    </asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <br />
                    <br />
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <table style="background-image: url('images/bkgAmt.jpg'); background-repeat: no-repeat;
                                width: 100%; height: 64px;">
                                <tr>
                                    <td align="center" style="width:50%">
                                    <span class="text" style="font-size: large;"><asp:Label ID="lblAmtPayabletext" runat="server" Text="Amount Payable"></asp:Label></span>                                        
                                    </td>
                                    <td align="left" style="width:50%">
                                        <asp:Label ID="lblAmtPayable" runat="server" style="font-size: large;" CssClass="text"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="btnVerify" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="left">
                    <br />
                    <input type="checkbox" id="chkFranchisee" onclick="showMe()" />Are you Franchisee?(optional)
                    <table id="Fran_info" style="display: none;">
                        <tr>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <table>
                                            <tr>
                                                <td class="text">
                                                    Enter Franchisee Code
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtFranCode" TextMode="Password" runat="server"></asp:TextBox>                                                   
                        
                                                </td>
                                                <td align="right">
                                                    <asp:Button ID="btnVerify" runat="server" Text="Franchisee Login" CssClass="text"
                                                        OnClick="btnVerify_Click"  CausesValidation="false"/>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                    <asp:Label ID="lblFranName" runat="server" CssClass="text"></asp:Label>
                                                </td>
                                            </tr>
                                             <tr>
                                                <td>
                                                    <asp:Label ID="lblFranMarkup" runat="server" CssClass="text" Text="Franchisee Mark-up" Visible="false"></asp:Label>
                                                </td>
                                                 <td colspan="2">
                                                     <asp:TextBox ID="txtFranMarkup" runat="server" Visible="false" MaxLength="4"></asp:TextBox>
                                                     <ajx:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" TargetControlID="txtFranMarkup"
                                                         WatermarkText="Franchisee Mark-up value" WatermarkCssClass="watermark">
                                                     </ajx:TextBoxWatermarkExtender>
                                                     <asp:RangeValidator ID="ValMarkup" runat="server" ControlToValidate="txtFranMarkup"
                                                         ForeColor="Red"></asp:RangeValidator>
                                                 </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
             <tr><td colspan="2" align="left">
                <asp:Literal ID="lttPolicy" runat="server" ></asp:Literal></td></tr>
            <tr>
                <td colspan="2" align="left">
                <br />
                    <asp:Button ID="btnpay" runat="server" Text="Proceed to Payment Gateway" CssClass="text"
                        OnClick="btnpay_Click"  Height="40px" Width="230px" Font-Size="12pt"/>
                </td>
            </tr>
            
           
        </table>
        </td>
        <td style="width:30%" align="right" valign="top" id="Bookingsummary" runat="server">
        <table border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td class="bgimage" style="width: 225px; height: 250px;">
                    <table border="0" cellpadding="0" cellspacing="0" class="text" style="height: 250px;
                        width: 215px; padding: 6px 2px 20px 8px">
                        <tr>
                            <td colspan="2" class="text"  style="font-size:medium" align="center" valign="top">
                               Booking Summary
                            </td>
                        </tr>
                        <tr>
                            <td class="text" style="width: 80px; text-align: left;">
                                <asp:Label ID="lblSourceText" runat="server" Text="From"></asp:Label>   
                            </td>
                            <td align="left" style="width: 135px">
                              <asp:Label ID="lblSource" runat="server"  Font-Underline="true"  Text="" CssClass="text"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 80px; text-align: left;">
                              <asp:Label ID="lblDesText" runat="server" Text="To"></asp:Label>  
                            </td>
                            <td align="left" style="width: 135px">
                              <asp:Label ID="lblDes" runat="server" Font-Underline="true"  Text="" CssClass="text"></asp:Label>
                            </td>
                        </tr>
                        
                      
                        <tr>
                            <td style="width: 80px; text-align: left;">
                              <asp:Label ID="lblModeText" runat="server" Text="Vehicle Type"></asp:Label>  
                            </td>
                            <td style="text-align: left; width: 135px">
                             <asp:Label ID="lblMode" runat="server" Text="" CssClass="text"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left; width: 80px">
                              <asp:Label ID="lblDateText" runat="server" Text="Date & Time"></asp:Label> 
                            </td>
                            <td style="width: 135px;">
                                  <asp:Label ID="lblDate" runat="server" Text="" CssClass="text"></asp:Label>
                            </td>
                        </tr>
                         <tr>
                            <td style="width: 80px; text-align: left;">
                              <asp:Label ID="lblSeatnoText" runat="server" Text="Seat no(s):"></asp:Label>   
                            </td>
                            <td align="left" style="width: 135px">
                             <asp:Label ID="lblSeatno" runat="server" Text="" CssClass="text"></asp:Label>
                            </td>
                        </tr>
                      
                        <tr>
                            <td style="width: 80px; text-align: left;">
                              <asp:Label ID="lblFareText" runat="server" Text="Fare Details"></asp:Label>  
                            </td>
                            <td align="left" style="width: 135px">
                             <asp:Label ID="lblFare" runat="server" Text="" CssClass="text"></asp:Label>
                            </td>
                        </tr>
                           <tr>
                            <td style="width: 80px; text-align: left;">
                              <asp:Label ID="lblCounterText" runat="server" Text="Operator"></asp:Label>  
                            </td>
                            <td align="left" style="width: 135px">
                              <asp:Label ID="lblCounter" runat="server" Text="" CssClass="text"></asp:Label>
                            </td>
                        </tr>
                      
                      
                    </table>
                </td>       
            
            
                
               
            </tr>
        </table>
        <br />
        <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table id="tbl_BmetWallet" runat="server" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td class="bgimage" style="width: 225px; height: 250px;">
                            <table border="0" cellpadding="0" cellspacing="0" class="text" style="height: 250px;
                                width: 225px; padding: 6px 2px 20px 8px">
                                <tr>
                                    <td class="text" style="font-size: medium;" align="center" valign="top">
                                        BMET Wallet
                                    </td>
                                </tr>
                                <tr>
                                    <td class="text" align="left" valign="top" style="font-size:medium;">
                                    <br />
                                     1. Get 1% cash back at once  <br /> <br />
                                     2. Hassle free transaction<br /> <br />
                                     3. No need to access  gateway <br />   <br />      
                                     4. Easy to Use    <br />   <br />   
                                     5. Secure transactions    <br />   <br />                                      
                                         
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <table id="tbl_BmetWalletinfo" runat="server" border="0" cellpadding="0" cellspacing="0"
                    visible="false">
                    <tr>
                        <td class="bgimage" style="width: 225px; height: 250px;">
                            <table border="0" cellpadding="0" cellspacing="0" class="text" style="height: 250px;
                                width: 225px; padding: 6px 2px 20px 8px">
                                <tr>
                                    <td  colspan="2" class="text" style="font-size: medium;" align="center" valign="top">
                                        BMET Wallet
                                    </td>
                                </tr>
                                <tr>
                                    <td class="text" style="padding-right:5px">
                                        Frachisee
                                    </td>
                                    <td style="padding-left:5px">
                                        <asp:Label ID="lblFranNameWallet" runat="server" Text="" CssClass="text"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                <td class="text" style="padding-right:5px">
                                        Balance
                                    </td>
                                    <td style="padding-left:5px;">
                                        <asp:Label ID="lblBmetWallet" runat="server" Text="" CssClass="text" Font-Size="Medium"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:Label ID="lblBMETWalletmsg" runat="server" Text="Enter BMETWallet Password"
                                            Visible="false"></asp:Label>
                                        <asp:TextBox ID="txtBMETWalletCode" Text="" runat="server" Visible="false" Width="160px"
                                            MaxLength="10" TextMode="Password"></asp:TextBox><br />
                                        
                                            <br />
                                            <asp:Button ID="btnBMETWallet" runat="server" Text="Proceed with BMETWallet" Visible="false"
                                                CssClass="text"  OnClick="btnBMETWallet_Click"
                                                Height="40px" Width="200px" Font-Size="12pt" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnVerify" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
        </td>
        </tr>
        </table>
    </div>
    <input type="hidden" id="hd_confirm" runat="server" />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
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

