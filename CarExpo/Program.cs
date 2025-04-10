using FluentValidation;
using CarExpo.Application.Interfaces;
using CarExpo.Application.Mappings;
using CarExpo.Infrastructure;
using CarExpo.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using CarExpo.Infrastructure.Repositories;
using CarExpo.Domain.Interfaces;
using CarExpo.Domain.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using CarExpo.Application.Services.USER_SERVICE;
using CarExpo.Application.Services.VEHICLE_SERVICE;
using CarExpo.Application.Commands.CommandValidator.UserCommandValidator;
using CarExpo.Application.Commands.CommandValidator.VehicleCommandValidator;
using CarExpo.FilterException;
using Microsoft.AspNetCore.Mvc.Filters;
using CarExpo.Application.Services.Order_Service;


namespace CarExpo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<DataBaseContext>(option =>
              option.UseSqlServer(builder.Configuration.GetConnectionString("CarExpo")));


            builder.Services.AddValidatorsFromAssemblyContaining<RegisterCommandValidator>();
            builder.Services.AddValidatorsFromAssemblyContaining<AddCarCommandValidator>();
            builder.Services.AddValidatorsFromAssemblyContaining<EditCarInfoCommandValidator>();

            builder.Services.AddAutoMapper(typeof(UserMapper));
            builder.Services.AddAutoMapper(typeof(VehicleMapper));
            builder.Services.AddAutoMapper(typeof(OrderMapper));

            builder.Services.AddIdentityCore<User>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
            })
           .AddEntityFrameworkStores<DataBaseContext>()
           .AddDefaultTokenProviders();
            builder.Services.AddScoped<UserManager<User>>();
            builder.Services.AddScoped<IUserStore<User>, UserStore<User, IdentityRole<Guid>, DataBaseContext, Guid>>();
            builder.Services.AddScoped<SignInManager<User>>();
            builder.Services.AddDataProtection();
            builder.Services.AddHttpContextAccessor();


            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            builder.Services.AddScoped<ICarImageService, CarImageService>();
            builder.Services.AddScoped<ICarImageRepository, CarImageRepository>();

            builder.Services.AddScoped<IVehicleService, VehicleService>();
            builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();

            builder.Services.AddScoped<IuserService, UserService>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IOtpService, OtpService>();

            builder.Services.AddScoped<IOrderService, OrderService>();
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddControllers(Options =>
            {
                Options.Filters.Add<CustomExceptionFilter>();
            });


            var app = builder.Build();



            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
