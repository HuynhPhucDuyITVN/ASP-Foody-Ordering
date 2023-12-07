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
	MatKhau varchar(255),
	QuyenHan int not null default 0, --0:khach; 1 admin
	TrangThai int default 1 --1:con hoat dong; 0:ngung hoat dong
)
go

create table DIACHI(
	MaDC int identity primary key not null,
	MaTK int foreign key (MaTK) references TAIKHOAN(MaTK) not null,
	DiaChi nvarchar (100) not null,
	PhuongXa nvarchar(20),
	QuanHuyen nvarchar(50),
	TinhThanh nvarchar(50)
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
--Món chiên
insert into MonAn(Ten,GiaGoc,GiaBan,MoTa,HinhAnh,MaDM)  values(N'Cá viên chiên',30000,25000,N'Cá viên chiên là một món ăn vặt phổ biến ở Việt Nam, được làm từ thịt cá xay, bột mì, bột năng, và các gia vị khác. Cá viên chiên có vị ngọt thơm, giòn rụm, rất thích hợp để nhâm nhi vào những ngày hè nóng bức.','mon26.jpg',4)
insert into MonAn(Ten,GiaGoc,GiaBan,MoTa,HinhAnh,MaDM)  values(N'Khoai lang chiên',40000,40000,N'Khoai lang chiên là một món ăn vặt phổ biến ở nhiều nước trên thế giới, trong đó có Việt Nam. Khoai lang chiên có vị ngọt thơm, giòn rụm, thường được ăn kèm với nước chấm tương ớt hoặc tương cà.','mon27.jpg',4)
insert into MonAn(Ten,GiaGoc,GiaBan,MoTa,HinhAnh,MaDM)  values(N'Phomai que',20000,20000,N'Phô mai que chiên là một món ăn vặt phổ biến ở nhiều nước trên thế giới, trong đó có Việt Nam. Phô mai que chiên có vị béo ngậy, thơm ngon, giòn rụm, thường được ăn kèm với tương ớt hoặc tương cà.','mon28.jpg',4)
insert into MonAn(Ten,GiaGoc,GiaBan,MoTa,HinhAnh,MaDM)  values(N'Há cảo chiên',40000,35000,N'Há cảo chiên là một món ăn phổ biến ở nhiều nước châu Á, trong đó có Việt Nam. Món ăn này được làm từ bột há cảo, nhân tôm thịt và các loại rau củ, sau đó được chiên vàng giòn.','mon29.jpg',4)
insert into MonAn(Ten,GiaGoc,GiaBan,MoTa,HinhAnh,MaDM)  values(N'Gà rán muối',70000,70000,N'Gà rán muối là một món ăn vặt phổ biến ở nhiều nước trên thế giới, trong đó có Việt Nam. Món ăn này có vị giòn rụm, thơm ngon, đậm đà hương vị muối.','mon30.jpg',4)
insert into MonAn(Ten,GiaGoc,GiaBan,MoTa,HinhAnh,MaDM)  values(N'Tokbokki rán lắc phomai',40000,35000,N'Tokbokki rán lắc phô mai là một món ăn vặt hấp dẫn, với lớp vỏ ngoài giòn rụm, bên trong là nhân tokbokki mềm dai, đậm đà, hòa quyện với vị béo ngậy của phô mai.','mon31.jpg',4)
insert into MonAn(Ten,GiaGoc,GiaBan,MoTa,HinhAnh,MaDM)  values(N'Da gà lắc',20000,20000,N'Da gà rán lắc là một món ăn vặt hấp dẫn, với lớp vỏ ngoài giòn rụm, bên trong là da gà mềm dai, đậm đà, hòa quyện với các loại gia vị và topping khác nhau.','mon32.jpg',4)
--Món nướng
insert into MonAn(Ten,GiaGoc,GiaBan,MoTa,HinhAnh,MaDM)  values(N'Ba chỉ bò mỹ nướng tiêu đen',30000,25000,N'Sợi thịt ba chỉ từ bò Mỹ được nướng chín mềm, phủ lớp tiêu đen tạo nên hương vị đặc trưng và thơm ngon.','mon33.jpg',5)
insert into MonAn(Ten,GiaGoc,GiaBan,MoTa,HinhAnh,MaDM)  values(N'Bẹ sữa heo ướp chao',40000,40000,N'Bẹ sữa heo được ướp gia vị chao, tạo nên một lớp vị thơm ngon và hấp dẫn khi nướng chín.','mon34.jpg',5)
insert into MonAn(Ten,GiaGoc,GiaBan,MoTa,HinhAnh,MaDM)  values(N'Sụn heo ướp sa tế',20000,20000,N'Sụn heo được ướp gia vị sa tế, tạo nên hương vị cay nồng đặc trưng và thịt sụn giữ được độ ngon mềm.','mon35.jpg',5)
insert into MonAn(Ten,GiaGoc,GiaBan,MoTa,HinhAnh,MaDM)  values(N'Mực nướng sốt hàng quốc',40000,35000,N'Mực được nướng chín và ướp sốt hàng quốc, tạo nên một hương vị độc đáo hòa quyện giữa ngọt, cay, và mặn.','mon36.jpg',5)
insert into MonAn(Ten,GiaGoc,GiaBan,MoTa,HinhAnh,MaDM)  values(N'Sườn heo sốt BBQ',70000,70000,N'Sườn heo được nướng và phủ lớp sốt BBQ đặc trưng, tạo nên một hương vị ngon ngọt, cay nồng và thơm phức.','mon37.jpg',5)
insert into MonAn(Ten,GiaGoc,GiaBan,MoTa,HinhAnh,MaDM)  values(N'Ếch nướng muối ớt',40000,35000,N' Ếch được nướng chín và ướp gia vị muối ớt, tạo nên một hương vị cay nồng và thơm ngon đặc trưng.','mon38.jpg',5)
insert into MonAn(Ten,GiaGoc,GiaBan,MoTa,HinhAnh,MaDM)  values(N'Gà ta nướng muối ớt',20000,20000,N'Gà ta được nướng và ướp muối ớt, tạo nên hương vị độc đáo, cay nồng, và thơm ngon.','mon39.jpg',5)
insert into MonAn(Ten,GiaGoc,GiaBan,MoTa,HinhAnh,MaDM)  values(N'Sườn heo ngũ vị',35000,30000,N'Sườn heo được ướp gia vị ngũ vị, kết hợp với cách nướng độc đáo, tạo nên hương vị đa dạng và hấp dẫn.','mon40.jpg',5)
insert into MonAn(Ten,GiaGoc,GiaBan,MoTa,HinhAnh,MaDM)  values(N'Lưỡi vịt nướng muối ớt',40000,40000,N'Lưỡi vịt được nướng chín và ướp muối ớt, tạo nên một hương vị cay nồng, thơm ngon và độc đáo.','mon41.jpg',5)
--Combo
insert into MonAn(Ten,GiaGoc,GiaBan,MoTa,HinhAnh,MaDM)  values(N'Combo cà phê cowboy',90000,75000,N'Mì hoàng đế singapore; Bún măng thiên nga; Cơm chiên bò lúc lắc và cà phê cowboy một trong những combo vô cùng đặc biệt và nổi bật trong thời gian gần đây hãy nhanh tay order món này nào.','mon49.jpg',6)
insert into MonAn(Ten,GiaGoc,GiaBan,MoTa,HinhAnh,MaDM)  values(N'Combo trà sữa trân châu đường đen MIXUE',40000,38000,N'Chỉ 38K/2 ly trà sữa trân trâu đường đen béo ngậy, đậm đà, với những viên trân châu dẻo ngọt.','mon50.jpg',6)
insert into MonAn(Ten,GiaGoc,GiaBan,MoTa,HinhAnh,MaDM)  values(N'Combo tết là sum vầy',534000,399000,N'Combo 2 ly pepsi size L và một phần bánh mì nướng tỏi thơm ngon với phần salad đầy tươi sống và đặc biệt nhất là phần pizza hải sản size XL.','mon51.jpg',6)
insert into MonAn(Ten,GiaGoc,GiaBan,MoTa,HinhAnh,MaDM)  values(N'Combo hải sản thượng phẩm',2087000,1790000,N'Với 2 con tôm hùm cỡ lớn cùng với đó là ốc hương sữa và hào pháp đầy tươi ngon và phần cua lông giới hạn trong năm và ngiêu hải sản đầy cuốn hút','mon52.jpg',6)
--Lẩu
insert into MonAn(Ten,GiaGoc,GiaBan,MoTa,HinhAnh,MaDM)  values(N'Lẩu thác lác khổ qua',300000,250000,N'Lẩu thác lác kết hợp với khổ qua tạo nên một hương vị độc đáo. Thác lác thêm sự giòn giòn, còn khổ qua mang lại hương vị đắng nhẹ, tạo nên một sự kết hợp hài hòa và dễ chịu.','mon42.jpg',7)
insert into MonAn(Ten,GiaGoc,GiaBan,MoTa,HinhAnh,MaDM)  values(N'Lẩu Thái hải sản',400000,400000,N'Lẩu Thái hải sản là sự pha trộn của nhiều loại hải sản như tôm, sò điệp, mực, cá, kết hợp với gia vị Thái tạo nên một lẩu hương vị đậm đà, cay nồng và đầy ẩm thực biển.','mon43.jpg',7)
insert into MonAn(Ten,GiaGoc,GiaBan,MoTa,HinhAnh,MaDM)  values(N'Lẩu gà ta ớt hiểm',200000,200000,N' Lẩu gà ta với ớt hiểm tạo nên hương vị cay nồng, thơm ngon và đậm đà. Gà ta thêm vào đó mang lại sự ngon miệng và thịt mềm mịn.','mon44.jpg',7)
insert into MonAn(Ten,GiaGoc,GiaBan,MoTa,HinhAnh,MaDM)  values(N'Lẩu tôm sú',400000,350000,N'Lẩu tôm sú là sự kết hợp của tôm sú tươi ngon, nước lẩu ngon miệng và gia vị tinh tế. Hương vị độc đáo và thịt tôm ngon mềm là điểm đặc sắc của món này.','mon45.jpg',7)
insert into MonAn(Ten,GiaGoc,GiaBan,MoTa,HinhAnh,MaDM)  values(N'Lẩu cua ',300000,250000,N'Lẩu cua là sự phối hợp của nước lẩu thơm ngon và thịt cua tươi ngon. Hương vị ngon miệng và thịt cua giữ được độ giòn, tạo nên một món lẩu hấp dẫn.','mon46.jpg',7)
insert into MonAn(Ten,GiaGoc,GiaBan,MoTa,HinhAnh,MaDM)  values(N'Lẩu cá kèo',400000,350000,N' Lẩu cá kèo sử dụng cá kèo tươi ngon, kết hợp với nước lẩu thơm ngon và các loại rau sống. Món ăn mang lại hương vị đặc trưng của cá biển và hấp dẫn với sự giòn ngon của cá.','mon47.jpg',7)
insert into MonAn(Ten,GiaGoc,GiaBan,MoTa,HinhAnh,MaDM)  values(N'Lẩu nấm gà',200000,200000,N'Lẩu nấm gà là sự kết hợp của nước lẩu ngon và nấm gà tươi ngon. Món ăn mang lại hương vị đậm đà, thơm ngon và phong phú từ các loại nấm.','mon48.jpg',7)

select * from MONAN;
--Cập nhật lượt xem mặc định
update MONAN set LuotXem =10 where MaMA=1;
update MONAN set LuotXem =9 where MaMA=11;
update MONAN set LuotXem =8 where MaMA=17;
update MONAN set LuotXem =7 where MaMA=26;
update MONAN set LuotXem =6 where MaMA=33;
update MONAN set LuotXem =5 where MaMA=42;

alter table TAIKHOAN
alter column MatKhau varchar(255);
--Tài khoản admin mặc định
insert into TAIKHOAN(Ten,DienThoai,Email,MatKhau,QuyenHan) values (N'Admin','0378108260','admin@gmail.com','AQAAAAEAACcQAAAAECfllvvNXn5YXRaP/pMk+35EeP2pP1Snj/OQd2c7IkTEAB05xE7f38SDVvYSzWOsIA==',1);
--Tài khoản user mặc định
insert into TAIKHOAN(Ten,DienThoai,Email,MatKhau,QuyenHan) values (N'Duy','0378108260','phucduy11032002@gmail.com','AQAAAAEAACcQAAAAEE4kBiWlhd9+TuzfBf1Wkmf3t6VK8mMfLYmH1sUWiVJh804hML1vaI16ARuqgMlqfQ==',0);

SELECT * FROM HOADON;
SELECT * FROM CTHOADON;
select * from TAIKHOAN;
select * from DIACHI;
select * from MONAN;

select * from TAIKHOAN