ThisView = 'v_wychodzace_do_przekazania'
IF  INDBC(ThisView,"VIEW")
	DROP VIEW (ThisView)
ENDI
CREATE SQL VIEW (ThisView) CONNECTION 'conPostgres' SHAR as ;
SELECT L.grupa AS nast_stano_grupa, '      ' AS nast_stano_opis,;
  L.typ AS nast_stano_typ, 0 AS nrdzienp, W.grupa, W.pnrdzien, W.nrdzien,;
  W.adrsatmie, W.adrsatadr, W.adrsarnaz, W.nadawca, W.nadwcaznk, W.datapisma,;
  W.dotyczy, W.nrsprawy, W.datawysl, W.rodzprzes, W.nrprzesyl, W.taryfpocz,;
  W.waga, W.przekaz, W.zaliczka, W.termins, W.zalatw, W.idpisma, W.idprzy, W.nrk,;
  W.nrd, W.rejestrowa, W.idw, W.idw_copy, W.nr_copy, W.rok, W.date_stamp, W.kgrupa,;
  W.knrdzien, W.id_poprz, W.data_zmian, W.id_zmien, W.podp_zmien, W.zrodlo,;
  W.kod, W.kraj_id, W.maska, W.czy_zagr, W.p_d_id, W.nast_stano, W.idplanu,;
  W.po_id, W.po_next_id, W.id_dotyczy, W.timestamp_column, W.serial_id,;
  W.dataoszp, W.dataodebr, W.aktualnie ;
 FROM ;
     wychodz W,;
    struktura S,;
    listauzy L,;
    nadania N;
 WHERE ( (  S.id_stanowiska = N.id_stanowiska;
   AND  S.id_stanowiska = W.nast_stano );
   AND  N.id_uzyt = L.id_uzy );
   AND  W.aktualnie = ( ?STANOWISKO_ID );
 ORDER BY L.grupa, W.nrdzien

DBSetProp(ThisView,"View","SendUpdates",.F.)
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
DBSetProp(ThisView,"View","Tables","listauzy,wychodz")
DBSetProp(ThisView,"View","WhereType",3)

DBSetProp(ThisView+".nast_stano_grupa","Field","DataType","C(5)")
DBSetProp(ThisView+".nast_stano_grupa","Field","UpdateName","listauzy.grupa")
DBSetProp(ThisView+".nast_stano_grupa","Field","KeyField",.F.)
DBSetProp(ThisView+".nast_stano_grupa","Field","Updatable",.T.)

DBSetProp(ThisView+".nast_stano_opis","Field","DataType","M")
DBSetProp(ThisView+".nast_stano_opis","Field","UpdateName","nast_stano_opis")
DBSetProp(ThisView+".nast_stano_opis","Field","KeyField",.F.)
DBSetProp(ThisView+".nast_stano_opis","Field","Updatable",.F.)

DBSetProp(ThisView+".nast_stano_typ","Field","DataType","C(1)")
DBSetProp(ThisView+".nast_stano_typ","Field","UpdateName","listauzy.typ")
DBSetProp(ThisView+".nast_stano_typ","Field","KeyField",.F.)
DBSetProp(ThisView+".nast_stano_typ","Field","Updatable",.T.)

DBSetProp(ThisView+".nrdzienp","Field","DataType","I")
DBSetProp(ThisView+".nrdzienp","Field","UpdateName","nrdzienp")
DBSetProp(ThisView+".nrdzienp","Field","KeyField",.F.)
DBSetProp(ThisView+".nrdzienp","Field","Updatable",.F.)

DBSetProp(ThisView+".grupa","Field","DataType","C(5)")
DBSetProp(ThisView+".grupa","Field","UpdateName","wychodz.grupa")
DBSetProp(ThisView+".grupa","Field","KeyField",.F.)
DBSetProp(ThisView+".grupa","Field","Updatable",.T.)

DBSetProp(ThisView+".pnrdzien","Field","DataType","I")
DBSetProp(ThisView+".pnrdzien","Field","UpdateName","wychodz.pnrdzien")
DBSetProp(ThisView+".pnrdzien","Field","KeyField",.F.)
DBSetProp(ThisView+".pnrdzien","Field","Updatable",.T.)

DBSetProp(ThisView+".nrdzien","Field","DataType","I")
DBSetProp(ThisView+".nrdzien","Field","UpdateName","wychodz.nrdzien")
DBSetProp(ThisView+".nrdzien","Field","KeyField",.F.)
DBSetProp(ThisView+".nrdzien","Field","Updatable",.T.)

DBSetProp(ThisView+".adrsatmie","Field","DataType","C(35)")
DBSetProp(ThisView+".adrsatmie","Field","UpdateName","wychodz.adrsatmie")
DBSetProp(ThisView+".adrsatmie","Field","KeyField",.F.)
DBSetProp(ThisView+".adrsatmie","Field","Updatable",.T.)

DBSetProp(ThisView+".adrsatadr","Field","DataType","C(40)")
DBSetProp(ThisView+".adrsatadr","Field","UpdateName","wychodz.adrsatadr")
DBSetProp(ThisView+".adrsatadr","Field","KeyField",.F.)
DBSetProp(ThisView+".adrsatadr","Field","Updatable",.T.)

DBSetProp(ThisView+".adrsarnaz","Field","DataType","C(80)")
DBSetProp(ThisView+".adrsarnaz","Field","UpdateName","wychodz.adrsarnaz")
DBSetProp(ThisView+".adrsarnaz","Field","KeyField",.F.)
DBSetProp(ThisView+".adrsarnaz","Field","Updatable",.T.)

DBSetProp(ThisView+".nadawca","Field","DataType","C(60)")
DBSetProp(ThisView+".nadawca","Field","UpdateName","wychodz.nadawca")
DBSetProp(ThisView+".nadawca","Field","KeyField",.F.)
DBSetProp(ThisView+".nadawca","Field","Updatable",.T.)

DBSetProp(ThisView+".nadwcaznk","Field","DataType","C(40)")
DBSetProp(ThisView+".nadwcaznk","Field","UpdateName","wychodz.nadwcaznk")
DBSetProp(ThisView+".nadwcaznk","Field","KeyField",.F.)
DBSetProp(ThisView+".nadwcaznk","Field","Updatable",.T.)

DBSetProp(ThisView+".datapisma","Field","DataType","T")
DBSetProp(ThisView+".datapisma","Field","UpdateName","wychodz.datapisma")
DBSetProp(ThisView+".datapisma","Field","KeyField",.F.)
DBSetProp(ThisView+".datapisma","Field","Updatable",.T.)

DBSetProp(ThisView+".dotyczy","Field","DataType","C(254)")
DBSetProp(ThisView+".dotyczy","Field","UpdateName","wychodz.dotyczy")
DBSetProp(ThisView+".dotyczy","Field","KeyField",.F.)
DBSetProp(ThisView+".dotyczy","Field","Updatable",.T.)

DBSetProp(ThisView+".nrsprawy","Field","DataType","C(40)")
DBSetProp(ThisView+".nrsprawy","Field","UpdateName","wychodz.nrsprawy")
DBSetProp(ThisView+".nrsprawy","Field","KeyField",.F.)
DBSetProp(ThisView+".nrsprawy","Field","Updatable",.T.)

DBSetProp(ThisView+".datawysl","Field","DataType","T")
DBSetProp(ThisView+".datawysl","Field","UpdateName","wychodz.datawysl")
DBSetProp(ThisView+".datawysl","Field","KeyField",.F.)
DBSetProp(ThisView+".datawysl","Field","Updatable",.T.)

DBSetProp(ThisView+".rodzprzes","Field","DataType","C(5)")
DBSetProp(ThisView+".rodzprzes","Field","UpdateName","wychodz.rodzprzes")
DBSetProp(ThisView+".rodzprzes","Field","KeyField",.F.)
DBSetProp(ThisView+".rodzprzes","Field","Updatable",.T.)

DBSetProp(ThisView+".nrprzesyl","Field","DataType","C(10)")
DBSetProp(ThisView+".nrprzesyl","Field","UpdateName","wychodz.nrprzesyl")
DBSetProp(ThisView+".nrprzesyl","Field","KeyField",.F.)
DBSetProp(ThisView+".nrprzesyl","Field","Updatable",.T.)

DBSetProp(ThisView+".taryfpocz","Field","DataType","N(8,2)")
DBSetProp(ThisView+".taryfpocz","Field","UpdateName","wychodz.taryfpocz")
DBSetProp(ThisView+".taryfpocz","Field","KeyField",.F.)
DBSetProp(ThisView+".taryfpocz","Field","Updatable",.T.)

DBSetProp(ThisView+".waga","Field","DataType","N(10)")
DBSetProp(ThisView+".waga","Field","UpdateName","wychodz.waga")
DBSetProp(ThisView+".waga","Field","KeyField",.F.)
DBSetProp(ThisView+".waga","Field","Updatable",.T.)

DBSetProp(ThisView+".przekaz","Field","DataType","C(1)")
DBSetProp(ThisView+".przekaz","Field","UpdateName","wychodz.przekaz")
DBSetProp(ThisView+".przekaz","Field","KeyField",.F.)
DBSetProp(ThisView+".przekaz","Field","Updatable",.T.)

DBSetProp(ThisView+".zaliczka","Field","DataType","N(10,2)")
DBSetProp(ThisView+".zaliczka","Field","UpdateName","wychodz.zaliczka")
DBSetProp(ThisView+".zaliczka","Field","KeyField",.F.)
DBSetProp(ThisView+".zaliczka","Field","Updatable",.T.)

DBSetProp(ThisView+".termins","Field","DataType","T")
DBSetProp(ThisView+".termins","Field","UpdateName","wychodz.termins")
DBSetProp(ThisView+".termins","Field","KeyField",.F.)
DBSetProp(ThisView+".termins","Field","Updatable",.T.)

DBSetProp(ThisView+".zalatw","Field","DataType","L")
DBSetProp(ThisView+".zalatw","Field","UpdateName","wychodz.zalatw")
DBSetProp(ThisView+".zalatw","Field","KeyField",.F.)
DBSetProp(ThisView+".zalatw","Field","Updatable",.T.)

DBSetProp(ThisView+".idpisma","Field","DataType","I")
DBSetProp(ThisView+".idpisma","Field","UpdateName","wychodz.idpisma")
DBSetProp(ThisView+".idpisma","Field","KeyField",.F.)
DBSetProp(ThisView+".idpisma","Field","Updatable",.T.)

DBSetProp(ThisView+".idprzy","Field","DataType","I")
DBSetProp(ThisView+".idprzy","Field","UpdateName","wychodz.idprzy")
DBSetProp(ThisView+".idprzy","Field","KeyField",.F.)
DBSetProp(ThisView+".idprzy","Field","Updatable",.T.)

DBSetProp(ThisView+".nrk","Field","DataType","C(10)")
DBSetProp(ThisView+".nrk","Field","UpdateName","wychodz.nrk")
DBSetProp(ThisView+".nrk","Field","KeyField",.F.)
DBSetProp(ThisView+".nrk","Field","Updatable",.T.)

DBSetProp(ThisView+".nrd","Field","DataType","C(1)")
DBSetProp(ThisView+".nrd","Field","UpdateName","wychodz.nrd")
DBSetProp(ThisView+".nrd","Field","KeyField",.F.)
DBSetProp(ThisView+".nrd","Field","Updatable",.T.)

DBSetProp(ThisView+".rejestrowa","Field","DataType","L")
DBSetProp(ThisView+".rejestrowa","Field","UpdateName","wychodz.rejestrowa")
DBSetProp(ThisView+".rejestrowa","Field","KeyField",.F.)
DBSetProp(ThisView+".rejestrowa","Field","Updatable",.T.)

DBSetProp(ThisView+".idw","Field","DataType","I")
DBSetProp(ThisView+".idw","Field","UpdateName","wychodz.idw")
DBSetProp(ThisView+".idw","Field","KeyField",.F.)
DBSetProp(ThisView+".idw","Field","Updatable",.T.)

DBSetProp(ThisView+".idw_copy","Field","DataType","I")
DBSetProp(ThisView+".idw_copy","Field","UpdateName","wychodz.idw_copy")
DBSetProp(ThisView+".idw_copy","Field","KeyField",.F.)
DBSetProp(ThisView+".idw_copy","Field","Updatable",.T.)

DBSetProp(ThisView+".nr_copy","Field","DataType","I")
DBSetProp(ThisView+".nr_copy","Field","UpdateName","wychodz.nr_copy")
DBSetProp(ThisView+".nr_copy","Field","KeyField",.F.)
DBSetProp(ThisView+".nr_copy","Field","Updatable",.T.)

DBSetProp(ThisView+".rok","Field","DataType","I")
DBSetProp(ThisView+".rok","Field","UpdateName","wychodz.rok")
DBSetProp(ThisView+".rok","Field","KeyField",.F.)
DBSetProp(ThisView+".rok","Field","Updatable",.T.)

DBSetProp(ThisView+".date_stamp","Field","DataType","T")
DBSetProp(ThisView+".date_stamp","Field","UpdateName","wychodz.date_stamp")
DBSetProp(ThisView+".date_stamp","Field","KeyField",.F.)
DBSetProp(ThisView+".date_stamp","Field","Updatable",.T.)

DBSetProp(ThisView+".kgrupa","Field","DataType","C(5)")
DBSetProp(ThisView+".kgrupa","Field","UpdateName","wychodz.kgrupa")
DBSetProp(ThisView+".kgrupa","Field","KeyField",.F.)
DBSetProp(ThisView+".kgrupa","Field","Updatable",.T.)

DBSetProp(ThisView+".knrdzien","Field","DataType","I")
DBSetProp(ThisView+".knrdzien","Field","UpdateName","wychodz.knrdzien")
DBSetProp(ThisView+".knrdzien","Field","KeyField",.F.)
DBSetProp(ThisView+".knrdzien","Field","Updatable",.T.)

DBSetProp(ThisView+".id_poprz","Field","DataType","I")
DBSetProp(ThisView+".id_poprz","Field","UpdateName","wychodz.id_poprz")
DBSetProp(ThisView+".id_poprz","Field","KeyField",.F.)
DBSetProp(ThisView+".id_poprz","Field","Updatable",.T.)

DBSetProp(ThisView+".data_zmian","Field","DataType","T")
DBSetProp(ThisView+".data_zmian","Field","UpdateName","wychodz.data_zmian")
DBSetProp(ThisView+".data_zmian","Field","KeyField",.F.)
DBSetProp(ThisView+".data_zmian","Field","Updatable",.T.)

DBSetProp(ThisView+".id_zmien","Field","DataType","I")
DBSetProp(ThisView+".id_zmien","Field","UpdateName","wychodz.id_zmien")
DBSetProp(ThisView+".id_zmien","Field","KeyField",.F.)
DBSetProp(ThisView+".id_zmien","Field","Updatable",.T.)

DBSetProp(ThisView+".podp_zmien","Field","DataType","M")
DBSetProp(ThisView+".podp_zmien","Field","UpdateName","wychodz.podp_zmien")
DBSetProp(ThisView+".podp_zmien","Field","KeyField",.F.)
DBSetProp(ThisView+".podp_zmien","Field","Updatable",.T.)

DBSetProp(ThisView+".zrodlo","Field","DataType","C(50)")
DBSetProp(ThisView+".zrodlo","Field","UpdateName","wychodz.zrodlo")
DBSetProp(ThisView+".zrodlo","Field","KeyField",.F.)
DBSetProp(ThisView+".zrodlo","Field","Updatable",.T.)

DBSetProp(ThisView+".kod","Field","DataType","C(20)")
DBSetProp(ThisView+".kod","Field","UpdateName","wychodz.kod")
DBSetProp(ThisView+".kod","Field","KeyField",.F.)
DBSetProp(ThisView+".kod","Field","Updatable",.T.)

DBSetProp(ThisView+".kraj_id","Field","DataType","I")
DBSetProp(ThisView+".kraj_id","Field","UpdateName","wychodz.kraj_id")
DBSetProp(ThisView+".kraj_id","Field","KeyField",.F.)
DBSetProp(ThisView+".kraj_id","Field","Updatable",.T.)

DBSetProp(ThisView+".maska","Field","DataType","C(20)")
DBSetProp(ThisView+".maska","Field","UpdateName","wychodz.maska")
DBSetProp(ThisView+".maska","Field","KeyField",.F.)
DBSetProp(ThisView+".maska","Field","Updatable",.T.)

DBSetProp(ThisView+".czy_zagr","Field","DataType","N(3)")
DBSetProp(ThisView+".czy_zagr","Field","UpdateName","wychodz.czy_zagr")
DBSetProp(ThisView+".czy_zagr","Field","KeyField",.F.)
DBSetProp(ThisView+".czy_zagr","Field","Updatable",.T.)

DBSetProp(ThisView+".p_d_id","Field","DataType","I")
DBSetProp(ThisView+".p_d_id","Field","UpdateName","wychodz.p_d_id")
DBSetProp(ThisView+".p_d_id","Field","KeyField",.F.)
DBSetProp(ThisView+".p_d_id","Field","Updatable",.T.)

DBSetProp(ThisView+".nast_stano","Field","DataType","I")
DBSetProp(ThisView+".nast_stano","Field","UpdateName","wychodz.nast_stano")
DBSetProp(ThisView+".nast_stano","Field","KeyField",.F.)
DBSetProp(ThisView+".nast_stano","Field","Updatable",.T.)

DBSetProp(ThisView+".idplanu","Field","DataType","I")
DBSetProp(ThisView+".idplanu","Field","UpdateName","wychodz.idplanu")
DBSetProp(ThisView+".idplanu","Field","KeyField",.F.)
DBSetProp(ThisView+".idplanu","Field","Updatable",.T.)

DBSetProp(ThisView+".po_id","Field","DataType","I")
DBSetProp(ThisView+".po_id","Field","UpdateName","wychodz.po_id")
DBSetProp(ThisView+".po_id","Field","KeyField",.F.)
DBSetProp(ThisView+".po_id","Field","Updatable",.T.)

DBSetProp(ThisView+".po_next_id","Field","DataType","I")
DBSetProp(ThisView+".po_next_id","Field","UpdateName","wychodz.po_next_id")
DBSetProp(ThisView+".po_next_id","Field","KeyField",.F.)
DBSetProp(ThisView+".po_next_id","Field","Updatable",.T.)

DBSetProp(ThisView+".id_dotyczy","Field","DataType","I")
DBSetProp(ThisView+".id_dotyczy","Field","UpdateName","wychodz.id_dotyczy")
DBSetProp(ThisView+".id_dotyczy","Field","KeyField",.F.)
DBSetProp(ThisView+".id_dotyczy","Field","Updatable",.T.)

DBSetProp(ThisView+".timestamp_column","Field","DataType","T")
DBSetProp(ThisView+".timestamp_column","Field","UpdateName","wychodz.timestamp_column")
DBSetProp(ThisView+".timestamp_column","Field","KeyField",.F.)
DBSetProp(ThisView+".timestamp_column","Field","Updatable",.T.)

