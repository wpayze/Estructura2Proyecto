using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fat16DiscoVirtual.BplusTree
{
    class Node
    {
        protected bool isLeafNode { get; set; }
        protected bool keys { get; set; }
        public string name { get; set; }
        public ushort CLUSTER { get; set; }
        public LeafNode RightValues { get; set; }
        public LeafNode LeftValues { get; set; }

        public bool isOverflowed()
        {
            return (true);
        }

        public bool isUnderflowed()
        {
            return false;
        }
        public void IndexInput(string _name, LeafNode L, LeafNode R)
        {
            LeftValues = L;
            RightValues = R;
            name = _name;
            CLUSTER = 0;
            
        }

        public void LeafInput(string _name, ushort _CLUSTER)
        {
            name = _name;
            CLUSTER = _CLUSTER;
            LeftValues = null;
            RightValues = null;
        }

      
    }
}
