/*
 * See : http://support.microsoft.com/kb/319401
 * For details of the code below and it's implementation
 * The code below has been modifed to meet the needs of this application
 */

using System;
using System.Collections;
using System.Threading;
using System.Windows.Forms;

namespace TurtleMine
{
    /// <summary>
    /// This class is an implementation of the <c>IComparer</c> interface.
    /// </summary>
    internal class ListViewColumnSorter : IComparer
    {
        #region Members

        /// <summary>
        /// Case insensitive comparer object
        /// </summary>
        private readonly CaseInsensitiveComparer objectCompare;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ListViewColumnSorter"/> class.
        /// </summary>
        public ListViewColumnSorter()
        {
            // Initialize the column to '0'
            SortColumn = 0;

            // Initialize the sort order to 'none'
            Order = SortOrder.None;

            // Initialize the CaseInsensitiveComparer object
            objectCompare = new CaseInsensitiveComparer(Thread.CurrentThread.CurrentCulture);
        }

        #endregion


        #region Properties

        /// <summary>
        /// Gets or sets the number of the column to which to apply the sorting operation (Defaults to '0').
        /// </summary>
        public int SortColumn { get; set; }

        /// <summary>
        /// Gets or sets the order of sorting to apply (for example, 'Ascending' or 'Descending').
        /// </summary>
        public SortOrder Order { get; set; }

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
            // Cast the objects to be compared to ListViewItem objects
            var listviewX = (ListViewItem)x;
            var listviewY = (ListViewItem)y;


            // Determine sort type and Compare the two items
            int compareResult;
            if (listviewX.ListView.Columns[SortColumn].Name != null)
            {
                try
                {
                    switch ((ColumnType)Enum.Parse(typeof(ColumnType), listviewX.ListView.Columns[SortColumn].Name))
                    {
                        case ColumnType.Text:
                            compareResult = objectCompare.Compare(listviewX.SubItems[SortColumn].Text, listviewY.SubItems[SortColumn].Text);
                            break;
                        case ColumnType.Numeric:
                            compareResult = objectCompare.Compare(Int32.Parse(listviewX.SubItems[SortColumn].Text), Int32.Parse(listviewY.SubItems[SortColumn].Text));
                            break;
                        case ColumnType.DateTime:
                            compareResult = objectCompare.Compare(DateTime.Parse(listviewX.SubItems[SortColumn].Text), DateTime.Parse(listviewY.SubItems[SortColumn].Text));
                            break;
                        default:
                            return 0;
                    }
                }
                catch
                {
                    //unable to read tag into ColumnType so just use text sort
                    compareResult = objectCompare.Compare(listviewX.SubItems[SortColumn].Text, listviewY.SubItems[SortColumn].Text);
                }
            }
            else
            {
                compareResult = objectCompare.Compare(listviewX.SubItems[SortColumn].Text, listviewY.SubItems[SortColumn].Text);
            }


            // Calculate correct return value based on object comparison
            switch (Order)
            {
                case SortOrder.Ascending:  // Ascending sort is selected, return normal result of compare operation
                    return compareResult;
                case SortOrder.Descending: // Descending sort is selected, return negative result of compare operation
                    return (-compareResult);
                default:                   // Return '0' to indicate they are equal
                    return 0;
            }
        }

        #endregion
        
        /// <summary>
        /// Specifies the column type for sorting
        /// </summary>
        public enum ColumnType
        {
            /// <summary>
            /// Indicates the Column contains Text based data
            /// </summary>
            Text = 0,

            /// <summary>
            /// Indicates the Column contains Numerical based data
            /// </summary>
            Numeric = 1,

            /// <summary>
            /// Indicates the Column contains DateTime based data
            /// </summary>
            DateTime = 2,

            /// <summary>
            /// Indicates the Column contains other or unknown type data
            /// </summary>
            Other = 3
        }
    }
}
