using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Models
{
    internal class Order
    {
        public static int idcount = 0;
        public int Id { get; set; }

        public string Description { get; set; }

        public Customer Customer { get; set; }

        public DateTime CrateAt { get; set; }

        public DateTime UpdateAt { get; set; }

        public List<Product> Products { get; set; }
        // !!!!!!!

        public void getBill()
        {
            Console.WriteLine($"The bill for customer {Customer.Name}   : ");

            var discountType = DisCount.getdiscount(Customer.Type);
            int i = 0;
            double totalToPay = 0;

            foreach (var item in Products)
            {
                totalToPay += item.Price;
                Console.WriteLine($"{++i}. Product with name {item.Name} with Id {item.Id} with price {item.Price} ");
            }


            Console.WriteLine($"Total price : {totalToPay}");
            Console.WriteLine($"Your dicount : {discountType.getdiscount()}");
            Console.WriteLine($"Your final total after discount is : {totalToPay - totalToPay * discountType.getdiscount()}");

        }

        public Order(){
            Id = ++idcount;
            CrateAt = DateTime.Now;
        }
    }
}
