
ThisView = 'v_listauzy'
IF  INDBC(ThisView,"VIEW")
	DROP VIEW (ThisView)
ENDI
CREATE SQL VIEW (ThisView) CONNECTION 'conPostgres' SHAR as ;
SELECT Listauzy.id_uzy, Listauzy.grupa, Listauzy.typ, Listauzy.nazwa,;
  Listauzy.pracownik, Listauzy.ggrupa, Listauzy.pop_nr, Listauzy.pkt_kanc,;
  Listauzy.czykanc, Listauzy.wszystko, Listauzy.przelacz,;
  Listauzy.przychod, Listauzy.wychodz, Listauzy.nowy_p, Listauzy.nowy_w,;
  Listauzy.pnadawca, Listauzy.prodzprzes, Listauzy.pnrprzesyl,;
  Listauzy.pdatawplyw, Listauzy.pdokogo, Listauzy.zm_hasla,;
  Listauzy.skrytka, Listauzy.rejestr, Listauzy.adr_mod_z, Listauzy.copy_p,;
  Listauzy.copy_w, Listauzy.wnrprzesyl, Listauzy.cofanie_p,;
  Listauzy.cofanie_w, Listauzy.aktywne, Listauzy.wom, Listauzy.sldotyczy,;
  Listauzy.widocznep, Listauzy.timestamp_column, Listauzy.serial_id,;
  Listauzy.delegatura;
 FROM ;
     listauzy Listauzy

DBSetProp(ThisView,"View","SendUpdates",.T.)
DBSetProp(ThisView,"View","BatchUpdateCount",1)
DBSetProp(ThisView,"View","CompareMemo",.T.)
DBSetProp(ThisView,"View","FetchAsNeeded",.F.)
DBSetProp(ThisView,"View","FetchMemo",.T.)
DBSetProp(ThisView,"View","FetchSize",100)
DBSetProp(ThisView,"View","MaxRecords",-1)
DBSetProp(ThisView,"View","Prepared",.F.)
DBSetProp(ThisView,"View","ShareConnection",.T.)
DBSetProp(ThisView,"View","AllowSimultaneousFetch",.F.)
DBSetProp(ThisView,"View","UpdateType",1)
DBSetProp(ThisView,"View","UseMemoSize",255)
DBSetProp(ThisView,"View","Tables","listauzy")
DBSetProp(ThisView,"View","WhereType",1)

DBSetProp(ThisView+".id_uzy","Field","DataType","I")
DBSetProp(ThisView+".id_uzy","Field","UpdateName","listauzy.id_uzy")
DBSetProp(ThisView+".id_uzy","Field","KeyField",.F.)
DBSetProp(ThisView+".id_uzy","Field","Updatable",.T.)

DBSetProp(ThisView+".grupa","Field","DataType","C(5)")
DBSetProp(ThisView+".grupa","Field","UpdateName","listauzy.grupa")
DBSetProp(ThisView+".grupa","Field","KeyField",.F.)
DBSetProp(ThisView+".grupa","Field","Updatable",.T.)

DBSetProp(ThisView+".typ","Field","DataType","C(1)")
DBSetProp(ThisView+".typ","Field","UpdateName","listauzy.typ")
DBSetProp(ThisView+".typ","Field","KeyField",.F.)
DBSetProp(ThisView+".typ","Field","Updatable",.T.)

DBSetProp(ThisView+".nazwa","Field","DataType","C(30)")
DBSetProp(ThisView+".nazwa","Field","UpdateName","listauzy.nazwa")
DBSetProp(ThisView+".nazwa","Field","KeyField",.F.)
DBSetProp(ThisView+".nazwa","Field","Updatable",.T.)

DBSetProp(ThisView+".pracownik","Field","DataType","C(10)")
DBSetProp(ThisView+".pracownik","Field","UpdateName","listauzy.pracownik")
DBSetProp(ThisView+".pracownik","Field","KeyField",.F.)
DBSetProp(ThisView+".pracownik","Field","Updatable",.T.)

