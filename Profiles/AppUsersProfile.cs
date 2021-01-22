using System;
using AutoMapper;
using ReactTube.Dtos;
using ReactTube.Models;

namespace ReactTube.Profiles
{
    public class AppUsersProfile : Profile
    {
        ApplicationDbContext _context;
        public AppUsersProfile(ApplicationDbContext context)
        {
            _context = context;
            CreateMap<string, Guid>().ConvertUsing(s => Guid.Parse(s));
            CreateMap<ApplicationUser, AppUserReadDto>();
            CreateMap<Video, VideoReadDto>()
                .ForMember(vdto => vdto.AuthorName,
                            memberOptions => memberOptions.MapFrom(Video => Video.AppUser.UserName));
            CreateMap<AppUserCreateDto, ApplicationUser>();
            CreateMap<VideoCreateDto, Video>()
                .ForMember(i => i.AppUser,
                            opt => opt.MapFrom(o =>
                              _context.Users.Find(o.AppUserId)));

        }
    }
}