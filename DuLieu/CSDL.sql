create database QuanLyTieuChuanTieuChi
go
use QuanLyTieuChuanTieuChi
go

create table TaiKhoan
(ID int identity primary key,
TenTaiKhoan varchar(30) not null,
MatKhau varchar(30) not null,
TenHienThi varchar(50) not null,
LoaiTK int --0: admin, 1: nhanvien
)
go
create table NhomTieuChi
(MaNhom int identity primary key,
TenNhom nvarchar(200) not null
)
go
create table TieuChi
(MaTieuChi int identity primary key,
MaNhom int references NhomTieuChi(MaNhom),
NoiDung nvarchar(200) not null,
KieuHienThiTuyChon int not null, --0: singlechoice, 1: multichoice, 2:input
MoTaTieuChi nvarchar(200),
IDNguoiTao int references TaiKhoan(ID) not null,
NgayTao datetime not null
)
go
create table TuyChonTieuChi
(MaTuyChon int identity primary key,
MaTieuChi int references TieuChi(MaTieuChi),
NoiDungTuyChon nvarchar(50) not null,
)
go
create table BoTieuChi
(
IDBoTieuChi int identity primary key,
HocKy int not null,
NamHoc nvarchar(10) not null,
IDNguoiTao int references TaiKhoan(ID),
NgayTao datetime not null,
isActive int
unique (HocKy, NamHoc)
)
go

create table ChiTietBoTieuChi
(
IDChiTietBo int identity primary key,
IDBoTieuChi int references BoTieuChi(IDBoTieuChi),
MaTieuChi int references TieuChi(MaTieuChi),
DiemTieuChi int not null,
DiemMin int
)
create table DiemTuyChon
(
IDTuyChon int identity primary key,
IDChiTietBo int references ChiTietBoTieuChi(IDChiTietBo),
MaTuyChon int references TuyChonTieuChi(MaTuyChon),
DiemTuyChon int not null,
)

