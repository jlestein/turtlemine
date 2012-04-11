using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using System.Windows.Forms;
using TurtleMine.Resources;
using TurtleMine.Settings;

namespace TurtleMine
{
	/// <summary>
	/// The Issue Display Form
	/// </summary>
	partial class IssuesForm : Form
	{
		#region Members

		private readonly Plugin _servicePlugin;
		private IEnumerable<FeedItem> feedItems;
		private readonly List<FeedItem> itemsAffected = new List<FeedItem>();
		private readonly List<FeedItem> itemsList = new List<FeedItem>();

		//Color of list items
		private readonly Color colorSuccess = Color.LightSkyBlue;
		private readonly Color colorFailed = Color.LightGray;
		private readonly Color colorNeutral = Color.White;
		private readonly Color colorRecent = Color.Gainsboro;
		/// Color selections of current (past or searched)
		private Color colorSelectionCurrent;

		//The entry comment from the TSVN window
		private readonly string entryComment;

		//Column sorter
		private readonly ListViewColumnSorter lvwColumnSorter;
		private const string ArrowDownImage = "arrow_down";
		private const string ArrowUpImage = "arrow_up";

		//Indicates a hidden column
		private const string HiddenTag = "hidden";

		//Search combo selection
		private object selectedSearchField = string.Empty;

		#endregion

		#region Constructor
		/// <summary>
		/// Initializes a new instance of the <see cref="IssuesForm"/> class.
		/// </summary>
		/// <param name="plugin">The plugin.</param>
		/// <param name="baseComment">The base comment.</param>
		public IssuesForm(Plugin plugin, string baseComment)
		{
			Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;
			_servicePlugin = plugin;
			InitializeComponent();

			colorSelectionCurrent = colorRecent;
			entryComment = baseComment;

			// Create an instance of a ListView column sorter and assign it to the ListView.
			lvwColumnSorter = new ListViewColumnSorter();
			lvwIssueList.ListViewItemSorter = lvwColumnSorter;
		}

		#endregion

		#region Properties

		/// <summary>
		/// Gets the <see cref="feedItems"/> fixed.
		/// </summary>
		/// <value>The <see cref="feedItems"/> fixed.</value>
		public List<FeedItem> ItemsFixed
		{
			get { return itemsAffected; }
		}

		/// <summary>
		/// Gets the <see cref="feedItems"/> list.
		/// </summary>
		/// <value>The <see cref="feedItems"/> list.</value>
		public List<FeedItem> ItemsList
		{
			get
			{
				#region ATOM Thread

				var feedThread = new Thread(_servicePlugin.GetFeed) { CurrentUICulture = Thread.CurrentThread.CurrentCulture };
				feedThread.Start();
				while ((feedThread.ThreadState != ThreadState.Aborted) && (feedThread.ThreadState != ThreadState.Stopped))
				{
					Thread.Sleep(25);
				}

				//Check if load failed
				if (_servicePlugin == null || _servicePlugin.FeedFailedToLoad)
				{
					return itemsList;
				}

				#endregion

				//Get Feed Items
				IEnumerable<FeedItem> feedItemsList = _servicePlugin.FeedItems;
			
				//Add Items to ListView
				foreach (var item in feedItemsList)
				{
					var lvi = new ListViewItem {Text = string.Empty};
					lvi.SubItems.Add(item.Number.ToString());
					lvi.SubItems.Add(item.Type);
					lvi.SubItems.Add(item.Description);
					lvi.SubItems.Add(item.Status);
					lvi.SubItems.Add(item.Author);
					lvi.SubItems.Add(item.LastUpdated.ToString());
					lvi.Tag = item;

					itemsList.Add(item);
				}

				return itemsList; 
			}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether to [include summary].
		/// </summary>
		/// <value><c>true</c> if [include summary]; otherwise, <c>false</c>.</value>
		public bool IncludeSummary
		{
			get; private set;
		}

		private bool enabledControlWindow
		{
			set
			{
				btnOk.Enabled = value;
				btnCancel.Enabled = value;
				btnDescription.Enabled = value;
				//btOurvirRedmine.Enabled = value;
				//btPointage.Enabled = value;
				btnNext.Enabled = value;
				btnCheck.Enabled = value;
				txtSearch.Enabled = value;
				lvwIssueList.Enabled = value;
			}
		}

		#endregion

		#region Methods

		#region Form Events
		
		/// <summary>
		/// Handles the Load event of the myIssuesForm control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void myIssuesForm_Load(object sender, EventArgs e)
		{
			//Display Version
			lblVersion.Text = String.Format("{0} : {1}", Strings.VersionLabel, VersionCheck.CurrentVersion);

			//Check for New Version
			checkForNewVersion();
		}
		
		/// <summary>
		/// Handles the Shown event of the myIssuesForm control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void myIssuesForm_Shown(object sender, EventArgs e)
		{
			//Default focus to Search box
			txtSearch.Focus();

			// Loading settings from last session
			loadSettings();

			#region ATOM Thread

			enabledControlWindow = false;
			lblStatus.Text = Strings.AtomLoading;
			var feedThread = new Thread(_servicePlugin.GetFeed) { CurrentUICulture = Thread.CurrentThread.CurrentCulture };
			feedThread.Start();
			while ((feedThread.ThreadState != ThreadState.Aborted) && (feedThread.ThreadState != ThreadState.Stopped))
			{
				Thread.Sleep(25);
				//Update progress bar
				pbrLoading.Value = (pbrLoading.Value + 1) % 100;
				Application.DoEvents();
			}
			pbrLoading.Visible = false;

			//Check if load failed
			if (_servicePlugin == null || _servicePlugin.FeedFailedToLoad)
			{
				lblStatus.Text = Strings.AtomLoadFailed;
				btnCancel.Enabled = true;
				return;                
			}

			lblStatus.Text = String.Format(Strings.AtomLoadComplete, _servicePlugin.FeedItems.Count);
			enabledControlWindow = true;

			#endregion

			// Once loaded, we initialize the window
			initializeItemList();

			//Set title to feed title if not blank
			if (!String.IsNullOrEmpty(_servicePlugin.FeedTitle))
			{
				Text = _servicePlugin.FeedTitle;
			}
		}

		/// <summary>
		/// Handles the FormClosing event of the myIssuesForm control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.Windows.Forms.FormClosingEventArgs"/> instance containing the event data.</param>
		private void myIssuesForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (lvwIssueList.Columns.Count > 0)
			{
				//Save Windows settings on exit
				saveSettings();                
			}
		}

