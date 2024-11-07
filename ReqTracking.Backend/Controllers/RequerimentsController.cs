using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReqTracking.Backend.Context;
using ReqTracking.Backend.Dtos;
using ReqTracking.Backend.Enums;
using ReqTracking.Backend.Models;

namespace ReqTracking.Backend.Controllers;

[ApiController]
[Route("[controller]")]
public class RequerimentsController(ApplicationDbContext context) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var requeriments = await context.Requeriments.ToListAsync();
        return Ok(requeriments);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var requeriment = await context.Requeriments.FindAsync(id);
        if (requeriment == null)
        {
            return NotFound();
        }
        return Ok(requeriment);
    }
    
    [HttpPost]
    public async Task<IActionResult> Post(Requeriment requeriment)
    {
        context.Requeriments.Add(requeriment);
        await context.SaveChangesAsync();
        return CreatedAtRoute("GetRequeriment", new { id = requeriment.Id }, requeriment);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Requeriment requeriment)
    {
        if (id != requeriment.Id)
        {
            return BadRequest();
        }
        
        context.Entry(requeriment).State = EntityState.Modified;
        await context.SaveChangesAsync();
        return NoContent();
    }
    
    [HttpPost("updateStage/{id}/{stage}")]
    public async Task<IActionResult> ChangeStage(int id, int stage)
    {
        var requeriment = await context.Requeriments.FindAsync(id);
        if (requeriment == null)
        {
            return NotFound();
        }
        
        requeriment.Stage = (Stage)stage;
        await context.SaveChangesAsync();
        return NoContent();
    }
    
    [HttpPost("assignUser/{id}/{userId}")]
    public async Task<IActionResult> AssignUser(int id, int userId)
    {
        var requeriment = await context.Requeriments.FindAsync(id);
        if (requeriment == null)
        {
            return NotFound();
        }
        
        var user = await context.Users.FindAsync(userId);
        if (user == null)
        {
            return NotFound();
        }
        
        requeriment.UserAssignedId = userId;
        await context.SaveChangesAsync();
        return NoContent();
    }
}