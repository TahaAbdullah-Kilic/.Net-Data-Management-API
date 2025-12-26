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
    [Authorize(Roles = "Admin")]
    public class UsersController : ControllerBase
    {
        readonly UserManager<IdentityUser> userManager;
        readonly RoleManager<IdentityRole> roleManager;
        readonly IUserRepository userRepository;

        public UsersController(IUserRepository userRepository, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] bool isAscending = true, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var userDtos = await userRepository.GetAllAsync(isAscending, pageNumber, pageSize);

            return Ok(userDtos);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            var userDto = await userRepository.GetByIdAsync(id);

            if (userDto == null)
            {
                return NotFound("User not found");
            }
            
            return Ok(userDto);
        }

        [HttpPost]
        [Route("assign-role/{id}")]
        public async Task<IActionResult> AssignRole([FromRoute] string id, [FromBody] AssignRoleRequestDto assignRoleRequestDto)
        {
            var user = await userRepository.UpdateRolesAsync(id, assignRoleRequestDto.Roles);

            if (user == null)
            {
                return NotFound("User not found");
            }
            
            return Ok(user);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            var user = await userRepository.DeleteAsync(id);

            if (user == null)
            {
                return NotFound("User not found");
            }
            
            return Ok(user);
        }
    }
}
