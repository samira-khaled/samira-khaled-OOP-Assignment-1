using Part3_BuilderPattern;

namespace REDACTED_PROJECT_NAME
{
    public class Program
    {
        static void Main(string[] args)
        {

            var billingAddress = new AddressBuilder("12 Nile Street", "Cairo")
                .SetState("Cairo")
                .SetZipCode("11511")
                .SetCountry("Egypt")
                .Build();

            var shippingAddress = new AddressBuilder("456 Oak Ave", "Giza")
                .SetState("Giza")
                .SetZipCode("12511")
                .SetCountry("Egypt")
                .Build();

            var order = new OrderBuilder(
                    DateTime.Now,
                    "Credit Card",
                    "EGP",
                    5000)
                .SetDiscount(500)
                .SetTax(200)
                .Build();

            var invoice = new InvoiceBuilder(
                    1001,
                    "Mona Ahmed",
                    "mona@example.com")
                .SetCustomerPhone("01012345678")
                .SetBillingAddress(billingAddress)
                .SetShippingAddress(shippingAddress)
                .SetOrder(order)
                .Build();

            Console.WriteLine("===== Invoice =====");
            Console.WriteLine($"Invoice ID: {invoice.InvoiceId}");
            Console.WriteLine($"Customer: {invoice.CustomerName}");
            Console.WriteLine($"Email: {invoice.CustomerEmail}");
            Console.WriteLine($"Phone: {invoice.CustomerPhone}");

            Console.WriteLine("\n--- Billing Address ---");
            Console.WriteLine($"Street: {invoice.BillingAddress.Street}");
            Console.WriteLine($"City: {invoice.BillingAddress.City}");
            Console.WriteLine($"State: {invoice.BillingAddress.State}");
            Console.WriteLine($"Zip Code: {invoice.BillingAddress.ZipCode}");
            Console.WriteLine($"Country: {invoice.BillingAddress.Country}");

            Console.WriteLine("\n--- Shipping Address ---");
            Console.WriteLine($"Street: {invoice.ShippingAddress.Street}");
            Console.WriteLine($"City: {invoice.ShippingAddress.City}");
            Console.WriteLine($"State: {invoice.ShippingAddress.State}");
            Console.WriteLine($"Zip Code: {invoice.ShippingAddress.ZipCode}");
            Console.WriteLine($"Country: {invoice.ShippingAddress.Country}");

            Console.WriteLine("\n--- Order ---");
            Console.WriteLine($"Order Date: {invoice.Order.OrderDate}");
            Console.WriteLine($"Payment Method: {invoice.Order.PaymentMethod}");
            Console.WriteLine($"Currency: {invoice.Order.Currency}");
            Console.WriteLine($"Subtotal: {invoice.Order.SubTotal}");
            Console.WriteLine($"Discount: {invoice.Order.DiscountAmount}");
            Console.WriteLine($"Tax: {invoice.Order.TaxAmount}");
            Console.WriteLine($"Total: {invoice.Order.TotalAmount}");
        }
        }
    }
