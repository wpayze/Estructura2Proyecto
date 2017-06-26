using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fat16DiscoVirtual.BplusTree
{
    class IndexNode
    {
        protected List<Node> children;

        public IndexNode(List<int> newKeys, List<Node> newChildren)
        {
            children = new List<Node>(newChildren);
        }

        /*public void insertSorted(Entry<int, Node> e, int index)
        {
            int key = e.getKey();
            Node child = e.getValue();
        }*/
    }
}
