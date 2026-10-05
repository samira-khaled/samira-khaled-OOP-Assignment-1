using Part3_BuilderPattern;

namespace REDACTED_PROJECT_NAME
{
    public class Program
    {
        static void Main(string[] args)
        {

            var invoice = new InvoiceBuilder()
              .SetCustomer(1001, "Mona Ahmed", "mona@example.com")
              .SetBillingAddress("12 Nile Street", "Cairo")
              .SetShippingAddress("25 Tahrir Street", "Giza")
              .SetOrderDetails(DateTime.Now,"Credit Card","EGP",5000)
              .SetCustomerPhone("01012345678")
              .SetDiscount(500)
              .SetTax(200)
              .Build();

            Console.WriteLine($"Customer: {invoice.CustomerName}");
            Console.WriteLine($"Subtotal: {invoice.SubTotal}");
            Console.WriteLine($"Discount: {invoice.DiscountAmount}");
            Console.WriteLine($"Tax: {invoice.TaxAmount}");
            Console.WriteLine($"Total: {invoice.TotalAmount}");
        }
        }
    }
