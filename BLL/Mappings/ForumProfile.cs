using AutoMapper;
using BLL.DTOs;
using DAL.Entities;

namespace BLL.Mappings
{
    internal class ForumProfile : Profile
    {
        public ForumProfile()
        {
            CreateMap<ForumDTO, Forum>().ReverseMap();
        }
    }
}
