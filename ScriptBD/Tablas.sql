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
print '-------------------------------'
print 'creando Tablas Mantenimiento...'
print '-------------------------------'

print 'creando tabSECUENCIA...'
create table tabSECUENCIA
(Id					int identity(1,1) not null primary key,
 tabla				varchar(50),
 anio				char(4),
 prefijo			char(3),
 numero				int,
 fechaCreacion		smalldatetime,
 fechaModificacion	smalldatetime,
 fechaDesactivacion	smalldatetime,
)
go

print 'creando tabEMPRESA...'
create table tabEMPRESA
(Id					int identity(1,1) not null primary key,
 codigo				char(8) not null,
 nombre				varchar(100),
 direccion			varchar(250),
 ruc				varchar(11),
 telefono			varchar(25),
 movil				varchar(15),
 nombreContacto		varchar(150),
 correoContacto		varchar(50),
 tlfContacto		varchar(15),
 movilContacto		varchar(15),
 fechaCreacion		smalldatetime,
 fechaModificacion	smalldatetime,
 fechaDesactivacion	smalldatetime,
 imgEmpresa			varbinary(max)
)
go

print 'creando tbLOCAL_PRINCIPAL...'
create table tabLOCAL_PRINCIPAL
(Id					int identity(1,1) not null primary key,
 codigo				char(8) not null,
 idEmpresa			int,
 direccion			varchar(250),
 nroLocales			int,
 totalM2			int,
 dimenciones		varchar(150),
 imgFrontis			varbinary(max),
 fechaCreacion		smalldatetime,
 fechaModificacion	smalldatetime,
 fechaDesactivacion	smalldatetime,
 constraint fk_LocalPrincipal_Empresa foreign key(idEmpresa) references tabEMPRESA(Id)
)
go

print 'creando tabTIPO_USUARIO...'
create table tabTIPO_USUARIO
(Id					int identity(1,1) not null primary key,
 abreviatura		char(3),
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
 abreviatura		char(3),
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
 codigo				char(8) not null,
 nombre				varchar(50),
 paterno			varchar(50),
 materno			varchar(50),
 correo				varchar(50),
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
 abreviatura		char(3),
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
 codigo				char(8) not null,
 nombre				varchar(50),
 paterno			varchar(50),
 materno			varchar(50),
 IdTipoDocumento	int,
 numeroDocumento	varchar(25),
 correo				varchar(50),
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
 codigo				char(8) not null,
 idLocalPrincipal	int,
 numeroInterior		int,
 totalM2			int,
 dimenciones		varchar(150),
 fechaCreacion		smalldatetime,
 fechaModificacion	smalldatetime,
 fechaDesactivacion	smalldatetime,
 constraint fk_LocalArrendar_LocalPrincipal foreign key(idLocalPrincipal) references tabLOCAL_PRINCIPAL(Id)
)
go

print 'creando tabESTADO...'
create table tabESTADO
(Id					int identity(1,1) not null primary key,
 abreviatura		char(6),
 nombre				varchar(15),
 descripcion		varchar(100)
)
go

/************************************/
/*			Tablas Negocio			*/
/************************************/
print '-------------------------'
print 'creando Tablas Negocio...'
print '-------------------------'

print 'creando tabCONTRATO...'
create table tabCONTRATO
(Id					int identity(1,1) not null primary key,
 codigo				varchar(8),
 idCliente			int,
 idUsuarioRegistra	int,
 idUsuarioAutoriza	int,
 idLocalArrendar	int,
 fechaInicio		smalldatetime,
 fechaFin			smalldatetime,
 montoAlquiler		decimal(18,2),
 montoLuz			decimal(18,2),
 montoAgua			decimal(18,2),
 montoMantenimiento	decimal(18,2),
 montoOtros			decimal(18,2),
 Observaciones		varchar(max),
 contratoPDF		varbinary(max),
 idEstado			int,
 fechaCreacion		smalldatetime,
 fechaModificacion	smalldatetime,
 fechaDesactivacion	smalldatetime,
 constraint fk_Contrato_Cliente foreign key(idCliente) references tabCLIENTE(Id),
 constraint fk_Contrato_UsuRegistra foreign key(idUsuarioRegistra) references tabUSUARIO(Id),
 constraint fk_Contrato_UsuAutoriza foreign key(idUsuarioAutoriza) references tabUSUARIO(Id),
 constraint fk_Contrato_LocalArrendar foreign key(idLocalArrendar) references tabLOCAL_ARRENDAR(Id),
 constraint fk_Contrato_Estado foreign key(idEstado) references tabESTADO(Id)
)
go

print 'creando tabTIPO_MONEDA...'
create table tabTIPO_MONEDA
(Id					int identity(1,1) not null primary key,
 abreviatura		char(3),
 nombre				varchar(25),
 descripcion		varchar(100),
 fechaCreacion		smalldatetime,
 fechaModificacion	smalldatetime,
 fechaDesactivacion	smalldatetime
)
go

print 'creando tabCOMPROBANTE...'
create table tabCOMPROBANTE
(Id					int identity(1,1) not null primary key,
 idEmpresa			int,
 idTipoComprobante	int,
 nroComprobante		varchar(10),
 idCliente			int,
 idContrato			int,
 idUsuarioRegistra	int,
 fechaEmision		smalldatetime,
 fechaVencimiento	smalldatetime,
 idTipoMoneda		int,
 observacion		varchar(max),
 importeTotal		decimal(18,2),
 fechaCreacion		smalldatetime,
 fechaModificacion	smalldatetime,
 fechaDesactivacion	smalldatetime
 constraint fk_Comprobante_Empresa foreign key(idEmpresa) references tabEMPRESA(Id),
 constraint fk_Comprobante_TipoComprobante foreign key(idTipoComprobante) references tabTIPO_COMPROBANTE(Id),
 constraint fk_Comprobante_Cliente foreign key(idCliente) references tabCLIENTE(Id),
 constraint fk_Comprobante_Contrato foreign key(idContrato) references tabCONTRATO(Id),
 constraint fk_Comprobante_UsuRegistra foreign key(idUsuarioRegistra) references tabUSUARIO(Id),
 constraint fk_Comprobante_TipoMoneda foreign key(idTipoMoneda) references tabTIPO_MONEDA(Id)
)
go

