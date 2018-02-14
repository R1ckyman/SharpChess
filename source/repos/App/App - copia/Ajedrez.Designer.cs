namespace App
{
    partial class Ajedrez
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ajedrez));
            this.TextX = new System.Windows.Forms.TextBox();
            this.TextY = new System.Windows.Forms.TextBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.player1 = new System.Windows.Forms.Label();
            this.player2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.board = new System.Windows.Forms.Label();
            this.datos = new System.Windows.Forms.Label();
            this.datosficha = new System.Windows.Forms.Label();
            this.informacion = new System.Windows.Forms.Label();
            this.Cancel = new System.Windows.Forms.Button();
            this.configuration = new System.Windows.Forms.Button();
            this.mover = new System.Windows.Forms.Button();
            this.ejemplo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TextX
            // 
            this.TextX.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.TextX.Font = new System.Drawing.Font("Year supply of fairy cakes", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextX.ForeColor = System.Drawing.SystemColors.Window;
            this.TextX.Location = new System.Drawing.Point(298, 70);
            this.TextX.MaxLength = 1;
            this.TextX.Name = "TextX";
            this.TextX.Size = new System.Drawing.Size(34, 34);
            this.TextX.TabIndex = 9;
            this.TextX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TextY
            // 
            this.TextY.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.TextY.Font = new System.Drawing.Font("Year supply of fairy cakes", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextY.ForeColor = System.Drawing.SystemColors.Window;
            this.TextY.Location = new System.Drawing.Point(372, 70);
            this.TextY.MaxLength = 1;
            this.TextY.Name = "TextY";
            this.TextY.Size = new System.Drawing.Size(34, 34);
            this.TextY.TabIndex = 10;
            this.TextY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Font = new System.Drawing.Font("Goudy Old Style", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnExit.Location = new System.Drawing.Point(412, 255);
            this.btnExit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(99, 36);
            this.btnExit.TabIndex = 11;
            this.btnExit.Text = "Menu";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSelect.Font = new System.Drawing.Font("Goudy Old Style", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelect.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSelect.Location = new System.Drawing.Point(298, 111);
            this.btnSelect.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(108, 36);
            this.btnSelect.TabIndex = 12;
            this.btnSelect.Text = "Seleccionar";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(289, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 19);
            this.label1.TabIndex = 13;
            this.label1.Text = "Número";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(367, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 19);
            this.label2.TabIndex = 14;
            this.label2.Text = "Letra";
            // 
            // player1
            // 
            this.player1.AutoSize = true;
            this.player1.Location = new System.Drawing.Point(108, 272);
            this.player1.Name = "player1";
            this.player1.Size = new System.Drawing.Size(97, 19);
            this.player1.TabIndex = 16;
            this.player1.Text = "-----Jugador 1-----";
            this.player1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // player2
            // 
            this.player2.AutoSize = true;
            this.player2.Location = new System.Drawing.Point(108, 9);
            this.player2.Name = "player2";
            this.player2.Size = new System.Drawing.Size(87, 19);
            this.player2.TabIndex = 17;
            this.player2.Text = "     Jugador 2";
            this.player2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(54, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(210, 38);
            this.label3.TabIndex = 18;
            this.label3.Text = "       A   B   C   D   E   F   G   H\r\n   ╔═════════════════════════╗";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(248, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 152);
            this.label4.TabIndex = 19;
            this.label4.Text = "║ 8\r\n║ 7\r\n║ 6\r\n║ 5\r\n║ 4\r\n║ 3\r\n║ 2\r\n║ 1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(54, 232);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(210, 38);
            this.label5.TabIndex = 20;
            this.label5.Text = "   ╚═════════════════════════╝\r\n       A   B   C   D   E   F   G   H";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(54, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 152);
            this.label6.TabIndex = 21;
            this.label6.Text = "8 ║ \r\n7 ║ \r\n6 ║ \r\n5 ║ \r\n4 ║ \r\n3 ║ \r\n2 ║\r\n1 ║";
            // 
            // board
            // 
            this.board.AutoSize = true;
            this.board.Location = new System.Drawing.Point(77, 80);
            this.board.Name = "board";
            this.board.Size = new System.Drawing.Size(177, 152);
            this.board.TabIndex = 22;
            this.board.Text = resources.GetString("board.Text");
            // 
            // datos
            // 
            this.datos.AutoSize = true;
            this.datos.Location = new System.Drawing.Point(303, 29);
            this.datos.Name = "datos";
            this.datos.Size = new System.Drawing.Size(96, 19);
            this.datos.TabIndex = 23;
            this.datos.Text = "Elige una ficha";
            // 
            // datosficha
            // 
            this.datosficha.AutoSize = true;
            this.datosficha.Location = new System.Drawing.Point(294, 151);
            this.datosficha.Name = "datosficha";
            this.datosficha.Size = new System.Drawing.Size(49, 19);
            this.datosficha.TabIndex = 24;
            this.datosficha.Text = "Ficha: ";
            // 
            // informacion
            // 
            this.informacion.AutoSize = true;
            this.informacion.Font = new System.Drawing.Font("Lato", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.informacion.Location = new System.Drawing.Point(412, 29);
            this.informacion.MaximumSize = new System.Drawing.Size(160, 228);
            this.informacion.Name = "informacion";
            this.informacion.Size = new System.Drawing.Size(125, 216);
            this.informacion.TabIndex = 27;
            this.informacion.Text = "   ---Jugador 1---\r\n\r\n\r\n <--- Coordenadas\r\n\r\n<--- Selección\r\n\r\n\r\n<--- Movimiento\r" +
    "\n\r\n\r\n<--- Cancelar";
            // 
            // Cancel
            // 
            this.Cancel.Font = new System.Drawing.Font("Goudy Old Style", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cancel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Cancel.Location = new System.Drawing.Point(298, 221);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(108, 36);
            this.Cancel.TabIndex = 28;
            this.Cancel.Text = "Cancelar";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // configuration
            // 
            this.configuration.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.configuration.Image = global::App.Properties.Resources.screen;
            this.configuration.Location = new System.Drawing.Point(520, 255);
            this.configuration.Name = "configuration";
            this.configuration.Size = new System.Drawing.Size(46, 36);
            this.configuration.TabIndex = 29;
            this.configuration.UseVisualStyleBackColor = true;
            this.configuration.Click += new System.EventHandler(this.configuration_Click);
            // 
            // mover
            // 
            this.mover.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.mover.Font = new System.Drawing.Font("Goudy Old Style", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mover.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.mover.Image = global::App.Properties.Resources.attack2;
            this.mover.Location = new System.Drawing.Point(298, 174);
            this.mover.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.mover.Name = "mover";
            this.mover.Size = new System.Drawing.Size(108, 33);
            this.mover.TabIndex = 25;
            this.mover.UseVisualStyleBackColor = true;
            this.mover.Click += new System.EventHandler(this.mover_Click);
            // 
            // ejemplo
            // 
            this.ejemplo.AutoSize = true;
            this.ejemplo.Location = new System.Drawing.Point(562, 294);
            this.ejemplo.MaximumSize = new System.Drawing.Size(330, 240);
            this.ejemplo.Name = "ejemplo";
            this.ejemplo.Size = new System.Drawing.Size(223, 228);
            this.ejemplo.TabIndex = 15;
            this.ejemplo.Text = resources.GetString("ejemplo.Text");
            // 
            // Ajedrez
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(584, 321);
            this.Controls.Add(this.configuration);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.informacion);
            this.Controls.Add(this.mover);
            this.Controls.Add(this.datosficha);
            this.Controls.Add(this.datos);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.board);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.player2);
            this.Controls.Add(this.player1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.TextY);
            this.Controls.Add(this.TextX);
            this.Controls.Add(this.ejemplo);
            this.Font = new System.Drawing.Font("Goudy Old Style", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(600, 360);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(600, 360);
            this.Name = "Ajedrez";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sesión iniciada";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox TextX;
        private System.Windows.Forms.TextBox TextY;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label player1;
        private System.Windows.Forms.Label player2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label board;
        private System.Windows.Forms.Label datos;
        private System.Windows.Forms.Label datosficha;
        private System.Windows.Forms.Button mover;
        private System.Windows.Forms.Label informacion;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Button configuration;
        private System.Windows.Forms.Label ejemplo;
    }
}