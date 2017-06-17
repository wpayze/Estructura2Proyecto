using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fat16DiscoVirtual.FAT16
{
    class DirectoryEntry
    {
        public DirectoryEntry()
        {
            DIR_NAME = new byte[8];
            DIR_EXT = new byte[3];
            DIR_ATTR = new byte();
            DIR_NTRES = new byte();
            DIR_CrtTimeTenth = new byte();
            DIR_CrtTime = new ushort();
            DIR_CrtDate = new byte[2];
            DIR_LstAccDate = new byte[2];
            DIR_FstClustHI= new ushort();
            DIR_WrtTime = new byte[2];
            DIR_WrtDate = new byte[2];
            DIR_FstClustLO = new ushort();
            DIR_FileSize = new uint();
        }

        public byte[] DIR_NAME { get; set; }    //Offset 0 - 8 bytes. Primeros ocho caracteres del nombre del archivo con el formato 8.3
        public byte[] DIR_EXT { get; set; }     //Offset 8 - 3 bytes. Ultimos 3 caracteres correspondientes a la extension del archivo en el formato 8.3
        public byte DIR_ATTR { get; set; }      //Offset 11 - 1 byte. Byte que nos dice el atributo del archivo.
        public byte DIR_NTRES { get; set; }     //Offset 12 - 1 bytes. Reservado, tiene que ser 0
        public byte DIR_CrtTimeTenth { get; set; }  //Offset 13 - 1 bytes.
        public ushort DIR_CrtTime { get; set; }     //Offset 14 - 2 bytes.
        public byte[] DIR_CrtDate { get; set; }     //Offset 16 - 2 bytes.
        public byte[] DIR_LstAccDate { get; set; }      //Offset 18 - 2 bytes.
        public ushort DIR_FstClustHI { get; set; }      //Offset 20 - 2 bytes.
        public byte[] DIR_WrtTime { get; set; }     //Offset 22 - 2 bytes.
        public byte[] DIR_WrtDate { get; set; }     //Offset 24 - 2 bytes.
        public ushort DIR_FstClustLO { get; set; }      //Offset 26 - 2 bytes
        public uint DIR_FileSize { get; set; }		//Offset 28 - 4 bytes

        public void setclusterSubdirectorio(ushort nCluster)
        {
            DIR_FstClustLO = nCluster;
        }

        public void NewFile(string NameArchivo, char ATTR, DateTime CRT, ushort FstClust, uint size)
        {
            string[] DirAndExt = NameArchivo.Split('.');
            byte[] aux = Encoding.ASCII.GetBytes(DirAndExt[0]);

            DIR_CrtTimeTenth = Convert.ToByte(CRT.Millisecond / 10);
            aux = Encoding.ASCII.GetBytes(DirAndExt[1]);
            Array.Resize<byte>(ref aux, 8);
            DIR_ATTR = Convert.ToByte(ATTR);
            Array.Resize<byte>(ref aux, 3);
            
            DIR_NTRES = 0;
            DIR_NAME = aux;
            DIR_EXT = aux;
            DIR_CrtTime = ushort.Parse(CRT.ToString("HHmm"));
            DIR_CrtDate = Encoding.ASCII.GetBytes(CRT.ToString("ddMMyy"));
            DIR_LstAccDate = Encoding.ASCII.GetBytes(CRT.ToShortDateString());
            DIR_FstClustHI = 0;
            DIR_WrtTime = Encoding.ASCII.GetBytes(CRT.ToShortTimeString());
            DIR_WrtDate = Encoding.ASCII.GetBytes(CRT.ToShortDateString());
            DIR_FstClustLO = FstClust;
            DIR_FileSize = size;
        }

        public void NewDir(string NameDirectory, DateTime CRT)
        {
            byte[] aux = Encoding.ASCII.GetBytes(NameDirectory);
            Array.Resize<byte>(ref aux, 8);
            DIR_NAME = aux;
            DIR_EXT = new byte[3];
            DIR_ATTR = Convert.ToByte('D');
            DIR_NTRES = 0;
            DIR_CrtTimeTenth = Convert.ToByte(CRT.Millisecond);
            DIR_CrtTime = ushort.Parse(CRT.ToString("HHmm"));
            DIR_CrtDate = Encoding.ASCII.GetBytes(CRT.ToShortDateString());
            DIR_LstAccDate = Encoding.ASCII.GetBytes(CRT.ToShortDateString());
            DIR_FstClustHI = 0;
            DIR_WrtTime = Encoding.ASCII.GetBytes(CRT.ToShortTimeString());
            DIR_WrtDate = Encoding.ASCII.GetBytes(CRT.ToShortDateString());
            DIR_FstClustLO = 0;
            DIR_FileSize = 0;
        }
    }
}
