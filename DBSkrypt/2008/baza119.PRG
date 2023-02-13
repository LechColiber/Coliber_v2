ThisView = 'profile_gen'
IF  INDBC(ThisView,"VIEW")
	DROP VIEW (ThisView)
ENDI
CREATE SQL VIEW (ThisView) CONNECTION 'conPostgres' SHAR as ;
SELECT Profile_gen.id, Profile_gen.nazwa, Profile_gen.profil,;
  Profile_gen.id_tworcy, Profile_gen.data_utw, Profile_gen.data_mod,;
  Profile_gen.wspoldziel;
 FROM ;
     profile_gen Profile_gen

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
DBSetProp(ThisView,"View","Tables","profile_gen")
DBSetProp(ThisView,"View","WhereType",1)

DBSetProp(ThisView+".id","Field","DataType","I")
DBSetProp(ThisView+".id","Field","UpdateName","profile_gen.id")
DBSetProp(ThisView+".id","Field","KeyField",.T.)
DBSetProp(ThisView+".id","Field","Updatable",.T.)

DBSetProp(ThisView+".nazwa","Field","DataType","C(60)")
DBSetProp(ThisView+".nazwa","Field","UpdateName","profile_gen.nazwa")
DBSetProp(ThisView+".nazwa","Field","KeyField",.F.)
DBSetProp(ThisView+".nazwa","Field","Updatable",.T.)

DBSetProp(ThisView+".profil","Field","DataType","M")
DBSetProp(ThisView+".profil","Field","UpdateName","profile_gen.profil")
DBSetProp(ThisView+".profil","Field","KeyField",.F.)
DBSetProp(ThisView+".profil","Field","Updatable",.T.)

DBSetProp(ThisView+".id_tworcy","Field","DataType","I")
DBSetProp(ThisView+".id_tworcy","Field","UpdateName","profile_gen.id_tworcy")
DBSetProp(ThisView+".id_tworcy","Field","KeyField",.F.)
DBSetProp(ThisView+".id_tworcy","Field","Updatable",.T.)

DBSetProp(ThisView+".data_utw","Field","DataType","T")
DBSetProp(ThisView+".data_utw","Field","UpdateName","profile_gen.data_utw")
DBSetProp(ThisView+".data_utw","Field","KeyField",.F.)
DBSetProp(ThisView+".data_utw","Field","Updatable",.T.)

DBSetProp(ThisView+".data_mod","Field","DataType","T")
DBSetProp(ThisView+".data_mod","Field","UpdateName","profile_gen.data_mod")
DBSetProp(ThisView+".data_mod","Field","KeyField",.F.)
DBSetProp(ThisView+".data_mod","Field","Updatable",.T.)

DBSetProp(ThisView+".wspoldziel","Field","DataType","L")
DBSetProp(ThisView+".wspoldziel","Field","UpdateName","profile_gen.wspoldziel")
DBSetProp(ThisView+".wspoldziel","Field","KeyField",.F.)
DBSetProp(ThisView+".wspoldziel","Field","Updatable",.T.)

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
 WHERE  (Spr_zapo.spr_id) = ( ?Thisform.id_sprawy );
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

ThisView = 'dzialania'
IF  INDBC(ThisView,"VIEW")
	DROP VIEW (ThisView)
ENDI
CREATE SQL VIEW (ThisView) CONNECTION 'conPostgres' SHAR as ;
SELECT Dzialania.dz_id, Dzialania.nazwa, Dzialania.ukryte,;
  Dzialania.wybrany;
 FROM ;
     dzialania Dzialania ORDER BY Nazwa

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

DBSetProp(ThisView+".ukryte","Field","DataType","L")
DBSetProp(ThisView+".ukryte","Field","UpdateName","dzialania.ukryte")
DBSetProp(ThisView+".ukryte","Field","KeyField",.F.)
DBSetProp(ThisView+".ukryte","Field","Updatable",.T.)

DBSetProp(ThisView+".wybrany","Field","DataType","L")
DBSetProp(ThisView+".wybrany","Field","UpdateName","dzialania.wybrany")
DBSetProp(ThisView+".wybrany","Field","KeyField",.F.)
DBSetProp(ThisView+".wybrany","Field","Updatable",.T.)

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
 WHERE  (Spr_dzial.spr_id) = ( ?Thisform.id_sprawy );
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

ThisView = 'Struorg'
IF  INDBC(ThisView,"VIEW")
	DROP VIEW (ThisView)
