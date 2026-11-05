-- =========================================================================================
-- FLORASHOP - ENTERPRISE DATABASE SETUP & SEED DATA
-- HỆ THỐNG QUẢN LÝ CỬA HÀNG ĐIỆN HOA FLORASHOP
-- =========================================================================================

USE master;
GO

SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
GO

-- 1. TẠO MỚI CƠ SỞ DỮ LIỆU FLORASHOPDB (XÓA BẢN CŨ NẾU CÓ ĐỂ ĐỒNG BỘ 100%)
IF EXISTS (SELECT name FROM sys.databases WHERE name = N'FloraShopDB')
BEGIN
    ALTER DATABASE FloraShopDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE FloraShopDB;
END
GO

CREATE DATABASE FloraShopDB
COLLATE Vietnamese_CI_AS;
GO

USE FloraShopDB;
GO

SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
GO

-- =========================================================================================
-- PHẦN 1: CẤU TRÚC CƠ SỞ DỮ LIỆU (7 BẢNG CHUẨN BCNF)
-- =========================================================================================

-- Bảng 1: DanhMucHoa (Phân loại các dòng hoa)
CREATE TABLE DanhMucHoa (
    MaDM NVARCHAR(20) NOT NULL,
    TenDM NVARCHAR(100) NOT NULL,
    MoTa NVARCHAR(300) NULL,
    CONSTRAINT PK_DanhMucHoa PRIMARY KEY (MaDM),
    CONSTRAINT UQ_DanhMucHoa_TenDM UNIQUE (TenDM)
);
GO

-- Bảng 2: Hoa (Thông tin mặt hàng hoa, đơn giá, tồn kho)
CREATE TABLE Hoa (
    MaHoa NVARCHAR(20) NOT NULL,
    TenHoa NVARCHAR(150) NOT NULL,
    DonViTinh NVARCHAR(50) NOT NULL DEFAULT N'Bông',
    DonGia DECIMAL(18, 2) NOT NULL DEFAULT 0,
    SoLuongTon INT NOT NULL DEFAULT 0,
    MaDM NVARCHAR(20) NOT NULL,
    CONSTRAINT PK_Hoa PRIMARY KEY (MaHoa),
    CONSTRAINT FK_Hoa_DanhMucHoa FOREIGN KEY (MaDM) 
        REFERENCES DanhMucHoa(MaDM) ON UPDATE CASCADE ON DELETE NO ACTION,
    CONSTRAINT CK_Hoa_DonGia CHECK (DonGia >= 0),
    CONSTRAINT CK_Hoa_SoLuongTon CHECK (SoLuongTon >= 0)
);
GO

-- Bảng 3: KhachHang (Khách hàng đặt điện hoa)
CREATE TABLE KhachHang (
    MaKH NVARCHAR(20) NOT NULL,
    HoTenKH NVARCHAR(150) NOT NULL,
    SoDienThoai NVARCHAR(20) NOT NULL,
    DiaChi NVARCHAR(300) NULL,
    Email NVARCHAR(100) NULL,
    CONSTRAINT PK_KhachHang PRIMARY KEY (MaKH),
    CONSTRAINT UQ_KhachHang_SDT UNIQUE (SoDienThoai)
);
GO

-- Bảng 4: NhanVien (Nhân sự & Tài khoản đăng nhập hệ thống)
CREATE TABLE NhanVien (
    MaNV NVARCHAR(20) NOT NULL,
    HoTenNV NVARCHAR(150) NOT NULL,
    SoDienThoai NVARCHAR(20) NULL,
    ChucVu NVARCHAR(100) NOT NULL DEFAULT N'Nhân viên bán hàng',
    TenDangNhap NVARCHAR(50) NOT NULL,
    MatKhau NVARCHAR(100) NOT NULL,
    QuyenHan NVARCHAR(20) NOT NULL DEFAULT N'User', -- 'Admin' | 'User'
    CONSTRAINT PK_NhanVien PRIMARY KEY (MaNV),
    CONSTRAINT UQ_NhanVien_TenDangNhap UNIQUE (TenDangNhap),
    CONSTRAINT CK_NhanVien_QuyenHan CHECK (QuyenHan IN (N'Admin', N'User'))
);
GO

