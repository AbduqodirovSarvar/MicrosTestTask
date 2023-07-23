using AutoMapper;
using Micros.Application.Models.ViewModels;
using Micros.Application.UseCases.InComeCases.Command;
using Micros.Application.UseCases.OutComeCases.Command;
using Micros.Application.UseCases.UserCases.Command;
using Micros.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micros.Application.MappingProfiles
{
    public class Mapper : Profile
    {
        public Mapper() 
        {
            CreateMap<User, UserViewModel>();
            CreateMap<InCome, InComeViewModel>();
            CreateMap<OutCome, OutComeViewModel>();
            CreateMap<CreateUserCommand, User>();
            CreateMap<CreateInComeCommand, InCome>();
            CreateMap<CreateoutComeCommand, OutCome>();
        }
    }
}
