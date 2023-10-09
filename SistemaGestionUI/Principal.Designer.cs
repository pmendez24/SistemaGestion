namespace SistemaGestionUI
{
    partial class Principal
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
            this.tabControlSistemaGestion = new System.Windows.Forms.TabControl();
            this.tabUsuarios = new System.Windows.Forms.TabPage();
            this.tabProductos = new System.Windows.Forms.TabPage();
            this.tabVentas = new System.Windows.Forms.TabPage();
            this.tabProductosVendidos = new System.Windows.Forms.TabPage();
            this.tabControlSistemaGestion.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlSistemaGestion
            // 
            this.tabControlSistemaGestion.Controls.Add(this.tabUsuarios);
            this.tabControlSistemaGestion.Controls.Add(this.tabProductos);
            this.tabControlSistemaGestion.Controls.Add(this.tabVentas);
            this.tabControlSistemaGestion.Controls.Add(this.tabProductosVendidos);
            this.tabControlSistemaGestion.Location = new System.Drawing.Point(12, 12);
            this.tabControlSistemaGestion.Name = "tabControlSistemaGestion";
            this.tabControlSistemaGestion.SelectedIndex = 0;
            this.tabControlSistemaGestion.Size = new System.Drawing.Size(741, 408);
            this.tabControlSistemaGestion.TabIndex = 0;
            this.tabControlSistemaGestion.SelectedIndexChanged += new System.EventHandler(this.tabControlSistemaGestion_SelectedIndexChanged);
            // 
            // tabUsuarios
            // 
            this.tabUsuarios.Location = new System.Drawing.Point(4, 24);
            this.tabUsuarios.Name = "tabUsuarios";
            this.tabUsuarios.Padding = new System.Windows.Forms.Padding(3);
            this.tabUsuarios.Size = new System.Drawing.Size(733, 380);
            this.tabUsuarios.TabIndex = 0;
            this.tabUsuarios.Text = "Usuarios";
            this.tabUsuarios.UseVisualStyleBackColor = true;
            // 
            // tabProductos
            // 
            this.tabProductos.Location = new System.Drawing.Point(4, 24);
            this.tabProductos.Name = "tabProductos";
            this.tabProductos.Padding = new System.Windows.Forms.Padding(3);
            this.tabProductos.Size = new System.Drawing.Size(733, 380);
            this.tabProductos.TabIndex = 1;
            this.tabProductos.Text = "Productos";
            this.tabProductos.UseVisualStyleBackColor = true;
            this.tabProductos.Click += new System.EventHandler(this.tabProductos_Click);
            // 
            // tabVentas
            // 
            this.tabVentas.Location = new System.Drawing.Point(4, 24);
            this.tabVentas.Name = "tabVentas";
            this.tabVentas.Padding = new System.Windows.Forms.Padding(3);
            this.tabVentas.Size = new System.Drawing.Size(733, 380);
            this.tabVentas.TabIndex = 2;
            this.tabVentas.Text = "Ventas";
            this.tabVentas.UseVisualStyleBackColor = true;
            // 
            // tabProductosVendidos
            // 
            this.tabProductosVendidos.Location = new System.Drawing.Point(4, 24);
            this.tabProductosVendidos.Name = "tabProductosVendidos";
            this.tabProductosVendidos.Padding = new System.Windows.Forms.Padding(3);
            this.tabProductosVendidos.Size = new System.Drawing.Size(733, 380);
            this.tabProductosVendidos.TabIndex = 3;
            this.tabProductosVendidos.Text = "Productos Vendidos";
            this.tabProductosVendidos.UseVisualStyleBackColor = true;
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControlSistemaGestion);
            this.Name = "Principal";
            this.Text = "Sistema Gestion";
            this.tabControlSistemaGestion.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl tabControlSistemaGestion;
        private TabPage tabUsuarios;
        private TabPage tabProductos;
        private TabPage tabVentas;
        private TabPage tabProductosVendidos;
    }
}