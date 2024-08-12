using CertificatesManager.Application.Services;
using CertificatesManager.Domain.Interfaces;
using CertificatesManager.Domain.Interfaces.Services;
using CertificatesManager.Infrastructure.CertificatesGenerator;
using CertificatesManager.Infrastructure.Data;

namespace CertificatesManager.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddDependencyInjection(
         this IServiceCollection services)
    {
        services.AddScoped<IX509CertificateGenerator, X509CertificateGenerator>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ICertificateService, CertificateService>();

        return services;
    }
}