-- Bảng 5: KhuyenMai (Chương trình ưu đãi, giảm giá điện hoa)
CREATE TABLE KhuyenMai (
    MaKM NVARCHAR(20) NOT NULL,
    TenKM NVARCHAR(150) NOT NULL,
    PhanTramGiam DECIMAL(5, 2) NOT NULL DEFAULT 0,
    NgayBatDau DATE NOT NULL,
    NgayKetThuc DATE NOT NULL,
    DieuKienToiThieu DECIMAL(18, 2) NOT NULL DEFAULT 0,
    CONSTRAINT PK_KhuyenMai PRIMARY KEY (MaKM),
    CONSTRAINT CK_KhuyenMai_PhanTram CHECK (PhanTramGiam >= 0 AND PhanTramGiam <= 100),
    CONSTRAINT CK_KhuyenMai_Ngay CHECK (NgayKetThuc >= NgayBatDau),
    CONSTRAINT CK_KhuyenMai_DieuKien CHECK (DieuKienToiThieu >= 0)
);
GO

-- Bảng 6: DonHang (Đơn đặt điện hoa - Master)
CREATE TABLE DonHang (
    MaDH NVARCHAR(20) NOT NULL,
    NgayDat DATETIME NOT NULL DEFAULT GETDATE(),
    NgayGiao DATETIME NOT NULL,
    DiaChiGiao NVARCHAR(300) NOT NULL,
    NguoiNhan NVARCHAR(150) NOT NULL,
    SDTNguoiNhan NVARCHAR(20) NOT NULL,
    LoiChuc NVARCHAR(500) NULL,
    TrangThai NVARCHAR(50) NOT NULL DEFAULT N'Chờ xử lý', -- 'Chờ xử lý', 'Đang giao', 'Hoàn thành', 'Đã hủy'
    TongTien DECIMAL(18, 2) NOT NULL DEFAULT 0,
    MaKH NVARCHAR(20) NOT NULL,
    MaNV NVARCHAR(20) NOT NULL,
    MaKM NVARCHAR(20) NULL,
    CONSTRAINT PK_DonHang PRIMARY KEY (MaDH),
    CONSTRAINT FK_DonHang_KhachHang FOREIGN KEY (MaKH) REFERENCES KhachHang(MaKH),
    CONSTRAINT FK_DonHang_NhanVien FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV),
    CONSTRAINT FK_DonHang_KhuyenMai FOREIGN KEY (MaKM) REFERENCES KhuyenMai(MaKM),
    CONSTRAINT CK_DonHang_TongTien CHECK (TongTien >= 0)
);
GO

-- Bảng 7: ChiTietDonHang (Chi tiết giỏ hoa trong từng đơn - Detail)
CREATE TABLE ChiTietDonHang (
    MaDH NVARCHAR(20) NOT NULL,
    MaHoa NVARCHAR(20) NOT NULL,
    SoLuong INT NOT NULL DEFAULT 1,
    DonGiaBan DECIMAL(18, 2) NOT NULL DEFAULT 0,
    GhiChu NVARCHAR(300) NULL,
    CONSTRAINT PK_ChiTietDonHang PRIMARY KEY (MaDH, MaHoa),
    CONSTRAINT FK_ChiTietDonHang_DonHang FOREIGN KEY (MaDH) 
        REFERENCES DonHang(MaDH) ON DELETE CASCADE,
    CONSTRAINT FK_ChiTietDonHang_Hoa FOREIGN KEY (MaHoa) 
        REFERENCES Hoa(MaHoa),
    CONSTRAINT CK_ChiTietDonHang_SoLuong CHECK (SoLuong > 0),
    CONSTRAINT CK_ChiTietDonHang_DonGiaBan CHECK (DonGiaBan >= 0)
);
GO

-- =========================================================================================
-- PHẦN 2: TẠO CÁC VIEW THỐNG KÊ & THEO DÕI ĐƠN HÀNG
-- =========================================================================================

-- View 1: Danh sách đơn hàng chưa xử lý / đang giao hàng
IF OBJECT_ID('dbo.V_DanhSachChuaXuLy', 'V') IS NOT NULL
    DROP VIEW dbo.V_DanhSachChuaXuLy;
GO

CREATE VIEW dbo.V_DanhSachChuaXuLy AS
SELECT 
    dh.MaDH AS [Mã ĐH],
    kh.HoTenKH AS [Khách Hàng],
    dh.NguoiNhan AS [Người Nhận],
    dh.SDTNguoiNhan AS [SĐT Nhận],
    dh.NgayDat AS [Ngày Đặt],
    dh.NgayGiao AS [Ngày Giao Hẹn],
    dh.DiaChiGiao AS [Địa Chỉ Giao],
    dh.TongTien AS [Tổng Tiền (VNĐ)],
    dh.TrangThai AS [Trạng Thái],
    nv.HoTenNV AS [Nhân Viên Phụ Trách]
FROM DonHang dh
INNER JOIN KhachHang kh ON dh.MaKH = kh.MaKH
INNER JOIN NhanVien nv ON dh.MaNV = nv.MaNV
WHERE dh.TrangThai IN (N'Chờ xử lý', N'Đang giao');
GO

