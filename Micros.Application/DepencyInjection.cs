﻿using AutoMapper;
using Micros.Application.Abstractions;
using Micros.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using Micros.Application.MappingProfiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micros.Application
{
    public static class DepencyInjection
    {
        public static IServiceCollection ApplicationServices(this IServiceCollection _services)
        {
            _services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(DepencyInjection).Assembly);
            });
            _services.AddScoped<ICurrentUserService, CurrentUserService>();
            _services.AddScoped<IHashService, HashService>();
            var mappingconfig = new MapperConfiguration(x =>
            {
                x.AddProfile(new Mapping());
            });

            IMapper mapper = mappingconfig.CreateMapper();
            _services.AddSingleton(mapper);
            return _services;
        }
    }
}
