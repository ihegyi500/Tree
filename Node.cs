using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PocketSolution_Tree
{
    class Node
    {
        const int byteLim = 256;
        private string value = RandomString(), input = "";
        private static Random ranChars = new Random(), ranLength = new Random();
        public ExpandState es { get; set; }
        public SelectionState ss { get; set; }
        public Node parent { get; set; }
        public List<Node> children { get; set; }
        public Node()
        {
            parent = null;
            children = new List<Node>();
            es = ExpandState.Collapsed;
            ss = SelectionState.NotSelected;
        }
        public static string RandomString()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, ranLength.Next(0, byteLim / sizeof(char)))
              .Select(s => s[ranChars.Next(s.Length)]).ToArray());
        }
        public string GetValue() { return value; }
        public void Expand()
        {
                while (input != "1" && input != "2" && input != "3")
                {
                    Console.WriteLine("1: Expand\n2: Collapse\n3: Back");
                    input = Console.ReadLine();
                    switch (input)
                    {
                        case "1":
                            es = ExpandState.Expanded;
                            Console.WriteLine("Node expanded!\n");
                            break;
                        case "2":
                            es = ExpandState.Collapsed;
                            Console.WriteLine("Node collapsed!\n");
                            break;
                        case "3":
                            break;
                        default:
                            Console.WriteLine("Invalid user input, please try again!\n");
                            break;
                    }
                }
                input = "";
            }
        public void Selection()
        {
            while (input != "1" && input != "2" && input != "3" && input != "4")
            {
                Console.WriteLine("1: Select\n2: Unselect\n3: Back");
                input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        if(es == ExpandState.Collapsed)
                        {
                            RecursivelySelect(this);
                            Console.WriteLine("Node recursively selected!\n");
                        }
                        else
                        {
                            ss = SelectionState.Selected;
                            Console.WriteLine("Node selected!\n");
                        }
                        break;
                    case "2":
                        if (es == ExpandState.Collapsed)
                        {
                            RecursivelyUnselect(this);
                            Console.WriteLine("Node recursively unselected!\n");
                        }
                        else
                        {
                            ss = SelectionState.NotSelected;
                            Console.WriteLine("Node unselected!\n");
                        }
                        break;
                    case "3":
                        break;
                    default:
                        Console.WriteLine("Invalid user input, please try again!\n");
                        break;
                }
            }
            input = "";
        }
        private void RecursivelySelect(Node n)
        {
            n.ss = SelectionState.Selected;
            if(n.es == ExpandState.Collapsed)
            {
                foreach(Node child in n.children)
                {
                    RecursivelySelect(child);
                }
            }
        }
        private void RecursivelyUnselect(Node n)
        {
            n.ss = SelectionState.NotSelected;
            if (n.es == ExpandState.Collapsed)
            {
                foreach (Node child in n.children)
                {
                    RecursivelyUnselect(child);
                }
            }
        }
    }
}
