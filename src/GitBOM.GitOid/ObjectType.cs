using System.ComponentModel;

namespace GitBOM.GitOid;

/// <summary>
/// The types of objects for which a <see cref="GitOid"/> can be made.
/// </summary>
public enum ObjectType
{
    /// <summary>
    /// An opaque git blob.
    /// </summary>
    [Description("blob")]
    Blob,

    /// <summary>
    /// A Git tree.
    /// </summary>
    [Description("tree")]
    Tree,

    /// <summary>
    /// A Git commit.
    /// </summary>
    [Description("commit")]
    Commit,

    /// <summary>
    /// A Git tag.
    /// </summary>
    [Description("tag")]
    Tag,
}
