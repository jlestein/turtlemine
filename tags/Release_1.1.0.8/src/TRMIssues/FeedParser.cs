using System;
using System.Collections.Generic;
using System.ServiceModel.Syndication;
using TRMIssues.Resources;

namespace TRMIssues
{
    /// <summary>
    /// Parse an Atom Feed
    /// </summary>
    internal class FeedParser
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="FeedParser"/> class.
        /// </summary>
        /// <param name="feedUrl">The feed URL.</param>
        /// <exception cref="ArgumentException"><paramref name="feedUrl"/> is <c>null</c> or empty.</exception>
        public FeedParser(String feedUrl)
        {
            if (String.IsNullOrEmpty(feedUrl))
            {
                throw new ArgumentException(ClassesResources.FeedParser_FeedParser_feedUrl_is_not_provided, "feedUrl");
            }

            //Read the Url into a Syndication Feed.
            var reader = ConnectionHelper.CreateXmlReader(feedUrl);
            var feed = SyndicationFeed.Load(reader);

            if (feed == null)
                return;

            //Set base properties
            FeedTitle = feed.Title.Text;
            baseRedmineUrl = feed.Id;

            //Handle Welcome message as part of FeedId
            if (baseRedmineUrl.EndsWith("welcome", StringComparison.CurrentCultureIgnoreCase))
            {
                baseRedmineUrl = baseRedmineUrl.Remove(baseRedmineUrl.LastIndexOf("welcome"));
            }

            //Remove BaseRedmineUrl and "Issues" wording
            projectUrlPath = feed.Links[0].Uri.AbsoluteUri.Replace(baseRedmineUrl, String.Empty).Replace("/issues.atom", String.Empty).Replace("/issues", String.Empty);

            //Also remove Url Query info if exists
            if (!String.IsNullOrEmpty(feed.Links[0].Uri.Query))
            {
                projectUrlPath = projectUrlPath.Replace(feed.Links[0].Uri.Query, String.Empty);
            }

            //Set item properties
            FeedItems = new List<FeedItem>();
            foreach (var item in feed.Items)
            {
                FeedItems.Add(new FeedItem(item, baseRedmineUrl, projectUrlPath));
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the feed title.
        /// </summary>
        /// <value>The feed title.</value>
        public String FeedTitle { get; private set; }

        /// <summary>
        /// Gets or sets the base redmine URL.
        /// </summary>
        /// <value>The base redmine URL.</value>
        private String baseRedmineUrl { get; set; }

        /// <summary>
        /// Gets or sets the redmine project URL.
        /// </summary>
        /// <value>The redmine project URL.</value>
        private String projectUrlPath { get; set; }

        /// <summary>
        /// Gets the feed items.
        /// </summary>
        /// <value>The feed items.</value>
        public List<FeedItem> FeedItems { get; private set; }

        #endregion
    }
}
