using CertificatesManager.Common.Models.GenerateCertificates;
using CertificatesManager.Common.Models.GetCertificate;
using CertificatesManager.Common.Models.GetCertificates;

namespace CertificatesManager.Domain.Interfaces.Services;

public interface ICertificateService
{
    Task<GenerateCertificatesResponse> GenerateCertificatesAsync(GenerateCertificatesRequest request, CancellationToken cancellationToken);

    Task<GetCertificateResponse> GetSertificateBySerialNumberAsync(GetCertificateRequest request, CancellationToken cancellationToken);

    Task<GetCertificatesResponse> GetSertificatesAsync(CancellationToken cancellationToken);
}
