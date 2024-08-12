namespace CertificatesManager.Domain.Entities;

public class Certificate : BaseModel
{
    public string PrivateKey { get; set; }

    public string PublicKey { get; set; }

    public string SerialNumber { get; set; }

    public string? UsedByService { get; set; }

    public Certificate(string privateKey, string publicKey, string serialNumber)
    {
        PrivateKey = privateKey;
        PublicKey = publicKey;
        SerialNumber = serialNumber;
    }
}
