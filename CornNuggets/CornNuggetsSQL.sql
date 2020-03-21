/*create store table; has a unique name and location string
  naming convention is first four characters of state and 3 digit number*/
CREATE TABLE NuggetStores
(
    StoreID INT primary key identity(1,1),
    StoreName varchar(7) DEFAULT 'TEXA001' unique , 
    StoreLocation NVARCHAR(50)
);


--create product table; has a unique id, name, price, and inventory value showing how many in stock
CREATE TABLE Products
(
    ProductID INT primary key,
    ProductName NVARCHAR(50),
    Price money,
    Inventory INT
);

/*create customer table; has a unique id, first name and last name, preferred store name
  link to store name using foreign key*/
CREATE TABLE Customers
(
    CustomerID INT primary key identity(100000000, 1),
    FirstName NVARCHAR(50),
    LastName NVARCHAR(50),
    PreferredStore VARCHAR(8) FOREIGN KEY REFERENCES NuggetStores(StoreName)  
);


/*-create order table; has a unique order number, datetime stamp, store of origin, products in order,
   customer id
*/
CREATE TABLE Orders
(
    OrderID INT primary key identity(1000, 1),
    DateTimeStamp DATETIME,
    StoreID INT, --may need to link to store ID using foreign key
    CustomerID INT, --may need to link to customer ID using foreign key
    Total money
);


--insert into customer; set first name and last name of demo customer
INSERT INTO Customers values ('Derrell', 'Brown', 'SCAR001')


--insert into NuggetStores; names and location of all stores
INSERT INTO NuggetStores values ('TEXAS001', 'Arlington')
INSERT INTO NuggetStores values ('TEXAS002', 'Dallas')
INSERT INTO NuggetStores values ('TEXAS003', 'Houston')
INSERT INTO NuggetStores values ('TEXAS004', 'Arlington')
INSERT INTO NuggetStores values ('FLORI001', 'Miami')
INSERT INTO NuggetStores values ('FLORI002', 'Daytona Beach')
INSERT INTO NuggetStores values ('FLORI003', 'Jacksonville')
INSERT INTO NuggetStores values ('FLORI004', 'Tampa')
INSERT INTO NuggetStores values ('GEORG001', 'Augusta')
INSERT INTO NuggetStores values ('GEORG002', 'Atlanta')
INSERT INTO NuggetStores values ('GEORG003', 'Albany')
INSERT INTO NuggetStores values ('GEORG004', 'Hephzibah')
INSERT INTO NuggetStores values ('NEWYO001', 'Brooklyn')
INSERT INTO NuggetStores values ('UTAH0001', 'Salt Lake City')
INSERT INTO NuggetStores values ('CALIF001', 'Los Angelos')
INSERT INTO NuggetStores values ('CALIF002', 'San Francisco')
INSERT INTO NuggetStores values ('CALIF003', 'Sacramento')
INSERT INTO NuggetStores values ('SCARO001', 'Columbia')


--insert into product the inventory of items available for order
INSERT INTO Products values (111, 'Habenero', 4.0, 1000)
INSERT INTO Products values (112, 'Nacho', 4.5, 1000)
INSERT INTO Products values (113, 'Blue', 3.5, 1000)
INSERT INTO Products values (114, 'Tomato', 4.0, 1000)
INSERT INTO Products values (222, 'Salsa', 1.5, 1000)
INSERT INTO Products values (223, 'Avocado', Price, 1000)
INSERT INTO Products values (224, 'Onion', Price, 1000)
INSERT INTO Products values (225, 'Cheese', Price, 1000)
INSERT INTO Products values (333, 'Fizzy', Price, 1000)
INSERT INTO Products values (334, 'Tea', Price, 1000)
INSERT INTO Products values (335, 'Juice', Price, 1000)
INSERT INTO Products values (336, 'Smoothie', Price, 1000)


--create an order log table with products in a particular order; has an order id, product id, and quantity
CREATE TABLE OrderLog
(
    OrderID INT FOREIGN KEY REFERENCES Orders(OrderID), --link to the order in the orders as a foreign key
    ProductID INT FOREIGN KEY REFERENCES Products(ProductID), --link to a product in the table as a foreign key
    ProductQty INT
);

--select orders by store
SELECT *
FROM Orders
GROUP BY StoreID;


--select orders by customer
SELECT *
FROM Orders
GROUP BY CustomerID;


--select product where inventory less than desired amount. Alert for low inventory.
SELECT *
FROM Products
WHERE Inventory <= 10;

--select the customers by first name and last name; shows all customers by name
SELECT FirstName,LastName
FROM Customers;


--select order log by order id and grouped by product
SELECT *
FROM OrderLog
GROUP BY OrderID;
