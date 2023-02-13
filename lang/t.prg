PRIV  cPath,cForm,ArrLang,cFunc,cDir
cPath ="C:\Program\Exell\Net\Lang\"
DIME ArrLang[5]
ArrLang[1] = "DE"
ArrLang[2] = "EN"
ArrLang[3] = "ES"
ArrLang[4] = "FR"
ArrLang[5] = "PL"


CLOS TABL ALL

cDir  = 'Ksiazki'

cForm = 'EditMARCForm'

*cFunc = "ContentFormComboboxValues.Add("
*cFunc = "ToolTip.SetToolTip("
*cFunc = ".HeaderText ="
*cFunc = "WykrComboBoxValues.Add("
*cFunc = "Dictionary.Add("
cFunc = ".HeaderText ="
cFunc = "ToolStripMenuItem.Text ="
cFunc = "(NewConnection,"
cFunc = ".Text ="
cFunc = "MessageBox.Show("

*UpdateLMaster(1)
*FindPol()
*UpdateKeys()
*CreateResx(0)
*TransformStr()

*UpdateLMaster()
*FindPol()
*UpdateKeys()
*CreateResx(0)
*getControlsText()


*DataToTable("","")
*KMasterWebUpdate()


*KMaster_()
*TrimM()
CreateResx(1)

PROC  TransformStr
LPAR  lClipText
LOCAL cSrc,cOld,cNew,iPos,iCnt,cBak
LOCAL ARRA aSrc[1]
SELE 0
CREA CURS qZmiana (Old C(250),New C(250),Pos I)
cFunc = LOWE(cFunc)
cPlik = "C:\Program\Exell\NET\" + cDir + "\" + cForm
cSrc = FileToStr(cPlik)
ALIN(aSrc,cSrc,.F., CHR(10))
FOR iCnt = 1 TO ALEN(aSrc)
	aSrc[iCnt] = STRT(aSrc[iCnt],CHR(13))
	IF  LEN(aSrc[iCnt]) > 250
		MessageBox(STR(iCnt))
	ELSE
		INSE INTO qZmiana VALU (aSrc[iCnt],'',-iCnt)
	ENDI
ENDF
IF  lClipText
	cSrc = ""
ENDI
*
SELE 0
USE  LMaster
SCAN FOR Type = cForm AND EMPT(Object)
	 cOld = StrConv(STRT(RTRI(FName),'__TXT__','"'+ALLT(Pol)+'"'),9,1045)
	 IF  lClipText
		 cNew = STRT(RTRI(FName),'__TXT__','_T("'+ALLT(KeyName)+'")')
		 cSrc = cSrc + CHR(13) + CHR(10) + cNew
	 ELSE	
		 cNew = StrConv(STRT(RTRI(FName),'__TXT__','_T("'+ALLT(KeyName)+'")'),9,1045)
	 ENDI
	 if  lowe('i zosta')$lowe(cOld)
*		 set Step On 
	 endi	
	 iPos = ASCA(aSrc,cOld)
	 IF  iPos # 0
		 aSrc[iPos] = cNew
	 ENDI	
	 INSE INTO qZmiana VALU (cOld,cNew,iPos)
ENDS
USE
SELE qZmiana
BROW LAST

IF  lClipText
   _cliptext = cSrc
	RETU
ENDI