DBSetProp(ThisView+".ggrupa","Field","DataType","C(5)")
DBSetProp(ThisView+".ggrupa","Field","UpdateName","listauzy.ggrupa")
DBSetProp(ThisView+".ggrupa","Field","KeyField",.F.)
DBSetProp(ThisView+".ggrupa","Field","Updatable",.T.)

DBSetProp(ThisView+".pop_nr","Field","DataType","C(252)")
DBSetProp(ThisView+".pop_nr","Field","UpdateName","listauzy.pop_nr")
DBSetProp(ThisView+".pop_nr","Field","KeyField",.F.)
DBSetProp(ThisView+".pop_nr","Field","Updatable",.T.)

DBSetProp(ThisView+".pkt_kanc","Field","DataType","N(4)")
DBSetProp(ThisView+".pkt_kanc","Field","UpdateName","listauzy.pkt_kanc")
DBSetProp(ThisView+".pkt_kanc","Field","KeyField",.F.)
DBSetProp(ThisView+".pkt_kanc","Field","Updatable",.T.)

DBSetProp(ThisView+".czykanc","Field","DataType","L")
DBSetProp(ThisView+".czykanc","Field","UpdateName","listauzy.czykanc")
DBSetProp(ThisView+".czykanc","Field","KeyField",.F.)
DBSetProp(ThisView+".czykanc","Field","Updatable",.T.)

DBSetProp(ThisView+".wszystko","Field","DataType","L")
DBSetProp(ThisView+".wszystko","Field","UpdateName","listauzy.wszystko")
DBSetProp(ThisView+".wszystko","Field","KeyField",.F.)
DBSetProp(ThisView+".wszystko","Field","Updatable",.T.)

DBSetProp(ThisView+".przelacz","Field","DataType","L")
DBSetProp(ThisView+".przelacz","Field","UpdateName","listauzy.przelacz")
DBSetProp(ThisView+".przelacz","Field","KeyField",.F.)
DBSetProp(ThisView+".przelacz","Field","Updatable",.T.)

DBSetProp(ThisView+".przychod","Field","DataType","L")
DBSetProp(ThisView+".przychod","Field","UpdateName","listauzy.przychod")
DBSetProp(ThisView+".przychod","Field","KeyField",.F.)
DBSetProp(ThisView+".przychod","Field","Updatable",.T.)

DBSetProp(ThisView+".wychodz","Field","DataType","L")
DBSetProp(ThisView+".wychodz","Field","UpdateName","listauzy.wychodz")
DBSetProp(ThisView+".wychodz","Field","KeyField",.F.)
DBSetProp(ThisView+".wychodz","Field","Updatable",.T.)

DBSetProp(ThisView+".nowy_p","Field","DataType","L")
DBSetProp(ThisView+".nowy_p","Field","UpdateName","listauzy.nowy_p")
DBSetProp(ThisView+".nowy_p","Field","KeyField",.F.)
DBSetProp(ThisView+".nowy_p","Field","Updatable",.T.)

DBSetProp(ThisView+".nowy_w","Field","DataType","L")
DBSetProp(ThisView+".nowy_w","Field","UpdateName","listauzy.nowy_w")
DBSetProp(ThisView+".nowy_w","Field","KeyField",.F.)
DBSetProp(ThisView+".nowy_w","Field","Updatable",.T.)

DBSetProp(ThisView+".pnadawca","Field","DataType","L")
DBSetProp(ThisView+".pnadawca","Field","UpdateName","listauzy.pnadawca")
DBSetProp(ThisView+".pnadawca","Field","KeyField",.F.)
DBSetProp(ThisView+".pnadawca","Field","Updatable",.T.)

