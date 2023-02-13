thisView = 'ErrorH'
IF  INDBC(ThisView,"VIEW")
	DROP VIEW (ThisView)
ENDI
CREATE SQL VIEW (ThisView) CONNECTION 'conPostgres' SHAR as ;
SELECT Errorh.error, Errorh.message, Errorh.opis_b,;
  Errorh.timestamp_column, Errorh.serial_id;
 FROM ;
     ERRORH Errorh

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
DBSetProp(ThisView,"View","Tables","ERRORH")
DBSetProp(ThisView,"View","WhereType",3)

DBSetProp(ThisView+".error","Field","DataType","N(7)")
DBSetProp(ThisView+".error","Field","UpdateName","ERRORH.error")
DBSetProp(ThisView+".error","Field","KeyField",.F.)
DBSetProp(ThisView+".error","Field","Updatable",.T.)

DBSetProp(ThisView+".message","Field","DataType","C(200)")
DBSetProp(ThisView+".message","Field","UpdateName","ERRORH.message")
DBSetProp(ThisView+".message","Field","KeyField",.F.)
DBSetProp(ThisView+".message","Field","Updatable",.T.)

DBSetProp(ThisView+".opis_b","Field","DataType","M")
DBSetProp(ThisView+".opis_b","Field","UpdateName","ERRORH.opis_b")
DBSetProp(ThisView+".opis_b","Field","KeyField",.F.)
DBSetProp(ThisView+".opis_b","Field","Updatable",.T.)

DBSetProp(ThisView+".timestamp_column","Field","DataType","T")
DBSetProp(ThisView+".timestamp_column","Field","UpdateName","ERRORH.timestamp_column")
DBSetProp(ThisView+".timestamp_column","Field","KeyField",.F.)
DBSetProp(ThisView+".timestamp_column","Field","Updatable",.T.)

DBSetProp(ThisView+".serial_id","Field","DataType","I")
DBSetProp(ThisView+".serial_id","Field","UpdateName","ERRORH.serial_id")
DBSetProp(ThisView+".serial_id","Field","KeyField",.T.)
DBSetProp(ThisView+".serial_id","Field","Updatable",.F.)

insert into errorh (message,opis_b) values ([Connectivity error: Cannot insert duplicate key row in object 'dbo.sprawy' with unique index 'idx_sprawy_nr'.],[Sprawa o podanym numerze ju¿ istnieje])
use in errorh