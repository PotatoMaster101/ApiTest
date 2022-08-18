namespace Authentication.Models;

/// <summary>
/// Represents the user credentials - used in authentication request body.
/// </summary>
public record UserCredentials(string? Username, string? Password);
