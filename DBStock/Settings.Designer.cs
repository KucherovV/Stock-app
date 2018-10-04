namespace DBStock
{
    partial class Settings
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
            this.labelpath = new System.Windows.Forms.Label();
            this.textBoxPath = new System.Windows.Forms.TextBox();
            this.buttonPath = new System.Windows.Forms.Button();
            this.labelV = new System.Windows.Forms.Label();
            this.textBoxCapacity = new System.Windows.Forms.TextBox();
            this.buttonSetCapacity = new System.Windows.Forms.Button();
            this.labelPass = new System.Windows.Forms.Label();
            this.textBoxPass = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelpath
            // 
            this.labelpath.AutoSize = true;
            this.labelpath.Location = new System.Drawing.Point(12, 9);
            this.labelpath.Name = "labelpath";
            this.labelpath.Size = new System.Drawing.Size(117, 13);
            this.labelpath.TabIndex = 0;
            this.labelpath.Text = "Путь для сохранения ";
            // 
            // textBoxPath
            // 
            this.textBoxPath.Location = new System.Drawing.Point(135, 9);
            this.textBoxPath.Name = "textBoxPath";
            this.textBoxPath.Size = new System.Drawing.Size(100, 20);
            this.textBoxPath.TabIndex = 1;
            this.textBoxPath.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // buttonPath
            // 
            this.buttonPath.Location = new System.Drawing.Point(256, 6);
            this.buttonPath.Name = "buttonPath";
            this.buttonPath.Size = new System.Drawing.Size(75, 23);
            this.buttonPath.TabIndex = 2;
            this.buttonPath.Text = "Обновить";
            this.buttonPath.UseVisualStyleBackColor = true;
            this.buttonPath.Click += new System.EventHandler(this.buttonPath_Click);
            // 
            // labelV
            // 
            this.labelV.AutoSize = true;
            this.labelV.Location = new System.Drawing.Point(12, 45);
            this.labelV.Name = "labelV";
            this.labelV.Size = new System.Drawing.Size(80, 13);
            this.labelV.TabIndex = 3;
            this.labelV.Text = "Обьем склада";
            // 
            // textBoxCapacity
            // 
            this.textBoxCapacity.Location = new System.Drawing.Point(135, 42);
            this.textBoxCapacity.Name = "textBoxCapacity";
            this.textBoxCapacity.Size = new System.Drawing.Size(100, 20);
            this.textBoxCapacity.TabIndex = 4;
            this.textBoxCapacity.TextChanged += new System.EventHandler(this.textBoxCapacity_TextChanged);
            // 
            // buttonSetCapacity
            // 
            this.buttonSetCapacity.Location = new System.Drawing.Point(256, 39);
            this.buttonSetCapacity.Name = "buttonSetCapacity";
            this.buttonSetCapacity.Size = new System.Drawing.Size(75, 23);
            this.buttonSetCapacity.TabIndex = 5;
            this.buttonSetCapacity.Text = "Обновить";
            this.buttonSetCapacity.UseVisualStyleBackColor = true;
            this.buttonSetCapacity.Click += new System.EventHandler(this.buttonSetCapacity_Click);
            // 
            // labelPass
            // 
            this.labelPass.AutoSize = true;
            this.labelPass.Location = new System.Drawing.Point(12, 79);
            this.labelPass.Name = "labelPass";
            this.labelPass.Size = new System.Drawing.Size(45, 13);
            this.labelPass.TabIndex = 6;
            this.labelPass.Text = "Пароль";
            // 
            // textBoxPass
            // 
            this.textBoxPass.Location = new System.Drawing.Point(135, 76);
            this.textBoxPass.Name = "textBoxPass";
            this.textBoxPass.Size = new System.Drawing.Size(100, 20);
            this.textBoxPass.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(256, 74);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Обновить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 139);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxPass);
            this.Controls.Add(this.labelPass);
            this.Controls.Add(this.buttonSetCapacity);
            this.Controls.Add(this.textBoxCapacity);
            this.Controls.Add(this.labelV);
            this.Controls.Add(this.buttonPath);
            this.Controls.Add(this.textBoxPath);
            this.Controls.Add(this.labelpath);
            this.Name = "Settings";
            this.Text = "Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Settings_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelpath;
        private System.Windows.Forms.TextBox textBoxPath;
        private System.Windows.Forms.Button buttonPath;
        private System.Windows.Forms.Label labelV;
        private System.Windows.Forms.TextBox textBoxCapacity;
        private System.Windows.Forms.Button buttonSetCapacity;
        private System.Windows.Forms.Label labelPass;
        private System.Windows.Forms.TextBox textBoxPass;
        private System.Windows.Forms.Button button1;
    }
}