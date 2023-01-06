using AutoMapper;
using com.da.alquileres.api.AccesoDatos.Repository.Interfaces;
using com.da.alquileres.api.DTO;
using com.da.alquileres.api.Entidades.DTO;
using com.da.alquileres.api.Entidades.Models;

namespace com.da.alquileres.api.AccesoDatos.Services
{
    public class LocalPrincipalServices : ILocalPrincipalServices
    {
        private readonly ILocalPrincipalRepository repository;
        private readonly IToolsRepository tools;
        private readonly IMapper mapper;

        public LocalPrincipalServices(ILocalPrincipalRepository repository, IToolsRepository tools, IMapper mapper)
        {
            this.repository = repository;
            this.tools = tools;
            this.mapper = mapper;
        }

        public async Task<BaseResponseGeneric<string>> activarLocalPrincipal(int id)
        {
            //declarando variable para mostrar el resultado
            var resultado = new BaseResponseGeneric<string>();

            try
            {
                //buscando entidad a activar
                var localActivar = await repository.buscarXId(id);

                //verificando si se encontro local
                if (localActivar == null)
                    throw new Exception($"No se encontro el local principal con Id: {id}");

                //verificando que el local este desactivado
                if (localActivar.fechaDesactivacion == null)
                    throw new Exception($"El local con Id: {id} se encuentra activo");

                //activando local
                await repository.activarEntidad(localActivar);

                //completando valores
                resultado.Data = $"Se activo el local principal con Id: {id}";
                resultado.Success = true;
            }
            catch (Exception ex)
            {
                //completando valores si existiera errores
                resultado.Success = false;
                resultado.ErrorMessage = ex.Message;
            }

            return resultado;
        }

        public async Task<BaseResponseGeneric<int>> actualizarEntidad(int id, LocalPrincipalDTOActualizar dTOActualizar)
        {
            //declarando variable para mostrar el resultado
            var resultado = new BaseResponseGeneric<int>();

            try
            {
                //buscando la entidad a actualizar
                var localBuscado = await repository.buscarXId(id);

                //verificando que exista el local
                if (localBuscado == null)
                    throw new Exception($"No se encontró el local con Id: {id}");

                //mapeando dto con entidad
                var localActualizar = mapper.Map<tabLocal_Principal>(dTOActualizar);

                //completando valores
                localActualizar.Id = id;
                localActualizar.codigo = localBuscado.codigo;
                localActualizar.fechaCreacion = localBuscado.fechaCreacion;

                //ejecutando actualizacion
                resultado.Data = await repository.actualizarEntidad(localActualizar);

                //completando valores
                resultado.Success = true;

            }
            catch (Exception ex)
            {
                resultado.Success = false;
                resultado.ErrorMessage = ex.Message;
            }

            return resultado;
        }

        public async Task<BaseResponseGeneric<int>> agregarEntidad(LocalPrincipalDTONuevo dTONuevo)
        {
            //declarando variable para mostrar resultado
            var resultado = new BaseResponseGeneric<int>();

            try
            {
                //mapeando dto a entidad
                var localPrincipal = mapper.Map<tabLocal_Principal>(dTONuevo);

                //obteniendo codigo para insertar
                localPrincipal.codigo = await tools.obtenerConsecutivo("tabLOCAL_PRINCIPAL");

                if (localPrincipal.codigo == null)
                    throw new Exception("No se pudo generar el correlativo");

                //ejecutando metodo
                resultado.Data = await repository.agregarEntidad(localPrincipal);

                //completando valores
                resultado.Success = true;

            }
            catch (Exception ex)
            {
                //completando valores si se encuentra un error
                resultado.Success = false;
                resultado.ErrorMessage = ex.Message;
            }

            return resultado;
        }

