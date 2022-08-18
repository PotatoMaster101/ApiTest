using Microsoft.AspNetCore.Mvc;

namespace Version.Controllers.V1;

/// <summary>
/// Say hello to user.
/// </summary>
[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/hello")]
public class HelloWorldController : ControllerBase
{
    [HttpGet]
    public IActionResult SayHello()
    {
        return Ok("Hello World from V1");
    }
}
