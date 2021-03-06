USE [master]
GO
/****** Object:  Database [system_prestamo]    Script Date: 26/4/20 10:06:20 p. m. ******/
CREATE DATABASE [system_prestamo]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'system_prestamo', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\system_prestamo.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'system_prestamo_log', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\system_prestamo_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [system_prestamo] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [system_prestamo].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [system_prestamo] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [system_prestamo] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [system_prestamo] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [system_prestamo] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [system_prestamo] SET ARITHABORT OFF 
GO
ALTER DATABASE [system_prestamo] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [system_prestamo] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [system_prestamo] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [system_prestamo] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [system_prestamo] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [system_prestamo] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [system_prestamo] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [system_prestamo] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [system_prestamo] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [system_prestamo] SET  DISABLE_BROKER 
GO
ALTER DATABASE [system_prestamo] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [system_prestamo] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [system_prestamo] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [system_prestamo] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [system_prestamo] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [system_prestamo] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [system_prestamo] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [system_prestamo] SET RECOVERY FULL 
GO
ALTER DATABASE [system_prestamo] SET  MULTI_USER 
GO
ALTER DATABASE [system_prestamo] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [system_prestamo] SET DB_CHAINING OFF 
GO
ALTER DATABASE [system_prestamo] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [system_prestamo] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [system_prestamo] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'system_prestamo', N'ON'
GO
USE [system_prestamo]
GO
/****** Object:  User [jmiguel]    Script Date: 26/4/20 10:06:21 p. m. ******/
CREATE USER [jmiguel] FOR LOGIN [jmiguel] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[TAtrasos]    Script Date: 26/4/20 10:06:21 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TAtrasos](
	[IdAtraso] [int] IDENTITY(1,1) NOT NULL,
	[CodigoSolicitud] [int] NULL,
	[Capital] [int] NULL,
	[Intere] [decimal](18, 2) NULL,
	[Comision] [decimal](18, 2) NULL,
	[Seguro] [decimal](18, 2) NULL,
	[Mora] [int] NULL,
	[Cargos] [int] NULL,
 CONSTRAINT [PK_TAtraso] PRIMARY KEY CLUSTERED 
(
	[IdAtraso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TClasePrestamos]    Script Date: 26/4/20 10:06:21 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TClasePrestamos](
	[IdClasePrestamo] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NULL,
 CONSTRAINT [PK_TClasePrestamo] PRIMARY KEY CLUSTERED 
(
	[IdClasePrestamo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TClientes]    Script Date: 26/4/20 10:06:21 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TClientes](
	[IdCliente] [int] IDENTITY(1,1) NOT NULL,
	[NoDocumento] [varchar](15) NULL,
	[Nombre] [varchar](50) NULL,
	[Apellido] [varchar](50) NULL,
	[Apodo] [varchar](20) NULL,
	[Sexo] [varchar](15) NULL,
	[EstadoCivil] [varchar](20) NULL,
	[FechaNacimiento] [date] NULL,
	[Celular] [varchar](15) NULL,
	[Telefono] [varchar](15) NULL,
	[Email] [varchar](50) NULL,
	[Direccion] [varchar](200) NULL,
	[EstadoCliente] [bit] NULL,
	[CodigoCliente] [int] NULL,
	[IdUsuario] [int] NULL,
	[Fecha] [date] NULL,
	[Hora] [varchar](50) NULL,
	[IdSucursal] [int] NULL,
 CONSTRAINT [PK__TCliente__D59466427459C717] PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TCobros]    Script Date: 26/4/20 10:06:21 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TCobros](
	[IdCobro] [int] IDENTITY(1,1) NOT NULL,
	[CodigoPrestamo] [int] NOT NULL,
	[FechaCobro] [date] NULL,
	[HoraCobro] [varchar](20) NULL,
	[CodigoRecibo] [varchar](50) NULL,
	[ConceptoCobro] [varchar](50) NULL,
	[IdUsuario] [int] NULL,
	[IdSucursal] [int] NULL,
	[EstadoCobro] [bit] NULL,
	[IdDistribucion] [int] NULL,
 CONSTRAINT [PK_TPagos] PRIMARY KEY CLUSTERED 
(
	[IdCobro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TDatosLaborables]    Script Date: 26/4/20 10:06:21 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TDatosLaborables](
	[IdDatosLaborables] [int] IDENTITY(1,1) NOT NULL,
	[Empresa] [varchar](50) NOT NULL,
	[TelefonoEmp] [varchar](15) NULL,
	[DireccionEmp] [varchar](200) NULL,
	[Cargo] [varchar](50) NULL,
	[TiempoLaborando] [varchar](30) NULL,
	[Sueldo] [decimal](18, 2) NULL,
	[OtroIngresos] [decimal](18, 2) NULL,
	[DetalleOtroIngresos] [varchar](100) NULL,
	[UtilidadNeta] [decimal](18, 2) NULL,
	[CodigoCliente] [int] NULL,
	[Gastos] [decimal](18, 2) NULL,
 CONSTRAINT [PK__TDatosLa__794906C5D78064F7] PRIMARY KEY CLUSTERED 
(
	[IdDatosLaborables] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TDetalleCobros]    Script Date: 26/4/20 10:06:21 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TDetalleCobros](
	[IdDetalleCobro] [int] IDENTITY(1,1) NOT NULL,
	[CodigoRecibo] [varchar](50) NULL,
	[Capital] [int] NULL,
	[Interes] [decimal](18, 2) NULL,
	[Comision] [decimal](18, 2) NULL,
	[Seguro] [decimal](18, 2) NULL,
	[Mora] [int] NULL,
	[Cargo] [int] NULL,
 CONSTRAINT [PK_TDetalleCobros] PRIMARY KEY CLUSTERED 
(
	[IdDetalleCobro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TDetallePagos]    Script Date: 26/4/20 10:06:21 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TDetallePagos](
	[IdDetallePago] [int] IDENTITY(1,1) NOT NULL,
	[CodigoPago] [int] NULL,
	[Capital] [int] NULL,
	[Interes] [decimal](18, 2) NULL,
	[Comision] [decimal](18, 2) NULL,
	[Seguro] [decimal](18, 2) NULL,
	[Mora] [int] NULL,
	[Cargo] [int] NULL,
	[TotalPagado] [int] NULL,
 CONSTRAINT [PK_TDetallePagos] PRIMARY KEY CLUSTERED 
(
	[IdDetallePago] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TDetalleSolicitudes]    Script Date: 26/4/20 10:06:21 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TDetalleSolicitudes](
	[IdDetalleSolicitud] [int] IDENTITY(1,1) NOT NULL,
	[CodigoSolicitud] [int] NOT NULL,
	[NoCuota] [int] NULL,
	[FechaPago] [date] NULL,
	[Capital] [int] NULL,
	[Interes] [decimal](18, 2) NULL,
	[Comision] [decimal](18, 2) NULL,
	[Seguro] [decimal](18, 2) NULL,
	[ValorCuota] [int] NULL,
 CONSTRAINT [PK_TDetalleSolicitudes] PRIMARY KEY CLUSTERED 
(
	[IdDetalleSolicitud] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TDistribucionPagos]    Script Date: 26/4/20 10:06:21 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TDistribucionPagos](
	[IdDistribucion] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NULL,
 CONSTRAINT [PK_TDistribucionPagos] PRIMARY KEY CLUSTERED 
(
	[IdDistribucion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TEmpresas]    Script Date: 26/4/20 10:06:21 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TEmpresas](
	[IdEmpresa] [int] IDENTITY(1,1) NOT NULL,
	[NombreEP] [varchar](50) NULL,
	[RncEM] [varchar](20) NULL,
	[LemaEM] [varchar](150) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdEmpresa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TEstadoCuotas]    Script Date: 26/4/20 10:06:21 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TEstadoCuotas](
	[IdEstadoCuota] [int] IDENTITY(1,1) NOT NULL,
	[DescripcionEC] [varchar](50) NULL,
 CONSTRAINT [PK_TEstadoCuota] PRIMARY KEY CLUSTERED 
(
	[IdEstadoCuota] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TEstadoPrestamos]    Script Date: 26/4/20 10:06:21 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TEstadoPrestamos](
	[IdEstadoPrestamo] [int] IDENTITY(1,1) NOT NULL,
	[DescripcionEp] [varchar](50) NULL,
 CONSTRAINT [PK_TEstadoPrestamos] PRIMARY KEY CLUSTERED 
(
	[IdEstadoPrestamo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TEstadoSolicitudes]    Script Date: 26/4/20 10:06:21 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TEstadoSolicitudes](
	[IdEstadoSolicitud] [int] IDENTITY(1,1) NOT NULL,
	[DescripcionES] [varchar](50) NULL,
 CONSTRAINT [PK_TEstadoSolicitud] PRIMARY KEY CLUSTERED 
(
	[IdEstadoSolicitud] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TFormaPagos]    Script Date: 26/4/20 10:06:21 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TFormaPagos](
	[IdFormaPago] [int] IDENTITY(1,1) NOT NULL,
	[DescripcionFP] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TFormaPago] PRIMARY KEY CLUSTERED 
(
	[IdFormaPago] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TGarantiaEconomica]    Script Date: 26/4/20 10:06:21 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TGarantiaEconomica](
	[IdGarantiaE] [int] IDENTITY(1,1) NOT NULL,
	[CodigoGarantia] [int] NOT NULL,
	[NombreGE] [varchar](50) NULL,
	[DescripcionGE] [varchar](max) NULL,
	[MatriculaOTituloGE] [bit] NULL,
	[ValorEstimadoGE] [decimal](18, 2) NULL,
	[CodigoCliente] [int] NULL,
	[Fecha] [date] NULL,
	[Hora] [varchar](50) NULL,
	[IdUsuario] [int] NULL,
 CONSTRAINT [PK_TGarantiaEconomica] PRIMARY KEY CLUSTERED 
(
	[IdGarantiaE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TGestores]    Script Date: 26/4/20 10:06:21 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TGestores](
	[IdGestor] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](60) NULL,
 CONSTRAINT [PK_TGestor] PRIMARY KEY CLUSTERED 
(
	[IdGestor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TNotasSolicitudes]    Script Date: 26/4/20 10:06:21 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TNotasSolicitudes](
	[IdNotaSolicitud] [int] IDENTITY(1,1) NOT NULL,
	[CodigoSolicitud] [int] NULL,
	[IdEstadoSolicitud] [int] NULL,
	[DescripcionNS] [varchar](1000) NULL,
	[FechaCreacion] [date] NULL,
 CONSTRAINT [PK_TNotasSolicitudes] PRIMARY KEY CLUSTERED 
(
	[IdNotaSolicitud] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TPrestamos]    Script Date: 26/4/20 10:06:21 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TPrestamos](
	[IdPrestamo] [int] IDENTITY(1,1) NOT NULL,
	[CodigoSolicitud] [int] NULL,
	[FechaSolicitud] [date] NULL,
	[FechaAprovacion] [date] NULL,
 CONSTRAINT [PK_TPrestamos] PRIMARY KEY CLUSTERED 
(
	[IdPrestamo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TReferencias]    Script Date: 26/4/20 10:06:21 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TReferencias](
	[IdReferencias] [int] IDENTITY(1,1) NOT NULL,
	[NombreRef] [varchar](80) NOT NULL,
	[Parentesco] [varchar](15) NULL,
	[Celular] [varchar](15) NULL,
	[Direccion] [varchar](200) NULL,
	[CodigoCliente] [int] NULL,
 CONSTRAINT [PK__TReferen__AC79E0EF170D2916] PRIMARY KEY CLUSTERED 
(
	[IdReferencias] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TReportePagos]    Script Date: 26/4/20 10:06:21 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TReportePagos](
	[IdReportePago] [int] IDENTITY(1,1) NOT NULL,
	[CodigoSolicitud] [int] NOT NULL,
	[MontoPrestamo] [int] NULL,
	[CapitalPagado] [int] NULL,
	[InteresPagado] [decimal](18, 2) NULL,
	[ComisionPagado] [decimal](18, 2) NULL,
	[SeguroPagado] [decimal](18, 2) NULL,
	[MoraPagada] [int] NULL,
	[CargosPagado] [int] NULL,
	[SaldoActual] [int] NULL,
	[FechaUltimoPago] [varchar](50) NULL,
	[DiasSinPagar] [int] NULL,
	[Estado] [bit] NULL,
 CONSTRAINT [PK_TReportePagos] PRIMARY KEY CLUSTERED 
(
	[IdReportePago] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TReportePrestamos]    Script Date: 26/4/20 10:06:21 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TReportePrestamos](
	[IdReportePrestamos] [int] IDENTITY(1,1) NOT NULL,
	[CodigoSolicitud] [int] NOT NULL,
	[NoCuota] [int] NULL,
	[FechaPago] [date] NULL,
	[Capital] [int] NULL,
	[Interes] [decimal](18, 2) NULL,
	[Comision] [decimal](18, 2) NULL,
	[Seguro] [decimal](18, 2) NULL,
	[Mora] [int] NULL,
	[Cargos] [int] NULL,
	[SubTotal] [int] NULL,
	[IdEstadoCuota] [int] NULL,
	[EstadoFecha] [bit] NULL,
 CONSTRAINT [PK_TReportePrestamos] PRIMARY KEY CLUSTERED 
(
	[IdReportePrestamos] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TRoles]    Script Date: 26/4/20 10:06:21 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TRoles](
	[IdRoles] [int] IDENTITY(1,1) NOT NULL,
	[DescripcionRoles] [varchar](50) NULL,
 CONSTRAINT [PK_TRoles] PRIMARY KEY CLUSTERED 
(
	[IdRoles] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TRutas]    Script Date: 26/4/20 10:06:21 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TRutas](
	[IdRuta] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NULL,
 CONSTRAINT [PK_TRuta] PRIMARY KEY CLUSTERED 
(
	[IdRuta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TSolicitudes]    Script Date: 26/4/20 10:06:21 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TSolicitudes](
	[IdSolicitud] [int] IDENTITY(1,1) NOT NULL,
	[CodigoSolicitud] [int] NOT NULL,
	[CodigoCliente] [int] NOT NULL,
	[CodigoCoDeudor] [int] NULL,
	[CodigoGarantia] [int] NULL,
	[IdTipoPrestamo] [int] NOT NULL,
	[IdFormaPago] [int] NOT NULL,
	[IdClasePrestamo] [int] NOT NULL,
	[IdTipoGarantia] [int] NOT NULL,
	[IdRuta] [int] NOT NULL,
	[IdZona] [int] NOT NULL,
	[IdGestor] [int] NOT NULL,
	[FechaPago] [date] NULL,
	[DescripcionInversion] [varchar](100) NOT NULL,
	[MontoSolicitado] [int] NOT NULL,
	[GastosLegales] [int] NULL,
	[MontoTotal] [int] NULL,
	[CantidadCuotas] [int] NOT NULL,
	[TasaInteresAnual] [decimal](18, 2) NOT NULL,
	[TasaComisionAnual] [decimal](18, 2) NULL,
	[TasaSeguroAnual] [decimal](18, 2) NULL,
	[MontoCuota] [int] NULL,
	[IdEstadoSolicitud] [int] NULL,
	[Estado] [bit] NULL,
	[Fecha] [date] NULL,
	[Hora] [varchar](50) NULL,
	[IdUsuario] [int] NULL,
	[IdSucursal] [int] NULL,
	[IdEstadoPrestamo] [int] NULL,
 CONSTRAINT [PK_TSolicitudes] PRIMARY KEY CLUSTERED 
(
	[IdSolicitud] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TSucursales]    Script Date: 26/4/20 10:06:21 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TSucursales](
	[IdSucursal] [int] IDENTITY(1,1) NOT NULL,
	[NombreSU] [varchar](60) NULL,
	[TelefonoSU] [varchar](30) NULL,
	[DireccionSU] [varchar](150) NULL,
	[IdEmpresa] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdSucursal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TTasaInteres]    Script Date: 26/4/20 10:06:21 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TTasaInteres](
	[IdTasaInteres] [int] IDENTITY(1,1) NOT NULL,
	[Valor] [decimal](18, 2) NULL,
 CONSTRAINT [PK_TTasaInteres] PRIMARY KEY CLUSTERED 
(
	[IdTasaInteres] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TTasaMoras]    Script Date: 26/4/20 10:06:21 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TTasaMoras](
	[IdTasaMora] [int] IDENTITY(1,1) NOT NULL,
	[Valor] [decimal](18, 2) NULL,
 CONSTRAINT [PK_TTasaMora] PRIMARY KEY CLUSTERED 
(
	[IdTasaMora] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TTipoGarantias]    Script Date: 26/4/20 10:06:21 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TTipoGarantias](
	[IdTipoGarantia] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NULL,
 CONSTRAINT [PK_TTipoGarantia] PRIMARY KEY CLUSTERED 
(
	[IdTipoGarantia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TTipoPagos]    Script Date: 26/4/20 10:06:21 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TTipoPagos](
	[IdTipoPago] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NULL,
 CONSTRAINT [PK_TFormaPago_1] PRIMARY KEY CLUSTERED 
(
	[IdTipoPago] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TTipoPrestamos]    Script Date: 26/4/20 10:06:21 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TTipoPrestamos](
	[IdTipoPrestamo] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NULL,
 CONSTRAINT [PK_TTipoPrestamo] PRIMARY KEY CLUSTERED 
(
	[IdTipoPrestamo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TUsuarios]    Script Date: 26/4/20 10:06:21 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TUsuarios](
	[IdUsuario] [int] NOT NULL,
	[CodigoUsuario] [int] NULL,
	[NombreUsuario] [varchar](50) NULL,
	[ApellidoUsuario] [varchar](50) NULL,
	[UserUsuario] [varchar](50) NULL,
	[PasswordUsuario] [varchar](50) NULL,
	[IdRoles] [int] NULL,
	[EstadoUsuario] [bit] NULL,
 CONSTRAINT [PK_TUsuarios] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TZonas]    Script Date: 26/4/20 10:06:21 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TZonas](
	[IdZona] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NULL,
 CONSTRAINT [PK_TZonas] PRIMARY KEY CLUSTERED 
(
	[IdZona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[TAtrasos] ON 

GO
INSERT [dbo].[TAtrasos] ([IdAtraso], [CodigoSolicitud], [Capital], [Intere], [Comision], [Seguro], [Mora], [Cargos]) VALUES (1, 658910, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, 0)
GO
INSERT [dbo].[TAtrasos] ([IdAtraso], [CodigoSolicitud], [Capital], [Intere], [Comision], [Seguro], [Mora], [Cargos]) VALUES (2, 439851, 3905, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 6, 0)
GO
INSERT [dbo].[TAtrasos] ([IdAtraso], [CodigoSolicitud], [Capital], [Intere], [Comision], [Seguro], [Mora], [Cargos]) VALUES (3, 925579, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, 0)
GO
INSERT [dbo].[TAtrasos] ([IdAtraso], [CodigoSolicitud], [Capital], [Intere], [Comision], [Seguro], [Mora], [Cargos]) VALUES (4, 205860, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, 0)
GO
INSERT [dbo].[TAtrasos] ([IdAtraso], [CodigoSolicitud], [Capital], [Intere], [Comision], [Seguro], [Mora], [Cargos]) VALUES (5, 101332, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, 0)
GO
SET IDENTITY_INSERT [dbo].[TAtrasos] OFF
GO
SET IDENTITY_INSERT [dbo].[TClasePrestamos] ON 

GO
INSERT [dbo].[TClasePrestamos] ([IdClasePrestamo], [Descripcion]) VALUES (1, N'PRESTAMOS COMERVIALES')
GO
INSERT [dbo].[TClasePrestamos] ([IdClasePrestamo], [Descripcion]) VALUES (2, N'PRESTAMOS HIPOTECARIOS')
GO
SET IDENTITY_INSERT [dbo].[TClasePrestamos] OFF
GO
SET IDENTITY_INSERT [dbo].[TClientes] ON 

GO
INSERT [dbo].[TClientes] ([IdCliente], [NoDocumento], [Nombre], [Apellido], [Apodo], [Sexo], [EstadoCivil], [FechaNacimiento], [Celular], [Telefono], [Email], [Direccion], [EstadoCliente], [CodigoCliente], [IdUsuario], [Fecha], [Hora], [IdSucursal]) VALUES (1, N'058-0035804-5', N'JUAN RAMON ', N'MIGUEL GONZALEZ', N'ANYELO', N'HOMBRE', N'UNION LIBRE', CAST(N'1995-01-05' AS Date), N'(809)205-0534', N'809-587-0000', N'JUAN1995@GMAIL.COM', N'C/ PEDRO MARIA GOMEZ NO. S/N, SECTOR LA CANCHA,CASTILLO, PROV. DUARTE, RD.', 1, 100000, 0, CAST(N'2020-03-25' AS Date), N'18:13:47 Actualización', 1)
GO
INSERT [dbo].[TClientes] ([IdCliente], [NoDocumento], [Nombre], [Apellido], [Apodo], [Sexo], [EstadoCivil], [FechaNacimiento], [Celular], [Telefono], [Email], [Direccion], [EstadoCliente], [CodigoCliente], [IdUsuario], [Fecha], [Hora], [IdSucursal]) VALUES (2, N'059-0000000-0', N'PENIEL EMMANUEL', N'CASTRO HERNANDEZ', N'CASPEN 01', N'HOMBRE', N'UNION LIBRE', CAST(N'1990-01-21' AS Date), N'(809)888-8888', N'809-587-8888', N'CASPEN@GMAIL.COM', N'VILLA RIVA', 0, 100001, 0, CAST(N'2020-04-04' AS Date), N'11:13:02 Actualización', 1)
GO
INSERT [dbo].[TClientes] ([IdCliente], [NoDocumento], [Nombre], [Apellido], [Apodo], [Sexo], [EstadoCivil], [FechaNacimiento], [Celular], [Telefono], [Email], [Direccion], [EstadoCliente], [CodigoCliente], [IdUsuario], [Fecha], [Hora], [IdSucursal]) VALUES (3, N'058-8888888-8', N'ESMERALDA', N'REYES', N'EME', N'MUJER', N'SOLTERO', CAST(N'1991-03-18' AS Date), N'(809)000-0000', N'809-000-0000', N'', N'COTUI, RD', 1, 100002, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[TClientes] ([IdCliente], [NoDocumento], [Nombre], [Apellido], [Apodo], [Sexo], [EstadoCivil], [FechaNacimiento], [Celular], [Telefono], [Email], [Direccion], [EstadoCliente], [CodigoCliente], [IdUsuario], [Fecha], [Hora], [IdSucursal]) VALUES (7, N'058-0035804-2', N'ISAAC ', N'MIGUEL TIFA', N'ISAAC', N'HOMBRE', N'SOLTERO', CAST(N'2020-01-05' AS Date), N'(809)999-9999', N'809-999-9999', N'', N'CASTILLO', 0, 622871, 0, CAST(N'2020-03-27' AS Date), N'19:44:39 Actualización', 1)
GO
INSERT [dbo].[TClientes] ([IdCliente], [NoDocumento], [Nombre], [Apellido], [Apodo], [Sexo], [EstadoCivil], [FechaNacimiento], [Celular], [Telefono], [Email], [Direccion], [EstadoCliente], [CodigoCliente], [IdUsuario], [Fecha], [Hora], [IdSucursal]) VALUES (8, N'402-3333333-3', N'KATIANNY', N'MIGUEL TIFA', N'KATY', N'MUJER', N'SOLTERO', CAST(N'2020-01-05' AS Date), N'(232)222-2222', N'232-222-2222', N'KATY@GMAIL.COM', N'C/ SANCHEZ MO. 25, CASTILLO', 0, 978006, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[TClientes] ([IdCliente], [NoDocumento], [Nombre], [Apellido], [Apodo], [Sexo], [EstadoCivil], [FechaNacimiento], [Celular], [Telefono], [Email], [Direccion], [EstadoCliente], [CodigoCliente], [IdUsuario], [Fecha], [Hora], [IdSucursal]) VALUES (9, N'876-5433333-3', N'ESMERLINA', N'MIGUEL', N'ESMERLIN', N'MUJER', N'SOLTERO', CAST(N'2018-03-12' AS Date), N'(809)111-1111', N'809-111-3333', N'ESMERLINA@GMAIL.COM', N'C/ 27 DE FEBRERO NO. 45, VILLA RIVA, PROV DUARTE, RD.', 1, 247011, 0, CAST(N'2020-04-14' AS Date), N'20:05:23 Actualización', 1)
GO
INSERT [dbo].[TClientes] ([IdCliente], [NoDocumento], [Nombre], [Apellido], [Apodo], [Sexo], [EstadoCivil], [FechaNacimiento], [Celular], [Telefono], [Email], [Direccion], [EstadoCliente], [CodigoCliente], [IdUsuario], [Fecha], [Hora], [IdSucursal]) VALUES (11, N'058-3333333-3', N'ORQUIDEA', N'GONZALEZ', N'', N'MUJER', N'UNION LIBRE', CAST(N'1980-03-12' AS Date), N'(111)111-1111', N'   -   -', N'', N'VILLA RIVA', 0, 163478, 0, CAST(N'2020-04-17' AS Date), N'20:07:35 Actualización', 1)
GO
INSERT [dbo].[TClientes] ([IdCliente], [NoDocumento], [Nombre], [Apellido], [Apodo], [Sexo], [EstadoCivil], [FechaNacimiento], [Celular], [Telefono], [Email], [Direccion], [EstadoCliente], [CodigoCliente], [IdUsuario], [Fecha], [Hora], [IdSucursal]) VALUES (12, N'056-0000000-0', N'MARIA ', N'ROSARIO', N'MARY', N'MUJER', N'CASADO', CAST(N'1980-01-10' AS Date), N'(809)056-0000', N'809-056-0000', N'MARIA056@GMAIL.COM', N'C/ INDEPENDENCIA NO. 01, VILLA RIVA, PROV. DUARTE, RD.', 1, 281265, 0, CAST(N'2020-04-14' AS Date), N'14:27:22 Inserción', 1)
GO
INSERT [dbo].[TClientes] ([IdCliente], [NoDocumento], [Nombre], [Apellido], [Apodo], [Sexo], [EstadoCivil], [FechaNacimiento], [Celular], [Telefono], [Email], [Direccion], [EstadoCliente], [CodigoCliente], [IdUsuario], [Fecha], [Hora], [IdSucursal]) VALUES (13, N'057-0000000-0', N'ANA', N'ROSARIO', N'ANA', N'MUJER', N'CASADO', CAST(N'1975-05-09' AS Date), N'(809)747-2437', N'809-747-2437', N'', N'C/ PEDRO MARIA GOMEZ NO. 74, CASTILLO, PROV. DUARTE, RD.', 1, 684624, 0, CAST(N'2020-04-14' AS Date), N'14:31:49 Inserción', 1)
GO
INSERT [dbo].[TClientes] ([IdCliente], [NoDocumento], [Nombre], [Apellido], [Apodo], [Sexo], [EstadoCivil], [FechaNacimiento], [Celular], [Telefono], [Email], [Direccion], [EstadoCliente], [CodigoCliente], [IdUsuario], [Fecha], [Hora], [IdSucursal]) VALUES (14, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[TClientes] OFF
GO
SET IDENTITY_INSERT [dbo].[TCobros] ON 

GO
INSERT [dbo].[TCobros] ([IdCobro], [CodigoPrestamo], [FechaCobro], [HoraCobro], [CodigoRecibo], [ConceptoCobro], [IdUsuario], [IdSucursal], [EstadoCobro], [IdDistribucion]) VALUES (10, 439851, CAST(N'2020-04-25' AS Date), N'21:35:34', N'CR-780706', N'ABONO A CUOTA', 0, 1, 1, 1)
GO
SET IDENTITY_INSERT [dbo].[TCobros] OFF
GO
SET IDENTITY_INSERT [dbo].[TDatosLaborables] ON 

GO
INSERT [dbo].[TDatosLaborables] ([IdDatosLaborables], [Empresa], [TelefonoEmp], [DireccionEmp], [Cargo], [TiempoLaborando], [Sueldo], [OtroIngresos], [DetalleOtroIngresos], [UtilidadNeta], [CodigoCliente], [Gastos]) VALUES (1, N'RUMAR SRL', N'809-333-0000', N'C/ 27 DE FEBRERO, VILLA RIVA', N'GESTOR DE NEGOCIOS', N'2 AÑOS', CAST(17500.00 AS Decimal(18, 2)), CAST(5000.00 AS Decimal(18, 2)), N'SOLUCSOFTW', CAST(20500.00 AS Decimal(18, 2)), 100000, CAST(2000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[TDatosLaborables] ([IdDatosLaborables], [Empresa], [TelefonoEmp], [DireccionEmp], [Cargo], [TiempoLaborando], [Sueldo], [OtroIngresos], [DetalleOtroIngresos], [UtilidadNeta], [CodigoCliente], [Gastos]) VALUES (2, N'RUAMAR', N'809-587-9999', N'VILLA RIVA', N'MENSAJERO', N'1 AÑO', CAST(17600.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), N'', CAST(17600.00 AS Decimal(18, 2)), 100001, CAST(0.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[TDatosLaborables] ([IdDatosLaborables], [Empresa], [TelefonoEmp], [DireccionEmp], [Cargo], [TiempoLaborando], [Sueldo], [OtroIngresos], [DetalleOtroIngresos], [UtilidadNeta], [CodigoCliente], [Gastos]) VALUES (3, N'RESIDENCIAL MAMI', N'   -   -', N'COUIT', N'EMPLEADA DOMESTICA', N'1 AÑO', CAST(8000.00 AS Decimal(18, 2)), CAST(3000.00 AS Decimal(18, 2)), N'PENSION DE UN HIJO', CAST(11000.00 AS Decimal(18, 2)), 100002, CAST(0.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[TDatosLaborables] ([IdDatosLaborables], [Empresa], [TelefonoEmp], [DireccionEmp], [Cargo], [TiempoLaborando], [Sueldo], [OtroIngresos], [DetalleOtroIngresos], [UtilidadNeta], [CodigoCliente], [Gastos]) VALUES (4, N'CLARO ', N'809-999-9999', N'SFM', N'AGENTE DE VENTAS', N'3 MESES', CAST(15000.00 AS Decimal(18, 2)), CAST(5000.00 AS Decimal(18, 2)), N'COMISION', CAST(20000.00 AS Decimal(18, 2)), 778668, CAST(0.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[TDatosLaborables] ([IdDatosLaborables], [Empresa], [TelefonoEmp], [DireccionEmp], [Cargo], [TiempoLaborando], [Sueldo], [OtroIngresos], [DetalleOtroIngresos], [UtilidadNeta], [CodigoCliente], [Gastos]) VALUES (5, N'EASDVC', N'   -   -', N'', N'EWSDA', N'6 MESES', CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), N'', CAST(0.00 AS Decimal(18, 2)), 670325, CAST(0.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[TDatosLaborables] ([IdDatosLaborables], [Empresa], [TelefonoEmp], [DireccionEmp], [Cargo], [TiempoLaborando], [Sueldo], [OtroIngresos], [DetalleOtroIngresos], [UtilidadNeta], [CodigoCliente], [Gastos]) VALUES (6, N'KHJ', N'   -   -', N'', N'.KHMIJ,', N'3 AÑOS', CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), N'', CAST(0.00 AS Decimal(18, 2)), 554391, CAST(0.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[TDatosLaborables] ([IdDatosLaborables], [Empresa], [TelefonoEmp], [DireccionEmp], [Cargo], [TiempoLaborando], [Sueldo], [OtroIngresos], [DetalleOtroIngresos], [UtilidadNeta], [CodigoCliente], [Gastos]) VALUES (7, N'BAN RESERVAS', N'   -   -', N'VILLA RIVA', N'GERENTE', N'5 AÑOS O MAS', CAST(60000.00 AS Decimal(18, 2)), CAST(15000.00 AS Decimal(18, 2)), N'SOLUCSOFTW', CAST(70000.00 AS Decimal(18, 2)), 622871, CAST(5000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[TDatosLaborables] ([IdDatosLaborables], [Empresa], [TelefonoEmp], [DireccionEmp], [Cargo], [TiempoLaborando], [Sueldo], [OtroIngresos], [DetalleOtroIngresos], [UtilidadNeta], [CodigoCliente], [Gastos]) VALUES (8, N'POPULAR', N'212-222-2222', N'', N'GERENTE', N'5 AÑOS O MAS', CAST(45000.00 AS Decimal(18, 2)), CAST(10000.00 AS Decimal(18, 2)), N'SOLUCSOFTW', CAST(55000.00 AS Decimal(18, 2)), 978006, CAST(8000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[TDatosLaborables] ([IdDatosLaborables], [Empresa], [TelefonoEmp], [DireccionEmp], [Cargo], [TiempoLaborando], [Sueldo], [OtroIngresos], [DetalleOtroIngresos], [UtilidadNeta], [CodigoCliente], [Gastos]) VALUES (9, N'NORDESTANA', N'809-333-3333', N'SAN FRANCISCO DE MACORI.', N'GERENTE DE TECNOLOGIA', N'4 AÑOS O MAS', CAST(40000.00 AS Decimal(18, 2)), CAST(90000.00 AS Decimal(18, 2)), N'RENTA DE APARTAMENTOS', CAST(109500.00 AS Decimal(18, 2)), 247011, CAST(20500.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[TDatosLaborables] ([IdDatosLaborables], [Empresa], [TelefonoEmp], [DireccionEmp], [Cargo], [TiempoLaborando], [Sueldo], [OtroIngresos], [DetalleOtroIngresos], [UtilidadNeta], [CodigoCliente], [Gastos]) VALUES (11, N'EDUCACION', N'   -   -', N'', N'MAESTRA', N'5 AÑOS O MAS', CAST(55000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), N'', CAST(55000.00 AS Decimal(18, 2)), 163478, CAST(0.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[TDatosLaborables] ([IdDatosLaborables], [Empresa], [TelefonoEmp], [DireccionEmp], [Cargo], [TiempoLaborando], [Sueldo], [OtroIngresos], [DetalleOtroIngresos], [UtilidadNeta], [CodigoCliente], [Gastos]) VALUES (12, N'HELADO BOM', N'809-111-1111', N'', N'SUPERVISORA', N'4 AÑOS O MAS', CAST(14000.00 AS Decimal(18, 2)), CAST(5000.00 AS Decimal(18, 2)), N'MANUTENCION DE UN HIJO', CAST(16000.00 AS Decimal(18, 2)), 281265, CAST(3000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[TDatosLaborables] ([IdDatosLaborables], [Empresa], [TelefonoEmp], [DireccionEmp], [Cargo], [TiempoLaborando], [Sueldo], [OtroIngresos], [DetalleOtroIngresos], [UtilidadNeta], [CodigoCliente], [Gastos]) VALUES (13, N'VENTA DE ESPECIA NANAO', N'809-000-0932', N'CASTILLO', N'EMPACADORA', N'6 MESES', CAST(10000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), N'', CAST(8500.00 AS Decimal(18, 2)), 684624, CAST(1500.00 AS Decimal(18, 2)))
GO
SET IDENTITY_INSERT [dbo].[TDatosLaborables] OFF
GO
SET IDENTITY_INSERT [dbo].[TDetalleCobros] ON 

GO
INSERT [dbo].[TDetalleCobros] ([IdDetalleCobro], [CodigoRecibo], [Capital], [Interes], [Comision], [Seguro], [Mora], [Cargo]) VALUES (10, N'CR-780706', 8120, CAST(1700.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 180, 0)
GO
SET IDENTITY_INSERT [dbo].[TDetalleCobros] OFF
GO
SET IDENTITY_INSERT [dbo].[TDetalleSolicitudes] ON 

GO
INSERT [dbo].[TDetalleSolicitudes] ([IdDetalleSolicitud], [CodigoSolicitud], [NoCuota], [FechaPago], [Capital], [Interes], [Comision], [Seguro], [ValorCuota]) VALUES (86, 925579, 1, CAST(N'2020-06-01' AS Date), 12390, CAST(850.00 AS Decimal(18, 2)), CAST(85.00 AS Decimal(18, 2)), CAST(42.50 AS Decimal(18, 2)), 13367)
GO
INSERT [dbo].[TDetalleSolicitudes] ([IdDetalleSolicitud], [CodigoSolicitud], [NoCuota], [FechaPago], [Capital], [Interes], [Comision], [Seguro], [ValorCuota]) VALUES (87, 925579, 2, CAST(N'2020-07-01' AS Date), 12627, CAST(643.51 AS Decimal(18, 2)), CAST(64.35 AS Decimal(18, 2)), CAST(32.18 AS Decimal(18, 2)), 13367)
GO
INSERT [dbo].[TDetalleSolicitudes] ([IdDetalleSolicitud], [CodigoSolicitud], [NoCuota], [FechaPago], [Capital], [Interes], [Comision], [Seguro], [ValorCuota]) VALUES (88, 925579, 3, CAST(N'2020-08-01' AS Date), 12869, CAST(433.06 AS Decimal(18, 2)), CAST(43.31 AS Decimal(18, 2)), CAST(21.65 AS Decimal(18, 2)), 13367)
GO
INSERT [dbo].[TDetalleSolicitudes] ([IdDetalleSolicitud], [CodigoSolicitud], [NoCuota], [FechaPago], [Capital], [Interes], [Comision], [Seguro], [ValorCuota]) VALUES (89, 925579, 4, CAST(N'2020-09-01' AS Date), 13115, CAST(219.65 AS Decimal(18, 2)), CAST(21.86 AS Decimal(18, 2)), CAST(10.93 AS Decimal(18, 2)), 13367)
GO
INSERT [dbo].[TDetalleSolicitudes] ([IdDetalleSolicitud], [CodigoSolicitud], [NoCuota], [FechaPago], [Capital], [Interes], [Comision], [Seguro], [ValorCuota]) VALUES (90, 101332, 1, CAST(N'2020-04-14' AS Date), 3207, CAST(784.33 AS Decimal(18, 2)), CAST(120.67 AS Decimal(18, 2)), CAST(60.33 AS Decimal(18, 2)), 4172)
GO
INSERT [dbo].[TDetalleSolicitudes] ([IdDetalleSolicitud], [CodigoSolicitud], [NoCuota], [FechaPago], [Capital], [Interes], [Comision], [Seguro], [ValorCuota]) VALUES (91, 101332, 2, CAST(N'2020-05-14' AS Date), 3292, CAST(714.86 AS Decimal(18, 2)), CAST(109.98 AS Decimal(18, 2)), CAST(54.99 AS Decimal(18, 2)), 4172)
GO
INSERT [dbo].[TDetalleSolicitudes] ([IdDetalleSolicitud], [CodigoSolicitud], [NoCuota], [FechaPago], [Capital], [Interes], [Comision], [Seguro], [ValorCuota]) VALUES (92, 101332, 3, CAST(N'2020-06-14' AS Date), 3380, CAST(643.53 AS Decimal(18, 2)), CAST(99.00 AS Decimal(18, 2)), CAST(49.50 AS Decimal(18, 2)), 4172)
GO
INSERT [dbo].[TDetalleSolicitudes] ([IdDetalleSolicitud], [CodigoSolicitud], [NoCuota], [FechaPago], [Capital], [Interes], [Comision], [Seguro], [ValorCuota]) VALUES (93, 101332, 4, CAST(N'2020-07-14' AS Date), 3470, CAST(570.29 AS Decimal(18, 2)), CAST(87.74 AS Decimal(18, 2)), CAST(43.87 AS Decimal(18, 2)), 4172)
GO
INSERT [dbo].[TDetalleSolicitudes] ([IdDetalleSolicitud], [CodigoSolicitud], [NoCuota], [FechaPago], [Capital], [Interes], [Comision], [Seguro], [ValorCuota]) VALUES (94, 101332, 5, CAST(N'2020-08-14' AS Date), 3563, CAST(495.11 AS Decimal(18, 2)), CAST(76.17 AS Decimal(18, 2)), CAST(38.09 AS Decimal(18, 2)), 4172)
GO
INSERT [dbo].[TDetalleSolicitudes] ([IdDetalleSolicitud], [CodigoSolicitud], [NoCuota], [FechaPago], [Capital], [Interes], [Comision], [Seguro], [ValorCuota]) VALUES (95, 101332, 6, CAST(N'2020-09-14' AS Date), 3658, CAST(417.92 AS Decimal(18, 2)), CAST(64.29 AS Decimal(18, 2)), CAST(32.15 AS Decimal(18, 2)), 4172)
GO
INSERT [dbo].[TDetalleSolicitudes] ([IdDetalleSolicitud], [CodigoSolicitud], [NoCuota], [FechaPago], [Capital], [Interes], [Comision], [Seguro], [ValorCuota]) VALUES (96, 101332, 7, CAST(N'2020-10-14' AS Date), 3755, CAST(338.67 AS Decimal(18, 2)), CAST(52.10 AS Decimal(18, 2)), CAST(26.05 AS Decimal(18, 2)), 4172)
GO
INSERT [dbo].[TDetalleSolicitudes] ([IdDetalleSolicitud], [CodigoSolicitud], [NoCuota], [FechaPago], [Capital], [Interes], [Comision], [Seguro], [ValorCuota]) VALUES (97, 101332, 8, CAST(N'2020-11-14' AS Date), 3855, CAST(257.31 AS Decimal(18, 2)), CAST(39.59 AS Decimal(18, 2)), CAST(19.79 AS Decimal(18, 2)), 4172)
GO
INSERT [dbo].[TDetalleSolicitudes] ([IdDetalleSolicitud], [CodigoSolicitud], [NoCuota], [FechaPago], [Capital], [Interes], [Comision], [Seguro], [ValorCuota]) VALUES (98, 101332, 9, CAST(N'2020-12-14' AS Date), 3958, CAST(173.77 AS Decimal(18, 2)), CAST(26.73 AS Decimal(18, 2)), CAST(13.37 AS Decimal(18, 2)), 4172)
GO
INSERT [dbo].[TDetalleSolicitudes] ([IdDetalleSolicitud], [CodigoSolicitud], [NoCuota], [FechaPago], [Capital], [Interes], [Comision], [Seguro], [ValorCuota]) VALUES (99, 101332, 10, CAST(N'2021-01-14' AS Date), 4062, CAST(89.49 AS Decimal(18, 2)), CAST(13.54 AS Decimal(18, 2)), CAST(6.77 AS Decimal(18, 2)), 4172)
GO
INSERT [dbo].[TDetalleSolicitudes] ([IdDetalleSolicitud], [CodigoSolicitud], [NoCuota], [FechaPago], [Capital], [Interes], [Comision], [Seguro], [ValorCuota]) VALUES (100, 658910, 1, CAST(N'2020-05-01' AS Date), 49274, CAST(3060.00 AS Decimal(18, 2)), CAST(765.00 AS Decimal(18, 2)), CAST(382.50 AS Decimal(18, 2)), 53482)
GO
INSERT [dbo].[TDetalleSolicitudes] ([IdDetalleSolicitud], [CodigoSolicitud], [NoCuota], [FechaPago], [Capital], [Interes], [Comision], [Seguro], [ValorCuota]) VALUES (101, 658910, 2, CAST(N'2020-06-01' AS Date), 49952, CAST(2567.26 AS Decimal(18, 2)), CAST(641.81 AS Decimal(18, 2)), CAST(320.91 AS Decimal(18, 2)), 53482)
GO
INSERT [dbo].[TDetalleSolicitudes] ([IdDetalleSolicitud], [CodigoSolicitud], [NoCuota], [FechaPago], [Capital], [Interes], [Comision], [Seguro], [ValorCuota]) VALUES (102, 658910, 3, CAST(N'2020-07-01' AS Date), 50639, CAST(2067.73 AS Decimal(18, 2)), CAST(516.93 AS Decimal(18, 2)), CAST(258.47 AS Decimal(18, 2)), 53482)
GO
INSERT [dbo].[TDetalleSolicitudes] ([IdDetalleSolicitud], [CodigoSolicitud], [NoCuota], [FechaPago], [Capital], [Interes], [Comision], [Seguro], [ValorCuota]) VALUES (103, 658910, 4, CAST(N'2020-08-01' AS Date), 51335, CAST(1561.35 AS Decimal(18, 2)), CAST(390.34 AS Decimal(18, 2)), CAST(195.17 AS Decimal(18, 2)), 53482)
GO
INSERT [dbo].[TDetalleSolicitudes] ([IdDetalleSolicitud], [CodigoSolicitud], [NoCuota], [FechaPago], [Capital], [Interes], [Comision], [Seguro], [ValorCuota]) VALUES (104, 658910, 5, CAST(N'2020-09-01' AS Date), 52041, CAST(1047.99 AS Decimal(18, 2)), CAST(262.00 AS Decimal(18, 2)), CAST(131.00 AS Decimal(18, 2)), 53482)
GO
INSERT [dbo].[TDetalleSolicitudes] ([IdDetalleSolicitud], [CodigoSolicitud], [NoCuota], [FechaPago], [Capital], [Interes], [Comision], [Seguro], [ValorCuota]) VALUES (105, 658910, 6, CAST(N'2020-10-01' AS Date), 52758, CAST(525.69 AS Decimal(18, 2)), CAST(131.90 AS Decimal(18, 2)), CAST(65.95 AS Decimal(18, 2)), 53482)
GO
INSERT [dbo].[TDetalleSolicitudes] ([IdDetalleSolicitud], [CodigoSolicitud], [NoCuota], [FechaPago], [Capital], [Interes], [Comision], [Seguro], [ValorCuota]) VALUES (106, 205860, 1, CAST(N'2020-06-10' AS Date), 167614, CAST(5950.00 AS Decimal(18, 2)), CAST(850.00 AS Decimal(18, 2)), CAST(425.00 AS Decimal(18, 2)), 174839)
GO
INSERT [dbo].[TDetalleSolicitudes] ([IdDetalleSolicitud], [CodigoSolicitud], [NoCuota], [FechaPago], [Capital], [Interes], [Comision], [Seguro], [ValorCuota]) VALUES (107, 205860, 2, CAST(N'2020-07-10' AS Date), 169989, CAST(3994.50 AS Decimal(18, 2)), CAST(570.64 AS Decimal(18, 2)), CAST(285.32 AS Decimal(18, 2)), 174839)
GO
INSERT [dbo].[TDetalleSolicitudes] ([IdDetalleSolicitud], [CodigoSolicitud], [NoCuota], [FechaPago], [Capital], [Interes], [Comision], [Seguro], [ValorCuota]) VALUES (108, 205860, 3, CAST(N'2020-08-10' AS Date), 172397, CAST(2010.55 AS Decimal(18, 2)), CAST(287.33 AS Decimal(18, 2)), CAST(143.66 AS Decimal(18, 2)), 174839)
GO
INSERT [dbo].[TDetalleSolicitudes] ([IdDetalleSolicitud], [CodigoSolicitud], [NoCuota], [FechaPago], [Capital], [Interes], [Comision], [Seguro], [ValorCuota]) VALUES (109, 439851, 1, CAST(N'2020-04-16' AS Date), 12025, CAST(1700.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 13725)
GO
INSERT [dbo].[TDetalleSolicitudes] ([IdDetalleSolicitud], [CodigoSolicitud], [NoCuota], [FechaPago], [Capital], [Interes], [Comision], [Seguro], [ValorCuota]) VALUES (110, 439851, 2, CAST(N'2020-05-01' AS Date), 12225, CAST(1499.58 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 13725)
GO
INSERT [dbo].[TDetalleSolicitudes] ([IdDetalleSolicitud], [CodigoSolicitud], [NoCuota], [FechaPago], [Capital], [Interes], [Comision], [Seguro], [ValorCuota]) VALUES (111, 439851, 3, CAST(N'2020-05-16' AS Date), 12429, CAST(1295.83 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 13725)
GO
INSERT [dbo].[TDetalleSolicitudes] ([IdDetalleSolicitud], [CodigoSolicitud], [NoCuota], [FechaPago], [Capital], [Interes], [Comision], [Seguro], [ValorCuota]) VALUES (112, 439851, 4, CAST(N'2020-05-31' AS Date), 12636, CAST(1088.67 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 13725)
GO
INSERT [dbo].[TDetalleSolicitudes] ([IdDetalleSolicitud], [CodigoSolicitud], [NoCuota], [FechaPago], [Capital], [Interes], [Comision], [Seguro], [ValorCuota]) VALUES (113, 439851, 5, CAST(N'2020-06-15' AS Date), 12847, CAST(878.07 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 13725)
GO
INSERT [dbo].[TDetalleSolicitudes] ([IdDetalleSolicitud], [CodigoSolicitud], [NoCuota], [FechaPago], [Capital], [Interes], [Comision], [Seguro], [ValorCuota]) VALUES (114, 439851, 6, CAST(N'2020-06-30' AS Date), 13061, CAST(663.95 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 13725)
GO
INSERT [dbo].[TDetalleSolicitudes] ([IdDetalleSolicitud], [CodigoSolicitud], [NoCuota], [FechaPago], [Capital], [Interes], [Comision], [Seguro], [ValorCuota]) VALUES (115, 439851, 7, CAST(N'2020-07-15' AS Date), 13279, CAST(446.27 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 13725)
GO
INSERT [dbo].[TDetalleSolicitudes] ([IdDetalleSolicitud], [CodigoSolicitud], [NoCuota], [FechaPago], [Capital], [Interes], [Comision], [Seguro], [ValorCuota]) VALUES (116, 439851, 8, CAST(N'2020-07-30' AS Date), 13497, CAST(227.63 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 13725)
GO
SET IDENTITY_INSERT [dbo].[TDetalleSolicitudes] OFF
GO
SET IDENTITY_INSERT [dbo].[TDistribucionPagos] ON 

GO
INSERT [dbo].[TDistribucionPagos] ([IdDistribucion], [Descripcion]) VALUES (1, N'AUTOMÁTICA')
GO
INSERT [dbo].[TDistribucionPagos] ([IdDistribucion], [Descripcion]) VALUES (2, N'MANUAL ')
GO
SET IDENTITY_INSERT [dbo].[TDistribucionPagos] OFF
GO
SET IDENTITY_INSERT [dbo].[TEmpresas] ON 

GO
INSERT [dbo].[TEmpresas] ([IdEmpresa], [NombreEP], [RncEM], [LemaEM]) VALUES (1, N'PRESTAMOS SOLUCSOFTW', N'RNC : 401011000', N'PRESTAMOS PARA TU SOLUCION')
GO
SET IDENTITY_INSERT [dbo].[TEmpresas] OFF
GO
SET IDENTITY_INSERT [dbo].[TEstadoCuotas] ON 

GO
INSERT [dbo].[TEstadoCuotas] ([IdEstadoCuota], [DescripcionEC]) VALUES (1, N'VIGENTE')
GO
INSERT [dbo].[TEstadoCuotas] ([IdEstadoCuota], [DescripcionEC]) VALUES (2, N'VENCIDA')
GO
INSERT [dbo].[TEstadoCuotas] ([IdEstadoCuota], [DescripcionEC]) VALUES (3, N'PAGADA')
GO
SET IDENTITY_INSERT [dbo].[TEstadoCuotas] OFF
GO
SET IDENTITY_INSERT [dbo].[TEstadoPrestamos] ON 

GO
INSERT [dbo].[TEstadoPrestamos] ([IdEstadoPrestamo], [DescripcionEp]) VALUES (1, N'EN PROCESO')
GO
INSERT [dbo].[TEstadoPrestamos] ([IdEstadoPrestamo], [DescripcionEp]) VALUES (2, N'VIGETE')
GO
INSERT [dbo].[TEstadoPrestamos] ([IdEstadoPrestamo], [DescripcionEp]) VALUES (3, N'SALDO')
GO
INSERT [dbo].[TEstadoPrestamos] ([IdEstadoPrestamo], [DescripcionEp]) VALUES (4, N'CASTIGADO')
GO
SET IDENTITY_INSERT [dbo].[TEstadoPrestamos] OFF
GO
SET IDENTITY_INSERT [dbo].[TEstadoSolicitudes] ON 

GO
INSERT [dbo].[TEstadoSolicitudes] ([IdEstadoSolicitud], [DescripcionES]) VALUES (1, N'PENDIENTE DE APROBACION')
GO
INSERT [dbo].[TEstadoSolicitudes] ([IdEstadoSolicitud], [DescripcionES]) VALUES (2, N'PENDIENTE DE CORRECCION')
GO
INSERT [dbo].[TEstadoSolicitudes] ([IdEstadoSolicitud], [DescripcionES]) VALUES (3, N'APROBADA')
GO
INSERT [dbo].[TEstadoSolicitudes] ([IdEstadoSolicitud], [DescripcionES]) VALUES (4, N'RECHAZADA')
GO
SET IDENTITY_INSERT [dbo].[TEstadoSolicitudes] OFF
GO
SET IDENTITY_INSERT [dbo].[TFormaPagos] ON 

GO
INSERT [dbo].[TFormaPagos] ([IdFormaPago], [DescripcionFP]) VALUES (1, N'MENSUAL')
GO
INSERT [dbo].[TFormaPagos] ([IdFormaPago], [DescripcionFP]) VALUES (2, N'QUINCENAL')
GO
INSERT [dbo].[TFormaPagos] ([IdFormaPago], [DescripcionFP]) VALUES (3, N'SEMANAL')
GO
SET IDENTITY_INSERT [dbo].[TFormaPagos] OFF
GO
SET IDENTITY_INSERT [dbo].[TGarantiaEconomica] ON 

GO
INSERT [dbo].[TGarantiaEconomica] ([IdGarantiaE], [CodigoGarantia], [NombreGE], [DescripcionGE], [MatriculaOTituloGE], [ValorEstimadoGE], [CodigoCliente], [Fecha], [Hora], [IdUsuario]) VALUES (1, 101010, N'CARRO BMW', N'1-NUMERO DE PLACA: A898900. 2-CHASIS: SNA20201789. 3-ESTADO: ACTIVO. 4-TIPO DE VEHICULO: AUTOMOVIL PRIVADO.  5-MARCA: VMW. 6-MODELO: PLUS. 7- AÑO: 2010. 8-PASAGEROS: 5.  9-A NOMBRE DE: ISAAC  MIGUEL TIFA', 1, CAST(650000.00 AS Decimal(18, 2)), 622871, CAST(N'2020-03-26' AS Date), N'06:43:10 Inserción', 0)
GO
INSERT [dbo].[TGarantiaEconomica] ([IdGarantiaE], [CodigoGarantia], [NombreGE], [DescripcionGE], [MatriculaOTituloGE], [ValorEstimadoGE], [CodigoCliente], [Fecha], [Hora], [IdUsuario]) VALUES (2, 249001, N'UNA CASA NUEVA CON DISEÑOS MODERNOS', N'1- MATRICULA: 0202803454. 2- PARCELA: 220-B CD 05. 3-TITULAR: ESMERLINA MIGUEL', 1, CAST(3500000.00 AS Decimal(18, 2)), 247011, CAST(N'2020-04-14' AS Date), N'07:55:35 Inserción', 0)
GO
INSERT [dbo].[TGarantiaEconomica] ([IdGarantiaE], [CodigoGarantia], [NombreGE], [DescripcionGE], [MatriculaOTituloGE], [ValorEstimadoGE], [CodigoCliente], [Fecha], [Hora], [IdUsuario]) VALUES (3, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[TGarantiaEconomica] OFF
GO
SET IDENTITY_INSERT [dbo].[TGestores] ON 

GO
INSERT [dbo].[TGestores] ([IdGestor], [Nombre]) VALUES (1, N'GENERAL')
GO
INSERT [dbo].[TGestores] ([IdGestor], [Nombre]) VALUES (2, N'JUAN MIGUEL')
GO
INSERT [dbo].[TGestores] ([IdGestor], [Nombre]) VALUES (3, N'PENIEL CASTRO')
GO
INSERT [dbo].[TGestores] ([IdGestor], [Nombre]) VALUES (4, N'RAMON MIGUEL')
GO
INSERT [dbo].[TGestores] ([IdGestor], [Nombre]) VALUES (5, N'ROLDAN LOPEZ')
GO
INSERT [dbo].[TGestores] ([IdGestor], [Nombre]) VALUES (6, N'JOSE HERNNADEZ ')
GO
SET IDENTITY_INSERT [dbo].[TGestores] OFF
GO
SET IDENTITY_INSERT [dbo].[TNotasSolicitudes] ON 

GO
INSERT [dbo].[TNotasSolicitudes] ([IdNotaSolicitud], [CodigoSolicitud], [IdEstadoSolicitud], [DescripcionNS], [FechaCreacion]) VALUES (2, 439851, 3, N'APROVADA POR EL COMITE.', CAST(N'2020-04-20' AS Date))
GO
INSERT [dbo].[TNotasSolicitudes] ([IdNotaSolicitud], [CodigoSolicitud], [IdEstadoSolicitud], [DescripcionNS], [FechaCreacion]) VALUES (3, 658910, 3, N'APROVADA POR EL COMITE.', CAST(N'2020-04-20' AS Date))
GO
INSERT [dbo].[TNotasSolicitudes] ([IdNotaSolicitud], [CodigoSolicitud], [IdEstadoSolicitud], [DescripcionNS], [FechaCreacion]) VALUES (4, 205860, 3, N'APROVADA POR EL COMITE.', CAST(N'2020-04-20' AS Date))
GO
INSERT [dbo].[TNotasSolicitudes] ([IdNotaSolicitud], [CodigoSolicitud], [IdEstadoSolicitud], [DescripcionNS], [FechaCreacion]) VALUES (5, 925579, 3, N'APROVADA POR EL COMITE.', CAST(N'2020-04-20' AS Date))
GO
INSERT [dbo].[TNotasSolicitudes] ([IdNotaSolicitud], [CodigoSolicitud], [IdEstadoSolicitud], [DescripcionNS], [FechaCreacion]) VALUES (6, 439851, 3, N'APROVADA 2', CAST(N'2020-04-21' AS Date))
GO
INSERT [dbo].[TNotasSolicitudes] ([IdNotaSolicitud], [CodigoSolicitud], [IdEstadoSolicitud], [DescripcionNS], [FechaCreacion]) VALUES (7, 439851, 3, N'RPRUEVA DEL SISTEMA', CAST(N'2020-04-21' AS Date))
GO
INSERT [dbo].[TNotasSolicitudes] ([IdNotaSolicitud], [CodigoSolicitud], [IdEstadoSolicitud], [DescripcionNS], [FechaCreacion]) VALUES (8, 439851, 3, N'APROVADA POR EL COMITED DE CREDITO.', CAST(N'2020-04-21' AS Date))
GO
SET IDENTITY_INSERT [dbo].[TNotasSolicitudes] OFF
GO
SET IDENTITY_INSERT [dbo].[TReferencias] ON 

GO
INSERT [dbo].[TReferencias] ([IdReferencias], [NombreRef], [Parentesco], [Celular], [Direccion], [CodigoCliente]) VALUES (1, N'KATHERINE TIFA', N'ESPOSO (A)', N'(809)000-1111', N'CASTILLO', 100000)
GO
INSERT [dbo].[TReferencias] ([IdReferencias], [NombreRef], [Parentesco], [Celular], [Direccion], [CodigoCliente]) VALUES (2, N'RAMON GONZALEZ ', N'HERMANO (A)', N'(809)888-5544', N'VILLA RIVA', 100000)
GO
INSERT [dbo].[TReferencias] ([IdReferencias], [NombreRef], [Parentesco], [Celular], [Direccion], [CodigoCliente]) VALUES (3, N'VIANKARLY JIMENEZ', N'ESPOSO (A)', N'(809)999-3399', N'VILLA RIVA', 100001)
GO
INSERT [dbo].[TReferencias] ([IdReferencias], [NombreRef], [Parentesco], [Celular], [Direccion], [CodigoCliente]) VALUES (4, N'EMMANUEL POLANCO', N'PRIMO (A)', N'(089)333-3333', N'VILLA RIVA, PROV. DUARTE, RD.', 100002)
GO
INSERT [dbo].[TReferencias] ([IdReferencias], [NombreRef], [Parentesco], [Celular], [Direccion], [CodigoCliente]) VALUES (6, N'ANUEL VASQUEZ', N'ESPOSO (A)', N'(000)000-0000', N'VILLA RIVA', 100002)
GO
INSERT [dbo].[TReferencias] ([IdReferencias], [NombreRef], [Parentesco], [Celular], [Direccion], [CodigoCliente]) VALUES (9, N'JUAN MIGUEL', N'PADRE', N'(809)000-0000', N'CASTILLO', 622871)
GO
INSERT [dbo].[TReferencias] ([IdReferencias], [NombreRef], [Parentesco], [Celular], [Direccion], [CodigoCliente]) VALUES (10, N'KATHERINE TIFA', N'MADRE', N'(809)000-0111', N'CASTILLO', 622871)
GO
INSERT [dbo].[TReferencias] ([IdReferencias], [NombreRef], [Parentesco], [Celular], [Direccion], [CodigoCliente]) VALUES (11, N'ROBERTO TIFA', N'PADRE', N'(333)333-3333', N'CASTILLO', 978006)
GO
INSERT [dbo].[TReferencias] ([IdReferencias], [NombreRef], [Parentesco], [Celular], [Direccion], [CodigoCliente]) VALUES (12, N'ANA ROSARIO', N'GENERAL', N'(555)555-5555', N'FGHBXDBSFDB', 978006)
GO
INSERT [dbo].[TReferencias] ([IdReferencias], [NombreRef], [Parentesco], [Celular], [Direccion], [CodigoCliente]) VALUES (13, N'ANYELO MIGUEL', N'PADRE', N'(555)555-5555', N'VR', 247011)
GO
INSERT [dbo].[TReferencias] ([IdReferencias], [NombreRef], [Parentesco], [Celular], [Direccion], [CodigoCliente]) VALUES (14, N'YANELLI MORONTA', N'MADRE', N'(444)444-4444', N'CASTILLO', 247011)
GO
INSERT [dbo].[TReferencias] ([IdReferencias], [NombreRef], [Parentesco], [Celular], [Direccion], [CodigoCliente]) VALUES (17, N'JUAN MIGUEL', N'HERMANO (A)', N'(333)333-3333', N'CAST', 839841)
GO
INSERT [dbo].[TReferencias] ([IdReferencias], [NombreRef], [Parentesco], [Celular], [Direccion], [CodigoCliente]) VALUES (18, N'CAROLINA MIGUEL', N'HERMANO (A)', N'(232)333-3333', N'VR', 839841)
GO
INSERT [dbo].[TReferencias] ([IdReferencias], [NombreRef], [Parentesco], [Celular], [Direccion], [CodigoCliente]) VALUES (19, N'JUAN MIGUEL GONZALEZ', N'HERMANO (A)', N'(232)323-222', N'CAST', 163478)
GO
INSERT [dbo].[TReferencias] ([IdReferencias], [NombreRef], [Parentesco], [Celular], [Direccion], [CodigoCliente]) VALUES (20, N'JUANA GONZALEZ', N'MADRE', N'(222)222-2222', N'WECES', 163478)
GO
INSERT [dbo].[TReferencias] ([IdReferencias], [NombreRef], [Parentesco], [Celular], [Direccion], [CodigoCliente]) VALUES (21, N'CAROLINA MIGUEL G', N'HERMANO (A)', N'(235)555-5555', N'VR', 163478)
GO
INSERT [dbo].[TReferencias] ([IdReferencias], [NombreRef], [Parentesco], [Celular], [Direccion], [CodigoCliente]) VALUES (22, N'RAMINO PEREZ', N'ESPOSO (A)', N'(809)748-7457', N'C/ INDEPENDENCIA NO. 01, VILLA RIVA, PROV. DUARTE, RD.', 281265)
GO
INSERT [dbo].[TReferencias] ([IdReferencias], [NombreRef], [Parentesco], [Celular], [Direccion], [CodigoCliente]) VALUES (23, N'KARTHERINE TIFA ROSARIO', N'HIJO (A)', N'(809)988-8888', N'CASTILLO', 684624)
GO
SET IDENTITY_INSERT [dbo].[TReferencias] OFF
GO
SET IDENTITY_INSERT [dbo].[TReportePagos] ON 

GO
INSERT [dbo].[TReportePagos] ([IdReportePago], [CodigoSolicitud], [MontoPrestamo], [CapitalPagado], [InteresPagado], [ComisionPagado], [SeguroPagado], [MoraPagada], [CargosPagado], [SaldoActual], [FechaUltimoPago], [DiasSinPagar], [Estado]) VALUES (1, 658910, 306000, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, 0, 306000, N'', 0, 1)
GO
INSERT [dbo].[TReportePagos] ([IdReportePago], [CodigoSolicitud], [MontoPrestamo], [CapitalPagado], [InteresPagado], [ComisionPagado], [SeguroPagado], [MoraPagada], [CargosPagado], [SaldoActual], [FechaUltimoPago], [DiasSinPagar], [Estado]) VALUES (2, 439851, 102000, 8120, CAST(1700.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 180, 0, 93880, N'25/04/2020', 1, 1)
GO
INSERT [dbo].[TReportePagos] ([IdReportePago], [CodigoSolicitud], [MontoPrestamo], [CapitalPagado], [InteresPagado], [ComisionPagado], [SeguroPagado], [MoraPagada], [CargosPagado], [SaldoActual], [FechaUltimoPago], [DiasSinPagar], [Estado]) VALUES (3, 925579, 306000, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, 0, 306000, N'', 0, 1)
GO
INSERT [dbo].[TReportePagos] ([IdReportePago], [CodigoSolicitud], [MontoPrestamo], [CapitalPagado], [InteresPagado], [ComisionPagado], [SeguroPagado], [MoraPagada], [CargosPagado], [SaldoActual], [FechaUltimoPago], [DiasSinPagar], [Estado]) VALUES (4, 205860, 510000, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, 0, 510000, N'', 0, 1)
GO
INSERT [dbo].[TReportePagos] ([IdReportePago], [CodigoSolicitud], [MontoPrestamo], [CapitalPagado], [InteresPagado], [ComisionPagado], [SeguroPagado], [MoraPagada], [CargosPagado], [SaldoActual], [FechaUltimoPago], [DiasSinPagar], [Estado]) VALUES (5, 101332, 36200, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, 0, 36200, N'', 0, 1)
GO
SET IDENTITY_INSERT [dbo].[TReportePagos] OFF
GO
SET IDENTITY_INSERT [dbo].[TReportePrestamos] ON 

GO
INSERT [dbo].[TReportePrestamos] ([IdReportePrestamos], [CodigoSolicitud], [NoCuota], [FechaPago], [Capital], [Interes], [Comision], [Seguro], [Mora], [Cargos], [SubTotal], [IdEstadoCuota], [EstadoFecha]) VALUES (86, 925579, 1, CAST(N'2020-06-01' AS Date), 12390, CAST(850.00 AS Decimal(18, 2)), CAST(85.00 AS Decimal(18, 2)), CAST(42.50 AS Decimal(18, 2)), 0, 0, 13367, 1, 1)
GO
INSERT [dbo].[TReportePrestamos] ([IdReportePrestamos], [CodigoSolicitud], [NoCuota], [FechaPago], [Capital], [Interes], [Comision], [Seguro], [Mora], [Cargos], [SubTotal], [IdEstadoCuota], [EstadoFecha]) VALUES (87, 925579, 2, CAST(N'2020-07-01' AS Date), 12627, CAST(643.51 AS Decimal(18, 2)), CAST(64.35 AS Decimal(18, 2)), CAST(32.18 AS Decimal(18, 2)), 0, 0, 13367, 1, 1)
GO
INSERT [dbo].[TReportePrestamos] ([IdReportePrestamos], [CodigoSolicitud], [NoCuota], [FechaPago], [Capital], [Interes], [Comision], [Seguro], [Mora], [Cargos], [SubTotal], [IdEstadoCuota], [EstadoFecha]) VALUES (88, 925579, 3, CAST(N'2020-08-01' AS Date), 12869, CAST(433.06 AS Decimal(18, 2)), CAST(43.31 AS Decimal(18, 2)), CAST(21.65 AS Decimal(18, 2)), 0, 0, 13367, 1, 1)
GO
INSERT [dbo].[TReportePrestamos] ([IdReportePrestamos], [CodigoSolicitud], [NoCuota], [FechaPago], [Capital], [Interes], [Comision], [Seguro], [Mora], [Cargos], [SubTotal], [IdEstadoCuota], [EstadoFecha]) VALUES (89, 925579, 4, CAST(N'2020-09-01' AS Date), 13115, CAST(219.65 AS Decimal(18, 2)), CAST(21.86 AS Decimal(18, 2)), CAST(10.93 AS Decimal(18, 2)), 0, 0, 13367, 1, 1)
GO
INSERT [dbo].[TReportePrestamos] ([IdReportePrestamos], [CodigoSolicitud], [NoCuota], [FechaPago], [Capital], [Interes], [Comision], [Seguro], [Mora], [Cargos], [SubTotal], [IdEstadoCuota], [EstadoFecha]) VALUES (90, 101332, 1, CAST(N'2020-04-14' AS Date), 3207, CAST(784.33 AS Decimal(18, 2)), CAST(120.67 AS Decimal(18, 2)), CAST(60.33 AS Decimal(18, 2)), 0, 0, 4220, 1, 1)
GO
INSERT [dbo].[TReportePrestamos] ([IdReportePrestamos], [CodigoSolicitud], [NoCuota], [FechaPago], [Capital], [Interes], [Comision], [Seguro], [Mora], [Cargos], [SubTotal], [IdEstadoCuota], [EstadoFecha]) VALUES (91, 101332, 2, CAST(N'2020-05-14' AS Date), 3292, CAST(714.86 AS Decimal(18, 2)), CAST(109.98 AS Decimal(18, 2)), CAST(54.99 AS Decimal(18, 2)), 0, 0, 4171, 1, 1)
GO
INSERT [dbo].[TReportePrestamos] ([IdReportePrestamos], [CodigoSolicitud], [NoCuota], [FechaPago], [Capital], [Interes], [Comision], [Seguro], [Mora], [Cargos], [SubTotal], [IdEstadoCuota], [EstadoFecha]) VALUES (92, 101332, 3, CAST(N'2020-06-14' AS Date), 3380, CAST(643.53 AS Decimal(18, 2)), CAST(99.00 AS Decimal(18, 2)), CAST(49.50 AS Decimal(18, 2)), 0, 0, 4172, 1, 1)
GO
INSERT [dbo].[TReportePrestamos] ([IdReportePrestamos], [CodigoSolicitud], [NoCuota], [FechaPago], [Capital], [Interes], [Comision], [Seguro], [Mora], [Cargos], [SubTotal], [IdEstadoCuota], [EstadoFecha]) VALUES (93, 101332, 4, CAST(N'2020-07-14' AS Date), 3470, CAST(570.29 AS Decimal(18, 2)), CAST(87.74 AS Decimal(18, 2)), CAST(43.87 AS Decimal(18, 2)), 0, 0, 4171, 1, 1)
GO
INSERT [dbo].[TReportePrestamos] ([IdReportePrestamos], [CodigoSolicitud], [NoCuota], [FechaPago], [Capital], [Interes], [Comision], [Seguro], [Mora], [Cargos], [SubTotal], [IdEstadoCuota], [EstadoFecha]) VALUES (94, 101332, 5, CAST(N'2020-08-14' AS Date), 3563, CAST(495.11 AS Decimal(18, 2)), CAST(76.17 AS Decimal(18, 2)), CAST(38.09 AS Decimal(18, 2)), 0, 0, 4172, 1, 1)
GO
INSERT [dbo].[TReportePrestamos] ([IdReportePrestamos], [CodigoSolicitud], [NoCuota], [FechaPago], [Capital], [Interes], [Comision], [Seguro], [Mora], [Cargos], [SubTotal], [IdEstadoCuota], [EstadoFecha]) VALUES (95, 101332, 6, CAST(N'2020-09-14' AS Date), 3658, CAST(417.92 AS Decimal(18, 2)), CAST(64.29 AS Decimal(18, 2)), CAST(32.15 AS Decimal(18, 2)), 0, 0, 4172, 1, 1)
GO
INSERT [dbo].[TReportePrestamos] ([IdReportePrestamos], [CodigoSolicitud], [NoCuota], [FechaPago], [Capital], [Interes], [Comision], [Seguro], [Mora], [Cargos], [SubTotal], [IdEstadoCuota], [EstadoFecha]) VALUES (96, 101332, 7, CAST(N'2020-10-14' AS Date), 3755, CAST(338.67 AS Decimal(18, 2)), CAST(52.10 AS Decimal(18, 2)), CAST(26.05 AS Decimal(18, 2)), 0, 0, 4171, 1, 1)
GO
INSERT [dbo].[TReportePrestamos] ([IdReportePrestamos], [CodigoSolicitud], [NoCuota], [FechaPago], [Capital], [Interes], [Comision], [Seguro], [Mora], [Cargos], [SubTotal], [IdEstadoCuota], [EstadoFecha]) VALUES (97, 101332, 8, CAST(N'2020-11-14' AS Date), 3855, CAST(257.31 AS Decimal(18, 2)), CAST(39.59 AS Decimal(18, 2)), CAST(19.79 AS Decimal(18, 2)), 0, 0, 4171, 1, 1)
GO
INSERT [dbo].[TReportePrestamos] ([IdReportePrestamos], [CodigoSolicitud], [NoCuota], [FechaPago], [Capital], [Interes], [Comision], [Seguro], [Mora], [Cargos], [SubTotal], [IdEstadoCuota], [EstadoFecha]) VALUES (98, 101332, 9, CAST(N'2020-12-14' AS Date), 3958, CAST(173.77 AS Decimal(18, 2)), CAST(26.73 AS Decimal(18, 2)), CAST(13.37 AS Decimal(18, 2)), 0, 0, 4171, 1, 1)
GO
INSERT [dbo].[TReportePrestamos] ([IdReportePrestamos], [CodigoSolicitud], [NoCuota], [FechaPago], [Capital], [Interes], [Comision], [Seguro], [Mora], [Cargos], [SubTotal], [IdEstadoCuota], [EstadoFecha]) VALUES (99, 101332, 10, CAST(N'2021-01-14' AS Date), 4062, CAST(89.49 AS Decimal(18, 2)), CAST(13.54 AS Decimal(18, 2)), CAST(6.77 AS Decimal(18, 2)), 0, 0, 4171, 1, 1)
GO
INSERT [dbo].[TReportePrestamos] ([IdReportePrestamos], [CodigoSolicitud], [NoCuota], [FechaPago], [Capital], [Interes], [Comision], [Seguro], [Mora], [Cargos], [SubTotal], [IdEstadoCuota], [EstadoFecha]) VALUES (100, 658910, 1, CAST(N'2020-05-01' AS Date), 49274, CAST(3060.00 AS Decimal(18, 2)), CAST(765.00 AS Decimal(18, 2)), CAST(382.50 AS Decimal(18, 2)), 0, 0, 52825, 1, 1)
GO
INSERT [dbo].[TReportePrestamos] ([IdReportePrestamos], [CodigoSolicitud], [NoCuota], [FechaPago], [Capital], [Interes], [Comision], [Seguro], [Mora], [Cargos], [SubTotal], [IdEstadoCuota], [EstadoFecha]) VALUES (101, 658910, 2, CAST(N'2020-06-01' AS Date), 49952, CAST(2567.26 AS Decimal(18, 2)), CAST(641.81 AS Decimal(18, 2)), CAST(320.91 AS Decimal(18, 2)), 0, 0, 50235, 1, 1)
GO
INSERT [dbo].[TReportePrestamos] ([IdReportePrestamos], [CodigoSolicitud], [NoCuota], [FechaPago], [Capital], [Interes], [Comision], [Seguro], [Mora], [Cargos], [SubTotal], [IdEstadoCuota], [EstadoFecha]) VALUES (102, 658910, 3, CAST(N'2020-07-01' AS Date), 50639, CAST(2067.73 AS Decimal(18, 2)), CAST(516.93 AS Decimal(18, 2)), CAST(258.47 AS Decimal(18, 2)), 0, 0, 47659, 1, 1)
GO
INSERT [dbo].[TReportePrestamos] ([IdReportePrestamos], [CodigoSolicitud], [NoCuota], [FechaPago], [Capital], [Interes], [Comision], [Seguro], [Mora], [Cargos], [SubTotal], [IdEstadoCuota], [EstadoFecha]) VALUES (103, 658910, 4, CAST(N'2020-08-01' AS Date), 51335, CAST(1561.35 AS Decimal(18, 2)), CAST(390.34 AS Decimal(18, 2)), CAST(195.17 AS Decimal(18, 2)), 0, 0, 44926, 1, 1)
GO
INSERT [dbo].[TReportePrestamos] ([IdReportePrestamos], [CodigoSolicitud], [NoCuota], [FechaPago], [Capital], [Interes], [Comision], [Seguro], [Mora], [Cargos], [SubTotal], [IdEstadoCuota], [EstadoFecha]) VALUES (104, 658910, 5, CAST(N'2020-09-01' AS Date), 52041, CAST(1047.99 AS Decimal(18, 2)), CAST(262.00 AS Decimal(18, 2)), CAST(131.00 AS Decimal(18, 2)), 0, 0, 42120, 1, 1)
GO
INSERT [dbo].[TReportePrestamos] ([IdReportePrestamos], [CodigoSolicitud], [NoCuota], [FechaPago], [Capital], [Interes], [Comision], [Seguro], [Mora], [Cargos], [SubTotal], [IdEstadoCuota], [EstadoFecha]) VALUES (105, 658910, 6, CAST(N'2020-10-01' AS Date), 52758, CAST(525.69 AS Decimal(18, 2)), CAST(131.90 AS Decimal(18, 2)), CAST(65.95 AS Decimal(18, 2)), 0, 0, 39325, 1, 1)
GO
INSERT [dbo].[TReportePrestamos] ([IdReportePrestamos], [CodigoSolicitud], [NoCuota], [FechaPago], [Capital], [Interes], [Comision], [Seguro], [Mora], [Cargos], [SubTotal], [IdEstadoCuota], [EstadoFecha]) VALUES (106, 205860, 1, CAST(N'2020-06-10' AS Date), 167614, CAST(5950.00 AS Decimal(18, 2)), CAST(850.00 AS Decimal(18, 2)), CAST(425.00 AS Decimal(18, 2)), 0, 0, 174839, 1, 1)
GO
INSERT [dbo].[TReportePrestamos] ([IdReportePrestamos], [CodigoSolicitud], [NoCuota], [FechaPago], [Capital], [Interes], [Comision], [Seguro], [Mora], [Cargos], [SubTotal], [IdEstadoCuota], [EstadoFecha]) VALUES (107, 205860, 2, CAST(N'2020-07-10' AS Date), 169989, CAST(3994.50 AS Decimal(18, 2)), CAST(570.64 AS Decimal(18, 2)), CAST(285.32 AS Decimal(18, 2)), 0, 0, 174839, 1, 1)
GO
INSERT [dbo].[TReportePrestamos] ([IdReportePrestamos], [CodigoSolicitud], [NoCuota], [FechaPago], [Capital], [Interes], [Comision], [Seguro], [Mora], [Cargos], [SubTotal], [IdEstadoCuota], [EstadoFecha]) VALUES (108, 205860, 3, CAST(N'2020-08-10' AS Date), 172397, CAST(2010.55 AS Decimal(18, 2)), CAST(287.33 AS Decimal(18, 2)), CAST(143.66 AS Decimal(18, 2)), 0, 0, 174838, 1, 1)
GO
INSERT [dbo].[TReportePrestamos] ([IdReportePrestamos], [CodigoSolicitud], [NoCuota], [FechaPago], [Capital], [Interes], [Comision], [Seguro], [Mora], [Cargos], [SubTotal], [IdEstadoCuota], [EstadoFecha]) VALUES (109, 439851, 1, CAST(N'2020-04-16' AS Date), 3905, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 6, 0, 3912, 2, 1)
GO
INSERT [dbo].[TReportePrestamos] ([IdReportePrestamos], [CodigoSolicitud], [NoCuota], [FechaPago], [Capital], [Interes], [Comision], [Seguro], [Mora], [Cargos], [SubTotal], [IdEstadoCuota], [EstadoFecha]) VALUES (110, 439851, 2, CAST(N'2020-05-01' AS Date), 12225, CAST(1499.58 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, 0, 13724, 1, 1)
GO
INSERT [dbo].[TReportePrestamos] ([IdReportePrestamos], [CodigoSolicitud], [NoCuota], [FechaPago], [Capital], [Interes], [Comision], [Seguro], [Mora], [Cargos], [SubTotal], [IdEstadoCuota], [EstadoFecha]) VALUES (111, 439851, 3, CAST(N'2020-05-16' AS Date), 12429, CAST(1295.83 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, 0, 13724, 1, 1)
GO
INSERT [dbo].[TReportePrestamos] ([IdReportePrestamos], [CodigoSolicitud], [NoCuota], [FechaPago], [Capital], [Interes], [Comision], [Seguro], [Mora], [Cargos], [SubTotal], [IdEstadoCuota], [EstadoFecha]) VALUES (112, 439851, 4, CAST(N'2020-05-31' AS Date), 12636, CAST(1088.67 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, 0, 13724, 1, 1)
GO
INSERT [dbo].[TReportePrestamos] ([IdReportePrestamos], [CodigoSolicitud], [NoCuota], [FechaPago], [Capital], [Interes], [Comision], [Seguro], [Mora], [Cargos], [SubTotal], [IdEstadoCuota], [EstadoFecha]) VALUES (113, 439851, 5, CAST(N'2020-06-15' AS Date), 12847, CAST(878.07 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, 0, 13725, 1, 1)
GO
INSERT [dbo].[TReportePrestamos] ([IdReportePrestamos], [CodigoSolicitud], [NoCuota], [FechaPago], [Capital], [Interes], [Comision], [Seguro], [Mora], [Cargos], [SubTotal], [IdEstadoCuota], [EstadoFecha]) VALUES (114, 439851, 6, CAST(N'2020-06-30' AS Date), 13061, CAST(663.95 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, 0, 13724, 1, 1)
GO
INSERT [dbo].[TReportePrestamos] ([IdReportePrestamos], [CodigoSolicitud], [NoCuota], [FechaPago], [Capital], [Interes], [Comision], [Seguro], [Mora], [Cargos], [SubTotal], [IdEstadoCuota], [EstadoFecha]) VALUES (115, 439851, 7, CAST(N'2020-07-15' AS Date), 13279, CAST(446.27 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, 0, 13725, 1, 1)
GO
INSERT [dbo].[TReportePrestamos] ([IdReportePrestamos], [CodigoSolicitud], [NoCuota], [FechaPago], [Capital], [Interes], [Comision], [Seguro], [Mora], [Cargos], [SubTotal], [IdEstadoCuota], [EstadoFecha]) VALUES (116, 439851, 8, CAST(N'2020-07-30' AS Date), 13497, CAST(227.63 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, 0, 13724, 1, 1)
GO
SET IDENTITY_INSERT [dbo].[TReportePrestamos] OFF
GO
SET IDENTITY_INSERT [dbo].[TRutas] ON 

GO
INSERT [dbo].[TRutas] ([IdRuta], [Descripcion]) VALUES (1, N'GENERAL')
GO
INSERT [dbo].[TRutas] ([IdRuta], [Descripcion]) VALUES (2, N'LUNE')
GO
INSERT [dbo].[TRutas] ([IdRuta], [Descripcion]) VALUES (3, N'MARTE')
GO
INSERT [dbo].[TRutas] ([IdRuta], [Descripcion]) VALUES (4, N'MIERCOLE')
GO
INSERT [dbo].[TRutas] ([IdRuta], [Descripcion]) VALUES (5, N'JUEVE')
GO
INSERT [dbo].[TRutas] ([IdRuta], [Descripcion]) VALUES (6, N'VIERNE')
GO
INSERT [dbo].[TRutas] ([IdRuta], [Descripcion]) VALUES (7, N'SABADO')
GO
INSERT [dbo].[TRutas] ([IdRuta], [Descripcion]) VALUES (8, N'DOMINGO')
GO
SET IDENTITY_INSERT [dbo].[TRutas] OFF
GO
SET IDENTITY_INSERT [dbo].[TSolicitudes] ON 

GO
INSERT [dbo].[TSolicitudes] ([IdSolicitud], [CodigoSolicitud], [CodigoCliente], [CodigoCoDeudor], [CodigoGarantia], [IdTipoPrestamo], [IdFormaPago], [IdClasePrestamo], [IdTipoGarantia], [IdRuta], [IdZona], [IdGestor], [FechaPago], [DescripcionInversion], [MontoSolicitado], [GastosLegales], [MontoTotal], [CantidadCuotas], [TasaInteresAnual], [TasaComisionAnual], [TasaSeguroAnual], [MontoCuota], [IdEstadoSolicitud], [Estado], [Fecha], [Hora], [IdUsuario], [IdSucursal], [IdEstadoPrestamo]) VALUES (1, 658910, 622871, 0, 101010, 1, 1, 2, 3, 1, 3, 2, CAST(N'2020-04-01' AS Date), N'USO PERSONAL', 300000, 6000, 306000, 6, CAST(12.00 AS Decimal(18, 2)), CAST(3.00 AS Decimal(18, 2)), CAST(1.50 AS Decimal(18, 2)), 53482, 3, 1, CAST(N'2020-04-21' AS Date), N'21:44:30 Actualización', 0, 1, 2)
GO
INSERT [dbo].[TSolicitudes] ([IdSolicitud], [CodigoSolicitud], [CodigoCliente], [CodigoCoDeudor], [CodigoGarantia], [IdTipoPrestamo], [IdFormaPago], [IdClasePrestamo], [IdTipoGarantia], [IdRuta], [IdZona], [IdGestor], [FechaPago], [DescripcionInversion], [MontoSolicitado], [GastosLegales], [MontoTotal], [CantidadCuotas], [TasaInteresAnual], [TasaComisionAnual], [TasaSeguroAnual], [MontoCuota], [IdEstadoSolicitud], [Estado], [Fecha], [Hora], [IdUsuario], [IdSucursal], [IdEstadoPrestamo]) VALUES (2, 439851, 100000, 100001, 0, 1, 2, 1, 2, 1, 2, 1, CAST(N'2020-04-01' AS Date), N'COMPRA DE UNA COMPUTADORA PARA TRABAJAR EN PROGRAMACION', 100000, 2000, 102000, 8, CAST(20.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 13725, 3, 1, CAST(N'2020-04-25' AS Date), N'21:13:05 Actualización', 0, 1, 2)
GO
INSERT [dbo].[TSolicitudes] ([IdSolicitud], [CodigoSolicitud], [CodigoCliente], [CodigoCoDeudor], [CodigoGarantia], [IdTipoPrestamo], [IdFormaPago], [IdClasePrestamo], [IdTipoGarantia], [IdRuta], [IdZona], [IdGestor], [FechaPago], [DescripcionInversion], [MontoSolicitado], [GastosLegales], [MontoTotal], [CantidadCuotas], [TasaInteresAnual], [TasaComisionAnual], [TasaSeguroAnual], [MontoCuota], [IdEstadoSolicitud], [Estado], [Fecha], [Hora], [IdUsuario], [IdSucursal], [IdEstadoPrestamo]) VALUES (3, 925579, 684624, 0, 0, 1, 1, 1, 1, 1, 3, 2, CAST(N'2020-05-01' AS Date), N'COMPRA DE ELECTRODOMESTICOS', 50000, 1000, 51000, 4, CAST(20.00 AS Decimal(18, 2)), CAST(2.00 AS Decimal(18, 2)), CAST(1.00 AS Decimal(18, 2)), 13367, 1, 1, CAST(N'2020-04-21' AS Date), N'21:40:27 Actualización', 0, 1, 1)
GO
INSERT [dbo].[TSolicitudes] ([IdSolicitud], [CodigoSolicitud], [CodigoCliente], [CodigoCoDeudor], [CodigoGarantia], [IdTipoPrestamo], [IdFormaPago], [IdClasePrestamo], [IdTipoGarantia], [IdRuta], [IdZona], [IdGestor], [FechaPago], [DescripcionInversion], [MontoSolicitado], [GastosLegales], [MontoTotal], [CantidadCuotas], [TasaInteresAnual], [TasaComisionAnual], [TasaSeguroAnual], [MontoCuota], [IdEstadoSolicitud], [Estado], [Fecha], [Hora], [IdUsuario], [IdSucursal], [IdEstadoPrestamo]) VALUES (4, 205860, 247011, 163478, 249001, 1, 1, 1, 1, 1, 1, 1, CAST(N'2020-05-10' AS Date), N'COMPRA DE UNA MEJORA', 500000, 10000, 510000, 3, CAST(14.00 AS Decimal(18, 2)), CAST(2.00 AS Decimal(18, 2)), CAST(1.00 AS Decimal(18, 2)), 174839, 1, 1, CAST(N'2020-04-21' AS Date), N'21:45:00 Actualización', 0, 1, 1)
GO
INSERT [dbo].[TSolicitudes] ([IdSolicitud], [CodigoSolicitud], [CodigoCliente], [CodigoCoDeudor], [CodigoGarantia], [IdTipoPrestamo], [IdFormaPago], [IdClasePrestamo], [IdTipoGarantia], [IdRuta], [IdZona], [IdGestor], [FechaPago], [DescripcionInversion], [MontoSolicitado], [GastosLegales], [MontoTotal], [CantidadCuotas], [TasaInteresAnual], [TasaComisionAnual], [TasaSeguroAnual], [MontoCuota], [IdEstadoSolicitud], [Estado], [Fecha], [Hora], [IdUsuario], [IdSucursal], [IdEstadoPrestamo]) VALUES (5, 101332, 281265, 684624, 0, 1, 1, 1, 2, 1, 2, 2, CAST(N'2020-03-14' AS Date), N'COMPRA DE UNA PASOLA', 35000, 1200, 36200, 10, CAST(26.00 AS Decimal(18, 2)), CAST(4.00 AS Decimal(18, 2)), CAST(2.00 AS Decimal(18, 2)), 4172, 1, 1, CAST(N'2020-04-21' AS Date), N'21:43:33 Actualización', 0, 1, 1)
GO
SET IDENTITY_INSERT [dbo].[TSolicitudes] OFF
GO
SET IDENTITY_INSERT [dbo].[TSucursales] ON 

GO
INSERT [dbo].[TSucursales] ([IdSucursal], [NombreSU], [TelefonoSU], [DireccionSU], [IdEmpresa]) VALUES (1, N'OFICINA : CASTILLO', N'TELEFONO : 809-581-0001', N'C/PEDRO MARIA GOMEZ NO. 10, CASTILLO, PROV. DUARTE, REP. DOM.', 1)
GO
INSERT [dbo].[TSucursales] ([IdSucursal], [NombreSU], [TelefonoSU], [DireccionSU], [IdEmpresa]) VALUES (2, N'OFICINA : DE VILLA RIVA', N'TELEFONO :  809-581-0002', N'C/ 27 DE FEBRERO NO. 34, VILLA RIVA, PROV. DUARTE, REP. DOM.', 1)
GO
SET IDENTITY_INSERT [dbo].[TSucursales] OFF
GO
SET IDENTITY_INSERT [dbo].[TTasaMoras] ON 

GO
INSERT [dbo].[TTasaMoras] ([IdTasaMora], [Valor]) VALUES (1, CAST(5.00 AS Decimal(18, 2)))
GO
SET IDENTITY_INSERT [dbo].[TTasaMoras] OFF
GO
SET IDENTITY_INSERT [dbo].[TTipoGarantias] ON 

GO
INSERT [dbo].[TTipoGarantias] ([IdTipoGarantia], [Descripcion]) VALUES (1, N'SOLO FIRMA')
GO
INSERT [dbo].[TTipoGarantias] ([IdTipoGarantia], [Descripcion]) VALUES (2, N'CO-DEUDOR')
GO
INSERT [dbo].[TTipoGarantias] ([IdTipoGarantia], [Descripcion]) VALUES (3, N'SOBRE VEICULO')
GO
INSERT [dbo].[TTipoGarantias] ([IdTipoGarantia], [Descripcion]) VALUES (4, N'HIPOTECARIO')
GO
SET IDENTITY_INSERT [dbo].[TTipoGarantias] OFF
GO
SET IDENTITY_INSERT [dbo].[TTipoPagos] ON 

GO
INSERT [dbo].[TTipoPagos] ([IdTipoPago], [Descripcion]) VALUES (1, N'EFECTIVO')
GO
INSERT [dbo].[TTipoPagos] ([IdTipoPago], [Descripcion]) VALUES (2, N'CHEQUE')
GO
INSERT [dbo].[TTipoPagos] ([IdTipoPago], [Descripcion]) VALUES (3, N'DEPOSITO BANCO')
GO
INSERT [dbo].[TTipoPagos] ([IdTipoPago], [Descripcion]) VALUES (4, N'TRANFERENCIA BANCO')
GO
SET IDENTITY_INSERT [dbo].[TTipoPagos] OFF
GO
SET IDENTITY_INSERT [dbo].[TTipoPrestamos] ON 

GO
INSERT [dbo].[TTipoPrestamos] ([IdTipoPrestamo], [Descripcion]) VALUES (1, N'SALDO INSOLUTO')
GO
INSERT [dbo].[TTipoPrestamos] ([IdTipoPrestamo], [Descripcion]) VALUES (2, N'PAGO DE INTERES A VENCIMIENTO')
GO
SET IDENTITY_INSERT [dbo].[TTipoPrestamos] OFF
GO
SET IDENTITY_INSERT [dbo].[TZonas] ON 

GO
INSERT [dbo].[TZonas] ([IdZona], [Descripcion]) VALUES (1, N'GENERAL')
GO
INSERT [dbo].[TZonas] ([IdZona], [Descripcion]) VALUES (2, N'VILLA RIVA')
GO
INSERT [dbo].[TZonas] ([IdZona], [Descripcion]) VALUES (3, N'CASTILLO')
GO
INSERT [dbo].[TZonas] ([IdZona], [Descripcion]) VALUES (4, N'LAS TARANA')
GO
INSERT [dbo].[TZonas] ([IdZona], [Descripcion]) VALUES (5, N'BOMBA DE YAIBA')
GO
INSERT [dbo].[TZonas] ([IdZona], [Descripcion]) VALUES (6, N'BOMBILLO')
GO
INSERT [dbo].[TZonas] ([IdZona], [Descripcion]) VALUES (7, N'CEIBA DE LOS PAJARO')
GO
INSERT [dbo].[TZonas] ([IdZona], [Descripcion]) VALUES (8, N'ARENSO')
GO
INSERT [dbo].[TZonas] ([IdZona], [Descripcion]) VALUES (9, N'HOSTOS')
GO
SET IDENTITY_INSERT [dbo].[TZonas] OFF
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__TCliente__BFBAD14ABB84B251]    Script Date: 26/4/20 10:06:22 p. m. ******/
ALTER TABLE [dbo].[TClientes] ADD  CONSTRAINT [UQ__TCliente__BFBAD14ABB84B251] UNIQUE NONCLUSTERED 
(
	[NoDocumento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[PS_LISTADODEPRESTAMOS]    Script Date: 26/4/20 10:06:22 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PS_LISTADODEPRESTAMOS] 

AS
BEGIN

	SELECT C.CodigoCliente AS 'CODIGO', C.Nombre + ' ' + C.Apellido AS 'CLIENTE', 
	S.FechaPago AS 'FECHA', (S.GastosLegales + S.MontoSolicitado) AS 'MONTO', S.CantidadCuotas AS 'PLAZO' ,  S.MontoCuota AS 'CUOTA',
	FP.DescripcionFP AS 'FORMA PAGO', S.TasaInteresAnual AS 'INTERES', S.TasaComisionAnual AS 'COMISION', S.TasaSeguroAnual AS 'SEGURO',
	RP.CapitalPagado AS 'CAP. PAGADO', RP.InteresPagado AS 'INT. PAGADO',  RP.ComisionPagado AS 'COM. PAGADA', RP.SeguroPagado AS 'SEG. PAGADO', RP.MoraPagada AS 'MORA PAGADA',
	RP.SaldoActual AS 'SALDO ACTUAL', EM.NombreEP AS 'EMPRESA', EM.RncEM AS 'RNC', SU.NombreSU AS 'SUCURSAL', SU.TelefonoSU AS 'TELEFONO', SU.DireccionSU AS 'DIRACCION', EM.LemaEM AS 'LEMA'

	FROM TClientes C INNER JOIN TSolicitudes S ON C.CodigoCliente = S.CodigoCliente
					 INNER JOIN TFormaPagos FP ON S.IdFormaPago = FP.IdFormaPago
					 INNER JOIN TReportePagos RP ON S.CodigoSolicitud = RP.CodigoSolicitud
					 INNER JOIN TSucursales SU ON S.IdSucursal = SU.IdSucursal
					 INNER JOIN TEmpresas EM ON SU.IdEmpresa = EM.IdEmpresa
					

	WHERE S.IdEstadoSolicitud = 3 and s.IdEstadoPrestamo = 2

END

GO
/****** Object:  StoredProcedure [dbo].[SP_CUENTAS_POR_COBRAR]    Script Date: 26/4/20 10:06:22 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_CUENTAS_POR_COBRAR]

AS


SELECT CONVERT(varchar, C.CodigoCliente)  + ' ' + C.Nombre + ' ' +  C.Apellido AS 'CLIENTE', C.Celular AS 'CELULAR CLI', CO.Nombre + ' ' + CO.Apellido AS 'CODEUDOR', CO.Celular AS 'CELLAR CO',
	   S.CodigoSolicitud AS 'CODIGO SOLICITUD', S.FechaPago AS 'FECHA PRESTAMO', RP.FechaUltimoPago AS 'ULTIMO PAGO', RP.DiasSinPagar AS 'DIA SIN PAGAR', (S.MontoSolicitado +  S.GastosLegales) AS 'MONTO',
	   S.MontoCuota AS 'CUOTA', A.Mora AS 'MORA', (A.Capital + A.Intere + A.Comision + A.Seguro + A.Mora) AS 'TOTAL ATRASO',
	   EM.NombreEP, EM.RncEM, SU.NombreSU, SU.TelefonoSU, SU.DireccionSU, EM.LemaEM
FROM  TSolicitudes S   INNER JOIN TClientes C ON S.CodigoCliente = C.CodigoCliente
					   INNER JOIN TClientes CO ON S.CodigoCoDeudor =  CO.CodigoCliente
					   INNER JOIN TGarantiaEconomica GE ON S.CodigoGarantia =  GE.CodigoGarantia
					   INNER JOIN TReportePagos RP ON S.CodigoSolicitud = RP.CodigoSolicitud
					   INNER JOIN TAtrasos A ON S.CodigoSolicitud = A.CodigoSolicitud
					   INNER JOIN TSucursales SU ON S.IdSucursal = SU.IdSucursal
					   INNER JOIN TEmpresas EM ON SU.IdEmpresa = EM.IdEmpresa
WHERE S.IdEstadoPrestamo = 2 AND  (A.Capital > 0 OR A.Intere > 0 OR A.Comision > 0 OR A.Seguro > 0 OR A.Mora > 0)
GO
/****** Object:  StoredProcedure [dbo].[SP_CUOTASVENCIDASPORCLINETE]    Script Date: 26/4/20 10:06:22 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE  PROCEDURE [dbo].[SP_CUOTASVENCIDASPORCLINETE]
as
SELECT CONVERT(varchar,  CL.CodigoCliente)+' '+ CL.Nombre+' '+ CL.Apellido AS 'NOMBRE', P.CodigoSolicitud AS 'CODIGO PRESTAMO', C.DescripcionEC +'  '+CONVERT(varchar ,COUNT(p.IdEstadoCuota)) AS CANTIDAD
FROM TReportePrestamos P INNER JOIN TEstadoCuotas C ON P.IdEstadoCuota = C.IdEstadoCuota
						 INNER JOIN TSolicitudes S ON P.CodigoSolicitud = S.CodigoSolicitud
						 INNER JOIN TClientes CL ON S.CodigoCliente = CL.CodigoCliente
WHERE P.IdEstadoCuota = 2 AND S.IdEstadoSolicitud = 3 and s.IdEstadoPrestamo = 2
GROUP BY CL.CodigoCliente, CL.Nombre, CL.Apellido, P.CodigoSolicitud, C.DescripcionEC, p.IdEstadoCuota
GO
/****** Object:  StoredProcedure [dbo].[SP_DATOSEMPRESA]    Script Date: 26/4/20 10:06:22 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_DATOSEMPRESA]
@IDSUCURSAL INT
AS
BEGIN

	SELECT E.NombreEP, E.RncEM, S.NombreSU, S.TelefonoSU, S.DireccionSU, E.LemaEM
	FROM TSucursales S INNER JOIN TEmpresas E ON S.IdEmpresa = E.IdEmpresa
	WHERE S.IdSucursal = @IDSUCURSAL

END

GO
/****** Object:  StoredProcedure [dbo].[SP_SOLICITUD]    Script Date: 26/4/20 10:06:22 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_SOLICITUD]

@CODIGO_SOLICITUD INT 
AS

BEGIN


SELECT 
        C.NoDocumento AS 'CEDULA CLIENTE', C.Nombre + ' ' + C.Apellido AS 'NOMBRE CLIENTE', C.Apodo AS 'APODO CLIENTE',  C.FechaNacimiento AS 'FECHA NAC. CLIENTE', C.Celular AS 'CELULAR CLIENTE', C.Telefono AS 'TELEFONO CLIENTE', C.Email  AS 'EMAIL CLIENTE', C.Direccion AS 'DIRECCION CLIENTE',
		CO.NoDocumento AS 'CEDULA CO-DEUDOR', CO.Nombre + ' ' + CO.Apellido AS 'NOMBRE CO-DEUDOR', CO.Apodo AS 'APODO CO-DEUDOR', CO.FechaNacimiento AS 'FECHA NAC.  CO-DEUDOR', CO.Celular AS 'CELULAR CO-DEUDOR', CO.Telefono AS 'TELEFONO CO-DEUDOR', CO.Email  AS 'EMAIL CO-DEUDOR', CO.Direccion AS 'DIRECCION CO-DEUDOR',
		S.CodigoSolicitud, S.DescripcionInversion, (S.MontoSolicitado + S.GastosLegales) AS 'MONTO', S.CantidadCuotas, S.TasaInteresAnual, S.TasaComisionAnual, S.TasaSeguroAnual, S.MontoCuota, S.Fecha AS 'FECHA CREACION',
		TP.Descripcion AS 'TIPO DE PRESTAMO', FP.DescripcionFP AS 'FORMA DE PAGO', CP.Descripcion AS 'CLASE DE PRESTAMO', TG.Descripcion AS 'TIPO DE GARANTIA', RT.Descripcion AS 'RUTA', GT.Nombre AS 'GESTOR',
		DLC.Empresa AS 'EMPRESA LABOR CL', DLC.TelefonoEmp AS 'TELEFONO EMP CL',  DLC.Cargo AS 'CARGO EMP CL', DLC.TiempoLaborando AS 'TIEMPO LABORANDO EMP CL', DLC.Sueldo AS 'SUELDO CL', DLC.OtroIngresos AS 'OTROS INGRESOS CL', DLC.DetalleOtroIngresos AS 'DETALLE OTRO CL', DLC.Gastos AS 'GASTOS CL', (DLC.Sueldo + DLC.OtroIngresos - DLC.Gastos) AS 'SUELDO NETO CL',
		DLCO.Empresa AS 'EMPRESA LABOR CO', DLCO.TelefonoEmp AS 'TELEFONO EMP CO', DLCO.Cargo AS 'CARGO EMP CO', DLCO.TiempoLaborando AS 'TIEMPO LABORANDO EMP CO', DLCO.Sueldo AS 'SUELDO CO', DLCO.OtroIngresos AS 'OTROS INGRESOS CO', DLCO.DetalleOtroIngresos AS 'DETALLE OTRO CO', DLCO.Gastos AS 'GASTOS CO', (DLCO.Sueldo + DLCO.OtroIngresos - DLCO.Gastos) AS 'SUELDO NETO CO',
		EM.NombreEP, EM.RncEM, SU.NombreSU, SU.TelefonoSU, SU.DireccionSU, EM.LemaEM
 
FROM TSolicitudes S INNER JOIN TClientes C ON S.CodigoCliente = C.CodigoCliente
					INNER JOIN TClientes CO ON S.CodigoCoDeudor = CO.CodigoCliente
					INNER JOIN TDatosLaborables DLC ON S.CodigoCliente = DLC.CodigoCliente 
					INNER JOIN TDatosLaborables DLCO ON S.CodigoCoDeudor = DLCO.CodigoCliente
					INNER JOIN TSucursales SU ON S.IdSucursal = SU.IdSucursal
					INNER JOIN TEmpresas EM ON SU.IdEmpresa = EM.IdEmpresa
					INNER JOIN TTipoPrestamos TP ON S.IdTipoPrestamo = TP.IdTipoPrestamo
					INNER JOIN TFormaPagos FP ON S.IdFormaPago = FP.IdFormaPago
					INNER JOIN TClasePrestamos CP ON S.IdClasePrestamo = CP.IdClasePrestamo
					INNER JOIN TTipoGarantias TG ON S.IdTipoGarantia = TG.IdTipoGarantia
					INNER JOIN TRutas RT ON S.IdRuta = RT.IdRuta
					INNER JOIN TGestores GT ON S.IdGestor = GT.IdGestor
					
WHERE S.CodigoSolicitud = @CODIGO_SOLICITUD

END

GO
/****** Object:  StoredProcedure [dbo].[SP_SOLICITUD_CODEUDOR_Y_GARANTIA]    Script Date: 26/4/20 10:06:22 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_SOLICITUD_CODEUDOR_Y_GARANTIA]

@CODIGO_SOLICITUD INT 
AS

BEGIN


SELECT 
        C.NoDocumento AS 'CEDULA CLIENTE', C.Nombre + ' ' + C.Apellido AS 'NOMBRE CLIENTE', C.Apodo AS 'APODO CLIENTE',  C.FechaNacimiento AS 'FECHA NAC. CLIENTE', C.Celular AS 'CELULAR CLIENTE', C.Telefono AS 'TELEFONO CLIENTE', C.Email  AS 'EMAIL CLIENTE', C.Direccion AS 'DIRECCION CLIENTE',
		CO.NoDocumento AS 'CEDULA CO-DEUDOR', CO.Nombre + ' ' + CO.Apellido AS 'NOMBRE CO-DEUDOR', CO.Apodo AS 'APODO CO-DEUDOR', CO.FechaNacimiento AS 'FECHA NAC.  CO-DEUDOR', CO.Celular AS 'CELULAR CO-DEUDOR', CO.Telefono AS 'TELEFONO CO-DEUDOR', CO.Email  AS 'EMAIL CO-DEUDOR', CO.Direccion AS 'DIRECCION CO-DEUDOR',
		GE.NombreGE, GE.DescripcionGE, GE.MatriculaOTituloGE, GE.ValorEstimadoGE,
		S.CodigoSolicitud, S.DescripcionInversion, (S.MontoSolicitado + S.GastosLegales) AS 'MONTO', S.CantidadCuotas, S.TasaInteresAnual, S.TasaComisionAnual, S.TasaSeguroAnual, S.MontoCuota, S.Fecha AS 'FECHA CREACION',
		TP.Descripcion AS 'TIPO DE PRESTAMO', FP.DescripcionFP AS 'FORMA DE PAGO', CP.Descripcion AS 'CLASE DE PRESTAMO', TG.Descripcion AS 'TIPO DE GARANTIA', RT.Descripcion AS 'RUTA', GT.Nombre AS 'GESTOR',
		DLC.Empresa AS 'EMPRESA LABOR CL', DLC.TelefonoEmp AS 'TELEFONO EMP CL',  DLC.Cargo AS 'CARGO EMP CL', DLC.TiempoLaborando AS 'TIEMPO LABORANDO EMP CL', DLC.Sueldo AS 'SUELDO CL', DLC.OtroIngresos AS 'OTROS INGRESOS CL', DLC.DetalleOtroIngresos AS 'DETALLE OTRO CL', DLC.Gastos AS 'GASTOS CL', (DLC.Sueldo + DLC.OtroIngresos - DLC.Gastos) AS 'SUELDO NETO CL',
		DLCO.Empresa AS 'EMPRESA LABOR CO', DLCO.TelefonoEmp AS 'TELEFONO EMP CO', DLCO.Cargo AS 'CARGO EMP CO', DLCO.TiempoLaborando AS 'TIEMPO LABORANDO EMP CO', DLCO.Sueldo AS 'SUELDO CO', DLCO.OtroIngresos AS 'OTROS INGRESOS CO', DLCO.DetalleOtroIngresos AS 'DETALLE OTRO CO', DLCO.Gastos AS 'GASTOS CO', (DLCO.Sueldo + DLCO.OtroIngresos - DLCO.Gastos) AS 'SUELDO NETO CO',
		EM.NombreEP, EM.RncEM, SU.NombreSU, SU.TelefonoSU, SU.DireccionSU, EM.LemaEM
 
FROM TSolicitudes S INNER JOIN TClientes C ON S.CodigoCliente = C.CodigoCliente
					INNER JOIN TClientes CO ON S.CodigoCoDeudor = CO.CodigoCliente
					INNER JOIN TGarantiaEconomica GE ON S.CodigoGarantia = GE.CodigoGarantia
					INNER JOIN TDatosLaborables DLC ON S.CodigoCliente = DLC.CodigoCliente 
					INNER JOIN TDatosLaborables DLCO ON S.CodigoCoDeudor = DLCO.CodigoCliente
					INNER JOIN TSucursales SU ON S.IdSucursal = SU.IdSucursal
					INNER JOIN TEmpresas EM ON SU.IdEmpresa = EM.IdEmpresa
					INNER JOIN TTipoPrestamos TP ON S.IdTipoPrestamo = TP.IdTipoPrestamo
					INNER JOIN TFormaPagos FP ON S.IdFormaPago = FP.IdFormaPago
					INNER JOIN TClasePrestamos CP ON S.IdClasePrestamo = CP.IdClasePrestamo
					INNER JOIN TTipoGarantias TG ON S.IdTipoGarantia = TG.IdTipoGarantia
					INNER JOIN TRutas RT ON S.IdRuta = RT.IdRuta
					INNER JOIN TGestores GT ON S.IdGestor = GT.IdGestor
					
WHERE S.CodigoSolicitud = @CODIGO_SOLICITUD

END
GO
/****** Object:  StoredProcedure [dbo].[SP_SOLICITUD_CONGARANTIA]    Script Date: 26/4/20 10:06:22 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_SOLICITUD_CONGARANTIA]

@CODIGO_SOLICITUD INT 
AS


BEGIN


SELECT 
        C.NoDocumento AS 'CEDULA CLIENTE', C.Nombre + ' ' + C.Apellido AS 'NOMBRE CLIENTE', C.Apodo AS 'APODO CLIENTE',  C.FechaNacimiento AS 'FECHA NAC. CLIENTE', C.Celular AS 'CELULAR CLIENTE', C.Telefono AS 'TELEFONO CLIENTE', C.Email  AS 'EMAIL CLIENTE', C.Direccion AS 'DIRECCION CLIENTE',
		GE.NombreGE, GE.DescripcionGE, GE.MatriculaOTituloGE, GE.ValorEstimadoGE,
		S.CodigoSolicitud, S.DescripcionInversion, (S.MontoSolicitado + S.GastosLegales) AS 'MONTO', S.CantidadCuotas, S.TasaInteresAnual, S.TasaComisionAnual, S.TasaSeguroAnual, S.MontoCuota, S.Fecha AS 'FECHA CREACION',
		TP.Descripcion AS 'TIPO DE PRESTAMO', FP.DescripcionFP AS 'FORMA DE PAGO', CP.Descripcion AS 'CLASE DE PRESTAMO', TG.Descripcion AS 'TIPO DE GARANTIA', RT.Descripcion AS 'RUTA', GT.Nombre AS 'GESTOR',
		DLC.Empresa AS 'EMPRESA LABOR CL', DLC.TelefonoEmp AS 'TELEFONO EMP CL', DLC.Cargo AS 'CARGO EMP CL', DLC.TiempoLaborando AS 'TIEMPO LABORANDO EMP CL', DLC.Sueldo AS 'SUELDO CL', DLC.OtroIngresos AS 'OTROS INGRESOS CL', DLC.DetalleOtroIngresos AS 'DETALLE OTRO CL', DLC.Gastos AS 'GASTOS CL', (DLC.Sueldo + DLC.OtroIngresos - DLC.Gastos) AS 'SUELDO NETO CL',
		EM.NombreEP, EM.RncEM, SU.NombreSU, SU.TelefonoSU, SU.DireccionSU, EM.LemaEM
 
FROM TSolicitudes S INNER JOIN TClientes C ON S.CodigoCliente = C.CodigoCliente
					INNER JOIN TDatosLaborables DLC ON S.CodigoCliente = DLC.CodigoCliente 
					INNER JOIN TGarantiaEconomica GE ON S.CodigoGarantia = GE.CodigoGarantia
					INNER JOIN TSucursales SU ON S.IdSucursal = SU.IdSucursal
					INNER JOIN TEmpresas EM ON SU.IdEmpresa = EM.IdEmpresa
					INNER JOIN TTipoPrestamos TP ON S.IdTipoPrestamo = TP.IdTipoPrestamo
					INNER JOIN TFormaPagos FP ON S.IdFormaPago = FP.IdFormaPago
					INNER JOIN TClasePrestamos CP ON S.IdClasePrestamo = CP.IdClasePrestamo
					INNER JOIN TTipoGarantias TG ON S.IdTipoGarantia = TG.IdTipoGarantia
					INNER JOIN TRutas RT ON S.IdRuta = RT.IdRuta
					INNER JOIN TGestores GT ON S.IdGestor = GT.IdGestor
					
WHERE S.CodigoSolicitud = @CODIGO_SOLICITUD

END

GO
/****** Object:  StoredProcedure [dbo].[SP_SOLICITUD_SOLOFIRMA]    Script Date: 26/4/20 10:06:22 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_SOLICITUD_SOLOFIRMA]

@CODIGO_SOLICITUD INT 
AS

BEGIN


SELECT 
        C.NoDocumento AS 'CEDULA CLIENTE', C.Nombre + ' ' + C.Apellido AS 'NOMBRE CLIENTE', C.Apodo AS 'APODO CLIENTE',  C.FechaNacimiento AS 'FECHA NAC. CLIENTE', C.Celular AS 'CELULAR CLIENTE', C.Telefono AS 'TELEFONO CLIENTE', C.Email  AS 'EMAIL CLIENTE', C.Direccion AS 'DIRECCION CLIENTE',
		S.CodigoSolicitud, S.DescripcionInversion, (S.MontoSolicitado + S.GastosLegales) AS 'MONTO', S.CantidadCuotas, S.TasaInteresAnual, S.TasaComisionAnual, S.TasaSeguroAnual, S.MontoCuota, S.Fecha AS 'FECHA CREACION',
		TP.Descripcion AS 'TIPO DE PRESTAMO', FP.DescripcionFP AS 'FORMA DE PAGO', CP.Descripcion AS 'CLASE DE PRESTAMO', TG.Descripcion AS 'TIPO DE GARANTIA', RT.Descripcion AS 'RUTA', GT.Nombre AS 'GESTOR',
		DLC.Empresa AS 'EMPRESA LABOR CL', DLC.TelefonoEmp AS 'TELEFONO EMP CL',  DLC.Cargo AS 'CARGO EMP CL', DLC.TiempoLaborando AS 'TIEMPO LABORANDO EMP CL', DLC.Sueldo AS 'SUELDO CL', DLC.OtroIngresos AS 'OTROS INGRESOS CL', DLC.DetalleOtroIngresos AS 'DETALLE OTRO CL', DLC.Gastos AS 'GASTOS CL', (DLC.Sueldo + DLC.OtroIngresos - DLC.Gastos) AS 'SUELDO NETO CL',
		EM.NombreEP, EM.RncEM, SU.NombreSU, SU.TelefonoSU, SU.DireccionSU, EM.LemaEM
 
FROM TSolicitudes S INNER JOIN TClientes C ON S.CodigoCliente = C.CodigoCliente
					INNER JOIN TDatosLaborables DLC ON S.CodigoCliente = DLC.CodigoCliente 
					INNER JOIN TSucursales SU ON S.IdSucursal = SU.IdSucursal
					INNER JOIN TEmpresas EM ON SU.IdEmpresa = EM.IdEmpresa
					INNER JOIN TTipoPrestamos TP ON S.IdTipoPrestamo = TP.IdTipoPrestamo
					INNER JOIN TFormaPagos FP ON S.IdFormaPago = FP.IdFormaPago
					INNER JOIN TClasePrestamos CP ON S.IdClasePrestamo = CP.IdClasePrestamo
					INNER JOIN TTipoGarantias TG ON S.IdTipoGarantia = TG.IdTipoGarantia
					INNER JOIN TRutas RT ON S.IdRuta = RT.IdRuta
					INNER JOIN TGestores GT ON S.IdGestor = GT.IdGestor
					
WHERE S.CodigoSolicitud = @CODIGO_SOLICITUD

END
GO
USE [master]
GO
ALTER DATABASE [system_prestamo] SET  READ_WRITE 
GO
