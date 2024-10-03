using AutoMapper;
using mySampleBackend.Domain;
using mySampleBackend.Infrastructure;

namespace mySampleBackend.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<Floop, FloopDbEntity>()
                    .ForMember(dest => dest.floop_type_code, opt => opt.MapFrom(src => src.FloopType))
                    .ForMember(dest => dest.floop_name, opt => opt.MapFrom(src => src.FloopName))
                    .ForMember(dest => dest.floop_value, opt => opt.MapFrom(src => src.FloopValue))
                    .ForMember(dest => dest.floop_safety_code, opt => opt.MapFrom(src => src.FloopSafetyCode));
            CreateMap<FloopDbEntity, Floop>()
                    .ForMember(dest => dest.FloopType, opt => opt.MapFrom(src => src.floop_type_code))
                    .ForMember(dest => dest.FloopName, opt => opt.MapFrom(src => src.floop_name))
                    .ForMember(dest => dest.FloopValue, opt => opt.MapFrom(src => src.floop_value))
                    .ForMember(dest => dest.FloopSafetyCode, opt => opt.MapFrom(src => src.floop_safety_code));




        }
    }
}
