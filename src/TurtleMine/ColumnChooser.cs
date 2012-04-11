using System;
using System.Collections;
using System.Threading;
using System.Windows.Forms;
using TurtleMine.Resources;

namespace TurtleMine
{
    /// <summary>
    /// Allows for selection of Columns to display
    /// </summary>
    public partial class ColumnChooser : Form
    {
        #region Members

        private const string HiddenTag = "hidden";

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ColumnChooser"/> class.
        /// </summary>
        public ColumnChooser()
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

        private void columnChooser_Load(object sender, EventArgs e)
        {
            //Set which ColumnHeader property to display
            lstCurrent.DisplayMember = "Text";
            lstAvailable.DisplayMember = "Text";

            foreach (ColumnHeader column in CurrentColumnsCollection)
            {
                if (string.IsNullOrEmpty(column.Text.Trim()))
                {
                    continue;
                }

                var item = new ListBoxItem {Text = column.Text, Column = column, DisplayIndex = column.DisplayIndex};


                if (column.Tag != null && column.Tag.ToString() == HiddenTag)
                {
                    lstAvailable.Items.Add(item);
                }
                else
                {
                    lstCurrent.Items.Add(item);
                }
            }
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            moveItem(lstCurrent, lstAvailable);
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            moveItem(lstAvailable, lstCurrent);
        }

        /// <summary>
        /// Moves the selected items from the origin to the destination.
        /// </summary>
        /// <param name="origin">The origin.</param>
        /// <param name="destination">The destination.</param>
        private static void moveItem(ListBox origin, ListBox destination)
        {
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
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            //If nothing left in current listbox then notify of error
            if (lstCurrent.Items.Count == 0)
            {
                MessageBox.Show(Strings.ErrorColumnRequiredMessage, Strings.ErrorColumnRequiredTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //Hide items selected as hidden
            foreach (ListBoxItem item in lstAvailable.Items)
            {
                item.Column.Tag = HiddenTag;
                item.Column.Width = 0;
            }

            //Show all other items
            foreach (ListBoxItem item in lstCurrent.Items)
            {
                item.Column.Tag = null;
                if (item.Column.Width == 0)
                {
                    item.Column.Width = -1;
                }
            }
            
            Close();
        }

        #endregion
    }
}
