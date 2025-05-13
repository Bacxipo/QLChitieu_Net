using PblNet1.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using PblNet1.BLL;
using PblNet1.DTO;


namespace PblNet1
{
    public partial class Login : Form
    {
        private readonly UserBLL userBLL;
        public Login()
        {
            InitializeComponent();
            userBLL = new UserBLL();
        }

        private void btnDK_Click(object sender, EventArgs e)
        {
            Dangky dangky = new Dangky();
            dangky.Show();
        }

        private void btnDN_Click(object sender, EventArgs e)
        {
            string tenDangNhap = txtUS.Text.Trim();
            string matKhau = txtPW.Text.Trim();
            if (string.IsNullOrEmpty(tenDangNhap) || string.IsNullOrEmpty(matKhau))
            {
                MessageBox.Show("Vui lòng nhập tài khoản và mật khẩu.");
                return;
            }
            try
            {
                if (string.IsNullOrEmpty(tenDangNhap) || string.IsNullOrEmpty(matKhau))
                {
                    MessageBox.Show("Vui lòng nhập tài khoản và mật khẩu.");
                    return;
                }
                user user = userBLL.Authenticate(tenDangNhap, matKhau);
                if (user != null)
                {//lưu thông tin người dùng vào Session
                    Session.CurrentUserId = user.userID; // Lưu thông tin người dùng vào Session
                    Session.CurrentUserName = user.Fullname;
                    //Kiểm tra quyền của người dùng có phải admin
                    Session.IsAdmin = userBLL.HasPermission(user.userID,"Admin");
                    Session.IsManager = userBLL.HasPermission(user.userID, "Manager");

                    // Mở form chính của ứng dụng
                    MainForm mainForm = new MainForm(user);
                    this.Hide(); // Ẩn form đăng nhập
                    mainForm.ShowDialog();
                    this.Close(); // Ẩn form đăng nhập
                }
                else
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu không đúng.");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi",
                MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

        }
        public static class Session
        {
            public static int CurrentUserId { get; set; }
            public static string CurrentUserName { get; set; }
            public static bool IsAdmin { get; set; }
            public static bool IsManager { get; set; }
        }
    }
}
