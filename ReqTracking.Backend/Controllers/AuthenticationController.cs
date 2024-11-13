using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReqTracking.Backend.Context;
using ReqTracking.Backend.Dtos;
using ReqTracking.Backend.Enums;
using ReqTracking.Backend.Models;

namespace ReqTracking.Backend.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthenticationController(ApplicationDbContext context) : Controller
{
    [HttpGet("login")]
    public async Task<IActionResult> Login(string email, string password)
    {
        var user = await context.Users.FirstOrDefaultAsync(u => u.Email.ToLower() == email.ToLower());
        if (user == null)
        {
            return NotFound();
        }
        
        if (!BCrypt.Net.BCrypt.Verify(password, user.Password))
        {
            return Unauthorized();
        }
        
        return Ok(user.Id);
    }
    
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto dto)
    {
        var user = await context.Users.FirstOrDefaultAsync(u => u.Email.ToLower() == dto.Email.ToLower());

        if (user is null)
        {
            var newUser = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                Role = Role.Guest
            };
            
            context.Users.Add(newUser);
            await context.SaveChangesAsync();
            return Ok(newUser.Id);
        }
        else
        {
            return Ok(user.Id);
        }
    }
}