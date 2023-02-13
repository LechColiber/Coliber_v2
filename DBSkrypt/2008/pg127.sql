CREATE TABLE imp_jedn (nr_oddz numeric(3) NOT NULL , nr_insp numeric(3) NOT NULL , nazwa char(100) NOT NULL , skrot char(50) NOT NULL , isdefault bit NOT NULL , seq_firstv numeric(12) NOT NULL , miejscow char(50) NOT NULL )
GO

CREATE TABLE [dbo].[spr_zapo](
	[spr_id] [int] NULL,
	[zapo_id] [int] NULL,
	[kolejnosc] [smallint] NULL
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[spr_dzial](
	[id] [int] NOT NULL,
	[spr_id] [int] NULL,
	[dz_id] [int] NULL,
	[data] [datetime] NULL,
 CONSTRAINT [spr_dzial_sl_dzialania_pkey] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE NONCLUSTERED INDEX [idx_spr_dzial_spr_id] ON [dbo].[spr_dzial] 
(
	[spr_id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [idx_spr_zapo_spr_id] ON [dbo].[spr_zapo] 
(
	[spr_id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
GO
