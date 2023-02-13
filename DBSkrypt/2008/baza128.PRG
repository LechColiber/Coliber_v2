thisView = 'listauzy'
IF  INDBC(ThisView,"VIEW")
	DROP VIEW (ThisView)
ENDI
CREATE SQL VIEW (ThisView) CONNECTION 'conPostgres' SHAR as ;
SELECT Listauzy.id_uzy, Listauzy.grupa, Listauzy.typ, Listauzy.nazwa,;
  Listauzy.pracownik, Listauzy.ggrupa, Listauzy.pop_nr, Listauzy.pkt_kanc,;
  Listauzy.delegatura, Listauzy.czykanc, Listauzy.wszystko,;
  Listauzy.przelacz, Listauzy.przychod, Listauzy.wychodz, Listauzy.nowy_p,;
  Listauzy.nowy_w, Listauzy.pnadawca, Listauzy.prodzprzes,;
  Listauzy.pnrprzesyl, Listauzy.pdatawplyw, Listauzy.pdokogo,;
  Listauzy.zm_hasla, Listauzy.skrytka, Listauzy.rejestr,;
  Listauzy.adr_mod_z, Listauzy.copy_p, Listauzy.copy_w,;
  Listauzy.wnrprzesyl, Listauzy.cofanie_p, Listauzy.cofanie_w,;
  Listauzy.aktywne, Listauzy.wom, Listauzy.sldotyczy, Listauzy.widocznep,;
  Listauzy.usun_p, Listauzy.usun_w, Listauzy.timestamp_column,;
  Listauzy.serial_id;
 FROM ;
     LISTAUZY Listauzy

DBSetProp(ThisView,"View","SendUpdates",.T.)
DBSetProp(ThisView,"View","BatchUpdateCount",1)
DBSetProp(ThisView,"View","CompareMemo",.T.)
DBSetProp(ThisView,"View","FetchAsNeeded",.F.)
DBSetProp(ThisView,"View","FetchMemo",.T.)
DBSetProp(ThisView,"View","FetchSize",-1)
DBSetProp(ThisView,"View","MaxRecords",-1)
DBSetProp(ThisView,"View","Prepared",.F.)
DBSetProp(ThisView,"View","ShareConnection",.T.)
DBSetProp(ThisView,"View","AllowSimultaneousFetch",.F.)
DBSetProp(ThisView,"View","UpdateType",1)
DBSetProp(ThisView,"View","UseMemoSize",255)
DBSetProp(ThisView,"View","Tables","LISTAUZY")
DBSetProp(ThisView,"View","WhereType",1)

DBSetProp(ThisView+".id_uzy","Field","DataType","I")
DBSetProp(ThisView+".id_uzy","Field","UpdateName","LISTAUZY.id_uzy")
DBSetProp(ThisView+".id_uzy","Field","KeyField",.F.)
DBSetProp(ThisView+".id_uzy","Field","Updatable",.T.)

DBSetProp(ThisView+".grupa","Field","DataType","C(5)")
DBSetProp(ThisView+".grupa","Field","UpdateName","LISTAUZY.grupa")
DBSetProp(ThisView+".grupa","Field","KeyField",.F.)
DBSetProp(ThisView+".grupa","Field","Updatable",.T.)

DBSetProp(ThisView+".typ","Field","DataType","C(1)")
DBSetProp(ThisView+".typ","Field","UpdateName","LISTAUZY.typ")
DBSetProp(ThisView+".typ","Field","KeyField",.F.)
DBSetProp(ThisView+".typ","Field","Updatable",.T.)

DBSetProp(ThisView+".nazwa","Field","DataType","C(30)")
DBSetProp(ThisView+".nazwa","Field","UpdateName","LISTAUZY.nazwa")
DBSetProp(ThisView+".nazwa","Field","KeyField",.F.)
DBSetProp(ThisView+".nazwa","Field","Updatable",.T.)

