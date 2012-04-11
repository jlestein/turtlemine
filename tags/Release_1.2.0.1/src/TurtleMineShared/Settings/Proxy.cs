namespace TurtleMine.Settings
{
	/// <summary>Connection Settings Proxy information</summary>
	[System.SerializableAttribute]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public class Proxy
	{
		/// <summary>The proxy settings type, either <c>bool</c> or <c>ConnectionSettingsProxyManualProxy</c></summary>
		[System.Xml.Serialization.XmlElementAttribute("ManualProxy", typeof(ManualProxy)),
		System.Xml.Serialization.XmlElementAttribute("NoProxy", typeof(bool)),
		System.Xml.Serialization.XmlElementAttribute("WindowsProxy", typeof(bool)),
		System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemElementName")]
		public object Item { get; set; }

		/// <summary>The Type of proxy settings to use</summary>
		[System.Xml.Serialization.XmlIgnoreAttribute]
		public ProxyType ItemElementName { get; set; }
	}
}