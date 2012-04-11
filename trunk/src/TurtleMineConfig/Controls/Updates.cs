using System;
using System.Diagnostics;
using System.Windows.Forms;
using TurtleMine.Settings;

namespace TurtleMine.Controls
{
	/// <summary>
	/// Check for Updates
	/// </summary>
	public partial class Updates : Template
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Updates"/> class.
		/// </summary>
		public Updates()
		{
			InitializeComponent();
		}

		private void updates_Load(object sender, EventArgs e)
		{
			//Current Version
			lblCurrentVersionNumber.Text = VersionCheck.CurrentVersion.ToString();

			//Latest Version
			grpLatestVersion.Visible = false;

			//Get saved settings
			getSettings();
		}

		private void lnkLatestVersion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start(lnkLatestVersion.Tag.ToString());
		}

		private void lnkChangeList_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start(lnkChangeList.Tag.ToString());
		}

		private void btnCheckForUpdates_Click(object sender, EventArgs e)
		{
			//Latest Version
			const string downloadUrl = "http://redmine-projects.googlecode.com/files/";
			const string changesUrl = "http://code.google.com/p/redmine-projects/issues/list?can=1&q=label%3AMilestone-ReleaseXXXX&colspec=ID+Type+Status+Priority+Milestone+Owner+Summary&cells=tiles";

			try
			{
				var latestVersion = new VersionCheck();
				lnkLatestVersion.Text = latestVersion.LatestVersion.ToString();
				lnkLatestVersion.Tag = downloadUrl + latestVersion.LatestVersionFileName;
				lnkChangeList.Tag = changesUrl.Replace("XXXX", lnkLatestVersion.Text);
				lnkLatestVersion.Visible = true;
				lnkChangeList.Visible = true;
			}
			catch (Exception ex)
			{
				txtCheckFailed.Text = ex.Message;
				lnkLatestVersion.Visible = false;
				lnkChangeList.Visible = false;
			}
			
			grpLatestVersion.Visible = true;
		}

		private void autoUpdate_CheckedChanged(object sender, EventArgs e)
		{
			if (((RadioButton)sender).Checked && !_loadingSettings)
			{
				PropertyChanged = true;
			}
		}

		public override void ApplyChanges()
		{
			if (rdoCheckNoAuto.Checked)
			{
				 SettingsManager.Settings.Updates = UpdateInterval.NoAutoCheck;
			}

			if (rdoCheckWeekly.Checked)
			{
				SettingsManager.Settings.Updates = UpdateInterval.CheckWeekly;
			}

			if (rdoCheckDaily.Checked)
			{
				SettingsManager.Settings.Updates = UpdateInterval.CheckDaily;
			}

			if (rdoCheckEveryStartup.Checked)
			{
				SettingsManager.Settings.Updates = UpdateInterval.CheckEveryStartup;
			}
		}

		private bool _loadingSettings;
		internal override void getSettings()
		{
			_loadingSettings = true;

			switch (SettingsManager.Settings.Updates)
			{
				case UpdateInterval.NoAutoCheck:
					rdoCheckNoAuto.Checked = true;
					break;
				case UpdateInterval.CheckWeekly:
					rdoCheckWeekly.Checked = true;
					break;
				case UpdateInterval.CheckDaily:
					rdoCheckDaily.Checked = true;
					break;
				default:
					rdoCheckEveryStartup.Checked = true;
					break;
			}

			_loadingSettings = false;
		}
	}
}
