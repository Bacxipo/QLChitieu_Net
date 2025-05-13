using PBL111.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PBL111.DTO;
using static PBL111.View.Login;
using PBL111.DAL;

namespace PBL111.View
{
    public partial class formCTCN : Form
    {
        private readonly ChiphiBLL chiphiBLL;
        private readonly TheloaiDAL TheloaiDAL;
        private readonly NgansachBLL ngansachBLL;

        public formCTCN()
        {
            InitializeComponent();
            chiphiBLL = new ChiphiBLL();
            lbnameUS.Text = Session.CurrentFullName;
            lbDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            LoadGDGD();
            LoadTCT();
        }

        private void LoadTCT()
        {
            DateTime ngayBD = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            DateTime ngayKT = ngayBD.AddMonths(1).AddDays(-1);
            var chiphis = chiphiBLL.GetUserExpenses(Session.CurrentUserId, ngayBD, ngayKT) ?? new List<Giaodich>();
            decimal tongChiTieu = chiphis.Sum(g => g.soluong);
            lbTCT.Text = $"Tổng Chi Tiêu: {tongChiTieu:N0} VNĐ";
        }

        private void LoadGDGD()
        {
            if (Session.CurrentUserId == 0)
            {
                MessageBox.Show("Người dùng chưa đăng nhập. Vui lòng đăng nhập lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DateTime ngayBD = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            DateTime ngayKT = ngayBD.AddMonths(1).AddDays(-1);
            var chiphis = chiphiBLL.GetUserExpenses(Session.CurrentUserId, ngayBD, ngayKT);

            if (chiphis == null || chiphis.Count == 0)
            {
                dgvGD.DataSource = null;
                MessageBox.Show("Không có giao dịch nào trong tháng này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            dgvGD.Columns.Clear();
            dgvGD.AutoGenerateColumns = false;
            dgvGD.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "giaodichID",
                HeaderText = "Mã Giao Dịch",
                DataPropertyName = "giaodichID"
            });
            dgvGD.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "soluong",
                HeaderText = "Số Lượng",
                DataPropertyName = "soluong"
            });
            dgvGD.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ngayGD",
                HeaderText = "Ngày Giao Dịch",
                DataPropertyName = "ngayGD"
            });
            dgvGD.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Description",
                HeaderText = "Mô Tả",
                DataPropertyName = "Description"
            });
            dgvGD.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "diachi",
                HeaderText = "Địa Chỉ",
                DataPropertyName = "diachi"
            });
            dgvGD.DataSource = chiphis;
            LoadTCT();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var addGD = new AddGD())
            {
                addGD.ShowDialog();
            }
            LoadGDGD();
        }

        private void btnMainUS_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (var mainUS = new mainUS())
            {
                mainUS.ShowDialog();
            }
            this.Close();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = dtpBD.Value.Date;
            LoadTransactionsByDate(selectedDate);
        }

        private void LoadTransactionsByDate(DateTime selectedDate)
        {
            DateTime ngayBD = new DateTime(selectedDate.Year, selectedDate.Month, 1);
            DateTime ngayKT = ngayBD.AddMonths(1).AddDays(-1);
            var chiphis = chiphiBLL.GetUserExpenses(Session.CurrentUserId, ngayBD, ngayKT);

            if (chiphis == null || chiphis.Count == 0)
            {
                dgvGD.DataSource = null;
                MessageBox.Show("Không có giao dịch nào trong tháng này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            dgvGD.DataSource = chiphis;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvGD.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một giao dịch để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var selectedRow = dgvGD.SelectedRows[0];
            int giaodichID = Convert.ToInt32(selectedRow.Cells["giaodichID"].Value);
            var giaodich = chiphiBLL.GetUserExpenses(Session.CurrentUserId)
                                    .FirstOrDefault(g => g.giaodichID == giaodichID);
            if (giaodich == null)
            {
                MessageBox.Show("Không tìm thấy giao dịch.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            using (var editForm = new EditGD(giaodich))
            {
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    LoadGDGD();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvGD.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một giao dịch để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var selectedRow = dgvGD.SelectedRows[0];
            if (selectedRow.Cells["giaodichID"].Value == null)
            {
                MessageBox.Show("Không thể lấy thông tin giao dịch. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int giaodichID = Convert.ToInt32(selectedRow.Cells["giaodichID"].Value);
            var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa giao dịch này?",
                                                "Xác nhận xóa",
                                                MessageBoxButtons.YesNo,
                                                MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {
                bool result = chiphiBLL.deleteGD(giaodichID, Session.CurrentUserId);
                if (result)
                {
                    MessageBox.Show("Xóa giao dịch thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadGDGD();
                }
                else
                {
                    MessageBox.Show("Xóa giao dịch thất bại. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime fromDate = dtpBD.Value.Date;
            DateTime toDate = dtpKT.Value.Date;

            if (fromDate > toDate)
            {
                MessageBox.Show("Ngày bắt đầu phải nhỏ hơn hoặc bằng ngày kết thúc.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var chiphis = chiphiBLL.GetUserExpenses(Session.CurrentUserId, fromDate, toDate);
            if (chiphis == null || chiphis.Count == 0)
            {
                dgvGD.DataSource = null;
                MessageBox.Show("Không có giao dịch nào trong khoảng thời gian này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            dgvGD.DataSource = chiphis;
        }
    }
}
