<%@ Page Title="Test" Language="C#" AutoEventWireup="true"  %>
<%
    string cText;
    cText = HttpContext.Current.Session["CanOrder"].ToString() + " $ " + HttpContext.Current.Session["UserID"].ToString();
    lbHello.Text = lbHello.Text + " $ " + cText;
%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Test Page</title>
</head>
<body>
    <form id="TestForm" runat="server">
    <div>
    <asp:Label runat="server" id="lbHello">Hello world</asp:Label>
    </div>
    </form>
</body>
</html>