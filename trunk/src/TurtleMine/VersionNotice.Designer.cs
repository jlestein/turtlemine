namespace TurtleMine
{
    partial class VersionNotice
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VersionNotice));
            this.btnOK = new System.Windows.Forms.Button();
            this.lblCurrentVersionTitle = new System.Windows.Forms.Label();
            this.lnkLatestVersion = new System.Windows.Forms.LinkLabel();
            this.lnkChangeList = new System.Windows.Forms.LinkLabel();
            this.lblCurrentVersionNumber = new System.Windows.Forms.Label();
            this.lblLatestVersionTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.Gainsboro;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.Name = "btnOK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblCurrentVersionTitle
            // 
            resources.ApplyResources(this.lblCurrentVersionTitle, "lblCurrentVersionTitle");
            this.lblCurrentVersionTitle.Name = "lblCurrentVersionTitle";
            // 
            // lnkLatestVersion
            // 
            resources.ApplyResources(this.lnkLatestVersion, "lnkLatestVersion");
            this.lnkLatestVersion.Name = "lnkLatestVersion";
            this.lnkLatestVersion.TabStop = true;
            this.lnkLatestVersion.Tag = "http://redmine-projects.googlecode.com/files/TortoiseSVNRedmineIssuesPlugin_x86_1" +
                ".1.0.1.msi";
            this.lnkLatestVersion.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLatestVersion_LinkClicked);
            // 
            // lnkChangeList
            // 
            resources.ApplyResources(this.lnkChangeList, "lnkChangeList");
            this.lnkChangeList.Name = "lnkChangeList";
            this.lnkChangeList.TabStop = true;
            this.lnkChangeList.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkChangeList_LinkClicked);
            // 
            // lblCurrentVersionNumber
            // 
            resources.ApplyResources(this.lblCurrentVersionNumber, "lblCurrentVersionNumber");
            this.lblCurrentVersionNumber.Name = "lblCurrentVersionNumber";
            // 
            // lblLatestVersionTitle
            // 
            resources.ApplyResources(this.lblLatestVersionTitle, "lblLatestVersionTitle");
            this.lblLatestVersionTitle.Name = "lblLatestVersionTitle";
            // 
            // VersionNotice
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblLatestVersionTitle);
            this.Controls.Add(this.lblCurrentVersionNumber);
            this.Controls.Add(this.lnkChangeList);
            this.Controls.Add(this.lnkLatestVersion);
            this.Controls.Add(this.lblCurrentVersionTitle);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = global::TurtleMine.Resources.Images.download_linkicon;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VersionNotice";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.versionNotice_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblCurrentVersionTitle;
        private System.Windows.Forms.LinkLabel lnkLatestVersion;
        private System.Windows.Forms.LinkLabel lnkChangeList;
        private System.Windows.Forms.Label lblCurrentVersionNumber;
        private System.Windows.Forms.Label lblLatestVersionTitle;
    }
}