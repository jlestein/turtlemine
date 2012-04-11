using System;
using System.Collections;
using System.Threading;
using System.Windows.Forms;
using TurtleMine.Resources;
using TurtleMine.Settings;

namespace TurtleMine.Controls
{
	/// <summary>
	/// Arrange columns for display
	/// </summary>
	public partial class Columns : Template
	{
		#region Constructor
		
		/// <summary>
		/// Initializes a new instance of the <see cref="Columns"/> class.
		/// </summary>
		public Columns()
		{
			Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;
			InitializeComponent();
		}

		#endregion

		#region Properties

		/// <summary>
		/// Gets or sets the list of all currently displayed columns.
		/// </summary>
		/// <value>The column list.</value>
		public ListView.ColumnHeaderCollection CurrentColumnsCollection { get; set; }

		#endregion

		#region Methods

		private void Columns_Load(object sender, EventArgs e)
		{
			//Load saved or default columns
			getSettings();

			loadLists();
		}

		private void btnLeft_Click(object sender, EventArgs e)
		{
			moveItem(lstCurrent, lstAvailable);
		}

		private void btnRight_Click(object sender, EventArgs e)
		{
			moveItem(lstAvailable, lstCurrent);
		}

		private void btnUp_Click(object sender, EventArgs e)
		{
			arrangeItem(Direction.Up);
		}

		private void btnDown_Click(object sender, EventArgs e)
		{
			arrangeItem(Direction.Down);
		}


		private void btnReset_Click(object sender, EventArgs e)
		{
			//Confirm
			if (MessageBox.Show(Strings.Confirm_Reset, Strings.Confirm_Reset_Title, MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Cancel)
			{
				return;
			}

			//Reset to default
			CurrentColumnsCollection = ColumnListColumn.DefaultHeaders();
			loadLists();

			PropertyChanged = true;
		}

		/// <summary>Loads the list views.</summary>
		private void loadLists()
		{
			lstCurrent.Items.Clear();
			lstAvailable.Items.Clear();
	
			//Set which ColumnHeader property to display
			lstCurrent.DisplayMember = "Text";
			lstAvailable.DisplayMember = "Text";

			foreach (ColumnHeader column in CurrentColumnsCollection)
			{
				if (string.IsNullOrEmpty(column.Text.Trim()))
				{
					continue;
				}

				var item = new ListBoxItem { Text = column.Text, Column = column, DisplayIndex = column.DisplayIndex };


				if (column.Tag != null && int.Parse(column.Tag.ToString()) < 0)
				{
					lstAvailable.Items.Add(item);
				}
				else
				{
					lstCurrent.Items.Add(item);
				}
			}
		}

		/// <summary>
		/// Moves the selected items from the origin to the destination.
		/// </summary>
		/// <param name="origin">The origin.</param>
		/// <param name="destination">The destination.</param>
		private void moveItem(ListBox origin, ListBox destination)
		{
			if (origin.SelectedItems.Count <= 0) return;

			//Create ArrayList of current items
			var originList = new ArrayList(origin.Items);

			//Create ArrayList of destination items
			var destinationList = new ArrayList(destination.Items);
			
			//Add selected items from origin listbox to destination list
			foreach (ListBoxItem item in origin.SelectedItems)
			{
				destinationList.Add(item);
			}

			//remove the selected items from the origin list
			foreach (var item in origin.SelectedItems)
			{
				originList.Remove(item);
			}

			//Comparer for sorting
			var comparer = new ListBoxItem();

			//Clear and repopulate origin Listbox sorted
			originList.Sort(comparer);
			origin.Items.Clear();
			origin.Items.AddRange(originList.ToArray());

			//Clear and repopulate destination Listbox sorted
			destinationList.Sort(comparer);
			destination.Items.Clear();
			destination.Items.AddRange(destinationList.ToArray());

			PropertyChanged = true;
		}

		private void arrangeItem(Direction direction)
		{
			if (lstCurrent.SelectedItems.Count <= 0) return;

			var selected = (ListBoxItem)lstCurrent.SelectedItem;

			if (direction == Direction.Up)
			{
				selected.DisplayIndex--;
				//Get previous item
				var previous = (ListBoxItem) lstCurrent.Items[lstCurrent.SelectedIndex - 1];
				previous.DisplayIndex++;
			}

			if (direction == Direction.Down)
			{
				selected.DisplayIndex++;
				//Get next item
				var next = (ListBoxItem)lstCurrent.Items[lstCurrent.SelectedIndex + 1];
				next.DisplayIndex--;
			}

			//Create ArrayList of current items
			var originList = new ArrayList(lstCurrent.Items);

			//Comparer for sorting
			var comparer = new ListBoxItem();

			//Clear and repopulate origin Listbox sorted
			originList.Sort(comparer);
			lstCurrent.Items.Clear();
			lstCurrent.Items.AddRange(originList.ToArray());

			//Reselect item
			lstCurrent.SelectedItem = selected;

			PropertyChanged = true;
		}

		private void lstCurrent_SelectedIndexChanged(object sender, EventArgs e)
		{
			btnUp.Enabled = lstCurrent.SelectedIndex != 0;
			btnDown.Enabled = lstCurrent.SelectedIndex != lstCurrent.Items.Count - 1;
		}

		private enum Direction
		{
			Up,
			Down
		}

		#endregion

		#region Settings

		public override void ApplyChanges()
		{
			//If nothing left in current listbox then notify of error
			if (lstCurrent.Items.Count == 0)
			{
				MessageBox.Show(Strings.ErrorColumnRequiredMessage, Strings.ErrorColumnRequiredTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}

			//Clear current list first
			SettingsManager.Settings.Columns.Clear();

			//Hide items selected as hidden
			foreach (ListBoxItem item in lstAvailable.Items)
			{
				SettingsManager.Settings.Columns.Add(new ColumnListColumn(Math.Abs((int)item.Column.Tag), item.DisplayIndex, true));
			}

			//Show all other items
			foreach (ListBoxItem item in lstCurrent.Items)
			{
				SettingsManager.Settings.Columns.Add(new ColumnListColumn(Math.Abs((int)item.Column.Tag), item.DisplayIndex, false));
			}
		}


		internal override void getSettings()
		{
			if (SettingsManager.Settings.Columns.Count == 0)
			{
				//Get Default column list
				CurrentColumnsCollection = ColumnListColumn.DefaultHeaders();
				return;
			}

			var listView = new ListView();
			foreach (ColumnListColumn column in SettingsManager.Settings.Columns)
			{
				var columnHeader = new ColumnHeader();
				switch (column.Index)
				{
					case 1:
						columnHeader.Text = Strings.ColumnNumber;
						break;
					case 2:
						columnHeader.Text = Strings.ColumnType;
						break;
					case 3:
						columnHeader.Text = Strings.ColumnSummary;
						break;
					case 4:
						columnHeader.Text = Strings.ColumnStatus;
						break;
					case 5:
						columnHeader.Text = Strings.ColumnAuthor;
						break;
					case 6:
						columnHeader.Text = Strings.ColumnLastUpdated;
						break;
				}

				columnHeader.DisplayIndex = column.DisplayIndex;
				columnHeader.Tag = column.Hidden ? -1*column.Index : column.Index;

				listView.Columns.Add(columnHeader);
			}

			CurrentColumnsCollection = listView.Columns;
		}

		#endregion
	}
}