DBSetProp(ThisView+".prodzprzes","Field","DataType","L")
DBSetProp(ThisView+".prodzprzes","Field","UpdateName","listauzy.prodzprzes")
DBSetProp(ThisView+".prodzprzes","Field","KeyField",.F.)
DBSetProp(ThisView+".prodzprzes","Field","Updatable",.T.)

DBSetProp(ThisView+".pnrprzesyl","Field","DataType","L")
DBSetProp(ThisView+".pnrprzesyl","Field","UpdateName","listauzy.pnrprzesyl")
DBSetProp(ThisView+".pnrprzesyl","Field","KeyField",.F.)
DBSetProp(ThisView+".pnrprzesyl","Field","Updatable",.T.)

DBSetProp(ThisView+".pdatawplyw","Field","DataType","L")
DBSetProp(ThisView+".pdatawplyw","Field","UpdateName","listauzy.pdatawplyw")
DBSetProp(ThisView+".pdatawplyw","Field","KeyField",.F.)
DBSetProp(ThisView+".pdatawplyw","Field","Updatable",.T.)

DBSetProp(ThisView+".pdokogo","Field","DataType","L")
DBSetProp(ThisView+".pdokogo","Field","UpdateName","listauzy.pdokogo")
DBSetProp(ThisView+".pdokogo","Field","KeyField",.F.)
DBSetProp(ThisView+".pdokogo","Field","Updatable",.T.)

DBSetProp(ThisView+".zm_hasla","Field","DataType","L")
DBSetProp(ThisView+".zm_hasla","Field","UpdateName","listauzy.zm_hasla")
DBSetProp(ThisView+".zm_hasla","Field","KeyField",.F.)
DBSetProp(ThisView+".zm_hasla","Field","Updatable",.T.)

DBSetProp(ThisView+".skrytka","Field","DataType","L")
DBSetProp(ThisView+".skrytka","Field","UpdateName","listauzy.skrytka")
DBSetProp(ThisView+".skrytka","Field","KeyField",.F.)
DBSetProp(ThisView+".skrytka","Field","Updatable",.T.)

DBSetProp(ThisView+".rejestr","Field","DataType","L")
DBSetProp(ThisView+".rejestr","Field","UpdateName","listauzy.rejestr")
DBSetProp(ThisView+".rejestr","Field","KeyField",.F.)
DBSetProp(ThisView+".rejestr","Field","Updatable",.T.)

DBSetProp(ThisView+".adr_mod_z","Field","DataType","L")
DBSetProp(ThisView+".adr_mod_z","Field","UpdateName","listauzy.adr_mod_z")
DBSetProp(ThisView+".adr_mod_z","Field","KeyField",.F.)
DBSetProp(ThisView+".adr_mod_z","Field","Updatable",.T.)

DBSetProp(ThisView+".copy_p","Field","DataType","L")
DBSetProp(ThisView+".copy_p","Field","UpdateName","listauzy.copy_p")
DBSetProp(ThisView+".copy_p","Field","KeyField",.F.)
DBSetProp(ThisView+".copy_p","Field","Updatable",.T.)

DBSetProp(ThisView+".copy_w","Field","DataType","L")
DBSetProp(ThisView+".copy_w","Field","UpdateName","listauzy.copy_w")
DBSetProp(ThisView+".copy_w","Field","KeyField",.F.)
DBSetProp(ThisView+".copy_w","Field","Updatable",.T.)

DBSetProp(ThisView+".wnrprzesyl","Field","DataType","L")
DBSetProp(ThisView+".wnrprzesyl","Field","UpdateName","listauzy.wnrprzesyl")
DBSetProp(ThisView+".wnrprzesyl","Field","KeyField",.F.)
DBSetProp(ThisView+".wnrprzesyl","Field","Updatable",.T.)

DBSetProp(ThisView+".cofanie_p","Field","DataType","L")
DBSetProp(ThisView+".cofanie_p","Field","UpdateName","listauzy.cofanie_p")
DBSetProp(ThisView+".cofanie_p","Field","KeyField",.F.)
DBSetProp(ThisView+".cofanie_p","Field","Updatable",.T.)

