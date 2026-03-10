using AutoMapper;
using Blog.Application.Features.ContacInfos.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Domain.Entities;
using Blog.Application.Features.ContacInfos.Command;


namespace Blog.Application.Features.ContacInfos.Mappings
{
    public class ContacInfoMappingProfile : Profile
    {
        public ContacInfoMappingProfile()
        {
            CreateMap<ContacInfo, GetContacInfoQueryResult>().ReverseMap();
            CreateMap<ContacInfo, GetContacInfoByIdQueryResult>().ReverseMap();
            CreateMap<ContacInfo, CreateContactInfoCommand>().ReverseMap();
                CreateMap<ContacInfo, UpdateContactInfoCommand>().ReverseMap();
               CreateMap<ContacInfo, RemoveContacInfoCommand>().ReverseMap();
        }
    }
}
