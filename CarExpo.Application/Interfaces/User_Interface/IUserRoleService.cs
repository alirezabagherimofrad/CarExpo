using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarExpo.Application.Interfaces.User_Interface
{
    public interface IUserRoleService
    {
        Task AssignRoleAsync(Guid userId, string roleName);
    }
}
