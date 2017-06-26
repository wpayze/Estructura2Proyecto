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
using Fat16DiscoVirtual.FAT16;
using Microsoft.VisualBasic;

namespace Fat16DiscoVirtual
{
    public partial class AdministrarDisco : Form
    {

        
        public List<DirectoryEntry> listaRootDirectory = new List<DirectoryEntry>();
        public List<DirectoryEntry> listaDirectorioActual = new List<DirectoryEntry>();
        public DirectoryEntry Dir2 = new DirectoryEntry();
        public DMBR MBR = new DMBR();
        public int OFFMB = 512;
        public bool viewRootDirectory = new bool(); 
        public int SizeCluster = new int();
        public List<FileAllocationTable> FAT1 = new List<FileAllocationTable>();
        public List<FileAllocationTable> FAT2 = new List<FileAllocationTable>();
        public AdministrarDisco()
        {    
            InitializeComponent();
        }

        private void VG_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void crearcarpeta_Click(object sender, EventArgs e)
        {
            string name = "";

            if (name.Length > 0 && name.Length <= 8)
            {
                if (viewRootDirectory)
                {
                    int EXST = 0;

                    foreach (var v in listaRootDirectory)
                    {
                        string a = Encoding.ASCII.GetString(v.DIR_NAME);
                        string nombre = a.Replace("\0", string.Empty);
                        if (nombre == name)
                        {
                            EXST = 1;
                        }
                    }

                    if (EXST > 0)
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
                   

                    if (EXST > 0)
                    {
                        MessageBox.Show("carpeta ya existente!"
                                        , "Error"
                                        , MessageBoxButtons.OK
                                        , MessageBoxIcon.Error);
                    }
                    else
                    {
                        DirectoryEntry directory = new DirectoryEntry();
                        directory.NewDir(name, DateTime.Now);
                    }
                }
            }
            else
            {
                MessageBox.Show("Ingrese nombre en el indice B+"
                                , "Informacion"
                                , MessageBoxButtons.OK
                                , MessageBoxIcon.Exclamation);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenFile = new OpenFileDialog();
            byte[] file;

            if (OpenFile.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(OpenFile.FileName))
                {
                    using (FileStream stream = File.OpenRead(OpenFile.FileName))
                    {
                        file = new byte[stream.Length];
                        stream.Read(file, 0, file.Length);
                    }
                    DirectoryEntry inFile = new DirectoryEntry();
                    FileInfo info = new FileInfo(OpenFile.FileName);
                    uint filesize = (uint)info.Length;

                    inFile.NewFile(info.Name, 'A', DateTime.Now, 0, filesize);
                    
                }
            }
        }

        public int EXST { get; set; }
    }
}
