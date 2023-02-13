<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SearchBox.ascx.cs" Inherits="WebColiber.SearchBox"  %>
<style type="text/css">
	.style1
	{
		height: 26px;
	}
	.style2
	{
		width: 121px;
	}
	.style3
	{
		height: 26px;
		width: 121px;
	}
	.phrase
	{
		min-width: 121px;
		font-size: 14px;
	}
	
	.AlignToRight
	{
		text-align:right;
	}

	.ui-autocomplete {
		max-height: 200px;
		overflow-y: auto;
		/* prevent horizontal scrollbar */
		overflow-x: hidden;
	}
</style>
<!--<script type="text/javascript" language="javascript">-->
<script type='text/javascript' src="<%=ResolveClientUrl("~/Scripts/jquery.simplePagination.js")%>"></script>  

<script type='text/javascript' src="<%=ResolveClientUrl("~/Scripts/jquery-ui.js")%>"></script>  
<script type='text/javascript' src="<%=ResolveClientUrl("~/Scripts/bootstrap.js")%>"></script>   

<!--<script type='text/javascript' src="http://code.jquery.com/ui/1.10.4/jquery-ui.js"></script>-->
<!--<link rel="stylesheet" href="http://code.jquery.com/ui/1.10.3/themes/smoothness/jquery-ui.css">-->
<link rel="stylesheet" href="<%=ResolveClientUrl("~/Styles/bootstrap.css")%>">


