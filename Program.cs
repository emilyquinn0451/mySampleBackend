
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using mySampleBackend.Clients;
using mySampleBackend.Domain;
using mySampleBackend.Implementations;
using mySampleBackend.Interfaces;
using mySampleBackend.Mapping;
using mySampleBackend.Repositories;
using mySampleBackend.Validation;

namespace mySampleBackend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            //Clients and Services
            builder.Services.AddLogging();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddHttpClient();
            builder.Services.AddSingleton<IFloopClient, FloopClient>();
            builder.Services.AddHttpClient<IFloopClient, FloopClient>();
            builder.Services.AddScoped<IValidator<Floop>, FloopValidator>();
            builder.Services.AddTransient<IDbAccessService, DbAccessService>();
            builder.Services.AddScoped<IFloopService, FloopService>();
            builder.Services.AddAutoMapper(typeof(MappingProfile));

            //Configure Database
            builder.Services.AddDbContext<DbContext>();
            builder.Services.AddTransient<FloopRepository>();



            var app = builder.Build();

            // Configure the HTTP request pipeline.
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
