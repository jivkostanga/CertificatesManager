using CertificatesManager.Domain.Entities;

namespace CertificatesManager.Domain.Interfaces;

public interface IUnitOfWork
{
    IQueryable<Certificate> Certificates { get; }

    void Add(object entity);

    void Remove(object entity);

    void Update(object entity);

    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}
