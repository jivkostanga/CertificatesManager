using CertificatesManager.Domain.Entities;
using CertificatesManager.Domain.Interfaces;

namespace CertificatesManager.Infrastructure.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly CertificatesManagerDbContext _db;

    public IQueryable<Certificate> Certificates => _db.Certificates;

    public UnitOfWork(CertificatesManagerDbContext db)
    {
        _db = db;
    }

    public void Add(object entity)
    {
        if (entity is IEnumerable<object>)
        {
            _db.AddRange(entity);
        }
        else
        {
            _db.Add(entity);
        }
    }

    public void Remove(object entity)
    {
        if (entity is IEnumerable<object>)
        {
            _db.RemoveRange(entity);
        }
        else
        {
            _db.Remove(entity);
        }
    }

    public void Update(object entity)
    {
        _db.Update(entity);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _db.SaveChangesAsync(cancellationToken);
    }
}
