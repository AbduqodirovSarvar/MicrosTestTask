using AutoMapper;
using Micros.Application.Abstractions;
using Micros.Application.Models.ViewModels;
using Micros.Application.UseCases.UserCases.Query;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micros.Application.UseCases.UserCases.QueryHandler
{
    public class GetAllUserByPositionQueryHandler : IQueryHandler<GetAllUserByPositionQuery, List<UserViewModel>>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        public GetAllUserByPositionQueryHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<UserViewModel>> Handle(GetAllUserByPositionQuery request, CancellationToken cancellationToken)
        {
            var users = await _context.Users.Where(x => (int)(x.Position) == (int)(request.Position)).ToListAsync(cancellationToken);
            return _mapper.Map<List<UserViewModel>>(users);
        }
    }
}
