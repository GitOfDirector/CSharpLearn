using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 二叉排序树_链式存储
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] datas = { 55, 40, 70, 20, 50, 60, 90, 10, 30, 80, 100};

            BinarySortTree bst = new BinarySortTree();
            
            bst.AddRange(datas);
            Console.WriteLine("finish add......the count is " + bst.nodeCount);

            bst.TreeTraversalBySort();
            Console.WriteLine();

            bst.Delete(40);

            bst.TreeTraversal();
            Console.WriteLine();

            Console.ReadKey();

        }
    }
}
