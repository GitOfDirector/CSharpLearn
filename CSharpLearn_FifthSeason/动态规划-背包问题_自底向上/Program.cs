using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 动态规划_背包问题_自底向上
{
    class Program
    {
        static int[,] result = new int[50, 10];

        static void Main(string[] args)
        {

            int[] w = { 0, 3, 4, 5, 1, 8, 6, 10, 15, 12 };//物品重量
            int[] p = { 0, 4, 5, 6, 10, 4, 6, 10, 16, 24 };//物品价值

            Console.WriteLine("1===" + BottomUp(10, 9, w, p));
            Console.WriteLine("2===" + BottomUp(30, 9, w, p));

            Console.ReadKey();
        }

        public static int BottomUp(int m, int i, int[] w, int[] p)
        {
            //如下判断只适用于w，p未进行变化的情况
            if (result[m, i] != 0)
                return result[m, i];

            for (int tempM = 1; tempM < m + 1; tempM++)
            {
                for (int tempI = 1; tempI < i + 1; tempI++)
                {
                    if (result[tempM, tempI] != 0)
                        continue;

                    if (w[tempI] > tempM)
                    {
                        result[tempM, tempI] = result[tempM, tempI - 1];
                    }
                    else
                    {
                        int maxVlue1 = result[tempM - w[tempI], tempI - 1] + p[tempI];
                        int maxVlue2 = result[tempM, tempI - 1];

                        if (maxVlue1 > maxVlue2)
                        {
                            result[tempM, tempI] = maxVlue1;
                        }
                        else
                        {
                            result[tempM, tempI] = maxVlue2;
                        }
                    }
                }
            }
            return result[m, i];
        }
    }
}
