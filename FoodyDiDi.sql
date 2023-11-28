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