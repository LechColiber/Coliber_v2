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
  Sprawy.pniezalatw, Sprawy.kopia;
 FROM ;
     sprawy Sprawy

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

DBSetProp(ThisView+".id","Field","Caption","Id")
DBSetProp(ThisView+".id","Field","DataType","I")
DBSetProp(ThisView+".id","Field","UpdateName","sprawy.id")
DBSetProp(ThisView+".id","Field","KeyField",.F.)
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
DBSetProp(ThisView+".opis","Field","DataType","M")
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
DBSetProp(ThisView+".serial_id","Field","KeyField",.T.)
DBSetProp(ThisView+".serial_id","Field","Updatable",.T.)

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

DBSetProp(ThisView+".kopia","Field","DataType","L")
DBSetProp(ThisView+".kopia","Field","UpdateName","sprawy.kopia")
DBSetProp(ThisView+".kopia","Field","KeyField",.F.)
DBSetProp(ThisView+".kopia","Field","Updatable",.T.)

