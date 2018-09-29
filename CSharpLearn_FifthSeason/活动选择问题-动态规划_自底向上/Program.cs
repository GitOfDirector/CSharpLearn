using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 活动选择问题_动态规划_自底向上
{
    /*
     * 有n个需要在同一天使用同一个教室的活动a1,a2,…,an，教室同一时刻只能由一个活动使用。每个活动ai都有一个开始时间si和结束时间fi 。
     * 一旦被选择后，活动ai就占据半开时间区间[si,fi)。如果[si,fi]和[sj,fj]互不重叠，ai和aj两个活动就可以被安排在这一天。
     * 该问题就是要安排这些活动使得尽量多的活动能不冲突的举行（最大兼容活动子集）。
     */

    class Program
    {
        static void Main(string[] args)
        {
            //添加起始、结束两组数据
            //即 [0, 0)  [24, 24)，使其能够包含整天的跨度

            //活动开始时间
            int[] s = { 0, 1, 3, 0, 5, 3, 5, 6, 8, 8, 2, 12, 24 };
            //活动结束时间
            int[] f = { 0, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 24 };

            int maxActNum = -1;
            int totalAct = s.Length;
            List<int> result = new List<int>();
            MyTestFun(s, f, totalAct, out result, ref maxActNum);
            Console.WriteLine("===" + result.Count);
            foreach (var item in result)
            {
                Console.Write(item + "   ");
            }
            Console.WriteLine();

            //常规数组：int[,] arr2 = new int[2, 3];
            //相当于建立了数组元素全是List<int>的二维数组
            List<int>[,] resultSiki = new List<int>[13, 13];

            //int row = resultSiki.GetLength(0);//获取第一维度的长度（行数）
            //int col = resultSiki.GetLength(1);//获取第二维度的长度（列数）

            for (int i = 0; i < 13; i++)
            {
                for (int j = 0; j < 13; j++)
                {
                    resultSiki[i, j] = new List<int>();
                }
            }

            for (int j = 0; j < 13; j++)
            {
                for (int i = 0; i < j - 1; i++)
                {
                    //s[i j] i结束之后 j开始之前的活动集合
                    //f[i] s[j] 这个时间区间内的所有活动
                    List<int> sij = new List<int>();

                    //为什么从1开始
                    for (int k = 1; k < s.Length - 1; k++)
                    {
                        //如果 第k个活动的开始时间大于第i个活动的结束时间
                        //并且 第k个活动的结束时间要小于第j个活动的开始时间
                        if (s[k] >= f[i] && f[k] <= s[j])
                        {
                            sij.Add(k);
                        }
                    }

                    if (sij.Count > 0)
                    {
                        List<int> tempList = new List<int>();
                        int maxCount = 0;
                        foreach (var num in sij)
                        {
                            /*
                             * 设c[i, j]为Sij中最大兼容子集中的活动数目，
                             *      当Sij为空集时，c[i, j]=0；
                             *      当Sij非空时，若ak在Sij的最大兼容子集中被使用，
                             *   则子问题Sik和Skj的最大兼容子集也被使用，故可得到c[i][j] = c[i, k]+c[k, j]+1
                             */


                            int count = resultSiki[i, num].Count + resultSiki[num, j].Count + 1;
                            if (maxCount < count)
                            {
                                maxCount = count;
                                tempList = resultSiki[i, num].Union<int>(resultSiki[num, j]).ToList();
                                tempList.Add(num);
                            }
                        }
                        resultSiki[i, j] = tempList;
                    }
                }
            }

            Console.WriteLine("===" +resultSiki[0, 12].Count);
            foreach (var item in resultSiki[0, 12])
            {
                Console.Write(item + "   ");
            }

            Console.ReadKey();

        }

        static void MyTestFun(int[] s, int[] f, int totalAct, out List<int> result, ref int maxActNum)
        {
            result = new List<int>();
            int nowCount = -1;

            for (int i = 0; i < s.Length; i++)
            {
                List<int> activities = new List<int>();
                int now = i;

                //如果剩余任务的数量小于当前最大任务数
                if (totalAct - nowCount <= nowCount)
                    break;

                activities.Add(now);
                nowCount = 1;

                //下一个开始的活动
                for (int j = i + 1; j < s.Length; j++)
                {
                    int nowActivityStart = s[now];
                    int nextActivityStart = s[j];
                    int nowActivityEnd = f[now];
                    int nextActivityEnd = f[j];

                    //如果下一个活动的开始时间不早于当前活动的结束时间
                    if (nextActivityStart >= nowActivityEnd)
                    {
                        activities.Add(j);
                        now = j;
                        nowCount = activities.Count;
                    }
                }

                //Console.WriteLine("+++ " + activities.Count);
                if (maxActNum < activities.Count)
                {
                    maxActNum = activities.Count;
                    result = activities;
                }

            }
        }

    }
}
