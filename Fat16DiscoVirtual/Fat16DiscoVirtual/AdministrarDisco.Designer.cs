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
            System.Windows.Forms.ColumnHeader name;
            this.crearcarpeta = new System.Windows.Forms.Button();
            this.VG = new System.Windows.Forms.ListView();
            this.size = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button1 = new System.Windows.Forms.Button();
            name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
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
            name,
            this.size,
            this.date});
            this.VG.Location = new System.Drawing.Point(12, 52);
            this.VG.MultiSelect = false;
            this.VG.Name = "VG";
            this.VG.Size = new System.Drawing.Size(256, 199);
            this.VG.TabIndex = 9;
            this.VG.UseCompatibleStateImageBehavior = false;
            this.VG.View = System.Windows.Forms.View.Details;
            this.VG.SelectedIndexChanged += new System.EventHandler(this.VG_SelectedIndexChanged);
            // 
            // name
            // 
            name.Text = "Name";
            // 
            // size
            // 
            this.size.Text = "Size";
            // 
            // date
            // 
            this.date.Text = "Date";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(135, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(133, 34);
            this.button1.TabIndex = 10;
            this.button1.Text = "Nuevo Archivo";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // AdministrarDisco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 265);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.VG);
            this.Controls.Add(this.crearcarpeta);
            this.Name = "AdministrarDisco";
            this.Text = "AdministrarDisco";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button crearcarpeta;
        private System.Windows.Forms.ListView VG;
        private System.Windows.Forms.ColumnHeader size;
        private System.Windows.Forms.ColumnHeader date;
        private System.Windows.Forms.Button button1;
    }
}