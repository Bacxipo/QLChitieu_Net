using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PBL111.BLL;
using PBL111.DAL;
using PBL111.DTO;
using PBL111.View;
using static PBL111.View.Login;

namespace PBL111.ViewAD
{
    public partial class MainAD : Form
    {
        private readonly UserBLL _userBLL = new UserBLL();
        private readonly NgansachBLL _ngansachBLL = new NgansachBLL();
        private readonly ChiphiBLL _chiphiBLL = new ChiphiBLL();
        private readonly TheloaiDAL _TheloaiDAL = new TheloaiDAL();

        public MainAD()
        {
            InitializeComponent();
            lbUS.Text = " Xin Chào :  " + Session.CurrentFullName;
            lbDate.Text = " Hôm Nay Là : " + DateTime.Now.ToString("dd/MM/yyyy");
            MainAD_Load(this, null);
        }

        private void MainAD_Load(object sender, EventArgs e)
        {
            LoadUsers();
            LoadCategories();
            LoadTransactions();
            LoadUserComboBox();
            LoadTheloaiComboBox();
        }

        private void LoadUsers()
        {
            var users = _userBLL.GetAllUsers();
            if (users == null || users.Count == 0)
            {
                dgvUS.DataSource = null;
                MessageBox.Show("Không có người dùng nào.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var userView = users.Select(u => new
            {
                u.userID,
                u.username,
                u.Fullname,
                u.Email,
                TrangThai = (u.IsActive ?? false) ? "Hoạt động" : "Khóa",
                NgayTao = u.CreateDate.HasValue ? u.CreateDate.Value.ToString("dd/MM/yyyy") : ""
            }).ToList();

            SetupUserGridColumns();
            dgvUS.DataSource = userView;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim();
            var users = _userBLL.GetAllUsers()
                .Where(u => u.username.Contains(searchText))
                .ToList();

            var userView = users.Select(u => new
            {
                u.userID,
                u.username,
                u.Fullname,
                u.Email,
                TrangThai = (u.IsActive ?? false) ? "Hoạt động" : "Khóa",
                NgayTao = u.CreateDate.HasValue ? u.CreateDate.Value.ToString("dd/MM/yyyy") : ""
            }).ToList();

            SetupUserGridColumns();
            dgvUS.DataSource = userView;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var addUserForm = new addUS())
            {
                if (addUserForm.ShowDialog() == DialogResult.OK)
                {
                    LoadUsers();
                    LoadTransactions();
                    LoadCategories();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvUS.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một người dùng để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int userId = Convert.ToInt32(dgvUS.SelectedRows[0].Cells["userID"].Value);
            var user = _userBLL.GetUserByid(userId);

            if (user != null)
            {
                using (var editUserForm = new editUS(user))
                {
                    if (editUserForm.ShowDialog() == DialogResult.OK)
                        LoadUsers();
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy người dùng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (dgvUS.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một người dùng để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int userId = Convert.ToInt32(dgvUS.SelectedRows[0].Cells["userID"].Value);
            var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa người dùng này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                bool result = _userBLL.DeleteUser(userId);
                if (result)
                {
                    MessageBox.Show("Xóa người dùng thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadUsers();
                }
                else
                {
                    MessageBox.Show("Xóa người dùng thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLock_Click(object sender, EventArgs e)
        {
            if (dgvUS.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một người dùng để khóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int userId = Convert.ToInt32(dgvUS.SelectedRows[0].Cells["userID"].Value);
            var user = _userBLL.GetUserByid(userId);

            if (user != null)
            {
                user.IsActive = false;
                bool result = _userBLL.UpdateUser(user);

                if (result)
                {
                    MessageBox.Show("Khóa tài khoản thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadUsers(); // ĐÃ ĐÚNG: sẽ cập nhật lại trạng thái trên dgvUS
                }
                else
                {
                    MessageBox.Show("Khóa tài khoản thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy người dùng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCategories()
        {
            var categories = _TheloaiDAL.GetAllTheloai()
                .Select(tl => new
                {
                    tl.theloaiID,
                    tl.nameTL,
                    tl.description
                })
                .ToList();

            dgvTL.AutoGenerateColumns = false;
            dgvTL.Columns.Clear();

            dgvTL.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "theloaiID",
                HeaderText = "ID",
                DataPropertyName = "theloaiID"
            });
            dgvTL.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "nameTL",
                HeaderText = "Tên thể loại",
                DataPropertyName = "nameTL"
            });
            dgvTL.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "description",
                HeaderText = "Mô tả",
                DataPropertyName = "description"
            });
            dgvTL.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTL.DataSource = categories;
        }

        private void LoadTransactions()
        {
            using (var context = new QLTC())
            {
                var data = (from gd in context.Giaodiches
                            join us in context.users on gd.userID equals us.userID
                            select new
                            {
                                MaGD = gd.giaodichID,
                                TenDangNhap = us.username,
                                HoTen = us.Fullname,
                                Email = us.Email,
                                SoTien = gd.soluong,
                                NgayGD = gd.ngayGD,
                                MoTa = gd.Description,
                                DiaChi = gd.diachi,
                                NgayTao = gd.ngaytao
                            }).ToList();

                dgvGD.AutoGenerateColumns = false;
                dgvGD.Columns.Clear();

                dgvGD.Columns.Add(new DataGridViewTextBoxColumn { Name = "MaGD", HeaderText = "Mã GD", DataPropertyName = "MaGD" });
                dgvGD.Columns.Add(new DataGridViewTextBoxColumn { Name = "TenDangNhap", HeaderText = "Tên đăng nhập", DataPropertyName = "TenDangNhap" });
                dgvGD.Columns.Add(new DataGridViewTextBoxColumn { Name = "HoTen", HeaderText = "Họ và tên", DataPropertyName = "HoTen" });
                dgvGD.Columns.Add(new DataGridViewTextBoxColumn { Name = "Email", HeaderText = "Email", DataPropertyName = "Email" });
                dgvGD.Columns.Add(new DataGridViewTextBoxColumn { Name = "SoTien", HeaderText = "Số tiền", DataPropertyName = "SoTien", DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" } });
                dgvGD.Columns.Add(new DataGridViewTextBoxColumn { Name = "NgayGD", HeaderText = "Ngày giao dịch", DataPropertyName = "NgayGD", DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" } });
                dgvGD.Columns.Add(new DataGridViewTextBoxColumn { Name = "MoTa", HeaderText = "Mô tả", DataPropertyName = "MoTa" });
                dgvGD.Columns.Add(new DataGridViewTextBoxColumn { Name = "DiaChi", HeaderText = "Địa chỉ", DataPropertyName = "DiaChi" });
                dgvGD.Columns.Add(new DataGridViewTextBoxColumn { Name = "NgayTao", HeaderText = "Ngày tạo", DataPropertyName = "NgayTao", DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" } });

                dgvGD.DataSource = data;
            }
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            int selectedUserId = (cbBUS.SelectedValue != null) ? Convert.ToInt32(cbBUS.SelectedValue) : -1;
            int selectedTheloaiId = (cbBGD.SelectedValue != null) ? Convert.ToInt32(cbBGD.SelectedValue) : -1;
            DateTime fromDate = dtpBD.Value.Date;
            DateTime toDate = dtpKT.Value.Date;

            using (var context = new QLTC())
            {
                var query = from gd in context.Giaodiches
                            join us in context.users on gd.userID equals us.userID
                            join tl in context.Theloais on gd.theloaiID equals tl.theloaiID
                            where gd.ngayGD >= fromDate && gd.ngayGD <= toDate
                            select new
                            {
                                MaGD = gd.giaodichID,
                                TenDangNhap = us.username,
                                HoTen = us.Fullname,
                                Email = us.Email,
                                SoTien = gd.soluong,
                                NgayGD = gd.ngayGD,
                                MoTa = gd.Description,
                                DiaChi = gd.diachi,
                                LoaiGD = tl.nameTL,
                                NgayTao = gd.ngaytao,
                                userID = us.userID,
                                theloaiID = tl.theloaiID
                            };

                if (selectedUserId != -1)
                    query = query.Where(x => x.userID == selectedUserId);

                if (selectedTheloaiId != -1)
                    query = query.Where(x => x.theloaiID == selectedTheloaiId);

                var data = query.ToList();

                dgvGD.AutoGenerateColumns = false;
                dgvGD.Columns.Clear();

                dgvGD.Columns.Add(new DataGridViewTextBoxColumn { Name = "MaGD", HeaderText = "Mã GD", DataPropertyName = "MaGD" });
                dgvGD.Columns.Add(new DataGridViewTextBoxColumn { Name = "TenDangNhap", HeaderText = "Tên đăng nhập", DataPropertyName = "TenDangNhap" });
                dgvGD.Columns.Add(new DataGridViewTextBoxColumn { Name = "HoTen", HeaderText = "Họ và tên", DataPropertyName = "HoTen" });
                dgvGD.Columns.Add(new DataGridViewTextBoxColumn { Name = "Email", HeaderText = "Email", DataPropertyName = "Email" });
                dgvGD.Columns.Add(new DataGridViewTextBoxColumn { Name = "SoTien", HeaderText = "Số tiền", DataPropertyName = "SoTien", DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" } });
                dgvGD.Columns.Add(new DataGridViewTextBoxColumn { Name = "NgayGD", HeaderText = "Ngày giao dịch", DataPropertyName = "NgayGD", DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" } });
                dgvGD.Columns.Add(new DataGridViewTextBoxColumn { Name = "MoTa", HeaderText = "Mô tả", DataPropertyName = "MoTa" });
                dgvGD.Columns.Add(new DataGridViewTextBoxColumn { Name = "DiaChi", HeaderText = "Địa chỉ", DataPropertyName = "DiaChi" });
                dgvGD.Columns.Add(new DataGridViewTextBoxColumn { Name = "LoaiGD", HeaderText = "Loại giao dịch", DataPropertyName = "LoaiGD" });
                dgvGD.Columns.Add(new DataGridViewTextBoxColumn { Name = "NgayTao", HeaderText = "Ngày tạo", DataPropertyName = "NgayTao", DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" } });

                dgvGD.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvGD.DataSource = data;
            }
        }

        private void LoadUserComboBox()
        {
            var users = _userBLL.GetAllUsers()
                .Select(u => new { u.userID, Display = u.Fullname + " (" + u.username + ")" })
                .ToList();

            users.Insert(0, new { userID = -1, Display = "Tất cả" });

            cbBUS.DataSource = users;
            cbBUS.DisplayMember = "Display";
            cbBUS.ValueMember = "userID";
            comboBox1.DataSource = users;
            comboBox1.DisplayMember = "Display";
            comboBox1.ValueMember = "userID";
        }

        private void LoadTheloaiComboBox()
        {
            var theloais = _TheloaiDAL.GetAllTheloai()
                .Select(tl => new { tl.theloaiID, tl.nameTL })
                .ToList();

            theloais.Insert(0, new { theloaiID = -1, nameTL = "Tất cả" });

            cbBGD.DataSource = theloais;
            cbBGD.DisplayMember = "nameTL";
            cbBGD.ValueMember = "theloaiID";
        }

        private void btnALL_Click(object sender, EventArgs e)
        {
            LoadTransactions();
        }

        private void btnAddTL_Click(object sender, EventArgs e)
        {
            using (var addTL = new AddTL())
            {
                if (addTL.ShowDialog() == DialogResult.OK)
                    LoadCategories();
            }
        }

        private void btnEditTL_Click(object sender, EventArgs e)
        {
            if (dgvTL.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một thể loại để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int theloaiId = Convert.ToInt32(dgvTL.SelectedRows[0].Cells["theloaiID"].Value);
            var theloai = _TheloaiDAL.GetAllTheloai().FirstOrDefault(t => t.theloaiID == theloaiId);

            if (theloai == null)
            {
                MessageBox.Show("Không tìm thấy thể loại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var editTL = new EditTL(theloai, Session.CurrentUserId))
            {
                if (editTL.ShowDialog() == DialogResult.OK)
                    LoadCategories();
            }
        }

        private void btnDelTL_Click(object sender, EventArgs e)
        {
            if (dgvTL.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một thể loại để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int theloaiId = Convert.ToInt32(dgvTL.SelectedRows[0].Cells["theloaiID"].Value);
            var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa thể loại này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                bool result = _TheloaiDAL.DeleteTheloai(theloaiId, Session.CurrentUserId);
                if (result)
                {
                    MessageBox.Show("Xóa thể loại thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadCategories();
                }
                else
                {
                    MessageBox.Show("Xóa thể loại thất bại. Có thể thể loại này đang được sử dụng hoặc bạn không có quyền.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedUserId = (comboBox1.SelectedValue != null) ? Convert.ToInt32(comboBox1.SelectedValue) : -1;
                DateTime fromDate = dt1.Value.Date;
                DateTime toDate = dt2.Value.Date;

                if (fromDate > toDate)
                {
                    MessageBox.Show("Ngày bắt đầu phải nhỏ hơn hoặc bằng ngày kết thúc.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                List<Giaodich> giaoDichList;
                using (var context = new QLTC())
                {
                    if (selectedUserId == -1)
                    {
                        giaoDichList = context.Giaodiches
                            .Where(gd => gd.ngayGD >= fromDate && gd.ngayGD <= toDate)
                            .ToList();
                    }
                    else
                    {
                        giaoDichList = context.Giaodiches
                            .Where(gd => gd.userID == selectedUserId && gd.ngayGD >= fromDate && gd.ngayGD <= toDate)
                            .ToList();
                    }
                }

                decimal tongChiTieu = giaoDichList.Sum(gd => gd.soluong);
                textBox1.Text = tongChiTieu.ToString("N0") + "VNĐ";

                var thongKeTheLoai = giaoDichList
                    .GroupBy(gd => gd.theloaiID)
                    .Select(g => new
                    {
                        TheloaiID = g.Key,
                        TongTien = g.Sum(x => x.soluong)
                    })
                    .ToList();

                var theloaiDict = _TheloaiDAL.GetAllTheloai().ToDictionary(t => t.theloaiID, t => t.nameTL);

                chart2.Series.Clear();
                var seriesCot = chart2.Series.Add("Chi tiêu theo thể loại");
                seriesCot.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
                foreach (var item in thongKeTheLoai)
                {
                    string tenTL = theloaiDict.ContainsKey(item.TheloaiID) ? theloaiDict[item.TheloaiID] : "Khác";
                    seriesCot.Points.AddXY(tenTL, item.TongTien);
                }

                chart1.Series.Clear();
                var seriesTron = chart1.Series.Add("Tỉ lệ chi tiêu");
                seriesTron.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                foreach (var item in thongKeTheLoai)
                {
                    string tenTL = theloaiDict.ContainsKey(item.TheloaiID) ? theloaiDict[item.TheloaiID] : "Khác";
                    seriesTron.Points.AddXY(tenTL, item.TongTien);
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                if (ex.InnerException != null)
                    msg += "\n" + ex.InnerException.Message;
                MessageBox.Show(msg, "Lỗi truy vấn", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupUserGridColumns()
        {
            dgvUS.Columns.Clear();
            dgvUS.AutoGenerateColumns = false;

            dgvUS.Columns.Add(new DataGridViewTextBoxColumn { Name = "userID", HeaderText = "ID", DataPropertyName = "userID", Visible = false });
            dgvUS.Columns.Add(new DataGridViewTextBoxColumn { Name = "username", HeaderText = "Tên đăng nhập", DataPropertyName = "username" });
            dgvUS.Columns.Add(new DataGridViewTextBoxColumn { Name = "Fullname", HeaderText = "Họ và tên", DataPropertyName = "Fullname" });
            dgvUS.Columns.Add(new DataGridViewTextBoxColumn { Name = "Email", HeaderText = "Email", DataPropertyName = "Email" });
            dgvUS.Columns.Add(new DataGridViewTextBoxColumn { Name = "TrangThai", HeaderText = "Trạng thái hoạt động", DataPropertyName = "TrangThai" });
            dgvUS.Columns.Add(new DataGridViewTextBoxColumn { Name = "NgayTao", HeaderText = "Ngày tạo", DataPropertyName = "NgayTao" });
            dgvUS.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            this.Hide();
            login.ShowDialog();
            this.Close();
        }
    }
}
