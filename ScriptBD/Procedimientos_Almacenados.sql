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
	set @secuencia = '00000000'

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