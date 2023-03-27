using System.Security.Cryptography.X509Certificates;

namespace CoreLibraryImprovements;

public static class CryptographyEnhancements
{
    public static void DemoCertificateNameBuilder()
    {
        var builder = new X500DistinguishedNameBuilder();
        builder.AddCommonName("CertificateSubject");
        builder.AddOrganizationalUnitName("TestUnit");
        builder.AddOrganizationName("Scientific Programmer Ltd.");

        Console.WriteLine($"The certificate name is: {
            builder.Build().Decode(X500DistinguishedNameFlags.None)}");
    }
}