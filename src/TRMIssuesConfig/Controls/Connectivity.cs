using System;
using System.Diagnostics;
using System.Windows.Forms;
using TRMIssuesConfig.Resources;

namespace TRMIssuesConfig.Controls
{
    /// <summary>
    /// Provide connectivity Control
    /// </summary>
    public partial class Connectivity : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Connectivity"/> class.
        /// </summary>
        public Connectivity()
        {
            InitializeComponent();

            //Determine which header to show
            if (ProjectInfo.ProjectID == null)
            {
                lblConnectivity.Visible = true;
                rdoGlobalSettings.Visible = false;
                rdoCustomSettings.Visible = false;
            }
            else
            {
                lblConnectivity.Visible = false;
                rdoGlobalSettings.Visible = true;
                rdoCustomSettings.Visible = true;
            }
        }

        private void btnInternetOptions_Click(object sender, EventArgs e)
        {
            Process.Start("control.exe","InetCpl.cpl,,4");
        }

        private void rdoWindowsProxy_CheckedChanged(object sender, EventArgs e)
        {
            pnlManual.Enabled = false;
        }

        private void rdoNoProxy_CheckedChanged(object sender, EventArgs e)
        {
            pnlManual.Enabled = false;
        }

        private void rdoManualProxy_CheckedChanged(object sender, EventArgs e)
        {
            pnlManual.Enabled = true;
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == char.MinValue)
            {
                btnShow.Text = Strings.ShowPassword;
                txtPassword.PasswordChar = Convert.ToChar("*");
            }
            else
            {
                btnShow.Text = Strings.HidePassword;
                txtPassword.PasswordChar = char.MinValue;
            }
            txtPassword.Refresh();
            txtPassword.Focus();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            //Save changes
        }

        private void rdoGlobalSettings_CheckedChanged(object sender, EventArgs e)
        {
            pnlSettings.Enabled = false;
        }

        private void rdoCustomSettings_CheckedChanged(object sender, EventArgs e)
        {
            pnlSettings.Enabled = true;
        }

        private void connectivity_Load(object sender, EventArgs e)
        {
            //Load project specific settings of this project has any
            if (ProjectInfo.ProjectID != null && ProjectInfo.ProjectID != -1)
            {
                //TODO: Load settings from settings manager
            }
            else  //New project
            {
                //Default to global settings
                rdoGlobalSettings.Checked = true;
            }
        }
    }
}
