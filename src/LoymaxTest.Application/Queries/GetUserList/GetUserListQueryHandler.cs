using AutoMapper;
using AutoMapper.QueryableExtensions;
using LoymaxTest.Application.Interfaces;
using LoymaxTest.Application.Queries.GetUser;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LoymaxTest.Application.Queries.GetUserList
{
    /// <summary>
    /// Обработчик для получения всех пользователей
    /// </summary>
    public class GetUserListQueryHandler : IRequestHandler<GetUserListQuery, UserListVm>
    {
        private readonly IBankDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetUserListQueryHandler(IBankDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<UserListVm> Handle(GetUserListQuery _, CancellationToken cancellationToken)
        {
            var usersQuery = await _dbContext.Users
                .ProjectTo<UserLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new UserListVm(usersQuery);
        }
    }
}
