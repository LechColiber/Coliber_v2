ThisView = 'Zaposrdn'
IF  INDBC(ThisView,"VIEW")
	DROP VIEW (ThisView)
ENDI
CREATE SQL VIEW (ThisView) CONNECTION 'conPostgres' SHAR as ;
SELECT Zaposrdn.nazwa, Zaposrdn.timestamp_column, Zaposrdn.serial_id,;
  Zaposrdn.nazwad, Zaposrdn.del, Zaposrdn.kolej_wysw;
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
DBSetProp(ThisView+".serial_id","Field","Updatable",.T.)

DBSetProp(ThisView+".nazwad","Field","DataType","C(200)")
DBSetProp(ThisView+".nazwad","Field","UpdateName","ZAPOSRDN.nazwad")
DBSetProp(ThisView+".nazwad","Field","KeyField",.F.)
DBSetProp(ThisView+".nazwad","Field","Updatable",.T.)

DBSetProp(ThisView+".del","Field","DataType","I")
DBSetProp(ThisView+".del","Field","UpdateName","ZAPOSRDN.del")
DBSetProp(ThisView+".del","Field","KeyField",.F.)
DBSetProp(ThisView+".del","Field","Updatable",.T.)

DBSetProp(ThisView+".kolej_wysw","Field","DataType","I")
DBSetProp(ThisView+".kolej_wysw","Field","UpdateName","ZAPOSRDN.kolej_wysw")
DBSetProp(ThisView+".kolej_wysw","Field","KeyField",.F.)
DBSetProp(ThisView+".kolej_wysw","Field","Updatable",.T.)

USE Zaposrdn
repl del with 0 for isnull(del)
USE