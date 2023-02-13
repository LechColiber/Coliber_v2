thisView = 'lista_obieg'
IF  INDBC(ThisView,"VIEW")
	DROP VIEW (ThisView)
ENDI
CREATE SQL VIEW (ThisView) CONNECTION 'conPostgres' SHAR as ;
SELECT G.struktura_grupa AS biuro, G.nazwa_uzyt AS nazwisko,;
  G.stanow_nazwa, G.id_stanowiska, Obieg.nrdzien, Obieg.datawplyw,;
  Obieg.przekaz, Obieg.stanowisko, Obieg.idpisma, Obieg.deklar;
 FROM ;
     obieg Obieg,;
    t_global_uzyt_i_stanow G;
 WHERE  Obieg.stanowisko = G.id_stanowiska;
   AND  Obieg.idpisma = ( ?thisform.idpisma )

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

DBSetProp(ThisView+".deklar","Field","DataType","C(41)")
DBSetProp(ThisView+".deklar","Field","UpdateName","obieg.deklar")
DBSetProp(ThisView+".deklar","Field","KeyField",.F.)
DBSetProp(ThisView+".deklar","Field","Updatable",.T.)

