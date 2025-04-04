﻿
using CarExpo.Domain.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarExpo.Infrastructure.Context
{
    public class DataBaseContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-BO3LEGK\\MSSQLSERVER01;Database=CarExpo;Trusted_Connection=True;TrustServerCertificate=True;", builder =>
                {
                    builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
                });
            }
        }
    }
}





