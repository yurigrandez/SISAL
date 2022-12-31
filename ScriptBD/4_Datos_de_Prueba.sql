/************************************/
/*			Poblando tablas 		*/
/************************************/
print '----------------------------'
print 'Activando dbSISAL...........'
print '----------------------------'
use dbSISAL
go

print '----------------------------'
print 'Poblando tablas...'
print '----------------------------'

print 'poblando tabSECUENCIA...'
insert into tabSECUENCIA ( tabla, anio, prefijo, numero )
values( 'tabEMPRESA', 2022, 'EMP', 2)
go
insert into tabSECUENCIA ( tabla, anio, prefijo, numero )
values( 'tabLocal_Principal', 2022, 'LPR', 2)
go

print 'poblando tabEMPRESA...'
insert into tabEMPRESA( codigo, nombre, direccion, ruc, telefono, movil, nombreContacto, correoContacto, tlfContacto, movilContacto )
values ('EMP00001', 'DA Soluciones e Inversiones', 'SMP', '20606416106', '555-5555', '986794436', 'Yuri Grandez Del Aguila', 'yuri.grandez@dasol-inv.com', '555-5555', '986794436')
go

print 'poblando tabLOCAL_PRINCIPAL...'
insert into tabLOCAL_PRINCIPAL( codigo, idEmpresa, direccion, nroLocales, totalM2, dimensiones,  nroPisos)
values ('LPR00001', 1, 'SMP', 8, 1000, 'Frontis: 20 m, Profundidad: 50 m' ,2)
go

/*
	select * from tabSECUENCIA
	select * from tabEMPRESA
	select * from tabLOCAL_PRINCIPAL
*/