DBSetProp(ThisView+".serial_id","Field","DataType","I")
DBSetProp(ThisView+".serial_id","Field","UpdateName","wychodz.serial_id")
DBSetProp(ThisView+".serial_id","Field","KeyField",.T.)
DBSetProp(ThisView+".serial_id","Field","Updatable",.F.)

DBSetProp(ThisView+".dataoszp","Field","DataType","T")
DBSetProp(ThisView+".dataoszp","Field","UpdateName","wychodz.dataoszp")
DBSetProp(ThisView+".dataoszp","Field","KeyField",.F.)
DBSetProp(ThisView+".dataoszp","Field","Updatable",.T.)

DBSetProp(ThisView+".dataodebr","Field","DataType","T")
DBSetProp(ThisView+".dataodebr","Field","UpdateName","wychodz.dataodebr")
DBSetProp(ThisView+".dataodebr","Field","KeyField",.F.)
DBSetProp(ThisView+".dataodebr","Field","Updatable",.T.)

DBSetProp(ThisView+".aktualnie","Field","DataType","I")
DBSetProp(ThisView+".aktualnie","Field","UpdateName","wychodz.aktualnie")
DBSetProp(ThisView+".aktualnie","Field","KeyField",.F.)
DBSetProp(ThisView+".aktualnie","Field","Updatable",.T.)


ThisView = 'v_przychodzace_do_przekazania'
IF  INDBC(ThisView,"VIEW")
	DROP VIEW (ThisView)
ENDI
CREATE SQL VIEW (ThisView) CONNECTION 'conPostgres' SHAR as ;
SELECT P.idpisma, P.pnrdzien, P.nadwcamie, P.nadwcaadr, P.nadwcanaz,;
  P.nadwcaznk, P.rodzprzes, P.nrprzesyl, P.datapisma, P.dotyczy, P.dokogo,;
  P.nrsprawy, P.grupa, P.datawplyw, P.nrdzien, P.termins, P.zalatw, P.grupaw,;
  P.nrdzienw, P.datapismaw, P.przekaz2, P.aktualnie, P.nast_stano, P.wystap,;
  P.uwagi, P.idw_copy, P.nr_copy, P.rok, P.up, P.ggrupa, P.id_poprz, P.data_zmian,;
  P.id_zmien, P.podp_zmien, P.kod, P.kraj_id, P.maska, P.czy_zagr, P.p_d_id,;
  P.idplanu, P.po_id, P.po_next_id, P.nr_kanc, P.id_dotyczy,;
  P.timestamp_column, P.serial_id, P.wiadomosc, '    ' AS nast_stano_opis,;
  L.typ AS nast_stano_typ, L.grupa AS nast_stano_grupa;
 FROM ;
     przychod P,;
    struktura S,;
    listauzy L,;
    nadania N;
 WHERE ( (  S.id_stanowiska = N.id_stanowiska;
   AND  S.id_stanowiska = P.nast_stano );
   AND  N.id_uzyt = L.id_uzy );
   AND  P.aktualnie = ( ?STANOWISKO_ID );
 ORDER BY P.grupa, P.pnrdzien, P.nrdzien

DBSetProp(ThisView,"View","SendUpdates",.F.)
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
DBSetProp(ThisView,"View","Tables","przychod")
DBSetProp(ThisView,"View","WhereType",1)

DBSetProp(ThisView+".idpisma","Field","DataType","N(12)")
DBSetProp(ThisView+".idpisma","Field","UpdateName","przychod.idpisma")
DBSetProp(ThisView+".idpisma","Field","KeyField",.T.)
DBSetProp(ThisView+".idpisma","Field","Updatable",.F.)

DBSetProp(ThisView+".pnrdzien","Field","DataType","N(8)")
DBSetProp(ThisView+".pnrdzien","Field","UpdateName","przychod.pnrdzien")
DBSetProp(ThisView+".pnrdzien","Field","KeyField",.F.)
DBSetProp(ThisView+".pnrdzien","Field","Updatable",.T.)

DBSetProp(ThisView+".nadwcamie","Field","DataType","C(35)")
DBSetProp(ThisView+".nadwcamie","Field","UpdateName","przychod.nadwcamie")
DBSetProp(ThisView+".nadwcamie","Field","KeyField",.F.)
DBSetProp(ThisView+".nadwcamie","Field","Updatable",.T.)

DBSetProp(ThisView+".nadwcaadr","Field","DataType","C(40)")
DBSetProp(ThisView+".nadwcaadr","Field","UpdateName","przychod.nadwcaadr")
DBSetProp(ThisView+".nadwcaadr","Field","KeyField",.F.)
DBSetProp(ThisView+".nadwcaadr","Field","Updatable",.T.)

DBSetProp(ThisView+".nadwcanaz","Field","DataType","C(80)")
DBSetProp(ThisView+".nadwcanaz","Field","UpdateName","przychod.nadwcanaz")
DBSetProp(ThisView+".nadwcanaz","Field","KeyField",.F.)
DBSetProp(ThisView+".nadwcanaz","Field","Updatable",.T.)

DBSetProp(ThisView+".nadwcaznk","Field","DataType","C(40)")
DBSetProp(ThisView+".nadwcaznk","Field","UpdateName","przychod.nadwcaznk")
DBSetProp(ThisView+".nadwcaznk","Field","KeyField",.F.)
DBSetProp(ThisView+".nadwcaznk","Field","Updatable",.T.)

DBSetProp(ThisView+".rodzprzes","Field","DataType","C(5)")
DBSetProp(ThisView+".rodzprzes","Field","UpdateName","przychod.rodzprzes")
DBSetProp(ThisView+".rodzprzes","Field","KeyField",.F.)
DBSetProp(ThisView+".rodzprzes","Field","Updatable",.T.)

DBSetProp(ThisView+".nrprzesyl","Field","DataType","C(30)")
DBSetProp(ThisView+".nrprzesyl","Field","UpdateName","przychod.nrprzesyl")
DBSetProp(ThisView+".nrprzesyl","Field","KeyField",.F.)
DBSetProp(ThisView+".nrprzesyl","Field","Updatable",.T.)

DBSetProp(ThisView+".datapisma","Field","DataType","D")
DBSetProp(ThisView+".datapisma","Field","UpdateName","przychod.datapisma")
DBSetProp(ThisView+".datapisma","Field","KeyField",.F.)
DBSetProp(ThisView+".datapisma","Field","Updatable",.T.)

DBSetProp(ThisView+".dotyczy","Field","DataType","C(254)")
DBSetProp(ThisView+".dotyczy","Field","UpdateName","przychod.dotyczy")
DBSetProp(ThisView+".dotyczy","Field","KeyField",.F.)
DBSetProp(ThisView+".dotyczy","Field","Updatable",.T.)

DBSetProp(ThisView+".dokogo","Field","DataType","C(40)")
DBSetProp(ThisView+".dokogo","Field","UpdateName","przychod.dokogo")
DBSetProp(ThisView+".dokogo","Field","KeyField",.F.)
DBSetProp(ThisView+".dokogo","Field","Updatable",.T.)

DBSetProp(ThisView+".nrsprawy","Field","DataType","C(40)")
DBSetProp(ThisView+".nrsprawy","Field","UpdateName","przychod.nrsprawy")
DBSetProp(ThisView+".nrsprawy","Field","KeyField",.F.)
DBSetProp(ThisView+".nrsprawy","Field","Updatable",.T.)

DBSetProp(ThisView+".grupa","Field","DataType","C(5)")
DBSetProp(ThisView+".grupa","Field","UpdateName","przychod.grupa")
DBSetProp(ThisView+".grupa","Field","KeyField",.F.)
DBSetProp(ThisView+".grupa","Field","Updatable",.T.)

DBSetProp(ThisView+".datawplyw","Field","DataType","D")
DBSetProp(ThisView+".datawplyw","Field","UpdateName","przychod.datawplyw")
DBSetProp(ThisView+".datawplyw","Field","KeyField",.F.)
DBSetProp(ThisView+".datawplyw","Field","Updatable",.T.)

DBSetProp(ThisView+".nrdzien","Field","DataType","N(8)")
DBSetProp(ThisView+".nrdzien","Field","UpdateName","przychod.nrdzien")
DBSetProp(ThisView+".nrdzien","Field","KeyField",.F.)
DBSetProp(ThisView+".nrdzien","Field","Updatable",.T.)

DBSetProp(ThisView+".termins","Field","DataType","D")
DBSetProp(ThisView+".termins","Field","UpdateName","przychod.termins")
DBSetProp(ThisView+".termins","Field","KeyField",.F.)
DBSetProp(ThisView+".termins","Field","Updatable",.T.)

DBSetProp(ThisView+".zalatw","Field","DataType","C(1)")
DBSetProp(ThisView+".zalatw","Field","UpdateName","przychod.zalatw")
DBSetProp(ThisView+".zalatw","Field","KeyField",.F.)
DBSetProp(ThisView+".zalatw","Field","Updatable",.T.)

DBSetProp(ThisView+".grupaw","Field","DataType","C(5)")
DBSetProp(ThisView+".grupaw","Field","UpdateName","przychod.grupaw")
DBSetProp(ThisView+".grupaw","Field","KeyField",.F.)
DBSetProp(ThisView+".grupaw","Field","Updatable",.T.)

DBSetProp(ThisView+".nrdzienw","Field","DataType","N(8)")
DBSetProp(ThisView+".nrdzienw","Field","UpdateName","przychod.nrdzienw")
DBSetProp(ThisView+".nrdzienw","Field","KeyField",.F.)
DBSetProp(ThisView+".nrdzienw","Field","Updatable",.T.)

DBSetProp(ThisView+".datapismaw","Field","DataType","D")
DBSetProp(ThisView+".datapismaw","Field","UpdateName","przychod.datapismaw")
DBSetProp(ThisView+".datapismaw","Field","KeyField",.F.)
DBSetProp(ThisView+".datapismaw","Field","Updatable",.T.)

DBSetProp(ThisView+".przekaz2","Field","DataType","C(1)")
DBSetProp(ThisView+".przekaz2","Field","UpdateName","przychod.przekaz2")
DBSetProp(ThisView+".przekaz2","Field","KeyField",.F.)
DBSetProp(ThisView+".przekaz2","Field","Updatable",.T.)

DBSetProp(ThisView+".aktualnie","Field","DataType","N(12)")
DBSetProp(ThisView+".aktualnie","Field","UpdateName","przychod.aktualnie")
DBSetProp(ThisView+".aktualnie","Field","KeyField",.F.)
DBSetProp(ThisView+".aktualnie","Field","Updatable",.T.)

DBSetProp(ThisView+".nast_stano","Field","DataType","N(12)")
DBSetProp(ThisView+".nast_stano","Field","UpdateName","przychod.nast_stano")
DBSetProp(ThisView+".nast_stano","Field","KeyField",.F.)
DBSetProp(ThisView+".nast_stano","Field","Updatable",.T.)

DBSetProp(ThisView+".wystap","Field","DataType","N(3)")
DBSetProp(ThisView+".wystap","Field","UpdateName","przychod.wystap")
DBSetProp(ThisView+".wystap","Field","KeyField",.F.)
DBSetProp(ThisView+".wystap","Field","Updatable",.T.)

DBSetProp(ThisView+".uwagi","Field","DataType","C(254)")
DBSetProp(ThisView+".uwagi","Field","UpdateName","przychod.uwagi")
DBSetProp(ThisView+".uwagi","Field","KeyField",.F.)
DBSetProp(ThisView+".uwagi","Field","Updatable",.T.)

DBSetProp(ThisView+".idw_copy","Field","DataType","N(12)")
DBSetProp(ThisView+".idw_copy","Field","UpdateName","przychod.idw_copy")
DBSetProp(ThisView+".idw_copy","Field","KeyField",.F.)
DBSetProp(ThisView+".idw_copy","Field","Updatable",.T.)

DBSetProp(ThisView+".nr_copy","Field","DataType","N(5)")
DBSetProp(ThisView+".nr_copy","Field","UpdateName","przychod.nr_copy")
DBSetProp(ThisView+".nr_copy","Field","KeyField",.F.)
DBSetProp(ThisView+".nr_copy","Field","Updatable",.T.)

DBSetProp(ThisView+".rok","Field","DataType","N(6)")
DBSetProp(ThisView+".rok","Field","UpdateName","przychod.rok")
DBSetProp(ThisView+".rok","Field","KeyField",.F.)
DBSetProp(ThisView+".rok","Field","Updatable",.T.)

DBSetProp(ThisView+".up","Field","DataType","C(25)")
DBSetProp(ThisView+".up","Field","UpdateName","przychod.up")
DBSetProp(ThisView+".up","Field","KeyField",.F.)
DBSetProp(ThisView+".up","Field","Updatable",.T.)

DBSetProp(ThisView+".ggrupa","Field","DataType","C(5)")
DBSetProp(ThisView+".ggrupa","Field","UpdateName","przychod.ggrupa")
DBSetProp(ThisView+".ggrupa","Field","KeyField",.F.)
DBSetProp(ThisView+".ggrupa","Field","Updatable",.T.)

DBSetProp(ThisView+".id_poprz","Field","DataType","N(12)")
DBSetProp(ThisView+".id_poprz","Field","UpdateName","przychod.id_poprz")
DBSetProp(ThisView+".id_poprz","Field","KeyField",.F.)
DBSetProp(ThisView+".id_poprz","Field","Updatable",.T.)

DBSetProp(ThisView+".data_zmian","Field","DataType","D")
DBSetProp(ThisView+".data_zmian","Field","UpdateName","przychod.data_zmian")
DBSetProp(ThisView+".data_zmian","Field","KeyField",.F.)
DBSetProp(ThisView+".data_zmian","Field","Updatable",.T.)

DBSetProp(ThisView+".id_zmien","Field","DataType","N(12)")
DBSetProp(ThisView+".id_zmien","Field","UpdateName","przychod.id_zmien")
DBSetProp(ThisView+".id_zmien","Field","KeyField",.F.)
DBSetProp(ThisView+".id_zmien","Field","Updatable",.T.)

DBSetProp(ThisView+".podp_zmien","Field","DataType","M")
DBSetProp(ThisView+".podp_zmien","Field","UpdateName","przychod.podp_zmien")
DBSetProp(ThisView+".podp_zmien","Field","KeyField",.F.)
DBSetProp(ThisView+".podp_zmien","Field","Updatable",.T.)

DBSetProp(ThisView+".kod","Field","DataType","C(20)")
DBSetProp(ThisView+".kod","Field","UpdateName","przychod.kod")
DBSetProp(ThisView+".kod","Field","KeyField",.F.)
DBSetProp(ThisView+".kod","Field","Updatable",.T.)

DBSetProp(ThisView+".kraj_id","Field","DataType","N(6)")
DBSetProp(ThisView+".kraj_id","Field","UpdateName","przychod.kraj_id")
DBSetProp(ThisView+".kraj_id","Field","KeyField",.F.)
DBSetProp(ThisView+".kraj_id","Field","Updatable",.T.)

DBSetProp(ThisView+".maska","Field","DataType","C(20)")
DBSetProp(ThisView+".maska","Field","UpdateName","przychod.maska")
DBSetProp(ThisView+".maska","Field","KeyField",.F.)
DBSetProp(ThisView+".maska","Field","Updatable",.T.)

DBSetProp(ThisView+".czy_zagr","Field","DataType","N(3)")
DBSetProp(ThisView+".czy_zagr","Field","UpdateName","przychod.czy_zagr")
DBSetProp(ThisView+".czy_zagr","Field","KeyField",.F.)
DBSetProp(ThisView+".czy_zagr","Field","Updatable",.T.)

DBSetProp(ThisView+".p_d_id","Field","DataType","N(12)")
DBSetProp(ThisView+".p_d_id","Field","UpdateName","przychod.p_d_id")
DBSetProp(ThisView+".p_d_id","Field","KeyField",.F.)
DBSetProp(ThisView+".p_d_id","Field","Updatable",.T.)

DBSetProp(ThisView+".idplanu","Field","DataType","N(17)")
DBSetProp(ThisView+".idplanu","Field","UpdateName","przychod.idplanu")
DBSetProp(ThisView+".idplanu","Field","KeyField",.F.)
DBSetProp(ThisView+".idplanu","Field","Updatable",.T.)

DBSetProp(ThisView+".po_id","Field","DataType","N(17)")
DBSetProp(ThisView+".po_id","Field","UpdateName","przychod.po_id")
DBSetProp(ThisView+".po_id","Field","KeyField",.F.)
DBSetProp(ThisView+".po_id","Field","Updatable",.T.)

DBSetProp(ThisView+".po_next_id","Field","DataType","N(17)")
DBSetProp(ThisView+".po_next_id","Field","UpdateName","przychod.po_next_id")
DBSetProp(ThisView+".po_next_id","Field","KeyField",.F.)
DBSetProp(ThisView+".po_next_id","Field","Updatable",.T.)

DBSetProp(ThisView+".nr_kanc","Field","DataType","C(26)")
DBSetProp(ThisView+".nr_kanc","Field","UpdateName","przychod.nr_kanc")
DBSetProp(ThisView+".nr_kanc","Field","KeyField",.F.)
DBSetProp(ThisView+".nr_kanc","Field","Updatable",.T.)

DBSetProp(ThisView+".id_dotyczy","Field","DataType","N(7)")
DBSetProp(ThisView+".id_dotyczy","Field","UpdateName","przychod.id_dotyczy")
DBSetProp(ThisView+".id_dotyczy","Field","KeyField",.F.)
DBSetProp(ThisView+".id_dotyczy","Field","Updatable",.T.)

DBSetProp(ThisView+".timestamp_column","Field","DataType","T")
DBSetProp(ThisView+".timestamp_column","Field","UpdateName","przychod.timestamp_column")
DBSetProp(ThisView+".timestamp_column","Field","KeyField",.F.)
DBSetProp(ThisView+".timestamp_column","Field","Updatable",.T.)

DBSetProp(ThisView+".serial_id","Field","DataType","I")
DBSetProp(ThisView+".serial_id","Field","UpdateName","przychod.serial_id")
DBSetProp(ThisView+".serial_id","Field","KeyField",.T.)
DBSetProp(ThisView+".serial_id","Field","Updatable",.T.)

DBSetProp(ThisView+".wiadomosc","Field","DataType","L")
DBSetProp(ThisView+".wiadomosc","Field","UpdateName","przychod.wiadomosc")
DBSetProp(ThisView+".wiadomosc","Field","KeyField",.F.)
DBSetProp(ThisView+".wiadomosc","Field","Updatable",.T.)

DBSetProp(ThisView+".nast_stano_opis","Field","DataType","M")
DBSetProp(ThisView+".nast_stano_opis","Field","UpdateName","nast_stano_opis")
DBSetProp(ThisView+".nast_stano_opis","Field","KeyField",.F.)
DBSetProp(ThisView+".nast_stano_opis","Field","Updatable",.F.)