-- View 2: Bảng số liệu thống kê tổng hợp toàn hệ thống
IF OBJECT_ID('dbo.V_ThongKeTongHop', 'V') IS NOT NULL
    DROP VIEW dbo.V_ThongKeTongHop;
GO

CREATE VIEW dbo.V_ThongKeTongHop AS
SELECT 
    (SELECT COUNT(*) FROM DonHang) AS [Tổng Đơn Hàng],
    (SELECT COUNT(*) FROM DonHang WHERE TrangThai = N'Hoàn thành') AS [Đơn Hoàn Thành],
    (SELECT COUNT(*) FROM DonHang WHERE TrangThai = N'Chờ xử lý') AS [Đơn Chờ Xử Lý],
    (SELECT COUNT(*) FROM DonHang WHERE TrangThai = N'Đang giao') AS [Đơn Đang Giao],
    (SELECT COUNT(*) FROM DonHang WHERE TrangThai = N'Đã hủy') AS [Đơn Đã Hủy],
    ISNULL((SELECT SUM(TongTien) FROM DonHang WHERE TrangThai = N'Hoàn thành'), 0) AS [Doanh Thu Hoàn Tất],
    (SELECT COUNT(*) FROM KhachHang) AS [Tổng Khách Hàng],
    (SELECT COUNT(*) FROM Hoa) AS [Tổng Mặt Hàng Hoa],
    (SELECT COUNT(*) FROM NhanVien) AS [Tổng Nhân Sự];
GO

-- =========================================================================================
-- PHẦN 3: TẠO FUNCTION TÍNH TỔNG GIÁ TRỊ ĐƠN HÀNG CÓ KHUYẾN MÃI
-- =========================================================================================

IF OBJECT_ID('dbo.F_TinhTongGiaTri', 'FN') IS NOT NULL
    DROP FUNCTION dbo.F_TinhTongGiaTri;
GO

CREATE FUNCTION dbo.F_TinhTongGiaTri (@MaDH NVARCHAR(20))
RETURNS DECIMAL(18, 2)
AS
BEGIN
    DECLARE @TongTienGoc DECIMAL(18, 2) = 0;
    DECLARE @PhanTramGiam DECIMAL(5, 2) = 0;
    DECLARE @DieuKienToiThieu DECIMAL(18, 2) = 0;
    DECLARE @TongThanhToan DECIMAL(18, 2) = 0;
    DECLARE @MaKM NVARCHAR(20) = NULL;

    -- 1. Tính tổng giá trị gốc từ bảng ChiTietDonHang
    SELECT @TongTienGoc = ISNULL(SUM(SoLuong * DonGiaBan), 0)
    FROM ChiTietDonHang
    WHERE MaDH = @MaDH;

    -- 2. Lấy thông tin mã khuyến mãi của đơn hàng
    SELECT @MaKM = MaKM 
    FROM DonHang 
    WHERE MaDH = @MaDH;

    -- 3. Nếu có áp dụng mã khuyến mãi, kiểm tra điều kiện áp dụng
    IF @MaKM IS NOT NULL
    BEGIN
        SELECT 
            @PhanTramGiam = ISNULL(PhanTramGiam, 0),
            @DieuKienToiThieu = ISNULL(DieuKienToiThieu, 0)
        FROM KhuyenMai
        WHERE MaKM = @MaKM;

        -- Nếu tổng tiền gốc đạt điều kiện tối thiểu thì giảm giá
        IF @TongTienGoc >= @DieuKienToiThieu
        BEGIN
            SET @TongThanhToan = @TongTienGoc - (@TongTienGoc * (@PhanTramGiam / 100.0));
        END
        ELSE
        BEGIN
            SET @TongThanhToan = @TongTienGoc;
        END
    END
    ELSE
    BEGIN
        SET @TongThanhToan = @TongTienGoc;
    END

    RETURN @TongThanhToan;
END;
GO

-- =========================================================================================
-- PHẦN 4: TẠO STORED PROCEDURE QUẢN LÝ HOA (THÊM / SỬA / XÓA)
-- =========================================================================================

IF OBJECT_ID('dbo.P_ThemSuaXoa_Hoa', 'P') IS NOT NULL
    DROP PROCEDURE dbo.P_ThemSuaXoa_Hoa;
GO

