using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//De acuerdo a las especificacion es https://staff.washington.edu/dittrich/misc/fatgen103.pdf para FAT16

namespace Fat16DiscoVirtual.FAT16
{
    public class DirectoryEntry
    {
        public DirectoryEntry()
        {
            DIR_NAME = new byte[8];
            DIR_LstAccDate = new ushort();
            DIR_WrtDate = new ushort();
            DIR_CrtTimeTenth = new byte();
            DIR_FstClustLO = new ushort();
            DIR_NTRES = new byte();
            DIR_FileSize = new uint();
            DIR_FstClustHI= new ushort();
            DIR_EXT = new byte[3];
            DIR_WrtTime = new ushort();
            DIR_CrtDate = new ushort();
            DIR_CrtTime = new ushort();
            DIR_ATTR = new byte();
        }

        public byte[] DIR_NAME { get; set; }    //Offset 0 - 8 bytes. Primeros ocho caracteres del nombre del archivo con el formato 8.3
        public byte[] DIR_EXT { get; set; }     //Offset 8 - 3 bytes. Ultimos 3 caracteres correspondientes a la extension del archivo en el formato 8.3
        public byte DIR_ATTR { get; set; }      //Offset 11 - 1 byte. Byte que nos dice el atributo del archivo.
        public byte DIR_NTRES { get; set; }     //Offset 12 - 1 bytes. Reservado, tiene que ser 0
        public byte DIR_CrtTimeTenth { get; set; }  //Offset 13 - 1 bytes.
        public ushort DIR_CrtTime { get; set; }     //Offset 14 - 2 bytes.
        public ushort DIR_CrtDate { get; set; }     //Offset 16 - 2 bytes.
        public ushort DIR_LstAccDate { get; set; }      //Offset 18 - 2 bytes.
        public ushort DIR_FstClustHI { get; set; }      //Offset 20 - 2 bytes.
        public ushort DIR_WrtTime { get; set; }     //Offset 22 - 2 bytes.
        public ushort DIR_WrtDate { get; set; }     //Offset 24 - 2 bytes.
        public ushort DIR_FstClustLO { get; set; }      //Offset 26 - 2 bytes
        public uint DIR_FileSize { get; set; }		//Offset 28 - 4 bytes

        public void SetclusterSub(ushort nCluster)
        {
            DIR_FstClustLO = nCluster;
        }
        public ushort setDays(DateTime date)
        {
            DateTime fechabase = DateTime.Parse("01/01/2017");
            ushort result = (ushort)(date-fechabase).TotalDays;
            return result;
        }
        public ushort setHrs(DateTime date)
        {
            DateTime fechabase = DateTime.Parse("00:00PM");
            TimeSpan TSpan = date.Subtract(fechabase);
            return (ushort)TSpan.TotalMinutes; ;
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
            DIR_CrtTime = setHrs(CRT);
            DIR_CrtDate = setDays(CRT);
            DIR_LstAccDate = setDays(CRT);
            DIR_FstClustHI = 0;
            DIR_WrtTime = setHrs(CRT);
            DIR_WrtDate = setDays(CRT);
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
            DIR_CrtTimeTenth = Convert.ToByte(CRT.Millisecond / 10);
            DIR_CrtTime = setHrs(CRT);
            DIR_CrtDate = setDays(CRT);
            DIR_LstAccDate = setDays(CRT);
            DIR_FstClustHI = 0;
            DIR_WrtTime = setHrs(CRT);
            DIR_WrtDate = setDays(CRT);
            DIR_FstClustLO = 0;
            DIR_FileSize = 0;
        }
    }
}
