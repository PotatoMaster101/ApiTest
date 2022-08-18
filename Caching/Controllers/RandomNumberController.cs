using Microsoft.AspNetCore.Mvc;

namespace Caching.Controllers;

/// <summary>
/// Random number generation controller.
/// </summary>
[ApiController]
[Route("api/random")]
public class RandomNumberController : ControllerBase
{
    [HttpGet]
    [ResponseCache(Duration = 10, Location = ResponseCacheLocation.Any)]
    public IActionResult Get()
    {
        return Ok(Random.Shared.Next());
    }

    [HttpGet("{max:int}")]
    [ResponseCache(Duration = 10, Location = ResponseCacheLocation.Any)]
    public IActionResult Get(int max)
    {
        return Ok(new { Value = Random.Shared.Next(max), Max = max });
    }

    [HttpGet("nocache")]
    public IActionResult GetNotCached()
    {
        return Ok(Random.Shared.Next());
    }
}