		private void initializeItemList()
		{
			//Define columns
			ColumnListColumn.DefaultHeaders(lvwIssueList);

			//Get Feed Items
			feedItems = _servicePlugin.FeedItems;
			
			//Add Items to ListView
			foreach (var item in feedItems)
			{
				var lvi = new ListViewItem {Text = string.Empty};
				lvi.SubItems.Add(item.Number.ToString());
				lvi.SubItems.Add(item.Type);
				lvi.SubItems.Add(item.Description);
				lvi.SubItems.Add(item.Status);
				lvi.SubItems.Add(item.Author);
				lvi.SubItems.Add(item.LastUpdated.ToString());
				lvi.Tag = item;

				lvwIssueList.Items.Add(lvi);
			}

			//Set column width for all colums to stretch
			foreach (ColumnHeader column in lvwIssueList.Columns)
			{
				column.Width = string.IsNullOrEmpty(column.Text.Trim()) ? 30 : -1;

				if (column.Index == 6)
				{
					column.ImageKey = ArrowDownImage;
				}
			}

			//Re-higlight the last selected items
			restoreRecentItems();

			//Restore Sorting and Column order / display
			loadListViewSettings();

			//Fill the combo box with appropriate fields
			fillFieldList();
		}

		#endregion

		#region Settings

		private void loadSettings()
		{
			var settings = new FormSettings();
			settings.LoadFormSettings();

			//Set size
			if (!settings.FormSize.IsEmpty)
			{
				Size = settings.FormSize;
			}

			//Set Description window
			splitContainer1.Panel2Collapsed = settings.HideDescription;
			if (settings.DescriptionHeight != 0)
			{
				splitContainer1.SplitterDistance = settings.DescriptionHeight;
			}

			//Include Summary
			chkIncludeSummary.Checked = settings.IncludeSummary;
		}

		private void loadListViewSettings()
		{
			var formSettings = new FormSettings();
			formSettings.LoadListSettings();
			
			lvwIssueList.SuspendLayout();

			//Get Sorting settings
			lvwColumnSorter.SortColumn = formSettings.SortColumn;
			lvwColumnSorter.Order = formSettings.SortOrder;

			//Redo sort
			if (lvwColumnSorter.SortColumn != 0)
			{
				lvwIssueList.Sort();
			}

			//Redo column re-arrange
			foreach (var column in formSettings.ColumnsDisplay)
			{
				var lvwColumn = lvwIssueList.Columns[column.Key];
				lvwColumn.DisplayIndex = Math.Abs(column.Value);

				//Check if we have a hidden column
				if (column.Value >= 0)
				{
					continue;
				}
				lvwColumn.Tag = HiddenTag;
					lvwColumn.Width = 0;
				}

			lvwIssueList.ResumeLayout();
		}

