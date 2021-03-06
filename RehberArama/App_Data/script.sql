USE [master]
GO
/****** Object:  Database [RehberDB]    Script Date: 4.4.2018 23:10:22 ******/
CREATE DATABASE [RehberDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'RehberDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\RehberDB.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 5120KB )
 LOG ON 
( NAME = N'RehberDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\RehberDB_log.ldf' , SIZE = 816KB , MAXSIZE = 2048GB , FILEGROWTH = 5120KB )
GO
ALTER DATABASE [RehberDB] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [RehberDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [RehberDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [RehberDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [RehberDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [RehberDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [RehberDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [RehberDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [RehberDB] SET AUTO_SHRINK ON 
GO
ALTER DATABASE [RehberDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [RehberDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [RehberDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [RehberDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [RehberDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [RehberDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [RehberDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [RehberDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [RehberDB] SET AUTO_UPDATE_STATISTICS_ASYNC ON 
GO
ALTER DATABASE [RehberDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [RehberDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [RehberDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [RehberDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [RehberDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [RehberDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [RehberDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [RehberDB] SET  MULTI_USER 
GO
ALTER DATABASE [RehberDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [RehberDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [RehberDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [RehberDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [RehberDB] SET DELAYED_DURABILITY = DISABLED 
GO
USE [RehberDB]
GO
/****** Object:  User [RehberDB]    Script Date: 4.4.2018 23:10:23 ******/
CREATE USER [RehberDB] FOR LOGIN [RehberDB] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [RehberDB]
GO
ALTER ROLE [db_ddladmin] ADD MEMBER [RehberDB]
GO
ALTER ROLE [db_datareader] ADD MEMBER [RehberDB]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [RehberDB]
GO
/****** Object:  Table [dbo].[SearchModels]    Script Date: 4.4.2018 23:10:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SearchModels](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Ad] [nvarchar](50) NOT NULL,
	[Soyad] [nvarchar](50) NOT NULL,
	[Unite] [nvarchar](50) NOT NULL,
	[Fabrika] [nvarchar](50) NOT NULL,
	[Pozisyon] [nvarchar](50) NULL,
	[Is_Tel1] [nvarchar](20) NULL,
	[Is_Tel2] [nvarchar](20) NULL,
	[Kurumsal_Tel] [nvarchar](20) NULL,
	[Telsiz_No] [nvarchar](10) NULL,
	[Email] [nvarchar](100) NULL,
	[resimUrl] [nvarchar](300) NULL,
 CONSTRAINT [PK_dbo.SearchModels] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[SearchModels] ON 

INSERT [dbo].[SearchModels] ([ID], [Ad], [Soyad], [Unite], [Fabrika], [Pozisyon], [Is_Tel1], [Is_Tel2], [Kurumsal_Tel], [Telsiz_No], [Email], [resimUrl]) VALUES (1, N'Ahmet', N'Soyisim1', N'Monomer Müdürlüğü', N'VCM', N'Yönetici', N'123', N'123', N'124', N'124', N'email@a.com', N'/images/user-128.png')
INSERT [dbo].[SearchModels] ([ID], [Ad], [Soyad], [Unite], [Fabrika], [Pozisyon], [Is_Tel1], [Is_Tel2], [Kurumsal_Tel], [Telsiz_No], [Email], [resimUrl]) VALUES (2, N'Aydın', N'Soyisim2', N'Monomer Müdürlüğü', N'PP', N'Mühendis', N'456', N'456', N'456', N'456', N'email@a.com', N'/images/user-128.png')
INSERT [dbo].[SearchModels] ([ID], [Ad], [Soyad], [Unite], [Fabrika], [Pozisyon], [Is_Tel1], [Is_Tel2], [Kurumsal_Tel], [Telsiz_No], [Email], [resimUrl]) VALUES (3, N'Rıza', N'Soyisim3', N'Monomer Müdürlüğü', N'PVC', N'Teknisyen', N'456', N'241', N'124', N'124', N'email@a.com', N'/images/user-128.png')
INSERT [dbo].[SearchModels] ([ID], [Ad], [Soyad], [Unite], [Fabrika], [Pozisyon], [Is_Tel1], [Is_Tel2], [Kurumsal_Tel], [Telsiz_No], [Email], [resimUrl]) VALUES (4, N'Bahadır', N'Soyisim4', N'Polimer Müdürlüğü', N'PTA', N'Yönetici', N'789', N'124', N'214', N'124', N'4email@a.com', N'/images/user-128.png')
SET IDENTITY_INSERT [dbo].[SearchModels] OFF
USE [master]
GO
ALTER DATABASE [RehberDB] SET  READ_WRITE 
GO
