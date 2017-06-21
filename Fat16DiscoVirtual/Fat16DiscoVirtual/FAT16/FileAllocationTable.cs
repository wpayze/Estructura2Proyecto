using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//De acuerdo a las especificacion es https://staff.washington.edu/dittrich/misc/fatgen103.pdf para FAT16

namespace Fat16DiscoVirtual.FAT16
{
    [Serializable]
    class FileAllocationTable
    {
        public ushort entrada { get; set; }

        public FileAllocationTable()
        {
            ClusterStart();
        }

        public void ClusterStart()
        {
            entrada = new ushort();
        }
        
        public void ClusterFull(Nullable<ushort> NextCluster) //Si cluster lleno valor standar 65535
        {
            if (NextCluster != null)
            {
                entrada = (ushort)NextCluster;
            }
            else
            {
                entrada = 65535;
            }
        }

        public void ClusterReserved()
        {
            entrada = 65526;
        }

        public void ClusterDamaged()
        {
            entrada = 65527;
        }

    }
}
