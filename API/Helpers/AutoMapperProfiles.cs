using System.Linq;
using API.DTOs;
using API.Entities;
using API.Extensions;
using AutoMapper;

namespace API.Helpers
{
  public class AutoMapperProfiles : Profile
  {
    public AutoMapperProfiles()
    {
        CreateMap<AppUser, MemberDto>()
          .ForMember(dest => dest.PhotoUrl, opt => opt.MapFrom(
            src => src.Photos.FirstOrDefault(
              x => x.IsMain).Url)) //specify destination property (PhotoUrl), opt is the src of where you are mapping from, get first photo that is marked as main.
          .ForMember(dest => dest.Age, opt => opt.MapFrom(
            src => src.DateOfBirth.CalculateAge()
          ));
        CreateMap<Photo, PhotoDto>();
    }
  }
}