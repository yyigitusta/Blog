using AutoMapper;
using Blog.Application.Features.Blogs.Result;
using Blog.Domain.Entities;

namespace Blog.Application.Features.Blogs.Mappings
{
    public class BlogMappingProfile : Profile
    {
        public BlogMappingProfile()
        {
            CreateMap<eBlog,GetBlogsQueryResult>().ReverseMap();
        }
    }
}
