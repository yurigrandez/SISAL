using com.da.alquileres.api.DTO;
using com.da.alquileres.api.Entidades.DTO;

namespace com.da.alquileres.api.Services
{
    public interface IEmpresaServices
    {
        Task<BaseResponseGeneric<ICollection<EmpresaDTOResponse>>> listarTodas();

        Task<BaseResponseGeneric<int>> agregarEmpresa(EmpresaDTONuevo empresaDTONuevo);
    }
}
