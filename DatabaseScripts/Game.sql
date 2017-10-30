USE [GameShare]
GO
CREATE TABLE [dbo].[Game](
	[Id] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[Title] [varchar](30) NOT NULL,
	[Style] [varchar](30) NULL,
	[Description] [varchar](500) NULL,
	[Image] [varbinary](max) NULL,
	[IsAvailable] [bit] NOT NULL,
	[FriendId] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[Game]  WITH CHECK ADD FOREIGN KEY([FriendId])
REFERENCES [dbo].[Friend] ([Id])
GO

