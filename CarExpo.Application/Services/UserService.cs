using CarExpo.Application.Commands.Command;
using CarExpo.Application.Dto;
using CarExpo.Application.Interfaces;
using CarExpo.Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarExpo.Application.Services
{
    public class UserService : IuserService
    {
        public Task<User> RegisterAsync(RegisterCommand registerCommand)
        {
            throw new NotImplementedException();
        }
    }
}
