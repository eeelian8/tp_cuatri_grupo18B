use SEGURIDAD_DB 
go
create table dbo.[ADMINISTRADORES](
	[Id] [int] identity(1,1) not null,
	[CodAdminitrador] [varchar](150) not null,
	[NivelRol] [int] not null,
	[Celular] [int] not null,
	[Nombre] [varchar](100) not null,
	[Apellido] [varchar](100) not null
)
go
create table dbo.GERENTES(
	[Id] [int] identity(1,1) not null,
	[CodGerente] [varchar](10) not null,
	[NivelRol] [int] not null,
	[Celular] [int] not null,
	[Nombre] [varchar](100) not null,
	[Apellido] [varchar](100) not null
)
go
create table dbo.ESPECIALIDADES(
	[Id] [int] identity(1,1) not null,
	[Nombre] [varchar](80) not null,
	[Descripcion] [varchar](150) null,
	constraint PK_NombreEspecialidad
    primary key nonclustered (Nombre),
)
go
create table dbo.TECNICOS(
	[Id] [int] identity(1,1) not null,
	[CodTecnico] [varchar] (10) not null,
	[NivelRol] [int] not null,
	[Celular] [int] not null,
	[Nombre] [varchar](100) not null,
	[Apellido] [varchar](100) not null,
	[Localidad][varchar](80) null,
	[Especialidad] [varchar](80) null,
	constraint PK_CodTecnicos
    primary key nonclustered (CodTecnico),
	constraint FK_EspecialidadTecnico foreign key (Especialidad)
	references ESPECIALIDADES(Nombre)
	on delete cascade
	on update cascade
)
go
create table dbo.RECEPCIONISTAS(
	[Id] [int] identity(1,1) not null,
	[CodRecepcionista] [varchar](10) not null,
	[NivelRol] [int] not null,
	[Celular] [int] not null,
	[Nombre] [varchar](100) not null,
	[Apellido] [varchar](100) not null
)
go
create table dbo.SOLICITUDES_TRABAJO(
	[Id] [int] identity(1,1) not null,
	[Dni] [int] not null,
	[TipoTrabajo] [varchar](120) null,
	[Nombre] [varchar](100) not null,
	[Apellido][varchar](100) not null,
	[Descripcion][varchar](150) not null,
	[Telefono][int] not null,
	[Direccion][varchar](120) not null,
	[Localidad][varchar](80) not null,
	[Provincia][varchar](80) not null,
	[Estado][int] not null,
	[TecnicoAsignado][varchar](10) null,
	constraint PK_IdSolicitudTrabajo
    primary key nonclustered (Id),
	constraint FK_TecnicoXsolicitud foreign key (TecnicoAsignado)
	references TECNICOS(CodTecnico)
	on delete cascade
	on update cascade
)
go
create table dbo.TIPOS_TRABAJO(
	[Id] [int] identity(1,1) not null,
	[Nombre] [varchar](50) not null,
	[Descripcion][varchar](150) null
)
go
create table dbo.IMAGENES_TRABAJO(
	[Id] [int] identity(1,1) not null,
	[ImgUrl] [varchar](150) not null,
	[IdTrabajo][int] not null,
	constraint FK_ImagenesXtrabajo foreign key (IdTrabajo)
	references SOLICITUDES_TRABAJO(Id)
	on delete cascade
	on update cascade
)
go
create table dbo.USER_X_PASSWORD(
	[Id] [int] identity(1,1) not null,
	[User] [varchar](50) not null,
	[Pass] [varchar](100) not null
)
go
create table dbo.IMAGENES_TECNICO(
	[Id] [int] identity(1,1) not null,
	[ImgUrl] [varchar](150) not null,
	[CodTecnico] [varchar](10) not null,
	constraint FK_ImgTecnico foreign key (CodTecnico)
	references TECNICOS(CodTecnico)
	on delete cascade
	on update cascade
)
go
create table dbo.USUARIOS(
	[Id][int] identity(1,1) not null,
	[Usuario][varchar](20) not null,
	[Password][varchar](20) not null,
	[NivelRol][int] not null,
	constraint PK_Usuarios
    primary key nonclustered (Usuario)
)

INSERT INTO dbo.USUARIOS ([Usuario], [Password], [NivelRol])
VALUES
('adm001', 'administracion2024', 1),
('ger001', 'gerencia2024', 2),
('tec001', 'tecnico2024', 3),
('tec002', 'tecnico2024', 3),
('rec001', 'recepcion2024', 4)

INSERT INTO dbo.[ADMINISTRADORES] ([CodAdminitrador], [NivelRol], [Celular], [Nombre], [Apellido])
VALUES 
('ADMIN001', 1, 987654321, 'Juan', 'Pérez'),
('ADMIN002', 1, 912345678, 'María', 'Gómez'),
('ADMIN003', 1, 923456789, 'Carlos', 'Ramírez'),
('ADMIN004', 1, 934567890, 'Ana', 'Martínez');


