namespace DBStock
{
    partial class WorkingWithCategories
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
            this.dataGridViewCategories = new System.Windows.Forms.DataGridView();
            this.buttonAddCategory = new System.Windows.Forms.Button();
            this.textBoxCategory = new System.Windows.Forms.TextBox();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.textBoxV = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.labelV = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCategories)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewCategories
            // 
            this.dataGridViewCategories.AllowDrop = true;
            this.dataGridViewCategories.AllowUserToAddRows = false;
            this.dataGridViewCategories.AllowUserToDeleteRows = false;
            this.dataGridViewCategories.AllowUserToResizeColumns = false;
            this.dataGridViewCategories.AllowUserToResizeRows = false;
            this.dataGridViewCategories.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCategories.Location = new System.Drawing.Point(200, 23);
            this.dataGridViewCategories.Name = "dataGridViewCategories";
            this.dataGridViewCategories.ReadOnly = true;
            this.dataGridViewCategories.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewCategories.Size = new System.Drawing.Size(248, 207);
            this.dataGridViewCategories.TabIndex = 0;
            // 
            // buttonAddCategory
            // 
            this.buttonAddCategory.Location = new System.Drawing.Point(12, 102);
            this.buttonAddCategory.Name = "buttonAddCategory";
            this.buttonAddCategory.Size = new System.Drawing.Size(75, 23);
            this.buttonAddCategory.TabIndex = 1;
            this.buttonAddCategory.Text = "Добавить категорию";
            this.buttonAddCategory.UseVisualStyleBackColor = true;
            this.buttonAddCategory.Click += new System.EventHandler(this.buttonAddCategory_Click);
            // 
            // textBoxCategory
            // 
            this.textBoxCategory.Location = new System.Drawing.Point(81, 23);
            this.textBoxCategory.Name = "textBoxCategory";
            this.textBoxCategory.Size = new System.Drawing.Size(100, 20);
            this.textBoxCategory.TabIndex = 2;
            // 
            // buttonDelete
            // 
            this.buttonDelete.AutoSize = true;
            this.buttonDelete.Location = new System.Drawing.Point(106, 102);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonDelete.TabIndex = 3;
            this.buttonDelete.Text = "Удалить";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // textBoxV
            // 
            this.textBoxV.Location = new System.Drawing.Point(81, 49);
            this.textBoxV.Name = "textBoxV";
            this.textBoxV.Size = new System.Drawing.Size(100, 20);
            this.textBoxV.TabIndex = 4;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(12, 26);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(57, 13);
            this.labelName.TabIndex = 5;
            this.labelName.Text = "Название";
            // 
            // labelV
            // 
            this.labelV.AutoSize = true;
            this.labelV.Location = new System.Drawing.Point(12, 52);
            this.labelV.Name = "labelV";
            this.labelV.Size = new System.Drawing.Size(41, 13);
            this.labelV.TabIndex = 6;
            this.labelV.Text = "Обьем";
            this.labelV.Click += new System.EventHandler(this.label2_Click);
            // 
            // WorkingWithCategories
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 236);
            this.Controls.Add(this.labelV);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.textBoxV);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.textBoxCategory);
            this.Controls.Add(this.buttonAddCategory);
            this.Controls.Add(this.dataGridViewCategories);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "WorkingWithCategories";
            this.Text = "Добавить/Удалить категорию";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WorkingWithCategories_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCategories)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewCategories;
        private System.Windows.Forms.Button buttonAddCategory;
        private System.Windows.Forms.TextBox textBoxCategory;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.TextBox textBoxV;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelV;
    }
}