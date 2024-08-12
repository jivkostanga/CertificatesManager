namespace CertificatesManager.Common.Models.GetCertificates;

public class GetCertificatesResponse
{
    public IEnumerable<GetCertificatesResponseItem> Certificates { get; set; }
}

public class GetCertificatesResponseItem
{
    public string SerialNumber { get; set; }

    public string ServiceName { get; set; }
}
