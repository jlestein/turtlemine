using System.Diagnostics;
using System.Windows.Forms;

namespace TurtleMine.Controls
{
    /// <summary>
    /// About this application
    /// </summary>
    public partial class About : Template
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="About"/> class.
        /// </summary>
        public About()
        {
            InitializeComponent();
        }

        private void About_Load(object sender, System.EventArgs e)
        {
            //Current Version
            lblCurrentVersionNumber.Text = VersionCheck.CurrentVersion.ToString();
        }

        private void lnkWebsite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(((LinkLabel)sender).Text);
        }
    }
}
