LPAR  iBit
PRIV  cPath,cForm,ArrLang,cFunc
cPath ="C:\Program\Exell\Net\Lang\"
DIME ArrLang[5]
ArrLang[1] = "DE"
ArrLang[2] = "EN"
ArrLang[3] = "ES"
ArrLang[4] = "FR"
ArrLang[5] = "PL"


CLOS TABL ALL

IF  PCOU() = 0
	iBit = 0
ENDI

do CreateResx WITH iBit in t
