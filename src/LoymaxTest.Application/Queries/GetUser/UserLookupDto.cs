using AutoMapper;
using LoymaxTest.Application.Common.Mappings;
using LoymaxTest.Domain.Models;

namespace LoymaxTest.Application.Queries.GetUser
{
    public class UserLookupDto : IMapWith<User>
    {
        public Guid Id { get; set; }

        public string Login { get; set; }

        public string Name { get; set; }

        public string DateOfBirth { get; set; }

        public string Salt { get; set; }

        public string SaltedHashedPassword { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, UserLookupDto>()
                .ForMember(userDto => userDto.Login,
                    opt => opt.MapFrom(user => user.Login))
                .ForMember(userDto => userDto.Name,
                    opt => opt.MapFrom(
                        user => string.Join(' ', user.LastName, user.FirstName, user.Patronymic)))
                .ForMember(userDto => userDto.DateOfBirth,
                    opt => opt.MapFrom(user => user.DateOfBirth))
                .ForMember(userDto => userDto.Id,
                    opt => opt.MapFrom(user => user.Id))
                .ForMember(userDto => userDto.Salt,
                    opt => opt.MapFrom(user => user.Salt))
                .ForMember(userDto => userDto.SaltedHashedPassword,
                    opt => opt.MapFrom(user => user.SaltedHashedPassword));
        }
    }
}
