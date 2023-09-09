using TreeMiner;

namespace TreeBoard
{
    /// <summary>
    /// Represents a file system artifact in a directory tree.
    /// </summary>
    public class FileSystemArtifact : ITreeArtifact
    {
        /// <summary>
        /// Gets or sets the unique identifier of the artifact.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the parent artifact.
        /// </summary>
        public Guid ParentId { get; set; }

        /// <summary>
        /// Gets or sets the level of the artifact in the directory tree.
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        /// Gets or sets additional information associated with the artifact.
        /// </summary>
        public object? Info { get; set; }
    }
}
