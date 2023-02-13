<%@ Page Title="<%$ Resources: Language, orderConfirm %>" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OrderSent.aspx.cs" Inherits="WebColiber.OrderSent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeaderContent" runat="server">
    <%= GetGlobalResourceObject("Language", "orderConfirm")%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <div id="LeftBarDiv" class="col-md-2"></div>
    <div id="ResultArea" class="col-md-8">
        <asp:Label ID="Results" runat="server" />
    </div>
    <div id="RightBarDiv" class="col-md-2"></div>

</asp:Content>
