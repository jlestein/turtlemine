using System.Windows.Forms;
using TRMIssuesConfig.Resources;

namespace TRMIssuesConfig
{
    /// <summary>
    /// Configuration UI Main form
    /// </summary>
    public partial class Configuration : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Configuration"/> class.
        /// </summary>
        public Configuration()
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
            var lvi = lstOptions.SelectedItems[0];
            if (lvi.Text == Strings.ImportExport)
            {
                splitContainer1.Panel2.Controls["ImportExport"].BringToFront();
            }
            else
            {
                splitContainer1.Panel2.Controls[lvi.Text].BringToFront();
            }
        }

        private void configuration_Load(object sender, System.EventArgs e)
        {
            //Preload controls
            loadControls();

            //Select the first control (Projects)
            lstOptions.Items[0].Selected = true;
        }

        /// <summary>
        /// Loads the controls.
        /// </summary>
        private void loadControls()
        {
            splitContainer1.Panel2.Controls.Add(new Controls.Projects());
            splitContainer1.Panel2.Controls.Add(new Controls.Connectivity());
            splitContainer1.Panel2.Controls.Add(new Controls.Words());
            splitContainer1.Panel2.Controls.Add(new Controls.Columns());
            splitContainer1.Panel2.Controls.Add(new Controls.Updates());
            splitContainer1.Panel2.Controls.Add(new Controls.ImportExport());
            splitContainer1.Panel2.Controls.Add(new Controls.About());
        }
    }
}