DBSetProp(ThisView+".nast_stano_typ","Field","DataType","C(1)")
DBSetProp(ThisView+".nast_stano_typ","Field","UpdateName","listauzy.typ")
DBSetProp(ThisView+".nast_stano_typ","Field","KeyField",.F.)
DBSetProp(ThisView+".nast_stano_typ","Field","Updatable",.F.)

DBSetProp(ThisView+".nast_stano_grupa","Field","DataType","C(5)")
DBSetProp(ThisView+".nast_stano_grupa","Field","UpdateName","listauzy.grupa")
DBSetProp(ThisView+".nast_stano_grupa","Field","KeyField",.F.)
DBSetProp(ThisView+".nast_stano_grupa","Field","Updatable",.F.)

ThisView = 'v_sprawa'
IF  INDBC(ThisView,"VIEW")
	DROP VIEW (ThisView)
ENDI
CREATE SQL VIEW (ThisView) CONNECTION 'conPostgres' SHAR as ;
SELECT Sprawy.id, Sprawy.nr, Sprawy.nazwa_spra, Sprawy.opis,;
  Sprawy.spos_zak, Sprawy.nazwa_kli, Sprawy.imie, Sprawy.adres,;
  Sprawy.miejscow, Sprawy.kod_poczt, Sprawy.inspektora, Sprawy.jedn_teren,;
  Sprawy.oddzial, Sprawy.grup_ubez, Sprawy.data_szkod, Sprawy.od,;
  Sprawy.przewid, Sprawy.stanowisko, Sprawy.dot_l_s, Sprawy.rodz_spraw,;
  Sprawy.rwa_symbol, Sprawy.zaposrdn, Sprawy.nr_szkody, Sprawy.rodz_ryz,;
  Sprawy.wlasc_poj, Sprawy.nr_rej, Sprawy.wersja, Sprawy.id_encoded,;
  Sprawy.timestamp_column, Sprawy.serial_id, Sprawy.data_do;
 FROM ;
     sprawy Sprawy;
 WHERE  Sprawy.nr = ( ?thisform.nr_opisu_sprawy )

DBSetProp(ThisView,"View","SendUpdates",.F.)
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
DBSetProp(ThisView,"View","Tables","sprawy")
DBSetProp(ThisView,"View","WhereType",1)

DBSetProp(ThisView+".id","Field","DataType","N(12)")
DBSetProp(ThisView+".id","Field","UpdateName","sprawy.id")
DBSetProp(ThisView+".id","Field","KeyField",.F.)
DBSetProp(ThisView+".id","Field","Updatable",.T.)

DBSetProp(ThisView+".nr","Field","DataType","C(40)")
DBSetProp(ThisView+".nr","Field","UpdateName","sprawy.nr")
DBSetProp(ThisView+".nr","Field","KeyField",.F.)
DBSetProp(ThisView+".nr","Field","Updatable",.T.)

DBSetProp(ThisView+".nazwa_spra","Field","DataType","C(100)")
DBSetProp(ThisView+".nazwa_spra","Field","UpdateName","sprawy.nazwa_spra")
DBSetProp(ThisView+".nazwa_spra","Field","KeyField",.F.)
DBSetProp(ThisView+".nazwa_spra","Field","Updatable",.T.)

DBSetProp(ThisView+".opis","Field","DataType","M")
DBSetProp(ThisView+".opis","Field","UpdateName","sprawy.opis")
DBSetProp(ThisView+".opis","Field","KeyField",.F.)
DBSetProp(ThisView+".opis","Field","Updatable",.T.)

DBSetProp(ThisView+".spos_zak","Field","DataType","C(100)")
DBSetProp(ThisView+".spos_zak","Field","UpdateName","sprawy.spos_zak")
DBSetProp(ThisView+".spos_zak","Field","KeyField",.F.)
DBSetProp(ThisView+".spos_zak","Field","Updatable",.T.)

DBSetProp(ThisView+".nazwa_kli","Field","DataType","C(100)")
DBSetProp(ThisView+".nazwa_kli","Field","UpdateName","sprawy.nazwa_kli")
DBSetProp(ThisView+".nazwa_kli","Field","KeyField",.F.)
DBSetProp(ThisView+".nazwa_kli","Field","Updatable",.T.)

DBSetProp(ThisView+".imie","Field","DataType","C(30)")
DBSetProp(ThisView+".imie","Field","UpdateName","sprawy.imie")
DBSetProp(ThisView+".imie","Field","KeyField",.F.)
DBSetProp(ThisView+".imie","Field","Updatable",.T.)

DBSetProp(ThisView+".adres","Field","DataType","C(100)")
DBSetProp(ThisView+".adres","Field","UpdateName","sprawy.adres")
DBSetProp(ThisView+".adres","Field","KeyField",.F.)
DBSetProp(ThisView+".adres","Field","Updatable",.T.)

DBSetProp(ThisView+".miejscow","Field","DataType","C(50)")
DBSetProp(ThisView+".miejscow","Field","UpdateName","sprawy.miejscow")
DBSetProp(ThisView+".miejscow","Field","KeyField",.F.)
DBSetProp(ThisView+".miejscow","Field","Updatable",.T.)

DBSetProp(ThisView+".kod_poczt","Field","DataType","C(10)")
DBSetProp(ThisView+".kod_poczt","Field","UpdateName","sprawy.kod_poczt")
DBSetProp(ThisView+".kod_poczt","Field","KeyField",.F.)
DBSetProp(ThisView+".kod_poczt","Field","Updatable",.T.)

DBSetProp(ThisView+".inspektora","Field","DataType","C(50)")
DBSetProp(ThisView+".inspektora","Field","UpdateName","sprawy.inspektora")
DBSetProp(ThisView+".inspektora","Field","KeyField",.F.)
DBSetProp(ThisView+".inspektora","Field","Updatable",.T.)

DBSetProp(ThisView+".jedn_teren","Field","DataType","C(50)")
DBSetProp(ThisView+".jedn_teren","Field","UpdateName","sprawy.jedn_teren")
DBSetProp(ThisView+".jedn_teren","Field","KeyField",.F.)
DBSetProp(ThisView+".jedn_teren","Field","Updatable",.T.)

DBSetProp(ThisView+".oddzial","Field","DataType","C(50)")
DBSetProp(ThisView+".oddzial","Field","UpdateName","sprawy.oddzial")
DBSetProp(ThisView+".oddzial","Field","KeyField",.F.)
DBSetProp(ThisView+".oddzial","Field","Updatable",.T.)

DBSetProp(ThisView+".grup_ubez","Field","DataType","C(120)")
DBSetProp(ThisView+".grup_ubez","Field","UpdateName","sprawy.grup_ubez")
DBSetProp(ThisView+".grup_ubez","Field","KeyField",.F.)
DBSetProp(ThisView+".grup_ubez","Field","Updatable",.T.)

DBSetProp(ThisView+".data_szkod","Field","DataType","D")
DBSetProp(ThisView+".data_szkod","Field","UpdateName","sprawy.data_szkod")
DBSetProp(ThisView+".data_szkod","Field","KeyField",.F.)
DBSetProp(ThisView+".data_szkod","Field","Updatable",.T.)

DBSetProp(ThisView+".od","Field","DataType","D")
DBSetProp(ThisView+".od","Field","UpdateName","sprawy.od")
DBSetProp(ThisView+".od","Field","KeyField",.F.)
DBSetProp(ThisView+".od","Field","Updatable",.T.)

DBSetProp(ThisView+".przewid","Field","DataType","D")
DBSetProp(ThisView+".przewid","Field","UpdateName","sprawy.przewid")
DBSetProp(ThisView+".przewid","Field","KeyField",.F.)
DBSetProp(ThisView+".przewid","Field","Updatable",.T.)

DBSetProp(ThisView+".stanowisko","Field","DataType","N(10)")
DBSetProp(ThisView+".stanowisko","Field","UpdateName","sprawy.stanowisko")
DBSetProp(ThisView+".stanowisko","Field","KeyField",.F.)
DBSetProp(ThisView+".stanowisko","Field","Updatable",.T.)

DBSetProp(ThisView+".dot_l_s","Field","DataType","C(1)")
DBSetProp(ThisView+".dot_l_s","Field","UpdateName","sprawy.dot_l_s")
DBSetProp(ThisView+".dot_l_s","Field","KeyField",.F.)
DBSetProp(ThisView+".dot_l_s","Field","Updatable",.T.)

DBSetProp(ThisView+".rodz_spraw","Field","DataType","C(100)")
DBSetProp(ThisView+".rodz_spraw","Field","UpdateName","sprawy.rodz_spraw")
DBSetProp(ThisView+".rodz_spraw","Field","KeyField",.F.)
DBSetProp(ThisView+".rodz_spraw","Field","Updatable",.T.)

DBSetProp(ThisView+".rwa_symbol","Field","DataType","C(4)")
DBSetProp(ThisView+".rwa_symbol","Field","UpdateName","sprawy.rwa_symbol")
DBSetProp(ThisView+".rwa_symbol","Field","KeyField",.F.)
DBSetProp(ThisView+".rwa_symbol","Field","Updatable",.T.)

DBSetProp(ThisView+".zaposrdn","Field","DataType","M")
DBSetProp(ThisView+".zaposrdn","Field","UpdateName","sprawy.zaposrdn")
DBSetProp(ThisView+".zaposrdn","Field","KeyField",.F.)
DBSetProp(ThisView+".zaposrdn","Field","Updatable",.T.)

DBSetProp(ThisView+".nr_szkody","Field","DataType","C(20)")
DBSetProp(ThisView+".nr_szkody","Field","UpdateName","sprawy.nr_szkody")
DBSetProp(ThisView+".nr_szkody","Field","KeyField",.F.)
DBSetProp(ThisView+".nr_szkody","Field","Updatable",.T.)

DBSetProp(ThisView+".rodz_ryz","Field","DataType","C(120)")
DBSetProp(ThisView+".rodz_ryz","Field","UpdateName","sprawy.rodz_ryz")
DBSetProp(ThisView+".rodz_ryz","Field","KeyField",.F.)
DBSetProp(ThisView+".rodz_ryz","Field","Updatable",.T.)

DBSetProp(ThisView+".wlasc_poj","Field","DataType","C(120)")
DBSetProp(ThisView+".wlasc_poj","Field","UpdateName","sprawy.wlasc_poj")
DBSetProp(ThisView+".wlasc_poj","Field","KeyField",.F.)
DBSetProp(ThisView+".wlasc_poj","Field","Updatable",.T.)

DBSetProp(ThisView+".nr_rej","Field","DataType","C(20)")
DBSetProp(ThisView+".nr_rej","Field","UpdateName","sprawy.nr_rej")
DBSetProp(ThisView+".nr_rej","Field","KeyField",.F.)
DBSetProp(ThisView+".nr_rej","Field","Updatable",.T.)

DBSetProp(ThisView+".wersja","Field","DataType","N(7)")
DBSetProp(ThisView+".wersja","Field","UpdateName","sprawy.wersja")
DBSetProp(ThisView+".wersja","Field","KeyField",.F.)
DBSetProp(ThisView+".wersja","Field","Updatable",.T.)

DBSetProp(ThisView+".id_encoded","Field","DataType","N(17)")
DBSetProp(ThisView+".id_encoded","Field","UpdateName","sprawy.id_encoded")
DBSetProp(ThisView+".id_encoded","Field","KeyField",.F.)
DBSetProp(ThisView+".id_encoded","Field","Updatable",.T.)

DBSetProp(ThisView+".timestamp_column","Field","DataType","T")
DBSetProp(ThisView+".timestamp_column","Field","UpdateName","sprawy.timestamp_column")
DBSetProp(ThisView+".timestamp_column","Field","KeyField",.F.)
DBSetProp(ThisView+".timestamp_column","Field","Updatable",.T.)

DBSetProp(ThisView+".serial_id","Field","DataType","I")
DBSetProp(ThisView+".serial_id","Field","UpdateName","sprawy.serial_id")
DBSetProp(ThisView+".serial_id","Field","KeyField",.T.)
DBSetProp(ThisView+".serial_id","Field","Updatable",.T.)

DBSetProp(ThisView+".data_do","Field","DataType","D")
DBSetProp(ThisView+".data_do","Field","UpdateName","sprawy.data_do")
DBSetProp(ThisView+".data_do","Field","KeyField",.F.)
DBSetProp(ThisView+".data_do","Field","Updatable",.T.)


ThisView = 'sprawy'
IF  INDBC(ThisView,"VIEW")
	DROP VIEW (ThisView)
ENDI
CREATE SQL VIEW (ThisView) CONNECTION 'conPostgres' SHAR as ;
SELECT Sprawy.id, Sprawy.nr, Sprawy.nazwa_spra, Sprawy.opis,;
  Sprawy.spos_zak, Sprawy.nazwa_kli, Sprawy.imie, Sprawy.adres,;
  Sprawy.miejscow, Sprawy.kod_poczt, Sprawy.inspektora, Sprawy.jedn_teren,;
  Sprawy.oddzial, Sprawy.grup_ubez, Sprawy.data_szkod, Sprawy.od,;
  Sprawy.przewid, Sprawy.stanowisko, Sprawy.dot_l_s, Sprawy.rodz_spraw,;
  Sprawy.rwa_symbol, Sprawy.zaposrdn, Sprawy.nr_szkody, Sprawy.rodz_ryz,;
  Sprawy.wlasc_poj, Sprawy.nr_rej, Sprawy.wersja, Sprawy.id_encoded,;
  Sprawy.timestamp_column, Sprawy.serial_id, Sprawy.data_do,;
  Sprawy.skargana, Sprawy.id_produkt, Sprawy.id_g_ustaw, Sprawy.gr_ub_rzec,;
  Sprawy.gr_ub_osob, Sprawy.id_stru, Sprawy.nrog, Sprawy.id_oddzialu,;
  Sprawy.grupa;
 FROM ;
     sprawy Sprawy;
 ORDER BY Sprawy.nazwa_kli

DBSetProp(ThisView,"View","SendUpdates",.F.)
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
DBSetProp(ThisView,"View","Tables","sprawy")
DBSetProp(ThisView,"View","WhereType",1)

DBSetProp(ThisView+".id","Field","Caption","Id")
DBSetProp(ThisView+".id","Field","DataType","I")
DBSetProp(ThisView+".id","Field","UpdateName","sprawy.id")
DBSetProp(ThisView+".id","Field","KeyField",.T.)
DBSetProp(ThisView+".id","Field","Updatable",.T.)

DBSetProp(ThisView+".nr","Field","DataType","C(40)")
DBSetProp(ThisView+".nr","Field","UpdateName","sprawy.nr")
DBSetProp(ThisView+".nr","Field","KeyField",.F.)
DBSetProp(ThisView+".nr","Field","Updatable",.T.)

DBSetProp(ThisView+".nazwa_spra","Field","Caption","Nazwa sprawy")
DBSetProp(ThisView+".nazwa_spra","Field","DataType","C(100)")
DBSetProp(ThisView+".nazwa_spra","Field","UpdateName","sprawy.nazwa_spra")
DBSetProp(ThisView+".nazwa_spra","Field","KeyField",.F.)
DBSetProp(ThisView+".nazwa_spra","Field","Updatable",.T.)

DBSetProp(ThisView+".opis","Field","Caption","Opis sprawy")
DBSetProp(ThisView+".opis","Field","DataType","C(252)")
DBSetProp(ThisView+".opis","Field","UpdateName","sprawy.opis")
DBSetProp(ThisView+".opis","Field","KeyField",.F.)
DBSetProp(ThisView+".opis","Field","Updatable",.T.)

DBSetProp(ThisView+".spos_zak","Field","Caption","Sposób zakoñczenia sprawy")
DBSetProp(ThisView+".spos_zak","Field","DataType","C(100)")
DBSetProp(ThisView+".spos_zak","Field","UpdateName","sprawy.spos_zak")
DBSetProp(ThisView+".spos_zak","Field","KeyField",.F.)
DBSetProp(ThisView+".spos_zak","Field","Updatable",.T.)

DBSetProp(ThisView+".nazwa_kli","Field","Caption","Nazwa klienta")
DBSetProp(ThisView+".nazwa_kli","Field","DataType","C(100)")
DBSetProp(ThisView+".nazwa_kli","Field","UpdateName","sprawy.nazwa_kli")
DBSetProp(ThisView+".nazwa_kli","Field","KeyField",.F.)
DBSetProp(ThisView+".nazwa_kli","Field","Updatable",.T.)

DBSetProp(ThisView+".imie","Field","DataType","C(30)")
DBSetProp(ThisView+".imie","Field","UpdateName","sprawy.imie")
DBSetProp(ThisView+".imie","Field","KeyField",.F.)
DBSetProp(ThisView+".imie","Field","Updatable",.T.)

DBSetProp(ThisView+".adres","Field","Caption","Adres klienta")
DBSetProp(ThisView+".adres","Field","DataType","C(100)")
DBSetProp(ThisView+".adres","Field","UpdateName","sprawy.adres")
DBSetProp(ThisView+".adres","Field","KeyField",.F.)
DBSetProp(ThisView+".adres","Field","Updatable",.T.)

DBSetProp(ThisView+".miejscow","Field","Caption","Miejscowoœæ")
DBSetProp(ThisView+".miejscow","Field","DataType","C(50)")
DBSetProp(ThisView+".miejscow","Field","UpdateName","sprawy.miejscow")
DBSetProp(ThisView+".miejscow","Field","KeyField",.F.)
DBSetProp(ThisView+".miejscow","Field","Updatable",.T.)

DBSetProp(ThisView+".kod_poczt","Field","Caption","Kod pocztowy")
DBSetProp(ThisView+".kod_poczt","Field","DataType","C(10)")
DBSetProp(ThisView+".kod_poczt","Field","UpdateName","sprawy.kod_poczt")
DBSetProp(ThisView+".kod_poczt","Field","KeyField",.F.)
DBSetProp(ThisView+".kod_poczt","Field","Updatable",.T.)

DBSetProp(ThisView+".inspektora","Field","Caption","Inspektorat")
DBSetProp(ThisView+".inspektora","Field","DataType","C(50)")
DBSetProp(ThisView+".inspektora","Field","UpdateName","sprawy.inspektora")
DBSetProp(ThisView+".inspektora","Field","KeyField",.F.)
DBSetProp(ThisView+".inspektora","Field","Updatable",.T.)

DBSetProp(ThisView+".jedn_teren","Field","DataType","C(50)")
DBSetProp(ThisView+".jedn_teren","Field","UpdateName","sprawy.jedn_teren")
DBSetProp(ThisView+".jedn_teren","Field","KeyField",.F.)
DBSetProp(ThisView+".jedn_teren","Field","Updatable",.T.)

DBSetProp(ThisView+".oddzial","Field","Caption","Oddzia³")
DBSetProp(ThisView+".oddzial","Field","DataType","C(50)")
DBSetProp(ThisView+".oddzial","Field","UpdateName","sprawy.oddzial")
DBSetProp(ThisView+".oddzial","Field","KeyField",.F.)
DBSetProp(ThisView+".oddzial","Field","Updatable",.T.)

