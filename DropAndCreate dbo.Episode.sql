USE [IACAST_WEB.Data]
GO

/****** Object: Table [dbo].[Episode] Script Date: 11/2/2022 3:45:54 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[Episode];


GO
CREATE TABLE [dbo].[Episode] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [Name]      NVARCHAR (MAX) NULL,
    [Theme]     NVARCHAR (MAX) NULL,
    [Released]  DATETIME2 (7)  NULL,
    [Invitado]  NVARCHAR (MAX) NULL,
    [Anfitrion] NVARCHAR (MAX) NULL,
	[Youtube] NVARCHAR (MAX) NULL
);


