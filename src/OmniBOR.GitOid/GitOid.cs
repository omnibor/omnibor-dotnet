namespace OmniBOR.GitOid;

using System.Text;

public sealed record GitOid
{
    private GitOid(HashAlgorithm hashAlgorithm, ObjectType objectType, byte[] value)
    {
        this.HashAlgorithm = hashAlgorithm;
        this.ObjectType = objectType;
        this.Value = value;
    }

    public HashAlgorithm HashAlgorithm { get; }

    public ObjectType ObjectType { get; }

    public byte[] Value { get; }

    public string Hash() => Convert.ToHexString(this.Value).ToLowerInvariant();

    public override string ToString() => $"{this.HashAlgorithm}:{this.Hash()}";

    public Uri Uri() => new($"gitoid:{this.ObjectType.GetName()}:{this.HashAlgorithm.GetName()}:{this.Hash()}");

    public static GitOid CreateFromBytes(HashAlgorithm hashAlgorithm, ObjectType objectType, byte[] content)
    {
        if (content == null)
        {
            throw new ArgumentNullException(nameof(content));
        }

        using var digester = hashAlgorithm.GetDigester();
        var prefix = $"{objectType.GetName()} {content.Length}\0";
        var value = digester.ComputeHash(Encoding.ASCII.GetBytes(prefix).Concat(content).ToArray());

        return new GitOid(hashAlgorithm, objectType, value);
    }

    public static async Task<GitOid> CreateFromBytesAsync(
        HashAlgorithm hashAlgorithm,
        ObjectType objectType,
        Stream content,
        CancellationToken cancellationToken = default)
    {
        if (content == null)
        {
            throw new ArgumentNullException(nameof(content));
        }

        using var digester = hashAlgorithm.GetDigester();
        var prefix = $"{objectType.GetName()} {content.Length}\0";
        await using var stream = new MemoryStream();
        await stream.WriteAsync(Encoding.ASCII.GetBytes(prefix), cancellationToken).ConfigureAwait(false);
        await content.CopyToAsync(stream, cancellationToken).ConfigureAwait(false);
        stream.Seek(0, SeekOrigin.Begin);
        var value = await digester.ComputeHashAsync(stream, cancellationToken).ConfigureAwait(false);

        return new GitOid(hashAlgorithm, objectType, value);
    }
}
