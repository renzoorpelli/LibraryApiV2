using StockService.Configuration;
using StockService.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddApplication()
    .AddInfrastructure(builder.Configuration);

var app = builder.Build();

app.UseHttpsRedirection();

//app.UseMiddleware<ValidationExceptionMiddleware>();
app.UseAuthorization();

app.MapControllers();

app.Run();