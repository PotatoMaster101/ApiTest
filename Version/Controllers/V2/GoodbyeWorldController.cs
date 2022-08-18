using Microsoft.AspNetCore.Mvc;

namespace Version.Controllers.V2;

/// <summary>
/// Say goodbye to user.
/// </summary>
[ApiController]
[ApiVersion("2.0")]
[Route("api/v{version:apiVersion}/goodbye")]
public class GoodbyeWorldController : ControllerBase
{
    [HttpGet]
    public IActionResult SayGoodbye()
    {
        return Ok("Goodbye World from V2");
    }
}