		private void fillFieldList()
		{
			cboFields.Items.Clear();

			//Add "All Fields" as the default
			cboFields.Items.Add(Strings.SearchFieldAllFields);

			//For each visibile column add it
			foreach (ColumnHeader column in lvwIssueList.Columns)
			{
				if ((column.Tag == null || column.Tag.ToString() != HiddenTag) && column.Text.Trim() != string.Empty)
				{
					cboFields.Items.Add(column.Text);
				}

				//Reselect this item if it was previously selected
				if (column.Text == selectedSearchField.ToString())
				{
					cboFields.SelectedItem = selectedSearchField;
				}
			}

			//Select "All Fields" if nothing else selected
			if (cboFields.SelectedItem != null && cboFields.SelectedItem.ToString() != string.Empty)
			{
				return;
			}
  
			cboFields.SelectedIndex = 0;
			selectedSearchField = cboFields.SelectedItem;
		}

		private void saveSettings()
		{
			//Save Form Size, Description Window, Sort Info
			var formSettings = new FormSettings
						   {
							   FormSize = Size,
							   HideDescription = splitContainer1.Panel2Collapsed,
							   DescriptionHeight = splitContainer1.SplitterDistance,
							   SortColumn = lvwColumnSorter.SortColumn,
							   SortOrder = lvwColumnSorter.Order,
							   ColumnsDisplay = new Dictionary<int, int>(),
							   IncludeSummary = chkIncludeSummary.Checked
						   };

			//Save Columns list
			foreach (ColumnHeader column in lvwIssueList.Columns)
			{
				if (column.Tag == null || column.Tag.ToString() != HiddenTag)
				{
					formSettings.ColumnsDisplay.Add(column.Index, column.DisplayIndex);
				}
				else
				{
					//Flag hidden column with negative display index
					formSettings.ColumnsDisplay.Add(column.Index, -1 * column.DisplayIndex);
				}

			}

			//Do Save
			formSettings.SaveAllSettings();
		}
		
		/// <summary>
		/// indicates what the last selected items were
		/// </summary>
		private void restoreRecentItems()
		{
			//Reset the color on all items
			foreach (ListViewItem lvi in lvwIssueList.Items)
			{
				lvi.BackColor = colorNeutral;
			}

			//For each recent item (if any), find it in the list and set the color
			foreach (var item in FormSettings.GetRecentItems())
			{
				findIssue(item, colorRecent, colorNeutral, true);
			}
		}

		/// <summary>
		/// Save list of currently selected items to registry
		/// </summary>
		/// <param name="listItems">lists <see cref="feedItems"/> selected</param>
		private static void saveRecentItems(IEnumerable<FeedItem> listItems)
		{
			FormSettings.SaveRecentItems(listItems);
		}

		#endregion

		#region Search and Select Events

		/// <summary>
		/// Handles the TextChanged event of the txtSearch control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void txtSearch_TextChanged(object sender, EventArgs e)
		{
			if (String.IsNullOrEmpty(txtSearch.Text))
			{
				gbxSearch.Text = Strings.SearchBoxNoResults;
				restoreRecentItems();
			}
			else
			{
				var nbResu = findIssue(txtSearch.Text, colorSuccess, colorFailed, false);
				gbxSearch.Text = String.Format(Strings.SearchBoxWithResults, nbResu);
			}
		}

		/// <summary>
		/// Handles the Click event of the btnNext control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void btnNext_Click(object sender, EventArgs e)
		{
			int firstSelectedItem;
			if (lvwIssueList.SelectedItems.Count > 0)
			{
				firstSelectedItem = lvwIssueList.SelectedIndices[lvwIssueList.SelectedItems.Count - 1] + 1;
			}
			else
			{
				firstSelectedItem = 0;
			}

			var indexFound = findHighlightedItems(firstSelectedItem, lvwIssueList.Items.Count - 1, colorSelectionCurrent);
			if (indexFound == -1)
			{
				indexFound = findHighlightedItems(0, firstSelectedItem - 2, colorSelectionCurrent);
			}

			if (indexFound < 0)
			{
				return;
			}

			lvwIssueList.Focus();
			for (var i = 0; i < lvwIssueList.SelectedIndices.Count; i++)
			{
				lvwIssueList.Items[lvwIssueList.SelectedIndices[i]].Selected = false;
			}
			lvwIssueList.Items[indexFound].EnsureVisible();
			lvwIssueList.Items[indexFound].Selected = true;
		}

