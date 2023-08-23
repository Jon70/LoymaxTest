using AutoMapper;
using LoymaxTest.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LoymaxTest.Application.Queries.GetUser
{
    /// <summary>
    /// Обработчик для получения пользователя по логину
    /// </summary>
    public class GetUserByLoginQueryHandler : IRequestHandler<GetUserByLoginQuery, UserLookupDto>
    {
        private readonly IBankDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetUserByLoginQueryHandler(IBankDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<UserLookupDto> Handle(GetUserByLoginQuery request, CancellationToken cancellationToken)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(l => l.Login == request.Login, cancellationToken);

            return (user == null ? await Task.FromResult<UserLookupDto?>(null) : _mapper.Map<UserLookupDto>(user))!;
        }
    }
}
