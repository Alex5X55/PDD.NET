namespace WebApi.Models.User
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Login { get; set; }

        public string Email { get; set; }

        public DateTime LastLoginOn { get; set; }

        public string PasswordHash { get; set; }

        //public int UserDetailId { get; set; }
    }
}