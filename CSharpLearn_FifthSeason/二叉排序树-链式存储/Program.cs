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
            int[] datas = { 55, 40, 70, 20, 50, 60, 90, 10, 30, 80, 100 };

            BinarySortTree bst = new BinarySortTree();

            bst.AddRange(datas);
            Console.WriteLine("finish add......the count is " + bst.nodeCount);

            bst.TreeTraversalBySort();
            Console.WriteLine();

            bst.Delete(40);

            bst.TreeTraversal();
            Console.WriteLine();

            int[] datas2 = { 55, 40, 70, 20, 50, 60, 90, 10, 30, 43, 53, 80, 100 };
            BinarySortTree bst2 = new BinarySortTree();
            bst2.AddRange(datas2);
            bst2.TreeTraversalBySort();
            Console.WriteLine();
            bst2.Delete(40);
            bst2.TreeTraversal();
            Console.WriteLine();
            bst2.Delete(53);
            bst2.TreeTraversal();
            Console.WriteLine();

            int[] datas3 = { 521 };
            BinarySortTree bst3 = new BinarySortTree();
            bst3.AddRange(datas3);
            bst3.TreeTraversalBySort();
            Console.WriteLine();
            bst3.Delete(521);
            bst3.TreeTraversal();
            Console.WriteLine();


            int[] arr = { 1, 4, 5 };
            System.Console.WriteLine("Inside Main, before calling the method, the first element is: {0}", arr[0]);

            ChangeArr(arr);
            System.Console.WriteLine("Inside Main, after calling the method, the first element is: {0}", arr[0]);
          
            //output:
            //Inside Main, before calling the method, the first element is: 1 
            //Inside the method, the first element is: -3 
            //Inside Main, after calling the method, the first element is: 888 

            int[] arr2 = { 1, 4, 5 };
            System.Console.WriteLine("Inside Main, before calling the method, the first element is: {0}", arr2[0]);

            ChangeArr2(ref arr2);
            System.Console.WriteLine("Inside Main, after calling the method, the first element is: {0}", arr2[0]);

            //output:
            //Inside Main, before calling the method, the first element is: 1 
            //Inside the method, the first element is: -3 
            //Inside Main, after calling the method, the first element is: -3

            Console.ReadKey();

        }

        static void ChangeArr(int[] pArray)
        {
            pArray[0] = 888;  // This change affects the original element.
            pArray = new int[5] { -3, -1, -2, -3, -4 };   // This change is local.
            System.Console.WriteLine("Inside the method, the first element is: {0}", pArray[0]);
        }

        static void ChangeArr2(ref int[] pArray)
        {
            // Both of the following changes will affect the original variables:
            pArray[0] = 888;
            pArray = new int[5] { -3, -1, -2, -3, -4 };
            System.Console.WriteLine("Inside the method, the first element is: {0}", pArray[0]);
        }
    }

    

}
