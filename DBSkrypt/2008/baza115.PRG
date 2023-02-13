
ThisView = 'zaposrdn'
IF  INDBC(ThisView,"VIEW")
	DROP VIEW (ThisView)
ENDI
CREATE SQL VIEW (ThisView) CONNECTION 'conPostgres' SHAR as ;
SELECT Zaposrdn.nazwa, Zaposrdn.timestamp_column, Zaposrdn.serial_id,;
  Zaposrdn.nazwad;
 FROM ;
     zaposrdn Zaposrdn

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
DBSetProp(ThisView,"View","Tables","zaposrdn")
DBSetProp(ThisView,"View","WhereType",1)

DBSetProp(ThisView+".nazwa","Field","DataType","C(252)")
DBSetProp(ThisView+".nazwa","Field","UpdateName","zaposrdn.nazwa")
DBSetProp(ThisView+".nazwa","Field","KeyField",.F.)
DBSetProp(ThisView+".nazwa","Field","Updatable",.T.)

DBSetProp(ThisView+".timestamp_column","Field","DataType","T")
DBSetProp(ThisView+".timestamp_column","Field","UpdateName","zaposrdn.timestamp_column")
DBSetProp(ThisView+".timestamp_column","Field","KeyField",.F.)
DBSetProp(ThisView+".timestamp_column","Field","Updatable",.T.)

DBSetProp(ThisView+".serial_id","Field","DataType","I")
DBSetProp(ThisView+".serial_id","Field","UpdateName","zaposrdn.serial_id")
DBSetProp(ThisView+".serial_id","Field","KeyField",.T.)
DBSetProp(ThisView+".serial_id","Field","Updatable",.T.)

DBSetProp(ThisView+".nazwad","Field","DataType","C(200)")
DBSetProp(ThisView+".nazwad","Field","UpdateName","zaposrdn.nazwad")
DBSetProp(ThisView+".nazwad","Field","KeyField",.F.)
DBSetProp(ThisView+".nazwad","Field","Updatable",.T.)

ThisView = 'nrsprawy'
IF  INDBC(ThisView,"VIEW")
	DROP VIEW (ThisView)
ENDI
CREATE SQL VIEW (ThisView) CONNECTION 'conPostgres' SHAR as ;
SELECT Nrsprawy.id, Nrsprawy.id_sprawy, Nrsprawy.biuro, Nrsprawy.nrs;
 FROM ;
     nrsprawy Nrsprawy WHERE id_sprawy = ?lnv_id_sprawy


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
DBSetProp(ThisView,"View","Tables","nrsprawy")
DBSetProp(ThisView,"View","WhereType",1)

DBSetProp(ThisView+".id","Field","DataType","I")
DBSetProp(ThisView+".id","Field","UpdateName","nrsprawy.id")
DBSetProp(ThisView+".id","Field","KeyField",.T.)
DBSetProp(ThisView+".id","Field","Updatable",.T.)

DBSetProp(ThisView+".id_sprawy","Field","DataType","I")
DBSetProp(ThisView+".id_sprawy","Field","UpdateName","nrsprawy.id_sprawy")
DBSetProp(ThisView+".id_sprawy","Field","KeyField",.F.)
DBSetProp(ThisView+".id_sprawy","Field","Updatable",.T.)

DBSetProp(ThisView+".biuro","Field","DataType","C(5)")
DBSetProp(ThisView+".biuro","Field","UpdateName","nrsprawy.biuro")
DBSetProp(ThisView+".biuro","Field","KeyField",.F.)
DBSetProp(ThisView+".biuro","Field","Updatable",.T.)

DBSetProp(ThisView+".nrs","Field","DataType","C(40)")
DBSetProp(ThisView+".nrs","Field","UpdateName","nrsprawy.nrs")
DBSetProp(ThisView+".nrs","Field","KeyField",.F.)
DBSetProp(ThisView+".nrs","Field","Updatable",.T.)

ThisView = 'v_obieg'
IF  INDBC(ThisView,"VIEW")
	DROP VIEW (ThisView)
ENDI
CREATE SQL VIEW (ThisView) CONNECTION 'conPostgres' SHAR as ;
SELECT Obieg.idpisma, Obieg.stanowisko, Obieg.nrdzien, Obieg.datawplyw,;
  Obieg.przekaz, Obieg.deklar, Obieg.dodekret, Obieg.time_, Obieg.podpisal,;
  Obieg.rok, Obieg.nr_copy, Obieg.date_stamp, Obieg.grupa, Obieg.serial_id;
 FROM ;
     obieg Obieg

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
DBSetProp(ThisView,"View","Tables","obieg")
DBSetProp(ThisView,"View","WhereType",1)

