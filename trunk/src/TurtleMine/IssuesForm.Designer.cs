namespace TurtleMine
{
    partial class IssuesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing"><c>true</c> if managed resources should be disposed; otherwise, <c>false</c>.</param>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IssuesForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lvwIssueList = new System.Windows.Forms.ListView();
            this.cmsIssueList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.chooseColumnsToDisplayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetIssueListDisplayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ilstSortImages = new System.Windows.Forms.ImageList(this.components);
            this.wbrDescription = new System.Windows.Forms.WebBrowser();
            this.pnlOkCancel = new System.Windows.Forms.Panel();
            this.chkIncludeSummary = new System.Windows.Forms.CheckBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.gbxSearch = new System.Windows.Forms.GroupBox();
            this.pnlSelection = new System.Windows.Forms.Panel();
            this.cboFields = new System.Windows.Forms.ComboBox();
            this.btnCheck = new System.Windows.Forms.Button();
            this.sspStatusVersion = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.pbrLoading = new System.Windows.Forms.ToolStripProgressBar();
            this.lblVersion = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblUpdateAvailable = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblUpdateCheckFailed = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnTimeEntry = new System.Windows.Forms.Button();
            this.btnOpenRedmine = new System.Windows.Forms.Button();
            this.btnDescription = new System.Windows.Forms.Button();
            this.helpProviderToolTip = new System.Windows.Forms.HelpProvider();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.pnlDoMore = new System.Windows.Forms.Panel();
            this.tmrNewVersion = new System.Windows.Forms.Timer(this.components);
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.cmsIssueList.SuspendLayout();
            this.pnlOkCancel.SuspendLayout();
            this.gbxSearch.SuspendLayout();
            this.pnlSelection.SuspendLayout();
            this.sspStatusVersion.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlDoMore.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lvwIssueList);
            resources.ApplyResources(this.splitContainer1.Panel1, "splitContainer1.Panel1");
            this.helpProviderToolTip.SetShowHelp(this.splitContainer1.Panel1, ((bool)(resources.GetObject("splitContainer1.Panel1.ShowHelp"))));
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.wbrDescription);
            resources.ApplyResources(this.splitContainer1.Panel2, "splitContainer1.Panel2");
            this.helpProviderToolTip.SetShowHelp(this.splitContainer1.Panel2, ((bool)(resources.GetObject("splitContainer1.Panel2.ShowHelp"))));
            this.splitContainer1.Panel2Collapsed = true;
            this.helpProviderToolTip.SetShowHelp(this.splitContainer1, ((bool)(resources.GetObject("splitContainer1.ShowHelp"))));
            // 
            // lvwIssueList
            // 
            this.lvwIssueList.AllowColumnReorder = true;
            this.lvwIssueList.CheckBoxes = true;
            this.lvwIssueList.ContextMenuStrip = this.cmsIssueList;
            resources.ApplyResources(this.lvwIssueList, "lvwIssueList");
            this.lvwIssueList.FullRowSelect = true;
            this.helpProviderToolTip.SetHelpString(this.lvwIssueList, resources.GetString("lvwIssueList.HelpString"));
            this.lvwIssueList.Name = "lvwIssueList";
            this.lvwIssueList.ShowGroups = false;
            this.helpProviderToolTip.SetShowHelp(this.lvwIssueList, ((bool)(resources.GetObject("lvwIssueList.ShowHelp"))));
            this.lvwIssueList.SmallImageList = this.ilstSortImages;
            this.lvwIssueList.UseCompatibleStateImageBehavior = false;
            this.lvwIssueList.View = System.Windows.Forms.View.Details;
            this.lvwIssueList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvwIssueList_ColumnClick);
            this.lvwIssueList.ColumnWidthChanged += new System.Windows.Forms.ColumnWidthChangedEventHandler(this.lvwIssueList_ColumnWidthChanged);
            this.lvwIssueList.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.lvwIssueList_ColumnWidthChanging);
            this.lvwIssueList.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lvwIssueList_ItemChecked);
            this.lvwIssueList.SelectedIndexChanged += new System.EventHandler(this.lvwIssueList_SelectedIndexChanged);
            // 
            // cmsIssueList
            // 
            this.cmsIssueList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chooseColumnsToDisplayToolStripMenuItem,
            this.resetIssueListDisplayToolStripMenuItem});
            this.cmsIssueList.Name = "cmsIssueList";
            this.helpProviderToolTip.SetShowHelp(this.cmsIssueList, ((bool)(resources.GetObject("cmsIssueList.ShowHelp"))));
            this.cmsIssueList.ShowImageMargin = false;
            this.cmsIssueList.ShowItemToolTips = false;
            resources.ApplyResources(this.cmsIssueList, "cmsIssueList");
            // 
            // chooseColumnsToDisplayToolStripMenuItem
            // 
            this.chooseColumnsToDisplayToolStripMenuItem.Name = "chooseColumnsToDisplayToolStripMenuItem";
            resources.ApplyResources(this.chooseColumnsToDisplayToolStripMenuItem, "chooseColumnsToDisplayToolStripMenuItem");
            this.chooseColumnsToDisplayToolStripMenuItem.Click += new System.EventHandler(this.chooseColumnsToDisplayToolStripMenuItem_Click);
            // 
            // resetIssueListDisplayToolStripMenuItem
            // 
            this.resetIssueListDisplayToolStripMenuItem.Name = "resetIssueListDisplayToolStripMenuItem";
            resources.ApplyResources(this.resetIssueListDisplayToolStripMenuItem, "resetIssueListDisplayToolStripMenuItem");
            this.resetIssueListDisplayToolStripMenuItem.Click += new System.EventHandler(this.resetIssueListDisplayToolStripMenuItem_Click);
            // 
            // ilstSortImages
            // 
            this.ilstSortImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilstSortImages.ImageStream")));
            this.ilstSortImages.TransparentColor = System.Drawing.Color.Transparent;
            this.ilstSortImages.Images.SetKeyName(0, "arrow_up");
            this.ilstSortImages.Images.SetKeyName(1, "arrow_down");
            // 
            // wbrDescription
            // 
            this.wbrDescription.AllowWebBrowserDrop = false;
            resources.ApplyResources(this.wbrDescription, "wbrDescription");
            this.wbrDescription.IsWebBrowserContextMenuEnabled = false;
            this.wbrDescription.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbrDescription.Name = "wbrDescription";
            this.wbrDescription.ScriptErrorsSuppressed = true;
            this.helpProviderToolTip.SetShowHelp(this.wbrDescription, ((bool)(resources.GetObject("wbrDescription.ShowHelp"))));
            this.wbrDescription.WebBrowserShortcutsEnabled = false;
            // 
            // pnlOkCancel
            // 
            this.pnlOkCancel.Controls.Add(this.chkIncludeSummary);
            this.pnlOkCancel.Controls.Add(this.btnOk);
            this.pnlOkCancel.Controls.Add(this.btnCancel);
            resources.ApplyResources(this.pnlOkCancel, "pnlOkCancel");
            this.pnlOkCancel.MinimumSize = new System.Drawing.Size(380, 0);
            this.pnlOkCancel.Name = "pnlOkCancel";
            this.helpProviderToolTip.SetShowHelp(this.pnlOkCancel, ((bool)(resources.GetObject("pnlOkCancel.ShowHelp"))));
            // 
            // chkIncludeSummary
            // 
            resources.ApplyResources(this.chkIncludeSummary, "chkIncludeSummary");
            this.helpProviderToolTip.SetHelpString(this.chkIncludeSummary, resources.GetString("chkIncludeSummary.HelpString"));
            this.chkIncludeSummary.Name = "chkIncludeSummary";
            this.helpProviderToolTip.SetShowHelp(this.chkIncludeSummary, ((bool)(resources.GetObject("chkIncludeSummary.ShowHelp"))));
            this.chkIncludeSummary.UseVisualStyleBackColor = false;
            this.chkIncludeSummary.CheckedChanged += new System.EventHandler(this.chkIncludeSummary_CheckedChanged);
            // 
            // btnOk
            // 
            resources.ApplyResources(this.btnOk, "btnOk");
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.helpProviderToolTip.SetHelpString(this.btnOk, resources.GetString("btnOk.HelpString"));
            this.btnOk.Image = global::TurtleMine.Resources.Images.accept;
            this.btnOk.Name = "btnOk";
            this.helpProviderToolTip.SetShowHelp(this.btnOk, ((bool)(resources.GetObject("btnOk.ShowHelp"))));
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.helpProviderToolTip.SetHelpString(this.btnCancel, resources.GetString("btnCancel.HelpString"));
            this.btnCancel.Image = global::TurtleMine.Resources.Images.delete;
            this.btnCancel.Name = "btnCancel";
            this.helpProviderToolTip.SetShowHelp(this.btnCancel, ((bool)(resources.GetObject("btnCancel.ShowHelp"))));
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            resources.ApplyResources(this.btnNext, "btnNext");
            this.helpProviderToolTip.SetHelpString(this.btnNext, resources.GetString("btnNext.HelpString"));
            this.btnNext.Image = global::TurtleMine.Resources.Images.next;
            this.btnNext.Name = "btnNext";
            this.helpProviderToolTip.SetShowHelp(this.btnNext, ((bool)(resources.GetObject("btnNext.ShowHelp"))));
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // txtSearch
            // 
            resources.ApplyResources(this.txtSearch, "txtSearch");
            this.helpProviderToolTip.SetHelpString(this.txtSearch, resources.GetString("txtSearch.HelpString"));
            this.txtSearch.Name = "txtSearch";
            this.helpProviderToolTip.SetShowHelp(this.txtSearch, ((bool)(resources.GetObject("txtSearch.ShowHelp"))));
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // gbxSearch
            // 
            resources.ApplyResources(this.gbxSearch, "gbxSearch");
            this.gbxSearch.Controls.Add(this.txtSearch);
            this.gbxSearch.Controls.Add(this.pnlSelection);
            this.gbxSearch.Name = "gbxSearch";
            this.helpProviderToolTip.SetShowHelp(this.gbxSearch, ((bool)(resources.GetObject("gbxSearch.ShowHelp"))));
            this.gbxSearch.TabStop = false;
            // 
            // pnlSelection
            // 
            this.pnlSelection.Controls.Add(this.cboFields);
            this.pnlSelection.Controls.Add(this.btnNext);
            this.pnlSelection.Controls.Add(this.btnCheck);
            resources.ApplyResources(this.pnlSelection, "pnlSelection");
            this.pnlSelection.Name = "pnlSelection";
            this.helpProviderToolTip.SetShowHelp(this.pnlSelection, ((bool)(resources.GetObject("pnlSelection.ShowHelp"))));
            // 
            // cboFields
            // 
            resources.ApplyResources(this.cboFields, "cboFields");
            this.cboFields.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboFields.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboFields.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFields.FormattingEnabled = true;
            this.helpProviderToolTip.SetHelpString(this.cboFields, resources.GetString("cboFields.HelpString"));
            this.cboFields.Name = "cboFields";
            this.helpProviderToolTip.SetShowHelp(this.cboFields, ((bool)(resources.GetObject("cboFields.ShowHelp"))));
            this.cboFields.SelectedIndexChanged += new System.EventHandler(this.cboFields_SelectedIndexChanged);
            // 
            // btnCheck
            // 
            resources.ApplyResources(this.btnCheck, "btnCheck");
            this.helpProviderToolTip.SetHelpString(this.btnCheck, resources.GetString("btnCheck.HelpString"));
            this.btnCheck.Image = global::TurtleMine.Resources.Images.button_Check;
            this.btnCheck.Name = "btnCheck";
            this.helpProviderToolTip.SetShowHelp(this.btnCheck, ((bool)(resources.GetObject("btnCheck.ShowHelp"))));
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // sspStatusVersion
            // 
            this.sspStatusVersion.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus,
            this.pbrLoading,
            this.lblVersion,
            this.lblUpdateAvailable,
            this.lblUpdateCheckFailed});
            this.sspStatusVersion.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            resources.ApplyResources(this.sspStatusVersion, "sspStatusVersion");
            this.sspStatusVersion.Name = "sspStatusVersion";
            this.helpProviderToolTip.SetShowHelp(this.sspStatusVersion, ((bool)(resources.GetObject("sspStatusVersion.ShowHelp"))));
            this.sspStatusVersion.ShowItemToolTips = true;
            // 
            // lblStatus
            // 
            this.lblStatus.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.lblStatus.Name = "lblStatus";
            resources.ApplyResources(this.lblStatus, "lblStatus");
            // 
            // pbrLoading
            // 
            this.pbrLoading.ForeColor = System.Drawing.Color.SteelBlue;
            this.pbrLoading.Name = "pbrLoading";
            resources.ApplyResources(this.pbrLoading, "pbrLoading");
            // 
            // lblVersion
            // 
            this.lblVersion.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblVersion.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.lblVersion.Name = "lblVersion";
            resources.ApplyResources(this.lblVersion, "lblVersion");
            // 
            // lblUpdateAvailable
            // 
            this.lblUpdateAvailable.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblUpdateAvailable.AutoToolTip = true;
            this.lblUpdateAvailable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblUpdateAvailable.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lblUpdateAvailable.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.lblUpdateAvailable.Image = global::TurtleMine.Resources.Images.download_link;
            this.lblUpdateAvailable.IsLink = true;
            this.lblUpdateAvailable.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lblUpdateAvailable.Name = "lblUpdateAvailable";
            resources.ApplyResources(this.lblUpdateAvailable, "lblUpdateAvailable");
            this.lblUpdateAvailable.Click += new System.EventHandler(this.lblUpdateAvailable_Click);
            // 
            // lblUpdateCheckFailed
            // 
            this.lblUpdateCheckFailed.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblUpdateCheckFailed.AutoToolTip = true;
            this.lblUpdateCheckFailed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lblUpdateCheckFailed.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lblUpdateCheckFailed.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.lblUpdateCheckFailed.Image = global::TurtleMine.Resources.Images.download_broken;
            this.lblUpdateCheckFailed.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lblUpdateCheckFailed.Name = "lblUpdateCheckFailed";
            resources.ApplyResources(this.lblUpdateCheckFailed, "lblUpdateCheckFailed");
            this.lblUpdateCheckFailed.ToolTipText = global::TurtleMine.Resources.Strings.ErrorInUpdatesConnectionTitle;
            // 
            // btnTimeEntry
            // 
            resources.ApplyResources(this.btnTimeEntry, "btnTimeEntry");
            this.helpProviderToolTip.SetHelpString(this.btnTimeEntry, resources.GetString("btnTimeEntry.HelpString"));
            this.btnTimeEntry.Image = global::TurtleMine.Resources.Images.clock;
            this.btnTimeEntry.Name = "btnTimeEntry";
            this.helpProviderToolTip.SetShowHelp(this.btnTimeEntry, ((bool)(resources.GetObject("btnTimeEntry.ShowHelp"))));
            this.btnTimeEntry.UseVisualStyleBackColor = true;
            this.btnTimeEntry.Click += new System.EventHandler(this.btnTimeEntry_Click);
            // 
            // btnOpenRedmine
            // 
            resources.ApplyResources(this.btnOpenRedmine, "btnOpenRedmine");
            this.helpProviderToolTip.SetHelpString(this.btnOpenRedmine, resources.GetString("btnOpenRedmine.HelpString"));
            this.btnOpenRedmine.Image = global::TurtleMine.Resources.Images.globe;
            this.btnOpenRedmine.Name = "btnOpenRedmine";
            this.helpProviderToolTip.SetShowHelp(this.btnOpenRedmine, ((bool)(resources.GetObject("btnOpenRedmine.ShowHelp"))));
            this.btnOpenRedmine.UseVisualStyleBackColor = true;
            this.btnOpenRedmine.Click += new System.EventHandler(this.btnOpenRedmine_Click);
            // 
            // btnDescription
            // 
            resources.ApplyResources(this.btnDescription, "btnDescription");
            this.helpProviderToolTip.SetHelpString(this.btnDescription, resources.GetString("btnDescription.HelpString"));
            this.btnDescription.Image = global::TurtleMine.Resources.Images.note_book;
            this.btnDescription.Name = "btnDescription";
            this.helpProviderToolTip.SetShowHelp(this.btnDescription, ((bool)(resources.GetObject("btnDescription.ShowHelp"))));
            this.btnDescription.UseVisualStyleBackColor = true;
            this.btnDescription.Click += new System.EventHandler(this.btnDescription_Click);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.pnlDoMore);
            this.pnlBottom.Controls.Add(this.pnlOkCancel);
            resources.ApplyResources(this.pnlBottom, "pnlBottom");
            this.pnlBottom.Name = "pnlBottom";
            this.helpProviderToolTip.SetShowHelp(this.pnlBottom, ((bool)(resources.GetObject("pnlBottom.ShowHelp"))));
            // 
            // pnlDoMore
            // 
            this.pnlDoMore.Controls.Add(this.btnDescription);
            this.pnlDoMore.Controls.Add(this.btnOpenRedmine);
            this.pnlDoMore.Controls.Add(this.btnTimeEntry);
            resources.ApplyResources(this.pnlDoMore, "pnlDoMore");
            this.pnlDoMore.MinimumSize = new System.Drawing.Size(360, 0);
            this.pnlDoMore.Name = "pnlDoMore";
            this.helpProviderToolTip.SetShowHelp(this.pnlDoMore, ((bool)(resources.GetObject("pnlDoMore.ShowHelp"))));
            // 
            // tmrNewVersion
            // 
            this.tmrNewVersion.Enabled = true;
            this.tmrNewVersion.Interval = 500;
            this.tmrNewVersion.Tick += new System.EventHandler(this.tmrNewVersion_Tick);
            // 
            // IssuesForm
            // 
            this.AcceptButton = this.btnOk;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.sspStatusVersion);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.gbxSearch);
            this.HelpButton = true;
            this.Icon = global::TurtleMine.Resources.Images.TRMLogo;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IssuesForm";
            this.helpProviderToolTip.SetShowHelp(this, ((bool)(resources.GetObject("$this.ShowHelp"))));
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.myIssuesForm_FormClosing);
            this.Load += new System.EventHandler(this.myIssuesForm_Load);
            this.Shown += new System.EventHandler(this.myIssuesForm_Shown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.cmsIssueList.ResumeLayout(false);
            this.pnlOkCancel.ResumeLayout(false);
            this.gbxSearch.ResumeLayout(false);
            this.gbxSearch.PerformLayout();
            this.pnlSelection.ResumeLayout(false);
            this.sspStatusVersion.ResumeLayout(false);
            this.sspStatusVersion.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.pnlDoMore.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ListView lvwIssueList;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.GroupBox gbxSearch;
        private System.Windows.Forms.WebBrowser wbrDescription;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnDescription;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Panel pnlSelection;
        private System.Windows.Forms.Button btnOpenRedmine;
        private System.Windows.Forms.Button btnTimeEntry;
        private System.Windows.Forms.StatusStrip sspStatusVersion;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripProgressBar pbrLoading;
        private System.Windows.Forms.ToolStripStatusLabel lblVersion;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.ToolStripStatusLabel lblUpdateAvailable;
        private System.Windows.Forms.ToolStripStatusLabel lblUpdateCheckFailed;
        private System.Windows.Forms.HelpProvider helpProviderToolTip;
        private System.Windows.Forms.ContextMenuStrip cmsIssueList;
        private System.Windows.Forms.ToolStripMenuItem resetIssueListDisplayToolStripMenuItem;
        private System.Windows.Forms.ImageList ilstSortImages;
        private System.Windows.Forms.ToolStripMenuItem chooseColumnsToDisplayToolStripMenuItem;
        private System.Windows.Forms.CheckBox chkIncludeSummary;
        private System.Windows.Forms.Timer tmrNewVersion;
        private System.Windows.Forms.ComboBox cboFields;
        private System.Windows.Forms.Panel pnlOkCancel;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Panel pnlDoMore;
    }
}