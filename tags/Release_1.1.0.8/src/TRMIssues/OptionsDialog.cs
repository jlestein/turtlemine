using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using TRMIssues.Resources;

namespace TRMIssues
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
                testLink();
            }
            catch (Exception ex)
            {
                if (MessageBox.Show(String.Format(ClassesResources.ErrorReadingIssuesListMessage, Environment.NewLine + ex.Message + Environment.NewLine + Environment.NewLine + "Do you wish to continue anyway?"), ClassesResources.ErrorReadingIssuesListTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Cancel)
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
                btnOK.Enabled = false;
                btnTest.Enabled = false;
            }
            else
            {
                btnOK.Enabled = true;
                btnTest.Enabled = true;
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            //Try parsing the link 
            try
            {
                MessageBox.Show(string.Format(FormsResources.OptionsDialog_btnTest_Click_Successfully_read_atom_feed, testLink()), FormsResources.OptionsDialog_btnTest_Click_Success, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format(ClassesResources.ErrorReadingIssuesListMessage, Environment.NewLine + ex.Message), ClassesResources.ErrorReadingIssuesListTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void lnkFeedUrl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Process.Start(lnkFeedUrl.Text);
            }
            catch (Exception ex)
            {

                MessageBox.Show(FormsResources.OptionsDialog_lnkFeedUrl_LinkClicked_Unable_to_open_link + Environment.NewLine + ex.Message, FormsResources.OptionsDialog_lnkFeedUrl_LinkClicked_Failed, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        #region Helper Methods

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
