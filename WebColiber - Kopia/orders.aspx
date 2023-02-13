<%@ Page Title="<%$ Resources: Language, orders %>" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Orders.aspx.cs" Inherits="WebColiber.Orders" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server"> </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeaderContent" runat="server"> <%= GetGlobalResourceObject("Language", "myOrders")%> </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">    
    <div id="LeftBarDiv1" class="col-md-2"></div>          
    <div id="CenterBarDiv1" class="col-md-8"> 
        <asp:Label ID="ResultsO" runat="server" /><br />
    </div>
    <div id="RightBarDiv1" class="col-md-2"></div>  
    <br /> 
</asp:Content>
