namespace OmniBOR.GitOid;

/// <summary>
/// The types of objects for which a <see cref="GitOid"/> can be made.
/// </summary>
public enum ObjectType
{
    /// <summary>
    /// An opaque git blob.
    /// </summary>
    Blob,

    /// <summary>
    /// A Git tree.
    /// </summary>
    Tree,

    /// <summary>
    /// A Git commit.
    /// </summary>
    Commit,

    /// <summary>
    /// A Git tag.
    /// </summary>
    Tag,
}
