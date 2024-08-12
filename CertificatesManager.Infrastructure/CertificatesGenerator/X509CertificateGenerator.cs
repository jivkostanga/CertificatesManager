using CertificatesManager.Domain.Entities;
using CertificatesManager.Domain.Interfaces;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Operators;
using Org.BouncyCastle.Crypto.Prng;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Pkcs;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.X509;
using System.Text;

namespace CertificatesManager.Infrastructure.CertificatesGenerator;

public class X509CertificateGenerator : IX509CertificateGenerator
{
    public record PemCertificate(string cert, string privateKey, string serialNumber);

    public Certificate Generate(string subjectName)
    {
        var randomGenerator = new CryptoApiRandomGenerator();
        var random = new SecureRandom(randomGenerator);
        var serialNumber = BigIntegers.CreateRandomInRange(
            BigInteger.One,
            BigInteger.ValueOf(long.MaxValue), random);
        var subjectDistinguishedName = new X509Name(subjectName);
        var issuerDistinguishedName = subjectDistinguishedName;
        var notBefore = DateTime.UtcNow.Date;
        var notAfter = notBefore.AddYears(1);
        var keyGenerationParameters = new KeyGenerationParameters(random, 2048);
        var keyPairGenerator = new RsaKeyPairGenerator();
        keyPairGenerator.Init(keyGenerationParameters);
        var subjectKeyPair = keyPairGenerator.GenerateKeyPair();
        var issuerPrivateKey = subjectKeyPair.Private;

        var certificateGenerator = new X509V3CertificateGenerator();
        certificateGenerator.SetSerialNumber(serialNumber);
        certificateGenerator.AddExtension(
            X509Extensions.ExtendedKeyUsage,
            true,
            new ExtendedKeyUsage(KeyPurposeID.id_kp_serverAuth));
        certificateGenerator.SetIssuerDN(issuerDistinguishedName);
        certificateGenerator.SetSubjectDN(subjectDistinguishedName);
        certificateGenerator.SetNotBefore(notBefore);
        certificateGenerator.SetNotAfter(notAfter);
        certificateGenerator.SetPublicKey(subjectKeyPair.Public);

        var signatureFactory = new Asn1SignatureFactory("SHA512WITHRSA", issuerPrivateKey, random);
        var certificate = certificateGenerator.Generate(signatureFactory);
        var privateKeyInfo = PrivateKeyInfoFactory.CreatePrivateKeyInfo(subjectKeyPair.Private);

        var builder = new StringBuilder();
        using var writer = new StringWriter(builder);
        using var pemWriter = new PemWriter(writer);

        pemWriter.WriteObject(certificate);
        var cert = builder.ToString();
        builder.Clear();

        pemWriter.WriteObject(privateKeyInfo);
        var privateKey = builder.ToString();

        return new Certificate(privateKey, cert, serialNumber.ToString());
    }
}