CREATE PROCEDURE dbo.P_ThemSuaXoa_Hoa
    @Action NVARCHAR(10),        -- 'INSERT', 'UPDATE', 'DELETE'
    @MaHoa NVARCHAR(20),
    @TenHoa NVARCHAR(150) = NULL,
    @DonViTinh NVARCHAR(50) = NULL,
    @DonGia DECIMAL(18, 2) = NULL,
    @SoLuongTon INT = NULL,
    @MaDM NVARCHAR(20) = NULL,
    @KetQua NVARCHAR(250) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        IF @Action = 'INSERT'
        BEGIN
            IF EXISTS (SELECT 1 FROM Hoa WHERE MaHoa = @MaHoa)
            BEGIN
                SET @KetQua = N'Thất bại: Mã hoa [' + @MaHoa + N'] đã tồn tại!';
                RETURN;
            END

            IF NOT EXISTS (SELECT 1 FROM DanhMucHoa WHERE MaDM = @MaDM)
            BEGIN
                SET @KetQua = N'Thất bại: Danh mục hoa [' + @MaDM + N'] không tồn tại!';
                RETURN;
            END

            INSERT INTO Hoa (MaHoa, TenHoa, DonViTinh, DonGia, SoLuongTon, MaDM)
            VALUES (@MaHoa, @TenHoa, @DonViTinh, @DonGia, @SoLuongTon, @MaDM);

            SET @KetQua = N'Thành công: Đã thêm mới hoa [' + @TenHoa + N']!';
        END
        ELSE IF @Action = 'UPDATE'
        BEGIN
            IF NOT EXISTS (SELECT 1 FROM Hoa WHERE MaHoa = @MaHoa)
            BEGIN
                SET @KetQua = N'Thất bại: Không tìm thấy mã hoa [' + @MaHoa + N']!';
                RETURN;
            END

            IF NOT EXISTS (SELECT 1 FROM DanhMucHoa WHERE MaDM = @MaDM)
            BEGIN
                SET @KetQua = N'Thất bại: Danh mục hoa [' + @MaDM + N'] không hợp lệ!';
                RETURN;
            END

            UPDATE Hoa
            SET TenHoa = @TenHoa,
                DonViTinh = @DonViTinh,
                DonGia = @DonGia,
                SoLuongTon = @SoLuongTon,
                MaDM = @MaDM
            WHERE MaHoa = @MaHoa;

            SET @KetQua = N'Thành công: Đã cập nhật thông tin hoa [' + @TenHoa + N']!';
        END
        ELSE IF @Action = 'DELETE'
        BEGIN
            IF NOT EXISTS (SELECT 1 FROM Hoa WHERE MaHoa = @MaHoa)
            BEGIN
                SET @KetQua = N'Thất bại: Mã hoa [' + @MaHoa + N'] không tồn tại để xóa!';
                RETURN;
            END

            -- Kiểm tra xem mặt hàng đã phát sinh giao dịch trong đơn hàng chưa
            IF EXISTS (SELECT 1 FROM ChiTietDonHang WHERE MaHoa = @MaHoa)
            BEGIN
                SET @KetQua = N'Thất bại: Hoa [' + @MaHoa + N'] đã có trong lịch sử đơn hàng, không được phép xóa!';
                RETURN;
            END

            DELETE FROM Hoa WHERE MaHoa = @MaHoa;
            SET @KetQua = N'Thành công: Đã xóa hoa [' + @MaHoa + N']!';
        END
        ELSE
        BEGIN
            SET @KetQua = N'Thất bại: Thao tác không hợp lệ (chỉ hỗ trợ INSERT, UPDATE, DELETE)!';
        END
    END TRY
    BEGIN CATCH
        SET @KetQua = N'Lỗi thực thi SQL: ' + ERROR_MESSAGE();
    END CATCH
END;
GO

-- =========================================================================================
-- PHẦN 5: TẠO CÁC TRIGGER RÀNG BUỘC TOÀN VẸN & KIỂM TRA TỒN KHO TỰ ĐỘNG
-- =========================================================================================

-- Trigger 1: Kiểm tra tính hợp lệ của Đơn hàng (Ngày giao >= Ngày đặt, Mã KM còn hạn)
IF OBJECT_ID('dbo.TRG_Check_DonHang', 'TR') IS NOT NULL
    DROP TRIGGER dbo.TRG_Check_DonHang;
GO

