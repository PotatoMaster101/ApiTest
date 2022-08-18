using Authentication.Models;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.Controllers;

/// <summary>
/// User actions controller.
/// </summary>
[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    /// <summary>
    /// Gets all users.
    /// </summary>
    /// <returns>All users.</returns>
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new[]
        {
            new UserData(Guid.Empty, "test")
        });
    }
}
