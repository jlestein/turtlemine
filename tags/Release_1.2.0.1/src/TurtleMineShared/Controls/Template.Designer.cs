namespace TurtleMine.Controls
{
    partial class Template
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing"><see langword="true"/> if managed resources should be disposed; otherwise, <see langword="false"/>.</param>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Template));
            this.pnlSettings = new System.Windows.Forms.Panel();
            this.rdoCustomSettings = new System.Windows.Forms.RadioButton();
            this.lblHeading = new System.Windows.Forms.Label();
            this.rdoGlobalSettings = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // pnlSettings
            // 
            resources.ApplyResources(this.pnlSettings, "pnlSettings");
            this.pnlSettings.BackColor = System.Drawing.SystemColors.Control;
            this.pnlSettings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSettings.Name = "pnlSettings";
            // 
            // rdoCustomSettings
            // 
            resources.ApplyResources(this.rdoCustomSettings, "rdoCustomSettings");
            this.rdoCustomSettings.Name = "rdoCustomSettings";
            this.rdoCustomSettings.UseVisualStyleBackColor = true;
            this.rdoCustomSettings.CheckedChanged += new System.EventHandler(this.rdoCustomSettings_CheckedChanged);
            // 
            // lblHeading
            // 
            resources.ApplyResources(this.lblHeading, "lblHeading");
            this.lblHeading.Name = "lblHeading";
            // 
            // rdoGlobalSettings
            // 
            resources.ApplyResources(this.rdoGlobalSettings, "rdoGlobalSettings");
            this.rdoGlobalSettings.Name = "rdoGlobalSettings";
            this.rdoGlobalSettings.UseVisualStyleBackColor = true;
            this.rdoGlobalSettings.CheckedChanged += new System.EventHandler(this.rdoGlobalSettings_CheckedChanged);
            // 
            // Template
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rdoCustomSettings);
            this.Controls.Add(this.lblHeading);
            this.Controls.Add(this.pnlSettings);
            this.Controls.Add(this.rdoGlobalSettings);
            this.Name = "Template";
            this.Load += new System.EventHandler(this.Template_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Panel pnlSettings;
        public System.Windows.Forms.RadioButton rdoCustomSettings;
        public System.Windows.Forms.Label lblHeading;
        public System.Windows.Forms.RadioButton rdoGlobalSettings;
    }
}
