using System.ComponentModel;

namespace GitBOM.GitOid;

public enum HashAlgorithm
{
    /// <summary>
    /// <a href="https://en.wikipedia.org/wiki/SHA-1">SHA1</a>
    /// </summary>
    [Description("sha1")]
    Sha1,

    /// <summary>
    /// <a href="https://en.wikipedia.org/wiki/SHA-2">SHA256</a>
    /// </summary>
    [Description("sha256")]
    Sha256,
}
