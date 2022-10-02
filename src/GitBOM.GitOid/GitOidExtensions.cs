namespace GitBOM.GitOid;

using System.Collections.Generic;
using System.Security.Cryptography;

public static class GitOidExtensions
{
    private static readonly Dictionary<HashAlgorithm, System.Security.Cryptography.HashAlgorithm> HashAlgorithmMap = new()
    {
        {
            HashAlgorithm.Sha1, SHA1.Create()
        },
        {
            HashAlgorithm.Sha256, SHA256.Create()
        },
    };

    public static System.Security.Cryptography.HashAlgorithm GetDigester(this HashAlgorithm hashAlgorithm) =>
        HashAlgorithmMap[hashAlgorithm];
}