DBSetProp(ThisView+".cofanie_w","Field","DataType","L")
DBSetProp(ThisView+".cofanie_w","Field","UpdateName","listauzy.cofanie_w")
DBSetProp(ThisView+".cofanie_w","Field","KeyField",.F.)
DBSetProp(ThisView+".cofanie_w","Field","Updatable",.T.)

DBSetProp(ThisView+".aktywne","Field","DataType","L")
DBSetProp(ThisView+".aktywne","Field","UpdateName","listauzy.aktywne")
DBSetProp(ThisView+".aktywne","Field","KeyField",.F.)
DBSetProp(ThisView+".aktywne","Field","Updatable",.T.)

DBSetProp(ThisView+".wom","Field","DataType","L")
DBSetProp(ThisView+".wom","Field","UpdateName","listauzy.wom")
DBSetProp(ThisView+".wom","Field","KeyField",.F.)
DBSetProp(ThisView+".wom","Field","Updatable",.T.)

DBSetProp(ThisView+".sldotyczy","Field","DataType","L")
DBSetProp(ThisView+".sldotyczy","Field","UpdateName","listauzy.sldotyczy")
DBSetProp(ThisView+".sldotyczy","Field","KeyField",.F.)
DBSetProp(ThisView+".sldotyczy","Field","Updatable",.T.)

DBSetProp(ThisView+".widocznep","Field","DataType","L")
DBSetProp(ThisView+".widocznep","Field","UpdateName","listauzy.widocznep")
DBSetProp(ThisView+".widocznep","Field","KeyField",.F.)
DBSetProp(ThisView+".widocznep","Field","Updatable",.T.)

DBSetProp(ThisView+".timestamp_column","Field","DataType","T")
DBSetProp(ThisView+".timestamp_column","Field","UpdateName","listauzy.timestamp_column")
DBSetProp(ThisView+".timestamp_column","Field","KeyField",.F.)
DBSetProp(ThisView+".timestamp_column","Field","Updatable",.T.)

DBSetProp(ThisView+".serial_id","Field","DataType","I")
DBSetProp(ThisView+".serial_id","Field","UpdateName","listauzy.serial_id")
DBSetProp(ThisView+".serial_id","Field","KeyField",.T.)
DBSetProp(ThisView+".serial_id","Field","Updatable",.T.)

DBSetProp(ThisView+".delegatura","Field","DataType","C(100)")
DBSetProp(ThisView+".delegatura","Field","UpdateName","listauzy.delegatura")
DBSetProp(ThisView+".delegatura","Field","KeyField",.F.)
DBSetProp(ThisView+".delegatura","Field","Updatable",.T.)

ThisView = 'nadania'
IF  INDBC(ThisView,"VIEW")
	DROP VIEW (ThisView)
ENDI
CREATE SQL VIEW (ThisView) CONNECTION 'conPostgres' SHAR as ;
SELECT Nadania.id_stanowiska, Nadania.id_uzyt, Nadania.data_od,;
  Nadania.data_do, Nadania.serial_id, Nadania.zast;
 FROM ;
     NADANIA Nadania;
 WHERE  NOT Nadania.zast 

DBSetProp(ThisView,"View","SendUpdates",.T.)
DBSetProp(ThisView,"View","BatchUpdateCount",1)
DBSetProp(ThisView,"View","CompareMemo",.T.)
DBSetProp(ThisView,"View","FetchAsNeeded",.F.)
DBSetProp(ThisView,"View","FetchMemo",.T.)
DBSetProp(ThisView,"View","FetchSize",100)
DBSetProp(ThisView,"View","MaxRecords",-1)
DBSetProp(ThisView,"View","Prepared",.F.)
DBSetProp(ThisView,"View","ShareConnection",.T.)
DBSetProp(ThisView,"View","AllowSimultaneousFetch",.F.)
DBSetProp(ThisView,"View","UpdateType",1)
DBSetProp(ThisView,"View","UseMemoSize",255)
DBSetProp(ThisView,"View","Tables","NADANIA")
DBSetProp(ThisView,"View","WhereType",1)

