using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Service
{
    internal class OrderService
    {
        List<Order> orderList = new List<Order>();
        public void CreateNewOrder(Order newOrder)
        {
            orderList.Add(newOrder);
        }



        public void AddNewOrder(Order order)
        {
            orderList.Add(order);
        }

        public void ViewAllOrders() { 
            foreach(var order in orderList)
            {
                Console.WriteLine($"Order ID : {order.Id}, Customer name : {order.Customer.Name}");
                int i = 0;
                foreach(var prod in order.Products)
                {
                    Console.WriteLine($"{++i}.ID: {prod.Id},Name: {prod.Name},Price: {prod.Price}");
                }
                Console.WriteLine("\n------------------------------\n");
            }
        }

        
    }
}
