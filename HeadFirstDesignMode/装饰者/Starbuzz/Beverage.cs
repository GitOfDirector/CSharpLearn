using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 装饰者
{
    public abstract class Beverage
    {
        protected string description = "Unknown Beverage";

        public string GetDescription()
        {
            return description;
        }

        public abstract double Cost();
    }
}
