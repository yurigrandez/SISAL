using com.da.alquileres.api.DTO;
using com.da.alquileres.api.Entidades.DTO;

namespace com.da.alquileres.api.AccesoDatos.Services
{
    public interface ILocalPrincipalServices
    {
        Task<BaseResponseGeneric<ICollection<LocalPrincipalDTOResponse>>> listarLocalesPrincipales();
    }
}
