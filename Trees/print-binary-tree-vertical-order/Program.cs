using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace print_binary_tree_vertical_order
{
    class Program
    {
        // http://www.geeksforgeeks.org/print-binary-tree-vertical-order-set-2/
        static void Main(string[] args)
        {
            PrintVerticalOrder(GetTree());
        }

        static Node GetTree()
        {
            /*
                   1
                /    \
               2      3
              / \    / \
             4   5  6   7
                     \   \
                      8   9 
             */
            return new Node(1, 
                new Node(2, new Node(4), new Node(5)), 
                new Node(3, new Node(6, null, new Node(8)), new Node(7, null, new Node(9)))
               );
        }

        static void PrintVerticalOrder(Node tree)
        {
            SortedList<int, List<int>> keys = new SortedList<int, List<int>>();
            TraversTreeVertical(tree, 0, keys);
            foreach (var k in keys.Keys)
            {
                Console.WriteLine(string.Join(" ", keys[k].ToArray()));
            }
            Console.Read();
        }

        static void TraversTreeVertical(Node node, int horizontalDistance, SortedList<int, List<int>> keys)
        {
            if (node == null)
                return;

            if (!keys.ContainsKey(horizontalDistance))
                keys.Add(horizontalDistance, new List<int>());
            keys[horizontalDistance].Add(node.Data);

            TraversTreeVertical(node.Left, horizontalDistance - 1, keys);

            TraversTreeVertical(node.Right, horizontalDistance + 1, keys);
        }
    }

    class Node
    {
        public int Data { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
        public Node(int data, Node left = null, Node right = null)
        {
            Data = data;
            Left = left;
            Right = right;
        }
    }
}
