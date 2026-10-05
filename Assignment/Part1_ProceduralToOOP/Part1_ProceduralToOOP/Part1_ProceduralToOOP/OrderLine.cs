using System;
using System.Collections.Generic;
using System.Text;

namespace Part1_ProceduralToOOP
{
    public class OrderLine
    {
        public int Quantity { get; set; }
        public Product Product { get; set; }

        public OrderLine(int quantity, Product product)
        {
            Quantity = quantity;
            Product = product;
        }
        public override string ToString()
        {
            return $"Product: {Product.ProductName}, Quantity: {Quantity}, Price: {Product.ProductPrice:F2}";
        }
    }
}
