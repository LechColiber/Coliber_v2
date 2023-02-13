thisView = 'spr_zapo'
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
 WHERE  Spr_zapo.spr_id = ( ?Thisform.id_sprawy );
 ORDER BY Spr_zapo.kolejnosc

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
DBSetProp(ThisView+".kolejnosc","Field","KeyField",.T.)
DBSetProp(ThisView+".kolejnosc","Field","Updatable",.T.)

DBSetProp(ThisView+".nazwa","Field","DataType","C(20)")
DBSetProp(ThisView+".nazwa","Field","UpdateName","zaposrdn.nazwa")
DBSetProp(ThisView+".nazwa","Field","KeyField",.F.)
DBSetProp(ThisView+".nazwa","Field","Updatable",.F.)

DBSetProp(ThisView+".nazwad","Field","DataType","C(200)")
DBSetProp(ThisView+".nazwad","Field","UpdateName","zaposrdn.nazwad")
DBSetProp(ThisView+".nazwad","Field","KeyField",.F.)
DBSetProp(ThisView+".nazwad","Field","Updatable",.F.)

