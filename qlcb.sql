create database quanlicanbo

use quanlicanbo

create table phongban (
phongbanID char(10),
tenphongban nvarchar(30),

primary key (phongbanID)
)

update phongban set tenphongban=N'Ban TC' where phongbanID='PB04'
select * from phongban
insert into phongban values ('PB01',N'Ban nhân sự')
insert into phongban values ('PB02',N'Ban tài chính')
insert into phongban values ('PB03',N'Ban giám đốc')
insert into phongban values ('PB04',N'Ban thiết kế')
insert into phongban values ('PB05',N'Ban kế toán')

create table canbo (
canboID char(10),
phongbanID char(10),
chucvuID char(10),
hoten nvarchar(30),
ngaysinh datetime,
gioitinh nvarchar(5),
hesoluong int,
ladangvien nvarchar(30),
vaocongdoan nvarchar(30),
anh nvarchar(10),
ghichu nvarchar(30),

primary key (canboID,phongbanID,chucvuID)
)


insert into canbo values ('CA01','PB01','CV01',N'Cao Tiến Đạt','2000-2-8',N'Nam',10, N'Là đảng', N'Chưa vào công đoàn',N'Không',N'Không')
insert into canbo values ('CA02','PB02','CV02',N'Phan Cư Chánh','1997-2-6',N'Nam',6, N'Là đảng', N'đã vào công đoàn',N'Không',N'Không')
insert into canbo values ('CA03','PB03','CV03',N'Nguyễn Quốc Việt','1996-8-8',N'Nữ',10, N'Chưa vào đảng', N'đã vào công đoàn',N'Không',N'Không')
insert into canbo values ('CA04','PB04','CV04',N'Nguyễn Thắng Hưng','1996-2-8',N'Nam',10, N'Là đảng', N'Chưa vào công đoàn',N'Không',N'Không')
insert into canbo values ('CA05','PB05','CV05',N'Nguyễn Như Thịnh','2000-1-8',N'Nam',10, N'Là đảng', N'Đã vào công đoàn',N'Không',N'Không')

--tester
select phongbanID, tenphongban from phongban