CREATE TRIGGER dbo.TRG_Check_DonHang
ON dbo.DonHang
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    -- 1. Kiểm tra ngày giao hàng phải lớn hơn hoặc bằng ngày đặt hàng
    IF EXISTS (
        SELECT 1 FROM inserted
        WHERE NgayGiao < NgayDat
    )
    BEGIN
        RAISERROR (N'Lỗi nghiệp vụ: Ngày giao hàng phải lớn hơn hoặc bằng ngày đặt hàng!', 16, 1);
        ROLLBACK TRANSACTION;
        RETURN;
    END

    -- 2. Kiểm tra nếu có mã khuyến mãi: Ngày đặt hàng phải nằm trong thời hạn áp dụng
    IF EXISTS (
        SELECT 1 
        FROM inserted i
        INNER JOIN KhuyenMai km ON i.MaKM = km.MaKM
        WHERE CAST(i.NgayDat AS DATE) < km.NgayBatDau 
           OR CAST(i.NgayDat AS DATE) > km.NgayKetThuc
    )
    BEGIN
        RAISERROR (N'Lỗi khuyến mãi: Mã khuyến mãi đã hết hạn hoặc chưa đến ngày bắt đầu áp dụng!', 16, 1);
        ROLLBACK TRANSACTION;
        RETURN;
    END
END;
GO

-- Trigger 2: Kiểm tra số lượng tồn kho và cập nhật kho tự động khi tạo/sửa/hủy chi tiết đơn
IF OBJECT_ID('dbo.TRG_CheckAndUpdateStock_ChiTietDonHang', 'TR') IS NOT NULL
    DROP TRIGGER dbo.TRG_CheckAndUpdateStock_ChiTietDonHang;
GO

CREATE TRIGGER dbo.TRG_CheckAndUpdateStock_ChiTietDonHang
ON dbo.ChiTietDonHang
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    -- TRƯỜNG HỢP 1: THÊM MẶT HÀNG VÀO ĐƠN (INSERT)
    IF EXISTS (SELECT 1 FROM inserted) AND NOT EXISTS (SELECT 1 FROM deleted)
    BEGIN
        -- Kiểm tra tồn kho
        IF EXISTS (
            SELECT 1 
            FROM inserted i
            INNER JOIN Hoa h ON i.MaHoa = h.MaHoa
            WHERE i.SoLuong > h.SoLuongTon
        )
        BEGIN
            RAISERROR (N'Lỗi tồn kho: Số lượng đặt mua vượt quá số lượng tồn kho hiện có của cửa hàng!', 16, 1);
            ROLLBACK TRANSACTION;
            RETURN;
        END

        -- Tự động trừ số lượng tồn kho
        UPDATE Hoa
        SET SoLuongTon = Hoa.SoLuongTon - i.SoLuong
        FROM Hoa
        INNER JOIN inserted i ON Hoa.MaHoa = i.MaHoa;
    END

    -- TRƯỜNG HỢP 2: XÓA MẶT HÀNG KHỎI ĐƠN (DELETE) -> HOÀN TRẢ TỒN KHO
    IF EXISTS (SELECT 1 FROM deleted) AND NOT EXISTS (SELECT 1 FROM inserted)
    BEGIN
        UPDATE Hoa
        SET SoLuongTon = Hoa.SoLuongTon + d.SoLuong
        FROM Hoa
        INNER JOIN deleted d ON Hoa.MaHoa = d.MaHoa;
    END

    -- TRƯỜNG HỢP 3: CẬP NHẬT SỐ LƯỢNG MẶT HÀNG TRONG ĐƠN (UPDATE)
    IF EXISTS (SELECT 1 FROM inserted) AND EXISTS (SELECT 1 FROM deleted)
    BEGIN
        -- Kiểm tra số lượng chênh lệch có vượt tồn kho hiện tại không
        IF EXISTS (
            SELECT 1 
            FROM inserted i
            INNER JOIN deleted d ON i.MaDH = d.MaDH AND i.MaHoa = d.MaHoa
            INNER JOIN Hoa h ON i.MaHoa = h.MaHoa
            WHERE (i.SoLuong - d.SoLuong) > h.SoLuongTon
        )
        BEGIN
            RAISERROR (N'Lỗi tồn kho: Số lượng tăng thêm vượt quá số lượng tồn kho có sẵn trong kho!', 16, 1);
            ROLLBACK TRANSACTION;
            RETURN;
        END

        -- Cập nhật chênh lệch tồn kho
        UPDATE Hoa
        SET SoLuongTon = Hoa.SoLuongTon - (i.SoLuong - d.SoLuong)
        FROM Hoa
        INNER JOIN inserted i ON Hoa.MaHoa = i.MaHoa
        INNER JOIN deleted d ON i.MaDH = d.MaDH AND i.MaHoa = d.MaHoa;
    END
END;
GO

-- =========================================================================================
-- PHẦN 6: THIẾT LẬP BẢO MẬT & PHÂN QUYỀN SQL SERVER (Flora_Admin & Flora_User)
-- =========================================================================================

