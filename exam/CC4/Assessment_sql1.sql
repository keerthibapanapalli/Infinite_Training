create database TechMart
use TechMart

create table Customers11( 
    CustID INT PRIMARY KEY, 
    CustName VARCHAR(100), 
    Email VARCHAR(200), 
    City VARCHAR(100) 
)

create table Products( 
    ProductID INT PRIMARY KEY, 
    ProductName VARCHAR(100), 
    Price DECIMAL(10,2), 
    Stock INT CHECK(Stock >= 0) 
)

create table Orders22( 
    OrderID INT PRIMARY KEY, 
    CustID INT FOREIGN KEY REFERENCES Customers11(CustID), 
    OrderDate DATE, 
    Statuss VARCHAR(20) 
) 

create table OrderDetails11( 
    DetailID INT PRIMARY KEY, 
    OrderID INT FOREIGN KEY REFERENCES Orders22(OrderID), 
    ProductID INT FOREIGN KEY REFERENCES Products(ProductID), 
    Qty INT CHECK(Qty > 0) 
) 

create table Payments( 
    PaymentID INT PRIMARY KEY, 
    OrderID INT FOREIGN KEY REFERENCES Orders22(OrderID), 
    Amount DECIMAL(10,2), 
    PaymentDate DATE 
) 

INSERT INTO Customers11 (CustID, CustName, Email, City) VALUES
(1, 'Amit Sharma', 'amit.sharma@gmail.com', 'Mumbai'),
(2, 'Ravi Kumar', 'ravi.kumar@yahoo.com', 'Delhi'),
(3, 'Priya Singh', 'priya.singh@gmail.com', 'Pune'),
(4, 'John Mathew', 'john.mathew@hotmail.com', 'Bangalore'),
(5, 'Sara Thomas', 'sara.thomas@gmail.com', 'Kochi'),
(6, 'Nidhi Jain', 'nidhi.jain@gmail.com', NULL);
 
 select * from customers11
 
INSERT INTO Products (ProductID, ProductName, Price, Stock) VALUES
(101, 'Laptop Pro 14', 75000, 15),
(102, 'Laptop Air 13', 55000, 8),
(103, 'Wireless Mouse', 800, 50),
(104, 'Mechanical Keyboard', 3000, 20),
(105, 'USB-C Charger', 1200, 5),
(106, '27-inch Monitor', 18000, 10),
(107, 'Pen Drive 64GB', 600, 80);
 
 
 
INSERT INTO Orders22 (OrderID, CustID, OrderDate, Statuss) VALUES
(5001, 1, '2025-01-05', 'Pending'),
(5002, 2, '2025-01-10', 'Completed'),
(5003, 1, '2025-01-20', 'Completed'),
(5004, 3, '2025-02-01', 'Pending'),
(5005, 4, '2025-02-15', 'Completed'),
(5006, 5, '2025-02-18', 'Pending');
 
 select * from Orders22
 
INSERT INTO OrderDetails11 (DetailID, OrderID, ProductID, Qty) VALUES
(9001, 5001, 101, 1),
(9002, 5001, 103, 2),
 
(9003, 5002, 104, 1),
(9004, 5002, 103, 1),
 
(9005, 5003, 102, 1),
(9006, 5003, 105, 1),
(9007, 5003, 103, 3),
 
(9008, 5004, 106, 1),
 
(9009, 5005, 107, 4),
(9010, 5005, 104, 1),
 
(9011, 5006, 101, 1),
(9012, 5006, 107, 2);
 
 select * from OrderDetails11
 
INSERT INTO Payments (PaymentID, OrderID, Amount, PaymentDate) VALUES
(7001, 5002, 3300, '2025-01-11'),
(7002, 5003, 62000, '2025-01-22'),
(7003, 5005, 4500, '2025-02-16');

select * from Payments
--1--
select c.custname, c.City from Customers11 c join Orders22 o on c.custid = o.custid
where o.orderdate >= dateadd(day, -30, getdate())

--2--
select top 3 p.productname, sum(od.qty * p.price) as totalsales
from orderdetails11 od join products p on od.productid = p.productid
group by p.productname order by totalsales desc

