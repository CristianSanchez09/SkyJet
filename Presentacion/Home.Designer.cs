namespace Presentacion
{
    partial class Home
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblCerrar = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPasajeros = new System.Windows.Forms.Button();
            this.btnTickets = new System.Windows.Forms.Button();
            this.btnCancelacion = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnVuelos = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Red;
            this.panel1.Controls.Add(this.lblCerrar);
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(607, 69);
            this.panel1.TabIndex = 0;
            // 
            // lblCerrar
            // 
            this.lblCerrar.AutoSize = true;
            this.lblCerrar.BackColor = System.Drawing.Color.LightCoral;
            this.lblCerrar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblCerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCerrar.ForeColor = System.Drawing.Color.White;
            this.lblCerrar.Location = new System.Drawing.Point(568, 9);
            this.lblCerrar.Name = "lblCerrar";
            this.lblCerrar.Size = new System.Drawing.Size(27, 26);
            this.lblCerrar.TabIndex = 10;
            this.lblCerrar.Text = "X";
            this.lblCerrar.Click += new System.EventHandler(this.lblCerrar_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(175, 13);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(278, 42);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "SkyJet Airlines";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(91, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(429, 29);
            this.label1.TabIndex = 3;
            this.label1.Text = "Profesionalismo calidad de servicio";
            // 
            // btnPasajeros
            // 
            this.btnPasajeros.BackColor = System.Drawing.Color.LightCoral;
            this.btnPasajeros.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPasajeros.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnPasajeros.FlatAppearance.BorderSize = 2;
            this.btnPasajeros.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnPasajeros.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPasajeros.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPasajeros.ForeColor = System.Drawing.SystemColors.Control;
            this.btnPasajeros.Location = new System.Drawing.Point(182, 257);
            this.btnPasajeros.Name = "btnPasajeros";
            this.btnPasajeros.Size = new System.Drawing.Size(107, 31);
            this.btnPasajeros.TabIndex = 5;
            this.btnPasajeros.Text = "Pasajeros";
            this.btnPasajeros.UseVisualStyleBackColor = false;
            this.btnPasajeros.Click += new System.EventHandler(this.btnPasajeros_Click);
            // 
            // btnTickets
            // 
            this.btnTickets.BackColor = System.Drawing.Color.LightCoral;
            this.btnTickets.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTickets.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnTickets.FlatAppearance.BorderSize = 2;
            this.btnTickets.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnTickets.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTickets.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTickets.ForeColor = System.Drawing.SystemColors.Control;
            this.btnTickets.Location = new System.Drawing.Point(305, 257);
            this.btnTickets.Name = "btnTickets";
            this.btnTickets.Size = new System.Drawing.Size(107, 31);
            this.btnTickets.TabIndex = 6;
            this.btnTickets.Text = "Tickets";
            this.btnTickets.UseVisualStyleBackColor = false;
            this.btnTickets.Click += new System.EventHandler(this.btnTickets_Click);
            // 
            // btnCancelacion
            // 
            this.btnCancelacion.BackColor = System.Drawing.Color.LightCoral;
            this.btnCancelacion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelacion.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnCancelacion.FlatAppearance.BorderSize = 2;
            this.btnCancelacion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnCancelacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelacion.ForeColor = System.Drawing.SystemColors.Control;
            this.btnCancelacion.Location = new System.Drawing.Point(429, 257);
            this.btnCancelacion.Name = "btnCancelacion";
            this.btnCancelacion.Size = new System.Drawing.Size(127, 31);
            this.btnCancelacion.TabIndex = 7;
            this.btnCancelacion.Text = "Cancelación";
            this.btnCancelacion.UseVisualStyleBackColor = false;
            this.btnCancelacion.Click += new System.EventHandler(this.btnCancelacion_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(250, 127);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(107, 104);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // btnVuelos
            // 
            this.btnVuelos.BackColor = System.Drawing.Color.LightCoral;
            this.btnVuelos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVuelos.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnVuelos.FlatAppearance.BorderSize = 2;
            this.btnVuelos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnVuelos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVuelos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVuelos.ForeColor = System.Drawing.SystemColors.Control;
            this.btnVuelos.Location = new System.Drawing.Point(60, 257);
            this.btnVuelos.Name = "btnVuelos";
            this.btnVuelos.Size = new System.Drawing.Size(107, 31);
            this.btnVuelos.TabIndex = 9;
            this.btnVuelos.Text = "Vuelos";
            this.btnVuelos.UseVisualStyleBackColor = false;
            this.btnVuelos.Click += new System.EventHandler(this.btnVuelos_Click_1);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 308);
            this.Controls.Add(this.btnVuelos);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnCancelacion);
            this.Controls.Add(this.btnTickets);
            this.Controls.Add(this.btnPasajeros);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPasajeros;
        private System.Windows.Forms.Button btnTickets;
        private System.Windows.Forms.Button btnCancelacion;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblCerrar;
        private System.Windows.Forms.Button btnVuelos;
    }
}