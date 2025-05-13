using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using PBL111.BLL;
using PBL111.DTO;
using PBL111.DAL;
using static PBL111.View.Login;

namespace PBL111.View
{
    public partial class mainUS : Form
    {
        private readonly ChiphiDAL _chiphiBLL = new ChiphiDAL();
        private readonly TheloaiDAL _TheloaiDAL = new TheloaiDAL();
        private readonly NganSachDAL _NgansachDAL = new NganSachDAL();

        public mainUS()
        {
            InitializeComponent();
            LoadForm();
        }

        private void LoadForm()
        {
            LoadPieChart();
            LoadGDGD();
            LoadTCT();
            lbnameUS.Text = Session.CurrentFullName;
            lbDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void LoadPieChart()
        {
            var data = _chiphiBLL.GetMonthlyExpenses(Session.CurrentUserId, DateTime.Today);
            chart1.Series.Clear();
            chart1.Titles.Clear();
            chart1.Titles.Add("Phân Loại Chi tiêu");

            var series = new Series
            {
                ChartType = SeriesChartType.Pie
            };
            chart1.Series.Add(series);

            foreach (var item in data)
            {
                series.Points.AddXY(item.Key, item.Value);
            }
        }

        private void LoadGDGD()
        {
            DateTime ngayBD = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            DateTime ngayKT = ngayBD.AddMonths(1).AddDays(-1);

            var chiphis = _chiphiBLL.GetUserExpenses(Session.CurrentUserId, ngayBD, ngayKT);

            if (chiphis == null || chiphis.Count == 0)
            {
                dgvGD.DataSource = null;
                MessageBox.Show("Không có giao dịch nào trong tháng này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            dgvGD.Columns.Clear();
            dgvGD.AutoGenerateColumns = false;

            dgvGD.Columns.Add(new DataGridViewTextBoxColumn { Name = "giaodichID", HeaderText = "Mã Giao Dịch", DataPropertyName = "giaodichID" });
            dgvGD.Columns.Add(new DataGridViewTextBoxColumn { Name = "soluong", HeaderText = "Số Lượng", DataPropertyName = "soluong" });
            dgvGD.Columns.Add(new DataGridViewTextBoxColumn { Name = "ngayGD", HeaderText = "Ngày Giao Dịch", DataPropertyName = "ngayGD" });
            dgvGD.Columns.Add(new DataGridViewTextBoxColumn { Name = "Description", HeaderText = "Mô Tả", DataPropertyName = "Description" });
            dgvGD.Columns.Add(new DataGridViewTextBoxColumn { Name = "diachi", HeaderText = "Địa Chỉ", DataPropertyName = "diachi" });

            dgvGD.DataSource = chiphis;
        }

        private void LoadTCT()
        {
            DateTime ngayBD = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            DateTime ngayKT = ngayBD.AddMonths(1).AddDays(-1);

            var chiphis = _chiphiBLL.GetUserExpenses(Session.CurrentUserId, ngayBD, ngayKT) ?? new List<Giaodich>();
            decimal tongChiTieu = chiphis.Sum(g => g.soluong);

            // Lấy ngân sách có hiệu lực trong tháng hiện tại
            var allNgansach = _NgansachDAL.GetUserNgansach(Session.CurrentUserId) ?? new List<Ngansach>();
            var dsNgansachHieuLuc = allNgansach
                .Where(n => n.NgayBD <= ngayKT && n.NgayKT >= ngayBD)
                .ToList();
            decimal tongNgansach = dsNgansachHieuLuc.Sum(g => g.Soluong);

            lbTCT.Text = $"{tongChiTieu:N0} VNĐ";
            lbNS.Text = $"{(tongNgansach - tongChiTieu):N0} VNĐ";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Login().ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new formCTCN().ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new QLyNS().ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Taikhoan().ShowDialog();
            this.Close();
        }
    }
}
