namespace TurtleMine.Controls
{
    partial class Connectivity
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Connectivity));
			this.grpSSL = new System.Windows.Forms.GroupBox();
			this.btnSSLPath = new System.Windows.Forms.Button();
			this.txtSSLPath = new System.Windows.Forms.TextBox();
			this.lblSSLPath = new System.Windows.Forms.Label();
			this.grpAuthentication = new System.Windows.Forms.GroupBox();
			this.rdoAuthProvidedCredentials = new System.Windows.Forms.RadioButton();
			this.rdoAuthCurrentUser = new System.Windows.Forms.RadioButton();
			this.pnlProvideAuth = new System.Windows.Forms.Panel();
			this.btnShow = new System.Windows.Forms.Button();
			this.lblUsername = new System.Windows.Forms.Label();
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.txtUserName = new System.Windows.Forms.TextBox();
			this.lblPassword = new System.Windows.Forms.Label();
			this.grpProxy = new System.Windows.Forms.GroupBox();
			this.pnlManual = new System.Windows.Forms.Panel();
			this.chkBypassProxy = new System.Windows.Forms.CheckBox();
			this.nudPort = new System.Windows.Forms.NumericUpDown();
			this.lblPort = new System.Windows.Forms.Label();
			this.txtAddress = new System.Windows.Forms.TextBox();
			this.lblAddress = new System.Windows.Forms.Label();
			this.btnInternetOptions = new System.Windows.Forms.Button();
			this.rdoManualProxy = new System.Windows.Forms.RadioButton();
			this.rdoWindowsProxy = new System.Windows.Forms.RadioButton();
			this.rdoNoProxy = new System.Windows.Forms.RadioButton();
			this.pnlSettings.SuspendLayout();
			this.grpSSL.SuspendLayout();
			this.grpAuthentication.SuspendLayout();
			this.pnlProvideAuth.SuspendLayout();
			this.grpProxy.SuspendLayout();
			this.pnlManual.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudPort)).BeginInit();
			this.SuspendLayout();
			// 
			// pnlSettings
			// 
			this.pnlSettings.Controls.Add(this.grpSSL);
			this.pnlSettings.Controls.Add(this.grpAuthentication);
			this.pnlSettings.Controls.Add(this.grpProxy);
			// 
			// lblHeading
			// 
			resources.ApplyResources(this.lblHeading, "lblHeading");
			// 
			// rdoGlobalSettings
			// 
			this.rdoGlobalSettings.Checked = true;
			this.rdoGlobalSettings.TabStop = true;
			// 
			// grpSSL
			// 
			this.grpSSL.Controls.Add(this.btnSSLPath);
			this.grpSSL.Controls.Add(this.txtSSLPath);
			this.grpSSL.Controls.Add(this.lblSSLPath);
			resources.ApplyResources(this.grpSSL, "grpSSL");
			this.grpSSL.Name = "grpSSL";
			this.grpSSL.TabStop = false;
			// 
			// btnSSLPath
			// 
			this.btnSSLPath.BackColor = System.Drawing.SystemColors.Control;
			this.btnSSLPath.Image = global::TurtleMine.Resources.Images.folder;
			resources.ApplyResources(this.btnSSLPath, "btnSSLPath");
			this.btnSSLPath.Name = "btnSSLPath";
			this.btnSSLPath.UseVisualStyleBackColor = false;
			this.btnSSLPath.Click += new System.EventHandler(this.btnSSLPath_Click);
			// 
			// txtSSLPath
			// 
			resources.ApplyResources(this.txtSSLPath, "txtSSLPath");
			this.txtSSLPath.Name = "txtSSLPath";
			this.txtSSLPath.TextChanged += new System.EventHandler(this.propertyChanged);
			// 
			// lblSSLPath
			// 
			resources.ApplyResources(this.lblSSLPath, "lblSSLPath");
			this.lblSSLPath.Name = "lblSSLPath";
			// 
			// grpAuthentication
			// 
			this.grpAuthentication.Controls.Add(this.rdoAuthProvidedCredentials);
			this.grpAuthentication.Controls.Add(this.rdoAuthCurrentUser);
			this.grpAuthentication.Controls.Add(this.pnlProvideAuth);
			resources.ApplyResources(this.grpAuthentication, "grpAuthentication");
			this.grpAuthentication.Name = "grpAuthentication";
			this.grpAuthentication.TabStop = false;
			// 
			// rdoAuthProvidedCredentials
			// 
			resources.ApplyResources(this.rdoAuthProvidedCredentials, "rdoAuthProvidedCredentials");
			this.rdoAuthProvidedCredentials.Name = "rdoAuthProvidedCredentials";
			this.rdoAuthProvidedCredentials.UseVisualStyleBackColor = true;
			this.rdoAuthProvidedCredentials.CheckedChanged += new System.EventHandler(this.rdo_CheckedChanged);
			// 
			// rdoAuthCurrentUser
			// 
			resources.ApplyResources(this.rdoAuthCurrentUser, "rdoAuthCurrentUser");
			this.rdoAuthCurrentUser.Checked = true;
			this.rdoAuthCurrentUser.Name = "rdoAuthCurrentUser";
			this.rdoAuthCurrentUser.TabStop = true;
			this.rdoAuthCurrentUser.UseVisualStyleBackColor = true;
			this.rdoAuthCurrentUser.CheckedChanged += new System.EventHandler(this.rdo_CheckedChanged);
			// 
			// pnlProvideAuth
			// 
			this.pnlProvideAuth.Controls.Add(this.btnShow);
			this.pnlProvideAuth.Controls.Add(this.lblUsername);
			this.pnlProvideAuth.Controls.Add(this.txtPassword);
			this.pnlProvideAuth.Controls.Add(this.txtUserName);
			this.pnlProvideAuth.Controls.Add(this.lblPassword);
			resources.ApplyResources(this.pnlProvideAuth, "pnlProvideAuth");
			this.pnlProvideAuth.Name = "pnlProvideAuth";
			// 
			// btnShow
			// 
			this.btnShow.BackColor = System.Drawing.SystemColors.Control;
			resources.ApplyResources(this.btnShow, "btnShow");
			this.btnShow.Name = "btnShow";
			this.btnShow.UseVisualStyleBackColor = false;
			this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
			// 
			// lblUsername
			// 
			resources.ApplyResources(this.lblUsername, "lblUsername");
			this.lblUsername.Name = "lblUsername";
			// 
			// txtPassword
			// 
			resources.ApplyResources(this.txtPassword, "txtPassword");
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.TextChanged += new System.EventHandler(this.propertyChanged);
			// 
			// txtUserName
			// 
			resources.ApplyResources(this.txtUserName, "txtUserName");
			this.txtUserName.Name = "txtUserName";
			this.txtUserName.TextChanged += new System.EventHandler(this.propertyChanged);
			// 
			// lblPassword
			// 
			resources.ApplyResources(this.lblPassword, "lblPassword");
			this.lblPassword.Name = "lblPassword";
			// 
			// grpProxy
			// 
			this.grpProxy.Controls.Add(this.pnlManual);
			this.grpProxy.Controls.Add(this.btnInternetOptions);
			this.grpProxy.Controls.Add(this.rdoManualProxy);
			this.grpProxy.Controls.Add(this.rdoWindowsProxy);
			this.grpProxy.Controls.Add(this.rdoNoProxy);
			resources.ApplyResources(this.grpProxy, "grpProxy");
			this.grpProxy.Name = "grpProxy";
			this.grpProxy.TabStop = false;
			// 
			// pnlManual
			// 
			this.pnlManual.Controls.Add(this.chkBypassProxy);
			this.pnlManual.Controls.Add(this.nudPort);
			this.pnlManual.Controls.Add(this.lblPort);
			this.pnlManual.Controls.Add(this.txtAddress);
			this.pnlManual.Controls.Add(this.lblAddress);
			resources.ApplyResources(this.pnlManual, "pnlManual");
			this.pnlManual.Name = "pnlManual";
			// 
			// chkBypassProxy
			// 
			resources.ApplyResources(this.chkBypassProxy, "chkBypassProxy");
			this.chkBypassProxy.Name = "chkBypassProxy";
			this.chkBypassProxy.UseVisualStyleBackColor = true;
			this.chkBypassProxy.CheckedChanged += new System.EventHandler(this.propertyChanged);
			// 
			// nudPort
			// 
			resources.ApplyResources(this.nudPort, "nudPort");
			this.nudPort.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
			this.nudPort.Name = "nudPort";
			this.nudPort.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
			this.nudPort.ValueChanged += new System.EventHandler(this.propertyChanged);
			// 
			// lblPort
			// 
			resources.ApplyResources(this.lblPort, "lblPort");
			this.lblPort.Name = "lblPort";
			// 
			// txtAddress
			// 
			resources.ApplyResources(this.txtAddress, "txtAddress");
			this.txtAddress.Name = "txtAddress";
			this.txtAddress.TextChanged += new System.EventHandler(this.propertyChanged);
			// 
			// lblAddress
			// 
			resources.ApplyResources(this.lblAddress, "lblAddress");
			this.lblAddress.Name = "lblAddress";
			// 
			// btnInternetOptions
			// 
			this.btnInternetOptions.BackColor = System.Drawing.SystemColors.Control;
			resources.ApplyResources(this.btnInternetOptions, "btnInternetOptions");
			this.btnInternetOptions.Name = "btnInternetOptions";
			this.btnInternetOptions.UseVisualStyleBackColor = false;
			this.btnInternetOptions.Click += new System.EventHandler(this.btnInternetOptions_Click);
			// 
			// rdoManualProxy
			// 
			resources.ApplyResources(this.rdoManualProxy, "rdoManualProxy");
			this.rdoManualProxy.Name = "rdoManualProxy";
			this.rdoManualProxy.UseVisualStyleBackColor = true;
			this.rdoManualProxy.CheckedChanged += new System.EventHandler(this.rdo_CheckedChanged);
			// 
			// rdoWindowsProxy
			// 
			resources.ApplyResources(this.rdoWindowsProxy, "rdoWindowsProxy");
			this.rdoWindowsProxy.Checked = true;
			this.rdoWindowsProxy.Name = "rdoWindowsProxy";
			this.rdoWindowsProxy.TabStop = true;
			this.rdoWindowsProxy.UseVisualStyleBackColor = true;
			this.rdoWindowsProxy.CheckedChanged += new System.EventHandler(this.rdo_CheckedChanged);
			// 
			// rdoNoProxy
			// 
			resources.ApplyResources(this.rdoNoProxy, "rdoNoProxy");
			this.rdoNoProxy.Name = "rdoNoProxy";
			this.rdoNoProxy.UseVisualStyleBackColor = true;
			this.rdoNoProxy.CheckedChanged += new System.EventHandler(this.rdo_CheckedChanged);
			// 
			// Connectivity
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Name = "Connectivity";
			this.Load += new System.EventHandler(this.connectivity_Load);
			this.pnlSettings.ResumeLayout(false);
			this.grpSSL.ResumeLayout(false);
			this.grpSSL.PerformLayout();
			this.grpAuthentication.ResumeLayout(false);
			this.grpAuthentication.PerformLayout();
			this.pnlProvideAuth.ResumeLayout(false);
			this.pnlProvideAuth.PerformLayout();
			this.grpProxy.ResumeLayout(false);
			this.grpProxy.PerformLayout();
			this.pnlManual.ResumeLayout(false);
			this.pnlManual.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudPort)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpAuthentication;
        private System.Windows.Forms.GroupBox grpProxy;
        private System.Windows.Forms.RadioButton rdoManualProxy;
        private System.Windows.Forms.RadioButton rdoWindowsProxy;
        private System.Windows.Forms.RadioButton rdoNoProxy;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Button btnInternetOptions;
        private System.Windows.Forms.Panel pnlManual;
        private System.Windows.Forms.NumericUpDown nudPort;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.GroupBox grpSSL;
        private System.Windows.Forms.Button btnSSLPath;
        private System.Windows.Forms.TextBox txtSSLPath;
        private System.Windows.Forms.Label lblSSLPath;
        private System.Windows.Forms.Panel pnlProvideAuth;
        private System.Windows.Forms.RadioButton rdoAuthProvidedCredentials;
        private System.Windows.Forms.RadioButton rdoAuthCurrentUser;
        private System.Windows.Forms.CheckBox chkBypassProxy;
    }
}
