using Micros.Application.Abstractions;
using Micros.Infrastucture.DbContexts;
using Micros.Infrastucture.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micros.Infrastucture
{
    public static class DepencyInjection
    {
        public static IServiceCollection InfrastructureServices(this IServiceCollection _services, IConfiguration _configuration)
        {
            _services.AddDbContext<AppDbContext>(options
                => options.UseNpgsql(_configuration.GetConnectionString("DefaultConnection")));

            _services.AddScoped<IAppDbContext, AppDbContext>();
            _services.AddScoped<ITokenService, TokenService>();

            _services.Configure<JWTConfiguration>(_configuration.GetSection("JWTConfiguration"));

            _services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidAudience = _configuration["JWTConfiguration:ValidAudience"],
                        ValidIssuer = _configuration["JWTConfiguration:ValidIssuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWTConfiguration:Secret"]))
                    };
                });


            return _services;
        }
    }
}