DBSetProp(ThisView+".grup_ubez","Field","Caption","Grupa ubezpieczeniowa")
DBSetProp(ThisView+".grup_ubez","Field","DataType","C(120)")
DBSetProp(ThisView+".grup_ubez","Field","UpdateName","sprawy.grup_ubez")
DBSetProp(ThisView+".grup_ubez","Field","KeyField",.F.)
DBSetProp(ThisView+".grup_ubez","Field","Updatable",.T.)

DBSetProp(ThisView+".data_szkod","Field","Caption","Data szkody")
DBSetProp(ThisView+".data_szkod","Field","DataType","D")
DBSetProp(ThisView+".data_szkod","Field","UpdateName","sprawy.data_szkod")
DBSetProp(ThisView+".data_szkod","Field","KeyField",.F.)
DBSetProp(ThisView+".data_szkod","Field","Updatable",.T.)

DBSetProp(ThisView+".od","Field","Caption","Data za³o¿enia sprawy")
DBSetProp(ThisView+".od","Field","DataType","D")
DBSetProp(ThisView+".od","Field","UpdateName","sprawy.od")
DBSetProp(ThisView+".od","Field","KeyField",.F.)
DBSetProp(ThisView+".od","Field","Updatable",.T.)

DBSetProp(ThisView+".przewid","Field","Caption","Przewidywana data zakoñczenia sprawy")
DBSetProp(ThisView+".przewid","Field","DataType","D")
DBSetProp(ThisView+".przewid","Field","UpdateName","sprawy.przewid")
DBSetProp(ThisView+".przewid","Field","KeyField",.F.)
DBSetProp(ThisView+".przewid","Field","Updatable",.T.)

DBSetProp(ThisView+".stanowisko","Field","Caption","Prowadz¹cy sprawê")
DBSetProp(ThisView+".stanowisko","Field","DataType","I")
DBSetProp(ThisView+".stanowisko","Field","UpdateName","sprawy.stanowisko")
DBSetProp(ThisView+".stanowisko","Field","KeyField",.F.)
DBSetProp(ThisView+".stanowisko","Field","Updatable",.T.)

DBSetProp(ThisView+".dot_l_s","Field","Caption","Sprawa dotyczy likwidacji czy sprzeda¿y?")
DBSetProp(ThisView+".dot_l_s","Field","DataType","C(1)")
DBSetProp(ThisView+".dot_l_s","Field","UpdateName","sprawy.dot_l_s")
DBSetProp(ThisView+".dot_l_s","Field","KeyField",.F.)
DBSetProp(ThisView+".dot_l_s","Field","Updatable",.T.)

DBSetProp(ThisView+".rodz_spraw","Field","Caption","Rodzaj sprawy")
DBSetProp(ThisView+".rodz_spraw","Field","DataType","C(100)")
DBSetProp(ThisView+".rodz_spraw","Field","UpdateName","sprawy.rodz_spraw")
DBSetProp(ThisView+".rodz_spraw","Field","KeyField",.F.)
DBSetProp(ThisView+".rodz_spraw","Field","Updatable",.T.)

DBSetProp(ThisView+".rwa_symbol","Field","Caption","Numer rzeczowego wykazu akt")
DBSetProp(ThisView+".rwa_symbol","Field","DataType","C(4)")
DBSetProp(ThisView+".rwa_symbol","Field","UpdateName","sprawy.rwa_symbol")
DBSetProp(ThisView+".rwa_symbol","Field","KeyField",.F.)
DBSetProp(ThisView+".rwa_symbol","Field","Updatable",.T.)

DBSetProp(ThisView+".zaposrdn","Field","Caption","Za poœrednictwem kogo wp³ynê³y pisma w sprawie?")
DBSetProp(ThisView+".zaposrdn","Field","DataType","C(252)")
DBSetProp(ThisView+".zaposrdn","Field","UpdateName","sprawy.zaposrdn")
DBSetProp(ThisView+".zaposrdn","Field","KeyField",.F.)
DBSetProp(ThisView+".zaposrdn","Field","Updatable",.T.)

DBSetProp(ThisView+".nr_szkody","Field","Caption","Numer szkody")
DBSetProp(ThisView+".nr_szkody","Field","DataType","C(20)")
DBSetProp(ThisView+".nr_szkody","Field","UpdateName","sprawy.nr_szkody")
DBSetProp(ThisView+".nr_szkody","Field","KeyField",.F.)
DBSetProp(ThisView+".nr_szkody","Field","Updatable",.T.)

DBSetProp(ThisView+".rodz_ryz","Field","Caption","Rodzaj ryzyka")
DBSetProp(ThisView+".rodz_ryz","Field","DataType","C(120)")
DBSetProp(ThisView+".rodz_ryz","Field","UpdateName","sprawy.rodz_ryz")
DBSetProp(ThisView+".rodz_ryz","Field","KeyField",.F.)
DBSetProp(ThisView+".rodz_ryz","Field","Updatable",.T.)

DBSetProp(ThisView+".wlasc_poj","Field","Caption","W³aœciciel pojazdu")
DBSetProp(ThisView+".wlasc_poj","Field","DataType","C(120)")
DBSetProp(ThisView+".wlasc_poj","Field","UpdateName","sprawy.wlasc_poj")
DBSetProp(ThisView+".wlasc_poj","Field","KeyField",.F.)
DBSetProp(ThisView+".wlasc_poj","Field","Updatable",.T.)

DBSetProp(ThisView+".nr_rej","Field","Caption","Numer rejestracyjny")
DBSetProp(ThisView+".nr_rej","Field","DataType","C(20)")
DBSetProp(ThisView+".nr_rej","Field","UpdateName","sprawy.nr_rej")
DBSetProp(ThisView+".nr_rej","Field","KeyField",.F.)
DBSetProp(ThisView+".nr_rej","Field","Updatable",.T.)

DBSetProp(ThisView+".wersja","Field","DataType","I")
DBSetProp(ThisView+".wersja","Field","UpdateName","sprawy.wersja")
DBSetProp(ThisView+".wersja","Field","KeyField",.F.)
DBSetProp(ThisView+".wersja","Field","Updatable",.T.)

DBSetProp(ThisView+".id_encoded","Field","DataType","N(20)")
DBSetProp(ThisView+".id_encoded","Field","UpdateName","sprawy.id_encoded")
DBSetProp(ThisView+".id_encoded","Field","KeyField",.F.)
DBSetProp(ThisView+".id_encoded","Field","Updatable",.T.)

DBSetProp(ThisView+".timestamp_column","Field","DataType","T")
DBSetProp(ThisView+".timestamp_column","Field","UpdateName","sprawy.timestamp_column")
DBSetProp(ThisView+".timestamp_column","Field","KeyField",.F.)
DBSetProp(ThisView+".timestamp_column","Field","Updatable",.T.)

DBSetProp(ThisView+".serial_id","Field","DataType","I")
DBSetProp(ThisView+".serial_id","Field","UpdateName","sprawy.serial_id")
DBSetProp(ThisView+".serial_id","Field","KeyField",.F.)
DBSetProp(ThisView+".serial_id","Field","Updatable",.F.)

DBSetProp(ThisView+".data_do","Field","Caption","Data zakoñczenia sprawy")
DBSetProp(ThisView+".data_do","Field","DataType","D")
DBSetProp(ThisView+".data_do","Field","UpdateName","sprawy.data_do")
DBSetProp(ThisView+".data_do","Field","KeyField",.F.)
DBSetProp(ThisView+".data_do","Field","Updatable",.T.)

DBSetProp(ThisView+".skargana","Field","Caption","Na co to skarga?")
DBSetProp(ThisView+".skargana","Field","DataType","C(250)")
DBSetProp(ThisView+".skargana","Field","UpdateName","sprawy.skargana")
DBSetProp(ThisView+".skargana","Field","KeyField",.F.)
DBSetProp(ThisView+".skargana","Field","Updatable",.T.)

DBSetProp(ThisView+".id_produkt","Field","Caption","Identyfikator produktu")
DBSetProp(ThisView+".id_produkt","Field","DataType","I")
DBSetProp(ThisView+".id_produkt","Field","UpdateName","sprawy.id_produkt")
DBSetProp(ThisView+".id_produkt","Field","KeyField",.F.)
DBSetProp(ThisView+".id_produkt","Field","Updatable",.T.)

DBSetProp(ThisView+".id_g_ustaw","Field","Caption","Identyfikator grupy ustawowej")
DBSetProp(ThisView+".id_g_ustaw","Field","DataType","I")
DBSetProp(ThisView+".id_g_ustaw","Field","UpdateName","sprawy.id_g_ustaw")
DBSetProp(ThisView+".id_g_ustaw","Field","KeyField",.F.)
DBSetProp(ThisView+".id_g_ustaw","Field","Updatable",.T.)

DBSetProp(ThisView+".gr_ub_rzec","Field","Caption","Rzeczowa")
DBSetProp(ThisView+".gr_ub_rzec","Field","DataType","L")
DBSetProp(ThisView+".gr_ub_rzec","Field","UpdateName","sprawy.gr_ub_rzec")
DBSetProp(ThisView+".gr_ub_rzec","Field","KeyField",.F.)
DBSetProp(ThisView+".gr_ub_rzec","Field","Updatable",.T.)

DBSetProp(ThisView+".gr_ub_osob","Field","Caption","Osobowa")
DBSetProp(ThisView+".gr_ub_osob","Field","DataType","L")
DBSetProp(ThisView+".gr_ub_osob","Field","UpdateName","sprawy.gr_ub_osob")
DBSetProp(ThisView+".gr_ub_osob","Field","KeyField",.F.)
DBSetProp(ThisView+".gr_ub_osob","Field","Updatable",.T.)

DBSetProp(ThisView+".id_stru","Field","DataType","I")
DBSetProp(ThisView+".id_stru","Field","UpdateName","sprawy.id_stru")
DBSetProp(ThisView+".id_stru","Field","KeyField",.F.)
DBSetProp(ThisView+".id_stru","Field","Updatable",.T.)

DBSetProp(ThisView+".nrog","Field","Caption","Numer ogólny sprawy")
DBSetProp(ThisView+".nrog","Field","DataType","C(40)")
DBSetProp(ThisView+".nrog","Field","UpdateName","sprawy.nrog")
DBSetProp(ThisView+".nrog","Field","KeyField",.F.)
DBSetProp(ThisView+".nrog","Field","Updatable",.T.)

DBSetProp(ThisView+".id_oddzialu","Field","DataType","I")
DBSetProp(ThisView+".id_oddzialu","Field","UpdateName","sprawy.id_oddzialu")
DBSetProp(ThisView+".id_oddzialu","Field","KeyField",.F.)
DBSetProp(ThisView+".id_oddzialu","Field","Updatable",.T.)

DBSetProp(ThisView+".grupa","Field","DataType","C(5)")
DBSetProp(ThisView+".grupa","Field","UpdateName","sprawy.grupa")
DBSetProp(ThisView+".grupa","Field","KeyField",.F.)
DBSetProp(ThisView+".grupa","Field","Updatable",.T.)

ThisView = 'v_sprawy'
IF  INDBC(ThisView,"VIEW")
	DROP VIEW (ThisView)
ENDI
CREATE SQL VIEW (ThisView) CONNECTION 'conPostgres' SHAR as ;
SELECT Sprawy.id, Sprawy.nr, Sprawy.nazwa_spra, Sprawy.opis,;
  Sprawy.spos_zak, Sprawy.nazwa_kli, Sprawy.imie, Sprawy.adres,;
  Sprawy.miejscow, Sprawy.kod_poczt, Sprawy.inspektora, Sprawy.jedn_teren,;
  Sprawy.oddzial, Sprawy.grup_ubez, Sprawy.data_szkod, Sprawy.od,;
  Sprawy.przewid, Sprawy.stanowisko, Sprawy.dot_l_s, Sprawy.rodz_spraw,;
  Sprawy.rwa_symbol, Sprawy.zaposrdn, Sprawy.nr_szkody, Sprawy.rodz_ryz,;
  Sprawy.wlasc_poj, Sprawy.nr_rej, Sprawy.wersja, Sprawy.id_encoded,;
  Sprawy.timestamp_column, Sprawy.serial_id, Sprawy.data_do,;
  Sprawy.skargana, Sprawy.id_produkt, Sprawy.id_g_ustaw, Sprawy.gr_ub_rzec,;
  Sprawy.gr_ub_osob, Sprawy.id_stru, Sprawy.nrog, Sprawy.id_oddzialu,;
  Sprawy.grupa, SPACE(50) AS nazwa_prowadz, Sprawy.sp_zakoncz,;
  Sprawy.pniezalatw;
 FROM ;
     sprawy Sprawy;
 ORDER BY Sprawy.nazwa_kli

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
DBSetProp(ThisView,"View","Tables","sprawy")
DBSetProp(ThisView,"View","WhereType",1)

DBSetProp(ThisView+".id","Field","DataType","I")
DBSetProp(ThisView+".id","Field","UpdateName","sprawy.id")
DBSetProp(ThisView+".id","Field","KeyField",.T.)
DBSetProp(ThisView+".id","Field","Updatable",.T.)

DBSetProp(ThisView+".nr","Field","DataType","C(40)")
DBSetProp(ThisView+".nr","Field","UpdateName","sprawy.nr")
DBSetProp(ThisView+".nr","Field","KeyField",.F.)
DBSetProp(ThisView+".nr","Field","Updatable",.T.)

DBSetProp(ThisView+".nazwa_spra","Field","DataType","C(100)")
DBSetProp(ThisView+".nazwa_spra","Field","UpdateName","sprawy.nazwa_spra")
DBSetProp(ThisView+".nazwa_spra","Field","KeyField",.F.)
DBSetProp(ThisView+".nazwa_spra","Field","Updatable",.T.)

DBSetProp(ThisView+".opis","Field","DataType","C(252)")
DBSetProp(ThisView+".opis","Field","UpdateName","sprawy.opis")
DBSetProp(ThisView+".opis","Field","KeyField",.F.)
DBSetProp(ThisView+".opis","Field","Updatable",.T.)

DBSetProp(ThisView+".spos_zak","Field","DataType","C(100)")
DBSetProp(ThisView+".spos_zak","Field","UpdateName","sprawy.spos_zak")
DBSetProp(ThisView+".spos_zak","Field","KeyField",.F.)
DBSetProp(ThisView+".spos_zak","Field","Updatable",.T.)

DBSetProp(ThisView+".nazwa_kli","Field","DataType","C(100)")
DBSetProp(ThisView+".nazwa_kli","Field","UpdateName","sprawy.nazwa_kli")
DBSetProp(ThisView+".nazwa_kli","Field","KeyField",.F.)
DBSetProp(ThisView+".nazwa_kli","Field","Updatable",.T.)

DBSetProp(ThisView+".imie","Field","DataType","C(30)")
DBSetProp(ThisView+".imie","Field","UpdateName","sprawy.imie")
DBSetProp(ThisView+".imie","Field","KeyField",.F.)
DBSetProp(ThisView+".imie","Field","Updatable",.T.)

DBSetProp(ThisView+".adres","Field","DataType","C(100)")
DBSetProp(ThisView+".adres","Field","UpdateName","sprawy.adres")
DBSetProp(ThisView+".adres","Field","KeyField",.F.)
DBSetProp(ThisView+".adres","Field","Updatable",.T.)

DBSetProp(ThisView+".miejscow","Field","DataType","C(50)")
DBSetProp(ThisView+".miejscow","Field","UpdateName","sprawy.miejscow")
DBSetProp(ThisView+".miejscow","Field","KeyField",.F.)
DBSetProp(ThisView+".miejscow","Field","Updatable",.T.)

DBSetProp(ThisView+".kod_poczt","Field","DataType","C(10)")
DBSetProp(ThisView+".kod_poczt","Field","UpdateName","sprawy.kod_poczt")
DBSetProp(ThisView+".kod_poczt","Field","KeyField",.F.)
DBSetProp(ThisView+".kod_poczt","Field","Updatable",.T.)

DBSetProp(ThisView+".inspektora","Field","DataType","C(50)")
DBSetProp(ThisView+".inspektora","Field","UpdateName","sprawy.inspektora")
DBSetProp(ThisView+".inspektora","Field","KeyField",.F.)
DBSetProp(ThisView+".inspektora","Field","Updatable",.T.)

DBSetProp(ThisView+".jedn_teren","Field","DataType","C(50)")
DBSetProp(ThisView+".jedn_teren","Field","UpdateName","sprawy.jedn_teren")
DBSetProp(ThisView+".jedn_teren","Field","KeyField",.F.)
DBSetProp(ThisView+".jedn_teren","Field","Updatable",.T.)

DBSetProp(ThisView+".oddzial","Field","DataType","C(50)")
DBSetProp(ThisView+".oddzial","Field","UpdateName","sprawy.oddzial")
DBSetProp(ThisView+".oddzial","Field","KeyField",.F.)
DBSetProp(ThisView+".oddzial","Field","Updatable",.T.)

DBSetProp(ThisView+".grup_ubez","Field","DataType","C(120)")
DBSetProp(ThisView+".grup_ubez","Field","UpdateName","sprawy.grup_ubez")
DBSetProp(ThisView+".grup_ubez","Field","KeyField",.F.)
DBSetProp(ThisView+".grup_ubez","Field","Updatable",.T.)

DBSetProp(ThisView+".data_szkod","Field","DataType","D")
DBSetProp(ThisView+".data_szkod","Field","UpdateName","sprawy.data_szkod")
DBSetProp(ThisView+".data_szkod","Field","KeyField",.F.)
DBSetProp(ThisView+".data_szkod","Field","Updatable",.T.)

DBSetProp(ThisView+".od","Field","DataType","D")
DBSetProp(ThisView+".od","Field","UpdateName","sprawy.od")
DBSetProp(ThisView+".od","Field","KeyField",.F.)
DBSetProp(ThisView+".od","Field","Updatable",.T.)

DBSetProp(ThisView+".przewid","Field","DataType","D")
DBSetProp(ThisView+".przewid","Field","UpdateName","sprawy.przewid")
DBSetProp(ThisView+".przewid","Field","KeyField",.F.)
DBSetProp(ThisView+".przewid","Field","Updatable",.T.)

DBSetProp(ThisView+".stanowisko","Field","DataType","I")
DBSetProp(ThisView+".stanowisko","Field","UpdateName","sprawy.stanowisko")
DBSetProp(ThisView+".stanowisko","Field","KeyField",.F.)
DBSetProp(ThisView+".stanowisko","Field","Updatable",.T.)

DBSetProp(ThisView+".dot_l_s","Field","DataType","C(1)")
DBSetProp(ThisView+".dot_l_s","Field","UpdateName","sprawy.dot_l_s")
DBSetProp(ThisView+".dot_l_s","Field","KeyField",.F.)
DBSetProp(ThisView+".dot_l_s","Field","Updatable",.T.)

