namespace PDD.NET.Domain.Entities;

public class JwtConfig
{
    public required string Secret { get; set; }

    public int LifeTimeAccessMin { get;  set; }

    public int LifeTimeRefreshMin { get;  set; }
}
