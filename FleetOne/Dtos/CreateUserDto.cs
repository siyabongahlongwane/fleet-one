using System.ComponentModel.DataAnnotations;

namespace FleetOne.Dtos;

public class CreateUserDto
{
    [Required]
    [MinLength(2)]
    public required string Name { get; set; }
    
    [Required]
    [MinLength(2)]
    public required string Surname { get; set; }
    
    [Required]
    [EmailAddress]
    public required string Email { get; set; }
    
    [Required]
    [MinLength(6)]
    public required string Password { get; set; }
    
    [MinLength(10)]
    [MaxLength(12)]
    public string? ContactNumber { get; set; }  
}