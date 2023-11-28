Use Master
GO
    IF exists(Select name From sys.databases Where name='FoodyDiDi' )
    DROP Database FoodyDiDi
GO
    Create Database FoodyDiDi
GO

use FoodyDiDi;

create table DANHMUC(
	MaDM int identity primary key not null,
	Ten nvarchar(100) not null,
	HinhAnh varchar (255),
	TrangThai int default 1 --1:con hoat dong; 0:ngung hoat dong
)
go

create table MONAN(
	MaMA int identity primary key not null,
	Ten nvarchar(100) not null,
	GiaGoc int not null,
	GiaBan int not null,
	MoTa nvarchar(1000),
	HinhAnh varchar(255),
	MaDM int foreign key (MaDM) references DANHMUC(MaDM) not null,
	LuotXem int,
	LuotMua int
)
go


create table TAIKHOAN(
	MaTK int identity primary key not null,
	Ten nvarchar(100) not null,
	DienThoai varchar(20),
	Email varchar(50),
	MatKhau varchar(50) not null,
	QuyenHan int not null default 0, --0:khach; 1 admin
	TrangThai int default 1 --1:con hoat dong; 0:ngung hoat dong
)
go

create table DIACHI(
	MaDC int identity primary key not null,
	MaTK int foreign key (MaTK) references TAIKHOAN(MaTK) not null,
	DiaChi nvarchar (100) not null,
	PhuongXa varchar(20),
	QuanHuyen varchar(50),
	TinhThanh varchar(50)
)
go

create table HOADON(
	MaHD int identity primary key not null,
	Ngay datetime default getdate(),
	TongTien int,
	MaTK int foreign key (MaTK) references TAIKHOAN(MaTK) not null,
	TrangThai int default 0 -- 0:duoc tao; 1:dang van chuyen; 2:giao thanh cong
)
go

