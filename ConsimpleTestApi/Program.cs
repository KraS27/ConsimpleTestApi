
using ConsimpleTestApi.BL.Product;
using ConsimpleTestApi.BL.Purchase;
using ConsimpleTestApi.BL.User;
using ConsimpleTestApi.DAL;
using ConsimpleTestApi.Models.DTO.User;
using ConsimpleTestApi.Validators.User;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace ConsimpleTestApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var MsSqlConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");


            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(MsSqlConnectionString);
            });

            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<IPurchaseService, PurchaseService>();

            builder.Services.AddTransient<IValidator<CreateUserRequest>, CreateUserRequestValidator>();

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
