using System;
using System.Reflection;
using System.Windows.Forms;

namespace TRMIssues
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
            const string versionUrl = "http://redmine-projects.googlecode.com/svn/trunk/TSVNRM/TSVNRMVersion.xml";

            try
            {
                // Create an XmlReader to get the latest version number and file name
                using (var reader = ConnectionHelper.CreateXmlReader(versionUrl))
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
                MessageBox.Show(String.Format(Resources.ClassesResources.ErrorInUpdatesConnectionMessage, Environment.NewLine + ex.Message), Resources.ClassesResources.ErrorInUpdatesConnectionTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
