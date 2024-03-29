USE [master]
GO
/****** Object:  Database [MyStore]    Script Date: 11/10/2023 2:49:07 PM ******/
CREATE DATABASE [MyStore]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MyStore', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\MyStore.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MyStore_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\MyStore_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [MyStore] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MyStore].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MyStore] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MyStore] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MyStore] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MyStore] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MyStore] SET ARITHABORT OFF 
GO
ALTER DATABASE [MyStore] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MyStore] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MyStore] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MyStore] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MyStore] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MyStore] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MyStore] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MyStore] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MyStore] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MyStore] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MyStore] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MyStore] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MyStore] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MyStore] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MyStore] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MyStore] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MyStore] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MyStore] SET RECOVERY FULL 
GO
ALTER DATABASE [MyStore] SET  MULTI_USER 
GO
ALTER DATABASE [MyStore] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MyStore] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MyStore] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MyStore] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MyStore] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MyStore] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [MyStore] SET QUERY_STORE = OFF
GO
USE [MyStore]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 11/10/2023 2:49:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 11/10/2023 2:49:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[CustomerId] [int] IDENTITY(1,1) NOT NULL,
	[CustomerName] [nvarchar](50) NOT NULL,
	[Email] [varchar](30) NOT NULL,
	[Password] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 11/10/2023 2:49:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](50) NULL,
	[UnitPrice] [money] NULL,
	[UnitsInStock] [int] NULL,
	[CategoryID] [int] NULL,
	[Discontinued] [bit] NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([CategoryID], [CategoryName]) VALUES (1, N'Laptop')
INSERT [dbo].[Categories] ([CategoryID], [CategoryName]) VALUES (2, N'PC')
INSERT [dbo].[Categories] ([CategoryID], [CategoryName]) VALUES (3, N'Mobile')
INSERT [dbo].[Categories] ([CategoryID], [CategoryName]) VALUES (4, N'Tablet')
INSERT [dbo].[Categories] ([CategoryID], [CategoryName]) VALUES (5, N'Headphone')
INSERT [dbo].[Categories] ([CategoryID], [CategoryName]) VALUES (7, N'Switch')
INSERT [dbo].[Categories] ([CategoryID], [CategoryName]) VALUES (8, N'Key Board')
INSERT [dbo].[Categories] ([CategoryID], [CategoryName]) VALUES (9, N'KeyBoard')
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([ProductID], [ProductName], [UnitPrice], [UnitsInStock], [CategoryID], [Discontinued]) VALUES (1, N'Demo 1', 0.0000, 0, 1, 1)
INSERT [dbo].[Products] ([ProductID], [ProductName], [UnitPrice], [UnitsInStock], [CategoryID], [Discontinued]) VALUES (2, N'Demo 2', 15.5000, 50, 2, 0)
INSERT [dbo].[Products] ([ProductID], [ProductName], [UnitPrice], [UnitsInStock], [CategoryID], [Discontinued]) VALUES (3, N'Demo 3', 16.5000, 250, 1, 0)
INSERT [dbo].[Products] ([ProductID], [ProductName], [UnitPrice], [UnitsInStock], [CategoryID], [Discontinued]) VALUES (7, N'Demo 5', 15.5000, 100, 4, 1)
INSERT [dbo].[Products] ([ProductID], [ProductName], [UnitPrice], [UnitsInStock], [CategoryID], [Discontinued]) VALUES (8, N'Demo 6', 20.5000, 100, 3, 1)
INSERT [dbo].[Products] ([ProductID], [ProductName], [UnitPrice], [UnitsInStock], [CategoryID], [Discontinued]) VALUES (9, N'New demo', 0.0000, 0, 1, 1)
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Categories] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Categories] ([CategoryID])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Categories]
GO
USE [master]
GO
ALTER DATABASE [MyStore] SET  READ_WRITE 
GO
