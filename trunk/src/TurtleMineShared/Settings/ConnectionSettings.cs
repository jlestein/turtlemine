namespace TurtleMine.Settings
{
	/// <summary>Connection Settings</summary>
	[System.SerializableAttribute]
	public class ConnectionSettings
	{
		private Proxy proxyField;

		private Authentication authenticationField;

		/// <summary>Connection Proxy Settings</summary>
		public Proxy Proxy
		{
			get { return proxyField ?? (proxyField = new Proxy()); }
			set { proxyField = value; }
		}

		/// <summary>Connection Authentication Type</summary>
		public Authentication Authentication
		{
			get { return authenticationField ?? (authenticationField = new Authentication()); }
			set { authenticationField = value; }
		}

		/// <summary>The path to the SSL Certificate to use</summary>
		public string SSLCertPath { get; set; }

		/// <summary>Test whether <see cref="SSLCertPath"/> should be serialized</summary>
		public bool ShouldSerializeSSLCertPath()
		{
			return !string.IsNullOrEmpty(SSLCertPath);
		}
	}
}