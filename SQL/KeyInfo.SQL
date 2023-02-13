USE [coliber_wzorzec_multilang]
GO

/****** Object:  Table [dbo].[KeyInfo]    Script Date: 2019-09-23 14:25:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[KeyInfo](
	[Id] [uniqueidentifier] NOT NULL CONSTRAINT [DF_KeyInfo_Id]  DEFAULT (newsequentialid()),
	[Stat] [int] NOT NULL,
	[Name] [nchar](500) NULL,
	[SID] [varchar](36) NULL,
	[Key1] [varchar](max) NULL,
	[Key2] [varchar](max) NULL,
	[PID] [int] NULL,
	[D2] [datetime] NULL,
	[Key3] [varchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


USE [coliber_wzorzec_multilang]
GO
/****** Object:  StoredProcedure [dbo].[spKeyInfo]    Script Date: 2019-09-23 14:23:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[spKeyInfo]
AS
BEGIN 

DECLARE @Domain NVARCHAR(100)
DECLARE @MAC NVARCHAR(100)
DECLARE @Machine NVARCHAR(100)
DECLARE @Server NVARCHAR(100)
declare @nIle Integer

/*
declare @t table
(
i uniqueidentifier default newsequentialid(),
m as cast(i as char(36))
)

insert into @t default values;

select @MAC = 
    substring(m,25,2) + '-' + 
    substring(m,27,2) + '-' + 
    substring(m,29,2) + '-' +
    substring(m,31,2) + '-' +
    substring(m,33,2) + '-' +
    substring(m,35,2) 
FROM @t
*/


select @nIle = COUNT(*) from KeyInfo where KeyInfo.Stat <> 6

if (@nIle = 0)
begin
	insert into KeyInfo (Stat,PID) values (0,0)
end

select @MAC = (select CAST(Id as CHAR(36)) from KeyInfo where Stat <> 6)
    select @MAC = 
        substring(@MAC,25,2) + '-' + 
        substring(@MAC,27,2) + '-' + 
        substring(@MAC,29,2) + '-' +
        substring(@MAC,31,2) + '-' +
        substring(@MAC,33,2) + '-' +
        substring(@MAC,35,2)

--EXEC master.dbo.xp_instance_regread 'HKEY_LOCAL_MACHINE', 'SYSTEM\CurrentControlSet\services\Tcpip\Parameters', N'Domain',@Domain OUTPUT
SET @Domain = (SELECT DEFAULT_DOMAIN())
SET @Machine = CAST(SERVERPROPERTY(N'MachineName') as nvarchar)
SET @Server = CAST(@@SERVERNAME as nvarchar)


select @Domain AS Domain,@MAC as MAC,@Server AS Server,@Machine AS Machine

END


