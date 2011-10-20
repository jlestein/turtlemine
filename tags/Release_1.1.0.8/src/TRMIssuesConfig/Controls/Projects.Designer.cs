namespace TRMIssuesConfig.Controls
{
    partial class Projects
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Projects));
            this.lblProjects = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.clmName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.clmDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnNewProject = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblProjects
            // 
            resources.ApplyResources(this.lblProjects, "lblProjects");
            this.lblProjects.Name = "lblProjects";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmName,
            this.clmPath,
            this.clmEdit,
            this.clmDelete});
            resources.ApplyResources(this.dataGridView1, "dataGridView1");
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            // 
            // clmName
            // 
            resources.ApplyResources(this.clmName, "clmName");
            this.clmName.Name = "clmName";
            this.clmName.ReadOnly = true;
            // 
            // clmPath
            // 
            resources.ApplyResources(this.clmPath, "clmPath");
            this.clmPath.Name = "clmPath";
            this.clmPath.ReadOnly = true;
            // 
            // clmEdit
            // 
            this.clmEdit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            resources.ApplyResources(this.clmEdit, "clmEdit");
            this.clmEdit.Name = "clmEdit";
            this.clmEdit.ReadOnly = true;
            this.clmEdit.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clmEdit.Text = "Edit";
            this.clmEdit.UseColumnTextForButtonValue = true;
            // 
            // clmDelete
            // 
            this.clmDelete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            resources.ApplyResources(this.clmDelete, "clmDelete");
            this.clmDelete.Name = "clmDelete";
            this.clmDelete.ReadOnly = true;
            this.clmDelete.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clmDelete.Text = "Delete";
            this.clmDelete.UseColumnTextForButtonValue = true;
            // 
            // btnNewProject
            // 
            resources.ApplyResources(this.btnNewProject, "btnNewProject");
            this.btnNewProject.Name = "btnNewProject";
            this.btnNewProject.UseVisualStyleBackColor = true;
            this.btnNewProject.Click += new System.EventHandler(this.btnNewProject_Click);
            // 
            // Projects
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnNewProject);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lblProjects);
            this.Name = "Projects";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblProjects;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPath;
        private System.Windows.Forms.DataGridViewButtonColumn clmEdit;
        private System.Windows.Forms.DataGridViewButtonColumn clmDelete;
        private System.Windows.Forms.Button btnNewProject;
    }
}
