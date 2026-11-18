using FleetOne.Dtos;
using FleetOne.Entities;
using FleetOne.Repositories;

namespace FleetOne.Services;

public class UserService(UserRepository userRepository, PasswordHasherService passwordHasherService)
{
    public async Task<List<User>> GetAllUsers()
    {
        return await userRepository.GetAllAsync();
    }

    public Task<User?> GetUserById(Guid userId)
    {
        return userRepository.FindByIdAsync(userId);
    }

    public Task<User?> GetUserByEmail(string email)
    {
        return userRepository.FindByEmailAsync(email);
    }

    public async Task<User> AddUser(CreateUserDto userDto)
    {
        var passwordHash = passwordHasherService.HashPassword(userDto.Password);
        var newUserEntity = new User
        {
            FirstName = userDto.Name,
            LastName = userDto.Surname,
            Email = userDto.Email,
            PasswordHash = passwordHash,
        };

        await userRepository.AddUser(newUserEntity);

        return newUserEntity;
    }

    public async Task<bool> DeleteAsync(Guid userId)
    {
        var user = await userRepository.FindByIdAsync(userId);
        if (user is null)
        {
            return false;
        }

        userRepository.RemoveAsync(user);
        
        return true;
    }
}