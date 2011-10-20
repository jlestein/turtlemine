namespace TRMIssuesConfig
{
    partial class ProjectConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjectConfig));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lstOptions = new System.Windows.Forms.ListView();
            this.ilLargeIcons = new System.Windows.Forms.ImageList(this.components);
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
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
            // 
            // lstOptions
            // 
            this.lstOptions.Activation = System.Windows.Forms.ItemActivation.OneClick;
            resources.ApplyResources(this.lstOptions, "lstOptions");
            this.lstOptions.BackColor = System.Drawing.SystemColors.Info;
            this.lstOptions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstOptions.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            ((System.Windows.Forms.ListViewGroup)(resources.GetObject("lstOptions.Groups"))),
            ((System.Windows.Forms.ListViewGroup)(resources.GetObject("lstOptions.Groups1")))});
            this.lstOptions.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            ((System.Windows.Forms.ListViewItem)(resources.GetObject("lstOptions.Items"))),
            ((System.Windows.Forms.ListViewItem)(resources.GetObject("lstOptions.Items1"))),
            ((System.Windows.Forms.ListViewItem)(resources.GetObject("lstOptions.Items2"))),
            ((System.Windows.Forms.ListViewItem)(resources.GetObject("lstOptions.Items3")))});
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
            this.ilLargeIcons.Images.SetKeyName(0, "Project");
            this.ilLargeIcons.Images.SetKeyName(1, "Connectivity");
            this.ilLargeIcons.Images.SetKeyName(2, "Words");
            this.ilLargeIcons.Images.SetKeyName(3, "Columns");
            // 
            // ProjectConfig
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.MaximizeBox = false;
            this.Name = "ProjectConfig";
            this.Load += new System.EventHandler(this.projectSettings_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView lstOptions;
        private System.Windows.Forms.ImageList ilLargeIcons;
    }
}

