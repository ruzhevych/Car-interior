﻿using AutoMapper;
using Car_interior.Dtos;
using Car_interior.Entities;

namespace Car_interior.MapperProfiles
{
    public class AppProfile : Profile
    {
        public AppProfile()
        {
                 CreateMap<CarsDto, Cars>().ReverseMap();
        }
    }
}
