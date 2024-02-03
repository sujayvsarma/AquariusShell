namespace AquariusShell.Objects
{
    /// <summary>
    /// An item in the recycle bin
    /// </summary>
    /// <param name="FileName">Name of the file</param>
    /// <param name="OriginalPath">Original path of the file or folder</param>
    /// <param name="DeletedAt">Date/time deleted at (pre-formatted string!)</param>
    /// <param name="Size">Size of file</param>
    /// <param name="FileType">Type of file</param>
    /// <param name="FullyQualifiedRecyclebinPath">Fully qualified path within the recycle bin</param>
    public record RecyclebinItem(
            string FileName,
            string OriginalPath,
            string DeletedAt,
            string Size,
            string FileType,
            string FullyQualifiedRecyclebinPath
        );
}