DBSetProp(ThisView+".rodz_spraw","Field","DataType","C(100)")
DBSetProp(ThisView+".rodz_spraw","Field","UpdateName","sprawy.rodz_spraw")
DBSetProp(ThisView+".rodz_spraw","Field","KeyField",.F.)
DBSetProp(ThisView+".rodz_spraw","Field","Updatable",.T.)

DBSetProp(ThisView+".rwa_symbol","Field","DataType","C(4)")
DBSetProp(ThisView+".rwa_symbol","Field","UpdateName","sprawy.rwa_symbol")
DBSetProp(ThisView+".rwa_symbol","Field","KeyField",.F.)
DBSetProp(ThisView+".rwa_symbol","Field","Updatable",.T.)

DBSetProp(ThisView+".zaposrdn","Field","DataType","C(252)")
DBSetProp(ThisView+".zaposrdn","Field","UpdateName","sprawy.zaposrdn")
DBSetProp(ThisView+".zaposrdn","Field","KeyField",.F.)
DBSetProp(ThisView+".zaposrdn","Field","Updatable",.T.)

DBSetProp(ThisView+".nr_szkody","Field","DataType","C(20)")
DBSetProp(ThisView+".nr_szkody","Field","UpdateName","sprawy.nr_szkody")
DBSetProp(ThisView+".nr_szkody","Field","KeyField",.F.)
DBSetProp(ThisView+".nr_szkody","Field","Updatable",.T.)

DBSetProp(ThisView+".rodz_ryz","Field","DataType","C(120)")
DBSetProp(ThisView+".rodz_ryz","Field","UpdateName","sprawy.rodz_ryz")
DBSetProp(ThisView+".rodz_ryz","Field","KeyField",.F.)
DBSetProp(ThisView+".rodz_ryz","Field","Updatable",.T.)

DBSetProp(ThisView+".wlasc_poj","Field","DataType","C(120)")
DBSetProp(ThisView+".wlasc_poj","Field","UpdateName","sprawy.wlasc_poj")
DBSetProp(ThisView+".wlasc_poj","Field","KeyField",.F.)
DBSetProp(ThisView+".wlasc_poj","Field","Updatable",.T.)

DBSetProp(ThisView+".nr_rej","Field","DataType","C(20)")
DBSetProp(ThisView+".nr_rej","Field","UpdateName","sprawy.nr_rej")
DBSetProp(ThisView+".nr_rej","Field","KeyField",.F.)
DBSetProp(ThisView+".nr_rej","Field","Updatable",.T.)

DBSetProp(ThisView+".wersja","Field","DataType","I")
DBSetProp(ThisView+".wersja","Field","UpdateName","sprawy.wersja")
DBSetProp(ThisView+".wersja","Field","KeyField",.F.)
DBSetProp(ThisView+".wersja","Field","Updatable",.T.)

DBSetProp(ThisView+".id_encoded","Field","DataType","N(20)")
DBSetProp(ThisView+".id_encoded","Field","UpdateName","sprawy.id_encoded")
DBSetProp(ThisView+".id_encoded","Field","KeyField",.F.)
DBSetProp(ThisView+".id_encoded","Field","Updatable",.T.)

DBSetProp(ThisView+".timestamp_column","Field","DataType","T")
DBSetProp(ThisView+".timestamp_column","Field","UpdateName","sprawy.timestamp_column")
DBSetProp(ThisView+".timestamp_column","Field","KeyField",.F.)
DBSetProp(ThisView+".timestamp_column","Field","Updatable",.T.)

DBSetProp(ThisView+".serial_id","Field","DataType","I")
DBSetProp(ThisView+".serial_id","Field","UpdateName","sprawy.serial_id")
DBSetProp(ThisView+".serial_id","Field","KeyField",.F.)
DBSetProp(ThisView+".serial_id","Field","Updatable",.F.)

DBSetProp(ThisView+".data_do","Field","DataType","D")
DBSetProp(ThisView+".data_do","Field","UpdateName","sprawy.data_do")
DBSetProp(ThisView+".data_do","Field","KeyField",.F.)
DBSetProp(ThisView+".data_do","Field","Updatable",.T.)

DBSetProp(ThisView+".skargana","Field","DataType","C(250)")
DBSetProp(ThisView+".skargana","Field","UpdateName","sprawy.skargana")
DBSetProp(ThisView+".skargana","Field","KeyField",.F.)
DBSetProp(ThisView+".skargana","Field","Updatable",.T.)

DBSetProp(ThisView+".id_produkt","Field","DataType","I")
DBSetProp(ThisView+".id_produkt","Field","UpdateName","sprawy.id_produkt")
DBSetProp(ThisView+".id_produkt","Field","KeyField",.F.)
DBSetProp(ThisView+".id_produkt","Field","Updatable",.T.)

DBSetProp(ThisView+".id_g_ustaw","Field","DataType","I")
DBSetProp(ThisView+".id_g_ustaw","Field","UpdateName","sprawy.id_g_ustaw")
DBSetProp(ThisView+".id_g_ustaw","Field","KeyField",.F.)
DBSetProp(ThisView+".id_g_ustaw","Field","Updatable",.T.)

DBSetProp(ThisView+".gr_ub_rzec","Field","DataType","L")
DBSetProp(ThisView+".gr_ub_rzec","Field","UpdateName","sprawy.gr_ub_rzec")
DBSetProp(ThisView+".gr_ub_rzec","Field","KeyField",.F.)
DBSetProp(ThisView+".gr_ub_rzec","Field","Updatable",.T.)

DBSetProp(ThisView+".gr_ub_osob","Field","DataType","L")
DBSetProp(ThisView+".gr_ub_osob","Field","UpdateName","sprawy.gr_ub_osob")
DBSetProp(ThisView+".gr_ub_osob","Field","KeyField",.F.)
DBSetProp(ThisView+".gr_ub_osob","Field","Updatable",.T.)

DBSetProp(ThisView+".id_stru","Field","DataType","I")
DBSetProp(ThisView+".id_stru","Field","UpdateName","sprawy.id_stru")
DBSetProp(ThisView+".id_stru","Field","KeyField",.F.)
DBSetProp(ThisView+".id_stru","Field","Updatable",.T.)

DBSetProp(ThisView+".nrog","Field","DataType","C(40)")
DBSetProp(ThisView+".nrog","Field","UpdateName","sprawy.nrog")
DBSetProp(ThisView+".nrog","Field","KeyField",.F.)
DBSetProp(ThisView+".nrog","Field","Updatable",.T.)

DBSetProp(ThisView+".id_oddzialu","Field","DataType","I")
DBSetProp(ThisView+".id_oddzialu","Field","UpdateName","sprawy.id_oddzialu")
DBSetProp(ThisView+".id_oddzialu","Field","KeyField",.F.)
DBSetProp(ThisView+".id_oddzialu","Field","Updatable",.T.)

DBSetProp(ThisView+".grupa","Field","DataType","C(5)")
DBSetProp(ThisView+".grupa","Field","UpdateName","sprawy.grupa")
DBSetProp(ThisView+".grupa","Field","KeyField",.F.)
DBSetProp(ThisView+".grupa","Field","Updatable",.T.)

DBSetProp(ThisView+".nazwa_prowadz","Field","DataType","C(252)")
DBSetProp(ThisView+".nazwa_prowadz","Field","UpdateName","nazwa_prowadz")
DBSetProp(ThisView+".nazwa_prowadz","Field","KeyField",.F.)
DBSetProp(ThisView+".nazwa_prowadz","Field","Updatable",.F.)

DBSetProp(ThisView+".sp_zakoncz","Field","DataType","L")
DBSetProp(ThisView+".sp_zakoncz","Field","UpdateName","sprawy.sp_zakoncz")
DBSetProp(ThisView+".sp_zakoncz","Field","KeyField",.F.)
DBSetProp(ThisView+".sp_zakoncz","Field","Updatable",.T.)

DBSetProp(ThisView+".pniezalatw","Field","DataType","I")
DBSetProp(ThisView+".pniezalatw","Field","UpdateName","sprawy.pniezalatw")
DBSetProp(ThisView+".pniezalatw","Field","KeyField",.F.)
DBSetProp(ThisView+".pniezalatw","Field","Updatable",.F.)

ThisView = 'v_sprawy_na_stanowisku'
IF  INDBC(ThisView,"VIEW")
	DROP VIEW (ThisView)
ENDI
CREATE SQL VIEW (ThisView) CONNECTION 'conPostgres' SHAR as ;
SELECT Sprawy.nr, Sprawy.nazwa_spra, Sprawy.stanowisko,;
  Sprawy.pniezalatw, Sprawy.sp_zakoncz, Sprawy.od, 0 AS idpisma, 0 AS idw,;
  -1 AS ilep, -1 AS ilepn, -1 AS ilew, -1 AS ilewn, -1 AS iledp, -1 AS iledw,;
  -1 AS ileo, 0 AS flagi;
 FROM ;
     sprawy Sprawy

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
DBSetProp(ThisView,"View","Tables","sprawy")
DBSetProp(ThisView,"View","WhereType",1)

DBSetProp(ThisView+".nr","Field","DataType","C(40)")
DBSetProp(ThisView+".nr","Field","UpdateName","sprawy.nr")
DBSetProp(ThisView+".nr","Field","KeyField",.T.)
DBSetProp(ThisView+".nr","Field","Updatable",.F.)

DBSetProp(ThisView+".nazwa_spra","Field","DataType","C(100)")
DBSetProp(ThisView+".nazwa_spra","Field","UpdateName","sprawy.nazwa_spra")
DBSetProp(ThisView+".nazwa_spra","Field","KeyField",.F.)
DBSetProp(ThisView+".nazwa_spra","Field","Updatable",.F.)

DBSetProp(ThisView+".stanowisko","Field","DataType","I")
DBSetProp(ThisView+".stanowisko","Field","UpdateName","sprawy.stanowisko")
DBSetProp(ThisView+".stanowisko","Field","KeyField",.F.)
DBSetProp(ThisView+".stanowisko","Field","Updatable",.F.)

DBSetProp(ThisView+".pniezalatw","Field","DataType","I")
DBSetProp(ThisView+".pniezalatw","Field","UpdateName","sprawy.pniezalatw")
DBSetProp(ThisView+".pniezalatw","Field","KeyField",.F.)
DBSetProp(ThisView+".pniezalatw","Field","Updatable",.T.)

DBSetProp(ThisView+".sp_zakoncz","Field","DataType","L")
DBSetProp(ThisView+".sp_zakoncz","Field","UpdateName","sprawy.sp_zakoncz")
DBSetProp(ThisView+".sp_zakoncz","Field","KeyField",.F.)
DBSetProp(ThisView+".sp_zakoncz","Field","Updatable",.F.)

DBSetProp(ThisView+".od","Field","DataType","T")
DBSetProp(ThisView+".od","Field","UpdateName","sprawy.od")
DBSetProp(ThisView+".od","Field","KeyField",.F.)
DBSetProp(ThisView+".od","Field","Updatable",.F.)

DBSetProp(ThisView+".idpisma","Field","DataType","I")
DBSetProp(ThisView+".idpisma","Field","UpdateName","0")
DBSetProp(ThisView+".idpisma","Field","KeyField",.F.)
DBSetProp(ThisView+".idpisma","Field","Updatable",.F.)

DBSetProp(ThisView+".idw","Field","DataType","I")
DBSetProp(ThisView+".idw","Field","UpdateName","0")
DBSetProp(ThisView+".idw","Field","KeyField",.F.)
DBSetProp(ThisView+".idw","Field","Updatable",.F.)

DBSetProp(ThisView+".ilep","Field","DataType","I")
DBSetProp(ThisView+".ilep","Field","UpdateName","ilep")
DBSetProp(ThisView+".ilep","Field","KeyField",.F.)
DBSetProp(ThisView+".ilep","Field","Updatable",.F.)

DBSetProp(ThisView+".ilepn","Field","DataType","I")
DBSetProp(ThisView+".ilepn","Field","UpdateName","ilepn")
DBSetProp(ThisView+".ilepn","Field","KeyField",.F.)
DBSetProp(ThisView+".ilepn","Field","Updatable",.F.)

DBSetProp(ThisView+".ilew","Field","DataType","I")
DBSetProp(ThisView+".ilew","Field","UpdateName","ilew")
DBSetProp(ThisView+".ilew","Field","KeyField",.F.)
DBSetProp(ThisView+".ilew","Field","Updatable",.F.)

DBSetProp(ThisView+".ilewn","Field","DataType","I")
DBSetProp(ThisView+".ilewn","Field","UpdateName","ilewn")
DBSetProp(ThisView+".ilewn","Field","KeyField",.F.)
DBSetProp(ThisView+".ilewn","Field","Updatable",.F.)

DBSetProp(ThisView+".iledp","Field","DataType","I")
DBSetProp(ThisView+".iledp","Field","UpdateName","iledp")
DBSetProp(ThisView+".iledp","Field","KeyField",.F.)
DBSetProp(ThisView+".iledp","Field","Updatable",.F.)

DBSetProp(ThisView+".iledw","Field","DataType","I")
DBSetProp(ThisView+".iledw","Field","UpdateName","iledw")
DBSetProp(ThisView+".iledw","Field","KeyField",.F.)
DBSetProp(ThisView+".iledw","Field","Updatable",.F.)

DBSetProp(ThisView+".ileo","Field","DataType","I")
DBSetProp(ThisView+".ileo","Field","UpdateName","ileo")
DBSetProp(ThisView+".ileo","Field","KeyField",.F.)
DBSetProp(ThisView+".ileo","Field","Updatable",.F.)

DBSetProp(ThisView+".flagi","Field","DataType","I")
DBSetProp(ThisView+".flagi","Field","UpdateName","0")
DBSetProp(ThisView+".flagi","Field","KeyField",.F.)
DBSetProp(ThisView+".flagi","Field","Updatable",.F.)

ThisView = 'Zaposrdn'
IF  INDBC(ThisView,"VIEW")
	DROP VIEW (ThisView)
ENDI
CREATE SQL VIEW (ThisView) CONNECTION 'conPostgres' SHAR as ;
SELECT Zaposrdn.nazwa, Zaposrdn.timestamp_column, Zaposrdn.serial_id,;
  Zaposrdn.nazwad;
 FROM ;
     ZAPOSRDN Zaposrdn

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
DBSetProp(ThisView,"View","Tables","ZAPOSRDN")
DBSetProp(ThisView,"View","WhereType",1)

DBSetProp(ThisView+".nazwa","Field","DataType","C(20)")
DBSetProp(ThisView+".nazwa","Field","UpdateName","ZAPOSRDN.nazwa")
DBSetProp(ThisView+".nazwa","Field","KeyField",.F.)
DBSetProp(ThisView+".nazwa","Field","Updatable",.T.)

DBSetProp(ThisView+".timestamp_column","Field","DataType","T")
DBSetProp(ThisView+".timestamp_column","Field","UpdateName","ZAPOSRDN.timestamp_column")
DBSetProp(ThisView+".timestamp_column","Field","KeyField",.F.)
DBSetProp(ThisView+".timestamp_column","Field","Updatable",.T.)

DBSetProp(ThisView+".serial_id","Field","DataType","I")
DBSetProp(ThisView+".serial_id","Field","UpdateName","ZAPOSRDN.serial_id")
DBSetProp(ThisView+".serial_id","Field","KeyField",.T.)
DBSetProp(ThisView+".serial_id","Field","Updatable",.F.)

DBSetProp(ThisView+".nazwad","Field","DataType","C(200)")
DBSetProp(ThisView+".nazwad","Field","UpdateName","ZAPOSRDN.nazwad")
DBSetProp(ThisView+".nazwad","Field","KeyField",.F.)
DBSetProp(ThisView+".nazwad","Field","Updatable",.T.)


ThisView = 'StruOrg'
IF  INDBC(ThisView,"VIEW")
	DROP VIEW (ThisView)
ENDI
CREATE SQL VIEW (ThisView) CONNECTION 'conPostgres' SHAR as ;
SELECT Struorg.id_stru, Struorg.nazwa, Struorg.data_od, Struorg.data_do,;
  Struorg.aktualna;
 FROM ;
     struorg Struorg

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
DBSetProp(ThisView,"View","Tables","struorg")
DBSetProp(ThisView,"View","WhereType",1)

DBSetProp(ThisView+".id_stru","Field","DataType","I")
DBSetProp(ThisView+".id_stru","Field","UpdateName","struorg.id_stru")
DBSetProp(ThisView+".id_stru","Field","KeyField",.T.)
DBSetProp(ThisView+".id_stru","Field","Updatable",.T.)

DBSetProp(ThisView+".nazwa","Field","DataType","C(60)")
DBSetProp(ThisView+".nazwa","Field","UpdateName","struorg.nazwa")
DBSetProp(ThisView+".nazwa","Field","KeyField",.F.)
DBSetProp(ThisView+".nazwa","Field","Updatable",.T.)

DBSetProp(ThisView+".data_od","Field","DataType","D")
DBSetProp(ThisView+".data_od","Field","UpdateName","struorg.data_od")
DBSetProp(ThisView+".data_od","Field","KeyField",.F.)
DBSetProp(ThisView+".data_od","Field","Updatable",.T.)

DBSetProp(ThisView+".data_do","Field","DataType","D")
DBSetProp(ThisView+".data_do","Field","UpdateName","struorg.data_do")
DBSetProp(ThisView+".data_do","Field","KeyField",.F.)
DBSetProp(ThisView+".data_do","Field","Updatable",.T.)

DBSetProp(ThisView+".aktualna","Field","DataType","L")
DBSetProp(ThisView+".aktualna","Field","UpdateName","struorg.aktualna")
DBSetProp(ThisView+".aktualna","Field","KeyField",.F.)
DBSetProp(ThisView+".aktualna","Field","Updatable",.T.)

ThisView = 'ListaPol'
IF  INDBC(ThisView,"VIEW")
	DROP VIEW (ThisView)
ENDI
CREATE SQL VIEW (ThisView) CONNECTION 'conPostgres' SHAR as ;
SELECT Listapol.pole, Listapol.tabela, Listapol.tytul, Listapol.czy_druk,;
  Listapol.id, Listapol.serial_id;
 FROM ;
     LISTAPOL Listapol

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
DBSetProp(ThisView,"View","Tables","LISTAPOL")
DBSetProp(ThisView,"View","WhereType",1)

DBSetProp(ThisView+".pole","Field","DataType","C(15)")
DBSetProp(ThisView+".pole","Field","UpdateName","LISTAPOL.pole")
DBSetProp(ThisView+".pole","Field","KeyField",.F.)
DBSetProp(ThisView+".pole","Field","Updatable",.T.)

DBSetProp(ThisView+".tabela","Field","DataType","C(8)")
DBSetProp(ThisView+".tabela","Field","UpdateName","LISTAPOL.tabela")
DBSetProp(ThisView+".tabela","Field","KeyField",.F.)
DBSetProp(ThisView+".tabela","Field","Updatable",.T.)

DBSetProp(ThisView+".tytul","Field","DataType","C(30)")
DBSetProp(ThisView+".tytul","Field","UpdateName","LISTAPOL.tytul")
DBSetProp(ThisView+".tytul","Field","KeyField",.F.)
DBSetProp(ThisView+".tytul","Field","Updatable",.T.)