		/// <summary>
		/// Check all lines highlighted.
		/// Handles the Click event of the btnCheck control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void btnCheck_Click(object sender, EventArgs e)
		{
			for (var i = 0; i < lvwIssueList.Items.Count; i++)
			{
				var itItem = lvwIssueList.Items[i];
				if (itItem.BackColor == colorSelectionCurrent)
				{
					itItem.Checked = !itItem.Checked;
				}
			}
		}
		
		/// <summary>
		/// Finds the highlighted items.
		/// </summary>
		/// <param name="firstHighlightedItem">The first highlighted item.</param>
		/// <param name="lastHighlightedItem">The last highlighted item.</param>
		/// <param name="highlightedItemBackColor">Color of the highlighted item back.</param>
		/// <returns></returns>
		private int findHighlightedItems(int firstHighlightedItem, int lastHighlightedItem, Color highlightedItemBackColor)
		{
			for (var i = firstHighlightedItem; i <= lastHighlightedItem; i++)
			{
				if (lvwIssueList.Items[i].BackColor == highlightedItemBackColor)
				{
					return i;
				}
			}
			return -1;
		}

		/// <summary>
		/// Function list colorization based on a criterion on the text
		/// </summary>
		/// <param name="text">search text</param>
		/// <param name="successColor">Color lines with the text in the description</param>
		/// <param name="failColor">Color lines not having the text in the description</param>
		/// <param name="onlyMatch">If <c>true</c>, only the lines "Winning" is modified</param>
		/// <returns>Number of results</returns>
		private int findIssue(string text, Color successColor, Color failColor, bool onlyMatch)
		{
			colorSelectionCurrent = successColor;
			var textNoCase = standardizedText(text);
			var nbVal = 0;

			foreach (ListViewItem item in lvwIssueList.Items)
			{
				if (textNoCase != string.Empty)
				{
					for (var i = 0; i < item.SubItems.Count; i++)
					{
						//Don't search hidden columns
						if (lvwIssueList.Columns[i].Tag != null && lvwIssueList.Columns[i].Tag.ToString() == HiddenTag)
						{
							continue;
						}

						//Only search this field if "All fields" selected or it is the selected field
						if (cboFields.SelectedItem != null && cboFields.SelectedItem.ToString() != Strings.SearchFieldAllFields && cboFields.SelectedItem.ToString() != lvwIssueList.Columns[i].Text)
						{
							continue;
						}

						if (item.SubItems[i].Text.ToLower().IndexOf(textNoCase) >= 0)
						{
							nbVal++;
							item.BackColor = successColor;
							break;
						}

						if (!onlyMatch)
						{
							item.BackColor = failColor;
						}
					}
				}
				else
				{
					item.BackColor = colorNeutral;
				}
			}

			return nbVal;
		}

		private static string standardizedText(string texte)
		{
			var nomFinal = texte.ToLower();

			nomFinal = nomFinal.Replace('à', 'a');
			nomFinal = nomFinal.Replace('â', 'a');

			nomFinal = nomFinal.Replace('ç', 'c');

			nomFinal = nomFinal.Replace('é', 'e');
			nomFinal = nomFinal.Replace('è', 'e');
			nomFinal = nomFinal.Replace('ê', 'e');

			nomFinal = nomFinal.Replace('ï', 'i');
			nomFinal = nomFinal.Replace('î', 'i');

			nomFinal = nomFinal.Replace('ù', 'u');
			nomFinal = nomFinal.Replace('û', 'u');
			nomFinal = nomFinal.Replace('ü', 'u');

			return nomFinal;
		}

		#endregion

		#region Other Events

		/// <summary>
		/// Handles the Click event of the btnOk control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void btnOk_Click(object sender, EventArgs e)
		{
			foreach (var feedItem in from ListViewItem lvi in lvwIssueList.Items
									 let feedItem = lvi.Tag as FeedItem
									 where feedItem != null && lvi.Checked
									 select feedItem)
			{
				itemsAffected.Add(feedItem);
			}
			if (itemsAffected.Count > 0)
			{
				saveRecentItems(itemsAffected);
			}
		}


