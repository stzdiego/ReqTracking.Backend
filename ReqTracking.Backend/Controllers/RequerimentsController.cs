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
        var requeriments = await context.Requeriments
            .Include(x => x.UserCreator)
            .Include(x => x.UserAssigned)
            .ToListAsync();
        return Ok(requeriments);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var requeriment = await context.Requeriments
            .Include(x => x.UserCreator)
            .Include(x => x.UserAssigned)
            .FirstOrDefaultAsync(x => x.Id == id);
            
        if (requeriment == null)
        {
            return NotFound();
        }
        return Ok(requeriment);
    }
    
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Requeriment requeriment)
    {
        context.Requeriments.Add(requeriment);
        await context.SaveChangesAsync();
        return CreatedAtRoute("GetRequeriment", new { id = requeriment.Id }, requeriment);
    }
    
    [HttpPost("list")]
    public async Task <IActionResult> List([FromBody] Requeriment[] requeriments)
    {
        context.Requeriments.AddRange(requeriments);
        await context.SaveChangesAsync();
        return Ok();
    }
    
    [HttpPost("filter")]
    public async Task<IActionResult> Filter([FromBody] RequerimentFilterDto filter)
    {
        var query = context.Requeriments.AsQueryable();
        
        query = query.Include(x => x.UserCreator)
            .Include(x => x.UserAssigned);
        
        if (filter.Id > 0)
        {
            query = query.Where(r => r.Id == filter.Id);
        }
        
        if (!string.IsNullOrEmpty(filter.Subject))
        {
            query = query.Where(r => r.Subject.Contains(filter.Subject));
        }
        
        if (filter.Stage != Stage.None)
        {
            query = query.Where(r => r.Stage == filter.Stage);
        }
        
        if (filter.Priority != Priority.None)
        {
            query = query.Where(r => r.Priority == filter.Priority);
        }
        
        var requeriments = await query.ToListAsync();
        
        return Ok(requeriments);
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
    
    [HttpPost("updateStage")]
    public async Task<IActionResult> ChangeStage([FromBody] ChangeStageDto dto)
    {
        var requeriment = await context.Requeriments.FindAsync(dto.IdRequeriment);
        if (requeriment == null)
        {
            return NotFound();
        }
        
        var track = new Tracking()
        {
            RequerimentId = dto.IdRequeriment,
            Stage = dto.Stage,
            Description = dto.Description,
            UserId = dto.IdUser
        };
        
        requeriment.Stage = dto.Stage;
        requeriment.UpdatedAt = DateTime.UtcNow;
        
        context.Trackings.Add(track);
        context.Entry(requeriment).State = EntityState.Modified;
        
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