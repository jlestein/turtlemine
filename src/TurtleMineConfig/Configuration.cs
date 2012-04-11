using System.Linq;
using System.Windows.Forms;
using TurtleMine.Controls;
using TurtleMine.Resources;
using TurtleMine.Settings;

namespace TurtleMine
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

		#region Navigation

		private void lstOptions_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//If nothing selected just return
			if (lstOptions.SelectedIndices.Count <= 0)
			{
				return;
			}

			//Bring the coresponding control to the front
			var lvi = lstOptions.SelectedItems[0];
			pnlGlobal.Controls[lvi.Tag.ToString()].BringToFront();
		}

		private void lstOptionsProject_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//If nothing selected just return
			if (lstOptionsProject.SelectedIndices.Count <= 0)
			{
				return;
			}

			//Bring the coresponding control to the front
			var lvi = lstOptionsProject.SelectedItems[0];
			pnlProject.Controls[lvi.Tag.ToString()].BringToFront();
		}

		#endregion

		#region Load / Unload

		private void configuration_Load(object sender, System.EventArgs e)
		{
			//Preload controls
			loadControls();
		}


		private void configuration_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason == CloseReason.UserClosing && splitContainer1.Panel1.Controls.GetChildIndex(lstOptionsProject) == 0)
			{
				loadControls();
				e.Cancel = true;
			}
		}

		/// <summary>
		/// Loads the controls.
		/// </summary>
		private void loadControls()
		{
			//only load controls once
			if (pnlGlobal.Controls.Count == 0)
			{
				pnlGlobal.Controls.Add(new Projects());
				lstOptions.Items[0].Tag = "Projects";
				pnlGlobal.Controls.Add(new Connectivity());
				lstOptions.Items[1].Tag = "Connectivity";
				pnlGlobal.Controls.Add(new Words());
				lstOptions.Items[2].Tag = "Words";
				pnlGlobal.Controls.Add(new Columns());
				lstOptions.Items[3].Tag = "Columns";
				pnlGlobal.Controls.Add(new Updates());
				lstOptions.Items[4].Tag = "Updates";
				pnlGlobal.Controls.Add(new ImportExport());
				lstOptions.Items[5].Tag = "ImportExport";
				pnlGlobal.Controls.Add(new About());
				lstOptions.Items[6].Tag = "About";

				//Select the first control (Projects)
				lstOptions.Items[0].Selected = true;
			}

			//Bring global settings to front.
			lstOptions.BringToFront();
			pnlGlobal.BringToFront();

			//Update form name
			Text = Strings.Configuration_loadControls_Configuration_Utility;
		}

		/// <summary>
		/// Loads the controls.
		/// </summary>
		public void LoadControlsProject()
		{
			//Remove existing controls so new project info will be loaded
			pnlProject.Controls.Clear();
			
			//Load controls for project
			pnlProject.Controls.Add(new ProjectDetails());
			lstOptionsProject.Items[0].Tag = "ProjectDetails";
			pnlProject.Controls.Add(new Connectivity());
			lstOptionsProject.Items[1].Tag = "Connectivity";
			pnlProject.Controls.Add(new Words());
			lstOptionsProject.Items[2].Tag = "Words";
			pnlProject.Controls.Add(new Columns());
			lstOptionsProject.Items[3].Tag = "Columns";

			//Select the first control (Project Settings)
			lstOptionsProject.Items[0].Selected = true;

			//Bring project settings to front
			lstOptionsProject.BringToFront();
			pnlProject.BringToFront();

			//Update form name
			Text = Strings.Configuration_LoadControlsProject_Configuration_Utility___Project_Settings;
		}

		#endregion

		#region Apply / Cancel / OK

		private void saveSettings()
		{
			//Apply settings for each template control
			foreach (Template control in pnlGlobal.Controls.OfType<Template>())
			{
				control.ApplyChanges();
			}

			//Save the settings file to disk
			SettingsManager.SaveSettings();
		}

		private void btnApply_Click(object sender, System.EventArgs e)
		{
			saveSettings();

			//Toggle buttons
			btnApply.Enabled = false;
		}

		private void btnOk_Click(object sender, System.EventArgs e)
		{
			saveSettings();

			//exit
			Close();
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			//If on project details tab close and go back to project list.
			if (splitContainer1.Panel1.Controls.GetChildIndex(lstOptionsProject) == 0)
			{
				loadControls();
			}
			else
			{
				Close();
			}
		}

		#endregion
	}
}
