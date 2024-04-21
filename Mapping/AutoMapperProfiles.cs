using AutoMapper;
using NZZwalks.Models.Domain;
using NZZwalks.Models.DTO;

namespace NZZwalks.Mapping
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Region, RegionDTO>().ReverseMap();
            //CreateMap<Region, RegionAddDTO>().ReverseMap();
            CreateMap<Walk, AddWalkDTO>().ReverseMap();
            CreateMap<Walk, SendWalkDto>().ReverseMap();    
            CreateMap<Difficulty, DifficultyDto>().ReverseMap();
            CreateMap<Walk, WalkUpdateDto>().ReverseMap();
            CreateMap<Register, RegisterDTO>().ReverseMap();
            CreateMap<Login, LoginDTO>().ReverseMap();
            CreateMap<Image, ImageUploadDTO>().ReverseMap();
        }
    }
}
