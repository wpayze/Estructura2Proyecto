using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Fat16DiscoVirtual.FAT16;

namespace Fat16DiscoVirtual
{
    public partial class AdministrarDisco : Form
    {
        public AdministrarDisco()
        {    
            InitializeComponent();
        }

        private void VG_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void crearcarpeta_Click(object sender, EventArgs e)
        {
            string name = Interaction.InputBox("Nombre", "Nueva Carpeta");

            if (name.Length > 0 && name.Length <= 8)
            {
                if (viewRootDirectory)
                {
                    int existecarpeta = 0;
                    foreach (var v in listaRootDirectory)
                    {
                        string a = Encoding.ASCII.GetString(v.filename);
                        string nombre = a.Replace("\0", string.Empty);
                        if (nombre == nombreCarpeta)
                        {
                            existecarpeta = 1;
                        }
                    }

                    if (existecarpeta > 0)
                    {
                        MessageBox.Show("Carpeta Repetida"
                                        , "Take it easy"
                                        , MessageBoxButtons.OK
                                        , MessageBoxIcon.Error);
                    }
                    else
                    {
                        DirectoryEntry directory = new DirectoryEntry();
                        directory.NewDir(name, DateTime.Now);
                    }
                }
                else
                {
                   

                    if (existecarpeta > 0)
                    {
                        MessageBox.Show("Ya existe una carpeta con ese nombre!"
                                        , "Informacion"
                                        , MessageBoxButtons.OK
                                        , MessageBoxIcon.Error);
                    }
                    else
                    {
                        DirectoryEntry directory = new DirectoryEntry();
                        directory.NewDir(name, DateTime.Now)
                    }
                }
            }
            else
            {
                MessageBox.Show("El nombre debe ser menor o igual a 8 caracteres"
                                , "Informacion"
                                , MessageBoxButtons.OK
                                , MessageBoxIcon.Exclamation);
            }
        }
    }
}
