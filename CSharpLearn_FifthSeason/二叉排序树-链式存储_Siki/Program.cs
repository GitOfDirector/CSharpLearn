using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 二叉排序树_链式存储_Siki
{
    class Program
    {
        static void Main(string[] args)
        {

            BSTree tree = new BSTree();
            int[] data = { 62, 58, 88, 47, 73, 99, 35, 51, 93, 37 };
            foreach (int t in data)
            {
                tree.Add(t);
            }
            tree.MiddleTraversal();
            Console.WriteLine();

            Console.WriteLine("查找-------------");
            Console.WriteLine(tree.Find(99));
            Console.WriteLine(tree.Find(100));

            Console.WriteLine("删除-------------");
            tree.Delete(35);
            tree.MiddleTraversal(); Console.WriteLine();
            tree.Delete(62);
            tree.MiddleTraversal(); Console.WriteLine();



            BSTree tree2 = new BSTree();
            int[] data2 = { 62 };
            foreach (int t in data2)
            {
                tree2.Add(t);
            }

            Console.WriteLine("删除2-------------");
            tree2.Delete(62);
            tree2.MiddleTraversal(); Console.WriteLine();











            Console.ReadKey();
        }
    }
}
