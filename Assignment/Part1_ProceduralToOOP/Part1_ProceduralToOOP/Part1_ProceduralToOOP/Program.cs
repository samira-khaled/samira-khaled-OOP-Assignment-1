namespace Part1_ProceduralToOOP
{
    public class Program
    {
        static void Main(string[] args)
        {

            List<Customer> customers = new List<Customer>
            {
                new Customer(1, "Mona Ali", "mona@example.com", "Cairo", true),
                new Customer(2, "Omar Hassan", "omar@example.com", "Alexandria", false),
                new Customer(3, "Sara Nabil", "sara@example.com", "Giza", false)
            };
            List<Product> products = new List<Product>
            {
                new Product(101, "USB Cable", 50.0, 100),
                new Product(102, "Wireless Mouse", 250.0, 40),
                new Product(103, "Mechanical Keyboard", 1200.0, 15),
                new Product(104, "Laptop Stand", 400.0, 25)
            };
            List<Order> orders = new List<Order>
            {
                new Order(1001, customers[0], new DateTime(2026, 9, 15), true, new List<OrderLine> { new OrderLine(2, products[0]), new OrderLine(1, products[1]) }),
                new Order(1002, customers[1], new DateTime(2026, 9, 15), false, new List<OrderLine> { new OrderLine(1, products[2]), new OrderLine(1, products[3]) }),
                new Order(1003, customers[2], new DateTime(2026, 9, 16), true, new List<OrderLine> { new OrderLine(5, products[0]) })
            };
            Console.WriteLine("Procedural Order System (no classes / no structs)\n");
            Console.WriteLine("Seed sample data, show a demo, then open the menu.\n");
            Console.WriteLine($"\n=== CUSTOMERS ({customers.Count}) ===");
            PrintAllCustomers(customers);
            Console.WriteLine($"\n=== PRODUCTS ({products.Count}) ===");
            PrintAllProducts(products);
            PrintOrder(orders);
            RunInteractiveMenu(customers, products, orders);
        }
            public static void PrintMenu()
            {
            Console.WriteLine("\n---------- MENU ----------");
            Console.WriteLine("1) Print customers");
            Console.WriteLine("2) Print products");
            Console.WriteLine("3) Print all orders");
            Console.WriteLine("4) Print one order by id");
            Console.WriteLine("5) Create order");
            Console.WriteLine("6) Add line to order");
            Console.WriteLine("7) Mark order paid");
            Console.WriteLine("8) Show paid sales total");
            Console.WriteLine("0) Exit");
            Console.Write("Choice: ");
            }

        public static void RunInteractiveMenu(
            List<Customer> customers,
            List<Product> products,
            List<Order> orders)
        {
            int choice = -1;

            while (choice != 0)
            {
                PrintMenu();
                choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                {
                    PrintAllCustomers(customers);
                }
                else if (choice == 2)
                {
                    PrintAllProducts(products);
                }
                else if (choice == 3)
                {
                    PrintOrder(orders);
                }
                else if (choice == 4)
                {
                    PrintOrderById(orders);
                }
                else if (choice == 5)
                {
                    Order order = CreateOrder(customers, orders);

                    if (order != null)
                    {
                        orders.Add(order);
                    }
                }
                else if (choice == 6)
                {
                    AddOrderLine(orders, products);
                }
                else if (choice == 7)
                {
                    MarkOrderAsPaid(orders);
                }
                else if (choice == 8)
                {
                    Console.WriteLine(
                        $"Paid sales total: {totalSalesPaidOnly(orders):F2}");
                }
                else if (choice == 0)
                {
                    Console.WriteLine("Bye.");
                }
                else
                {
                    Console.WriteLine("Unknown choice.");
                }
            }
        }
                    
        public static Order CreateOrder(List<Customer> customers, List<Order> orders)
        {
            Console.WriteLine("Enter order ID:");
            int orderId = int.Parse(Console.ReadLine());

            // Check if order ID already exists
            foreach (Order order in orders)
            {
                if (order.OrderId == orderId)
                {
                    Console.WriteLine("ERROR: order ID already exists.");
                    return null;
                }
            }

            Console.WriteLine("Enter customer ID:");
            int customerId = int.Parse(Console.ReadLine());

            // Find customer
            Customer customer = null;

            foreach (Customer c in customers)
            {
                if (c.CustomerId == customerId)
                {
                    customer = c;
                    break;
                }
            }

            if (customer == null)
            {
                Console.WriteLine("ERROR: customer not found.");
                return null;
            }

            Console.WriteLine("Enter order date (yyyy-MM-dd):");
            DateTime orderDate = DateTime.Parse(Console.ReadLine());

            // Create new order
            Order newOrder = new Order(
                orderId,
                customer,
                orderDate,
                false,
                new List<OrderLine>()
            );

            return newOrder;
        }
        public static void AddOrderLine(List<Order> orders, List<Product> products)
        {

            Console.WriteLine("Enter order ID:");
            int orderId = int.Parse(Console.ReadLine());
            Order order = null;

            foreach (Order o in orders)
            {
                if (o.OrderId == orderId)
                {
                    order = o;
                    break;
                }
            }

            if (order == null)
            {
                Console.WriteLine("ERROR: order not found.");
                return;
            }

            Console.WriteLine("Enter product ID:");
            int productId = int.Parse(Console.ReadLine());
            // Find product
            Product product = null;
            foreach (Product p in products)
            {
                if (p.ProductId == productId)
                {
                    product = p;
                }
            }
            if (product == null)
            {
                Console.WriteLine("ERROR: product not found.");
                return;
            }
            Console.WriteLine("Enter quantity:");
            int quantity = int.Parse(Console.ReadLine());
            // Create new order line
            OrderLine newOrderLine = new OrderLine(quantity, product);
            try
            {
                order.addLineToOrder(newOrderLine);
                Console.WriteLine("Order line added successfully.");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"ERROR: {ex.Message}");
            }
        }
        public static void MarkOrderAsPaid(List<Order> orders)
        {
            Console.WriteLine("Enter order ID:");
            int orderId = int.Parse(Console.ReadLine());
            Order order = null;
            foreach (Order o in orders)
            {
                if (o.OrderId == orderId)
                {
                    order = o;
                    break;
                }
            }
            if (order == null)
            {
                Console.WriteLine("ERROR: order not found.");
                return;
            }
            order.MarkAsPaid();
            Console.WriteLine("Order marked as paid.");

        }
        public static void PrintAllCustomers(List<Customer>customers)
        {
            foreach(Customer customer in customers)
            {
                Console.WriteLine(customer);
            }
        }
        public static void PrintAllProducts(List<Product> products)
        {
            foreach (Product product in products)
            {
                Console.WriteLine(product);
            }
        }
        public static double totalSalesPaidOnly(List<Order> orders)
        {
            double sum = 0.0;
            foreach (var o in orders)
            {
                if (o.OrderIsPaid)
                {
                    sum += o.CalculateTotal();
                }

            }
            return sum;
        }
        public static void PrintOrder(List<Order> orders)
        {
            foreach (Order order in orders)
            {
               Console.WriteLine($"\n=== ORDER #{order.OrderId} ===");
                Console.WriteLine(order);
            }
            Console.WriteLine($"Paid sales total: {totalSalesPaidOnly(orders):F2}");
        }
        public static void PrintOrderById(List<Order> orders)
        {
            Console.WriteLine("Enter Order Id:");
            int id = int.Parse(Console.ReadLine());

            foreach (var order in orders)
            {
                if (order.OrderId == id)
                {
                    Console.WriteLine(order);
                    return;
                }
            }

            Console.WriteLine("ERROR: order not found.");
        }
        public static void PrintPaidSalesTotal(List<Order> orders)
        {
            Console.WriteLine($"Paid sales total: {totalSalesPaidOnly(orders):F2}");
        }
    }
}
