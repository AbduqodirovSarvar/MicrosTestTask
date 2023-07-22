using AutoMapper;
using Micros.Application.Models.ViewModels;
using Micros.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micros.Application.Mapping
{
    public class Mapper : Profile
    {
        public Mapper() 
        {
            CreateMap<User, UserViewModel>();
            CreateMap<InCome, InComeViewModel>();
            CreateMap<OutCome, OutComeViewModel>();
        }
    }
}
