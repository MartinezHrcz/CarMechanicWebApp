using MechanicAPI.DB;
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
                options.UseSqlite(builder.Configuration.GetConnectionString("SQLLiteConnection"));
                options.UseLazyLoadingProxies();
            });
        
        builder.Services.AddSerilog(
            options => options
                .MinimumLevel.Information()
                .WriteTo.Console());
        
        //Singleton
        
        //build
        
        //if is development use swagger and ui
        
        //app. usehttpsRedirection
        // ap.MapControllers
        //app.run
        
    }
}
