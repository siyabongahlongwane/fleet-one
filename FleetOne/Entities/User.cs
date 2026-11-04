using System.ComponentModel.DataAnnotations;

namespace FleetOne.Entities;

public class User
{
    public Guid UserId { get; set; }
    [MinLength(2)]
    public required string FirstName { get; set; }
    [MinLength(2)]
    public required string LastName { get; set; }
    public required string Email { get; set; }
    [MinLength(6)]
    public required string PasswordHash { get; set; }
    public string? Phone { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}