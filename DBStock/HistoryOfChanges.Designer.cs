namespace DBStock
{
    partial class HistoryOfChanges
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
            this.dataGridViewRecipies = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.печатьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRecipies)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewRecipies
            // 
            this.dataGridViewRecipies.AllowUserToAddRows = false;
            this.dataGridViewRecipies.AllowUserToDeleteRows = false;
            this.dataGridViewRecipies.AllowUserToOrderColumns = true;
            this.dataGridViewRecipies.AllowUserToResizeColumns = false;
            this.dataGridViewRecipies.AllowUserToResizeRows = false;
            this.dataGridViewRecipies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRecipies.Location = new System.Drawing.Point(0, 27);
            this.dataGridViewRecipies.Name = "dataGridViewRecipies";
            this.dataGridViewRecipies.ReadOnly = true;
            this.dataGridViewRecipies.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewRecipies.Size = new System.Drawing.Size(849, 507);
            this.dataGridViewRecipies.TabIndex = 0;
            this.dataGridViewRecipies.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.печатьToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(854, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // печатьToolStripMenuItem
            // 
            this.печатьToolStripMenuItem.Name = "печатьToolStripMenuItem";
            this.печатьToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.печатьToolStripMenuItem.Text = "Печать";
            this.печатьToolStripMenuItem.Click += new System.EventHandler(this.печатьToolStripMenuItem_Click);
            // 
            // HistoryOfChanges
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 556);
            this.Controls.Add(this.dataGridViewRecipies);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "HistoryOfChanges";
            this.Text = "История изменений";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HistoryOfChanges_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRecipies)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewRecipies;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem печатьToolStripMenuItem;
    }
}