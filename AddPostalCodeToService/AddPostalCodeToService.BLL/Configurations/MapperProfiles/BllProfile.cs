using System;
using System.Collections.Generic;
using System.Text;
using AddPostalCodeToService.BLL.DTOs.PostalCodeDto;
using AddPostalCodeToService.DAL.Entities;
using AutoMapper;

namespace AddPostalCodeToService.BLL.Configurations.MapperProfiles
{
    class BllProfile : Profile
    {
        public BllProfile()
        {
            CreateMap<CreatePostalCodeDto, PostalCode>();

            CreateMap<PostalCode, CreatePostalCodeDto>();
        }
    }
}
