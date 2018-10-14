using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 活动选择问题_贪心算法_迭代解决
{
    class Program
    {
        static void Main(string[] args)
        {
            //活动开始时间
            int[] s = { 0, 1, 3, 0, 5, 3, 5, 6, 8, 8, 2, 12, 24 };
            //活动结束时间
            int[] f = { 0, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 24 };

            int startTime = 0;
            int endTime = 24;

            List<int> list = new List<int>();

            //因为默认已经按结束时间以非递减的方式进行了排序
            //所以第一个必定是全区间内结束时间最早的任务

            for (int number = 1; number <= 11; number++)
            {
                if (s[number] >= startTime && f[number] <= endTime)
                {
                    list.Add(number);
                    startTime = f[number];
                }
            }

            foreach (var item in list)
            {
                Console.Write(item + "   ");
            }

            Console.ReadKey();
        }
    }
}
