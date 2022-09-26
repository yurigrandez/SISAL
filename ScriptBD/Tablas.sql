use master
go

/***************Verificando si existe BD******************/ 
if exists (select * from sysdatabases where (name = 'dbSISAL'))
begin
	print 'existe BD dbSISAL, eliminando...'
	drop database dbSISAL
end

/***********************Creando BD***********************/
print 'creando BD dbSISAL...'
create database dbSISAL
go

/***********************Activando BD***********************/
use dbSISAL
go

/************************************/
/*			Tablas Mantenimiento	*/
/************************************/
print 'creando Tablas Mantenimiento...'
print '-------------------------------'

print 'creando tbEMPRESA...'
create table tbEMPRESA
(Id					int identity(1,1) not null primary key,
 codigo				char(6) not null,
 nombre				varchar(100),
 direccion			varchar(250),
 ruc				varchar(11),
 telefono			varchar(25),
 movil				varchar(15),
 fechaCreacion		smalldatetime,
 fechaModificacion	smalldatetime,
 fechaDesactivacion	smalldatetime,
 imgEmpresa			varbinary(max)				
)
go

print 'creando tbLOCAL_PRINCIPAL...'
create table tbLOCAL_PRINCIPAL
(Id					int identity(1,1) not null primary key,
 codigo				char(6) not null,
 idEmpresa			int,
 direccion			varchar(250),
 nroLocales			int,
 totalM2			int,
 dimenciones		varchar(150),
 imgFrontis			varbinary(max),
 fechaCreacion		smalldatetime,
 fechaModificacion	smalldatetime,
 fechaDesactivacion	smalldatetime,
 constraint fk_LocalPrincipal_Empresa foreign key(idEmpresa) references tbEMPRESA(Id)
)
go

print 'creando tabTIPO_USUARIO...'
create table tabTIPO_USUARIO
(Id					int identity(1,1) not null primary key,
 codigo				char(3),
 nombre				varchar(25),
 descripcion		varchar(100),
 fechaCreacion		smalldatetime,
 fechaModificacion	smalldatetime,
 fechaDesactivacion	smalldatetime
)
go

print 'creando tabTIPO_DOCUMENTO...'
create table tabTIPO_DOCUMENTO
(Id					int identity(1,1) not null primary key,
 codigo				char(3),
 nombre				varchar(25),
 descripcion		varchar(100),
 fechaCreacion		smalldatetime,
 fechaModificacion	smalldatetime,
 fechaDesactivacion	smalldatetime
)
go

print 'creando tabUSUARIO...'
create table tabUSUARIO
(Id					int identity(1,1) not null primary key,
 codigo				char(6) not null,
 nombre				varchar(50),
 paterno			varchar(50),
 materno			varchar(50),
 clave				varchar(max),
 idTipoUsuario		int,
 IdtipoDocumento	int,
 numeroDocumento	varchar(25),
 direccion			varchar(250),
 telefono			varchar(25),
 fechaCreacion		smalldatetime,
 fechaModificacion	smalldatetime,
 fechaDesactivacion	smalldatetime,
 constraint fk_Usuario_TipoUsuario foreign key(idTipoUsuario) references tabTIPO_USUARIO(Id),
 constraint fk_Usuario_TipoDocumento foreign key(IdtipoDocumento) references tabTIPO_DOCUMENTO(Id)
)
go

print 'creando tabTIPO_COMPROBANTE...'
create table tabTIPO_COMPROBANTE
(Id					int identity(1,1) not null primary key,
 codigo				char(3),
 nombre				varchar(25),
 descripcion		varchar(100),
 fechaCreacion		smalldatetime,
 fechaModificacion	smalldatetime,
 fechaDesactivacion	smalldatetime
)
go

print 'creando tabCLIENTE...'
create table tabCLIENTE
(Id					int identity(1,1) not null primary key,
 codigo				char(6) not null,
 nombre				varchar(50),
 paterno			varchar(50),
 materno			varchar(50),
 IdTipoDocumento	int,
 numeroDocumento	varchar(25),
 direccion			varchar(250),
 telefono			varchar(25),
 IdTipoComprobante	int,
 fechaCreacion		smalldatetime,
 fechaModificacion	smalldatetime,
 fechaDesactivacion	smalldatetime,
 constraint fk_Cliente_TipoDocumento foreign key(IdTipoDocumento) references tabTIPO_DOCUMENTO(Id),
 constraint fk_Cliente_TipoComprobante foreign key(IdTipoComprobante) references tabTIPO_COMPROBANTE(Id)
)
go

print 'creando tabLOCAL_ARRENDAR...'
create table tabLOCAL_ARRENDAR
(Id					int identity(1,1) not null primary key,
 codigo				char(6) not null,
 idLocalPrincipal	int,
 numeroInterior		int,
 totalM2			int,
 dimenciones		varchar(150),
 fechaCreacion		smalldatetime,
 fechaModificacion	smalldatetime,
 fechaDesactivacion	smalldatetime,
 constraint fk_LocalArrendar_LocalPrincipal foreign key(idLocalPrincipal) references tbLOCAL_PRINCIPAL(Id)
)
go

print 'Script ejecutado con exito...'