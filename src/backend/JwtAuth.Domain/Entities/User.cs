namespace JwtAuth.Domain.Entities;

public class User 
{
    public required int Id { get; set; }

    public string? Name { get; set; }

    public required string Username { get; set; }

    public required string Password { get; set; }
}
