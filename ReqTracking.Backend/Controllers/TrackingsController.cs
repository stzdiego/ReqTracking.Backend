using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReqTracking.Backend.Context;

namespace ReqTracking.Backend.Controllers;

[ApiController]
[Route("[controller]")]
public class TrackingsController(ApplicationDbContext context) : Controller
{
    [HttpGet("{reqId}")]
    public async Task<IActionResult> Get(int reqId)
    {
        var trackings = await context.Trackings
            .Where(t => t.RequerimentId == reqId)
            .Include(x => x.User)
            .Include(x => x.Requeriment)
            .ToListAsync();
        return Ok(trackings);
    }
}