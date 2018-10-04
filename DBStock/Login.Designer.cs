namespace DBStock
{
    partial class Login
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
            this.labelPass = new System.Windows.Forms.Label();
            this.textBoxPass = new System.Windows.Forms.TextBox();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.textBoxServerName = new System.Windows.Forms.TextBox();
            this.labelServer = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelPass
            // 
            this.labelPass.AutoSize = true;
            this.labelPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPass.Location = new System.Drawing.Point(39, 21);
            this.labelPass.Name = "labelPass";
            this.labelPass.Size = new System.Drawing.Size(114, 17);
            this.labelPass.TabIndex = 0;
            this.labelPass.Text = "Введите пароль";
            // 
            // textBoxPass
            // 
            this.textBoxPass.Location = new System.Drawing.Point(42, 55);
            this.textBoxPass.Name = "textBoxPass";
            this.textBoxPass.PasswordChar = '*';
            this.textBoxPass.Size = new System.Drawing.Size(111, 20);
            this.textBoxPass.TabIndex = 1;
            this.textBoxPass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // buttonLogin
            // 
            this.buttonLogin.Location = new System.Drawing.Point(42, 141);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(111, 23);
            this.buttonLogin.TabIndex = 2;
            this.buttonLogin.Text = "Авторизация";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxServerName
            // 
            this.textBoxServerName.Location = new System.Drawing.Point(42, 105);
            this.textBoxServerName.Name = "textBoxServerName";
            this.textBoxServerName.Size = new System.Drawing.Size(111, 20);
            this.textBoxServerName.TabIndex = 3;
            // 
            // labelServer
            // 
            this.labelServer.AutoSize = true;
            this.labelServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelServer.Location = new System.Drawing.Point(52, 87);
            this.labelServer.Name = "labelServer";
            this.labelServer.Size = new System.Drawing.Size(83, 15);
            this.labelServer.TabIndex = 4;
            this.labelServer.Text = "Имя сервера";
            this.labelServer.Click += new System.EventHandler(this.label2_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(195, 195);
            this.Controls.Add(this.labelServer);
            this.Controls.Add(this.textBoxServerName);
            this.Controls.Add(this.buttonLogin);
            this.Controls.Add(this.textBoxPass);
            this.Controls.Add(this.labelPass);
            this.Name = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelPass;
        private System.Windows.Forms.TextBox textBoxPass;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.TextBox textBoxServerName;
        private System.Windows.Forms.Label labelServer;
    }
}