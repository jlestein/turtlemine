using System.Windows.Forms;

namespace TurtleMine.Controls
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

        /// <summary>
        /// Handles the Click event of the btnNewProject control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnNewProject_Click(object sender, System.EventArgs e)
        {
            //Indicate new project
            ProjectInfo.ProjectID = -1;
            
            //Load project Settings page
            if (ParentForm != null)
            {
                ((Configuration)ParentForm).LoadControlsProject();
            }
        }
    }
}
