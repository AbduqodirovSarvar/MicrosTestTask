using Micros.Application.Abstractions;
using Micros.Application.Services;
using Microsoft.Extensions.DependencyInjection;
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
            _services.AddScoped<ICurrentUserService, CurrentUserService>();
            _services.AddScoped<IHashService, HashService>();
            return _services;
        }
    }
}
