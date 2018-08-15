<%@ Page Language="C#" MasterPageFile="~/Master/MasterPage2.master" AutoEventWireup="true" CodeFile="FranchiseeList.aspx.cs" Inherits="FranchiseeList" Title="BuyMyETicket.com :: Our Franchisees" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        #divProducts {
            font-family: Arial, Verdana, Sans-Serif;
            font-size: 12px;
        }

        .item {
            padding: 10px;
            background-color: Menu;
            box-shadow: 10px 10px 5px #888888;
            width: 200px;
            height: 150px;
            margin: 6px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
 <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
    <table>
        <tr>
            <td>Select City : </td>
            <td>
                <asp:DropDownList ID="ddlFranCity" runat="server" CssClass="dd" Width="180px" AutoPostBack="true" EnableViewState="true" OnSelectedIndexChanged="ddlFranCity_SelectedIndexChanged"></asp:DropDownList></td>
        </tr>
    </table>
    <br />
    <br />
    <hr />
    <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div id="divProducts">
                <asp:DataList ID="RepSample" RepeatColumns="4" RepeatDirection="Horizontal" runat="server"
                    HorizontalAlign="Center">
                    <ItemTemplate>
                        <div class="item">
                            <%#Eval("FranName")%>
                            <br />
                            <%#Eval("FranAdd")%>
                            <br />
                            <img src="images/ph1.jpg" width="15" height="15" alt="Phone" /><%#Eval("FranPhone")%>
                            ,&nbsp;<%#Eval("FranMob")%>
                            <br />
                            Email-ID: &nbsp;<%#Eval("FranEmail")%>
                        </div>
                    </ItemTemplate>
                </asp:DataList>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

