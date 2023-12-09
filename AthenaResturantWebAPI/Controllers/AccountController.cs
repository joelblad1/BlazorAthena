using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using AthenaResturantWebAPI.Services;
using System.Threading.Tasks;
using AthenaResturantWebAPI.Data.AppUser;

public class AccountController : ControllerBase
{
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly JwtService _jwtService;

    public AccountController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, JwtService jwtService)
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _jwtService = jwtService;
    }



    [HttpGet("current-user")]
    public async Task<IActionResult> GetCurrentUserInfo()
    {
        // Get the user's ID from the claims
        var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (userId == null)
        {
            // User is not authenticated
            return Unauthorized();
        }

        // Retrieve the user from UserManager using their ID
        var user = await _userManager.FindByIdAsync(userId);

        if (user == null)
        {
            // User not found
            return NotFound();
        }

        // Now 'user' contains the IdentityUser object for the current user
        return Ok(new
        {
            UserId = user.Id,
            UserName = user.UserName,
            Email = user.Email,
            // Add any other properties you want to expose
        });
    }

    [HttpGet("current-user1")]
    public async Task<IActionResult> GetCurrentUserInfo1()
    {
        // Get the user's ID from the claims
        var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (userId == null)
        {
            // User is not authenticated
            return Unauthorized();
        }

        // Retrieve the user from UserManager using their ID
        var user = await _userManager.FindByIdAsync(userId);

        if (user == null)
        {
            // User not found
            return NotFound();
        }

        // Retrieve the user's roles
        var roles = await _userManager.GetRolesAsync(user);
        // Generate the JWT token
        
        var token = _jwtService.GenerateJwtToken(user.Id, user.Email, roles.ToList());

        // Now 'user' contains the IdentityUser object for the current user
        return Ok(new
        {
            UserId = user.Id,
            UserName = user.UserName,
            Email = user.Email,
            Token = token,
            // Add any other properties you want to expose
        });
    }
}
