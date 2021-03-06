USE [master]
GO
/****** Object:  Database [RestaurantDb]    Script Date: 28/04/2016 11:14:52 p.m. ******/
CREATE DATABASE [RestaurantDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'RestaurantDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\RestaurantDb.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'RestaurantDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\RestaurantDb_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [RestaurantDb] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [RestaurantDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [RestaurantDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [RestaurantDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [RestaurantDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [RestaurantDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [RestaurantDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [RestaurantDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [RestaurantDb] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [RestaurantDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [RestaurantDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [RestaurantDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [RestaurantDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [RestaurantDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [RestaurantDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [RestaurantDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [RestaurantDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [RestaurantDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [RestaurantDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [RestaurantDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [RestaurantDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [RestaurantDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [RestaurantDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [RestaurantDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [RestaurantDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [RestaurantDb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [RestaurantDb] SET  MULTI_USER 
GO
ALTER DATABASE [RestaurantDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [RestaurantDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [RestaurantDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [RestaurantDb] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [RestaurantDb]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 28/04/2016 11:14:53 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Categories](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [varchar](300) NULL,
	[CategoryStatus] [bit] NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FoodMenu]    Script Date: 28/04/2016 11:14:54 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FoodMenu](
	[FoodMenuID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryID] [int] NULL,
	[FoodName] [varchar](200) NULL,
	[DescriptionFood] [varchar](500) NULL,
	[Price] [decimal](10, 2) NULL,
	[PreparationTime] [datetime] NULL,
	[FoodStatus] [bit] NULL,
 CONSTRAINT [PK_FoodMenu] PRIMARY KEY CLUSTERED 
(
	[FoodMenuID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 28/04/2016 11:14:54 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[OrderTime] [datetime] NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SaleControl]    Script Date: 28/04/2016 11:14:54 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SaleControl](
	[SaleControlID] [int] IDENTITY(1,1) NOT NULL,
	[FoodMenuID] [int] NULL,
	[OrderID] [int] NULL,
	[Quantity] [int] NULL,
	[ServiceStatus] [bit] NULL,
 CONSTRAINT [PK_SaleControl] PRIMARY KEY CLUSTERED 
(
	[SaleControlID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User]    Script Date: 28/04/2016 11:14:54 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserTypeID] [int] NULL,
	[UserName] [varchar](100) NULL,
	[NickName] [varchar](30) NULL,
	[Password] [varchar](300) NULL,
	[ActiveStatus] [bit] NULL,
	[OrderStatus] [bit] NULL,
	[OrderQuantityPerson] [int] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserType]    Script Date: 28/04/2016 11:14:54 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserType](
	[UserTypeID] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](100) NULL,
 CONSTRAINT [PK_UserType] PRIMARY KEY CLUSTERED 
(
	[UserTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [CategoryStatus]) VALUES (1, N'Entreé', 1)
INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [CategoryStatus]) VALUES (2, N'Soups', 1)
INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [CategoryStatus]) VALUES (3, N'Main Course', 1)
INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [CategoryStatus]) VALUES (4, N'Beverages', 1)
INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [CategoryStatus]) VALUES (5, N'Desserts', 1)
INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [CategoryStatus]) VALUES (6, N'Combo', 1)
SET IDENTITY_INSERT [dbo].[Categories] OFF
SET IDENTITY_INSERT [dbo].[UserType] ON 

INSERT [dbo].[UserType] ([UserTypeID], [Description]) VALUES (1, N'Administrator')
INSERT [dbo].[UserType] ([UserTypeID], [Description]) VALUES (2, N'UserTable')
SET IDENTITY_INSERT [dbo].[UserType] OFF
ALTER TABLE [dbo].[FoodMenu]  WITH CHECK ADD  CONSTRAINT [FK_FoodMenu_Categories] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Categories] ([CategoryID])
GO
ALTER TABLE [dbo].[FoodMenu] CHECK CONSTRAINT [FK_FoodMenu_Categories]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_User]
GO
ALTER TABLE [dbo].[SaleControl]  WITH CHECK ADD  CONSTRAINT [FK_SaleControl_FoodMenu] FOREIGN KEY([FoodMenuID])
REFERENCES [dbo].[FoodMenu] ([FoodMenuID])
GO
ALTER TABLE [dbo].[SaleControl] CHECK CONSTRAINT [FK_SaleControl_FoodMenu]
GO
ALTER TABLE [dbo].[SaleControl]  WITH CHECK ADD  CONSTRAINT [FK_SaleControl_Orders] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Orders] ([OrderID])
GO
ALTER TABLE [dbo].[SaleControl] CHECK CONSTRAINT [FK_SaleControl_Orders]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_UserType] FOREIGN KEY([UserTypeID])
REFERENCES [dbo].[UserType] ([UserTypeID])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_UserType]
GO
USE [master]
GO
ALTER DATABASE [RestaurantDb] SET  READ_WRITE 
GO
