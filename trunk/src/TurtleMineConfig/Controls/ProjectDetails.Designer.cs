namespace TurtleMine.Controls
{
    partial class ProjectDetails
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjectDetails));
            this.grpNameLocation = new System.Windows.Forms.GroupBox();
            this.picRepoType = new System.Windows.Forms.PictureBox();
            this.txtRepoName = new System.Windows.Forms.TextBox();
            this.lblRepoName = new System.Windows.Forms.Label();
            this.btnRepoPath = new System.Windows.Forms.Button();
            this.txtRepoPath = new System.Windows.Forms.TextBox();
            this.lblRepoPath = new System.Windows.Forms.Label();
            this.grpRedmineIssues = new System.Windows.Forms.GroupBox();
            this.btnVerifyLinks = new System.Windows.Forms.Button();
            this.dgvIssuesLists = new System.Windows.Forms.DataGridView();
            this.ProjectID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LinkID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ListName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IssuesURL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.errVerifyLinks = new System.Windows.Forms.ErrorProvider(this.components);
            this.chkRequireIssueNumber = new System.Windows.Forms.CheckBox();
            this.pnlSettings.SuspendLayout();
            this.grpNameLocation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picRepoType)).BeginInit();
            this.grpRedmineIssues.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIssuesLists)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errVerifyLinks)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSettings
            // 
            this.pnlSettings.Controls.Add(this.grpRedmineIssues);
            this.pnlSettings.Controls.Add(this.grpNameLocation);
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
            // grpNameLocation
            // 
            this.grpNameLocation.Controls.Add(this.chkRequireIssueNumber);
            this.grpNameLocation.Controls.Add(this.picRepoType);
            this.grpNameLocation.Controls.Add(this.txtRepoName);
            this.grpNameLocation.Controls.Add(this.lblRepoName);
            this.grpNameLocation.Controls.Add(this.btnRepoPath);
            this.grpNameLocation.Controls.Add(this.txtRepoPath);
            this.grpNameLocation.Controls.Add(this.lblRepoPath);
            resources.ApplyResources(this.grpNameLocation, "grpNameLocation");
            this.grpNameLocation.Name = "grpNameLocation";
            this.grpNameLocation.TabStop = false;
            // 
            // picRepoType
            // 
            resources.ApplyResources(this.picRepoType, "picRepoType");
            this.picRepoType.Name = "picRepoType";
            this.picRepoType.TabStop = false;
            // 
            // txtRepoName
            // 
            resources.ApplyResources(this.txtRepoName, "txtRepoName");
            this.txtRepoName.Name = "txtRepoName";
            // 
            // lblRepoName
            // 
            resources.ApplyResources(this.lblRepoName, "lblRepoName");
            this.lblRepoName.Name = "lblRepoName";
            // 
            // btnRepoPath
            // 
            this.btnRepoPath.BackColor = System.Drawing.SystemColors.Control;
            this.btnRepoPath.Image = global::TurtleMine.Resources.Images.folder;
            resources.ApplyResources(this.btnRepoPath, "btnRepoPath");
            this.btnRepoPath.Name = "btnRepoPath";
            this.btnRepoPath.UseVisualStyleBackColor = false;
            this.btnRepoPath.Click += new System.EventHandler(this.btnRepoPath_Click);
            // 
            // txtRepoPath
            // 
            this.txtRepoPath.BackColor = System.Drawing.Color.WhiteSmoke;
            resources.ApplyResources(this.txtRepoPath, "txtRepoPath");
            this.txtRepoPath.Name = "txtRepoPath";
            this.txtRepoPath.ReadOnly = true;
            // 
            // lblRepoPath
            // 
            resources.ApplyResources(this.lblRepoPath, "lblRepoPath");
            this.lblRepoPath.Name = "lblRepoPath";
            // 
            // grpRedmineIssues
            // 
            this.grpRedmineIssues.Controls.Add(this.btnVerifyLinks);
            this.grpRedmineIssues.Controls.Add(this.dgvIssuesLists);
            resources.ApplyResources(this.grpRedmineIssues, "grpRedmineIssues");
            this.grpRedmineIssues.Name = "grpRedmineIssues";
            this.grpRedmineIssues.TabStop = false;
            // 
            // btnVerifyLinks
            // 
            this.btnVerifyLinks.Image = global::TurtleMine.Resources.Images.accept;
            resources.ApplyResources(this.btnVerifyLinks, "btnVerifyLinks");
            this.btnVerifyLinks.Name = "btnVerifyLinks";
            this.btnVerifyLinks.UseVisualStyleBackColor = true;
            this.btnVerifyLinks.Click += new System.EventHandler(this.btnVerifyLinks_Click);
            // 
            // dgvIssuesLists
            // 
            this.dgvIssuesLists.AllowUserToOrderColumns = true;
            this.dgvIssuesLists.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIssuesLists.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProjectID,
            this.LinkID,
            this.ListName,
            this.IssuesURL});
            resources.ApplyResources(this.dgvIssuesLists, "dgvIssuesLists");
            this.dgvIssuesLists.MultiSelect = false;
            this.dgvIssuesLists.Name = "dgvIssuesLists";
            // 
            // ProjectID
            // 
            resources.ApplyResources(this.ProjectID, "ProjectID");
            this.ProjectID.Name = "ProjectID";
            this.ProjectID.ReadOnly = true;
            // 
            // LinkID
            // 
            resources.ApplyResources(this.LinkID, "LinkID");
            this.LinkID.Name = "LinkID";
            this.LinkID.ReadOnly = true;
            // 
            // ListName
            // 
            this.ListName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            resources.ApplyResources(this.ListName, "ListName");
            this.ListName.Name = "ListName";
            // 
            // IssuesURL
            // 
            this.IssuesURL.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            resources.ApplyResources(this.IssuesURL, "IssuesURL");
            this.IssuesURL.Name = "IssuesURL";
            // 
            // errVerifyLinks
            // 
            this.errVerifyLinks.ContainerControl = this;
            // 
            // chkRequireIssueNumber
            // 
            resources.ApplyResources(this.chkRequireIssueNumber, "chkRequireIssueNumber");
            this.chkRequireIssueNumber.Name = "chkRequireIssueNumber";
            this.chkRequireIssueNumber.UseVisualStyleBackColor = true;
            // 
            // ProjectDetails
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ProjectDetails";
            this.Load += new System.EventHandler(this.ProjectDetails_Load);
            this.pnlSettings.ResumeLayout(false);
            this.grpNameLocation.ResumeLayout(false);
            this.grpNameLocation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picRepoType)).EndInit();
            this.grpRedmineIssues.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIssuesLists)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errVerifyLinks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpNameLocation;
        private System.Windows.Forms.Button btnRepoPath;
        private System.Windows.Forms.TextBox txtRepoPath;
        private System.Windows.Forms.Label lblRepoPath;
        private System.Windows.Forms.TextBox txtRepoName;
        private System.Windows.Forms.Label lblRepoName;
        private System.Windows.Forms.GroupBox grpRedmineIssues;
        private System.Windows.Forms.DataGridView dgvIssuesLists;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProjectID;
        private System.Windows.Forms.DataGridViewTextBoxColumn LinkID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ListName;
        private System.Windows.Forms.DataGridViewTextBoxColumn IssuesURL;
        private System.Windows.Forms.Button btnVerifyLinks;
        private System.Windows.Forms.ErrorProvider errVerifyLinks;
		private System.Windows.Forms.PictureBox picRepoType;
        private System.Windows.Forms.CheckBox chkRequireIssueNumber;

    }
}
