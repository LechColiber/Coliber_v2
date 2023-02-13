<%@ Page Title="<%$ Resources: Language, search %>" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="WebColiber.Search" EnableEventValidation="false" %>
<%@ Register TagPrefix="uc" TagName="SearchBox" Src="UserControls/SearchBox.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server"> 
    <script type="text/javascript" language="javascript">                    
    btnEnabled = false;
    var checkBoxes2 = new Array();
    var checkBoxes = new Array();    

    if (document.cookie != "")
    {
        var toCookie = document.cookie.split("; ");

        for (var i = 0; i < toCookie.length; i++) 
        {
            if (toCookie[i].substr(0, 5) == "order") 
            {
                var orderCookieArray = toCookie[i].split("=");

                orderCookieArray = orderCookieArray[1].split(",");

                for (var j = 0; j < orderCookieArray.length; j++) 
                {
                    if (orderCookieArray[j] == "" || orderCookieArray[j] == " ")
                        continue;

                    checkBoxes[checkBoxes.length] = orderCookieArray[j];
                }
            }
        }
    }

    var waznosc = new Date();
    waznosc.setTime(waznosc.getTime() - (1000 * 60 * 20));
    document.cookie = "order =";//+ "; expires=" + waznosc.toGMTString();

    function check(checkB) 
    {    
        var Occured = new Boolean();
        Occured = false;
        
        if (checkB.checked == true) 
        {
            btnEnabled = true;
            
            for (var j = 0; j < checkBoxes.length; j++)
            {  
                //if (checkB.id.replace("MainContent_Result", "").replace("_chkOrder", "") == checkBoxes[j])
                //Occured = true;

                if (checkB.id.replace("Checkbox", "") == checkBoxes[j])
                    Occured = true;
            }

            if (Occured == false) 
            {
                //btnEnabled = true;
                //checkBoxes[checkBoxes.length] = checkB.id.replace("MainContent_Result", "").replace("_chkOrder", "");
                checkBoxes[checkBoxes.length] = checkB.id.replace("Checkbox", "");                
            }
        }
        else
        {
            for (var j = 0; j < checkBoxes.length; j++)
            {
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
        document.cookie = "order =" + temp;// + "; expires=" + waznosc.toGMTString(); //.getMinutes() + 20;
    }

    function lookCheckboxes(checkB) {
        check(checkB);

        CanOrder();
    }

    function CanOrder() {
        var btn = document.getElementById("BottomOrderBtn");
        if (btn == null) return;

        var btnTop = document.getElementById("TopOrderBtn");
        if (btnTop == null) return;        
        
        if (checkBoxes.length > 0 && checkBoxes != " " && checkBoxes != "")
            btnEnabled = true;
        else
            btnEnabled = false;

        btn.disabled = !btnEnabled;
        btnTop.disabled = !btnEnabled;
        $("#<%=TopExportBtn.ClientID%>").prop("disabled", !btnEnabled);
        $("#<%=BottomExportBtn.ClientID%>").prop("disabled", !btnEnabled);
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
        var cEl = document.getElementById("SearchType");
        if (cEl != null && cEl.textContent.toLowerCase() == "normy")
            self.location = "AddToBasket.aspx?ordersNor=" + s;
        else
            self.location = "AddToBasket.aspx?orders=" + s;
        //alert(s);
        //window.navigate("AddToBasket.aspx?orders=" + s);
    }

    $(document).ready(function () {
        $('.selectingAllCheckbox').click(function (event) {  //on click 
            if (this.checked) { // check select status
                $('.itemCheckbox').each(function () { 
                    this.checked = true;              
                    $(this).trigger('change');
                });
            } else {
                $('.itemCheckbox').each(function () { 
                    this.checked = false;                        
                    $(this).trigger('change');
                });
            }

            if (this.checked) { // check select status
                $('.selectingAllCheckbox').each(function () {
                    this.checked = true;                                   
                });
            } else {
                $('.selectingAllCheckbox').each(function () {
                    this.checked = false;                    
                });
            }
        });

    });
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeaderContent" runat="server">  <asp:Literal ID="Literal2" runat="server" Text="<%$ Resources: Language, search%>" />  </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"></asp:ScriptManager>
    <uc:SearchBox ID="SearchBox" runat="server" />
    <hr />
    <div id="MainDiv">
        <div id="LeftBarDiv" class="col-md-1">    
        </div>
        <div id="ResultArea" class="col-md-10">        
            <div id='TopResultPagining'></div>
            <br />        
            
            <asp:Button ID="TopExportBtn" runat="server" class="btn btn-default" Text="<%$ Resources: Language, exportDOC %>" UseSubmitBehavior="False" OnClick="TopExportBtn_Click" style="width:150px; display:none" />
           <% if (((string)HttpContext.Current.Session["CanOrder"]).ToLower() == "true" ) { %>         
                <input id="TopOrderBtn" type="button" class="btn btn-default" value="<%= GetGlobalResourceObject("Language", "addToBAsket")%>"  style="width:150px; display:none"/>
           <% } %><br /> 
            <br />
            <label class="checkbox-inline selectingAllLabel" style="display:none">    
                <input type="checkbox" id="selecctall" class="selectingAllCheckbox"/><asp:Literal runat="server" Text="<%$ Resources: Language, checkUncheckAll %>" />
            </label>
            <div id='ResultTable'></div>   
            <label class="checkbox-inline selectingAllLabel" style="display:none">    
                <input type="checkbox" id="selecctall2" class="selectingAllCheckbox"/><asp:Literal runat="server" Text="<%$ Resources: Language, checkUncheckAll %>" />
            </label>
            <br />
            <br />                     
            <asp:Button ID="BottomExportBtn" runat="server" class="btn btn-default" Text="<%$ Resources: Language, exportDOC %>" UseSubmitBehavior="False" OnClick="TopExportBtn_Click" style="width:150px; display:none" />
           
               <% if (((string)HttpContext.Current.Session["CanOrder"]).ToLower() == "true")  { %>
                <input id="BottomOrderBtn" type="button" class="btn btn-default" value= "<%= GetGlobalResourceObject("Language", "addToBAsket")%>" style="width:150px; display:none"/>
               <% }  %> 
            <br />
            <br />
            <div id='BottomResultPagining'></div>
            <br />
        </div>
        <div id="RightBarDiv" class="col-md-1">    
        </div>
    </div>
    <script language="javascript" type="text/javascript">
        window.onload = function () {
            CanOrder(); checkChecked(); makeCookie();
        };   </script>    
</asp:Content>