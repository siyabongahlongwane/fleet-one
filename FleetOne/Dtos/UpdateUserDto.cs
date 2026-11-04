using System.ComponentModel.DataAnnotations;

namespace FleetOne.Dtos;

public class UpdateUserDto
{
    [MinLength(2)]
    public string? Name { get; set; }
    
    [MinLength(2)]
    public string? Surname { get; set; }
    
    [EmailAddress]
    public string? Email { get; set; }
    
    [MinLength(6)]
    public string? Password { get; set; }
    
    [MinLength(10)]
    [MaxLength(12)]
    public string? ContactNumber { get; set; }  
}