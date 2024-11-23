create database SEGURIDAD_DB 
go 
use SEGURIDAD_DB
go
create table ADMINISTRADORES(
	[Id] [int] identity(1,1) not null,
	[CodAdminitrador] [varchar](10) not null,
	[NivelRol] [int] not null,
	[Celular] [int] not null,
	[Nombre] [varchar](100) not null,
	[Apellido] [varchar](100) not null,
	[NroDocumento][int] not null
)
go
create table GERENTES(
	[Id] [int] identity(1,1) not null,
	[CodGerente] [varchar](10) not null,
	[NivelRol] [int] not null,
	[Celular] [int] not null,
	[Nombre] [varchar](100) not null,
	[Apellido] [varchar](100) not null,
	[NroDocumento][int] not null
)
go
create table TECNICOS(
	[Id] [int] identity(1,1) not null,
	[CodTecnico] [varchar] (10) not null,
	[NivelRol] [int] not null,
	[Celular] [int] not null,
	[Nombre] [varchar](100) not null,
	[Apellido] [varchar](100) not null,
	[Provincia][varchar](80) not null,
	[Localidad][varchar](80) null,
	[NroDocumento][int] not null,
	constraint PK_CodTecnicos
    primary key nonclustered (CodTecnico)
)
go
create table RECEPCIONISTAS(
	[Id] [int] identity(1,1) not null,
	[CodRecepcionista] [varchar](10) not null,
	[NivelRol] [int] not null,
	[Celular] [int] not null,
	[Nombre] [varchar](100) not null,
	[Apellido] [varchar](100) not null,
	[NroDocumento][int] not null
)
go
create table TIPOS_TRABAJO(
	[Id] [int] identity(1,1) not null,
	[Nombre] [varchar](50) not null,
	[Descripcion][varchar](150) null,
	[DuracionCantDias][int] not null,
	constraint PK_TiposTrabajo
    primary key nonclustered (Id)
)
go
create table SOLICITUDES_TRABAJO(
	[Id][int] identity(1,1) not null,
	[DniCliente] [int] not null,
	[IdTipoTrabajo][int] not null,
	[NombreCliente] [varchar](100) not null,
	[ApellidoCliente][varchar](100) not null,
	[DescripcionTrabajo][varchar](150) not null,
	[TelefonoCliente][int] not null,
	[DireccionCliente][varchar](120) not null,
	[LocalidadCliente][varchar](80) not null,
	[ProvinciaCliente][varchar](80) not null,
	[Estado][int] not null,
	[TecnicoAsignado][varchar](10) null,
	constraint PK_IdSolicitudTrabajo
    primary key nonclustered (Id),
	constraint FK_TecnicoXsolicitud foreign key (TecnicoAsignado)
	references TECNICOS(CodTecnico)
	on delete cascade
	on update cascade,
	constraint FK_TipoTrabajoXsolicitud foreign key (IdTipoTrabajo)
	references TIPOS_TRABAJO(Id)
	on delete cascade
	on update cascade
)
go
create table FECHAS_TRABAJO(
	[Id][int] identity(1, 1) not null,
	[IdSolicitudTrabajo][int] not null,
	[FechaAsignacionTecnico][date] null,
	[FechaInicio][date] null,
	[FechaFin][date] null,
	constraint FK_FechasXsolicitud foreign key (IdSolicitudTrabajo)
	references SOLICITUDES_TRABAJO(Id)
	on delete cascade
	on update cascade
)
go


create table REPORTES_TRABAJO(
	[Id][int] identity(1, 1) not null,
	[IdSolicitudTrabajo][int] not null,
	[FechaReporte][date] not null,
	[DescripcionReporte][varchar](150) not null,
	constraint FK_ReportesXsolicitud foreign key (IdSolicitudTrabajo)
	references SOLICITUDES_TRABAJO(Id)
	on delete cascade
	on update cascade
)
go
create table IMAGENES_TRABAJO(
	[Id] [int] identity(1,1) not null,
	[ImgUrl] [varchar](150) not null,
	[IdTrabajo][int] not null,
	constraint FK_ImagenesXtrabajo foreign key (IdTrabajo)
	references SOLICITUDES_TRABAJO(Id)
	on delete cascade
	on update cascade
)
go
create table IMAGENES_TECNICO(
	[Id] [int] identity(1,1) not null,
	[ImgUrl] [varchar](150) not null,
	[CodTecnico] [varchar](10) not null,
	constraint FK_ImgTecnico foreign key (CodTecnico)
	references TECNICOS(CodTecnico)
	on delete cascade
	on update cascade
)
go
create table USUARIOS(
	[Id][int] identity(1,1) not null,
	[Usuario][varchar](50) not null,
	[Password][varchar](50) not null,
	[NivelRol][int] not null,
	[NroDocumento][int] not null,
	constraint PK_Usuarios
    primary key nonclustered (Usuario)
)

create table ETAPAS_TRABAJO(
	[Id][int] identity(1,1) not null,
	[IdTipoTrabajo][int] not null,
	[Etapa][varchar](120) not null
	constraint FK_etapasXtrabajo foreign key (IdTipoTrabajo)
	references TIPOS_TRABAJO(Id)
	on delete cascade
	on update cascade
)

INSERT INTO dbo.[GERENTES] ([CodGerente], [NivelRol], [Celular], [Nombre], [Apellido], [NroDocumento])
VALUES 
('G001', 2, 987654321, 'Luis', 'García', 4423254);

INSERT INTO dbo.[TECNICOS] ([CodTecnico], [NivelRol], [Celular], [Nombre], [Apellido], [Localidad], [Provincia], [NroDocumento])
VALUES 
('T001', 3, 987654321, 'Carlos', 'López', 'Pilar' ,'Buenos aires', 41565789),
('T002', 3, 912345678, 'Maria', 'Fernández', 'Tigre','Buenos aires', 51565729),
('T003', 3, 923456789, 'Juan', 'Pérez', 'Lanus', 'Buenos aires', 43666219);

INSERT INTO dbo.[RECEPCIONISTAS] ([CodRecepcionista], [NivelRol], [Celular], [Nombre], [Apellido], [NroDocumento])
VALUES 
('RC001', 4, 987654321, 'Lucía', 'Gómez', 22398564);

INSERT INTO dbo.USUARIOS ([Usuario], [Password], [NivelRol], [NroDocumento])
VALUES
('adm001', 'administracion2024', 1, 20507899),
('ger001', 'gerencia2024', 2, 4423254),
('tec001', 'tecnico2024', 3, 41565789),
('tec002', 'tecnico2024', 3, 51565729),
('rec001', 'recepcion2024', 4, 22398564)

INSERT INTO ETAPAS_TRABAJO (IdTipoTrabajo, Etapa)
VALUES 
    -- Etapas para "Instalación sistema de vigilancia de instalaciones"
    (1, 'Evaluación de necesidades'),
    (1, 'Diseño del sistema'),
    (1, 'Instalación del sistema'),
    (1, 'Pruebas y ajustes'),
    (1, 'Capacitación al usuario'),
    -- Etapas para "Instalación de sistemas de seguridad"
    (2, 'Diagnóstico inicial'),
    (2, 'Selección de equipos'),
    (2, 'Instalación de equipos'),
    (2, 'Configuración del sistema'),
    (2, 'Entrega y capacitación'),
    -- Etapas para "Monitoreo de alarmas"
    (3, 'Configuración del panel de control'),
    (3, 'Prueba de sensores'),
    (3, 'Conexión al centro de monitoreo'),
    (3, 'Verificación del sistema'),
    (3, 'Activación y seguimiento');
