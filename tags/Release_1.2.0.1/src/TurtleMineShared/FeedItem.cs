using System;
using System.ServiceModel.Syndication;
using System.Text.RegularExpressions;

namespace TurtleMine
{
    /// <summary>
    /// An Individual feed item
    /// </summary>
    internal class FeedItem : IComparable
    {
        #region Constructor

        //Flag to indicate if this is an older redmine version
        private bool _oldredmineVer;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="FeedItem"/> class.
        /// </summary>
        /// <param name="item">The syndication item.</param>
        /// <param name="baseRedmineUrl">The base redmine URL.</param>
        /// <param name="projectUrlPath">The project URL path.</param>
        public FeedItem(SyndicationItem item, String baseRedmineUrl, String projectUrlPath)
        {
            //Set Type, Number, Status, Description
            parseTitle(item.Title.Text);

            //Set Link
        	var absoluteUri = item.Links[0].GetAbsoluteUri();
        	if (absoluteUri != null)
        	{
        		Link = absoluteUri.ToString();
        	}

        	//Set Updated DateTime
            LastUpdated = item.LastUpdatedTime.LocalDateTime;

            //Set Author
            Author = item.Authors[0].Name;

            //Set Content
            parseHtmlContent((TextSyndicationContent)item.Content, baseRedmineUrl, projectUrlPath);

            //Set TimeEntry Url
            parseTimeEntryUrl(baseRedmineUrl + projectUrlPath);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the type.
        /// </summary>
        /// <value>The type.</value>
        public String Type { get; private set; }

        /// <summary>
        /// Gets the number.
        /// </summary>
        /// <value>The number.</value>
        public Int32 Number { get; private set; }

        /// <summary>
        /// Gets the status.
        /// </summary>
        /// <value>The status.</value>
        public String Status { get; private set; }
        
        /// <summary>
        /// Gets the summary.
        /// </summary>
        /// <value>The summary.</value>
        public String Description { get; private set; }

        /// <summary>
        /// Gets the link.
        /// </summary>
        /// <value>The link.</value>
        public String Link { get; private set; }


        /// <summary>
        /// Gets the last updated date and time.
        /// </summary>
        /// <value>The last updated <c>DateTime</c>.</value>
        public DateTime LastUpdated { get; private set; }

        /// <summary>
        /// Gets or sets the author.
        /// </summary>
        /// <value>The author.</value>
        public String Author { get; private set; }

        /// <summary>
        /// Gets the Content.
        /// </summary>
        /// <value>The Content.</value>
        public String Content { get; private set; }

        /// <summary>
        /// Gets or sets the time entry URL.
        /// </summary>
        /// <value>The time entry URL.</value>
        public String TimeEntryUrl { get; private set; }


        #endregion

        #region Parse fields methods

        /// <summary>
        /// Parses the title into Type, Number, Status, Description.
        /// </summary>
        /// <param name="fullTitle">The full title.</param>
        private void parseTitle(String fullTitle)
        {
            //Retrieve info from newer Redmine hosts
            var regexObj = new Regex(@"(?<Type>.*)#(?<Id>\d*).*\x28(?<Status>.*)\x29:(?<Desc>.*)");

            //Test if data retrieved, if not it could be an older redmine host
            if (!String.IsNullOrEmpty(regexObj.Match(fullTitle).Groups["Id"].Value))
            {
                Type = regexObj.Match(fullTitle).Groups["Type"].Value;
                Number = int.Parse(regexObj.Match(fullTitle).Groups["Id"].Value);
                Status = regexObj.Match(fullTitle).Groups["Status"].Value;
                Description = regexObj.Match(fullTitle).Groups["Desc"].Value;
            }
            else
            {
                //Try using regex for older redmine hosts
                regexObj = new Regex(@"(?<Type>[^#]*)#(?<Id>\d*):(?<Desc>.*)");
                Type = regexObj.Match(fullTitle).Groups["Type"].Value;
                Number = int.Parse(regexObj.Match(fullTitle).Groups["Id"].Value);
                Description = regexObj.Match(fullTitle).Groups["Desc"].Value;
                //Flag as older version
                _oldredmineVer = true;
            }
        }

        /// <summary>
        /// Parses the content to HTML.
        /// </summary>
        /// <param name="content">The content.</param>
        /// <param name="baseRedmineUrl">The base redmine URL.</param>
        /// <param name="projectUrlPath">The project URL path.</param>
        private void parseHtmlContent(TextSyndicationContent content, String baseRedmineUrl, String projectUrlPath)
        {
            //Add sourounding html tags
            //Update links to use a new window
            //Replace Project links (eg. for Source or Export) with full url
            //Replace wiki links with issue URL
            const string href = "href=\"";
            Content = String.Format("<html><body style=\"font-size:11px\">{0}</body></html>",
                                    content.Text.Replace("<a ", "<a target=\"_new\" ").Replace("<A ", "<A target=\"_new\" ")
                                                .Replace(href + "/" + projectUrlPath, href + baseRedmineUrl + projectUrlPath)
                                                .Replace(href + "#", String.Format(href + "{0}#", Link)));
        }

        /// <summary>
        /// Parses the time entry URL.
        /// </summary>
        /// <param name="projectUrl">The project URL.</param>
        private void parseTimeEntryUrl(String projectUrl)
        {
            TimeEntryUrl = _oldredmineVer ? String.Format("{0}/timelog/edit?issue_id={1}", projectUrl, Number) : string.Format("{0}/issues/{1}/time_entries/new", projectUrl, Number);
        }

        #endregion

        #region IComparable Members

        /// <summary>
        /// Compares the current instance with another object of the same type and returns an Int32eger that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.
        /// </summary>
        /// <returns>
        /// A 32-bit signed Int32eger that indicates the relative order of the objects being compared. The return value has these meanings: 
        ///                     Value 
        ///                     Meaning 
        ///                     Less than zero 
        ///                     This instance is less than <paramref name="obj"/>. 
        ///                     Zero 
        ///                     This instance is equal to <paramref name="obj"/>. 
        ///                     Greater than zero 
        ///                     This instance is greater than <paramref name="obj"/>. 
        /// </returns>
        /// <param name="obj">An object to compare with this instance. 
        ///                 </param><exception cref="T:System.ArgumentException"><paramref name="obj"/> is not the same type as this instance. 
        ///                 </exception><filterpriority>2</filterpriority>
        public Int32 CompareTo(object obj)
        {
            var objCompare = obj as FeedItem;

            if (objCompare == null)
            {
                return -1;
            }

            return objCompare.Number - Number;
                
        }

        /// <summary>
        /// Determines whether the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <returns>
        /// <c>true</c> if the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>; otherwise, <c>false</c>.
        /// </returns>
        /// <param name="obj">The <see cref="T:System.Object"/> to compare with the current <see cref="T:System.Object"/>. 
        ///                 </param><exception cref="T:System.NullReferenceException">The <paramref name="obj"/> parameter is <c>null</c>.
        ///                 </exception><filterpriority>2</filterpriority>
        public override bool Equals(object obj)
        {
            return CompareTo(obj)==0;
        }

        /// <summary>
        /// Serves as a hash function for a particular type. 
        /// </summary>
        /// <returns>
        /// A hash code for the current <see cref="T:System.Object"/>.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public override Int32 GetHashCode()
        {
            return Number;
        }

        #endregion
    }
}
