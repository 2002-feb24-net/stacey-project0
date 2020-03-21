# stacey-project0
Store Implementation
Functionality:

1. add a new customer *done*
    main menu option "a" to add, then add option "m" for new customer. User enters customer name. Feedback at console is "Added customer: [custName]" or "Customer already exists."

2. search customers by name *done*
    main menu selection "s" to search, then search option "c" for existing customer. User enters customer's name. Feedback at console  is "Found Customer: [name]" or  "No match found. Please add customer."

3. place orders to store locations for customers *done*
    main menu option "a" to add, then add option "n" for new order. Requests Customer name and store name before going into a loop to add items to order. Feedback at console is "Product [prodNum] purchased. Thank you!" loop allows additional items to be added to order. Order.TakeOrder returns the order number.

4. display all order history of a customer *in progress*

5. display details of an order *done*
    Order.DisplayOrder method called after taking order in the add option "n" for new order. OrderBanner is printed, as well as the order details: timeStamp, OrderNum, CustName, StoreName, and Total 

6. display all order history of a store location *in progress*

7. input validation *in progress*
    Customer.AddCustomer(string custName) method -checks to see if customer exists before adding a new customer, alerts if the customer already exists with feedback at console: "Customer already exists!"

8. exception handling
9. persistent data; no prices, customers, order history, etc. hardcoded in C# [new]
10. (optional: order history can be sorted by earliest, latest, cheapest, most expensive)
11. (optional: get a suggested order for a customer based on his order history)
12. (optional: display some statistics based on order history)
13. (optional: asynchronous network & file I/O) [new]
14. (optional: deserialize data from disk) [now optional]
15. (optional: serialize data to disk) [now optional]

/* Note - after operation completes, it returns to UX: request next menu option "Enter the letter of your choice" currently allows any level option to be entered - main level: add-search-view, add level: order-customer-store, search level: customer-location-order, view level: orders-customers-locations
*/
Update requirements as of 3/20/2020:


design:
use EF Core (either database-first approach or code-first approach) [new]
use an Azure SQL DB in third normal form [new]
don't use public fields
define and use at least one interface


core / domain / business logic:
class library
contains all business logic
contains domain classes (customer, order, store, product, etc.)
documentation with <summary> XML comments on all public types and members (optional: <params> and <return>)
(recommended: has no dependency on UI, data access, or any input/output considerations)


customer:
has first name, last name, etc.
(optional: has a default store location to order from)


order:
has a store location
has a customer
has an order time (when the order was placed)
can contain multiple kinds of product in the same order
rejects orders with unreasonably high product quantities
(optional: some additional business rules, like special deals)


location:
has an inventory
inventory decreases when orders are accepted
rejects orders that cannot be fulfilled with remaining inventory
(optional: for at least one product, more than one inventory item decrements when ordering that product)

product (etc.)

user interface:
interactive console application
has only display- and input-related code
low-priority component, will be replaced when we move to project 1


data access (recommended):
class library
recommended separate project for data access code using EF Core
contains data access logic but no business logic
use repository pattern for separation of concerns

test:
at least 10 test methods
focus on unit testing business logic; testing the console app is very low priority