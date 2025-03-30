using CarExpo.Application.Commands.Command;
using CarExpo.Application.Dto;
using CarExpo.Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarExpo.Application.Interfaces
{
    public interface IuserService
    {
        Task<User> RegisterAsync(RegisterCommand registerCommand);

    }
}