print 'creando tabCOMPROBANTE_DETALLE...'
create table tabCOMPROBANTE_DETALLE
(Id					int identity(1,1) not null primary key,
 idComprobante		int,
 cantidad			int,
 concepto			varchar(250),
 precioUnitario		decimal(18,2),
 subTotal			decimal(18,2),
 constraint fk_ComDetalle_Comprobante foreign key(idComprobante) references tabCOMPROBANTE(Id)
)
go

/************************************/
/*			Tablas Incidentes		*/
/************************************/
print '----------------------------'
print 'creando Tablas Incidentes...'
print '----------------------------'

print 'creando tabTIPO_INCIDENTES...'
create table tabTIPO_INCIDENTE
(Id					int identity(1,1) not null primary key,
 abreviatura		char(3),
 nombre				varchar(25),
 descripcion		varchar(100),
 fechaCreacion		smalldatetime,
 fechaModificacion	smalldatetime,
 fechaDesactivacion	smalldatetime 
)
go

print 'creando tabINCIDENTES...'
create table tabINCIDENTE
(Id					int identity(1,1) not null primary key,
 idUsuarioRegistra	int,
 idCliente			int,
 idTipoIncidente	int,
 descripcion		varchar(max),
 fechaCreacion		smalldatetime,
 fechaModificacion	smalldatetime,
 fechaDesactivacion	smalldatetime,
 constraint fk_Incidente_UsuRegistra foreign key(idUsuarioRegistra) references tabUSUARIO(Id),
 constraint fk_Incidente_Cliente foreign key(idCliente) references tabCLIENTE(Id),
 constraint fk_Incidente_TipoIncidente foreign key(idTipoIncidente) references tabTIPO_INCIDENTE(Id)
)
go

/************************************/
/*			Tablas Control			*/
/************************************/
print '-------------------------'
print 'creando Tablas Control...'
print '-------------------------'

print 'creando tabEVENTOS...'
create table tabEVENTOS
(Id					int identity(1,1) not null primary key,
 IdEntidad			int,
 codigoIdentidad	varchar(6),
 Entidad			char(6),
 idUsuario			int,
 codigoUsuario		char(6),
 fechaCreacion		smalldatetime,
 mensaje			varchar(max)
 constraint fk_Evento_Usuario foreign key(idUsuario) references tabUSUARIO(Id)
)
go

/************************************/
/*			Poblando tablas 		*/
/************************************/
print '----------------------------'
print 'Poblando tablas...'
print '----------------------------'

print 'poblando tbEMPRESA...'
insert into tabEMPRESA( codigo, nombre, direccion, ruc, telefono, movil, nombreContacto, correoContacto, tlfContacto, movilContacto )
values ('EMP00001', 'DA Soluciones e Inversiones', 'SMP', '20606416106', '555-5555', '986794436', 'Yuri Grandez Del Aguila', 'yuri.grandez@dasol-inv.com', '555-5555', '986794436')
go

print 'poblando tabSECUENCIA...'
insert into tabSECUENCIA ( tabla, anio, prefijo, numero, fechaCreacion )
values( 'tabEMPRESA', 2022, 'EMP', 1, GETDATE() )
go

/************************************/
/*		Procedimientos Almacenados	*/
/************************************/
print '----------------------------'
print 'Procedimientos Almacenados..'
print '----------------------------'

print 'Generador de consecutivos...'
go

create procedure upsS_obtenerSecuencia
	@tabla varchar(50),
	@secuencia char(8) output 
as
	--variables para obtener secuencia
	declare @prefijo char(3)
	declare @numero int
	declare @complemento varchar(5)
	declare @error int

	--inicializando el correlativo
	set @secuencia = '000000'

	--obteniendo valores para generar el consecutivo
	select @prefijo = prefijo, @numero = numero from tabSECUENCIA where tabla = @tabla

	--validando que el numero no sobrepase el 99999
	if( @numero > 99999 )
		begin
			return
		end

	--verificando que se tengan los valores minimos para crear un consecutivo
	if ( @prefijo is not null ) and ( @numero > 0 )
		begin

			if( @numero > 9999 )
				begin
					set @complemento = ''
				end
			else if( @numero > 999 )
				begin
					set @complemento = '0'
				end
			else if( @numero > 99 )
				begin
					set @complemento = '00'
				end
			else if( @numero > 9 )
				begin
					set @complemento = '000'
				end
			else
				begin
					set @complemento = '0000'
				end

			print 'prefijo: ' + @prefijo + ' complemento: ' +@complemento + ' numero: ' + cast(@numero as varchar)
			--generando consecutivo
			set @secuencia = CONCAT(@prefijo, @complemento, @numero)

			--recuperando codigo de error
			set @error = @@ERROR

			--imprimiendo correlativo generado
			print 'consecutivo: ' + @secuencia

		end
	
	if @error = 0
		begin 

			--actualizando el numero para el siguiente correlativo
			update tabSECUENCIA
			set numero = numero + 1
			where tabla = @tabla

		end

go

print 'Script ejecutado con exito...'