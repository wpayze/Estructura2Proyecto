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
                    fs.Seek(1024*1024*1024, SeekOrigin.Begin);
                    fs.WriteByte(0);
                    fs.Close();

                    MasterBootRecord table = new MasterBootRecord();
                    table.DatosMBR();
                    using (BinaryWriter stream = new BinaryWriter(File.Open(NewFileDialog.FileName, FileMode.Open)))
                    {

                        stream.BaseStream.Position = 0;
                        stream.Write(table.JumpIns, 0, table.JumpIns.Length);
                        stream.Write(table.OEMname, 0, table.OEMname.Length);
                        stream.Write(table.BytesPerSector);
                        stream.Write(table.SectorsPerCluster);
                        stream.Write(table.ReservedSectors);
                        stream.Write(table.NumeroDeFATS);
                        stream.Write(table.RootEntryCount);
                        stream.Write(table.SmallSectors);
                        stream.Write(table.MediaDescriptor);
                        stream.Write(table.SectorPerFATS);
                        stream.Write(table.SectorPerTrack);
                        stream.Write(table.NumeroHeads);
                        stream.Write(table.HiddenSectors);
                        stream.Write(table.LargeSectors);
                        stream.Write(table.PhysicalDrive);
                        stream.Write(table.Reservado);
                        stream.Write(table.ExtBootSignature);
                        stream.Write(table.Serial);
                        stream.Write(table.VolumeLabel);
                        stream.Write(table.FileSystemType);
                        stream.Write(table.BootCode, 0, table.BootCode.Length);
                        stream.Write(table.EndOfSector);

                        FileAllocationTable[] FAT = new FileAllocationTable[65525];
                        for (int a=0; a<2;a++)
                        {
                            for (int i=0;i<65525;i++)
                            {
                                FAT[i] = new FileAllocationTable();
                                if (i >= 2)
                                {
                                    FAT[i].ClusterStart();
                                }
                                else
                                {
                                    FAT[i].ClusterReserved();
                                }
                            }
                            foreach (FileAllocationTable fentry in FAT)
                            {
                                stream.Write(fentry.entrada);
                            }
                        }

                        for (int i=0;i<512;i++)
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

                    Main.Default = Path.GetFullPath(NewFileDialog.FileName);
                    MessageBox.Show("Disco Creado Exitosamente!", "Aviso", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                }
                else
                {
                    MessageBox.Show("Error en el archivo!","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show("Seleccione un Archivo Valido!","Error!",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }

            }
        }

    }
}
