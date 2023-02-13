<%@ Page Title="Strona główna" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="WebColiber._Default" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="HeaderContent"> Web Coliber </asp:Content>
<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="MainContent">
    <h2>Witamy w systemie WebColiber</h2>
	<p>Podczas próby uruchomienia systemu wystąpiły błędy - oznacza to, że system nie 
		jest skonfigurowany, albo jest skonfigurowany nieprawidłowo.</p>
	<p>
		Aby dokonać konfiguracji, należy zalogować się do panelu 
			administracyjnego.</p>
	<p>System WebColiber posiada wbudowane, predefiniowane konto administracyjne: <em>admin</em>. 
		Domyślnym hasłem jest: <em>admin</em> - należy *BEZWZGLĘDNIE* zmienić to hasło 
		przy pierwszym uruchomieniu panelu.</p>
</asp:Content>
