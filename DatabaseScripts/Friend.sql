USE [GameShare]
GO
CREATE TABLE [Friend](
	[Id] [int] IDENTITY(1,1) PRimary key NOT NULL,
	[Name] [varchar](30) NOT NULL,
	[Email] [varchar](100) NULL,
	)
