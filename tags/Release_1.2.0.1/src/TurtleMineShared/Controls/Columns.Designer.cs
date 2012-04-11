namespace TurtleMine.Controls
{
    partial class Columns
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Columns));
            this.lstCurrent = new System.Windows.Forms.ListBox();
            this.lstAvailable = new System.Windows.Forms.ListBox();
            this.lblCurrentColumns = new System.Windows.Forms.Label();
            this.lblAvailableColumns = new System.Windows.Forms.Label();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.pnlSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSettings
            // 
            resources.ApplyResources(this.pnlSettings, "pnlSettings");
            this.pnlSettings.Controls.Add(this.btnReset);
            this.pnlSettings.Controls.Add(this.btnDown);
            this.pnlSettings.Controls.Add(this.btnUp);
            this.pnlSettings.Controls.Add(this.lstCurrent);
            this.pnlSettings.Controls.Add(this.lstAvailable);
            this.pnlSettings.Controls.Add(this.lblCurrentColumns);
            this.pnlSettings.Controls.Add(this.lblAvailableColumns);
            this.pnlSettings.Controls.Add(this.btnLeft);
            this.pnlSettings.Controls.Add(this.btnRight);
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
            // lstCurrent
            // 
            resources.ApplyResources(this.lstCurrent, "lstCurrent");
            this.lstCurrent.FormattingEnabled = true;
            this.lstCurrent.Name = "lstCurrent";
            this.lstCurrent.SelectedIndexChanged += new System.EventHandler(this.lstCurrent_SelectedIndexChanged);
            // 
            // lstAvailable
            // 
            resources.ApplyResources(this.lstAvailable, "lstAvailable");
            this.lstAvailable.FormattingEnabled = true;
            this.lstAvailable.Name = "lstAvailable";
            // 
            // lblCurrentColumns
            // 
            resources.ApplyResources(this.lblCurrentColumns, "lblCurrentColumns");
            this.lblCurrentColumns.BackColor = System.Drawing.SystemColors.Control;
            this.lblCurrentColumns.Name = "lblCurrentColumns";
            // 
            // lblAvailableColumns
            // 
            resources.ApplyResources(this.lblAvailableColumns, "lblAvailableColumns");
            this.lblAvailableColumns.BackColor = System.Drawing.SystemColors.Control;
            this.lblAvailableColumns.Name = "lblAvailableColumns";
            // 
            // btnLeft
            // 
            resources.ApplyResources(this.btnLeft, "btnLeft");
            this.btnLeft.BackColor = System.Drawing.SystemColors.Control;
            this.btnLeft.Image = global::TurtleMine.Resources.Images.next;
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.UseVisualStyleBackColor = false;
            this.btnLeft.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // btnRight
            // 
            resources.ApplyResources(this.btnRight, "btnRight");
            this.btnRight.BackColor = System.Drawing.SystemColors.Control;
            this.btnRight.Image = global::TurtleMine.Resources.Images.back;
            this.btnRight.Name = "btnRight";
            this.btnRight.UseVisualStyleBackColor = false;
            this.btnRight.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // btnDown
            // 
            resources.ApplyResources(this.btnDown, "btnDown");
            this.btnDown.BackColor = System.Drawing.SystemColors.Control;
            this.btnDown.Image = global::TurtleMine.Resources.Images.down;
            this.btnDown.Name = "btnDown";
            this.btnDown.UseVisualStyleBackColor = false;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnUp
            // 
            resources.ApplyResources(this.btnUp, "btnUp");
            this.btnUp.BackColor = System.Drawing.SystemColors.Control;
            this.btnUp.Image = global::TurtleMine.Resources.Images.up;
            this.btnUp.Name = "btnUp";
            this.btnUp.UseVisualStyleBackColor = false;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnReset
            // 
            resources.ApplyResources(this.btnReset, "btnReset");
            this.btnReset.Image = global::TurtleMine.Resources.Images.orange_arrow_down;
            this.btnReset.Name = "btnReset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // Columns
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "Columns";
            this.Load += new System.EventHandler(this.Columns_Load);
            this.pnlSettings.ResumeLayout(false);
            this.pnlSettings.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstCurrent;
        private System.Windows.Forms.ListBox lstAvailable;
        private System.Windows.Forms.Label lblCurrentColumns;
        private System.Windows.Forms.Label lblAvailableColumns;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnUp;
		private System.Windows.Forms.Button btnReset;
    }
}
