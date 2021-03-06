USE [master]
GO
/****** Object:  Database [IndraWeb_DB]    Script Date: 4/09/2018 5:12:49 p. m. ******/
CREATE DATABASE [IndraWeb_DB] ON  PRIMARY 
( NAME = N'IndraWeb_DB', FILENAME = N'D:\SQLSERVER\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\IndraWeb_DB.mdf' , SIZE = 3328KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'IndraWeb_DB_log', FILENAME = N'D:\SQLSERVER\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\IndraWeb_DB_log.LDF' , SIZE = 1088KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [IndraWeb_DB] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [IndraWeb_DB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [IndraWeb_DB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [IndraWeb_DB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [IndraWeb_DB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [IndraWeb_DB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [IndraWeb_DB] SET ARITHABORT OFF 
GO
ALTER DATABASE [IndraWeb_DB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [IndraWeb_DB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [IndraWeb_DB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [IndraWeb_DB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [IndraWeb_DB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [IndraWeb_DB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [IndraWeb_DB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [IndraWeb_DB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [IndraWeb_DB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [IndraWeb_DB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [IndraWeb_DB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [IndraWeb_DB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [IndraWeb_DB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [IndraWeb_DB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [IndraWeb_DB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [IndraWeb_DB] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [IndraWeb_DB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [IndraWeb_DB] SET RECOVERY FULL 
GO
ALTER DATABASE [IndraWeb_DB] SET  MULTI_USER 
GO
ALTER DATABASE [IndraWeb_DB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [IndraWeb_DB] SET DB_CHAINING OFF 
GO
USE [IndraWeb_DB]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 4/09/2018 5:12:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Almacenes]    Script Date: 4/09/2018 5:12:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Almacenes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](300) NULL,
 CONSTRAINT [PK_dbo.Almacenes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AlmacenRecursoes]    Script Date: 4/09/2018 5:12:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AlmacenRecursoes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AlmacenId] [int] NOT NULL,
	[RecursoId] [int] NOT NULL,
	[Stock] [decimal](18, 2) NOT NULL,
	[StockCommitted] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_dbo.AlmacenRecursoes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 4/09/2018 5:12:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 4/09/2018 5:12:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 4/09/2018 5:12:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 4/09/2018 5:12:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 4/09/2018 5:12:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[ProfilePhoto] [varbinary](max) NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CategoriaComponentes]    Script Date: 4/09/2018 5:12:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CategoriaComponentes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](300) NULL,
	[Remark] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.CategoriaComponentes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 4/09/2018 5:12:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RazonSocial] [nvarchar](50) NOT NULL,
	[NroDocumento] [nvarchar](11) NOT NULL,
	[TipoDocumentoIdentidadId] [int] NOT NULL,
	[Telefono] [nvarchar](9) NULL,
	[Email] [nvarchar](50) NULL,
	[WebSite] [nvarchar](50) NULL,
	[ContactName] [nvarchar](50) NOT NULL,
	[Direccion] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_dbo.Clientes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CriterioEvaluacions]    Script Date: 4/09/2018 5:12:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CriterioEvaluacions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](300) NULL,
 CONSTRAINT [PK_dbo.CriterioEvaluacions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Documentos]    Script Date: 4/09/2018 5:12:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Documentos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NumDocument] [nvarchar](25) NOT NULL,
	[FileName] [nvarchar](100) NULL,
	[FileExtension] [nvarchar](10) NULL,
	[ContentType] [nvarchar](300) NULL,
	[Content] [varbinary](max) NULL,
	[ResponsableId] [int] NOT NULL,
	[RemarkDocumento] [nvarchar](max) NULL,
	[UserId] [nvarchar](50) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[EditDate] [datetime] NOT NULL,
	[PortafolioId] [int] NULL,
 CONSTRAINT [PK_dbo.Documentos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EstadoAprobacions]    Script Date: 4/09/2018 5:12:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EstadoAprobacions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](300) NULL,
 CONSTRAINT [PK_dbo.EstadoAprobacions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Estados]    Script Date: 4/09/2018 5:12:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estados](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](300) NULL,
 CONSTRAINT [PK_dbo.Estados] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Patrocinadores]    Script Date: 4/09/2018 5:12:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patrocinadores](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombres] [nvarchar](50) NOT NULL,
	[ApellidoPaterno] [nvarchar](25) NOT NULL,
	[ApellidoMaterno] [nvarchar](25) NOT NULL,
	[NroDocumento] [nvarchar](8) NOT NULL,
	[TipoDocumentoIdentidadId] [int] NOT NULL,
	[Telefono] [nvarchar](9) NULL,
	[Email] [nvarchar](50) NULL,
 CONSTRAINT [PK_dbo.Patrocinadores] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Portafolios]    Script Date: 4/09/2018 5:12:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Portafolios](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NumDocument] [nvarchar](25) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Presupuesto] [decimal](18, 2) NOT NULL,
	[StarDate] [datetime] NOT NULL,
	[FinalDate] [datetime] NOT NULL,
	[CategoriaComponenteId] [int] NOT NULL,
	[PrioridadId] [int] NOT NULL,
	[EstadoId] [int] NOT NULL,
	[ResponsableId] [int] NOT NULL,
	[UserId] [nvarchar](50) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[EditDate] [datetime] NOT NULL,
	[TipoDuracionId] [int] NOT NULL,
	[Duracion] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_dbo.Portafolios] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Prioridades]    Script Date: 4/09/2018 5:12:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Prioridades](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](300) NULL,
 CONSTRAINT [PK_dbo.Prioridades] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Programas]    Script Date: 4/09/2018 5:12:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Programas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NumDocument] [nvarchar](25) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Presupuesto] [decimal](18, 2) NOT NULL,
	[StarDate] [datetime] NOT NULL,
	[FinalDate] [datetime] NOT NULL,
	[PrioridadId] [int] NOT NULL,
	[EstadoId] [int] NOT NULL,
	[ResponsableId] [int] NOT NULL,
	[UserId] [nvarchar](50) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[EditDate] [datetime] NOT NULL,
	[TipoDuracionId] [int] NOT NULL,
	[Duracion] [decimal](18, 2) NOT NULL,
	[PortafolioId] [int] NULL,
 CONSTRAINT [PK_dbo.Programas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PropuestaBalanceoDetalles]    Script Date: 4/09/2018 5:12:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PropuestaBalanceoDetalles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PropuestaBalanceoId] [int] NOT NULL,
	[SolicitudRecursoDetalleId] [int] NOT NULL,
	[Quantity] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_dbo.PropuestaBalanceoDetalles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PropuestaBalanceos]    Script Date: 4/09/2018 5:12:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PropuestaBalanceos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NumPropuesta] [nvarchar](25) NOT NULL,
	[PortafolioId] [int] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[EstadoId] [int] NOT NULL,
	[UserId] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_dbo.PropuestaBalanceos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Proyectos]    Script Date: 4/09/2018 5:12:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proyectos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NumDocument] [nvarchar](25) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Presupuesto] [decimal](18, 2) NOT NULL,
	[StarDate] [datetime] NOT NULL,
	[FinalDate] [datetime] NOT NULL,
	[EstadoAprobacionId] [int] NOT NULL,
	[PrioridadId] [int] NOT NULL,
	[EstadoId] [int] NOT NULL,
	[ClienteId] [int] NOT NULL,
	[TipoProyectoId] [int] NOT NULL,
	[ResponsableId] [int] NOT NULL,
	[PatrocinadorId] [int] NOT NULL,
	[ProgramaId] [int] NULL,
	[PortafolioId] [int] NULL,
	[UserId] [nvarchar](50) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[EditDate] [datetime] NOT NULL,
	[TipoDuracionId] [int] NOT NULL,
	[Duracion] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_dbo.Proyectos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Recursos]    Script Date: 4/09/2018 5:12:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Recursos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](300) NULL,
	[CostoUnitario] [decimal](18, 2) NOT NULL,
	[CostoAlquiler] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_dbo.Recursos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SolicitudesRecurso]    Script Date: 4/09/2018 5:12:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SolicitudesRecurso](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProyectoId] [int] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[PrioridadId] [int] NOT NULL,
	[EstadoId] [int] NOT NULL,
	[ResponsableId] [int] NOT NULL,
	[Remark] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.SolicitudesRecurso] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SolicitudesRecursoDetalle]    Script Date: 4/09/2018 5:12:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SolicitudesRecursoDetalle](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SolicitudRecursoId] [int] NOT NULL,
	[RecursoId] [int] NOT NULL,
	[Quantity] [decimal](18, 2) NOT NULL,
	[QuantityAttended] [decimal](18, 2) NOT NULL,
	[TipoSolicitudRecursoId] [int] NOT NULL,
	[DiasAlquiler] [decimal](18, 2) NULL,
	[CostoTotal] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_dbo.SolicitudesRecursoDetalle] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tareas]    Script Date: 4/09/2018 5:12:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tareas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Index] [int] NOT NULL,
	[TipoDuracionId] [int] NOT NULL,
	[Duracion] [decimal](18, 2) NOT NULL,
	[StarDate] [datetime] NOT NULL,
	[FinalDate] [datetime] NOT NULL,
	[EstadoId] [int] NOT NULL,
	[ResponsableId] [int] NOT NULL,
	[ProyectoId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Tareas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoDocumentoIdentidads]    Script Date: 4/09/2018 5:12:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoDocumentoIdentidads](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](300) NULL,
 CONSTRAINT [PK_dbo.TipoDocumentoIdentidads] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoDuraciones]    Script Date: 4/09/2018 5:12:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoDuraciones](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_dbo.TipoDuraciones] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoProyectoes]    Script Date: 4/09/2018 5:12:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoProyectoes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](300) NULL,
 CONSTRAINT [PK_dbo.TipoProyectoes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoSolicitudRecursoes]    Script Date: 4/09/2018 5:12:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoSolicitudRecursoes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_dbo.TipoSolicitudRecursoes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Trabajadores]    Script Date: 4/09/2018 5:12:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Trabajadores](
	[Id] [int] NOT NULL,
	[TipoDocumentoIdentidad_Id] [int] NULL,
 CONSTRAINT [PK_dbo.Trabajadores] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [IX_AlmacenId]    Script Date: 4/09/2018 5:12:49 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_AlmacenId] ON [dbo].[AlmacenRecursoes]
