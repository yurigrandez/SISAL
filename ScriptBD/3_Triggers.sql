/************************************/
/*				Triggers	 		*/
/************************************/
print '----------------------------'
print 'Activando dbSISAL...........'
print '----------------------------'
use dbSISAL
go

print '----------------------------'
print '.........Triggers...........'
print '----------------------------'

print '----------------------------'
print 'Triggers tabSECUENCIA.......'
print '----------------------------'

--print 'asignando fechaCreacion.....'
--go
--create trigger tabSECUENCIA_FechaCreacion
--on tabSECUENCIA
--after insert
--as
	
--	declare @ID int

--	select @ID = ID from inserted

--	update tabSECUENCIA
--	set fechaCreacion = GETDATE()
--	where ID = @ID
--go

print 'asignando fechaModificacion...'
go
create trigger tabSECUENCIA_FechaModificacion
on tabSECUENCIA
after update
as
	
	declare @ID int

	select @ID = ID from inserted

	update tabSECUENCIA
	set fechaModificacion = GETDATE()
	where ID = @ID
go

print '----------------------------'
print 'Triggers tabEMPRESA.........'
print '----------------------------'

--print 'asignando fechaCreacion.....'
--go
--create trigger tabEMPRESA_FechaCreacion
--on tabEMPRESA
--after insert
--as
	
--	declare @ID int

--	select @ID = ID from inserted

--	update tabEMPRESA
--	set fechaCreacion = GETDATE()
--	where ID = @ID
--go

print 'asignando fechaModificacion...'
go
create trigger tabEMPRESA_FechaModificacion
on tabEMPRESA
after update
as
	
	declare @ID int

	select @ID = ID from inserted

	update tabEMPRESA
	set fechaModificacion = GETDATE()
	where ID = @ID
go

print '----------------------------'
print 'Triggers tabLocal_Principal.'
print '----------------------------'

--print 'asignando fechaCreacion.....'
--go
--create trigger tabLocal_Principal_FechaCreacion
--on tabLocal_Principal
--after insert
--as
	
--	declare @ID int

--	select @ID = ID from inserted

--	update tabLocal_Principal
--	set fechaCreacion = GETDATE()
--	where ID = @ID
--go

print 'asignando fechaModificacion...'
go
create trigger tabLocal_Principal_FechaModificacion
on tabLocal_Principal
after update
as
	
	declare @ID int

	select @ID = ID from inserted

	update tabLocal_Principal
	set fechaModificacion = GETDATE()
	where ID = @ID
go

