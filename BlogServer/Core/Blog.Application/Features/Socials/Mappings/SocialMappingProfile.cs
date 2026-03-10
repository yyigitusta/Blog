using AutoMapper;
using Blog.Application.Features.Socials.Commands;
using Blog.Application.Features.Socials.Results;
using Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Features.Socials.Mappings
{
    public class SocialMappingProfile : Profile
    {
        public SocialMappingProfile()
        {
            CreateMap<Social,GetSocialQueryResult>().ReverseMap();
            CreateMap<Social, GetSocialByIdQueryResult>().ReverseMap();
            CreateMap<Social, CreateSocialCommand>().ReverseMap();
             CreateMap<Social, UpdateSocialCommand>().ReverseMap();
             CreateMap<Social, DeleteSocialCommand>().ReverseMap();
        }
    }
}
