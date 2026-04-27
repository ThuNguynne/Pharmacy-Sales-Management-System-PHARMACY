using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace PharmacyManagement
{
    public partial class frmBaoCaoTongHop : Form
    {
        private const string STR_CONN = "Data Source=DESKTOP-Q1UORLL\\DESKTOP;Initial Catalog=QLNhaThuocPharmacy;Persist Security Info=True;User ID=sa;Password=123";

        public frmBaoCaoTongHop()
        {
            InitializeComponent();
        }

        private void frmBaoCaoTongHop_Load(object sender, EventArgs e)
        {
            // Thiết lập Loại Báo Cáo
            cboLoaiBaoCao.Items.Clear();
            cboLoaiBaoCao.Items.AddRange(new string[] { "Doanh Thu", "Đơn Hàng", "Tồn Kho" });
            cboLoaiBaoCao.SelectedIndex = 0;

            // Thiết lập Nhóm Theo (Để gộp dữ liệu trên biểu đồ)
            cboKieuXem.Items.Clear();
            cboKieuXem.Items.AddRange(new string[] { "Theo Ngày", "Theo Tháng", "Theo Năm" });
            cboKieuXem.SelectedIndex = 0;

            // Set mặc định ngày (Lấy từ 01/10/2024 để khớp dữ liệu mẫu của bạn)
            dtpTuNgay.Value = new DateTime(2024, 10, 1);
            dtpDenNgay.Value = DateTime.Now;

            // Tự động load biểu đồ ngay khi mở Form
            LoadDataToChart();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            LoadDataToChart();
        }

        private void LoadDataToChart()
        {
            string sql = "";
            string kieuXem = cboKieuXem.Text;
            string loaiBC = cboLoaiBaoCao.Text;

            // Các biến xử lý chuỗi SQL để Format thời gian và Group By
            string colThoiGian = "";
            string groupByThoiGian = "";
            string orderByThoiGian = "";

            // Tùy theo lựa chọn mà SQL sẽ tự động nhóm theo Ngày/Tháng/Năm
            if (kieuXem == "Theo Ngày")
            {
                colThoiGian = "CONVERT(VARCHAR, CAST({0} AS DATE), 103)";
                groupByThoiGian = "CAST({0} AS DATE)";
                orderByThoiGian = "CAST({0} AS DATE)";
            }
            else if (kieuXem == "Theo Tháng")
            {
                colThoiGian = "RIGHT(CONVERT(VARCHAR, CAST({0} AS DATE), 103), 7)";
                groupByThoiGian = "YEAR({0}), MONTH({0}), RIGHT(CONVERT(VARCHAR, CAST({0} AS DATE), 103), 7)";
                orderByThoiGian = "YEAR({0}), MONTH({0})";
            }
            else // Theo Năm
            {
                colThoiGian = "CAST(YEAR({0}) AS VARCHAR)";
                groupByThoiGian = "YEAR({0})";
                orderByThoiGian = "YEAR({0})";
            }

            // Tạo truy vấn SQL dựa trên Loại Báo Cáo
            if (loaiBC == "Doanh Thu")
            {
                string dateCol = "NGAYLAP";
                sql = $@"SELECT {string.Format(colThoiGian, dateCol)} as [Thời Gian], SUM(TONGTIEN) as [Giá Trị (VNĐ)] 
                         FROM HOADON 
                         WHERE TRANGTHAID = N'DaThanhToan' AND {dateCol} >= @TuNgay AND {dateCol} <= @DenNgay 
                         GROUP BY {string.Format(groupByThoiGian, dateCol)} 
                         ORDER BY {string.Format(orderByThoiGian, dateCol)}";
            }
            else if (loaiBC == "Đơn Hàng")
            {
                string dateCol = "NGAYDAT";
                sql = $@"SELECT {string.Format(colThoiGian, dateCol)} as [Thời Gian], COUNT(MADON) as [Số Lượng Đơn] 
                         FROM DONHANG 
                         WHERE {dateCol} >= @TuNgay AND {dateCol} <= @DenNgay 
                         GROUP BY {string.Format(groupByThoiGian, dateCol)} 
                         ORDER BY {string.Format(orderByThoiGian, dateCol)}";
            }
            else // Tồn Kho (Lưu ý: Tồn kho là dữ liệu hiện tại, không phụ thuộc lịch sử ngày tháng)
            {
                sql = @"SELECT TOP 15 T.TENTHUOC as [Tên Thuốc], SUM(L.SOLUONGTON) as [Tồn Kho] 
                        FROM LOHANG L JOIN THUOC T ON L.MATHUOC = T.MATHUOC 
                        GROUP BY T.TENTHUOC 
                        ORDER BY [Tồn Kho] DESC";
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(STR_CONN))
                {
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    // Truyền tham số Ngày an toàn
                    cmd.Parameters.AddWithValue("@TuNgay", dtpTuNgay.Value.Date);
                    cmd.Parameters.AddWithValue("@DenNgay", dtpDenNgay.Value.Date.AddDays(1).AddSeconds(-1));

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvData.DataSource = dt;
                    chartBaoCao.Series.Clear();

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Không có dữ liệu trong khoảng thời gian này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    // Đổ dữ liệu vào biểu đồ
                    string xCol = dt.Columns[0].ColumnName;
                    string yCol = dt.Columns[1].ColumnName;

                    Series series = new Series(loaiBC)
                    {
                        ChartType = (loaiBC == "Tồn Kho") ? SeriesChartType.Pie : SeriesChartType.Column,
                        XValueMember = xCol,
                        YValueMembers = yCol,
                        IsValueShownAsLabel = true
                    };

                    if (loaiBC == "Doanh Thu")
                    {
                        series.LabelFormat = "{0:N0}";
                    }

                    chartBaoCao.Series.Add(series);
                    chartBaoCao.DataSource = dt;
                    chartBaoCao.DataBind();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi CSDL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}