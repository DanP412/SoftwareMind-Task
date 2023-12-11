using Microsoft.EntityFrameworkCore;
using NegotiationApp.Data.Entities.Configuration;
using NegotiationApp.Services.NegotiationService;
using NegotiationApp.Services.ProductService;
using NegotiationApp.Services.Validation.NegotiationValidationService;
using NegotiationApp.Services.Validation.Product;

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IProductValidationService, ProductValidationService>();
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<INegotiationService, NegotiationService>();
            builder.Services.AddScoped<INegotiationValidationService, NegotiationValidationService>();
            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
            });

            builder.Services.AddDbContext<NegotiaionAppDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("NegotiaionAppDbContext"));
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