DBSetProp(ThisView+".pracownik","Field","DataType","C(10)")
DBSetProp(ThisView+".pracownik","Field","UpdateName","LISTAUZY.pracownik")
DBSetProp(ThisView+".pracownik","Field","KeyField",.F.)
DBSetProp(ThisView+".pracownik","Field","Updatable",.T.)

DBSetProp(ThisView+".ggrupa","Field","DataType","C(5)")
DBSetProp(ThisView+".ggrupa","Field","UpdateName","LISTAUZY.ggrupa")
DBSetProp(ThisView+".ggrupa","Field","KeyField",.F.)
DBSetProp(ThisView+".ggrupa","Field","Updatable",.T.)

DBSetProp(ThisView+".pop_nr","Field","DataType","M")
DBSetProp(ThisView+".pop_nr","Field","UpdateName","LISTAUZY.pop_nr")
DBSetProp(ThisView+".pop_nr","Field","KeyField",.F.)
DBSetProp(ThisView+".pop_nr","Field","Updatable",.T.)

DBSetProp(ThisView+".pkt_kanc","Field","DataType","N(4)")
DBSetProp(ThisView+".pkt_kanc","Field","UpdateName","LISTAUZY.pkt_kanc")
DBSetProp(ThisView+".pkt_kanc","Field","KeyField",.F.)
DBSetProp(ThisView+".pkt_kanc","Field","Updatable",.T.)

DBSetProp(ThisView+".delegatura","Field","DataType","C(100)")
DBSetProp(ThisView+".delegatura","Field","UpdateName","LISTAUZY.delegatura")
DBSetProp(ThisView+".delegatura","Field","KeyField",.F.)
DBSetProp(ThisView+".delegatura","Field","Updatable",.T.)

DBSetProp(ThisView+".czykanc","Field","DataType","L")
DBSetProp(ThisView+".czykanc","Field","UpdateName","LISTAUZY.czykanc")
DBSetProp(ThisView+".czykanc","Field","KeyField",.F.)
DBSetProp(ThisView+".czykanc","Field","Updatable",.T.)

DBSetProp(ThisView+".wszystko","Field","DataType","L")
DBSetProp(ThisView+".wszystko","Field","UpdateName","LISTAUZY.wszystko")
DBSetProp(ThisView+".wszystko","Field","KeyField",.F.)
DBSetProp(ThisView+".wszystko","Field","Updatable",.T.)

DBSetProp(ThisView+".przelacz","Field","DataType","L")
DBSetProp(ThisView+".przelacz","Field","UpdateName","LISTAUZY.przelacz")
DBSetProp(ThisView+".przelacz","Field","KeyField",.F.)
DBSetProp(ThisView+".przelacz","Field","Updatable",.T.)

DBSetProp(ThisView+".przychod","Field","DataType","L")
DBSetProp(ThisView+".przychod","Field","UpdateName","LISTAUZY.przychod")
DBSetProp(ThisView+".przychod","Field","KeyField",.F.)
DBSetProp(ThisView+".przychod","Field","Updatable",.T.)

DBSetProp(ThisView+".wychodz","Field","DataType","L")
DBSetProp(ThisView+".wychodz","Field","UpdateName","LISTAUZY.wychodz")
DBSetProp(ThisView+".wychodz","Field","KeyField",.F.)
DBSetProp(ThisView+".wychodz","Field","Updatable",.T.)

DBSetProp(ThisView+".nowy_p","Field","DataType","L")
DBSetProp(ThisView+".nowy_p","Field","UpdateName","LISTAUZY.nowy_p")
DBSetProp(ThisView+".nowy_p","Field","KeyField",.F.)
DBSetProp(ThisView+".nowy_p","Field","Updatable",.T.)

