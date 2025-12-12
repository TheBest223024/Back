using AutoMapper;
using Library.Application.Mappings;
using Library.Application.Services;
using Library.Domain.Ports.Out;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // AutoMapper: registra tu MappingProfile
        services.AddAutoMapper(typeof(MappingProfile));

        // Servicios de dominio
        services.AddScoped<IBookService, BookService>();
        services.AddScoped<ILoanService, LoanService>();

        return services;
    }
}