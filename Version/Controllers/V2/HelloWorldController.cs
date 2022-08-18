using Microsoft.AspNetCore.Mvc;

namespace Version.Controllers.V2;

/// <summary>
/// Say hello to user.
/// </summary>
[ApiController]
[ApiVersion("2.0")]
[Route("api/v{version:apiVersion}/hello")]
public class HelloWorldController : ControllerBase
{
    [HttpGet]
    public IActionResult SayHello()
    {
        return Ok("Hello World from V2");
    }

    [HttpGet("loud")]
    public IActionResult SayHelloLoud()
    {
        return Ok("HELLO WORLD!!!!!!!!!!! from V2");
    }
}
