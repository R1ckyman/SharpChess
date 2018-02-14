namespace App
{
    partial class Menu
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
            this.btnExit = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.nickBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.appBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Font = new System.Drawing.Font("Goudy Old Style", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(349, 252);
            this.btnExit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(99, 36);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Salir";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnLogin.Font = new System.Drawing.Font("Goudy Old Style", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.Location = new System.Drawing.Point(100, 252);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(139, 36);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "Iniciar sesión";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(96, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Introduce usuario:";
            // 
            // nickBox
            // 
            this.nickBox.BackColor = System.Drawing.SystemColors.MenuText;
            this.nickBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.nickBox.Font = new System.Drawing.Font("Goudy Old Style", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nickBox.ForeColor = System.Drawing.SystemColors.Window;
            this.nickBox.Location = new System.Drawing.Point(258, 107);
            this.nickBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nickBox.MaxLength = 20;
            this.nickBox.Name = "nickBox";
            this.nickBox.Size = new System.Drawing.Size(190, 23);
            this.nickBox.TabIndex = 0;
            this.nickBox.Text = "test";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(96, 157);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Introduce contraseña:";
            // 
            // passwordBox
            // 
            this.passwordBox.BackColor = System.Drawing.SystemColors.MenuText;
            this.passwordBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.passwordBox.Font = new System.Drawing.Font("Goudy Old Style", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordBox.ForeColor = System.Drawing.SystemColors.Window;
            this.passwordBox.Location = new System.Drawing.Point(258, 157);
            this.passwordBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.passwordBox.MaxLength = 20;
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.PasswordChar = '*';
            this.passwordBox.Size = new System.Drawing.Size(190, 23);
            this.passwordBox.TabIndex = 1;
            this.passwordBox.Text = "test";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Cursor = System.Windows.Forms.Cursors.Cross;
            this.label3.Font = new System.Drawing.Font("Goudy Stout", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(95, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(353, 28);
            this.label3.TabIndex = 7;
            this.label3.Text = "Inicio de sesión";
            // 
            // appBox
            // 
            this.appBox.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.appBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.appBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.appBox.ForeColor = System.Drawing.SystemColors.Window;
            this.appBox.FormattingEnabled = true;
            this.appBox.Items.AddRange(new object[] {
            "Ajedrez",
            "Adivina un número(soon)"});
            this.appBox.Location = new System.Drawing.Point(258, 56);
            this.appBox.Name = "appBox";
            this.appBox.Size = new System.Drawing.Size(190, 28);
            this.appBox.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(96, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Selecciona aplicación:";
            // 
            // Menu
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(584, 321);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.appBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.passwordBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nickBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.btnExit);
            this.Cursor = System.Windows.Forms.Cursors.Cross;
            this.Font = new System.Drawing.Font("Goudy Old Style", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(600, 360);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(600, 360);
            this.Name = "Menu";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inicio de sesión";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nickBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox passwordBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox appBox;
        private System.Windows.Forms.Label label4;
    }
}