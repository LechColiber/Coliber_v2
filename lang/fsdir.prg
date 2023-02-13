*FindKey("toDelete","C:\Program\Exell\NET\","*.cs")
FindVal("Autor","C:\Program\Exell\NET\","*.cs",'PL')
*FindVal("e active address","C:\Program\Exell\NET\","*.cs",'EN')
IF  USED('qFind')
	SELE qFind
	BROW LAST
	USE
ENDI
*/*//////////////////////////////////////////////////////////////////////////////////////
*/*//////////////////////////////////////////////////////////////////////////////////////
PROC  FindVal
LPAR  cFind,cDir,cMask,cLang
LOCAL cRun
IF  EMPT(cFind)
	RETU
ENDI
IF  USED('KMaster')
	SELE  KMaster
ELSE
	SELE 0
	USE KMaster
ENDI
cFind =  LOWE(cFind)
cRun = 'SET FILT TO "'+cFind+'"$LOWE('+cLang+'T)'
&cRun.
LOCA
BROW LAST
cFind = ALLT(KeyName)
USE
IF  LAST() = 27
	WAIT WIND 'Akcja przerwana przez u¿ytkownika '
	RETU
ENDI
IF  EMPT(cFind)
	RETU
ENDI
IF  USED('qFind')
	USE IN qFind
ENDI
fsDir_(cFind,cDir,cMask)
*/*//////////////////////////////////////////////////////////////////////////////////////
*/*//////////////////////////////////////////////////////////////////////////////////////
PROC  FindKey
LPAR  cFind,cDir,cMask
IF  EMPT(cFind)
	RETU
ENDI
IF  USED('qFind')
	USE IN qFind
ENDI
fsDir_(cFind,cDir,cMask)
*/*//////////////////////////////////////////////////////////////////////////////////////
*/*//////////////////////////////////////////////////////////////////////////////////////
PROC  fsDir_
LPAR  cFind,cDir,cMask
LOCAL iCnt,cChar,iFiles
LOCAL ARRA aFiles[1]
*!*=========================================
cChar = RIGH(cDir,1)
IF !DIRE(cDir)
	RETU .F.
ENDI
IF !BETW(ASC(cChar),1,255)
	RETU .F.
ENDI
IF  cChar#'\'
	cDir=cDir+'\'
ENDI
IF !(VART(cMask)='C' AND !EMPT(cMask))
	cMask='*.*'
ENDI
iFiles   = ADIR(aFiles,cDir+'*.*','D')
FOR iCnt = 3 TO iFiles
	IF  RIGH(aFiles[iCnt,5],1)='D'
		fsDir_(cFind,cDir+aFiles[iCnt,1],cMask)
	ENDI	
ENDF
FindString(cFind,cDir,cMask,.T.)
*/*//////////////////////////////////////////////////////////////////////////////////////
*/*//////////////////////////////////////////////////////////////////////////////////////
PROC  fsError
LPAR  tcObject,tnLinia,tnNrBledu 
cRozkaz = STRT(MESS(1),CHR(9),' ')
cOpis   = MESS()
cParam  = LOWE(SYS(2018))
cWA     = ALIA() + '$WA' + ALLT(STR(SELE(0))) + '$DS' + ALLT(STR(SET('DATAS'))) + '$RN' + ALLT(STR(RECN()))
cNapis  = ""
cNapis     = cNapis+' Procedura'   +   CHR(9)+': '+tcObject +CR_LF
cNapis     = cNapis+' Rozkaz'  +CHR(9)+CHR(9)+': '+cRozkaz  +CR_LF
cNapis     = cNapis+' Opis'    +CHR(9)+CHR(9)+': '+cOpis    +CR_LF
cNapis	   = cNapis+' Parametr '      +CHR(9)+': '+cParam   +CR_LF
cNapis     = cNapis+' Numer b³êdu '   +CHR(9)+': '+ALLT(STR(tnNrBledu))+CR_LF
cNapis     = cNapis+' Linia'   +CHR(9)+CHR(9)+': '+ALLT(STR(tnLinia))+CR_LF
cNapis     = cNapis+' Obszar roboczy'+CHR(9)+': '+cWA
MessageBox(cNapis)
*!* @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
*!* @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
PROC  FindString
LPAR  cFind,cKat,cMask,lLeave
LOCAL iPliki,iCnt,cPlik,iExpr,iMLine,iMLines,cExpr,lFound,cLinia,cKlasa,iPos,cTemp,nIle,cDir,cRazem,lFindDollar
LOCAL cProc,lRaport,gnError,iLen,lFull,cPrzed,cPo
LOCAL ARRA aPliki[1],aExpr[1],aRows[1]
iPliki  = ADIR(aPliki,AddB(cKat)+cMask)
gnError = 0
IF  PCOU() < 6
	iFlagi = 0
ENDI	
SELE 0
IF !USED( 'qFind') 
	CREA CURS qFind(Plik C(50),Napis C(250),Linia I,Rek I,Content M,Sciezka C(80))
ELSE	
	IF !lLeave
		USE IN qFind
		CREA CURS qFind(Plik C(50),Napis C(250),Linia I,Rek I,Content M,Sciezka C(80))
	ENDI
ENDI
cDir = AddB(cKat) && AddB(IIF(cKat#'C:\',SYS(5)+CURD(),'')+cKat)
SELE 0
*
*lFindDollar = .T.		&& odkomentuj ten wiersz, ¿eby móc znaleœæ napisy zawieraj¹ce znak $
lFull = .T.			&& odkomentuj ten wiersz, ¿eby móc znaleœæ ca³e wyrazy
IF !lLeave AND (lFindDollar OR lFull)
	MsgBox('Opcje niestandardowe','I','Findstring')
ENDI
ON ERRO DO fsError WITH SYS(16),LINE(1),ERRO()
IF  lFindDollar
	nIle = 1
	DIME aExpr[1]
	aExpr[1] = cFind
ELSE	
	IF  RIGH(cFind,1)#'$'
		cFind=cFind+'$'
	ENDI
	nIle = OCCU('$',cFind)
	DIME aExpr[nIle]
	FOR iCnt = 1 TO nIle
		iPos = AT('$',cFind)
		IF  iPos = 0
			EXIT
		ENDI
		cTemp  = LEFT(cFind,iPos-1)
		cFind  = SUBS(cFind,iPos+1)
		aExpr[iCnt] = cTemp
	ENDF
ENDI	
*
FOR iCnt = 1 TO iPliki
	cPlik   = cDir+aPliki[iCnt,1]
	lReport = IIF(INLI(RIGH(cPlik,4),'.FRX','.LBX'),.T.,.F.)
	cKlasa  = ''
	cRazem  = ''
	WAIT WIND cPlik NOWA
	IF  RIGH(cPlik,1)#'X' OR LEN(JustExt(cPlik))#3
		iMLines = ALIN(aRows,FileToStr(cPlik))
		FOR iMLine = 1 TO iMLines
			cLinia = aRows[iMLine]
			lFound = .T.
		 	IF  ATC('PROC ',cLinia)#0 OR ATC('FUNC ',cLinia)#0 OR ATC('PROCEDURE',cLinia)#0 OR ATC('FUNCTION',cLinia)#0
		 		cKlasa = cLinia
		 	ENDI
			FOR iExpr = 1 TO ALEN(aExpr,1)
			 	cExpr = aExpr[iExpr]
				iLen  = LEN(cExpr)
				iPos  = ATC(cExpr,cLinia)
			 	IF  iPos = 0
			 	 	lFound = .F.
			 	 	EXIT
				ELSE
					IF  lFull
						cPrzed = SUBS(cLinia,iPos-1   ,1)
						cPo    = SUBS(cLinia,iPos+iLen,1)
						IF  isAlpha(cPrzed) OR isDigit(cPrzed) OR isAlpha(cPo) OR isDigit(cPo)
							lFound = .F.
							EXIT
						ENDI
					ENDI
			 	ENDI
			ENDF
			IF  lFound
				INSE INTO qFind VALU (JustFName(cPlik),ALLT(cLinia),iMLine,0,cRazem,cKat)
			ENDI
		ENDF
	ELSE
		cProc = ''
*		USE (cPlik) SHAR AGAI ALIA Temp
		IF '!'$cPlik
			LOOP
		ENDI
 		USE (cPlik) EXCL ALIA Temp
		IF  gnError # 0
			gnError = 0
			LOOP
		ENDI
		IF  isField('Methods')
			SCAN ALL
				 IF  lReport
					 iMLines = ALIN(aRows,Expr)
					 cRazem  = Expr
				 ELSE
				 	 IF  lPP
						 iMLines = ALIN(aRows,Properties)
		 				 cRazem  = Properties
		 			 ELSE	 
						 iMLines = ALIN(aRows,Methods)
						 cRazem  = Methods
					 ENDI	 
				 ENDI	 
				 FOR iMLine = 1 TO iMLines
					 cLinia = aRows[iMLine]
					 lFound = .T.
				 	 IF  ATC('PROCEDURE',cLinia)#0 
				 		 cProc = cLinia
				 	 ENDI
					 FOR iExpr = 1 TO ALEN(aExpr,1)
					 	 cExpr = aExpr[iExpr]
					 	 IF  ATC(cExpr,cLinia)=0
					 	 	 lFound = .F.
					 	 	 EXIT
					 	 ENDI
					 ENDF
					 IF  lFound
						 cKlasa = IIF(lReport,'',Class+' - '+Parent+'.'+ObjName)
						 INSE INTO qFind VALU (JustFName(cPlik),cLinia,iMLine,RECN('Temp'),cRazem,cKat)
						 cRazem = ''
					 ENDI
				 ENDF
			ENDS	 
		ENDI
		USE
	ENDI	
ENDF
SELE qFind
ON ERROR
WAIT CLEA
