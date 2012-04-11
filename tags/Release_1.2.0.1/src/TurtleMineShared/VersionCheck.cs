using System;
using System.Reflection;
using TurtleMine.Resources;

namespace TurtleMine
{
    /// <summary>
    /// Check and compare version numbers
    /// </summary>
    internal class VersionCheck
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="VersionCheck"/> class.
        /// </summary>
        public VersionCheck()
        {
            const string versionUrl = "http://turtlemine.googlecode.com/svn/trunk/Version/Version.xml";
            
            try
            {
                // Create an XmlReader to get the latest version number and file name
                using (var reader = ConnectionHelper.CreateXmlReader(versionUrl, ConnectionHelper.GetDefaultProxy()))
                {
                    reader.ReadToFollowing("LatestVersion");
                    LatestVersion = new Version(reader.ReadElementContentAsString());
                    switch (IntPtr.Size)
                    {
                        case 8:
                            reader.ReadToFollowing("DownloadFilename64");
                            break;
                        case 4:
                            reader.ReadToFollowing("DownloadFilename");
                            break;
                    } 
                    
                    LatestVersionFileName = reader.ReadElementContentAsString();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format(Strings.ErrorInUpdatesConnectionMessage, Environment.NewLine + ex.Message), ex);
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the latest version.
        /// </summary>
        /// <value>The latest version.</value>
        public Version LatestVersion { get; private set; }

        /// <summary>
        /// Gets the name of the latest version file.
        /// </summary>
        /// <value>The name of the latest version file.</value>
        public string LatestVersionFileName { get; private set; }

        #endregion

        #region Static Properties / Methods

        /// <summary>
        /// Gets the current version.
        /// </summary>
        /// <value>The current version.</value>
        public static Version CurrentVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version;
            }
        }
        
        /// <summary>
        /// Determines whether [a new version is available].
        /// </summary>
        /// <returns>
        /// 	<c>true</c> if [a new version is available]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNewVersionAvailable()
        {
            var check = new VersionCheck();

            return check.LatestVersion > CurrentVersion;
        }

        #endregion
    }
}
