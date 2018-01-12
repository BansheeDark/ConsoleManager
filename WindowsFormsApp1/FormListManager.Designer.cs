namespace ConsoleManager
{
    partial class FormListManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormListManager));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuCommand = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuStart = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuStartCommand = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuStartWithoutKey = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.lToolStripMenuCancel = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuCommand,
            this.toolStripMenuStart,
            this.toolStripMenuSave,
            this.toolStripMenuUpdate,
            this.toolStripMenuQuit,
            this.lToolStripMenuCancel});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(637, 24);
            this.menuStrip1.TabIndex = 25;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuCommand
            // 
            this.toolStripMenuCommand.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuAdd,
            this.toolStripMenuDelete});
            this.toolStripMenuCommand.Name = "toolStripMenuCommand";
            this.toolStripMenuCommand.Size = new System.Drawing.Size(76, 20);
            this.toolStripMenuCommand.Text = "Command";
            // 
            // toolStripMenuAdd
            // 
            this.toolStripMenuAdd.Name = "toolStripMenuAdd";
            this.toolStripMenuAdd.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuAdd.Text = "Add";
            this.toolStripMenuAdd.Click += new System.EventHandler(this.ToolStripMenuAdd_Click);
            // 
            // toolStripMenuDelete
            // 
            this.toolStripMenuDelete.Name = "toolStripMenuDelete";
            this.toolStripMenuDelete.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuDelete.Text = "Delete ";
            this.toolStripMenuDelete.Click += new System.EventHandler(this.ToolStripMenuDelete_Click);
            // 
            // toolStripMenuStart
            // 
            this.toolStripMenuStart.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuStartCommand,
            this.ToolStripMenuStartWithoutKey});
            this.toolStripMenuStart.Name = "toolStripMenuStart";
            this.toolStripMenuStart.Size = new System.Drawing.Size(43, 20);
            this.toolStripMenuStart.Text = "Start";
            // 
            // ToolStripMenuStartCommand
            // 
            this.ToolStripMenuStartCommand.Name = "ToolStripMenuStartCommand";
            this.ToolStripMenuStartCommand.Size = new System.Drawing.Size(166, 22);
            this.ToolStripMenuStartCommand.Text = "Start Command";
            this.ToolStripMenuStartCommand.Click += new System.EventHandler(this.ToolStripMenuStartCommand_Click);
            // 
            // ToolStripMenuStartWithoutKey
            // 
            this.ToolStripMenuStartWithoutKey.Name = "ToolStripMenuStartWithoutKey";
            this.ToolStripMenuStartWithoutKey.Size = new System.Drawing.Size(166, 22);
            this.ToolStripMenuStartWithoutKey.Text = "Start Without Key";
            // 
            // toolStripMenuSave
            // 
            this.toolStripMenuSave.Name = "toolStripMenuSave";
            this.toolStripMenuSave.Size = new System.Drawing.Size(43, 20);
            this.toolStripMenuSave.Text = "Save";
            this.toolStripMenuSave.Click += new System.EventHandler(this.ToolStripMenuSave_Click);
            // 
            // toolStripMenuUpdate
            // 
            this.toolStripMenuUpdate.Name = "toolStripMenuUpdate";
            this.toolStripMenuUpdate.Size = new System.Drawing.Size(57, 20);
            this.toolStripMenuUpdate.Text = "Update";
            this.toolStripMenuUpdate.Click += new System.EventHandler(this.ToolStripMenuUpdate_Click);
            // 
            // toolStripMenuQuit
            // 
            this.toolStripMenuQuit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripMenuQuit.Name = "toolStripMenuQuit";
            this.toolStripMenuQuit.Size = new System.Drawing.Size(42, 20);
            this.toolStripMenuQuit.Text = "Quit";
            // 
            // lToolStripMenuCancel
            // 
            this.lToolStripMenuCancel.Name = "lToolStripMenuCancel";
            this.lToolStripMenuCancel.Size = new System.Drawing.Size(55, 20);
            this.lToolStripMenuCancel.Text = "Cancel";
            this.lToolStripMenuCancel.Click += new System.EventHandler(this.ToolStripMenuCancel_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Desktop;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.AppWorkspace;
            this.dataGridView1.Location = new System.Drawing.Point(0, 24);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.Red;
            this.dataGridView1.Size = new System.Drawing.Size(637, 565);
            this.dataGridView1.TabIndex = 24;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellClick);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellDoubleClick);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.DataGridView1_SelectionChanged);
            // 
            // FormListManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.ClientSize = new System.Drawing.Size(637, 589);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.SystemColors.Menu;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormListManager";
            this.Load += new System.EventHandler(this.FormListManager_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormListManager_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuUpdate;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuCommand;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuAdd;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuDelete;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuStart;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuSave;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuQuit;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripMenuItem lToolStripMenuCancel;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuStartCommand;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuStartWithoutKey;
    }
}