namespace OmniBOR.GitOid.Benchmark.Benchmarks;

using BenchmarkDotNet.Attributes;

[MemoryDiagnoser]
public class GitOid
{
    private static readonly byte[] DataBytes = "hello World"u8.ToArray();
    private static readonly Stream DataStream = new MemoryStream(DataBytes);

    [Benchmark]
    public string Sha1GitOidFromBytes() => OmniBOR.GitOid.GitOid
        .CreateFromBytes(HashAlgorithm.Sha1, ObjectType.Blob, DataBytes).ToString();

    [Benchmark]
    public async Task<string> Sha1GitOidFromBytesAsync() => (await OmniBOR.GitOid.GitOid
        .CreateFromBytesAsync(HashAlgorithm.Sha1, ObjectType.Blob, DataStream).ConfigureAwait(false)).ToString();

    [Benchmark]
    public string Sha256GitOidFromBytes() => OmniBOR.GitOid.GitOid
        .CreateFromBytes(HashAlgorithm.Sha256, ObjectType.Blob, DataBytes).ToString();

    [Benchmark]
    public async Task<string> Sha256GitOidFromBytesAsync() => (await OmniBOR.GitOid.GitOid
        .CreateFromBytesAsync(HashAlgorithm.Sha256, ObjectType.Blob, DataStream).ConfigureAwait(false)).ToString();
}
