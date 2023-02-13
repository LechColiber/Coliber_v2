<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Result.ascx.cs" Inherits="WebColiber.Result" %>
<tr>   
    <td><asp:Label ID="lblIndex" runat="server" /></td>
    <td><asp:Label ID="lblAvailableCopies" runat="server" align="center"  Width="80px" Visible="true"/></td>
    <td><asp:CheckBox ID="chkOrder" onClick="lookCheckboxes(this);" runat="server"/></td>     
    <td>
        <asp:Label ID="lblTitle" runat="server" />
    </td>         
</tr>
