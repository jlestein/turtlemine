namespace TurtleMine.Settings
{
	/// <summary>
	/// Manual Proxy Settings
	/// </summary>
	[System.SerializableAttribute]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	public class ManualProxy
	{
		/// <summary>Proxy Server Address</summary>
		[System.Xml.Serialization.XmlAttributeAttribute]
		public string Address { get; set; }

		/// <summary>Proxy Server Port number</summary>
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="integer")]
		public string Port { get; set; }

		/// <summary>By Proxy server for local addresses</summary>
		[System.Xml.Serialization.XmlAttributeAttribute]
		public bool BypassLocal { get; set; }

		/// <summary>true if Manual Proxy is set, else false.</summary>
		[System.Xml.Serialization.XmlTextAttribute]
		public bool Value { get; set; }
	}
}