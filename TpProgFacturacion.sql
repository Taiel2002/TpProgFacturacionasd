USE [master]
GO
/****** Object:  Database [TpProgFacturacion]    Script Date: 10/11/2021 12:28:38 p.m. ******/
CREATE DATABASE [TpProgFacturacion]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TpProgFacturacion', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\TpProgFacturacion.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'TpProgFacturacion_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\TpProgFacturacion_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [TpProgFacturacion] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TpProgFacturacion].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TpProgFacturacion] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TpProgFacturacion] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TpProgFacturacion] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TpProgFacturacion] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TpProgFacturacion] SET ARITHABORT OFF 
GO
ALTER DATABASE [TpProgFacturacion] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TpProgFacturacion] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TpProgFacturacion] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TpProgFacturacion] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TpProgFacturacion] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TpProgFacturacion] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TpProgFacturacion] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TpProgFacturacion] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TpProgFacturacion] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TpProgFacturacion] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TpProgFacturacion] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TpProgFacturacion] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TpProgFacturacion] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TpProgFacturacion] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TpProgFacturacion] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TpProgFacturacion] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TpProgFacturacion] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TpProgFacturacion] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TpProgFacturacion] SET  MULTI_USER 
GO
ALTER DATABASE [TpProgFacturacion] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TpProgFacturacion] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TpProgFacturacion] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TpProgFacturacion] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [TpProgFacturacion] SET DELAYED_DURABILITY = DISABLED 
GO
USE [TpProgFacturacion]
GO
/****** Object:  Table [dbo].[articulos]    Script Date: 10/11/2021 12:28:38 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[articulos](
	[id_articulo] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [nvarchar](200) NOT NULL,
	[pre_unitario] [money] NOT NULL,
	[stock] [int] NULL,
	[pre_costo] [money] NOT NULL,
 CONSTRAINT [PK_articulos] PRIMARY KEY CLUSTERED 
(
	[id_articulo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[barrios]    Script Date: 10/11/2021 12:28:38 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[barrios](
	[id_barrio] [int] IDENTITY(1,1) NOT NULL,
	[barrio] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_barrios] PRIMARY KEY CLUSTERED 
(
	[id_barrio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[clientes]    Script Date: 10/11/2021 12:28:38 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[clientes](
	[id_cliente] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](100) NOT NULL,
	[apellido] [nvarchar](100) NOT NULL,
	[calle] [nvarchar](100) NULL,
	[altura] [nvarchar](50) NULL,
	[id_barrio] [int] NOT NULL,
	[email] [nvarchar](100) NULL,
	[tel] [nvarchar](20) NULL,
 CONSTRAINT [PK_clientes] PRIMARY KEY CLUSTERED 
(
	[id_cliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[detalles_factura]    Script Date: 10/11/2021 12:28:38 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[detalles_factura](
	[nro_factura] [int] NOT NULL,
	[id_articulo] [int] NOT NULL,
	[cantidad] [int] NOT NULL,
	[nro_detalle] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[facturas]    Script Date: 10/11/2021 12:28:38 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[facturas](
	[nro_factura] [int] IDENTITY(1,1) NOT NULL,
	[id_forma_pago] [int] NOT NULL,
	[id_cliente] [int] NOT NULL,
	[id_usuario] [int] NOT NULL,
	[fecha] [datetime] NOT NULL,
	[total] [numeric](8, 2) NOT NULL,
 CONSTRAINT [PK_facturas] PRIMARY KEY CLUSTERED 
(
	[nro_factura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[formas_pago]    Script Date: 10/11/2021 12:28:38 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[formas_pago](
	[id_forma_pago] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_formas_pago] PRIMARY KEY CLUSTERED 
(
	[id_forma_pago] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usuarios]    Script Date: 10/11/2021 12:28:38 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuarios](
	[id_usuario] [int] IDENTITY(1,1) NOT NULL,
	[usuario] [nvarchar](50) NOT NULL,
	[contraseña] [nvarchar](50) NOT NULL,
	[fecha_registro] [datetime] NOT NULL,
	[email] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_usuarios] PRIMARY KEY CLUSTERED 
(
	[id_usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[clientes]  WITH CHECK ADD  CONSTRAINT [FK_clientes_barrios] FOREIGN KEY([id_barrio])
REFERENCES [dbo].[barrios] ([id_barrio])
GO
ALTER TABLE [dbo].[clientes] CHECK CONSTRAINT [FK_clientes_barrios]
GO
ALTER TABLE [dbo].[detalles_factura]  WITH CHECK ADD  CONSTRAINT [FK_detalles_factura_articulos] FOREIGN KEY([id_articulo])
REFERENCES [dbo].[articulos] ([id_articulo])
GO
ALTER TABLE [dbo].[detalles_factura] CHECK CONSTRAINT [FK_detalles_factura_articulos]
GO
ALTER TABLE [dbo].[detalles_factura]  WITH CHECK ADD  CONSTRAINT [FK_detalles_factura_facturas] FOREIGN KEY([nro_factura])
REFERENCES [dbo].[facturas] ([nro_factura])
GO
ALTER TABLE [dbo].[detalles_factura] CHECK CONSTRAINT [FK_detalles_factura_facturas]
GO
ALTER TABLE [dbo].[facturas]  WITH CHECK ADD  CONSTRAINT [FK_facturas_clientes] FOREIGN KEY([id_cliente])
REFERENCES [dbo].[clientes] ([id_cliente])
GO
ALTER TABLE [dbo].[facturas] CHECK CONSTRAINT [FK_facturas_clientes]
GO
ALTER TABLE [dbo].[facturas]  WITH CHECK ADD  CONSTRAINT [FK_facturas_formas_pago] FOREIGN KEY([id_forma_pago])
REFERENCES [dbo].[formas_pago] ([id_forma_pago])
GO
ALTER TABLE [dbo].[facturas] CHECK CONSTRAINT [FK_facturas_formas_pago]
GO
ALTER TABLE [dbo].[facturas]  WITH CHECK ADD  CONSTRAINT [FK_facturas_usuarios] FOREIGN KEY([id_usuario])
REFERENCES [dbo].[usuarios] ([id_usuario])
GO
ALTER TABLE [dbo].[facturas] CHECK CONSTRAINT [FK_facturas_usuarios]
GO
/****** Object:  StoredProcedure [dbo].[pa_BorrarDetalleFactura]    Script Date: 10/11/2021 12:28:38 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[pa_BorrarDetalleFactura]
		@nroDetalle int
AS
BEGIN
	delete from detalles_factura
	where nro_detalle = @nroDetalle
END
GO
/****** Object:  StoredProcedure [dbo].[pa_BorrarFactura]    Script Date: 10/11/2021 12:28:38 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[pa_BorrarFactura]
		@nroFactura int
AS
BEGIN
	delete detalles_factura
	where nro_factura = @nroFactura

	delete from facturas
	where nro_factura = @nroFactura
END
GO
/****** Object:  StoredProcedure [dbo].[pa_CantidadArticuloFecha]    Script Date: 10/11/2021 12:28:38 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[pa_CantidadArticuloFecha]
	@FecDesde VARCHAR(10), 
	@FecHasta VARCHAR(10)
AS
BEGIN
	DECLARE @FecD DATE
	DECLARE @FecH DATE
	SET @FecD = CONVERT(date, @FecDesde, 103)
	SET @FecH = CONVERT(date, @FecHasta, 103)

	SELECT a.descripcion AS articulo, SUM(d.cantidad) AS cantidad_vendida
	FROM articulos AS a JOIN detalles_factura AS d ON a.id_articulo=d.id_articulo
		JOIN facturas AS f ON d.nro_factura=f.nro_factura
	WHERE f.fecha BETWEEN @FecD AND @FecH
	GROUP BY a.descripcion
END
GO
/****** Object:  StoredProcedure [dbo].[pa_ClienteMontoFormaPago]    Script Date: 10/11/2021 12:28:38 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[pa_ClienteMontoFormaPago]
	@FormaPago int 
AS
BEGIN
	SELECT c.apellido + ', ' + c.nombre AS Cliente, SUM(f.total) AS MontoTotal
	FROM clientes AS c JOIN facturas AS f ON c.id_cliente=f.id_cliente
	WHERE f.id_forma_pago=@FormaPago
	GROUP BY c.apellido + ', ' + c.nombre
END
GO
/****** Object:  StoredProcedure [dbo].[pa_ConsultarArticulos]    Script Date: 10/11/2021 12:28:38 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[pa_ConsultarArticulos]
AS
begin
	select *
	from articulos   
end
GO
/****** Object:  StoredProcedure [dbo].[pa_ConsultarBarrios]    Script Date: 10/11/2021 12:28:38 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[pa_ConsultarBarrios]
AS
begin
	select *
	from barrios   
end
GO
/****** Object:  StoredProcedure [dbo].[pa_ConsultarClientes]    Script Date: 10/11/2021 12:28:38 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[pa_ConsultarClientes]
AS
begin
	select *, nombre + ' ' + apellido
	from clientes
end
GO
/****** Object:  StoredProcedure [dbo].[pa_ConsultarFactura]    Script Date: 10/11/2021 12:28:38 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[pa_ConsultarFactura]
AS
BEGIN
	select f.nro_factura 'Numero de Factura', c.nombre + ' ' + c.apellido Cliente, 
		f.fecha Fecha, fp.descripcion 'Forma de pago', f.total Total
	from facturas f, clientes c, formas_pago fp
	where f.id_cliente = c.id_cliente and fp.id_forma_pago = f.id_forma_pago
END
GO
/****** Object:  StoredProcedure [dbo].[pa_ConsultarFormasPago]    Script Date: 10/11/2021 12:28:38 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[pa_ConsultarFormasPago]
AS
begin
	select *
	from formas_pago   
end
GO
/****** Object:  StoredProcedure [dbo].[pa_EditarArticulos]    Script Date: 10/11/2021 12:28:38 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[pa_EditarArticulos]
	@idArticulo int,
	@descripcion nvarchar(200),
	@preUnitario money,
	@stock int,
	@preCosto money
AS
BEGIN
	UPDATE articulos 
	SET descripcion = @descripcion ,
		pre_unitario = @preUnitario,
		pre_costo = @preCosto,
		stock = @stock
	WHERE id_articulo = @idArticulo;
	
END
GO
/****** Object:  StoredProcedure [dbo].[pa_EditarCliente]    Script Date: 10/11/2021 12:28:38 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[pa_EditarCliente]
	@idCliente int,
	@nombre nvarchar(100),
	@apellido nvarchar(100),
	@calle nvarchar(100),
	@email nvarchar(100),
	@telefono nvarchar(100),
	@altura nvarchar(50),
	@idBarrio nvarchar(200)
AS
BEGIN
	UPDATE clientes 
	SET nombre = @nombre ,
		apellido = @apellido,
		calle = @calle,
		email = @email,
		tel = @telefono,
		altura = @altura,
		id_barrio = @idBarrio
	WHERE id_cliente = @idCliente 
	
END
GO
/****** Object:  StoredProcedure [dbo].[pa_EditarFactura]    Script Date: 10/11/2021 12:28:38 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[pa_EditarFactura]
		@nroFactura int,
		@cliente int, 
		@formaPago int
AS
BEGIN
	update facturas
	set id_cliente = @cliente, id_forma_pago = @formaPago
	where nro_factura = @nroFactura
END
GO
/****** Object:  StoredProcedure [dbo].[pa_EliminarArticulo]    Script Date: 10/11/2021 12:28:38 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[pa_EliminarArticulo]
	@IdArticulo int
AS
begin
	delete articulos 
	where id_articulo = @IdArticulo 
end
GO
/****** Object:  StoredProcedure [dbo].[pa_EliminarCliente]    Script Date: 10/11/2021 12:28:38 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[pa_EliminarCliente]
	@IdCliente int
AS
begin
	delete clientes
	where id_cliente = @IdCliente
end
GO
/****** Object:  StoredProcedure [dbo].[pa_FiltrarPorCliente]    Script Date: 10/11/2021 12:28:38 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[pa_FiltrarPorCliente]
		@cliente nvarchar(100)
AS
BEGIN
	select f.nro_factura 'Numero de Factura', f.fecha Fecha, 
		fp.descripcion 'Forma de pago', f.total Total
	from facturas f, clientes c, formas_pago fp
	where f.id_cliente = c.id_cliente and fp.id_forma_pago = f.id_forma_pago 
		and c.nombre + ' ' + c.apellido = @cliente order by fecha
END
GO
/****** Object:  StoredProcedure [dbo].[pa_FiltrarPorFecha]    Script Date: 10/11/2021 12:28:38 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[pa_FiltrarPorFecha]
		@fecha datetime
AS
BEGIN
	select f.nro_factura 'Numero de Factura', c.nombre + ' ' + c.apellido Cliente, 
		fp.descripcion 'Forma de pago', f.total Total
	from facturas f	join clientes c on f.id_cliente = c.id_cliente 
		join formas_pago fp on f.id_forma_pago = fp.id_forma_pago
	where cast(f.fecha as date)= CAST(@fecha as date)
END
GO
/****** Object:  StoredProcedure [dbo].[pa_FiltrarPorFechas]    Script Date: 10/11/2021 12:28:38 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[pa_FiltrarPorFechas]
		@fecha1 datetime,
		@fecha2 datetime
AS
BEGIN
	select f.nro_factura 'Numero de Factura', c.nombre + ' ' + c.apellido Cliente, 
		fp.descripcion 'Forma de pago', f.total Total
	from facturas f	join clientes c on f.id_cliente = c.id_cliente 
		join formas_pago fp on f.id_forma_pago = fp.id_forma_pago
	where cast(f.fecha as date) between CAST(@fecha1 as date) and CAST(@fecha2 as date)
END
GO
/****** Object:  StoredProcedure [dbo].[pa_FiltrarPorFormaDePago]    Script Date: 10/11/2021 12:28:38 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[pa_FiltrarPorFormaDePago]
		@formaPago nvarchar(100)
AS
BEGIN
	select f.nro_factura 'Numero de Factura', c.nombre + ' ' + c.apellido Cliente, 
		f.fecha Fecha, f.total Total
	from facturas f, clientes c, formas_pago fp
	where f.id_cliente = c.id_cliente and fp.id_forma_pago = f.id_forma_pago
			and fp.descripcion = @formaPago order by fecha
END
GO
/****** Object:  StoredProcedure [dbo].[pa_InsertarArticulo]    Script Date: 10/11/2021 12:28:38 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[pa_InsertarArticulo]
	
	@idArticulo int,
	@descripcion nvarchar(200),
	@preUnitario money,
	@stock int,
	@preCosto money
AS
begin
	INSERT INTO articulos(descripcion,pre_unitario,stock,pre_costo)
    VALUES (@descripcion,@preUnitario,@stock,@preCosto);
    --Asignamos el valor del último ID autogenerado (obtenido --  
    --mediante la función SCOPE_IDENTITY() de SQLServer)	
    SET @idArticulo = SCOPE_IDENTITY()+1;
end
GO
/****** Object:  StoredProcedure [dbo].[pa_InsertarBarrio]    Script Date: 10/11/2021 12:28:38 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[pa_InsertarBarrio]
	@idBarrio int output,
	@barrio nvarchar(100)
AS
begin
	select barrios.barrio
	from barrios
	where barrio like @barrio
	--set @idBarrio = id_barrio
	and @idBarrio = id_barrio
end
GO
/****** Object:  StoredProcedure [dbo].[pa_InsertarCliente]    Script Date: 10/11/2021 12:28:38 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[pa_InsertarCliente]
	@nombre nvarchar(100),
	@apellido nvarchar (100),
	@calle nvarchar(100),
	@altura nvarchar (10),
	@idBarrio int,
	@email nvarchar(100),
	@tel nvarchar(20)
AS
begin
	INSERT INTO clientes(nombre,apellido,calle,altura,id_barrio,email,tel)
    VALUES (@nombre,@apellido,@calle,@altura,@idBarrio,@email,@tel);
    --Asignamos el valor del último ID autogenerado (obtenido --  
    --mediante la función SCOPE_IDENTITY() de SQLServer)	
   -- SET id_cliente = SCOPE_IDENTITY()+1;
end
GO
/****** Object:  StoredProcedure [dbo].[pa_InsertarDetalle]    Script Date: 10/11/2021 12:28:38 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[pa_InsertarDetalle]
	@nroFactura int,
	@idArticulo int,
	@cantidad int,
	@nroDetalle int 
AS
begin
	INSERT INTO detalles_factura(nro_factura,id_articulo,cantidad,nro_detalle)
    VALUES (@nroFactura,@idArticulo,@cantidad,@nroDetalle);
   
end
GO
/****** Object:  StoredProcedure [dbo].[pa_InsertarMaestro]    Script Date: 10/11/2021 12:28:38 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[pa_InsertarMaestro]
	
	@id_forma_pago int,            
	@id_cliente int,
	@id_usuario  int,            
	@fecha date  ,          
	@total money,
	@facturaNro int output
AS
begin
	INSERT INTO facturas(id_forma_pago,id_cliente,id_usuario,fecha,total)
    VALUES (@id_forma_pago,@id_cliente,@id_usuario, GETDATE(), @total);
    --Asignamos el valor del último ID autogenerado (obtenido --  
    --mediante la función SCOPE_IDENTITY() de SQLServer)	
    SET @facturaNro = SCOPE_IDENTITY();
end
GO
/****** Object:  StoredProcedure [dbo].[pa_InsertarUsuario]    Script Date: 10/11/2021 12:28:38 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[pa_InsertarUsuario]
	@idUsuario int,
	@usuario nvarchar(100),
	@contraseña	nvarchar(50),
	@fechaRegistro datetime,
	@email nvarchar(100)
AS
begin
	INSERT INTO usuarios(usuario,contraseña,fecha_registro,email)
    VALUES (@usuario,@contraseña,@fechaRegistro,@email)
	SET @idUsuario = SCOPE_IDENTITY();
end
GO
/****** Object:  StoredProcedure [dbo].[pa_Login]    Script Date: 10/11/2021 12:28:38 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[pa_Login]
	@usuario nvarchar(100),	
	@password nvarchar(100)
AS
begin
	SELECT *
	from usuarios u
	where	u.usuario = @usuario 
	and 	u.contraseña = @password 
end	
GO
/****** Object:  StoredProcedure [dbo].[pa_MostrarDetallesDeFactura]    Script Date: 10/11/2021 12:28:38 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[pa_MostrarDetallesDeFactura]
		@nroFactura int
AS
BEGIN
	select n.nro_detalle 'Numero de detalle', a.descripcion Articulo, n.cantidad Cantidad, pre_costo 'Precio', pre_costo * cantidad Total
	from detalles_factura n join articulos a on n.id_articulo = a.id_articulo
	where n.nro_factura = @nroFactura
END
GO
/****** Object:  StoredProcedure [dbo].[pa_PromMontoCliente]    Script Date: 10/11/2021 12:28:38 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[pa_PromMontoCliente]
	@Monto int 
AS
BEGIN
	SELECT c.apellido + ', ' + c.nombre AS Cliente, AVG(f.total) AS Monto_Promedio
	FROM clientes AS c JOIN facturas AS f ON c.id_cliente=f.id_cliente
		JOIN detalles_factura AS df ON f.nro_factura=df.nro_factura
	GROUP BY c.apellido + ', ' + c.nombre
	HAVING AVG(f.total)>@Monto
END
GO
/****** Object:  StoredProcedure [dbo].[pa_ProximoIdFactura]    Script Date: 10/11/2021 12:28:38 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create PROCEDURE [dbo].[pa_ProximoIdFactura]
@prox int OUTPUT
AS
BEGIN
	SET @prox = (SELECT MAX(nro_factura)+1  FROM facturas);
END
GO
/****** Object:  StoredProcedure [dbo].[pa_RecuperarFactura]    Script Date: 10/11/2021 12:28:38 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[pa_RecuperarFactura]
		@nroFactura int
AS
BEGIN
	select f.nro_factura nroFactura, u.usuario usuario, 
		c.nombre nombre, c.apellido apellido, fp.descripcion formaPago
	from facturas f, formas_pago fp, clientes c, usuarios u
	where f.id_forma_pago = fp.id_forma_pago and f.id_cliente = c.id_cliente
		and u.id_usuario = f.id_usuario and nro_factura = @nroFactura
END
GO
USE [master]
GO
ALTER DATABASE [TpProgFacturacion] SET  READ_WRITE 
GO
