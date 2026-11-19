using FleetOne.Entities;
using FleetOne.Repositories;
using Microsoft.AspNetCore.Identity;

namespace FleetOne.Services;

public class PasswordHasherService(UserRepository userRepository)
{
    public string HashPassword(string password)
    {
        var passwordHasher = new PasswordHasher<User>();
        var hashedPassword = passwordHasher.HashPassword(null!, password);

        return hashedPassword;
    }

    public async Task<bool> VerifyHashedPassword(string email, string password)
    {
        var user = await userRepository.FindByEmailAsync(email);
        if (user is null)
        {
            return false;
        }

        var passwordHasher = new PasswordHasher<User>();
        var passwordMatched = passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password);

        return passwordMatched == PasswordVerificationResult.Success;
    }
}
