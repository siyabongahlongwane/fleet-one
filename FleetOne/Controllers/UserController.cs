using FleetOne.Data;
using FleetOne.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FleetOne.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(ApplicationDbContext dbContext)
{
    [HttpGet]
    public async Task<List<User>> Get()
    {
        var users = await dbContext.Users.ToListAsync();
        return users;
    }
}