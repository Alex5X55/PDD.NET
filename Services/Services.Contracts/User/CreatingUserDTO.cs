
namespace Services.Contracts.User
{
    public class CreatingUserDTO
    {
        public string Login { get; set; }

        public string Email { get; set; }

        public DateTime LastLoginOn { get; set; }

        public string PasswordHash { get; set; }

        //public Guid UserDetailId { get; set; }
    }
}