﻿using AutoMapper;
using CarExpo.Application.Commands.Command.UserCommand;
using CarExpo.Application.Dto.UserDto;
using CarExpo.Domain.Models.Users;

namespace CarExpo.Application.Mappings.UserMapp
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
