using System.Collections;
using System.Threading;
using System.Windows.Forms;

namespace TRMIssues
{
    /// <summary>
    /// Provides a custom Listbox item containing a columnHeader as well as a sortable DisplayIndex and Text property.
    /// </summary>
    internal class ListBoxItem : IComparer
    {
        #region Members

        /// <summary>
        /// Case insensitive comparer object
        /// </summary>
        private readonly CaseInsensitiveComparer objectCompare;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the Column Header
        /// </summary>
        /// <value>The column.</value>
        public ColumnHeader Column { get; set; }


        /// <summary>
        /// Gets or sets the Column display index
        /// </summary>
        /// <value>The display index.</value>
        public int DisplayIndex { get; set; }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>The text.</value>
        public string Text { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ListBoxItem"/> class.
        /// </summary>
        public ListBoxItem()
        {
            // Initialize the CaseInsensitiveComparer object
            objectCompare = new CaseInsensitiveComparer(Thread.CurrentThread.CurrentCulture);
        }

        #endregion

        #region IComparer Implementation

        /// <summary>
        /// Compares two objects and returns a value indicating whether one is less than, equal to, or greater than the other.
        /// It compares the two objects passed using a case insensitive comparison.
        /// </summary>
        /// <returns>
        /// Value 
        ///                     Condition 
        ///                     Less than zero 
        ///                 <paramref name="x"/> is less than <paramref name="y"/>. 
        ///                     Zero 
        ///                 <paramref name="x"/> equals <paramref name="y"/>. 
        ///                     Greater than zero 
        ///                 <paramref name="x"/> is greater than <paramref name="y"/>. 
        /// </returns>
        /// <param name="x">The first object to compare. 
        ///                 </param><param name="y">The second object to compare. 
        ///                 </param><exception cref="T:System.ArgumentException">Neither <paramref name="x"/> nor <paramref name="y"/> implements the <see cref="T:System.IComparable"/> interface.
        ///                     -or- 
        ///                 <paramref name="x"/> and <paramref name="y"/> are of different types and neither one can handle comparisons with the other. 
        ///                 </exception><filterpriority>2</filterpriority>
        public int Compare(object x, object y)
        {
            // Cast the objects to be compared to ListBoxItem objects
            var listBoxX = (ListBoxItem)x;
            var listBoxY = (ListBoxItem)y;

            // Sort numerically by DisplayIndex
            var compareResult = objectCompare.Compare(listBoxX.DisplayIndex, listBoxY.DisplayIndex);

            return compareResult;

        }

        #endregion
    }

}