-- 1. Tạo SQL Server Login ở cấp độ Server (nếu chưa có hoặc cập nhật lại mật khẩu)
USE master;
GO

IF EXISTS (SELECT name FROM sys.server_principals WHERE name = 'Flora_Admin')
BEGIN
    ALTER LOGIN Flora_Admin WITH PASSWORD = N'FloraAdmin@2026!', CHECK_POLICY = OFF;
    ALTER LOGIN Flora_Admin ENABLE;
END
ELSE
BEGIN
    CREATE LOGIN Flora_Admin WITH PASSWORD = N'FloraAdmin@2026!', CHECK_POLICY = OFF;
END
GO

IF EXISTS (SELECT name FROM sys.server_principals WHERE name = 'Flora_User')
BEGIN
    ALTER LOGIN Flora_User WITH PASSWORD = N'FloraUser@2026!', CHECK_POLICY = OFF;
    ALTER LOGIN Flora_User ENABLE;
END
ELSE
BEGIN
    CREATE LOGIN Flora_User WITH PASSWORD = N'FloraUser@2026!', CHECK_POLICY = OFF;
END
GO

-- 2. Tạo User trong cơ sở dữ liệu FloraShopDB và gán quyền
USE FloraShopDB;
GO

IF NOT EXISTS (SELECT name FROM sys.database_principals WHERE name = 'Flora_Admin')
BEGIN
    CREATE USER Flora_Admin FOR LOGIN Flora_Admin;
END
GO
ALTER ROLE db_owner ADD MEMBER Flora_Admin;
GO

IF NOT EXISTS (SELECT name FROM sys.database_principals WHERE name = 'Flora_User')
BEGIN
    CREATE USER Flora_User FOR LOGIN Flora_User;
END
GO

-- Cấp quyền nghiệp vụ cơ bản cho Flora_User (Nhân viên)
GRANT CONNECT TO Flora_User;
GRANT SELECT, INSERT, UPDATE ON dbo.DanhMucHoa TO Flora_User;
GRANT SELECT, INSERT, UPDATE ON dbo.Hoa TO Flora_User;
GRANT SELECT, INSERT, UPDATE ON dbo.KhachHang TO Flora_User;
GRANT SELECT, INSERT, UPDATE ON dbo.KhuyenMai TO Flora_User;
GRANT SELECT, INSERT, UPDATE ON dbo.DonHang TO Flora_User;
GRANT SELECT, INSERT, UPDATE ON dbo.ChiTietDonHang TO Flora_User;

-- Cấp quyền truy cập Views & Stored Procedures / Functions
GRANT SELECT ON dbo.V_DanhSachChuaXuLy TO Flora_User;
GRANT SELECT ON dbo.V_ThongKeTongHop TO Flora_User;
GRANT EXECUTE ON dbo.P_ThemSuaXoa_Hoa TO Flora_User;
GRANT EXECUTE ON dbo.F_TinhTongGiaTri TO Flora_User;

-- THIẾT LẬP BẢO MẬT THEO YÊU CẦU ĐỒ ÁN:
-- Cấm xóa trực tiếp trên bảng Hoa, DonHang, ChiTietDonHang (minh họa lỗi SqlException DENY DELETE)
DENY DELETE ON dbo.Hoa TO Flora_User;
DENY DELETE ON dbo.DonHang TO Flora_User;
DENY DELETE ON dbo.ChiTietDonHang TO Flora_User;

-- Cấm hoàn toàn quyền xem, sửa, xóa danh mục Nhân viên đối với tài khoản Flora_User
DENY SELECT, INSERT, UPDATE, DELETE ON dbo.NhanVien TO Flora_User;
GO

-- =========================================================================================
-- PHẦN 7: CHÈN DỮ LIỆU MẪU ĐỂ CHẠY THỬ NGAY LẬP TỨC (MỖI BẢNG >= 5 DÒNG)
-- =========================================================================================

-- Tạm ngắt trigger để nạp dữ liệu mẫu ban đầu chính xác
DISABLE TRIGGER dbo.TRG_CheckAndUpdateStock_ChiTietDonHang ON dbo.ChiTietDonHang;
DISABLE TRIGGER dbo.TRG_Check_DonHang ON dbo.DonHang;
GO

