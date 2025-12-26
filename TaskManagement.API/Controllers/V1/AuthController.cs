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
        readonly RoleManager<IdentityRole> roleManager;

        public AuthController(UserManager<IdentityUser> userManager, ITokenRepository tokenRepository, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.tokenRepository = tokenRepository;
            this.roleManager = roleManager;
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

                var response = new
                {
                    Token = jwtToken,
                };

            return Ok(response);

        }

        [HttpPost]
        [Route("assign-role/{userId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AssignRole([FromRoute] string userId, [FromBody] AssignRoleRequestDto assignRoleRequestDto)
        {
            var user = await userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return NotFound("User not found");
            }

            foreach (var role in assignRoleRequestDto.Roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    return BadRequest($"Role '{role}' does not exist");
                }
            }

            var currentRoles = await userManager.GetRolesAsync(user);

            var rolesToAdd = assignRoleRequestDto.Roles.Except(currentRoles).ToList();

            var rolesToRemove = currentRoles.Except(assignRoleRequestDto.Roles).ToList();

            if (rolesToAdd.Any())
            {
                var result = await userManager.AddToRolesAsync(user, rolesToAdd);
                if (!result.Succeeded)
                {
                    return BadRequest(result.Errors);
                }
            }

            if (rolesToRemove.Any())
            {
                var result = await userManager.RemoveFromRolesAsync(user, rolesToRemove);
                if (!result.Succeeded)
                {
                    return BadRequest(result.Errors);
                }
            }
            return Ok("Roles assigned successfully");
        }
    }
}