DBSetProp(ThisView+".nowy_w","Field","DataType","L")
DBSetProp(ThisView+".nowy_w","Field","UpdateName","LISTAUZY.nowy_w")
DBSetProp(ThisView+".nowy_w","Field","KeyField",.F.)
DBSetProp(ThisView+".nowy_w","Field","Updatable",.T.)

DBSetProp(ThisView+".pnadawca","Field","DataType","L")
DBSetProp(ThisView+".pnadawca","Field","UpdateName","LISTAUZY.pnadawca")
DBSetProp(ThisView+".pnadawca","Field","KeyField",.F.)
DBSetProp(ThisView+".pnadawca","Field","Updatable",.T.)

DBSetProp(ThisView+".prodzprzes","Field","DataType","L")
DBSetProp(ThisView+".prodzprzes","Field","UpdateName","LISTAUZY.prodzprzes")
DBSetProp(ThisView+".prodzprzes","Field","KeyField",.F.)
DBSetProp(ThisView+".prodzprzes","Field","Updatable",.T.)

DBSetProp(ThisView+".pnrprzesyl","Field","DataType","L")
DBSetProp(ThisView+".pnrprzesyl","Field","UpdateName","LISTAUZY.pnrprzesyl")
DBSetProp(ThisView+".pnrprzesyl","Field","KeyField",.F.)
DBSetProp(ThisView+".pnrprzesyl","Field","Updatable",.T.)

DBSetProp(ThisView+".pdatawplyw","Field","DataType","L")
DBSetProp(ThisView+".pdatawplyw","Field","UpdateName","LISTAUZY.pdatawplyw")
DBSetProp(ThisView+".pdatawplyw","Field","KeyField",.F.)
DBSetProp(ThisView+".pdatawplyw","Field","Updatable",.T.)

DBSetProp(ThisView+".pdokogo","Field","DataType","L")
DBSetProp(ThisView+".pdokogo","Field","UpdateName","LISTAUZY.pdokogo")
DBSetProp(ThisView+".pdokogo","Field","KeyField",.F.)
DBSetProp(ThisView+".pdokogo","Field","Updatable",.T.)

DBSetProp(ThisView+".zm_hasla","Field","DataType","L")
DBSetProp(ThisView+".zm_hasla","Field","UpdateName","LISTAUZY.zm_hasla")
DBSetProp(ThisView+".zm_hasla","Field","KeyField",.F.)
DBSetProp(ThisView+".zm_hasla","Field","Updatable",.T.)

DBSetProp(ThisView+".skrytka","Field","DataType","L")
DBSetProp(ThisView+".skrytka","Field","UpdateName","LISTAUZY.skrytka")
DBSetProp(ThisView+".skrytka","Field","KeyField",.F.)
DBSetProp(ThisView+".skrytka","Field","Updatable",.T.)

DBSetProp(ThisView+".rejestr","Field","DataType","L")
DBSetProp(ThisView+".rejestr","Field","UpdateName","LISTAUZY.rejestr")
DBSetProp(ThisView+".rejestr","Field","KeyField",.F.)
DBSetProp(ThisView+".rejestr","Field","Updatable",.T.)

DBSetProp(ThisView+".adr_mod_z","Field","DataType","L")
DBSetProp(ThisView+".adr_mod_z","Field","UpdateName","LISTAUZY.adr_mod_z")
DBSetProp(ThisView+".adr_mod_z","Field","KeyField",.F.)
DBSetProp(ThisView+".adr_mod_z","Field","Updatable",.T.)

DBSetProp(ThisView+".copy_p","Field","DataType","L")
DBSetProp(ThisView+".copy_p","Field","UpdateName","LISTAUZY.copy_p")
DBSetProp(ThisView+".copy_p","Field","KeyField",.F.)
DBSetProp(ThisView+".copy_p","Field","Updatable",.T.)

DBSetProp(ThisView+".copy_w","Field","DataType","L")
DBSetProp(ThisView+".copy_w","Field","UpdateName","LISTAUZY.copy_w")
DBSetProp(ThisView+".copy_w","Field","KeyField",.F.)
DBSetProp(ThisView+".copy_w","Field","Updatable",.T.)

