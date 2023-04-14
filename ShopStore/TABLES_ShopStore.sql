
CREATE DATABASE dbMyOnlineShopping
go
use dbMyOnlineShopping
go


Create table Tbl_Category(
	CategoryId int IDENTITY PRIMARY KEY NOT NULL,
	CategoryName varchar(500) unique ,
	IsActive bit NULL,
	IsDelete bit NULL,
)


CREATE TABLE Tbl_Product(
	ProductId int IDENTITY PRIMARY KEY NOT NULL,
	ProductName varchar(500) unique,
	CategoryId int NULL,
	IsActive bit NULL,
	IsDelete bit NULL,
	CreatedDate datetime NULL,
	ModifiedDate datetime NULL,
	Description nvarchar(500) NULL,
	ProductImage varchar(max) NULL,
	IsFeatured bit NULL,
	Quantity int NULL,
	foreign key (CategoryId) references  Tbl_Category(CategoryId)
)

CREATE TABLE Tbl_CartStatus(
	CartStatusId int IDENTITY PRIMARY KEY NOT NULL,
	CartStatus varchar(500) NULL,
)


CREATE TABLE Tbl_Members(
	MemberId int IDENTITY PRIMARY KEY NOT NULL,
	FristName varchar(200) NULL,
	LastName varchar(200) NULL,
	EmailId varchar(200) unique,
	Password varchar(500) NULL,
	IsActive bit NULL,
	IsDelete bit NULL,
	CreatedOn datetime NULL,
	ModifiedOn datetime NULL,
)

CREATE TABLE Tbl_ShippingDetails(
	ShippingDetailId int IDENTITY PRIMARY KEY NOT NULL,
	MemberId int NULL,
	Adress varchar(500) NULL,
	City varchar(500) NULL,
	State varchar(500) NULL,
	Country varchar(50) NULL,
	ZipCode varchar(50) NULL,
	OrderId int NULL,
	AmountPaid decimal(18, 0) NULL,
	PaymentType varchar(50) NULL,
	foreign key (MemberId) references Tbl_Members(MemberId)
)


CREATE TABLE Tbl_Roles(
	RoleId int IDENTITY PRIMARY KEY NOT NULL,
	RoleName varchar(200) unique
)


CREATE TABLE Tbl_Cart(
	CartId int IDENTITY PRIMARY KEY NOT NULL,
	ProductId int NULL,
	MemberId int NULL,
	CartStatusId int NULL,
	foreign key (ProductId) references Tbl_Product(ProductId)
)


CREATE TABLE Tbl_MemberRole(
	MemberRoleID int IDENTITY PRIMARY KEY NOT NULL,
	memberId int NULL,
	RoleId int NULL,

)

CREATE TABLE Tbl_SlideImage (
	SlideId int IDENTITY PRIMARY KEY NOT NULL,
	SlideTitle varchar(500) NULL,
	SlideImage varchar(max) NULL
)



