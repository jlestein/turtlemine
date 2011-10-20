using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Interop.BugTraqProvider;

namespace TRMIssues
{
    /// <summary>
    /// Redmine Plugin
    /// </summary>
    [ComVisible(true),
     Guid("55B7DC40-2D4A-46AB-8884-329A02D26EDE"),
     ClassInterface(ClassInterfaceType.None),
     ProgId("TRMIssues")]
    public sealed class PluginRedMine : IBugTraqProvider2
    {
        #region Members

        private FeedParser _parser;

        #endregion

        #region Constructor

        ///// <summary>
        ///// Initializes a new instance of the <see cref="PluginRedMine"/> class.
        ///// </summary>
        //public PluginRedMine()
        //{
        //    noItemPerPage = 100; // 25,50,100
        //    keyItemPerPage = "&per_page=";
        //    //keyNumPage = "&page=";
        //}
        #endregion

        #region Properties

        private string feedsUrl { get; set; }

        /// <summary>
        /// Gets the feedItems.
        /// </summary>
        /// <value>The feedItems.</value>
        internal List<FeedItem> FeedItems
        {
            get { return _parser != null ? _parser.FeedItems : new List<FeedItem>(); }
        }

        /// <summary>
        /// Gets the feed title.
        /// </summary>
        /// <value>The feed title.</value>
        internal string FeedTitle
        {
            get
            {
                return _parser != null ? _parser.FeedTitle : String.Empty;
                
            }
        }

        /// <summary>
        /// Gets a value indicating whether the [feed failed to load].
        /// </summary>
        /// <value><c>true</c> if [feed failed to load]; otherwise, <c>false</c>.</value>
        internal bool FeedFailedToLoad { get; private set; }
        #endregion

        #region Methods for TSVN


        /// <summary>
        /// Validates the parameters.
        /// </summary>
        /// <param name="hParentWnd">Parent window for any UI that needs to be displayed during validation.</param>
        /// <param name="parameters">The parameter string that needs to be validated.</param>
        /// <returns>Is the string valid?</returns>
        public bool ValidateParameters(IntPtr hParentWnd, string parameters)
        {
            return true;
        }

        /// <summary>
        /// Gets the link text.
        /// </summary>
        /// <param name="hParentWnd">Parent window for any (error) UI that needs to be displayed.</param>
        /// <param name="parameters">The parameter string, just in case you need to talk to your web service (e.g.) to find out what the correct text is.</param>
        /// <returns>What text do you want to display? Use the current thread locale.</returns>
        public string GetLinkText(IntPtr hParentWnd, string parameters)
        {
            return Resources.ClassesResources.ButtonText;
        }

