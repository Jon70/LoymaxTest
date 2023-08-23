namespace LoymaxTest.Application.Commands.CreateUser
{
    public class CreateUserDto
    {
        public string Login { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Patronymic { get; set; }

        public string DateOfBirth { get; set; }

        public string Password { get; set; }
    }
}
