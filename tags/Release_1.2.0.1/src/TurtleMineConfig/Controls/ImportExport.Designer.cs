namespace TurtleMine.Controls
{
    partial class ImportExport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportExport));
            this.grpExport = new System.Windows.Forms.GroupBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnExportPath = new System.Windows.Forms.Button();
            this.txtExportPath = new System.Windows.Forms.TextBox();
            this.lblExportPath = new System.Windows.Forms.Label();
            this.grpImport = new System.Windows.Forms.GroupBox();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnImportPath = new System.Windows.Forms.Button();
            this.txtImportPath = new System.Windows.Forms.TextBox();
            this.lblImportPath = new System.Windows.Forms.Label();
            this.pnlSettings.SuspendLayout();
            this.grpExport.SuspendLayout();
            this.grpImport.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSettings
            // 
            resources.ApplyResources(this.pnlSettings, "pnlSettings");
            this.pnlSettings.Controls.Add(this.grpImport);
            this.pnlSettings.Controls.Add(this.grpExport);
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
            // grpExport
            // 
            resources.ApplyResources(this.grpExport, "grpExport");
            this.grpExport.Controls.Add(this.btnExport);
            this.grpExport.Controls.Add(this.btnExportPath);
            this.grpExport.Controls.Add(this.txtExportPath);
            this.grpExport.Controls.Add(this.lblExportPath);
            this.grpExport.Name = "grpExport";
            this.grpExport.TabStop = false;
            // 
            // btnExport
            // 
            resources.ApplyResources(this.btnExport, "btnExport");
            this.btnExport.Image = global::TurtleMine.Resources.Images.page_down;
            this.btnExport.Name = "btnExport";
            this.btnExport.UseVisualStyleBackColor = true;
            // 
            // btnExportPath
            // 
            resources.ApplyResources(this.btnExportPath, "btnExportPath");
            this.btnExportPath.BackColor = System.Drawing.SystemColors.Control;
            this.btnExportPath.Image = global::TurtleMine.Resources.Images.folder;
            this.btnExportPath.Name = "btnExportPath";
            this.btnExportPath.UseVisualStyleBackColor = false;
            // 
            // txtExportPath
            // 
            resources.ApplyResources(this.txtExportPath, "txtExportPath");
            this.txtExportPath.Name = "txtExportPath";
            // 
            // lblExportPath
            // 
            resources.ApplyResources(this.lblExportPath, "lblExportPath");
            this.lblExportPath.Name = "lblExportPath";
            // 
            // grpImport
            // 
            resources.ApplyResources(this.grpImport, "grpImport");
            this.grpImport.Controls.Add(this.btnImport);
            this.grpImport.Controls.Add(this.btnImportPath);
            this.grpImport.Controls.Add(this.txtImportPath);
            this.grpImport.Controls.Add(this.lblImportPath);
            this.grpImport.Name = "grpImport";
            this.grpImport.TabStop = false;
            // 
            // btnImport
            // 
            resources.ApplyResources(this.btnImport, "btnImport");
            this.btnImport.Image = global::TurtleMine.Resources.Images.page_up;
            this.btnImport.Name = "btnImport";
            this.btnImport.UseVisualStyleBackColor = true;
            // 
            // btnImportPath
            // 
            resources.ApplyResources(this.btnImportPath, "btnImportPath");
            this.btnImportPath.BackColor = System.Drawing.SystemColors.Control;
            this.btnImportPath.Image = global::TurtleMine.Resources.Images.folder;
            this.btnImportPath.Name = "btnImportPath";
            this.btnImportPath.UseVisualStyleBackColor = false;
            // 
            // txtImportPath
            // 
            resources.ApplyResources(this.txtImportPath, "txtImportPath");
            this.txtImportPath.Name = "txtImportPath";
            // 
            // lblImportPath
            // 
            resources.ApplyResources(this.lblImportPath, "lblImportPath");
            this.lblImportPath.Name = "lblImportPath";
            // 
            // ImportExport
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ImportExport";
            this.pnlSettings.ResumeLayout(false);
            this.grpExport.ResumeLayout(false);
            this.grpExport.PerformLayout();
            this.grpImport.ResumeLayout(false);
            this.grpImport.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpExport;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnExportPath;
        private System.Windows.Forms.TextBox txtExportPath;
        private System.Windows.Forms.Label lblExportPath;
        private System.Windows.Forms.GroupBox grpImport;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnImportPath;
        private System.Windows.Forms.TextBox txtImportPath;
        private System.Windows.Forms.Label lblImportPath;

    }
}
