using System;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Xml;
using TurtleMine.Settings;

namespace TurtleMine
{
	/// <summary>
	/// Provides shared connection method including proxy configuration
	/// </summary>
	internal class ConnectionHelper
	{
		/// <summary>Gets the default system proxy.</summary>
		/// <returns></returns>
		public static IWebProxy GetDefaultProxy()
		{
			IWebProxy prx = null;
			try
			{
				prx = WebRequest.GetSystemWebProxy();
			}
			catch {} // If failed to get, simply return null.

			return prx;
		}

		/// <summary>
		/// Creates an XML reader from the provided URL with the appropriate configured connection.
		/// </summary>
		/// <param name="url">The URL.</param>
		/// <param name="defaultProxy">The default System proxy which is passed in due to issues retrieving this on a separate thread.</param>
		/// <returns></returns>
		public static XmlReader CreateXmlReader(string url, IWebProxy defaultProxy)
		{
			//Default to use No proxy settings with Windows Authentication
			IWebProxy prox = null;
			var cred = CredentialCache.DefaultCredentials;
			string certPath = null;
			
			//Check settings Manager for values
			SettingsManager.LoadSettings();
			if (SettingsManager.Settings.Connectivity != null)
			{
				//Proxy
				if (SettingsManager.Settings.Connectivity.Proxy.Item != null)
				{
					switch (SettingsManager.Settings.Connectivity.Proxy.ItemElementName)
					{
						case ProxyType.WindowsProxy:
							prox = defaultProxy;
							break;
						case ProxyType.ManualProxy:
							var manproxy = (ManualProxy) SettingsManager.Settings.Connectivity.Proxy.Item;
							prox = new WebProxy
									   {
										   Address = new Uri(manproxy.Address + ":" + manproxy.Port),
										   BypassProxyOnLocal = manproxy.BypassLocal
									   };
							break;
					}
				}

				//Auth
				if (SettingsManager.Settings.Connectivity.Authentication.Item != null && !(SettingsManager.Settings.Connectivity.Authentication.Item is bool))
				{
					var credentials = (ProvidedCredentials) SettingsManager.Settings.Connectivity.Authentication.Item;
					cred = new NetworkCredential(credentials.Username, credentials.Password);
				}

				if (prox != null)
				{
					prox.Credentials = cred;
				}

				//SSL
				certPath = SettingsManager.Settings.Connectivity.SSLCertPath;
			}
			
			//Also pass credentials to web client so it can authenticate against servers that do not allow anonymous connections
			var client = new CertWebClient { Proxy = prox, Credentials = cred, CertPath = certPath };

			//Provide support for SSL by accepting all certificates
			ServicePointManager.ServerCertificateValidationCallback += delegate { return true; };  

			//Read the url
			if (url != null)
			{
				var rmstream = client.OpenRead(url);
				if (rmstream != null)
				{
					var reader = XmlReader.Create(rmstream, new XmlReaderSettings { ProhibitDtd = false, CheckCharacters = false });

					return reader;
				}
			}
			return null;
		}
	}

	internal class CertWebClient : WebClient
	{
		/// <summary>
		/// Gets or sets the certificate path.
		/// </summary>
		/// <value>The certificate path.</value>
		public string CertPath { get; set; }

		/// <summary>
		/// Returns a <see cref="T:System.Net.WebRequest"/> object for the specified resource.
		/// </summary>
		/// <param name="address">A <see cref="T:System.Uri"/> that identifies the resource to request.</param>
		/// <returns>
		/// A new <see cref="T:System.Net.WebRequest"/> object for the specified resource.
		/// </returns>
		protected override WebRequest GetWebRequest(Uri address)
		{
			//Create a httpWebRequest so the certificate can be added
			var request = base.GetWebRequest(address);

			//Make sure we have a Request and that it is not file based.
			if (request == null || request is FileWebRequest)
			{
				return request;
			}

			//Convert the request to a web http Web Request so the certificate can be added.
			var webrequest = (HttpWebRequest)request;

			//If we have a certificate - add it.
			if (!string.IsNullOrEmpty(CertPath))
			{
				//Create a certificate and add it.
				var cert = X509Certificate.CreateFromCertFile(CertPath);
				webrequest.ClientCertificates.Add(cert);
			}

			return webrequest;
		}
}

}
