USE [master]
GO
/****** Object:  Database [ECommerceDB]    Script Date: 4/25/2023 3:42:37 PM ******/
CREATE DATABASE [ECommerceDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ECommerceDB', FILENAME = N'C:\Users\udemir\ECommerceDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ECommerceDB_log', FILENAME = N'C:\Users\udemir\ECommerceDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ECommerceDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ECommerceDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ECommerceDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ECommerceDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ECommerceDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ECommerceDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ECommerceDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [ECommerceDB] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [ECommerceDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ECommerceDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ECommerceDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ECommerceDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ECommerceDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ECommerceDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ECommerceDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ECommerceDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ECommerceDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ECommerceDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ECommerceDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ECommerceDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ECommerceDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ECommerceDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ECommerceDB] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [ECommerceDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ECommerceDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ECommerceDB] SET  MULTI_USER 
GO
ALTER DATABASE [ECommerceDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ECommerceDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ECommerceDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ECommerceDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ECommerceDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ECommerceDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [ECommerceDB] SET QUERY_STORE = OFF
GO
USE [ECommerceDB]
GO
/****** Object:  Schema [cap]    Script Date: 4/25/2023 3:42:38 PM ******/
CREATE SCHEMA [cap]
GO
/****** Object:  Table [cap].[Published]    Script Date: 4/25/2023 3:42:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [cap].[Published](
	[Id] [bigint] NOT NULL,
	[Version] [nvarchar](20) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Content] [nvarchar](max) NULL,
	[Retries] [int] NOT NULL,
	[Added] [datetime2](7) NOT NULL,
	[ExpiresAt] [datetime2](7) NULL,
	[StatusName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_cap.Published] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [cap].[Received]    Script Date: 4/25/2023 3:42:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [cap].[Received](
	[Id] [bigint] NOT NULL,
	[Version] [nvarchar](20) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Group] [nvarchar](200) NULL,
	[Content] [nvarchar](max) NULL,
	[Retries] [int] NOT NULL,
	[Added] [datetime2](7) NOT NULL,
	[ExpiresAt] [datetime2](7) NULL,
	[StatusName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_cap.Received] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 4/25/2023 3:42:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 4/25/2023 3:42:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [uniqueidentifier] NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[ModifiedDate] [datetime2](7) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderItems]    Script Date: 4/25/2023 3:42:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderItems](
	[Id] [uniqueidentifier] NOT NULL,
	[OrderId] [uniqueidentifier] NOT NULL,
	[ProductId] [uniqueidentifier] NOT NULL,
	[Amount] [int] NOT NULL,
	[Price] [real] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[ModifiedDate] [datetime2](7) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_OrderItems] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 4/25/2023 3:42:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[Id] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[TotalPrice] [real] NOT NULL,
	[TotalAmount] [int] NOT NULL,
	[OrderDate] [datetime2](7) NOT NULL,
	[Status] [int] NOT NULL,
	[Number] [bigint] NOT NULL,
	[Expiry] [datetime2](7) NOT NULL,
	[CreatedBy] [uniqueidentifier] NOT NULL,
	[ModifiedBy] [uniqueidentifier] NOT NULL,
	[ConfirmDate] [datetime2](7) NOT NULL,
	[CanceledDate] [datetime2](7) NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[ModifiedDate] [datetime2](7) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[Address_District] [nvarchar](max) NOT NULL,
	[Address_Line] [nvarchar](max) NOT NULL,
	[Address_Province] [nvarchar](max) NOT NULL,
	[Address_Street] [nvarchar](max) NOT NULL,
	[Address_ZipCode] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 4/25/2023 3:42:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [uniqueidentifier] NOT NULL,
	[Title] [nvarchar](max) NULL,
	[Price] [float] NOT NULL,
	[Description] [nvarchar](max) NULL,
	[CategoryId] [uniqueidentifier] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[ModifiedDate] [datetime2](7) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 4/25/2023 3:42:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [uniqueidentifier] NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[EMail] [nvarchar](max) NULL,
	[UserName] [nvarchar](max) NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[RefreshToken] [nvarchar](max) NULL,
	[RefreshTokenExpiry] [datetime2](7) NOT NULL,
	[UserTypeId] [uniqueidentifier] NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[ModifiedDate] [datetime2](7) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserType]    Script Date: 4/25/2023 3:42:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserType](
	[Id] [uniqueidentifier] NOT NULL,
	[Title] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[ModifiedDate] [datetime2](7) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_UserType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [cap].[Published] ([Id], [Version], [Name], [Content], [Retries], [Added], [ExpiresAt], [StatusName]) VALUES (9053845319584870401, N'v1', N'createOrder.transaction', N'{"Headers":{"cap-callback-name":null,"cap-msg-id":"9053845319584870401","cap-corr-id":"9053845319584870401","cap-corr-seq":"0","cap-msg-name":"createOrder.transaction","cap-msg-type":"String","cap-senttime":"4/19/2023 6:28:41 PM","cap-exception":"PublisherSentFailedException--\u003ENone of the specified endpoints were reachable"},"Value":"35804e07-33ca-4dfd-944e-ed3b04ff320e"}', 50, CAST(N'2023-04-19T18:28:41.6866667' AS DateTime2), CAST(N'2023-05-04T18:28:41.6866667' AS DateTime2), N'Failed')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230322071920_IdentityAdded', N'7.0.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230322072145_CatalogAdded', N'7.0.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230411230325_OrderAdded', N'7.0.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230411231201_ProductAdded', N'7.0.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230417212809_AddressAdded', N'7.0.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230418233346_DeleteCascadeEnabled', N'7.0.3')
GO
INSERT [dbo].[Categories] ([Id], [Title], [Description], [CreatedDate], [ModifiedDate], [IsDeleted]) VALUES (N'a692ef37-ca37-4bac-a8f9-03af1d2c26ab', N'Sports', N'Sports', CAST(N'2023-04-03T00:00:00.0000000' AS DateTime2), CAST(N'2023-04-03T00:00:00.0000000' AS DateTime2), 0)
INSERT [dbo].[Categories] ([Id], [Title], [Description], [CreatedDate], [ModifiedDate], [IsDeleted]) VALUES (N'8ca5c6c4-a2fc-48cd-8e8c-09c12dd1676a', N'Luggage', N'Luggage', CAST(N'2023-04-03T00:00:00.0000000' AS DateTime2), CAST(N'2023-04-03T00:00:00.0000000' AS DateTime2), 0)
INSERT [dbo].[Categories] ([Id], [Title], [Description], [CreatedDate], [ModifiedDate], [IsDeleted]) VALUES (N'828e2c10-d964-4ed4-a37a-09d00d373314', N'Environment', N'Environment', CAST(N'2023-04-03T00:00:00.0000000' AS DateTime2), CAST(N'2023-04-03T00:00:00.0000000' AS DateTime2), 0)
INSERT [dbo].[Categories] ([Id], [Title], [Description], [CreatedDate], [ModifiedDate], [IsDeleted]) VALUES (N'e7d6c8e6-1a0b-44e9-b235-0c8ab5bab646', N'Computers', N'Computers', CAST(N'2023-04-03T00:00:00.0000000' AS DateTime2), CAST(N'2023-04-03T00:00:00.0000000' AS DateTime2), 0)
INSERT [dbo].[Categories] ([Id], [Title], [Description], [CreatedDate], [ModifiedDate], [IsDeleted]) VALUES (N'1bf1dc87-440a-4179-aa5b-1901f0594208', N'Construction', N'Construction', CAST(N'2023-04-03T00:00:00.0000000' AS DateTime2), CAST(N'2023-04-03T00:00:00.0000000' AS DateTime2), 0)
INSERT [dbo].[Categories] ([Id], [Title], [Description], [CreatedDate], [ModifiedDate], [IsDeleted]) VALUES (N'da5eb209-1fe4-4153-ab4d-1f05e3e4e001', N'Arts', N'Arts', CAST(N'2023-04-03T00:00:00.0000000' AS DateTime2), CAST(N'2023-04-03T00:00:00.0000000' AS DateTime2), 0)
INSERT [dbo].[Categories] ([Id], [Title], [Description], [CreatedDate], [ModifiedDate], [IsDeleted]) VALUES (N'6fb9de88-8387-4a9b-847b-2496f6185f35', N'Health', N'Health', CAST(N'2023-04-03T00:00:00.0000000' AS DateTime2), CAST(N'2023-04-03T00:00:00.0000000' AS DateTime2), 0)
INSERT [dbo].[Categories] ([Id], [Title], [Description], [CreatedDate], [ModifiedDate], [IsDeleted]) VALUES (N'b899a5d0-4d57-45bd-85d7-26e62e493b31', N'Electronics', N'Technology', CAST(N'2023-04-03T00:00:00.0000000' AS DateTime2), CAST(N'2023-04-03T00:00:00.0000000' AS DateTime2), 0)
INSERT [dbo].[Categories] ([Id], [Title], [Description], [CreatedDate], [ModifiedDate], [IsDeleted]) VALUES (N'adfb5072-24f5-458b-8a9b-2dcf35d8aa1c', N'Lights', N'Lights', CAST(N'2023-04-03T00:00:00.0000000' AS DateTime2), CAST(N'2023-04-03T00:00:00.0000000' AS DateTime2), 0)
INSERT [dbo].[Categories] ([Id], [Title], [Description], [CreatedDate], [ModifiedDate], [IsDeleted]) VALUES (N'cc835163-50e1-453f-85c4-36abd63af7b8', N'Smart Home', N'Smart Home', CAST(N'2023-04-03T00:00:00.0000000' AS DateTime2), CAST(N'2023-04-03T00:00:00.0000000' AS DateTime2), 0)
INSERT [dbo].[Categories] ([Id], [Title], [Description], [CreatedDate], [ModifiedDate], [IsDeleted]) VALUES (N'd3103a91-917c-43e1-bb60-3ad1b21e9d85', N'Toys and Games', N'Toys and Games', CAST(N'2023-04-03T00:00:00.0000000' AS DateTime2), CAST(N'2023-04-03T00:00:00.0000000' AS DateTime2), 0)
INSERT [dbo].[Categories] ([Id], [Title], [Description], [CreatedDate], [ModifiedDate], [IsDeleted]) VALUES (N'5349bdde-d724-4a42-bb8f-47be37c9e677', N'Software', N'Software', CAST(N'2023-04-03T00:00:00.0000000' AS DateTime2), CAST(N'2023-04-03T00:00:00.0000000' AS DateTime2), 0)
INSERT [dbo].[Categories] ([Id], [Title], [Description], [CreatedDate], [ModifiedDate], [IsDeleted]) VALUES (N'98ecd59d-a415-4ee1-b2a4-56538ea43edd', N'Beauty', N'Beauty', CAST(N'2023-04-03T00:00:00.0000000' AS DateTime2), CAST(N'2023-04-03T00:00:00.0000000' AS DateTime2), 0)
INSERT [dbo].[Categories] ([Id], [Title], [Description], [CreatedDate], [ModifiedDate], [IsDeleted]) VALUES (N'cd2d41e5-056a-438e-ac49-5da9b56b99d5', N'Automotive', N'Automotive', CAST(N'2023-04-03T00:00:00.0000000' AS DateTime2), CAST(N'2023-04-03T00:00:00.0000000' AS DateTime2), 0)
INSERT [dbo].[Categories] ([Id], [Title], [Description], [CreatedDate], [ModifiedDate], [IsDeleted]) VALUES (N'50865197-921a-48b1-8619-646aaf650906', N'Pet Supplies', N'Pet Supplies', CAST(N'2023-04-03T00:00:00.0000000' AS DateTime2), CAST(N'2023-04-03T00:00:00.0000000' AS DateTime2), 0)
INSERT [dbo].[Categories] ([Id], [Title], [Description], [CreatedDate], [ModifiedDate], [IsDeleted]) VALUES (N'84502e60-1b4b-4aa5-a00d-7e863f0a483f', N'Security', N'Security', CAST(N'2023-04-03T00:00:00.0000000' AS DateTime2), CAST(N'2023-04-03T00:00:00.0000000' AS DateTime2), 0)
INSERT [dbo].[Categories] ([Id], [Title], [Description], [CreatedDate], [ModifiedDate], [IsDeleted]) VALUES (N'b537c4b2-d62d-4dee-b162-a41228a697ab', N'Industrial', N'Industrial', CAST(N'2023-04-03T00:00:00.0000000' AS DateTime2), CAST(N'2023-04-03T00:00:00.0000000' AS DateTime2), 0)
INSERT [dbo].[Categories] ([Id], [Title], [Description], [CreatedDate], [ModifiedDate], [IsDeleted]) VALUES (N'd34c62f6-258b-4031-82b9-a65392f724fd', N'Baby', N'Baby', CAST(N'2023-04-03T00:00:00.0000000' AS DateTime2), CAST(N'2023-04-03T00:00:00.0000000' AS DateTime2), 0)
INSERT [dbo].[Categories] ([Id], [Title], [Description], [CreatedDate], [ModifiedDate], [IsDeleted]) VALUES (N'e10a5294-9a00-49ad-bb40-a7e1ff37d46b', N'Tools & Home Improvement', N'Tools & Home Improvement', CAST(N'2023-04-03T00:00:00.0000000' AS DateTime2), CAST(N'2023-04-03T00:00:00.0000000' AS DateTime2), 0)
INSERT [dbo].[Categories] ([Id], [Title], [Description], [CreatedDate], [ModifiedDate], [IsDeleted]) VALUES (N'bb163266-64f8-42ce-926b-bfb2db6e6ced', N'Home and Kitchen', N'Home and Kitchen', CAST(N'2023-04-03T00:00:00.0000000' AS DateTime2), CAST(N'2023-04-03T00:00:00.0000000' AS DateTime2), 0)
INSERT [dbo].[Categories] ([Id], [Title], [Description], [CreatedDate], [ModifiedDate], [IsDeleted]) VALUES (N'04969f68-a986-4500-bac6-d9050b2cf647', N'Personal Care', N'Personal Care', CAST(N'2023-04-03T00:00:00.0000000' AS DateTime2), CAST(N'2023-04-03T00:00:00.0000000' AS DateTime2), 0)
INSERT [dbo].[Categories] ([Id], [Title], [Description], [CreatedDate], [ModifiedDate], [IsDeleted]) VALUES (N'7e0c6feb-76ca-4a23-8b50-d9189efb7ccc', N'Video Games', N'Video Games', CAST(N'2023-04-03T00:00:00.0000000' AS DateTime2), CAST(N'2023-04-03T00:00:00.0000000' AS DateTime2), 0)
INSERT [dbo].[Categories] ([Id], [Title], [Description], [CreatedDate], [ModifiedDate], [IsDeleted]) VALUES (N'e2fa7ed9-1533-46d8-ad45-d9eb52922a60', N'Music', N'Music', CAST(N'2023-04-03T00:00:00.0000000' AS DateTime2), CAST(N'2023-04-03T00:00:00.0000000' AS DateTime2), 0)
INSERT [dbo].[Categories] ([Id], [Title], [Description], [CreatedDate], [ModifiedDate], [IsDeleted]) VALUES (N'0a2d037e-d1cc-4d4a-aa35-e4f10f15cffa', N'Gifts', N'Gifts', CAST(N'2023-04-03T00:00:00.0000000' AS DateTime2), CAST(N'2023-04-03T00:00:00.0000000' AS DateTime2), 0)
INSERT [dbo].[Categories] ([Id], [Title], [Description], [CreatedDate], [ModifiedDate], [IsDeleted]) VALUES (N'55033b44-c1f3-4af3-9972-e86f632edc42', N'Fashion', N'Fashion', CAST(N'2023-04-03T00:00:00.0000000' AS DateTime2), CAST(N'2023-04-03T00:00:00.0000000' AS DateTime2), 0)
GO
INSERT [dbo].[OrderItems] ([Id], [OrderId], [ProductId], [Amount], [Price], [CreatedDate], [ModifiedDate], [IsDeleted]) VALUES (N'3d18085c-64b6-4996-96c0-07310faf01ec', N'870ea380-2e16-4eff-82d6-4762805ccb3f', N'5258a685-0eef-42a2-86db-949f006e58b7', 1, 1500, CAST(N'2023-04-19T18:09:48.2441842' AS DateTime2), CAST(N'2023-04-19T18:09:48.2441844' AS DateTime2), 0)
INSERT [dbo].[OrderItems] ([Id], [OrderId], [ProductId], [Amount], [Price], [CreatedDate], [ModifiedDate], [IsDeleted]) VALUES (N'f33b49cb-3043-4691-aa42-08d208551468', N'870ea380-2e16-4eff-82d6-4762805ccb3f', N'11084d4a-cb4d-401c-961f-fc39c3953aa2', 1, 19000, CAST(N'2023-04-19T18:09:48.2439266' AS DateTime2), CAST(N'2023-04-19T18:09:48.2439678' AS DateTime2), 0)
INSERT [dbo].[OrderItems] ([Id], [OrderId], [ProductId], [Amount], [Price], [CreatedDate], [ModifiedDate], [IsDeleted]) VALUES (N'20c528d0-5169-42b6-8e1d-4f361cbef6b5', N'35804e07-33ca-4dfd-944e-ed3b04ff320e', N'5258a685-0eef-42a2-86db-949f006e58b7', 1, 1500, CAST(N'2023-04-19T18:28:32.6079807' AS DateTime2), CAST(N'2023-04-19T18:28:32.6079809' AS DateTime2), 0)
INSERT [dbo].[OrderItems] ([Id], [OrderId], [ProductId], [Amount], [Price], [CreatedDate], [ModifiedDate], [IsDeleted]) VALUES (N'fc48bf8c-8c44-4537-9890-59fe0c0e1279', N'219f9e4c-4bd5-4d61-9383-bab13c78ed74', N'11084d4a-cb4d-401c-961f-fc39c3953aa2', 1, 19000, CAST(N'2023-04-19T18:17:09.5058811' AS DateTime2), CAST(N'2023-04-19T18:17:09.5059226' AS DateTime2), 0)
INSERT [dbo].[OrderItems] ([Id], [OrderId], [ProductId], [Amount], [Price], [CreatedDate], [ModifiedDate], [IsDeleted]) VALUES (N'94920c51-f81f-4dc5-8983-5bc90bb2d5ea', N'aabcba6d-1b61-4a59-985e-3b8fd8b2c7e2', N'5258a685-0eef-42a2-86db-949f006e58b7', 1, 1500, CAST(N'2023-04-19T17:16:57.6446660' AS DateTime2), CAST(N'2023-04-19T17:16:57.6446667' AS DateTime2), 0)
INSERT [dbo].[OrderItems] ([Id], [OrderId], [ProductId], [Amount], [Price], [CreatedDate], [ModifiedDate], [IsDeleted]) VALUES (N'ad200578-4938-45bb-a4cb-b940b8e27095', N'aabcba6d-1b61-4a59-985e-3b8fd8b2c7e2', N'11084d4a-cb4d-401c-961f-fc39c3953aa2', 1, 19000, CAST(N'2023-04-19T17:16:57.6442869' AS DateTime2), CAST(N'2023-04-19T17:16:57.6443445' AS DateTime2), 0)
INSERT [dbo].[OrderItems] ([Id], [OrderId], [ProductId], [Amount], [Price], [CreatedDate], [ModifiedDate], [IsDeleted]) VALUES (N'24d0965b-fca9-440f-8573-bef6b11546f9', N'35804e07-33ca-4dfd-944e-ed3b04ff320e', N'11084d4a-cb4d-401c-961f-fc39c3953aa2', 1, 19000, CAST(N'2023-04-19T18:28:32.6077409' AS DateTime2), CAST(N'2023-04-19T18:28:32.6077976' AS DateTime2), 0)
INSERT [dbo].[OrderItems] ([Id], [OrderId], [ProductId], [Amount], [Price], [CreatedDate], [ModifiedDate], [IsDeleted]) VALUES (N'1b773c99-4183-49e9-8de9-dd6457bce723', N'219f9e4c-4bd5-4d61-9383-bab13c78ed74', N'5258a685-0eef-42a2-86db-949f006e58b7', 1, 1500, CAST(N'2023-04-19T18:17:09.5061394' AS DateTime2), CAST(N'2023-04-19T18:17:09.5061396' AS DateTime2), 0)
GO
INSERT [dbo].[Orders] ([Id], [UserId], [TotalPrice], [TotalAmount], [OrderDate], [Status], [Number], [Expiry], [CreatedBy], [ModifiedBy], [ConfirmDate], [CanceledDate], [CreatedDate], [ModifiedDate], [IsDeleted], [Address_District], [Address_Line], [Address_Province], [Address_Street], [Address_ZipCode]) VALUES (N'aabcba6d-1b61-4a59-985e-3b8fd8b2c7e2', N'38028c6f-6fb9-4433-8b8a-482c0e8d19db', 20500, 2, CAST(N'2023-04-19T17:16:54.0816979' AS DateTime2), 1, 12344435, CAST(N'2023-04-29T17:16:54.0819108' AS DateTime2), N'00000000-0000-0000-0000-000000000000', N'00000000-0000-0000-0000-000000000000', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2023-04-19T17:16:58.8945302' AS DateTime2), CAST(N'2023-04-19T17:16:58.8945326' AS DateTime2), 0, N'Disssss', N'asdfasdf', N'ProvinceDeneme', N'Ayaaaaz', N'34396')
INSERT [dbo].[Orders] ([Id], [UserId], [TotalPrice], [TotalAmount], [OrderDate], [Status], [Number], [Expiry], [CreatedBy], [ModifiedBy], [ConfirmDate], [CanceledDate], [CreatedDate], [ModifiedDate], [IsDeleted], [Address_District], [Address_Line], [Address_Province], [Address_Street], [Address_ZipCode]) VALUES (N'870ea380-2e16-4eff-82d6-4762805ccb3f', N'38028c6f-6fb9-4433-8b8a-482c0e8d19db', 20500, 2, CAST(N'2023-04-19T18:09:42.7537602' AS DateTime2), 1, 12344435, CAST(N'2023-04-29T18:09:42.7539066' AS DateTime2), N'38028c6f-6fb9-4433-8b8a-482c0e8d19db', N'38028c6f-6fb9-4433-8b8a-482c0e8d19db', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2023-04-19T18:09:48.9862069' AS DateTime2), CAST(N'2023-04-19T18:09:48.9862103' AS DateTime2), 0, N'Disssss', N'asdfasdf', N'ProvinceDeneme', N'Ayaaaaz', N'34396')
INSERT [dbo].[Orders] ([Id], [UserId], [TotalPrice], [TotalAmount], [OrderDate], [Status], [Number], [Expiry], [CreatedBy], [ModifiedBy], [ConfirmDate], [CanceledDate], [CreatedDate], [ModifiedDate], [IsDeleted], [Address_District], [Address_Line], [Address_Province], [Address_Street], [Address_ZipCode]) VALUES (N'219f9e4c-4bd5-4d61-9383-bab13c78ed74', N'38028c6f-6fb9-4433-8b8a-482c0e8d19db', 20500, 2, CAST(N'2023-04-19T18:17:06.4595917' AS DateTime2), 1, 12344435, CAST(N'2023-04-29T18:17:06.4597926' AS DateTime2), N'38028c6f-6fb9-4433-8b8a-482c0e8d19db', N'38028c6f-6fb9-4433-8b8a-482c0e8d19db', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2023-04-19T18:17:10.1019729' AS DateTime2), CAST(N'2023-04-19T18:17:10.1019753' AS DateTime2), 0, N'Disssss', N'asdfasdf', N'ProvinceDeneme', N'Ayaaaaz', N'34396')
INSERT [dbo].[Orders] ([Id], [UserId], [TotalPrice], [TotalAmount], [OrderDate], [Status], [Number], [Expiry], [CreatedBy], [ModifiedBy], [ConfirmDate], [CanceledDate], [CreatedDate], [ModifiedDate], [IsDeleted], [Address_District], [Address_Line], [Address_Province], [Address_Street], [Address_ZipCode]) VALUES (N'35804e07-33ca-4dfd-944e-ed3b04ff320e', N'38028c6f-6fb9-4433-8b8a-482c0e8d19db', 20500, 2, CAST(N'2023-04-19T18:28:27.1890978' AS DateTime2), 0, 12344435, CAST(N'2023-04-29T18:28:27.1892361' AS DateTime2), N'38028c6f-6fb9-4433-8b8a-482c0e8d19db', N'38028c6f-6fb9-4433-8b8a-482c0e8d19db', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2023-04-19T18:28:33.7528573' AS DateTime2), CAST(N'2023-04-19T18:28:33.7528609' AS DateTime2), 0, N'Disssss', N'asdfasdf', N'ProvinceDeneme', N'Ayaaaaz', N'34396')
GO
INSERT [dbo].[Products] ([Id], [Title], [Price], [Description], [CategoryId], [CreatedDate], [ModifiedDate], [IsDeleted]) VALUES (N'5258a685-0eef-42a2-86db-949f006e58b7', N'Wheel', 1500, N'Wheel For Cars', N'cd2d41e5-056a-438e-ac49-5da9b56b99d5', CAST(N'2023-03-03T00:00:00.0000000' AS DateTime2), CAST(N'2023-03-03T00:00:00.0000000' AS DateTime2), 0)
INSERT [dbo].[Products] ([Id], [Title], [Price], [Description], [CategoryId], [CreatedDate], [ModifiedDate], [IsDeleted]) VALUES (N'11084d4a-cb4d-401c-961f-fc39c3953aa2', N'Asus Notebook A3D34', 19000, N'Asus Bilgisayar', N'e7d6c8e6-1a0b-44e9-b235-0c8ab5bab646', CAST(N'2023-03-03T00:00:00.0000000' AS DateTime2), CAST(N'2023-03-03T00:00:00.0000000' AS DateTime2), 0)
GO
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [EMail], [UserName], [PasswordHash], [PhoneNumber], [RefreshToken], [RefreshTokenExpiry], [UserTypeId], [CreatedDate], [ModifiedDate], [IsDeleted]) VALUES (N'38028c6f-6fb9-4433-8b8a-482c0e8d19db', N'Uğur', N'Demir', N'ugurdemir551@gmail.com', N'ugur', N'pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=', N'5340682415', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'2023-03-23T13:43:31.3914491' AS DateTime2), CAST(N'2023-03-23T13:43:31.3914839' AS DateTime2), 0)
GO
/****** Object:  Index [IX_OrderItems_OrderId]    Script Date: 4/25/2023 3:42:38 PM ******/
CREATE NONCLUSTERED INDEX [IX_OrderItems_OrderId] ON [dbo].[OrderItems]
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Users_UserTypeId]    Script Date: 4/25/2023 3:42:38 PM ******/
CREATE NONCLUSTERED INDEX [IX_Users_UserTypeId] ON [dbo].[Users]
(
	[UserTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Orders] ADD  DEFAULT (N'') FOR [Address_District]
GO
ALTER TABLE [dbo].[Orders] ADD  DEFAULT (N'') FOR [Address_Line]
GO
ALTER TABLE [dbo].[Orders] ADD  DEFAULT (N'') FOR [Address_Province]
GO
ALTER TABLE [dbo].[Orders] ADD  DEFAULT (N'') FOR [Address_Street]
GO
ALTER TABLE [dbo].[Orders] ADD  DEFAULT (N'') FOR [Address_ZipCode]
GO
ALTER TABLE [dbo].[OrderItems]  WITH CHECK ADD  CONSTRAINT [FK_OrderItems_Orders_OrderId] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderItems] CHECK CONSTRAINT [FK_OrderItems_Orders_OrderId]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_UserType_UserTypeId] FOREIGN KEY([UserTypeId])
REFERENCES [dbo].[UserType] ([Id])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_UserType_UserTypeId]
GO
USE [master]
GO
ALTER DATABASE [ECommerceDB] SET  READ_WRITE 
GO
