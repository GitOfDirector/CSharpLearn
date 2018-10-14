using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 动态规划_背包问题_无备忘递归_自顶向下
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] w = { 0, 3, 4, 5, 1, 8, 6, 10, 15, 12 };//物品重量
            int[] p = { 0, 4, 5, 6, 10, 4, 6, 10, 16, 24 };//物品价值

            Console.WriteLine("1===" + UpDown(10, 9, w, p));
            Console.WriteLine("2===" + UpDown(30, 9, w, p));

            Console.ReadKey();
        }

        public static int UpDown(int m, int i, int[] w, int[] p)
        {

            //背包容量为0或者物品数量为0
            if (i == 0 || m == 0)
                return 0;

            if (w[i] > m)//如果第i种物品大于背包容量，那么不放入
            {
                return UpDown(m, i - 1, w, p);
            }
            else
            {
                //如果第i类物品的重量小于背包容量
                //那么分为两种情况
                //放入
                int maxValue1 = UpDown(m - w[i], i - 1, w, p) + p[i];
                //不放入
                int maxValue2 = UpDown(m, i - 1, w, p);

                if (maxValue1 > maxValue2)
                {
                    return maxValue1;
                }
                else
                {
                    return maxValue2;
                }
            }
        }









    }
}
