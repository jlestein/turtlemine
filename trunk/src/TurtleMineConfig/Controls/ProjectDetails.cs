using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using TurtleMine.Resources;

namespace TurtleMine.Controls
{
	/// <summary>
	/// Details for a selected project
	/// </summary>
	public partial class ProjectDetails : Template
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ProjectDetails"/> class.
		/// </summary>
		public ProjectDetails()
		{
			InitializeComponent();

			//Still use template control but treat differently - Always show header and hide options.
			lblHeading.Visible = true;
			rdoGlobalSettings.Visible = false;
			rdoCustomSettings.Visible = false;
			pnlSettings.Enabled = true;
		}

		private void ProjectDetails_Load(object sender, EventArgs e)
		{

		}

		private void btnRepoPath_Click(object sender, EventArgs e)
		{
			var dialog = new FolderBrowserDialog
							 {
								 Description = Strings.ProjectDetails_btnRepoPath_Click_Select_Repository_Location,
								 ShowNewFolderButton = false
							 };

			//Restore last directory if there is one
			if (!String.IsNullOrEmpty(txtRepoPath.Text))
			{
				dialog.SelectedPath = txtRepoPath.Text;
			}

			if (dialog.ShowDialog(ParentForm) != DialogResult.OK)
			{
				return;
			}

			//Check for Repo
			//Note: for some reason ? is not working as a wild card.
			var isSvn = Directory.GetDirectories(dialog.SelectedPath, ".svn").Length > 0 ||
			            Directory.GetDirectories(dialog.SelectedPath, "_svn").Length > 0;
			var isGit = Directory.GetDirectories(dialog.SelectedPath, ".git").Length > 0 ||
			            Directory.GetDirectories(dialog.SelectedPath, "_git").Length > 0;
			var isHg = Directory.GetDirectories(dialog.SelectedPath, ".hg").Length > 0 ||
			           Directory.GetDirectories(dialog.SelectedPath, "_hg").Length > 0;

			//Validate path is a Repo Path
			if (!isSvn && !isGit && !isHg)
			{
				if (MessageBox.Show(Strings.ProjectDetails_btnRepoPath_Click_This_directory_can_not_be_identified_1 + Environment.NewLine + Strings.ProjectDetails_btnRepoPath_Click_This_directory_can_not_be_identified_2, Strings.ProjectDetails_btnRepoPath_Click_Unknown_Repository_Type, MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) != DialogResult.OK)
				{
					return;
				}
			}

			txtRepoPath.Text = dialog.SelectedPath;

			//Add Repo Type image if know type
			if (isSvn)
			{
				picRepoType.Image = Images.svn24;
			}
			else if (isGit)
			{
				picRepoType.Image = Images.git24;
			}
			else if (isHg)
			{
				picRepoType.Image = Images.hg24;
			}
			else
			{
				picRepoType.Image = null;
			}
		}

		private void btnVerifyLinks_Click(object sender, EventArgs e)
		{
			//Loop through rows that have a Issues URL
			foreach (var row in dgvIssuesLists.Rows.Cast<DataGridViewRow>().Where(row => row.Cells["IssuesURL"].Value != null))
			{
				//Set Atom URL text
				setLinkText(row);

				var feedtitle = string.Empty;
				try
				{
					//Try parsing the text
					var parser = new FeedParser(row.Cells["IssuesURL"].Value.ToString());
					feedtitle = parser.FeedTitle;
				}
				catch
				{
					//Unable to read feed so it must be invalid
				}

				if (string.IsNullOrEmpty(feedtitle))
				{
					//Set Error Text
					row.Cells["IssuesURL"].ErrorText = "Verification Failed";
				}
			}
		}

		#region Helper Methods

		/// <summary>
		/// Sets the link text.
		/// </summary>
		private static void setLinkText(DataGridViewRow row)
		{
			var url = row.Cells["IssuesURL"].Value.ToString();

			//Make sure it is a valid link
			if (!isUri(url))
			{
				return;
			}

			//Append format=atom if it does not contain it already, does not contain issues.atom and is not a local file path
			if (!url.Contains("format=atom") && !url.Contains("issues.atom") && !Path.IsPathRooted(url))
			{
				row.Cells["IssuesURL"].Value = url.Contains("?") ? url + "&format=atom" : url + "?format=atom";
			}
		}


		/// <summary>
		/// Determines whether the specified source is a valid URI.
		/// </summary>
		/// <param name="source">The source.</param>
		/// <returns>
		/// 	<c>true</c> if the specified source is a valid URI; otherwise, <c>false</c>.
		/// </returns>
		private static bool isUri(string source)
		{
			try
			{
				new Uri(source);
			}
			catch
			{
				return false;
			}

			return true;
		}

		#endregion

	}
}
