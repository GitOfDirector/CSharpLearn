using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 动态规划_钢条切割_递归实现
{
    class Program
    {
        static void Main(string[] args)
        {
            int steelBarLen = 5;//需要切割的钢条的长度
            int[] price = { 0, 1, 5, 8, 9, 10, 17, 17, 20, 24, 30 };//索引代表钢条的长度，值代表价格

            Console.WriteLine(0 + " 收益：" + UpDown(0, price));//0
            Console.WriteLine(1 + " 收益：" + UpDown(1, price));//1
            Console.WriteLine(2 + " 收益：" + UpDown(2, price));//5
            Console.WriteLine(9 + " 收益：" + UpDown(9, price));//25
            Console.WriteLine(10 + " 收益：" + UpDown(10, price));//30

            Console.ReadKey();
        }

        /// <summary>
        /// 求得长度为n的最大收益
        /// 自顶向下
        /// </summary>
        /// <param name="len"></param>
        /// <param name="price"></param>
        /// <returns></returns>
        static int UpDown(int len, int[] price) 
        {

            /*
             * r(n)= max( p(i) +r(n - i) );
             * 
             *缺点：
             *      反复求解了相同子问题
             *      例如
                     *      r(10) = p(1) + r(9);
                     *      r(9) = p(1) + r(8);
             *      重复求取了r(8)
             * 
             */


            if (len == 0)
            {
                return 0;                
            }

            int tempMaxPrice =0;

            for (int i = 1; i < len+ 1; i++)
            {
                int maxPrice = price[i] + UpDown(len - i, price);
                if (maxPrice > tempMaxPrice)
                {
                    tempMaxPrice = maxPrice;
                }

            }

            return tempMaxPrice;

        }

        //动态规划---付出空间以节省计算时间



    }
}
