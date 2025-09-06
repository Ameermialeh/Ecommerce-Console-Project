using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Service
{
    internal class ProductService
    {
        List<Product> productList;
        public void AddProduct(Product newProduct)
        {
            productList.Add(newProduct);
        }

        public void Update(Product updProd)
        {
            productList = productList.Where(p => p.Id != updProd.Id).ToList();

            productList.Add(updProd);

        }

        public void Delete(int delID) 
        {
            productList = productList.Where(p => p.Id != delID).ToList();
        }

        public void Search(int productID) 
        { 
            foreach(var prod in productList)
            {
                if(prod.Id == productID)
                {
                    Console.WriteLine($"ID:{prod.Id}, Name: {prod.Name}, Quantity: {prod.Quantity}, Price: {prod.Price}\n");
                }
            }
        }
        
        public bool ChickIfExist(int idProduct)
        {
            return productList.Any(p => p.Id == idProduct && p.Quantity > 0);
        }

        public Product getProduct(int idProduct)
        {
            return productList.FirstOrDefault(p => p.Id == idProduct)!;
        }

        public void ViewAllProducts()
        {
            Console.WriteLine("All Products: \n");
            int index = 0;
            foreach (var prod in productList)
            {
                Console.WriteLine($"{++index}. ID:{prod.Id},Name: {prod.Name}, Quantity: {prod.Quantity}, Price: {prod.Price}");
            }
            Console.WriteLine("\n");
        }

        public ProductService()
        {
            productList = new List<Product>();
        }
    }
}
