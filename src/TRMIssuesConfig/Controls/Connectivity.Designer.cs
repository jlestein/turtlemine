namespace TRMIssuesConfig.Controls
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
            this.rdoGlobalSettings = new System.Windows.Forms.RadioButton();
            this.pnlSettings = new System.Windows.Forms.Panel();
            this.grpAuthentication = new System.Windows.Forms.GroupBox();
            this.btnShow = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.grpProxy = new System.Windows.Forms.GroupBox();
            this.pnlManual = new System.Windows.Forms.Panel();
            this.nudPort = new System.Windows.Forms.NumericUpDown();
            this.lblPort = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.btnInternetOptions = new System.Windows.Forms.Button();
            this.rdoManualProxy = new System.Windows.Forms.RadioButton();
            this.rdoWindowsProxy = new System.Windows.Forms.RadioButton();
            this.rdoNoProxy = new System.Windows.Forms.RadioButton();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.lblConnectivity = new System.Windows.Forms.Label();
            this.rdoCustomSettings = new System.Windows.Forms.RadioButton();
            this.pnlSettings.SuspendLayout();
            this.grpAuthentication.SuspendLayout();
            this.grpProxy.SuspendLayout();
            this.pnlManual.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPort)).BeginInit();
            this.SuspendLayout();
            // 
            // rdoGlobalSettings
            // 
            resources.ApplyResources(this.rdoGlobalSettings, "rdoGlobalSettings");
            this.rdoGlobalSettings.Name = "rdoGlobalSettings";
            this.rdoGlobalSettings.UseVisualStyleBackColor = true;
            this.rdoGlobalSettings.CheckedChanged += new System.EventHandler(this.rdoGlobalSettings_CheckedChanged);
            // 
            // pnlSettings
            // 
            this.pnlSettings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSettings.Controls.Add(this.grpAuthentication);
            this.pnlSettings.Controls.Add(this.grpProxy);
            resources.ApplyResources(this.pnlSettings, "pnlSettings");
            this.pnlSettings.Name = "pnlSettings";
            // 
            // grpAuthentication
            // 
            this.grpAuthentication.Controls.Add(this.btnShow);
            this.grpAuthentication.Controls.Add(this.txtPassword);
            this.grpAuthentication.Controls.Add(this.lblPassword);
            this.grpAuthentication.Controls.Add(this.txtUserName);
            this.grpAuthentication.Controls.Add(this.lblUsername);
            resources.ApplyResources(this.grpAuthentication, "grpAuthentication");
            this.grpAuthentication.Name = "grpAuthentication";
            this.grpAuthentication.TabStop = false;
            // 
            // btnShow
            // 
            resources.ApplyResources(this.btnShow, "btnShow");
            this.btnShow.Name = "btnShow";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // txtPassword
            // 
            resources.ApplyResources(this.txtPassword, "txtPassword");
            this.txtPassword.Name = "txtPassword";
            // 
            // lblPassword
            // 
            resources.ApplyResources(this.lblPassword, "lblPassword");
            this.lblPassword.Name = "lblPassword";
            // 
            // txtUserName
            // 
            resources.ApplyResources(this.txtUserName, "txtUserName");
            this.txtUserName.Name = "txtUserName";
            // 
            // lblUsername
            // 
            resources.ApplyResources(this.lblUsername, "lblUsername");
            this.lblUsername.Name = "lblUsername";
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
            this.pnlManual.Controls.Add(this.nudPort);
            this.pnlManual.Controls.Add(this.lblPort);
            this.pnlManual.Controls.Add(this.txtAddress);
            this.pnlManual.Controls.Add(this.lblAddress);
            resources.ApplyResources(this.pnlManual, "pnlManual");
            this.pnlManual.Name = "pnlManual";
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
            // 
            // lblAddress
            // 
            resources.ApplyResources(this.lblAddress, "lblAddress");
            this.lblAddress.Name = "lblAddress";
            // 
            // btnInternetOptions
            // 
            resources.ApplyResources(this.btnInternetOptions, "btnInternetOptions");
            this.btnInternetOptions.Name = "btnInternetOptions";
            this.btnInternetOptions.UseVisualStyleBackColor = true;
            this.btnInternetOptions.Click += new System.EventHandler(this.btnInternetOptions_Click);
            // 
            // rdoManualProxy
            // 
            resources.ApplyResources(this.rdoManualProxy, "rdoManualProxy");
            this.rdoManualProxy.Name = "rdoManualProxy";
            this.rdoManualProxy.UseVisualStyleBackColor = true;
            this.rdoManualProxy.CheckedChanged += new System.EventHandler(this.rdoManualProxy_CheckedChanged);
            // 
            // rdoWindowsProxy
            // 
            resources.ApplyResources(this.rdoWindowsProxy, "rdoWindowsProxy");
            this.rdoWindowsProxy.Checked = true;
            this.rdoWindowsProxy.Name = "rdoWindowsProxy";
            this.rdoWindowsProxy.TabStop = true;
            this.rdoWindowsProxy.UseVisualStyleBackColor = true;
            this.rdoWindowsProxy.CheckedChanged += new System.EventHandler(this.rdoWindowsProxy_CheckedChanged);
            // 
            // rdoNoProxy
            // 
            resources.ApplyResources(this.rdoNoProxy, "rdoNoProxy");
            this.rdoNoProxy.Name = "rdoNoProxy";
            this.rdoNoProxy.UseVisualStyleBackColor = true;
            this.rdoNoProxy.CheckedChanged += new System.EventHandler(this.rdoNoProxy_CheckedChanged);
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            resources.ApplyResources(this.btnOk, "btnOk");
            this.btnOk.Name = "btnOk";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lblConnectivity
            // 
            resources.ApplyResources(this.lblConnectivity, "lblConnectivity");
            this.lblConnectivity.Name = "lblConnectivity";
            // 
            // rdoCustomSettings
            // 
            resources.ApplyResources(this.rdoCustomSettings, "rdoCustomSettings");
            this.rdoCustomSettings.Name = "rdoCustomSettings";
            this.rdoCustomSettings.UseVisualStyleBackColor = true;
            this.rdoCustomSettings.CheckedChanged += new System.EventHandler(this.rdoCustomSettings_CheckedChanged);
            // 
            // Connectivity
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rdoCustomSettings);
            this.Controls.Add(this.lblConnectivity);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.pnlSettings);
            this.Controls.Add(this.rdoGlobalSettings);
            this.Name = "Connectivity";
            this.Load += new System.EventHandler(this.connectivity_Load);
            this.pnlSettings.ResumeLayout(false);
            this.grpAuthentication.ResumeLayout(false);
            this.grpAuthentication.PerformLayout();
            this.grpProxy.ResumeLayout(false);
            this.grpProxy.PerformLayout();
            this.pnlManual.ResumeLayout(false);
            this.pnlManual.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPort)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rdoGlobalSettings;
        private System.Windows.Forms.Panel pnlSettings;
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
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Panel pnlManual;
        private System.Windows.Forms.NumericUpDown nudPort;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblConnectivity;
        private System.Windows.Forms.RadioButton rdoCustomSettings;
    }
}
