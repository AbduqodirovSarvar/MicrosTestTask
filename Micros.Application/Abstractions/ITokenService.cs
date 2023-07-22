using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Micros.Application.Abstractions
{
    public interface ITokenService
    {
        string GetToken(Claim[] claims);
    }
}