INSERT INTO dbo.[GERENTES] ([CodGerente], [NivelRol], [Celular], [Nombre], [Apellido])
VALUES 
('G001', 2, 987654321, 'Luis', 'García'),
('G002', 2, 912345678, 'Laura', 'Hernández'),
('G003', 2, 923456789, 'Jorge', 'Rodríguez'),
('G004', 2, 934567890, 'Carla', 'Sánchez'),
('G005', 2, 945678901, 'Pedro', 'Martínez');

INSERT INTO dbo.[ESPECIALIDADES] ([Nombre], [Descripcion])
VALUES 
('Electricidad Residencial', 'Instalación y mantenimiento de sistemas eléctricos en viviendas y residencias.'),
('Electricidad Industrial', 'Mantenimiento y reparación de maquinaria y sistemas eléctricos en fábricas e industrias.'),
('Electricidad Comercial', 'Instalación de sistemas eléctricos en tiendas, oficinas y edificios comerciales.'),
('Automatización', 'Configuración y mantenimiento de sistemas de automatización y control industrial.'),
('Redes de Baja Tensión', 'Instalación y mantenimiento de redes de baja tensión para diversos tipos de edificaciones.'),
('Mantenimiento de Subestaciones', 'Revisión y reparación de equipos en subestaciones eléctricas.'),
('Energía Solar', 'Instalación y mantenimiento de paneles solares y sistemas de energía renovable.');

INSERT INTO dbo.[TECNICOS] ([CodTecnico], [NivelRol], [Celular], [Nombre], [Apellido], [Localidad], [Especialidad])
VALUES 
('T001', 3, 987654321, 'Carlos', 'López', 'Pilar' ,'Electricidad Residencial'),
('T002', 3, 912345678, 'María', 'Fernández', 'Tigre','Electricidad Industrial'),
('T003', 3, 923456789, 'Juan', 'Pérez', 'Lanus', 'Automatización'),
('T004', 3, 934567890, 'Ana', 'Martínez', 'Belgrano', 'Redes de Baja Tensión'),
('T005', 3, 945678901, 'Pedro', 'Rodríguez', '9 de julio', 'Mantenimiento de Subestaciones'),
('T006', 3, 956789012, 'Luis', 'González', 'Palermo', 'Energía Solar'),
('T007', 3, 967890123, 'Laura', 'Hernández', 'Moreno', 'Electricidad Comercial');

INSERT INTO dbo.[RECEPCIONISTAS] ([CodRecepcionista], [NivelRol], [Celular], [Nombre], [Apellido])
VALUES 
('RC001', 4, 987654321, 'Lucía', 'Gómez'),
('RC002', 4, 912345678, 'Fernando', 'Ríos'),
('RC003', 4, 923456789, 'Claudia', 'Lara'),
('RC004', 4, 934567890, 'Diego', 'Sosa'),
('RC005', 4, 945678901, 'Patricia', 'Méndez');

INSERT INTO dbo.[TIPOS_TRABAJO] ([Nombre], [Descripcion])
VALUES 
('Instalación de toma corriente', 'Instalación de tomas de corriente en diferentes espacios de la vivienda.'),
('Reparación de cableado', 'Reparación de cables dañados o deteriorados en el sistema eléctrico.'),
('Mantenimiento de sistema eléctrico', 'Revisión y mantenimiento general de todo el sistema eléctrico de la vivienda.'),
('Instalación de iluminación exterior', 'Instalación de sistemas de iluminación en áreas exteriores, como patios y jardines.'),
('Cambio de interruptor', 'Sustitución de interruptores de luz dañados o no funcionales.'),
('Instalación de paneles solares', 'Instalación de sistemas de paneles solares para energía renovable.'),
('Diagnóstico eléctrico', 'Análisis y diagnóstico de fallas en el sistema eléctrico de la propiedad.');

INSERT INTO dbo.[SOLICITUDES_TRABAJO] 
([Dni], [TipoTrabajo], [Nombre], [Apellido], [Descripcion], [Telefono], [Direccion], [Localidad], [Provincia], [Estado], [TecnicoAsignado])
VALUES 
(12345678, 'Instalación de toma corriente', 'Santiago', 'Pérez', 'Solicitud para instalar tomas de corriente en sala de estar.', 987654321, 'Av. Principal 123', 'Buenos Aires', 'Buenos Aires', 1, 'T001'),
(87654321, 'Reparación de cableado', 'Ana', 'López', 'Reparación de cableado dañado en cocina.', 912345678, 'Calle Falsa 456', 'CABA', 'Buenos Aires', 2, 'T002'),
(23456789, 'Mantenimiento de sistema eléctrico', 'Carlos', 'González', 'Revisión completa del sistema eléctrico de la vivienda.', 923456789, 'Diagonal 789', 'La Plata', 'Buenos Aires', 1, 'T003'),
(34567890, 'Instalación de iluminación exterior', 'Laura', 'Martínez', 'Instalación de luces en el patio exterior.', 934567890, 'Ruta 8 km 10', 'Tigre', 'Buenos Aires', 1, 'T002'),
(45678901, 'Cambio de interruptor', 'Diego', 'Sosa', 'Cambio de interruptor de luz dañado.', 945678901, 'Calle del Sol 321', 'Quilmes', 'Buenos Aires', 3, 'T001');
