using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Models
{
    internal class Emplyee : User
    {
        public static int idcount = 1;
        public Emplyee() {
            Id = idcount++;
        }

        public int Salary {  get; set; }
        public override Role access()
        {
            return Role.Emplyee;
        }

    }
}
