using System;
using System.Collections.Generic;
using System.Text;

namespace PocketSolution_Tree
{
    class Tree
    {
        Node root, n1, n2, n3, n4, n5;
        string tab = "";
        public int i = 1;
        public Tree()
        {
            root = new Node();
            n1 = new Node();
            n2 = new Node();
            n3 = new Node();
            n4 = new Node();
            n5 = new Node();
            SetParentAndChildren(root, n1);
            SetParentAndChildren(root, n2);
            SetParentAndChildren(n1, n3);
            SetParentAndChildren(n1, n4);
            SetParentAndChildren(n1, n5);
        }
        private void SetParentAndChildren(Node parent, Node child)
        {
            parent.children.Add(child);
            child.parent = parent;
        }
        public Node GetRoot() { return root; }
        public void ShowsNodesToChoose(Node n)
        {
            Console.WriteLine("{0} - {1}\n", i, n.GetValue());
            i++;
            if (n.children.Count != 0)
            {
                foreach (Node child in n.children)
                    ShowsNodesToChoose(child);
            }
        }
        public void ChooseNode(Node n, string chosenNode, string chosenTask)
        {
            if (chosenNode == i.ToString())
            {
                if (chosenTask == "1")
                    n.Selection();
                else
                    n.Expand();
            }
            i++;
            if (n.children.Count != 0)
            {
                foreach (Node child in n.children)
                    ChooseNode(child, chosenNode, chosenTask);
            }
        }
        public void ShowAllNodes(Node n)
        {
            Console.WriteLine("{0}{1}\n", tab, n.GetValue());
            if(n.children.Count != 0)
            {
                Console.WriteLine("{0}|-->",tab);
                tab += "\t";
                foreach (Node child in n.children)
                {
                    ShowAllNodes(child);
                }
                tab = tab.Remove(tab.Length - 1);
            }
        }
        public void ShowSelectedNodes(Node n)
        {
            if (n.ss == SelectionState.Selected)
                Console.WriteLine("{0}\n", n.GetValue());
            foreach (Node nodes in n.children)
            {
                ShowSelectedNodes(nodes);
            }
        }
    }
}