DBSetProp(ThisView+".czy_druk","Field","DataType","L")
DBSetProp(ThisView+".czy_druk","Field","UpdateName","LISTAPOL.czy_druk")
DBSetProp(ThisView+".czy_druk","Field","KeyField",.F.)
DBSetProp(ThisView+".czy_druk","Field","Updatable",.T.)

DBSetProp(ThisView+".id","Field","DataType","I")
DBSetProp(ThisView+".id","Field","UpdateName","LISTAPOL.id")
DBSetProp(ThisView+".id","Field","KeyField",.F.)
DBSetProp(ThisView+".id","Field","Updatable",.T.)

DBSetProp(ThisView+".serial_id","Field","DataType","I")
DBSetProp(ThisView+".serial_id","Field","UpdateName","LISTAPOL.serial_id")
DBSetProp(ThisView+".serial_id","Field","KeyField",.T.)
DBSetProp(ThisView+".serial_id","Field","Updatable",.T.)

ThisView = 'lpoczt'
IF  INDBC(ThisView,"VIEW")
	DROP VIEW (ThisView)
ENDI
CREATE SQL VIEW (ThisView) CONNECTION 'conPostgres' SHAR as ;
SELECT Lpoczt.lprzesyl, Lpoczt.skrot, Lpoczt.rejestrowa, Lpoczt.ekspres,;
  Lpoczt.lotnicza, Lpoczt.cennik, Lpoczt.typ_dom, Lpoczt.rejon_dom,;
  Lpoczt.kontyn_dom, Lpoczt.kolejny, Lpoczt.wewnetrz, Lpoczt.ustna,;
  Lpoczt.dor, Lpoczt.czy_zagr, Lpoczt.aktualny, Lpoczt.serial_id,;
  Lpoczt.aktywne, Lpoczt.przekazko, Lpoczt.typprzesyl, Lpoczt.typrzesyl;
 FROM ;
     LPOCZT Lpoczt

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
DBSetProp(ThisView,"View","Tables","LPOCZT")
DBSetProp(ThisView,"View","WhereType",1)

DBSetProp(ThisView+".lprzesyl","Field","DataType","C(20)")
DBSetProp(ThisView+".lprzesyl","Field","UpdateName","LPOCZT.lprzesyl")
DBSetProp(ThisView+".lprzesyl","Field","KeyField",.F.)
DBSetProp(ThisView+".lprzesyl","Field","Updatable",.T.)

DBSetProp(ThisView+".skrot","Field","DataType","C(5)")
DBSetProp(ThisView+".skrot","Field","UpdateName","LPOCZT.skrot")
DBSetProp(ThisView+".skrot","Field","KeyField",.F.)
DBSetProp(ThisView+".skrot","Field","Updatable",.T.)

DBSetProp(ThisView+".rejestrowa","Field","DataType","L")
DBSetProp(ThisView+".rejestrowa","Field","UpdateName","LPOCZT.rejestrowa")
DBSetProp(ThisView+".rejestrowa","Field","KeyField",.F.)
DBSetProp(ThisView+".rejestrowa","Field","Updatable",.T.)

DBSetProp(ThisView+".ekspres","Field","DataType","L")
DBSetProp(ThisView+".ekspres","Field","UpdateName","LPOCZT.ekspres")
DBSetProp(ThisView+".ekspres","Field","KeyField",.F.)
DBSetProp(ThisView+".ekspres","Field","Updatable",.T.)

DBSetProp(ThisView+".lotnicza","Field","DataType","L")
DBSetProp(ThisView+".lotnicza","Field","UpdateName","LPOCZT.lotnicza")
DBSetProp(ThisView+".lotnicza","Field","KeyField",.F.)
DBSetProp(ThisView+".lotnicza","Field","Updatable",.T.)

DBSetProp(ThisView+".cennik","Field","DataType","N(11,2)")
DBSetProp(ThisView+".cennik","Field","UpdateName","LPOCZT.cennik")
DBSetProp(ThisView+".cennik","Field","KeyField",.F.)
DBSetProp(ThisView+".cennik","Field","Updatable",.T.)

DBSetProp(ThisView+".typ_dom","Field","DataType","N(3)")
DBSetProp(ThisView+".typ_dom","Field","UpdateName","LPOCZT.typ_dom")
DBSetProp(ThisView+".typ_dom","Field","KeyField",.F.)
DBSetProp(ThisView+".typ_dom","Field","Updatable",.T.)

DBSetProp(ThisView+".rejon_dom","Field","DataType","N(3)")
DBSetProp(ThisView+".rejon_dom","Field","UpdateName","LPOCZT.rejon_dom")
DBSetProp(ThisView+".rejon_dom","Field","KeyField",.F.)
DBSetProp(ThisView+".rejon_dom","Field","Updatable",.T.)

DBSetProp(ThisView+".kontyn_dom","Field","DataType","N(3)")
DBSetProp(ThisView+".kontyn_dom","Field","UpdateName","LPOCZT.kontyn_dom")
DBSetProp(ThisView+".kontyn_dom","Field","KeyField",.F.)
DBSetProp(ThisView+".kontyn_dom","Field","Updatable",.T.)

DBSetProp(ThisView+".kolejny","Field","DataType","N(5)")
DBSetProp(ThisView+".kolejny","Field","UpdateName","LPOCZT.kolejny")
DBSetProp(ThisView+".kolejny","Field","KeyField",.F.)
DBSetProp(ThisView+".kolejny","Field","Updatable",.T.)

DBSetProp(ThisView+".wewnetrz","Field","DataType","L")
DBSetProp(ThisView+".wewnetrz","Field","UpdateName","LPOCZT.wewnetrz")
DBSetProp(ThisView+".wewnetrz","Field","KeyField",.F.)
DBSetProp(ThisView+".wewnetrz","Field","Updatable",.T.)

DBSetProp(ThisView+".ustna","Field","DataType","L")
DBSetProp(ThisView+".ustna","Field","UpdateName","LPOCZT.ustna")
DBSetProp(ThisView+".ustna","Field","KeyField",.F.)
DBSetProp(ThisView+".ustna","Field","Updatable",.T.)

DBSetProp(ThisView+".dor","Field","DataType","L")
DBSetProp(ThisView+".dor","Field","UpdateName","LPOCZT.dor")
DBSetProp(ThisView+".dor","Field","KeyField",.F.)
DBSetProp(ThisView+".dor","Field","Updatable",.T.)

DBSetProp(ThisView+".czy_zagr","Field","DataType","N(3)")
DBSetProp(ThisView+".czy_zagr","Field","UpdateName","LPOCZT.czy_zagr")
DBSetProp(ThisView+".czy_zagr","Field","KeyField",.F.)
DBSetProp(ThisView+".czy_zagr","Field","Updatable",.T.)

DBSetProp(ThisView+".aktualny","Field","DataType","L")
DBSetProp(ThisView+".aktualny","Field","UpdateName","LPOCZT.aktualny")
DBSetProp(ThisView+".aktualny","Field","KeyField",.F.)
DBSetProp(ThisView+".aktualny","Field","Updatable",.T.)

DBSetProp(ThisView+".serial_id","Field","DataType","I")
DBSetProp(ThisView+".serial_id","Field","UpdateName","LPOCZT.serial_id")
DBSetProp(ThisView+".serial_id","Field","KeyField",.T.)
DBSetProp(ThisView+".serial_id","Field","Updatable",.T.)

DBSetProp(ThisView+".aktywne","Field","DataType","L")
DBSetProp(ThisView+".aktywne","Field","UpdateName","LPOCZT.aktywne")
DBSetProp(ThisView+".aktywne","Field","KeyField",.F.)
DBSetProp(ThisView+".aktywne","Field","Updatable",.T.)

DBSetProp(ThisView+".przekazko","Field","DataType","L")
DBSetProp(ThisView+".przekazko","Field","UpdateName","LPOCZT.przekazko")
DBSetProp(ThisView+".przekazko","Field","KeyField",.F.)
DBSetProp(ThisView+".przekazko","Field","Updatable",.T.)

DBSetProp(ThisView+".typprzesyl","Field","DataType","N(4)")
DBSetProp(ThisView+".typprzesyl","Field","UpdateName","LPOCZT.typprzesyl")
DBSetProp(ThisView+".typprzesyl","Field","KeyField",.F.)
DBSetProp(ThisView+".typprzesyl","Field","Updatable",.T.)

DBSetProp(ThisView+".typrzesyl","Field","DataType","N(4)")
DBSetProp(ThisView+".typrzesyl","Field","UpdateName","LPOCZT.typrzesyl")
DBSetProp(ThisView+".typrzesyl","Field","KeyField",.F.)
DBSetProp(ThisView+".typrzesyl","Field","Updatable",.T.)

ThisView = 'lista_obieg'
IF  INDBC(ThisView,"VIEW")
	DROP VIEW (ThisView)
ENDI
CREATE SQL VIEW (ThisView) CONNECTION 'conPostgres' SHAR as ;
SELECT G.struktura_grupa AS biuro, G.nazwa_uzyt AS nazwisko,;
  G.stanow_nazwa, G.id_stanowiska, Obieg.nrdzien, Obieg.datawplyw,;
  Obieg.przekaz, Obieg.stanowisko, Obieg.idpisma;
 FROM ;
     obieg Obieg,;
    t_global_uzyt_i_stanow G;
 WHERE  Obieg.stanowisko = ( G.id_stanowiska );
   AND  Obieg.idpisma = ( ?thisform.idpisma )

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
DBSetProp(ThisView,"View","Tables","t_global_uzyt_i_stanow,obieg")
DBSetProp(ThisView,"View","WhereType",1)

DBSetProp(ThisView+".biuro","Field","DataType","C(20)")
DBSetProp(ThisView+".biuro","Field","UpdateName","t_global_uzyt_i_stanow.struktura_grupa")
DBSetProp(ThisView+".biuro","Field","KeyField",.F.)
DBSetProp(ThisView+".biuro","Field","Updatable",.T.)

DBSetProp(ThisView+".nazwisko","Field","DataType","C(50)")
DBSetProp(ThisView+".nazwisko","Field","UpdateName","t_global_uzyt_i_stanow.nazwa_uzyt")
DBSetProp(ThisView+".nazwisko","Field","KeyField",.F.)
DBSetProp(ThisView+".nazwisko","Field","Updatable",.T.)

DBSetProp(ThisView+".stanow_nazwa","Field","DataType","C(30)")
DBSetProp(ThisView+".stanow_nazwa","Field","UpdateName","t_global_uzyt_i_stanow.stanow_nazwa")
DBSetProp(ThisView+".stanow_nazwa","Field","KeyField",.F.)
DBSetProp(ThisView+".stanow_nazwa","Field","Updatable",.T.)

DBSetProp(ThisView+".id_stanowiska","Field","DataType","I")
DBSetProp(ThisView+".id_stanowiska","Field","UpdateName","t_global_uzyt_i_stanow.id_stanowiska")
DBSetProp(ThisView+".id_stanowiska","Field","KeyField",.F.)
DBSetProp(ThisView+".id_stanowiska","Field","Updatable",.T.)

DBSetProp(ThisView+".nrdzien","Field","DataType","I")
DBSetProp(ThisView+".nrdzien","Field","UpdateName","obieg.nrdzien")
DBSetProp(ThisView+".nrdzien","Field","KeyField",.F.)
DBSetProp(ThisView+".nrdzien","Field","Updatable",.T.)

DBSetProp(ThisView+".datawplyw","Field","DataType","D")
DBSetProp(ThisView+".datawplyw","Field","UpdateName","obieg.datawplyw")
DBSetProp(ThisView+".datawplyw","Field","KeyField",.F.)
DBSetProp(ThisView+".datawplyw","Field","Updatable",.T.)

DBSetProp(ThisView+".przekaz","Field","DataType","C(1)")
DBSetProp(ThisView+".przekaz","Field","UpdateName","obieg.przekaz")
DBSetProp(ThisView+".przekaz","Field","KeyField",.F.)
DBSetProp(ThisView+".przekaz","Field","Updatable",.T.)

DBSetProp(ThisView+".stanowisko","Field","DataType","I")
DBSetProp(ThisView+".stanowisko","Field","UpdateName","obieg.stanowisko")
DBSetProp(ThisView+".stanowisko","Field","KeyField",.F.)
DBSetProp(ThisView+".stanowisko","Field","Updatable",.T.)

DBSetProp(ThisView+".idpisma","Field","DataType","I")
DBSetProp(ThisView+".idpisma","Field","UpdateName","obieg.idpisma")
DBSetProp(ThisView+".idpisma","Field","KeyField",.F.)
DBSetProp(ThisView+".idpisma","Field","Updatable",.T.)

ThisView = 'rwa'
IF  INDBC(ThisView,"VIEW")
	DROP VIEW (ThisView)
ENDI
CREATE SQL VIEW (ThisView) CONNECTION 'conPostgres' SHAR as ;
SELECT Rwa.idrwa, Rwa.symbol, Rwa.i_symbol, Rwa.ii_symbol, Rwa.iii_symbol,;
  Rwa.iv_symbol, Rwa.hasla, Rwa.kat_panstw, Rwa.czas_panst, Rwa.kat_niepan,;
  Rwa.kat_inne_k, Rwa.czas_innyc, Rwa.uwagi, Rwa.serial_id;
 FROM ;
     rwa Rwa

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
DBSetProp(ThisView,"View","Tables","rwa")
DBSetProp(ThisView,"View","WhereType",1)

DBSetProp(ThisView+".idrwa","Field","DataType","N(6)")
DBSetProp(ThisView+".idrwa","Field","UpdateName","rwa.idrwa")
DBSetProp(ThisView+".idrwa","Field","KeyField",.F.)
DBSetProp(ThisView+".idrwa","Field","Updatable",.T.)

DBSetProp(ThisView+".symbol","Field","DataType","C(4)")
DBSetProp(ThisView+".symbol","Field","UpdateName","rwa.symbol")
DBSetProp(ThisView+".symbol","Field","KeyField",.F.)
DBSetProp(ThisView+".symbol","Field","Updatable",.T.)

DBSetProp(ThisView+".i_symbol","Field","DataType","C(1)")
DBSetProp(ThisView+".i_symbol","Field","UpdateName","rwa.i_symbol")
DBSetProp(ThisView+".i_symbol","Field","KeyField",.F.)
DBSetProp(ThisView+".i_symbol","Field","Updatable",.T.)

DBSetProp(ThisView+".ii_symbol","Field","DataType","C(1)")
DBSetProp(ThisView+".ii_symbol","Field","UpdateName","rwa.ii_symbol")
DBSetProp(ThisView+".ii_symbol","Field","KeyField",.F.)
DBSetProp(ThisView+".ii_symbol","Field","Updatable",.T.)

DBSetProp(ThisView+".iii_symbol","Field","DataType","C(1)")
DBSetProp(ThisView+".iii_symbol","Field","UpdateName","rwa.iii_symbol")
DBSetProp(ThisView+".iii_symbol","Field","KeyField",.F.)
DBSetProp(ThisView+".iii_symbol","Field","Updatable",.T.)

DBSetProp(ThisView+".iv_symbol","Field","DataType","C(1)")
DBSetProp(ThisView+".iv_symbol","Field","UpdateName","rwa.iv_symbol")
DBSetProp(ThisView+".iv_symbol","Field","KeyField",.F.)
DBSetProp(ThisView+".iv_symbol","Field","Updatable",.T.)

DBSetProp(ThisView+".hasla","Field","DataType","C(254)")
DBSetProp(ThisView+".hasla","Field","UpdateName","rwa.hasla")
DBSetProp(ThisView+".hasla","Field","KeyField",.F.)
DBSetProp(ThisView+".hasla","Field","Updatable",.T.)

DBSetProp(ThisView+".kat_panstw","Field","DataType","C(2)")
DBSetProp(ThisView+".kat_panstw","Field","UpdateName","rwa.kat_panstw")
DBSetProp(ThisView+".kat_panstw","Field","KeyField",.F.)
DBSetProp(ThisView+".kat_panstw","Field","Updatable",.T.)

DBSetProp(ThisView+".czas_panst","Field","DataType","N(4)")
DBSetProp(ThisView+".czas_panst","Field","UpdateName","rwa.czas_panst")
DBSetProp(ThisView+".czas_panst","Field","KeyField",.F.)
DBSetProp(ThisView+".czas_panst","Field","Updatable",.T.)

DBSetProp(ThisView+".kat_niepan","Field","DataType","C(2)")
DBSetProp(ThisView+".kat_niepan","Field","UpdateName","rwa.kat_niepan")
DBSetProp(ThisView+".kat_niepan","Field","KeyField",.F.)
DBSetProp(ThisView+".kat_niepan","Field","Updatable",.T.)

DBSetProp(ThisView+".kat_inne_k","Field","DataType","C(2)")
DBSetProp(ThisView+".kat_inne_k","Field","UpdateName","rwa.kat_inne_k")
DBSetProp(ThisView+".kat_inne_k","Field","KeyField",.F.)
DBSetProp(ThisView+".kat_inne_k","Field","Updatable",.T.)

DBSetProp(ThisView+".czas_innyc","Field","DataType","N(4)")
DBSetProp(ThisView+".czas_innyc","Field","UpdateName","rwa.czas_innyc")
DBSetProp(ThisView+".czas_innyc","Field","KeyField",.F.)
DBSetProp(ThisView+".czas_innyc","Field","Updatable",.T.)

DBSetProp(ThisView+".uwagi","Field","DataType","C(254)")
DBSetProp(ThisView+".uwagi","Field","UpdateName","rwa.uwagi")
DBSetProp(ThisView+".uwagi","Field","KeyField",.F.)
DBSetProp(ThisView+".uwagi","Field","Updatable",.T.)

DBSetProp(ThisView+".serial_id","Field","DataType","I")
DBSetProp(ThisView+".serial_id","Field","UpdateName","rwa.serial_id")
DBSetProp(ThisView+".serial_id","Field","KeyField",.T.)
DBSetProp(ThisView+".serial_id","Field","Updatable",.T.)

ThisView = 'v_przychodzace'
IF  INDBC(ThisView,"VIEW")
	DROP VIEW (ThisView)
