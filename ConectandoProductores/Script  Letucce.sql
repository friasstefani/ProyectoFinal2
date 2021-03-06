USE [master]
GO
/****** Object:  Database [LETTUCE]    Script Date: 8/4/2015 4:21:41 AM ******/
CREATE DATABASE [LETTUCE] 
GO
USE [LETTUCE]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 8/4/2015 4:21:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[IdCliente] [int] IDENTITY(1,1) NOT NULL,
	[IdUsuario] [int] NULL,
	[Nombres] [nvarchar](100) NULL,
	[Apellidos] [nvarchar](100) NULL,
	[Email] [nvarchar](255) NULL,
	[Telefono] [nvarchar](10) NULL,
	[Celular] [nvarchar](10) NULL,
	[Direccion] [nvarchar](100) NULL,
	[Cedula] [nvarchar](13) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Medidas]    Script Date: 8/4/2015 4:21:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Medidas](
	[IdMedidas] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdMedidas] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Pedidos]    Script Date: 8/4/2015 4:21:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pedidos](
	[IdPedidos] [int] IDENTITY(1,1) NOT NULL,
	[IdCliente] [int] NULL,
	[Fecha] [datetime] NULL,
	[Total] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdPedidos] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PedidosDetalles]    Script Date: 8/4/2015 4:21:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PedidosDetalles](
	[IdDetalle] [int] IDENTITY(1,1) NOT NULL,
	[IdPedidos] [int] NULL,
	[IdProducto] [int] NULL,
	[IdProductor] [int] NULL,
	[Cantidad] [float] NULL,
	[Precio] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdDetalle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Productores]    Script Date: 8/4/2015 4:21:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Productores](
	[IdProductor] [int] IDENTITY(1,1) NOT NULL,
	[IdUsuario] [int] NULL,
	[Nombres] [nvarchar](100) NULL,
	[Apellidos] [nvarchar](100) NULL,
	[Telefono] [nvarchar](10) NULL,
	[Celular] [nvarchar](10) NULL,
	[Email] [nvarchar](255) NULL,
	[Direccion] [nvarchar](100) NULL,
	[Cedula] [nvarchar](13) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdProductor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Productos]    Script Date: 8/4/2015 4:21:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Productos](
	[IdProducto] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](100) NULL,
	[Precio] [float] NULL,
	[Imagen] [nvarchar](400) NULL,
	[IdMedida] [int] NULL,
	[Nombre] [varchar](100) NOT NULL DEFAULT (''),
	[Estado] [bit] NULL DEFAULT ((0)),
	[IdProductor] [int] NULL DEFAULT ((0)),
PRIMARY KEY CLUSTERED 
(
	[IdProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 8/4/2015 4:21:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Clave] [nvarchar](20) NULL,
	[Nombres] [nvarchar](50) NULL,
	[Estado] [int] NULL,
	[IdTipoUsuario] [int] NULL DEFAULT ((1)),
PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_Nombres] UNIQUE NONCLUSTERED 
(
	[Nombres] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Clientes]  WITH CHECK ADD FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuarios] ([IdUsuario])
GO
ALTER TABLE [dbo].[Pedidos]  WITH CHECK ADD FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Clientes] ([IdCliente])
GO
ALTER TABLE [dbo].[PedidosDetalles]  WITH CHECK ADD FOREIGN KEY([IdProductor])
REFERENCES [dbo].[Productores] ([IdProductor])

GO
ALTER TABLE [dbo].[PedidosDetalles]  WITH CHECK ADD FOREIGN KEY([IdPedidos])
REFERENCES [dbo].[Pedidos] ([IdPedidos])

GO
ALTER TABLE [dbo].[PedidosDetalles]  WITH CHECK ADD  CONSTRAINT [FK_PedidosDetalles_Productos] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Productos] ([IdProducto])
GO
ALTER TABLE [dbo].[PedidosDetalles] CHECK CONSTRAINT [FK_PedidosDetalles_Productos]
GO
ALTER TABLE [dbo].[Productores]  WITH CHECK ADD FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuarios] ([IdUsuario])
GO
ALTER TABLE [dbo].[Productos]  WITH CHECK ADD FOREIGN KEY([IdMedida])
REFERENCES [dbo].[Medidas] ([IdMedidas])
GO
ALTER TABLE [dbo].[Productos]  WITH CHECK ADD  CONSTRAINT [FK_Productos_Productores] FOREIGN KEY([IdProductor])
REFERENCES [dbo].[Productores] ([IdProductor])
GO
ALTER TABLE [dbo].[Productos] CHECK CONSTRAINT [FK_Productos_Productores]
GO
USE [master]
GO
ALTER DATABASE [LETTUCE] SET  READ_WRITE 
GO
SET IDENTITY_INSERT Usuarios ON 
  Insert Into Usuarios(IdUsuario, Clave, Nombres, Estado, IdTipoUsuario)
  Values(1,'123','StefaniFrias',1,1)
SET IDENTITY_INSERT Usuarios OFF 
GO

