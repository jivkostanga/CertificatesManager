using CertificatesManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CertificatesManager.Infrastructure.Data;

public class CertificatesManagerDbContext : DbContext
{
    public CertificatesManagerDbContext(DbContextOptions<CertificatesManagerDbContext> options)
        : base(options)
    { }

    public DbSet<Certificate> Certificates { get; set; }
}
