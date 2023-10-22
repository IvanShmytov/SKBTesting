USE [SKBDataBase]
GO

/****** Object:  Table [dbo].[Items]    Script Date: 21.10.2023 21:55:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Items](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [varchar](20) NOT NULL,
	[Priority] [int] NOT NULL,
	[Description] [varchar](50) NULL,
	[Status] [varchar](15) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Items]  WITH CHECK ADD CHECK  (([Priority]>(0)))
GO

ALTER TABLE [dbo].[Items]  WITH CHECK ADD CHECK  (([Status]='Almost done' OR [Status]='In progress' OR [Status]='Done'))
GO

--insert into dbo.Items (Id, Name, Priority, Description, Status) values('19185074-a465-4523-8292-5793ac51e6d8', 'One', 9, 'Some task for today', 'In progress')
--insert into dbo.Items (Id, Name, Priority, Description, Status) values('29185074-a465-4523-8292-5793ac51e6d8', 'Two', 2, 'Another one task for today', 'Done')
--insert into dbo.Items (Id, Name, Priority, Description, Status) values('39185074-a465-4523-8292-5793ac51e6d8', 'Three', 7, 'Final task for today', 'Almost done')