using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 钱币找零问题
{
    class Program
    {
        /*
         * 这个问题在我们的日常生活中就更加普遍了。假设1元、2元、5元、10元、20元、50元、100元的纸币
         * 分别有c0, c1, c2, c3, c4, c5, c6张。
         * 现在要用这些钱来支付K元，至少要用多少张纸币？
         * 用贪心算法的思想，很显然，每一步尽可能用面值大的纸币即可
         */

        static void Main(string[] args)
        {
            //对应钱币数量
            int[] count = { 3, 0, 2, 1, 0, 3, 5 };
            //钱币价值
            int[] value = { 1, 2, 5, 10, 20, 50, 100 };
            
            //当前总价值673

            int[] result = Change(680, count, value);

            foreach (var item in result)
            {
                Console.Write(item + "   ");
            }

            Console.ReadKey();
        }

        public static int[] Change(int k, int[] count, int[] amount)
        {
            if (k == 0)
                return new int[0];

            int index = amount.Length - 1;
            //最后一位存储剩余的钱
            //因为存在
            //          1   所有的钱也不够换的情况
            //          2   有零碎钱剩余，例如换4元，只有3个一元，一定会剩1元
            int[] result = new int[amount.Length + 1];

            while (true)
            {
                //如果当前金额小于等于0或者钱币种类为0
                if (k <= 0 || index < 0)
                    break;

                int values = count[index] * amount[index];
                if (k > values)
                {
                    result[index] = count[index];
                    k -= values;
                }
                else
                {
                    result[index] = k / amount[index];
                    k -= result[index] * amount[index];
                }

                index--;
            }

            result[amount.Length] = k;

            return result;
        }

    }
}
