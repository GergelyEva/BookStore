using BookStore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class LoginController : ControllerBase
{
    private readonly IConfiguration config;
    private readonly IUserService userService;

    public LoginController(IConfiguration config1, IUserService userService1)
    {
        config = config1;
        userService = userService1;
    }

    [AllowAnonymous]
    [HttpPost]
    public IActionResult Login([FromBody] UserModel login)
    {
        IActionResult response = Unauthorized();
        var user = userService.Authenticate(login.Username, login.Password);

        if (user != null)
        {
            var accessToken = TokenUtils.GenerateAccessToken(user, config["Jwt:Key"]);
            var refreshToken = TokenUtils.GenerateRefreshToken(user, config["Jwt:Key"]);
            userService.SaveRefreshToken(user.Id, refreshToken);

            response = Ok(new { AccessToken = accessToken, RefreshToken = refreshToken });
        }

        return response;
    }
}