DBSetProp(ThisView+".id_stanowiska","Field","DataType","I")
DBSetProp(ThisView+".id_stanowiska","Field","UpdateName","NADANIA.id_stanowiska")
DBSetProp(ThisView+".id_stanowiska","Field","KeyField",.F.)
DBSetProp(ThisView+".id_stanowiska","Field","Updatable",.T.)

DBSetProp(ThisView+".id_uzyt","Field","DataType","I")
DBSetProp(ThisView+".id_uzyt","Field","UpdateName","NADANIA.id_uzyt")
DBSetProp(ThisView+".id_uzyt","Field","KeyField",.F.)
DBSetProp(ThisView+".id_uzyt","Field","Updatable",.T.)

DBSetProp(ThisView+".data_od","Field","DataType","D")
DBSetProp(ThisView+".data_od","Field","UpdateName","NADANIA.data_od")
DBSetProp(ThisView+".data_od","Field","KeyField",.F.)
DBSetProp(ThisView+".data_od","Field","Updatable",.T.)

DBSetProp(ThisView+".data_do","Field","DataType","D")
DBSetProp(ThisView+".data_do","Field","UpdateName","NADANIA.data_do")
DBSetProp(ThisView+".data_do","Field","KeyField",.F.)
DBSetProp(ThisView+".data_do","Field","Updatable",.T.)

DBSetProp(ThisView+".serial_id","Field","DataType","I")
DBSetProp(ThisView+".serial_id","Field","UpdateName","NADANIA.serial_id")
DBSetProp(ThisView+".serial_id","Field","KeyField",.T.)
DBSetProp(ThisView+".serial_id","Field","Updatable",.T.)

DBSetProp(ThisView+".zast","Field","DataType","L")
DBSetProp(ThisView+".zast","Field","DefaultValue",".F.")
DBSetProp(ThisView+".zast","Field","UpdateName","NADANIA.zast")
DBSetProp(ThisView+".zast","Field","KeyField",.F.)
DBSetProp(ThisView+".zast","Field","Updatable",.T.)

ThisView = 'v_nadania'
IF  INDBC(ThisView,"VIEW")
	DROP VIEW (ThisView)
ENDI
CREATE SQL VIEW (ThisView) CONNECTION 'conPostgres' SHAR as ;
SELECT N.id_stanowiska, S.nazwa, U.Imie,N.id_uzyt, N.data_od, N.data_do, N.serial_id, N.zast,D.id_uzyt AS IdU;
 FROM NADANIA N ;
    LEFT OUTER JOIN Nadania   D ON  N.id_stanowiska = D.id_stanowiska;
    LEFT OUTER JOIN Struktura S ON  N.id_stanowiska = S.id_stanowiska;
    LEFT OUTER JOIN uzytkown  U ON  D.id_uzyt = U.Id;
 WHERE  ( N.id_uzyt ) = (?v_listauzyuzy.id_uzy) and D.Zast is not true AND N.Zast is true
  
DBSetProp(ThisView,"View","SendUpdates",.T.)
DBSetProp(ThisView,"View","BatchUpdateCount",1)
DBSetProp(ThisView,"View","CompareMemo",.T.)
DBSetProp(ThisView,"View","FetchAsNeeded",.F.)
DBSetProp(ThisView,"View","FetchMemo",.T.)
DBSetProp(ThisView,"View","FetchSize",100)
DBSetProp(ThisView,"View","MaxRecords",-1)
DBSetProp(ThisView,"View","Prepared",.F.)
DBSetProp(ThisView,"View","ShareConnection",.T.)
DBSetProp(ThisView,"View","AllowSimultaneousFetch",.F.)
DBSetProp(ThisView,"View","UpdateType",1)
DBSetProp(ThisView,"View","UseMemoSize",255)
DBSetProp(ThisView,"View","Tables","NADANIA")
DBSetProp(ThisView,"View","WhereType",1)

