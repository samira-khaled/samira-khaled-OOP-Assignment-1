using System;
using System.Collections.Generic;
using System.Text;

namespace Part3_BuilderPattern
{
    public class Order
    {
        public DateTime OrderDate { get; }
        public string PaymentMethod { get; }
        public string Currency { get; }

        public decimal SubTotal { get; }
        public decimal DiscountAmount { get; }
        public decimal TaxAmount { get; }
        public decimal TotalAmount { get; }

        public Order(DateTime orderDate,string paymentMethod,string currency,decimal subTotal,decimal discountAmount,decimal taxAmount)
        {
            OrderDate = orderDate;
            PaymentMethod = paymentMethod;
            Currency = currency;
            SubTotal = subTotal;
            DiscountAmount = discountAmount;
            TaxAmount = taxAmount;

            TotalAmount = subTotal - discountAmount + taxAmount;
        }
    }
    public class OrderBuilder
    {
        private DateTime _orderDate;
        private string _paymentMethod;
        private string _currency;
        private decimal _subTotal;
        private decimal _discountAmount;
        private decimal _taxAmount;
        public OrderBuilder(DateTime orderDate, string paymentMethod, string currency, decimal subTotal)
        {
            if (string.IsNullOrWhiteSpace(paymentMethod))
                throw new ArgumentException("Payment method is required.");

            if (string.IsNullOrWhiteSpace(currency))
                throw new ArgumentException("Currency is required.");

            if (subTotal < 0)
                throw new ArgumentException("Subtotal cannot be negative.");
            _orderDate = orderDate;
            _paymentMethod = paymentMethod;
            _currency = currency;
            _subTotal = subTotal;
        }
        public OrderBuilder SetDiscount(decimal discountAmount)
        {
            if (discountAmount < 0)
                throw new ArgumentException("Discount cannot be negative.");

            _discountAmount = discountAmount;
            return this;
        }

        public OrderBuilder SetTax(decimal taxAmount)
        {
            if (taxAmount < 0)
                throw new ArgumentException("Tax cannot be negative.");

            _taxAmount = taxAmount;
            return this;
        }
        public Order Build()
        {
            return new Order(_orderDate, _paymentMethod, _currency, _subTotal, _discountAmount, _taxAmount);
        }
    }
}
