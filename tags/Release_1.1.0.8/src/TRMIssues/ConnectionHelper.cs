using System.Net;
using System.Xml;

namespace TRMIssues
{
    /// <summary>
    /// Provides shared connection method including proxy configuration
    /// </summary>
    internal class ConnectionHelper
    {
        /// <summary>
        /// Creates an XML reader from the provided URL with the appropriate configured connection.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        public static XmlReader CreateXmlReader(string url)
        {
            //TODO: Add proxy configuration screen
            //      Have the ability to use IE proxy settings
            //      Specify Proxy settings
            //              - including bypasslocal
            //              - Use windows authentication /specify credentials

            //Sample Proxy config
            //var proxy = new WebProxy
            //            {
            //                Address = new Uri("http://abc:8080"),
            //                BypassProxyOnLocal = true,
            //                Credentials = new NetworkCredential("MYUSERNAME", "MYPASSWORD", "MYDOMAIN")
            //                //Credentials = CredentialCache.DefaultCredentials //Windows Authentication
            //            };

            //For now use IE proxy settings with Windows Authentication
            var prox = WebRequest.GetSystemWebProxy();
            prox.Credentials = CredentialCache.DefaultCredentials;
            
            //Also pass credentials to web client so it can authenticate against servers that do not allow annonymous connections
            var client = new WebClient {Proxy = prox, Credentials = CredentialCache.DefaultCredentials};

            //Provide support for SSL by accepting all certificates
            ServicePointManager.ServerCertificateValidationCallback += delegate { return true; };  

            //Read the url
            var reader = XmlReader.Create(client.OpenRead(url), new XmlReaderSettings { ProhibitDtd = false, CheckCharacters = false });

            return reader;
        }

    }
}
