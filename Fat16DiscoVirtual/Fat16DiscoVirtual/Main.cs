using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Drawing;
using Fat16DiscoVirtual.FAT16;

//De acuerdo a las especificacion es https://staff.washington.edu/dittrich/misc/fatgen103.pdf para FAT16

namespace Fat16DiscoVirtual
{
    public partial class Main : Form
    {

        public Main()
        {
            InitializeComponent();
            this.StartPosition=FormStartPosition.CenterScreen;
        }

        public static string Default { get; set; }

        private void creardisco_Click(object sender, EventArgs e)
        {
            SaveFileDialog NewFileDialog = new SaveFileDialog();

            if (NewFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (!File.Exists(NewFileDialog.FileName))
                {
                    FileStream fs = new FileStream(NewFileDialog.FileName, FileMode.CreateNew);
                    fs.Seek(1024 * 1024 * 1024, SeekOrigin.Begin);
                    fs.WriteByte(0);
                    fs.Close();

                    MasterBootRecord tablembr = new MasterBootRecord();
                    tablembr.DatosMBR();
                    using (BinaryWriter stream = new BinaryWriter(File.Open(NewFileDialog.FileName, FileMode.Open)))
                    {

                        stream.BaseStream.Position = 0;
                        stream.Write(tablembr.JumpIns, 0, tablembr.JumpIns.Length);
                        stream.Write(tablembr.OEMname, 0, tablembr.OEMname.Length);
                        stream.Write(tablembr.BytesPerSector);
                        stream.Write(tablembr.SectorsPerCluster);
                        stream.Write(tablembr.ReservedSectors);
                        stream.Write(tablembr.NumeroDeFATS);
                        stream.Write(tablembr.RootEntryCount);
                        stream.Write(tablembr.SmallSectors);
                        stream.Write(tablembr.MediaDescriptor);
                        stream.Write(tablembr.SectorPerFATS);
                        stream.Write(tablembr.SectorPerTrack);
                        stream.Write(tablembr.NumeroHeads);
                        stream.Write(tablembr.HiddenSectors);
                        stream.Write(tablembr.LargeSectors);
                        stream.Write(tablembr.PhysicalDrive);
                        stream.Write(tablembr.Reservado);
                        stream.Write(tablembr.ExtBootSignature);
                        stream.Write(tablembr.Serial);
                        stream.Write(tablembr.VolumeLabel);
                        stream.Write(tablembr.FileSystemType);
                        stream.Write(tablembr.BootCode, 0, tablembr.BootCode.Length);
                        stream.Write(tablembr.EndOfSector);

                        FileAllocationTable[] FAT = new FileAllocationTable[65536];

                        for (int i = 0; i < 65536; i++)
                        {
                            FAT[i] = new FileAllocationTable();
                            if (i >= 17)
                            {
                                FAT[i].ClusterStart();
                            }
                            else
                            {
                                FAT[i].ClusterReserved();
                            }
                        }

                        for (int a = 0; a < 2; a++)
                        {
                            foreach (FileAllocationTable fen in FAT)
                            {
                                stream.Write(fen.entrada);
                            }
                        }

                        for (int i = 0; i < 512; i++)
                        {
                            DirectoryEntry EmptyDir = new DirectoryEntry();

                            stream.Write(EmptyDir.DIR_NAME);
                            stream.Write(EmptyDir.DIR_EXT);
                            stream.Write(EmptyDir.DIR_ATTR);
                            stream.Write(EmptyDir.DIR_NTRES);
                            stream.Write(EmptyDir.DIR_CrtTimeTenth);
                            stream.Write(EmptyDir.DIR_CrtTime);
                            stream.Write(EmptyDir.DIR_CrtDate);
                            stream.Write(EmptyDir.DIR_LstAccDate);
                            stream.Write(EmptyDir.DIR_FstClustHI);
                            stream.Write(EmptyDir.DIR_WrtTime);
                            stream.Write(EmptyDir.DIR_WrtDate);
                            stream.Write(EmptyDir.DIR_FstClustLO);
                            stream.Write(EmptyDir.DIR_FileSize);
                        }
                    }

                    Vars.Default = Path.GetFullPath(NewFileDialog.FileName);

                    string rutaIndex = Vars.discoDefault.Substring(0, Vars.discoDefault.Length - 4) + ".index";

                    using (FileStream fi = new FileStream(rutaIndex, FileMode.CreateNew))
                    {
                        fi.Seek(0, SeekOrigin.Begin);
                        fi.WriteByte(0);
                    }

                    Vars.Index = rutaIndex;

                    Main.Default = Path.GetFullPath(NewFileDialog.FileName);
                    MessageBox.Show("Disco Creado Exitosamente!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    MessageBox.Show("Error en el archivo!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void abrirdisco_Click(object sender, EventArgs e)
        {
            OpenFileDialog pfd = new OpenFileDialog();

            if (pfd.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(pfd.FileName))
                {
                    Default = Path.GetFullPath(pfd.FileName);
                    MessageBox.Show("Disco listo para ser administrado!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Seleccione un Archivo Valido!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void administrardisco_Click(object sender, EventArgs e)
        {
            if (Default != null)
            {
                if (!Application.OpenForms.OfType<AdministrarDisco>().Any())
                {
                    AdministrarDisco administrador = new AdministrarDisco();
                    administrador.StartPosition=FormStartPosition.CenterScreen;
                    administrador.Show();
                }
            }
            else
            {
                MessageBox.Show("No hay ningun Disco Abierto, Cargue uno desde « Abrir Disco »", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void eliminar_Click(object sender, EventArgs e)
        {
            Default = null;
        }

        public byte[] ConvertToData(object objeto)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            
            using (MemoryStream stream = new MemoryStream())
            {
                formatter.Serialize(stream, objeto);
                return stream.ToArray();
            }
        }
    }
}