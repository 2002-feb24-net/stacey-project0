--start over by dropping the tables and re-run the create and insert commands
drop table OrderLog;
drop table Orders;
drop table Products;
drop table Customers;
drop table NuggetStores;

/*create stores table; has a unique name and location string
  naming convention is first four characters of state and 3 digit number*/
drop table NuggetStores;
CREATE TABLE NuggetStores
(
    StoreID INT primary key identity(1,1),
    StoreName VARCHAR(7) NOT NULL DEFAULT 'TEXA001', 
    StoreLocation NVARCHAR(50) default 'Arlington'
);


--create product table; has a unique id, name, price, and inventory value showing how many in stock
drop table Products;
CREATE TABLE Products
(
    ProductID INT primary key,
    ProductName NVARCHAR(50),
    ProductPrice money default 0.00,
    Inventory INT not null default 1000
);

/*create customer table; has a unique id, first name and last name, preferred store name
  link to store name using foreign key*/
drop table Customers;
CREATE TABLE Customers
(
    CustomerID INT primary key identity(100000000, 1),
    FirstName NVARCHAR(50),
    LastName NVARCHAR(50),
    PreferredStore VARCHAR(7) NOT NULL DEFAULT 'TEXA001'  
);



/*-create order table; has a unique order number, datetime stamp, store of origin, products in order,
   customer id
*/
drop table Orders;
CREATE TABLE Orders
(
    OrderID INT primary key identity(1000, 1),
    DateTimeStamp DATETIME default getdate(),
    StoreID INT Foreign Key References NuggetStores(StoreID), --may need to link to store ID using foreign key
    CustomerID INT Foreign Key References Customers(CustomerID), --may need to link to customer ID using foreign key
    Total money not null default 0.0
);

--create an order log table with products in a particular order; has an order id, product id, and quantity
drop table OrderLog;
CREATE TABLE OrderLog
(
    OrderID INT FOREIGN KEY REFERENCES Orders(OrderID), --link to the order in the orders as a foreign key
    ProductID INT FOREIGN KEY REFERENCES Products(ProductID), --link to a product in the table as a foreign key
    ProductQty INT default 1,
	SubTotal money not null default 0.0
);

--insert into customer; set first name and last name of demo customer
INSERT INTO Customers values ('Derrell', 'Brown', 'SCAR001');
INSERT INTO Customers values ('Stacey', 'Joseph', 'TEXA001');
INSERT INTO Customers values ('Eunique', 'Joseph', 'TEXA002');
INSERT INTO Customers values ('Euri', 'Joseph', 'TEXA002');
INSERT INTO Customers values ('Euriah', 'Joseph', 'TEXA002');
INSERT INTO Customers values ('Astrid', 'Ryan', 'SCAR001');


--insert into NuggetStores; names and location of all stores
INSERT INTO NuggetStores values ('TEXA001', 'Arlington');
INSERT INTO NuggetStores values ('TEXA002', 'Dallas');
INSERT INTO NuggetStores values ('TEXA003', 'Houston');
INSERT INTO NuggetStores values ('TEXA004', 'Arlington');
INSERT INTO NuggetStores values ('FLOR001', 'Miami');
INSERT INTO NuggetStores values ('FLOR002', 'Daytona Beach');
INSERT INTO NuggetStores values ('FLOR003', 'Jacksonville');
INSERT INTO NuggetStores values ('FLOR004', 'Tampa');
INSERT INTO NuggetStores values ('GEOR001', 'Augusta');
INSERT INTO NuggetStores values ('GEOR002', 'Atlanta');
INSERT INTO NuggetStores values ('GEOR003', 'Albany');
INSERT INTO NuggetStores values ('GEOR004', 'Hephzibah');
INSERT INTO NuggetStores values ('NYOR001', 'Brooklyn');
INSERT INTO NuggetStores values ('UTAH001', 'Salt Lake City');
INSERT INTO NuggetStores values ('CALI001', 'Los Angelos');
INSERT INTO NuggetStores values ('CALI002', 'San Francisco');
INSERT INTO NuggetStores values ('CALI003', 'Sacramento');
INSERT INTO NuggetStores values ('SCAR001', 'Columbia');


--insert into product the inventory of items available for order
INSERT INTO Products values (111, 'Habenero', 4.0, 1000);
INSERT INTO Products values (112, 'Nacho', 4.5, 1000);
INSERT INTO Products values (113, 'Blue', 3.5, 1000);
INSERT INTO Products values (114, 'Tomato', 4.0, 1000);
INSERT INTO Products values (222, 'Salsa', 1.5, 1000);
INSERT INTO Products values (223, 'Avocado', 2.0, 1000);
INSERT INTO Products values (224, 'Onion', 1.0, 1000);
INSERT INTO Products values (225, 'Cheese', 2.5, 1000);
INSERT INTO Products values (333, 'Fizzy', 1.5, 1000);
INSERT INTO Products values (334, 'Tea', 1.00, 1000);
INSERT INTO Products values (335, 'Juice', 1.75, 1000);
INSERT INTO Products values (336, 'Smoothie', 2.5, 5);