DBSetProp(ThisView+".idpisma","Field","DataType","I")
DBSetProp(ThisView+".idpisma","Field","UpdateName","obieg.idpisma")
DBSetProp(ThisView+".idpisma","Field","KeyField",.F.)
DBSetProp(ThisView+".idpisma","Field","Updatable",.T.)

DBSetProp(ThisView+".stanowisko","Field","DataType","I")
DBSetProp(ThisView+".stanowisko","Field","UpdateName","obieg.stanowisko")
DBSetProp(ThisView+".stanowisko","Field","KeyField",.F.)
DBSetProp(ThisView+".stanowisko","Field","Updatable",.T.)

DBSetProp(ThisView+".nrdzien","Field","DataType","I")
DBSetProp(ThisView+".nrdzien","Field","UpdateName","obieg.nrdzien")
DBSetProp(ThisView+".nrdzien","Field","KeyField",.F.)
DBSetProp(ThisView+".nrdzien","Field","Updatable",.T.)

DBSetProp(ThisView+".datawplyw","Field","DataType","T")
DBSetProp(ThisView+".datawplyw","Field","UpdateName","obieg.datawplyw")
DBSetProp(ThisView+".datawplyw","Field","KeyField",.F.)
DBSetProp(ThisView+".datawplyw","Field","Updatable",.T.)

DBSetProp(ThisView+".przekaz","Field","DataType","C(1)")
DBSetProp(ThisView+".przekaz","Field","UpdateName","obieg.przekaz")
DBSetProp(ThisView+".przekaz","Field","KeyField",.F.)
DBSetProp(ThisView+".przekaz","Field","Updatable",.T.)

DBSetProp(ThisView+".deklar","Field","DataType","C(41)")
DBSetProp(ThisView+".deklar","Field","UpdateName","obieg.deklar")
DBSetProp(ThisView+".deklar","Field","KeyField",.F.)
DBSetProp(ThisView+".deklar","Field","Updatable",.T.)

DBSetProp(ThisView+".dodekret","Field","DataType","L")
DBSetProp(ThisView+".dodekret","Field","UpdateName","obieg.dodekret")
DBSetProp(ThisView+".dodekret","Field","KeyField",.F.)
DBSetProp(ThisView+".dodekret","Field","Updatable",.T.)

DBSetProp(ThisView+".time_","Field","DataType","C(13)")
DBSetProp(ThisView+".time_","Field","UpdateName","obieg.time_")
DBSetProp(ThisView+".time_","Field","KeyField",.F.)
DBSetProp(ThisView+".time_","Field","Updatable",.T.)

DBSetProp(ThisView+".podpisal","Field","DataType","C(40)")
DBSetProp(ThisView+".podpisal","Field","UpdateName","obieg.podpisal")
DBSetProp(ThisView+".podpisal","Field","KeyField",.F.)
DBSetProp(ThisView+".podpisal","Field","Updatable",.T.)

DBSetProp(ThisView+".rok","Field","DataType","I")
DBSetProp(ThisView+".rok","Field","UpdateName","obieg.rok")
DBSetProp(ThisView+".rok","Field","KeyField",.F.)
DBSetProp(ThisView+".rok","Field","Updatable",.T.)

DBSetProp(ThisView+".nr_copy","Field","DataType","I")
DBSetProp(ThisView+".nr_copy","Field","UpdateName","obieg.nr_copy")
DBSetProp(ThisView+".nr_copy","Field","KeyField",.F.)
DBSetProp(ThisView+".nr_copy","Field","Updatable",.T.)

DBSetProp(ThisView+".date_stamp","Field","DataType","T")
DBSetProp(ThisView+".date_stamp","Field","UpdateName","obieg.date_stamp")
DBSetProp(ThisView+".date_stamp","Field","KeyField",.F.)
DBSetProp(ThisView+".date_stamp","Field","Updatable",.T.)

DBSetProp(ThisView+".grupa","Field","DataType","C(5)")
DBSetProp(ThisView+".grupa","Field","UpdateName","obieg.grupa")
DBSetProp(ThisView+".grupa","Field","KeyField",.F.)
DBSetProp(ThisView+".grupa","Field","Updatable",.T.)

