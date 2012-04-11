namespace TurtleMine
{
    /// <summary>
    /// Information about the current project being configured.
    /// </summary>
    internal static class ProjectInfo
    {
        /// <summary>
        /// Gets or sets the project ID.
        /// </summary>
        /// <value>The project ID.</value>
        public static int? ProjectID { get; set; }

        /// <summary>
        /// Determines whether this instance is empty.
        /// </summary>
        /// <returns>
        /// 	<c>true</c> if this instance is empty; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsEmpty()
        {
            return ProjectID == null || ProjectID == -1;
        }

        /// <summary>
        /// Determines whether this instance is <c>null</c>.
        /// </summary>
        /// <returns>
        /// 	<c>true</c> if this instance is <c>null</c>; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNull()
        {
            return ProjectID == null;
        }
    }
}
