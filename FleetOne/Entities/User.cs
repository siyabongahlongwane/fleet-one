using System.ComponentModel.DataAnnotations;

namespace FleetOne.Entities;

public class User
{
    public Guid UserId { get; init; }
    [MinLength(2)]
    [MaxLength(100)]
    public required string FirstName { get; init; }
    [MinLength(2)]
    [MaxLength(100)]
    public required string LastName { get; init; }
    [MaxLength(100)]
    public required string Email { get; init; }
    [MinLength(6)]
    [MaxLength(100)]
    public required string PasswordHash { get; init; }
    
    [MaxLength(15)]
    public string? Phone { get; init; }
    public bool IsActive { get; init; } = true;
    public DateTime CreatedAt { get; init; }
    public DateTime UpdatedAt { get; init; }
}