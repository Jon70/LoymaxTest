using AutoMapper;
using LoymaxTest.Application.Common.Exceptions;
using LoymaxTest.Application.Interfaces;
using LoymaxTest.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LoymaxTest.Application.Queries.GetUser
{
    /// <summary>
    /// Обработчик для получения пользователя по id
    /// </summary>
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserLookupDto>
    {
        private readonly IBankDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetUserByIdQueryHandler(IBankDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<UserLookupDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(l => l.Id == request.Id, cancellationToken);

            return user == null ? throw new NotFoundException(nameof(User)) : _mapper.Map<UserLookupDto>(user);
        }
    }
}
