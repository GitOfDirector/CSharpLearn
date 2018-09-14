using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 最大子数组_暴力求解
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] priceArray = { 10, 200, -10, 50, 45, 110, 85, 105, 102, 86, 63, 81, 101, 94, 106, 101, 79, 94, 90, 97 };
            foreach (var item in priceArray)
            {
                Console.Write(item + "  ");
            }

            int[] priceFluctuationArr = new int[priceArray.Length - 1];
            for (int i = 1; i < priceArray.Length; i++)
            {
                int fluc = priceArray[i] - priceArray[i - 1];
                priceFluctuationArr[i - 1] = fluc;
            }

            Console.WriteLine();
            foreach (var item in priceFluctuationArr)
            {
                Console.Write(item + "   ");
            }

            int total = 0;
            int startIndex = 0;
            int endIndex = 0;

            for (int i = 0; i < priceFluctuationArr.Length; i++)
            {

                //取得以i为起点的所有子数组
                for (int j = i; j < priceFluctuationArr.Length; j++)
                {
                    int totalTemp = 0;
                    for (int k = i; k < j + 1; k++)
                    {
                        totalTemp += priceFluctuationArr[k];
                    }

                    if (totalTemp > total)
                    {
                        total = totalTemp;
                        startIndex = i + 1;//第i个波动代表着从下标为i买入，即第i + 1天
                        endIndex = j + 2;//第j个的波动代表着从下标为j + 1卖出，即第j + 2天卖出
                    }

                }
            }

            Console.WriteLine();
            Console.WriteLine("在第" + startIndex + "天买入，在第" + endIndex + "天卖出，总收入：" + total);

            Console.ReadKey();
        }
    }
}
