using FleetOne.Dtos;
using FleetOne.Entities;
using Microsoft.AspNetCore.Identity;

namespace FleetOne.Services;

public class PasswordHasherService
{
    public string HashPassword(string password)
    {
        var passwordHasher = new PasswordHasher<User>();
        var hashedPassword = passwordHasher.HashPassword(null!, password);

        return hashedPassword;
    }
}