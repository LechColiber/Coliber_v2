ThisView = 'v_grup_ubez'
IF  INDBC(ThisView,"VIEW")
	DROP VIEW (ThisView)
ENDI
CREATE SQL VIEW (ThisView) CONNECTION 'conPostgres' SHAR as ;
SELECT Grup_ubez.nazwa, Grup_ubez.del, Grup_ubez.numer,;
  Grup_ubez.serial_id;
 FROM ;
     grup_ubez Grup_ubez

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
DBSetProp(ThisView,"View","Tables","grup_ubez")
DBSetProp(ThisView,"View","WhereType",1)

DBSetProp(ThisView+".nazwa","Field","DataType","C(120)")
DBSetProp(ThisView+".nazwa","Field","UpdateName","grup_ubez.nazwa")
DBSetProp(ThisView+".nazwa","Field","KeyField",.F.)
DBSetProp(ThisView+".nazwa","Field","Updatable",.T.)

DBSetProp(ThisView+".del","Field","DataType","N(3)")
DBSetProp(ThisView+".del","Field","UpdateName","grup_ubez.del")
DBSetProp(ThisView+".del","Field","KeyField",.F.)
DBSetProp(ThisView+".del","Field","Updatable",.T.)

DBSetProp(ThisView+".numer","Field","DataType","C(3)")
DBSetProp(ThisView+".numer","Field","UpdateName","grup_ubez.numer")
DBSetProp(ThisView+".numer","Field","KeyField",.F.)
DBSetProp(ThisView+".numer","Field","Updatable",.T.)

DBSetProp(ThisView+".serial_id","Field","DataType","I")
DBSetProp(ThisView+".serial_id","Field","UpdateName","grup_ubez.serial_id")
DBSetProp(ThisView+".serial_id","Field","KeyField",.T.)
DBSetProp(ThisView+".serial_id","Field","Updatable",.T.)

ThisView = 'grup_ubez'
IF  INDBC(ThisView,"VIEW")
	DROP VIEW (ThisView)
ENDI
CREATE SQL VIEW (ThisView) CONNECTION 'conPostgres' SHAR as ;
SELECT Grup_ubez.nazwa, Grup_ubez.del, Grup_ubez.numer,;
  Grup_ubez.serial_id;
 FROM ;
     GRUP_UBEZ Grup_ubez

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
DBSetProp(ThisView,"View","Tables","GRUP_UBEZ")
DBSetProp(ThisView,"View","WhereType",1)

DBSetProp(ThisView+".nazwa","Field","DataType","C(120)")
DBSetProp(ThisView+".nazwa","Field","UpdateName","GRUP_UBEZ.nazwa")
DBSetProp(ThisView+".nazwa","Field","KeyField",.F.)
DBSetProp(ThisView+".nazwa","Field","Updatable",.T.)

DBSetProp(ThisView+".del","Field","DataType","N(3)")
DBSetProp(ThisView+".del","Field","UpdateName","GRUP_UBEZ.del")
DBSetProp(ThisView+".del","Field","KeyField",.F.)
DBSetProp(ThisView+".del","Field","Updatable",.T.)

DBSetProp(ThisView+".numer","Field","DataType","C(3)")
DBSetProp(ThisView+".numer","Field","UpdateName","GRUP_UBEZ.numer")
DBSetProp(ThisView+".numer","Field","KeyField",.F.)
DBSetProp(ThisView+".numer","Field","Updatable",.T.)

DBSetProp(ThisView+".serial_id","Field","DataType","I")
DBSetProp(ThisView+".serial_id","Field","UpdateName","GRUP_UBEZ.serial_id")
DBSetProp(ThisView+".serial_id","Field","KeyField",.T.)
DBSetProp(ThisView+".serial_id","Field","Updatable",.T.)

ThisView = 'prod_ust'
IF  INDBC(ThisView,"VIEW")
	DROP VIEW (ThisView)
ENDI
CREATE SQL VIEW (ThisView) CONNECTION 'conPostgres' SHAR as ;
SELECT Prod_ust.id_usta, Prod_ust.id_prod;
 FROM ;
     prod_ust Prod_ust

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
DBSetProp(ThisView,"View","Tables","prod_ust")
DBSetProp(ThisView,"View","WhereType",1)

