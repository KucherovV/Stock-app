namespace DBStock
{
    partial class AddToStock
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
            this.dataGridViewProducts = new System.Windows.Forms.DataGridView();
            this.maskedTextBoxAmount = new System.Windows.Forms.MaskedTextBox();
            this.labelAmount = new System.Windows.Forms.Label();
            this.buttonAddToCheck = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridViewItems = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItems)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewProducts
            // 
            this.dataGridViewProducts.AllowUserToAddRows = false;
            this.dataGridViewProducts.AllowUserToDeleteRows = false;
            this.dataGridViewProducts.AllowUserToOrderColumns = true;
            this.dataGridViewProducts.AllowUserToResizeColumns = false;
            this.dataGridViewProducts.AllowUserToResizeRows = false;
            this.dataGridViewProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProducts.Location = new System.Drawing.Point(-2, 12);
            this.dataGridViewProducts.Name = "dataGridViewProducts";
            this.dataGridViewProducts.ReadOnly = true;
            this.dataGridViewProducts.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewProducts.Size = new System.Drawing.Size(240, 398);
            this.dataGridViewProducts.TabIndex = 0;
            this.dataGridViewProducts.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // maskedTextBoxAmount
            // 
            this.maskedTextBoxAmount.Location = new System.Drawing.Point(81, 428);
            this.maskedTextBoxAmount.Mask = "000000";
            this.maskedTextBoxAmount.Name = "maskedTextBoxAmount";
            this.maskedTextBoxAmount.Size = new System.Drawing.Size(49, 20);
            this.maskedTextBoxAmount.TabIndex = 1;
            this.maskedTextBoxAmount.ValidatingType = typeof(int);
            // 
            // labelAmount
            // 
            this.labelAmount.AutoSize = true;
            this.labelAmount.Location = new System.Drawing.Point(9, 433);
            this.labelAmount.Name = "labelAmount";
            this.labelAmount.Size = new System.Drawing.Size(66, 13);
            this.labelAmount.TabIndex = 2;
            this.labelAmount.Text = "Количество";
            this.labelAmount.Click += new System.EventHandler(this.label1_Click);
            // 
            // buttonAddToCheck
            // 
            this.buttonAddToCheck.Location = new System.Drawing.Point(157, 428);
            this.buttonAddToCheck.Name = "buttonAddToCheck";
            this.buttonAddToCheck.Size = new System.Drawing.Size(142, 23);
            this.buttonAddToCheck.TabIndex = 3;
            this.buttonAddToCheck.Text = "Добавить в накладную";
            this.buttonAddToCheck.UseVisualStyleBackColor = true;
            this.buttonAddToCheck.Click += new System.EventHandler(this.buttonAddToCheck_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(383, 426);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(134, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Оформить накладную";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridViewItems
            // 
            this.dataGridViewItems.AllowUserToAddRows = false;
            this.dataGridViewItems.AllowUserToDeleteRows = false;
            this.dataGridViewItems.AllowUserToResizeColumns = false;
            this.dataGridViewItems.AllowUserToResizeRows = false;
            this.dataGridViewItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewItems.Location = new System.Drawing.Point(258, 12);
            this.dataGridViewItems.Name = "dataGridViewItems";
            this.dataGridViewItems.ReadOnly = true;
            this.dataGridViewItems.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewItems.Size = new System.Drawing.Size(620, 398);
            this.dataGridViewItems.TabIndex = 6;
            // 
            // AddToStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(938, 455);
            this.Controls.Add(this.dataGridViewItems);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonAddToCheck);
            this.Controls.Add(this.labelAmount);
            this.Controls.Add(this.maskedTextBoxAmount);
            this.Controls.Add(this.dataGridViewProducts);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "AddToStock";
            this.Text = "Добавить на склад";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddToStock_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewProducts;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxAmount;
        private System.Windows.Forms.Label labelAmount;
        private System.Windows.Forms.Button buttonAddToCheck;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridViewItems;
    }
}