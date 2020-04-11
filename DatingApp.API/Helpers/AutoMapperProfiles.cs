using System.Linq;
using AutoMapper;
using DatingApp.API.Dtos;
using DatingApp.API.Model;

namespace DatingApp.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            //add url and age
            CreateMap<User, UserForListDto>()
              .ForMember(dest => dest.PhotoUrl, opt => 
                  opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url))
              .ForMember(dest => dest.Age, opt =>
                  opt.MapFrom(src => src.DateOfBirth.CalculateAge()));        
            
            CreateMap<User, UserForDetailDto>()
              .ForMember(dest => dest.PhotoUrl, opt => 
                  opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url))
              .ForMember(dest => dest.Age, opt => 
                  opt.MapFrom(src => src.DateOfBirth.CalculateAge()));

            CreateMap<Photo, PhotosForDetailDto>();
        }
    }
}