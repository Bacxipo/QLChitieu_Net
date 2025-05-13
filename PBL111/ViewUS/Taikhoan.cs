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
using PBL111.DTO;
using static PBL111.View.Login;


namespace PBL111.View
{
    public partial class Taikhoan : Form
    {
        public Taikhoan()
        {
            InitializeComponent();
            lbnameUS.Text = Session.CurrentFullName;
            lbDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            loadForm();
        }
       public void loadForm()
        {
            txtFN.Text = Session.CurrentFullName;
            txtTDN.Text = Session.CurrentUserName;
            txtEmail.Text = Session.CurrentUserEmail;

        }
        private void button1_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtFN.Text) || string.IsNullOrWhiteSpace(txtTDN.Text) || string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var userBLL = new UserBLL();
            var user = userBLL.GetUserByid(Session.CurrentUserId); // Sửa tên hàm thành GetUserById

            if (user != null)
            {
                user.Fullname = txtFN.Text.Trim(); // Sửa tên thuộc tính thành Fullname
                user.username = txtTDN.Text.Trim(); // Sửa tên thuộc tính thành username
                user.Email = txtEmail.Text.Trim();

                bool result = userBLL.UpdateUser(user);

                if (result)
                {
                    MessageBox.Show("Cập nhật thông tin thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Session.CurrentUserName = user.username; // Cập nhật lại thông tin trong Session
                    Session.CurrentFullName = user.Fullname;
                    Session.CurrentUserEmail = user.Email;
                    loadForm(); // Làm mới giao diện
                }
                else
                {
                    MessageBox.Show("Cập nhật thông tin thất bại. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy tài khoản. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtOMK.Text) || string.IsNullOrWhiteSpace(txtNMK.Text) || string.IsNullOrWhiteSpace(txtXN.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtNMK.Text != txtXN.Text)
            {
                MessageBox.Show("Mật khẩu mới và xác nhận mật khẩu không khớp.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var userBLL = new UserBLL();
            bool result = userBLL.ChangePassword(Session.CurrentUserId, txtOMK.Text.Trim(), txtNMK.Text.Trim());

            if (result)
            {
                MessageBox.Show("Thay đổi mật khẩu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtOMK.Clear();
                txtNMK.Clear();
                txtXN.Clear();
            }
            else
            {
                MessageBox.Show("Mật khẩu cũ không đúng hoặc thay đổi mật khẩu thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            mainUS mainUS = new mainUS();
            this.Hide();
            mainUS.ShowDialog();
            this.Close();
        }
    }
}
