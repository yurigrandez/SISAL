using com.da.alquileres.accesodatos.Interfaces;
using com.da.alquileres.api.DTO;

namespace com.da.alquileres.api.Services
{
    public class EmpresaServices : IEmpresaServices
    {
        private readonly IEmpresaRepository repository;

        public EmpresaServices( IEmpresaRepository repository)
        {
            this.repository = repository;
        }
        public async Task<BaseResponseGeneric<ICollection<EmpresaDTOResponse>>> listarTodas()
        {
            var response = new BaseResponseGeneric<ICollection<EmpresaDTOResponse>>();

            try
            {
                var empresa = await repository.listarAsync();



            }
            catch (Exception ex)
            {

                throw;
            }

            return response;
        }
    }
}
