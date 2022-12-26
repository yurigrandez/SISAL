using AutoMapper;
using com.da.alquileres.api.DTO;
using com.da.alquileres.api.Entidades.DTO;
using com.da.alquileres.api.Entidades.Models;

namespace com.da.alquileres.api.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<tabEmpresa, EmpresaDTOResponse>().ReverseMap();
            CreateMap<tabEmpresa, EmpresaDTONuevo>().ReverseMap();
        }
    }
}
