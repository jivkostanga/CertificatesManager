using CertificatesManager.Common.Models.GenerateCertificates;
using CertificatesManager.Common.Models.GetCertificate;
using CertificatesManager.Common.Models.GetCertificates;
using CertificatesManager.Domain.Interfaces;
using CertificatesManager.Domain.Interfaces.Services;

namespace CertificatesManager.Application.Services;

public class CertificateService : ICertificateService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IX509CertificateGenerator _certGen;

    public CertificateService(IUnitOfWork unitOfWork, IX509CertificateGenerator certGen)
    {
        _unitOfWork = unitOfWork;
        _certGen = certGen;
    }

    public async Task<GenerateCertificatesResponse> GenerateCertificatesAsync(
        GenerateCertificatesRequest request, CancellationToken cancellationToken)
    {
        var serialNumbers = new List<string>();

        for (int i = 0; i < request.Count; i++)
        {
            var certificate = _certGen.Generate("cn=Test");
            serialNumbers.Add(certificate.SerialNumber);
            _unitOfWork.Add(certificate);
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return new GenerateCertificatesResponse { SerialNumbers = serialNumbers };
    }

    public async Task<GetCertificateResponse> GetSertificateBySerialNumberAsync(
        GetCertificateRequest request, CancellationToken cancellationToken)
    {
        var cert = _unitOfWork.Certificates.FirstOrDefault(c => c.SerialNumber == request.SerialNumber);

        if (cert == null || !string.IsNullOrEmpty(cert.UsedByService))
        {
            return null;
        }

        var response = new GetCertificateResponse
        {
            PrivateKey = cert.PrivateKey,
            PublicKey = cert.PublicKey,
        };

        cert.UsedByService = request.ServiceName;
        _unitOfWork.Update(cert);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return response;
    }

    public async Task<GetCertificatesResponse> GetSertificatesAsync(CancellationToken cancellationToken)
    {
        var certificates = _unitOfWork.Certificates
            .Where(x => !string.IsNullOrEmpty(x.UsedByService))
            .Select(x => new GetCertificatesResponseItem
            {
                SerialNumber = x.SerialNumber,
                ServiceName = x.UsedByService,
            });
        return new GetCertificatesResponse
        {
            Certificates = certificates
        };
    }
}
