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
        private readonly IMapper mapper;

        public LocalPrincipalServices(ILocalPrincipalRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
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
