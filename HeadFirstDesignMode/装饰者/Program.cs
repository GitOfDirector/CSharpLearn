using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 装饰者
{
    class Program
    {
        static void Main(string[] args)
        {
            Beverage beverage = new Espresso();
            Console.WriteLine(beverage.GetDescription() +"  " + beverage.Cost());

            Beverage beverage2 = new DarkRoast();
            Console.WriteLine(beverage2.GetDescription() + "  " + beverage2.Cost());
            beverage2 = new Mocha(beverage2);
            //beverage2 = new Mocha(beverage2);
            //beverage2 = new Whip(beverage2);
            Console.WriteLine(beverage2.GetDescription() + "  " + beverage2.Cost());

            Beverage beverage3 = new HourseBlend();
            beverage3 = new Soy(beverage3);
            beverage3 = new Mocha(beverage3);
            beverage3 = new Whip(beverage3);
            Console.WriteLine(beverage3.GetDescription() + "  " + beverage3.Cost());

            ParentA pa = new ChiildB();
            pa.HelloP();
            pa.WriteP();
            ChiildB cb = new ChiildB();
            //ChiildB cb = new ParentA();
            cb.HelloP();
            cb.WriteP();

            Console.ReadKey();
        }
    }

    class ParentA
    {
        public void HelloP()
        {
            Console.WriteLine("In Parent Hello---1");
        }

        public virtual void WriteP()
        {
            Console.WriteLine("In Parent Write---1");
        }
       
    }

    class ChiildB :ParentA
    {
        public new void HelloP()
        {
            Console.WriteLine("In Child Hello---2");
        }

        public override void WriteP()
        {
            Console.WriteLine("In Child Write---2");
        }

    }


}
