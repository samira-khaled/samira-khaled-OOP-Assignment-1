using System;
using System.Collections.Generic;
using System.Text;

namespace Part1_ProceduralToOOP
{
    public class Customer
    {

        public int CustomerId { get; set; }
        public string CustomerName { get ; set; }
        public string CustomerEmail { get; set ; }
        public string CustomerCity { get ; set ; }
        public bool CustomerIsVip { get; set ; }



        public Customer(int id, string name, string email, string city, bool isVip)
        {
            CustomerId = id;
            CustomerName = name;
            CustomerEmail = email;
            CustomerCity = city;
            CustomerIsVip = isVip;
        }
        public override string ToString()
        {
            return $"#{CustomerId}  {CustomerName}  <{CustomerEmail}>  {CustomerCity}  vip={(CustomerIsVip ? "yes" : "no")}";
        }
    }
}
