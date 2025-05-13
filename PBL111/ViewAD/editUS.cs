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

namespace PBL111.ViewAD
{
    public partial class editUS : Form
    {
       
        private readonly user _user;
        private readonly UserBLL _userBLL = new UserBLL();

        public editUS(user user)
        {
            InitializeComponent();
            _user = user;
            LoadStatusComboBox();
            LoadUserData();
        }

        private void LoadStatusComboBox()
        {
            cbBTT.DataSource = new List<string> { "Hoạt động", "Khóa" };
        }

        private void LoadUserData()
        {
            txtUS.Text = _user.username;
            txtFN.Text = _user.Fullname;
            txtEmail.Text = _user.Email;
            cbBTT.SelectedItem = (_user.IsActive ?? false) ? "Hoạt động" : "Khóa";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUS.Text) ||
                string.IsNullOrWhiteSpace(txtFN.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                cbBTT.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _user.username = txtUS.Text.Trim();
            _user.Fullname = txtFN.Text.Trim();
            _user.Email = txtEmail.Text.Trim();
            _user.IsActive = cbBTT.SelectedItem.ToString() == "Hoạt động";
            // Không nên sửa CreateDate

            bool result = _userBLL.UpdateUser(_user);
            if (result)
            {
                MessageBox.Show("Cập nhật người dùng thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
