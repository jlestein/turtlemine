using System.Collections.Generic;

namespace TurtleMine.Settings
{
	/// <summary>A Projects configuration</summary>
	[System.SerializableAttribute]
	public class Project
	{
		private List<IssueList> issueListsField;

		private ConnectionSettings connectivityField;

		private List<string> wordsField;

		private List<ColumnListColumn> columnsField;

		/// <summary>The Repository Identifiying Name</summary>
		public string RepoName { get; set; }

		/// <summary>The Path of disk to the Repository</summary>
		public string RepoPath { get; set; }

		/// <summary>The Source Control Type</summary>
		public ProjectScType SCType { get; set; }

		/// <summary>Determines if an Issue number is required in the Commit message for the project</summary>
		public bool? RequireIssueNumber { get; set; }

		/// <summary>Test whether <see cref="RequireIssueNumber"/> should be serialized</summary>
		public bool ShouldSerializeRequireIssueNumber()
		{
			return RequireIssueNumber.HasValue;
		}

		/// <summary>The Issue Lists that apply to this project</summary>
		[System.Xml.Serialization.XmlArrayItemAttribute(IsNullable = false)]
		public List<IssueList> IssueLists
		{
			get { return issueListsField ?? (issueListsField = new List<IssueList>()); }
			set { issueListsField = value; }
		}

		/// <summary>Test whether <see cref="IssueLists"/> should be serialized</summary>
		public virtual bool ShouldSerializeIssueLists()
		{
			return issueListsField != null && issueListsField.Count > 0;
		}

		/// <summary>Connection Settings for this project</summary>
		public ConnectionSettings Connectivity
		{
			get { return connectivityField ?? (connectivityField = new ConnectionSettings()); }
			set { connectivityField = value; }
		}

		/// <summary>Test whether <see cref="Connectivity"/> should be serialized</summary>
		public virtual bool ShouldSerializeConnectivity()
		{
			return connectivityField != null;
		}

		/// <summary>The list of words to appear as identifiers for an issue</summary>
		[System.Xml.Serialization.XmlArrayItemAttribute("Word", IsNullable = false)]
		public List<string> Words
		{
			get { return wordsField ?? (wordsField = new List<string>()); }
			set { wordsField = value; }
		}

		/// <summary>Test whether <see cref="Words"/> should be serialized</summary>
		public virtual bool ShouldSerializeWords()
		{
			return wordsField != null && wordsField.Count > 0;
		}

		/// <summary>The list of columns to display</summary>
		[System.Xml.Serialization.XmlArrayItemAttribute("Column", IsNullable = false)]
		public List<ColumnListColumn> Columns
		{
			get { return columnsField ?? (columnsField = new List<ColumnListColumn>()); }
			set { columnsField = value; }
		}

		/// <summary>Test whether <see cref="Columns"/> should be serialized</summary>
		public virtual bool ShouldSerializeColumns()
		{
			return columnsField != null && columnsField.Count > 0;
		}
	}
}