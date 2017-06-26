using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fat16DiscoVirtual.FAT16;

namespace Fat16DiscoVirtual.BplusTree
{
    class Operations
    {
        LeafNode hoja = new LeafNode();
        //Initial Insert to tree
        public static Node insert(Node newNode, LeafNode newLeaf)
        {
            if (newLeaf.index == false)
            {
                newLeaf.values.Add(newNode);
                newLeaf.values = newLeaf.values.OrderBy(x => x.name).ToList();

                if (newLeaf.values.Count() > Vars.m)
                {
                    Node promoted = Promover(newLeaf);
                    return promoted;
                }
                else
                {
                    return null;
                }
            }
            else 
            {
                int LeafSize = newLeaf.values.Count();

                for (int i = 0; i < LeafSize; i++)
                {
                    Node actual = newLeaf.values.ElementAt(i);

                    int c = string.Compare(newNode.name, actual.name);
                    if (c == -1)
                    {
                        Node promoted = insert(newNode, actual.LeftValues);
                        if (promoted != null)
                        {
                            actual.LeftValues = promoted.RightValues;
                        }
                        return promoted;
                    }
                    else
                    {
                        if (i != LeafSize - 1)
                        {
                            Node nextNode = newLeaf.values.ElementAt(i + 1);
                            c = string.Compare(newNode.name, nextNode.name);

                            if (c == -1)
                            {
                                Node promoted = insert(newNode, actual.RightValues);
                                if (promoted != null)
                                {
                                    actual.RightValues = new LeafNode();
                                    actual.RightValues = promoted.LeftValues
;
                                    nextNode.LeftValues = promoted.RightValues;
                                }
                                return promoted;
                            }
                            else
                            {
                                Node promoted = insert(newNode, nextNode.RightValues);
                                if (promoted != null)
                                {
                                    nextNode.RightValues = new LeafNode();
                                    nextNode.RightValues = promoted.LeftValues;
                                }
                                return promoted;
                            }
                        }
                        else
                        {
                            Node promoted = insert(newNode, actual.RightValues);
                            if (promoted != null)
                            {
                                actual.RightValues = new LeafNode();
                                actual.RightValues = promoted.LeftValues;
                            }
                            return promoted;
                        }
                    }
                }
                return null;
            }
        }

        public static Node Promover(LeafNode hoja)
        {
            Node NodePromoted;
            int Middle = Vars.m / 2;
            NodePromoted = hoja.values.ElementAt(Middle);
            LeafNode RightValues = new LeafNode();
            LeafNode LeftValues = new LeafNode();

            if (hoja.index != null)
            {
                hoja.newIndex();
                RightValues.newIndex();
                hoja.values.RemoveAt(Middle);

            }
            else
            {
                LeftValues.newLeaf();
                RightValues.newLeaf();
            }

            if (hoja.index)
            {
                LeftValues.nextLeaf= null;
            }
            else
            {
               LeftValues.nextLeaf = RightValues;
            }
            NodePromoted.LeftValues = LeftValues;
            NodePromoted.RightValues = RightValues;
            return NodePromoted;
        }


       
        }
    }

