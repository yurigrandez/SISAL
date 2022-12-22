using com.da.alquileres.api.DTO;

namespace com.da.alquileres.api.Services
{
    public interface IEmpresaServices
    {
        Task<BaseResponseGeneric<ICollection<EmpresaDTOResponse>>> listarTodas();
    }
}
