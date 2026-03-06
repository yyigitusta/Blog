using AutoMapper;
using Blog.Application.Features.Blogs.Commands;
using Blog.Application.Features.Blogs.Handlers;
using Blog.Application.Features.Blogs.Result;
using Blog.Domain.Entities;

namespace Blog.Application.Features.Blogs.Mappings
{
    public class BlogMappingProfile : Profile
    {
        public BlogMappingProfile()
        {
            CreateMap<eBlog,GetBlogsQueryResult>().ReverseMap();
            CreateMap<eBlog, CreateBlogCommand>().ReverseMap();
            CreateMap<eBlog,GetBlogByIdQueryResult>().ReverseMap();
            CreateMap<eBlog,UpdateBlogCommand>().ReverseMap();
            CreateMap<eBlog , GetBlogByCategoryIdQueryResult>().ReverseMap();
        }
    }
}