ENDI
CREATE SQL VIEW (ThisView) CONNECTION 'conPostgres' SHAR as ;
SELECT Przychod.idpisma, Przychod.pnrdzien, Przychod.nadwcamie,;
  Przychod.nadwcaadr, Przychod.nadwcanaz, Przychod.nadwcaznk,;
  Przychod.rodzprzes, Przychod.nrprzesyl, Przychod.datapisma,;
  Przychod.dotyczy, Przychod.dokogo, Przychod.nrsprawy, Przychod.grupa,;
  Przychod.datawplyw, Przychod.nrdzien, Przychod.termins, Przychod.zalatw,;
  Przychod.grupaw, Przychod.nrdzienw, Przychod.datapismaw,;
  Przychod.przekaz2, Przychod.aktualnie, Przychod.nast_stano,;
  Przychod.wystap, Przychod.uwagi, Przychod.idw_copy, Przychod.nr_copy,;
  Przychod.rok, Przychod.up, Przychod.ggrupa, Przychod.id_poprz,;
  Przychod.data_zmian, Przychod.id_zmien, Przychod.podp_zmien,;
  Przychod.kod, Przychod.kraj_id, Przychod.maska, Przychod.czy_zagr,;
  Przychod.p_d_id, Przychod.idplanu, Przychod.po_id, Przychod.po_next_id,;
  Przychod.nr_kanc, Przychod.id_dotyczy, Przychod.timestamp_column,;
  Przychod.serial_id, Przychod.wiadomosc, Przychod.nrrej,;
  Przychod.ilosczal, Przychod.blad, 0 AS znak;
 FROM ;
     przychod Przychod;
 WHERE  Przychod.nrsprawy = ( ?thisform.nrsprawy )

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
DBSetProp(ThisView,"View","Tables","przychod")
DBSetProp(ThisView,"View","WhereType",1)

DBSetProp(ThisView+".idpisma","Field","DataType","I")
DBSetProp(ThisView+".idpisma","Field","UpdateName","przychod.idpisma")
DBSetProp(ThisView+".idpisma","Field","KeyField",.F.)
DBSetProp(ThisView+".idpisma","Field","Updatable",.T.)

DBSetProp(ThisView+".pnrdzien","Field","DataType","I")
DBSetProp(ThisView+".pnrdzien","Field","UpdateName","przychod.pnrdzien")
DBSetProp(ThisView+".pnrdzien","Field","KeyField",.F.)
DBSetProp(ThisView+".pnrdzien","Field","Updatable",.T.)

DBSetProp(ThisView+".nadwcamie","Field","DataType","C(35)")
DBSetProp(ThisView+".nadwcamie","Field","UpdateName","przychod.nadwcamie")
DBSetProp(ThisView+".nadwcamie","Field","KeyField",.F.)
DBSetProp(ThisView+".nadwcamie","Field","Updatable",.T.)

DBSetProp(ThisView+".nadwcaadr","Field","DataType","C(40)")
DBSetProp(ThisView+".nadwcaadr","Field","UpdateName","przychod.nadwcaadr")
DBSetProp(ThisView+".nadwcaadr","Field","KeyField",.F.)
DBSetProp(ThisView+".nadwcaadr","Field","Updatable",.T.)

DBSetProp(ThisView+".nadwcanaz","Field","DataType","C(80)")
DBSetProp(ThisView+".nadwcanaz","Field","UpdateName","przychod.nadwcanaz")
DBSetProp(ThisView+".nadwcanaz","Field","KeyField",.F.)
DBSetProp(ThisView+".nadwcanaz","Field","Updatable",.T.)

DBSetProp(ThisView+".nadwcaznk","Field","DataType","C(40)")
DBSetProp(ThisView+".nadwcaznk","Field","UpdateName","przychod.nadwcaznk")
DBSetProp(ThisView+".nadwcaznk","Field","KeyField",.F.)
DBSetProp(ThisView+".nadwcaznk","Field","Updatable",.T.)

DBSetProp(ThisView+".rodzprzes","Field","DataType","C(5)")
DBSetProp(ThisView+".rodzprzes","Field","UpdateName","przychod.rodzprzes")
DBSetProp(ThisView+".rodzprzes","Field","KeyField",.F.)
DBSetProp(ThisView+".rodzprzes","Field","Updatable",.T.)

DBSetProp(ThisView+".nrprzesyl","Field","DataType","C(30)")
DBSetProp(ThisView+".nrprzesyl","Field","UpdateName","przychod.nrprzesyl")
DBSetProp(ThisView+".nrprzesyl","Field","KeyField",.F.)
DBSetProp(ThisView+".nrprzesyl","Field","Updatable",.T.)

DBSetProp(ThisView+".datapisma","Field","DataType","D")
DBSetProp(ThisView+".datapisma","Field","UpdateName","przychod.datapisma")
DBSetProp(ThisView+".datapisma","Field","KeyField",.F.)
DBSetProp(ThisView+".datapisma","Field","Updatable",.T.)

DBSetProp(ThisView+".dotyczy","Field","DataType","C(254)")
DBSetProp(ThisView+".dotyczy","Field","UpdateName","przychod.dotyczy")
DBSetProp(ThisView+".dotyczy","Field","KeyField",.F.)
DBSetProp(ThisView+".dotyczy","Field","Updatable",.T.)

DBSetProp(ThisView+".dokogo","Field","DataType","C(40)")
DBSetProp(ThisView+".dokogo","Field","UpdateName","przychod.dokogo")
DBSetProp(ThisView+".dokogo","Field","KeyField",.F.)
DBSetProp(ThisView+".dokogo","Field","Updatable",.T.)

DBSetProp(ThisView+".nrsprawy","Field","DataType","C(40)")
DBSetProp(ThisView+".nrsprawy","Field","UpdateName","przychod.nrsprawy")
DBSetProp(ThisView+".nrsprawy","Field","KeyField",.F.)
DBSetProp(ThisView+".nrsprawy","Field","Updatable",.T.)

DBSetProp(ThisView+".grupa","Field","DataType","C(5)")
DBSetProp(ThisView+".grupa","Field","UpdateName","przychod.grupa")
DBSetProp(ThisView+".grupa","Field","KeyField",.F.)
DBSetProp(ThisView+".grupa","Field","Updatable",.T.)

DBSetProp(ThisView+".datawplyw","Field","DataType","D")
DBSetProp(ThisView+".datawplyw","Field","UpdateName","przychod.datawplyw")
DBSetProp(ThisView+".datawplyw","Field","KeyField",.F.)
DBSetProp(ThisView+".datawplyw","Field","Updatable",.T.)

DBSetProp(ThisView+".nrdzien","Field","DataType","I")
DBSetProp(ThisView+".nrdzien","Field","UpdateName","przychod.nrdzien")
DBSetProp(ThisView+".nrdzien","Field","KeyField",.F.)
DBSetProp(ThisView+".nrdzien","Field","Updatable",.T.)

DBSetProp(ThisView+".termins","Field","DataType","D")
DBSetProp(ThisView+".termins","Field","UpdateName","przychod.termins")
DBSetProp(ThisView+".termins","Field","KeyField",.F.)
DBSetProp(ThisView+".termins","Field","Updatable",.T.)

DBSetProp(ThisView+".zalatw","Field","DataType","L")
DBSetProp(ThisView+".zalatw","Field","UpdateName","przychod.zalatw")
DBSetProp(ThisView+".zalatw","Field","KeyField",.F.)
DBSetProp(ThisView+".zalatw","Field","Updatable",.T.)

DBSetProp(ThisView+".grupaw","Field","DataType","C(5)")
DBSetProp(ThisView+".grupaw","Field","UpdateName","przychod.grupaw")
DBSetProp(ThisView+".grupaw","Field","KeyField",.F.)
DBSetProp(ThisView+".grupaw","Field","Updatable",.T.)

DBSetProp(ThisView+".nrdzienw","Field","DataType","I")
DBSetProp(ThisView+".nrdzienw","Field","UpdateName","przychod.nrdzienw")
DBSetProp(ThisView+".nrdzienw","Field","KeyField",.F.)
DBSetProp(ThisView+".nrdzienw","Field","Updatable",.T.)

DBSetProp(ThisView+".datapismaw","Field","DataType","D")
DBSetProp(ThisView+".datapismaw","Field","UpdateName","przychod.datapismaw")
DBSetProp(ThisView+".datapismaw","Field","KeyField",.F.)
DBSetProp(ThisView+".datapismaw","Field","Updatable",.T.)

DBSetProp(ThisView+".przekaz2","Field","DataType","C(1)")
DBSetProp(ThisView+".przekaz2","Field","UpdateName","przychod.przekaz2")
DBSetProp(ThisView+".przekaz2","Field","KeyField",.F.)
DBSetProp(ThisView+".przekaz2","Field","Updatable",.T.)

DBSetProp(ThisView+".aktualnie","Field","DataType","I")
DBSetProp(ThisView+".aktualnie","Field","UpdateName","przychod.aktualnie")
DBSetProp(ThisView+".aktualnie","Field","KeyField",.F.)
DBSetProp(ThisView+".aktualnie","Field","Updatable",.T.)

DBSetProp(ThisView+".nast_stano","Field","DataType","I")
DBSetProp(ThisView+".nast_stano","Field","UpdateName","przychod.nast_stano")
DBSetProp(ThisView+".nast_stano","Field","KeyField",.F.)
DBSetProp(ThisView+".nast_stano","Field","Updatable",.T.)

DBSetProp(ThisView+".wystap","Field","DataType","I")
DBSetProp(ThisView+".wystap","Field","UpdateName","przychod.wystap")
DBSetProp(ThisView+".wystap","Field","KeyField",.F.)
DBSetProp(ThisView+".wystap","Field","Updatable",.T.)

DBSetProp(ThisView+".uwagi","Field","DataType","C(254)")
DBSetProp(ThisView+".uwagi","Field","UpdateName","przychod.uwagi")
DBSetProp(ThisView+".uwagi","Field","KeyField",.F.)
DBSetProp(ThisView+".uwagi","Field","Updatable",.T.)

DBSetProp(ThisView+".idw_copy","Field","DataType","I")
DBSetProp(ThisView+".idw_copy","Field","UpdateName","przychod.idw_copy")
DBSetProp(ThisView+".idw_copy","Field","KeyField",.F.)
DBSetProp(ThisView+".idw_copy","Field","Updatable",.T.)

DBSetProp(ThisView+".nr_copy","Field","DataType","I")
DBSetProp(ThisView+".nr_copy","Field","UpdateName","przychod.nr_copy")
DBSetProp(ThisView+".nr_copy","Field","KeyField",.F.)
DBSetProp(ThisView+".nr_copy","Field","Updatable",.T.)

DBSetProp(ThisView+".rok","Field","DataType","I")
DBSetProp(ThisView+".rok","Field","UpdateName","przychod.rok")
DBSetProp(ThisView+".rok","Field","KeyField",.F.)
DBSetProp(ThisView+".rok","Field","Updatable",.T.)

DBSetProp(ThisView+".up","Field","DataType","C(25)")
DBSetProp(ThisView+".up","Field","UpdateName","przychod.up")
DBSetProp(ThisView+".up","Field","KeyField",.F.)
DBSetProp(ThisView+".up","Field","Updatable",.T.)

DBSetProp(ThisView+".ggrupa","Field","DataType","C(5)")
DBSetProp(ThisView+".ggrupa","Field","UpdateName","przychod.ggrupa")
DBSetProp(ThisView+".ggrupa","Field","KeyField",.F.)
DBSetProp(ThisView+".ggrupa","Field","Updatable",.T.)

DBSetProp(ThisView+".id_poprz","Field","DataType","I")
DBSetProp(ThisView+".id_poprz","Field","UpdateName","przychod.id_poprz")
DBSetProp(ThisView+".id_poprz","Field","KeyField",.F.)
DBSetProp(ThisView+".id_poprz","Field","Updatable",.T.)

DBSetProp(ThisView+".data_zmian","Field","DataType","D")
DBSetProp(ThisView+".data_zmian","Field","UpdateName","przychod.data_zmian")
DBSetProp(ThisView+".data_zmian","Field","KeyField",.F.)
DBSetProp(ThisView+".data_zmian","Field","Updatable",.T.)

DBSetProp(ThisView+".id_zmien","Field","DataType","I")
DBSetProp(ThisView+".id_zmien","Field","UpdateName","przychod.id_zmien")
DBSetProp(ThisView+".id_zmien","Field","KeyField",.F.)
DBSetProp(ThisView+".id_zmien","Field","Updatable",.T.)

DBSetProp(ThisView+".podp_zmien","Field","DataType","M")
DBSetProp(ThisView+".podp_zmien","Field","UpdateName","przychod.podp_zmien")
DBSetProp(ThisView+".podp_zmien","Field","KeyField",.F.)
DBSetProp(ThisView+".podp_zmien","Field","Updatable",.T.)

DBSetProp(ThisView+".kod","Field","DataType","C(20)")
DBSetProp(ThisView+".kod","Field","UpdateName","przychod.kod")
DBSetProp(ThisView+".kod","Field","KeyField",.F.)
DBSetProp(ThisView+".kod","Field","Updatable",.T.)

DBSetProp(ThisView+".kraj_id","Field","DataType","I")
DBSetProp(ThisView+".kraj_id","Field","UpdateName","przychod.kraj_id")
DBSetProp(ThisView+".kraj_id","Field","KeyField",.F.)
DBSetProp(ThisView+".kraj_id","Field","Updatable",.T.)

DBSetProp(ThisView+".maska","Field","DataType","C(20)")
DBSetProp(ThisView+".maska","Field","UpdateName","przychod.maska")
DBSetProp(ThisView+".maska","Field","KeyField",.F.)
DBSetProp(ThisView+".maska","Field","Updatable",.T.)

DBSetProp(ThisView+".czy_zagr","Field","DataType","I")
DBSetProp(ThisView+".czy_zagr","Field","UpdateName","przychod.czy_zagr")
DBSetProp(ThisView+".czy_zagr","Field","KeyField",.F.)
DBSetProp(ThisView+".czy_zagr","Field","Updatable",.T.)

DBSetProp(ThisView+".p_d_id","Field","DataType","I")
DBSetProp(ThisView+".p_d_id","Field","UpdateName","przychod.p_d_id")
DBSetProp(ThisView+".p_d_id","Field","KeyField",.F.)
DBSetProp(ThisView+".p_d_id","Field","Updatable",.T.)

DBSetProp(ThisView+".idplanu","Field","DataType","I")
DBSetProp(ThisView+".idplanu","Field","UpdateName","przychod.idplanu")
DBSetProp(ThisView+".idplanu","Field","KeyField",.F.)
DBSetProp(ThisView+".idplanu","Field","Updatable",.T.)

DBSetProp(ThisView+".po_id","Field","DataType","I")
DBSetProp(ThisView+".po_id","Field","UpdateName","przychod.po_id")
DBSetProp(ThisView+".po_id","Field","KeyField",.F.)
DBSetProp(ThisView+".po_id","Field","Updatable",.T.)

DBSetProp(ThisView+".po_next_id","Field","DataType","I")
DBSetProp(ThisView+".po_next_id","Field","UpdateName","przychod.po_next_id")
DBSetProp(ThisView+".po_next_id","Field","KeyField",.F.)
DBSetProp(ThisView+".po_next_id","Field","Updatable",.T.)

DBSetProp(ThisView+".nr_kanc","Field","DataType","C(26)")
DBSetProp(ThisView+".nr_kanc","Field","UpdateName","przychod.nr_kanc")
DBSetProp(ThisView+".nr_kanc","Field","KeyField",.F.)
DBSetProp(ThisView+".nr_kanc","Field","Updatable",.T.)

DBSetProp(ThisView+".id_dotyczy","Field","DataType","I")
DBSetProp(ThisView+".id_dotyczy","Field","UpdateName","przychod.id_dotyczy")
DBSetProp(ThisView+".id_dotyczy","Field","KeyField",.F.)
DBSetProp(ThisView+".id_dotyczy","Field","Updatable",.T.)

DBSetProp(ThisView+".timestamp_column","Field","DataType","T")
DBSetProp(ThisView+".timestamp_column","Field","UpdateName","przychod.timestamp_column")
DBSetProp(ThisView+".timestamp_column","Field","KeyField",.F.)
DBSetProp(ThisView+".timestamp_column","Field","Updatable",.T.)

DBSetProp(ThisView+".serial_id","Field","DataType","I")
DBSetProp(ThisView+".serial_id","Field","UpdateName","przychod.serial_id")
DBSetProp(ThisView+".serial_id","Field","KeyField",.T.)
DBSetProp(ThisView+".serial_id","Field","Updatable",.T.)

DBSetProp(ThisView+".wiadomosc","Field","DataType","L")
DBSetProp(ThisView+".wiadomosc","Field","UpdateName","przychod.wiadomosc")
DBSetProp(ThisView+".wiadomosc","Field","KeyField",.F.)
DBSetProp(ThisView+".wiadomosc","Field","Updatable",.T.)

DBSetProp(ThisView+".nrrej","Field","DataType","C(31)")
DBSetProp(ThisView+".nrrej","Field","UpdateName","przychod.nrrej")
DBSetProp(ThisView+".nrrej","Field","KeyField",.F.)
DBSetProp(ThisView+".nrrej","Field","Updatable",.T.)

DBSetProp(ThisView+".ilosczal","Field","DataType","N(4)")
DBSetProp(ThisView+".ilosczal","Field","UpdateName","przychod.ilosczal")
DBSetProp(ThisView+".ilosczal","Field","KeyField",.F.)
DBSetProp(ThisView+".ilosczal","Field","Updatable",.T.)

DBSetProp(ThisView+".blad","Field","DataType","I")
DBSetProp(ThisView+".blad","Field","UpdateName","przychod.blad")
DBSetProp(ThisView+".blad","Field","KeyField",.F.)
DBSetProp(ThisView+".blad","Field","Updatable",.T.)

DBSetProp(ThisView+".znak","Field","DataType","I")
DBSetProp(ThisView+".znak","Field","UpdateName","0")
DBSetProp(ThisView+".znak","Field","KeyField",.F.)
DBSetProp(ThisView+".znak","Field","Updatable",.F.)

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
 WHERE  ( n.id_uzyt ) = (?v_listauzyuzy.id_uzy) and D.Zast = (?_l(.F.)) and N.Zast = (?_l(.T.))
  
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

ThisView = 'nadania'
IF  INDBC(ThisView,"VIEW")
	DROP VIEW (ThisView)
ENDI
CREATE SQL VIEW (ThisView) CONNECTION 'conPostgres' SHAR as ;
SELECT Nadania.id_stanowiska, Nadania.id_uzyt, Nadania.data_od,;
  Nadania.data_do, Nadania.serial_id, Nadania.zast;
 FROM ;
     NADANIA Nadania;
 WHERE  Nadania.zast = ?_l(.f.)

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

ThisView = 'osoby'
IF  INDBC(ThisView,"VIEW")
	DROP VIEW (ThisView)
ENDI
CREATE SQL VIEW (ThisView) CONNECTION 'conPostgres' SHAR as ;
SELECT Osoby.id_osoby, Osoby.nazwisko, Osoby.imie, Osoby.firma,;
  Osoby.miasto, Osoby.kod, Osoby.panstwo, Osoby.adres, Osoby.telefon,;
  Osoby.typ, Osoby.tytulnauk, Osoby.stanowisko, Osoby.znacznik, Osoby.grupa,;
  Osoby.rodzprzes, Osoby.skrytka, Osoby.sprzeciw, Osoby.zrodlo,;
  Osoby.id_poprz, Osoby.data_zmian, Osoby.id_zmien, Osoby.podp_zmien,;
  Osoby.kraj_id, Osoby.timestamp_column;
 FROM ;
     osoby Osoby

