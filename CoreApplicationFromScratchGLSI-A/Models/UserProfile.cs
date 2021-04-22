using AutoMapper;
using CoreApplicationFromScratchGLSI_A.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApplicationFromScratchGLSI_A.Models
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<Category, CategoryDTO>();
        }
    }
}
