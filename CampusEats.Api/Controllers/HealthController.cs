using CampusEats.Api.Data;
using Microsoft.AspNetCore.Mvc;

namespace CampusEats.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HealthController(AppDbContext db, IWebHostEnvironment env) : ControllerBase
{
    // GET /api/health — used for platform health checks and monitoring
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var dbOk = await db.Database.CanConnectAsync();
        return Ok(new
        {
            status = dbOk ? "Healthy" : "Degraded",
            database = dbOk ? "Connected" : "Unreachable",
            environment = env.EnvironmentName,
            timeUtc = DateTime.UtcNow
        });
    }
}
