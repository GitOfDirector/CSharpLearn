using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 动态规划_背包问题_穷举法
{
    class Program
    {
        static void Main(string[] args)
        {
            //string str = "102201";
            //char c = str[0];
            //Console.WriteLine("第一个字符：" + str[0] + "===" + c);

            //int backpackCapacity = 100;//背包容量

            int[] w = { 0, 3, 4, 5, 1, 8, 6, 10, 15, 12 };//物品重量
            int[] p = { 0, 4, 5, 6, 10, 4, 6, 10, 16, 24 };//物品价值

            Console.WriteLine("1===" + Exhaustivity(10, w, p));
            Console.WriteLine("1===" + Exhaustivity(30, w, p));
            Console.WriteLine("2===" + Exhaustivity2(10, w, p));
            Console.WriteLine("2===" + Exhaustivity2(30, w, p));


            Console.WriteLine("1000 0000 指定位：" + GetOneBinaryValue2(128, 8));
            Console.WriteLine("0001 指定位：" + GetOneBinaryValue2(1, 1));
            Console.WriteLine("0110 指定位：" + GetOneBinaryValue2(6, 3));
            Console.WriteLine("1010 指定位：" + GetOneBinaryValue2(10, 3));
            Console.WriteLine("1001 0110 指定位：" + GetOneBinaryValue2(150, 6));

            Console.ReadKey();
        }

        public static int Exhaustivity(int m, int[] w, int[] p)
        {
            int goodsNum = w.Length;//物品种类

            /* 
             *对于n中物品，可以将其看成n位的二进制数，
             *第几种物品被选中，将该位置二进制值置为1即可，
             *然后累计其价值和重量
             * 0   0   0   0   0
             * 
             * 那么共有2^n种分配情况，即从0到2^n -1
             */

            int classifyWays = (int)Math.Pow(2, goodsNum);

            int maxPrice = 0;//最大价值        
            int maxWeight = 0;//最大价值        

            for (int i = 0; i < classifyWays; i++)
            {
                //计算当前方式下的总价值

                string binaryStr = Convert.ToString(i, 2);
                int len = binaryStr.Length - 1;

                int weightTotal = 0;
                int priceTotal = 0;

                //Console.WriteLine(binaryStr.Length);
                for (int j = 0; j < binaryStr.Length; j++)
                {
                    //字符串第 j 位 相当于 第 len-j 位二进制数

                    //int cPos = len - j;
                    //Console.WriteLine(cPos);

                    char c = binaryStr[len - j];
                    if (c == '1')
                    {
                        weightTotal += w[j];
                        priceTotal += p[j];
                    }
                }
                //Console.WriteLine();

                if (weightTotal <= m && maxPrice < priceTotal)
                {
                    maxWeight = i;
                    maxPrice = priceTotal;
                }
            }

            Console.WriteLine("1 采用方式：" + Convert.ToString(maxWeight, 2));

            return maxPrice;
        }

        public static int Exhaustivity2(int m, int[] w, int[] p)
        {
            int goodsNum = w.Length - 1;//物品种类

            int classifyWays = (int)Math.Pow(2, goodsNum);

            int maxPrice = 0;//最大价值        
            int maxWeight = 0;

            for (int j = 0; j < classifyWays; j++)
            {
                int weightTotal = 0;
                int priceTotal = 0;

                //依次取得数 j 的第 number 位的值
                for (int number = 1; number <= goodsNum; number++)
                {
                    int result = GetOneBinaryValue(j, number);
                    if (result == 1)
                    {
                        weightTotal += w[number];
                        priceTotal += p[number];
                    }
                }
                if (weightTotal <= m && priceTotal > maxPrice)
                {
                    maxWeight = j;
                    maxPrice = priceTotal;
                }
            }

            Console.WriteLine("2 采用方式：" + Convert.ToString(maxWeight, 2));

            return maxPrice;
        }

        /// <summary>
        /// 取得数 j 二进制后 第 number 位的数值
        /// </summary>
        /// <param name="j"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        public static int GetOneBinaryValue(int j, int number)
        {
            int A = j;

            int B = (int)Math.Pow(2, number - 1);
            //将数字B默认为每一位均为0，将需要求的第n位设为1，即数字B为2^(number-1)
            //然后将A和B进行与运算，那么A的第n位如果为0，那么运算结果就为0

            int result = A & B;

            if (result == 0)
                return 0;
            return 1;
        }

        public static int GetOneBinaryValue2(int j, int number)
        {
            int num = j;
            int move = number - 1;

            //将第n位的数字取出，将其右移(n - 1)位，即将其放置到第一个位置上
            int newNum = j >> move;

            //和 1 进行与运算
            return newNum & 1;

        }

    }
}
