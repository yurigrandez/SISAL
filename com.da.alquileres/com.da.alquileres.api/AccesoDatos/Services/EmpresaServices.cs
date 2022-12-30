using AutoMapper;
using com.da.alquileres.accesodatos.Interfaces;
using com.da.alquileres.api.AccesoDatos.Repository.Interfaces;
using com.da.alquileres.api.DTO;
using com.da.alquileres.api.Entidades.DTO;
using com.da.alquileres.api.Entidades.Models;

namespace com.da.alquileres.api.Services
{
    public class EmpresaServices : IEmpresaServices
    {
        private readonly IEmpresaRepository repository;
        private readonly IToolsRepository tools;
        private readonly IMapper mapper;

        public EmpresaServices( IEmpresaRepository repository, IToolsRepository tools, IMapper mapper)
        {
            this.repository = repository;
            this.tools = tools;
            this.mapper = mapper;
        }

        public async Task<BaseResponseGeneric<int>> agregarEmpresa(EmpresaDTONuevo empresaDTONuevo)
        {
            var resultado = new BaseResponseGeneric<int>();

            try
            {
                var empresa = mapper.Map<tabEmpresa>(empresaDTONuevo);

                //obteniendo consecutivo
                empresa.codigo = await tools.obtenerConsecutivo("tabEMPRESA");

                if (empresa.codigo == null || empresa.codigo == "00000000")
                {
                    throw new Exception("Error al generar consecutivo");
                }

                resultado.Data = await repository.agregarEntidad(empresa);

                resultado.Success = true;

            }
            catch (Exception ex)
            {
                resultado.Success = false;
                resultado.ErrorMessage = ex.Message;
            }

            return resultado;
        }

        public async Task<BaseResponseGeneric<EmpresaDTOResponse>> buscarXId(int Id)
        {
            //declarando variable para devolver el resultado
            var resultado = new BaseResponseGeneric<EmpresaDTOResponse>();

            try
            {
                //realizando la búsqueda
                var empresa = await repository.buscarXId(Id);

                //verificamos si se encontro conincidencia
                if (empresa == null)
                {
                    resultado.Success = false;
                    resultado.ErrorMessage = "No se encontraron resultados";
                    return resultado;
                }
                
                //mapeando resultado
                resultado.Data = mapper.Map<EmpresaDTOResponse>(empresa);

                //realizando la búsqueda
                resultado.Success=true;

            }
            catch (Exception ex)
            {
                //completando valores de error
                resultado.Success = false;
                resultado.ErrorMessage=ex.Message;
            }

            return resultado;
        }

        public async Task<BaseResponseGeneric<ICollection<EmpresaDTOResponse>>> buscarXString( string str )
        {
            //declarando variable para devolver el resultado
            var resultado = new BaseResponseGeneric<ICollection<EmpresaDTOResponse>>();

            try
            {
                //realizando la busqueda
                var empresas = await repository.buscarXString(str);

                //si no contiene resultado
                if(empresas == null)
                {
                    resultado.Success = false;
                    resultado.ErrorMessage = "No se encontraron resultados";
                }

                //mapeando los resultados de la consulta
                resultado.Data = mapper.Map<ICollection<EmpresaDTOResponse>>(empresas);

                //completando parametros para devolver
                resultado.Success = true;

            }
            catch (Exception ex)
            {
                //asignando parametros de error
                resultado.Success = false;
                resultado.ErrorMessage = ex.Message;
            }

            return resultado;

        }

        public async Task<BaseResponseGeneric<string>> desactivarEntidad(int Id)
        {
            //declarando variable para devolver resultado
            var resultado = new BaseResponseGeneric<string>();

            try
            {
                //buscando la empresa
                var empresa = await repository.buscarXId(Id);

                //verificando si existe la empresa
                if (empresa == null)
                    throw new Exception($"No se encontro la empresa con Id: {Id}");


                //realizando la descativacion
                await repository.desactivarEntidad(empresa);

                //seteando los parametros si se desactivo
                resultado.Success=true;

            }
            catch (Exception ex)
            {
                //configurando parametros cuando se encuentre un error
                resultado.Success = false;
                resultado.ErrorMessage = ex.Message;
            }

            return resultado;
        }

        public async Task<BaseResponseGeneric<ICollection<EmpresaDTOResponse>>> listarTodas()
        {
            var response = new BaseResponseGeneric<ICollection<EmpresaDTOResponse>>();

            try
            {
                var empresa = await repository.listarAsync();
                response.Data = mapper.Map<ICollection<EmpresaDTOResponse>>(empresa);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }
    }
}