DBSetProp(ThisView+".id_stanowiska","Field","DataType","I")
DBSetProp(ThisView+".id_stanowiska","Field","UpdateName","NADANIA.id_stanowiska")
DBSetProp(ThisView+".id_stanowiska","Field","KeyField",.F.)
DBSetProp(ThisView+".id_stanowiska","Field","Updatable",.T.)

DBSetProp(ThisView+".nazwa","Field","DataType","C(30)")
DBSetProp(ThisView+".nazwa","Field","UpdateName","Struktura.nazwa")
DBSetProp(ThisView+".nazwa","Field","KeyField",.F.)
DBSetProp(ThisView+".nazwa","Field","Updatable",.F.)

DBSetProp(ThisView+".id_uzyt","Field","DataType","I")
DBSetProp(ThisView+".id_uzyt","Field","UpdateName","NADANIA.id_uzyt")
DBSetProp(ThisView+".id_uzyt","Field","KeyField",.F.)
DBSetProp(ThisView+".id_uzyt","Field","Updatable",.T.)

DBSetProp(ThisView+".data_od","Field","DataType","D")
DBSetProp(ThisView+".data_od","Field","UpdateName","NADANIA.data_od")
DBSetProp(ThisView+".data_od","Field","KeyField",.F.)
DBSetProp(ThisView+".data_od","Field","Updatable",.T.)

DBSetProp(ThisView+".data_do","Field","DataType","D")
DBSetProp(ThisView+".data_do","Field","UpdateName","NADANIA.data_do")
DBSetProp(ThisView+".data_do","Field","KeyField",.F.)
DBSetProp(ThisView+".data_do","Field","Updatable",.T.)

DBSetProp(ThisView+".serial_id","Field","DataType","I")
DBSetProp(ThisView+".serial_id","Field","UpdateName","NADANIA.serial_id")
DBSetProp(ThisView+".serial_id","Field","KeyField",.T.)
DBSetProp(ThisView+".serial_id","Field","Updatable",.T.)

DBSetProp(ThisView+".zast","Field","DataType","L")
DBSetProp(ThisView+".zast","Field","DefaultValue",".F.")
DBSetProp(ThisView+".zast","Field","UpdateName","NADANIA.zast")
DBSetProp(ThisView+".zast","Field","KeyField",.F.)
DBSetProp(ThisView+".zast","Field","Updatable",.T.)

DBSetProp(ThisView+".idu","Field","DataType","I")
DBSetProp(ThisView+".idu","Field","UpdateName","NADANIA.id_uzyt")
DBSetProp(ThisView+".idu","Field","KeyField",.F.)
DBSetProp(ThisView+".idu","Field","Updatable",.F.)

ThisView = 'c_global_uzyt_i_stanow'
IF  INDBC(ThisView,"VIEW")
	DROP VIEW (ThisView)
ENDI
CREATE SQL VIEW (ThisView) CONNECTION 'conPostgres' SHAR as ;
SELECT T_global_uzyt_i_stanow.id_uzy, T_global_uzyt_i_stanow.typ,;
  T_global_uzyt_i_stanow.grupa, T_global_uzyt_i_stanow.ggrupa,;
  T_global_uzyt_i_stanow.nazwa_uzyt,;
  T_global_uzyt_i_stanow.id_stanowiska,;
  T_global_uzyt_i_stanow.stanow_nazwa,;
  T_global_uzyt_i_stanow.struktura_grupa;
 FROM ;
     t_global_uzyt_i_stanow T_global_uzyt_i_stanow

