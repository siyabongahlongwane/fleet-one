using FleetOne.Dtos;
using FleetOne.Entities;
using FleetOne.Repositories;

namespace FleetOne.Services;

public class AuthService(PasswordHasherService passwordHasherService, UserRepository userRepository)
{
    public async Task<LoginResponseDto?> Login(LoginDto loginDetails)
    {
        var user = await userRepository.FindByEmailAsync(loginDetails.Email);

        if (user is null)
        {
            return null;
        }

        var passwordIsValid = await passwordHasherService.VerifyHashedPassword(
            loginDetails.Email,
            loginDetails.Password
        );

        return passwordIsValid
            ? new LoginResponseDto
            {
                UserId = user.UserId,
                Email = user.Email,
                FirstName = user.FirstName,
                Surname = user.LastName,
                ContactNumber = user.Phone ?? ""
            }
            : null;
    }

    public async Task<User?> Register(CreateUserDto newUser)
    {
        var existingUser = await userRepository.FindByEmailAsync(newUser.Email);

        if (existingUser is not null)
        {
            return null;
        }

        var user = new User
        {
            FirstName = newUser.Name,
            LastName = newUser.Surname,
            Email = newUser.Email,
            Phone = newUser.ContactNumber,
            PasswordHash = passwordHasherService.HashPassword(newUser.Password)
        };
        return await userRepository.AddUser(user);
    }
}