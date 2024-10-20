USE [master]
GO
/****** Object:  Database [CargoMSdb]    Script Date: 10/20/2024 4:35:43 PM ******/
CREATE DATABASE [CargoMSdb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CargoMSdb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\CargoMSdb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CargoMSdb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\CargoMSdb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [CargoMSdb] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CargoMSdb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CargoMSdb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CargoMSdb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CargoMSdb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CargoMSdb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CargoMSdb] SET ARITHABORT OFF 
GO
ALTER DATABASE [CargoMSdb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CargoMSdb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CargoMSdb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CargoMSdb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CargoMSdb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CargoMSdb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CargoMSdb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CargoMSdb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CargoMSdb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CargoMSdb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CargoMSdb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CargoMSdb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CargoMSdb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CargoMSdb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CargoMSdb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CargoMSdb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CargoMSdb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CargoMSdb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CargoMSdb] SET  MULTI_USER 
GO
ALTER DATABASE [CargoMSdb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CargoMSdb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CargoMSdb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CargoMSdb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CargoMSdb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CargoMSdb] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [CargoMSdb] SET QUERY_STORE = ON
GO
ALTER DATABASE [CargoMSdb] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [CargoMSdb]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 10/20/2024 4:35:43 PM ******/
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
/****** Object:  Table [dbo].[_user]    Script Date: 10/20/2024 4:35:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[_user](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](255) NOT NULL,
	[password] [varchar](255) NOT NULL,
	[email] [varchar](255) NOT NULL,
	[first_name] [varchar](255) NULL,
	[last_name] [varchar](255) NULL,
	[role] [varchar](255) NULL,
	[date_joined] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[admin]    Script Date: 10/20/2024 4:35:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[admin](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NULL,
	[phone_number] [varchar](20) NOT NULL,
	[address] [text] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[booking]    Script Date: 10/20/2024 4:35:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[booking](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[parcel_id] [int] NULL,
	[customer_id] [int] NULL,
	[booking_date] [datetime] NULL,
	[amount_paid] [decimal](10, 2) NULL,
	[payment_status] [text] NOT NULL,
	[created_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[city]    Script Date: 10/20/2024 4:35:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[city](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](255) NOT NULL,
	[Address] [varchar](100) NOT NULL,
	[state_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[contactus]    Script Date: 10/20/2024 4:35:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[contactus](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[phone_number] [varchar](20) NOT NULL,
	[Message] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[country]    Script Date: 10/20/2024 4:35:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[country](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[customer]    Script Date: 10/20/2024 4:35:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[customer](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NULL,
	[phone_number] [varchar](20) NOT NULL,
	[address] [text] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[deliveryroute]    Script Date: 10/20/2024 4:35:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[deliveryroute](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[from_city_id] [int] NULL,
	[to_city_id] [int] NULL,
	[distance_km] [decimal](10, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[employee]    Script Date: 10/20/2024 4:35:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[employee](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NULL,
	[phone_number] [varchar](20) NOT NULL,
	[address] [text] NOT NULL,
	[position] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[feedback]    Script Date: 10/20/2024 4:35:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[feedback](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[created_by] [int] NULL,
	[feedback_text] [text] NULL,
	[created_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[invoice]    Script Date: 10/20/2024 4:35:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[invoice](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedOn] [date] NOT NULL,
	[CustmerName] [varchar](255) NOT NULL,
	[Description] [varchar](255) NOT NULL,
	[Price] [varchar](255) NOT NULL,
	[BookingId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[parcel]    Script Date: 10/20/2024 4:35:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[parcel](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[tracking_id] [varchar](255) NOT NULL,
	[customer_id] [int] NULL,
	[parcel_type] [varchar](255) NULL,
	[from_city_id] [int] NULL,
	[to_city_id] [int] NULL,
	[weight] [decimal](10, 2) NULL,
	[height] [decimal](10, 2) NULL,
	[lenght] [decimal](10, 2) NULL,
	[width] [decimal](10, 2) NULL,
	[price] [decimal](10, 2) NULL,
	[status] [text] NOT NULL,
	[created_at] [datetime] NULL,
	[updated_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[parcelstatus]    Script Date: 10/20/2024 4:35:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[parcelstatus](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[parcel_id] [int] NULL,
	[status] [text] NOT NULL,
	[update_by_user_id] [int] NOT NULL,
	[updated_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[pricing]    Script Date: 10/20/2024 4:35:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[pricing](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[base_price] [decimal](10, 2) NULL,
	[price_per_km] [decimal](10, 2) NULL,
	[price_per_kg] [decimal](10, 2) NULL,
	[created_at] [datetime] NULL,
	[updated_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[state]    Script Date: 10/20/2024 4:35:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[state](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](255) NOT NULL,
	[country_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[_user] ON 

INSERT [dbo].[_user] ([id], [username], [password], [email], [first_name], [last_name], [role], [date_joined]) VALUES (3, N'monit45', N'mon22b', N'monit56@gmail.com', N'dube', N'monit', N'Admin', NULL)
INSERT [dbo].[_user] ([id], [username], [password], [email], [first_name], [last_name], [role], [date_joined]) VALUES (2002, N'jignes', N'jig1010', N'jig123@gmail.com', N'jignes', N'parmar', N'Employee', NULL)
INSERT [dbo].[_user] ([id], [username], [password], [email], [first_name], [last_name], [role], [date_joined]) VALUES (2003, N'karan', N'karan1212', N'karan12@gmail.com', N'karan', N'vasita', N'Customer', NULL)
INSERT [dbo].[_user] ([id], [username], [password], [email], [first_name], [last_name], [role], [date_joined]) VALUES (3009, N'newuser', N'pass123', N'johndoe@example.com', N'John', N'Doe', N'Customer', CAST(N'2024-10-12T11:17:02.050' AS DateTime))
INSERT [dbo].[_user] ([id], [username], [password], [email], [first_name], [last_name], [role], [date_joined]) VALUES (3010, N'darshan12', N'darshan45', N'darshan12@gmail.com', N'darshan', N'panchal', N'Customer', CAST(N'2024-10-12T11:21:13.790' AS DateTime))
INSERT [dbo].[_user] ([id], [username], [password], [email], [first_name], [last_name], [role], [date_joined]) VALUES (3011, N'sahil', N'sahil123', N'sahilb99@gmail.com', N'Bhavsar', N'Sahil', N'Customer', CAST(N'2024-10-12T13:49:48.890' AS DateTime))
INSERT [dbo].[_user] ([id], [username], [password], [email], [first_name], [last_name], [role], [date_joined]) VALUES (3012, N'manan12', N'mk47mk47', N'mk45@gmail.com', N'manan', N'kolate', N'Customer', CAST(N'2024-10-14T11:29:20.077' AS DateTime))
INSERT [dbo].[_user] ([id], [username], [password], [email], [first_name], [last_name], [role], [date_joined]) VALUES (4013, N'samir', N'sam8989', N'samir56@gmail.com', N'samir', N'sahajanad', N'Employee', CAST(N'2024-10-17T14:45:25.187' AS DateTime))
SET IDENTITY_INSERT [dbo].[_user] OFF
GO
SET IDENTITY_INSERT [dbo].[admin] ON 

INSERT [dbo].[admin] ([id], [user_id], [phone_number], [address]) VALUES (2, 3, N'9876567896', N'a 12 narol ahmedabad')
SET IDENTITY_INSERT [dbo].[admin] OFF
GO
SET IDENTITY_INSERT [dbo].[booking] ON 

INSERT [dbo].[booking] ([id], [parcel_id], [customer_id], [booking_date], [amount_paid], [payment_status], [created_at]) VALUES (1, 1, 7, CAST(N'2024-10-17T16:39:33.687' AS DateTime), CAST(10100.00 AS Decimal(10, 2)), N'Pending', CAST(N'2024-10-17T16:39:33.687' AS DateTime))
INSERT [dbo].[booking] ([id], [parcel_id], [customer_id], [booking_date], [amount_paid], [payment_status], [created_at]) VALUES (2, 2, 8, CAST(N'2024-10-17T17:17:27.347' AS DateTime), CAST(10100.00 AS Decimal(10, 2)), N'Pending', CAST(N'2024-10-17T17:17:27.347' AS DateTime))
INSERT [dbo].[booking] ([id], [parcel_id], [customer_id], [booking_date], [amount_paid], [payment_status], [created_at]) VALUES (3, 3, 7, CAST(N'2024-10-17T17:23:04.833' AS DateTime), CAST(10100.00 AS Decimal(10, 2)), N'Pending', CAST(N'2024-10-17T17:23:04.833' AS DateTime))
INSERT [dbo].[booking] ([id], [parcel_id], [customer_id], [booking_date], [amount_paid], [payment_status], [created_at]) VALUES (1002, 1002, 7, CAST(N'2024-10-17T19:25:12.050' AS DateTime), CAST(10100.00 AS Decimal(10, 2)), N'Pending', CAST(N'2024-10-17T19:25:12.050' AS DateTime))
INSERT [dbo].[booking] ([id], [parcel_id], [customer_id], [booking_date], [amount_paid], [payment_status], [created_at]) VALUES (1003, 1003, 7, CAST(N'2024-10-17T19:31:00.767' AS DateTime), CAST(40400.00 AS Decimal(10, 2)), N'Pending', CAST(N'2024-10-17T19:31:00.767' AS DateTime))
INSERT [dbo].[booking] ([id], [parcel_id], [customer_id], [booking_date], [amount_paid], [payment_status], [created_at]) VALUES (1004, 1004, 7, CAST(N'2024-10-17T19:31:19.613' AS DateTime), CAST(10100.00 AS Decimal(10, 2)), N'Pending', CAST(N'2024-10-17T19:31:19.613' AS DateTime))
INSERT [dbo].[booking] ([id], [parcel_id], [customer_id], [booking_date], [amount_paid], [payment_status], [created_at]) VALUES (1005, 1005, 7, CAST(N'2024-10-17T19:31:36.590' AS DateTime), CAST(20200.00 AS Decimal(10, 2)), N'Pending', CAST(N'2024-10-17T19:31:36.590' AS DateTime))
INSERT [dbo].[booking] ([id], [parcel_id], [customer_id], [booking_date], [amount_paid], [payment_status], [created_at]) VALUES (2003, 2003, 7, CAST(N'2024-10-18T19:42:40.220' AS DateTime), CAST(40400.00 AS Decimal(10, 2)), N'Accepted', CAST(N'2024-10-18T19:42:40.220' AS DateTime))
SET IDENTITY_INSERT [dbo].[booking] OFF
GO
SET IDENTITY_INSERT [dbo].[city] ON 

INSERT [dbo].[city] ([id], [Name], [Address], [state_id]) VALUES (2, N'Ahmedabad', N'45 vatva ahmedabad', 1)
INSERT [dbo].[city] ([id], [Name], [Address], [state_id]) VALUES (3, N'Vadodara', N'23 nr Vadodara', 1)
INSERT [dbo].[city] ([id], [Name], [Address], [state_id]) VALUES (1002, N'Surat', N'45 nr keem chokdi surat', 1)
INSERT [dbo].[city] ([id], [Name], [Address], [state_id]) VALUES (2002, N'pornabandar', N'67 nr abc hotel porbandar', 1)
SET IDENTITY_INSERT [dbo].[city] OFF
GO
SET IDENTITY_INSERT [dbo].[contactus] ON 

INSERT [dbo].[contactus] ([id], [Name], [Email], [phone_number], [Message]) VALUES (2, N'avinash', N'avi89@gmail.com', N'7890987784', N'i want to know your service')
SET IDENTITY_INSERT [dbo].[contactus] OFF
GO
SET IDENTITY_INSERT [dbo].[country] ON 

INSERT [dbo].[country] ([id], [Name]) VALUES (2, N'India')
SET IDENTITY_INSERT [dbo].[country] OFF
GO
SET IDENTITY_INSERT [dbo].[customer] ON 

INSERT [dbo].[customer] ([id], [user_id], [phone_number], [address]) VALUES (7, 3011, N'789876789', N'66 kalapi nagar ahmedabad')
INSERT [dbo].[customer] ([id], [user_id], [phone_number], [address]) VALUES (8, 3012, N'9876789876', N'78 nigam society ghodasar')
SET IDENTITY_INSERT [dbo].[customer] OFF
GO
SET IDENTITY_INSERT [dbo].[deliveryroute] ON 

INSERT [dbo].[deliveryroute] ([id], [from_city_id], [to_city_id], [distance_km]) VALUES (1, 2, 3, CAST(100.00 AS Decimal(10, 2)))
SET IDENTITY_INSERT [dbo].[deliveryroute] OFF
GO
SET IDENTITY_INSERT [dbo].[employee] ON 

INSERT [dbo].[employee] ([id], [user_id], [phone_number], [address], [position]) VALUES (1, 2002, N'9009878967', N'89 narol road amedabad', N'Driver')
INSERT [dbo].[employee] ([id], [user_id], [phone_number], [address], [position]) VALUES (1002, 4013, N'9089786756', N'90 uday society isanpur ahmedabad', N'Manager')
SET IDENTITY_INSERT [dbo].[employee] OFF
GO
SET IDENTITY_INSERT [dbo].[invoice] ON 

INSERT [dbo].[invoice] ([id], [CreatedOn], [CustmerName], [Description], [Price], [BookingId]) VALUES (1, CAST(N'2024-10-20' AS Date), N'Bhavsar Sahil', N'Ahmedabad to Vadodara', N'10100.00', 1)
INSERT [dbo].[invoice] ([id], [CreatedOn], [CustmerName], [Description], [Price], [BookingId]) VALUES (2, CAST(N'2024-10-20' AS Date), N'manan kolate', N'Ahmedabad to Vadodara', N'10100.00', 2)
INSERT [dbo].[invoice] ([id], [CreatedOn], [CustmerName], [Description], [Price], [BookingId]) VALUES (3, CAST(N'2024-10-20' AS Date), N'Bhavsar Sahil', N'Ahmedabad to Vadodara', N'10100.00', 3)
SET IDENTITY_INSERT [dbo].[invoice] OFF
GO
SET IDENTITY_INSERT [dbo].[parcel] ON 

INSERT [dbo].[parcel] ([id], [tracking_id], [customer_id], [parcel_type], [from_city_id], [to_city_id], [weight], [height], [lenght], [width], [price], [status], [created_at], [updated_at]) VALUES (1, N'616fd66f-2443-4a18-b07e-5f8278a26346', 7, N'Small', 2, 3, NULL, NULL, NULL, NULL, CAST(10100.00 AS Decimal(10, 2)), N'Booked', CAST(N'2024-10-17T16:39:33.687' AS DateTime), NULL)
INSERT [dbo].[parcel] ([id], [tracking_id], [customer_id], [parcel_type], [from_city_id], [to_city_id], [weight], [height], [lenght], [width], [price], [status], [created_at], [updated_at]) VALUES (2, N'd95300b7-72ed-4c31-aed0-2a09a3ac425e', 8, N'Medium', 2, 3, NULL, NULL, NULL, NULL, CAST(10100.00 AS Decimal(10, 2)), N'Booked', CAST(N'2024-10-17T17:17:27.347' AS DateTime), NULL)
INSERT [dbo].[parcel] ([id], [tracking_id], [customer_id], [parcel_type], [from_city_id], [to_city_id], [weight], [height], [lenght], [width], [price], [status], [created_at], [updated_at]) VALUES (3, N'aaf97869-1364-4ab0-9447-a6284277e73c', 7, N'Large', 2, 3, NULL, NULL, NULL, NULL, CAST(10100.00 AS Decimal(10, 2)), N'Booked', CAST(N'2024-10-17T17:23:04.830' AS DateTime), NULL)
INSERT [dbo].[parcel] ([id], [tracking_id], [customer_id], [parcel_type], [from_city_id], [to_city_id], [weight], [height], [lenght], [width], [price], [status], [created_at], [updated_at]) VALUES (1002, N'de2546f1-ea7d-4dd4-a008-e8fe517ef587', 7, N'large', 2, 3, NULL, NULL, NULL, NULL, CAST(10100.00 AS Decimal(10, 2)), N'Booked', CAST(N'2024-10-17T19:25:12.050' AS DateTime), NULL)
INSERT [dbo].[parcel] ([id], [tracking_id], [customer_id], [parcel_type], [from_city_id], [to_city_id], [weight], [height], [lenght], [width], [price], [status], [created_at], [updated_at]) VALUES (1003, N'9cccbb47-0f82-4643-b40d-312c4ce55251', 7, N'large', 2, 3, NULL, NULL, NULL, NULL, CAST(40400.00 AS Decimal(10, 2)), N'Booked', CAST(N'2024-10-17T19:31:00.767' AS DateTime), NULL)
INSERT [dbo].[parcel] ([id], [tracking_id], [customer_id], [parcel_type], [from_city_id], [to_city_id], [weight], [height], [lenght], [width], [price], [status], [created_at], [updated_at]) VALUES (1004, N'479eb705-f3e1-474b-b263-97cd7d9cf89c', 7, N'small', 2, 3, NULL, NULL, NULL, NULL, CAST(10100.00 AS Decimal(10, 2)), N'Booked', CAST(N'2024-10-17T19:31:19.613' AS DateTime), NULL)
INSERT [dbo].[parcel] ([id], [tracking_id], [customer_id], [parcel_type], [from_city_id], [to_city_id], [weight], [height], [lenght], [width], [price], [status], [created_at], [updated_at]) VALUES (1005, N'ee451487-34b4-4ff6-a674-ffaa79485029', 7, N'Medium', 2, 3, NULL, NULL, NULL, NULL, CAST(20200.00 AS Decimal(10, 2)), N'Booked', CAST(N'2024-10-17T19:31:36.590' AS DateTime), NULL)
INSERT [dbo].[parcel] ([id], [tracking_id], [customer_id], [parcel_type], [from_city_id], [to_city_id], [weight], [height], [lenght], [width], [price], [status], [created_at], [updated_at]) VALUES (2003, N'3a26a646-3fe1-4ffa-a6a0-6874586f69c0', 7, N'Large', 2, 3, NULL, NULL, NULL, NULL, CAST(40400.00 AS Decimal(10, 2)), N'Booked', CAST(N'2024-10-18T19:42:40.220' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[parcel] OFF
GO
SET IDENTITY_INSERT [dbo].[pricing] ON 

INSERT [dbo].[pricing] ([id], [base_price], [price_per_km], [price_per_kg], [created_at], [updated_at]) VALUES (2002, CAST(100.00 AS Decimal(10, 2)), CAST(100.00 AS Decimal(10, 2)), CAST(100.00 AS Decimal(10, 2)), CAST(N'2024-10-16T10:36:30.793' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[pricing] OFF
GO
SET IDENTITY_INSERT [dbo].[state] ON 

INSERT [dbo].[state] ([id], [Name], [country_id]) VALUES (1, N'gujarat', 2)
INSERT [dbo].[state] ([id], [Name], [country_id]) VALUES (2, N'Rajesthan', 2)
SET IDENTITY_INSERT [dbo].[state] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__parcel__7AC3E9AF6CA7E7C5]    Script Date: 10/20/2024 4:35:43 PM ******/
ALTER TABLE [dbo].[parcel] ADD UNIQUE NONCLUSTERED 
(
	[tracking_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[admin]  WITH CHECK ADD FOREIGN KEY([user_id])
REFERENCES [dbo].[_user] ([id])
GO
ALTER TABLE [dbo].[booking]  WITH CHECK ADD FOREIGN KEY([customer_id])
REFERENCES [dbo].[customer] ([id])
GO
ALTER TABLE [dbo].[booking]  WITH CHECK ADD FOREIGN KEY([parcel_id])
REFERENCES [dbo].[parcel] ([id])
GO
ALTER TABLE [dbo].[city]  WITH CHECK ADD FOREIGN KEY([state_id])
REFERENCES [dbo].[state] ([id])
GO
ALTER TABLE [dbo].[customer]  WITH CHECK ADD FOREIGN KEY([user_id])
REFERENCES [dbo].[_user] ([id])
GO
ALTER TABLE [dbo].[deliveryroute]  WITH CHECK ADD FOREIGN KEY([from_city_id])
REFERENCES [dbo].[city] ([id])
GO
ALTER TABLE [dbo].[deliveryroute]  WITH CHECK ADD FOREIGN KEY([to_city_id])
REFERENCES [dbo].[city] ([id])
GO
ALTER TABLE [dbo].[employee]  WITH CHECK ADD FOREIGN KEY([user_id])
REFERENCES [dbo].[_user] ([id])
GO
ALTER TABLE [dbo].[feedback]  WITH CHECK ADD FOREIGN KEY([created_by])
REFERENCES [dbo].[customer] ([id])
GO
ALTER TABLE [dbo].[invoice]  WITH CHECK ADD FOREIGN KEY([BookingId])
REFERENCES [dbo].[booking] ([id])
GO
ALTER TABLE [dbo].[parcel]  WITH CHECK ADD FOREIGN KEY([customer_id])
REFERENCES [dbo].[customer] ([id])
GO
ALTER TABLE [dbo].[parcel]  WITH CHECK ADD FOREIGN KEY([from_city_id])
REFERENCES [dbo].[city] ([id])
GO
ALTER TABLE [dbo].[parcel]  WITH CHECK ADD FOREIGN KEY([to_city_id])
REFERENCES [dbo].[city] ([id])
GO
ALTER TABLE [dbo].[parcelstatus]  WITH CHECK ADD FOREIGN KEY([parcel_id])
REFERENCES [dbo].[parcel] ([id])
GO
ALTER TABLE [dbo].[parcelstatus]  WITH CHECK ADD FOREIGN KEY([update_by_user_id])
REFERENCES [dbo].[_user] ([id])
GO
ALTER TABLE [dbo].[state]  WITH CHECK ADD FOREIGN KEY([country_id])
REFERENCES [dbo].[country] ([id])
GO
USE [master]
GO
ALTER DATABASE [CargoMSdb] SET  READ_WRITE 
GO