DBSetProp(ThisView+".id_usta","Field","DataType","I")
DBSetProp(ThisView+".id_usta","Field","UpdateName","prod_ust.id_usta")
DBSetProp(ThisView+".id_usta","Field","KeyField",.T.)
DBSetProp(ThisView+".id_usta","Field","Updatable",.T.)

DBSetProp(ThisView+".id_prod","Field","DataType","I")
DBSetProp(ThisView+".id_prod","Field","UpdateName","prod_ust.id_prod")
DBSetProp(ThisView+".id_prod","Field","KeyField",.T.)
DBSetProp(ThisView+".id_prod","Field","Updatable",.T.)


ThisView = 'v_InspInOddz'
IF  INDBC(ThisView,"VIEW")
	DROP VIEW (ThisView)
ENDI
CREATE SQL VIEW (ThisView) CONNECTION 'conPostgres' SHAR as ;
SELECT Inspektorat.nazwa, Inspektorat.del, Inspektorat.id_oddzialu,;
  Inspektorat.serial_id;
 FROM ;
     inspektorat Inspektorat;
 WHERE  Inspektorat.id_oddzialu = ?v_sprawy.id_oddzialu

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
DBSetProp(ThisView,"View","Tables","inspektorat")
DBSetProp(ThisView,"View","WhereType",1)

DBSetProp(ThisView+".nazwa","Field","DataType","C(50)")
DBSetProp(ThisView+".nazwa","Field","UpdateName","inspektorat.nazwa")
DBSetProp(ThisView+".nazwa","Field","KeyField",.F.)
DBSetProp(ThisView+".nazwa","Field","Updatable",.T.)

DBSetProp(ThisView+".del","Field","DataType","N(3)")
DBSetProp(ThisView+".del","Field","UpdateName","inspektorat.del")
DBSetProp(ThisView+".del","Field","KeyField",.F.)
DBSetProp(ThisView+".del","Field","Updatable",.T.)

DBSetProp(ThisView+".id_oddzialu","Field","DataType","N(4)")
DBSetProp(ThisView+".id_oddzialu","Field","UpdateName","inspektorat.id_oddzialu")
DBSetProp(ThisView+".id_oddzialu","Field","KeyField",.F.)
DBSetProp(ThisView+".id_oddzialu","Field","Updatable",.T.)

DBSetProp(ThisView+".serial_id","Field","DataType","I")
DBSetProp(ThisView+".serial_id","Field","UpdateName","inspektorat.serial_id")
DBSetProp(ThisView+".serial_id","Field","KeyField",.T.)
DBSetProp(ThisView+".serial_id","Field","Updatable",.T.)

ThisView = 'v_Sprawy'
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
  SPACE(50) AS nazwa_prowadz, Sprawy.skargana, Sprawy.id_produkt,;
  Sprawy.id_g_ustaw, Sprawy.gr_ub_rzec, Sprawy.gr_ub_osob, Sprawy.id_stru,;
  Sprawy.nrog, Sprawy.id_oddzialu;
 FROM ;
     sprawy Sprawy;
 ORDER BY Sprawy.nazwa_kli

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

DBSetProp(ThisView+".id","Field","DataType","N(12)")
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
DBSetProp(ThisView+".serial_id","Field","KeyField",.F.)
DBSetProp(ThisView+".serial_id","Field","Updatable",.F.)

DBSetProp(ThisView+".data_do","Field","DataType","D")
DBSetProp(ThisView+".data_do","Field","UpdateName","sprawy.data_do")
DBSetProp(ThisView+".data_do","Field","KeyField",.F.)
DBSetProp(ThisView+".data_do","Field","Updatable",.T.)

DBSetProp(ThisView+".nazwa_prowadz","Field","DataType","C(252)")
DBSetProp(ThisView+".nazwa_prowadz","Field","UpdateName","nazwa_prowadz")
DBSetProp(ThisView+".nazwa_prowadz","Field","KeyField",.F.)
DBSetProp(ThisView+".nazwa_prowadz","Field","Updatable",.F.)

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

