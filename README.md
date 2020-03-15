# stacey-project0
Store Implementation
Functionality:

1. add a new customer *done*
    main menu option "a" to add, then add option "m" for new customer. User enters customer name. feedback at console is "Added customer: [custName]" or "Customer already exists."

2. search customers by name *done*
    main menu selection "s" to search, then search option "c" for existing customer. User enters customer's name. Feedback at console  is "Found Customer: {name}" or  "No match found. Please add customer."

3. place orders to store locations for customers *done*
    main menu option "a" to add, then add option "n" for new order. Requests Customer name and store name before going into a loop to add items to order.

4. display all order history of a customer *in progress*

5. display details of an order *done*

6. display all order history of a store location *in progress*

7. input validation *in progress*
    Customer.AddCustomer(string custName) method -checks to see if customer exists before adding a new customer, alerts if the customer already exists with feedback at console: "Customer already exists!"

(optional: order history can be sorted by earliest, latest, cheapest, most expensive)
(optional: get a suggested order for a customer based on his order history)
(optional: display some statistics based on order history)

/* Note - after operation completes, it returns to UX: request next menu option "Enter the letter of your choice" currently allows any level option to be entered - main level: add-search-view, add level: order-customer-store, search level: customer-location-order, view level: orders-customers-locations
*/