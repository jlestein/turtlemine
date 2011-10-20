using System.Windows.Forms;

namespace TRMIssuesConfig
{
    /// <summary>
    /// Configure settings for a project
    /// </summary>
    public partial class ProjectConfig : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectConfig"/> class.
        /// </summary>
        public ProjectConfig()
        {
            InitializeComponent();
        }

        private void lstOptions_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            //If nothing selected just return
            if (lstOptions.SelectedIndices.Count <= 0)
            {
                return;
            }

            //Bring the coresponding control to the front
            splitContainer1.Panel2.Controls[lstOptions.SelectedItems[0].Text.Replace(" ", string.Empty)].BringToFront();
        }

        private void projectSettings_Load(object sender, System.EventArgs e)
        {
            //Preload controls
            loadControls();

            //Select the first control (Project Settings)
            lstOptions.Items[0].Selected = true;
        }

        /// <summary>
        /// Loads the controls.
        /// </summary>
        private void loadControls()
        {
            splitContainer1.Panel2.Controls.Add(new Controls.ProjectDetails());
            splitContainer1.Panel2.Controls.Add(new Controls.Connectivity());
            splitContainer1.Panel2.Controls.Add(new Controls.Words());
            splitContainer1.Panel2.Controls.Add(new Controls.Columns());
        }
    }
}
