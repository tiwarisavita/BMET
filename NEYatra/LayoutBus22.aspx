<%@ Page Language="C#" MasterPageFile="~/Master/MasterPage2.master" AutoEventWireup="true" CodeFile="LayoutBus22.aspx.cs" Inherits="LayoutBus22" Title="BuyMyETicket :: 2*2 Bus Layout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script type="text/javascript" language="javascript" src="JS/JssBus.js">

    </script>

    <link href="style.css" rel="stylesheet" type="text/css" />
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
    <div id="Div1" style="width: 100%; height: 1000px; background-color: White; display: block;">
        <table cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td align="right">
                    <a href="javascript:history.back()"><b>
                        <h2 align="right">
                            Back</h2>
                    </b></a>
                </td>
            </tr>
        </table>
        <asp:UpdatePanel ID="updl" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table cellpadding="3" cellspacing="3" width="100%" class="traveldetails">
                    <tr>
                        <td colspan="4" style="width: 100%" class="traveldetailbar">
                            <span class="text">TRAVELLING DETAILS</span>
                        </td>
                    </tr>
                    <tr>
                        <td class="text" style="width: 20%">
                            Source:
                        </td>
                        <td class="text" style="width: 30%">
                            <asp:Label ID="lblSource" runat="server" Text="" CssClass="text"></asp:Label>
                        </td>
                        <td class="text" style="width: 20%">
                            Destination:
                        </td>
                        <td class="text" style="width: 30%">
                            <asp:Label ID="lblDestination" runat="server" Text="" CssClass="text"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="text" style="width: 20%">
                            Mode:
                        </td>
                        <td class="text" style="width: 30%">
                            <asp:Label ID="lblMode" runat="server" Text="" CssClass="text"></asp:Label>
                        </td>
                        <td class="text" style="width: 20%">
                            Journey Date &amp; Time:
                        </td>
                        <td class="text" style="width: 30%">
                            <asp:Label ID="lbldate" runat="server" Text="" CssClass="text"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="text" style="width: 20%">
                            Distance:
                        </td>
                        <td class="text" style="width: 30%">
                            <asp:Label ID="lblDistance" runat="server" Text="" CssClass="text"></asp:Label>
                        </td>
                        <td valign="top" class="text" style="width: 20%">
                            Counter:&nbsp;&nbsp;
                        </td>
                        <td class="text" style="width: 30%">
                           <%--<asp:Label ID="lblLandmarks" runat="server" Text="" CssClass="text"></asp:Label>--%>
                           <asp:Label ID="lblCounter" runat="server" Text="" CssClass="text"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="text" style="width: 20%">
                            LandMarks:
                        </td>
                        <td class="text" style="width: 30%">
                            <asp:Label ID="lblBPoints" runat="server" Text="" CssClass="text"></asp:Label>
                        </td>
                        <td class="text" style="width: 20%">
                            Travelling Time:
                        </td>
                        <td class="text" style="width: 30%">
                            <asp:Label ID="lblTravelTime" runat="server" Text="" CssClass="text"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="text" style="width: 20%">
                           Seat no(s):
                        </td>
                        <td class="text" style="width: 30%">
                            <asp:Label ID="lblSeats" runat="server" Text="" CssClass="text" 
                                ForeColor="Red"></asp:Label>
                        </td>
                        <td class="text" style="width: 20%">
                            Total Fare:
                        </td>
                        <td class="text" style="width: 30%">
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
                        <td colspan="2" class="bus-bg" style="width: 463px; padding: 10px 70px 10px 70px;"
                            align="center" valign="middle">
                            <%--border: solid 2px #007cc3;background-color: #f0f8ff--%>
                            <div style="width: 100%;">
                                <img id="Img5" alt="" src="images/seat-reservation.png" runat="server" />
                                <br />
                                &#9733; Click on a seat to select it. Click again to de-select it.
                            </div>
                            <br />
                            <table cellpadding="5" cellspacing="0" style="float: left; border: solid 2px silver">
                                <tr>
                                    <td>
                                        <asp:Image ID="Image2" runat="server" ImageUrl="~/images/steering_wheel.png" />
                                    </td>
                                    <td>
                                        <b>2</b><img src="images/purple-seat.png" id="img2" alt="Seat 2" onclick="imgclick1('img2')"
                                            title="Free" />
                                    </td>
                                    <td>
                                        <b>6</b><img src="images/purple-seat.png" id="img6" alt="Seat 6" onclick="imgclick1('img6')"
                                            title="Free" />
                                    </td>
                                    <td>
                                        <b>10</b><img src="images/purple-seat.png" id="img10" alt="Seat 10" onclick="imgclick1('img10')"
                                            title="Free" />
                                    </td>
                                    <td>
                                        <b>14</b><img src="images/purple-seat.png" id="img14" alt="Seat 14" onclick="imgclick1('img14')"
                                            title="Free" />
                                    </td>
                                    <td>
                                        <b>18</b><img src="images/purple-seat.png" id="img18" alt="Seat 18" onclick="imgclick1('img18')"
                                            title="Free" />
                                    </td>
                                    <td>
                                        <b>22</b><img src="images/purple-seat.png" id="img22" alt="Seat 22" onclick="imgclick1('img22')"
                                            title="Free" />
                                    </td>
                                    <td>
                                        <b>26</b><img src="images/purple-seat.png" id="img26" alt="Seat 26" onclick="imgclick1('img26')"
                                            title="Free" />
                                    </td>
                                    <td>
                                        <b>30</b><img src="images/purple-seat.png" id="img30" alt="Seat 30" onclick="imgclick1('img30')"
                                            title="Free" />
                                    </td>
                                    <td>
                                        <b>34</b><img src="images/purple-seat.png" id="img34" alt="Seat 34" onclick="imgclick1('img34')"
                                            title="Free" />
                                    </td>
                                    <td>
                                        <b>39</b><img src="images/purple-seat.png" id="img39" alt="Seat 39" onclick="imgclick1('img39')"
                                            title="Free" />
                                    </td>
                                    
                                </tr>
                                <tr>
                                    <td rowspan="3">
                                        CABIN
                                    </td>
                                    <td>
                                        <b>1</b><img src="images/purple-seat.png" id="img1" alt="Seat 1" onclick="imgclick1('img1')"
                                            title="Free" />
                                    </td>
                                    <td>
                                        <b>5</b><img src="images/purple-seat.png" id="img5" alt="Seat 5" onclick="imgclick1('img5')"
                                            title="Free" />
                                    </td>
                                    <td>
                                        <b>9</b><img src="images/purple-seat.png" id="img9" alt="Seat 9" onclick="imgclick1('img9')"
                                            title="Free" />
                                    </td>
                                    <td>
                                        <b>13</b><img src="images/purple-seat.png" id="img13" alt="Seat 13" onclick="imgclick1('img13')"
                                            title="Free" />
                                    </td>
                                    
                                    <td>
                                        <b>17</b><img src="images/purple-seat.png" id="img17" alt="Seat 17" onclick="imgclick1('img17')"
                                            title="Free" />
                                    </td>
                                    <td>
                                        <b>21</b><img src="images/purple-seat.png" id="img21" alt="Seat 21" onclick="imgclick1('img21')"
                                            title="Free" />
                                    </td>
                                    <td>
                                        <b>25</b><img src="images/purple-seat.png" id="img25" alt="Seat 25" onclick="imgclick1('img25')"
                                            title="Free" />
                                    </td>
                                    <td>
                                       <b>29</b><img src="images/purple-seat.png" id="img29" alt="Seat 29" onclick="imgclick1('img29')"
                                            title="Free" />
                                      
                                    </td>
                                    <td>
                                     <b>33</b><img src="images/purple-seat.png" id="img33" alt="Seat 33" onclick="imgclick1('img33')"
                                            title="Free" />
                                        
                                    </td>
                                    <td>
                                        <b>38</b><img src="images/purple-seat.png" id="img38" alt="Seat 38" onclick="imgclick1('img38')"
                                            title="Free" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                  
                                    <td>
                                         <b>37</b><img src="images/purple-seat.png" id="img37" alt="Seat 37" onclick="imgclick1('img37')"
                                            title="Free" />
                                    </td>
                                </tr>
                                <tr>
                                    <td rowspan="2">
                                    <b>40</b><img src="images/purple-seat.png" id="img40" alt="Seat 40" onclick="imgclick1('img40')"
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
                                    <td>
                                    <b>12</b><img src="images/purple-seat.png" id="img12" alt="Seat 12" onclick="imgclick1('img12')"
                                            title="Free" />
                                    </td>
                                    <td>
                                    <b>16</b><img src="images/purple-seat.png" id="img16" alt="Seat 16" onclick="imgclick1('img16')"
                                            title="Free" />
                                    </td>
                                    <td>
                                    <b>20</b><img src="images/purple-seat.png" id="img20" alt="Seat 20" onclick="imgclick1('img20')"
                                            title="Free" />
                                    </td>
                                    <td>
                                    <b>24</b><img src="images/purple-seat.png" id="img24" alt="Seat 24" onclick="imgclick1('img24')"
                                            title="Free" />
                                    </td>
                                    
                                    
                                    <td>
                                    <b>28</b><img src="images/purple-seat.png" id="img28" alt="Seat 28" onclick="imgclick1('img28')"
                                            title="Free" />
                                    </td>
                                    <td>
                                    <b>32</b><img src="images/purple-seat.png" id="img32" alt="Seat 32" onclick="imgclick1('img32')"
                                            title="Free" />
                                    </td>
                                    <td>
                                        <b>36</b><img src="images/purple-seat.png" id="img36" alt="Seat 36" onclick="imgclick1('img36')"
                                            title="Free" />
                                    </td>
                                </tr>
                               
                                <tr>
                                    <td>
                                        DOOR
                                    </td>
                                    <td>
                                        <b>3</b><img src="images/purple-seat.png" id="img3" alt="Seat 3" onclick="imgclick1('img3')"
                                            title="Free" />
                                    </td>
                                    <td>
                                     <b>7</b><img src="images/purple-seat.png" id="img7" alt="Seat 7" onclick="imgclick1('img7')"
                                            title="Free" />
                                        
                                    </td>
                                    <td>
                                       <b>11</b><img src="images/purple-seat.png" id="img11" alt="Seat 11" onclick="imgclick1('img11')"
                                            title="Free" />
                                    </td>
                                    <td>
                                        <b>15</b><img src="images/purple-seat.png" id="img15" alt="Seat 15" onclick="imgclick1('img15')"
                                            title="Free" />
                                    </td>
                                    <td>
                                        <b>19</b><img src="images/purple-seat.png" id="img19" alt="Seat 19" onclick="imgclick1('img19')"
                                            title="Free" />
                                    </td>
                                    
                                    
                                    <td>
                                        <b>23</b><img src="images/purple-seat.png" id="img23" alt="Seat 23" onclick="imgclick1('img23')"
                                            title="Free" />
                                    </td>
                                    <td>
                                        <b>27</b><img src="images/purple-seat.png" id="img27" alt="Seat 27" onclick="imgclick1('img27')"
                                            title="Free" />
                                    </td>
                                    <td>
                                    <b>31</b><img src="images/purple-seat.png" id="img31" alt="Seat 31" onclick="imgclick1('img31')"
                                            title="Free" />
                                      
                                    </td>
                                    <td>
                                         <b>35</b><img src="images/purple-seat.png" id="img35" alt="Seat 35" onclick="imgclick1('img35')"
                                            title="Free" /> 
                                    </td>
                                </tr>
                            </table>
                            <table cellpadding="0" cellspacing="0" style="width: 150px; height: 155px; float: right;
                                border: solid 1px silver">
                                <%--class="sumo-bg"--%>
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
                            <br />
                            <br />
                            <table cellpadding="5" cellspacing="5" width="100%" style="float: left">
                                <tr>
                                    <td>
                                        Seat No(s):
                                    </td>
                                    <td>
                                        <asp:TextBox ID="SeatTxt" runat="server" CssClass="dd-tb" Text="" Width="300"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Amount : &nbsp;&nbsp;&nbsp;
                                    </td>
                                    <td>
                                        <asp:TextBox ID="SeatAmt" runat="server" CssClass="dd-tb" Width="300"></asp:TextBox>
                                  
                                     
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <br />
                                        <asp:Button ID="Button11" runat="server" CssClass="text" Style="top: 178px; left: -90px;"
                                            Text="Proceed" OnClick="Button11_Click" OnClientClick="return rs();" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <input type="hidden" id="hid_button1" value="0" />
    <input type="hidden" id="hid_seatnos" value="0" runat="server" />
    <input type="hidden" id="hid_seatAmt" value="0" runat="server" />
    <input type="hidden" id="hid_tranValue" value="0" runat="server" />
    <input type="hidden" id="hid_session" value="0" runat="server" />
    <input type="hidden" id="hid_mode" value="0" runat="server" />
</asp:Content>


