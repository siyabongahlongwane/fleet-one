using FleetOne.Dtos;
using FleetOne.Entities;
using FleetOne.Services;
using Microsoft.AspNetCore.Mvc;

namespace FleetOne.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(UserService userService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<User>>> Get()
    {
        var users = await userService.GetAllUsers();
        return Ok(users);
    }

    [HttpGet]
    [Route("{id:guid}")]
    public async Task<ActionResult<User>> GetUserById(Guid id)
    {
        var user = await userService.GetUserById(id);
        if (user is null)
        {
            return NotFound("No user matching that id found");
        }

        return Ok(user);
    }

    [HttpGet("by-email")]
    public async Task<ActionResult<User>> GetUserByEmail([FromQuery] string email)
    {
        var user = await userService.GetUserByEmail(email);
        if (user is null)
        {
            return NotFound("No user matching that email");
        }

        return Ok(user);
    }

    [HttpPost]
    public async Task<ActionResult<User>> AddUser([FromBody] CreateUserDto newUser)
    {
        var user = await userService.GetUserByEmail(newUser.Email);
        if (user is not null)
        {
            return Conflict("User with that email exists");
        }

        var newUserEntity = await userService.AddUser(newUser);

        return Ok(newUserEntity);
    }

    [HttpDelete]
    [Route("{id:guid}")]
    public async Task<ActionResult<User>> DeleteUser([FromRoute] Guid id)
    {
        try
        {
            var deleted = await userService.DeleteAsync(id);
            if (!deleted)
            {
                return NotFound(new { message = "No user matching that id found" });
            }

            return NoContent();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}