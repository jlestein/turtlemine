using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using TurtleMine.Resources;
using TurtleMine.Settings;

namespace TurtleMine.Controls
{
	/// <summary>
	/// Provide connectivity Control
	/// </summary>
	public partial class Connectivity : Template
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Connectivity"/> class.
		/// </summary>
		public Connectivity()
		{
			Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;
			InitializeComponent();
		}

		private void connectivity_Load(object sender, EventArgs e)
		{
			//Load project specific settings of this project has any
			if (!ProjectInfo.IsEmpty())
			{
				
			}

			getSettings();
		}

		private void btnInternetOptions_Click(object sender, EventArgs e)
		{
			Process.Start("control.exe","InetCpl.cpl,,4");
		}

		private void rdo_CheckedChanged(object sender, EventArgs e)
		{
			pnlManual.Enabled = rdoManualProxy.Checked;
			pnlProvideAuth.Enabled = rdoAuthProvidedCredentials.Checked;
			if (((RadioButton)sender).Checked && !_loadingSettings)
			{
				PropertyChanged = true;	
			}
		}

		private void propertyChanged(object sender, EventArgs e)
		{
			if (!_loadingSettings)
			{
				PropertyChanged = true;
			}
		}

		private void btnShow_Click(object sender, EventArgs e)
		{
			if (txtPassword.PasswordChar == char.MinValue)
			{
				btnShow.Text = Strings.ShowPassword;
				txtPassword.PasswordChar = Convert.ToChar("*");
			}
			else
			{
				btnShow.Text = Strings.HidePassword;
				txtPassword.PasswordChar = char.MinValue;
			}
			txtPassword.Refresh();
			txtPassword.Focus();
		}


		private void btnSSLPath_Click(object sender, EventArgs e)
		{
			var dialog = new OpenFileDialog
							 {
								 CheckFileExists = true,
								 AutoUpgradeEnabled = true,
								 Filter = string.Format("{0} | *.arm;*.cer;*.crt;*.der;*.key;*.pem;*.pfx;*.p7b;*.p7c;*.p12 | {1} | *.*", Strings.Connectivity_btnSSLPath_Click_Certificate_Files, Strings.Connectivity_btnSSLPath_Click_All_Files),
								 Title = Strings.Connectivity_btnSSLPath_Click_Select_Certificate_File
							 };

			if (dialog.ShowDialog(ParentForm) != DialogResult.OK)
			{
				return;
			}

			txtSSLPath.Text = dialog.FileName;
		}

		public override void ApplyChanges()
		{
			if (rdoNoProxy.Checked)
			{
				SettingsManager.Settings.Connectivity.Proxy.ItemElementName = ProxyType.NoProxy;
				SettingsManager.Settings.Connectivity.Proxy.Item = true;
			}

			if (rdoWindowsProxy.Checked)
			{
				SettingsManager.Settings.Connectivity.Proxy.ItemElementName = ProxyType.WindowsProxy;
				SettingsManager.Settings.Connectivity.Proxy.Item = true;
			}
			
			if (rdoManualProxy.Checked)
			{
				SettingsManager.Settings.Connectivity.Proxy.ItemElementName = ProxyType.ManualProxy;

				var manprox = new ManualProxy
								{Address = txtAddress.Text, Port = nudPort.Text, BypassLocal = chkBypassProxy.Checked, Value = true};
				SettingsManager.Settings.Connectivity.Proxy.Item = manprox;
			}

			if (rdoAuthCurrentUser.Checked)
			{
				SettingsManager.Settings.Connectivity.Authentication.Item = true;
			}

			if (rdoAuthProvidedCredentials.Checked)
			{
				var credentials = new ProvidedCredentials {Username = txtUserName.Text, PasswordText = txtPassword.Text, Value = true};

				SettingsManager.Settings.Connectivity.Authentication.Item = credentials;
			}

			if (!string.IsNullOrEmpty(txtSSLPath.Text.Trim()))
			{
				SettingsManager.Settings.Connectivity.SSLCertPath = txtSSLPath.Text.Trim();
			}
		}

		private bool _loadingSettings;
		internal override void getSettings()
		{
			_loadingSettings = true;

			//Proxy
			if (SettingsManager.Settings.Connectivity.Proxy.Item == null)
			{
				rdoWindowsProxy.Checked = true;
			}
			else
			{
				switch (SettingsManager.Settings.Connectivity.Proxy.ItemElementName)
				{
					case ProxyType.NoProxy:
						rdoNoProxy.Checked = true;
						break;
					case ProxyType.ManualProxy:
						rdoManualProxy.Checked = true;
						var proxy = (ManualProxy)SettingsManager.Settings.Connectivity.Proxy.Item;
						txtAddress.Text = proxy.Address;
						nudPort.Text = proxy.Port;
						chkBypassProxy.Checked = proxy.BypassLocal;
						break;
					default:
						rdoWindowsProxy.Checked = true;
						break;
				}
			}

			//Auth
			if (SettingsManager.Settings.Connectivity.Authentication.Item == null || SettingsManager.Settings.Connectivity.Authentication.Item is bool)
			{
				rdoAuthCurrentUser.Checked = true;
			}
			else
			{
				rdoAuthProvidedCredentials.Checked = true;
				var credentials = (ProvidedCredentials) SettingsManager.Settings.Connectivity.Authentication.Item;
				txtUserName.Text = credentials.Username;
				txtPassword.Text = credentials.PasswordText;
			}

			//SSL
			if (!string.IsNullOrEmpty(SettingsManager.Settings.Connectivity.SSLCertPath))
			{
				txtSSLPath.Text = SettingsManager.Settings.Connectivity.SSLCertPath;
			}

			_loadingSettings = false;
		}
	}
}
