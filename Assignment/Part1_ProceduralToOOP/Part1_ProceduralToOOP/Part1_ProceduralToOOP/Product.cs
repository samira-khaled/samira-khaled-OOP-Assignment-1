using System;
using System.Collections.Generic;
using System.Text;

namespace Part1_ProceduralToOOP
{
    public class Product
    {
        public int  ProductId { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public int ProductStock { get; set; }
        public Product(int id, string name, double price, int stock)
        {
            ProductId = id;
            ProductName = name;
            ProductPrice = price;
            ProductStock = stock;
        }
        public override string ToString()
        {
            return $"#{ProductId}  {ProductName}  price={ProductPrice:F2}  stock={ProductStock}";
        }

    }
}
