using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Service
{
    internal class CustomerService
    {
        static List<Customer> customerList;

        public CustomerService()
        {
            customerList = new List<Customer>();
            
        }


        public static bool CheckIfExiste(int customerID)
        {
            Customer? cust = findCustomer(customerID);
            if(cust != null)
                return true;
            return false;
        }
        public static bool CheckPassword(int customerID, string customerPass)
        {
            Customer? cust = findCustomer(customerID);
            if (cust != null && cust.Password == customerPass)
                return true;
            return false;
        }

        public static void CreateNewCustomer(Customer newCustomer)
        {
            customerList.Add(newCustomer);
        } 

        public Customer getCustomer(int idCustomer)
        {
            return customerList.FirstOrDefault(c => c.Id == idCustomer) ?? new Customer();
        }

        public static Customer? findCustomer(int customerID)
        {
            foreach (var customer in customerList)
            {
                if (customerID == customer.Id)
                {
                    return customer;
                }
            }
            return null;
        }

    }
}
