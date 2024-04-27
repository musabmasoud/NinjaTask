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
            CreateMap<Users,UserDto>().ReverseMap();
            CreateMap<Segment,SegmentDto>().ReverseMap();
        }
    }
}
