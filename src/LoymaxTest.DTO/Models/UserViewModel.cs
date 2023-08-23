using System.ComponentModel.DataAnnotations;
using LoymaxTest.Domain.Models;

namespace LoymaxTest.DTO.Models
{
    public class UserViewModel
    {
        #region Property

        /// <summary>
        /// Логин
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        [MaxLength(15)]
        public string Login { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        [MaxLength(50)]
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        [MaxLength(50)]
        public string LastName { get; set; }

        /// <summary>
        /// Отчество
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        [MaxLength(50)]
        public string Patronymic { get; set; }

        /// <summary>
        /// Дата рождения (00/00/0000)
        /// </summary>
        public string DateOfBirth { get; set; }

        public string Password { get; set; }

        #endregion

        #region Methods

        public static UserViewModel Create(User user)
            => new()
            {
                Login = user.Login,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Patronymic = user.Patronymic,
                DateOfBirth = user.DateOfBirth.ToShortDateString()
            };

        #endregion
    }

    public record UserSecurityDto(string Login, string Password);
}