DBSetProp(ThisView+".serial_id","Field","DataType","I")
DBSetProp(ThisView+".serial_id","Field","UpdateName","obieg.serial_id")
DBSetProp(ThisView+".serial_id","Field","KeyField",.T.)
DBSetProp(ThisView+".serial_id","Field","Updatable",.T.)


ThisView = 'v_struorg'
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
DBSetProp(ThisView,"View","FetchSize",100)
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


ThisView = 'grup_usta'
IF  INDBC(ThisView,"VIEW")
	DROP VIEW (ThisView)
ENDI
CREATE SQL VIEW (ThisView) CONNECTION 'conPostgres' SHAR as ;
SELECT Grup_usta.id, Grup_usta.nazwa, Grup_usta.opis;
 FROM ;
     grup_usta Grup_usta

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
DBSetProp(ThisView,"View","Tables","grup_usta")
DBSetProp(ThisView,"View","WhereType",1)

DBSetProp(ThisView+".id","Field","DataType","I")
DBSetProp(ThisView+".id","Field","UpdateName","grup_usta.id")
DBSetProp(ThisView+".id","Field","KeyField",.T.)
DBSetProp(ThisView+".id","Field","Updatable",.T.)

DBSetProp(ThisView+".nazwa","Field","DataType","C(120)")
DBSetProp(ThisView+".nazwa","Field","UpdateName","grup_usta.nazwa")
DBSetProp(ThisView+".nazwa","Field","KeyField",.F.)
DBSetProp(ThisView+".nazwa","Field","Updatable",.T.)

DBSetProp(ThisView+".opis","Field","DataType","M")
DBSetProp(ThisView+".opis","Field","UpdateName","grup_usta.opis")
DBSetProp(ThisView+".opis","Field","KeyField",.F.)
DBSetProp(ThisView+".opis","Field","Updatable",.T.)



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
  SPACE(50) AS nazwa_prowadz,skargana,id_produkt,id_g_ustaw,gr_ub_rzec,gr_ub_osob,id_stru,nrog;
 FROM  sprawy Sprawy ;
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

DBSetProp(ThisView+".data_szkod","Field","DataType","T")
DBSetProp(ThisView+".data_szkod","Field","UpdateName","sprawy.data_szkod")
DBSetProp(ThisView+".data_szkod","Field","KeyField",.F.)
DBSetProp(ThisView+".data_szkod","Field","Updatable",.T.)

DBSetProp(ThisView+".od","Field","DataType","T")
DBSetProp(ThisView+".od","Field","UpdateName","sprawy.od")
DBSetProp(ThisView+".od","Field","KeyField",.F.)
DBSetProp(ThisView+".od","Field","Updatable",.T.)

DBSetProp(ThisView+".przewid","Field","DataType","T")
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

DBSetProp(ThisView+".data_do","Field","DataType","T")
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

drop view af_etyk_dla_rodz_dok
drop view af_ety_i_wart_ety_dla_opi_opi_id
drop view af_existing_wart_ety
drop view af_wart_ety_dla_opisu_view
drop view af_wybrany_opis

drop view bazapust
drop view bdoprzek
drop view bdziendo
drop view bdzienni
drop view binnewyc
drop view bkontrol
drop view bobieg
drop view bopisrej
drop view bosoby
drop view bprze_kl
drop view bprzycho
drop view brejestr
drop view bwychodz
drop view d_filtry
drop view stanydok
drop view stanytab

drop view PRZYCH_ADOKOGO
drop view PRZYCH_ADOTYCZY
drop view PRZYCH_AGRUPA
drop view PRZYCH_ANADWCAADR
drop view PRZYCH_ANADWCAMIE
drop view PRZYCH_ANADWCANAZ
drop view PRZYCH_ANADWCAZNK
drop view PRZYCH_ANRDDEK
drop view PRZYCH_ANRDZIEN
drop view PRZYCH_ANRPRZESYL
drop view PRZYCH_APNRDZIEN
drop view WYCH_GADRESNAZ
drop view WYCH_GADRSATADR
drop view WYCH_GADRSATMI
drop view WYCH_GDOTYCZY
drop view WYCH_GGRUPA
drop view WYCH_GNADAWCA
drop view WYCH_GNADZNAK
drop view WYCH_GNRDZIEN
drop view WYCH_GNRPRZES
drop view WYCH_KNRDZIEN

Use Dbc() Again In 0
Replace property with strt(property,'MT','MD') for objecttype='f' and 'MT'$property and !'stamp'$objectname
Use

pack data