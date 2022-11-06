namespace Game
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Vida2 = new System.Windows.Forms.ProgressBar();
            this.Vida1 = new System.Windows.Forms.ProgressBar();
            this.TimeL = new System.Windows.Forms.Label();
            this.TimeMov = new System.Windows.Forms.Timer(this.components);
            this.TimeTime = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.Fondo = new System.Windows.Forms.PictureBox();
            this.Player1 = new System.Windows.Forms.PictureBox();
            this.Player2 = new System.Windows.Forms.PictureBox();
            this.TimeSalto = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Fondo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Player1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Player2)).BeginInit();
            this.SuspendLayout();
            // 
            // Vida2
            // 
            this.Vida2.ForeColor = System.Drawing.Color.LimeGreen;
            this.Vida2.Location = new System.Drawing.Point(531, 12);
            this.Vida2.Name = "Vida2";
            this.Vida2.Size = new System.Drawing.Size(258, 25);
            this.Vida2.TabIndex = 0;
            this.Vida2.Value = 100;
            // 
            // Vida1
            // 
            this.Vida1.BackColor = System.Drawing.Color.LimeGreen;
            this.Vida1.ForeColor = System.Drawing.Color.LimeGreen;
            this.Vida1.Location = new System.Drawing.Point(12, 12);
            this.Vida1.Name = "Vida1";
            this.Vida1.Size = new System.Drawing.Size(258, 25);
            this.Vida1.TabIndex = 1;
            this.Vida1.Value = 100;
            // 
            // TimeL
            // 
            this.TimeL.AutoSize = true;
            this.TimeL.Font = new System.Drawing.Font("Matura MT Script Capitals", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeL.Location = new System.Drawing.Point(372, 9);
            this.TimeL.Name = "TimeL";
            this.TimeL.Size = new System.Drawing.Size(68, 26);
            this.TimeL.TabIndex = 4;
            this.TimeL.Text = "Time:";
            // 
            // TimeMov
            // 
            this.TimeMov.Interval = 1;
            this.TimeMov.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // TimeTime
            // 
            this.TimeTime.Interval = 1000;
            this.TimeTime.Tick += new System.EventHandler(this.TimeTime_Tick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Fondo);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 479);
            this.panel1.TabIndex = 5;
            // 
            // Fondo
            // 
            this.Fondo.Image = global::Game.Properties.Resources.Fondo;
            this.Fondo.Location = new System.Drawing.Point(0, 0);
            this.Fondo.Name = "Fondo";
            this.Fondo.Size = new System.Drawing.Size(800, 479);
            this.Fondo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Fondo.TabIndex = 0;
            this.Fondo.TabStop = false;
            // 
            // Player1
            // 
            this.Player1.BackColor = System.Drawing.Color.Transparent;
            this.Player1.Image = global::Game.Properties.Resources.pg2;
            this.Player1.Location = new System.Drawing.Point(110, 326);
            this.Player1.Name = "Player1";
            this.Player1.Size = new System.Drawing.Size(69, 120);
            this.Player1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Player1.TabIndex = 3;
            this.Player1.TabStop = false;
            // 
            // Player2
            // 
            this.Player2.Image = global::Game.Properties.Resources.im11;
            this.Player2.Location = new System.Drawing.Point(616, 326);
            this.Player2.Name = "Player2";
            this.Player2.Size = new System.Drawing.Size(69, 120);
            this.Player2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Player2.TabIndex = 2;
            this.Player2.TabStop = false;
            // 
            // TimeSalto
            // 
            this.TimeSalto.Interval = 1;
            this.TimeSalto.Tick += new System.EventHandler(this.TimeSalto_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 479);
            this.Controls.Add(this.TimeL);
            this.Controls.Add(this.Player1);
            this.Controls.Add(this.Player2);
            this.Controls.Add(this.Vida1);
            this.Controls.Add(this.Vida2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Fondo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Player1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Player2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar Vida2;
        private System.Windows.Forms.ProgressBar Vida1;
        private System.Windows.Forms.PictureBox Player2;
        private System.Windows.Forms.PictureBox Player1;
        private System.Windows.Forms.Label TimeL;
        private System.Windows.Forms.Timer TimeMov;
        private System.Windows.Forms.Timer TimeTime;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox Fondo;
        private System.Windows.Forms.Timer TimeSalto;
    }
}

