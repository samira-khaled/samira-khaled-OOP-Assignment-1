using System;
using System.Collections.Generic;
using System.Text;

namespace Part1_ProceduralToOOP
{
    public class Order
    {
        public int OrderId { get; set; }
        public Customer Customer { get; set; }
        public DateTime OrderDate { get; set; }
        public bool OrderIsPaid { get; set; }
        public List<OrderLine> OrderLines { get; set; }





        public Order(int id, Customer customer, DateTime orderDate, bool orderIsPaid, List<OrderLine> orderLines)
        {
            OrderId = id;
            Customer = customer;
            OrderDate = orderDate;
            OrderIsPaid = orderIsPaid;
            OrderLines = orderLines;
        }

        public double CalculateTotal()
        {
            double total = 0;
            foreach (var orderLine in OrderLines)
            {

                total += orderLine.Quantity * orderLine.Product.ProductPrice;
            }
            if (Customer.CustomerIsVip)
            {
                total *= 0.9; // Apply 10% discount for VIP customers
            }
            return total;
        }
        public void addLineToOrder(OrderLine orderLine)
        {
            if (OrderIsPaid)
            {
                throw new InvalidOperationException("Cannot add order lines to a paid order.");
            }

            if (orderLine.Quantity <= 0)
            {
                throw new InvalidOperationException("Quantity must be greater than zero.");
            }

            if (orderLine.Quantity > orderLine.Product.ProductStock)
            {
                throw new InvalidOperationException("Not enough stock for the product.");
            }

            if (OrderLines == null)
            {
                OrderLines = new List<OrderLine>();
            }

            orderLine.Product.ProductStock -= orderLine.Quantity;

            OrderLines.Add(orderLine);
        }
        public void MarkAsPaid()
        {
            if (OrderIsPaid)
            {
                throw new InvalidOperationException("Order is already marked as paid.");
            }

            if (OrderLines.Count == 0)
            {
                throw new InvalidOperationException("Cannot pay an empty order.");
            }

            OrderIsPaid = true;
        }

        public override string ToString()
        {
            string result =
                $"Order ID: {OrderId}, Customer: {Customer.CustomerName}, " +
                $"Date: {OrderDate:yyyy-MM-dd}, " +
                $"Paid: {(OrderIsPaid ? "yes" : "no")}\n";

            result += "Lines:\n";

            foreach (var line in OrderLines)
            {
                double lineTotal = line.Quantity * line.Product.ProductPrice;

                result += $"  - {line.Product.ProductName} " +
                          $"x{line.Quantity} " +
                          $"@{line.Product.ProductPrice:F2} " +
                          $"= {lineTotal:F2}\n";
            }

            result += $"Total: {CalculateTotal():F2}";

            return result;
        }
    }

}
