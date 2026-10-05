### 1. Why is a 20-parameter constructor a problem?

A constructor with 20 parameters is hard to read and use. When creating an Invoice, it is difficult to understand what each value represents.

It is also easy to pass two values in the wrong order, especially when they have the same type, such as `decimal` or `string`. For example, `SubTotal` and `TaxAmount` are both `decimal`, so they can be passed in the wrong order without the compiler detecting the mistake.

If we add another optional property later, we may need to change the constructor and update many places where it is used. This makes the code harder to maintain.

### 2. Is the problem only the long constructor?

No. The deeper problem is that the class contains many loosely related properties.

For example, billing address, shipping address, order information, and payment information are different groups of data. Putting all of them directly in one class makes the class harder to understand and maintain.

It would be better to group related properties together. Then, a Builder can be used to make creating the Invoice clearer and easier.
