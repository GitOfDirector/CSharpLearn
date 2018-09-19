using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 二叉树_顺序存储
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] data = { 'A', 'B', 'C', 'D', 'E', 'F', 'G'};
            //A B D E C F G
            //D B E A F C G
            //D E B F G C A
           
            BinaryTree<char> tree = new BinaryTree<char>(7);
            for (int i = 0; i < data.Length; i++)
            {
                tree.Add(data[i]);
            }

            tree.TreeTraversal();
            Console.WriteLine();
            tree.TreeTraversal(BinaryTree<char>.TraversalType.Inorder);
            Console.WriteLine();
            tree.TreeTraversal(BinaryTree<char>.TraversalType.Postorder);
            Console.WriteLine();
            tree.TreeTraversal(BinaryTree<char>.TraversalType.Layer);

            Console.ReadKey();

        }
    }
}
