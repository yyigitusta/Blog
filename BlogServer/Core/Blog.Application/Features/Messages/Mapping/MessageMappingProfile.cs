using AutoMapper;
using Blog.Application.Features.Messages.Command;
using Blog.Application.Features.Messages.Results;
using Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Features.Messages.Mapping
{
    public class MessageMappingProfile : Profile
    {
        public MessageMappingProfile()
        {
             CreateMap<Message,CreateMessageCommand>().ReverseMap();
             CreateMap<Message, GetMessageQueryByIdResult>().ReverseMap();
             CreateMap<Message, GetMessageQueryResult>().ReverseMap();
             CreateMap<Message, UdpateMessageCommand>().ReverseMap();
             CreateMap<Message, RemoveMessageCommand>().ReverseMap();   
        }
    }
}
