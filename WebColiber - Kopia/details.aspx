<%@ Page Title="<%$ Resources: Language, details%>" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="WebColiber.Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeaderContent" runat="server"><%= GetGlobalResourceObject("Language", "itemDescription")%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
<asp:Label ID="lblContent" runat="server" />
    <br />
    <asp:Button ID="AddToBasketButton" runat="server" onclick="AddToBasketButton_Click" 
        Text="<%$ Resources: Language, addToBasket %>" />
    <script language="javascript" type="text/javascript">
        window.onload = function () {
            $('#MenuDiv1').hide();
        };   </script>
</asp:Content>


