using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fat16DiscoVirtual.FAT16
{
    class DMBR
    {
        public DMBR()
        {

        }

        public byte[] JumpIns { get; set; }
        public byte[] OEMname { get; set; }

        //BIOS Parameter Block
        public short BytesPerSector { get; set; }
        public byte SectorsPerCluster { get; set; }
        public short ReservedSectors { get; set; }
        public byte NumeroDeFATS { get; set; }
        public short RootEntryCount { get; set; }
        public short SmallSectors { get; set; }
        public byte MediaDescriptor { get; set; }
        public short SectorPerFATS { get; set; }
        public short SectorPerTrack { get; set; }
        public short NumeroHeads { get; set; }
        public int HiddenSectors { get; set; }
        public int LargeSectors { get; set; }
        public byte PhysicalDrive { get; set; }
        public byte Reservado { get; set; }
        public byte ExtBootSignature { get; set; }
        public int Serial { get; set; }
        public string VolumeLabel { get; set; }
        public string FileSystemType { get; set; }
        public byte[] BootCode { get; set; }
        public short EndOfSector { get; set; }
    }
}
