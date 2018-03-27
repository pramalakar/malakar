using AutoMapper;
using malakar.Dtos;
using malakar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace malakar.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Layout, LayoutDto>();
            Mapper.CreateMap<LayoutDto, Layout>();
        }
    }
}