        /// <summary>
        /// Gets the commit message.
        /// </summary>
        /// <param name="hParentWnd">Parent window for your provider's UI.</param>
        /// <param name="parameters">Parameters for your provider.</param>
        /// <param name="commonRoot">The common root.</param>
        /// <param name="pathList">The path list.</param>
        /// <param name="originalMessage">The text already present in the commit message. Your provider should include this text in the new message, where appropriate.</param>
        /// <returns>The new text for the commit message. This replaces the original message.</returns>
        /// <exception cref="Exception"><c>Exception</c>.</exception>
        public string GetCommitMessage(IntPtr hParentWnd, string parameters, string commonRoot, string[] pathList, string originalMessage)
        {
            try
            {
                feedsUrl = parameters;

                //Show form
                var form = new IssuesForm(this, originalMessage);

                //If don't click ok then return the original message.
                if (form.ShowDialog() != DialogResult.OK)
                {
                    return originalMessage;
                }

                //If we click ok but no items are selected then return the original message.
                if (form.ItemsFixed.Count <= 0)
                {
                    return originalMessage;
                }

                //Add issues to comment window
                var result = new StringBuilder();
                var regexObj = new Regex(@"([Ii]ssues?:?(\s*(,|and)?\s*#\d+)+)", RegexOptions.IgnoreCase);

                if (regexObj.Matches(originalMessage).Count <= 0)
                {
                    //Not found at all

                    //Check if we include summary
                    if (form.IncludeSummary)
                    {
                        if (originalMessage.Length > 0)
                        {
                            result.AppendLine(originalMessage);
                        }

                        //Add each checked issue
                        foreach (var item in form.ItemsFixed)
                        {
                            result.AppendLine(string.Format("({0} #{1}) : {2}", Resources.ClassesResources.IssueText, item.Number,
                                                item.Description));
                        }
                    }
                    else
                    {
                        //Add Original message and "Issues"
                        result.AppendFormat("{0} ({1}", originalMessage, Resources.ClassesResources.IssueText);
                        //Add each checked issue
                        foreach (var item in form.ItemsFixed)
                        {
                            result.AppendFormat(" #{0},", item.Number);
                        }
                        //Remove trailing comma
                        result.Remove(result.Length - 1, 1);
                        result.Append(")");
                    }
                }
                else
                {
                    //Found

                    if (originalMessage.EndsWith(Environment.NewLine))
                    {
                        result.Append(originalMessage);
                    }
                    else
                    {
                        result.AppendLine(originalMessage);    
                    }

                    //Add each checked issue if not already there
                    foreach (var item in form.ItemsFixed)
                    {
                        if (form.IncludeSummary)
                        {
                            if (originalMessage.Contains(string.Format("({0} #{1}) : {2}", Resources.ClassesResources.IssueText, item.Number,
                                                item.Description)))
                            {
                                //Number and summary are already included so skip this issue number
                                continue;
                            }
                            
                            if (originalMessage.Contains(string.Format("#{0}", item.Number)))
                            {
                                //Issue number is included but not description so add the description on a new line if it is
                                //not in the original comment somewhere else.
                                if (!originalMessage.Contains(item.Description))
                                {
                                    result.AppendLine(item.Description);    
                                }
                                
                                continue;
                            }

                            //Got here which means this is a new issue so add it.
                            result.AppendLine(string.Format("({0} #{1}) : {2}", Resources.ClassesResources.IssueText, item.Number,
                                                item.Description));
                        }
                        else
                        {
                            if (originalMessage.Contains(string.Format("#{0}", item.Number)))
                            {
                                //Issue is already in the original comment so skip adding
                                continue;
                            }

                            //Got here which means this is a new issue so add it to the existing list.
                            //Find (Issues #xxx in original message and append to it.
                            var startpos =
                                originalMessage.LastIndexOf(
                                    string.Format("{0} #", Resources.ClassesResources.IssueText),
                                    StringComparison.CurrentCultureIgnoreCase);
                            var endpos = originalMessage.IndexOf(")", startpos);

                            //If can't find closing brace then add after the word issue and before the #
                            if (endpos < 0)
                            {
                                endpos = startpos + Resources.ClassesResources.IssueText.Length;
                                result.Insert(endpos, string.Format(" #{0},", item.Number));
                            }
                            else
                            {
                                result.Insert(endpos, string.Format(", #{0}", item.Number));
                            }
                        }
                    }
                }

                //If we have issues added to the list return them  otherwise return just the original message
                return result.ToString() != originalMessage + " ()" ? result.ToString() : originalMessage;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());                
                throw;
            }
        }

        /// <summary>
        /// Gets the commit message2.
        /// </summary>
        /// <param name="hParentWnd">Parent window for your provider's UI.</param>
        /// <param name="parameters">Parameters for your provider.</param>
        /// <param name="commonUrl">The common URL of the commit.</param>
        /// <param name="commonRoot">The common root.</param>
        /// <param name="pathList">The path list.</param>
        /// <param name="originalMessage">The text already present in the commit message. Your provider should include this text in the new message, where appropriate.</param>
        /// <param name="bugID">The content of the <paramref name="bugID"/> field (if shown)</param>
        /// <param name="bugIDOut">Modified content of the <paramref name="bugID"/> field.</param>
        //You can assign custom revision properties to a commit by setting the next two params.  note: Both safearrays must be of the same length.   For every property name there must be a property value!
        /// <param name="revPropNames">The list of revision property names.</param>
        /// <param name="revPropValues">The list of revision property values.</param>
        /// <returns>The new text for the commit message. This replaces the original message.</returns>
        public string GetCommitMessage2(IntPtr hParentWnd, string parameters, string commonUrl, string commonRoot, string[] pathList, string originalMessage, string bugID, out string bugIDOut, out string[] revPropNames, out string[] revPropValues)
        {
            bugIDOut = bugID;

            // If no revision properties are to be set, 
            // the plug-in MUST return empty arrays. 
            revPropNames = new string[0];
            revPropValues = new string[0];

            return GetCommitMessage(hParentWnd, parameters, commonRoot, pathList, originalMessage);
        }

