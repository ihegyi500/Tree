using System;

namespace PocketSolution_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "";
            Tree tree = new Tree();

            while (input != "E")
            {
                Console.WriteLine("1 - Node Selection" + Environment.NewLine +
                                  "2 - Expand/Collapse Node" + Environment.NewLine +
                                  "3 - Show selected nodes" + Environment.NewLine +
                                  "4 - Show the entire tree" + Environment.NewLine +
                                  "E - Exit");
                input = Console.ReadLine();
                if(input == "1" || input == "2")
                {
                    Console.WriteLine("Please choose a node: ");
                    tree.ShowsNodesToChoose(tree.GetRoot());
                    tree.i = 1;
                    tree.ChooseNode(tree.GetRoot(), Console.ReadLine(), input);
                    tree.i = 1;
                }
                else if(input == "3")
                    tree.ShowSelectedNodes(tree.GetRoot());
                else if(input == "4")
                    tree.ShowAllNodes(tree.GetRoot());
                else if(input == "E")
                {
                    Console.WriteLine("Bye!\n");
                    return;
                }
                else
                    Console.WriteLine("Invalid user input, please try again!\n");
            }
        }
    }
}
