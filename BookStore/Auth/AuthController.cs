using BookStore.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly JwtSettings _jwtSettings;

        public AuthController(IOptions<JwtSettings> jwtSettings)
        {
            _jwtSettings = jwtSettings.Value;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginModel loginModel)
        {
            if (IsValidUser(loginModel.Username, loginModel.Password, out var user))
            {
                var accessToken = TokenUtils.GenerateAccessToken(user, _jwtSettings.Secret);
                var refreshToken = TokenUtils.GenerateRefreshToken();

                var response = new TokenResponse
                {
                    AccessToken = accessToken,
                    RefreshToken = refreshToken
                };

                return Ok(response);
            }

            return Unauthorized();
        }

        [HttpPost("refresh")]
        public IActionResult Refresh(TokenResponse tokenResponse)
        {
            var newAccessToken = TokenUtils.GenerateAccessTokenFromRefreshToken(tokenResponse.RefreshToken, _jwtSettings.Secret);

            var response = new TokenResponse
            {
                AccessToken = newAccessToken,
                RefreshToken = tokenResponse.RefreshToken
            };

            return Ok(response);
        }

        private bool IsValidUser(string username, string password, out User user)
        {
            if (username == "monkey" && password == "monkeypass")
            {
                user = new User { Id = 1, Username = username };
                return true;
            }

            user = null;
            return false;
        }
    }
}
