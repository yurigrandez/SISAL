using com.da.alquileres.api.DTO;
using com.da.alquileres.api.Entidades.DTO;

namespace com.da.alquileres.api.Services
{
    public interface IEmpresaServices
    {
        Task<BaseResponseGeneric<ICollection<EmpresaDTOResponse>>> listarTodas();

        Task<BaseResponseGeneric<ICollection<EmpresaDTOResponse>>> buscarXString(string? str);
        Task<BaseResponseGeneric<int>> agregarEmpresa(EmpresaDTONuevo empresaDTONuevo);
        Task<BaseResponseGeneric<int>> actualizarEmpresa(int Id, EmpresaDTOActualizar empresaDTOActualizar);
        Task<BaseResponseGeneric<EmpresaDTOResponse>> buscarXId(int Id);
        Task<BaseResponseGeneric<string>> desactivarEntidad(int Id);
        Task<BaseResponseGeneric<string>> activarEntidad(int Id);
        Task<BaseResponseGeneric<string>> eliminarEntidad(int Id);

    }
}
