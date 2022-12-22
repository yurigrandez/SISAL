using AutoMapper;
using com.da.alquiler.API.Entidades.DTO;
using com.da.alquiler.API.Entidades.Models;

namespace com.da.alquiler.API.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<tabEMPRESA, EmpresaDTOResponse>().ReverseMap();
        }
    }
}
