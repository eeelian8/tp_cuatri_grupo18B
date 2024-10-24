USE SEGURIDAD_DB 

CREATE TABLE [dbo].[CLIENTES](
    [Id] [int] IDENTITY(1,1) NOT NULL,
      [NroCliente][int] NOT NULL,
      [NivelRol][int] NOT NULL,
      [Celular][int] NOT NULL,
      [Nombre][varchar](50) NOT NULL,
      [Apellido][varchar](50) NOT NULL,
      [Direccion][varchar](150) NOT NULL,
      [Localidad][varchar](50) NOT NULL,
      [Provincia][varchar](50) NOT NULL,
 CONSTRAINT [PK_CLIENTES] PRIMARY KEY CLUSTERED 
(
    [Id] ASC
) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY];

CREATE TABLE [dbo].[ESPECIALIDADES](
    [Id] [int] IDENTITY(1,1) NOT NULL,
     [Nombre][varchar](50) NOT NULL,
	 [Descripcion][varchar](150) NULL,
    CONSTRAINT [PK_ESPECIALIDADES] PRIMARY KEY CLUSTERED 
    (
        [Id] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY];

CREATE TABLE [dbo].[TECNICOS](
    [Id] [int] IDENTITY(1,1) NOT NULL,
      [CodTecnico][varchar](20) NOT NULL,
      [NivelRol][int] NOT NULL,
      [Celular][int] NOT NULL,
      [Nombre][varchar](50) NOT NULL,
      [Apellido][varchar](50) NOT NULL,
      [Direccion][varchar](150) NOT NULL,
      [Localidad][varchar](50) NOT NULL,
      [Provincia][varchar](50) NOT NULL,
    [Especialidad] [int] NOT NULL,
	 CONSTRAINT [PK_TECNICOS] PRIMARY KEY CLUSTERED 
(
    [Id] ASC
) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY];

ALTER TABLE [dbo].[TECNICOS]
ADD CONSTRAINT [FK_TECNICOS_ESPECIALIDAD]
FOREIGN KEY ([Especialidad]) REFERENCES [dbo].[ESPECIALIDADES]([Id]);

CREATE TABLE [dbo].[GERENTE](
    [Id] [int] IDENTITY(1,1) NOT NULL,
      [CodGerente][varchar](20) NOT NULL,
      [NivelRol][int] NOT NULL,
      [Celular][int] NOT NULL,
      [Nombre][varchar](50) NOT NULL,
      [Apellido][varchar](50) NOT NULL,
      [Direccion][varchar](150) NOT NULL,
      [Localidad][varchar](50) NOT NULL,
      [Provincia][varchar](50) NOT NULL,
 CONSTRAINT [PK_GERENTE] PRIMARY KEY CLUSTERED 
(
    [Id] ASC
) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY];

CREATE TABLE [dbo].[ADMINISTRADOR](
    [Id] [int] IDENTITY(1,1) NOT NULL,
      [CodAdministrador][varchar](20) NOT NULL,
      [NivelRol][int] NOT NULL,
      [Celular][int] NOT NULL,
      [Nombre][varchar](50) NOT NULL,
      [Apellido][varchar](50) NOT NULL,
      [Direccion][varchar](150) NOT NULL,
      [Localidad][varchar](50) NOT NULL,
      [Provincia][varchar](50) NOT NULL,
 CONSTRAINT [PK_ADMINISTRADOR] PRIMARY KEY CLUSTERED 
(
    [Id] ASC
) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY];

INSERT INTO [dbo].[CLIENTES] ([NroCliente], [NivelRol], [Celular], [Nombre], [Apellido], [Direccion], [Localidad], [Provincia])
VALUES 
(1001, 4, 1124567897, 'Juan', 'P�rez', 'Av. Siempre Viva 742', 'Palermo', 'CABA'),
(1002, 4, 1189115499, 'Ana', 'G�mez', 'Calle Falsa 123', 'Belgrano', 'CABA'),
(1003, 4, 1174557800, 'Carlos', 'Mart�nez', 'Paseo de la Reforma 456', 'Merlo', 'Buenos Aires'),
(1004, 4, 1124487797, 'Laura', 'S�nchez', 'Boulevard de los h�roes 789', 'Moreno', 'Buenos Aires'),
(1005, 4, 1199967891, 'Jos�', 'Rodr�guez', 'Plaza Central 12', 'Lanus', 'Buenos Aires');

INSERT INTO [dbo].[ESPECIALIDADES] ([Nombre], [Descripcion])
VALUES 
('Electricidad', 'Especialistas en instalaciones el�ctricas y mantenimiento.'),
('Fontaner�a', 'Expertos en sistemas de plomer�a y reparaci�n de fugas.'),
('Climatizaci�n', 'T�cnicos en sistemas de aire acondicionado y calefacci�n.'),
('Mantenimiento General', 'Profesionales en mantenimiento de edificios y equipos.'),
('Pintura y Decoraci�n', 'Especialistas en pintura interior y exterior.');

INSERT INTO [dbo].[TECNICOS] ([CodTecnico], [NivelRol], [Celular], [Nombre], [Apellido], [Direccion], [Localidad], [Provincia], [Especialidad])
VALUES 
('T001', 3, 1198765432, 'Pedro', 'Mart�nez', 'Av. Principal 123', 'Buenos Aires', 'Buenos Aires', 1),
('T002', 3, 1191234567, 'Luc�a', 'Fern�ndez', 'Calle de la Luz 456', 'C�rdoba', 'C�rdoba', 2),
('T003', 3, 1199876543, 'Javier', 'G�mez', 'Paseo de la Innovaci�n 789', 'Rosario', 'Santa Fe', 0),
('T004', 3, 1193456789, 'Ana', 'S�nchez', 'Calle Verde 101', 'Mendoza', 'Mendoza', 0),
('T005', 3, 1192345678, 'Roberto', 'L�pez', 'Boulevard del Sol 202', 'La Plata', 'Buenos Aires', 3);

INSERT INTO [dbo].[ADMINISTRADOR] ([CodAdministrador], [NivelRol], [Celular], [Nombre], [Apellido], [Direccion], [Localidad], [Provincia]) 
VALUES 
    ('ADMIN001', 1, 1122335431, 'Juan', 'P�rez', 'Av. Siempre Viva 742', 'Chajari', 'Entre Rios');

INSERT INTO [dbo].[GERENTE] (CodGerente, NivelRol, Celular, Nombre, Apellido, Direccion, Localidad, Provincia)
VALUES ('G12345', 2, 1234567890, 'Juan', 'P�rez', 'Calle Falsa 123', 'Ciudad', 'Provincia');

select * from TECNICOS