using AutoMapper;
using HedonismBlog.Models;
using HedonismBlog.ViewModels;
using SQLitePCL;

namespace HedonismBlog
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, RegisterUserViewModel>();
            CreateMap<RegisterUserViewModel, User>();
        }
    }
}
