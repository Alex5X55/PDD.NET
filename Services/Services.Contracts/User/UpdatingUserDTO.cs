
namespace Services.Contracts.User
{
    public class UpdatingUserDTO
    {
        public string Login { get; set; }

        public string Email { get; set; }

        public DateTime LastLoginOn { get; set; }

        public string PasswordHash { get; set; }

        //public int UserDetailId { get; set; }
    }
}