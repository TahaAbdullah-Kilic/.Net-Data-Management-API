using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.API.Models.Dto;
using TaskManagement.API.Repositories;

namespace TaskManagement.API.Controllers.V1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        readonly UserManager<IdentityUser> userManager;
        readonly ITokenRepository tokenRepository;

        public AuthController(UserManager<IdentityUser> userManager, ITokenRepository tokenRepository)
        {
            this.userManager = userManager;
            this.tokenRepository = tokenRepository;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerRequestDto)
        {
            var user = new IdentityUser
            {
                UserName = registerRequestDto.Email,
                Email = registerRequestDto.Email
            };

            var identityResult = await userManager.CreateAsync(user, registerRequestDto.Password);

            if (!identityResult.Succeeded)
            {
                return BadRequest(identityResult.Errors);
            }

            identityResult = await userManager.AddToRoleAsync(user, "User");

            if (!identityResult.Succeeded)
            {
                identityResult = await userManager.DeleteAsync(user);
                return BadRequest(identityResult.Errors);
            }

            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
        {
            var user = await userManager.FindByEmailAsync(loginRequestDto.Email);

            if (user == null || !await userManager.CheckPasswordAsync(user, loginRequestDto.Password))
            {
                return Unauthorized("Invalid email or password");
            }

            var roles = await userManager.GetRolesAsync(user);

            var jwtToken = tokenRepository.CreateJWTToken(user, roles.ToList());

            if (jwtToken == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to generate JWT token");
            }

                var response = new
                {
                    Token = jwtToken,
                };

            return Ok(response);

        }     
    }
}
