namespace TurtleMine.Settings
{
	/// <summary>
	/// The type of update check to do
	/// </summary>
	[System.SerializableAttribute]
	[System.Xml.Serialization.XmlTypeAttribute(IncludeInSchema = false)]
	public enum UpdateInterval
	{
		/// <summary>Do not auto check for updates</summary>
		NoAutoCheck,

		/// <summary>Check daily for updates</summary>
		CheckDaily,

		/// <summary>Check weekly for updates</summary>
		CheckWeekly,

		/// <summary>Check Every Startup for updates</summary>
		CheckEveryStartup,
	}
}
