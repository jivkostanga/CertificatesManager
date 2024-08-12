using System.ComponentModel.DataAnnotations;

namespace CertificatesManager.Common.Models.GetCertificate;

public class GetCertificateRequest
{
    [Required]
    public string SerialNumber { get; set; }

    [Required]
    public string ServiceName { get; set; }
}
