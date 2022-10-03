namespace GitBOM.GitOid.Benchmark.Benchmarks;

using System.Text;
using BenchmarkDotNet.Attributes;

[MemoryDiagnoser]
public class GitOid
{
    private static readonly byte[] DataBytes = Encoding.ASCII.GetBytes("hello World");
    private static readonly Stream DataStream = new MemoryStream(DataBytes);

    [Benchmark]
    public string Sha1GitOidFromBytes() => GitBOM.GitOid.GitOid
        .CreateFromBytes(HashAlgorithm.Sha1, ObjectType.Blob, DataBytes).ToString();

    [Benchmark]
    public async Task<string> Sha1GitOidFromBytesAsync() => (await GitBOM.GitOid.GitOid
        .CreateFromBytesAsync(HashAlgorithm.Sha1, ObjectType.Blob, DataStream).ConfigureAwait(false)).ToString();

    [Benchmark]
    public string Sha256GitOidFromBytes() => GitBOM.GitOid.GitOid
        .CreateFromBytes(HashAlgorithm.Sha256, ObjectType.Blob, DataBytes).ToString();

    [Benchmark]
    public async Task<string> Sha256GitOidFromBytesAsync() => (await GitBOM.GitOid.GitOid
        .CreateFromBytesAsync(HashAlgorithm.Sha256, ObjectType.Blob, DataStream).ConfigureAwait(false)).ToString();
}
