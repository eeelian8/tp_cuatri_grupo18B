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
	constraint PK_IdTecnicos
    primary key nonclustered (Id),
	constraint FK_EspecialidadTecnico foreign key (Especialidad)
	references ESPECIALIDADES(Nombre)
	on delete cascade
	on update cascade
)
go
create table dbo.RECEPCIONISTAS(
	[Id] [int] identity(1,1) not null,
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
	constraint PK_IdSolicitudTrabajo
    primary key nonclustered (Id),
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
	[IdTecnico] [int] not null,
	constraint FK_ImgTecnico foreign key (IdTecnico)
	references TECNICOS(Id)
	on delete cascade
	on update cascade
)

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

INSERT INTO dbo.[RECEPCIONISTAS] ([NivelRol], [Celular], [Nombre], [Apellido])
VALUES 
(4, 987654321, 'Luc�a', 'G�mez'),
(4, 912345678, 'Fernando', 'R�os'),
(4, 923456789, 'Claudia', 'Lara'),
(4, 934567890, 'Diego', 'Sosa'),
(4, 945678901, 'Patricia', 'M�ndez');

INSERT INTO dbo.[SOLICITUDES_TRABAJO] ([Dni], [TipoTrabajo], [Nombre], [Apellido], [Descripcion], [Telefono], [Direccion], [Localidad], [Provincia], [Estado])
VALUES 
(12345678, 'Instalaci�n de toma corriente', 'Santiago', 'P�rez', 'Solicitud para la instalaci�n de tomas de corriente en la sala de estar.', 987654321, 'Av. Principal 123', 'Buenos Aires', 'Buenos Aires', 1),
(87654321, 'Reparaci�n de cableado', 'Ana', 'L�pez', 'Necesito reparar el cableado de la cocina que se ha da�ado.', 912345678, 'Calle Falsa 456', 'CABA', 'Buenos Aires', 2),
(23456789, 'Mantenimiento de sistema el�ctrico', 'Carlos', 'Gonz�lez', 'Revisar el sistema el�ctrico completo de la vivienda.', 923456789, 'Diagonal 789', 'La Plata', 'Buenos Aires', 1),
(34567890, 'Instalaci�n de iluminaci�n exterior', 'Laura', 'Mart�nez', 'Instalaci�n de luces en el patio exterior.', 934567890, 'Ruta 8 km 10', 'Tigre', 'Buenos Aires', 1),
(45678901, 'Cambio de interruptor', 'Diego', 'Sosa', 'Solicito el cambio de un interruptor de luz que no funciona.', 945678901, 'Calle del Sol 321', 'Quilmes', 'Buenos Aires', 3);

INSERT INTO dbo.[TIPOS_TRABAJO] ([Nombre], [Descripcion])
VALUES 
('Instalaci�n de toma corriente', 'Instalaci�n de tomas de corriente en diferentes espacios de la vivienda.'),
('Reparaci�n de cableado', 'Reparaci�n de cables da�ados o deteriorados en el sistema el�ctrico.'),
('Mantenimiento de sistema el�ctrico', 'Revisi�n y mantenimiento general de todo el sistema el�ctrico de la vivienda.'),
('Instalaci�n de iluminaci�n exterior', 'Instalaci�n de sistemas de iluminaci�n en �reas exteriores, como patios y jardines.'),
('Cambio de interruptor', 'Sustituci�n de interruptores de luz da�ados o no funcionales.'),
('Instalaci�n de paneles solares', 'Instalaci�n de sistemas de paneles solares para energ�a renovable.'),
('Diagn�stico el�ctrico', 'An�lisis y diagn�stico de fallas en el sistema el�ctrico de la propiedad.');
