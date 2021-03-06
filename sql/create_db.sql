USE [master]
GO
/****** Object:  Database [GitNumberVersionLink]    Script Date: 15.10.2018 21:41:40 ******/
CREATE DATABASE [GitNumberVersionLink]
GO

USE [GitNumberVersionLink]
GO
/****** Object:  Table [dbo].[GitIdNumber]    Script Date: 15.10.2018 21:41:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GitIdNumber](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdProject] [int] NOT NULL,
	[GitId] [char](50) NOT NULL,
	[Number] [int] NOT NULL,
 CONSTRAINT [PK_GitRepoNumber] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Project]    Script Date: 15.10.2018 21:41:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Project](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nchar](255) NOT NULL,
 CONSTRAINT [PK_Project] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[GitIdNumber]  WITH CHECK ADD  CONSTRAINT [FK_GitIdNumber_Project] FOREIGN KEY([IdProject])
REFERENCES [dbo].[Project] ([Id])
GO
ALTER TABLE [dbo].[GitIdNumber] CHECK CONSTRAINT [FK_GitIdNumber_Project]
GO
USE [master]
GO
ALTER DATABASE [GitNumberVersionLink] SET  READ_WRITE 
GO
