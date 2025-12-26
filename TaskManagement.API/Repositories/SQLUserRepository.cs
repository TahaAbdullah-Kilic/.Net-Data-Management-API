using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TaskManagement.API.Data;
using TaskManagement.API.Models.Dto;

namespace TaskManagement.API.Repositories
{
    public class SQLUserRepository : IUserRepository
    {
        readonly TaskManagementAuthDbContext dbContext;
        readonly UserManager<IdentityUser> userManager;
        public SQLUserRepository(TaskManagementAuthDbContext dbContext,UserManager<IdentityUser> userManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
        }
        public async Task<List<UserDto>> GetAllAsync(bool isAscending, int pageNumber = 1, int pageSize = 100)
        {
            var users = await userManager.Users.ToListAsync();
            var userDtos = new List<UserDto>();

            foreach (var user in users)
            {
                var roles = await userManager.GetRolesAsync(user);
                
                userDtos.Add(new UserDto
                {
                    Id = user.Id,
                    Email =  user.Email,
                    Roles = roles.ToArray()
                });
            }

            userDtos = isAscending 
                ? userDtos.OrderBy(u => u.Email).ToList()
                : userDtos.OrderByDescending(u => u.Email).ToList();

            pageNumber = pageNumber < 1 
                ? 1 
                : pageNumber;
            pageSize = pageSize < 1
                ? 10 
                : pageSize;

            userDtos = userDtos.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            return userDtos;
        }

        public async Task<UserDto> GetByIdAsync(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            
            if (user == null)
            {
                return null;
            }

            var roles = await userManager.GetRolesAsync(user);

            var userDto = new UserDto
            {
                Id = user.Id,
                Email = user.Email,
                Roles = roles.ToArray()
            };

            return userDto;
        }

        public async Task<UserDto> UpdateRolesAsync(string id, string[] roles)
        {
            var user = await userManager.FindByIdAsync(id);

            if (user == null)
            {
                return null;
            }

            var currentRoles = await userManager.GetRolesAsync(user);

            var rolesToAdd = roles.Except(currentRoles).ToList();

            var rolesToRemove = currentRoles.Except(roles).ToList();

            if (rolesToAdd.Any())
            {
                var result = await userManager.AddToRolesAsync(user, rolesToAdd);
                if (!result.Succeeded)
                {
                    throw new Exception("Failed to add roles: " + string.Join(", ", result.Errors.Select(e => e.Description)));
                }
            }

            if (rolesToRemove.Any())
            {
                var result = await userManager.RemoveFromRolesAsync(user, rolesToRemove);
                if (!result.Succeeded)
                {
                    throw new Exception("Failed to remove roles: " + string.Join(", ", result.Errors.Select(e => e.Description)));
                }
            }

            var rolesAfterUpdate = await userManager.GetRolesAsync(user);

            var userDto = new UserDto
            {
                Id = user.Id,
                Email = user.Email,
                Roles = rolesAfterUpdate.ToArray()
            };

            return userDto;
        }

        public async Task<UserDto> DeleteAsync(string id)
        {
            var user = await userManager.FindByIdAsync(id);

            if (user == null)
            {
                return null;
            }

            var roles = await userManager.GetRolesAsync(user);

            var userDto = new UserDto
            {
                Id = user.Id,
                Email = user.Email,
                Roles = roles.ToArray()
            };
            await userManager.DeleteAsync(user);
            return userDto;
        }
    }
}
