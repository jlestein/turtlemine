namespace TurtleMine.Controls
{
    partial class Updates
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Updates));
            this.lblLatestVersionTitle = new System.Windows.Forms.Label();
            this.lblCurrentVersionNumber = new System.Windows.Forms.Label();
            this.lnkChangeList = new System.Windows.Forms.LinkLabel();
            this.lnkLatestVersion = new System.Windows.Forms.LinkLabel();
            this.lblCurrentVersionTitle = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnCheckForUpdates = new System.Windows.Forms.Button();
            this.grpSchedule = new System.Windows.Forms.GroupBox();
            this.rdoCheckEveryStartup = new System.Windows.Forms.RadioButton();
            this.rdoCheckDaily = new System.Windows.Forms.RadioButton();
            this.rdoCheckWeekly = new System.Windows.Forms.RadioButton();
            this.rdoCheckNoAuto = new System.Windows.Forms.RadioButton();
            this.grpLatestVersion = new System.Windows.Forms.GroupBox();
            this.txtCheckFailed = new System.Windows.Forms.Label();
            this.pnlSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.grpSchedule.SuspendLayout();
            this.grpLatestVersion.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSettings
            // 
            this.pnlSettings.Controls.Add(this.grpSchedule);
            this.pnlSettings.Controls.Add(this.grpLatestVersion);
            this.pnlSettings.Controls.Add(this.btnCheckForUpdates);
            this.pnlSettings.Controls.Add(this.pictureBox1);
            this.pnlSettings.Controls.Add(this.lblCurrentVersionNumber);
            this.pnlSettings.Controls.Add(this.lblCurrentVersionTitle);
            // 
            // rdoCustomSettings
            // 
            resources.ApplyResources(this.rdoCustomSettings, "rdoCustomSettings");
            // 
            // lblHeading
            // 
            resources.ApplyResources(this.lblHeading, "lblHeading");
            // 
            // rdoGlobalSettings
            // 
            resources.ApplyResources(this.rdoGlobalSettings, "rdoGlobalSettings");
            this.rdoGlobalSettings.Checked = true;
            this.rdoGlobalSettings.TabStop = true;
            // 
            // lblLatestVersionTitle
            // 
            resources.ApplyResources(this.lblLatestVersionTitle, "lblLatestVersionTitle");
            this.lblLatestVersionTitle.Name = "lblLatestVersionTitle";
            // 
            // lblCurrentVersionNumber
            // 
            resources.ApplyResources(this.lblCurrentVersionNumber, "lblCurrentVersionNumber");
            this.lblCurrentVersionNumber.Name = "lblCurrentVersionNumber";
            // 
            // lnkChangeList
            // 
            resources.ApplyResources(this.lnkChangeList, "lnkChangeList");
            this.lnkChangeList.Name = "lnkChangeList";
            this.lnkChangeList.TabStop = true;
            this.lnkChangeList.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkChangeList_LinkClicked);
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
            // lblCurrentVersionTitle
            // 
            resources.ApplyResources(this.lblCurrentVersionTitle, "lblCurrentVersionTitle");
            this.lblCurrentVersionTitle.Name = "lblCurrentVersionTitle";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::TurtleMine.Resources.Images.download_link64;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // btnCheckForUpdates
            // 
            this.btnCheckForUpdates.Image = global::TurtleMine.Resources.Images.globe;
            resources.ApplyResources(this.btnCheckForUpdates, "btnCheckForUpdates");
            this.btnCheckForUpdates.Name = "btnCheckForUpdates";
            this.btnCheckForUpdates.UseVisualStyleBackColor = true;
            this.btnCheckForUpdates.Click += new System.EventHandler(this.btnCheckForUpdates_Click);
            // 
            // grpSchedule
            // 
            this.grpSchedule.Controls.Add(this.rdoCheckEveryStartup);
            this.grpSchedule.Controls.Add(this.rdoCheckDaily);
            this.grpSchedule.Controls.Add(this.rdoCheckWeekly);
            this.grpSchedule.Controls.Add(this.rdoCheckNoAuto);
            resources.ApplyResources(this.grpSchedule, "grpSchedule");
            this.grpSchedule.Name = "grpSchedule";
            this.grpSchedule.TabStop = false;
            // 
            // rdoCheckEveryStartup
            // 
            resources.ApplyResources(this.rdoCheckEveryStartup, "rdoCheckEveryStartup");
            this.rdoCheckEveryStartup.Checked = true;
            this.rdoCheckEveryStartup.Name = "rdoCheckEveryStartup";
            this.rdoCheckEveryStartup.TabStop = true;
            this.rdoCheckEveryStartup.UseVisualStyleBackColor = true;
            this.rdoCheckEveryStartup.CheckedChanged += new System.EventHandler(this.autoUpdate_CheckedChanged);
            // 
            // rdoCheckDaily
            // 
            resources.ApplyResources(this.rdoCheckDaily, "rdoCheckDaily");
            this.rdoCheckDaily.Name = "rdoCheckDaily";
            this.rdoCheckDaily.UseVisualStyleBackColor = true;
            this.rdoCheckDaily.CheckedChanged += new System.EventHandler(this.autoUpdate_CheckedChanged);
            // 
            // rdoCheckWeekly
            // 
            resources.ApplyResources(this.rdoCheckWeekly, "rdoCheckWeekly");
            this.rdoCheckWeekly.Name = "rdoCheckWeekly";
            this.rdoCheckWeekly.UseVisualStyleBackColor = true;
            this.rdoCheckWeekly.CheckedChanged += new System.EventHandler(this.autoUpdate_CheckedChanged);
            // 
            // rdoCheckNoAuto
            // 
            resources.ApplyResources(this.rdoCheckNoAuto, "rdoCheckNoAuto");
            this.rdoCheckNoAuto.Name = "rdoCheckNoAuto";
            this.rdoCheckNoAuto.UseVisualStyleBackColor = true;
            this.rdoCheckNoAuto.CheckedChanged += new System.EventHandler(this.autoUpdate_CheckedChanged);
            // 
            // grpLatestVersion
            // 
            this.grpLatestVersion.Controls.Add(this.txtCheckFailed);
            this.grpLatestVersion.Controls.Add(this.lnkChangeList);
            this.grpLatestVersion.Controls.Add(this.lblLatestVersionTitle);
            this.grpLatestVersion.Controls.Add(this.lnkLatestVersion);
            resources.ApplyResources(this.grpLatestVersion, "grpLatestVersion");
            this.grpLatestVersion.Name = "grpLatestVersion";
            this.grpLatestVersion.TabStop = false;
            // 
            // txtCheckFailed
            // 
            resources.ApplyResources(this.txtCheckFailed, "txtCheckFailed");
            this.txtCheckFailed.Name = "txtCheckFailed";
            // 
            // Updates
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "Updates";
            this.Load += new System.EventHandler(this.updates_Load);
            this.pnlSettings.ResumeLayout(false);
            this.pnlSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.grpSchedule.ResumeLayout(false);
            this.grpSchedule.PerformLayout();
            this.grpLatestVersion.ResumeLayout(false);
            this.grpLatestVersion.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblLatestVersionTitle;
        private System.Windows.Forms.Label lblCurrentVersionNumber;
        private System.Windows.Forms.LinkLabel lnkChangeList;
        private System.Windows.Forms.LinkLabel lnkLatestVersion;
        private System.Windows.Forms.Label lblCurrentVersionTitle;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnCheckForUpdates;
        private System.Windows.Forms.GroupBox grpSchedule;
        private System.Windows.Forms.GroupBox grpLatestVersion;
        private System.Windows.Forms.RadioButton rdoCheckDaily;
        private System.Windows.Forms.RadioButton rdoCheckWeekly;
        private System.Windows.Forms.RadioButton rdoCheckNoAuto;
        private System.Windows.Forms.RadioButton rdoCheckEveryStartup;
        private System.Windows.Forms.Label txtCheckFailed;

    }
}