ThisView = 'Sprawy'
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
  SPACE(50) AS nazwa_prowadz, Sprawy.skargana, Sprawy.id_produkt,;
  Sprawy.id_g_ustaw, Sprawy.gr_ub_rzec, Sprawy.gr_ub_osob, Sprawy.id_stru,;
  Sprawy.nrog, Sprawy.id_oddzialu;
 FROM ;
     sprawy Sprawy;
 ORDER BY Sprawy.nazwa_kli

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

DBSetProp(ThisView+".id","Field","DataType","N(12)")
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
DBSetProp(ThisView+".serial_id","Field","KeyField",.F.)
DBSetProp(ThisView+".serial_id","Field","Updatable",.F.)

DBSetProp(ThisView+".data_do","Field","DataType","D")
DBSetProp(ThisView+".data_do","Field","UpdateName","sprawy.data_do")
DBSetProp(ThisView+".data_do","Field","KeyField",.F.)
DBSetProp(ThisView+".data_do","Field","Updatable",.T.)

DBSetProp(ThisView+".nazwa_prowadz","Field","DataType","C(252)")
DBSetProp(ThisView+".nazwa_prowadz","Field","UpdateName","nazwa_prowadz")
DBSetProp(ThisView+".nazwa_prowadz","Field","KeyField",.F.)
DBSetProp(ThisView+".nazwa_prowadz","Field","Updatable",.F.)

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


ThisView = 'oddzial'
IF  INDBC(ThisView,"VIEW")
	DROP VIEW (ThisView)
ENDI
CREATE SQL VIEW (ThisView) CONNECTION 'conPostgres' SHAR as ;
SELECT Oddzial.id_oddzialu, Oddzial.nazwa, Oddzial.del,;
  Oddzial.serial_id, Oddzial.id_stru;
 FROM ;
     oddzial Oddzial

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
DBSetProp(ThisView,"View","Tables","oddzial")
DBSetProp(ThisView,"View","WhereType",1)

DBSetProp(ThisView+".id_oddzialu","Field","DataType","I")
DBSetProp(ThisView+".id_oddzialu","Field","UpdateName","oddzial.id_oddzialu")
DBSetProp(ThisView+".id_oddzialu","Field","KeyField",.F.)
DBSetProp(ThisView+".id_oddzialu","Field","Updatable",.T.)

DBSetProp(ThisView+".nazwa","Field","DataType","C(50)")
DBSetProp(ThisView+".nazwa","Field","UpdateName","oddzial.nazwa")
DBSetProp(ThisView+".nazwa","Field","KeyField",.F.)
DBSetProp(ThisView+".nazwa","Field","Updatable",.T.)

DBSetProp(ThisView+".del","Field","DataType","N(3)")
DBSetProp(ThisView+".del","Field","UpdateName","oddzial.del")
DBSetProp(ThisView+".del","Field","KeyField",.F.)
DBSetProp(ThisView+".del","Field","Updatable",.T.)

DBSetProp(ThisView+".serial_id","Field","DataType","I")
DBSetProp(ThisView+".serial_id","Field","UpdateName","oddzial.serial_id")
DBSetProp(ThisView+".serial_id","Field","KeyField",.T.)
DBSetProp(ThisView+".serial_id","Field","Updatable",.T.)

DBSetProp(ThisView+".id_stru","Field","DataType","I")
DBSetProp(ThisView+".id_stru","Field","UpdateName","oddzial.id_stru")
DBSetProp(ThisView+".id_stru","Field","KeyField",.F.)
DBSetProp(ThisView+".id_stru","Field","Updatable",.T.)


ThisView = 'v_oddzial'
IF  INDBC(ThisView,"VIEW")
	DROP VIEW (ThisView)
ENDI
CREATE SQL VIEW (ThisView) CONNECTION 'conPostgres' SHAR as ;
SELECT Oddzial.id_oddzialu, Oddzial.nazwa, Oddzial.del,;
  Oddzial.serial_id, Oddzial.id_stru;
 FROM ;
     oddzial Oddzial;
 WHERE  Oddzial.id_stru = ?v_oddzial_nIdStru

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
DBSetProp(ThisView,"View","Tables","oddzial")
DBSetProp(ThisView,"View","WhereType",1)

