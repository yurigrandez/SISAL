using com.da.alquiler.API.Entidades.DTO;

namespace com.da.alquiler.API.AccesoDatos.Services
{
    public interface IEmpresaServices
    {
        Task<BaseResponseGeneric<ICollection<EmpresaDTOResponse>>> listarTodas();
    }
}
