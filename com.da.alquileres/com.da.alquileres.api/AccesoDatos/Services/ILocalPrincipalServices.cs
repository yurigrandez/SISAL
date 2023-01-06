using com.da.alquileres.api.DTO;
using com.da.alquileres.api.Entidades.DTO;

namespace com.da.alquileres.api.AccesoDatos.Services
{
    public interface ILocalPrincipalServices
    {
        Task<BaseResponseGeneric<ICollection<LocalPrincipalDTOResponse>>> listarLocalesPrincipales();
        Task<BaseResponseGeneric<int>> agregarEntidad(LocalPrincipalDTONuevo dTONuevo);
        Task<BaseResponseGeneric<LocalPrincipalDTOResponse>> buscarXId(int id);
        Task<BaseResponseGeneric<int>> actualizarEntidad(int id, LocalPrincipalDTOActualizar dTOActualizar);
        Task<BaseResponseGeneric<string>> activarLocalPrincipal(int id);
        Task<BaseResponseGeneric<string>> desactivarLocalPrincipal(int id);
        Task<BaseResponseGeneric<string>> eliminarLocalPrincipal(int id);
        Task<BaseResponseGeneric<ICollection<LocalPrincipalDTOResponse>>> buscarXString(string str);
    }
}