DBSetProp(ThisView+".id_oddzialu","Field","DataType","I")
DBSetProp(ThisView+".id_oddzialu","Field","UpdateName","oddzial.id_oddzialu")
DBSetProp(ThisView+".id_oddzialu","Field","KeyField",.F.)
DBSetProp(ThisView+".id_oddzialu","Field","Updatable",.T.)

DBSetProp(ThisView+".nazwa","Field","DataType","C(50)")
DBSetProp(ThisView+".nazwa","Field","UpdateName","oddzial.nazwa")
DBSetProp(ThisView+".nazwa","Field","KeyField",.F.)
DBSetProp(ThisView+".nazwa","Field","Updatable",.T.)

DBSetProp(ThisView+".del","Field","DataType","N(3)")
DBSetProp(ThisView+".del","Field","UpdateName","oddzial.del")
DBSetProp(ThisView+".del","Field","KeyField",.F.)
DBSetProp(ThisView+".del","Field","Updatable",.T.)

DBSetProp(ThisView+".serial_id","Field","DataType","I")
DBSetProp(ThisView+".serial_id","Field","UpdateName","oddzial.serial_id")
DBSetProp(ThisView+".serial_id","Field","KeyField",.T.)
DBSetProp(ThisView+".serial_id","Field","Updatable",.T.)

DBSetProp(ThisView+".id_stru","Field","DataType","I")
DBSetProp(ThisView+".id_stru","Field","UpdateName","oddzial.id_stru")
DBSetProp(ThisView+".id_stru","Field","KeyField",.F.)
DBSetProp(ThisView+".id_stru","Field","Updatable",.T.)

ThisView = 'v_spr_dzial'
IF  INDBC(ThisView,"VIEW")
	DROP VIEW (ThisView)
ENDI
CREATE SQL VIEW (ThisView) CONNECTION 'conPostgres' SHAR as ;
SELECT Spr_dzial.id, Spr_dzial.spr_id, Spr_dzial.dz_id, Spr_dzial.data,;
  Dzialania.nazwa;
 FROM ;
   {oj  spr_dzial Spr_dzial ;
    LEFT OUTER JOIN dzialania Dzialania ;
   ON  Spr_dzial.dz_id = Dzialania.dz_id};
 WHERE  Spr_dzial.spr_id = ( ?v_sprawy.id );
 ORDER BY Spr_dzial.data

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
DBSetProp(ThisView,"View","Tables","spr_dzial")
DBSetProp(ThisView,"View","WhereType",1)

DBSetProp(ThisView+".id","Field","DataType","I")
DBSetProp(ThisView+".id","Field","UpdateName","spr_dzial.id")
DBSetProp(ThisView+".id","Field","KeyField",.T.)
DBSetProp(ThisView+".id","Field","Updatable",.T.)

DBSetProp(ThisView+".spr_id","Field","DataType","I")
DBSetProp(ThisView+".spr_id","Field","UpdateName","spr_dzial.spr_id")
DBSetProp(ThisView+".spr_id","Field","KeyField",.F.)
DBSetProp(ThisView+".spr_id","Field","Updatable",.T.)

DBSetProp(ThisView+".dz_id","Field","DataType","I")
DBSetProp(ThisView+".dz_id","Field","UpdateName","spr_dzial.dz_id")
DBSetProp(ThisView+".dz_id","Field","KeyField",.F.)
DBSetProp(ThisView+".dz_id","Field","Updatable",.T.)

DBSetProp(ThisView+".data","Field","DataType","D")
DBSetProp(ThisView+".data","Field","UpdateName","spr_dzial.data")
DBSetProp(ThisView+".data","Field","KeyField",.F.)
DBSetProp(ThisView+".data","Field","Updatable",.T.)

DBSetProp(ThisView+".nazwa","Field","DataType","C(50)")
DBSetProp(ThisView+".nazwa","Field","UpdateName","dzialania.nazwa")
DBSetProp(ThisView+".nazwa","Field","KeyField",.F.)
DBSetProp(ThisView+".nazwa","Field","Updatable",.F.)