DBSetProp(ThisView+".wnrprzesyl","Field","DataType","L")
DBSetProp(ThisView+".wnrprzesyl","Field","UpdateName","LISTAUZY.wnrprzesyl")
DBSetProp(ThisView+".wnrprzesyl","Field","KeyField",.F.)
DBSetProp(ThisView+".wnrprzesyl","Field","Updatable",.T.)

DBSetProp(ThisView+".cofanie_p","Field","DataType","L")
DBSetProp(ThisView+".cofanie_p","Field","UpdateName","LISTAUZY.cofanie_p")
DBSetProp(ThisView+".cofanie_p","Field","KeyField",.F.)
DBSetProp(ThisView+".cofanie_p","Field","Updatable",.T.)

DBSetProp(ThisView+".cofanie_w","Field","DataType","L")
DBSetProp(ThisView+".cofanie_w","Field","UpdateName","LISTAUZY.cofanie_w")
DBSetProp(ThisView+".cofanie_w","Field","KeyField",.F.)
DBSetProp(ThisView+".cofanie_w","Field","Updatable",.T.)

DBSetProp(ThisView+".aktywne","Field","DataType","L")
DBSetProp(ThisView+".aktywne","Field","UpdateName","LISTAUZY.aktywne")
DBSetProp(ThisView+".aktywne","Field","KeyField",.F.)
DBSetProp(ThisView+".aktywne","Field","Updatable",.T.)

DBSetProp(ThisView+".wom","Field","DataType","L")
DBSetProp(ThisView+".wom","Field","UpdateName","LISTAUZY.wom")
DBSetProp(ThisView+".wom","Field","KeyField",.F.)
DBSetProp(ThisView+".wom","Field","Updatable",.T.)

DBSetProp(ThisView+".sldotyczy","Field","DataType","L")
DBSetProp(ThisView+".sldotyczy","Field","UpdateName","LISTAUZY.sldotyczy")
DBSetProp(ThisView+".sldotyczy","Field","KeyField",.F.)
DBSetProp(ThisView+".sldotyczy","Field","Updatable",.T.)

DBSetProp(ThisView+".widocznep","Field","DataType","L")
DBSetProp(ThisView+".widocznep","Field","UpdateName","LISTAUZY.widocznep")
DBSetProp(ThisView+".widocznep","Field","KeyField",.F.)
DBSetProp(ThisView+".widocznep","Field","Updatable",.T.)

DBSetProp(ThisView+".usun_p","Field","DataType","L")
DBSetProp(ThisView+".usun_p","Field","UpdateName","LISTAUZY.usun_p")
DBSetProp(ThisView+".usun_p","Field","KeyField",.F.)
DBSetProp(ThisView+".usun_p","Field","Updatable",.T.)

DBSetProp(ThisView+".usun_w","Field","DataType","L")
DBSetProp(ThisView+".usun_w","Field","UpdateName","LISTAUZY.usun_w")
DBSetProp(ThisView+".usun_w","Field","KeyField",.F.)
DBSetProp(ThisView+".usun_w","Field","Updatable",.T.)

DBSetProp(ThisView+".timestamp_column","Field","DataType","T")
DBSetProp(ThisView+".timestamp_column","Field","UpdateName","LISTAUZY.timestamp_column")
DBSetProp(ThisView+".timestamp_column","Field","KeyField",.F.)
DBSetProp(ThisView+".timestamp_column","Field","Updatable",.T.)

DBSetProp(ThisView+".serial_id","Field","DataType","I")
DBSetProp(ThisView+".serial_id","Field","UpdateName","LISTAUZY.serial_id")
DBSetProp(ThisView+".serial_id","Field","KeyField",.T.)
DBSetProp(ThisView+".serial_id","Field","Updatable",.T.)

