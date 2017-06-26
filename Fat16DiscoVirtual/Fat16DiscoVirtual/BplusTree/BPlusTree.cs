using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fat16DiscoVirtual.BplusTree
{
    /**
 * BPlusTree Class Assumptions: 1. No duplicate keys inserted 2. Order D:
 * D<=number of keys in a node <=2*D 3. All keys are non-negative
 */
    public class BPlusTree
    {
        //public Node Root;
        public static int D = 2;

        private void updateIndexNodeKeyWithKey(Node theNode, int searchKey, int newKey)
        {
            if (theNode == null)
                return;
        }
    }
}
