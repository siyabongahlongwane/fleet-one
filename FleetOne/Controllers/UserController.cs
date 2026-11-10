using FleetOne.Data;
using FleetOne.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FleetOne.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(ApplicationDbContext dbContext) : ControllerBase
{
    [HttpGet]
    public async Task<List<User>> Get()
    {
        var users = await dbContext.Users.ToListAsync();
        return users;
    }

    [HttpGet]
    [Route("{id:guid}")]
    public async Task<ActionResult<User>> GetUserById(Guid id)
    {
        Console.WriteLine(id);
        var user = await dbContext.Users.FirstOrDefaultAsync(u => u.UserId == id);
        if (user is null)
        {
            return NotFound();
        }
        return user;
    }
    
    [HttpGet("by-email")]
    public async Task<ActionResult<User>> GetUserByEmail([FromQuery] string email)
    {
        var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
        if (user is null)
        {
            return NotFound("User not found");
        }
        return user;
    }
}