(
	[AlmacenId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_RecursoId]    Script Date: 4/09/2018 5:12:49 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_RecursoId] ON [dbo].[AlmacenRecursoes]
(
	[RecursoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 4/09/2018 5:12:49 p. m. ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserId]    Script Date: 4/09/2018 5:12:49 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserId]    Script Date: 4/09/2018 5:12:49 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_RoleId]    Script Date: 4/09/2018 5:12:49 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserId]    Script Date: 4/09/2018 5:12:49 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserRoles]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 4/09/2018 5:12:49 p. m. ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_TipoDocumentoIdentidadId]    Script Date: 4/09/2018 5:12:49 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_TipoDocumentoIdentidadId] ON [dbo].[Clientes]
(
	[TipoDocumentoIdentidadId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_PortafolioId]    Script Date: 4/09/2018 5:12:49 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_PortafolioId] ON [dbo].[Documentos]
(
	[PortafolioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ResponsableId]    Script Date: 4/09/2018 5:12:49 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_ResponsableId] ON [dbo].[Documentos]
(
	[ResponsableId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_TipoDocumentoIdentidadId]    Script Date: 4/09/2018 5:12:49 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_TipoDocumentoIdentidadId] ON [dbo].[Patrocinadores]
(
	[TipoDocumentoIdentidadId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_CategoriaComponenteId]    Script Date: 4/09/2018 5:12:49 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_CategoriaComponenteId] ON [dbo].[Portafolios]
