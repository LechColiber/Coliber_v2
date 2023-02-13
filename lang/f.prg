LPAR  cKey
LOCAL cRun
IF  USED('LMaster')
	SELE  LMaster
ELSE
	SELE 0
	USE  LMaster
ENDI
IF  PCOU() = 0 OR EMPT(cKey)
	SET Filter To
ELSE
	cKey = LOWE(cKey)
	cRun = 'SET FILT TO "'+cKey+'"$LOWE(POL)'
	&cRun.
ENDI
LOCA
BROW LAST NOWA

retu