GO
SET IDENTITY_INSERT Productores ON 
  Insert Into Productores (IdProductor,IdUsuario, Nombres, Apellidos, Telefono, Celular, Email, Direccion, Cedula) 
  Values(1,1,'Stefani','Frias','','','','','')
SET IDENTITY_INSERT Productores OFF 
GO

GO
SET IDENTITY_INSERT clientes ON 
  Insert Into clientes (IdCliente,IdUsuario, Nombres, Apellidos, Telefono, Celular, Email, Direccion, Cedula) 
  Values(1,1,'Stefani','Frias','','','','','')
SET IDENTITY_INSERT clientes OFF 
GO


GO
SET IDENTITY_INSERT Usuarios ON 
  Insert Into Usuarios(IdUsuario, Clave, Nombres, Estado, IdTipoUsuario)
  Values(2,'123','Enel',1,1)
SET IDENTITY_INSERT Usuarios OFF 
GO

GO
SET IDENTITY_INSERT Productores ON 
  Insert Into Productores (IdProductor,IdUsuario, Nombres, Apellidos, Telefono, Celular, Email, Direccion, Cedula) 
  Values(2,2,'Enel','Almonte','','','','','')
SET IDENTITY_INSERT Productores OFF 
GO
 
GO
SET IDENTITY_INSERT clientes ON 
  Insert Into clientes (IdCliente,IdUsuario, Nombres, Apellidos, Telefono, Celular, Email, Direccion, Cedula) 
  Values(2,2,'Enel','Almonte','','','','','')
SET IDENTITY_INSERT clientes OFF 
GO


insert into Medidas(Descripcion) Values ('Libras')
insert into Medidas(Descripcion) Values ('Quintales')
insert into Medidas(Descripcion) Values ('Sacos')
insert into Medidas(Descripcion) Values ('Unidades')

 
  
 GO
insert into Productos(Nombre,Descripcion,Precio,Imagen,IdMedida,IdProductor) 
Values ('Salami concentrado','Salami concentrado',50,'http://www.bertocchi.com.au/Upload/Product/Photo/Photo46.jpg',1,1)
 
insert into Productos(Nombre,Descripcion,Precio,Imagen,IdMedida,IdProductor) 
Values ('Pan Sobao','Pan Sobao',05,'http://almomento.net/wp-content/uploads/2015/03/secondaryImage_3587.jpg',1,1)  

insert into Productos(Nombre,Descripcion,Precio,Imagen,IdMedida,IdProductor) 
Values ('Lechuga Repollada','Lechuga Repollada',25,'http://www.bayercropscience.cl/upfiles/cultivos/20100524001836663544_lechuga.jpg',1,1)  

insert into Productos(Nombre,Descripcion,Precio,Imagen,IdMedida,IdProductor) 
Values ('LEchuga inglesa','LEchuga inglesa',30,'http://blog.casapia.com/wp-content/uploads/2012/07/lechuga2.jpg',1,1) 

insert into Productos(Nombre,Descripcion,Precio,Imagen,IdMedida,IdProductor) 
Values ('Lechuga española','Lechuga española',55,'http://www.sanar.org/files/sanar/alimentos-que-pueden-contaminar.jpg',1,1)   
GO

GO   
insert into Productos(Nombre,Descripcion,Precio,Imagen,IdMedida,IdProductor) 
Values ('Piñas Dominicanas','Piñas Dominicanas importadas',350,'http://sipse.com/imgs/022013/080213fd80ea5abmed.jpg',1,2) 

insert into Productos(Nombre,Descripcion,Precio,Imagen,IdMedida,IdProductor) 
Values ('Cacao Cibaeño','El mejor Cacao Cibaeño',120,'http://t2.gstatic.com/images?q=tbn:ANd9GcQyp82MwOaLWMjDwubqV8jKYK33D218UmPVrxsFxkt3SU5EFs64',1,2)  

insert into Productos(Nombre,Descripcion,Precio,Imagen,IdMedida,IdProductor) 
Values ('Tomates Barcelo','Tomates Barcelo totalmente garantizados',900,'http://img.informador.com.mx/biblioteca/imagen/370x277/764/763624.jpg',1,2)  

insert into Productos(Nombre,Descripcion,Precio,Imagen,IdMedida,IdProductor) 
Values ('Combo Leche','Combo Leche que incluye varios productos',300,'http://katyarenas.com/wp-content/uploads/2015/03/light.jpg',1,2)
 
insert into Productos(Nombre,Descripcion,Precio,Imagen,IdMedida,IdProductor) 
Values ('Uvas del Monte','Estas son las mejores Uvas',300,'http://www.prochile.gob.cl/wp-content/uploads/2014/12/uva3_red_globe.jpg',1,2)
 
insert into Productos(Nombre,Descripcion,Precio,Imagen,IdMedida,IdProductor) 
Values ('Maiz Mazorca','Maiz Mazorca',1200,'http://images.prensa.com/economia/provincia-Santos-productores-preparan-cosecha_LPRIMA20150104_0074_23.jpg',1,2)   
GO