-- 1. Chèn mẫu bảng DanhMucHoa (5 dòng)
INSERT INTO DanhMucHoa (MaDM, TenDM, MoTa) VALUES
('DM01', N'Hoa Bó Tươi Cao Cấp', N'Các mẫu bó hoa tươi kết hợp hoa hồng, hoa baby, hoa cẩm chướng tặng sinh nhật'),
('DM02', N'Lẵng Hoa Khai Trương', N'Kệ và giỏ hoa đứng mừng khai trương, thăng chức sang trọng'),
('DM03', N'Hoa Cưới Cầm Tay Cô Dâu', N'Bó hoa cưới tone trắng, pastel, hoa tulip và mẫu đơn tinh tế'),
('DM04', N'Hoa Lan Hồ Điệp Quý Phái', N'Chậu lan hồ điệp xuất xứ Đà Lạt nhiều cành tài lộc mừng tân gia'),
('DM05', N'Hoa Chia Buồn Tang Lễ', N'Vòng hoa trang nghiêm bày tỏ lòng thành kính và sẻ chia');
GO

-- 2. Chèn mẫu bảng Hoa (10 dòng)
INSERT INTO Hoa (MaHoa, TenHoa, DonViTinh, DonGia, SoLuongTon, MaDM) VALUES
('HOA01', N'Hoa Hồng Đỏ Ecuador', N'Cành', 45000, 150, 'DM01'),
('HOA02', N'Hoa Tulip Trắng Hà Lan', N'Bông', 65000, 80, 'DM03'),
('HOA03', N'Hoa Hướng Dương Rực Rỡ', N'Bông', 35000, 120, 'DM02'),
('HOA04', N'Lan Hồ Điệp Tím Đại Cát', N'Cành', 250000, 45, 'DM04'),
('HOA05', N'Hoa Baby Trắng Nhập Khẩu', N'Bó nhỏ', 120000, 60, 'DM01'),
('HOA06', N'Hoa Cúc Mẫu Đơn Xanh Biển', N'Bông', 85000, 75, 'DM02'),
('HOA07', N'Cẩm Tú Cầu Đà Lạt Lam Ngọc', N'Bông', 55000, 90, 'DM01'),
('HOA08', N'Hoa Ly Vàng Hoàng Gia', N'Cành', 70000, 65, 'DM05'),
('HOA09', N'Hoa Hồng Cam Spirit Ngoại', N'Cành', 48000, 110, 'DM01'),
('HOA10', N'Lan Hồ Điệp Vàng Tài Lộc', N'Cành', 260000, 40, 'DM04');
GO

-- 3. Chèn mẫu bảng KhachHang (6 dòng)
INSERT INTO KhachHang (MaKH, HoTenKH, SoDienThoai, DiaChi, Email) VALUES
('KH01', N'Nguyễn Hoàng Anh', '0912345678', N'123 Lê Duẩn, Quận Hải Châu, Đà Nẵng', 'hoanganh@gmail.com'),
('KH02', N'Trần Thị Mai Phương', '0987654321', N'45 Nguyễn Thị Minh Khai, Quận 1, TP.HCM', 'maiphuong@outlook.com'),
('KH03', N'Phạm Quang Dũng', '0905123987', N'88 Hoàng Hoa Thám, Ba Đình, Hà Nội', 'quangdung.pham@yahoo.com'),
('KH04', N'Lê Minh Trang', '0935888999', N'12 Trần Phú, Nha Trang, Khánh Hòa', 'minhtrang88@gmail.com'),
('KH05', N'Võ Quốc Bảo', '0978111222', N'76 Hùng Vương, Ninh Kiều, Cần Thơ', 'baovo@gmail.com'),
('KH06', N'Đặng Thanh Thảo', '0944556677', N'29 Phan Chu Trinh, TP Huế', 'thanhthao_flora@gmail.com');
GO

-- 4. Chèn mẫu bảng NhanVien (5 dòng)
INSERT INTO NhanVien (MaNV, HoTenNV, SoDienThoai, ChucVu, TenDangNhap, MatKhau, QuyenHan) VALUES
('NV01', N'Lê Quản Trị', '0901000001', N'Cửa hàng trưởng', 'admin', '123456', 'Admin'),
('NV02', N'Nguyễn Bích Lan', '0901000002', N'Nhân viên bán hàng', 'nv_lan', '123456', 'User'),
('NV03', N'Trần Hữu Minh', '0901000003', N'Nghệ nhân cắm hoa', 'nv_minh', '123456', 'User'),
('NV04', N'Võ Thu Hương', '0901000004', N'Tư vấn viên điện hoa', 'nv_huong', '123456', 'User'),
('NV05', N'Phạm Đức Toàn', '0901000005', N'Quản lý kỹ thuật hệ thống', 'admin_toan', '123456', 'Admin');
GO