cSrc = ArrayToStr(@aSrc,CHR(13)+CHR(10))
cBak = STRT(cPlik,'\'+cDir+'\','\BAK\')
IF  MessageBox('ZamieniÊ plik ürÛd≥owy ?',1+32+256) = 1
	COPY File (cPlik) TO (cBak)
	StrToFile(cSrc,cPlik)
ENDI

PROC  TransformSrc

MessageBox('n')
retu

LOCAL cSrc,cOld,cNew,iPos,iCnt,cBak
LOCAL ARRA aSrc[1]
SELE 0
CREA CURS qZmiana (Old C(100),New C(100),Pos I)
cFunc = LOWE(cFunc)
cPlik = "C:\Program\Exell\NET\Ksiazki\" + cForm
cSrc = FileToStr(cPlik)
ALIN(aSrc,cSrc,.F., CHR(10))
FOR iCnt = 1 TO ALEN(aSrc)
	aSrc[iCnt] = STRT(aSrc[iCnt],CHR(13))
	INSE INTO qZmiana VALU (aSrc[iCnt],'',-1)
ENDF
SELE 0
USE  LMaster
SCAN FOR Form = cForm AND Eksport
	 IF !cFunc$LOWE(FName)
		 LOOP	
	 ENDI	
	 cOld = RTRI(FName)+ALLT(Object)+', "'+ALLT(StrConv(Pol,9,1045))+'");'
	 cNew = RTRI(FName)+ALLT(Object)+', _T("'+ALLT(KeyName)+'"));'
	 iPos = ASCA(aSrc,cOld)
	 IF  iPos # 0
		 aSrc[iPos] = cNew
	 ENDI	
	 INSE INTO qZmiana VALU (cOld,cNew,iPos)
ENDS
USE
SELE qZmiana
BROW LAST
cSrc = ArrayToStr(@aSrc,CHR(13)+CHR(10))
cBak = STRT(cPlik,'\NET\','\BAK\')
COPY File (cPlik) TO (cBak)
StrToFile(cSrc,cPlik)

PROC  UpdateLMaster
LPAR  iOcc
LOCAL cPlik,cObj,cSrc,cLin,iPos,iLen,iComa,cObj,cPol,i_AT,iRAT,cPFix,lSrc
LOCAL ARRA aSrc[1]
IF  PCOU() > 0
	lSrc  = .T.
	iOcc  = iOcc - 1
	cFunc = LOWE(cFunc)
	SELE 0
	CREA CURS Data (Object C(50),Pol C(250),FName C(150),Type C(50),Linia C(250))
	cPlik = "C:\Program\Exell\NET\" + cDir + "\" + cForm
	cSrc  = FileToStr(cPlik)
	cSrc  = StrConv(cSrc,11,1045)
	ALIN(aSrc,cSrc,.F., CHR(10))
	iLen = LEN(cFunc)
	FOR iCnt = 1 TO ALEN(aSrc)
		cLin = aSrc[iCnt]
		cLin = STRT(cLin,CHR(13))
		iPos = AT(cFunc,LOWE(cLin))
		IF  iPos # 0 AND !'datagridview'$LOWE(cLin) &&AND !'_T('$cLin
			iAT1 = AT('"',cLin,1+(iOcc*2))
			iAT2 = AT('"',cLin,2+(iOcc*2))
*			cPol = SUBS(cLin,iAT1+1,iAT2-iAT1-1)
			cPol = SUBS(cLin,iAT1,iAT2-iAT1+1)
			cLin = STRT(cLin,cPol,"__TXT__")
			cPol = STRT(cPol,'"')
			cPFix = SUBS(cLin,iAT1-3,3)
			IF  iAT1 = 0 OR cPFix = '_T('
				LOOP
			ENDI			
			INSE INTO Data VALU (cPFix,ALLT(cPol),"",cForm,cLin)
		ENDI
	ENDF
ELSE
	cPlik = cPath + "1" + cForm + ".XML"
	XMLtoCursor(cPlik, "Data" ,512)
ENDI
*!*	sele data
*!*	brow last
*!*	retu
SELE 0
USE LMaster
SELE Data
SCAN ALL
	 IF  lSrc AND EMPT(Object)
		 LOOP
	 ENDI
	 IF  EMPT(Pol)
		 LOOP
	 ENDI
	 cObj = LEFT(Object,25)
	 SELE LMaster
	 IF  lSrc 
		 INSE INTO LMaster (Pol,Form,Eksport,Type,FName) VALU (ALLT(Data.Pol),cForm,.T.,Data.Type,Data.Linia)
	 ELSE
		 LOCA FOR Object = cObj AND Form = cForm
		 IF !FOUN()
			 *MessageBox(cObj+CHR(13)+Data.Pol)
			 INSE INTO LMaster (Object,Pol,Form,Eksport,Type,FName) VALU (cObj,ALLT(Data.Pol),cForm,.T.,Data.Type,Data.FName)
		 ENDI
	 ENDI
	 SELE Data	
ENDS
USE
SELE LMaster
SET Order To
BROW LAST

PROC  FindPol
LOCAL cPol

*set Step On 

USE KMaster
SELE 0
USE LMaster
SCAN FOR Form = cForm AND Eksport
	 IF !EMPT(KeyName)
		 LOOP
	 ENDI	
	 cPol = ClearLine(Pol,'S')
	 cPol = STRT(cPol,':')
	 SELE KMaster
	 LOCA FOR PLT = cPol + '  '
	 IF  FOUN()	
		 REPL KeyName WITH KMaster.KeyName,KeyValue WITH KMaster.PLT IN LMaster
	 ENDI
	 SELE LMaster
ENDS
BROW LAST

PROC  UpdateKeys
LOCAL cVal,cNapis
USE KMaster
SELE 0
USE LMaster
SCAN FOR Form = cForm AND Eksport
	 cVal = STRT(ClearLine(Pol,'S'),':')
	 *cVal = Pol
	 SELE KMaster
	 LOCA FOR KeyName = LMaster.KeyName
	 IF  FOUN()
		 IF  PLT # cVal
			 cNapis = 'Klucz:' + CHR(9) + LMaster.KeyName + CHR(13) + 'New:' + CHR(9) + ALLT(LMaster.Pol) + CHR(13) + 'Old:' + CHR(9) + ALLT(KMaster.PLT)
			 MessageBox(cNapis)

*	set Step On 

		 ENDI
	 ELSE
		 INSE INTO KMaster (KeyName,PLT,PLM,PLL) VALU (ALLT(LMaster.KeyName),ALLT(LMaster.Pol),ALLT(LMaster.Pol),.T.)
	 ENDI
ENDS
SELE KMaster
UpdateEmpty()
brow last

PROC  UpdateEmpty
SCAN ALL
	 cKey = ALLT(STRT(STRT(KeyName,'-',' '),'_',' '))
	
	 cVal = "p " + cKey
	 IF  EMPT(PLT)	
		 REPL PLT WITH cVal
	 ENDI	
	 IF  EMPT(PLM)	
		 REPL PLM WITH cVal
	 ENDI	
	 cVal = "f " + cKey
	 IF  EMPT(FRT)	
		 REPL FRT WITH cVal
	 ENDI	
	 IF  EMPT(FRM)	
		 REPL FRM WITH cVal
	 ENDI	
	 cVal = "s " + cKey
	 IF  EMPT(EST)	
		 REPL EST WITH cVal
	 ENDI	
	 IF  EMPT(ESM)	
		 REPL ESM WITH cVal
	 ENDI	
	 cVal = "e " + cKey
	 IF  EMPT(ENT)	
		 REPL ENT WITH cVal
	 ENDI	
	 IF  EMPT(ENM)	
		 REPL ENM WITH cVal
	 ENDI	
	 cVal = "d " + cKey
	 IF  EMPT(DET)	
		 REPL DET WITH cVal
	 ENDI	
	 IF  EMPT(DEM)	
		 REPL DEM WITH cVal
	 ENDI	

*!*		 cVal = "DE: " + cKey
*!*		 IF  ALLT(DET) == cVal
*!*			 cVal = STRT(cVal,'DE: ','d ')	
*!*			 REPL DET WITH cVal
*!*		 ENDI	
*!*		 cVal = "EN: "  + cKey
*!*		 IF  ALLT(ENT) == cVal
*!*			 cVal = STRT(cVal,'EN: ','e ')	
*!*			 REPL ENT WITH cVal
*!*		 ENDI	
*!*		 cVal = "ES: "  + cKey
*!*		 IF  ALLT(EST) == cVal
*!*			 cVal = STRT(cVal,'ES: ','s ')	
*!*			 REPL EST WITH cVal
*!*		 ENDI	
*!*		 cVal = "FR: "  + cKey
*!*		 IF  ALLT(FRT) == cVal
*!*			 cVal = STRT(cVal,'FR: ','f ')	
*!*			 REPL FRT WITH cVal
*!*		 ENDI	
*!*		 cVal = "PL: "  + cKey
*!*		 IF  ALLT(PLT) == cVal
*!*			 cVal = STRT(cVal,'PL: ','p ')	
*!*			 REPL PLT WITH cVal
*!*		 ENDI	

ENDS

PROC  CreateResx
LPAR  iWeb
LOCAL cPlik,cHead,cXML,iCnt,iPos,cKult,cLang,cZ,cDo
cPlik = cPath + "Head.TXT"
cHead = FileToStr(cPlik)
cXML  = ""
IF  PCOU() = 0
	iWeb = 0
ENDI
FOR iCnt = 1 TO ALEN(ArrLang)
	cLang = ArrLang[iCnt]
	cPole = cLang +'M'
	cPlik = cPath + ArrLang[iCnt] + 'Data.XML'
*	SELE KeyName,&cPole. AS KeyValue FROM KMaster INTO CURS Data
	WAIT WIND cPole NOWA
	DO CASE
	CASE cLang = 'DE'
		 SELE KeyName,DEM AS KeyValue FROM KMaster WHER BITT(Web,iWeb) INTO CURS Data
	CASE cLang = 'EN'
		 SELE KeyName,ENM AS KeyValue FROM KMaster WHER BITT(Web,iWeb) INTO CURS Data
	CASE cLang = 'ES'
		 SELE KeyName,ESM AS KeyValue FROM KMaster WHER BITT(Web,iWeb) INTO CURS Data
	CASE cLang = 'FR'
		 SELE KeyName,FRM AS KeyValue FROM KMaster WHER BITT(Web,iWeb) INTO CURS Data
	CASE cLang = 'PL'
		 SELE KeyName,PLM AS KeyValue FROM KMaster WHER BITT(Web,iWeb) INTO CURS Data
	ENDC
*	brow last
	CURSORTOXML("Data","cXML",1,16)
	cXML = STRT(cXML,[<data>]+CHR(13)+CHR(10)+CHR(9)+CHR(9)+[<keyname>],[<data name="])
	cXML = STRT(cXML,[</keyname>],[" xml:space="preserve">])
	cXML = STRT(cXML,[keyvalue],[value])
	cXML = STRT(cXML,CHR(9),'  ')
	iPos = AT([<data name="],cXML)
	cXML = SUBS(cXML,iPos-1)
	cXML = STRT(cXML,'</VFPData>')
	cXML = cHead + CHR(13) + CHR(10) + CHR(32) + cXML + "</root>"
	cKult = IIF(cLang = 'EN','US',cLang)
	cPlik = cPath + IIF(iWeb = 1,"language.","lang.") + LOWE(cLang) + "-" + UPPE(cKult) + ".resx"
	StrToFile(StrConv(cXML,9),cPlik)
*	MODI FILE (cPlik)
ENDF
IF  iWeb = 1
	RETU
ENDI
cZ  =  cPath + "lang.*.resx"
cDo = "C:\Program\Bin\Coliber\Debug\lang"
COPY File (cZ) TO (cDo)
cDo = "C:\Program\Bin\Coliber\Release\lang"
COPY File (cZ) TO (cDo)
WAIT CLEA
SELE KMaster

PROC  getControlsText
LOCAL cNapis
cNapis = "        private void setControlsText()" + CHR(13) + "        {" + CHR(13) + "            var mapping = new Dictionary<Object, string>();"
USE LMaster
SCAN FOR Form = cForm AND Eksport
	 cNapis = cNapis + [mapping.Add(] + ALLT(Object) + [,"] + ALLT(KeyName) + [");] + CHR(13)
ENDS
USE
cNapis = cNapis + "            _translationsDictionary = CommonFunctions.GetAndLoadTranslations(mapping, Thread.CurrentThread.CurrentUICulture.Name) ?? new Dictionary<string, string>();" + CHR(13) + "        }"
_CLIPTEXT = cNapis

PROC  TrimM
LOCAL cVal1,cVal2,nIle
nIle = 0
USE KMaster
SCAN ALL
	 cVal1 = DEM
	 cVal2 = ALLT(DEM)
	 IF !cVal1 == cVal2
		 REPL DEM WITH cVal2
		 nIle = nIle + 1
	 ENDI 	
	 cVal1 = ENM
	 cVal2 = ALLT(ENM)
	 IF !cVal1 == cVal2
		 REPL ENM WITH cVal2
		 nIle = nIle + 1
	 ENDI 	
	 cVal1 = ESM
	 cVal2 = ALLT(ESM)
	 IF !cVal1 == cVal2
		 REPL ESM WITH cVal2
		 nIle = nIle + 1
	 ENDI 	
	 cVal1 = FRM
	 cVal2 = ALLT(FRM)
	 IF !cVal1 == cVal2
		 REPL FRM WITH cVal2
		 nIle = nIle + 1
	 ENDI 	
	 cVal1 = PLM
	 cVal2 = ALLT(PLM)
	 IF !cVal1 == cVal2
		 REPL PLM WITH cVal2
		 nIle = nIle + 1
	 ENDI 	
ENDS
MessageBox(STR(nIle))

PROC  KMaster_
LOCAL cFile,iCnt,cKey,cPoleT,cPoleM,cPoleL
cFile = cPath + "KMaster.DBF"
SELE 0
IF  FILE(cFile)
	USE (cFile)	ORDE KeyName
ELSE
	CREA TABL (cFile) (KeyName C(60),PLT C(100),FRT C(100),EST C(100),ENT C(100),DET C(100),PLM M,FRM M,ESM M,ENM M,DEM M,PLL L,FRL L,ESL L,ENL L,DEL L)
	INDE ON KeyName TAG KeyName
ENDI
SELE 0
FOR iCnt = 1 TO ALEN(ArrLang)
	cFile = cPath + ArrLang[iCnt] + "Data.DBF"
	WAIT WIND cFile NOWA	
	USE (cFile) ALIA Imp
	cPoleT = ArrLang[iCnt] + 'T'
	cPoleM = ArrLang[iCnt] + 'M'
	cPoleL = ArrLang[iCnt] + 'L'
	SCAN ALL
		 cKey = KeyName
*!*			 IF  LOWE(ALLT(cKey)) == 'signatures'	AND ArrLang[iCnt] = 'ES'
*!*				 SET Step On 
*!*			 ENDI
		 SELE KMaster
		 LOCA FOR KeyName = cKey
		 IF  FOUN()	&&SEEK(cKey,'KMaster')
			 REPL (cPoleT) WITH Imp.Tekst,(cPoleM) WITH Imp.KeyValue,(cPoleL) WITH .T. IN KMaster
		 ELSE
			 INSE INTO KMaster (KeyName,(cPoleT),(cPoleT),(cPoleL)) VALU (Imp.KeyName,Imp.Tekst,Imp.KeyValue,.T.)
		 ENDI
		 SELE Imp	
	ENDS
	USE
ENDF
SELE KMaster
WAIT CLEA
BROW LAST

PROC  KMasterWebUpdate
LOCAL cFile,iCnt,cKey,cPoleT,cPoleM,cPoleL
cFile = cPath + "KMaster.DBF"
SELE 0
USE (cFile)	ORDE KeyName
SELE 0
cFile = cPath + "WebLang.DBF"
	WAIT WIND cFile NOWA	
	USE (cFile) ALIA Imp
	SCAN ALL
		 cKey = KeyName
		 SELE KMaster
		 LOCA FOR KeyName = cKey
		 IF  FOUN()	&&SEEK(cKey,'KMaster')
*			 repl web with bitt(web,1) in kmaster			
			 repl web with 3 in kmaster			
*			 REPL PLT WITH Imp.KayValue,PLM WITH Imp.KeyValue
			 IF  ALLT(kmaster.plt) # allt(imp.keyvalue)
				 brow last titl allt(imp.keyvalue)
			 endi
		 ELSE
			 INSE INTO KMaster (KeyName,PLT,PLM,web) VALU (Imp.KeyName,Imp.KeyValue,Imp.KeyValue,2)
		 ENDI
		 SELE Imp	
	ENDS
	USE
SELE KMaster
*!*	set Order To 
*!*	set Filter To webl
*!*	WAIT CLEA
*!*	BROW LAST
set Filter To 
scan for web > 0
	 u()
ends
use
CreateResx(1)

PROC  DataToTable
LPAR  cLang,cKult
LOCAL cFile,cXML,iPos
IF  PCOU()=1
	cKult = cLang
ENDI
cFile = cPath + "lang." + LOWE(cLang) + "-" + UPPE(cKult) + ".resx"
cFile = cPath + "language.resx"
*MODI FILE (cFile)

*set Step On 

cXML = FileToStr(cFile)
iPos = AT('<data name="app_name" xml:space="preserve">',cXML)
*cXML = SUBS(cXML,iPos-1)
cXML = STRT(cXML,'</root>')
cXML = STRT(cXML,[<data name="],[<data>]+CHR(13)+CHR(10)+SPAC(4)+[<keyname>])
cXML = STRT(cXML,[" xml:space="preserve">],[</keyname>])
cXML = STRT(cXML,[value>],[keyvalue>])
cXML = [<?xml version="1.0" encoding="UTF-8" standalone="yes"?>]+CHR(13)+CHR(10)+[<DocumentElement>] + cXML + ;
	    CHR(13)+CHR(10)+[</DocumentElement>]
cFile = cPath + cLang + "Data.XML"
StrToFile(cXML,cFile)
MODI FILE (cFile)
XMLToCursor(cFile, "Data", 512+48)
SELE 0
cFile = STRT(cFile,".XML",".DBF")
USE (cFile)
ZAP
APPE FROM DBF("Data")
REPL Tekst WITH KeyValue ALL
Brow last

retu

retu

* Read the XML file into a memory variable
lcXML = FILETOSTR("C:\Program\Exell\Net\Lang\DetailsForm.XML")

loXML = CREATEOBJECT("XMLAdapter")
    
* Convert XML to one or more cursor
WITH loXML
  .LoadXML(lcXML)
  FOR lnI = 1 TO .Tables.Count
    lcCursorName = "SomeCursor" + TRANSFORM(lnI)
    USE IN SELECT(lcCursorName)
    .Tables(lnI).ToCursor(.F., lcCursorName)
  ENDFOR
ENDWITH 

return

* Define and create a schema cache object
LOCAL loXMLSchema as "MSXML2.XMLSchemaCache.4.0"
loXMLSchema = CREATEOBJECT("MSXML2.XMLSchemaCache.4.0")
loXMLSchema.add("", "CDS1.XSD")

* en-us: Define e cria um objeto DOMDocument
LOCAL loXML as "MSXML2.DOMDocument.4.0"
loXML = CREATEOBJECT("MSXML2.DOMDocument.4.0")

* en-us: Assign the schema cache to the DOM Document
loXML.schemas = loXMLSchema

* en-us: Load the XML document
loXML.async = .F.
loXML.load("CDS1.XML")

* en-us: Verify whether the document was sucefully loaded.
IF loXML.parseError.errorCode = 0
  MESSAGEBOX("XML Documento loaded sucefully!")
ELSE
  lcErrorMsg = "The document could not be loaded because it does not conform to its schema" + CHR(13)
  lcErrorMsg = lcErrorMsg + "Line: " + TRANSFORM(loXML.parseError.line)
  lcErrorMsg = lcErrorMsg + "Char in line: " + TRANSFORM(loXML.parseError.linepos)
  lcErrorMsg = lcErrorMsg + "Cause of error: " + TRANSFORM(loXML.parseError.reason)
  MESSAGEBOX(lcErrorMsg)
ENDIF

FUNC  ClearLine
LPAR  cDirty,cType,cRepl,cDobry
LOCAL cClear,cZnak,iASC,cZlyZnak,iPos,iCnt,iLen
STOR '' TO cClear,cZnak
*!*===========================================================================
IF  PCOU()=1
	cType='S'
ENDI
IF  cType='P'
	cDobry   ='ACELNOSZZacelnoszz'
	cZlyZnak = IIF(cType='P852','§è®ù„‡óΩç•Ü©à‰¢òæ´','•∆ £—”åØèπÊÍ≥ÒÛúøü')
ENDI
IF  cType  ='A1'
	cDobry = IIF(VART(cDobry)='C',cDobry,'_')
ENDI
IF  VART(cRepl)#'C'
	cRepl = ' '
ENDI
cDirty = ALLT(cDirty)
iLen   = LEN(cDirty)
FOR iCnt  = 1 TO iLen
	cZnak = SUBS(cDirty,iCnt,1)
	iASC  = ASC(cZnak)
	DO CASE
	CASE cType='S'
		 IF  ASC(cZnak)<32
			 cZnak=cRepl
		 ENDI	
	CASE INLI(cType,'C','M')
		 IF  ASC(cZnak)<39
			 cZnak=cRepl
		 ENDI	
	CASE cType = 'A1'		&& Alfanumeric + cDobry
		 IF !BETW(iASC,48,57) AND !BETW(iASC,65,90) AND !BETW(iASC,97,122) AND !cZnak$cDobry
			 cZnak = cRepl
		 ENDI
	CASE cType = 'A'		&& Alfanumeric
		 IF !BETW(iASC,48,57) AND !BETW(iASC,65,90) AND !BETW(iASC,97,122)
			 cZnak = cRepl
		 ENDI
	CASE cType = 'X'		&& tylko litery
		 IF !BETW(iASC,65,90) AND !BETW(iASC,97,122)
			 cZnak = cRepl
		 ENDI
	CASE INLI(cType,'D','T')
		 IF  iCnt>10
			 EXIT
		 ENDI
		 IF !BETW(ASC(cZnak),46,57) OR ASC(cZnak)=47
			 cZnak=''
		 ENDI
	CASE cType='P'
		 iPos = AT(cZnak,cZlyZnak)
		 IF  iPos  = 0
			 IF  ASC(cZnak)<32
				 cZnak=cRepl
			 ENDI	
		 ELSE	 
		 	 cZnak = SUBS(cDobry,iPos,1)
		 ENDI
	CASE cType='L'
		 cZnak=cZnak	
	OTHE 			&& typy numeryczne
		 IF  iCnt>14
			 EXIT
		 ENDI
		 IF !BETW(ASC(cZnak),44,57) OR ASC(cZnak)=47
			 cZnak=''
		 ENDI			
	ENDC	
	cClear=cClear+cZnak
ENDF
RETU cClear

*/*//////////////////////////////////////////////////////////////////////////////////////
*/*//////////////////////////////////////////////////////////////////////////////////////
FUNC ArrayToStr
LPAR aArr,cZnak,iFlagi
EXTERNAL ARRAY aArr
LOCAL iCnt,cRet,iLen,lSkipFirst,lSkipLast
IF  VART(cZnak)#'C'
	cZnak = '$'
ENDI
IF  PCOU()<3
	iFlagi = 0
ENDI
lSkipFirst = BITT(iFlagi,0)
lSkipLast  = BITT(iFlagi,1)
cRet = IIF(lSkipFirst,'',cZnak)
iLen = ALEN(aArr,1)
FOR iCnt = 1 TO iLen
	IF  lSkipLast AND iCnt = iLen
		cZnak = ''
	ENDI
	cRet = cRet + aArr[iCnt] + cZnak
ENDF
RETURN cRet
