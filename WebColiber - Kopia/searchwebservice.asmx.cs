using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI.WebControls;
using WebColiber.App_GlobalResources;

namespace WebColiber
{
	/// <summary>
	/// Summary description for SearchWebService
	/// </summary>
	//[WebService(Namespace = "http://tempuri.org/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[System.ComponentModel.ToolboxItem(false)]
	// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
	[System.Web.Script.Services.ScriptService]
	public class SearchWebService : System.Web.Services.WebService
	{
		[WebMethod(EnableSession = true)]
		[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
		public string GetData(string Type, string[] Values, string[] ANDValues, int StartIndex, int Count, bool Basic, string Sort)
		{            
			SqlCommand Command = new SqlCommand();

			List<string[]> Lista = new List<string[]>();
			List<string[]> ANDLista = new List<string[]>();

			List<ListItem> CriteriaList = Search.GetItemsList(Type);

			if (Basic)
			{               
				if(Values.Length > 0 && !string.IsNullOrEmpty(Values[0]))
				{
					foreach (ListItem item in CriteriaList)
						Lista.Add(new string[]{Values[0].Trim().Replace("\"", ""), item.Value, "or", "", ""});
				}

				for (int i = 0; i < ANDValues.Length; i += 5)
				{
					if (!string.IsNullOrEmpty(ANDValues[i].Trim()) && ANDValues[i].Trim() != "-1" && ANDValues[i].Trim() != "0")
						ANDLista.Add(new string[] { ANDValues[i].Trim().Replace("\"", ""), ANDValues[i + 1].Trim(), ANDValues[i + 2], Values[i + 3].Trim(), ANDValues[i + 4].Trim() });
				} 
			}
			else
			{
				for (int i = 0; i < Values.Length; i += 5)
				{
					if (!string.IsNullOrEmpty(Values[i].Trim()) && Values[i].Trim() != "-1" && Values[i].Trim() != "0")
						Lista.Add(new string[] { Values[i].Trim().Replace("\"", ""), Values[i + 1].Trim(), Values[i + 2].Trim(), Values[i + 3].Trim(), Values[i + 4].Trim() });
				}                

				for (int i = 0; i < ANDValues.Length; i += 5)
				{
					if (!string.IsNullOrEmpty(ANDValues[i].Trim()) && ANDValues[i].Trim() != "-1" && ANDValues[i].Trim() != "0")
						ANDLista.Add(new string[] { ANDValues[i].Trim().Replace("\"", ""), ANDValues[i + 1].Trim(), ANDValues[i + 2], Values[i + 3].Trim(), ANDValues[i + 4].Trim() });
				}                
			}
			
			Type = Type.ToLower().Trim();

			// select items only in search criteria
			Lista = Lista.Where(x => CriteriaList.Select(c => c.Text == x[0]).Count() > 0).ToList();

			// choose type
			switch (Type)
			{
				case "books": Command = getBooksQuery(Lista, ANDLista, StartIndex, Count, Sort); break;
				case "articles": Command = getArticlesQuery(Lista, ANDLista, StartIndex, Count, Sort); break;
				case "magazines": Command = getMagazinesQuery(Lista, ANDLista, StartIndex, Count); break;
			}

			StringBuilder Output = new StringBuilder();
			StringBuilder Temp = new StringBuilder();

			DataTable Dt = CommonFunctions.ReadData(Command, ref Settings.ColiberConnection);

			if (Dt.Rows.Count == 0)
			{
				Output.Append("<div id='ResultCount' style=\"visibility:hidden\">0</div>");

				Output.Append(Language.noSearchResults);
			}
			else
			{
				Output.Append("<div id='ResultCount' style=\"visibility:hidden\">" + Dt.Rows[0]["rows_count"].ToString() + "</div>");

				Output.Append("<table id=\"ResultTab\" style=\"font-family:Calibri; align=\"left\";\" border=0 rules='rows' class=\"table table-striped table-bordered table-hover table-condensed\">");
				Output.Append("<tr>");
				Output.Append("<th align=\"center\" style='padding-left: 10px; padding-right: 10px; width: 20px;'>" + Language.oridinalShort + "</th>");

				if (Type == "books")
					Output.Append("<th align=\"center\" style='padding-left: 10px; padding-right: 10px; width:30px'>" + Language.copiesOf + "</th>");

				//if (Type == "books" && HttpContext.Current.Session["CanOrder"] != null && Boolean.Parse(HttpContext.Current.Session["CanOrder"] as string))
				Output.Append("<th align=\"center\" style='padding-left: 10px; padding-right: 10px; width:30px'>" + Language.check + "</td>");                                

				if (Type == "books" || Type == "articles")
				{
					Output.Append("<th align=\"center\" id='title_thead' style='padding-left: 10px; padding-right: 10px;'><a href='#'>" + Language.title + "</a></th>");
					Output.Append("<th align=\"center\" id='author_thead' style='padding-left: 10px; padding-right: 10px; '><a href='#'>" + Language.author + "</a></th>");                    
				}
				else
					Output.Append("<th align=\"center\" id='title_thead' style='padding-left: 10px; padding-right: 10px;'>" + Language.title + "</th>");

				if (Type == "books")
				{
					Output.Append("<th align=\"center\" id='publish_year_thead' style='padding-left: 10px; padding-right: 10px; width:130px'><a href='#'>" + Language.yearOfPublishing + "</a></th>");                    
				}

				Output.Append("</tr>");

				for (int i = 0; i < Dt.Rows.Count; i++)
				{
					Temp.Clear();
					Temp.Append("<tr>");

					// lp.
					Temp.Append("<td align=\"center\">" + Dt.Rows[i]["OrderID"].ToString() + "</td>");

					if (Type == "books")
					{
						// ilość dostępna
						if (Dt.Rows[i]["ilosc"].ToString() == "0")
							Temp.Append("<td align=\"center\"><font color=\"red\">" + Dt.Rows[i]["ilosc"].ToString() + Language.cpy + " </font></td>");
						else if(Dt.Rows[i]["ilosc"].ToString() == "-1")
							Temp.Append("<td align=\"center\"> " + Language.noCpy + " </td>");
						else
							Temp.Append("<td align=\"center\"><font color=\"green\">" + Dt.Rows[i]["ilosc"].ToString() + Language.cpy + " </font></td>");
					}
					// checkbox
					//if (Type == "books" && HttpContext.Current.Session["CanOrder"] as string != null && Boolean.Parse(HttpContext.Current.Session["CanOrder"] as string))
					if (Dt.Rows[i]["ilosc"].ToString() != "-1")
						Temp.Append("<td align=\"center\"><input id=\"Checkbox" + Dt.Rows[i]["kod"].ToString() + "\" class=\"itemCheckbox\" type=\"checkbox\" OnChange=\"lookCheckboxes(this);\"/></td>");
					else
						Temp.Append("<td align=\"center\"></td>");

					//tytuł
					//Temp += "<td><a onclick=\"window.open(\"google.pl\", \"aaa\", \"height=200,width=200\"); return false;\" href=\"Details.aspx?id=" + Dt.Rows[i]["kod"].ToString() + "&type=" + Dt.Rows[i]["type"].ToString() + "\"> " + Dt.Rows[i]["tytul"].ToString() + "</a></td>";
					//Temp += "<td><a onclick=\"window.open('Details.aspx?id=" + Dt.Rows[i]["kod"].ToString() + "&type=" + Dt.Rows[i]["type"].ToString() + "','','width=1000,height=800,scrollbars=yes');return false;\" href=\"Details.aspx?id=" + Dt.Rows[i]["kod"].ToString() + "&type=" + Dt.Rows[i]["type"].ToString() + "\" >" + Dt.Rows[i]["tytul"].ToString() + "</a></td>";
					Temp.Append("<td><a class='link_click' href=\"Details.aspx?id=" + Dt.Rows[i]["kod"].ToString() + "&type=" + Dt.Rows[i]["type"].ToString() + "\" onclick=\" return false;\" rel=\"" + Dt.Rows[i]["kod"].ToString() + "\">" + Dt.Rows[i]["tytul"].ToString() + "</a></td>");

					if (Type == "books" || Type == "articles")
					{
						//Temp += "<td align=\"left\" style=\"width:auto; white-space:nowrap;\">" + Dt.Rows[i]["autor"].ToString() + "</td>";
						Temp.Append("<td align=\"left\" style=\"width:auto; \">" + Dt.Rows[i]["autor"].ToString() + "</td>");
					}

					if (Type == "books")
					{                        
						Temp.Append("<td align=\"center\">" + Dt.Rows[i]["rok_wydania"].ToString() + "</td>");
					}

					Temp.Append("</tr>");

					Temp.Append("<tr><td colspan=10><div id='containter" + Dt.Rows[i]["kod"].ToString() + "' style='display:none;'></div></td></tr>");

					

					Output.Append(Temp.ToString());
				}

				Output.Append("</table>");
			}

			return Output.ToString();
		}

		#region Books
		public SqlCommand getBooksQuery(List<string[]> Values, List<string[]> ANDValues, int StartIndex, int Count, string Sort)
		{
			SqlCommand Command = new SqlCommand();
			string dropTables = "";
			string SearchCommand = " ;with result AS" + Environment.NewLine +
									"(" + Environment.NewLine +
									"SELECT DISTINCT ksiazki_new.kod, syg_expand.syg_expand FROM ksiazki_new" + Environment.NewLine +
									//"INNER JOIN sygnat ON sygnat.kod = ksiazki_new.kod  " + Environment.NewLine +
									"OUTER APPLY (SELECT TOP 1 syg_expand FROM sygnat WHERE sygnat.kod = ksiazki_new.kod) syg_expand";

			Command.CommandText = "DECLARE @ResultOrder TABLE  " + Environment.NewLine +
								  "(     OrderID int identity(1,1) not null primary key clustered," + Environment.NewLine +
								  "      ResultID int," + Environment.NewLine +
								  "      tytul varchar(1024)    " + Environment.NewLine +
								  ");" + Environment.NewLine;

			string[] temp;
			string Phrase;
			string Type;
			string Operator;
			string LewyNawias;
			string PrawyNawias;

			if (Values.Count > 0)
				SearchCommand += " WHERE (";

			for (int i = 0; i < Values.Count; i++)
			{
				temp = Values[i];

				Phrase = temp[0].Trim();
				//Phrase = string.Join(" AND", Phrase.Split(' ').Where(x => x.Trim().Length > 1).Select(x => "\"" + x.Trim() + "*\""));
				Phrase = string.Join(" AND", Phrase.Replace(".", " ").Split(' ').Where(x => x.Trim().Length > 1).Select(x => "\"" + x.Trim() + "\""));

				//Phrase = "\"" + Phrase + "\"";

				if (Phrase.Trim().Length == 0)
					Phrase = "\"" + temp[0].Trim() + "*\"";

				Type = temp[1].Trim().ToLower();
				Operator = temp[2].Trim();
				LewyNawias = temp[3].Trim();
				PrawyNawias = temp[4].Trim();

				switch (Type)
				{                    
					case "authorslastname": //Command.CommandText += "EXISTS (SELECT 1 FROM list_aut_k INNER JOIN ksiazki_autor_new ON ksiazki_autor_new.id_autor = list_aut_k.id_aut AND ksiazki_autor_new.id_ksiazka = ksiazki_new.kod WHERE CONTAINS(imie_nazwisko, @fraza" + i + ")) OR EXISTS (SELECT 1 FROM list_aut_k INNER JOIN ksiazki_wautor_new ON ksiazki_wautor_new.id_wautor = list_aut_k.id_aut AND ksiazki_wautor_new.id_ksiazka = ksiazki_new.kod WHERE CONTAINS(imie_nazwisko, @fraza" + i + ")) " + Environment.NewLine;
											Command.CommandText +=  ";with aut AS" + Environment.NewLine +
																	"(" + Environment.NewLine +
																	"	SELECT id_ksiazka AS kod FROM list_aut_k INNER JOIN ksiazki_autor_new ON ksiazki_autor_new.id_autor = list_aut_k.id_aut WHERE CONTAINS(imie_nazwisko, @fraza" + i + ")" + Environment.NewLine +
																	"	union" + Environment.NewLine +
																	"	SELECT id_ksiazka AS kod FROM list_aut_k INNER JOIN ksiazki_wautor_new ON ksiazki_wautor_new.id_wautor = list_aut_k.id_aut WHERE CONTAINS(imie_nazwisko, @fraza" + i + ")" + Environment.NewLine +
																	")" + Environment.NewLine +
																	"SELECT kod INTO #aut" + i + " FROM aut " + Environment.NewLine;
											Command.Parameters.AddWithValue("@fraza" + i, Phrase.ToUpper());
											SearchCommand += LewyNawias + " ksiazki_new.kod in (select kod from #aut" + i + ")" + PrawyNawias;
											dropTables += "drop table #aut" + i + "; ";
											break;                    
					case "title": //Command.CommandText += "CONTAINS (tytul_gl, @fraza" + i + ")" + Environment.NewLine;
											Command.CommandText += " ;with tytultab AS" + Environment.NewLine +
																	"(" + Environment.NewLine +
																	"	SELECT ksiazki_new.kod " + Environment.NewLine +
																	"	FROM ksiazki_new  " + Environment.NewLine +
																	"	WHERE CONTAINS (tytul_gl, @fraza" + i + ")" + Environment.NewLine +
																	//"	WHERE CONTAINS (tytul_gl, 'FORMSOF(THESAURUS , @fraza" + i + ")')" + Environment.NewLine +
																	")" + Environment.NewLine +
																	" SELECT kod INTO #tytultab" + i + " FROM tytultab " + Environment.NewLine;
											Command.Parameters.AddWithValue("@fraza" + i, Phrase);
											SearchCommand += LewyNawias + " ksiazki_new.kod in (select kod from #tytultab" + i + ")" + PrawyNawias;
											dropTables += "drop table #tytultab" + i + "; ";
											break;                    
					case "key": //Command.CommandText += "EXISTS (SELECT 1 FROM ksi_klu INNER JOIN klucze_k ON ksi_klu.kody = klucze_k.kody AND ksi_klu.kod = ksiazki_new.kod WHERE CONTAINS (klucze_k.klucze, @fraza" + i + ")) " + Environment.NewLine;
											Command.CommandText +=  " ;with klucze AS(" + Environment.NewLine +
																	"	SELECT kod FROM ksi_klu INNER JOIN klucze_k ON ksi_klu.kody = klucze_k.kody WHERE CONTAINS (klucze_k.klucze, @fraza" + i + "))" + Environment.NewLine +
																	"SELECT kod INTO #klucze" + i + " FROM klucze " + Environment.NewLine;
											SearchCommand += LewyNawias + " ksiazki_new.kod in (select kod from #klucze" + i + ")" + PrawyNawias;
											Command.Parameters.AddWithValue("@fraza" + i, Phrase);
											dropTables += "drop table #klucze" + i + "; ";
											break;                    
					case "syg": //Command.CommandText += "CONTAINS (syg, @fraza" + i + ")" + Environment.NewLine;
											Command.CommandText += " ;with syg AS(" + Environment.NewLine +
													//"SELECT kod AS kod FROM sygnat WHERE CONTAINS(syg, @fraza" + i + "))" + Environment.NewLine +
													"SELECT kod AS kod FROM sygnat WHERE syg = @fraza" + i + ")" + Environment.NewLine +
												"SELECT kod INTO #syg" + i + " FROM syg" + Environment.NewLine;
											Command.Parameters.AddWithValue("@fraza" + i, temp[0].Trim()/*Phrase*/);
											SearchCommand += LewyNawias + " ksiazki_new.kod in (select kod from #syg" + i + ")" + PrawyNawias;
											dropTables += "drop table #syg" + i + "; ";
											break;                    
					case "publisher": //Command.CommandText += "EXISTS (SELECT 1 FROM wydawca_k WHERE CONTAINS((nazwa_w, sk_nazwa_w), @fraza" + i + ") AND (id_wyd1 = id_wydawcy OR id_wyd2 = id_wydawcy))" + Environment.NewLine;
											Command.CommandText +=  " ;with wydawcy AS(" + Environment.NewLine +
																	"	SELECT kod from ksiazki_new WHERE id_wyd1 in (SELECT id_wydawcy FROM wydawca_k WHERE CONTAINS((nazwa_w, sk_nazwa_w), @fraza" + i + ")) OR id_wyd2 in (SELECT id_wydawcy FROM wydawca_k WHERE CONTAINS((nazwa_w, sk_nazwa_w), @fraza" + i + ")))" + Environment.NewLine +
																	"SELECT kod INTO #wydawcy" + i + " FROM wydawcy " + Environment.NewLine;
											Command.Parameters.AddWithValue("@fraza" + i, Phrase);
											SearchCommand += LewyNawias + " ksiazki_new.kod in (select kod from #wydawcy" + i + ")" + PrawyNawias;
											dropTables += "drop table #wydawcy" + i + "; ";
											break;                    
					case "ukd": //Command.CommandText += "CONTAINS(ukd, @fraza" + i + ")" + Environment.NewLine;
											Command.CommandText += " ;with ukd AS (" + Environment.NewLine +
																	"	SELECT ksiazki_new.kod " + Environment.NewLine +
																	"	FROM ksiazki_new  	" + Environment.NewLine +
																	"	WHERE CONTAINS (ukd, @fraza" + i + "))" + Environment.NewLine +
																	" SELECT kod INTO #ukd" + i + " FROM ukd " + Environment.NewLine;
											Command.Parameters.AddWithValue("@fraza" + i, Phrase);
											SearchCommand += LewyNawias + " ksiazki_new.kod in (select kod from #ukd" + i + ")" + PrawyNawias;
											dropTables += "drop table #ukd" + i + "; ";
											break;                    
					case "serie": //Command.CommandText += "EXISTS (SELECT 1 FROM ksi_ser INNER JOIN serie ON serie.kody = ksi_ser.kody WHERE CONTAINS(tyt_serii, @fraza" + i + ") AND ksiazki_new.kod = ksi_ser.kod)" + Environment.NewLine;
											Command.CommandText += ";with serietab AS(" + Environment.NewLine +
																	"	SELECT kod FROM ksi_ser INNER JOIN serie ON serie.kody = ksi_ser.kody WHERE CONTAINS(tyt_serii, @fraza" + i + "))" + Environment.NewLine +
																	"SELECT kod INTO #serietab" + i + " FROM serietab " + Environment.NewLine;
											Command.Parameters.AddWithValue("@fraza" + i, Phrase.ToUpper());
											SearchCommand += LewyNawias + " ksiazki_new.kod in (select kod from #serietab" + i + ")" + PrawyNawias;
											dropTables += "drop table #serietab" + i + "; ";
											break;                    
					case "instyt": //Command.CommandText += "EXISTS (SELECT 1 FROM instyt WHERE CONTAINS(nazwa_inst, @fraza" + i + ") AND instyt.kod = ksiazki_new.kod)" + Environment.NewLine;
											Command.CommandText +=  " ;with inst AS(" + Environment.NewLine +
																	"	SELECT kod FROM instyt WHERE CONTAINS(nazwa_inst, @fraza" + i + "))" + Environment.NewLine +
																	 "SELECT kod INTO #inst" + i + " FROM inst " + Environment.NewLine;
											Command.Parameters.AddWithValue("@fraza" + i, Phrase.ToUpper());
											SearchCommand += LewyNawias + " ksiazki_new.kod in (select kod from #inst" + i + ")" + PrawyNawias;
											dropTables += "drop table #inst" + i + "; ";
											break;
					case "publish_year":
											//Command.CommandText += "EXISTS (SELECT 1 FROM instyt WHERE CONTAINS(nazwa_inst, @fraza" + i + ") AND instyt.kod = ksiazki_new.kod)" + Environment.NewLine;
											Command.CommandText += " ;with rok_wydania AS(" + Environment.NewLine +
																	"	SELECT kod FROM ksiazki_new WHERE rok_wyd = @fraza" + i + ")" + Environment.NewLine +
																	 "SELECT kod INTO #rok_wydania" + i + " FROM rok_wydania " + Environment.NewLine;
											Command.Parameters.AddWithValue("@fraza" + i, Phrase.Where(x => char.IsDigit(x)).Any() ? String.Join("", Phrase.Where(x => char.IsDigit(x))) : "-1");
											SearchCommand += LewyNawias + " ksiazki_new.kod in (select kod from #rok_wydania" + i + ")" + PrawyNawias;
											dropTables += "drop table #rok_wydania" + i + "; ";
											break;

					case "entry_date": Command.CommandText += ";with data_tab as( SELECT kod FROM sygnat WHERE CAST(data_zap AS date) = @fraza" + i + ")" + Environment.NewLine +
													"SELECT kod INTO #data_tab" + i + " FROM data_tab;" + Environment.NewLine;
											string date = String.Join("", Phrase.Where(x => char.IsDigit(x)));
											DateTime dateTime = new DateTime();
											DateTime.TryParseExact(date, "ddMMyyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime);
											Command.Parameters.AddWithValue("@fraza" + i, dateTime.ToString("yyyyMMdd"));
											SearchCommand += LewyNawias + " ksiazki_new.kod in (select kod from #data_tab" + i + ")" + PrawyNawias + Environment.NewLine;
											dropTables += "drop table #data_tab" + i + "; ";
											break;
				}

				if (i + 1 < Values.Count)
					SearchCommand += Operator.ToLower() == "and" ? " AND " : " OR ";
			}            

			if (Values.Count > 0)
				SearchCommand += ") " + Environment.NewLine;            

			// conditions with AND only
			if (ANDValues.Count > 0 && Values.Count > 0)
				SearchCommand += " AND ";
			else if(ANDValues.Count > 0)
				SearchCommand += " WHERE ";

			for (int i = 0; i < ANDValues.Count; i++)
			{
				temp = ANDValues[i];

				Phrase = temp[0].Trim();
				Type = temp[1].Trim().ToLower();
				Operator = temp[2].Trim();

				switch (Type)
				{
					case "lang": SearchCommand += "EXISTS (SELECT 1 FROM ksiazki_jezyki_new INNER JOIN jezyki ON jezyki.id = ksiazki_jezyki_new.id_jezyk AND ksiazki_jezyki_new.id_ksiazki = ksiazki_new.kod WHERE id_jezyk = @fraza_" + i + ")" + Environment.NewLine;
						Command.Parameters.AddWithValue("@fraza_" + i, Phrase.ToUpper());
						break;
					case "sources": SearchCommand += "EXISTS (SELECT 1 FROM documents WHERE kod = ksiazki_new.kod AND rodzaj_zasobu = 1)" + Environment.NewLine;
						break;
				}

				if (i + 1 < ANDValues.Count)
					SearchCommand += Operator.ToLower() == "and" ? " AND " : " OR ";
			}

			SearchCommand += ") " + Environment.NewLine;

			Command.CommandText += SearchCommand + Environment.NewLine;

			Command.CommandText += " INSERT INTO @ResultOrder" + Environment.NewLine +
								   " SELECT ksiazki_new.kod, '' " + Environment.NewLine +
								   " FROM ksiazki_new" + Environment.NewLine +
								   " INNER JOIN result ON result.kod = ksiazki_new.kod" + Environment.NewLine;

			switch (Sort.ToLower().Trim())
			{                
				case "syg":         Command.CommandText += " ORDER BY result.syg_expand;" + Environment.NewLine; break;
				case "year_desc":   Command.CommandText += " ORDER BY CASE WHEN ksiazki_new.rok_wyd IS NULL THEN 0 ELSE ksiazki_new.rok_wyd END desc;" + Environment.NewLine; break;
				case "year_asc":    Command.CommandText += " ORDER BY CASE WHEN ksiazki_new.rok_wyd IS NULL THEN 9999 ELSE ksiazki_new.rok_wyd END asc;" + Environment.NewLine; break;
				case "author":      Command.CommandText += " OUTER APPLY (SELECT TOP 1 imie_nazwisko AS nazwisko FROM list_aut_k " + Environment.NewLine +
															"   INNER JOIN ksiazki_autor_new on list_aut_k.id_aut = ksiazki_autor_new.id_autor" + Environment.NewLine +
															"   WHERE ksiazki_autor_new.id_ksiazka = ksiazki_new.kod ORDER BY nazwisko) AS nazwisko" + Environment.NewLine +
															"ORDER BY CASE WHEN nazwisko IS NULL THEN 1 ELSE 0 END, nazwisko, ksiazki_new.tytul_gl; " + Environment.NewLine;
									break;
				
				case "title":
				default:            Command.CommandText += " ORDER BY ksiazki_new.tytul_gl;" + Environment.NewLine; break;
			}
								   //" WHERE LEN(ISNULL(ksiazki_new.tytul_gl,'')) > 0" + Environment.NewLine +
								   //" ORDER BY ksiazki_new.tytul_gl;" + Environment.NewLine +
			/*Command.CommandText += " SELECT OrderID, tytul, ResultID AS kod, 'Book' AS type, (SELECT COUNT(*) FROM sygnat WHERE sygnat.kod = ResultID AND wypozycz = 0) AS ilosc, (SELECT COUNT(*) FROM @ResultOrder) AS rows_count" + Environment.NewLine +
								   " FROM @ResultOrder " + Environment.NewLine +
								   " WHERE OrderID >= @start AND OrderID < @end ORDER BY OrderID;" + Environment.NewLine;*/

			//Command.CommandText += " SELECT OrderID, ResultID AS kod, LTRIM(RTRIM(ksiazki_new.tytul_gl)) AS tytul, ksiazki_new.rok_wyd AS rok_wydania, 'Book' AS type, (SELECT COUNT(*) FROM sygnat WHERE sygnat.kod = ResultID AND wypozycz = 0) AS ilosc, (SELECT COUNT(*) FROM @ResultOrder) AS rows_count, " + Environment.NewLine +                                   
			Command.CommandText += " SELECT OrderID, ResultID AS kod, LTRIM(RTRIM(ksiazki_new.tytul_gl)) AS tytul, ksiazki_new.rok_wyd AS rok_wydania, 'Book' AS type,  CASE WHEN EXISTS (SELECT 1 FROM sygnat WHERE kod = ResultID) THEN (SELECT COUNT(*) FROM sygnat WHERE sygnat.kod = ResultID AND wypozycz = 0)ELSE -1 END AS ilosc, (SELECT COUNT(*) FROM @ResultOrder) AS rows_count, " + Environment.NewLine +

			
								   //" ('<ul>' + (SELECT stuff((select LTRIM(RTRIM(nazwisko)) + ' ' + LTRIM(RTRIM(imie)) FROM list_aut_k INNER JOIN ksiazki_autor_new ON ksiazki_autor_new.id_autor = list_aut_k.id_aut WHERE ksiazki_autor_new.id_ksiazka = ksiazki_new.kod ORDER BY rating for xml path('li')),1,0,'')) + '</ul>') as autor  " + Environment.NewLine +
								   " ('<ul>' + ISNULL((SELECT stuff((select LTRIM(RTRIM(nazwisko)) + ' ' + LTRIM(RTRIM(imie)) FROM list_aut_k INNER JOIN ksiazki_autor_new ON ksiazki_autor_new.id_autor = list_aut_k.id_aut WHERE ksiazki_autor_new.id_ksiazka = ksiazki_new.kod ORDER BY rating for xml path('li')),1,0,'')), '') + ISNULL((SELECT stuff((select LTRIM(RTRIM(nazwisko)) + ' ' + LTRIM(RTRIM(imie)) FROM list_aut_k INNER JOIN ksiazki_wautor_new ON ksiazki_wautor_new.id_wautor = list_aut_k.id_aut WHERE ksiazki_wautor_new.id_ksiazka = ksiazki_new.kod ORDER BY rating for xml path('li')),1,0,'')), '') + '</ul>') as autor " + Environment.NewLine +
								   
								   " FROM @ResultOrder " + Environment.NewLine +
								   " INNER JOIN ksiazki_new ON ksiazki_new.kod = ResultID" + Environment.NewLine +
								   " WHERE OrderID >= @start AND OrderID < @end ORDER BY OrderID;" + Environment.NewLine;

			Command.CommandText += dropTables;
			Command.Parameters.AddWithValue("@start", StartIndex);
			Command.Parameters.AddWithValue("@end", StartIndex + Count);

			//Command.CommandText = "SELECT top 50 '1' AS OrderID, 1 as ilosc, 1 as kod, 'aaaaa' as tytul, '50' as rows_count, 'book' as type from ksiazki_new;";

			return Command;
		}
		#endregion

		#region old_Books
		/*public SqlCommand getBooksSubQuery(List<string[]> Values, List<string[]> ANDValues)
		{
			SqlCommand Command = new SqlCommand();
			Command.CommandText = "";

			string[] temp;
			string Phrase;
			string Type;
			string Operator;

			if (Values.Count > 0)
				Command.CommandText += " AND (";

			for (int i = 0; i < Values.Count; i++)
			{
				temp = Values[i];

				Phrase = temp[0].Trim();
				Phrase = string.Join(" AND", Phrase.Split(' ').Select(x => "\"" + x + "*\""));
				Type = temp[1].Trim().ToLower();
				Operator = temp[2].Trim();

				switch (Type)
				{
					//case "authorslastname": Command.CommandText += "(EXISTS (SELECT 1 FROM list_aut_k INNER JOIN ksiazki_autor_new ON ksiazki_autor_new.id_autor = list_aut_k.id_aut AND ksiazki_autor_new.id_ksiazka = ksiazki_new.kod WHERE LTRIM(RTRIM(UPPER(nazwisko))) + ' ' + LTRIM(RTRIM(UPPER(imie))) like '%' + @fraza" + i + " + '%' OR LTRIM(RTRIM(UPPER(imie))) + ' ' + LTRIM(RTRIM(UPPER(nazwisko))) like '%' +  @fraza" + i + " + '%') OR EXISTS (SELECT 1 FROM list_aut_k INNER JOIN ksiazki_wautor_new ON ksiazki_wautor_new.id_wautor = list_aut_k.id_aut AND ksiazki_wautor_new.id_ksiazka = ksiazki_new.kod WHERE LTRIM(RTRIM(UPPER(nazwisko))) + LTRIM(RTRIM(UPPER(imie))) like '%' + @fraza" + i + " + '%' OR LTRIM(RTRIM(UPPER(imie))) + LTRIM(RTRIM(UPPER(nazwisko))) like '%' + @fraza" + i + " + '%')) " + Environment.NewLine;
					case "authorslastname": Command.CommandText += "EXISTS (SELECT 1 FROM list_aut_k INNER JOIN ksiazki_autor_new ON ksiazki_autor_new.id_autor = list_aut_k.id_aut AND ksiazki_autor_new.id_ksiazka = ksiazki_new.kod WHERE CONTAINS(imie_nazwisko, @fraza" + i + ")) OR EXISTS (SELECT 1 FROM list_aut_k INNER JOIN ksiazki_wautor_new ON ksiazki_wautor_new.id_wautor = list_aut_k.id_aut AND ksiazki_wautor_new.id_ksiazka = ksiazki_new.kod WHERE CONTAINS(imie_nazwisko, @fraza" + i + ")) " + Environment.NewLine;
						Command.Parameters.AddWithValue("@fraza" + i, Phrase.ToUpper());
						break;
					//case "title": Command.CommandText += "LTRIM(RTRIM(UPPER(tytul_gl))) LIKE '%' + @fraza" + i + " + '%'" + Environment.NewLine;
					case "title": Command.CommandText += "CONTAINS (tytul_gl, @fraza" + i + ")" + Environment.NewLine;
						Command.Parameters.AddWithValue("@fraza" + i, Phrase);
						break;
					//case "key": Command.CommandText += "EXISTS (SELECT 1 FROM ksi_klu INNER JOIN klucze_k ON ksi_klu.kody = klucze_k.kody AND ksi_klu.kod = ksiazki_new.kod WHERE LTRIM(RTRIM(UPPER(klucze_k.klucze))) like '%' + @fraza" + i + " + '%') " + Environment.NewLine;//"klu" + KeyCount + ".kody IN (SELECT kody FROM klucze_k WHERE klucze like '%' + @fraza" + i + " + '%')"; // "LTRIM(RTRIM(UPPER(klu" + KeyCount + ".klucze))) LIKE '%' + @" + i + " + '%'";
					case "key": Command.CommandText += "EXISTS (SELECT 1 FROM ksi_klu INNER JOIN klucze_k ON ksi_klu.kody = klucze_k.kody AND ksi_klu.kod = ksiazki_new.kod WHERE CONTAINS (klucze_k.klucze, @fraza" + i + ")) " + Environment.NewLine;
						Command.Parameters.AddWithValue("@fraza" + i, Phrase);
						//Command.Parameters.Add("@fraza" + i, System.Data.SqlDbType.NVarChar).Value = Phrase = string.Join(" AND", Phrase.Split(' ').Select(x => "\"" + x + "*\""));
						break;
					//case "syg": Command.CommandText += "LTRIM(RTRIM(UPPER(syg))) LIKE '%' + @fraza" + i + " +'%'" + Environment.NewLine;
					case "syg": Command.CommandText += "CONTAINS (syg, @fraza" + i + ")" + Environment.NewLine;
						Command.Parameters.AddWithValue("@fraza" + i, Phrase);
						break;
					//case "publisher": Command.CommandText += "EXISTS (SELECT 1 FROM wydawca_k WHERE (nazwa_w like '%' + @fraza" + i + " + '%' OR sk_nazwa_w like '%' + @fraza" + i + " + '%') AND (id_wyd1 = id_wydawcy OR id_wyd2 = id_wydawcy))" + Environment.NewLine;
					case "publisher": Command.CommandText += "EXISTS (SELECT 1 FROM wydawca_k WHERE CONTAINS((nazwa_w, sk_nazwa_w), @fraza" + i + ") AND (id_wyd1 = id_wydawcy OR id_wyd2 = id_wydawcy))" + Environment.NewLine;
						Command.Parameters.AddWithValue("@fraza" + i, Phrase);
						break;
					//case "ukd": Command.CommandText += "LTRIM(RTRIM(UPPER(ukd))) LIKE '%' + @fraza" + i + " + '%'" + Environment.NewLine;
					case "ukd": Command.CommandText += "CONTAINS(ukd, @fraza" + i + ")" + Environment.NewLine;
						Command.Parameters.AddWithValue("@fraza" + i, Phrase);
						break;
					//case "serie": Command.CommandText += "EXISTS (SELECT 1 FROM ksi_ser INNER JOIN serie ON serie.kody = ksi_ser.kody WHERE LTRIM(RTRIM(UPPER(tyt_serii))) LIKE '%' + @fraza" + i + " + '%' AND ksiazki_new.kod = ksi_ser.kod)" + Environment.NewLine;
					case "serie": Command.CommandText += "EXISTS (SELECT 1 FROM ksi_ser INNER JOIN serie ON serie.kody = ksi_ser.kody WHERE CONTAINS(tyt_serii, @fraza" + i + ") AND ksiazki_new.kod = ksi_ser.kod)" + Environment.NewLine;
						Command.Parameters.AddWithValue("@fraza" + i, Phrase.ToUpper());
						break;
					//case "instyt": Command.CommandText += "EXISTS (SELECT 1 FROM instyt WHERE LTRIM(RTRIM(UPPER(nazwa_inst))) LIKE '%' + @fraza" + i + " + '%' AND instyt.kod = ksiazki_new.kod)" + Environment.NewLine;
					case "instyt": Command.CommandText += "EXISTS (SELECT 1 FROM instyt WHERE CONTAINS(nazwa_inst, @fraza" + i + ") AND instyt.kod = ksiazki_new.kod)" + Environment.NewLine;
						Command.Parameters.AddWithValue("@fraza" + i, Phrase.ToUpper());
						break;
				}

				if (i + 1 < Values.Count)
					Command.CommandText += Operator.ToLower() == "and" ? " AND " : " OR ";
			}

			if (Values.Count > 0)
				Command.CommandText += ") " + Environment.NewLine;


			// conditions with AND only
			if (ANDValues.Count > 0)
				Command.CommandText += " AND ";

			for (int i = 0; i < ANDValues.Count; i++)
			{
				temp = ANDValues[i];

				Phrase = temp[0].Trim();
				Type = temp[1].Trim().ToLower();
				Operator = temp[2].Trim();

				switch (Type)
				{
					case "lang": Command.CommandText += "EXISTS (SELECT 1 FROM ksiazki_jezyki_new INNER JOIN jezyki ON jezyki.id = ksiazki_jezyki_new.id_jezyk AND ksiazki_jezyki_new.id_ksiazki = ksiazki_new.kod WHERE id_jezyk = @fraza_" + i + ")" + Environment.NewLine;
						Command.Parameters.AddWithValue("@fraza_" + i, Phrase.ToUpper());
						break;
					case "sources": Command.CommandText += "EXISTS (SELECT 1 FROM documents WHERE kod = ksiazki_new.kod AND rodzaj_zasobu = 1)" + Environment.NewLine;
						break;
				}

				if (i + 1 < ANDValues.Count)
					Command.CommandText += Operator.ToLower() == "and" ? " AND " : " OR ";
			}

			return Command;
		}*/
		#endregion

		#region Articles

		public static SqlCommand getArticlesQuery(List<string[]> Values, List<string[]> ANDValues, int StartIndex, int Count, string Sort)
		{
			SqlCommand Command = new SqlCommand();
			string dropTables = "";
			string SearchCommand = " ;with result AS" + Environment.NewLine +
									"(" + Environment.NewLine +
									"SELECT kod FROM artykuly" + Environment.NewLine;                                    

			Command.CommandText = "DECLARE @ResultOrder TABLE  " + Environment.NewLine +
								  "(     OrderID int identity(1,1) not null primary key clustered," + Environment.NewLine +
								  "      ResultID int," + Environment.NewLine +
								  "      tytul varchar(1024)    " + Environment.NewLine +
								  ");" + Environment.NewLine;

			string[] temp;
			string Phrase;
			string Type;
			string Operator;
			string LewyNawias;
			string PrawyNawias;

			if (Values.Count > 0)
				SearchCommand += " WHERE (";

			for (int i = 0; i < Values.Count; i++)
			{
				temp = Values[i];
				Type = temp[1].Trim().ToLower();

				Phrase = temp[0].Trim();
				
				//Phrase = string.Join(" AND", Phrase.Split(' ').Where(x => x.Trim().Length > 1).Select(x => "\"" + x + "*\""));
				//Phrase = string.Join(" AND", Phrase.Split(' ').Where(x => x.Trim().Length > 1).Select(x => "\"" + x + "\""));
				Phrase = string.Join(" AND", Phrase.Replace(".", " ").Split(' ').Where(x => x.Trim().Length > 1).Select(x => "\"" + x.Trim() + "\""));

				if (Phrase.Trim().Length == 0)
					Phrase = "\"" + temp[0].Trim() + "*\"";
				
				Operator = temp[2].Trim();
				LewyNawias = temp[3].Trim();
				PrawyNawias = temp[4].Trim();

				switch (Type)
				{
					//case "authorlastname": Command.CommandText += "(LTRIM(RTRIM(UPPER(imie))) + ' ' + LTRIM(RTRIM(UPPER(nazwisko))) LIKE '%' + @fraza" + i + " + '%' OR LTRIM(RTRIM(UPPER(nazwisko))) + ' ' + LTRIM(RTRIM(UPPER(imie))) LIKE '%' + @fraza" + i + " + '%')";
					case "authorslastname": Command.CommandText += ";with auttab AS( " + Environment.NewLine +
																	"	SELECT kod FROM list_aut_a INNER JOIN art_aut ON art_aut.id_aut = list_aut_a.id_aut WHERE CONTAINS(imie_nazwisko, @fraza" + i + "))" + Environment.NewLine +
																	"SELECT kod INTO #auttab" + i + " FROM auttab;" + Environment.NewLine;
											Command.Parameters.AddWithValue("@fraza" + i, Phrase);
											SearchCommand += LewyNawias + " kod in (select kod from #auttab" + i + ")" + PrawyNawias;
											dropTables += "drop table #auttab" + i + "; ";
						break;
					//case "title": Command.CommandText += "LTRIM(RTRIM(UPPER(tytul_a))) LIKE '%' + @fraza" + i + " + '%'";
					case "title": Command.CommandText += ";with tytultab AS(" + Environment.NewLine +
														"   SELECT DISTINCT artykuly.kod " + Environment.NewLine +
														"   FROM artykuly WHERE CONTAINS(tytul_a, @fraza" + i + "))" + Environment.NewLine +
														//"   FROM artykuly WHERE CONTAINS(tytul_a, @fraza" + i + ") OR (UPPER(rodzaj_zas) = 'C' AND CONTAINS(tytul, @fraza" + i + ")))" + Environment.NewLine +                                                        
														"SELECT kod INTO #tytultab" + i + " FROM tytultab;" + Environment.NewLine;
									Command.Parameters.AddWithValue("@fraza" + i, Phrase);
									SearchCommand += LewyNawias + " kod in (select kod from #tytultab" + i + ")" + PrawyNawias;
									dropTables += "drop table #tytultab" + i + "; ";
						break;
					//case "key": Command.CommandText += "EXISTS (SELECT 1 FROM art_klu INNER JOIN klucze_a ON art_klu.kody = klucze_a.kody AND art_klu.kod = artykuly.kod WHERE LTRIM(RTRIM(UPPER(klucze_a.klucze))) LIKE '%' + @fraza" + i + " + '%') " + Environment.NewLine;
					case "key": Command.CommandText += ";with kluczetab AS(" + Environment.NewLine +
														"	SELECT kod FROM art_klu INNER JOIN klucze_a ON art_klu.kody = klucze_a.kody WHERE CONTAINS(klucze_a.klucze, @fraza" + i + "))" + Environment.NewLine +
														"SELECT kod INTO #kluczetab" + i + " FROM kluczetab;" + Environment.NewLine;
								Command.Parameters.AddWithValue("@fraza" + i, Phrase);
								SearchCommand += LewyNawias + " kod in (select kod from #kluczetab" + i + ")" + PrawyNawias;
								dropTables += "drop table #kluczetab" + i + "; ";
						break;
					case "magazine_title": Command.CommandText += ";with czasoptab AS(" + Environment.NewLine +
																	"   SELECT kod FROM czasop WHERE CONTAINS(czasop.tytul, @fraza" + i + ") UNION SELECT kod FROM ksiazki_new WHERE CONTAINS(tytul_gl, @fraza" + i + "))" + Environment.NewLine +
																	"SELECT kod INTO #czasoptab" + i + " FROM czasoptab;" + Environment.NewLine +
																	";with tytul_zrodla AS(" + Environment.NewLine +
																	"   SELECT kod FROM artykuly WHERE ((kod_zas in (SELECT kod FROM #czasoptab" + i + ")  OR CONTAINS(tytul, @fraza" + i + "))))" + Environment.NewLine +
																	"SELECT kod INTO #tytul_zrodla" + i + " FROM tytul_zrodla;" + Environment.NewLine;
											Command.Parameters.AddWithValue("@fraza" + i, Phrase);
											//SearchCommand += LewyNawias + "((kod_zas in (SELECT kod FROM #czasoptab" + i + ") OR CONTAINS(tytul, @fraza" + i + ")) AND UPPER(rodzaj_zas) = 'C')" + PrawyNawias;
											SearchCommand += LewyNawias + "(kod in (SELECT kod FROM #tytul_zrodla" + i + "))" + PrawyNawias;                                            
											dropTables += "drop table #czasoptab" + i + "; ";
											dropTables += "drop table #tytul_zrodla" + i + "; ";
						break;
					case "entry_date": Command.CommandText += ";with data_tab AS(SELECT kod FROM artykuly where cast(data_biez as DATE) = @fraza" + i + ")" + Environment.NewLine +
														"SELECT kod INTO #data_tab" + i + " FROM data_tab;" + Environment.NewLine;
										string date = String.Join("", Phrase.Where(x => char.IsDigit(x)));
										DateTime dateTime = new DateTime();
										DateTime.TryParseExact(date, "ddMMyyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime);                        
										Command.Parameters.AddWithValue("@fraza" + i, dateTime.ToString("yyyyMMdd"));
										SearchCommand += LewyNawias + " kod in (select kod from #data_tab" + i + ")" + PrawyNawias + Environment.NewLine;
										dropTables += "drop table #data_tab" + i + "; ";
						break;
					case "desc_fragment": Command.CommandText += ";with opis_tab AS(" + Environment.NewLine +
																//"   SELECT kod FROM artykuly where opis like '%'+ @fraza" + i + "+'%')" + Environment.NewLine +
																"   SELECT kod FROM artykuly where CONTAINS(opis, @fraza" + i + "))" + Environment.NewLine +                                                                
																"SELECT kod INTO #opis_tab" + i + " FROM opis_tab;" + Environment.NewLine;
											Command.Parameters.AddWithValue("@fraza" + i, Phrase);
											SearchCommand += LewyNawias + " kod in (select kod from #opis_tab" + i + ")" + PrawyNawias + Environment.NewLine;
											dropTables += "drop table #opis_tab" + i + "; ";
						break;
				}

				if (i + 1 < Values.Count)
					SearchCommand += Operator.ToLower() == "and" ? " AND " : " OR ";
			}

			if (Values.Count > 0)
				SearchCommand += ") " + Environment.NewLine;


			// conditions with AND only
			if (ANDValues.Count > 0 && Values.Count > 0)
				SearchCommand += " AND ";
			else if (ANDValues.Count > 0)
				SearchCommand += " WHERE ";

			for (int i = 0; i < ANDValues.Count; i++)
			{
				temp = ANDValues[i];

				Phrase = temp[0].Trim();
				Type = temp[1].Trim().ToLower();
				Operator = temp[2].Trim();

				switch (Type)
				{
					case "lang": SearchCommand += "artykuly.jezyk = (SELECT jezyk FROM jezyki WHERE id = @fraza_" + i + ")" + Environment.NewLine;
						Command.Parameters.AddWithValue("@fraza_" + i, Phrase.ToUpper());
						break;
					case "sources": SearchCommand += "EXISTS (SELECT 1 FROM documents WHERE kod = artykuly.kod AND rodzaj_zasobu = 3)" + Environment.NewLine;
						break;
				}

				if (i + 1 < ANDValues.Count)
					SearchCommand += Operator.ToLower() == "and" ? " AND " : " OR ";
			}

			SearchCommand += ") " + Environment.NewLine;

			Command.CommandText += SearchCommand + Environment.NewLine;

			Command.CommandText += " INSERT INTO @ResultOrder" + Environment.NewLine +
								   " SELECT artykuly.kod, ''/*LTRIM(RTRIM(artykuly.tytul_a)) AS tytul*/ " + Environment.NewLine +
								   " FROM artykuly" + Environment.NewLine +
								   " INNER JOIN result ON result.kod = artykuly.kod" + Environment.NewLine;// +
								   //" WHERE LEN(ISNULL(artykuly.tytul_a,'')) > 0 " + Environment.NewLine;// +
								   //" ORDER BY artykuly.tytul_a;" + Environment.NewLine;


			switch (Sort.ToLower().Trim())
			{
				case "author": Command.CommandText += " OUTER APPLY (SELECT TOP 1 imie_nazwisko AS nazwisko FROM list_aut_a " + Environment.NewLine +
													   "   INNER JOIN art_aut on list_aut_a.id_aut = art_aut.id_aut" + Environment.NewLine +
													   "   WHERE art_aut.kod = artykuly.kod) AS nazwisko" + Environment.NewLine +
													   "ORDER BY CASE WHEN nazwisko IS NULL THEN 1 ELSE 0 END, nazwisko, artykuly.tytul_a; " + Environment.NewLine;
					break;

				case "title":
				default: Command.CommandText += " ORDER BY artykuly.tytul_a;" + Environment.NewLine; break;
			}

			Command.CommandText += " SELECT OrderID, LTRIM(RTRIM(artykuly.tytul_a)) AS tytul, ResultID AS kod, 'Article' AS type, 0 AS ilosc, (SELECT COUNT(*) FROM @ResultOrder) AS rows_count, " + Environment.NewLine +
								   //" ('<ul>' + (SELECT stuff((select LTRIM(RTRIM(nazwisko)) + ' ' + LTRIM(RTRIM(imie))FROM list_aut_a INNER JOIN art_aut ON art_aut.id_aut = list_aut_a.id_aut WHERE art_aut.kod = artykuly.kod ORDER BY nazwisko, imie for xml path('li')),1,0,'')) + '</ul>') as autor  " + Environment.NewLine +
								   " ('<ul>' + (SELECT stuff((select LTRIM(RTRIM(nazwisko)) + ' ' + LTRIM(RTRIM(imie))FROM list_aut_a INNER JOIN art_aut ON art_aut.id_aut = list_aut_a.id_aut WHERE art_aut.kod = artykuly.kod ORDER BY nazwisko, imie for xml path('li')),1,0,'')) + '</ul>') as autor  " + Environment.NewLine +
								   " FROM @ResultOrder result" + Environment.NewLine +
								   " INNER JOIN artykuly ON ResultID = artykuly.kod" + Environment.NewLine +
								   " WHERE OrderID >= @start AND OrderID < @end ORDER BY OrderID;" + Environment.NewLine;

			Command.CommandText += dropTables;

			Command.Parameters.AddWithValue("@start", StartIndex);
			Command.Parameters.AddWithValue("@end", StartIndex + Count);            

			return Command;
		}

		#endregion

		#region Magazines

		public static SqlCommand getMagazinesQuery(List<string[]> Values, List<string[]> ANDValues, int StartIndex, int Count)
		{

			SqlCommand Command = new SqlCommand();
			string dropTables = "";

			Command.CommandText = "DECLARE @ResultOrder TABLE  " + Environment.NewLine +
								  "(     OrderID int identity(1,1) not null primary key clustered," + Environment.NewLine +
								  "      ResultID int," + Environment.NewLine +
								  "      tytul varchar(1024)    " + Environment.NewLine +
								  ");" + Environment.NewLine;

			string SearchCommand = " ;with result AS" + Environment.NewLine +
								   "(" + Environment.NewLine +
								   "SELECT DISTINCT czasop.kod FROM dbo.czasop" + Environment.NewLine +
								   "INNER JOIN dbo.cza_syg ON dbo.cza_syg.kod = czasop.kod  " + Environment.NewLine;

			string[] temp;
			string Phrase;
			string Type;
			string Operator;
			string LewyNawias;
			string PrawyNawias;

			if (Values.Count > 0)
				SearchCommand += " WHERE (";

			for (int i = 0; i < Values.Count; i++)
			{
				temp = Values[i];

				Phrase = temp[0].Trim();
				//Phrase = string.Join(" AND", Phrase.Split(' ').Where(x => x.Trim().Length > 1).Select(x => "\"" + x + "*\""));
				//Phrase = string.Join(" AND", Phrase.Split(' ').Where(x => x.Trim().Length > 1).Select(x => "\"" + x + "\""));
				Phrase = string.Join(" AND", Phrase.Replace(".", " ").Split(' ').Where(x => x.Trim().Length > 1).Select(x => "\"" + x.Trim() + "\""));

				if (Phrase.Trim().Length == 0)
					Phrase = "\"" + temp[0].Trim() + "*\"";

				Type = temp[1].Trim().ToLower();
				Operator = temp[2].Trim();
				LewyNawias =  temp[3].Trim();
				PrawyNawias =  temp[4].Trim();

				switch (Type)
				{                    
					case "title":   Command.CommandText += ";with tytul_tab AS(SELECT kod FROM czasop WHERE CONTAINS(tytul, @fraza" + i + "))" + Environment.NewLine +
														   "SELECT kod INTO #tytul_tab" + i +" FROM tytul_tab;" + Environment.NewLine;
									Command.Parameters.AddWithValue("@fraza" + i, Phrase);
									SearchCommand += LewyNawias + " czasop.kod in (select kod from #tytul_tab" + i + ")" + PrawyNawias + Environment.NewLine;
									dropTables += "drop table #tytul_tab" + i + "; ";
						break;                    
					case "key": Command.CommandText += ";with klucze_tab AS(SELECT DISTINCT kod FROM cza_klu INNER JOIN klucze_c ON cza_klu.kody = klucze_c.kody WHERE CONTAINS(klucze_c.klucze, @fraza" + i + "))" + Environment.NewLine +
													   "SELECT kod INTO #klucze_tab" + i + " FROM klucze_tab;";
								Command.Parameters.AddWithValue("@fraza" + i, Phrase);
								SearchCommand += LewyNawias + " czasop.kod in (select kod from #klucze_tab" + i + ")" + PrawyNawias + Environment.NewLine;
								dropTables += "drop table #klucze_tab" + i + "; ";
						break;
					case "syg": Command.CommandText += ";with syg_tab AS(SELECT kod FROM cza_syg WHERE CONTAINS(syg, @fraza" + i + "))" + Environment.NewLine +
														"SELECT kod INTO #syg_tab" + i + " FROM syg_tab;" + Environment.NewLine;
								Command.Parameters.AddWithValue("@fraza" + i, Phrase);
								SearchCommand += LewyNawias + " czasop.kod in (select kod from #syg_tab" + i + ")" + PrawyNawias + Environment.NewLine;
								dropTables += "drop table #syg_tab" + i + "; ";
						break;
					case "publisher": Command.CommandText += ";with wydawca_tab AS(SELECT id_wydawcy FROM wydawca_c WHERE CONTAINS((nazwa_w, sk_nazwa_w), @fraza" + i + "))" + Environment.NewLine +
															 "SELECT id_wydawcy INTO #wydawca_tab" + i + " FROM wydawca_tab;" + Environment.NewLine;
									  Command.Parameters.AddWithValue("@fraza" + i, Phrase);
									  SearchCommand += LewyNawias + " czasop.id_wydawcy in (select id_wydawcy from #wydawca_tab" + i + ")" + PrawyNawias + Environment.NewLine;
									  dropTables += "drop table #wydawca_tab" + i + "; ";
						break;
					case "distributor": Command.CommandText += ";with kolport_tab AS(SELECT id_kolport FROM kolport WHERE CONTAINS((nazwa_k, sk_nazwa_k), @fraza" + i + "))" + Environment.NewLine +
																"SELECT id_kolport INTO #kolport_tab" + i + " FROM kolport_tab;" + Environment.NewLine;
										Command.Parameters.AddWithValue("@fraza" + i, Phrase);
										SearchCommand += LewyNawias + " czasop.id_kolport in (select id_kolport from #kolport_tab" + i + ")" + PrawyNawias + Environment.NewLine;
										dropTables += "drop table #kolport_tab" + i + "; ";
						break;
					case "extras_title": Command.CommandText += ";with dodatki_tab AS(SELECT kod FROM dodatki WHERE CONTAINS(tytul_dod, @fraza" + i + "))" + Environment.NewLine +
																"SELECT kod INTO #dodatki_tab" + i + " FROM dodatki_tab;" + Environment.NewLine;
										SearchCommand += LewyNawias + " czasop.kod in (select kod from #dodatki_tab" + i + ")" + PrawyNawias + Environment.NewLine;
										dropTables += "drop table #dodatki_tab" + i + "; ";
										Command.Parameters.AddWithValue("@fraza" + i, Phrase);
						break;
					case "extras_author": Command.CommandText += ";with dodatki_autor_tab AS(SELECT kod FROM dodatki WHERE (CONTAINS(autor1, @fraza" + i + ") OR CONTAINS(autor2, @fraza" + i + ") OR CONTAINS(autor3, @fraza" + i + ")))" + Environment.NewLine +
																 "SELECT kod INTO #dodatki_autor_tab" + i + " FROM dodatki_autor_tab;" + Environment.NewLine;
										Command.Parameters.AddWithValue("@fraza" + i, Phrase);
										SearchCommand += LewyNawias + " czasop.kod in (select kod from #dodatki_autor_tab" + i + ")" + PrawyNawias + Environment.NewLine;
										dropTables += "drop table #dodatki_autor_tab" + i + "; ";
						break;                    
				}

				if (i + 1 < Values.Count)
					SearchCommand += Operator.ToLower() == "and" ? " AND " : " OR ";
			}

			if (Values.Count > 0)
				SearchCommand += ") " + Environment.NewLine;

			// conditions with AND only
			if (ANDValues.Count > 0 && Values.Count > 0)
				SearchCommand += " AND ";
			else if (ANDValues.Count > 0)
				SearchCommand += " WHERE ";

			for (int i = 0; i < ANDValues.Count; i++)
			{
				temp = ANDValues[i];

				Phrase = temp[0].Trim();
				Type = temp[1].Trim().ToLower();
				Operator = temp[2].Trim();

				switch (Type)
				{
					case "lang": SearchCommand += "(SELECT jezyk FROM jezyki WHERE id = @fraza_" + i + ") IN (jezyk1, jezyk2, jezyk3)" + Environment.NewLine;
						Command.Parameters.AddWithValue("@fraza_" + i, Phrase.ToUpper());
						break;
					case "country": SearchCommand += "czasop.kraj_w = (SELECT panstwo FROM panstwa WHERE id = @fraza_" + i + ") " + Environment.NewLine;
						Command.Parameters.AddWithValue("@fraza_" + i, Phrase.ToUpper());
						break;
					case "freq": SearchCommand += "czasop.id_czest = @fraza_" + i + Environment.NewLine;
						Command.Parameters.AddWithValue("@fraza_" + i, Phrase.ToUpper());
						break;
					case "sources": SearchCommand += "EXISTS (SELECT 1 FROM documents WHERE kod = czasop.kod AND rodzaj_zasobu = 2)" + Environment.NewLine;
						break;
				}

				if (i + 1 < ANDValues.Count)
					SearchCommand += Operator.ToLower() == "and" ? " AND " : " OR ";
			}

			SearchCommand += ") " + Environment.NewLine;

			Command.CommandText += SearchCommand + Environment.NewLine;

			Command.CommandText += " INSERT INTO @ResultOrder" + Environment.NewLine +
								   " SELECT czasop.kod, LTRIM(RTRIM(czasop.tytul)) AS tytul" + Environment.NewLine +
								   " FROM czasop" + Environment.NewLine +
								   " INNER JOIN result ON result.kod = czasop.kod" + Environment.NewLine +
								   " ORDER BY czasop.tytul;" + Environment.NewLine +

								   " SELECT OrderID, tytul, ResultID AS kod, 'Magazine' AS type, 0 AS ilosc, (SELECT COUNT(*) FROM @ResultOrder) AS rows_count" + Environment.NewLine +
								   " FROM @ResultOrder" + Environment.NewLine +
								   " WHERE OrderID >= @start AND OrderID < @end ORDER BY OrderID; " + Environment.NewLine;

			Command.CommandText += dropTables;
			Command.Parameters.AddWithValue("@start", StartIndex);
			Command.Parameters.AddWithValue("@end", StartIndex + Count);            

			return Command;
		}

		#endregion

	}
}
