using CertificatesManager.Domain.Entities;

namespace CertificatesManager.Domain.Interfaces;

public interface IX509CertificateGenerator
{
    Certificate Generate(string subjectName);
}
