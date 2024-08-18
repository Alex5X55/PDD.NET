namespace PDD.NET.Domain.Entities;

public class JwtConfig
{
    public string? Secret { get; }

    public int LifeTimeAccessMin { get;}

    public int LifeTimeRefreshMin { get; }
}