		/// <summary>
		/// Handles the Click event of the btnDescription control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void btnDescription_Click(object sender, EventArgs e)
		{
			splitContainer1.Panel2Collapsed = !splitContainer1.Panel2Collapsed;
		}

		/// <summary>
		/// Handles the Click event of the btnOpenRedmine control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void btnOpenRedmine_Click(object sender, EventArgs e)
		{
			//For each checked item launch the redmine page
			foreach (ListViewItem item in lvwIssueList.CheckedItems)
			{
				System.Diagnostics.Process.Start(((FeedItem) item.Tag).Link);
			}
		}


		/// <summary>
		/// Handles the Click event of the btnTimeEntry control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void btnTimeEntry_Click(object sender, EventArgs e)
		{
			var comment = (entryComment == string.Empty ? string.Empty : "time_entry[comments]=" + entryComment);
			
			//For each checked item launch the time entry page
			foreach (ListViewItem item in lvwIssueList.CheckedItems)
			{
				var timeentryurl = Uri.EscapeUriString(((FeedItem) item.Tag).TimeEntryUrl);
				if (!String.IsNullOrEmpty(comment))
				{
					timeentryurl += ((FeedItem) item.Tag).TimeEntryUrl.Contains("?") ? "&" + comment : "?" + comment;
				}

				System.Diagnostics.Process.Start(timeentryurl);
			}
		}

		private void lblUpdateAvailable_Click(object sender, EventArgs e)
		{
			Form newversion = new VersionNotice();
			newversion.ShowDialog(this);
		}

		/// <summary>
		/// Handles the SelectedIndexChanged event of the lvwIssueList control.
		/// Display the description of the Issue selected.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void lvwIssueList_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lvwIssueList.SelectedItems.Count > 0)
			{
				wbrDescription.DocumentText = ((FeedItem)lvwIssueList.SelectedItems[0].Tag).Content;
			}
		}

		/// <summary>
		/// Handles the ItemChecked event of the lvwIssueList control.
		/// Enables and Disables the Open Redmine and Time Entry buttons.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.Windows.Forms.ItemCheckedEventArgs"/> instance containing the event data.</param>
		private void lvwIssueList_ItemChecked(object sender, ItemCheckedEventArgs e)
		{
			if (lvwIssueList.CheckedItems.Count > 0)
			{
				btnOpenRedmine.Enabled = true;
				btnTimeEntry.Enabled = true;
			}
			else
			{
				btnOpenRedmine.Enabled = false;
				btnTimeEntry.Enabled = false;
			}
		}

		private void lvwIssueList_ColumnClick(object sender, ColumnClickEventArgs e)
		{
			// Determine if clicked column is already the column that is being sorted.
			if (e.Column == lvwColumnSorter.SortColumn)
			{
				// Reverse the current sort direction for this column.
				lvwColumnSorter.Order = lvwColumnSorter.Order == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
			}
			else
			{
				// Set the column number that is to be sorted; default to ascending.
				lvwColumnSorter.SortColumn = e.Column;
				lvwColumnSorter.Order = SortOrder.Ascending;
			}

			//Reset sort icon on all columns
			foreach (ColumnHeader column in lvwIssueList.Columns)
			{
				column.ImageKey = String.Empty;
			}
			
			//Set sort icon
			switch (lvwColumnSorter.Order)
			{
				case SortOrder.Ascending:
					lvwIssueList.Columns[e.Column].ImageKey = ArrowUpImage;
					break;
				case SortOrder.Descending:
					lvwIssueList.Columns[e.Column].ImageKey = ArrowDownImage;
					break;
				default:
					lvwIssueList.Columns[e.Column].ImageKey = String.Empty;
					break;
			}

			// Perform the sort with these new sort options.
			lvwIssueList.Sort();
		}

		private void resetIssueListDisplayToolStripMenuItem_Click(object sender, EventArgs e)
		{
			selectedSearchField = cboFields.SelectedItem;

			//Restore Default Column order
			foreach (ColumnHeader column in lvwIssueList.Columns)
			{
				column.DisplayIndex = column.Index;
				column.Tag = null;
				column.Width = -1;
			}

			//Restore Default sort
			lvwColumnSorter.SortColumn = 6; //LastUpdated Column
			lvwColumnSorter.Order = SortOrder.Descending;
			lvwIssueList.Sort();

			//Redo search
			txtSearch_TextChanged(sender, e);

			//Refill field list
			fillFieldList();
		}

