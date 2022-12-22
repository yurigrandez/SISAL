using AutoMapper;
using com.da.alquileres.accesodatos.Interfaces;
using com.da.alquileres.api.DTO;

namespace com.da.alquileres.api.Services
{
    public class EmpresaServices : IEmpresaServices
    {
        private readonly IEmpresaRepository repository;
        private readonly IMapper mapper;

        public EmpresaServices( IEmpresaRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
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