(
	[CategoriaComponenteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_EstadoId]    Script Date: 4/09/2018 5:12:49 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_EstadoId] ON [dbo].[Portafolios]
(
	[EstadoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_PrioridadId]    Script Date: 4/09/2018 5:12:49 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_PrioridadId] ON [dbo].[Portafolios]
(
	[PrioridadId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ResponsableId]    Script Date: 4/09/2018 5:12:49 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_ResponsableId] ON [dbo].[Portafolios]
(
	[ResponsableId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_TipoDuracionId]    Script Date: 4/09/2018 5:12:49 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_TipoDuracionId] ON [dbo].[Portafolios]
(
	[TipoDuracionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_EstadoId]    Script Date: 4/09/2018 5:12:49 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_EstadoId] ON [dbo].[Programas]
(
	[EstadoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_PortafolioId]    Script Date: 4/09/2018 5:12:49 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_PortafolioId] ON [dbo].[Programas]
(
	[PortafolioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_PrioridadId]    Script Date: 4/09/2018 5:12:49 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_PrioridadId] ON [dbo].[Programas]
(
	[PrioridadId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ResponsableId]    Script Date: 4/09/2018 5:12:49 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_ResponsableId] ON [dbo].[Programas]
(
	[ResponsableId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_TipoDuracionId]    Script Date: 4/09/2018 5:12:49 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_TipoDuracionId] ON [dbo].[Programas]
(
	[TipoDuracionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_PropuestaBalanceoId]    Script Date: 4/09/2018 5:12:49 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_PropuestaBalanceoId] ON [dbo].[PropuestaBalanceoDetalles]
(
	[PropuestaBalanceoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_SolicitudRecursoDetalleId]    Script Date: 4/09/2018 5:12:49 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_SolicitudRecursoDetalleId] ON [dbo].[PropuestaBalanceoDetalles]
