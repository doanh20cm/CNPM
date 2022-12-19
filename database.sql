USE master
GO
DROP DATABASE IF EXISTS [test2]
GO
CREATE DATABASE [test2]
GO
USE [test2]
GO
/****** Object:  Table [dbo].[BoPhan]    Script Date: 12/19/2022 7:24:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BoPhan](
	[MaBoPhan] [int] IDENTITY(1,1) NOT NULL,
	[TenBoPhan] [nvarchar](50) NOT NULL,
	[NgayThanhLap] [date] NOT NULL,
	[SDTBoPhan] [char](10) NOT NULL,
	[GhiChu] [nvarchar](50) NULL,
 CONSTRAINT [PK_BoPhan] PRIMARY KEY CLUSTERED 
(
	[MaBoPhan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhongBan]    Script Date: 12/19/2022 7:24:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhongBan](
	[MaPhongBan] [int] IDENTITY(1,1) NOT NULL,
	[TenPhongBan] [nvarchar](50) NOT NULL,
	[MaBoPhan] [int] NULL,
	[NgayThanhLap] [date] NOT NULL,
	[TruongPhongBan] [nvarchar](50) NULL,
	[SDTPhong] [char](10) NOT NULL,
	[GhiChu] [nvarchar](50) NULL,
 CONSTRAINT [PK_PhongBan] PRIMARY KEY CLUSTERED 
(
	[MaPhongBan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[xemBoPhan]    Script Date: 12/19/2022 7:24:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[xemBoPhan] as
select BoPhan.MaBoPhan, BoPhan.TenBoPhan, BoPhan.NgayThanhLap, SDTBoPhan, BoPhan.GhiChu, count(PhongBan.MaPhongBan) as 'Số phòng ban hiện có'

from BoPhan left join PhongBan on BoPhan.MaBoPhan = PhongBan.MaBoPhan

group by BoPhan.MaBoPhan, BoPhan.TenBoPhan, BoPhan.NgayThanhLap, BoPhan.GhiChu, SDTBoPhan
GO
/****** Object:  View [dbo].[xempb]    Script Date: 12/19/2022 7:24:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[xempb] as
select MaPhongBan, TenPhongBan, PhongBan.MaBoPhan, TenBoPhan, PhongBan.NgayThanhLap, TruongPhongBan, SDTPhong, PhongBan.GhiChu
from PhongBan, BoPhan
where PhongBan.MaBoPhan = BoPhan.MaBoPhan
GO
/****** Object:  Table [dbo].[HoSoNhanVien]    Script Date: 12/19/2022 7:24:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoSoNhanVien](
	[MaNV] [int] IDENTITY(1,1) NOT NULL,
	[HoTen] [nvarchar](50) NOT NULL,
	[NgaySinh] [date] NOT NULL,
	[NoiSinh] [nvarchar](50) NOT NULL,
	[DiaChi] [nvarchar](50) NOT NULL,
	[SDT] [char](10) NOT NULL,
	[GioiTinh] [nvarchar](3) NOT NULL,
	[DanToc] [nvarchar](50) NOT NULL,
	[TonGiao] [nvarchar](50) NOT NULL,
	[HocVan] [nvarchar](50) NOT NULL,
	[GhiChu] [nvarchar](50) NULL,
	[AnhHoSo] [varbinary](max) NOT NULL,
 CONSTRAINT [PK_HoSoNhanVien] PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NguoiDung]    Script Date: 12/19/2022 7:24:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NguoiDung](
	[TaiKhoan] [nvarchar](50) NOT NULL,
	[MatKhau] [char](32) NOT NULL,
	[ChucVu] [nvarchar](50) NOT NULL,
	[MaNV] [int] NULL,
	[Email] [varchar](255) NOT NULL,
	[LastOTPRequestTime] [datetime] NULL,
	[GhiChu] [nvarchar](50) NULL,
 CONSTRAINT [PK_NguoiDung] PRIMARY KEY CLUSTERED 
(
	[TaiKhoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[xemtk]    Script Date: 12/19/2022 7:24:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE view [dbo].[xemtk]
as
select TaiKhoan as [Tên tài khoản], NguoiDung.MaNV ,ChucVu as [Chức vụ], HoTen as [Tên nhân viên], Email, NguoiDung.GhiChu as [Ghi chú]
from NguoiDung, HoSoNhanVien
where NguoiDung.MaNV = HoSoNhanVien.MaNV
GO
/****** Object:  Table [dbo].[Luong]    Script Date: 12/19/2022 7:24:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Luong](
	[MaLuong] [int] IDENTITY(1,1) NOT NULL,
	[MaNV] [int] NULL,
	[LuongCoSo] [int] NOT NULL,
	[HeSoLuong] [float] NOT NULL,
	[SoNgayCong] [int] NOT NULL,
	[SoGioLamThem] [int] NOT NULL,
	[PhuCap] [int] NOT NULL,
	[Thuong] [int] NOT NULL,
	[Phat] [int] NOT NULL,
	[Thang] [int] NOT NULL,
	[Nam] [int] NOT NULL,
	[GhiChu] [nvarchar](50) NULL,
	[TongKetThang] [float] NULL,
 CONSTRAINT [PK_Luong] PRIMARY KEY CLUSTERED 
(
	[MaLuong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[xemluong]    Script Date: 12/19/2022 7:24:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[xemluong]
AS
SELECT       dbo.Luong.MaLuong, dbo.HoSoNhanVien.HoTen, CAST(dbo.Luong.LuongCoSo / 1000000.0 AS decimal(5, 3)) AS LuongCoSo, CAST(dbo.Luong.HeSoLuong AS decimal(5, 3)) AS HeSoLuong, dbo.Luong.SoNgayCong, 
                         dbo.Luong.SoGioLamThem, CAST(dbo.Luong.PhuCap / 1000000.0 AS decimal(5, 3)) AS PhuCap, CAST(dbo.Luong.Thuong / 1000000.0 AS decimal(5, 3)) AS Thuong, CAST(dbo.Luong.Phat / 1000000.0 AS decimal(5, 3)) AS Phat, 
                         dbo.Luong.Thang, dbo.Luong.Nam, dbo.Luong.GhiChu, CAST(dbo.Luong.TongKetThang AS decimal(6, 2)) AS TongKetThang
FROM            dbo.Luong INNER JOIN
                         dbo.HoSoNhanVien ON dbo.Luong.MaNV = dbo.HoSoNhanVien.MaNV
GO
/****** Object:  Table [dbo].[NhanVienPhongBan]    Script Date: 12/19/2022 7:24:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVienPhongBan](
	[MaNV] [int] NOT NULL,
	[MaPhongBan] [int] NULL,
	[LoaiHD] [nvarchar](50) NOT NULL,
	[NgayKy] [date] NOT NULL,
	[NgayHetHan] [date] NOT NULL,
	[ThoiGian] [nvarchar](50) NOT NULL,
	[GhiChu] [nvarchar](50) NULL,
 CONSTRAINT [PK_NhanVienPhongBan] PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Luong] ADD  CONSTRAINT [DF_Luong_TongKetThang]  DEFAULT ((0)) FOR [TongKetThang]
GO
ALTER TABLE [dbo].[NguoiDung] ADD  CONSTRAINT [df_otp]  DEFAULT ('1753-01-01') FOR [LastOTPRequestTime]
GO
ALTER TABLE [dbo].[NguoiDung]  WITH CHECK ADD  CONSTRAINT [FK_NguoiDung_HoSoNhanVien] FOREIGN KEY([MaNV])
REFERENCES [dbo].[HoSoNhanVien] ([MaNV])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[NguoiDung] CHECK CONSTRAINT [FK_NguoiDung_HoSoNhanVien]
GO
ALTER TABLE [dbo].[NhanVienPhongBan]  WITH CHECK ADD  CONSTRAINT [FK_NhanVienPhongBan_HoSoNhanVien] FOREIGN KEY([MaNV])
REFERENCES [dbo].[HoSoNhanVien] ([MaNV])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[NhanVienPhongBan] CHECK CONSTRAINT [FK_NhanVienPhongBan_HoSoNhanVien]
GO
ALTER TABLE [dbo].[NhanVienPhongBan]  WITH CHECK ADD  CONSTRAINT [FK_NhanVienPhongBan_PhongBan] FOREIGN KEY([MaPhongBan])
REFERENCES [dbo].[PhongBan] ([MaPhongBan])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[NhanVienPhongBan] CHECK CONSTRAINT [FK_NhanVienPhongBan_PhongBan]
GO
ALTER TABLE [dbo].[PhongBan]  WITH CHECK ADD  CONSTRAINT [FK_PhongBan_BoPhan] FOREIGN KEY([MaBoPhan])
REFERENCES [dbo].[BoPhan] ([MaBoPhan])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[PhongBan] CHECK CONSTRAINT [FK_PhongBan_BoPhan]
GO