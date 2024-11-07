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
        var trackings = await context.Trackings.Where(t => t.RequerimentId == reqId).ToListAsync();
        return Ok(trackings);
    }
}