(
	[SolicitudRecursoDetalleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_EstadoId]    Script Date: 4/09/2018 5:12:49 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_EstadoId] ON [dbo].[PropuestaBalanceos]
(
	[EstadoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_PortafolioId]    Script Date: 4/09/2018 5:12:49 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_PortafolioId] ON [dbo].[PropuestaBalanceos]
(
	[PortafolioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ClienteId]    Script Date: 4/09/2018 5:12:49 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_ClienteId] ON [dbo].[Proyectos]
(
	[ClienteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_EstadoAprobacionId]    Script Date: 4/09/2018 5:12:49 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_EstadoAprobacionId] ON [dbo].[Proyectos]
(
	[EstadoAprobacionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_EstadoId]    Script Date: 4/09/2018 5:12:49 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_EstadoId] ON [dbo].[Proyectos]
(
	[EstadoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_PatrocinadorId]    Script Date: 4/09/2018 5:12:49 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_PatrocinadorId] ON [dbo].[Proyectos]
(
	[PatrocinadorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_PortafolioId]    Script Date: 4/09/2018 5:12:49 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_PortafolioId] ON [dbo].[Proyectos]
(
	[PortafolioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_PrioridadId]    Script Date: 4/09/2018 5:12:49 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_PrioridadId] ON [dbo].[Proyectos]
(
	[PrioridadId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProgramaId]    Script Date: 4/09/2018 5:12:49 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_ProgramaId] ON [dbo].[Proyectos]
(
	[ProgramaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ResponsableId]    Script Date: 4/09/2018 5:12:49 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_ResponsableId] ON [dbo].[Proyectos]
(
	[ResponsableId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_TipoDuracionId]    Script Date: 4/09/2018 5:12:49 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_TipoDuracionId] ON [dbo].[Proyectos]
(
	[TipoDuracionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_TipoProyectoId]    Script Date: 4/09/2018 5:12:49 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_TipoProyectoId] ON [dbo].[Proyectos]
(
	[TipoProyectoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_EstadoId]    Script Date: 4/09/2018 5:12:49 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_EstadoId] ON [dbo].[SolicitudesRecurso]
(
	[EstadoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_PrioridadId]    Script Date: 4/09/2018 5:12:49 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_PrioridadId] ON [dbo].[SolicitudesRecurso]
(
	[PrioridadId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProyectoId]    Script Date: 4/09/2018 5:12:49 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_ProyectoId] ON [dbo].[SolicitudesRecurso]
(
	[ProyectoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ResponsableId]    Script Date: 4/09/2018 5:12:49 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_ResponsableId] ON [dbo].[SolicitudesRecurso]
(
	[ResponsableId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_RecursoId]    Script Date: 4/09/2018 5:12:49 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_RecursoId] ON [dbo].[SolicitudesRecursoDetalle]
(
	[RecursoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_SolicitudRecursoId]    Script Date: 4/09/2018 5:12:49 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_SolicitudRecursoId] ON [dbo].[SolicitudesRecursoDetalle]
(
	[SolicitudRecursoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_TipoSolicitudRecursoId]    Script Date: 4/09/2018 5:12:49 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_TipoSolicitudRecursoId] ON [dbo].[SolicitudesRecursoDetalle]
(
	[TipoSolicitudRecursoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_EstadoId]    Script Date: 4/09/2018 5:12:49 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_EstadoId] ON [dbo].[Tareas]
(
	[EstadoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProyectoId]    Script Date: 4/09/2018 5:12:49 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_ProyectoId] ON [dbo].[Tareas]
(
	[ProyectoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ResponsableId]    Script Date: 4/09/2018 5:12:49 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_ResponsableId] ON [dbo].[Tareas]
(
	[ResponsableId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_TipoDuracionId]    Script Date: 4/09/2018 5:12:49 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_TipoDuracionId] ON [dbo].[Tareas]
(
	[TipoDuracionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Id]    Script Date: 4/09/2018 5:12:49 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_Id] ON [dbo].[Trabajadores]
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_TipoDocumentoIdentidad_Id]    Script Date: 4/09/2018 5:12:49 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_TipoDocumentoIdentidad_Id] ON [dbo].[Trabajadores]
(
	[TipoDocumentoIdentidad_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AlmacenRecursoes]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AlmacenRecursoes_dbo.Almacenes_AlmacenId] FOREIGN KEY([AlmacenId])
