using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fat16DiscoVirtual.FAT16
{
    [Serializable]
    class MasterBootRecord
    {
        public MasterBootRecord()
        {

        }

        public byte[] JumpIns = new byte[3]; //Offset 0 - 3 bytes
        public byte[] OEMname = new byte[8]; //Offset 3 - 8 bytes

        //BIOS Parameter Block

        public short BytesPerSector = new short(); //Offset 11 - 2 bytes
        public byte SectorsPerCluster = new byte(); //Offset 13 - 1 byte
        public short ReservedSectors = new short(); //Offset 14 - 2 bytes
        public byte NumeroDeFATS = new byte(); //Offset 16 - 1 byte - 2 FATs
        public short RootEntryCount = new short(); //Offset 17 - 2 bytes
        public byte Reservado = new byte(); //Offset 52 - 12 bytes
        public byte MediaDescriptor = new byte(); //Offset 21 - 1 byte
        public short SectorPerTrack = new short();  //Offset 24 - 2 bytes
        public short NumeroHeads = new short(); //Offset 26 - 2 bytes
        public int HiddenSectors = new int(); //Offset 28 - 4 bytes
        public short SmallSectors = new short();
        public short SectorPerFATS = new short();
        public int LargeSectors = new int();
        public byte PhysicalDrive = new byte();
        public int Serial = new int();
        public byte ExtBootSignature = new byte();
        public short EndOfSector = new short();

        public byte[] VolumeLabel = new byte[11]; //Offset 71 - 11 bytes
        public byte[] FileSystemType = new byte[8]; //Offset 82 - 8 bytes
        public byte[] BootCode = new byte[420]; //Offset 90 - 420 bytes
    
        public void DatosMBR ()
        {
            byte[] VLabel = Encoding.ASCII.GetBytes("DiscoLocal");
            Array.Resize<byte>(ref VLabel, 11);
            byte[] FStype = Encoding.ASCII.GetBytes("FAT16");
            Array.Resize<byte>(ref FStype, 8);

            FileSystemType = FStype;
            VolumeLabel = VLabel;

            OEMname = Encoding.ASCII.GetBytes("MSWIN4.1");
            BytesPerSector = 512;
            SectorsPerCluster = 32;
            ReservedSectors = 2;
            NumeroDeFATS = 1;
            RootEntryCount = 512;
            EndOfSector = 1;
            MediaDescriptor = 0xf8;
            SectorPerFATS = 256;
            Reservado = 0;
            SmallSectors = 0;
            SectorPerTrack = 0;
            NumeroHeads = 0;
            HiddenSectors = 0;
            Serial = 1995123;
            LargeSectors = 2097152;
            PhysicalDrive = 1;
            ExtBootSignature = 29;
        }

    }
}
