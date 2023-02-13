<%@ Page Title="<%$ Resources: Language, borrows %>" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Borrows.aspx.cs" Inherits="WebColiber.Borrows" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server"> </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeaderContent" runat="server"> <%= GetGlobalResourceObject("Language", "myBorrows") %> </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

<div class="row">
    <div id="LeftBarDiv1" class="col-md-1"></div>          

    <div id="CenterBarDiv1" class="col-md-10"> 
        <asp:Label ID="ResultsNR" runat="server" /><br />
        <asp:CheckBox ID="chkShowR" runat="server" Text = "<%$ Resources: Language, showReturned %>" AutoPostBack="True" /><br />
        <asp:Label ID="ResultsR" runat="server" />
    </div>
    <div id="RightBarDiv1" class="col-md-1"></div> 
</div>

    <br /> 
</asp:Content>
