<%@ page language="C#" autoeventwireup="true" masterpagefile="~/Master/MasterPage2.master" validaterequest="false" inherits="Counter_layout_sumo"  CodeFile="~/layout_sumo.aspx.cs" Title="BuyMyETicket :: Sumo Layout"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script type="text/javascript" language="javascript" src="JS/JssSumo.js">
    </script>

    <link href="style.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            font-size: 12px;
            font-family: "Verdana Arial Sans-Serif";
            color: Purple;
            font-weight: bold;
            width: 17%;
            text-align: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript">
         
            function rs()
             {
                var seats = document.getElementById('<%=SeatTxt.ClientID %>').value;
                if (seats.length == 0)
                {
                alert("OOPS!!! Seems like you have not selected any seat,please select atleast one seat");
                return false;
            }
            return true;
  }
 
    </script>

    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
    <div id="Div1" style="width: 100%; background-color: White; display: block;">
        <table cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td align="right">
                 
                    <a href="javascript:history.back()"><b>
                        <h3 align="right">
                            Back</h3>
                    </b></a>
                </td>
            </tr>
        </table>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table cellpadding="2" cellspacing="2"  width="100%" class="traveldetails">
                    <tr>
                        <td colspan="4" style="width: 100%" class="traveldetailbar">
                            <span class="text">TRAVELLING DETAILS</span>
                        </td>
                    </tr>
                    <tr>
                        <td class="text" style="width: 25%">
                            Source:
                        </td>
                        <td class="text" style="width: 25%">
                            <asp:Label ID="lblSource" runat="server" Text="" CssClass="text"></asp:Label>
                        </td>
                        <td class="text" style="width: 25%">
                            Destination:
                        </td>
                        <td class="text" style="width: 25%">
                            <asp:Label ID="lblDestination" runat="server" Text="" CssClass="text"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="text" style="width: 25%">
                            Mode:
                        </td>
                        <td class="text" style="width: 25%">
                            <asp:Label ID="lblMode" runat="server" Text="" CssClass="text"></asp:Label>
                        </td>
                        <td class="text" style="width: 25%">
                            Journey Date &amp; Time:
                        </td>
                        <td class="text" style="width: 25%">
                            <asp:Label ID="lbldate" runat="server" Text="" CssClass="text"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="text" style="width: 25%">
                            Seat no(s):
                        </td>
                        <td class="text" style="width: 25%">
                            <asp:Label ID="lblSeats" runat="server" Text="" CssClass="text" 
                                ForeColor="Red"></asp:Label>
                        </td>
                        <td class="text" style="width: 25%">
                            Total Fare:
                        </td>
                        <td class="text" style="width: 25%">
                            <asp:Label ID="lblTfare" runat="server" Text="" CssClass="text" 
                                ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                </table>
                <br />
                <br />
                <br />
                <table cellpadding="0" cellspacing="0" width="100%" style="height: 371px">
                    <%--copy table row--%>
                    <tr>
                        <td style="width: 250px">
                            <table cellpadding="0" cellspacing="0"  width="250px" style="height: 350px">
                                <tr>
                                    <td style="height: 180px; width: 250px; padding: 12px 0px 0px 0px"
                                        class="vehicle-image" align="center">  <%--border: solid 2px #007cc3--%>
                                        <asp:Image ID="Image1" runat="server" ImageUrl="~/images/sumo.png" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 170px; width: 250px; padding: 25px 5px 0px 5px"
                                        class="vehicle-down-image" valign="top"><%--border: solid 2px #007cc3--%>
                                        <span class="text">You can Click on the vehicle number to see the real image.</span>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td class="sumo-bg" style="width: 463px; padding: 10px 10px 10px 10px; background-color: #f0f8ff" align="left" valign="middle">
                            <div style="width: 100%; float: inherit">
                                <img id="Img5" alt="" src="images/seat-reservation.png" runat="server" />
                                <br />
                                &#9733; Click on a seat to select it. Click again to de-select it.
                            </div>
                            <br />
                            <table cellpadding="5" cellspacing="0" style="width: 250px; height: 155px; padding-left: 5px;float: left; border: solid 2px silver" class="sumo-bg">
                                
                                <tr>
                                    <td rowspan="2">
                                        <img alt="" src="images/steering_wheel.png" />
                                    </td>
                                    <td valign="middle">
                                        <b>6</b><img src="images/purple-seat.png" id="img6" alt="Seat 6" onclick="imgclick1('img6')"
                                            title="Free" />
                                    </td>
                                    <td>
                                        <b>10</b><img src="images/purple-seat.png" id="img10" alt="Seat 10" onclick="imgclick1('img10')"
                                            title="Free" />
                                </tr>
                                <tr>
                                    <td>
                                        <b>5</b><img src="images/purple-seat.png" id="img5" alt="Seat 5" onclick="imgclick1('img5')"
                                            title="Free" />
                                    </td>
                                    <td>
                                        <b>9</b><img src="images/purple-seat.png" id="img9" alt="Seat 9" onclick="imgclick1('img9')"
                                            title="Free" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>2</b><img src="images/purple-seat.png" id="img2" alt="Seat 2" onclick="imgclick1('img2')"
                                            title="Free" />
                                    </td>
                                    <td>
                                        <b>4</b><img src="images/purple-seat.png" id="img4" alt="Seat 4" onclick="imgclick1('img4')"
                                            title="Free" />
                                    </td>
                                    <td>
                                        <b>8</b><img src="images/purple-seat.png" id="img8" alt="Seat 8" onclick="imgclick1('img8')"
                                            title="Free" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>1</b><img src="images/purple-seat.png" id="img1" alt="Seat 1" onclick="imgclick1('img1')"
                                            title="Free" />
                                    </td>
                                    <td>
                                        <b>3</b><img src="images/purple-seat.png" id="img3" alt="Seat 3" onclick="imgclick1('img3')"
                                            title="Free" />
                                    </td>
                                    <td>
                                        <b>7</b><img src="images/purple-seat.png" id="img7" alt="Seat 7" onclick="imgclick1('img7')"
                                            title="Free" />
                                    </td>
                                </tr>
                            </table>
                            <table cellpadding="0" cellspacing="0" style="width: 150px; height: 155px; float: right;
                                border: solid 1px silver" class="sumo-bg">
                                <tr>
                                    <td class="text" valign="middle">
                                        <img id="Img6" alt="" src="images/purple-seat.png" runat="server" />Available Seat
                                    </td>
                                </tr>
                                <tr>
                                    <td class="text" valign="middle">
                                        <img id="Img7" alt="" src="images/green-seat.png" runat="server" />Selected Seat
                                    </td>
                                </tr>
                                <tr>
                                    <td class="text" valign="middle">
                                        <img id="Img8" alt="" src="images/red-seat.png" runat="server" />Reserved Seat
                                    </td>
                                </tr>
                            </table>
                            <table cellpadding="0" cellspacing="0" width="100%" style="float: left">
                                <tr>
                                    <td>
                                        <br />
                                        Seat No(s):
                                        <asp:TextBox ID="SeatTxt" runat="server" CssClass="dd-tb" Width="200" EnableViewState="false"></asp:TextBox>
                                        <br />
                                        <br />
                                        Amount : &nbsp;&nbsp;&nbsp;<asp:TextBox ID="SeatAmt" runat="server" CssClass="dd-tb"
                                            Width="200" EnableViewState="false"></asp:TextBox><br />
                                        <br />
                                        <asp:Button ID="Button11" runat="server" CssClass="text" OnClick="Button11_Click"
                                            Style="position: relative; top: 3px; left: 0px;" Text="Proceed" 
                                            OnClientClick="return rs()" />
                                        <br>
                                        <br />
                                        <br />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td style="width: 250px" class="travellinginfo" valign="top">
                            <table cellpadding="2" cellspacing="2" width="100%">
                                <tr>
                                    <td class="style1">
                                        Counter Name:
                                    </td>
                                    <td class="text" style="width: 25%; text-align: left">
                                        <asp:Label ID="lblCounter" runat="server" Text="" CssClass="text"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style1">
                                        Source:
                                    </td>
                                    <td class="text" style="width: 25%; text-align: left">
                                        <asp:Label ID="lblSrc" runat="server" Text="" CssClass="text"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style1">
                                        Destination:
                                    </td>
                                    <td class="text" style="width: 25%; text-align: left">
                                        <asp:Label ID="lblDes" runat="server" Text="" CssClass="text"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style1">
                                        Vehicle:
                                    </td>
                                    <td class="text" style="width: 25%; text-align: left">
                                        <asp:Label ID="lblVeh" runat="server" Text="" CssClass="text"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style1">
                                        Distance:
                                    </td>
                                    <td class="text" style="width: 25%; text-align: left">
                                        <asp:Label ID="lbldis" runat="server" Text="" CssClass="text"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top" class="style1">
                                        LandMarks:
                                    </td>
                                    <td class="text" style="width: 25%; text-align: left">
                                        <asp:Label ID="lblLM1" runat="server" Text="" CssClass="text"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style1">
                                        Travelling Time:
                                    </td>
                                    <td class="text" style="width: 25%; text-align: left">
                                        <asp:Label ID="lblTT" runat="server" Text="" CssClass="text"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <br />
                <br />
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <input type="hidden" id="hid_tranValue" value="0" runat="server" />
    <input type="hidden" id="hid_session" value="0" runat="server" />
    <input type="hidden" id="hid_seatAmt" value="0" runat="server" />
    <input type="hidden" id="hid_seatnos" value="0" runat="server" />
    <input type="hidden" id="hid_mode" value="0" runat="server" />
</asp:Content>