create table CTHOADON(
	MaCTHD int identity primary key not null,
	MaHD int foreign key (MaHD) references HOADON(MaHD) not null,
	MaMA int foreign key (MaMA) references MONAN(MaMA) not null,
	DonGia int,
	SoLuong int,
	ThanhTien int
)
go
--Thêm Danh Mục
insert into DANHMUC(Ten,HinhAnh)values(N'Món khai vị','icon1.png')
insert into DANHMUC(Ten,HinhAnh)values(N'Salad','icon2.png')
insert into DANHMUC(Ten,HinhAnh)values(N'Món ăn nhẹ','icon3.png')
insert into DANHMUC(Ten,HinhAnh)values(N'Món Chiên','icon4.png')
insert into DANHMUC(Ten,HinhAnh)values(N'Món nướng','icon5.png')
insert into DANHMUC(Ten,HinhAnh)values(N'Combo','icon6.png')
insert into DANHMUC(Ten,HinhAnh)values(N'Lẩu','icon7.png')
--Món Khai vị
insert into MonAn(Ten,GiaGoc,GiaBan,MoTa,HinhAnh,MaDM)  values(N'Đậu hủ non chiên giòn',40000,35000,N'Đậu hũ non chiên giòn được làm từ đậu hũ non, bột chiên giòn, bột mì và trứng gà. Đậu hũ non được cắt thành miếng vừa ăn, sau đó lăn qua bột mì, trứng gà và bột chiên giòn. Cuối cùng, đậu hũ được chiên ngập dầu cho đến khi vàng giòn.','mon1.jpg',1)
insert into MonAn(Ten,GiaGoc,GiaBan,MoTa,HinhAnh,MaDM)  values(N'Khoai tây chiên',40000,40000,N'Khoai tây chiên có màu vàng ươm bắt mắt, lớp vỏ bên ngoài giòn rụm, bên trong mềm mịn. Khi ăn, bạn sẽ cảm nhận được vị giòn tan của lớp vỏ, vị ngọt bùi của khoai tây. Khoai tây chiên thường được ăn kèm với nhiều loại nước sốt khác nhau, chẳng hạn như tương ớt, tương cà, sốt mayonnaise','mon2.jpg',1)
insert into MonAn(Ten,GiaGoc,GiaBan,MoTa,HinhAnh,MaDM)  values(N'Gỏi hải sản',40000,40000,N'Gỏi hải sản có màu sắc bắt mắt, hương vị chua ngọt hài hòa, vị ngọt thanh của hải sản, vị giòn giòn của rau củ hòa quyện với nhau tạo nên một món ăn vô cùng thơm ngon và hấp dẫn.','mon3.jpg',1)
insert into MonAn(Ten,GiaGoc,GiaBan,MoTa,HinhAnh,MaDM)  values(N'Gỏi ếch hoa chuối',60000,50000,N'Gỏi ếch hoa chuối được làm từ thịt ếch, hoa chuối, cà rốt, dưa leo, hành tây, rau thơm và nước chấm chua ngọt. Thịt ếch được luộc chín, xé sợi; hoa chuối bào sợi, ngâm nước muối loãng cho hết nhựa; cà rốt, dưa leo thái sợi; hành tây thái mỏng; rau thơm rửa sạch, thái nhỏ. Tất cả các nguyên liệu được trộn đều với nhau cùng nước chấm chua ngọt.','mon4.jpg',1)
insert into MonAn(Ten,GiaGoc,GiaBan,MoTa,HinhAnh,MaDM)  values(N'Khổ qua chà bông',70000,70000,N'Khổ qua chà bông được làm từ khổ qua, chà bông, đường, muối, nước mắm. Khổ qua được rửa sạch, bỏ ruột, thái lát mỏng. Sau đó, khổ qua được ngâm trong nước muối loãng khoảng 15 phút để bớt đắng. Sau đó, khổ qua được vớt ra, rửa sạch lại với nước. Khổ qua được trộn đều với chà bông, đường, muối, nước mắm. Để món ăn được ngon hơn, bạn có thể thêm một chút tỏi băm và ớt băm.','mon5.jpg',1)
insert into MonAn(Ten,GiaGoc,GiaBan,MoTa,HinhAnh,MaDM)  values(N'Súp bắp tôm',40000,40000,N'Súp bắp tôm là một món súp thơm ngon, bổ dưỡng, được nhiều người yêu thích. Món ăn này có vị ngọt thanh của bắp, vị ngọt của tôm, vị béo của kem tươi và vị thơm của hành lá.','mon6.jpg',1)
insert into MonAn(Ten,GiaGoc,GiaBan,MoTa,HinhAnh,MaDM)  values(N'Giò heo muối',60000,60000,N'Giò heo muối là một món ăn dân dã, quen thuộc của người Việt Nam. Món ăn này có vị dai giòn của giò heo, vị béo ngậy của muối mặn. ','mon7.jpg',1)
insert into MonAn(Ten,GiaGoc,GiaBan,MoTa,HinhAnh,MaDM)  values(N'Gà ủ muối',150000,150000,N'Gà ủ muối là một món ăn đặc trưng của xứ Huế. Món ăn này có vị ngọt thanh của thịt gà, vị béo ngậy của muối mặn. ','mon8.jpg',1)
insert into MonAn(Ten,GiaGoc,GiaBan,MoTa,HinhAnh,MaDM)  values(N'Bắp xào tôm tươi',50000,40000,N'Bắp xào tôm tươi là một món ăn thơm ngon, hấp dẫn, được nhiều người yêu thích. Món ăn này có vị ngọt thanh của bắp, vị ngọt của tôm, vị bùi của hành lá. ','mon9.jpg',1)
insert into MonAn(Ten,GiaGoc,GiaBan,MoTa,HinhAnh,MaDM)  values(N'Salad trứng bò',50000,35000,N'Salad trứng bò là một món salad thơm ngon, bổ dưỡng, được nhiều người yêu thích. Món ăn này có vị ngọt thanh của thịt bò, vị béo ngậy của trứng gà, vị giòn giòn của rau củ hòa quyện với nhau tạo nên một món ăn vô cùng hấp dẫn. ','mon10.jpg',1)
--Món Salad
insert into MonAn(Ten,GiaGoc,GiaBan,MoTa,HinhAnh,MaDM)  values(N'Salad Da Cá',30000,25000,N'Salad da cá là một món salad đơn giản, dễ làm nhưng lại vô cùng thơm ngon, hấp dẫn. Món ăn này có vị ngọt thanh của da cá, vị giòn giòn của rau củ hòa quyện với nhau tạo nên một món ăn vô cùng hấp dẫn.','mon11.jpg',2)
insert into MonAn(Ten,GiaGoc,GiaBan,MoTa,HinhAnh,MaDM)  values(N'Salad Tôm Bơ',40000,40000,N'Salad tôm bơ là một món salad thơm ngon, bổ dưỡng, được nhiều người yêu thích. Món ăn này có vị ngọt thanh của tôm, vị béo ngậy của bơ, vị giòn giòn của rau củ hòa quyện với nhau tạo nên một món ăn vô cùng hấp dẫn.','mon12.jpg',2)
insert into MonAn(Ten,GiaGoc,GiaBan,MoTa,HinhAnh,MaDM)  values(N'Salad Cầu Vòng',20000,20000,N'Salad cầu vòng là một món salad đặc trưng của ẩm thực Thái Lan. Món ăn này có màu sắc bắt mắt, hương vị chua cay hài hòa, được nhiều người yêu thích.','mon13.jpg',2)
insert into MonAn(Ten,GiaGoc,GiaBan,MoTa,HinhAnh,MaDM)  values(N'Salad Rong Sốt Mè Rang',40000,35000,N'Salad rong sốt mè rang là một món salad thanh mát, bổ dưỡng, được nhiều người yêu thích. Món ăn này có vị ngọt thanh của rong biển, vị béo ngậy của mè rang, vị cay của ớt hòa quyện với nhau tạo nên một món ăn vô cùng hấp dẫn.','mon14.jpg',2)
insert into MonAn(Ten,GiaGoc,GiaBan,MoTa,HinhAnh,MaDM)  values(N'Salad Chuối Phomai',70000,70000,N'Salad chuối phomai là một món salad độc đáo, lạ miệng, được nhiều người yêu thích. Món ăn này có vị ngọt thanh của chuối, vị béo ngậy của phomai, vị chua của chanh hòa quyện với nhau tạo nên một món ăn vô cùng hấp dẫn.','mon15.jpg',2)
insert into MonAn(Ten,GiaGoc,GiaBan,MoTa,HinhAnh,MaDM)  values(N'Salad Dầu Dấm',40000,35000,N'Salad dầu dấm là một món salad đơn giản, dễ làm, được nhiều người yêu thích. Món ăn này có vị chua chua, cay cay, giòn giòn của rau củ hòa quyện với','mon16.jpg',2)