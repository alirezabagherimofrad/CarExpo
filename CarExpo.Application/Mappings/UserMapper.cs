using AutoMapper;
using CarExpo.Application.Commands.Command.UserCommand;
using CarExpo.Application.Dto;
using CarExpo.Application.Services;
using CarExpo.Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarExpo.Application.Mappings
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<User, RegisterCommand>().ReverseMap();

            CreateMap<RegisterCommand, RegisterDto>().ReverseMap();

            CreateMap<User, RegisterDto>().ReverseMap();

            CreateMap<User, UpdateUserInformatiobCommand>().ReverseMap();
        }
    }
}
