using AutoMapper;
using EntityLayer.Concrete;
using MTAPI.DTO;

namespace MTAPI.AutoMapper.Profiles
{
    public class ProfileMapper : Profile
    {
        public ProfileMapper()
        {
            CreateMap<LicenseUpdateDTO, license>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore());
        }
    }
}
