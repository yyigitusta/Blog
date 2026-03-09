using AutoMapper;
using Blog.Application.Features.SubComments.Commands;
using Blog.Application.Features.SubComments.Queries;
using Blog.Application.Features.SubComments.Results;
using Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Features.SubComments.Mappings
{
    public class SubCommentMappingProfile : Profile
    {
        public SubCommentMappingProfile()
        {
            CreateMap<SubComment, AddSubCommentCommand>().ReverseMap();
            CreateMap<SubComment, GetSubCommentsQueryResult>().ReverseMap();
            CreateMap<SubComment, GetSubCommentByIdResult>().ReverseMap();
                CreateMap<SubComment, UpdateSubCommentCommand>().ReverseMap();
                CreateMap<SubComment, RemoveSubCommentCommand>().ReverseMap();
        }
    }
}
