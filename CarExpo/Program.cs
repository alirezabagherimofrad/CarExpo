using FluentValidation;
using CarExpo.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using CarExpo.Infrastructure.Repositories;
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
using CarExpo.Domain.Interfaces.CarRepositories;
using CarExpo.Domain.Interfaces.UserRepository;
using CarExpo.Domain.Interfaces.OrderRpository;
using CarExpo.Infrastructure.Repositories.Car_Repository;
using CarExpo.Infrastructure.Repositories.Order_Repository;
using CarExpo.Infrastructure.Repositories.User_Repository;
using CarExpo.Application.Interfaces.Car_Interface;
using CarExpo.Application.Interfaces.User_Interface;
using CarExpo.Application.Interfaces.Order_Interface;
using CarExpo.Application.Interfaces.Email_Interface;
using CarExpo.Application.Services.Email_Service;
using CarExpo.Application.Interfaces.Payment_Interface;
using CarExpo.Application.Services.PAYMENT_SERVICE;
using CarExpo.Application.Commands.CommandValidator.PaymentCommandValidator;
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
            builder.Services.AddValidatorsFromAssemblyContaining<PaymentRequestCommandValidator>();

            builder.Services.AddAutoMapper(typeof(UserMapper));
            builder.Services.AddAutoMapper(typeof(VehicleMapper));
            builder.Services.AddAutoMapper(typeof(OrderMapper));
            builder.Services.AddAutoMapper(typeof(PaymentMapper));

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

            builder.Services.AddScoped<IOrderItemRepository, OrderItemRepository>();

            builder.Services.AddScoped<IEmailNotificationService, EmailNotificationService>();

            builder.Services.AddScoped<IPaymentService, PaymentService>();

            builder.Services.AddScoped<ILoyaltyService, LoyaltyService>();

            builder.Services.AddScoped<IIAnalyticsService, IAnalyticsService>();

            builder.Services.AddScoped<IInvoiceService, InvoiceService>();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            using var scope = app.Services.CreateScope();

            var services = scope.ServiceProvider;

            var dbcontext = services.GetRequiredService<DataBaseContext>();

            dbcontext.Database.EnsureCreated();

            dbcontext.Database.Migrate();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
