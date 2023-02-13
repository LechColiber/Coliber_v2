<%@ Page Title="<%$ Resources: Language, order %>" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Order.aspx.cs" Inherits="WebColiber.Order" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeaderContent" runat="server"><%= GetGlobalResourceObject("Language", "sendOrder")%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div id="LeftBarDiv1" class="col-md-2"></div>          
    <div id="CenterBarDiv1" class="col-md-8">
        <asp:Table ID="Table2" runat="server" Width="600px">        
            <asp:TableRow id="TableRow1" runat="server">
                <asp:TableCell id="TableCell3" runat="server">
                    <%= GetGlobalResourceObject("Language", "whoOrders")%>
                </asp:TableCell>
                <asp:TableCell id="TableCell4" runat="server">
                    <asp:TextBox ID="txtOrder" runat="server" Width="400px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell id="TableCell1" runat="server">
                    <asp:RequiredFieldValidator ID="fieldValidator" runat="server" ErrorMessage="Pole wymagane" ControlToValidate="txtOrder" />
                </asp:TableCell></asp:TableRow></asp:Table><%= GetGlobalResourceObject("Language", "additionalOrderInfo")%> <br />
   
        <asp:TextBox ID="txtDescription" runat="server" Width="505px" Height="161px" TextMode="MultiLine"></asp:TextBox><br /><br />
        <asp:Button ID="btnSendOrder" runat="server" Text="<%$ Resources: Language, sendOrder %>" onclick="btnSendOrder_Click" />

    </div>
    <div id="RightBarDiv1" class="col-md-2"></div> 
</asp:Content>