namespace TurtleMine.Settings
{
	/// <summary>Connection Provided Credentials</summary>
	[System.SerializableAttribute]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public class ProvidedCredentials
	{
		private string passwordField;

		/// <summary>The Provided UserName</summary>
		[System.Xml.Serialization.XmlAttributeAttribute]
		public string Username { get; set; }



		//TODO: Override serialization to so serializes as encrypted string.

		/// <summary>The Provided Password</summary>
		[System.Xml.Serialization.XmlAttributeAttribute]
		public string Password
		{
			get
			{
				return CryptoEngine.Encrypt(passwordField);
			}
			set
			{
				passwordField = CryptoEngine.Decrypt(value);
			}
		}

		/// <summary>The Provided Password - Encrypted</summary>
		[System.Xml.Serialization.XmlIgnoreAttribute]
		public string PasswordText
		{
			get
			{
				return CryptoEngine.Decrypt(passwordField);
			}
			set
			{
				passwordField = CryptoEngine.Encrypt(value);
			}
		}

		/// <summary>True, if credentials provided, else false</summary>
		[System.Xml.Serialization.XmlTextAttribute]
		public bool Value { get; set; }
	}
}