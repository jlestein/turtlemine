using System;
using System.Management;
using System.Security.Cryptography;
using System.Text;

namespace TurtleMine.Settings
{
	/// <summary>
	/// Provides string Encryption and Decryption
	/// </summary>
	/// <remarks>Based on code found here: http://stackoverflow.com/questions/202011/encrypt-decrypt-string-in-net </remarks>
	internal class CryptoEngine
	{
		/// <summary>Encrypts the specified to string.</summary>
		/// <param name="toEncrypt">the string to encrypt.</param>
		/// <returns>Encrypted string</returns>
		public static string Encrypt(string toEncrypt)
		{
			//Get string in bytes
			var toEncryptArray = Encoding.UTF8.GetBytes(toEncrypt);

			//get md5 hash of processor id
			var hashmd5 = new MD5CryptoServiceProvider();
			var keyArray = hashmd5.ComputeHash(Encoding.UTF8.GetBytes(getProcessorID()));
			hashmd5.Clear();

			//Encrypt the string with Triple Des usng the hashed processor id.
			var tDes = new TripleDESCryptoServiceProvider { Key = keyArray, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 };
			var cTransform = tDes.CreateEncryptor();
			var resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
			tDes.Clear();

			//Return the encrypted string
			return Convert.ToBase64String(resultArray, 0, resultArray.Length);
		}

		/// <summary>Decrypts the specified cypher string.</summary>
		/// <param name="cypherString">The cypher string.</param>
		/// <returns>the unencrypted string</returns>
		public static string Decrypt(string cypherString)
		{
			//Get string in bytes
			var toDecryptArray = Convert.FromBase64String(cypherString);

			//get md5 hash of processor id
			var hashmd5 = new MD5CryptoServiceProvider();
			var keyArray = hashmd5.ComputeHash(Encoding.UTF8.GetBytes(getProcessorID()));
			hashmd5.Clear();

			//Decrypt the string with Triple Des usng the hashed processor id.
			var tDes = new TripleDESCryptoServiceProvider { Key = keyArray, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 };
			var cTransform = tDes.CreateDecryptor();
			try
			{
				var resultArray = cTransform.TransformFinalBlock(toDecryptArray, 0, toDecryptArray.Length);
				tDes.Clear();
				return Encoding.UTF8.GetString(resultArray, 0, resultArray.Length);
			}
			catch
			{
				return string.Empty;
			}
		}

		#region ProcessorID
		/// <summary>
		/// Return processorID from first Processor in machine
		/// </summary>
		/// <returns>[string] ProcessorID</returns>
		private static string getProcessorID()
		{
			//Connect to Processor Info
			var mc = new ManagementClass("Win32_Processor");
			ManagementObjectCollection moc = mc.GetInstances();

			string processorId = String.Empty;
			try
			{
				foreach (ManagementObject mo in moc)
				{
					processorId = mo["ProcessorId"].ToString();

					mo.Dispose();

					//Only return processorID from first processor
					if (processorId != String.Empty)
						break;
				}
			}
			catch
			{
				//Suppress errors if can't get processor
				processorId = "A!b2C3d4E5f6G7h8I9j)";
			}

			//Return processorId from first Processor
			return processorId;
		}
		#endregion
	}
}
