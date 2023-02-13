<%@ Page Title="<%$ Resources: Language, novelties %>" Language="C#" MasterPageFile="~/Site.master"
    AutoEventWireup="true" CodeBehind="Novelties.aspx.cs" Inherits="WebColiber._Novelties" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="HeaderContent">
    <%= GetGlobalResourceObject("Language", "novelties") %>
</asp:Content>
<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="MainContent">
    <div id="LeftBarDiv1" class="col-md-1">
    </div>
    <div id="CenterBarDiv1" class="col-md-10">
        <table border="1" frame='void' rules='all' class="table table-striped table-bordered table-hover table-condensed">
            <tr>
                <td align="center" valign="middle" style='padding-left: 10px; padding-right: 10px'>
                    <label style='font-weight: normal'>
                        <input type="radio" onclick="SzukajNew(1)" name="optionsRadios" id="NewItemsCM" value="curMonth"  />
                        <%= GetGlobalResourceObject("Language", "curMonth")%>
                    </label>
                </td>
                <td align="center" valign="middle" style='padding-left: 10px; padding-right: 10px'>
                    <label style='font-weight: normal'>
                        <input type="radio" onclick="SzukajNew(2)" name="optionsRadios" id="NewItemsCQ" value="curQuart" />
                        <%= GetGlobalResourceObject("Language", "curQtr")%>
                    </label>
                </td>
                <td align="center" valign="middle" style='padding-left: 10px; padding-right: 10px'>
                    <label style='font-weight: normal'>
                        <input type="radio" onclick="SzukajNew(3)" name="optionsRadios" id="NewItemsCY" value="curYear" />
                        <%= GetGlobalResourceObject("Language", "curYear")%>
                    </label>
                </td>
                <td style='border-right: hidden'>
                    <label style='font-weight: normal'>
                        <input type="radio" name="optionsRadios" id="Radio2" value="DateSpan" onclick="SzukajNew(5)"/>
                        <%= GetGlobalResourceObject("Language", "beginSpan")%>:
                    </label>
                </td>
                <td style='min-width: 170; border-right: hidden'>
                    <div class='input-group date' id='dpOd' style="max-width: 155px">
                        <input type='text' class="form-control" data-toggle="tooltip" data-placement="top"
                            title="<%= GetGlobalResourceObject("Language", "dateFormat")%>" style="max-width: 120px" id="tStart" />
                        <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span>
                        </span>
                    </div>
                </td>
                <td valign="middle" style='border-right: hidden' >
                    <label style='font-weight: normal'>
                        <%= GetGlobalResourceObject("Language", "to")%>:
                    </label>
                </td>
                <td style='min-width: 170; border-right: hidden'>
                    <div class='input-group date' id='dpDo' style="max-width: 155px">
                        <input type='text' class="form-control" data-toggle="tooltip" data-placement="top"
                            title="<%= GetGlobalResourceObject("Language", "dateFormat")%>" style="max-width: 120px" id="tEnd" />
                        <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span>
                        </span>
                    </div>
                </td>
                <td>
                    <button type="button" class="btn btn-default" onclick="SzukajNew(4)" id="cbSzukaj">
                        <%= GetGlobalResourceObject("Language", "search")%></button>
                </td>
            </tr>
        </table>
        <div id="ResultArea">
            <div id='TopResultPagining'>
            </div>
            <br />
            <asp:Button ID="TopExportBtn" runat="server" class="btn btn-default" Text="<%$ Resources: Language, exportDOC %>"
                UseSubmitBehavior="False" OnClick="TopExportBtn_Click" Style="width: 150px; display: none" />
            <% if (((string)HttpContext.Current.Session["CanOrder"]).ToLower() == "true")
               { %>
            <input id="TopOrderBtn" type="button" class="btn btn-default" value="<%= GetGlobalResourceObject("Language", "addToBAsket")%>"
                style="width: 150px; display: none" onclick="Order()" />
            <% } %><br />
            <br />
            <label class="checkbox-inline selectingAllLabel" style="display: none">
                <input type="checkbox" id="selecctall" class="selectingAllCheckbox" /><asp:Literal
                    ID="Literal1" runat="server" Text="<%$ Resources: Language, checkUncheckAll %>" />
            </label>
            <div id='ResultTable'>
            </div>
            <label class="checkbox-inline selectingAllLabel" style="display: none">
                <input type="checkbox" id="selecctall2" class="selectingAllCheckbox" /><asp:Literal
                    ID="Literal2" runat="server" Text="<%$ Resources: Language, checkUncheckAll %>" />
            </label>
            <br />
            <asp:Button ID="BottomExportBtn" runat="server" class="btn btn-default" Text="<%$ Resources: Language, exportDOC %>"
                UseSubmitBehavior="False" OnClick="TopExportBtn_Click" Style="width: 150px; display: none" />
            <% if (((string)HttpContext.Current.Session["CanOrder"]).ToLower() == "true")
               { %>
            <input id="BottomOrderBtn" type="button" class="btn btn-default" value="<%= GetGlobalResourceObject("Language", "addToBAsket")%>"
                style="width: 150px; display: none" onclick="Order()" />
            <% } %>
            <br />
            <div id='BottomResultPagining'>
            </div>
            <br />
        </div>
    </div>
    <div id="RightBarDiv1" class="col-md-1">
    </div>
    <script type='text/javascript' src="<%=ResolveClientUrl("~/Scripts/jquery.simplePagination.js")%>"></script>
    <script type='text/javascript' src="<%=ResolveClientUrl("~/Scripts/bootstrap.js")%>"></script>
    <script type='text/javascript' src="<%=ResolveClientUrl("~/Scripts/bootstrap-datepicker.de.min.js")%>"></script>
    <script type='text/javascript' src="<%=ResolveClientUrl("~/Scripts/bootstrap-datepicker.en.min.js")%>"></script>
    <script type='text/javascript' src="<%=ResolveClientUrl("~/Scripts/bootstrap-datepicker.es.min.js")%>"></script>
    <script type='text/javascript' src="<%=ResolveClientUrl("~/Scripts/bootstrap-datepicker.fr.min.js")%>"></script>
    <script type='text/javascript' src="<%=ResolveClientUrl("~/Scripts/bootstrap-datepicker.pl.min.js")%>"></script>
    <link rel="stylesheet" href="<%=ResolveClientUrl("~/Styles/bootstrap.css")%>">
    <script type="text/javascript">
        var lInit = false;
        var cOd = "";
        var cDo = "";
        var checkBoxes = "";
        var cLang = "pl";

        $(document).ready(function () {
            var $j = jQuery.noConflict();
            document.cookie = "order" + '=; expires=Thu, 01 Jan 1970 00:00:01 GMT;';
            cLang = '<%= (string)HttpContext.Current.Session["Lang"] %>';
            if (cLang.length > 2) cLang = cLang.substring(0, 2);

            $j('#tStart').tooltip();
            $j('#tEnd').tooltip();
            $j('#cbSzukaj').prop('disabled', true);

            $j("#NewItemsCM").prop("checked", true);
            SzukajNew(1);

            $j('#dpOd').datepicker({
                format: "dd-mm-yyyy",
                showOnFocus: false,
                language: cLang,
                autoclose: true
            });
            $j('#dpDo').datepicker({
                format: "dd-mm-yyyy",
                showOnFocus: false,
                language: cLang,
                autoclose: true,
                useCurrent: false //Important! See issue #1075
            });
        });

        function showBtns(lShow) {
            var $j = jQuery.noConflict();
            $j('#TopOrderBtn').show('fast');
            $j('#BottomOrderBtn').show('fast');
            $j('#MainContent_TopExportBtn').show('fast');
            $j('#MainContent_BottomExportBtn').show('fast');
            $j('#TopOrderBtn').prop('disabled', !lShow);
            $j('#BottomOrderBtn').prop('disabled', !lShow);
            $j('#MainContent_TopExportBtn').prop('disabled', !lShow);
            $j('#MainContent_BottomExportBtn').prop('disabled', !lShow);
        }

        function lookCheckboxes(oChkBox) {
            var cId = oChkBox.id;
            cId = cId.replace("Checkbox", "");
            if (checkBoxes.length > 100) {
                var chParts = checkBoxes.split(".");
                alert('<%= GetGlobalResourceObject("Language", "toManyItemsInBasket")%> +  !');
                return;
            }
            cId = "$" + cId + "$,";
            if (oChkBox.checked) checkBoxes = checkBoxes + cId;
            else checkBoxes = checkBoxes.replace(cId, "");
            if (checkBoxes == "") {
                document.cookie = "order" + '=; expires=Thu, 01 Jan 1970 00:00:01 GMT;';
                showBtns(false);
            }
            else {
                document.cookie = "order=" + checkBoxes;
                showBtns(true);
            }
        }

        function Order() {

            if (checkBoxes.length == 0) {
                alert('<%= GetGlobalResourceObject("Language", "noItemsToAdd")%> !');
                return;
            }
            var s = checkBoxes;
            s = s.split("$").join("");
            s = s.substring(0, s.length - 1);
            s = "{" + s + "}";
            self.location = "AddToBasket.aspx?orders=" + s;
        }

        function checkChecked() {

            var chParts = checkBoxes.split(",");
            var cId;
            for (var i = 0; i < chParts.length; i++) {
                cId = chParts[i];
                cId = cId.replace("$", "");
                cId = cId.replace("$", "");     // dwa dolary !!!
                var checkbox = document.getElementById("Checkbox" + cId);
                //var checkbox = $("#CheckBox" + checkBoxes[i]);             
                if (checkbox != null)
                    checkbox.checked = true;
            }
        }


        function parseDate(str) {
            if (str == null) return null;
            var dateParts = str.split("-");
            if (dateParts.length != 3)
                return null;
            var year = dateParts[2];
            var month = dateParts[1];
            var day = dateParts[0];

            if (isNaN(day) || isNaN(month) || isNaN(year))
                return null;

            var result = new Date(year, (month - 1), day);
            if (result == null)
                return null;
            if (result.getDate() != day)
                return null;
            if (result.getMonth() != (month - 1))
                return null;
            if (result.getFullYear() != year)
                return null;
            return result;
        }

        function SzukajNew(iOption) {
            var date = new Date(), y = date.getFullYear(), m = date.getMonth();
            var q = Math.floor(((date.getMonth() + 1) / 4));
            var firstDay;
            var lastDay;
            var $j = jQuery.noConflict();
            var lDisable = (iOption < 4);
            $j('#cbSzukaj').prop('disabled',lDisable);
            if (iOption == 1) {
                firstDay = new Date(y, m, 1);
                lastDay = new Date(y, m + 1, 0);
            }
            if (iOption == 2) {
                var m1;
                m1 = (q * 3);
                firstDay = new Date(y, m1, 1);
                lastDay = new Date(y, m1 + 3, 0);
            }
            if (iOption == 3) {
                firstDay = new Date(y, 0, 1);
                lastDay = new Date(y, 11, 31);
            }
            if (iOption == 4) {
                var d1;
                var d2;
                cOd = $j('#tStart').val();
                cDo = $j('#tEnd').val();
                d1 = parseDate(cOd);
                if (d1 == null) {
                    alert('<%= GetGlobalResourceObject("Language", "invalidDate1")%>: ' + cOd + '\n' + '<%= GetGlobalResourceObject("Language", "enterDateDDMMRRRR")%>');
                    return;
                }
                d2 = parseDate(cDo);
                if (d2 == null) {
                    alert('<%= GetGlobalResourceObject("Language", "invalidDate2")%>: ' + cDo + '\n' + '<%= GetGlobalResourceObject("Language", "enterDateDDMMRRRR")%>');
                    return;
                }
                if (d2 < d1) {
                    alert('<%= GetGlobalResourceObject("Language", "badDateSpan")%> !');
                    return;
                }
            }
            else {
                var cZnak;
                cOd = firstDay.toLocaleString();
                cDo = lastDay.toLocaleString();
                cOd = cOd.substring(0, 10);
                cDo = cDo.substring(0, 10);
                cZnak = cOd.substring(9, 10);
                if (cZnak == ',') cOd = '0' + cOd.substring(0, 9);
            }
            if (iOption == 5) return;

            //alert(cOd + "\n" + cDo);
            lInit = false;
            Szukaj(0);
        }

        function Szukaj(CurrentPage) {
            if (CurrentPage == null || CurrentPage < 1) CurrentPage = 1;
            var $j = jQuery.noConflict();
            var ValuesArray = [cOd, cDo];
            var ValuesArray2 = ["a", "b"];
            var Sort = '';
            var Basic = false;
            var Count = 50;
            var StartIndex = (CurrentPage - 1) * Count + 1;



            /*                url: "http://localhost:53472/lines.txt", // path to file
            dataType: 'text', // type of file (text, json, xml, etc)
            */

            $j.ajax({
                url: "SearchWebService.asmx/GetData",
                data: JSON.stringify({ Type: 'novelties', Values: ValuesArray, ANDValues: ValuesArray2, StartIndex: StartIndex, Count: Count, Basic: Basic, Sort: Sort }),
                type: "POST",
                dataType: "json",
                async: false,
                contentType: "application/json", // charset=utf-8",
                success: OnSuccess,
                error: OnError
            });
            return false;

        };

        function OnSuccess(data) {
            var d = data.d;

            var $j = jQuery.noConflict();
            $j('#ResultCount').remove();

            //var al = data.substring(1, 50);
            //alert(al);

            //$j("#ResultCount").html("<div id='ResultCount' style='visibility:hidden'>6443</div>")
            //$j("#ResultTable").html(data);

            $j('#ResultTable').text('');
            //$j("#ResultTable").append(d);
            $j("#ResultTable").html(d);


            var ShowOrderButtons = '<%=  (!string.IsNullOrEmpty(Session["CanOrder"].ToString()) != null ? Boolean.Parse(Session["CanOrder"].ToString()) : false) %>';

            if (ShowOrderButtons && $j('#ResultCount').text() != '' && $j('#ResultCount').text() > 0) {
                showBtns(false);
            }
            else {
                showBtns(false);
            }
            if (lInit == false) {
                checkBoxes = "";
                CreatePaginations();
            }

            checkChecked();


            return false;
        }

        function OnError(xhr, status) {
            alert(status + "\r\n" + xhr.responseText);
        }

        function CreatePaginations() {
            var $j = jQuery.noConflict();
            lInit = true;
            $j("#TopResultPagining").pagination({
                items: $j('#ResultCount').text(),
                itemsOnPage: 50,
                cssStyle: 'light-theme',
                displayedPages: 15,
                currentPage: 1,
                prevText: '<%= GetGlobalResourceObject("Language", "previous")%>',
                nextText: '<%= GetGlobalResourceObject("Language", "next")%>',
                firstText: '<%= GetGlobalResourceObject("Language", "first")%>',
                lastText: '<%= GetGlobalResourceObject("Language", "last")%>',
                onPageClick: function (pageNumber, event) {
                    var $j1 = jQuery.noConflict();
                    if ($j1('#BottomResultPagining').pagination('getCurrentPage') != pageNumber)
                        $j1('#BottomResultPagining').pagination('selectPage', pageNumber);
                    else {
                        Szukaj(pageNumber);
                    }
                }
            });

            $j("#BottomResultPagining").pagination({
                items: $j('#ResultCount').text(),
                itemsOnPage: 50,
                cssStyle: 'light-theme',
                displayedPages: 15,
                currentPage: 1,
                prevText: '<%= GetGlobalResourceObject("Language", "previous")%>',
                nextText: '<%= GetGlobalResourceObject("Language", "next")%>',
                firstText: '<%= GetGlobalResourceObject("Language", "first")%>',
                lastText: '<%= GetGlobalResourceObject("Language", "last")%>',
                onPageClick: function (pageNumber, event) {
                    var $j1 = jQuery.noConflict();
                    if ($j1('#BottomResultPagining').pagination('getCurrentPage') != pageNumber)
                        $j1('#BottomResultPagining').pagination('selectPage', pageNumber);
                    else {
                        Szukaj(pageNumber);
                    }
                }
            });
        }


        $('body').on('click', 'a.link_click', function () {
            var $j = jQuery.noConflict();
            var resId = $j(this).attr('rel');
            var name = "#containter" + resId;

            if ($j(name).is(':visible')) {
                $j(name).hide();
                return;
            }
            else {
                $j(name).show();
            }

            $j.ajax({
                url: "Details.aspx/GenerateContent",
                data: JSON.stringify({ type: "Books", id: resId, toPrint: false }),
                type: "POST",
                dataType: "json",
                async: false,
                contentType: "application/json", // charset=utf-8",
                success: DetailsSuccess,
                error: DetailsError
            });

            function DetailsSuccess(data) {
                var $j = jQuery.noConflict();
                var d = data.d;
                $j(name).html(d);
            }

            function DetailsError(xhr, status) {
                alert(status + "\r\n" + xhr.responseText);
            }
        });




    </script>
</asp:Content>
