GO
--drop table TaskStatus;
create table Category (
	CategoryId int primary key identity(1,1),
	CategoryName nvarchar(20) NOT NULL );


	GO
--drop table TaskStatus;
create table Supplier (
	SupplierId int primary key identity(1,1),
	SupplierName nvarchar(20) NOT NULL );


	GO
--drop table EmployeeTask;
create table Product (
	ProductId int primary key identity(1,1),
	ProductName nvarchar(20) NOT NULL,
	CategoryId int not null,
	SupplierId int not null,
	foreign key (CategoryId) references Category(CategoryId) on delete cascade,
	foreign key (SupplierId) references Supplier(SupplierId) on delete cascade,
	);