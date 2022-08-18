using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Authentication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Authentication.Controllers;

/// <summary>
/// User authentication controller.
/// </summary>
[ApiController]
[Route("api/auth")]
public class AuthenticationController : ControllerBase
{
    private readonly IConfiguration _configuration;

    public AuthenticationController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    /// <summary>
    /// Authenticates a user.
    /// </summary>
    /// <param name="data">Authentication request body.</param>
    /// <returns>The generated JWT token if authentication is successful, otherwise unauthorized.</returns>
    [AllowAnonymous]
    [HttpPost]
    public IActionResult Authenticate([FromBody] UserCredentials data)
    {
        var userData = ValidateUserCredentials(data);
        if (userData is null)
            return Unauthorized();

        var configSignKey = _configuration.GetValue<string>("Authentication:SignKey");
        var signKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configSignKey));
        var signCreds = new SigningCredentials(signKey, SecurityAlgorithms.HmacSha512);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, userData.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.UniqueName, userData.Username)
        };

        var token = new JwtSecurityToken(
            _configuration.GetValue<string>("Authentication:Issuer"),
            _configuration.GetValue<string>("Authentication:Audience"),
            claims,
            DateTime.UtcNow,
            DateTime.UtcNow.AddSeconds(30),     // token will expire after 30 sec
            signCreds);
        return Ok(new JwtSecurityTokenHandler().WriteToken(token));
    }

    /// <summary>
    /// Validates the user credentials and retrieves the user data.
    /// </summary>
    /// <param name="data">The user credentials to validate.</param>
    /// <returns>The user data matching the user credentials, or <see langword="null"/> when validation fails.</returns>
    private static UserData? ValidateUserCredentials(UserCredentials data)
    {
        // WARNING: DEMO PURPOSE ONLY
        // ideally you wanna query user database or talk to third party auth provider
        return data.Username == "test" && data.Password == "test" ? new UserData(Guid.Empty, "test") : null;
    }
}
