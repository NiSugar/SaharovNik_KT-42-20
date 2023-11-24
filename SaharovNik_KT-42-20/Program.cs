using NLog.Web;
using NLog;
using SaharovNik_KT_42_20.Database;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
try
{
    builder.Logging.ClearProviders();
    builder.Host.UseNLog();
    // Add services to the container.
    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddDbContext<StudentDbContext>(options =>
        options.UseSqlServer(
                builder.Configuration.GetConnectionString("DefaultConnection")
            )
    );
    /*builder.Services.AddDbContext<ApplicationDbContext>(
options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
    ));*/
    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}
catch (Exception ex)
{
    logger.Error("Stoped programm because from eception");
}
finally
{
    LogManager.Shutdown();
}