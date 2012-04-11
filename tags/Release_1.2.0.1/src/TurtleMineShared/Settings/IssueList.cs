namespace TurtleMine.Settings
{
	/// <summary>An Issue List</summary>
	[System.SerializableAttribute]
	public class IssueList
	{
		/// <summary>Identifiying Name for the issue list</summary>
		public string Name { get; set; }

		/// <summary>The URL to the issue list</summary>
		[System.Xml.Serialization.XmlElementAttribute(DataType="anyURI")]
		public string URL { get; set; }
	}
}