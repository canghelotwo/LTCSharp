create database VanDoanhDB
go
use VanDoanhDB
go
Create table UserAccount 
(
    ID varchar(50) PRIMARY KEY,
    UserName varchar(50) NULL,
    PassWord varchar(50) NULL,
    Status nvarchar(50) not null
)
go
Insert into UserAccount
Values('ND001','admin','21232f297a57a5a743894a0e4a801fc3',''),
	('ND002','Doanh','7e33ad856f9ff74645ad13796122fa89','BlOOKER'),
	('ND003','Doanh01','1e0c5a470355ff68969dfbf5df9399e6',''),
	('ND004','Doanh02','51fd603c5a7ff20c5fab4ee1fcb5f7f6',''),
	('ND005','Tien','83282093b1b7b349a507fbaf92ed1970','BlOOKER'),
	('ND006','Tuan','8f65900731b2dd9351ca5f08cf7735f2',''),
	('ND007','Nhan','8f65900731b2dd9351ca5f08cf7735f2',''),
	('ND008','Trang','8f65900731b2dd9351ca5f08cf7735f2','BlOOKER');
go
Create table Category
(
	CategoryID varchar(50) Primary key,
	Name nvarchar(50) null,
	Description nvarchar(50) null
)
go
Insert into Category
Values('L001',N'Điện Thoại','Không'),
	('L002',N'Máy Tính','Không'),
	('L003',N'Phụ Kiện','Không')
Go
Create table Product
(
	ProductID varchar(50) Primary key,
	Name nvarchar(50) null,
	UnitCost varchar(50) null,
	Quantity int null,
	Image varbinary(max) null,
	Description nvarchar(50) null,
	CategoryID varchar(50) null foreign key references Category(CategoryID),
	Status nvarchar(50) null
)
go
Insert into Product
Values('SP001',N'Realme 5 Pro','4.999.999 vnđ',10,null,null,'L001',null),
		('SP002',N'Realme 6 Pro','5.600.000 vnđ',5,null,null,'L001',null),
		('SP003',N'Máy Tính Aces','18.600.000 vnđ',7,null,null,'L002',null),
		('SP004',N'Sạc dự phòng 5000mh','600.000 vnđ',12,null,null,'L003',null),
		('SP005',N'IPhone X','12.600.000 vnđ',15,null,null,'L001',null),
		('SP006',N'IPhone 12','19.600.000 vnđ',20,null,null,'L001',null);
		
