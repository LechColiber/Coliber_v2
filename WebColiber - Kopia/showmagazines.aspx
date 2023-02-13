<%@ Page Title="<%$ Resources: Language, search %>" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShowMagazines.aspx.cs" Inherits="WebColiber.ShowMagazines" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server"> 
    <script type="text/javascript" language="javascript">

    $(document).ready(function () {
        $('#btnOrderTop').click(function (event) {
            Order();
            return false;
        });

        $('#btnOrder').click(function (event) {                
            Order();
            return false;
        });
    });

    btnEnabled = false;
    var checkBoxes2 = new Array();
    var checkBoxes = new Array();

    if (document.cookie != "") {
        var toCookie = document.cookie.split("; ");

        for (var i = 0; i < toCookie.length; i++) {
            if (toCookie[i].substr(0, 5) == "order") {
                var orderCookieArray = toCookie[i].split("=");

                orderCookieArray = orderCookieArray[1].split(",");

                for (var j = 0; j < orderCookieArray.length; j++) {
                    if (orderCookieArray[j] == "" || orderCookieArray[j] == " ")
                        continue;

                    checkBoxes[checkBoxes.length] = orderCookieArray[j];
                }
            }
        }
    }

    var waznosc = new Date();
    waznosc.setTime(waznosc.getTime() - (1000 * 60 * 20));
    document.cookie = "order =" + "; expires=" + waznosc.toGMTString();

    function check(checkB) {
        var Occured = new Boolean();
        Occured = false;

        if (checkB.checked == true) {
            btnEnabled = true;

            for (var j = 0; j < checkBoxes.length; j++) {
                //if (checkB.id.replace("MainContent_Result", "").replace("_chkOrder", "") == checkBoxes[j])
                //Occured = true;

                if (checkB.id.replace("Checkbox", "") == checkBoxes[j])
                    Occured = true;
            }

            if (Occured == false) {
                //btnEnabled = true;
                //checkBoxes[checkBoxes.length] = checkB.id.replace("MainContent_Result", "").replace("_chkOrder", "");
                checkBoxes[checkBoxes.length] = checkB.id.replace("Checkbox", "");
            }
        }
        else {
            for (var j = 0; j < checkBoxes.length; j++) {
                //if (checkB.id.replace("MainContent_Result", "").replace("_chkOrder", "") == checkBoxes[j]) {
                if (checkB.id.replace("Checkbox", "") == checkBoxes[j]) {
                    checkBoxes.splice(j, 1);
                }
            }
        }

        makeCookie();
    }

    function makeCookie() {
        var temp = "";
        for (var i = 0; i < checkBoxes.length; i++) {
            if (checkBoxes[i] == "")
                continue;

            if (i < checkBoxes.length - 1)
                temp += checkBoxes[i] + ",";
            else
                temp += checkBoxes[i];
        }

        var waznosc = new Date();
        waznosc.setTime(waznosc.getTime() + (1000 * 60 * 20));
        document.cookie = "order =" + temp + "; expires=" + waznosc.toGMTString(); //.getMinutes() + 20;
    }

    function lookCheckboxes(checkB) {
        check(checkB);

        CanOrder();
    }

    function CanOrder() {
        var btn = document.getElementById("btnOrderTop");
        if (btn == null) return;

        var btnTop = document.getElementById("btnOrder");
        if (btnTop == null) return;
        //alert("!"+checkBoxes+"!");

        if (checkBoxes.length > 0 && checkBoxes != " " && checkBoxes != "")
            btnEnabled = true;
        else
            btnEnabled = false;

        btn.disabled = !btnEnabled;
        btnTop.disabled = !btnEnabled;
    }

    function checkChecked() {
        for (var i = 0; i < checkBoxes.length; i++) {
            var checkbox = document.getElementById("Checkbox" + checkBoxes[i]);
            //var checkbox = $("#CheckBox" + checkBoxes[i]);             
            if (checkbox != null)
                checkbox.checked = true;
        }
    }

    function Order() {
        var s = "{";

        for (var i = 0; i < checkBoxes.length - 1; i++) {
            if (checkBoxes[i].trim() == "")
                continue;

            s += checkBoxes[i] + ",";
        }

        s += checkBoxes[checkBoxes.length - 1] + "}";
        //alert(s);
        self.location = "AddToBasket.aspx?ordersMag=" + s;
        //window.navigate("AddToBasket.aspx?orders=" + s);
    }

</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeaderContent" runat="server"> <%= GetGlobalResourceObject("Language", "numbers")%>
 </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    
    <asp:Panel ID="panelSearchResults" runat="server" Visible="true">
    <div id="LeftBarDiv1" class="col-md-2"></div>          
    <div id="CenterBarDiv1" class="col-md-8">       
        <% if (((string)HttpContext.Current.Session["CanOrder"]).ToLower() == "true")
            { %>   
            <input id="btnOrderTop" type="button" value="<%= GetGlobalResourceObject("Language", "addToBasket")%>" />
        <%  } %>
        <asp:Label ID="ResultsO" runat="server" /><br />  
              
        <% if (((string)HttpContext.Current.Session["CanOrder"]).ToLower() == "true")
            { %> 
        <input id="btnOrder" type="button" value="<%= GetGlobalResourceObject("Language", "addToBasket")%>" />
        <%  } %>
         
    </div>
    <div id="RightBarDiv1" class="col-md-2"></div> 
    </asp:Panel>
    
    <script language="javascript" type="text/javascript">        CanOrder(); checkChecked(); makeCookie(); /*lookcheckBoxesMag("");*/ </script>
</asp:Content>
