namespace GitBOM.GitOid.Tests;

using System.Text;
using FluentAssertions;

public class GitOidTest
{
    [Fact]
    public void GenerateSha1GitOidFromBytes()
    {
        var input = Encoding.ASCII.GetBytes("hello world");
        var result = GitOid.CreateFromBytes(HashAlgorithm.Sha1, ObjectType.Blob, input);

        result.Hash().Should().Be("95d09f2b10159347eece71399a7e2e907ea3df4f");
        result.Uri().ToString().Should().Be("gitoid:blob:sha1:95d09f2b10159347eece71399a7e2e907ea3df4f");
    }

    [Fact]
    public async Task GenerateSha1GitOidFromBytesAsync()
    {
        await using var input = new MemoryStream(Encoding.ASCII.GetBytes("hello world"));
        var result = await GitOid.CreateFromBytesAsync(HashAlgorithm.Sha1, ObjectType.Blob, input).ConfigureAwait(false);

        result.Hash().Should().Be("95d09f2b10159347eece71399a7e2e907ea3df4f");
        result.Uri().ToString().Should().Be("gitoid:blob:sha1:95d09f2b10159347eece71399a7e2e907ea3df4f");
    }

    [Fact]
    public void GenerateSha256GitOidFromBytes()
    {
        var input = Encoding.ASCII.GetBytes("hello world");
        var result = GitOid.CreateFromBytes(HashAlgorithm.Sha256, ObjectType.Blob, input);

        result.Hash().Should().Be("fee53a18d32820613c0527aa79be5cb30173c823a9b448fa4817767cc84c6f03");
        result.Uri().ToString().Should().Be("gitoid:blob:sha256:fee53a18d32820613c0527aa79be5cb30173c823a9b448fa4817767cc84c6f03");
    }

    [Fact]
    public async Task GenerateSha256GitOidFromBytesAsync()
    {
        await using var input = new MemoryStream(Encoding.ASCII.GetBytes("hello world"));
        var result = await GitOid.CreateFromBytesAsync(HashAlgorithm.Sha256, ObjectType.Blob, input).ConfigureAwait(false);

        result.Hash().Should().Be("fee53a18d32820613c0527aa79be5cb30173c823a9b448fa4817767cc84c6f03");
        result.Uri().ToString().Should().Be("gitoid:blob:sha256:fee53a18d32820613c0527aa79be5cb30173c823a9b448fa4817767cc84c6f03");
    }
}
