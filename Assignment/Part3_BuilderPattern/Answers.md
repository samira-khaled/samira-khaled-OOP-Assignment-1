# Part 3 — Builder Pattern

## 1. Why is a 20-parameter constructor a problem?

A constructor with 20 parameters is hard to read and use. When creating an Invoice, it is difficult to understand what each value represents.

It is also easy to pass two values in the wrong order, especially when they have the same type, such as `decimal` or `string`. For example, `SubTotal` and `TaxAmount` are both `decimal`, so they can be passed in the wrong order without the compiler detecting the mistake.

If we add another optional property later, we may need to change the constructor and update many places where it is used. This makes the code harder to maintain.

## 2. Is the problem only the long constructor?

No. The deeper problem is that the class contains many loosely related properties.

For example, billing address, shipping address, order information, and payment information are different groups of data. Putting all of them directly in one class makes the class harder to understand and maintain.

It would be better to group related properties together. Then, a Builder can be used to make creating the Invoice clearer and easier.

## 3. Why is the composed version better?

The composed version is better because it divides the big builder into smaller parts.

`AddressBuilder` is responsible only for creating an `Address`.

`OrderBuilder` is responsible only for creating an `Order`.

`InvoiceBuilder` combines the customer information, billing address, shipping address, and order to create the final `Invoice`.

### Single Responsibility

Each builder has one clear job.

* `AddressBuilder` handles address data.
* `OrderBuilder` handles order and payment data.
* `InvoiceBuilder` combines everything.

This makes the code easier to understand and maintain.

### Independent Validation

`AddressBuilder` can check the address by itself.

For example, it can make sure that Street and City are provided.

The `InvoiceBuilder` does not need to know how an address works.

The same idea applies to `OrderBuilder`.

### Reuse

We can use the same `AddressBuilder` for both billing and shipping addresses.

We do not need to create two different builders such as `BillingAddressBuilder` and `ShippingAddressBuilder`.

### Readability

The single big builder has many methods and handles many different types of data.

The composed version is easier to read because each part is created separately:

```csharp
var billingAddress = new AddressBuilder(...).Build();

var shippingAddress = new AddressBuilder(...).Build();

var order = new OrderBuilder(...).Build();

var invoice = new InvoiceBuilder(...)
    .SetBillingAddress(billingAddress)
    .SetShippingAddress(shippingAddress)
    .SetOrder(order)
    .Build();
```

This makes it clear what each part of the invoice contains.