---------------------------------------------------------------------------------------
/*
--start an order for a customer at their peferred store, timestamped and order total
**may need to check if result is scalar (no duplicate first and last names)*/
insert into Orders (DateTimeStamp,CustomerID, StoreID, Total) 
values 
(
	GETDATE(), 
	(Select CustomerID 
	from Customers 
	where lastname = 'Joseph'
	and firstname = 'Stacey') ,
	(Select StoreID
	from NuggetStores
	where StoreName = 
		(Select PreferredStore
		from customers
		where lastname = 'Joseph'
		and firstname = 'Stacey')),
	(Select ProductPrice
	from Products
	where ProductID = 112)
);
--add initial order to the log
insert into OrderLog (OrderID, ProductID, SubTotal)
values((select max(orderID) from Orders where customerID = (Select CustomerID 
	from Customers 
	where lastname = 'Joseph'
	and firstname = 'Stacey')), 112,(Select ProductPrice from Products where ProductID = 112));
--show orders
select *
from Orders;
---------------------------------------------------------------------------------------------------
--update the order total by adding the next product for that order id and customer
update Orders
set Total = Total+(Select ProductPrice
	from Products
	where ProductID = 223)
where OrderID = (select max(orderID) from Orders where customerID = (Select CustomerID 
	from Customers 
	where lastname = 'Joseph'
	and firstname = 'Stacey'));

--show total with initial order and additional item
select *
from Orders;

--insert the order data into the orderlog for the next item
insert into OrderLog (OrderID, ProductID, SubTotal)
values((select max(orderID) from Orders where customerID = (Select CustomerID 
	from Customers 
	where lastname = 'Joseph'
	and firstname = 'Stacey')), 223,(Select ProductPrice from Products where ProductID = 223));
--show the order log
select *
from OrderLog;
-----------------------------------------------------------------------------------------------------

--Total all the orders in the log for a particular order id that is generated for a customer at their preferred Store
Select sum(SubTotal) from OrderLog where OrderID = (select max(orderID) from Orders where customerID = (Select CustomerID 
	from Customers 
	where lastname = 'Joseph'
	and firstname = 'Stacey'));

--------------------------------------------------------------------------------------------------------------------------------

insert into OrderLog (OrderID, ProductID, SubTotal)
values(1001, 222,(Select ProductPrice
	from Products
	where ProductID = 222));
insert into OrderLog (OrderID, ProductID, SubTotal)
values(1002, 333,(Select ProductPrice
	from Products
	where ProductID = 333));
insert into OrderLog (OrderID, ProductID, SubTotal)
values(1003, 333,(Select ProductPrice
	from Products
	where ProductID = 333));
--show all columns of the tables: stores, customers, orders, orderlog, and products in their respective tables
select *
from customers;

select * 
from nuggetstores;

select *
from products;

select *
from Orders;

select *
from OrderLog;

--show items in an order and their quantity
select productid, productqty
from OrderLog
where orderid = 1003;

--show customer id and preferred store
select customerID
from Customers
where firstname = 'Stacey'
and lastname = 'Joseph'



--select product where inventory less than desired amount. Alert for low inventory.
SELECT *
FROM Products
WHERE Inventory <= 10;

--get the customer id by first and last name
Select CustomerID
from Customers
where lastname = 'Stration'
and firstname = 'Demon';


--get the price of an item based on the product id
Select ProductPrice
from Products
where ProductID = 114;


--select the customers by first name and last name; shows all customers by name
SELECT FirstName,LastName
FROM Customers;


--get timestamp of the order
select Datetimestamp
from orders
where orderid = 1008;


---get the last order id created by a customer
select max(orderID)
from Orders
where customerID = 100000000;
--------------------------------------------------------------------------------------
--Left join of customers and orders
select *
from orders as o
left join customers as c
on o.customerID = c.customerID;

--join order log and orders
select *
from orderlog as ol
left join orders as o
on ol.orderID = o.orderID
order by o.orderid;

--------------------------------------------------------create a procedure--------------------------------------------------



--select orders by store
/*SELECT *
FROM Orders
GROUP BY StoreID;


--select orders by customer
SELECT *
FROM Orders
GROUP BY CustomerID;


--select order log by order id and grouped by product
SELECT *
FROM OrderLog
GROUP BY OrderID;

--change the Preferred store to conform to the naming convention
update Customers
set PreferredStore = 'TEXA002'
from customers
where LastName = 'Joseph';


--alter the table to make the column non-nullable
ALTER TABLE NuggetStores 
ALTER COLUMN StoreName VARCHAR(7) NOT NULL;
*/

