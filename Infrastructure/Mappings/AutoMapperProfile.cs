using Application.Dtos;
using AutoMapper;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mappings
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User,UserDto>().ReverseMap();
            CreateMap<Segment,SegmentDto>().ReverseMap();
            CreateMap<UserSegment, UserSegmentDto>().ReverseMap();
        }
    }
}
