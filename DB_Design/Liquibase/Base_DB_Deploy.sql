USE [master]
GO
/****** Object:  Database [ShooterDB_test]    Script Date: 2/2/2020 7:27:36 PM ******/
CREATE DATABASE [ShooterDB_test]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ShooterDB_test', FILENAME = N'/var/opt/mssql/data/ShooterDB_test.mdl' , SIZE = 65536KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ShooterDB_test_log', FILENAME = N'/var/opt/mssql/data/ShooterDB_test.ldf' , SIZE = 65536KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ShooterDB_test] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ShooterDB_test].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ShooterDB_test] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ShooterDB_test] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ShooterDB_test] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ShooterDB_test] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ShooterDB_test] SET ARITHABORT OFF 
GO
ALTER DATABASE [ShooterDB_test] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ShooterDB_test] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ShooterDB_test] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ShooterDB_test] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ShooterDB_test] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ShooterDB_test] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ShooterDB_test] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ShooterDB_test] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ShooterDB_test] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ShooterDB_test] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ShooterDB_test] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ShooterDB_test] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ShooterDB_test] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ShooterDB_test] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ShooterDB_test] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ShooterDB_test] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ShooterDB_test] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ShooterDB_test] SET RECOVERY FULL 
GO
ALTER DATABASE [ShooterDB_test] SET  MULTI_USER 
GO
ALTER DATABASE [ShooterDB_test] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ShooterDB_test] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ShooterDB_test] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ShooterDB_test] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ShooterDB_test] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'ShooterDB_test', N'ON'
GO
ALTER DATABASE [ShooterDB_test] SET QUERY_STORE = OFF
GO
USE [ShooterDB_test]
GO
/****** Object:  User [Shooter_app]    Script Date: 2/2/2020 7:27:36 PM ******/
CREATE USER [Shooter_app] FOR LOGIN [Shooter_app] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [Shooter_app]
GO
/****** Object:  Table [dbo].[Class_types]    Script Date: 2/2/2020 7:27:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Class_types](
	[Class_id] [int] NOT NULL,
	[Class_name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_CLASS_TYPES] PRIMARY KEY CLUSTERED 
(
	[Class_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DATABASECHANGELOG]    Script Date: 2/2/2020 7:27:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DATABASECHANGELOG](
	[ID] [nvarchar](255) NOT NULL,
	[AUTHOR] [nvarchar](255) NOT NULL,
	[FILENAME] [nvarchar](255) NOT NULL,
	[DATEEXECUTED] [datetime2](3) NOT NULL,
	[ORDEREXECUTED] [int] NOT NULL,
	[EXECTYPE] [nvarchar](10) NOT NULL,
	[MD5SUM] [nvarchar](35) NULL,
	[DESCRIPTION] [nvarchar](255) NULL,
	[COMMENTS] [nvarchar](255) NULL,
	[TAG] [nvarchar](255) NULL,
	[LIQUIBASE] [nvarchar](20) NULL,
	[CONTEXTS] [nvarchar](255) NULL,
	[LABELS] [nvarchar](255) NULL,
	[DEPLOYMENT_ID] [nvarchar](10) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DATABASECHANGELOGLOCK]    Script Date: 2/2/2020 7:27:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DATABASECHANGELOGLOCK](
	[ID] [int] NOT NULL,
	[LOCKED] [bit] NOT NULL,
	[LOCKGRANTED] [datetime2](3) NULL,
	[LOCKEDBY] [nvarchar](255) NULL,
 CONSTRAINT [PK_DATABASECHANGELOGLOCK] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Equipment]    Script Date: 2/2/2020 7:27:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Equipment](
	[Equipment_id] [int] NOT NULL,
	[Equipment_name] [varchar](50) NOT NULL,
	[Equipment_Type] [varchar](50) NOT NULL,
	[Equipment_Manufacturer] [varchar](50) NOT NULL,
	[other_details] [varchar](50) NOT NULL,
 CONSTRAINT [PK_EQUIPMENT] PRIMARY KEY CLUSTERED 
(
	[Equipment_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Equipment_list]    Script Date: 2/2/2020 7:27:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Equipment_list](
	[Equipment_list_id] [int] NOT NULL,
	[shooter_id] [int] NOT NULL,
	[Equipment_id] [int] NOT NULL,
 CONSTRAINT [PK_EQUIPMENT_LIST] PRIMARY KEY CLUSTERED 
(
	[Equipment_list_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[pins]    Script Date: 2/2/2020 7:27:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[pins](
	[pin_id] [int] NOT NULL,
	[pin_name] [varchar](50) NOT NULL,
	[distance] [varchar](50) NOT NULL,
	[min_distance] [varchar](50) NOT NULL,
	[target_types_id] [int] NOT NULL,
 CONSTRAINT [PK_PINS] PRIMARY KEY CLUSTERED 
(
	[pin_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Shoot_history]    Script Date: 2/2/2020 7:27:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Shoot_history](
	[shoot_id] [int] NOT NULL,
	[shoot_details] [nchar](10) NULL,
	[shooter_id] [int] NOT NULL,
	[shoot_date] [date] NOT NULL,
 CONSTRAINT [PK_SHOOT_HISTORY] PRIMARY KEY CLUSTERED 
(
	[shoot_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Shooter]    Script Date: 2/2/2020 7:27:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Shooter](
	[shooter_id] [int] NOT NULL,
	[first_name] [varchar](50) NOT NULL,
	[last_name] [varchar](50) NOT NULL,
	[active] [bit] NULL,
	[iscoach] [bit] NULL,
	[Class_id] [int] NULL,
	[discription] [varchar](max) NOT NULL,
 CONSTRAINT [PK_SHOOTER] PRIMARY KEY CLUSTERED 
(
	[shooter_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Shooter_pins]    Script Date: 2/2/2020 7:27:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Shooter_pins](
	[shooterpin_id] [int] NOT NULL,
	[shooter_id] [int] NOT NULL,
	[location] [varchar](50) NOT NULL,
	[pin_id] [int] NULL,
 CONSTRAINT [PK_SHOOTER_PINS] PRIMARY KEY CLUSTERED 
(
	[shooterpin_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[target_types]    Script Date: 2/2/2020 7:27:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[target_types](
	[target_id] [int] NOT NULL,
	[target_name] [varchar](50) NOT NULL,
	[target_distance] [varchar](50) NOT NULL,
	[target_spot] [varchar](50) NOT NULL,
	[discription] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TARGET_TYPES] PRIMARY KEY CLUSTERED 
(
	[target_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Shooter] ADD  CONSTRAINT [DF_Shooter_active]  DEFAULT ((1)) FOR [active]
GO
ALTER TABLE [dbo].[Shooter] ADD  CONSTRAINT [DF_Shooter_iscoach]  DEFAULT ((0)) FOR [iscoach]
GO
ALTER TABLE [dbo].[Equipment_list]  WITH CHECK ADD  CONSTRAINT [FK_Equipment_list_Equipment] FOREIGN KEY([Equipment_id])
REFERENCES [dbo].[Equipment] ([Equipment_id])
GO
ALTER TABLE [dbo].[Equipment_list] CHECK CONSTRAINT [FK_Equipment_list_Equipment]
GO
ALTER TABLE [dbo].[Equipment_list]  WITH CHECK ADD  CONSTRAINT [FK_Equipment_list_Shooter] FOREIGN KEY([shooter_id])
REFERENCES [dbo].[Shooter] ([shooter_id])
GO
ALTER TABLE [dbo].[Equipment_list] CHECK CONSTRAINT [FK_Equipment_list_Shooter]
GO
ALTER TABLE [dbo].[pins]  WITH CHECK ADD  CONSTRAINT [FK_pins_target_types] FOREIGN KEY([target_types_id])
REFERENCES [dbo].[target_types] ([target_id])
GO
ALTER TABLE [dbo].[pins] CHECK CONSTRAINT [FK_pins_target_types]
GO
ALTER TABLE [dbo].[Shoot_history]  WITH CHECK ADD  CONSTRAINT [FK_Shoot_history_Shooter] FOREIGN KEY([shooter_id])
REFERENCES [dbo].[Shooter] ([shooter_id])
GO
ALTER TABLE [dbo].[Shoot_history] CHECK CONSTRAINT [FK_Shoot_history_Shooter]
GO
ALTER TABLE [dbo].[Shooter]  WITH CHECK ADD  CONSTRAINT [FK_Shooter_Class_types] FOREIGN KEY([Class_id])
REFERENCES [dbo].[Class_types] ([Class_id])
GO
ALTER TABLE [dbo].[Shooter] CHECK CONSTRAINT [FK_Shooter_Class_types]
GO
ALTER TABLE [dbo].[Shooter_pins]  WITH CHECK ADD  CONSTRAINT [FK_Shooter_pins_pins] FOREIGN KEY([pin_id])
REFERENCES [dbo].[pins] ([pin_id])
GO
ALTER TABLE [dbo].[Shooter_pins] CHECK CONSTRAINT [FK_Shooter_pins_pins]
GO
ALTER TABLE [dbo].[Shooter_pins]  WITH CHECK ADD  CONSTRAINT [FK_Shooter_pins_Shooter] FOREIGN KEY([shooter_id])
REFERENCES [dbo].[Shooter] ([shooter_id])
GO
ALTER TABLE [dbo].[Shooter_pins] CHECK CONSTRAINT [FK_Shooter_pins_Shooter]
GO
USE [master]
GO
ALTER DATABASE [ShooterDB_test] SET  READ_WRITE 
GO
