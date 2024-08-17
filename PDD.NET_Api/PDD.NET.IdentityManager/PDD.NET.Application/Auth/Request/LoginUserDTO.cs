using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PDD.NET.Application.Auth.Request;

public class LoginUserDTO
{
    [Required]
    [EmailAddress]
    [DefaultValue("admin@admin.ru")]
    public string Email { get; set; }

    [Required]
    [DefaultValue("password")]
    public string Password { get; set; }
}
