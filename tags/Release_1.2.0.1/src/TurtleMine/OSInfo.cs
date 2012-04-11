// Code downloaded from: http://andrewensley.com/2009/10/c-detect-windows-os-version-%e2%80%93-part-2-wmi/
// Code cleaned up after download. OS Language also added.

using System;
using System.Globalization;
using System.Management;
using System.Text.RegularExpressions;

namespace TurtleMine
{
	/// <summary>
	/// Gets information about the Operating system.
	/// </summary>
	internal static class OsInfo
	{
		public static string GetOSLanguage()
		{
			var ci = CultureInfo.InstalledUICulture;
			return ci.Name + " - " + ci.EnglishName;
		}

		/// <summary>
		/// Gets Operating System Name, Service Pack, and Architecture using WMI with the legacy methods as a fallback
		/// </summary>
		/// <returns>String containing the name of the operating system followed by its service pack (if any) and architecture</returns>
		public static string GetOSInfo()
		{
			var objMos = new ManagementObjectSearcher("SELECT * FROM  Win32_OperatingSystem");

			//Variables to hold our return value
			var os = string.Empty;
			var osArch = 0;

			try
			{
				foreach (ManagementObject objManagement in objMos.Get())
				{
					// Get OS version from WMI - This also gives us the edition
					var osCaption = objManagement.GetPropertyValue("Caption");
					if (osCaption == null) continue;

					// Remove all non-alphanumeric characters so that only letters, numbers, and spaces are left.
					var osC = Regex.Replace(osCaption.ToString(), "[^A-Za-z0-9 ]", "");
					//string osC = osCaption.ToString();
					// If the OS starts with "Microsoft," remove it.  We know that already
					if (osC.StartsWith("Microsoft"))
					{
						osC = osC.Substring(9);
					}
					//// If the OS now starts with "Windows," again... useless.  Remove it.
					//if (osC.Trim().StartsWith("Windows"))
					//{
					//    osC = osC.Trim().Substring(7);
					//}
					// Remove any remaining beginning or ending spaces.
					os = osC.Trim();

					// Only proceed if we actually have an OS version - service pack is useless without the OS version.
					if (!String.IsNullOrEmpty(os))
					{
						try
						{
							// Get OS service pack from WMI
							var osSp = objManagement.GetPropertyValue("ServicePackMajorVersion");
							if (osSp != null && osSp.ToString() != "0")
							{
								os += " Service Pack " + osSp;
							}
							else
							{
								// Service Pack not found.  Try built-in Environment class.
								os += getOSServicePackLegacy();
							}
						}
						catch (Exception)
						{
							// There was a problem getting the service pack from WMI.  Try built-in Environment class.
							os += getOSServicePackLegacy();
						}
					}

					try
					{
						// Get OS architecture from WMI
						var osA = objManagement.GetPropertyValue("OSArchitecture");
						if (osA != null)
						{
							var osAString = osA.ToString();
							// If "64" is anywhere in there, it's a 64-bit architecture.
							osArch = (osAString.Contains("64") ? 64 : 32);
						}
					}
					catch {}
				}
			}
			catch {}

			// If WMI couldn't tell us the OS, use our legacy method.
			// We won't get the exact OS edition, but something is better than nothing.
			if (os == "")
			{
				os = getOSLegacy();
			}

			// If WMI couldn't tell us the architecture, use our legacy method.
			if (osArch == 0)
			{
				osArch = getOSArchitectureLegacy();
			}
			return os + " " + osArch + "-bit";
		}

		/// <summary>
		/// Gets Operating System Name using .Net's Environment class.
		/// </summary>
		/// <returns>String containing the name of the operating system followed by its service pack (if any)</returns>
		private static string getOSLegacy()
		{
			//Get Operating system information.
			var os = Environment.OSVersion;
			//Get version information about the OS.
			var vs = os.Version;

			//Variable to hold our return value
			var operatingSystem = string.Empty;

			if (os.Platform == PlatformID.Win32Windows)
			{
				//This is a pre-NT version of Windows
				switch (vs.Minor)
				{
					case 0:
						operatingSystem = "95";
						break;
					case 10:
						operatingSystem = vs.Revision.ToString() == "2222A" ? "98SE" : "98";
						break;
					case 90:
						operatingSystem = "Me";
						break;
				}
			}
			else if (os.Platform == PlatformID.Win32NT)
			{
				switch (vs.Major)
				{
					case 3:
						operatingSystem = "NT 3.51";
						break;
					case 4:
						operatingSystem = "NT 4.0";
						break;
					case 5:
						operatingSystem = vs.Minor == 0 ? "2000" : "XP";
						break;
					case 6:
						operatingSystem = vs.Minor == 0 ? "Vista" : "7";
						break;
				}
			}

			//Make sure we actually got something in our OS check
			//We don't want to just return " Service Pack 2"
			//That information is useless without the OS version.
			if (operatingSystem != string.Empty)
			{
				//Got something.  Let's see if there's a service pack installed.
				operatingSystem += getOSServicePackLegacy();
			}

			//Return the information we've gathered.
			return operatingSystem;
		}

		/// <summary>
		/// Gets the installed Operating System Service Pack using .Net's Environment class.
		/// </summary>
		/// <returns>String containing the operating system's installed service pack (if any)</returns>
		private static string getOSServicePackLegacy()
		{
			// Get service pack from Environment Class
			var sp = Environment.OSVersion.ServicePack;
			if (!string.IsNullOrEmpty(sp.Trim()))
			{
				// If there's a service pack, return it with a space in front (for formatting)
				return " " + sp;
			}
			// No service pack.  Return an empty string
			return string.Empty;
		}

		/// <summary>
		/// Gets Operating System Architecture.  This does not tell you if the program in running in
		/// 32- or 64-bit mode or if the CPU is 64-bit capable.  It tells you whether the actual Operating
		/// System is 32- or 64-bit.
		/// </summary>
		/// <returns>Int containing 32 or 64 representing the number of bits in the OS Architecture</returns>
		private static int getOSArchitectureLegacy()
		{
			string pa = Environment.GetEnvironmentVariable("PROCESSOR_ARCHITECTURE");
			return ((String.IsNullOrEmpty(pa) || String.Compare(pa, 0, "x86", 0, 3, true) == 0) ? 32 : 64);
		}
	}
}
