ThisView = 'oddzial'
IF  INDBC(ThisView,"VIEW")
	DROP VIEW (ThisView)
ENDI
CREATE SQL VIEW (ThisView) CONNECTION 'conPostgres' SHAR as ;
SELECT Oddzial.id_oddzialu, Oddzial.nazwa, Oddzial.del,;
  Oddzial.serial_id, Oddzial.id_stru, Oddzial.oddzial;
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

DBSetProp(ThisView+".oddzial","Field","DataType","C(40)")
DBSetProp(ThisView+".oddzial","Field","UpdateName","oddzial.oddzial")
DBSetProp(ThisView+".oddzial","Field","KeyField",.F.)
DBSetProp(ThisView+".oddzial","Field","Updatable",.T.)

PACK DATA