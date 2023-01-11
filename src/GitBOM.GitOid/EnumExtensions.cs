namespace GitBOM.GitOid;

using System.Security.Cryptography;

public static class EnumExtensions
{
    public static string GetName(this HashAlgorithm hashAlgorithm) => hashAlgorithm switch
    {
        HashAlgorithm.Sha1 => "sha1",
        HashAlgorithm.Sha256 => "sha256",
        _ => throw new ArgumentOutOfRangeException(nameof(hashAlgorithm), hashAlgorithm, null),
    };

    public static string GetName(this ObjectType objectType) => objectType switch
    {
        ObjectType.Blob => "blob",
        ObjectType.Commit => "commit",
        ObjectType.Tag => "tag",
        ObjectType.Tree => "tree",
        _ => throw new ArgumentOutOfRangeException(nameof(objectType), objectType, null),
    };

    public static System.Security.Cryptography.HashAlgorithm GetDigester(this HashAlgorithm hashAlgorithm) =>
        hashAlgorithm switch
        {
            HashAlgorithm.Sha1 => SHA1.Create(),
            HashAlgorithm.Sha256 => SHA256.Create(),
            _ => throw new ArgumentOutOfRangeException(nameof(hashAlgorithm), hashAlgorithm, null),
        };
}