        /// <summary>
        /// Checks the commit.
        /// </summary>
        /// <param name="hParentWnd">The h parent WND.</param>
        /// <param name="parameters">The parameters.</param>
        /// <param name="commonUrl">The common URL.</param>
        /// <param name="commonRoot">The common root.</param>
        /// <param name="pathList">The path list.</param>
        /// <param name="commitMessage">The commit message.</param>
        /// <returns></returns>
        public string CheckCommit(IntPtr hParentWnd, string parameters, string commonUrl, string commonRoot, string[] pathList, string commitMessage)
        {
            return null;
        }

        /// <summary>
        /// Called when [commit finished].
        /// </summary>
        /// <param name="hParentWnd">Parent window for any (error) UI that needs to be displayed.</param>
        /// <param name="commonRoot">The common root of all paths that got committed.</param>
        /// <param name="pathList">All the paths that got committed.</param>
        /// <param name="logMessage">The text already present in the commit message.</param>
        /// <param name="revision">The revision of the commit.</param>
        /// <returns>An error to show to the user if this function returns something else than S_OK</returns>
        public string OnCommitFinished(IntPtr hParentWnd, string commonRoot, string[] pathList, string logMessage, int revision)
        {
            return null;
        }

        /// <summary>
        /// Whether the provider provides options
        /// </summary>
        /// <returns>
        /// 	<c>true</c> if this instance has options; otherwise, <c>false</c>.
        /// </returns>
        public bool HasOptions()
        {
            return true;
        }

        /// <summary>
        /// Shows the options dialog.
        /// </summary>
        /// <param name="hParentWnd">Parent window for the options dialog.</param>
        /// <param name="parameters">Parameters for your provider.</param>
        /// <returns>The parameters string</returns>
        public string ShowOptionsDialog(IntPtr hParentWnd, string parameters)
        {
            var dialog = new OptionsDialog {Parameter = parameters};

            return dialog.ShowDialog(WindowWrapper.TryCreate(hParentWnd)) == DialogResult.OK ? dialog.Parameter : parameters;
        }

        #endregion

        /// <summary>
        /// Gets the ATOM Feed.
        /// </summary>
        internal void GetFeed()
        {
            try
            {
                _parser = new FeedParser(feedsUrl);
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format(Resources.ClassesResources.ErrorReadingIssuesListMessage, Environment.NewLine + ex.Message), Resources.ClassesResources.ErrorReadingIssuesListTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                FeedFailedToLoad = true;
            }
        }
    }

    /// <summary>
    /// Convert an <c>IntPtr</c> to an Windows handle
    /// </summary>
    internal sealed class WindowWrapper : IWin32Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WindowWrapper"/> class.
        /// </summary>
        /// <param name="handle">The handle.</param>
        private WindowWrapper(IntPtr handle)
        {
            Handle = handle;
        }

        /// <summary>
        /// Gets the handle to the window represented by the implementer.
        /// </summary>
        /// <value></value>
        /// <returns>
        /// A handle to the window represented by the implementer.
        /// </returns>
        public IntPtr Handle { get; private set; }

        /// <summary>
        /// Tries to create a windows wrapper from the hwnd.
        /// </summary>
        /// <param name="handle">The handle.</param>
        /// <returns>A handle to the window represented by the implementer.</returns>
        public static WindowWrapper TryCreate(IntPtr handle)
        {
            return handle != IntPtr.Zero ? new WindowWrapper(handle) : null;
        }
    }
}