        public async Task<BaseResponseGeneric<LocalPrincipalDTOResponse>> buscarXId(int id)
        {
            //declarando variable para mostrar el resultado
            var resultado = new BaseResponseGeneric<LocalPrincipalDTOResponse>();

            try
            {
                //realizando la busqueda
                var localPrincipal = await repository.buscarXId(id);

                //verificando que exista resultado
                if (localPrincipal == null)
                    throw new Exception($"No se encontro local principal con Id: {id}");

                //mapeando el resultado para mostrar
                resultado.Data = mapper.Map<LocalPrincipalDTOResponse>(localPrincipal);

                //completando valores
                resultado.Success = true;
            }
            catch (Exception ex)
            {
                //completando valores si se encontrara errores
                resultado.Success = false;
                resultado.ErrorMessage = ex.Message;
            }

            return resultado;
        }

        public async Task<BaseResponseGeneric<ICollection<LocalPrincipalDTOResponse>>> buscarXString(string str)
        {
            //declarando variable para devolver resultado 
            var resultado = new BaseResponseGeneric<ICollection<LocalPrincipalDTOResponse>>();

            try
            {
                //buscando locales
                var localesEncontrados = await repository.buscarXString(str);

                //verificando que existan locales
                if (localesEncontrados == null)
                    throw new Exception($"No se encontraron locales que coincidan con {str}");

                //mapeando resultados
                resultado.Data = mapper.Map<ICollection<LocalPrincipalDTOResponse>>(localesEncontrados);

                //completando valores
                resultado.Success=true;
            }
            catch (Exception ex)
            {
                //completando valores si hay errores
                resultado.Success = false;
                resultado.ErrorMessage=ex.Message;
            }

            return resultado;
        }

        public async Task<BaseResponseGeneric<string>> desactivarLocalPrincipal(int id)
        {
            //declarando variable para devolver el resultado
            var resultado = new BaseResponseGeneric<string>();

            try
            {
                //buscando el local principal a desactivar
                var localDesactivar = await repository.buscarXId(id);

                //verificando que exista el local
                if (localDesactivar == null)
                    throw new Exception($"No se encontró local principal con Id: {id}");

                //verificando que el local no esté desactivado
                if (localDesactivar.fechaDesactivacion != null)
                    throw new Exception($"El local con Id {id} se encuentra desactivado");

                //desactivando el local
                await repository.desactivarEntidad(localDesactivar);

                //completando valores
                resultado.Data = $"Se desactivo el local principal con Id: {id}";
                resultado.Success = true;
            }
            catch (Exception ex)
            {
                //completando valores si existiera errores
                resultado.Success = false;
                resultado.ErrorMessage=ex.Message;
            }

            return resultado;
        }

        public async Task<BaseResponseGeneric<string>> eliminarLocalPrincipal(int id)
        {
            //declarando variable para mostrar resultado
            var resultado = new BaseResponseGeneric<string>();

            try
            {
                //buscando la entidad a eliminar
                var localEliminar = await repository.buscarXId(id);

                //verificando que exista el local
                if (localEliminar == null)
                    throw new Exception($"No se encontró el local principal con Id: {id}");

                //eliminando local
                await repository.eliminarEntidad(localEliminar);

                //completando valores
                resultado.Data = $"Se elimino el local principal con Id: {id}";
                resultado.Success = true;
            }
            catch (Exception ex)
            {
                //completando valores si existiera errores
                resultado.Success = false;
                resultado.ErrorMessage = ex.Message;
            }

            return resultado;
        }

        public async Task<BaseResponseGeneric<ICollection<LocalPrincipalDTOResponse>>> listarLocalesPrincipales()
        {
            //declarando variable para mostrar el resultado
            var resultado = new BaseResponseGeneric<ICollection<LocalPrincipalDTOResponse>>();

            try
            {
                //obteniendo locales
                var locales = await repository.listarAsync();

                //verificando si encontraron locales
                if (locales == null)
                    throw new Exception("No se encontraron registros");

                //si existen locales asignamos la lista al resultado
                resultado.Data = mapper.Map< ICollection<LocalPrincipalDTOResponse>>(locales);
                resultado.Success = true;

            }
            catch (Exception ex)
            {
                //completando valores si se encuentra algun error
                resultado.Success = false;
                resultado.ErrorMessage = ex.Message;
            }

            return resultado;
        }
    }
}