		private void chooseColumnsToDisplayToolStripMenuItem_Click(object sender, EventArgs e)
		{
			selectedSearchField = cboFields.SelectedItem;

			var chooser = new ColumnChooser { CurrentColumnsCollection = lvwIssueList.Columns };
			chooser.ShowDialog(this);

			//Redo search
			txtSearch_TextChanged(sender, e);

			//Refill field list
			fillFieldList();
		}

		private void lvwIssueList_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
		{
			//If this is not a hidden field then return
			if (lvwIssueList.Columns[e.ColumnIndex].Tag == null || lvwIssueList.Columns[e.ColumnIndex].Tag.ToString() != HiddenTag)
			{
				return;
			}

			//Set new width back to 0 and cancel UI display of resizing
			e.NewWidth = 0;
			e.Cancel = true;
		}

		private void lvwIssueList_ColumnWidthChanged(object sender, ColumnWidthChangedEventArgs e)
		{
			//If this is not a hidden field then return
			if (lvwIssueList.Columns[e.ColumnIndex].Tag == null || lvwIssueList.Columns[e.ColumnIndex].Tag.ToString() != HiddenTag)
			{
				return;
			}

			//Make sure column is not already 0 width to prevent infinite loop.
			if (lvwIssueList.Columns[e.ColumnIndex].Width != 0)
			{
				lvwIssueList.Columns[e.ColumnIndex].Width = 0;
			}
		}

		private void chkIncludeSummary_CheckedChanged(object sender, EventArgs e)
		{
			IncludeSummary = chkIncludeSummary.Checked;
		}

		private void cboFields_SelectedIndexChanged(object sender, EventArgs e)
		{
			//Redo search
			txtSearch_TextChanged(sender, e);
		}
		#endregion

		#region Version Check

		/// <summary>
		/// Async Check for new version.
		/// </summary>
		private void checkForNewVersion()
		{
			var delVersionCheck = new CheckForNewVersionDelegate(VersionCheck.IsNewVersionAvailable);

			delVersionCheck.BeginInvoke(checkForNewVersionCallback, null);
		}
		
		/// <summary>
		/// Delegate for Async check for new version. 
		/// </summary>
		private delegate bool CheckForNewVersionDelegate();

		/// <summary>
		/// Callback function for Async check for new version.
		/// </summary>
		/// <param name="ar">The Async Result.</param>
		private void checkForNewVersionCallback(IAsyncResult ar)
		{
			try
			{
				// first cast IAsyncResult to an AsyncResult object, so we can get the
				// delegate that was used to call the function.
				var result = (AsyncResult)ar;

				// grab the delegate
				var delVersionCheck = (CheckForNewVersionDelegate)result.AsyncDelegate;

				// now that we have the delegate, we must call EndInvoke on it,
				// so we can get all the information about our method call.
				var returnValue = delVersionCheck.EndInvoke(ar);

				//Set the Update Available label based on the return value
				lblUpdateAvailable.Visible = returnValue;
			}
			catch (Exception ex)
			{
				lblUpdateCheckFailed.Visible = true;
				lblUpdateCheckFailed.ToolTipText = ex.Message;
			}

			if (!lblUpdateAvailable.Visible && !lblUpdateCheckFailed.Visible)
			{
				//If no new version available and new version check didn't fail disable flashing color
				tmrNewVersion.Enabled = false;
			}
		}

		/// <summary>
		/// Handles the Tick event of the tmrNewVersion control.
		/// Toggles the color of the UpdateAvailable label to make it more noticeable.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void tmrNewVersion_Tick(object sender, EventArgs e)
		{


			if (lblUpdateAvailable.Visible)
			{
				var lightGreen = Color.FromArgb(192, 255, 192);
				var brightGreen = Color.FromArgb(28, 255, 28);

				lblUpdateAvailable.BackColor = lblUpdateAvailable.BackColor == lightGreen ? brightGreen : lightGreen;	        
			}

			if (lblUpdateCheckFailed.Visible)
			{
				var lightRed = Color.FromArgb(255, 192, 192);
				var brightRed = Color.FromArgb(255, 28, 28);

				lblUpdateCheckFailed.BackColor = lblUpdateCheckFailed.BackColor == lightRed ? brightRed : lightRed;
			}
		}

		#endregion

		#endregion
	}
}