<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LogHandling.aspx.cs" Inherits="LogHandling" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
 <script language="javascript" src="./JS/date-picker.js" type="text/javascript"></script>    
    <script language="javascript" src="./JS/ValidateGeneric.JS" type="text/javascript"></script>
    <title>Untitled Page</title>
</head>
<body>
<script language="javascript" type="text/javascript">
         
		function ShowDatePicker(calObj,flag,outObj,imageName)
		{ 
			var calId=new String(calObj.id)
			if(flag=='S')
				var objId=calId.replace(imageName,outObj)
			else 
				var objId=calId.replace(imageName,outObj)				
			show_calendar('form1.'+outObj,null,null,'DD-MON-YYYY')	
		}
		function ChangeDateFormat(calObj)
		{			
			if (calObj.value != "")
			{
			
			var txtDateVal = calObj.value;
			var ch = DateVerifierTo_ddMMMyyyy(txtDateVal);

			if (ch == "" )
			{
			calObj.focus();
			return
			}
			
			calObj.value =  DateVerifierTo_ddMMMyyyy(calObj.value) 
			
			}
		}
		
		
	function open_new_window(ObjFilename,empCOde) 
	{ 
        var url;
        url= ObjFilename+"?empcode="+empCOde;
        //alert(url);
        dlg = window.open (url,'',"width=500,height=500,toolbar=0,location=0, directories=0,status=yes,menubar=0,scrollbars=yes,resizable=0") ;
        
    } 
		
		
    </script>
    <form id="form1" runat="server">
    <div>
    <table class="tblHeader">
<tr style ="background-color : #FFF099" class="pagetitle">
    <td style="height: 24px">From :</td>
    <td style="height: 24px">
        <asp:TextBox ID="txtFrom" runat="server"></asp:TextBox><asp:Image  ID="Image1"
      runat="server" ImageUrl="./Images/Cal.gif" onclick="ShowDatePicker(this,'E','txtFrom','txtFrom');" />
    </td>    
    <td style="height: 24px">To:</td>    
    <td style="height: 24px"><asp:TextBox ID="txtTo"  runat="server"></asp:TextBox><asp:Image ID="Image2"
      runat="server" ImageUrl="./Images/Cal.gif" onclick="ShowDatePicker(this,'E','txtTo','txtTo');" /></td>
    <td style="height: 24px">
        <asp:Button CssClass="btns"  ID="Button1" runat="server" Text="Go" OnClick="btnGo_Click" /></td>
</tr>
<tr class="pagetitle"  runat="server" visible="true" id="trLabel" ><td colspan="5">Current Month Exceptions</td></tr> 
<tr><td colspan="5">
<asp:GridView ID="GridLog"  Width="100%" runat="server" CssClass="homTbl" 
        BackColor="#FFCC66" BorderColor="#FFCC66" BorderWidth="1px"  
        AutoGenerateColumns="False" AllowPaging="True" 
        OnPageIndexChanged="GridLog_PageIndexChanged" 
        OnPageIndexChanging="GridLog_PageIndexChanging" OnInit="GridLog_Init" 
        Height="30px">
        <Columns>
        
        <asp:TemplateField HeaderText="Sno.">
            <ItemTemplate>
            
           <%-- <a href="javascript:void(0)" onclick="window.open('UpdateStatus.aspx?Serial_No=<%# Eval("Serial_No") %>','','status=no,left=200,top=50,scrollbars=yes,width=750,height=500,toolbar=no,resizable=no,directories=0');" >--%>
                
                <asp:Label ID="lbl_errorid" runat="server" Text='<%# Eval("Serial_No") %>'></asp:Label>
            <%-- </a> --%>
             
             
                      </ItemTemplate>
        </asp:TemplateField>
           
       
              
           
            <asp:BoundField DataField="Error_Type" HeaderText="Exception" >
                <ItemStyle Wrap="True"  />
            </asp:BoundField>
            <asp:BoundField DataField="Error_Description" HeaderText="Description" >
                <ItemStyle Wrap="True"  />
            </asp:BoundField>
            <asp:BoundField DataField="Error_Source" HeaderText="Error Source" >
                <ItemStyle Wrap="True" />
            </asp:BoundField>
            <asp:BoundField DataField="Error_Caused_By_Method" HeaderText="Error Method" >
                <ItemStyle Wrap="True" />
            </asp:BoundField>
            <asp:BoundField DataField="File_Path" HeaderText="File path" >
                <ItemStyle Wrap="True"   />
            </asp:BoundField>
            <%-- <asp:BoundField DataField="Status" HeaderText="Status" >
                <ItemStyle Wrap="True" Width="10px" />
            </asp:BoundField>--%>
            <asp:BoundField HtmlEncode="False"  DataField="Error_DateTime" HeaderText="Error Date" DataFormatString="{0:dd/MM/yyyy}" >
                <ItemStyle Wrap="True" Width="10px" />
            </asp:BoundField>
            
        </Columns>
        <RowStyle BorderWidth="1px" CssClass="alternate" BackColor="LightYellow" Font-Names="Verdana" Font-Size="8pt" />
        <EditRowStyle BorderStyle="Dashed" />
    <HeaderStyle Font-Names="Verdana" Font-Size="8pt" />
    <AlternatingRowStyle BackColor="LightCyan" Font-Names="Verdana" Font-Size="8pt" />
    </asp:GridView>
</td></tr>
<tr>
   <td colspan="5"><asp:label id="lblNoRec" CssClass="pagetitle" Visible="False" Text="No Record Found." Runat="server" Font-Bold="True"
								ForeColor="Red"></asp:label></td></tr>
</table>
    </div>
    </form>
</body>
</html>
