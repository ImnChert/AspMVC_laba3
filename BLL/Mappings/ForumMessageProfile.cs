using AutoMapper;
using BLL.DTOs;
using DAL.Entities;

namespace BLL.Mappings
{
    internal class ForumMessageProfile : Profile
    {
        public ForumMessageProfile()
        {
            CreateMap<ForumMessageDTO, ForumMessage>().ReverseMap();
        }
    }
}
