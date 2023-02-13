<%@ Page Title="<%$ Resources: Language, basket %>" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Basket.aspx.cs" Inherits="WebColiber.Basket" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server"> 
    <script type="text/javascript" language="javascript">

    var waznosc = new Date();
    waznosc.setTime(waznosc.getTime() - (1000 * 60 * 20));
    document.cookie = "order =" + "; expires=" + waznosc.toGMTString();

    var checkBoxes = new Array();

    function check_all_in_document(doc) {
        var c = new Array();
        c = doc.getElementsByTagName('input');
        for (var i = 0; i < c.length; i++) {
            if (c[i].type == 'checkbox') {
                if (c[i].checked) {
                    checkBoxes[checkBoxes.length] = c[i].id.replace("Checkbox", "");                    
                }
            }
        }
    }


    function lookCheckboxes() {
        btnEnabled = false;
        checkBoxes = new Array()

        check_all_in_document(window.document);
        for (var j = 0; j < window.frames.length; j++) {
            check_all_in_document(window.frames[j].document);
        }
    }

    function Delete() {
        var s = "{";

        for (var i = 0; i < checkBoxes.length - 1; i++) {
            s += checkBoxes[i] + ",";
        }
        s += checkBoxes[checkBoxes.length - 1] + "}";        
        self.location = "DeleteFromBasket.aspx?orders=" + s;        
    }

   function Normy() {
        var s = "{";

        for (var i = 0; i < checkBoxes.length - 1; i++) {
            s += checkBoxes[i] + ",";
        }
       s += checkBoxes[checkBoxes.length - 1] + "}"; 
       self.location = "Order.aspx?orders=" + s;        
    }

</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeaderContent" runat="server"> <%= GetGlobalResourceObject("Language", "basket")%> </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <!--<asp:Panel ID="panelContent" runat="server">-->
        <!--<table><asp:Panel ID="panelResults" runat="server" /></table>-->
        <div id="LeftBarDiv1" class="col-md-2"></div>          
        <div id="CenterBarDiv1" class="col-md-8"> 
            <asp:Label ID="ResultsO" runat="server" /><br />  
            <asp:Button ID="btnDelete" runat="server" Text="<%$ Resources: Language, deleteChecked %>" />
            <asp:Button ID="btnOrder" runat="server" Text="<%$ Resources: Language, order %>" onclick="btnOrder_Click" />
            <asp:Button ID="btnNormy" runat="server" Text="Zamów" />
            <asp:Label ID="lblComment" runat="server" Visible="true" />
        </div>
        <div id="RightBarDiv1" class="col-md-2"></div>
    <!--</asp:Panel>    -->
</asp:Content>