-- 5. Chèn mẫu bảng KhuyenMai (5 dòng)
INSERT INTO KhuyenMai (MaKM, TenKM, PhanTramGiam, NgayBatDau, NgayKetThuc, DieuKienToiThieu) VALUES
('KM_TRIAN', N'Ưu Đãi Tri Ân Khách Hàng', 10.00, '2026-01-01', '2026-12-31', 300000),
('KM_VALENTINE', N'Lễ Tình Nhân Hoa Hồng Trao Tay', 15.00, '2026-02-01', '2026-02-28', 500000),
('KM_KHAITRUONG', N'Giảm Giá Lẵng Hoa Khai Trương', 8.00, '2026-03-01', '2026-12-31', 1000000),
('KM_HET_HAN', N'Mã Giảm Giá Đã Hết Hạn 2025', 20.00, '2025-01-01', '2025-12-31', 200000),
('KM_VIP', N'Đặc Quyền Khách Hàng Thân Thiết VIP', 12.00, '2026-01-01', '2026-12-31', 800000);
GO

-- 6. Chèn mẫu bảng DonHang (5 dòng)
INSERT INTO DonHang (MaDH, NgayDat, NgayGiao, DiaChiGiao, NguoiNhan, SDTNguoiNhan, LoiChuc, TrangThai, TongTien, MaKH, MaNV, MaKM) VALUES
('DH01', '2026-10-25 09:30:00', '2026-10-25 15:00:00', N'123 Lê Duẩn, Q. Hải Châu, Đà Nẵng', N'Nguyễn Hoàng Anh', '0912345678', N'Chúc mừng sinh nhật em gái yêu quý!', N'Hoàn thành', 450000, 'KH01', 'NV02', 'KM_TRIAN'),
('DH02', '2026-10-26 14:00:00', '2026-10-27 10:00:00', N'45 Nguyễn Thị Minh Khai, Q1, TP.HCM', N'Trần Thị Mai Phương', '0987654321', N'Kính mừng ngày nhà giáo hạnh phúc!', N'Đang giao', 1250000, 'KH02', 'NV02', NULL),
('DH03', '2026-10-27 08:15:00', '2026-10-28 09:00:00', N'Toà nhà Landmark 72, Cầu Giấy, Hà Nội', N'Giám đốc Phạm Công ty Tân Việt', '0905123987', N'Chúc mừng công ty khai trương hồng phát, vạn sự hanh thông!', N'Chờ xử lý', 1840000, 'KH03', 'NV03', 'KM_KHAITRUONG'),
('DH04', '2026-10-27 10:45:00', '2026-10-27 16:30:00', N'12 Trần Phú, Nha Trang', N'Chị Minh Trang', '0935888999', N'Mãi mãi rạng rỡ và thành công bạn nhé!', N'Chờ xử lý', 650000, 'KH04', 'NV04', NULL),
('DH05', '2026-10-24 11:20:00', '2026-10-24 18:00:00', N'76 Hùng Vương, Cần Thơ', N'Võ Quốc Bảo', '0978111222', N'Gửi lời chia buồn sâu sắc cùng gia quyến', N'Đã hủy', 0, 'KH05', 'NV02', NULL);
GO

-- 7. Chèn mẫu bảng ChiTietDonHang (12 dòng)
INSERT INTO ChiTietDonHang (MaDH, MaHoa, SoLuong, DonGiaBan, GhiChu) VALUES
('DH01', 'HOA01', 10, 45000, N'Bó giấy kraft phong cách vintage'),
('DH01', 'HOA05', 1, 120000, N'Phối thêm hoa baby điểm viền'),
('DH02', 'HOA04', 5, 250000, N'Cắm chậu sứ trắng mừng tân gia'),
('DH03', 'HOA03', 20, 35000, N'Cắm kệ đứng 2 tầng hoa hướng dương'),
('DH03', 'HOA06', 10, 85000, N'Điểm cúc mẫu đơn xung quanh'),
('DH03', 'HOA07', 8, 55000, N'Phối cẩm tú cầu lam ngọc chân kệ'),
('DH04', 'HOA02', 10, 65000, N'Bó hoa tulip trắng thắt ruy băng xanh'),
('DH05', 'HOA08', 5, 70000, N'Đã hủy do khách đổi lịch trình');
GO

-- Cập nhật lại tổng tiền chính xác của các đơn hàng thông qua Function F_TinhTongGiaTri
UPDATE DonHang 
SET TongTien = dbo.F_TinhTongGiaTri(MaDH)
WHERE TrangThai <> N'Đã hủy';
GO

-- Bật lại các trigger kiểm tra nghiệp vụ
ENABLE TRIGGER dbo.TRG_Check_DonHang ON dbo.DonHang;
ENABLE TRIGGER dbo.TRG_CheckAndUpdateStock_ChiTietDonHang ON dbo.ChiTietDonHang;
GO