--3--
select c.City, count(distinct c.custid) as customer_count, count(o.orderid) as order_count
from Customers11 c left join Orders22 o on c.custid = o.custid group by c.City

--4--
select c.City, count(distinct c.custid) as customer_count, count(o.orderid) as order_count
from Customers11 c left join Orders22 o on c.custid = o.custid group by c.City
 
--5--
select od.orderid, sum(od.qty * p.price) as total_amount
from OrderDetails11 od join products p on od.productid = p.productid
group by od.orderid having sum(od.qty * p.price) > 10000

--6--
select c.custname, p.productname from Customers11 c join Orders22 o on c.custid = o.custid
join OrderDetails11 od on o.orderid = od.orderid join products p on od.productid = p.productid
group by c.custname, p.productname having count(*) > 1

--7--
select * from Customers11

select e.CustID, e.CustName, count(o.orderid) as total_orders from Customers11 e 
join Orders22 o on e.CustID = o.CustID group by e.CustID, e.CustName

--views--
create view vw_LowStockProducts with schemabinding,encryption as select productid,
productname, stock from dbo.products where stock < 5

--functions----------------------------------------------------------------------
--1--
create function ffn_GetCustomerOrderHistory(@CustID int) returns table as return
(select o.orderid, o.orderdate, sum(od.qty * p.price) as totalamount
from Orders22 o join OrderDetails11 od on o.orderid = od.orderid join products p on
od.productid = p.productid where o.custid = @custid group by o.orderid, o.orderdate)

--2--
create function fn_GetCustomerLevel(@CustID int) 
returns varchar(20) as 
begin
declare @totalpurchase decimal(10,2)
select @totalpurchase = sum(od.Qty * p.Price) from Orders22 o join OrderDetails11 od on o.orderid = od.orderid
join Products p on od.ProductID = p.ProductID where o.CustID = @CustID
if @totalpurchase > 100000 return 'platinum'
else if @totalpurchase between 50000 and 100000 return 'gold'
else return 'silver'
end

--procedures---------------------------------------------------------------------------------------------------------
--1--
create table pricehistory (
productid int,
oldprice decimal(10,2),
changedate datetime default getdate()
)

create procedure sp_updateproductprices
@productid int,
@newprice decimal(10,2)
as
begin
if @newprice <= 0
begin
throw 50001,'invalid price', 1
end
declare @oldprice decimal(10,2)
select @oldprice = price from Products where ProductID = @productid;
insert into pricehistory(productid, oldprice, changedate) 
values(@productid, @oldprice,getdate())
update Products set Price = @newprice where ProductID = @productid
end

--2--
create procedure sp_SearchOrders 
@custname varchar(100),
@city varchar(100),
@productname varchar(100),
@startdate date,
@enddate date
as
begin
select o.OrderID, c.CustName, c.City, o.OrderDate, p.ProductName from Orders22 o join
Customers11 c on o.CustID = c.custid join OrderDetails11 od on o.orderid = od.orderid
join products p on od.productid = p.productid where o.orderid = 5003
end

--triggers----------------------------------------------------------------------------
--1--
create trigger trg_preventdeletion
on Products instead of delete as
begin
if exists(select 1 from OrderDetails11 where ProductID in (select ProductID from deleted))
begin
raiserror('cannot delete product linked to orders', 16, 1)
rollback
end
else
begin
delete from Products where ProductID in (select ProductID from deleted)
end
end

--2--
create table paymentaudit1 (
orderid int,
oldamount decimal(10,2),
newamount decimal(10,2),
changedate datetime not null default getdate()
)

create trigger paymentaudits on payments
after update as
begin
insert into paymentaudit1(orderid, oldamount, newamount, changedate)
select d.orderid, d.amount, i.amount, getdate()
from deleted d join inserted i on d.paymentid = i.paymentid;
end

--3--

alter table dbo.Customers11
add status varchar(20) default 'active';

create trigger deletecustomer
on Customers11 
instead of delete as
begin
if exists(select 1 from Orders22 where CustID in (select CustID from deleted))
begin
update Customers11 set status = 'inactive' where custid in (select custid from deleted);
end
else
begin
delete from Customers11 where CustID in (select CustID from deleted);
end
end









