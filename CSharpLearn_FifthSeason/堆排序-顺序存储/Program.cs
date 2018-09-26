using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 堆排序_顺序存储
{
    class Program
    {
        /*
         * 满二叉树
         *      除最后一层无任何子节点外，每一层上的所有结点都有两个子结点二叉树。
                国内教程定义：一个二叉树，如果每一个层的结点数都达到最大值，则这个二叉树就是满二叉树。也就是说，如果一个二叉树的层数为K，且结点总数是(2^k) -1 ，则它就是满二叉树。
         * 
         * 完全二叉树
         *      完全二叉树是效率很高的数据结构，完全二叉树是由满二叉树而引出来的。对于深度为K的，有n个结点的二叉树，当且仅当其每一个结点都与深度为K的满二叉树中编号从1至n的结点一一对应时称之为完全二叉树。
         *      有N个结点的完全二叉树各结点如果用顺序方式存储，则结点之间有如下关系：              
             *      若I为结点编号则 如果I>1，则其父结点的编号为I/2；             
             *      如果2*I<=N，则其左孩子（即左子树的根结点）的编号为2*I；若2*I>N，则无左孩子；                
             *      如果2*I+1<=N，则其右孩子的结点编号为2*I+1；若2*I+1>N，则无右孩子。
         *      
         */

        /*
         * 堆中某个节点的值总是不大于或者不小于其父节点的值
         * 堆总是一个完全二叉树
         * 
         * 将根节点最大的堆叫做最大堆（大顶堆），根节点最小的堆叫做最小堆（小顶堆）
         */

        static void Main(string[] args)
        {
            int[] data = { 50, 10, 90, 30, 70, 40, 80, 60, 20 };

            /*
                         *         50
                         *   10           90
                       * 30    70    40    80
                      60   20
             */


            HeapSort(data);

            Console.WriteLine();
            Console.WriteLine("最终结果：");
            foreach (var item in data)
            {
                Console.Write(item + "  ");
            }
            Console.WriteLine();

            Console.ReadKey();

        }

        public static void HeapSort(int[] data)
        {
            //因为data.Length为最后一个叶子节点，所以最后一个非叶节点为data.Length/2
            //遍历这个数的所有非子节点，挨个把所有的子树，变成大顶堆
            for (int i = data.Length / 2; i >= 1; i--)
            {
                HeapAjust(i, data, data.Length);
                //经过上面的for循环，是把二叉树变成了大顶堆
            }

            Console.WriteLine("第一遍循环：");
            foreach (var item in data)
            {
                Console.Write(item + "  ");
            }

            Console.WriteLine();            

            //使数据能够从小到达依次排列
            for (int i = data.Length; i > 1; i--)
            {
                //把编号1和编号i位置进行交换
                //交换此时的最大值和最小值
                int temp = data[0];
                data[0] = data[i - 1];
                data[i - 1] = temp;
                
                //此时编号i存储的是最大值，那么我们把剩余的数据重新构造成大顶堆
                //依次交换最大和最小值
                //1到(i - 1)构造成大顶堆
                HeapAjust(1, data, i - 1);

                Console.WriteLine("");
                Console.WriteLine("交换最大值之后：");
                foreach (var item in data)
                {
                    Console.Write(item + "  ");
                }
                Console.WriteLine();
             
            }

        }

        /// <summary>
        /// 堆调整---大顶堆
        /// </summary>
        /// <param name="numberToAjust">需要调整的编号</param>
        /// <param name="data"></param>
        /// <param name="maxNumber">最大编号</param>
        public static void HeapAjust(int numberToAjust, int[] data, int maxNumber)
        {
            //索引比编号小1，例如50编号为1，下标为0

            //把i节点的子树变成大顶堆
            int maxNodeNum = numberToAjust;//最大节点的编号.
            int tempNodeNum = numberToAjust;

            while (true)
            {

                int leftNodeNum = tempNodeNum * 2;
                int rightNodeNum = leftNodeNum + 1;

                //如果该节点编号存在，并且该节点的值小于其子节点的值

                if (leftNodeNum <= maxNumber && data[leftNodeNum - 1] > data[maxNodeNum - 1])
                {
                    maxNodeNum = leftNodeNum;
                }

                if (rightNodeNum <= maxNumber && data[rightNodeNum - 1] > data[maxNodeNum - 1])
                {
                    maxNodeNum = rightNodeNum;
                }

                //发现了一个比i更大的子节点，交换i和maxnodenum里面的数据
                if (maxNodeNum != tempNodeNum)
                {
                    int tempData = data[tempNodeNum - 1];
                    data[tempNodeNum - 1] = data[maxNodeNum - 1];
                    data[maxNodeNum - 1] = tempData;
                    
                    //更新缓存的最大子节点位置，循环向下比较，直至找不到比其更大的节点
                    tempNodeNum = maxNodeNum;
                }
                else
                {
                    break;
                }
            }

        }
    }
}
