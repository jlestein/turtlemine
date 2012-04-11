using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace TurtleMine
{
    /// <summary>
    /// Display a notice form with Version information
    /// </summary>
    public partial class VersionNotice : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VersionNotice"/> class.
        /// </summary>
        public VersionNotice()
        {
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;
            InitializeComponent();
        }

        private void versionNotice_Load(object sender, EventArgs e)
        {
            //Current Version
            lblCurrentVersionNumber.Text = VersionCheck.CurrentVersion.ToString();

            //Latest Version
            const string downloadUrl = "http://turtlemine.googlecode.com/files/";
            const string changesUrl = "http://code.google.com/p/redmine-projects/issues/list?can=1&q=label%3AMilestone-ReleaseXXXX&colspec=ID+Type+Status+Priority+Milestone+Owner+Summary&cells=tiles";

            var latestVersion = new VersionCheck();
            lnkLatestVersion.Text = latestVersion.LatestVersion.ToString();
            lnkLatestVersion.Tag = downloadUrl + latestVersion.LatestVersionFileName;
            lnkChangeList.Tag = changesUrl.Replace("XXXX", lnkLatestVersion.Text);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lnkLatestVersion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(lnkLatestVersion.Tag.ToString());
        }

        private void lnkChangeList_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(lnkChangeList.Tag.ToString());
        }
    }
}
