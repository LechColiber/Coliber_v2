thisView = 'imp_jedn'
IF  INDBC(ThisView,"VIEW")
	DROP VIEW (ThisView)
ENDI
CREATE SQL VIEW (ThisView) CONNECTION 'conPostgres' SHAR as ;
SELECT Imp_jedn.nr_oddz, Imp_jedn.nr_insp, Imp_jedn.nazwa,;
  Imp_jedn.skrot, Imp_jedn.isdefault, Imp_jedn.seq_firstv,;
  Imp_jedn.miejscow;
 FROM ;
     imp_jedn Imp_jedn

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
DBSetProp(ThisView,"View","Tables","imp_jedn")
DBSetProp(ThisView,"View","WhereType",1)

DBSetProp(ThisView+".nr_oddz","Field","DataType","N(5)")
DBSetProp(ThisView+".nr_oddz","Field","UpdateName","imp_jedn.nr_oddz")
DBSetProp(ThisView+".nr_oddz","Field","KeyField",.T.)
DBSetProp(ThisView+".nr_oddz","Field","Updatable",.T.)

DBSetProp(ThisView+".nr_insp","Field","DataType","N(5)")
DBSetProp(ThisView+".nr_insp","Field","UpdateName","imp_jedn.nr_insp")
DBSetProp(ThisView+".nr_insp","Field","KeyField",.F.)
DBSetProp(ThisView+".nr_insp","Field","Updatable",.T.)

DBSetProp(ThisView+".nazwa","Field","DataType","C(100)")
DBSetProp(ThisView+".nazwa","Field","UpdateName","imp_jedn.nazwa")
DBSetProp(ThisView+".nazwa","Field","KeyField",.F.)
DBSetProp(ThisView+".nazwa","Field","Updatable",.T.)

DBSetProp(ThisView+".skrot","Field","DataType","C(50)")
DBSetProp(ThisView+".skrot","Field","UpdateName","imp_jedn.skrot")
DBSetProp(ThisView+".skrot","Field","KeyField",.F.)
DBSetProp(ThisView+".skrot","Field","Updatable",.T.)

DBSetProp(ThisView+".isdefault","Field","DataType","L")
DBSetProp(ThisView+".isdefault","Field","UpdateName","imp_jedn.isdefault")
DBSetProp(ThisView+".isdefault","Field","KeyField",.F.)
DBSetProp(ThisView+".isdefault","Field","Updatable",.T.)

DBSetProp(ThisView+".seq_firstv","Field","DataType","N(14)")
DBSetProp(ThisView+".seq_firstv","Field","UpdateName","imp_jedn.seq_firstv")
DBSetProp(ThisView+".seq_firstv","Field","KeyField",.F.)
DBSetProp(ThisView+".seq_firstv","Field","Updatable",.T.)

DBSetProp(ThisView+".miejscow","Field","DataType","C(50)")
DBSetProp(ThisView+".miejscow","Field","UpdateName","imp_jedn.miejscow")
DBSetProp(ThisView+".miejscow","Field","KeyField",.F.)
DBSetProp(ThisView+".miejscow","Field","Updatable",.T.)

