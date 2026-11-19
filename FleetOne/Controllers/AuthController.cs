using FleetOne.Dtos;
using FleetOne.Services;
using Microsoft.AspNetCore.Mvc;

namespace FleetOne.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController(AuthService authService) : ControllerBase
{
    [HttpPost("login")]
    public async Task<ActionResult<LoginResponseDto>> Login([FromBody] LoginDto loginDetails)
    {
        var user = await authService.Login(loginDetails);

        if (user is null)
        {
            return Unauthorized("Invalid email or password");
        }

        return Ok(user);
    }

    [HttpPost("register")]
    public async Task<ActionResult> Register([FromBody] CreateUserDto newUser)
    {
        var user = await authService.Register(newUser);
        if (user is null)
        {
            return Conflict("A user with that email already exists");
        }

        return Ok(new RegisterResponseDto
        {
            UserId = user.UserId,
            FirstName = user.FirstName,
            Surname = user.LastName,
            Email = user.Email,
            ContactNumber = user.Phone ?? ""
        });
    }
}