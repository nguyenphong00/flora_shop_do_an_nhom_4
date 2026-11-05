using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace FloraShop
{
    public partial class FrmLapDonHang : Form
    {
        private DataTable dtChiTiet = new DataTable();
        private DataTable dtHoaList = new DataTable();
        private DataTable dtKhuyenMaiList = new DataTable();

        private decimal tongTienGoc = 0;
        private decimal phanTramGiam = 0;
        private decimal dieuKienToiThieu = 0;
        private decimal tienGiam = 0;
        private decimal tongThanhToan = 0;

        public FrmLapDonHang()
        {
            InitializeComponent();
        }

        private void FrmLapDonHang_Load(object sender, EventArgs e)
        {
            KhoiTaoBangChiTiet();
            TaiDanhSachKhachHang();
            TaiDanhSachKhuyenMai();
            TaiDanhSachHoa();
            cboTrangThai.SelectedIndex = 0; // "Chờ xử lý"
            cboLocTrangThai.SelectedIndex = 0;

            SinhMaDonHangTuDong();
            TaiDanhSachDonHang();
        }

        /// <summary>
        /// Khởi tạo cấu trúc bảng DataTable giỏ hàng chi tiết (Sub Form)
        /// </summary>
        private void KhoiTaoBangChiTiet()
        {
            dtChiTiet = new DataTable();
            dtChiTiet.Columns.Add("MaHoa", typeof(string));
            dtChiTiet.Columns.Add("TenHoa", typeof(string));
            dtChiTiet.Columns.Add("DonViTinh", typeof(string));
            dtChiTiet.Columns.Add("DonGiaBan", typeof(decimal));
            dtChiTiet.Columns.Add("SoLuong", typeof(int));
            dtChiTiet.Columns.Add("ThanhTien", typeof(decimal));
            dtChiTiet.Columns.Add("GhiChu", typeof(string));

            dgvChiTietDonHang.DataSource = dtChiTiet;

            if (dgvChiTietDonHang.Columns.Contains("MaHoa"))
            {
                dgvChiTietDonHang.Columns["MaHoa"].HeaderText = "Mã Hoa";
                dgvChiTietDonHang.Columns["MaHoa"].Width = 90;
            }
            if (dgvChiTietDonHang.Columns.Contains("TenHoa"))
            {
                dgvChiTietDonHang.Columns["TenHoa"].HeaderText = "Tên Mặt Hàng Hoa";
                dgvChiTietDonHang.Columns["TenHoa"].Width = 220;
            }
            if (dgvChiTietDonHang.Columns.Contains("DonViTinh"))
            {
                dgvChiTietDonHang.Columns["DonViTinh"].HeaderText = "ĐVT";
                dgvChiTietDonHang.Columns["DonViTinh"].Width = 70;
                dgvChiTietDonHang.Columns["DonViTinh"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            if (dgvChiTietDonHang.Columns.Contains("DonGiaBan"))
            {
                dgvChiTietDonHang.Columns["DonGiaBan"].HeaderText = "Đơn Giá Bán (đ)";
                dgvChiTietDonHang.Columns["DonGiaBan"].DefaultCellStyle.Format = "N0";
                dgvChiTietDonHang.Columns["DonGiaBan"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvChiTietDonHang.Columns["DonGiaBan"].Width = 120;
            }
            if (dgvChiTietDonHang.Columns.Contains("SoLuong"))
            {
                dgvChiTietDonHang.Columns["SoLuong"].HeaderText = "Số Lượng";
                dgvChiTietDonHang.Columns["SoLuong"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvChiTietDonHang.Columns["SoLuong"].Width = 90;
            }
            if (dgvChiTietDonHang.Columns.Contains("ThanhTien"))
            {
                dgvChiTietDonHang.Columns["ThanhTien"].HeaderText = "Thành Tiền (đ)";
                dgvChiTietDonHang.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
                dgvChiTietDonHang.Columns["ThanhTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvChiTietDonHang.Columns["ThanhTien"].Width = 140;
            }
            if (dgvChiTietDonHang.Columns.Contains("GhiChu"))
            {
                dgvChiTietDonHang.Columns["GhiChu"].HeaderText = "Ghi Chú Đơn Hoa";
                dgvChiTietDonHang.Columns["GhiChu"].Width = 200;
            }
        }

        /// <summary>
        /// Sinh mã đơn hàng mới tự động (ví dụ: DH06, DH07...)
        /// </summary>
        private void SinhMaDonHangTuDong()
        {
            try
            {
                using (SqlConnection conn = Session.CreateConnection())
                {
                    conn.Open();
                    string sql = "SELECT COUNT(*) FROM DonHang";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        int count = Convert.ToInt32(cmd.ExecuteScalar()) + 1;
                        txtMaDH.Text = $"DH{count:D2}";
                    }
                }
            }
            catch
            {
                txtMaDH.Text = "DH" + DateTime.Now.ToString("yyMMddHHmm");
            }

            dtpNgayDat.Value = DateTime.Now;
            dtpNgayGiao.Value = DateTime.Now.AddHours(4); // Mặc định giao sau 4 tiếng
        }

        private void btnSinhMaDH_Click(object sender, EventArgs e)
        {
            SinhMaDonHangTuDong();
        }

        /// <summary>
        /// Tải danh sách khách hàng vào ComboBox
        /// </summary>
        private void TaiDanhSachKhachHang()
        {
            try
            {
                using (SqlConnection conn = Session.CreateConnection())
                {
                    conn.Open();
                    string sql = "SELECT MaKH, HoTenKH, SoDienThoai, DiaChi, HoTenKH + ' - ' + SoDienThoai AS DisplayText FROM KhachHang ORDER BY HoTenKH";
                    using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        cboKhachHang.DataSource = dt;
                        cboKhachHang.DisplayMember = "DisplayText";
                        cboKhachHang.ValueMember = "MaKH";
                        cboKhachHang.SelectedIndex = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Tải danh sách chương trình khuyến mãi
        /// </summary>
        private void TaiDanhSachKhuyenMai()
        {
            try
            {
                using (SqlConnection conn = Session.CreateConnection())
                {
                    conn.Open();
                    string sql = @"
                        SELECT MaKM, TenKM, PhanTramGiam, DieuKienToiThieu, NgayBatDau, NgayKetThuc,
                               TenKM + ' (Giảm ' + CAST(CAST(PhanTramGiam AS INT) AS NVARCHAR) + '%)' AS DisplayText
                        FROM KhuyenMai 
                        ORDER BY NgayBatDau DESC";

                    using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
                    {
                        dtKhuyenMaiList = new DataTable();
                        da.Fill(dtKhuyenMaiList);

                        // Thêm dòng không áp dụng khuyến mãi
                        DataRow rowNone = dtKhuyenMaiList.NewRow();
                        rowNone["MaKM"] = "NONE";
                        rowNone["TenKM"] = "-- Không áp dụng mã giảm giá --";
                        rowNone["PhanTramGiam"] = 0;
                        rowNone["DieuKienToiThieu"] = 0;
                        rowNone["NgayBatDau"] = DateTime.Today.AddYears(-1);
                        rowNone["NgayKetThuc"] = DateTime.Today.AddYears(1);
                        rowNone["DisplayText"] = "-- Không áp dụng mã giảm giá --";
                        dtKhuyenMaiList.Rows.InsertAt(rowNone, 0);

                        cboKhuyenMai.DataSource = dtKhuyenMaiList;
                        cboKhuyenMai.DisplayMember = "DisplayText";
                        cboKhuyenMai.ValueMember = "MaKM";
                        cboKhuyenMai.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách khuyến mãi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Tải danh sách hoa tươi hiển thị vào cboChonHoa
        /// </summary>
        private void TaiDanhSachHoa()
        {
            try
            {
                using (SqlConnection conn = Session.CreateConnection())
                {
                    conn.Open();
                    string sql = @"
                        SELECT MaHoa, TenHoa, DonViTinh, DonGia, SoLuongTon,
                               TenHoa + ' [' + DonViTinh + '] - ' + FORMAT(DonGia, 'N0') + ' đ (Kho: ' + CAST(SoLuongTon AS NVARCHAR) + ')' AS DisplayText
                        FROM Hoa 
                        ORDER BY TenHoa";

                    using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
                    {
                        dtHoaList = new DataTable();
                        da.Fill(dtHoaList);

                        cboChonHoa.DataSource = dtHoaList;
                        cboChonHoa.DisplayMember = "DisplayText";
                        cboChonHoa.ValueMember = "MaHoa";
                        cboChonHoa.SelectedIndex = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách hoa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboKhachHang.SelectedItem is DataRowView drv)
            {
                txtNguoiNhan.Text = drv["HoTenKH"].ToString() ?? "";
                txtSDTNhan.Text = drv["SoDienThoai"].ToString() ?? "";
                txtDiaChiGiao.Text = drv["DiaChi"].ToString() ?? "";
            }
        }

        private void cboChonHoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboChonHoa.SelectedItem is DataRowView drv)
            {
                decimal donGia = Convert.ToDecimal(drv["DonGia"]);
                int tonKho = Convert.ToInt32(drv["SoLuongTon"]);

                txtDonGia.Text = string.Format("{0:N0} đ", donGia);
                lblTonKho.Text = $"Tồn kho hiện có: {tonKho:N0} {drv["DonViTinh"]}";

                if (tonKho <= 0)
                {
                    lblTonKho.ForeColor = Color.Red;
                    lblTonKho.Text += " (HẾT HÀNG)";
                }
                else if (tonKho < 10)
                {
                    lblTonKho.ForeColor = Color.OrangeRed;
                    lblTonKho.Text += " (Sắp hết)";
                }
                else
                {
                    lblTonKho.ForeColor = Color.FromArgb(30, 100, 50);
                }
            }
            else
            {
                txtDonGia.Clear();
                lblTonKho.Text = "Tồn kho: 0";
            }
        }

        private void cboKhuyenMai_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboKhuyenMai.SelectedItem is DataRowView drv && drv["MaKM"].ToString() != "NONE")
            {
                phanTramGiam = Convert.ToDecimal(drv["PhanTramGiam"]);
                dieuKienToiThieu = Convert.ToDecimal(drv["DieuKienToiThieu"]);
            }
            else
            {
                phanTramGiam = 0;
                dieuKienToiThieu = 0;
            }

            TinhToanTongTien();
        }

        /// <summary>
        /// Thêm mặt hàng hoa vào giỏ hàng chi tiết (Sub Form)
        /// </summary>
        private void btnThemVaoLuoi_Click(object sender, EventArgs e)
        {
            if (cboChonHoa.SelectedItem is not DataRowView drv)
            {
                MessageBox.Show("Vui lòng chọn loại hoa tươi cần thêm!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboChonHoa.Focus();
                return;
            }

            string maHoa = drv["MaHoa"].ToString() ?? "";
            string tenHoa = drv["TenHoa"].ToString() ?? "";
            string dvt = drv["DonViTinh"].ToString() ?? "Bông";
            decimal donGia = Convert.ToDecimal(drv["DonGia"]);
            int tonKho = Convert.ToInt32(drv["SoLuongTon"]);
            int soLuong = (int)numSoLuong.Value;
            string ghiChu = txtGhiChu.Text.Trim();

            if (soLuong <= 0)
            {
                MessageBox.Show("Số lượng mua phải lớn hơn 0!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra mặt hàng đã có trong giỏ chưa
            DataRow[] existingRows = dtChiTiet.Select($"MaHoa = '{maHoa}'");
            if (existingRows.Length > 0)
            {
                int soLuongHienCo = Convert.ToInt32(existingRows[0]["SoLuong"]);
                int soLuongMoi = soLuongHienCo + soLuong;

                existingRows[0]["SoLuong"] = soLuongMoi;
                existingRows[0]["ThanhTien"] = soLuongMoi * donGia;
                if (!string.IsNullOrEmpty(ghiChu))
                    existingRows[0]["GhiChu"] = ghiChu;
            }
            else
            {
                DataRow newRow = dtChiTiet.NewRow();
                newRow["MaHoa"] = maHoa;
                newRow["TenHoa"] = tenHoa;
                newRow["DonViTinh"] = dvt;
                newRow["DonGiaBan"] = donGia;
                newRow["SoLuong"] = soLuong;
                newRow["ThanhTien"] = soLuong * donGia;
                newRow["GhiChu"] = ghiChu;
                dtChiTiet.Rows.Add(newRow);
            }

            TinhToanTongTien();

            // Reset input
            numSoLuong.Value = 1;
            txtGhiChu.Clear();
            cboChonHoa.Focus();
        }

        /// <summary>
        /// Xóa mặt hàng khỏi lưới chi tiết
        /// </summary>
        private void btnXoaKhoiLuoi_Click(object sender, EventArgs e)
        {
            if (dgvChiTietDonHang.CurrentRow != null && dgvChiTietDonHang.CurrentRow.Index >= 0)
            {
                int index = dgvChiTietDonHang.CurrentRow.Index;
                dtChiTiet.Rows.RemoveAt(index);
                TinhToanTongTien();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng hoa trong lưới cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Tự động tính toán tổng tiền gốc, mức giảm giá và tổng thanh toán
        /// </summary>
        private void TinhToanTongTien()
        {
            tongTienGoc = 0;
            foreach (DataRow row in dtChiTiet.Rows)
            {
                tongTienGoc += Convert.ToDecimal(row["ThanhTien"]);
            }

            if (phanTramGiam > 0 && tongTienGoc >= dieuKienToiThieu)
            {
                tienGiam = tongTienGoc * (phanTramGiam / 100.0m);
                lblGiamGia.Text = $"{phanTramGiam}% ({tienGiam:N0} đ)";
                lblGiamGia.ForeColor = Color.FromArgb(180, 60, 20);
            }
            else if (phanTramGiam > 0 && tongTienGoc < dieuKienToiThieu)
            {
                tienGiam = 0;
                lblGiamGia.Text = $"Chưa đủ điều kiện (Tối thiểu: {dieuKienToiThieu:N0} đ)";
                lblGiamGia.ForeColor = Color.Gray;
            }
            else
            {
                tienGiam = 0;
                lblGiamGia.Text = "0% (0 đ)";
                lblGiamGia.ForeColor = Color.Gray;
            }

            tongThanhToan = Math.Max(0, tongTienGoc - tienGiam);

            lblTamTinh.Text = string.Format("{0:N0} VNĐ", tongTienGoc);
            lblTongThanhToan.Text = string.Format("{0:N0} VNĐ", tongThanhToan);
        }

        // =========================================================================================
        // NÚT "LƯU ĐƠN HÀNG": THỰC THI GIAO DỊCH MAIN - SUB BẰNG ADO.NET SqlTransaction
        // =========================================================================================
        private void btnLuuDonHang_Click(object sender, EventArgs e)
        {
            string maDH = txtMaDH.Text.Trim();
            if (string.IsNullOrWhiteSpace(maDH))
            {
                MessageBox.Show("Vui lòng nhập Mã đơn hàng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaDH.Focus();
                return;
            }

            if (cboKhachHang.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn Khách hàng đặt hoa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboKhachHang.Focus();
                return;
            }

            if (dtChiTiet.Rows.Count == 0)
            {
                MessageBox.Show(
                    "Đơn hàng phải có ít nhất một mặt hàng hoa trong giỏ chi tiết (Sub Form)!",
                    "Lỗi nghiệp vụ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            string maKH = cboKhachHang.SelectedValue.ToString() ?? "";
            string? maKM = cboKhuyenMai.SelectedValue?.ToString();
            if (maKM == "NONE" || string.IsNullOrEmpty(maKM)) maKM = null;

            DateTime ngayDat = dtpNgayDat.Value;
            DateTime ngayGiao = dtpNgayGiao.Value;

            string nguoiNhan = txtNguoiNhan.Text.Trim();
            if (string.IsNullOrEmpty(nguoiNhan)) nguoiNhan = cboKhachHang.Text;

            string sdtNhan = txtSDTNhan.Text.Trim();
            if (string.IsNullOrEmpty(sdtNhan)) sdtNhan = "0900000000";

            string diaChiGiao = txtDiaChiGiao.Text.Trim();
            if (string.IsNullOrEmpty(diaChiGiao)) diaChiGiao = "Nhận trực tiếp tại quầy FloraShop";

            string loiChuc = txtLoiChuc.Text.Trim();
            string trangThai = cboTrangThai.Text;

            // BẮT ĐẦU TRANSACTION ĐỒNG BỘ MAIN - SUB
            using (SqlConnection conn = Session.CreateConnection())
            {
                conn.Open();

                using (SqlTransaction tran = conn.BeginTransaction())
                {
                    try
                    {
                        // -------------------------------------------------------------
                        // BƯỚC 1: INSERT BẢNG MASTER DonHang TRONG TRANSACTION
                        // -------------------------------------------------------------
                        string sqlInsertMaster = @"
                            INSERT INTO DonHang 
                            (MaDH, NgayDat, NgayGiao, DiaChiGiao, NguoiNhan, SDTNguoiNhan, LoiChuc, TrangThai, TongTien, MaKH, MaNV, MaKM)
                            VALUES 
                            (@MaDH, @NgayDat, @NgayGiao, @DiaChiGiao, @NguoiNhan, @SDTNguoiNhan, @LoiChuc, @TrangThai, @TongTien, @MaKH, @MaNV, @MaKM)";

                        using (SqlCommand cmdMaster = new SqlCommand(sqlInsertMaster, conn, tran))
                        {
                            cmdMaster.Parameters.AddWithValue("@MaDH", maDH);
                            cmdMaster.Parameters.AddWithValue("@NgayDat", ngayDat);
                            cmdMaster.Parameters.AddWithValue("@NgayGiao", ngayGiao);
                            cmdMaster.Parameters.AddWithValue("@DiaChiGiao", diaChiGiao);
                            cmdMaster.Parameters.AddWithValue("@NguoiNhan", nguoiNhan);
                            cmdMaster.Parameters.AddWithValue("@SDTNguoiNhan", sdtNhan);
                            cmdMaster.Parameters.AddWithValue("@LoiChuc", (object)loiChuc ?? DBNull.Value);
                            cmdMaster.Parameters.AddWithValue("@TrangThai", trangThai);
                            cmdMaster.Parameters.AddWithValue("@TongTien", tongThanhToan);
                            cmdMaster.Parameters.AddWithValue("@MaKH", maKH);
                            cmdMaster.Parameters.AddWithValue("@MaNV", Session.MaNV);
                            cmdMaster.Parameters.AddWithValue("@MaKM", (object)maKM ?? DBNull.Value);

                            // LƯU Ý: Nếu ngày giao < ngày đặt hoặc mã KM hết hạn,
                            // Trigger TRG_Check_DonHang sẽ RAISERROR ngay tại đây!
                            cmdMaster.ExecuteNonQuery();
                        }

                        // -------------------------------------------------------------
                        // BƯỚC 2: LẶP QUA DGV ĐỂ INSERT BẢNG DETAIL ChiTietDonHang
                        // -------------------------------------------------------------
                        string sqlInsertDetail = @"
                            INSERT INTO ChiTietDonHang (MaDH, MaHoa, SoLuong, DonGiaBan, GhiChu)
                            VALUES (@MaDH, @MaHoa, @SoLuong, @DonGiaBan, @GhiChu)";

                        foreach (DataRow row in dtChiTiet.Rows)
                        {
                            using (SqlCommand cmdDetail = new SqlCommand(sqlInsertDetail, conn, tran))
                            {
                                cmdDetail.Parameters.AddWithValue("@MaDH", maDH);
                                cmdDetail.Parameters.AddWithValue("@MaHoa", row["MaHoa"].ToString());
                                cmdDetail.Parameters.AddWithValue("@SoLuong", Convert.ToInt32(row["SoLuong"]));
                                cmdDetail.Parameters.AddWithValue("@DonGiaBan", Convert.ToDecimal(row["DonGiaBan"]));
                                cmdDetail.Parameters.AddWithValue("@GhiChu", row["GhiChu"] ?? DBNull.Value);

                                // LƯU Ý: Nếu số lượng mua vượt tồn kho của Hoa,
                                // Trigger TRG_CheckAndUpdateStock_ChiTietDonHang sẽ RAISERROR ngay tại đây!
                                cmdDetail.ExecuteNonQuery();
                            }
                        }

                        // Nếu không có lỗi nào phát sinh, COMMIT giao dịch toàn vẹn
                        tran.Commit();

                        // -------------------------------------------------------------
                        // BƯỚC 3: GỌI FUNCTION SELECT dbo.F_TinhTongGiaTri(@MaDH) SAU KHI LƯU
                        // -------------------------------------------------------------
                        decimal tongTienSauLuu = 0;
                        string sqlFunc = "SELECT dbo.F_TinhTongGiaTri(@MaDH)";
                        using (SqlCommand cmdFunc = new SqlCommand(sqlFunc, conn))
                        {
                            cmdFunc.Parameters.AddWithValue("@MaDH", maDH);
                            object result = cmdFunc.ExecuteScalar();
                            if (result != null && result != DBNull.Value)
                                tongTienSauLuu = Convert.ToDecimal(result);
                        }

                        // Cập nhật lại cột TongTien trong DonHang để đồng bộ tuyệt đối với SQL Function
                        string sqlUpdateTongTien = "UPDATE DonHang SET TongTien = @TongTien WHERE MaDH = @MaDH";
                        using (SqlCommand cmdUpdate = new SqlCommand(sqlUpdateTongTien, conn))
                        {
                            cmdUpdate.Parameters.AddWithValue("@TongTien", tongTienSauLuu);
                            cmdUpdate.Parameters.AddWithValue("@MaDH", maDH);
                            cmdUpdate.ExecuteNonQuery();
                        }

                        MessageBox.Show(
                            $"Lưu đơn hàng [{maDH}] thành công!\n\n" +
                            $"• Khách hàng: {cboKhachHang.Text}\n" +
                            $"• Người nhận: {nguoiNhan} ({sdtNhan})\n" +
                            $"• Số lượng loại hoa: {dtChiTiet.Rows.Count}\n" +
                            $"• Tổng thanh toán: {tongTienSauLuu:N0} VNĐ",
                            "Thông báo",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        LamMoiDonHang();
                        TaiDanhSachHoa(); // Nạp lại tồn kho mới
                        TaiDanhSachDonHang();
                    }
                    catch (SqlException ex)
                    {
                        try
                        {
                            tran.Rollback();
                        }
                        catch { }

                        MessageBox.Show(
                            "Không thể lưu đơn hàng!\n\n" +
                            ex.Message,
                            "Thông báo lỗi",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                    }
                    catch (Exception ex)
                    {
                        try
                        {
                            tran.Rollback();
                        }
                        catch { }

                        MessageBox.Show("Lỗi ứng dụng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoiDonHang();
        }

        private void LamMoiDonHang()
        {
            dtChiTiet.Clear();
            cboKhachHang.SelectedIndex = -1;
            cboKhuyenMai.SelectedIndex = 0;
            cboChonHoa.SelectedIndex = -1;
            txtNguoiNhan.Clear();
            txtSDTNhan.Clear();
            txtDiaChiGiao.Clear();
            txtLoiChuc.Clear();
            cboTrangThai.SelectedIndex = 0;
            numSoLuong.Value = 1;
            txtGhiChu.Clear();

            SinhMaDonHangTuDong();
            TinhToanTongTien();
        }

        /// <summary>
        /// Tải danh sách tất cả đơn hàng cho Tab Danh Sách
        /// </summary>
        private void TaiDanhSachDonHang()
        {
            try
            {
                using (SqlConnection conn = Session.CreateConnection())
                {
                    conn.Open();
                    string sql = @"
                        SELECT 
                            dh.MaDH AS [Mã ĐH],
                            kh.HoTenKH AS [Khách Hàng],
                            dh.NguoiNhan AS [Người Nhận],
                            dh.SDTNguoiNhan AS [SĐT Nhận],
                            dh.NgayDat AS [Ngày Đặt],
                            dh.NgayGiao AS [Ngày Giao],
                            dh.TongTien AS [Tổng Tiền (VNĐ)],
                            ISNULL(km.TenKM, N'Không KM') AS [Khuyến Mãi],
                            dh.TrangThai AS [Trạng Thái],
                            nv.HoTenNV AS [Nhân Viên Lập]
                        FROM DonHang dh
                        INNER JOIN KhachHang kh ON dh.MaKH = kh.MaKH
                        INNER JOIN NhanVien nv ON dh.MaNV = nv.MaNV
                        LEFT JOIN KhuyenMai km ON dh.MaKM = km.MaKM
                        WHERE 1=1 ";

                    string locTrangThai = cboLocTrangThai.Text;
                    if (locTrangThai != "Tất cả trạng thái" && !string.IsNullOrEmpty(locTrangThai))
                    {
                        sql += " AND dh.TrangThai = @TrangThai";
                    }

                    sql += " ORDER BY dh.NgayDat DESC";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        if (locTrangThai != "Tất cả trạng thái" && !string.IsNullOrEmpty(locTrangThai))
                        {
                            cmd.Parameters.AddWithValue("@TrangThai", locTrangThai);
                        }

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dgvDanhSachDonHang.DataSource = dt;

                            if (dgvDanhSachDonHang.Columns.Contains("Tổng Tiền (VNĐ)"))
                            {
                                dgvDanhSachDonHang.Columns["Tổng Tiền (VNĐ)"].DefaultCellStyle.Format = "N0";
                                dgvDanhSachDonHang.Columns["Tổng Tiền (VNĐ)"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách đơn hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboLocTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {
            TaiDanhSachDonHang();
        }

        private void btnLamMoiDanhSach_Click(object sender, EventArgs e)
        {
            TaiDanhSachDonHang();
        }
    }
}
