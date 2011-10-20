namespace TRMIssues
{
    partial class ColumnChooser
    {
        ///// <summary>
        ///// Clean up any resources being used.
        ///// </summary>
        ///// <param name="disposing"><c>true</c> if managed resources should be disposed; otherwise, <c>false</c>.</param>
        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing && (components != null))
        //    {
        //        components.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ColumnChooser));
            this.pnlChooser = new System.Windows.Forms.Panel();
            this.lstCurrent = new System.Windows.Forms.ListBox();
            this.lstAvailable = new System.Windows.Forms.ListBox();
            this.lblCurrentColumns = new System.Windows.Forms.Label();
            this.lblAvailableColumns = new System.Windows.Forms.Label();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.pnlOkCancel = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.pnlChooser.SuspendLayout();
            this.pnlOkCancel.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlChooser
            // 
            this.pnlChooser.Controls.Add(this.lstCurrent);
            this.pnlChooser.Controls.Add(this.lstAvailable);
            this.pnlChooser.Controls.Add(this.lblCurrentColumns);
            this.pnlChooser.Controls.Add(this.lblAvailableColumns);
            this.pnlChooser.Controls.Add(this.btnLeft);
            this.pnlChooser.Controls.Add(this.btnRight);
            this.pnlChooser.Controls.Add(this.pnlOkCancel);
            resources.ApplyResources(this.pnlChooser, "pnlChooser");
            this.pnlChooser.Name = "pnlChooser";
            // 
            // lstCurrent
            // 
            resources.ApplyResources(this.lstCurrent, "lstCurrent");
            this.lstCurrent.FormattingEnabled = true;
            this.lstCurrent.Name = "lstCurrent";
            this.lstCurrent.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            // 
            // lstAvailable
            // 
            resources.ApplyResources(this.lstAvailable, "lstAvailable");
            this.lstAvailable.FormattingEnabled = true;
            this.lstAvailable.Name = "lstAvailable";
            this.lstAvailable.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            // 
            // lblCurrentColumns
            // 
            resources.ApplyResources(this.lblCurrentColumns, "lblCurrentColumns");
            this.lblCurrentColumns.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblCurrentColumns.Name = "lblCurrentColumns";
            // 
            // lblAvailableColumns
            // 
            resources.ApplyResources(this.lblAvailableColumns, "lblAvailableColumns");
            this.lblAvailableColumns.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblAvailableColumns.Name = "lblAvailableColumns";
            // 
            // btnLeft
            // 
            this.btnLeft.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnLeft.Image = global::TRMIssues.Properties.Resources.back;
            resources.ApplyResources(this.btnLeft, "btnLeft");
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.UseVisualStyleBackColor = false;
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // btnRight
            // 
            this.btnRight.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnRight.Image = global::TRMIssues.Properties.Resources.next;
            resources.ApplyResources(this.btnRight, "btnRight");
            this.btnRight.Name = "btnRight";
            this.btnRight.UseVisualStyleBackColor = false;
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // pnlOkCancel
            // 
            this.pnlOkCancel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlOkCancel.Controls.Add(this.btnCancel);
            this.pnlOkCancel.Controls.Add(this.btnOk);
            resources.ApplyResources(this.pnlOkCancel, "pnlOkCancel");
            this.pnlOkCancel.Name = "pnlOkCancel";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::TRMIssues.Properties.Resources.delete;
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Image = global::TRMIssues.Properties.Resources.accept;
            resources.ApplyResources(this.btnOk, "btnOk");
            this.btnOk.Name = "btnOk";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // ColumnChooser
            // 
            this.AcceptButton = this.btnOk;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.CancelButton = this.btnCancel;
            this.Controls.Add(this.pnlChooser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ColumnChooser";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.columnChooser_Load);
            this.pnlChooser.ResumeLayout(false);
            this.pnlChooser.PerformLayout();
            this.pnlOkCancel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlChooser;
        private System.Windows.Forms.Panel pnlOkCancel;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label lblCurrentColumns;
        private System.Windows.Forms.Label lblAvailableColumns;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.ListBox lstCurrent;
        private System.Windows.Forms.ListBox lstAvailable;

    }
}