using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 动态规划_钢条切割_自底向上
{
    class Program
    {
        /*
         * 所有的问题都应该依赖于其更小的子问题，而不是大问题
         */

        static void Main(string[] args)
        {
            int steelBarLen = 10;//需要切割的钢条的长度
            int[] price = { 0, 1, 5, 8, 9, 10, 17, 17, 20, 24, 30 };//索引代表钢条的长度，值代表价格

            int[] result = new int[steelBarLen + 1];

            TimeSpan time1 = System.DateTime.Now.TimeOfDay;

            Console.WriteLine(BottomUp(0, price, result));
            Console.WriteLine(BottomUp(10, price, result));

            TimeSpan time2 = System.DateTime.Now.TimeOfDay;

            Console.WriteLine("耗时：" + (time2 - time1).TotalMilliseconds);

            Console.ReadKey();

        }
        static int BottomUp(int len, int[] price, int[] result) 
        {
            for (int i = 1; i < len +1; i++)
            {
                //下面取得钢条长度为i的时候的最大收益

                int tempMaxPrice = -1;
               
                for (int j = 1; j <= i; j++)
                {
                    int maxPrice = price[j] + result[i - j];
                    if (maxPrice > tempMaxPrice)
                    {
                        tempMaxPrice = maxPrice;
                    }
                }

                result[i] = tempMaxPrice;
            }

            return result[len];
        }

    }
}
