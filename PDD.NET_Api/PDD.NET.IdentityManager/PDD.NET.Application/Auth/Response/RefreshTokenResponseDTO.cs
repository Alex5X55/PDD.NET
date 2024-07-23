namespace PDD.NET.Application.Auth.Response;

public class RefreshTokenResponseDTO
{
    public int Id { get; set; }

    public string Email { get; set; }
    public bool Success { get; set; }
    public List<string> Errors { get; set; }
}
