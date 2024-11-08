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
('ADMIN001', 1, 987654321, 'Juan', 'P�rez'),
('ADMIN002', 1, 912345678, 'Mar�a', 'G�mez'),
('ADMIN003', 1, 923456789, 'Carlos', 'Ram�rez'),
('ADMIN004', 1, 934567890, 'Ana', 'Mart�nez');


INSERT INTO dbo.[GERENTES] ([CodGerente], [NivelRol], [Celular], [Nombre], [Apellido])
VALUES 
('G001', 2, 987654321, 'Luis', 'Garc�a'),
('G002', 2, 912345678, 'Laura', 'Hern�ndez'),
('G003', 2, 923456789, 'Jorge', 'Rodr�guez'),
('G004', 2, 934567890, 'Carla', 'S�nchez'),
('G005', 2, 945678901, 'Pedro', 'Mart�nez');

INSERT INTO dbo.[ESPECIALIDADES] ([Nombre], [Descripcion])
VALUES 
('Electricidad Residencial', 'Instalaci�n y mantenimiento de sistemas el�ctricos en viviendas y residencias.'),
('Electricidad Industrial', 'Mantenimiento y reparaci�n de maquinaria y sistemas el�ctricos en f�bricas e industrias.'),
('Electricidad Comercial', 'Instalaci�n de sistemas el�ctricos en tiendas, oficinas y edificios comerciales.'),
('Automatizaci�n', 'Configuraci�n y mantenimiento de sistemas de automatizaci�n y control industrial.'),
('Redes de Baja Tensi�n', 'Instalaci�n y mantenimiento de redes de baja tensi�n para diversos tipos de edificaciones.'),
('Mantenimiento de Subestaciones', 'Revisi�n y reparaci�n de equipos en subestaciones el�ctricas.'),
('Energ�a Solar', 'Instalaci�n y mantenimiento de paneles solares y sistemas de energ�a renovable.');

INSERT INTO dbo.[TECNICOS] ([CodTecnico], [NivelRol], [Celular], [Nombre], [Apellido], [Localidad], [Especialidad])
VALUES 
('T001', 3, 987654321, 'Carlos', 'L�pez', 'Pilar' ,'Electricidad Residencial'),
('T002', 3, 912345678, 'Mar�a', 'Fern�ndez', 'Tigre','Electricidad Industrial'),
('T003', 3, 923456789, 'Juan', 'P�rez', 'Lanus', 'Automatizaci�n'),
('T004', 3, 934567890, 'Ana', 'Mart�nez', 'Belgrano', 'Redes de Baja Tensi�n'),
('T005', 3, 945678901, 'Pedro', 'Rodr�guez', '9 de julio', 'Mantenimiento de Subestaciones'),
('T006', 3, 956789012, 'Luis', 'Gonz�lez', 'Palermo', 'Energ�a Solar'),
('T007', 3, 967890123, 'Laura', 'Hern�ndez', 'Moreno', 'Electricidad Comercial');

INSERT INTO dbo.[RECEPCIONISTAS] ([CodRecepcionista], [NivelRol], [Celular], [Nombre], [Apellido])
VALUES 
('RC001', 4, 987654321, 'Luc�a', 'G�mez'),
('RC002', 4, 912345678, 'Fernando', 'R�os'),
('RC003', 4, 923456789, 'Claudia', 'Lara'),
('RC004', 4, 934567890, 'Diego', 'Sosa'),
('RC005', 4, 945678901, 'Patricia', 'M�ndez');

INSERT INTO dbo.[TIPOS_TRABAJO] ([Nombre], [Descripcion])
VALUES 
('Instalaci�n de toma corriente', 'Instalaci�n de tomas de corriente en diferentes espacios de la vivienda.'),
('Reparaci�n de cableado', 'Reparaci�n de cables da�ados o deteriorados en el sistema el�ctrico.'),
('Mantenimiento de sistema el�ctrico', 'Revisi�n y mantenimiento general de todo el sistema el�ctrico de la vivienda.'),
('Instalaci�n de iluminaci�n exterior', 'Instalaci�n de sistemas de iluminaci�n en �reas exteriores, como patios y jardines.'),
('Cambio de interruptor', 'Sustituci�n de interruptores de luz da�ados o no funcionales.'),
('Instalaci�n de paneles solares', 'Instalaci�n de sistemas de paneles solares para energ�a renovable.'),
('Diagn�stico el�ctrico', 'An�lisis y diagn�stico de fallas en el sistema el�ctrico de la propiedad.');

INSERT INTO dbo.[SOLICITUDES_TRABAJO] 
([Dni], [TipoTrabajo], [Nombre], [Apellido], [Descripcion], [Telefono], [Direccion], [Localidad], [Provincia], [Estado], [TecnicoAsignado])
VALUES 
(12345678, 'Instalaci�n de toma corriente', 'Santiago', 'P�rez', 'Solicitud para instalar tomas de corriente en sala de estar.', 987654321, 'Av. Principal 123', 'Buenos Aires', 'Buenos Aires', 1, 'T001'),
(87654321, 'Reparaci�n de cableado', 'Ana', 'L�pez', 'Reparaci�n de cableado da�ado en cocina.', 912345678, 'Calle Falsa 456', 'CABA', 'Buenos Aires', 2, 'T002'),
(23456789, 'Mantenimiento de sistema el�ctrico', 'Carlos', 'Gonz�lez', 'Revisi�n completa del sistema el�ctrico de la vivienda.', 923456789, 'Diagonal 789', 'La Plata', 'Buenos Aires', 1, 'T003'),
(34567890, 'Instalaci�n de iluminaci�n exterior', 'Laura', 'Mart�nez', 'Instalaci�n de luces en el patio exterior.', 934567890, 'Ruta 8 km 10', 'Tigre', 'Buenos Aires', 1, 'T002'),
(45678901, 'Cambio de interruptor', 'Diego', 'Sosa', 'Cambio de interruptor de luz da�ado.', 945678901, 'Calle del Sol 321', 'Quilmes', 'Buenos Aires', 3, 'T001');
