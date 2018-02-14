namespace App
{
    partial class Adivinar
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
            this.LDatos = new System.Windows.Forms.Label();
            this.TextX = new System.Windows.Forms.TextBox();
            this.TextY = new System.Windows.Forms.TextBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LDatos
            // 
            this.LDatos.AutoSize = true;
            this.LDatos.Cursor = System.Windows.Forms.Cursors.Cross;
            this.LDatos.Font = new System.Drawing.Font("Goudy Stout", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LDatos.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.LDatos.Location = new System.Drawing.Point(105, 0);
            this.LDatos.Name = "LDatos";
            this.LDatos.Size = new System.Drawing.Size(421, 28);
            this.LDatos.TabIndex = 8;
            this.LDatos.Text = "Adivina un número";
            // 
            // TextX
            // 
            this.TextX.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.TextX.Font = new System.Drawing.Font("Year supply of fairy cakes", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextX.ForeColor = System.Drawing.SystemColors.Window;
            this.TextX.Location = new System.Drawing.Point(110, 234);
            this.TextX.MaxLength = 1;
            this.TextX.Name = "TextX";
            this.TextX.Size = new System.Drawing.Size(34, 34);
            this.TextX.TabIndex = 9;
            this.TextX.Text = "1";
            this.TextX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TextY
            // 
            this.TextY.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.TextY.Font = new System.Drawing.Font("Year supply of fairy cakes", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextY.ForeColor = System.Drawing.SystemColors.Window;
            this.TextY.Location = new System.Drawing.Point(200, 234);
            this.TextY.MaxLength = 1;
            this.TextY.Name = "TextY";
            this.TextY.Size = new System.Drawing.Size(34, 34);
            this.TextY.TabIndex = 10;
            this.TextY.Text = "1";
            this.TextY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Font = new System.Drawing.Font("Goudy Old Style", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnExit.Location = new System.Drawing.Point(452, 232);
            this.btnExit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(99, 36);
            this.btnExit.TabIndex = 11;
            this.btnExit.Text = "Volver";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // Adivinar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(584, 321);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.TextY);
            this.Controls.Add(this.TextX);
            this.Controls.Add(this.LDatos);
            this.Font = new System.Drawing.Font("Goudy Old Style", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(600, 360);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(600, 360);
            this.Name = "Adivinar";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sesión iniciada";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LDatos;
        private System.Windows.Forms.TextBox TextX;
        private System.Windows.Forms.TextBox TextY;
        private System.Windows.Forms.Button btnExit;
    }
}