namespace TurtleMine.Controls
{
    partial class About
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.lblCurrentVersionNumber = new System.Windows.Forms.Label();
            this.lblCurrentVersionTitle = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.lblContributor = new System.Windows.Forms.Label();
            this.lnkWebsite = new System.Windows.Forms.LinkLabel();
            this.lnkWebsite2 = new System.Windows.Forms.LinkLabel();
            this.pnlSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSettings
            // 
            resources.ApplyResources(this.pnlSettings, "pnlSettings");
            this.pnlSettings.Controls.Add(this.lnkWebsite2);
            this.pnlSettings.Controls.Add(this.lnkWebsite);
            this.pnlSettings.Controls.Add(this.lblContributor);
            this.pnlSettings.Controls.Add(this.lblAuthor);
            this.pnlSettings.Controls.Add(this.lblTitle);
            this.pnlSettings.Controls.Add(this.lblCurrentVersionNumber);
            this.pnlSettings.Controls.Add(this.lblCurrentVersionTitle);
            this.pnlSettings.Controls.Add(this.picLogo);
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
            // picLogo
            // 
            resources.ApplyResources(this.picLogo, "picLogo");
            this.picLogo.Image = global::TurtleMine.Resources.Images.TRMLogo64;
            this.picLogo.Name = "picLogo";
            this.picLogo.TabStop = false;
            // 
            // lblCurrentVersionNumber
            // 
            resources.ApplyResources(this.lblCurrentVersionNumber, "lblCurrentVersionNumber");
            this.lblCurrentVersionNumber.Name = "lblCurrentVersionNumber";
            // 
            // lblCurrentVersionTitle
            // 
            resources.ApplyResources(this.lblCurrentVersionTitle, "lblCurrentVersionTitle");
            this.lblCurrentVersionTitle.Name = "lblCurrentVersionTitle";
            // 
            // lblTitle
            // 
            resources.ApplyResources(this.lblTitle, "lblTitle");
            this.lblTitle.Name = "lblTitle";
            // 
            // lblAuthor
            // 
            resources.ApplyResources(this.lblAuthor, "lblAuthor");
            this.lblAuthor.Name = "lblAuthor";
            // 
            // lblContributor
            // 
            resources.ApplyResources(this.lblContributor, "lblContributor");
            this.lblContributor.Name = "lblContributor";
            // 
            // lnkWebsite
            // 
            resources.ApplyResources(this.lnkWebsite, "lnkWebsite");
            this.lnkWebsite.Name = "lnkWebsite";
            this.lnkWebsite.TabStop = true;
            this.lnkWebsite.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkWebsite_LinkClicked);
            // 
            // lnkWebsite2
            // 
            resources.ApplyResources(this.lnkWebsite2, "lnkWebsite2");
            this.lnkWebsite2.Name = "lnkWebsite2";
            this.lnkWebsite2.TabStop = true;
            this.lnkWebsite2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkWebsite_LinkClicked);
            // 
            // About
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "About";
            this.Load += new System.EventHandler(this.About_Load);
            this.pnlSettings.ResumeLayout(false);
            this.pnlSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblCurrentVersionNumber;
        private System.Windows.Forms.Label lblCurrentVersionTitle;
        private System.Windows.Forms.Label lblContributor;
        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.LinkLabel lnkWebsite;
        private System.Windows.Forms.LinkLabel lnkWebsite2;

    }
}
