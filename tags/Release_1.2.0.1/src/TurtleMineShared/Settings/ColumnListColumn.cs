using System.Windows.Forms;
using TurtleMine.Resources;

namespace TurtleMine.Settings
{
	/// <summary>Describes a column in the column list</summary>
	[System.SerializableAttribute]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public class ColumnListColumn
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ColumnListColumn"/> class.
		/// </summary>
		public ColumnListColumn() {}

		/// <summary>
		/// Initializes a new instance of the <see cref="ColumnListColumn"/> class.
		/// </summary>
		/// <param name="index">The index.</param>
		/// <param name="displayindex">The displayindex.</param>
		/// <param name="hidden">if set to <c>true</c> [hidden].</param>
		public ColumnListColumn(int index, int displayindex, bool hidden)
		{
			Index = index;
			DisplayIndex = displayindex;
			Hidden = hidden;
		}

		/// <summary>The Display Index of the column</summary>
		[System.Xml.Serialization.XmlAttributeAttribute]
		public int DisplayIndex { get; set; }

		/// <summary>Indicates if the column should be hidden</summary>
		[System.Xml.Serialization.XmlAttributeAttribute]
		public bool Hidden { get; set; }

		/// <summary>The Column Index</summary>
		[System.Xml.Serialization.XmlTextAttribute]
		public int Index { get; set; }

		/// <summary>Provides a ColumnHeaderCollection with the Default Headers</summary>
		public static ListView.ColumnHeaderCollection DefaultHeaders()
		{
			var listView = new ListView();

			listView.Columns.Add(ListViewColumnSorter.ColumnType.Other.ToString(), "  ");
			listView.Columns.Add(ListViewColumnSorter.ColumnType.Numeric.ToString(), Strings.ColumnNumber);
			listView.Columns.Add(ListViewColumnSorter.ColumnType.Text.ToString(), Strings.ColumnType);
			listView.Columns.Add(ListViewColumnSorter.ColumnType.Text.ToString(), Strings.ColumnSummary);
			listView.Columns.Add(ListViewColumnSorter.ColumnType.Text.ToString(), Strings.ColumnStatus);
			listView.Columns.Add(ListViewColumnSorter.ColumnType.Text.ToString(), Strings.ColumnAuthor);
			listView.Columns.Add(ListViewColumnSorter.ColumnType.DateTime.ToString(), Strings.ColumnLastUpdated);

			for (var i = 0; i < listView.Columns.Count; i++)
			{
				listView.Columns[i].Tag = i;
			}

			return listView.Columns;
		}

		/// <summary>Provides a ColumnHeaderCollection with the Default Headers</summary>
		/// <param name="listView">The list view to set the column headers for.</param>
		public static void DefaultHeaders(ListView listView)
		{
			listView.Columns.Add(ListViewColumnSorter.ColumnType.Other.ToString(), "  ");
			listView.Columns.Add(ListViewColumnSorter.ColumnType.Numeric.ToString(), Strings.ColumnNumber);
			listView.Columns.Add(ListViewColumnSorter.ColumnType.Text.ToString(), Strings.ColumnType);
			listView.Columns.Add(ListViewColumnSorter.ColumnType.Text.ToString(), Strings.ColumnSummary);
			listView.Columns.Add(ListViewColumnSorter.ColumnType.Text.ToString(), Strings.ColumnStatus);
			listView.Columns.Add(ListViewColumnSorter.ColumnType.Text.ToString(), Strings.ColumnAuthor);
			listView.Columns.Add(ListViewColumnSorter.ColumnType.DateTime.ToString(), Strings.ColumnLastUpdated);

			for (var i = 0; i < listView.Columns.Count; i++)
			{
				listView.Columns[i].Tag = i;
			}
		}
	}
}