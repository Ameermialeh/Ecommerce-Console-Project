using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce
{
    interface Idiscount
    {
        public  double getdiscount();
    }

    public class VipDiscount :Idiscount {
        public double getdiscount()
        {
            return 0.30;
        }
    }
    public class NormalDiscount : Idiscount
    {
        public double getdiscount()
        {
            return 0.20;
        }
    }
    internal class DisCount
    {
        public static Idiscount getdiscount(CustomerType customerType)
        {
            if (customerType == CustomerType.Normal)
                return new NormalDiscount();
            else
                return new VipDiscount();
        }
    }
}
