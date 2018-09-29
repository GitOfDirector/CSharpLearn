using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 活动选择问题_贪心算法_递归解决
{
    class Program
    {

        /*
         * 想要使用贪心算法的话，得先找到适合贪心算法的规律（局部最优选择）
	        
         * 对于活动选择问题：
              * 对于任何非空的活动集合S，假如am是S中结束时间最早的活动，则am一定在S的某个最大兼容活动子集中。
         */

        //活动开始时间
       static  int[] s = { 0, 1, 3, 0, 5, 3, 5, 6, 8, 8, 2, 12, 24 };
        //活动结束时间
       static int[] f = { 0, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 24 };

        static void Main(string[] args)
        {

            List<int> list = ActivitySelection(1, 11, 0, 24);
            foreach (var item in list)
            {
                Console.Write(item + "   ");
            }


            Console.ReadKey();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="startActivityNumber">活动开始编号</param>
        /// <param name="endActivityNumber">活动结束编号</param>
        /// <param name="startTime">活动最早起始时间</param>
        /// <param name="endTime">活动最晚结束时间</param>
        /// <returns></returns>
        public static List<int> ActivitySelection(int startActivityNumber, int endActivityNumber, int startTime, int endTime)
        {
            if (startActivityNumber > endActivityNumber ||
                startTime >= endTime)
            {
                return new List<int>();
            }

            //找到结束时间最早的活动
            int earliestActibityNum = -1;

            for (int number = startActivityNumber; number <= endActivityNumber; number++)
            {
                if (s[number] >= startTime && f[number] <= endTime)
                {
                    earliestActibityNum = number;
                    break;
                }
            }

           List<int> list =  ActivitySelection(earliestActibityNum + 1, endActivityNumber, f[earliestActibityNum], endTime);
           list.Add(earliestActibityNum);

           return list;
        }

    }
}
