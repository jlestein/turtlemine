namespace TurtleMine.Settings
{
	/// <summary>The type of proxy server connection to use</summary>
	[System.SerializableAttribute]
	[System.Xml.Serialization.XmlTypeAttribute(IncludeInSchema = false)]
	public enum ProxyType
	{

		/// <summary>A Manual configuration</summary>
		ManualProxy,

		/// <summary>No Proxy server</summary>
		NoProxy,

		/// <summary>The Windows default settings</summary>
		WindowsProxy,
	}
}