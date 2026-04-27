using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace PharmacyManagement
{
    public partial class frmTonKho : Form
    {
        private const string CONNECTION_STRING = "Data Source=DESKTOP-Q1UORLL\\DESKTOP;Initial Catalog=QLNhaThuocPharmacy;Persist Security Info=True;User ID=sa;Password=123";

        public frmTonKho()
        {
            InitializeComponent();
        }

        private void frmTonKho_Load(object sender, EventArgs e)
        {
            LoadDuLieuTonKho();
        }

        private void LoadDuLieuTonKho(string filter = "")
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
                {
                    // Lấy dữ liệu từ bảng THUOC và LOHANG theo cấu trúc database
                    string query = @"SELECT t.MATHUOC, t.TENTHUOC, l.MALO, l.SOLUONGTON, l.HANSD, l.GIANHAP 
                                     FROM THUOC t 
                                     JOIN LOHANG l ON t.MATHUOC = l.MATHUOC 
                                     WHERE l.TRANGTHAI = N'HoatDong'";

                    
                    if (!string.IsNullOrEmpty(filter))
                    {
                        query += $" AND (t.MATHUOC LIKE N'%{filter}%' OR t.TENTHUOC LIKE N'%{filter}%' OR l.MALO LIKE N'%{filter}%')";
                    }

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvTonKho.DataSource = dt;
                    FormatGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối CSDL: " + ex.Message);
            }
        }

        private void FormatGrid()
        {
            dgvTonKho.Columns["MATHUOC"].HeaderText = "Mã Thuốc";
            dgvTonKho.Columns["TENTHUOC"].HeaderText = "Tên Thuốc";
            dgvTonKho.Columns["TENTHUOC"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvTonKho.Columns["MALO"].HeaderText = "Mã Lô";
            dgvTonKho.Columns["SOLUONGTON"].HeaderText = "Tồn Kho";
            dgvTonKho.Columns["HANSD"].HeaderText = "Hạn Sử Dụng";
            dgvTonKho.Columns["HANSD"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvTonKho.Columns["GIANHAP"].HeaderText = "Giá Nhập";
            dgvTonKho.Columns["GIANHAP"].DefaultCellStyle.Format = "N0";
        }

        private void dgvTonKho_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvTonKho.Columns[e.ColumnIndex].Name == "HANSD")
            {
                DateTime hsd = Convert.ToDateTime(dgvTonKho.Rows[e.RowIndex].Cells["HANSD"].Value);
                int tonKho = Convert.ToInt32(dgvTonKho.Rows[e.RowIndex].Cells["SOLUONGTON"].Value);

                if (tonKho <= 0)
                {
                    dgvTonKho.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGray;
                }
                else if ((hsd - DateTime.Now).TotalDays <= 30)
                {
                    dgvTonKho.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.MistyRose;
                    dgvTonKho.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e) => LoadDuLieuTonKho(txtTimKiem.Text.Trim());

        private void btnDong_Click(object sender, EventArgs e) => this.Close();
    }
}