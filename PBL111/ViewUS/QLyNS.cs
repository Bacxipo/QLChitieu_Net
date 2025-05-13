using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PBL111.BLL;
using PBL111.DTO;
using System.Windows.Forms;
using static PBL111.View.Login;
using System.Data.Entity;
using PBL111.DAL;

namespace PBL111.View
{
    public partial class QLyNS : Form
    {
        private readonly NgansachBLL _ngansachBLL = new NgansachBLL();
        private readonly ChiphiBLL _chiphiBLL = new ChiphiBLL();

        public QLyNS()
        {
            InitializeComponent();
            LoadNgansach();
            LoadTCT();
            lbnameUS.Text = Session.CurrentFullName;
            lbDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void btnMainUS_Click(object sender, EventArgs e)
        {
            this.Hide();
            new mainUS().ShowDialog();
            this.Close();
        }

        private void LoadTCT()
        {
            DateTime ngayBD = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            DateTime ngayKT = ngayBD.AddMonths(1).AddDays(-1);

            decimal tongChiTieu = _chiphiBLL.GetUserExpenses(Session.CurrentUserId, ngayBD, ngayKT)?.Sum(g => g.soluong) ?? 0;
            // Lấy ngân sách có hiệu lực trong tháng hiện tại
            var dsNgansach = _ngansachBLL.GetUserNgansach(Session.CurrentUserId)
                .Where(n => n.NgayBD <= ngayKT && n.NgayKT >= ngayBD)
                .ToList();
            decimal tongNgansach = dsNgansach.Sum(g => g.Soluong);

            lbNS.Text = $"{tongNgansach - tongChiTieu:N0} VNĐ";
        }

        private void LoadNgansach()
        {
            var ngansach = _ngansachBLL.GetUserNgansach(Session.CurrentUserId)
                                       .OrderByDescending(n => n.NgayBD)
                                       .FirstOrDefault();

            if (ngansach != null)
            {
                txtST.Text = ngansach.Soluong.ToString("N0");
                NgayBD.Value = ngansach.NgayBD;
                NgayKT.Value = ngansach.NgayKT;
            }
            else
            {
                txtST.Text = "";
                MessageBox.Show("Chưa thiết lập hạn mức.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtST.Text, out decimal hanMucMoi))
            {
                MessageBox.Show("Vui lòng nhập hạn mức chi tiêu hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (NgayBD.Value >= NgayKT.Value)
            {
                MessageBox.Show("Ngày bắt đầu phải nhỏ hơn ngày kết thúc.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var ngansach = _ngansachBLL.GetUserNgansach(Session.CurrentUserId).FirstOrDefault();
            bool result = false;

            if (ngansach != null)
            {
                ngansach.Soluong = hanMucMoi;
                ngansach.NgayBD = NgayBD.Value;
                ngansach.NgayKT = NgayKT.Value;
                result = _ngansachBLL.updateNgansach(ngansach, Session.CurrentUserId);
            }
            else
            {
                var newNgansach = new Ngansach
                {
                    userID = Session.CurrentUserId,
                    Soluong = hanMucMoi,
                    NgayBD = NgayBD.Value,
                    NgayKT = NgayKT.Value,
                    Ngaytao = DateTime.Now
                };
                result = _ngansachBLL.setupNgansach(newNgansach, Session.CurrentUserId);
            }

            if (result)
            {
                MessageBox.Show("Cập nhật ngân sách thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadNgansach();
                LoadTCT();
            }
            else
            {
                MessageBox.Show("Cập nhật ngân sách thất bại. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
