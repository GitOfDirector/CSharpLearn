using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 最大子数组_分治
{
    class Program
    {
        struct SubArrResult
        {
            public int startIndex;
            public int endIndex;
            public int totalSum;
        }

        static void Main(string[] args)
        {
            //int[] priceArray = { 10, 200, -10, 50, 45, 110, 85, 105, 102, 86, 63, 81, 101, 94, 106, 101, 79, 94, 90, 97 };
            //int[] priceArray = { 100, 110, 85, 105, 102, 86, 63, 81, 101, 94, 106, 101, 79, 94, 90, 97 };
            int[] priceArray = { 1, 2, 3, 4, -2, 2, 4, 6, 8, 6, 4, 2, 3, 4, 5, 6 };
            //int[] priceArray = { 1, 2, 1 };

            foreach (var item in priceArray)
            {
                Console.Write(item + "  ");
            }
            Console.WriteLine();

            int[] pFArr = new int[priceArray.Length - 1];
            for (int i = 1; i < priceArray.Length; i++)
            {
                int fluc = priceArray[i] - priceArray[i - 1];
                pFArr[i - 1] = fluc;
            }
            foreach (var item in pFArr)
            {
                Console.Write(item + "   ");
            }

            //SubArrResult result = GetMaxSubArr(0, pFArr.Length, pFArr);        
            SubArrResult result = RecursiveMerge(0, pFArr.Length, pFArr);

            Console.WriteLine();
            Console.WriteLine("在第" + result.startIndex + "天买入，在第" + result.endIndex + "天卖出，总收入：" + result.totalSum);

            Console.ReadKey();

        }

        /// <summary>
        /// 
        /// 算法复杂度O(n)
        /// </summary>
        /// <param name="low"></param>
        /// <param name="high"></param>
        /// <param name="array"></param>
        /// <returns></returns>
        static SubArrResult GetMaxSubArr(int low, int high, int[] array)
        {
            SubArrResult result = new SubArrResult(); 

            int maxSum = -100000;
            int sum = 0;
            int start = low;
            int end = high;

            //如果前面加起来的和小于0，那么前面的抛弃即可。 
            //当前最大值和小于零时，丢弃；大于等于零时，不断累加；比较先前的最大值和当前和，当前和大时，更新最大子序列和值和索引；
            for (int i = low; i < high; i++)
            {
                if (sum < 0)
                {
                    //重置当前和
                    sum = array[i];
                    //设置新的起始点，结束点
                    start = i;
                    //end = i;
                }
                else
                {
                    sum += array[i];
                    end = i;
                }

                if (sum > maxSum)
                {
                    maxSum = sum;

                    result.totalSum = maxSum;
                    result.startIndex = start;
                    result.endIndex = end + 1;
                }
            }

            Console.WriteLine();
            Console.WriteLine(start +"===" + end);

            return result;

        }


        static SubArrResult MidArraySum(int low, int high, int[] array) 
        {
            SubArrResult result = new SubArrResult(); 

            int mid = (low + high) / 2;

            int sum= 0;
            int leftSum = 0;
            int rightSum = 0;

            //左半部分求和
            for (int i = 0; i <= mid; i++)
            {
                sum += array[i];
                if (leftSum <sum)
                {
                    leftSum = sum;
                    result.startIndex = i;
                }
            }

            sum = 0;

            //右半部分求和
            for (int i = mid +1; i < high; i++)
            {
                sum += array[i];
                if (rightSum < sum)
                {
                    rightSum = sum;
                    result.endIndex = i;
                }
            }

            result.totalSum = leftSum + rightSum;

            return result;
        }

        /// <summary>
        /// 
        /// O(nlogn) 
        /// </summary>
        /// <param name="low"></param>
        /// <param name="high"></param>
        /// <param name="array"></param>
        /// <returns></returns>
        static SubArrResult RecursiveMerge(int low, int high, int[] array) 
        {
            SubArrResult result = new SubArrResult();

            if (low == high)
            {
                result.startIndex = low;
                result.endIndex = high;
                result.totalSum = array[low];
            }

            int mid = (low + high) / 2;
            SubArrResult resultLeft = RecursiveMerge( low, mid,array);           //递归左半部分
            SubArrResult resultRight = RecursiveMerge(mid + 1, high,array);       //递归右半部分
            SubArrResult resultMid = MidArraySum(low, high, array);        //计算此层的和(并不是最大中间子序列，问题已经化解为三部分找最大部分)

            if (resultLeft.totalSum > resultRight.totalSum && resultLeft.totalSum > resultMid.totalSum)
            {     
                return resultLeft;
            }
            else if (resultRight.totalSum > resultLeft.totalSum && resultRight.totalSum > resultMid.totalSum)
            {
                return resultRight;
            }
            else
            {
                return resultMid;
            }

            //return result;

        }

    }
}