ThisView = 'dzialania'
IF  INDBC(ThisView,"VIEW")
	DROP VIEW (ThisView)
ENDI
CREATE SQL VIEW (ThisView) CONNECTION 'conPostgres' SHAR as ;
SELECT Dzialania.dz_id, Dzialania.nazwa, true as wybrany;
 FROM ;
     dzialania Dzialania

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
DBSetProp(ThisView,"View","Tables","dzialania")
DBSetProp(ThisView,"View","WhereType",1)

DBSetProp(ThisView+".dz_id","Field","DataType","I")
DBSetProp(ThisView+".dz_id","Field","UpdateName","dzialania.dz_id")
DBSetProp(ThisView+".dz_id","Field","KeyField",.T.)
DBSetProp(ThisView+".dz_id","Field","Updatable",.T.)
DBSetProp(ThisView+".nazwa","Field","DataType","C(50)")
DBSetProp(ThisView+".nazwa","Field","UpdateName","dzialania.nazwa")
DBSetProp(ThisView+".nazwa","Field","KeyField",.F.)
DBSetProp(ThisView+".nazwa","Field","Updatable",.T.)
DBSetProp(ThisView+".wybrany", 'Field', 'KeyField', .F.)
DBSetProp(ThisView+".wybrany", 'Field', 'Updatable', .F.)
DBSetProp(ThisView+".wybrany", 'Field', 'UpdateName', '')
DBSetProp(ThisView+".wybrany", 'Field', 'DataType', "L")


ThisView = 'spr_zapo'
IF  INDBC(ThisView,"VIEW")
	DROP VIEW (ThisView)
ENDI
CREATE SQL VIEW (ThisView) CONNECTION 'conPostgres' SHAR as ;
SELECT Spr_zapo.spr_id, Spr_zapo.zapo_id, Spr_zapo.kolejnosc,;
  Zaposrdn.nazwa, Zaposrdn.nazwad;
 FROM ;
   {oj  spr_zapo Spr_zapo ;
    LEFT OUTER JOIN zaposrdn Zaposrdn ;
   ON  Spr_zapo.zapo_id = Zaposrdn.serial_id};
 WHERE  Spr_zapo.spr_id = ?v_sprawy.id;
 ORDER BY Spr_zapo.kolejnosc

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
DBSetProp(ThisView,"View","Tables","spr_zapo")
DBSetProp(ThisView,"View","WhereType",1)

DBSetProp(ThisView+".spr_id","Field","DataType","I")
DBSetProp(ThisView+".spr_id","Field","UpdateName","spr_zapo.spr_id")
DBSetProp(ThisView+".spr_id","Field","KeyField",.T.)
DBSetProp(ThisView+".spr_id","Field","Updatable",.T.)

DBSetProp(ThisView+".zapo_id","Field","DataType","I")
DBSetProp(ThisView+".zapo_id","Field","UpdateName","spr_zapo.zapo_id")
DBSetProp(ThisView+".zapo_id","Field","KeyField",.T.)
DBSetProp(ThisView+".zapo_id","Field","Updatable",.T.)

DBSetProp(ThisView+".kolejnosc","Field","DataType","I")
DBSetProp(ThisView+".kolejnosc","Field","UpdateName","spr_zapo.kolejnosc")
DBSetProp(ThisView+".kolejnosc","Field","KeyField",.F.)
DBSetProp(ThisView+".kolejnosc","Field","Updatable",.T.)

DBSetProp(ThisView+".nazwa","Field","DataType","C(20)")
DBSetProp(ThisView+".nazwa","Field","UpdateName","zaposrdn.nazwa")
DBSetProp(ThisView+".nazwa","Field","KeyField",.F.)
DBSetProp(ThisView+".nazwa","Field","Updatable",.F.)

DBSetProp(ThisView+".nazwad","Field","DataType","C(200)")
DBSetProp(ThisView+".nazwad","Field","UpdateName","zaposrdn.nazwad")
DBSetProp(ThisView+".nazwad","Field","KeyField",.F.)
DBSetProp(ThisView+".nazwad","Field","Updatable",.F.)

