namespace TurtleMine.Settings
{
	/// <summary>The Connection Authentication Method</summary>
	[System.SerializableAttribute]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public class Authentication
	{
		/// <summary>The Authentication type, either <c>bool</c> or <c>ProvidedCredentials</c></summary>
		[System.Xml.Serialization.XmlElementAttribute("CurrentUser", typeof(bool)),
		System.Xml.Serialization.XmlElementAttribute("ProvidedCredentials", typeof(ProvidedCredentials))]
		public object Item { get; set; }
	}
}