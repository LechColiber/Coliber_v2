CREATE NONCLUSTERED INDEX idx_sprawy_nrog ON dbo.sprawy
	(
	nrog
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
