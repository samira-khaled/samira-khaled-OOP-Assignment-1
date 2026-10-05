using System;

namespace Part3_BuilderPattern
{
    public class InvoiceBuilder
    {
        // Mandatory data
        private int _invoiceId;
        private string? _customerName;
        private string? _customerEmail;

        private string? _billingStreet;
        private string? _billingCity;

        private string? _shippingStreet;
        private string? _shippingCity;

        private DateTime? _orderDate;
        private string? _paymentMethod;
        private string? _currency;
        private decimal? _subTotal;

        // Optional data
        private string? _customerPhone;

        private string? _billingState;
        private string? _billingZipCode;
        private string? _billingCountry;

        private string? _shippingState;
        private string? _shippingZipCode;
        private string? _shippingCountry;

        private decimal _discountAmount;
        private decimal _taxAmount;


        // Customer
        public InvoiceBuilder SetCustomer(int invoiceId,string customerName,string customerEmail)
        {
            _invoiceId = invoiceId;
            _customerName = customerName;
            _customerEmail = customerEmail;

            return this;
        }


        // Billing Address
        public InvoiceBuilder SetBillingAddress(string street,string city)
        {
            _billingStreet = street;
            _billingCity = city;

            return this;
        }


        // Shipping Address
        public InvoiceBuilder SetShippingAddress(string street,string city)
        {
            _shippingStreet = street;
            _shippingCity = city;

            return this;
        }


        // Order Details
        public InvoiceBuilder SetOrderDetails(DateTime orderDate,string paymentMethod,string currency,decimal subTotal)
        {
            _orderDate = orderDate;
            _paymentMethod = paymentMethod;
            _currency = currency;
            _subTotal = subTotal;

            return this;
        }


        // Optional Customer Phone
        public InvoiceBuilder SetCustomerPhone(string phone)
        {
            _customerPhone = phone;

            return this;
        }


        // Optional Billing Details
        public InvoiceBuilder SetBillingDetails(string? state = null,string? zipCode = null,string? country = null)
        {
            _billingState = state;
            _billingZipCode = zipCode;
            _billingCountry = country;

            return this;
        }


        // Optional Shipping Details
        public InvoiceBuilder SetShippingDetails(string? state = null,string? zipCode = null,string? country = null)
        {
            _shippingState = state;
            _shippingZipCode = zipCode;
            _shippingCountry = country;

            return this;
        }


        // Optional Discount
        public InvoiceBuilder SetDiscount(decimal discount)
        {
            if (discount < 0)
                throw new ArgumentException(
                    "Discount cannot be negative.");

            _discountAmount = discount;

            return this;
        }


        // Optional Tax
        public InvoiceBuilder SetTax(decimal tax)
        {
            if (tax < 0)
                throw new ArgumentException(
                    "Tax cannot be negative.");

            _taxAmount = tax;

            return this;
        }


        // Build
        public Invoice Build()
        {
            if (string.IsNullOrWhiteSpace(_customerName))
                throw new InvalidOperationException(
                    "Customer name is required.");

            if (string.IsNullOrWhiteSpace(_customerEmail))
                throw new InvalidOperationException(
                    "Customer email is required.");

            if (string.IsNullOrWhiteSpace(_billingStreet) ||
                string.IsNullOrWhiteSpace(_billingCity))
                throw new InvalidOperationException(
                    "Billing address is required.");

            if (string.IsNullOrWhiteSpace(_shippingStreet) ||
                string.IsNullOrWhiteSpace(_shippingCity))
                throw new InvalidOperationException(
                    "Shipping address is required.");

            if (_orderDate == null)
                throw new InvalidOperationException(
                    "Order date is required.");

            if (string.IsNullOrWhiteSpace(_paymentMethod))
                throw new InvalidOperationException(
                    "Payment method is required.");

            if (string.IsNullOrWhiteSpace(_currency))
                throw new InvalidOperationException(
                    "Currency is required.");

            if (_subTotal == null)
                throw new InvalidOperationException(
                    "Subtotal is required.");

            if (_subTotal < 0)
                throw new ArgumentException(
                    "Subtotal cannot be negative.");

            decimal totalAmount =
                _subTotal.Value - _discountAmount + _taxAmount;

            return new Invoice(_invoiceId,_customerName, _customerEmail,_customerPhone, _billingStreet,
                _billingCity, _billingState, _billingZipCode, _billingCountry,

                _shippingStreet,_shippingCity,_shippingState,_shippingZipCode,_shippingCountry,

                _orderDate.Value,_paymentMethod,_currency,

                _subTotal.Value,_discountAmount,_taxAmount, totalAmount);
        }
    }
}