DBSetProp(ThisView,"View","SendUpdates",.F.)
DBSetProp(ThisView,"View","BatchUpdateCount",1)
DBSetProp(ThisView,"View","CompareMemo",.T.)
DBSetProp(ThisView,"View","FetchAsNeeded",.F.)
DBSetProp(ThisView,"View","FetchMemo",.T.)
DBSetProp(ThisView,"View","FetchSize",100)
DBSetProp(ThisView,"View","MaxRecords",-1)
DBSetProp(ThisView,"View","Prepared",.F.)
DBSetProp(ThisView,"View","ShareConnection",.T.)
DBSetProp(ThisView,"View","AllowSimultaneousFetch",.F.)
DBSetProp(ThisView,"View","UpdateType",1)
DBSetProp(ThisView,"View","UseMemoSize",255)
DBSetProp(ThisView,"View","WhereType",3)

DBSetProp(ThisView+".id_uzy","Field","DataType","I")
DBSetProp(ThisView+".id_uzy","Field","UpdateName","t_global_uzyt_i_stanow.id_uzy")
DBSetProp(ThisView+".id_uzy","Field","KeyField",.F.)
DBSetProp(ThisView+".id_uzy","Field","Updatable",.F.)

DBSetProp(ThisView+".typ","Field","DataType","C(1)")
DBSetProp(ThisView+".typ","Field","UpdateName","t_global_uzyt_i_stanow.typ")
DBSetProp(ThisView+".typ","Field","KeyField",.F.)
DBSetProp(ThisView+".typ","Field","Updatable",.F.)

DBSetProp(ThisView+".grupa","Field","DataType","C(5)")
DBSetProp(ThisView+".grupa","Field","UpdateName","t_global_uzyt_i_stanow.grupa")
DBSetProp(ThisView+".grupa","Field","KeyField",.F.)
DBSetProp(ThisView+".grupa","Field","Updatable",.F.)

DBSetProp(ThisView+".ggrupa","Field","DataType","C(5)")
DBSetProp(ThisView+".ggrupa","Field","UpdateName","t_global_uzyt_i_stanow.ggrupa")
DBSetProp(ThisView+".ggrupa","Field","KeyField",.F.)
DBSetProp(ThisView+".ggrupa","Field","Updatable",.F.)

DBSetProp(ThisView+".nazwa_uzyt","Field","DataType","C(50)")
DBSetProp(ThisView+".nazwa_uzyt","Field","UpdateName","t_global_uzyt_i_stanow.nazwa_uzyt")
DBSetProp(ThisView+".nazwa_uzyt","Field","KeyField",.F.)
DBSetProp(ThisView+".nazwa_uzyt","Field","Updatable",.F.)

DBSetProp(ThisView+".id_stanowiska","Field","DataType","I")
DBSetProp(ThisView+".id_stanowiska","Field","UpdateName","t_global_uzyt_i_stanow.id_stanowiska")
DBSetProp(ThisView+".id_stanowiska","Field","KeyField",.F.)
DBSetProp(ThisView+".id_stanowiska","Field","Updatable",.F.)

DBSetProp(ThisView+".stanow_nazwa","Field","DataType","C(30)")
DBSetProp(ThisView+".stanow_nazwa","Field","UpdateName","t_global_uzyt_i_stanow.stanow_nazwa")
DBSetProp(ThisView+".stanow_nazwa","Field","KeyField",.F.)
DBSetProp(ThisView+".stanow_nazwa","Field","Updatable",.F.)

DBSetProp(ThisView+".struktura_grupa","Field","DataType","C(20)")
DBSetProp(ThisView+".struktura_grupa","Field","UpdateName","t_global_uzyt_i_stanow.struktura_grupa")
DBSetProp(ThisView+".struktura_grupa","Field","KeyField",.F.)
DBSetProp(ThisView+".struktura_grupa","Field","Updatable",.F.)


PACK DATA