DBSetProp(ThisView,"View","SendUpdates",.T.)
DBSetProp(ThisView,"View","BatchUpdateCount",1)
DBSetProp(ThisView,"View","CompareMemo",.T.)
DBSetProp(ThisView,"View","FetchAsNeeded",.F.)
DBSetProp(ThisView,"View","FetchMemo",.T.)
DBSetProp(ThisView,"View","FetchSize",100)
DBSetProp(ThisView,"View","MaxRecords",-1)
DBSetProp(ThisView,"View","Prepared",.F.)
DBSetProp(ThisView,"View","ShareConnection",.F.)
DBSetProp(ThisView,"View","AllowSimultaneousFetch",.F.)
DBSetProp(ThisView,"View","UpdateType",1)
DBSetProp(ThisView,"View","UseMemoSize",255)
DBSetProp(ThisView,"View","Tables","osoby")
DBSetProp(ThisView,"View","WhereType",1)

DBSetProp(ThisView+".id_osoby","Field","DataType","I")
DBSetProp(ThisView+".id_osoby","Field","UpdateName","osoby.id_osoby")
DBSetProp(ThisView+".id_osoby","Field","KeyField",.T.)
DBSetProp(ThisView+".id_osoby","Field","Updatable",.T.)

DBSetProp(ThisView+".nazwisko","Field","DataType","C(25)")
DBSetProp(ThisView+".nazwisko","Field","UpdateName","osoby.nazwisko")
DBSetProp(ThisView+".nazwisko","Field","KeyField",.F.)
DBSetProp(ThisView+".nazwisko","Field","Updatable",.T.)

DBSetProp(ThisView+".imie","Field","DataType","C(15)")
DBSetProp(ThisView+".imie","Field","UpdateName","osoby.imie")
DBSetProp(ThisView+".imie","Field","KeyField",.F.)
DBSetProp(ThisView+".imie","Field","Updatable",.T.)

DBSetProp(ThisView+".firma","Field","DataType","C(100)")
DBSetProp(ThisView+".firma","Field","UpdateName","osoby.firma")
DBSetProp(ThisView+".firma","Field","KeyField",.F.)
DBSetProp(ThisView+".firma","Field","Updatable",.T.)

DBSetProp(ThisView+".miasto","Field","DataType","C(30)")
DBSetProp(ThisView+".miasto","Field","UpdateName","osoby.miasto")
DBSetProp(ThisView+".miasto","Field","KeyField",.F.)
DBSetProp(ThisView+".miasto","Field","Updatable",.T.)

DBSetProp(ThisView+".kod","Field","DataType","C(8)")
DBSetProp(ThisView+".kod","Field","UpdateName","osoby.kod")
DBSetProp(ThisView+".kod","Field","KeyField",.F.)
DBSetProp(ThisView+".kod","Field","Updatable",.T.)

DBSetProp(ThisView+".panstwo","Field","DataType","C(32)")
DBSetProp(ThisView+".panstwo","Field","UpdateName","osoby.panstwo")
DBSetProp(ThisView+".panstwo","Field","KeyField",.F.)
DBSetProp(ThisView+".panstwo","Field","Updatable",.T.)

DBSetProp(ThisView+".adres","Field","DataType","C(32)")
DBSetProp(ThisView+".adres","Field","UpdateName","osoby.adres")
DBSetProp(ThisView+".adres","Field","KeyField",.F.)
DBSetProp(ThisView+".adres","Field","Updatable",.T.)

DBSetProp(ThisView+".telefon","Field","DataType","C(10)")
DBSetProp(ThisView+".telefon","Field","UpdateName","osoby.telefon")
DBSetProp(ThisView+".telefon","Field","KeyField",.F.)
DBSetProp(ThisView+".telefon","Field","Updatable",.T.)

DBSetProp(ThisView+".typ","Field","DataType","C(15)")
DBSetProp(ThisView+".typ","Field","UpdateName","osoby.typ")
DBSetProp(ThisView+".typ","Field","KeyField",.F.)
DBSetProp(ThisView+".typ","Field","Updatable",.T.)

DBSetProp(ThisView+".tytulnauk","Field","DataType","C(34)")
DBSetProp(ThisView+".tytulnauk","Field","UpdateName","osoby.tytulnauk")
DBSetProp(ThisView+".tytulnauk","Field","KeyField",.F.)
DBSetProp(ThisView+".tytulnauk","Field","Updatable",.T.)

DBSetProp(ThisView+".stanowisko","Field","DataType","C(34)")
DBSetProp(ThisView+".stanowisko","Field","UpdateName","osoby.stanowisko")
DBSetProp(ThisView+".stanowisko","Field","KeyField",.F.)
DBSetProp(ThisView+".stanowisko","Field","Updatable",.T.)

DBSetProp(ThisView+".znacznik","Field","DataType","L")
DBSetProp(ThisView+".znacznik","Field","UpdateName","osoby.znacznik")
DBSetProp(ThisView+".znacznik","Field","KeyField",.F.)
DBSetProp(ThisView+".znacznik","Field","Updatable",.T.)

DBSetProp(ThisView+".grupa","Field","DataType","C(5)")
DBSetProp(ThisView+".grupa","Field","UpdateName","osoby.grupa")
DBSetProp(ThisView+".grupa","Field","KeyField",.F.)
DBSetProp(ThisView+".grupa","Field","Updatable",.T.)

DBSetProp(ThisView+".rodzprzes","Field","DataType","C(5)")
DBSetProp(ThisView+".rodzprzes","Field","UpdateName","osoby.rodzprzes")
DBSetProp(ThisView+".rodzprzes","Field","KeyField",.F.)
DBSetProp(ThisView+".rodzprzes","Field","Updatable",.T.)

DBSetProp(ThisView+".skrytka","Field","DataType","C(5)")
DBSetProp(ThisView+".skrytka","Field","UpdateName","osoby.skrytka")
DBSetProp(ThisView+".skrytka","Field","KeyField",.F.)
DBSetProp(ThisView+".skrytka","Field","Updatable",.T.)

DBSetProp(ThisView+".sprzeciw","Field","DataType","L")
DBSetProp(ThisView+".sprzeciw","Field","UpdateName","osoby.sprzeciw")
DBSetProp(ThisView+".sprzeciw","Field","KeyField",.F.)
DBSetProp(ThisView+".sprzeciw","Field","Updatable",.T.)

DBSetProp(ThisView+".zrodlo","Field","DataType","C(50)")
DBSetProp(ThisView+".zrodlo","Field","UpdateName","osoby.zrodlo")
DBSetProp(ThisView+".zrodlo","Field","KeyField",.F.)
DBSetProp(ThisView+".zrodlo","Field","Updatable",.T.)

DBSetProp(ThisView+".id_poprz","Field","DataType","I")
DBSetProp(ThisView+".id_poprz","Field","UpdateName","osoby.id_poprz")
DBSetProp(ThisView+".id_poprz","Field","KeyField",.F.)
DBSetProp(ThisView+".id_poprz","Field","Updatable",.T.)

DBSetProp(ThisView+".data_zmian","Field","DataType","D")
DBSetProp(ThisView+".data_zmian","Field","UpdateName","osoby.data_zmian")
DBSetProp(ThisView+".data_zmian","Field","KeyField",.F.)
DBSetProp(ThisView+".data_zmian","Field","Updatable",.T.)

DBSetProp(ThisView+".id_zmien","Field","DataType","I")
DBSetProp(ThisView+".id_zmien","Field","UpdateName","osoby.id_zmien")
DBSetProp(ThisView+".id_zmien","Field","KeyField",.F.)
DBSetProp(ThisView+".id_zmien","Field","Updatable",.T.)

DBSetProp(ThisView+".podp_zmien","Field","DataType","M")
DBSetProp(ThisView+".podp_zmien","Field","UpdateName","osoby.podp_zmien")
DBSetProp(ThisView+".podp_zmien","Field","KeyField",.F.)
DBSetProp(ThisView+".podp_zmien","Field","Updatable",.T.)

DBSetProp(ThisView+".kraj_id","Field","DataType","N(6)")
DBSetProp(ThisView+".kraj_id","Field","UpdateName","osoby.kraj_id")
DBSetProp(ThisView+".kraj_id","Field","KeyField",.F.)
DBSetProp(ThisView+".kraj_id","Field","Updatable",.T.)

DBSetProp(ThisView+".timestamp_column","Field","DataType","T")
DBSetProp(ThisView+".timestamp_column","Field","UpdateName","osoby.timestamp_column")
DBSetProp(ThisView+".timestamp_column","Field","KeyField",.F.)
DBSetProp(ThisView+".timestamp_column","Field","Updatable",.T.)

ThisView = 'loging'
IF  INDBC(ThisView,"VIEW")
	DROP VIEW (ThisView)
ENDI
CREATE SQL VIEW (ThisView) CONNECTION 'conPostgres' SHAR as ;
SELECT Loging.id_login, Loging.date, Loging.time_in, Loging.time_out,;
  Loging.user_, Loging.sys_group, Loging.logged_in, Loging.logged_out,;
  Loging.kto, Loging.program, Loging.pracownik, Loging.serial_id;
 FROM ;
     LOGING Loging

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
DBSetProp(ThisView,"View","Tables","LOGING")
DBSetProp(ThisView,"View","WhereType",1)

DBSetProp(ThisView+".id_login","Field","DataType","I")
DBSetProp(ThisView+".id_login","Field","UpdateName","LOGING.id_login")
DBSetProp(ThisView+".id_login","Field","KeyField",.F.)
DBSetProp(ThisView+".id_login","Field","Updatable",.T.)

DBSetProp(ThisView+".date","Field","DataType","D")
DBSetProp(ThisView+".date","Field","UpdateName","LOGING.date")
DBSetProp(ThisView+".date","Field","KeyField",.F.)
DBSetProp(ThisView+".date","Field","Updatable",.T.)

DBSetProp(ThisView+".time_in","Field","DataType","C(11)")
DBSetProp(ThisView+".time_in","Field","UpdateName","LOGING.time_in")
DBSetProp(ThisView+".time_in","Field","KeyField",.F.)
DBSetProp(ThisView+".time_in","Field","Updatable",.T.)

DBSetProp(ThisView+".time_out","Field","DataType","C(11)")
DBSetProp(ThisView+".time_out","Field","UpdateName","LOGING.time_out")
DBSetProp(ThisView+".time_out","Field","KeyField",.F.)
DBSetProp(ThisView+".time_out","Field","Updatable",.T.)

DBSetProp(ThisView+".user_","Field","DataType","C(18)")
DBSetProp(ThisView+".user_","Field","UpdateName","LOGING.user_")
DBSetProp(ThisView+".user_","Field","KeyField",.F.)
DBSetProp(ThisView+".user_","Field","Updatable",.T.)

DBSetProp(ThisView+".sys_group","Field","DataType","C(5)")
DBSetProp(ThisView+".sys_group","Field","UpdateName","LOGING.sys_group")
DBSetProp(ThisView+".sys_group","Field","KeyField",.F.)
DBSetProp(ThisView+".sys_group","Field","Updatable",.T.)

DBSetProp(ThisView+".logged_in","Field","DataType","L")
DBSetProp(ThisView+".logged_in","Field","UpdateName","LOGING.logged_in")
DBSetProp(ThisView+".logged_in","Field","KeyField",.F.)
DBSetProp(ThisView+".logged_in","Field","Updatable",.T.)

DBSetProp(ThisView+".logged_out","Field","DataType","L")
DBSetProp(ThisView+".logged_out","Field","UpdateName","LOGING.logged_out")
DBSetProp(ThisView+".logged_out","Field","KeyField",.F.)
DBSetProp(ThisView+".logged_out","Field","Updatable",.T.)

DBSetProp(ThisView+".kto","Field","DataType","C(1)")
DBSetProp(ThisView+".kto","Field","UpdateName","LOGING.kto")
DBSetProp(ThisView+".kto","Field","KeyField",.F.)
DBSetProp(ThisView+".kto","Field","Updatable",.T.)

DBSetProp(ThisView+".program","Field","DataType","C(1)")
DBSetProp(ThisView+".program","Field","UpdateName","LOGING.program")
DBSetProp(ThisView+".program","Field","KeyField",.F.)
DBSetProp(ThisView+".program","Field","Updatable",.T.)

DBSetProp(ThisView+".pracownik","Field","DataType","C(8)")
DBSetProp(ThisView+".pracownik","Field","UpdateName","LOGING.pracownik")
DBSetProp(ThisView+".pracownik","Field","KeyField",.F.)
DBSetProp(ThisView+".pracownik","Field","Updatable",.T.)

DBSetProp(ThisView+".serial_id","Field","DataType","I")
DBSetProp(ThisView+".serial_id","Field","UpdateName","LOGING.serial_id")
DBSetProp(ThisView+".serial_id","Field","KeyField",.T.)
DBSetProp(ThisView+".serial_id","Field","Updatable",.T.)

ThisView = 'globvar'
IF  INDBC(ThisView,"VIEW")
	DROP VIEW (ThisView)
ENDI
CREATE SQL VIEW (ThisView) CONNECTION 'conPostgres' SHAR as ;
SELECT Globvar.nazwa, Globvar.typ, Globvar.wartosc, Globvar.pub,;
  Globvar.serial_id;
 FROM ;
     GLOBVAR Globvar

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
DBSetProp(ThisView,"View","Tables","GLOBVAR")
DBSetProp(ThisView,"View","WhereType",1)

DBSetProp(ThisView+".nazwa","Field","DataType","C(30)")
DBSetProp(ThisView+".nazwa","Field","UpdateName","GLOBVAR.nazwa")
DBSetProp(ThisView+".nazwa","Field","KeyField",.F.)
DBSetProp(ThisView+".nazwa","Field","Updatable",.T.)

DBSetProp(ThisView+".typ","Field","DataType","C(10)")
DBSetProp(ThisView+".typ","Field","UpdateName","GLOBVAR.typ")
DBSetProp(ThisView+".typ","Field","KeyField",.F.)
DBSetProp(ThisView+".typ","Field","Updatable",.T.)

DBSetProp(ThisView+".wartosc","Field","DataType","C(254)")
DBSetProp(ThisView+".wartosc","Field","UpdateName","GLOBVAR.wartosc")
DBSetProp(ThisView+".wartosc","Field","KeyField",.F.)
DBSetProp(ThisView+".wartosc","Field","Updatable",.T.)

DBSetProp(ThisView+".pub","Field","DataType","L")
DBSetProp(ThisView+".pub","Field","UpdateName","GLOBVAR.pub")
DBSetProp(ThisView+".pub","Field","KeyField",.F.)
DBSetProp(ThisView+".pub","Field","Updatable",.T.)

DBSetProp(ThisView+".serial_id","Field","DataType","I")
DBSetProp(ThisView+".serial_id","Field","UpdateName","GLOBVAR.serial_id")
DBSetProp(ThisView+".serial_id","Field","KeyField",.T.)
DBSetProp(ThisView+".serial_id","Field","Updatable",.T.)

ThisView = 'document'
IF  INDBC(ThisView,"VIEW")
	DROP VIEW (ThisView)
ENDI
CREATE SQL VIEW (ThisView) CONNECTION 'conPostgres' SHAR as ;
SELECT Document.id_proces, Document.numer, Document.data,;
  Document.dokogo, Document.tresc, Document.nazwa, Document.do_wiadom,;
  Document.serial_id;
 FROM ;
     document Document

DBSetProp(ThisView,"View","SendUpdates",.T.)
DBSetProp(ThisView,"View","BatchUpdateCount",1)
DBSetProp(ThisView,"View","CompareMemo",.T.)
DBSetProp(ThisView,"View","FetchAsNeeded",.F.)
DBSetProp(ThisView,"View","FetchMemo",.T.)
DBSetProp(ThisView,"View","FetchSize",100)
DBSetProp(ThisView,"View","MaxRecords",-1)
DBSetProp(ThisView,"View","Prepared",.F.)
DBSetProp(ThisView,"View","ShareConnection",.F.)
DBSetProp(ThisView,"View","AllowSimultaneousFetch",.F.)
DBSetProp(ThisView,"View","UpdateType",1)
DBSetProp(ThisView,"View","UseMemoSize",255)
DBSetProp(ThisView,"View","Tables","document")
DBSetProp(ThisView,"View","WhereType",1)

DBSetProp(ThisView+".id_proces","Field","DataType","I")
DBSetProp(ThisView+".id_proces","Field","UpdateName","document.id_proces")
DBSetProp(ThisView+".id_proces","Field","KeyField",.F.)
DBSetProp(ThisView+".id_proces","Field","Updatable",.T.)

DBSetProp(ThisView+".numer","Field","DataType","C(40)")
DBSetProp(ThisView+".numer","Field","UpdateName","document.numer")
DBSetProp(ThisView+".numer","Field","KeyField",.F.)
DBSetProp(ThisView+".numer","Field","Updatable",.T.)

DBSetProp(ThisView+".data","Field","DataType","D")
DBSetProp(ThisView+".data","Field","UpdateName","document.data")
DBSetProp(ThisView+".data","Field","KeyField",.F.)
DBSetProp(ThisView+".data","Field","Updatable",.T.)

DBSetProp(ThisView+".dokogo","Field","DataType","C(250)")
DBSetProp(ThisView+".dokogo","Field","UpdateName","document.dokogo")
DBSetProp(ThisView+".dokogo","Field","KeyField",.F.)
DBSetProp(ThisView+".dokogo","Field","Updatable",.T.)

DBSetProp(ThisView+".tresc","Field","DataType","C(250)")
DBSetProp(ThisView+".tresc","Field","UpdateName","document.tresc")
DBSetProp(ThisView+".tresc","Field","KeyField",.F.)
DBSetProp(ThisView+".tresc","Field","Updatable",.T.)

DBSetProp(ThisView+".nazwa","Field","DataType","C(150)")
DBSetProp(ThisView+".nazwa","Field","UpdateName","document.nazwa")
DBSetProp(ThisView+".nazwa","Field","KeyField",.F.)
DBSetProp(ThisView+".nazwa","Field","Updatable",.T.)

DBSetProp(ThisView+".do_wiadom","Field","DataType","M")
DBSetProp(ThisView+".do_wiadom","Field","UpdateName","document.do_wiadom")
DBSetProp(ThisView+".do_wiadom","Field","KeyField",.F.)
DBSetProp(ThisView+".do_wiadom","Field","Updatable",.T.)

DBSetProp(ThisView+".serial_id","Field","DataType","I")
DBSetProp(ThisView+".serial_id","Field","UpdateName","document.serial_id")
DBSetProp(ThisView+".serial_id","Field","KeyField",.T.)
DBSetProp(ThisView+".serial_id","Field","Updatable",.T.)

USE Globvar
LOCA FOR Nazwa = 'gnDBType '
IF !FOUN()
	INSE INTO Globvar (Nazwa,Typ,Wartosc,Pub) VALU ('gnDBType ','N','1',.T.)
ENDI
USE 

Pack data