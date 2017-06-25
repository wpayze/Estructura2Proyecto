namespace Fat16DiscoVirtual
{
    partial class AdministrarDisco
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
            this.crearcarpeta = new System.Windows.Forms.Button();
            this.VG = new System.Windows.Forms.ListView();
            this.Nombre = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Fecha = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Tamano = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // crearcarpeta
            // 
            this.crearcarpeta.Location = new System.Drawing.Point(12, 12);
            this.crearcarpeta.Name = "crearcarpeta";
            this.crearcarpeta.Size = new System.Drawing.Size(117, 34);
            this.crearcarpeta.TabIndex = 0;
            this.crearcarpeta.Text = "Crear Carpeta";
            this.crearcarpeta.UseVisualStyleBackColor = true;
            this.crearcarpeta.Click += new System.EventHandler(this.crearcarpeta_Click);
            // 
            // VG
            // 
            this.VG.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Nombre,
            this.Fecha,
            this.Tamano});
            this.VG.Location = new System.Drawing.Point(12, 52);
            this.VG.MultiSelect = false;
            this.VG.Name = "VG";
            this.VG.Size = new System.Drawing.Size(578, 199);
            this.VG.TabIndex = 9;
            this.VG.UseCompatibleStateImageBehavior = false;
            this.VG.View = System.Windows.Forms.View.Details;
            this.VG.SelectedIndexChanged += new System.EventHandler(this.VG_SelectedIndexChanged);
            // 
            // Nombre
            // 
            this.Nombre.Text = "Name";
            this.Nombre.Width = 134;
            // 
            // Fecha
            // 
            this.Fecha.Text = "Fecha";
            this.Fecha.Width = 138;
            // 
            // Tamano
            // 
            this.Tamano.Text = "Tamaño";
            this.Tamano.Width = 104;
            // 
            // AdministrarDisco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 274);
            this.Controls.Add(this.VG);
            this.Controls.Add(this.crearcarpeta);
            this.Name = "AdministrarDisco";
            this.Text = "AdministrarDisco";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button crearcarpeta;
        private System.Windows.Forms.ListView VG;
        private System.Windows.Forms.ColumnHeader Nombre;
        private System.Windows.Forms.ColumnHeader Fecha;
        private System.Windows.Forms.ColumnHeader Tamano;
    }
}