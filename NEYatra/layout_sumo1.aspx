<%@ page language="C#" autoeventwireup="true" masterpagefile="~/Master/MasterPage2.master" validaterequest="false" inherits="Counter_layout_sumo"  CodeFile="~/layout_sumo1.aspx.cs"%>
 
<%--<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
--%>
  
    
    <asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    
        <link rel="Stylesheet" type="text/css" href="css/cvcsStyle.css" />
<link rel="Stylesheet" type="text/css" href="css/StyleSheet.css" />
<link rel="Stylesheet" type="text/css" href="css/style.css" />

      <asp:ScriptManager ID="ScriptManager1" runat="server">
      </asp:ScriptManager>
      
      <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
  
  
  <Triggers>
    <asp:PostBackTrigger ControlID = "Button11" />
      </Triggers> 
  
       <ContentTemplate>
        <div id="Div1" style="width: auto;  height:400; background-color: White; display: block;">   
            <br>
            <br>
            <br>
            <br>
          
            <br>
            <br>
            <br>
            <br>
            <br>
            <br>
            <br></br>
            <table border="1" class="style1" width="50%">
                <tr>
                    <td class="style4" rowspan="2">
                        <img src="images/steering_wheel.JPG" />
                    </td>
                    <td class="style5">
                        <asp:Button ID="Button3" runat="server" BackColor="Aqua" BorderStyle="Dashed" 
                            Font-Bold="True" Font-Size="Large" Height="29px" onclick="Button3_Click" 
                            Text="3" Width="26px" />
                    </td>
                    <td class="style6">
                        <asp:Button ID="Button7" runat="server" BackColor="Aqua" BorderStyle="Dashed" 
                            Font-Bold="True" Font-Size="Large" Height="29px" onclick="Button7_Click" 
                            Text="7" Width="26px" />
                    </td>
                </tr>
                <tr>
                    <td class="style3">
                        <asp:Button ID="Button4" runat="server" BackColor="Aqua" BorderStyle="Dashed" 
                            Font-Bold="True" Font-Size="Large" Height="29px" onclick="Button4_Click" 
                            Text="4" Width="26px" />
                    </td>
                    <td>
                        <asp:Button ID="Button8" runat="server" BackColor="Aqua" BorderStyle="Dashed" 
                            Font-Bold="True" Font-Size="Large" Height="29px" onclick="Button8_Click" 
                            Text="8" Width="26px" />
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                        <asp:Button ID="Button1" runat="server" BackColor="Aqua" BorderStyle="Dashed" 
                            Font-Bold="True" Font-Size="Large" Height="29px" onclick="Button1_Click" 
                            Text="1" UseSubmitBehavior="False" Width="26px" />
                    </td>
                    <td class="style3">
                        <asp:Button ID="Button5" runat="server" BackColor="Aqua" BorderStyle="Dashed" 
                            Font-Bold="True" Font-Size="Large" Height="29px" onclick="Button5_Click" 
                            Text="5" Width="26px" />
                    </td>
                    <td>
                        <asp:Button ID="Button9" runat="server" BackColor="Aqua" BorderStyle="Dashed" 
                            Font-Bold="True" Font-Size="Large" Height="29px" onclick="Button9_Click" 
                            Text="9" Width="26px" />
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                        <asp:Button ID="Button2" runat="server" BackColor="Aqua" BorderStyle="Dashed" 
                            Font-Bold="True" Font-Size="Large" Height="29px" onclick="Button2_Click" 
                            Text="2" Width="26px" />
                    </td>
                    <td class="style3">
                        <asp:Button ID="Button6" runat="server" BackColor="Aqua" BorderStyle="Dashed" 
                            Font-Bold="True" Font-Size="Large" Height="29px" onclick="Button6_Click" 
                            Text="6" Width="26px" />
                    </td>
                    <td>
                        <asp:Button ID="Button10" runat="server" BackColor="Aqua" BorderStyle="Dashed" 
                            Font-Bold="True" Font-Size="Medium" Height="29px" onclick="Button10_Click" 
                            Text="10" Width="26px" />
                    </td>
                </tr>
            </table>
            Seat No(s):
            <asp:TextBox ID="SeatTxt" runat="server"></asp:TextBox>
            <br />
            Amount : &nbsp;&nbsp;<asp:TextBox ID="SeatAmt" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="Button11" runat="server" CssClass="btn" 
                onclick="Button11_Click" style="position: relative" Text="Proceed" />
            <br>
            <br>
            <br>
            <br></br>
            <br></br>
            <br></br>
            <br></br>
            <br></br>
            <br></br>
            <br></br>
            <br></br>
            </br>
            </br>
            </br>
            </br>
            </br>
            </br>
            </br>
            </br>
            </br>
                            </div>
     </ContentTemplate>
 
 </asp:UpdatePanel>
 <div><br /><br />
 <a href="javascript:history.back()"><b><h2>Back</h2></b></a>
 </div>
 </asp:Content>
