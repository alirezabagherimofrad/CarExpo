using AutoMapper;
using CarExpo.Application.Commands.Command;
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
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<User, RegisterCommand>().ReverseMap();

            CreateMap<RegisterCommand, RegisterDto>().ReverseMap();


        }
    }
}
