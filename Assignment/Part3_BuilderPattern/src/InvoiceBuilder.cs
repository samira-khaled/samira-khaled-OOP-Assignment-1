using System;

namespace Part3_BuilderPattern
{
    public class InvoiceBuilder
    {
        private int _invoiceId;
        private string _customerName;
        private string _customerEmail;
        private string? _customerPhone;
        private Address _billingAddress;
        private Address _shippingAddress;
        private Order _order;

        public InvoiceBuilder(int invoiceId, string customerName, string customerEmail)
        {
            _invoiceId = invoiceId;
            _customerName = customerName;
            _customerEmail = customerEmail;
        }

        public InvoiceBuilder SetCustomerPhone(string? customerPhone)
        {
            _customerPhone = customerPhone;
            return this;
        }

        public InvoiceBuilder SetBillingAddress(Address billingAddress)
        {
            _billingAddress = billingAddress;
            return this;
        }

        public InvoiceBuilder SetShippingAddress(Address shippingAddress)
        {
            _shippingAddress = shippingAddress;
            return this;
        }

        public InvoiceBuilder SetOrder(Order order)
        {
            _order = order;
            return this;
        }

        public Invoice Build()
        {
            if (_billingAddress == null)
                throw new InvalidOperationException("Billing address is required.");

            if (_shippingAddress == null)
                throw new InvalidOperationException("Shipping address is required.");

            if (_order == null)
                throw new InvalidOperationException("Order is required.");
            return new Invoice(_invoiceId, _customerName, _customerEmail, _customerPhone, _billingAddress, _shippingAddress, _order);
        }
    }
}       

       

