namespace Fat16DiscoVirtual
{
    partial class Main
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
            this.creardisco = new System.Windows.Forms.Button();
            this.abrirdisco = new System.Windows.Forms.Button();
            this.administrardisco = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // creardisco
            // 
            this.creardisco.BackColor = System.Drawing.SystemColors.Info;
            this.creardisco.Font = new System.Drawing.Font("Copperplate Gothic Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.creardisco.Location = new System.Drawing.Point(12, 62);
            this.creardisco.Name = "creardisco";
            this.creardisco.Size = new System.Drawing.Size(195, 81);
            this.creardisco.TabIndex = 0;
            this.creardisco.Text = "Crear Disco";
            this.creardisco.UseVisualStyleBackColor = false;
            this.creardisco.Click += new System.EventHandler(this.creardisco_Click);
            // 
            // abrirdisco
            // 
            this.abrirdisco.BackColor = System.Drawing.SystemColors.Info;
            this.abrirdisco.Font = new System.Drawing.Font("Copperplate Gothic Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.abrirdisco.Location = new System.Drawing.Point(213, 62);
            this.abrirdisco.Name = "abrirdisco";
            this.abrirdisco.Size = new System.Drawing.Size(195, 81);
            this.abrirdisco.TabIndex = 1;
            this.abrirdisco.Text = "Abrir Disco";
            this.abrirdisco.UseVisualStyleBackColor = false;
            this.abrirdisco.Click += new System.EventHandler(this.abrirdisco_Click);
            // 
            // administrardisco
            // 
            this.administrardisco.BackColor = System.Drawing.SystemColors.Info;
            this.administrardisco.Font = new System.Drawing.Font("Copperplate Gothic Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.administrardisco.Location = new System.Drawing.Point(12, 149);
            this.administrardisco.Name = "administrardisco";
            this.administrardisco.Size = new System.Drawing.Size(396, 81);
            this.administrardisco.TabIndex = 2;
            this.administrardisco.Text = "Administrar Disco";
            this.administrardisco.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.HighlightText;
            this.label3.Location = new System.Drawing.Point(9, 239);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(181, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Wilfredo Paiz - Estructura de Datos II";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Info;
            this.label4.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(171, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 24);
            this.label4.TabIndex = 4;
            this.label4.Text = "FAT16";
            // 
            // Main
            // 
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(434, 261);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.administrardisco);
            this.Controls.Add(this.abrirdisco);
            this.Controls.Add(this.creardisco);
            this.Name = "Main";
            this.Text = "Disco Virtual FAT16";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button creardiscobtn;
        private System.Windows.Forms.Button abrirdiscobtn;
        private System.Windows.Forms.Button administrardiscobtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button creardisco;
        private System.Windows.Forms.Button abrirdisco;
        private System.Windows.Forms.Button administrardisco;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

