using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReqTracking.Backend.Context;
using ReqTracking.Backend.Models;
using BCrypt.Net;

namespace ReqTracking.Backend.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController(ApplicationDbContext context) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var users = await context.Users.ToListAsync();
        return Ok(users);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var user = await context.Users.FindAsync(id);
        if (user == null)
        {
            return NotFound();
        }
        return Ok(user);
    }
    
    [HttpPost]
    public async Task<IActionResult> Post(User user)
    {
        if (context.Users.Any(u => u.Email.ToLower() == user.Email.ToLower()))
        {
            return BadRequest("Email already in use");
        }
        
        user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
        user.Email = user.Email.ToLower();
        
        context.Users.Add(user);
        await context.SaveChangesAsync();
        return Ok(user.Id);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, User user)
    {
        if (id != user.Id)
        {
            return BadRequest();
        }
        
        context.Entry(user).State = EntityState.Modified;
        await context.SaveChangesAsync();
        return NoContent();
    }
    
    [HttpPost("assignLeader/{userId}/{reqId}")]
    public async Task<IActionResult> AssignLeader(int userId, int reqId)
    {
        var user = await context.Users.FindAsync(userId);
        if (user == null)
        {
            return NotFound();
        }
        
        var leader = await context.Requeriments.FindAsync(reqId);
        if (leader == null)
        {
            return NotFound();
        }
        
        var userLeader = new UserLead
        {
            UserId = userId,
            LeadId = reqId
        };
        
        context.UsersLeads.Add(userLeader);
        await context.SaveChangesAsync();
        return Ok();
    }
}