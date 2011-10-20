using System.Windows.Forms;

namespace TRMIssuesConfig.Controls
{
    /// <summary>
    /// List of Projects
    /// </summary>
    public partial class Projects : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Projects"/> class.
        /// </summary>
        public Projects()
        {
            InitializeComponent();
        }

        private void btnNewProject_Click(object sender, System.EventArgs e)
        {
            //Indicate new project
            ProjectInfo.ProjectID = -1;

            //Load project Settings page
            var projConfig = new ProjectConfig();
            projConfig.ShowDialog(this);
        }
    }
}
