namespace TurtleMine.Settings
{
	/// <summary>
	/// The Source Control type
	/// </summary>
	[System.SerializableAttribute]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public enum ProjectScType
	{

		/// <summary>Subversion</summary>
		SVN,

		/// <summary>Git</summary>
		GIT,

		/// <summary>Mecurial</summary>
		HG,
	}
}