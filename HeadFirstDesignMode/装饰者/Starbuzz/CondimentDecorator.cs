using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 装饰者
{
    abstract  class CondimentDecorator : Beverage
    {
        public override abstract string GetDescription();
       
    }
}
