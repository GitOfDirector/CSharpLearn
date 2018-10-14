using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 装饰者
{
    class Mocha : CondimentDecorator
    {
        Beverage beverage;

        public Mocha(Beverage beverage)
        {
            Console.WriteLine("当前字符串：" +beverage.GetDescription());
            this.beverage = beverage;
        }

        public override string GetDescription()
        {
            Console.WriteLine("为什么。。。");
            return beverage.GetDescription() + ", Mocha";
        }

        public override double Cost()
        {
            return .20 + beverage.Cost();
        }
    }
}
