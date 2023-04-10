using System.Reflection;
using FluentValidation;
using MediatR;
using StockService.Infrastructure.Data;
using StockService.Infrastructure.Data.Repositories;
using StockService.Infrastructure.Data.Repositories.Generic;
using StockService.Infrastructure.Data.UnitOfWork;
using StockService.Services.Book;

namespace StockService.Configuration;

public static class DependencyInjection
{
    /// <summary>
    /// adding infrastructure services of infrastructure layer, like SqlServer, Mail, Message Bus, etc.
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    /// <returns></returns>
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        string connstring = configuration["ConnectionStrings:StockDbConn"]!;
        
        services.AddSqlServer<ApplicationDbContext>(connstring);

        services.AddScoped<ISqlConnectionFactory, SqlConnectionFactory>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IRepository, BookRepository>();


        return services;
    }

    /// <summary>
    /// adding ther services of application layer, like MediatR, bussines logic, validation etc
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<Program>();

        services.AddAutoMapper(typeof(Program).Assembly);

        services.AddMediatR(typeof(Program).Assembly);

        services.AddScoped<IBookService, BookService>();   
        
        return services;
    }
}