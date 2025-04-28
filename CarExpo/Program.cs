using FluentValidation;
using CarExpo.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using CarExpo.Domain.Models.Users;
using Microsoft.AspNetCore.Identity;
using CarExpo.Application.Services.USER_SERVICE;
using CarExpo.Application.Commands.CommandValidator.UserCommandValidator;
using CarExpo.Application.Commands.CommandValidator.VehicleCommandValidator;
using CarExpo.Application.Commands.CommandValidator.PaymentCommandValidator;
using CarExpo.FilterException;
using CarExpo.Infrastructure.Repositories;
using CarExpo.Infrastructure.Repositories.Car_Repository;
using CarExpo.Infrastructure.Repositories.Order_Repository;
using CarExpo.Infrastructure.Repositories.User_Repository;
using CarExpo.Application.Services.Order_Service;
using CarExpo.Application.Interfaces.Car_Interface;
using CarExpo.Application.Interfaces.User_Interface;
using CarExpo.Application.Interfaces.Order_Interface;
using CarExpo.Application.Interfaces.Email_Interface;
using CarExpo.Application.Services.Email_Service;
using CarExpo.Application.Interfaces.Payment_Interface;
using CarExpo.Application.Services.PAYMENT_SERVICE;
using CarExpo.Application.Interfaces.Loyalty_Interface;
using CarExpo.Application.Services.Loyalty_Service;
using CarExpo.Application.Interfaces.IIAnalytics_Service;
using CarExpo.Application.Services.IAnalytics_Service;
using CarExpo.Application.Interfaces.Invoice__Interface;
using CarExpo.Application.Services.Invoice_Service;
using CarExpo.Application.Mappings.UserMapp;
using CarExpo.Application.Mappings.PaymentMap;
using CarExpo.Application.Mappings.OrderMap;
using CarExpo.Application.Mappings.VehicleMapp;
using CarExpo.Domain.Interfaces.IGenericInterface;
using CarExpo.Domain.Interfaces.UnitOfWorkInterface;
using CarExpo.Infrastructure.Authentication;
using CarExpo.Infrastructure.Seeders;
using CarExpo.Application.Services.VehicleService;
using CarExpo.Application.Services.CarImageService;
using Microsoft.OpenApi.Models;
using CarExpo.Application.Services;
using CarExpo.Domain.Interfaces.CarRepositories;
using CarExpo.Domain.Interfaces.OrderRpository;
using CarExpo.Domain.Interfaces.UserRepository;
using CarExpo.Application.Services.UserService;

namespace CarExpo
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // DbContext
            builder.Services.AddDbContext<DataBaseContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("CarExpo")));

            // Identity
            builder.Services.AddIdentity<User, IdentityRole<Guid>>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
            })
            .AddEntityFrameworkStores<DataBaseContext>()
            .AddDefaultTokenProviders();

            builder.Services.AddDataProtection();
            builder.Services.AddHttpContextAccessor();

            // Validators
            builder.Services.AddValidatorsFromAssemblyContaining<RegisterCommandValidator>();
            builder.Services.AddValidatorsFromAssemblyContaining<AddCarCommandValidator>();
            builder.Services.AddValidatorsFromAssemblyContaining<EditCarInfoCommandValidator>();
            builder.Services.AddValidatorsFromAssemblyContaining<PaymentRequestCommandValidator>();

            // AutoMapper
            builder.Services.AddAutoMapper(typeof(UserMapper));
            builder.Services.AddAutoMapper(typeof(VehicleMapper));
            builder.Services.AddAutoMapper(typeof(OrderMapper));
            builder.Services.AddAutoMapper(typeof(PaymentMapper));

            // Jwt
            builder.Services.AddScoped<IJwtService, JwtService>();
            builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));

            // Repositories and Services
            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddSingleton(new MeliPayamakService("USERNAME", "PASSWORD"));

            builder.Services.AddScoped<ICarImageService, CarImageService>();
            builder.Services.AddScoped<ICarImageRepository, CarImageRepository>();

            builder.Services.AddScoped<IVehicleService, VehicleService>();
            builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();

            builder.Services.AddScoped<IuserService, UserService>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IOtpService, OtpService>();
            builder.Services.AddScoped<IUserRoleService, UserRoleService>();

            builder.Services.AddScoped<IOrderService, OrderService>();
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();
            builder.Services.AddScoped<IOrderItemRepository, OrderItemRepository>();

            builder.Services.AddScoped<IEmailNotificationService, EmailNotificationService>();
            builder.Services.AddScoped<IPaymentService, PaymentService>();
            builder.Services.AddScoped<ILoyaltyService, LoyaltyService>();
            builder.Services.AddScoped<IAnalyticsService, AnalyticsService>();
            builder.Services.AddScoped<IInvoiceService, InvoiceService>();

            // Swagger
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "CarExpo", Version = "v1" });

                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Description = "لطفاً 'Bearer YOUR_TOKEN' را وارد کنید",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "JWT"
                };

                options.AddSecurityDefinition("Bearer", securityScheme);
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        }, new string[] { }
                    }
                });
            });

            // Controllers
            builder.Services.AddControllers(options =>
            {
                options.Filters.Add<CustomExceptionFilter>();
            })
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
                options.JsonSerializerOptions.WriteIndented = true;
            });

            var app = builder.Build();

            // Seed Roles and Admin
            using (var scope = app.Services.CreateScope())
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
                await IdentitySeeder.SeedRolesAndAdminAsync(userManager, roleManager);
            }

            // Middleware
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication(); // اضافه شده
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
