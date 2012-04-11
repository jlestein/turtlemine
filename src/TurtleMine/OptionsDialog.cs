using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using TurtleMine.Controls;
using TurtleMine.Resources;
using TurtleMine.Settings;

namespace TurtleMine
{
	/// <summary>
	/// Options Dialog for selecting atom feed
	/// </summary>
	public sealed partial class OptionsDialog : Form
	{
		/// <summary>
		/// Gets or sets the parameter.
		/// </summary>
		/// <value>The parameter.</value>
		public string Parameter { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="OptionsDialog"/> class.
		/// </summary>
		public OptionsDialog()
		{
			InitializeComponent();
		}

		private void OptionsDialog_Load(object sender, EventArgs e)
		{
			//Set current value at load
			if (string.IsNullOrEmpty(Parameter))
			{
				return;
			}

			txtIssueListUrl.Text = Parameter;

			_normalCursor = Cursor.Current;
		}

		private void OptionsDialog_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (DialogResult != DialogResult.OK)
			{
				return;
			}
			
			//Try parsing the link
			try
			{
				applySettings();

				//Test the link
				testLink();
			}
			catch (Exception ex)
			{
				var dialog = new ErrorDialog(Strings.ErrorReadingIssuesListTitle, String.Format(Strings.ErrorReadingIssuesListMessage, Environment.NewLine + ex.Message + Environment.NewLine + Environment.NewLine + Strings.ErrorConfirmContinue), ex, ErrorDialog.ButtonState.OkCancel);
				if (dialog.ShowDialog(Plugin.AppWindow) == DialogResult.Cancel)
				{
					e.Cancel = true;
				}
			}

			//Set url
			Parameter = lnkFeedUrl.Text;
		}

		private void txtIssueListUrl_TextChanged(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(txtIssueListUrl.Text.Trim()))
			{
				btnOk.Enabled = false;
				btnTest.Enabled = false;
			}
			else
			{
				btnOk.Enabled = true;
				btnTest.Enabled = true;
			}
		}

		private void btnTest_Click(object sender, EventArgs e)
		{
			toggleCursor(true);
			//Try parsing the link 
			try
			{
				MessageBox.Show(string.Format(Strings.OptionsDialog_btnTest_Click_Successfully_read_atom_feed, testLink()), Strings.OptionsDialog_btnTest_Click_Success, MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch (Exception ex)
			{
				var dialog = new ErrorDialog(Strings.ErrorReadingIssuesListTitle, String.Format(Strings.ErrorReadingIssuesListMessage, Environment.NewLine + ex.Message), ex, ErrorDialog.ButtonState.OkOnly);
				dialog.ShowDialog(Plugin.AppWindow);
			}
			toggleCursor(false);
		}

		private void lnkFeedUrl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			try
			{
				Process.Start(lnkFeedUrl.Text);
			}
			catch (Exception ex)
			{
				var dialog = new ErrorDialog(Strings.OptionsDialog_lnkFeedUrl_LinkClicked_Failed, Strings.OptionsDialog_lnkFeedUrl_LinkClicked_Unable_to_open_link + Environment.NewLine + ex.Message, ex, ErrorDialog.ButtonState.OkOnly);
				dialog.ShowDialog(Plugin.AppWindow);
			}
			
		}

		private void btnConnection_Click(object sender, EventArgs e)
		{
			if (Size.Height > 240)
			{
				Size = new Size(Size.Width, 228);
			}
			else
			{
				SettingsManager.LoadSettings();
				pnlConnectivity.Controls.Add(new Connectivity());
				Size = new Size(Size.Width, 739);				
			}
		}

		private void btnApply_Click(object sender, EventArgs e)
		{
			toggleCursor(true);
			applySettings();
			btnApply.Enabled = false;
			toggleCursor(false);
		}

		private Cursor _normalCursor;
		private void toggleCursor(bool wait)
		{
			Cursor.Current = wait ? Cursors.WaitCursor : _normalCursor;
		}

		#region Helper Methods

		private void applySettings()
		{
			//Apply settings for each template control
			foreach (Template control in pnlConnectivity.Controls.OfType<Template>())
			{
				control.ApplyChanges();
			}

			//Save the settings file to disk
			SettingsManager.SaveSettings();			
		}

		/// <summary>
		/// Tests the link. Raises an exception if link is not parseable.
		/// </summary>
		private string testLink()
		{
			//Set Atom URL text
			setLinkText();

			//Try parsing the text
			var parser = new FeedParser(lnkFeedUrl.Text);

			return parser.FeedTitle;
		}

		/// <summary>
		/// Sets the link text.
		/// </summary>
		private void setLinkText()
		{
			//Make sure it is a valid link
			if (!isUri(txtIssueListUrl.Text))
			{
				return;
			}

			//Append format=atom if it does not contain it already, does not contain issues.atom and is not a local file path
			if (!txtIssueListUrl.Text.Contains("format=atom") && !txtIssueListUrl.Text.Contains("issues.atom") && !Path.IsPathRooted(txtIssueListUrl.Text))
			{
				lnkFeedUrl.Text = txtIssueListUrl.Text.Contains("?")
									  ? txtIssueListUrl.Text + "&format=atom"
									  : txtIssueListUrl.Text + "?format=atom";
			}
			else
			{
				lnkFeedUrl.Text = txtIssueListUrl.Text;
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
