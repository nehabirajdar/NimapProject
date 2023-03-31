create table Product(ProductId int primary key,ProductName varchar(20),CategoryId int,constraint fkcategoryproduct foreign key(CategoryId) references Category(CategoryId))

create table Category(CategoryId int primary key,CategoryName varchar(20))

insert into Category values(1,'Digital_item')
insert into Category values(2,'Furniture')
insert into Category values(3,'Clothing')
insert into Category values(4,'Kitchen_item')


select * from Category
select * from Product


insert into Product values(1,'Mobile Phones',1)
insert into Product values(2,'Laptop',1)
insert into Product values(3,'Refrigerators',1)
insert into Product values(4,'TV',1)
insert into Product values(5,'Tab',1)


insert into Product values(6,'Sofa',2)
insert into Product values(7,'Bed',2)
insert into Product values(8,'Study Table',2)
insert into Product values(9,'Cupboards',2)
insert into Product values(10,'Sewing Machine',2)

insert into Product values(11,'Shirt',3)
insert into Product values(12,'Pant',3)
insert into Product values(13,'Saree',3)
insert into Product values(14,'Curti',3)
insert into Product values(15,'Track Pants',3)

delete Product where ProductId In(16,17,18,19,20)

insert into Product values(16,'Blender',4)
insert into Product values(17,'Mixer',4)
insert into Product values(18,'Coffee Machine',4)
insert into Product values(19,'Microwave',4)
insert into Product values(20,'Grinder',4)

