using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fat16DiscoVirtual.BplusTree
{
    class LeafNode
    {
        public bool index { get; set; }
        public List<Node> values { get; set; }
        public LeafNode nextLeaf { get; set; }

        public void newIndex()
        {
            values = new List<Node>();
            nextLeaf = null;
            index = true;
        }

        public void newLeaf()
        {
            values = new List<Node>();
            index = false;
            nextLeaf = null;
        }
    }
    
}
