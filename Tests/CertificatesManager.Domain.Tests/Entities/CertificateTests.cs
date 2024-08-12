using CertificatesManager.Domain.Entities;

namespace CertificatesManager.Domain.Tests.Entities;

public class CertificateTests
{
    [Fact]
    public void CreateCertificatePrivateKey()
    {
        var certificate = new Certificate("privateKey", "publicKey", "12345");

        Assert.Equal("privateKey", certificate.PrivateKey);
    }

    [Fact]
    public void CreateCertificatePublicKey()
    {
        var certificate = new Certificate("privateKey", "publicKey", "12345");

        Assert.Equal("publicKey", certificate.PublicKey);
    }

    [Fact]
    public void CreateCertificateSerialNumber()
    {
        var certificate = new Certificate("privateKey", "publicKey", "12345");

        Assert.Equal("12345", certificate.SerialNumber);
    }
}