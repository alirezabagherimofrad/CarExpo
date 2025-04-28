using CarExpo.Application.Interfaces.User_Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarExpo.Controllers.UserController
{
    [ApiController]
    [Route("api/User/[Controller]")]
    public class UserRoleController:ControllerBase
    {
        private readonly IUserRoleService _roleService;

        public UserRoleController(IUserRoleService roleService)
        {
            _roleService = roleService;
        }

        [Authorize(Roles = "SiteManager")]
        [HttpPost("assign")]
        public async Task<IActionResult> AssignRole(Guid userId, string roleName)
        {
            await _roleService.AssignRoleAsync(userId, roleName);
            return Ok("نقش با موفقیت به کاربر داده شد.");
        }
    }
}
