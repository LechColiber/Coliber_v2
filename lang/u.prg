LPAR iWeb
IF  PCOU() = 0
	iEwb = 1
ENDI

	 cKey = ALLT(STRT(STRT(KeyName,'-',' '),'_',' '))
	
	 cVal = "p " + cKey
	 IF  EMPT(PLT)	
		 REPL PLT WITH cVal
	 ENDI	
	 IF  EMPT(PLM)	
		 REPL PLM WITH ALLT(PLT)
	 ENDI	
	 cVal = "f " + cKey
	 IF  EMPT(FRT)	
		 REPL FRT WITH cVal
	 ENDI	
	 IF  EMPT(FRM)	
		 REPL FRM WITH ALLT(FRT)
	 ENDI	
	 cVal = "s " + cKey
	 IF  EMPT(EST)	
		 REPL EST WITH cVal
	 ENDI	
	 IF  EMPT(ESM)	
		 REPL ESM WITH ALLT(EST)
	 ENDI	
	 cVal = "e " + cKey
	 IF  EMPT(ENT)	
		 REPL ENT WITH cVal
	 ENDI	
	 IF  EMPT(ENM)	
		 REPL ENM WITH ALLT(ENT)
	 ENDI	
	 cVal = "d " + cKey
	 IF  EMPT(DET)	
		 REPL DET WITH cVal
	 ENDI	
	 IF  EMPT(DEM)	
		 REPL DEM WITH ALLT(DET)
	 ENDI	
	 REPL Web WITH iWeb