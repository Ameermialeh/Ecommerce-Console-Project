using Ecommerce.Models;
using Ecommerce.Service;
using Microsoft.Win32;


namespace Ecommerce
{
    internal class Program
    {
        public static void Menu()
        {
            Console.WriteLine("\n   Please choose a number\n");
            Console.WriteLine("1. Login as Customer");
            Console.WriteLine("2. Login as Employee");
            Console.WriteLine("3. Create new Customer account");
            Console.WriteLine("4. Exit");
        }
        public static void CustomerMenu()
        {
            Console.WriteLine("\n   Please choose a number\n");
            Console.WriteLine("1. Show all Products");
            Console.WriteLine("2. Search by ID for product");
            Console.WriteLine("3. Create new Order ");
            Console.WriteLine("4. Exit ");
        }
        public static void EmployeeMenu()
        {
            Console.WriteLine("\n   Please choose a number\n");
            Console.WriteLine("1. Show all Orders");
            Console.WriteLine("2. Create new Order for specific customer");
            Console.WriteLine("3. Show all Products");
            Console.WriteLine("4. Add new Product");
            Console.WriteLine("5. Delete Product");
            Console.WriteLine("6. Update Product");
            Console.WriteLine("7. Exit ");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Ameer e-commerce platform\n");
            CustomerService customerService = new CustomerService();
            ProductService productService = new ProductService();
            OrderService orderService = new OrderService();
            EmployeeService employeeService = new EmployeeService();

            while (true) {
                Menu();
                int choice = Convert.ToInt32(Console.ReadLine());
                if (choice == 1)
                {
                    Console.WriteLine("Enter Your Id:  ");
                    int customerID = Convert.ToInt32(Console.ReadLine());

                    if (CustomerService.CheckIfExiste(customerID)) //Check if customer existe
                    {
                        Console.WriteLine("Enter Your Password:  ");
                        string? customerPassword = Console.ReadLine();

                        if (customerPassword != null && CustomerService.CheckPassword(customerID, customerPassword)) // check password
                        {
                            Customer currentCustomer = customerService.getCustomer(customerID);
                            Console.WriteLine($"\nWelcome {currentCustomer.Name} ...\n");
                            

                            while (true)
                            {
                                CustomerMenu();
                                int num = Convert.ToInt32(Console.ReadLine());
                                if (num == 1)
                                {
                                    productService.ViewAllProducts();
                                }
                                else if (num == 2)
                                {
                                    Console.WriteLine("Enter ID product:  ");
                                    int id = Convert.ToInt32(Console.ReadLine());
                                    productService.Search(id);
                                }
                                else if (num == 3)
                                {
                                    
                                    Order order = new Order();
                                    Console.WriteLine("Enter the ID of products to buy:                press 0 if enough");
                                    while (true)
                                    {
                                        Console.WriteLine("Enter ID: ");
                                        int idProduct = Convert.ToInt32(Console.ReadLine());
                                        if(idProduct != 0)
                                        {
                                            if (productService.ChickIfExist(idProduct))
                                            {
                                                order.Products.Add(productService.getProduct(idProduct));
                                                Console.WriteLine($"{idProduct} added ");
                                            }
                                            else
                                            {
                                                Console.WriteLine($"{idProduct} not found Or out of stock");
                                            }
                                           
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                    order.Customer = currentCustomer;
                                    Console.WriteLine("Confirm the Order (y/n)?");
                                    char c = char.Parse(Console.ReadLine());
                                    if (c == 'y')
                                    {
                                        orderService.AddNewOrder(order);
                                        Console.WriteLine($"Your Order ID {order.Id} is confirmed");
                                    }
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Wrong Password!!");
                        }

                    }
                    else
                    {
                        Console.WriteLine("Customer account Does not Exist !!! Try another ID");
                    }
                    
                }
                else if (choice == 2) {
             
                    Console.WriteLine("Enter Your Id:  ");
                    int employeeID = Convert.ToInt32(Console.ReadLine());
                    if (EmployeeService.CheckIfExiste(employeeID))
                    {
                        Console.WriteLine("Enter Your Password:  ");
                        string? empPassword = Console.ReadLine();
                        if (empPassword != null && EmployeeService.CheckPassword(employeeID, empPassword))
                        {
                            Emplyee currentEmployee = employeeService.getEmployee(employeeID);
                            Console.WriteLine($"\nWelcome {currentEmployee.Name} ...\n");

                            while (true)
                            {
                                EmployeeMenu();
                                int number = Convert.ToInt32(Console.ReadLine());
                                if (number == 1)
                                {
                                    orderService.ViewAllOrders();
                                }
                                else if (number == 2)
                                {
                                    Order spOrder = new Order();
                                    Console.WriteLine("Enter Customer ID :");
                                    int custID = Convert.ToInt32(Console.ReadLine());
                                    spOrder.Customer = customerService.getCustomer(custID);

                                    Console.WriteLine("Enter the ID of products to add:                press 0 if enough");
                                    while (true)
                                    {
                                        Console.WriteLine("Enter ID: ");
                                        int idProd = Convert.ToInt32(Console.ReadLine());
                                        if (idProd != 0)
                                        {
                                            if (productService.ChickIfExist(idProd))
                                            {
                                                spOrder.Products.Add(productService.getProduct(idProd));
                                                Console.WriteLine($"{idProd} added ");
                                            }
                                            else
                                            {
                                                Console.WriteLine($"{idProd} not found Or out of stock");
                                            }
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }

                                    Console.WriteLine("Confirm the Order (y/n)?");
                                    char c = char.Parse(Console.ReadLine());
                                    if (c == 'y')
                                    {
                                        orderService.AddNewOrder(spOrder);
                                        Console.WriteLine($"Your Order ID {spOrder.Id} is confirmed");
                                    }
                                }
                                else if (number == 3)
                                {
                                    productService.ViewAllProducts();
                                }
                                else if (number == 4)
                                {

                                    string? prodName;
                                    int prodQuantity;
                                    int prodPrice;

                                    Console.WriteLine("Enter Product Name: ");
                                    prodName = Console.ReadLine();

                                    Console.WriteLine("Enter Product Quantity: ");
                                    prodQuantity = Convert.ToInt32(Console.ReadLine());

                                    Console.WriteLine("Enter Product Price: ");
                                    prodPrice = Convert.ToInt32(Console.ReadLine());

                                    Product newProduct = new Product(prodName!, prodPrice, prodQuantity);

                                    productService.AddProduct(newProduct);
                                }
                                else if (number == 5) //Delete
                                {
                                    Console.WriteLine("Enter Product ID you want to delete");
                                    int delID = Convert.ToInt32(Console.ReadLine());

                                    productService.Delete(delID);
                                    Console.WriteLine($"Product with ID : {delID} deleted successfully");
                                }
                                else if (number == 6) //Update
                                {
                                    string newName;
                                    int newPrice;
                                    int newQuantity;
                                    char c;
                                    Console.WriteLine("Enter Product ID you want to update");
                                    int updID = Convert.ToInt32(Console.ReadLine());

                                    Product product = productService.getProduct(updID);
                                    Console.WriteLine($"Old Data for product {product.Id}: \n");
                                    Console.WriteLine($"Old name: {product.Name}");
                                    Console.WriteLine($"Old price: {product.Price}");
                                    Console.WriteLine($"Old Quantity: {product.Quantity}");
                                    Console.WriteLine("---------------------------------\n");

                                    Console.WriteLine("Want to update name? (y/n)");
                                    c = char.Parse(Console.ReadLine());
                                    if (c == 'y')
                                    {
                                        Console.WriteLine("Enter new Name: ");
                                        newName = Console.ReadLine();
                                        product.Name = newName;
                                    }
                                    Console.WriteLine("Want to update Price? (y/n)");
                                    c = char.Parse(Console.ReadLine());
                                    if (c == 'y')
                                    {
                                        Console.WriteLine("Enter new Price: ");
                                        newPrice = Convert.ToInt32(Console.ReadLine());
                                        product.Price = newPrice;
                                    }

                                    Console.WriteLine("Want to update Quantity? (y/n)");
                                    c = char.Parse(Console.ReadLine());
                                    if (c == 'y')
                                    {
                                        Console.WriteLine("Enter new Quantity: ");
                                        newQuantity = Convert.ToInt32(Console.ReadLine());
                                        product.Quantity = newQuantity;
                                    }

                                    productService.Update(product);
                                    Console.WriteLine("Updated Product successfully");
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }


                    }

                }
                else if (choice == 3)
                {
                    Customer newCustomer = new Customer();
                    string? name;
                    string? email;
                    string? password;
                    DateTime date;
                    while (true)
                    {
                        Console.WriteLine("Enter Your Name:                 (Enter Q to exit)");
                        name = Console.ReadLine();
                        if (name != null && name != "Q")
                        {
                            newCustomer.Name = name;
                            break;
                        }else if(name != null && name == "Q")
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("The name field is empty Try again!!! ");
                        }
                    }
                    while (true)
                    {
                        Console.WriteLine("Enter Your Email:              (Enter Q to exit)");
                        email = Console.ReadLine();
                        if (email != null && email != "Q")
                        {
                            newCustomer.Email = email;
                            break;
                        }else if(email != null && email == "Q")
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("The email field is empty  Try again");
                       
                        }
                    }

                    Console.WriteLine("Enter Your Date (yyyy-MM-dd) :               -optionaly-");
                    string? input = Console.ReadLine();
                    if (input != "")
                    {
                        date = DateTime.ParseExact(input, "yyyy-MM-dd", null);
                        newCustomer.date = date;
                    }

                    while (true)
                    {
                        Console.WriteLine("Enter Password :");
                        password = Console.ReadLine();
                        if (password != null)
                        {
                            newCustomer.Password = password;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("The password field is empty  Try again");
                        }
                    }

                    newCustomer.CreateAt = DateTime.Now;
                    newCustomer.Type = CustomerType.Normal;

                    CustomerService.CreateNewCustomer(newCustomer);
                    Console.WriteLine("\nCreated new Customer Done");
                    Console.WriteLine($"Welcome {name} and your ID is {newCustomer.Id}, Try to Login\n");
                }
                else
                {
                    System.Environment.Exit(1);
                }
              
                
            }

        }
    }
}
