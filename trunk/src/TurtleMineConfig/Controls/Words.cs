using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using TurtleMine.Resources;
using TurtleMine.Settings;

namespace TurtleMine.Controls
{
	/// <summary>
	/// Choose Words to appear in list of optional words to prefix the issue number with.
	/// </summary>
	public partial class Words : Template
	{
		#region Constructor
		
		/// <summary>
		/// Initializes a new instance of the <see cref="Words"/> class.
		/// </summary>
		public Words()
		{
			Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;
			InitializeComponent();
		}

		#endregion

		#region Properties

		/// <summary>
		/// Gets or sets the list of all currently displayed words.
		/// </summary>
		/// <value>The word list.</value>
		public List<string> CurrentWordsCollection { get; set; }

		#endregion

		#region Methods

		private void Words_Load(object sender, EventArgs e)
		{
			//Load saved or default columns
			getSettings();

			loadList();
		}

		private void btnUp_Click(object sender, EventArgs e)
		{
			arrangeItem(Direction.Up);
		}

		private void btnDown_Click(object sender, EventArgs e)
		{
			arrangeItem(Direction.Down);
		}

		private void arrangeItem(Direction direction)
		{
			if (lstWordList.SelectedItems.Count <= 0) return;

			var selected = (ListBoxItem)lstWordList.SelectedItem;

			if (direction == Direction.Up)
			{
				selected.DisplayIndex--;
				//Get previous item
				var previous = (ListBoxItem)lstWordList.Items[lstWordList.SelectedIndex - 1];
				previous.DisplayIndex++;
			}

			if (direction == Direction.Down)
			{
				selected.DisplayIndex++;
				//Get next item
				var next = (ListBoxItem)lstWordList.Items[lstWordList.SelectedIndex + 1];
				next.DisplayIndex--;
			}

			//Create ArrayList of current items
			var originList = new ArrayList(lstWordList.Items);

			//Comparer for sorting
			var comparer = new ListBoxItem();

			//Clear and repopulate origin Listbox sorted
			originList.Sort(comparer);
			lstWordList.Items.Clear();
			lstWordList.Items.AddRange(originList.ToArray());

			//Reselect item
			lstWordList.SelectedItem = selected;

			PropertyChanged = true;
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			var value = string.Empty;
			if (InputBox(Strings.AddWord_Title, Strings.AddWord, ref value) != DialogResult.OK) return;

			if (string.IsNullOrEmpty(value.Trim()))
			{
				value = Strings.NoneText;
			}

			lstWordList.Items.Add(new ListBoxItem { Text = value, DisplayIndex = lstWordList.Items.Count + 1 });

			PropertyChanged = true;
		}

		public static DialogResult InputBox(string title, string promptText, ref string value)
		{
			var form = new Form();
			var label = new Label();
			var textBox = new TextBox();
			var buttonOk = new Button();
			var buttonCancel = new Button();

			form.Text = title;
			label.Text = promptText;
			textBox.Text = value;

			buttonOk.Text = DialogResult.OK.ToString();
			buttonCancel.Text = DialogResult.Cancel.ToString();
			buttonOk.DialogResult = DialogResult.OK;
			buttonCancel.DialogResult = DialogResult.Cancel;

			label.SetBounds(9, 20, 372, 13);
			textBox.SetBounds(12, 36, 372, 20);
			buttonOk.SetBounds(228, 72, 75, 23);
			buttonCancel.SetBounds(309, 72, 75, 23);

			label.AutoSize = true;
			textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
			buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

			form.ClientSize = new Size(396, 107);
			form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
			form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
			form.FormBorderStyle = FormBorderStyle.FixedDialog;
			form.StartPosition = FormStartPosition.CenterScreen;
			form.MinimizeBox = false;
			form.MaximizeBox = false;
			form.AcceptButton = buttonOk;
			form.CancelButton = buttonCancel;

			var dialogResult = form.ShowDialog();
			value = textBox.Text;
			return dialogResult;
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			//Confirm
			if (MessageBox.Show(this, Strings.Confirm_Delete, Strings.Confirm_Delete_Title, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Cancel)
			{
				return;
			}

			if (lstWordList.SelectedIndices.Count <= 0)
			{
				return;
			}

			lstWordList.Items.Remove(lstWordList.SelectedItem);

			PropertyChanged = true;
		}

		private void lstWordList_SelectedIndexChanged(object sender, EventArgs e)
		{
			btnUp.Enabled = lstWordList.SelectedIndex != 0;
			btnDown.Enabled = lstWordList.SelectedIndex != lstWordList.Items.Count - 1;
		}

		/// <summary>Loads the list views.</summary>
		private void loadList()
		{
			lstWordList.Items.Clear();

			//Set which property to display
			lstWordList.DisplayMember = "Text";

			for (var i = 0; i < CurrentWordsCollection.Count; i++)
			{
				var word = CurrentWordsCollection[i];
				if (string.IsNullOrEmpty(word.Trim()))
				{
					lstWordList.Items.Add(new ListBoxItem {Text = Strings.NoneText, DisplayIndex = i});
					continue;
				}

				lstWordList.Items.Add(new ListBoxItem {Text = word, DisplayIndex = i});
			}
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
			//If nothing left in the listbox then notify of error
			if (lstWordList.Items.Count == 0)
			{
				MessageBox.Show(Strings.ErrorWordRequiredMessage, Strings.ErrorWordRequiredTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}

			//Clear current list first
			SettingsManager.Settings.Words.Clear();

			//Add Words
			foreach (ListBoxItem item in lstWordList.Items)
			{
				SettingsManager.Settings.Words.Add(item.Text);
			}
		}

		internal override void getSettings()
		{
			if (SettingsManager.Settings.Words.Count == 0)
			{
				//Get Default column list
				CurrentWordsCollection = WordList.DefaultWords();
				return;
			}

			CurrentWordsCollection = SettingsManager.Settings.Words;
		}

		#endregion
	}
}
