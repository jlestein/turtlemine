namespace TurtleMine
{
    partial class OptionsDialog
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
			System.Windows.Forms.Label lblIssueListURL;
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionsDialog));
			this.btnTest = new System.Windows.Forms.Button();
			this.lnkFeedUrl = new System.Windows.Forms.LinkLabel();
			this.txtIssueListUrl = new System.Windows.Forms.TextBox();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.btnConnection = new System.Windows.Forms.Button();
			this.pnlConnectivity = new System.Windows.Forms.Panel();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOk = new System.Windows.Forms.Button();
			this.btnApply = new System.Windows.Forms.Button();
			lblIssueListURL = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// lblIssueListURL
			// 
			resources.ApplyResources(lblIssueListURL, "lblIssueListURL");
			lblIssueListURL.Name = "lblIssueListURL";
			// 
			// btnTest
			// 
			resources.ApplyResources(this.btnTest, "btnTest");
			this.btnTest.Name = "btnTest";
			this.btnTest.UseVisualStyleBackColor = true;
			this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
			// 
			// lnkFeedUrl
			// 
			resources.ApplyResources(this.lnkFeedUrl, "lnkFeedUrl");
			this.lnkFeedUrl.AutoEllipsis = true;
			this.lnkFeedUrl.Name = "lnkFeedUrl";
			this.lnkFeedUrl.UseMnemonic = false;
			this.lnkFeedUrl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkFeedUrl_LinkClicked);
			// 
			// txtIssueListUrl
			// 
			resources.ApplyResources(this.txtIssueListUrl, "txtIssueListUrl");
			this.txtIssueListUrl.Name = "txtIssueListUrl";
			this.toolTip1.SetToolTip(this.txtIssueListUrl, resources.GetString("txtIssueListUrl.ToolTip"));
			this.txtIssueListUrl.TextChanged += new System.EventHandler(this.txtIssueListUrl_TextChanged);
			// 
			// btnConnection
			// 
			this.btnConnection.Image = global::TurtleMine.Resources.Images.connectivity;
			resources.ApplyResources(this.btnConnection, "btnConnection");
			this.btnConnection.Name = "btnConnection";
			this.btnConnection.UseVisualStyleBackColor = true;
			this.btnConnection.Click += new System.EventHandler(this.btnConnection_Click);
			// 
			// pnlConnectivity
			// 
			resources.ApplyResources(this.pnlConnectivity, "pnlConnectivity");
			this.pnlConnectivity.Name = "pnlConnectivity";
			// 
			// btnCancel
			// 
			resources.ApplyResources(this.btnCancel, "btnCancel");
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Image = global::TurtleMine.Resources.Images.delete;
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// btnOk
			// 
			resources.ApplyResources(this.btnOk, "btnOk");
			this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOk.Image = global::TurtleMine.Resources.Images.accept;
			this.btnOk.Name = "btnOk";
			this.btnOk.UseVisualStyleBackColor = true;
			// 
			// btnApply
			// 
			resources.ApplyResources(this.btnApply, "btnApply");
			this.btnApply.Image = global::TurtleMine.Resources.Images.green_arrow_down;
			this.btnApply.Name = "btnApply";
			this.btnApply.UseVisualStyleBackColor = true;
			this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
			// 
			// OptionsDialog
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.btnApply);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.pnlConnectivity);
			this.Controls.Add(this.btnConnection);
			this.Controls.Add(this.btnTest);
			this.Controls.Add(this.lnkFeedUrl);
			this.Controls.Add(this.txtIssueListUrl);
			this.Controls.Add(lblIssueListURL);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "OptionsDialog";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OptionsDialog_FormClosing);
			this.Load += new System.EventHandler(this.OptionsDialog_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.LinkLabel lnkFeedUrl;
        private System.Windows.Forms.TextBox txtIssueListUrl;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnConnection;
        private System.Windows.Forms.Panel pnlConnectivity;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Button btnApply;
    }
}