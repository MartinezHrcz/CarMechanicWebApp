using MechanicAPI.DB;
using MechanicAPI.Interfaces;
using MechanicAPI.Services;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace MechanicAPI;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        builder.Services.AddControllers();

        builder.Services.AddSwaggerGen();

        builder.Services.AddDbContext<MechanicDataContext>(
            options =>
            {
                options.UseSqlite(builder.Configuration.GetConnectionString("SQLite"));
                //options.UseLazyLoadingProxies();
            });
        
        builder.Services.AddSerilog(
            options => options
                .MinimumLevel.Information()
                .WriteTo.Console());

        builder.Services.AddScoped<IClientService, ClientService>();
        builder.Services.AddScoped<IWorkService, WorkService>();
        
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowBlazorApp", policy =>
            {
                policy.WithOrigins("http://localhost:5252") // <-- Your Blazor WebAssembly URL
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
        });

        var app = builder.Build();
        
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseCors("AllowBlazorApp");
        app.UseHttpsRedirection();
        
        app.MapControllers();
        
        app.Run();

    }
}
