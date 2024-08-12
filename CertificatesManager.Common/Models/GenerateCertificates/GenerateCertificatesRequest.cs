using System.ComponentModel.DataAnnotations;

namespace CertificatesManager.Common.Models.GenerateCertificates;

public class GenerateCertificatesRequest
{
    [Range(1, 20)]
    public int Count { get; set; }
}