REFERENCES [dbo].[Almacenes] ([Id])
GO
ALTER TABLE [dbo].[AlmacenRecursoes] CHECK CONSTRAINT [FK_dbo.AlmacenRecursoes_dbo.Almacenes_AlmacenId]
GO
ALTER TABLE [dbo].[AlmacenRecursoes]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AlmacenRecursoes_dbo.Recursos_RecursoId] FOREIGN KEY([RecursoId])
REFERENCES [dbo].[Recursos] ([Id])
GO
ALTER TABLE [dbo].[AlmacenRecursoes] CHECK CONSTRAINT [FK_dbo.AlmacenRecursoes_dbo.Recursos_RecursoId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Clientes]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Clientes_dbo.TipoDocumentoIdentidads_TipoDocumentoIdentidadId] FOREIGN KEY([TipoDocumentoIdentidadId])
REFERENCES [dbo].[TipoDocumentoIdentidads] ([Id])
GO
ALTER TABLE [dbo].[Clientes] CHECK CONSTRAINT [FK_dbo.Clientes_dbo.TipoDocumentoIdentidads_TipoDocumentoIdentidadId]
GO
ALTER TABLE [dbo].[Documentos]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Documentos_dbo.Portafolios_PortafolioId] FOREIGN KEY([PortafolioId])
REFERENCES [dbo].[Portafolios] ([Id])
GO
ALTER TABLE [dbo].[Documentos] CHECK CONSTRAINT [FK_dbo.Documentos_dbo.Portafolios_PortafolioId]
GO
ALTER TABLE [dbo].[Documentos]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Documentos_dbo.Trabajadores_ResponsableId] FOREIGN KEY([ResponsableId])
REFERENCES [dbo].[Trabajadores] ([Id])
GO
ALTER TABLE [dbo].[Documentos] CHECK CONSTRAINT [FK_dbo.Documentos_dbo.Trabajadores_ResponsableId]
GO
ALTER TABLE [dbo].[Patrocinadores]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Patrocinadores_dbo.TipoDocumentoIdentidads_TipoDocumentoIdentidadId] FOREIGN KEY([TipoDocumentoIdentidadId])
REFERENCES [dbo].[TipoDocumentoIdentidads] ([Id])
GO
ALTER TABLE [dbo].[Patrocinadores] CHECK CONSTRAINT [FK_dbo.Patrocinadores_dbo.TipoDocumentoIdentidads_TipoDocumentoIdentidadId]
GO
ALTER TABLE [dbo].[Portafolios]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Portafolios_dbo.CategoriaComponentes_CategoriaComponenteId] FOREIGN KEY([CategoriaComponenteId])
REFERENCES [dbo].[CategoriaComponentes] ([Id])
GO
ALTER TABLE [dbo].[Portafolios] CHECK CONSTRAINT [FK_dbo.Portafolios_dbo.CategoriaComponentes_CategoriaComponenteId]
GO
ALTER TABLE [dbo].[Portafolios]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Portafolios_dbo.Estados_EstadoId] FOREIGN KEY([EstadoId])
REFERENCES [dbo].[Estados] ([Id])
GO
ALTER TABLE [dbo].[Portafolios] CHECK CONSTRAINT [FK_dbo.Portafolios_dbo.Estados_EstadoId]
GO
ALTER TABLE [dbo].[Portafolios]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Portafolios_dbo.Prioridades_PrioridadId] FOREIGN KEY([PrioridadId])
REFERENCES [dbo].[Prioridades] ([Id])
GO
ALTER TABLE [dbo].[Portafolios] CHECK CONSTRAINT [FK_dbo.Portafolios_dbo.Prioridades_PrioridadId]
GO
ALTER TABLE [dbo].[Portafolios]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Portafolios_dbo.TipoDuraciones_TipoDuracionId] FOREIGN KEY([TipoDuracionId])
REFERENCES [dbo].[TipoDuraciones] ([Id])
GO
ALTER TABLE [dbo].[Portafolios] CHECK CONSTRAINT [FK_dbo.Portafolios_dbo.TipoDuraciones_TipoDuracionId]
GO
ALTER TABLE [dbo].[Portafolios]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Portafolios_dbo.Trabajadores_ResponsableId] FOREIGN KEY([ResponsableId])
REFERENCES [dbo].[Trabajadores] ([Id])
GO
ALTER TABLE [dbo].[Portafolios] CHECK CONSTRAINT [FK_dbo.Portafolios_dbo.Trabajadores_ResponsableId]
GO
ALTER TABLE [dbo].[Programas]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Programas_dbo.Estados_EstadoId] FOREIGN KEY([EstadoId])
REFERENCES [dbo].[Estados] ([Id])
GO
ALTER TABLE [dbo].[Programas] CHECK CONSTRAINT [FK_dbo.Programas_dbo.Estados_EstadoId]
GO
ALTER TABLE [dbo].[Programas]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Programas_dbo.Portafolios_PortafolioId] FOREIGN KEY([PortafolioId])
REFERENCES [dbo].[Portafolios] ([Id])
GO
ALTER TABLE [dbo].[Programas] CHECK CONSTRAINT [FK_dbo.Programas_dbo.Portafolios_PortafolioId]
GO
ALTER TABLE [dbo].[Programas]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Programas_dbo.Prioridades_PrioridadId] FOREIGN KEY([PrioridadId])
REFERENCES [dbo].[Prioridades] ([Id])
GO
ALTER TABLE [dbo].[Programas] CHECK CONSTRAINT [FK_dbo.Programas_dbo.Prioridades_PrioridadId]
GO
ALTER TABLE [dbo].[Programas]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Programas_dbo.TipoDuraciones_TipoDuracionId] FOREIGN KEY([TipoDuracionId])
REFERENCES [dbo].[TipoDuraciones] ([Id])
GO
ALTER TABLE [dbo].[Programas] CHECK CONSTRAINT [FK_dbo.Programas_dbo.TipoDuraciones_TipoDuracionId]
GO
ALTER TABLE [dbo].[Programas]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Programas_dbo.Trabajadores_ResponsableId] FOREIGN KEY([ResponsableId])
REFERENCES [dbo].[Trabajadores] ([Id])
GO
ALTER TABLE [dbo].[Programas] CHECK CONSTRAINT [FK_dbo.Programas_dbo.Trabajadores_ResponsableId]
GO
ALTER TABLE [dbo].[PropuestaBalanceoDetalles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.PropuestaBalanceoDetalles_dbo.PropuestaBalanceos_PropuestaBalanceoId] FOREIGN KEY([PropuestaBalanceoId])
REFERENCES [dbo].[PropuestaBalanceos] ([Id])
GO
ALTER TABLE [dbo].[PropuestaBalanceoDetalles] CHECK CONSTRAINT [FK_dbo.PropuestaBalanceoDetalles_dbo.PropuestaBalanceos_PropuestaBalanceoId]
GO
ALTER TABLE [dbo].[PropuestaBalanceoDetalles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.PropuestaBalanceoDetalles_dbo.SolicitudesRecursoDetalle_SolicitudRecursoDetalleId] FOREIGN KEY([SolicitudRecursoDetalleId])
REFERENCES [dbo].[SolicitudesRecursoDetalle] ([Id])
GO
ALTER TABLE [dbo].[PropuestaBalanceoDetalles] CHECK CONSTRAINT [FK_dbo.PropuestaBalanceoDetalles_dbo.SolicitudesRecursoDetalle_SolicitudRecursoDetalleId]
GO
ALTER TABLE [dbo].[PropuestaBalanceos]  WITH CHECK ADD  CONSTRAINT [FK_dbo.PropuestaBalanceos_dbo.Estados_EstadoId] FOREIGN KEY([EstadoId])
REFERENCES [dbo].[Estados] ([Id])
GO
ALTER TABLE [dbo].[PropuestaBalanceos] CHECK CONSTRAINT [FK_dbo.PropuestaBalanceos_dbo.Estados_EstadoId]
GO
ALTER TABLE [dbo].[PropuestaBalanceos]  WITH CHECK ADD  CONSTRAINT [FK_dbo.PropuestaBalanceos_dbo.Portafolios_PortafolioId] FOREIGN KEY([PortafolioId])
REFERENCES [dbo].[Portafolios] ([Id])
GO
ALTER TABLE [dbo].[PropuestaBalanceos] CHECK CONSTRAINT [FK_dbo.PropuestaBalanceos_dbo.Portafolios_PortafolioId]
GO
ALTER TABLE [dbo].[Proyectos]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Proyectos_dbo.Clientes_ClienteId] FOREIGN KEY([ClienteId])
REFERENCES [dbo].[Clientes] ([Id])
GO
ALTER TABLE [dbo].[Proyectos] CHECK CONSTRAINT [FK_dbo.Proyectos_dbo.Clientes_ClienteId]
GO
ALTER TABLE [dbo].[Proyectos]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Proyectos_dbo.EstadoAprobacions_EstadoAprobacionId] FOREIGN KEY([EstadoAprobacionId])
REFERENCES [dbo].[EstadoAprobacions] ([Id])
GO
ALTER TABLE [dbo].[Proyectos] CHECK CONSTRAINT [FK_dbo.Proyectos_dbo.EstadoAprobacions_EstadoAprobacionId]
GO
ALTER TABLE [dbo].[Proyectos]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Proyectos_dbo.Estados_EstadoId] FOREIGN KEY([EstadoId])
REFERENCES [dbo].[Estados] ([Id])
GO
ALTER TABLE [dbo].[Proyectos] CHECK CONSTRAINT [FK_dbo.Proyectos_dbo.Estados_EstadoId]
GO
ALTER TABLE [dbo].[Proyectos]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Proyectos_dbo.Patrocinadores_PatrocinadorId] FOREIGN KEY([PatrocinadorId])
REFERENCES [dbo].[Patrocinadores] ([Id])
GO
ALTER TABLE [dbo].[Proyectos] CHECK CONSTRAINT [FK_dbo.Proyectos_dbo.Patrocinadores_PatrocinadorId]
GO
ALTER TABLE [dbo].[Proyectos]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Proyectos_dbo.Portafolios_PortafolioId] FOREIGN KEY([PortafolioId])
REFERENCES [dbo].[Portafolios] ([Id])
GO
ALTER TABLE [dbo].[Proyectos] CHECK CONSTRAINT [FK_dbo.Proyectos_dbo.Portafolios_PortafolioId]
GO
ALTER TABLE [dbo].[Proyectos]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Proyectos_dbo.Prioridades_PrioridadId] FOREIGN KEY([PrioridadId])
REFERENCES [dbo].[Prioridades] ([Id])
GO
ALTER TABLE [dbo].[Proyectos] CHECK CONSTRAINT [FK_dbo.Proyectos_dbo.Prioridades_PrioridadId]
GO
ALTER TABLE [dbo].[Proyectos]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Proyectos_dbo.Programas_ProgramaId] FOREIGN KEY([ProgramaId])
REFERENCES [dbo].[Programas] ([Id])
GO
ALTER TABLE [dbo].[Proyectos] CHECK CONSTRAINT [FK_dbo.Proyectos_dbo.Programas_ProgramaId]
GO
ALTER TABLE [dbo].[Proyectos]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Proyectos_dbo.TipoDuraciones_TipoDuracionId] FOREIGN KEY([TipoDuracionId])
REFERENCES [dbo].[TipoDuraciones] ([Id])
GO
ALTER TABLE [dbo].[Proyectos] CHECK CONSTRAINT [FK_dbo.Proyectos_dbo.TipoDuraciones_TipoDuracionId]
GO
ALTER TABLE [dbo].[Proyectos]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Proyectos_dbo.TipoProyectoes_TipoProyectoId] FOREIGN KEY([TipoProyectoId])
REFERENCES [dbo].[TipoProyectoes] ([Id])
GO
ALTER TABLE [dbo].[Proyectos] CHECK CONSTRAINT [FK_dbo.Proyectos_dbo.TipoProyectoes_TipoProyectoId]
GO
ALTER TABLE [dbo].[Proyectos]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Proyectos_dbo.Trabajadores_ResponsableId] FOREIGN KEY([ResponsableId])
REFERENCES [dbo].[Trabajadores] ([Id])
GO
ALTER TABLE [dbo].[Proyectos] CHECK CONSTRAINT [FK_dbo.Proyectos_dbo.Trabajadores_ResponsableId]
GO
ALTER TABLE [dbo].[SolicitudesRecurso]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SolicitudesRecurso_dbo.Estados_EstadoId] FOREIGN KEY([EstadoId])
REFERENCES [dbo].[Estados] ([Id])
GO
ALTER TABLE [dbo].[SolicitudesRecurso] CHECK CONSTRAINT [FK_dbo.SolicitudesRecurso_dbo.Estados_EstadoId]
GO
ALTER TABLE [dbo].[SolicitudesRecurso]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SolicitudesRecurso_dbo.Prioridades_PrioridadId] FOREIGN KEY([PrioridadId])
REFERENCES [dbo].[Prioridades] ([Id])
GO
ALTER TABLE [dbo].[SolicitudesRecurso] CHECK CONSTRAINT [FK_dbo.SolicitudesRecurso_dbo.Prioridades_PrioridadId]
GO
ALTER TABLE [dbo].[SolicitudesRecurso]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SolicitudesRecurso_dbo.Proyectos_ProyectoId] FOREIGN KEY([ProyectoId])
REFERENCES [dbo].[Proyectos] ([Id])
GO
ALTER TABLE [dbo].[SolicitudesRecurso] CHECK CONSTRAINT [FK_dbo.SolicitudesRecurso_dbo.Proyectos_ProyectoId]
GO
ALTER TABLE [dbo].[SolicitudesRecurso]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SolicitudesRecurso_dbo.Trabajadores_ResponsableId] FOREIGN KEY([ResponsableId])
REFERENCES [dbo].[Trabajadores] ([Id])
GO
ALTER TABLE [dbo].[SolicitudesRecurso] CHECK CONSTRAINT [FK_dbo.SolicitudesRecurso_dbo.Trabajadores_ResponsableId]
GO
ALTER TABLE [dbo].[SolicitudesRecursoDetalle]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SolicitudesRecursoDetalle_dbo.Recursos_RecursoId] FOREIGN KEY([RecursoId])
REFERENCES [dbo].[Recursos] ([Id])
GO
ALTER TABLE [dbo].[SolicitudesRecursoDetalle] CHECK CONSTRAINT [FK_dbo.SolicitudesRecursoDetalle_dbo.Recursos_RecursoId]
GO
ALTER TABLE [dbo].[SolicitudesRecursoDetalle]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SolicitudesRecursoDetalle_dbo.SolicitudesRecurso_SolicitudRecursoId] FOREIGN KEY([SolicitudRecursoId])
REFERENCES [dbo].[SolicitudesRecurso] ([Id])
GO
ALTER TABLE [dbo].[SolicitudesRecursoDetalle] CHECK CONSTRAINT [FK_dbo.SolicitudesRecursoDetalle_dbo.SolicitudesRecurso_SolicitudRecursoId]
GO
ALTER TABLE [dbo].[SolicitudesRecursoDetalle]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SolicitudesRecursoDetalle_dbo.TipoSolicitudRecursoes_TipoSolicitudRecursoId] FOREIGN KEY([TipoSolicitudRecursoId])
REFERENCES [dbo].[TipoSolicitudRecursoes] ([Id])
GO
ALTER TABLE [dbo].[SolicitudesRecursoDetalle] CHECK CONSTRAINT [FK_dbo.SolicitudesRecursoDetalle_dbo.TipoSolicitudRecursoes_TipoSolicitudRecursoId]
GO
ALTER TABLE [dbo].[Tareas]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Tareas_dbo.Estados_EstadoId] FOREIGN KEY([EstadoId])
REFERENCES [dbo].[Estados] ([Id])
GO
ALTER TABLE [dbo].[Tareas] CHECK CONSTRAINT [FK_dbo.Tareas_dbo.Estados_EstadoId]
GO
ALTER TABLE [dbo].[Tareas]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Tareas_dbo.Proyectos_ProyectoId] FOREIGN KEY([ProyectoId])
REFERENCES [dbo].[Proyectos] ([Id])
GO
ALTER TABLE [dbo].[Tareas] CHECK CONSTRAINT [FK_dbo.Tareas_dbo.Proyectos_ProyectoId]
GO
ALTER TABLE [dbo].[Tareas]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Tareas_dbo.TipoDuraciones_TipoDuracionId] FOREIGN KEY([TipoDuracionId])
REFERENCES [dbo].[TipoDuraciones] ([Id])
GO
ALTER TABLE [dbo].[Tareas] CHECK CONSTRAINT [FK_dbo.Tareas_dbo.TipoDuraciones_TipoDuracionId]
GO
ALTER TABLE [dbo].[Tareas]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Tareas_dbo.Trabajadores_ResponsableId] FOREIGN KEY([ResponsableId])
REFERENCES [dbo].[Trabajadores] ([Id])
GO
ALTER TABLE [dbo].[Tareas] CHECK CONSTRAINT [FK_dbo.Tareas_dbo.Trabajadores_ResponsableId]
GO
ALTER TABLE [dbo].[Trabajadores]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Trabajadores_dbo.Patrocinadores_Id] FOREIGN KEY([Id])
REFERENCES [dbo].[Patrocinadores] ([Id])
GO
ALTER TABLE [dbo].[Trabajadores] CHECK CONSTRAINT [FK_dbo.Trabajadores_dbo.Patrocinadores_Id]
GO
ALTER TABLE [dbo].[Trabajadores]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Trabajadores_dbo.TipoDocumentoIdentidads_TipoDocumentoIdentidad_Id] FOREIGN KEY([TipoDocumentoIdentidad_Id])
REFERENCES [dbo].[TipoDocumentoIdentidads] ([Id])
GO
ALTER TABLE [dbo].[Trabajadores] CHECK CONSTRAINT [FK_dbo.Trabajadores_dbo.TipoDocumentoIdentidads_TipoDocumentoIdentidad_Id]
GO
USE [master]
GO
ALTER DATABASE [IndraWeb_DB] SET  READ_WRITE 
GO
