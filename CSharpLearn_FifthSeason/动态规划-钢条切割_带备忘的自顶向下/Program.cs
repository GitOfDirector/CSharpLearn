using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 动态规划_钢条切割_带备忘的自顶向下
{
    class Program
    {
        static void Main(string[] args)
        {
            int steelBarLen = 10;//需要切割的钢条的长度
            int[] price = { 0, 1, 5, 8, 9, 10, 17, 17, 20, 24, 30 };//索引代表钢条的长度，值代表价格

            int[] result = new int[steelBarLen + 1] ;

            TimeSpan time1 = System.DateTime.Now.TimeOfDay;

            Console.WriteLine(0 + " 收益：" + UpDown(0, price, result));//0
            //Console.WriteLine(1 + " 收益：" + UpDown(1, price, result));//1
            //Console.WriteLine(2 + " 收益：" + UpDown(2, price, result));//5
            //Console.WriteLine(9 + " 收益：" + UpDown(9, price, result));//25
            Console.WriteLine(10 + " 收益：" + UpDown(10, price, result));//30

            TimeSpan time2 = System.DateTime.Now.TimeOfDay;

            Console.WriteLine("耗时：" + (time2 - time1).TotalMilliseconds);

            Console.ReadKey();

        }

        /// <summary>
        /// 求得长度为n的最大收益
        /// 自顶向下
        /// </summary>
        /// <param name="len"></param>
        /// <param name="price"></param>
        /// <returns></returns>
        static int UpDown(int len, int[] price, int[] result)
        {
            if (len == 0)
            {
                return 0;
            }

            //将已经求解过的子问题的解保存起来
            if (result[len] != 0)
            {
                return result[len];
            }

            int tempMaxPrice = 0;

            for (int i = 1; i < len + 1; i++)
            {
                int maxPrice = price[i] + UpDown(len - i, price, result);
                if (maxPrice > tempMaxPrice)
                {
                    tempMaxPrice = maxPrice;
                }

            }
            
            result[len] = tempMaxPrice;


            return tempMaxPrice;

        }

    }
}
