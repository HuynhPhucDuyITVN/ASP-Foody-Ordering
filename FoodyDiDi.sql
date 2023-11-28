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
--Món ăn nhẹ
insert into MonAn(Ten,GiaGoc,GiaBan,MoTa,HinhAnh,MaDM)  values(N'Bánh tráng trộn',30000,25000,N'Bánh tráng được cắt thành sợi nhỏ, sau đó trộn đều với các nguyên liệu khác. Muối tôm là gia vị đặc trưng của món bánh tráng trộn, tạo nên hương vị thơm ngon và đậm đà. Sa tế tạo nên vị cay nồng cho món ăn. Xoài xanh chua chua ngọt ngọt giúp cân bằng vị giác. Rau răm có tác dụng giải ngán và giúp món ăn thêm thơm ngon.','mon17.jpg',3)
insert into MonAn(Ten,GiaGoc,GiaBan,MoTa,HinhAnh,MaDM)  values(N'Bánh mì nướng muối ớt',40000,40000,N'Bánh mì được cắt đôi, phết bơ lên mặt rồi nướng vàng giòn. Sau đó, bánh mì được phết hỗn hợp muối ớt lên mặt, thêm chà bông, xúc xích, trứng cút, hành lá và mayonnaise.','mon18.jpg',3)
insert into MonAn(Ten,GiaGoc,GiaBan,MoTa,HinhAnh,MaDM)  values(N'Chè thái',20000,20000,N'Chè Thái có vị ngọt thanh, thơm béo của nước cốt dừa, giòn giòn của các loại thạch, và béo ngậy của các loại trái cây. Món chè này rất thích hợp để giải nhiệt vào những ngày hè nóng bức.','mon19.jpg',3)
insert into MonAn(Ten,GiaGoc,GiaBan,MoTa,HinhAnh,MaDM)  values(N'Pana Cotta',40000,35000,N'Panna cotta thường được phục vụ với các loại trái cây, sốt trái cây, hoặc sô cô la. Món ăn này có thể được làm với nhiều hương vị khác nhau, chẳng hạn như vani, chocolate, cà phê, hoặc hương vị trái cây.','mon20.jpg',3)
insert into MonAn(Ten,GiaGoc,GiaBan,MoTa,HinhAnh,MaDM)  values(N'Chân gà sả tắc',70000,70000,N'Chân gà sả tắc có vị chua chua, cay cay, mặn mặn, ngọt ngọt, giòn giòn, thơm thơm. Món ăn này rất thích hợp để nhâm nhi vào những ngày hè nóng bức.','mon21.jpg',3)
insert into MonAn(Ten,GiaGoc,GiaBan,MoTa,HinhAnh,MaDM)  values(N'Bánh flan',40000,35000,N'Bánh flan là một món ăn tráng miệng phổ biến ở nhiều nước trên thế giới, trong đó có Việt Nam. Bánh flan có vị ngọt thanh, béo ngậy, thơm mùi sữa và trứng. Món ăn này thường được phục vụ với nước cốt dừa, trái cây hoặc sốt chocolate.','mon22.jpg',3)
insert into MonAn(Ten,GiaGoc,GiaBan,MoTa,HinhAnh,MaDM)  values(N'Bột chiên',20000,20000,N'Bột chiên là một món ăn phổ biến ở nhiều nước châu Á, trong đó có Việt Nam. Bột chiên có vị giòn rụm, thơm ngon, thường được ăn kèm với nước chấm tương ớt hoặc tương cà. Bột chiên là món ăn đơn giản nhưng thơm ngon và hấp dẫn. Món ăn này rất thích hợp để thưởng thức vào những ngày hè nóng bức.','mon23.jpg',3)
insert into MonAn(Ten,GiaGoc,GiaBan,MoTa,HinhAnh,MaDM)  values(N'Bánh xếp nghìn lớp',35000,30000,N'Bánh xếp nghìn lớp là một món ăn phổ biến ở Trung Quốc, được làm từ bột ngàn lớp, nhân thịt, trứng cút và các loại rau củ. Bánh xếp có vị thơm ngon, béo ngậy, giòn rụm, thường được ăn kèm với nước chấm tương ớt hoặc tương cà.','mon24.jpg',3)
insert into MonAn(Ten,GiaGoc,GiaBan,MoTa,HinhAnh,MaDM)  values(N'Nem chua rán',40000,40000,N'Nem chua rán là một món ăn vặt phổ biến ở Việt Nam, được làm từ thịt lợn xay, bì lợn, thính gạo, và các gia vị khác. Nem chua rán có vị chua chua, cay cay, giòn rụm, rất thích hợp để nhâm nhi vào những ngày hè nóng bức.','mon25.jpg',3)