ENDI
CREATE SQL VIEW (ThisView) CONNECTION 'conPostgres' SHAR as ;
SELECT Struorg.id_stru, Struorg.nazwa, Struorg.data_od, Struorg.data_do,;
  Struorg.aktualna;
 FROM ;
     struorg Struorg

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
DBSetProp(ThisView,"View","Tables","struorg")
DBSetProp(ThisView,"View","WhereType",3)

DBSetProp(ThisView+".id_stru","Field","DataType","I")
DBSetProp(ThisView+".id_stru","Field","UpdateName","struorg.id_stru")
DBSetProp(ThisView+".id_stru","Field","KeyField",.F.)
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

DBSETPROP('SPRAWY.ID', 'Field', 'Caption', "Id")
DBSETPROP('SPRAWY.NROG', 'Field', 'Caption', "Numer ogólny sprawy")
DBSETPROP('SPRAWY.NAZWA_SPRA', 'Field', 'Caption', "Nazwa sprawy")
DBSETPROP('SPRAWY.OPIS', 'Field', 'Caption', "Opis sprawy")
DBSETPROP('SPRAWY.SPOS_ZAK', 'Field', 'Caption', "Sposób zakoñczenia sprawy")
DBSETPROP('SPRAWY.NAZWA_KLI', 'Field', 'Caption', "Nazwa klienta")
DBSETPROP('SPRAWY.ADRES', 'Field', 'Caption', "Adres klienta")
DBSETPROP('SPRAWY.MIEJSCOW', 'Field', 'Caption', "Miejscowoœæ")
DBSETPROP('SPRAWY.KOD_POCZT', 'Field', 'Caption', "Kod pocztowy")
DBSETPROP('SPRAWY.INSPEKTORA', 'Field', 'Caption', "Inspektorat")
DBSETPROP('SPRAWY.ODDZIAL', 'Field', 'Caption', "Oddzia³")
DBSETPROP('SPRAWY.GRUP_UBEZ', 'Field', 'Caption', "Grupa ubezpieczeniowa")
DBSETPROP('SPRAWY.DATA_SZKOD', 'Field', 'Caption', "Data szkody")
DBSETPROP('SPRAWY.OD', 'Field', 'Caption', "Data za³o¿enia sprawy")
DBSETPROP('SPRAWY.data_DO', 'Field', 'Caption', "Data zakoñczenia sprawy")
DBSETPROP('SPRAWY.PRZEWID', 'Field', 'Caption', "Przewidywana data zakoñczenia sprawy")
DBSETPROP('SPRAWY.STANOWISKO', 'Field', 'Caption', "Prowadz¹cy sprawê")
DBSETPROP('SPRAWY.DOT_L_S', 'Field', 'Caption', "Sprawa dotyczy likwidacji czy sprzeda¿y?")
DBSETPROP('SPRAWY.RODZ_SPRAW', 'Field', 'Caption', "Rodzaj sprawy")
DBSETPROP('SPRAWY.RWA_SYMBOL', 'Field', 'Caption', "Numer rzeczowego wykazu akt")
DBSETPROP('SPRAWY.ZAPOSRDN', 'Field', 'Caption', "Za poœrednictwem kogo wp³ynê³y pisma w sprawie?")
DBSETPROP('SPRAWY.NR_SZKODY', 'Field', 'Caption', "Numer szkody")
DBSETPROP('SPRAWY.RODZ_RYZ', 'Field', 'Caption', "Rodzaj ryzyka")
DBSETPROP('SPRAWY.WLASC_POJ', 'Field', 'Caption', "W³aœciciel pojazdu")
DBSETPROP('SPRAWY.NR_REJ', 'Field', 'Caption', "Numer rejestracyjny")
DBSETPROP('SPRAWY.SKARGANA', 'Field', 'Caption', "Na co to skarga?")
DBSETPROP('SPRAWY.ID_PRODUKT', 'Field', 'Caption', "Identyfikator produktu")
DBSETPROP('SPRAWY.ID_G_USTAW', 'Field', 'Caption', "Identyfikator grupy ustawowej")
DBSETPROP('SPRAWY.GR_UB_RZEC', 'Field', 'Caption', "Rzeczowa")
DBSETPROP('SPRAWY.GR_UB_OSOB', 'Field', 'Caption', "Osobowa")

Use Dbc() Again In 0
Replace property with strt(property,'MT','MD') for objecttype='f' and 'MT'$property and !'stamp'$objectname
Use

Pack DATA