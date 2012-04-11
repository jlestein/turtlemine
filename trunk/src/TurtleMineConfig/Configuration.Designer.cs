namespace TurtleMine
{
    partial class Configuration
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Configuration));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lstOptions = new System.Windows.Forms.ListView();
            this.ilLargeIcons = new System.Windows.Forms.ImageList(this.components);
            this.lstOptionsProject = new System.Windows.Forms.ListView();
            this.pnlGlobal = new System.Windows.Forms.Panel();
            this.pnlProject = new System.Windows.Forms.Panel();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lstOptions);
            this.splitContainer1.Panel1.Controls.Add(this.lstOptionsProject);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pnlGlobal);
            this.splitContainer1.Panel2.Controls.Add(this.pnlProject);
            this.splitContainer1.Panel2.Controls.Add(this.pnlButtons);
            this.splitContainer1.TabStop = false;
            // 
            // lstOptions
            // 
            this.lstOptions.Activation = System.Windows.Forms.ItemActivation.OneClick;
            resources.ApplyResources(this.lstOptions, "lstOptions");
            this.lstOptions.BackColor = System.Drawing.SystemColors.Info;
            this.lstOptions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstOptions.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            ((System.Windows.Forms.ListViewGroup)(resources.GetObject("lstOptions.Groups"))),
            ((System.Windows.Forms.ListViewGroup)(resources.GetObject("lstOptions.Groups1"))),
            ((System.Windows.Forms.ListViewGroup)(resources.GetObject("lstOptions.Groups2")))});
            this.lstOptions.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstOptions.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            ((System.Windows.Forms.ListViewItem)(resources.GetObject("lstOptions.Items"))),
            ((System.Windows.Forms.ListViewItem)(resources.GetObject("lstOptions.Items1"))),
            ((System.Windows.Forms.ListViewItem)(resources.GetObject("lstOptions.Items2"))),
            ((System.Windows.Forms.ListViewItem)(resources.GetObject("lstOptions.Items3"))),
            ((System.Windows.Forms.ListViewItem)(resources.GetObject("lstOptions.Items4"))),
            ((System.Windows.Forms.ListViewItem)(resources.GetObject("lstOptions.Items5"))),
            ((System.Windows.Forms.ListViewItem)(resources.GetObject("lstOptions.Items6")))});
            this.lstOptions.LargeImageList = this.ilLargeIcons;
            this.lstOptions.MinimumSize = new System.Drawing.Size(170, 530);
            this.lstOptions.MultiSelect = false;
            this.lstOptions.Name = "lstOptions";
            this.lstOptions.Scrollable = false;
            this.lstOptions.TileSize = new System.Drawing.Size(170, 56);
            this.lstOptions.UseCompatibleStateImageBehavior = false;
            this.lstOptions.View = System.Windows.Forms.View.Tile;
            this.lstOptions.SelectedIndexChanged += new System.EventHandler(this.lstOptions_SelectedIndexChanged);
            // 
            // ilLargeIcons
            // 
            this.ilLargeIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilLargeIcons.ImageStream")));
            this.ilLargeIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.ilLargeIcons.Images.SetKeyName(0, "Projects");
            this.ilLargeIcons.Images.SetKeyName(1, "Project");
            this.ilLargeIcons.Images.SetKeyName(2, "Connectivity");
            this.ilLargeIcons.Images.SetKeyName(3, "Words");
            this.ilLargeIcons.Images.SetKeyName(4, "Columns");
            this.ilLargeIcons.Images.SetKeyName(5, "Updates");
            this.ilLargeIcons.Images.SetKeyName(6, "Import_Export");
            this.ilLargeIcons.Images.SetKeyName(7, "About");
            // 
            // lstOptionsProject
            // 
            this.lstOptionsProject.Activation = System.Windows.Forms.ItemActivation.OneClick;
            resources.ApplyResources(this.lstOptionsProject, "lstOptionsProject");
            this.lstOptionsProject.BackColor = System.Drawing.SystemColors.Info;
            this.lstOptionsProject.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstOptionsProject.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            ((System.Windows.Forms.ListViewGroup)(resources.GetObject("lstOptionsProject.Groups"))),
            ((System.Windows.Forms.ListViewGroup)(resources.GetObject("lstOptionsProject.Groups1")))});
            this.lstOptionsProject.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            ((System.Windows.Forms.ListViewItem)(resources.GetObject("lstOptionsProject.Items"))),
            ((System.Windows.Forms.ListViewItem)(resources.GetObject("lstOptionsProject.Items1"))),
            ((System.Windows.Forms.ListViewItem)(resources.GetObject("lstOptionsProject.Items2"))),
            ((System.Windows.Forms.ListViewItem)(resources.GetObject("lstOptionsProject.Items3")))});
            this.lstOptionsProject.LargeImageList = this.ilLargeIcons;
            this.lstOptionsProject.MinimumSize = new System.Drawing.Size(170, 530);
            this.lstOptionsProject.MultiSelect = false;
            this.lstOptionsProject.Name = "lstOptionsProject";
            this.lstOptionsProject.Scrollable = false;
            this.lstOptionsProject.TileSize = new System.Drawing.Size(170, 56);
            this.lstOptionsProject.UseCompatibleStateImageBehavior = false;
            this.lstOptionsProject.View = System.Windows.Forms.View.Tile;
            this.lstOptionsProject.SelectedIndexChanged += new System.EventHandler(this.lstOptionsProject_SelectedIndexChanged);
            // 
            // pnlGlobal
            // 
            resources.ApplyResources(this.pnlGlobal, "pnlGlobal");
            this.pnlGlobal.Name = "pnlGlobal";
            // 
            // pnlProject
            // 
            resources.ApplyResources(this.pnlProject, "pnlProject");
            this.pnlProject.Name = "pnlProject";
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnApply);
            this.pnlButtons.Controls.Add(this.btnCancel);
            this.pnlButtons.Controls.Add(this.btnOk);
            resources.ApplyResources(this.pnlButtons, "pnlButtons");
            this.pnlButtons.Name = "pnlButtons";
            // 
            // btnApply
            // 
            resources.ApplyResources(this.btnApply, "btnApply");
            this.btnApply.Image = global::TurtleMine.Resources.Images.green_arrow_down;
            this.btnApply.Name = "btnApply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Image = global::TurtleMine.Resources.Images.delete;
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Image = global::TurtleMine.Resources.Images.accept;
            resources.ApplyResources(this.btnOk, "btnOk");
            this.btnOk.Name = "btnOk";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // Configuration
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Configuration";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.configuration_FormClosing);
            this.Load += new System.EventHandler(this.configuration_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView lstOptions;
        private System.Windows.Forms.ImageList ilLargeIcons;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.ListView lstOptionsProject;
        private System.Windows.Forms.Panel pnlGlobal;
        private System.Windows.Forms.Panel pnlProject;
    }
}