<script type="text/javascript" language="javascript">
    $(document).ready(function () {
        $('#<%=txtPhrase1.ClientID %>').tooltip('disable');
        $('#<%=txtPhrase2.ClientID %>').tooltip('disable');
        $('#<%=txtPhrase3.ClientID %>').tooltip('disable');
        $('#<%=txtPhrase4.ClientID %>').tooltip('disable');
        $('#<%=txtPhrase5.ClientID %>').tooltip('disable');

        //$('#<%=dropType1.ClientID %>').change(function () {            
        $('select').change(function () {
            //
            if ($('#<%=dropType1.ClientID %>').val() == "entry_date")
                $('#<%=txtPhrase1.ClientID %>').tooltip('enable');
            else
                $('#<%=txtPhrase1.ClientID %>').tooltip('disable');

            if ($('#<%=dropType2.ClientID %>').val() == "entry_date")
                $('#<%=txtPhrase2.ClientID %>').tooltip('enable');
            else
                $('#<%=txtPhrase2.ClientID %>').tooltip('disable');

            if ($('#<%=dropType3.ClientID %>').val() == "entry_date")
                $('#<%=txtPhrase3.ClientID %>').tooltip('enable');
            else
                $('#<%=txtPhrase3.ClientID %>').tooltip('disable');

            if ($('#<%=dropType4.ClientID %>').val() == "entry_date")
                $('#<%=txtPhrase4.ClientID %>').tooltip('enable');
            else
                $('#<%=txtPhrase4.ClientID %>').tooltip('disable');

            if ($('#<%=dropType5.ClientID %>').val() == "entry_date")
                $('#<%=txtPhrase5.ClientID %>').tooltip('enable');
            else
                $('#<%=txtPhrase5.ClientID %>').tooltip('disable');
        });


        var newPage = true;
        BindComobobox();

        ChangeSearchMode();

        var ValuesArray = [];
        var ValuesArray2 = [];
        var Sort = '';
        var Basic = false;

        $('#TopOrderBtn').click(function (event) {
            Order();
            return false;
        });

        $('#BottomOrderBtn').click(function (event) {
            Order();
            return false;
        });

        // event clearbutton - czyści
        $("#ClearButton").click(function (event) {
            //SearchFunction(1);

            //$('#<%=dropPath.ClientID %>').prop("selectedIndex", 0);
            //$('#<%=dropPath.ClientID %>').change();

            // clear phrase textboxes
            $('#<%=txtPhrase1.ClientID %>').val("");
            $('#<%=txtPhrase2.ClientID %>').val("");
            $('#<%=txtPhrase3.ClientID %>').val("");
            $('#<%=txtPhrase4.ClientID %>').val("");
            $('#<%=txtPhrase5.ClientID %>').val("");

            // select first
            $('#<%=dropType1.ClientID %>').prop("selectedIndex", 0);
            $('#<%=dropType2.ClientID %>').prop("selectedIndex", 0);
            $('#<%=dropType3.ClientID %>').prop("selectedIndex", 0);
            $('#<%=dropType4.ClientID %>').prop("selectedIndex", 0);
            $('#<%=dropType5.ClientID %>').prop("selectedIndex", 0);

            $('#<%=dropOperator1.ClientID %>').prop("selectedIndex", 0);
            $('#<%=dropOperator2.ClientID %>').prop("selectedIndex", 0);
            $('#<%=dropOperator3.ClientID %>').prop("selectedIndex", 0);
            $('#<%=dropOperator4.ClientID %>').prop("selectedIndex", 0);

            $('#<%=LangDDL.ClientID %>').prop("selectedIndex", 0);
            $('#<%=CountryDDL.ClientID %>').prop("selectedIndex", 0);
            $('#<%=FreqDDL.ClientID %>').prop("selectedIndex", 0);
            $('#SortDDL').prop("selectedIndex", 0);

            $("#LewyNawias1").prop("checked", false);
            $("#LewyNawias2").prop("checked", false);
            $("#LewyNawias3").prop("checked", false);
            $("#LewyNawias4").prop("checked", false);
            $("#PrawyNawias2").prop("checked", false);
            $("#PrawyNawias3").prop("checked", false);
            $("#PrawyNawias4").prop("checked", false);
            $("#PrawyNawias5").prop("checked", false);

            $("#SourcesCheckbox").prop("checked", false);

            MakeSearchPhrase();

            $('select').change();
            //$('#BasicSearchRadio').click();
        });

        function BindComobobox() {
            // show controls, when type is 'magazines'
            if ($('#<%=dropPath.ClientID %>').val() == "magazines" && !$('#BasicSearchRadio').is(":checked")) {
                // show
                $('#CountryTR').show("fast");
                $('#FreqTR').show("fast");
            }
            else {
                // hide
                $('#CountryTR').hide("fast");
                $('#FreqTR').hide("fast");
            }

            cId = $('#<%=dropPath.ClientID %>').val();

            if ((cId == "books") && !$('#BasicSearchRadio').is(":checked")) {
                $('#SortTR').show("fast");
                //SortDDLMod(cId);
            }
            else {
                $('#SortTR').hide("fast");
            }

            BindDropTypes();
        }

        /*
        function SortDDLMod(cMod) {
            if (cMod == "normy") {
                $("#SortDDL option[value='author']").remove();
                if ($("#SortDDL option[value='nrn']").length == 0) $("#SortDDL").append('<option value="nrn">Numer normy</option>');
            }
            else {
                $("#SortDDL option[value='nrn']").remove();
                if ($("#SortDDL option[value='author']").length == 0) $("#SortDDL").append('<option value="author">Autor</option>');
            }
        }
        */

        function BindDropTypes() {
            var type1 = $('#<%=dropType1.ClientID%>').val();
            var type2 = $('#<%=dropType2.ClientID%>').val();
            var type3 = $('#<%=dropType3.ClientID%>').val();
            var type4 = $('#<%=dropType4.ClientID%>').val();
            var type5 = $('#<%=dropType5.ClientID%>').val();

            $('#<%=dropType1.ClientID%>').empty();
            $('#<%=dropType2.ClientID%>').empty();
            $('#<%=dropType3.ClientID%>').empty();
            $('#<%=dropType4.ClientID%>').empty();
            $('#<%=dropType5.ClientID%>').empty();

            $('#<%=dropType1.ClientID%>').append($('<option></option>').val('0').html('<%= GetGlobalResourceObject("Language", "pleaseWait")%>'));
            $('#<%=dropType2.ClientID%>').append($('<option></option>').val('0').html('<%= GetGlobalResourceObject("Language", "pleaseWait")%>'));
            $('#<%=dropType3.ClientID%>').append($('<option></option>').val('0').html('<%= GetGlobalResourceObject("Language", "pleaseWait")%>'));
            $('#<%=dropType4.ClientID%>').append($('<option></option>').val('0').html('<%= GetGlobalResourceObject("Language", "pleaseWait")%>'));
            $('#<%=dropType5.ClientID%>').append($('<option></option>').val('0').html('<%= GetGlobalResourceObject("Language", "pleaseWait")%>'));

            $.ajax({
                url: "Search.aspx/GetItemsList",
                data: JSON.stringify({ type: $('#<%=dropPath.ClientID %>').val() }),
                type: "POST",
                dataType: "json",
                contentType: "application/json", //; charset=utf-8",
                success: OnSuccess,
                error: OnError
            });

            function OnSuccess(data) {
                $('#<%=dropType1.ClientID%>').empty();
                $('#<%=dropType2.ClientID%>').empty();
                $('#<%=dropType3.ClientID%>').empty();
                $('#<%=dropType4.ClientID%>').empty();
                $('#<%=dropType5.ClientID%>').empty();

                var d = data.d;
                var dropdown = $('#<%=dropType1.ClientID%>');
                var dropdown2 = $('#<%=dropType2.ClientID%>');
                var dropdown3 = $('#<%=dropType3.ClientID%>');
                var dropdown4 = $('#<%=dropType4.ClientID%>');
                var dropdown5 = $('#<%=dropType5.ClientID%>');

                for (var i = 0; i < d.length; i++) {
                    dropdown.append($('<option></option>').val(d[i].Value.toString()).html(d[i].Text.toString()));
                    dropdown2.append($('<option></option>').val(d[i].Value.toString()).html(d[i].Text.toString()));
                    dropdown3.append($('<option></option>').val(d[i].Value.toString()).html(d[i].Text.toString()));
                    dropdown4.append($('<option></option>').val(d[i].Value.toString()).html(d[i].Text.toString()));
                    dropdown5.append($('<option></option>').val(d[i].Value.toString()).html(d[i].Text.toString()));
                }

                //var Type1 = $("#<%=Type1HiddenField.ClientID %>").val();
                //var Type2 = $("#<%=Type2HiddenField.ClientID %>").val();
                //var Type3 = $("#<%=Type3HiddenField.ClientID %>").val();
                //var Type4 = $("#<%=Type4HiddenField.ClientID %>").val();
                //var Type5 = $("#<%=Type5HiddenField.ClientID %>").val();

                //$('#<%=dropType1.ClientID %>').val(type1);
                $('#<%=dropType1.ClientID %>' + " option[value='" + type1 + "']").prop("selected", true);
                $('#<%=dropType2.ClientID %>' + " option[value='" + type2 + "']").prop("selected", true);
                $('#<%=dropType3.ClientID %>' + " option[value='" + type3 + "']").prop("selected", true);
                $('#<%=dropType4.ClientID %>' + " option[value='" + type4 + "']").prop("selected", true);
                $('#<%=dropType5.ClientID %>' + " option[value='" + type5 + "']").prop("selected", true);

                //if (Type1 != '')
                //$('#<%=dropType1.ClientID %>').val(Type1);
                // if (Type2 != '')
                //$('#<%=dropType2.ClientID %>').val(Type2);
                //if (Type3 != '')
                //$('#<%=dropType3.ClientID %>').val(Type3);
                //if (Type4 != '')
                //$('#<%=dropType4.ClientID %>').val(Type4);
                //if (Type5 != '')
                //$('#<%=dropType5.ClientID %>').val(Type5);

                //alert('Zmiana dropPath');

                $('#<%=dropType1.ClientID %>').prop("selectedIndex", 0);
                $('#<%=dropType2.ClientID %>').prop("selectedIndex", 0);
                $('#<%=dropType3.ClientID %>').prop("selectedIndex", 0);
                $('#<%=dropType4.ClientID %>').prop("selectedIndex", 0);
                $('#<%=dropType5.ClientID %>').prop("selectedIndex", 0);

                MakeSearchPhrase();

                if (newPage)
                    Find();
            }

            function OnError(xhr, status) {
                alert(status + "\r\n" + xhr.responseText);
            }
        }

        function validSearch(cVal, cName) {
            if ((cVal == null) || (cVal == '')) return true;
            var n = 0;
            var index;
            var a = ["<", ">", "&amp;", "&apos;", "&quot;", "&lt;", "&gt;"];
            var cStr
            for (i = 0; i < a.length; ++i) {
                cStr = a[i];
                n = cVal.indexOf(cStr);
                if (n > -1) {
                    alert('Napis ' + cVal + ' zawiera nieprawidlowy znak "' + cStr + '"!');
                    return false;
                }
            }
            return true;
        }

        function SearchFunction(CurrentPage, NewSearch) {
            ValuesArray = [];
            ValuesArray2 = [];
            Sort = '';
            Basic = false;
            cVal = '';
            cName = '';
            cVal = $('#<%=txtPhrase1.ClientID %>').val();
            if (!validSearch(cVal, "1")) return;
            cVal = $('#<%=txtPhrase2.ClientID %>').val();
            if (!validSearch(cVal, "2")) return;
            cVal = $('#<%=txtPhrase3.ClientID %>').val();
            if (!validSearch(cVal, "3")) return;
            cVal = $('#<%=txtPhrase4.ClientID %>').val();
            if (!validSearch(cVal, "4")) return;
            cVal = $('#<%=txtPhrase5.ClientID %>').val();
            if (!validSearch(cVal, "5")) return;

            if ($('#BasicSearchRadio').is(":checked")) {
                ValuesArray.push($('#<%=txtPhrase1.ClientID %>').val(), '', '', '', '');

                Basic = true;
            }
            else {
                ValuesArray.push($('#<%=txtPhrase1.ClientID %>').val(), $('#<%=dropType1.ClientID %>').val(), $('#<%=dropOperator1.ClientID %>').val(), $('#LewyNawias1').is(":checked") ? '(' : '', '');
                ValuesArray.push($('#<%=txtPhrase2.ClientID %>').val(), $('#<%=dropType2.ClientID %>').val(), $('#<%=dropOperator2.ClientID %>').val(), $('#LewyNawias2').is(":checked") ? '(' : '', $('#PrawyNawias2').is(":checked") ? ')' : '');
                ValuesArray.push($('#<%=txtPhrase3.ClientID %>').val(), $('#<%=dropType3.ClientID %>').val(), $('#<%=dropOperator3.ClientID %>').val(), $('#LewyNawias3').is(":checked") ? '(' : '', $('#PrawyNawias3').is(":checked") ? ')' : '');
                ValuesArray.push($('#<%=txtPhrase4.ClientID %>').val(), $('#<%=dropType4.ClientID %>').val(), $('#<%=dropOperator4.ClientID %>').val(), $('#LewyNawias4').is(":checked") ? '(' : '', $('#PrawyNawias4').is(":checked") ? ')' : '');
                ValuesArray.push($('#<%=txtPhrase5.ClientID %>').val(), $('#<%=dropType5.ClientID %>').val(), '', '', $('#PrawyNawias5').is(":checked") ? ')' : '');

                ValuesArray2.push($('#<%=LangDDL.ClientID %>').val(), 'lang', 'and', '', '');
                ValuesArray2.push($('#<%=CountryDDL.ClientID %>').val(), 'country', 'and', '', '');
                ValuesArray2.push($('#<%=FreqDDL.ClientID %>').val(), 'freq', 'and', '', '');

                Sort = $('#SortDDL').val();
            }

            if ($('#SourcesCheckbox').is(":checked"))
                ValuesArray2.push('sources', 'sources', 'and', '', '');

            SearchInDb(CurrentPage, NewSearch, ValuesArray, ValuesArray2, Sort, Basic);
        }

        // search function
        function SearchInDb(CurrentPage, NewSearch, ValuesArray, ValuesArray2, Sort, Basic) {
            var Count = 50;
            StartIndex = (CurrentPage - 1) * Count + 1;

            document.cookie = "typeToPrint = " + $('#<%=dropPath.ClientID %>').val();

            $.ajax({
                url: "SearchWebService.asmx/GetData",
                data: JSON.stringify({ Type: $('#<%=dropPath.ClientID %>').val(), Values: ValuesArray, ANDValues: ValuesArray2, StartIndex: StartIndex, Count: Count, Basic: Basic, Sort: Sort }),
                type: "POST",
                dataType: "json",
                async: false,
                contentType: "application/json", // charset=utf-8",
                success: OnSuccess,
                error: OnError
            });

            function OnSuccess(data) {
                var d = data.d;

                $('#ResultCount').remove();
                $('#ResultTable').text('');

                $("#ResultTable").append(d);
                $(".selectingAllCheckbox").prop("checked", false);

                var ShowOrderButtons = '<%=  (!string.IsNullOrEmpty(Session["CanOrder"].ToString()) ? Boolean.Parse(Session["CanOrder"].ToString()) : false) && (dropPath.SelectedValue == "books" || dropPath.SelectedValue == "normy") %>'

                if (ShowOrderButtons && $('#ResultCount').text() != '' && $('#ResultCount').text() > 0) {
                    /*$('#TopResultPagining').show('fast');
                    $('#BottomResultPagining').show('fast');*/

                    $('#TopOrderBtn').show('fast');
                    $('#BottomOrderBtn').show('fast');
                }
                else {
                    /*$('#TopResultPagining').hide('fast');
                    $('#BottomResultPagining').hide('fast');*/

                    $('#TopOrderBtn').hide('fast');
                    $('#BottomOrderBtn').hide('fast');
                }

                if ($('#ResultCount').text() != '' && $('#ResultCount').text() > 0) {
                    $('#MainContent_TopExportBtn').show('fast');
                    $('#MainContent_BottomExportBtn').show('fast');
                    $('.selectingAllLabel').show('fast');
                }
                else {
                    $('#MainContent_TopExportBtn').hide('fast');
                    $('#MainContent_BottomExportBtn').hide('fast');
                    $('.selectingAllLabel').hide('fast');
                }

                if (NewSearch) {
                    CreatePaginations();
                    checkBoxes = new Array();
                }

                checkChecked();
                CanOrder();
            }

            function OnError(xhr, status) {
                alert(status + "\r\n" + xhr.responseText);
            }
        }

        function CreatePaginations() {
            $("#BottomResultPagining").pagination({
                items: $('#ResultCount').text(),
                itemsOnPage: 50,
                cssStyle: 'light-theme',
                displayedPages: 15,
                currentPage: 1,
                prevText: '<%= GetGlobalResourceObject("Language", "previous")%>',
                nextText: '<%= GetGlobalResourceObject("Language", "next")%>',
                firstText: '<%= GetGlobalResourceObject("Language", "first")%>',
                lastText: '<%= GetGlobalResourceObject("Language", "last")%>',
                onPageClick: function (pageNumber, event) {

                    if ($('#TopResultPagining').pagination('getCurrentPage') != pageNumber)
                        $('#TopResultPagining').pagination('selectPage', pageNumber);
                    else
                        SearchInDb(pageNumber, false, ValuesArray, ValuesArray2, Sort, Basic);
                }
            });

            $("#TopResultPagining").pagination({
                items: $('#ResultCount').text(),
                itemsOnPage: 50,
                cssStyle: 'light-theme',
                displayedPages: 15,
                currentPage: 1,
                prevText: '<%= GetGlobalResourceObject("Language", "previous")%>',
                nextText: '<%= GetGlobalResourceObject("Language", "next")%>',
                firstText: '<%= GetGlobalResourceObject("Language", "first")%>',
                lastText: '<%= GetGlobalResourceObject("Language", "last")%>',
                onPageClick: function (pageNumber, event) {

                    if ($('#BottomResultPagining').pagination('getCurrentPage') != pageNumber)
                        $('#BottomResultPagining').pagination('selectPage', pageNumber);
                    else
                        SearchInDb(pageNumber, false, ValuesArray, ValuesArray2, Sort, Basic);
                }
            });
        }

        // change event on 'baza'
        $('#<%=dropPath.ClientID %>').change(function (event) {
            BindComobobox();
        });

        // click event on 'search'
        $('#btnSearch').click(function (event) {
            SearchFunction(1, true);

            return false;
        });

        $.urlParam = function (name) {
            var results = new RegExp('[\\?&]' + name + '=([^&#]*)').exec(window.location.href);
            if (results == null) {
                return null;
            }
            else {
                return results[1] || 0;
            }
        };

        function Find() {
            if ($.urlParam('path') != null) {
                $('#<%=dropPath.ClientID %> option[value="' + decodeURIComponent($.urlParam('path')) + '"]').prop("selected", true);
            }

            if ($.urlParam('key') != null) {
                $('#AdvancedSearchRadio').click();
                $('#<%=txtPhrase1.ClientID %>').val(decodeURIComponent($.urlParam('key')));
                $('#<%=dropType1.ClientID %> option[value="key"]').prop("selected", true);

                SearchFunction(1, true);

                newPage = false;
            }
        };

        function ChangeSearchMode() {
            if ($('#BasicSearchRadio').is(":checked")) {
                //$('#Phrase1stLabel').text("");
                $('#LewyNawias1Label').hide("fast");
                $('#<%=dropType1.ClientID %>').hide("fast");
                $('#<%=dropOperator1.ClientID %>').hide("fast");

                // tr
                $('#Phrase2ndTR').hide("fast");
                $('#Phrase3rdTR').hide("fast");
                $('#Phrase4thTR').hide("fast");
                $('#Phrase5thTR').hide("fast");
                $('#LangTR').hide("fast");
                $('#CountryTR').hide("fast");
                $('#FreqTR').hide("fast");
                $('#SortTR').hide("fast");
            }
            else {
                // $('#Phrase1stLabel').text("Fraza");
                $('#LewyNawias1Label').show("fast");
                $('#<%=dropType1.ClientID %>').show("fast");
                $('#<%=dropOperator1.ClientID %>').show("fast");

                // tr
                $('#Phrase2ndTR').show("fast");
                $('#Phrase3rdTR').show("fast");
                $('#Phrase4thTR').show("fast");
                $('#Phrase5thTR').show("fast");
                $('#LangTR').show("fast");

                if ($('#<%=dropPath.ClientID %>').val() == "magazines") {
                    $('#CountryTR').show("fast");
                    $('#FreqTR').show("fast");
                }

                if ($('#<%=dropPath.ClientID %>').val() == "books") {
                    $('#SortTR').show("fast");
                }

                //if ($('#<%=dropPath.ClientID %>').val() == "normy")  $('#SortTR').show("fast");

            }
        }

         $(document).on("click", "#title_thead a", function () {
            if (Sort == 'title') Sort = 'title_desc';
            else Sort = 'title';
            SearchInDb(1, true, ValuesArray, ValuesArray2, Sort, Basic);
            if (Sort == 'title') $("#title_thead").append('\t' + '&#8595;');
            if (Sort == 'title_desc') $("#title_thead").append('\t' + '&#8593;');
        });

        $(document).on("click", "#author_thead a", function () {
            if (Sort == 'author') Sort = 'author_desc';
            else Sort = 'author';
            SearchInDb(1, true, ValuesArray, ValuesArray2, Sort, Basic);
            if (Sort == 'author') $("#author_thead").append('\t' + '&#8595;');
            if (Sort == 'author_desc') $("#author_thead").append('\t' + '&#8593;');
        });

        $(document).on("click", "#publish_year_thead a", function () {
            if (Sort == 'year_asc') Sort = 'year_desc';
            else Sort = 'year_asc';
            SearchInDb(1, true, ValuesArray, ValuesArray2, Sort, Basic);
            if (Sort == 'year_asc') $("#publish_year_thead").append('\t' + '&#8595;');
            if (Sort == 'year_desc') $("#publish_year_thead").append('\t' + '&#8593;');
        });

        $(document).on("click", "#data_pub_thead a", function () {
            if (Sort == 'data_pub') Sort = 'data_pub_desc';
            else Sort = 'data_pub';
            SearchInDb(1, true, ValuesArray, ValuesArray2, Sort, Basic);
            if (Sort == 'data_pub') $("#data_pub_thead").append('\t' + '&#8595;');
            if (Sort == 'data_pub_desc') $("#data_pub_thead").append('\t' + '&#8593;');
        });

        $(document).on("click", "#nrn_thead a", function () {
            Sort = 'nr_normy';
            SearchInDb(1, true, ValuesArray, ValuesArray2, 'nr_normy', Basic);
            $("#nrn_thead").append('\t' + '&#8595;');
        });

        $("input[name=optionsRadios]:radio").change(function () {
            ChangeSearchMode();
            MakeSearchPhrase();
        });

        $('input:checkbox').change(function () {
            MakeSearchPhrase();
            CheckPhrase();
        });

        $('input:text').on('input', function () {
            MakeSearchPhrase();
            CheckPhrase();
        });

        $('select').change(function () {
            MakeSearchPhrase();
        });

        function CheckPhrase() {
            var IsGood = true;
            var LeftCount = 0;
            var RightCount = 0;

            IsGood &= $('#LewyNawias1').is(":checked") ? ($('#PrawyNawias2').is(":checked") || $('#PrawyNawias3').is(":checked") || $('#PrawyNawias4').is(":checked") || $('#PrawyNawias5').is(":checked")) : true;
            IsGood &= $('#LewyNawias2').is(":checked") ? ($('#PrawyNawias2').is(":checked") || $('#PrawyNawias3').is(":checked") || $('#PrawyNawias4').is(":checked") || $('#PrawyNawias5').is(":checked")) : true;
            IsGood &= $('#LewyNawias3').is(":checked") ? ($('#PrawyNawias3').is(":checked") || $('#PrawyNawias4').is(":checked") || $('#PrawyNawias5').is(":checked")) : true;
            IsGood &= $('#LewyNawias4').is(":checked") ? ($('#PrawyNawias4').is(":checked") || $('#PrawyNawias5').is(":checked")) : true;

            LeftCount += $('#LewyNawias1').is(":checked") ? 1 : 0;
            LeftCount += $('#LewyNawias2').is(":checked") ? 1 : 0;
            LeftCount += $('#LewyNawias3').is(":checked") ? 1 : 0;
            LeftCount += $('#LewyNawias4').is(":checked") ? 1 : 0;

            RightCount += $('#PrawyNawias2').is(":checked") ? 1 : 0;
            RightCount += $('#PrawyNawias3').is(":checked") ? 1 : 0;
            RightCount += $('#PrawyNawias4').is(":checked") ? 1 : 0;
            RightCount += $('#PrawyNawias5').is(":checked") ? 1 : 0;

            IsGood &= $('#LewyNawias1').is(":checked") ? ($('#<%=txtPhrase1.ClientID %>').val().trim().length > 0 ? true : false) : true;
            IsGood &= $('#LewyNawias2').is(":checked") ? ($('#<%=txtPhrase2.ClientID %>').val().trim().length > 0 ? true : false) : true;
            IsGood &= $('#LewyNawias3').is(":checked") ? ($('#<%=txtPhrase3.ClientID %>').val().trim().length > 0 ? true : false) : true;
            IsGood &= $('#LewyNawias4').is(":checked") ? ($('#<%=txtPhrase4.ClientID %>').val().trim().length > 0 ? true : false) : true;

            IsGood &= $('#PrawyNawias2').is(":checked") ? ($('#<%=txtPhrase2.ClientID %>').val().trim().length > 0 ? true : false) : true;
            IsGood &= $('#PrawyNawias3').is(":checked") ? ($('#<%=txtPhrase3.ClientID %>').val().trim().length > 0 ? true : false) : true;
            IsGood &= $('#PrawyNawias4').is(":checked") ? ($('#<%=txtPhrase4.ClientID %>').val().trim().length > 0 ? true : false) : true;
            IsGood &= $('#PrawyNawias5').is(":checked") ? ($('#<%=txtPhrase5.ClientID %>').val().trim().length > 0 ? true : false) : true;

            $('#btnSearch').prop('disabled', !(LeftCount == RightCount && IsGood));
        }

        function MakeSearchPhrase() {
            var text = '';
            var ANDText = '';
            var operator = '';

            if (!$('#BasicSearchRadio').is(":checked")) {
                // first rows
                if ($('#<%=txtPhrase1.ClientID %>').val().trim().length > 0) {
                    text += ($('#LewyNawias1').is(":checked") ? '(' : '') + $('#<%=dropType1.ClientID %> option:selected').text() + ' ' + '<%= GetGlobalResourceObject("Language", "contains")%>' + ' "' + $('#<%=txtPhrase1.ClientID %>').val().trim() + '"';

                    operator = $('#<%=dropOperator1.ClientID %> option:selected').text();
                }

                // second row
                if ($('#<%=txtPhrase2.ClientID %>').val().trim().length > 0) {
                    if (text.trim().length > 0)
                        text += ' ' + operator + ' ';

                    text += ($('#LewyNawias2').is(":checked") ? '(' : '') + $('#<%=dropType2.ClientID %> option:selected').text() + ' ' + '<%= GetGlobalResourceObject("Language", "contains")%>' + ' "' + $('#<%=txtPhrase2.ClientID %>').val().trim() + '"' + ($('#PrawyNawias2').is(":checked") ? ')' : '');

                    operator = $('#<%=dropOperator2.ClientID %> option:selected').text();
                }

                // third rows
                if ($('#<%=txtPhrase3.ClientID %>').val().trim().length > 0) {
                    if (text.trim().length > 0)
                        text += ' ' + operator + ' ';

                    text += ($('#LewyNawias3').is(":checked") ? '(' : '') + $('#<%=dropType3.ClientID %> option:selected').text() + ' ' + '<%= GetGlobalResourceObject("Language", "contains")%>' + ' "' + $('#<%=txtPhrase3.ClientID %>').val().trim() + '"' + ($('#PrawyNawias3').is(":checked") ? ')' : '');

                    operator = $('#<%=dropOperator3.ClientID %> option:selected').text();
                }

                // forth row
                if ($('#<%=txtPhrase4.ClientID %>').val().trim().length > 0) {
                    if (text.trim().length > 0)
                        text += ' ' + operator + ' ';

                    text += ($('#LewyNawias4').is(":checked") ? '(' : '') + $('#<%=dropType4.ClientID %> option:selected').text() + ' ' + '<%= GetGlobalResourceObject("Language", "contains")%>' + ' "' + +$('#<%=txtPhrase4.ClientID %>').val().trim() + '"' + ($('#PrawyNawias4').is(":checked") ? ')' : '');

                    operator = $('#<%=dropOperator4.ClientID %> option:selected').text();
                }

                // fifth row
                if ($('#<%=txtPhrase5.ClientID %>').val().trim().length > 0) {
                    if (text.trim().length > 0)
                        text += ' ' + operator + ' ';

                    text += $('#<%=dropType5.ClientID %> option:selected').text() + ' ' + '<%= GetGlobalResourceObject("Language", "contains")%>' + ' "' + $('#<%=txtPhrase5.ClientID %>').val().trim() + '"' + ($('#PrawyNawias5').is(":checked") ? ')' : '');
                }


                // ANDText section
                // language
                if ($('#<%=LangDDL.ClientID %> option:selected').text().trim().length > 0) {
                    ANDText += (text.trim().length > 0 ? ' <%= GetGlobalResourceObject("Language", "and")%> ' : '') + ' ' + '<%= GetGlobalResourceObject("Language", "language")%>' + ' "' + $('#<%=LangDDL.ClientID %> option:selected').text() + '"';
                }

                // country
                if ($('#<%=CountryDDL.ClientID %> option:selected').text().trim().length > 0) {
                    ANDText += (text.trim().length > 0 || ANDText.trim().length > 0 ? ' <%= GetGlobalResourceObject("Language", "and")%> ' : '') + ' ' + '<%= GetGlobalResourceObject("Language", "publicationCountry")%>' + ' "' + $('#<%=CountryDDL.ClientID %> option:selected').text() + '"';
                }

                // freq
                if ($('#<%=FreqDDL.ClientID %> option:selected').text().trim().length > 0) {
                    ANDText += (text.trim().length > 0 || ANDText.trim().length > 0 ? ' <%= GetGlobalResourceObject("Language", "and")%> ' : '') + ' ' + '<%= GetGlobalResourceObject("Language", "frequency")%>' + ' "' + $('#<%=FreqDDL.ClientID %> option:selected').text() + '"';
                }

                // sources
                if ($('#SourcesCheckbox').is(":checked")) {
                    ANDText += (text.trim().length > 0 || ANDText.trim().length > 0 ? ' <%= GetGlobalResourceObject("Language", "and")%> ' : '') + ' ' + '<%= GetGlobalResourceObject("Language", "hasSources")%>' + ' ';
                }

                if (ANDText.trim().length > 0 && text.trim().length > 0)
                    text = '(' + text + ')';
            }

            $('td#SearchPhrase').text(text + ANDText);
        }

        $('body').on('click', 'a.link_click', function () {
            var resId = $(this).attr('rel');
            var name = "#containter" + resId;

            if ($(name).is(':visible')) {
                $(name).hide();
                return;
            }
            else {
                $(name).show();
            }

            $.ajax({
                url: "Details.aspx/GenerateContent",
                data: JSON.stringify({ type: $('#<%=dropPath.ClientID %>').val(), id: resId, toPrint: false }),
                type: "POST",
                dataType: "json",
                async: false,
                contentType: "application/json", // charset=utf-8",
                success: OnSuccess,
                error: OnError
            });

            function OnSuccess(data) {
                var d = data.d;
                $(name).html(d);
            }

            function OnError(xhr, status) {
                alert(status + "\r\n" + xhr.responseText);
            }
        });

        function autoComplete(control) {

        };

        $("#<%=txtPhrase1.ClientID%>").autocomplete({
            source: function (request, response) {
                // if ($('#<%=dropType1.ClientID %>').val() != 'key' || $('#BasicSearchRadio').is(":checked"))
                //     return;
                if ($('#BasicSearchRadio').is(":checked"))
                    return;

                var dictType = $('#<%=dropType1.ClientID %>').val();

                var type = 0;

                if ($('#<%=dropPath.ClientID %>').val() == "books")
                    type = 1;
                else if ($('#<%=dropPath.ClientID %>').val() == "magazines")
                    type = 2;
                else if ($('#<%=dropPath.ClientID %>').val() == "articles")
                    type = 3;

                var text = $("#<%=txtPhrase1.ClientID%>").val();
                //var text = $(".phrase").val();

                $.ajax({
                    url: '<%=ResolveUrl("~/Search.aspx/GetPromptList") %>',
                    data: "{ 'dictType': '" + dictType + "', 'type': '" + type + "', 'text':'" + text + "'}",
                    dataType: "json",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        response($.map(data.d, function (item) {
                            return {
                                label: item,
                                value: item
                            }
                        }))
                    },
                    error: function (response) {
                        alert(response.responseText);
                    },
                    failure: function (response) {
                        alert(response.responseText);
                    }
                });
            },
            select: function (e, i) {
                $(this).val(i.item.value);
            },
            minLength: 1
        });

        $("#<%=txtPhrase2.ClientID%>").autocomplete({
            source: function (request, response) {
                //if ($('#<%=dropType2.ClientID %>').val() != 'key' || $('#BasicSearchRadio').is(":checked"))
                //    return;
                if ($('#BasicSearchRadio').is(":checked"))
                    return;

                var dictType = $('#<%=dropType2.ClientID %>').val();

                var type = 0;

                if ($('#<%=dropPath.ClientID %>').val() == "books")
                    type = 1;
                else if ($('#<%=dropPath.ClientID %>').val() == "magazines")
                    type = 2;
                else if ($('#<%=dropPath.ClientID %>').val() == "articles")
                    type = 3;

                var text = $("#<%=txtPhrase2.ClientID%>").val();

                $.ajax({
                    url: '<%=ResolveUrl("~/Search.aspx/GetPromptList") %>',
                    data: "{ 'dictType': '" + dictType + "', 'type': '" + type + "', 'text':'" + text + "'}",
                    dataType: "json",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        response($.map(data.d, function (item) {
                            return {
                                label: item,
                                value: item
                            }
                        }))
                    },
                    error: function (response) {
                        alert(response.responseText);
                    },
                    failure: function (response) {
                        alert(response.responseText);
                    }
                });
            },
            select: function (e, i) {
                $(this).val(i.item.value);
            },
            minLength: 1
        });

        $("#<%=txtPhrase3.ClientID%>").autocomplete({
            source: function (request, response) {
                //if ($('#<%=dropType3.ClientID %>').val() != 'key' || $('#BasicSearchRadio').is(":checked"))
                //   return;

                if ($('#BasicSearchRadio').is(":checked"))
                    return;

                var dictType = $('#<%=dropType3.ClientID %>').val();

                var type = 0;

                if ($('#<%=dropPath.ClientID %>').val() == "books")
                    type = 1;
                else if ($('#<%=dropPath.ClientID %>').val() == "magazines")
                    type = 2;
                else if ($('#<%=dropPath.ClientID %>').val() == "articles")
                    type = 3;

                var text = $("#<%=txtPhrase3.ClientID%>").val();

                $.ajax({
                    url: '<%=ResolveUrl("~/Search.aspx/GetPromptList") %>',
                    data: "{ 'dictType': '" + dictType + "', 'type': '" + type + "', 'text':'" + text + "'}",
                    dataType: "json",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        response($.map(data.d, function (item) {
                            return {
                                label: item,
                                value: item
                            }
                        }))
                    },
                    error: function (response) {
                        alert(response.responseText);
                    },
                    failure: function (response) {
                        alert(response.responseText);
                    }
                });
            },
            select: function (e, i) {
                $(this).val(i.item.value);
            },
            minLength: 1
        });

        $("#<%=txtPhrase4.ClientID%>").autocomplete({
            source: function (request, response) {
                //if ($('#<%=dropType4.ClientID %>').val() != 'key' || $('#BasicSearchRadio').is(":checked"))
                //return;

                if ($('#BasicSearchRadio').is(":checked"))
                    return;

                var dictType = $('#<%=dropType4.ClientID %>').val();

                var type = 0;

                if ($('#<%=dropPath.ClientID %>').val() == "books")
                    type = 1;
                else if ($('#<%=dropPath.ClientID %>').val() == "magazines")
                    type = 2;
                else if ($('#<%=dropPath.ClientID %>').val() == "articles")
                    type = 3;

                var text = $("#<%=txtPhrase4.ClientID%>").val();

                $.ajax({
                    url: '<%=ResolveUrl("~/Search.aspx/GetPromptList") %>',
                    data: "{ 'dictType': '" + dictType + "', 'type': '" + type + "', 'text':'" + text + "'}",
                    dataType: "json",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        response($.map(data.d, function (item) {
                            return {
                                label: item,
                                value: item
                            }
                        }))
                    },
                    error: function (response) {
                        alert(response.responseText);
                    },
                    failure: function (response) {
                        alert(response.responseText);
                    }
                });
            },
            select: function (e, i) {
                $(this).val(i.item.value);
            },
            minLength: 1
        });

        $("#<%=txtPhrase5.ClientID%>").autocomplete({
            source: function (request, response) {
                //if ($('#<%=dropType5.ClientID %>').val() != 'key' || $('#BasicSearchRadio').is(":checked"))
                if ($('#BasicSearchRadio').is(":checked"))
                    return;

                var dictType = $('#<%=dropType5.ClientID %>').val();

                var type = 0;

                if ($('#<%=dropPath.ClientID %>').val() == "books")
                    type = 1;
                else if ($('#<%=dropPath.ClientID %>').val() == "magazines")
                    type = 2;
                else if ($('#<%=dropPath.ClientID %>').val() == "articles")
                    type = 3;

                var text = $("#<%=txtPhrase5.ClientID%>").val();

                $.ajax({
                    url: '<%=ResolveUrl("~/Search.aspx/GetPromptList") %>',
                    data: "{ 'dictType': '" + dictType + "', 'type': '" + type + "', 'text':'" + text + "'}",
                    dataType: "json",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        response($.map(data.d, function (item) {
                            return {
                                label: item,
                                value: item
                            }
                        }))
                    },
                    error: function (response) {
                        alert(response.responseText);
                    },
                    failure: function (response) {
                        alert(response.responseText);
                    }
                });
            },
            select: function (e, i) {
                $(this).val(i.item.value);
            },
            minLength: 1
        });
    });    
