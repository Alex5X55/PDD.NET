using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PDD.NET.Domain.Entities;

public class RefreshToken
{
    //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key, Column(Order = 0)]
    public int Id { get; set; }
    //public int? UserId { get; set; }
    public string? Token { get; set; }
    public string? JwtId { get; set; }
    public bool IsUsed { get; set; }
    public bool IsRevoked { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime ExpiredAt { get; set; }

    public int UserId { get; set; }
    //[ForeignKey(nameof(Id))]
    //public virtual User User { get; set; }
}
