namespace TurtleMine.Controls
{
    partial class Words
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Words));
            this.btnDown = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.lblWordList = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lstWordList = new System.Windows.Forms.ListBox();
            this.pnlSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSettings
            // 
            this.pnlSettings.Controls.Add(this.btnDelete);
            this.pnlSettings.Controls.Add(this.btnAdd);
            this.pnlSettings.Controls.Add(this.btnDown);
            this.pnlSettings.Controls.Add(this.btnUp);
            this.pnlSettings.Controls.Add(this.lblWordList);
            this.pnlSettings.Controls.Add(this.lstWordList);
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
            // btnDown
            // 
            this.btnDown.BackColor = System.Drawing.SystemColors.Control;
            this.btnDown.Image = global::TurtleMine.Resources.Images.down;
            resources.ApplyResources(this.btnDown, "btnDown");
            this.btnDown.Name = "btnDown";
            this.btnDown.UseVisualStyleBackColor = false;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnUp
            // 
            this.btnUp.BackColor = System.Drawing.SystemColors.Control;
            this.btnUp.Image = global::TurtleMine.Resources.Images.up;
            resources.ApplyResources(this.btnUp, "btnUp");
            this.btnUp.Name = "btnUp";
            this.btnUp.UseVisualStyleBackColor = false;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // lblWordList
            // 
            resources.ApplyResources(this.lblWordList, "lblWordList");
            this.lblWordList.BackColor = System.Drawing.SystemColors.Control;
            this.lblWordList.Name = "lblWordList";
            // 
            // btnAdd
            // 
            this.btnAdd.Image = global::TurtleMine.Resources.Images.add;
            resources.ApplyResources(this.btnAdd, "btnAdd");
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Image = global::TurtleMine.Resources.Images.delete;
            resources.ApplyResources(this.btnDelete, "btnDelete");
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lstWordList
            // 
            resources.ApplyResources(this.lstWordList, "lstWordList");
            this.lstWordList.FormattingEnabled = true;
            this.lstWordList.Name = "lstWordList";
            this.lstWordList.SelectedIndexChanged += new System.EventHandler(this.lstWordList_SelectedIndexChanged);
            // 
            // Words
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "Words";
            this.Load += new System.EventHandler(this.Words_Load);
            this.pnlSettings.ResumeLayout(false);
            this.pnlSettings.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Label lblWordList;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListBox lstWordList;

    }
}