</script>
<table align="center" cellpadding="4px" style="font-family:Calibri;" class="">
	<tr>
		<td></td>
		<td></td>
		<td></td>
		<td></td>
		<td>
			<div class="form-inline">
				<div class="controls-row">                    
					<div class="radio inline">
					  <label>
						<input type="radio" name="optionsRadios" id="BasicSearchRadio" value="basic" 
                            checked="checked" />
						<%= GetGlobalResourceObject("Language", "simpleSearch")%>

					  </label>
					</div>
					&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
					<div class="radio inline">
					  <label>
						<input type="radio" name="optionsRadios" id="AdvancedSearchRadio" value="advanced" />
						<%= GetGlobalResourceObject("Language", "advancedSearch")%>
					  </label>
					</div>
				</div>
			</div>
			<br />
		</td>
	</tr>
	<tr id="Phrase1stTR">
		<td class="AlignToRight"></td>
		<td><asp:DropDownList ID="dropPath" runat="server" class="form-control">
			<asp:ListItem Value="books" Text = "<%$ Resources: Language, books%>" /> 
			<asp:ListItem Value="magazines" Text = "<%$ Resources: Language,magazines %>" />
			<asp:ListItem Value="articles" Text = "<%$ Resources: Language, articles %>" />
			<asp:ListItem Value="normy" Text = "Normy" />
			</asp:DropDownList>
		</td>
		<td class="AlignToRight" id="Phrase1stLabel">&nbsp;</td>
		<td>
			<label class="checkbox-inline" id="LewyNawias1Label" >
				<input id="LewyNawias1" type="checkbox"/>(
			</label>
		</td>
		<td>
			<div class="ui-widget" style="text-align:left">
				<asp:TextBox ID="txtPhrase1" runat="server" placeholder="<%$ Resources: Language, enterPhrase %>" class="phrase form-control" data-toggle="tooltip" data-placement="top" title="DD-MM-RRRR" Width="370px" Font-Size="Small" />
			</div>
		</td>
		<td>
			<asp:DropDownList ID="dropType1" runat="server" Width="160px" class="form-control"></asp:DropDownList>
		</td>
		<td>
			
		</td>
		<td><asp:DropDownList ID="dropOperator1" runat="server" class="form-control">
			<asp:ListItem Value="OR" Text = "<%$ Resources: Language, or%>" />
			<asp:ListItem Value="AND" Text = "<%$ Resources: Language, and%>" />
			</asp:DropDownList>
		</td>
		<td>
			<input id="btnSearch" type="submit" class="btn btn-default" value="<%= GetGlobalResourceObject("Language", "search")%>" />
		</td>
		<td>            
			<input id="ClearButton" type="button" class="btn btn-default" value="<%= GetGlobalResourceObject("Language", "clearCriteria")%>" />
		</td>        
	</tr>
	<tr id="Phrase2ndTR">
		<td></td>
		<td>&nbsp;</td>
		<td class="AlignToRight">&nbsp;</td>
		<td>
			<label class="checkbox-inline">
				<input id="LewyNawias2" type="checkbox" />(
			</label>
		</td>        
		<td>
			<asp:TextBox ID="txtPhrase2" runat="server" class="phrase form-control" data-toggle="tooltip" data-placement="top" title="DD-MM-RRRR" Width="370px" />
		</td>
		<td>
			<asp:DropDownList ID="dropType2" runat="server" Width="160px" class="form-control">
			
			</asp:DropDownList>
		</td>
		<td>
			<label class="checkbox-inline">
				)<input id="PrawyNawias2" type="checkbox" />
			</label>
		</td>
		<td><asp:DropDownList ID="dropOperator2" runat="server" class="form-control">
			<asp:ListItem Value="OR" Text = "<%$ Resources: Language, or%>" />
			<asp:ListItem Value="AND" Text = "<%$ Resources: Language, and%>" />
			</asp:DropDownList>
		</td>    
		<td></td>    
		<td rowspan="4">
			<!--Nawiasy służą do wymuszenia kolejności<br />
			operacji logicznych na zbiorach danych.<br />
			Najpierw są wykonywane iloczyny logiczne (i)<br />
			od lewej do prawej strony, <br/> a następnie sumy logiczne (lub).-->
		</td>
	</tr>
	<tr id="Phrase3rdTR">
		<td class="style1"></td>
		<td class="style1"></td>
		<td class="AlignToRight">&nbsp;</td>
		<td>
			<label class="checkbox-inline">
				<input id="LewyNawias3" type="checkbox" />(
			</label>
		</td> 
		<td><asp:TextBox ID="txtPhrase3" runat="server" class="phrase form-control" data-toggle="tooltip" data-placement="top" title="DD-MM-RRRR" Width="370px" />
		</td>
		<td>
			<asp:DropDownList ID="dropType3" runat="server" Width="160px" class="form-control">
			</asp:DropDownList>
		</td>
		<td>
			<label class="checkbox-inline">
				)<input id="PrawyNawias3" type="checkbox" />
			</label>
		</td>
		<td>
			<asp:DropDownList ID="dropOperator3" runat="server" class="form-control">
			<asp:ListItem Value="OR" Text = "<%$ Resources: Language, or%>" />
			<asp:ListItem Value="AND" Text = "<%$ Resources: Language, and%>" />
			</asp:DropDownList>
		</td>
	</tr>
	<tr id="Phrase4thTR">
		<td></td>
		<td></td>
		<td class="AlignToRight">&nbsp;</td>
		<td>
			<label class="checkbox-inline">
				<input id="LewyNawias4" type="checkbox" />(
			</label>
		</td> 
		<td>
			<asp:TextBox ID="txtPhrase4" runat="server" class="phrase form-control" data-toggle="tooltip" data-placement="top" title="DD-MM-RRRR" Width="370px" />
		</td>
		<td>
			<asp:DropDownList ID="dropType4" runat="server" Width="160px" class="form-control"></asp:DropDownList>
		</td>
		<td>
			<label class="checkbox-inline">
				)<input id="PrawyNawias4" type="checkbox" />
			</label>
		</td>
		<td><asp:DropDownList ID="dropOperator4" runat="server" class="form-control">
			<asp:ListItem Value="OR" Text = "<%$ Resources: Language, or%>" />
			<asp:ListItem Value="AND" Text = "<%$ Resources: Language, and%>" />
			</asp:DropDownList>
		</td>
	</tr>
	<tr id="Phrase5thTR">
		<td></td>
		<td></td>
		<td class="AlignToRight">&nbsp;</td>
		<td>
			
		</td> 
		<td>            
			<asp:TextBox ID="txtPhrase5" runat="server" class="phrase form-control" data-toggle="tooltip" data-placement="top" title="DD-MM-RRRR" Width="370px" />
		</td>
		<td>
			<asp:DropDownList ID="dropType5" runat="server" Width="160px" class="form-control"></asp:DropDownList>
		</td>
		<td>
			<label class="checkbox-inline">
				)<input id="PrawyNawias5" type="checkbox" />
			</label>            
		</td>
		<td></td>
	</tr>    
	<tr id="LangTR">
		<td></td>
		<td></td>
		<td id="langLabel" class="AlignToRight" ><%= GetGlobalResourceObject("Language", "language")%></td>
		<td></td>
		<td id="langCmbx">
			
			<asp:DropDownList ID="LangDDL" runat="server" Width="370px" class="form-control">
			</asp:DropDownList>
			
		</td>        
	</tr>
	<tr id="CountryTR">
		<td></td>
		<td></td>
		<td id="CountryLabel" class="AlignToRight"><%= GetGlobalResourceObject("Language", "publicationCountry")%></td>
		<td></td>
		<td id="CountryDDLTD">            
			<asp:DropDownList ID="CountryDDL" runat="server" Width="370px" class="form-control">
			</asp:DropDownList>            
		</td>
	</tr>
	<tr id="FreqTR">
		<td></td>
		<td></td>
		<td id="FreqLabel" class="AlignToRight"><%= GetGlobalResourceObject("Language", "frequency")%></td>
		<td></td>
		<td id="FreqDDLTD">            
			<asp:DropDownList ID="FreqDDL" runat="server" Width="370px" class="form-control">
			</asp:DropDownList>
		</td>
	</tr>
	<tr id="SortTR">
		<td></td>
		<td></td>
		<td><%= GetGlobalResourceObject("Language", "sortBy")%></td>
		<td></td>
		<td>
			<select id="SortDDL" name="D1" style="width:370px" class="form-control">
				<option value="title"><%= GetGlobalResourceObject("Language", "title")%></option>
				<option value="author"><%= GetGlobalResourceObject("Language", "author")%></option>
				<option value="syg"><%= GetGlobalResourceObject("Language", "signature")%></option>
				<option value="year_asc"><%= GetGlobalResourceObject("Language", "yearOfPublishing")%> (<%=GetGlobalResourceObject("Language", "ascending")%>) </option>
				<option value="year_desc"><%= GetGlobalResourceObject("Language", "yearOfPublishing")%> (<%=GetGlobalResourceObject("Language", "descending")%>) </option>
			</select></td>
	</tr>
	<tr id="SourcesTR">
		<td></td>
		<td></td>
		<td></td>
		<td></td>
		<td>
			<label class="checkbox-inline">
				<input id="SourcesCheckbox" type="checkbox" /><%= GetGlobalResourceObject("Language", "searchWithSources")%>
			</label>
		</td>
	</tr>
	<tr><td><br /></td></tr>
	<tr>
		<td><b><%= GetGlobalResourceObject("Language", "phraseSearched")%>:</b>&nbsp;</td>
		<td colspan="9" id="SearchPhrase"></td>
	</tr>
</table>
<!--
<asp:HiddenField ID="Type1HiddenField" runat="server" />
<asp:HiddenField ID="Type2HiddenField" runat="server" />
<asp:HiddenField ID="Type3HiddenField" runat="server" />
<asp:HiddenField ID="Type4HiddenField" runat="server" />
<asp:HiddenField ID="Type5HiddenField" runat="server" />
-->