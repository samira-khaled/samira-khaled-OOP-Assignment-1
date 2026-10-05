# Task 1.1 – Procedural Order System Critique

The original program works, but its design has several problems that make the system harder to maintain, test, and extend.

## 1. Global Mutable State

The program stores customers, products, and orders in global variables such as `customerCount`, `productCount`, `orderCount`, and the different data arrays.

Many functions directly depend on and modify this shared state.

This makes the program harder to understand because a function does not work only with its own inputs. Its behavior also depends on global data that can be changed from many places. It also makes testing harder because the global state must be prepared correctly before testing a function.

## 2. Parallel Arrays

Customer information is stored in separate arrays:

* `customerIds`
* `customerNames`
* `customerEmails`
* `customerCities`
* `customerIsVip`

The same approach is used for products and orders.

This is error-prone because all arrays must stay synchronized using the same index. If one value is inserted, removed, or updated incorrectly, information from different customers or products could become mismatched.

## 3. Index-Based Relationships

Orders store the customer using an index:

`orderCustomerIndexes`

Order lines also refer to products using indexes:

`lineProductIndexes`

This creates a fragile relationship between the data. If the position of an item changes, an index may refer to the wrong customer or product.

The code therefore depends heavily on the internal positions of elements in the arrays instead of representing the actual relationships between domain objects.

## 4. Data and Behavior Are Separated

The program stores the data in global arrays while separate functions operate on that data.

For example, order information is stored in several global arrays, while functions such as `markOrderPaid`, `printOrder`, and `totalSalesPaidOnly` operate on those arrays.

This makes it difficult to know which operations belong to an order and allows many parts of the program to directly manipulate the same data.

## 5. Weak Encapsulation

The program does not have objects responsible for protecting their own data and rules.

For example, the paid state of an order is stored in:

`orderIsPaid`

and can be changed directly by procedural code.

There is no object controlling how an order changes from unpaid to paid. As the system grows, this can allow invalid states or inconsistent changes.

## 6. Fixed-Size Arrays

The program uses fixed limits such as:

* `MAX_CUSTOMERS = 50`
* `MAX_PRODUCTS = 50`
* `MAX_ORDERS = 100`
* `MAX_LINES_PER_ORDER = 20`

This limits the system unnecessarily. When a limit is reached, the program cannot add more data even if more memory is available.

It also requires extra checks throughout the code to handle full arrays.

## 7. Order Lines Are Represented by Separate Arrays

An order line is conceptually a single piece of information: a product and its quantity.

However, the program stores these separately in:

`lineProductIndexes`

and

`lineQuantities`

This makes the relationship between the product and its quantity dependent on matching indexes.

It would be clearer to represent an order line as one object containing both pieces of information.

## 8. Functions Depend on Shared Implementation Details

Functions such as `printOrder`, `markOrderPaid`, and `totalSalesPaidOnly` need to understand how orders are internally stored across multiple arrays.

For example, `printOrder` must use an order index, then access the customer index, line count, product indexes, and quantities from different arrays.

This creates tight coupling between the functions and the storage implementation. Changing the way orders are stored would require changes in many functions.

## 9. Search Logic Is Repeated Throughout the Program

The program uses functions such as:

* `findCustomerIndexById`
* `findProductIndexById`
* `findOrderIndexById`

to search through the global arrays.

The rest of the program then works with the returned indexes.

This approach ties the business logic to the array-based storage design and makes the code more complicated than it needs to be.

## 10. Business Rules Are Mixed With Data Management

The program mixes different responsibilities in the same procedural functions.

For example, creating an order involves checking capacity, checking whether the ID already exists, finding the customer, and then manually filling several order arrays.

As more business rules are added, these functions can become larger and harder to maintain.

## Conclusion

The original program demonstrates the required order-management functionality, but its procedural design relies heavily on global state, parallel arrays, indexes, and functions that directly manipulate shared data.

These design choices make the system more difficult to maintain, test, and extend.

The next step is to redesign the same domain using objects such as `Customer`, `Product`, `Order`, and `OrderLine`, while preserving the original functionality.
